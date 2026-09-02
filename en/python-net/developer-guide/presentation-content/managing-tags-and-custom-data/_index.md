---
title: Manage Tags and Custom Data in Presentations with Python
linktitle: Tags and Custom Data
type: docs
weight: 300
url: /python-net/managing-tags-and-custom-data/
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
- Python
- Aspose.Slides
description: "Learn how to manage tags and custom XML data in PowerPoint presentations with Aspose.Slides for Python via .NET, including adding, reading, updating, auditing, and removing custom XML parts."
---

## **Overview**

This article explains how Aspose.Slides works with tags and custom data in PowerPoint presentations. Presentation-specific data can be stored as tags or custom XML parts. Tags are simple key-value string pairs, while custom XML parts can store structured metadata and application-specific XML payloads.

Aspose.Slides provides APIs for adding, reading, updating, auditing, and removing custom XML parts at the presentation, slide, and shape levels. Custom XML parts are useful for integrations that store information such as document-management identifiers, workflow state, compliance metadata, template-binding data, or other structured application data inside a presentation.

## **Data Storage in Presentation Files**

PPTX files—files with the `.pptx` extension—are stored in the PresentationML format, which is part of the Office Open XML specification. Office Open XML defines the package structure and relationships used to store presentation content and related data.

A presentation contains multiple parts connected by relationships. For example, a slide part contains the content of a single slide and can have explicit relationships to other parts defined by ISO/IEC 29500.

Custom data can be stored as tags ([TagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/)) or custom XML parts ([CustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/customxmlpartcollection/)). Both are available through the [`CustomData`](https://reference.aspose.com/slides/python-net/aspose.slides/customdata/) class.

{{% alert color="info" %}}

Tags store simple string key-value pairs. Custom XML parts store structured XML data and can be associated with a presentation, slide, or shape.

{{% /alert %}}

## **Work with Custom XML Parts**

The [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/python-net/aspose.slides/customdata/custom_xml_parts/) property returns the collection of custom XML parts associated with a particular presentation object. For example:

- `presentation.custom_data.custom_xml_parts` contains custom XML parts associated with the presentation itself.
- `slide.custom_data.custom_xml_parts` contains custom XML parts associated with a specific slide.
- `shape.custom_data.custom_xml_parts` contains custom XML parts associated with a specific shape.

Use [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/all_custom_xml_parts/) when you need to inspect all custom XML parts in the presentation regardless of where they are associated.

### **Add a Custom XML Part to a Presentation**

Use [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/python-net/aspose.slides/customxmlpartcollection/add/) to add XML data to a custom XML part collection. The XML must be valid and non-empty.

The following example adds structured metadata to the presentation-level custom data collection:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add assigns an identifier automatically. Set a specific GUID only when required.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

The `add` method can also accept XML as a byte array or stream, which is useful when XML content is already available in binary form.

### **Add a Custom XML Part to a Slide or Shape**

Custom XML data can be associated with a specific slide or shape instead of the whole presentation. This is useful when metadata describes only one object, such as a template key, external record identifier, or binding information.

The following example adds one custom XML part to a slide and another to a shape:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

The level at which a part is added determines which object's `custom_data.custom_xml_parts` collection contains the relationship to that part. Presentation-level data is appropriate for document-wide metadata, slide-level data for information that belongs to a particular slide, and shape-level data for metadata tied to an individual shape.

### **List and Audit All Custom XML Parts**

Use [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/all_custom_xml_parts/) to retrieve all custom XML parts from a presentation. Each [`CustomXmlPart`](https://reference.aspose.com/slides/python-net/aspose.slides/customxmlpart/) exposes its identifier, XML content, and associated namespace schemas.

The following example lists all custom XML parts and their namespace schemas:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/python-net/aspose.slides/customxmlpart/namespace_schemas/) returns the XML schemas associated with the custom XML part. This information can be useful when auditing presentations that contain XML produced by external systems.

### **Read and Update XML Content and ItemId**

Use [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/python-net/aspose.slides/customxmlpart/xml_as_string/) to work with XML as a UTF-8 string, or [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/python-net/aspose.slides/customxmlpart/xml_data/) to work with the raw XML bytes. Both properties can be read and updated.

The [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/python-net/aspose.slides/customxmlpart/item_id/) property contains the GUID that identifies the custom XML part in the Office Open XML document. It can also be changed when an integration requires a new identifier.

The following example updates the XML content and the identifier:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Read the current XML as text.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Update the XML as a UTF-8 string.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data provides the same XML content as raw bytes.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Replace the identifier when required by the integration.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

When assigning `xml_as_string` or `xml_data`, provide valid, non-empty XML. Use one representation or the other depending on whether the application works primarily with strings or byte data.

### **Remove a Custom XML Part**

Aspose.Slides provides several ways to remove custom XML data:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/python-net/aspose.slides/customxmlpart/remove/) removes the custom XML part from the presentation.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/python-net/aspose.slides/customxmlpartcollection/remove/) removes a specific part from a custom XML part collection.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/python-net/aspose.slides/customxmlpartcollection/remove_at/) removes the part at a specified collection index.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/python-net/aspose.slides/customxmlpartcollection/clear/) removes all parts from a specific collection.

