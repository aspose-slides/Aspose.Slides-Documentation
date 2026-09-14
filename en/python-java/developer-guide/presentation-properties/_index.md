---
title: Manage Presentation Properties in Python
linktitle: Presentation Properties
type: docs
weight: 70
url: /python-java/presentation-properties/
keywords:
- PowerPoint properties
- presentation properties
- document properties
- built-in properties
- custom properties
- advanced properties
- manage properties
- modify properties
- document metadata
- edit metadata
- proofing language
- default language
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Master presentation properties in Aspose.Slides for Python via Java and streamline search, branding and workflow in your PowerPoint and OpenDocument files."
---

## **Introduction**

Aspose.Slides supports two types of document properties: **Built-in** and **Custom**. Both of these property types can easily be accessed and managed using the Aspose.Slides API.

Aspose.Slides allows you to work with presentation document properties through the [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) class. An instance of this class is returned by [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). The following examples show how to read, modify, and manage these properties.

{{% alert color="info" title="Note" %}}

Please note that the **Application** and **AppVersion** fields cannot be modified. Aspose.Slides rewrites them on every save, so a saved presentation always reports "Aspose.Slides for Java" and the version of the library that produced it. Any value passed to [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setNameOfApplication) is discarded when the presentation is written.

{{% /alert %}}

## **Document Properties in PowerPoint**

Microsoft PowerPoint 2007 allows you to manage the document properties of presentation files. Click the Office icon and select **Prepare | Properties | Advanced Properties**, as shown below:

|**Selecting Advanced Properties menu item**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|
After you select **Advanced Properties**, a dialog appears where you can manage the document properties of the PowerPoint file:

|**Properties Dialog**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|
The **Properties Dialog** contains tabs such as **General**, **Summary**, **Statistics**, **Contents**, and **Custom**. These tabs let you configure different kinds of information about PowerPoint files. Use the **Custom** tab to manage custom properties.

## **Work with Document Properties Using Aspose.Slides for Python via Java**

As described earlier, Aspose.Slides for Python via Java supports both **Built-in** and **Custom** document properties. The [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) class represents the document properties associated with a presentation file.

Use [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) to access these properties as described below.

## **Read Public Properties from an Encrypted Presentation**

An opening password normally protects both presentation content and document properties. When a presentation is encrypted by passing `false` to [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), its document properties remain public. An application can then pass `true` to [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) and read the public metadata without supplying the opening password.

The document-properties-only option controls what Aspose.Slides loads; it does not decrypt anything. If the properties were included in encryption, loading them without the password fails. If the presentation is not encrypted, the option is ignored and the complete presentation is loaded.

