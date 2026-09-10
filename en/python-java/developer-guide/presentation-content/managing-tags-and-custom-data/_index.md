---
title: Manage Tags and Custom Data in Presentations Using Python
linktitle: Tags and Custom Data
type: docs
weight: 300
url: /python-java/managing-tags-and-custom-data/
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
description: "Learn how to manage tags and custom XML data in PowerPoint presentations with Aspose.Slides for Python via Java, including adding, reading, updating, auditing, and removing custom XML parts."
---

## **Overview**

This article explains how Aspose.Slides works with tags and custom data in PowerPoint presentations. Presentation-specific data can be stored as tags or custom XML parts. Tags are simple key-value string pairs, while custom XML parts can store structured metadata and application-specific XML payloads.

Aspose.Slides provides APIs for adding, reading, updating, auditing, and removing custom XML parts at the presentation, slide, and shape levels. Custom XML parts are useful for integrations that store information such as document-management identifiers, workflow state, compliance metadata, template-binding data, or other structured application data inside a presentation.

## **Data Storage in Presentation Files**

PPTX files—files with the `.pptx` extension—are stored in the PresentationML format, which is part of the Office Open XML specification. Office Open XML defines the package structure and relationships used to store presentation content and related data.

A presentation contains multiple parts connected by relationships. For example, a slide part contains the content of a single slide and can have explicit relationships to other parts defined by ISO/IEC 29500.

