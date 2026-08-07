---
title: Manage Tags and Custom Data in Presentations in .NET
linktitle: Tags and Custom Data
type: docs
weight: 300
url: /net/managing-tags-and-custom-data/
keywords:
- document properties
- tag
- custom data
- custom XML
- custom XML part
- XML metadata
- ItemId
- add tag
- pair values
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to manage tags and custom XML data in PowerPoint presentations with Aspose.Slides for .NET, including adding, reading, updating, auditing, and removing custom XML parts."
---

## **Overview**

This article explains how Aspose.Slides works with tags and custom data in PowerPoint presentations. Presentation-specific data can be stored as tags or custom XML parts. Tags are simple key-value string pairs, while custom XML parts can store structured metadata and application-specific XML payloads.

Aspose.Slides provides APIs for adding, reading, updating, auditing, and removing custom XML parts at the presentation, slide, and shape levels. Custom XML parts are useful for integrations that store information such as document-management identifiers, workflow state, compliance metadata, template-binding data, or other structured application data inside a presentation.

## **Data Storage in Presentation Files**

PPTX files—files with the `.pptx` extension—are stored in the PresentationML format, which is part of the Office Open XML specification. Office Open XML defines the package structure and relationships used to store presentation content and related data.

A presentation contains multiple parts connected by relationships. For example, a slide part contains the content of a single slide and can have explicit relationships to other parts defined by ISO/IEC 29500.

Custom data can be stored as tags ([ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)) or custom XML parts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)). Both are available through the [`ICustomData`](https://reference.aspose.com/slides/net/aspose.slides/icustomdata/) interface.

{{% alert color="primary" %}}

Tags store simple string key-value pairs. Custom XML parts store structured XML data and can be associated with a presentation, slide, or shape.

{{% /alert %}}

## **Work with Custom XML Parts**

The [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/net/aspose.slides/icustomdata/customxmlparts/) property returns the collection of custom XML parts associated with a particular presentation object. For example:

- `presentation.CustomData.CustomXmlParts` contains custom XML parts associated with the presentation itself.
- `slide.CustomData.CustomXmlParts` contains custom XML parts associated with a specific slide.
- `shape.CustomData.CustomXmlParts` contains custom XML parts associated with a specific shape.

Use [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/net/aspose.slides/presentation/allcustomxmlparts/) when you need to inspect all custom XML parts in the presentation regardless of where they are associated.

### **Add a Custom XML Part to a Presentation**

Use [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection/add/) to add XML data to a custom XML part collection. The XML must be valid and non-empty.

The following example adds structured metadata to the presentation-level custom data collection:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add assigns an identifier automatically. Set a specific GUID only when required.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

The `Add` method can also accept XML as a byte array or stream, which is useful when XML content is already available in binary form.

### **Add a Custom XML Part to a Slide or Shape**

Custom XML data can be associated with a specific slide or shape instead of the whole presentation. This is useful when metadata describes only one object, such as a template key, external record identifier, or binding information.

The following example adds one custom XML part to a slide and another to a shape:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

The level at which a part is added determines which object's `CustomData.CustomXmlParts` collection contains the relationship to that part. Presentation-level data is appropriate for document-wide metadata, slide-level data for information that belongs to a particular slide, and shape-level data for metadata tied to an individual shape.

### **List and Audit All Custom XML Parts**

Use [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/net/aspose.slides/presentation/allcustomxmlparts/) to retrieve all custom XML parts from a presentation. Each [`ICustomXmlPart`](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpart/) exposes its identifier, XML content, and associated namespace schemas.

The following example lists all custom XML parts and their namespace schemas:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpart/namespaceschemas/) returns the XML schemas associated with the custom XML part. This information can be useful when auditing presentations that contain XML produced by external systems.

### **Read and Update XML Content and ItemId**

Use [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpart/xmlasstring/) to work with XML as a UTF-8 string, or [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpart/xmldata/) to work with the raw XML bytes. Both properties can be read and updated.

The [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpart/itemid/) property contains the GUID that identifies the custom XML part in the Office Open XML document. It can also be changed when an integration requires a new identifier.

The following example updates the XML content and the identifier:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Read the current XML as text.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Update the XML as a UTF-8 string.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData provides the same XML content as raw bytes.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Replace the identifier when required by the integration.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

