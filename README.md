# XML Helper Library
Simple and small XML helper library to serialize and deserialize objects. Targets the .NET Framework 3.0. It does not implement something new, but rather uses functions provided by the .NET Framework.

## Usage
Objects that should be serialized need the `[Serializable]` annotation. To conveniently serialize and deserialize objects to or from files you can inherit from the `XmlObject<T>` class.

```csharp
[Serializable]
public class ExampleObject : XmlObject<ExampleObject>
{
	public string AnyProperty { get; set; }
	public List<OtherObject> OtherObjects { get; set; }
}
```

Then you can use the static methods `SaveXML` and `LoadXML`.

```csharp
// Saving
ExampleObject objectToSerialize = new ExampleObject();
ExampleObject.SaveXML(objectToSerialize, "sample.xml");

// Loading
ExampleObject deserializedObject = ExampleObject.LoadXML("sample.xml");
```

If errors occur, an `XmlException` is thrown.

## Download
You can download the compiled assembly [here](https://github.com/sisakat/xml/releases/tag/1.0).