The following example verifies the loading mode through [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) and then reads built-in properties through [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

In this mode, slide content is not loaded. Slides, masters, layouts, shapes, media, and other presentation objects are unavailable. Applications should always check [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) before performing an operation that requires the complete presentation object model.

{{% alert color="warning" title="Warning" %}}
Public metadata may expose author names, titles, subjects, keywords, company information, comments, and custom values. Encrypt sensitive properties together with the presentation. Leave them public only when indexing, classification, search, or document-management systems have a specific requirement to access them without a password.
{{% /alert %}}

## **Update Properties of an Encrypted Presentation**

For an encrypted PPTX file, a presentation loaded in document-properties-only mode is intended for reading public metadata. Aspose.Slides cannot save changed properties from that metadata-only object because the public properties must remain consistent with the corresponding data inside the encrypted presentation. Updating them therefore requires the correct opening password and a complete load.

The following example opens the presentation with [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword), updates public built-in properties, and saves the result. It then uses [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) to verify that encryption is preserved and reopens the public metadata without a password to verify the new values:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

If an application is not allowed to decrypt or load the presentation content, it must treat public properties of an encrypted PPTX file as read-only.

## **Access Built-in Properties**

The built-in properties exposed by [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) include: **Creator** (Author), **Description**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject**, and **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Instantiate the Presentation class that represents the presentation
presentation = Presentation("Presentation.pptx")
try:
    # Create a reference to DocumentProperties object associated with Presentation
    properties = presentation.getDocumentProperties()

    # Display the built-in properties
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Modify Built-in Properties**

Modifying built-in properties is as straightforward as accessing them. Use the corresponding setter to assign a new value. The following example modifies built-in document properties using Aspose.Slides for Python via Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Create a reference to DocumentProperties object associated with Presentation
    properties = presentation.getDocumentProperties()

    # Set the built-in properties
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Save your presentation to a file
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

This example modifies the built-in properties of the presentation that can be viewed as shown below:

|**Built-in document properties after modification**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **Add Custom Document Properties**

Aspose.Slides for Python via Java also allows developers to add custom document properties to presentations. The example below adds three custom properties, then looks up the name stored at index 2 and removes that property, so the saved presentation keeps two of them. Custom properties are indexed in alphabetical order, not in the order they were added.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Getting Document Properties
    properties = presentation.getDocumentProperties()

    # Adding Custom properties
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Getting property name at particular index
    property_name = properties.getCustomPropertyName(2)

    # Removing selected property
    properties.removeCustomProperty(property_name)

    # Saving presentation
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Custom Document Properties Added**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **Access and Modify Custom Properties**

Aspose.Slides for Python via Java also allows developers to access the values of custom properties. The following example shows how to access and modify all custom properties in a presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Create a reference to DocumentProperties object associated with Presentation
    properties = presentation.getDocumentProperties()

    # Access and modify custom properties
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Display names and values of custom properties
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Modify values of custom properties
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Save your presentation to a file
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

This example modifies the custom properties of the [PPTX](https://docs.fileformat.com/presentation/pptx/) presentation. The following figures show the presentation custom properties before and after modification:

|**Custom Properties before Modification**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|


|**Custom Properties after Modification**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **Advanced Document Properties**

{{% alert color="info" title="Note" %}}

New methods [readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), and [writeBindedPresentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) have been added to the [PresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/), and the behavior of the [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setLastSavedTime) method has changed.

{{% /alert %}}

The two new methods [readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) and [updateDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) have been added to the [PresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/) class. They provide quick access to document properties and allow you to change and update properties without loading the whole presentation.

The typical workflow of loading properties, changing their values, and updating the document can be implemented as follows:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Read the presentation information
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Obtain the current properties
properties = presentation_info.readDocumentProperties()

# Set the new values of the Author and Title fields
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Update the presentation with the new values
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

There is another way to use properties of a particular presentation as a template to update properties in other presentations:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

A new template can be created from scratch and then used to update multiple presentations:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **Set Proofing Language**

Aspose.Slides provides the [PortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setLanguageId) method to allow you to set the proofing language for a PowerPoint document. The proofing language is the language for which spelling and grammar in the presentation are checked.

This Python code shows you how to set the proofing language for a PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # set the Id of a proofing language

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Set Default Language**

This Python code shows you how to set the default language for an entire PowerPoint presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # Adds a rectangle shape with text
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Checks the first portion language
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Live Example**

Try the [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) online app to see how to work with document properties through the Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**How can I remove a built-in property from a presentation?**

Built-in properties are an integral part of the presentation and cannot be removed entirely. However, you can either change their values or set them to empty if allowed by the specific property.

**What happens if I add a custom property that already exists?**

If you add a custom property that already exists, its existing value will be overwritten with the new one. You do not need to remove or check the property beforehand, as Aspose.Slides automatically updates the property's value.

**Can I access presentation properties without fully loading the presentation?**

Yes. Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) and then [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) to read stored document metadata without creating a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) instance. See [Build a Lightweight Presentation Inventory](/slides/python-java/examine-presentation/) for a complete reporting example and format-specific limitations.

**Can I read public properties of an encrypted presentation without its opening password?**

Yes. Document-property encryption must have been disabled before the presentation was encrypted, and the presentation must be loaded in document-properties-only mode.

**Can I update an encrypted PPTX file in document-properties-only mode?**

No. Public and encrypted property data must remain consistent, so updating an encrypted PPTX file requires loading the complete presentation with the correct opening password.