Custom data can be stored as tags ([TagCollection](https://reference.aspose.com/slides/python-java/aspose.slides/tagcollection/)) or custom XML parts ([CustomXmlPartCollection](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpartcollection/)). Both are available through the [CustomData](https://reference.aspose.com/slides/python-java/aspose.slides/customdata/) class.

{{% alert color="info" title="Note" %}}

Tags store simple string key-value pairs. Custom XML parts store structured XML data and can be associated with a presentation, slide, or shape.

{{% /alert %}}

## **Work with Custom XML Parts**

The [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/python-java/aspose.slides/customdata/#getCustomXmlParts) method returns the collection of custom XML parts associated with a particular presentation object. For example:

- The presentation’s [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/python-java/aspose.slides/customdata/#getCustomXmlParts) collection contains custom XML parts associated with the presentation itself.
- The slide’s [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/python-java/aspose.slides/customdata/#getCustomXmlParts) collection contains custom XML parts associated with a specific slide.
- The shape’s [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/python-java/aspose.slides/customdata/#getCustomXmlParts) collection contains custom XML parts associated with a specific shape.

Use [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAllCustomXmlParts) when you need to inspect all custom XML parts in the presentation regardless of where they are associated.

### **Add a Custom XML Part to a Presentation**

Use [CustomXmlPartCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpartcollection/#add) to add XML data to a custom XML part collection. The XML must be valid and non-empty.

The following example adds structured metadata to the presentation-level custom data collection:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add assigns an identifier automatically. Set a specific UUID only when required.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The [add](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpartcollection/#add) method can also accept XML as a byte array or input stream, which is useful when XML content is already available in binary form.

### **Add a Custom XML Part to a Slide or Shape**

Custom XML data can be associated with a specific slide or shape instead of the whole presentation. This is useful when metadata describes only one object, such as a template key, external record identifier, or binding information.

The following example adds one custom XML part to a slide and another to a shape:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The level at which a part is added determines which object's [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/python-java/aspose.slides/customdata/#getCustomXmlParts) collection contains the relationship to that part. Presentation-level data is appropriate for document-wide metadata, slide-level data for information that belongs to a particular slide, and shape-level data for metadata tied to an individual shape.

### **List and Audit All Custom XML Parts**

Use [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAllCustomXmlParts) to retrieve all custom XML parts from a presentation. Each [CustomXmlPart](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/) exposes its identifier, XML content, and associated namespace schemas.

The following example lists all custom XML parts and their namespace schemas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) returns the XML schemas associated with the custom XML part. This information can be useful when auditing presentations that contain XML produced by external systems.

### **Read and Update XML Content and ItemId**

Use [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#getXmlAsString) and [setXmlAsString](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#setXmlAsString) to work with XML as a UTF-8 string, or [getXmlData](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#getXmlData) and [setXmlData](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#setXmlData) to work with the raw XML bytes.

The [CustomXmlPart.getItemId](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#getItemId) method returns the UUID that identifies the custom XML part in the Office Open XML document. Use [setItemId](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#setItemId) when an integration requires a new identifier.

The following example updates the XML content and the identifier:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # Read the current XML as text.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # Update the XML as a UTF-8 string.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData provides the same XML content as raw bytes.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Replace the identifier when required by the integration.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

When calling [setXmlAsString](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#setXmlAsString) or [setXmlData](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#setXmlData), provide valid, non-empty XML. Use one representation or the other depending on whether the application works primarily with strings or byte data.

### **Remove a Custom XML Part**

Aspose.Slides provides several ways to remove custom XML data:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#remove) removes the custom XML part from the presentation.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpartcollection/#remove) removes a specific part from a custom XML part collection.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpartcollection/#removeAt) removes the part at a specified collection index.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpartcollection/#clear) removes all parts from a specific collection.

The following example removes one presentation-level custom XML part by reference:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

If you already have a [CustomXmlPart](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/) and want to remove that part from the presentation rather than addressing a particular collection, call [CustomXmlPart.remove](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#remove).

You can also remove an item by index:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **Clear All Custom XML Parts from a Collection**

Use [clear](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpartcollection/#clear) when all custom XML parts associated with a particular presentation object should be removed.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpartcollection/#clear) affects only the selected collection. For example, clearing a slide's collection does not clear the presentation-level or shape-level collections.

To remove every custom XML part in the presentation, iterate through [getAllCustomXmlParts](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAllCustomXmlParts) and remove each part:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Handle Linked or Shared Custom XML Parts**

In an Office Open XML presentation, the same custom XML part can be referenced from more than one presentation object. For example, an existing file can contain relationships from multiple slides or shapes to the same underlying custom XML part.

A shared part should be treated as one data object with multiple references:

- Updating it with [setXmlAsString](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#setXmlData), or [setItemId](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#setItemId) changes the underlying custom XML part, so the change applies wherever that part is referenced.
- [getItemId](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#getItemId) can be used to identify the same custom XML part while auditing object-level collections.
- Removing a part from a specific [getCustomXmlParts](https://reference.aspose.com/slides/python-java/aspose.slides/customdata/#getCustomXmlParts) collection removes it from that collection. Use [CustomXmlPart.remove](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#remove) when the part itself should be removed from the presentation.
- Before deleting or replacing a shared part, inspect the object-level collections to determine whether other slides or shapes still reference it.

The [add](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpartcollection/#add) overloads create a new custom XML part from XML content; they do not accept an existing [CustomXmlPart](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/). Therefore, shared relationships are most commonly encountered when loading presentations that already contain them.

The following example audits presentation-, slide-, and shape-level collections by `ItemId` and reports parts referenced from more than one place:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

This type of audit is useful before modifying or deleting custom XML data in presentations created by external systems, because the same metadata part may participate in more than one relationship.

## **Get Values of Tags**

In slides, a tag corresponds to the [DocumentProperties.getKeywords](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getKeywords) method. This sample code shows how to get a tag value with Aspose.Slides for Python via Java for [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **Add Tags to Presentations**

Aspose.Slides allows you to add tags to presentations. A tag typically consists of two items:

- the name of a custom property, for example, `MyTag`;
- the value of the custom property, for example, `My Tag Value`.

If you need to classify presentations based on a specific rule or property, you can add tags for that purpose. For example, if you want to categorize presentations from North American countries, you can create a North American tag and assign the relevant country as its value.

This sample code shows how to add a tag to a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) using Aspose.Slides for Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

Tags can also be set for a [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

Or for an individual [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **Limitations**

Tags added through the [CustomData.getTags](https://reference.aspose.com/slides/python-java/aspose.slides/customdata/#getTags) collection are stored only in the PowerPoint file. They are **not** transferred to the PDF tag structure when the presentation is exported to PDF. Consequently, a custom identifier assigned as a tag cannot be retrieved from the tagged PDF.

**Workaround**: You can store a custom identifier in the object's **Alt Text** (for example, [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) with the value `"MyId"`). After exporting to PDF, the Alt Text may appear in the PDF tag structure.

## **FAQ**

**Can I remove all tags from a presentation, slide, or shape in one operation?**

Yes. The [tag collection](https://reference.aspose.com/slides/python-java/aspose.slides/tagcollection/) supports a [clear](https://reference.aspose.com/slides/python-java/aspose.slides/tagcollection/#clear) operation that deletes all key-value pairs at once.

**How do I delete a single tag by its name without iterating over the whole collection?**

Use [remove](https://reference.aspose.com/slides/python-java/aspose.slides/tagcollection/#remove) on the [tag collection](https://reference.aspose.com/slides/python-java/aspose.slides/tagcollection/) to delete the tag by its key.

**How can I retrieve the complete list of tag names for analytics or filtering?**

Use [getNamesOfTags](https://reference.aspose.com/slides/python-java/aspose.slides/tagcollection/#getNamesOfTags) on the [tag collection](https://reference.aspose.com/slides/python-java/aspose.slides/tagcollection/); it returns an array of all tag names.

**How can I find all custom XML parts regardless of where they are stored?**

Use [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAllCustomXmlParts) to retrieve all custom XML parts in the presentation.

**Should I use [getXmlAsString](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#getXmlAsString)/[setXmlAsString](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#setXmlAsString) or [getXmlData](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#getXmlData)/[setXmlData](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#setXmlData) to update a custom XML part?**

Use [getXmlAsString](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#getXmlAsString) and [setXmlAsString](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#setXmlAsString) when the application works with UTF-8 XML text. Use [getXmlData](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#getXmlData) and [setXmlData](https://reference.aspose.com/slides/python-java/aspose.slides/customxmlpart/#setXmlData) when the XML is already available as a byte array or when binary-oriented processing is more convenient. Both representations refer to the XML content of the same custom XML part.
