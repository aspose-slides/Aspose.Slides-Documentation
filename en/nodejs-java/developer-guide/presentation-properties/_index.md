---
title: Presentation Properties
type: docs
weight: 70
url: /nodejs-java/presentation-properties/
keywords:
- PowerPoint properties
- presentation properties
- document properties
- built-in properties
- custom properties
- advanced properties
- modify properties
- document metadata
- edit metadata
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "Manage PowerPoint presentation properties in JavaScript"
---

{{% alert color="primary" %}} 

Microsoft PowerPoint provides a feature to add some properties to the presentation files. These document properties allow some useful information to be stored along with the documents (presentation files). There are two kinds of document properties as follows

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

**Built-in** properties contain general information about the document like document title, author's name, document statistics and so on. **Custom** properties are those ones, which are defined by the users as **Name/Value** pairs, where both name and value are defined by the user. Using Aspose.Slides for Node.js via Java, developers can access and modify the values of built-in properties as well as custom properties.

{{% /alert %}} 

## **Document Properties in PowerPoint**

Microsoft PowerPoint 2007 allows managing the document properties of the presentation files. All you have to do is to click the Office icon and further **Prepare | Properties | Advanced Properties** menu item of the Microsoft PowerPoint 2007 as shown below:

{{% alert color="primary" %}} 

Please note that you cannot set values against the **Application** and **Producer** fields, because Aspose Ltd. and Aspose.Slides for Node.js via Java x.x.x will be displayed against these fields.

{{% /alert %}} 

|**Selecting Advanced Properties menu item**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
After you select **Advanced Properties** menu item, a dialog would appear allowing you to manage the document properties of the PowerPoint file as shown below in the figure:

|**Properties Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
In the above **Properties Dialog**, you can see that there are many tab pages like **General**, **Summary**, **Statistics**, **Contents** and **Custom**. All these tab pages allow configuring different kinds of information related to the PowerPoint files. **Custom** tab is used to manage the custom properties of the PowerPoint files.

Working with Document Properties Using Aspose.Slides for Node.js via Java

As we have described earlier that Aspose.Slides for Node.js via Java supports two kinds of document properties, which are **Built-in** and **Custom** properties. So, developers can access both kinds of properties with the use of Aspose.Slides for Node.js via Java API. Aspose.Slides for Node.js via Java provides a class [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties) that represents the document properties associated with a presentation file through **Presentation.DocumentProperties** property.

Developers can use **DocumentProperties** property exposed by [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) object to access the document properties of the presentation files as described below:

## **Access Built-in Properties**

These properties as exposed by [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties) object include: **Creator** (Author), **Description**, **Keywords** **Created** (Creation Date), **Modified** Modification Date, **Printed** Last Print Date, **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** and **Title**

```javascript
// Instantiate the Presentation class that represents the presentation
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Create a reference to IDocumentProperties object associated with Presentation
    var dp = pres.getDocumentProperties();
    // Display the built-in properties
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modify Built-in Properties**

Modifying the built-in properties of presentation files is as easy as that of accessing them. You can simply assign a string value to any desired property and the property value would be modified. In the example given below, we have demonstrated how we can modify the built-in document properties of the presentation file using Aspose.Slides for Node.js via Java.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Create a reference to IDocumentProperties object associated with Presentation
    var dp = pres.getDocumentProperties();
    // Set the built-in properties
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Save your presentation to a file
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

This example modifies the built-in properties of the presentation that can be viewed as shown below:

|**Built-in document properties after modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Add Custom Document Properties**

Aspose.Slides for Node.js via Java also allows developers to add the custom the values for presentation Document properties. An example is given below that shows how to set the custom properties for a presentation.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Getting Document Properties
    var dProps = pres.getDocumentProperties();
    // Adding Custom properties
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Getting property name at particular index
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Removing selected property
    dProps.removeCustomProperty(getPropertyName);
    // Saving presentation
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Custom Document Properties Added**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Access and Modify Custom Properties**

Aspose.Slides for Node.js via Java also allows developers to access the values of custom properties. An example is given below that shows how can you access and modify all of these custom properties for a presentation.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Create a reference to DocumentProperties object associated with Presentation
    var dp = pres.getDocumentProperties();
    // Access and modify custom properties
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Display names and values of custom properties
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Modify values of custom properties
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Save your presentation to a file
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

This example modifies the custom properties of the [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentation. Following figures show the presentation custom properties before and after modification:

|**Custom Properties before Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Custom Properties after Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Advanced Document Properties**

{{% alert color="primary" %}} 

New methods [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), and [WriteBindedPresentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) have been added to [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo), logic of the [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) property setter has been changed.

{{% /alert %}} 

The two new methods [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) and [UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) have been added to [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo) class. They provide quick access to document properties and allow to change and update properties without loading a whole presentation.

The typical scenario load the properties, change some value and update the document can be implemented in the following way:

```javascript
// read the info of presentation
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obtain the current properties
var props = info.readDocumentProperties();
// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");
// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

There is another way to use properties of a particular presentation as a template to update properties in other presentations:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

A new template can be created from scratch and then used to update multiple presentations:

```javascript
var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Set Proofing Language**

Aspose.Slides provides the LanguageId property (exposed by the PortionFormat class) to allow you to set the proofing language for a PowerPoint document. The proofing language is the language for which spellings and grammar in the PowerPoint are checked.

This JavaScript code shows you how to set the proofing language for a PowerPoint: xxx Why is LanguageId missing from JavaScript PortionFormat class?

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// set the Id of a proofing language
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Default Language**

This JavaScript code shows you how to set the default language for an entire PowerPoint presentation:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Adds a new rectangle shape with text
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Checks the first portion language
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Live Example**

Try [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) online app to see how to work with document properties via Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**How can I remove a built-in property from a presentation?**

Built-in properties are an integral part of the presentation and cannot be removed entirely. However, you can either change their values or set them to empty if allowed by the specific property.

**What happens if I add a custom property that already exists?**

If you add a custom property that already exists, its existing value will be overwritten with the new one. You do not need to remove or check the property beforehand, as Aspose.Slides automatically updates the property's value.

**Can I access presentation properties without fully loading the presentation?**

Yes, you can access presentation properties without fully loading the presentation by using the `getPresentationInfo` method from the [PresentationFactory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/) class. Then, utilize the `readDocumentProperties` method provided by the [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo/) class to read the properties efficiently, saving memory and improving performance.
