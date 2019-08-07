# XML Helper Library
simple and small xml helper library for the .NET Framework 3.0
Simple and small XML helper library to serialize and deserialize objects. Targets the .NET Framework 3.0.

## Usage
Objects that should serializable need the `[Serializable]` annotation. To conviniently serialize and deserialize objects to or from files you can inherit from the `XmlObject<T>` class.

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