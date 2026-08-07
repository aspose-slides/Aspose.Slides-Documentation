---
title: Manage Tags and Custom Data in Presentations Using JavaScript
linktitle: Tags and Custom Data
type: docs
weight: 300
url: /nodejs-java/managing-tags-and-custom-data/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Learn how to manage tags and custom XML data in PowerPoint presentations with Aspose.Slides for Node.js via Java, including adding, reading, updating, auditing, and removing custom XML parts."
---

## **Overview**

This article explains how Aspose.Slides works with tags and custom data in PowerPoint presentations. Presentation-specific data can be stored as tags or custom XML parts. Tags are simple key-value string pairs, while custom XML parts can store structured metadata and application-specific XML payloads.

Aspose.Slides provides APIs for adding, reading, updating, auditing, and removing custom XML parts at the presentation, slide, and shape levels. Custom XML parts are useful for integrations that store information such as document-management identifiers, workflow state, compliance metadata, template-binding data, or other structured application data inside a presentation.

## **Data Storage in Presentation Files**

PPTX files—files with the `.pptx` extension—are stored in the PresentationML format, which is part of the Office Open XML specification. Office Open XML defines the package structure and relationships used to store presentation content and related data.

A presentation contains multiple parts connected by relationships. For example, a slide part contains the content of a single slide and can have explicit relationships to other parts defined by ISO/IEC 29500.

Custom data can be stored as tags ([TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/)) or custom XML parts ([CustomXmlPartCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/customxmlpartcollection/)). Both are available through the [`CustomData`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/customdata/) class.

{{% alert color="primary" %}}

Tags store simple string key-value pairs. Custom XML parts store structured XML data and can be associated with a presentation, slide, or shape.

{{% /alert %}}

## **Work with Custom XML Parts**

The `getCustomXmlParts()` method of [`CustomData`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/customdata/) returns the collection of custom XML parts associated with a particular presentation object. For example:

- `presentation.getCustomData().getCustomXmlParts()` contains custom XML parts associated with the presentation itself.
- `slide.getCustomData().getCustomXmlParts()` contains custom XML parts associated with a specific slide.
- `shape.getCustomData().getCustomXmlParts()` contains custom XML parts associated with a specific shape.

Use [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) when you need to inspect all custom XML parts in the presentation regardless of where they are associated.

### **Add a Custom XML Part to a Presentation**

Use the `add` method of [`CustomXmlPartCollection`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/customxmlpartcollection/) to add XML data to a custom XML part collection. The XML must be valid and non-empty.

The following example adds structured metadata to the presentation-level custom data collection:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add assigns an identifier automatically. Set a specific UUID only when required.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The `add` method can also accept XML as a byte array, which is useful when XML content is already available in binary form.

### **Add a Custom XML Part to a Slide or Shape**

Custom XML data can be associated with a specific slide or shape instead of the whole presentation. This is useful when metadata describes only one object, such as a template key, external record identifier, or binding information.

The following example adds one custom XML part to a slide and another to a shape:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The level at which a part is added determines which object's `getCustomData().getCustomXmlParts()` collection contains the relationship to that part. Presentation-level data is appropriate for document-wide metadata, slide-level data for information that belongs to a particular slide, and shape-level data for metadata tied to an individual shape.

### **List and Audit All Custom XML Parts**

Use [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) to retrieve all custom XML parts from a presentation. Each [`CustomXmlPart`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/customxmlpart/) exposes its identifier, XML content, and associated namespace schemas.

The following example lists all custom XML parts and their namespace schemas:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

