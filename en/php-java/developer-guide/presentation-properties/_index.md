---
title: Manage Presentation Properties in PHP
linktitle: Presentation Properties
type: docs
weight: 70
url: /php-java/presentation-properties/
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
- PHP
- Aspose.Slides
description: "Master presentation properties in Aspose.Slides for PHP via Java and streamline search, branding and workflow in your PowerPoint and OpenDocument files."
---

## **Introduction**

Aspose.Slides supports two types of document properties: **Built-in** and **Custom**. Both of these property types can easily be accessed and managed using the Aspose.Slides API.

Aspose.Slides allows you to work with presentation document properties through the [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) class. An instance of this class is returned by the [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) method. The following examples show how to read, modify, and manage these properties.

{{% alert color="info" title="Note" %}}

Please note that the **Application** and **AppVersion** fields cannot be modified. Aspose.Slides rewrites them on every save, so a saved presentation always reports "Aspose.Slides for PHP via Java" and the version of the library that produced it. Any value passed to `setNameOfApplication` is discarded when the presentation is written.

{{% /alert %}} 

## **Manage Presentation Properties**

Microsoft PowerPoint provides a feature to add some properties to the presentation files. These document properties allow some useful information to be stored along with the documents (presentation files). There are two kinds of document properties as follows

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

**Built-in** properties contain general information about the document like document title, author's name, document statistics and so on. **Custom** properties are those ones, which are defined by the users as **Name/Value** pairs, where both name and value are defined by the user. Using Aspose.Slides for PHP via Java, developers can access and modify the values of built-in properties as well as custom properties.

## **Document Properties in PowerPoint**

Microsoft PowerPoint 2007 allows managing the document properties of the presentation files. All you have to do is to click the Office icon and further **Prepare | Properties | Advanced Properties** menu item of the Microsoft PowerPoint 2007 as shown below:

|**Selecting Advanced Properties menu item**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
After you select **Advanced Properties** menu item, a dialog would appear allowing you to manage the document properties of the PowerPoint file as shown below in the figure:

|**Properties Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
In the above **Properties Dialog**, you can see that there are many tab pages like **General**, **Summary**, **Statistics**, **Contents** and **Custom**. All these tab pages allow configuring different kinds of information related to the PowerPoint files. **Custom** tab is used to manage the custom properties of the PowerPoint files.

Working with Document Properties Using Aspose.Slides for PHP via Java

As we have described earlier that Aspose.Slides for PHP via Java supports two kinds of document properties, which are **Built-in** and **Custom** properties. So, developers can access both kinds of properties with the use of Aspose.Slides for PHP via Java API. Aspose.Slides for PHP via Java provides a class [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties) that represents the document properties associated with a presentation file through **Presentation.DocumentProperties** property.

Developers can use **DocumentProperties** property exposed by [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) object to access the document properties of the presentation files as described below:

## **Read Public Properties from an Encrypted Presentation**

An opening password normally protects both presentation content and document properties. When a presentation is encrypted by passing `false` to [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), its document properties remain public. An application can then pass `true` to [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) and read the public metadata without supplying the opening password.

The document-properties-only option controls what Aspose.Slides loads; it does not decrypt anything. If the properties were included in encryption, loading them without the password fails. If the presentation is not encrypted, the option is ignored and the complete presentation is loaded.

