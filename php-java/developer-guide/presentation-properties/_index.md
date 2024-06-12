---
title: Presentation Properties
type: docs
weight: 70
url: /php-java/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint provides a feature to add some properties to the presentation files. These document properties allow some useful information to be stored along with the documents (presentation files). There are two kinds of document properties as follows

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

**Built-in** properties contain general information about the document like document title, author's name, document statistics and so on. **Custom** properties are those ones, which are defined by the users as **Name/Value** pairs, where both name and value are defined by the user. Using Aspose.Slides for PHP via Java, developers can access and modify the values of built-in properties as well as custom properties.

{{% /alert %}} 

## **Document Properties in PowerPoint**
Microsoft PowerPoint 2007 allows managing the document properties of the presentation files. All you have to do is to click the Office icon and further **Prepare | Properties | Advanced Properties** menu item of the Microsoft PowerPoint 2007 as shown below:

{{% alert color="primary" %}} 

Please note that you cannot set values against the **Application** and **Producer** fields, because Aspose Ltd. and Aspose.Slides for PHP via Java x.x.x will be displayed against these fields.

{{% /alert %}} 

|**Selecting Advanced Properties menu item**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
After you select **Advanced Properties** menu item, a dialog would appear allowing you to manage the document properties of the PowerPoint file as shown below in the figure:

|**Properties Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
In the above **Properties Dialog**, you can see that there are many tab pages like **General**, **Summary**, **Statistics**, **Contents** and **Custom**. All these tab pages allow configuring different kinds of information related to the PowerPoint files. **Custom** tab is used to manage the custom properties of the PowerPoint files.



Working with Document Properties Using Aspose.Slides for PHP via Java

As we have described earlier that Aspose.Slides for PHP via Java supports two kinds of document properties, which are **Built-in** and **Custom** properties. So, developers can access both kinds of properties with the use of Aspose.Slides for PHP via Java API. Aspose.Slides for PHP via Java provides a class [IDocumentProperties](https://reference.aspose.com/slides/php-java/com.aspose.slides/idocumentproperties) that represents the document properties associated with a presentation file through **Presentation.DocumentProperties** property.

Developers can use **IDocumentProperties** property exposed by [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation) object to access the document properties of the presentation files as described below:

## **Access Built-in Properties**
These properties as exposed by [IDocumentProperties](https://reference.aspose.com/slides/php-java/com.aspose.slides/idocumentproperties) object include: **Creator** (Author), **Description**, **Keywords** **Created** (Creation Date), **Modified** Modification Date, **Printed** Last Print Date, **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** and **Title**

```php
  // Instantiate the Presentation class that represents the presentation
  $pres = new Presentation("Presentation.pptx");
  try {
    // Create a reference to IDocumentProperties object associated with Presentation
    $dp = $pres->getDocumentProperties();
    // Display the built-in properties
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

## **Modify Built-in Properties**
Modifying the built-in properties of presentation files is as easy as that of accessing them. You can simply assign a string value to any desired property and the property value would be modified. In the example given below, we have demonstrated how we can modify the built-in document properties of the presentation file using Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    // Create a reference to IDocumentProperties object associated with Presentation
    $dp = $pres->getDocumentProperties();
    // Set the built-in properties
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    // Save your presentation to a file
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

This example modifies the built-in properties of the presentation that can be viewed as shown below:

|**Built-in document properties after modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Add Custom Document Properties**
Aspose.Slides for PHP via Java also allows developers to add the custom the values for presentation Document properties. An example is given below that shows how to set the custom properties for a presentation.

```php
  $pres = new Presentation();
  try {
    // Getting Document Properties
    $dProps = $pres->getDocumentProperties();
    // Adding Custom properties
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    // Getting property name at particular index
    $getPropertyName = $dProps->getCustomPropertyName(2);
    // Removing selected property
    $dProps->removeCustomProperty($getPropertyName);
    // Saving presentation
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

|**Custom Document Properties Added**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Access and Modify Custom Properties**
Aspose.Slides for PHP via Java also allows developers to access the values of custom properties. An example is given below that shows how can you access and modify all of these custom properties for a presentation.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    // Create a reference to DocumentProperties object associated with Presentation
    $dp = $pres->getDocumentProperties();
    // Access and modify custom properties
    for($i = 0; $i < $dp->getCountOfCustomProperties(); $i++) {
      // Display names and values of custom properties
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      // Modify values of custom properties
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    // Save your presentation to a file
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if ($pres != null) {
      $pres->dispose();
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

New methods [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), and [WriteBindedPresentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) have been added to [IPresentationInfo](https://reference.aspose.com/slides/php-java/com.aspose.slides/IPresentationInfo), logic of the [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) property setter has been changed.

{{% /alert %}} 

The two new methods [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) and [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) have been added to [IPresentationInfo](https://reference.aspose.com/slides/php-java/com.aspose.slides/IPresentationInfo) interface. They provide quick access to document properties and allow to change and update properties without loading a whole presentation.

The typical scenario load the properties, change some value and update the document can be implemented in the following way:

```php
  // read the info of presentation
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  // obtain the current properties
  $props = $info->readDocumentProperties();
  // set the new values of Author and Title fields
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  // update the presentation with a new values
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");

```

There is another way to use properties of a particular presentation as a template to update properties in other presentations:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

A new template can be created from scratch and then used to update multiple presentations:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

## **Check if Presentation is Modified or Created**
Aspose.Slides for PHP via Java provides the facility to check if a presentation is modified or created. An example is given below that shows how to check if the presentation is created or modified.

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("props.pptx");
  $props = $info->readDocumentProperties();
  $app = $props->getNameOfApplication();
  $ver = $props->getAppVersion();
  echo("Application Name: " . $app);
  echo("Application Version: " . $ver);

```

## **Set Proofing Language**

Aspose.Slides provides the LanguageId property (exposed by the PortionFormat class) to allow you to set the proofing language for a PowerPoint document. The proofing language is the language for which spellings and grammar in the PowerPoint are checked.

This Java code shows you how to set the proofing language for a PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// set the Id of a proofing language

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

## **Set Default Language**

This Java code shows you how to set the default language for an entire PowerPoint presentation:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    // Adds a new rectangle shape with text
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    // Checks the first portion language
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