[`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/customxmlpart/) returns the XML schemas associated with the custom XML part. This information can be useful when auditing presentations that contain XML produced by external systems.

### **Read and Update XML Content and ItemId**

Use `getXmlAsString()` and `setXmlAsString()` from [`CustomXmlPart`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/customxmlpart/) to work with XML as a UTF-8 string, or `getXmlData()` and `setXmlData()` to work with the raw XML bytes.

The `getItemId()` method returns the UUID that identifies the custom XML part in the Office Open XML document. Use `setItemId()` when an integration requires a new identifier.

The following example updates the XML content and the identifier:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Read the current XML as text.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Update the XML as a UTF-8 string.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData provides the same XML content as raw bytes.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Replace the identifier when required by the integration.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

When calling `setXmlAsString` or `setXmlData`, provide valid, non-empty XML. Use one representation or the other depending on whether the application works primarily with strings or byte data.

### **Remove a Custom XML Part**

Aspose.Slides provides several ways to remove custom XML data:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/customxmlpart/) removes the custom XML part from the presentation.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/customxmlpartcollection/) removes a specific part from a custom XML part collection.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/customxmlpartcollection/) removes the part at a specified collection index.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/customxmlpartcollection/) removes all parts from a specific collection.

The following example removes one presentation-level custom XML part by reference:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

If you already have a `CustomXmlPart` and want to remove that part from the presentation rather than addressing a particular collection, call `customXmlPart.remove()`.

You can also remove an item by index:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Clear All Custom XML Parts from a Collection**

Use `clear` when all custom XML parts associated with a particular presentation object should be removed.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` affects only the selected collection. For example, clearing a slide's collection does not clear the presentation-level or shape-level collections.

To remove every custom XML part in the presentation, iterate through `getAllCustomXmlParts()` and remove each part:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Handle Linked or Shared Custom XML Parts**

In an Office Open XML presentation, the same custom XML part can be referenced from more than one presentation object. For example, an existing file can contain relationships from multiple slides or shapes to the same underlying custom XML part.

A shared part should be treated as one data object with multiple references:

- Updating it with `setXmlAsString`, `setXmlData`, or `setItemId` changes the underlying custom XML part, so the change applies wherever that part is referenced.
- `getItemId()` can be used to identify the same custom XML part while auditing object-level collections.
- Removing a part from a specific `getCustomXmlParts()` collection removes it from that collection. Use `CustomXmlPart.remove()` when the part itself should be removed from the presentation.
- Before deleting or replacing a shared part, inspect the object-level collections to determine whether other slides or shapes still reference it.

The `add` overloads create a new custom XML part from XML content; they do not accept an existing `CustomXmlPart`. Therefore, shared relationships are most commonly encountered when loading presentations that already contain them.

The following example audits presentation-, slide-, and shape-level collections by `ItemId` and reports parts referenced from more than one place:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

This type of audit is useful before modifying or deleting custom XML data in presentations created by external systems, because the same metadata part may participate in more than one relationship.

## **Get Values of Tags**

In slides, a tag corresponds to the `DocumentProperties.getKeywords()` method. This sample code shows how to get a tag value with Aspose.Slides for Node.js via Java for [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Add Tags to Presentations**

Aspose.Slides allows you to add tags to presentations. A tag typically consists of two items:

- the name of a custom property, for example, `MyTag`;
- the value of the custom property, for example, `My Tag Value`.

If you need to classify presentations based on a specific rule or property, you can add tags for that purpose. For example, if you want to categorize presentations from North American countries, you can create a North American tag and assign the relevant country as its value.

This sample code shows how to add a tag to a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) using Aspose.Slides for Node.js via Java:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Tags can also be set for a [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Or for an individual [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Limitations**

Tags added through the `getCustomData().getTags()` collection are stored only in the PowerPoint file. They are **not** transferred to the PDF tag structure when the presentation is exported to PDF. Consequently, a custom identifier assigned as a tag cannot be retrieved from the tagged PDF.

**Workaround**: You can store a custom identifier in the object's **Alt Text** (for example, `shape.setAlternativeText("MyId")`). After exporting to PDF, the Alt Text may appear in the PDF tag structure.

## **FAQ**

**Can I remove all tags from a presentation, slide, or shape in one operation?**

Yes. The [tag collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) supports a [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) operation that deletes all key-value pairs at once.

**How do I delete a single tag by its name without iterating over the whole collection?**

Use `remove(name)` on the [tag collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) to delete the tag by its key.

**How can I retrieve the complete list of tag names for analytics or filtering?**

Use `getNamesOfTags()` on the [tag collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/); it returns an array of all tag names.

**How can I find all custom XML parts regardless of where they are stored?**

Use [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) to retrieve all custom XML parts in the presentation.

**Should I use `getXmlAsString`/`setXmlAsString` or `getXmlData`/`setXmlData` to update a custom XML part?**

Use `getXmlAsString` and `setXmlAsString` when the application works with UTF-8 XML text. Use `getXmlData` and `setXmlData` when the XML is already available as a byte array or when binary-oriented processing is more convenient. Both representations refer to the XML content of the same custom XML part.