When assigning `XmlAsString` or `XmlData`, provide valid, non-empty XML. Use one representation or the other depending on whether the application works primarily with strings or byte data.

### **Remove a Custom XML Part**

Aspose.Slides provides several ways to remove custom XML data:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpart/remove/) removes the custom XML part from the presentation.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection/remove/) removes a specific part from a custom XML part collection.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection/removeat/) removes the part at a specified collection index.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection/clear/) removes all parts from a specific collection.

The following example removes one presentation-level custom XML part by reference:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

If you already have an `ICustomXmlPart` and want to remove that part from the presentation rather than addressing a particular collection, call `customXmlPart.Remove()`.

You can also remove an item by index:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Clear All Custom XML Parts from a Collection**

Use `Clear` when all custom XML parts associated with a particular presentation object should be removed.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` affects only the selected collection. For example, clearing a slide's collection does not clear the presentation-level or shape-level collections.

To remove every custom XML part in the presentation, iterate through `AllCustomXmlParts` and remove each part:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Handle Linked or Shared Custom XML Parts**

In an Office Open XML presentation, the same custom XML part can be referenced from more than one presentation object. For example, an existing file can contain relationships from multiple slides or shapes to the same underlying custom XML part.

A shared part should be treated as one data object with multiple references:

- Updating its `XmlAsString`, `XmlData`, or `ItemId` changes the underlying custom XML part, so the change applies wherever that part is referenced.
- `ItemId` can be used to identify the same custom XML part while auditing object-level collections.
- Removing a part from a specific `CustomXmlParts` collection removes it from that collection. Use `ICustomXmlPart.Remove()` when the part itself should be removed from the presentation.
- Before deleting or replacing a shared part, inspect the object-level collections to determine whether other slides or shapes still reference it.

The `Add` overloads create a new custom XML part from XML content; they do not accept an existing `ICustomXmlPart`. Therefore, shared relationships are most commonly encountered when loading presentations that already contain them.

The following example audits presentation-, slide-, and shape-level collections by `ItemId` and reports parts referenced from more than one place:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

This type of audit is useful before modifying or deleting custom XML data in presentations created by external systems, because the same metadata part may participate in more than one relationship.

## **Get Values of Tags**

In slides, a tag corresponds to the `IDocumentProperties.Keywords` property. This sample code shows how to get a tag value with Aspose.Slides for .NET for [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Add Tags to Presentations**

Aspose.Slides allows you to add tags to presentations. A tag typically consists of two items:

- the name of a custom property, for example, `MyTag`;
- the value of the custom property, for example, `My Tag Value`.

If you need to classify presentations based on a specific rule or property, you can add tags for that purpose. For example, if you want to categorize presentations from North American countries, you can create a North American tag and assign the relevant country as its value.

This sample code shows how to add a tag to a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) using Aspose.Slides for .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Tags can also be set for a [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Or for an individual [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Limitations**

Tags added through the `CustomData.Tags` collection are stored only in the PowerPoint file. They are **not** transferred to the PDF tag structure when the presentation is exported to PDF. Consequently, a custom identifier assigned as a tag cannot be retrieved from the tagged PDF.

**Workaround**: You can store a custom identifier in the object's **Alt Text** (for example, `shape.AlternativeText = "MyId"`). After exporting to PDF, the Alt Text may appear in the PDF tag structure.

## **FAQ**

**Can I remove all tags from a presentation, slide, or shape in one operation?**

Yes. The [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) supports a [Clear](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/clear/) operation that deletes all key-value pairs at once.

**How do I delete a single tag by its name without iterating over the whole collection?**

Use [Remove(name)](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/remove/) on [TagCollection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) to delete the tag by its key.

**How can I retrieve the complete list of tag names for analytics or filtering?**

Use [GetNamesOfTags](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/getnamesoftags/) on the [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/); it returns an array of all tag names.

**How can I find all custom XML parts regardless of where they are stored?**

Use [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/net/aspose.slides/presentation/allcustomxmlparts/) to retrieve all custom XML parts in the presentation.

**Should I use `XmlAsString` or `XmlData` to update a custom XML part?**

Use `XmlAsString` when the application works with UTF-8 XML text. Use `XmlData` when the XML is already available as a byte array or when binary-oriented processing is more convenient. Both properties represent the XML content of the same custom XML part.