The following example verifies the loading mode through [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) and then reads built-in properties through [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

In this mode, slide content is not loaded. Slides, masters, layouts, shapes, media, and other presentation objects are unavailable. Applications should always check [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) before performing an operation that requires the complete presentation object model.

{{% alert color="warning" title="Warning" %}}
Public metadata may expose author names, titles, subjects, keywords, company information, comments, and custom values. Encrypt sensitive properties together with the presentation. Leave them public only when indexing, classification, search, or document-management systems have a specific requirement to access them without a password.
{{% /alert %}}

## **Update Properties of an Encrypted Presentation**

For an encrypted PPTX file, a presentation loaded in document-properties-only mode is intended for reading public metadata. Aspose.Slides cannot save changed properties from that metadata-only object because the public properties must remain consistent with the corresponding data inside the encrypted presentation. Updating them therefore requires the correct opening password and a complete load.

The following example opens the presentation with [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword), updates public built-in properties, and saves the result. It then uses [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#isEncrypted) to verify that encryption is preserved and reopens the public metadata without a password to verify the new values:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

If an application is not allowed to decrypt or load the presentation content, it must treat public properties of an encrypted PPTX file as read-only.

## **Access Built-in Properties**

These properties as exposed by [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties) object include: **Creator** (Author), **Description**, **Keywords** **Created** (Creation Date), **Modified** Modification Date, **Printed** Last Print Date, **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** and **Title**

```php
  # Instantiate the Presentation class that represents the presentation
  $pres = new Presentation("Presentation.pptx");
  try {
    # Create a reference to IDocumentProperties object associated with Presentation
    $dp = $pres->getDocumentProperties();
    # Display the built-in properties
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
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modify Built-in Properties**

Modifying the built-in properties of presentation files is as easy as that of accessing them. You can simply assign a string value to any desired property and the property value would be modified. In the example given below, we have demonstrated how we can modify the built-in document properties of the presentation file using Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Create a reference to IDocumentProperties object associated with Presentation
    $dp = $pres->getDocumentProperties();
    # Set the built-in properties
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Save your presentation to a file
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
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
    # Getting Document Properties
    $dProps = $pres->getDocumentProperties();
    # Adding Custom properties
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Getting property name at particular index
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Removing selected property
    $dProps->removeCustomProperty($getPropertyName);
    # Saving presentation
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
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
    # Create a reference to DocumentProperties object associated with Presentation
    $dp = $pres->getDocumentProperties();
    # Access and modify custom properties
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Display names and values of custom properties
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Modify values of custom properties
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Save your presentation to a file
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
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

{{% alert color="info" title="Note" %}}

New methods [readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties), and [writeBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) have been added to [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo), logic of the [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setLastSavedTime) property setter has been changed.

{{% /alert %}} 

The two new methods [readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) and [updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) have been added to [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) class. They provide quick access to document properties and allow to change and update properties without loading a whole presentation.

The typical scenario load the properties, change some value and update the document can be implemented in the following way:

```php
  # read the info of presentation
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # obtain the current properties
  $props = $info->readDocumentProperties();
  # set the new values of Author and Title fields
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # update the presentation with a new values
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

## **Set Proofing Language**

Aspose.Slides provides the LanguageId property (exposed by the PortionFormat class) to allow you to set the proofing language for a PowerPoint document. The proofing language is the language for which spellings and grammar in the PowerPoint are checked.

This PHP code shows you how to set the proofing language for a PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

```php
  $pres = new Presentation("Presentation.pptx");
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
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set Default Language**

This PHP code shows you how to set the default language for an entire PowerPoint presentation:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Adds a new rectangle shape with text
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Checks the first portion language
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Live Example**

Try [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) online app to see how to work with document properties via Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**How can I remove a built-in property from a presentation?**

Built-in properties are an integral part of the presentation and cannot be removed entirely. However, you can either change their values or set them to empty if allowed by the specific property.

**What happens if I add a custom property that already exists?**

If you add a custom property that already exists, its existing value will be overwritten with the new one. You do not need to remove or check the property beforehand, as Aspose.Slides automatically updates the property's value.

**Can I access presentation properties without fully loading the presentation?**

Yes. Use [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/) and then [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) to read stored document metadata without creating a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) instance. See [Build a Lightweight Presentation Inventory](/slides/php-java/examine-presentation/) for a complete reporting example and format-specific limitations.

**Can I read public properties of an encrypted presentation without its opening password?**

Yes. Document-property encryption must have been disabled before the presentation was encrypted, and the presentation must be loaded in document-properties-only mode.

**Can I update an encrypted PPTX file in document-properties-only mode?**

No. Public and encrypted property data must remain consistent, so updating an encrypted PPTX file requires loading the complete presentation with the correct opening password.