The following example removes one presentation-level custom XML part by reference:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

If you already have a `CustomXmlPart` and want to remove that part from the presentation rather than addressing a particular collection, call `custom_xml_part.remove()`.

You can also remove an item by index:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Clear All Custom XML Parts from a Collection**

Use `clear` when all custom XML parts associated with a particular presentation object should be removed.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` affects only the selected collection. For example, clearing a slide's collection does not clear the presentation-level or shape-level collections.

To remove every custom XML part in the presentation, iterate through `all_custom_xml_parts` and remove each part:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Handle Linked or Shared Custom XML Parts**

In an Office Open XML presentation, the same custom XML part can be referenced from more than one presentation object. For example, an existing file can contain relationships from multiple slides or shapes to the same underlying custom XML part.

A shared part should be treated as one data object with multiple references:

- Updating its `xml_as_string`, `xml_data`, or `item_id` changes the underlying custom XML part, so the change applies wherever that part is referenced.
- `item_id` can be used to identify the same custom XML part while auditing object-level collections.
- Removing a part from a specific `custom_xml_parts` collection removes it from that collection. Use `CustomXmlPart.remove()` when the part itself should be removed from the presentation.
- Before deleting or replacing a shared part, inspect the object-level collections to determine whether other slides or shapes still reference it.

The `add` overloads create a new custom XML part from XML content; they do not accept an existing `CustomXmlPart`. Therefore, shared relationships are most commonly encountered when loading presentations that already contain them.

The following example audits presentation-, slide-, and shape-level collections by `item_id` and reports parts referenced from more than one place:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

This type of audit is useful before modifying or deleting custom XML data in presentations created by external systems, because the same metadata part may participate in more than one relationship.

## **Get Values of Tags**

In slides, a tag corresponds to the `DocumentProperties.keywords` property. This sample code shows how to get a tag value with Aspose.Slides for Python via .NET for [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Add Tags to Presentations**

Aspose.Slides allows you to add tags to presentations. A tag typically consists of two items:

- the name of a custom property, for example, `MyTag`;
- the value of the custom property, for example, `My Tag Value`.

If you need to classify presentations based on a specific rule or property, you can add tags for that purpose. For example, if you want to categorize presentations from North American countries, you can create a North American tag and assign the relevant country as its value.

This sample code shows how to add a tag to a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) using Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

Tags can also be set for a [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Or for an individual [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Limitations**

Tags added through the `custom_data.tags` collection are stored only in the PowerPoint file. They are **not** transferred to the PDF tag structure when the presentation is exported to PDF. Consequently, a custom identifier assigned as a tag cannot be retrieved from the tagged PDF.

**Workaround**: You can store a custom identifier in the object's **Alt Text** (for example, `shape.alternative_text = "MyId"`). After exporting to PDF, the Alt Text may appear in the PDF tag structure.

## **FAQ**

**Can I remove all tags from a presentation, slide, or shape in one operation?**

Yes. The [tag collection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) supports a [clear](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/clear/) operation that deletes all key-value pairs at once.

**How do I delete a single tag by its name without iterating over the whole collection?**

Use [remove(name)](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/remove/) on [TagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) to delete the tag by its key.

**How can I retrieve the complete list of tag names for analytics or filtering?**

Use [get_names_of_tags](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/get_names_of_tags/) on the [tag collection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/); it returns an array of all tag names.

**How can I find all custom XML parts regardless of where they are stored?**

Use [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/all_custom_xml_parts/) to retrieve all custom XML parts in the presentation.

**Should I use `xml_as_string` or `xml_data` to update a custom XML part?**

Use `xml_as_string` when the application works with UTF-8 XML text. Use `xml_data` when the XML is already available as a byte array or when binary-oriented processing is more convenient. Both properties represent the XML content of the same custom XML part.
