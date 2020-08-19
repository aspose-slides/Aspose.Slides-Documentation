---
title: Managing Presentation Properties in PHP
type: docs
weight: 80
url: /java/managing-presentation-properties-in-php/
---

## **Aspose.Slides - Accessing Built-in Properties**
To access Built-in properties of presentation using **Aspose.Slides Java for PHP**, simply invoke **get_properties** method of **Properties** module. Here you can see example code.

**PHPCode**

```

 public static function get_properties($dataDir=null)

{

\# Instantiate the Presentation class that represents the presentation

$pres = new Presentation($dataDir . "HelloWorld.pptx");

\# Create a reference to IDocumentProperties object associated with Presentation

$dp = $pres->getDocumentProperties();

\# Display the builtin properties

print "Category : " . $dp->getCategory() . PHP_EOL;

print "Current Status : " . $dp->getContentStatus() . PHP_EOL;

print "Creation Date : " . $dp->getCreatedTime() . PHP_EOL;

print "Author : " . $dp->getAuthor() . PHP_EOL;

print "Description : " . $dp->getComments() . PHP_EOL;

print "KeyWords : " . $dp->getKeywords() . PHP_EOL;

print "Last Modified By : " . $dp->getLastSavedBy() . PHP_EOL;

print "Supervisor : " . $dp->getManager() . PHP_EOL;

print "Modified Date : " . $dp->getLastSavedTime() . PHP_EOL;

print "Presentation Format : " . $dp->getPresentationFormat() . PHP_EOL;

print "Last Print Date : " . $dp->getLastPrinted() . PHP_EOL;

print "Is Shared between producers : " . $dp->getSharedDoc() . PHP_EOL;

print "Subject : " . $dp->getSubject() . PHP_EOL;

print "Title : " . $dp->getTitle() . PHP_EOL;

}

```
## **Aspose.Slides - Modifying Built-in Properties**
To update Built-in properties of presentation using **Aspose.Slides Java for PHP**, call **update_properties** method of **Properties** module. Here you can see example code.

**PHPCode**

```

 public static function update_properties($dataDir=null)

{

    # Instantiate the Presentation class that represents the presentation

    $pres = new Presentation($dataDir . "HelloWorld.pptx");

    # Create a reference to IDocumentProperties object associated with Presentation

    $dp = $pres->getDocumentProperties();

    # Set the builtin properties

    $dp->setAuthor ("Aspose.Slides for Java");

    $dp->setTitle ("Modifying Presentation Properties");

    $dp->setSubject ( "Aspose Subject");

    $dp->setComments ( "Aspose Description");

    $dp->setManager ( "Aspose Manager");

    # Save your presentation to a file

    $save_format = new SaveFormat();

    $pres->save($dataDir . "DocProps.pptx", $save_format->Pptx);

    print "Properties have been updated, Please check output file.";

}

```
## **Aspose.Slides - Adding Custom Document Properties**
To add custom property of document using **Aspose.Slides Java for PHP**, call **add_custom_properties** method of **Properties** module. Here you can see example code.

**PHPCode**

```

 public static function add_custom_properties($dataDir=null)

{

\# Instantiate the Presentation class that represents the presentation

$pres = new Presentation($dataDir . "HelloWorld.pptx");

\# Getting Document Properties

$dp = $pres->getDocumentProperties();

\# Adding Custom properties

$dp->set_Item("New Custom" , 12);

$dp->set_Item("My Name","Mudassir");

$dp->set_Item("Custom", 124);

\# Saving presentation

$save_format = new SaveFormat();

$pres->save($dataDir . "CustomDemo.pptx", $save_format->Pptx);

print "Added custom properties, please check output file.";

}

```
## **Aspose.Slides - Removing Document Properties**
To add custom property of document using **Aspose.Slides Java for PHP**, call **remove_property** method of **Properties** module. Here you can see example code.

**PHPCode**

```

 public static function remove_property($dataDir=null)

{

\# Instantiate the Presentation class that represents the presentation

$pres = new Presentation($dataDir . "HelloWorld.pptx");

\# Getting Document Properties

$dp = $pres->getDocumentProperties();

\# Getting property name at particular index

$property_name = $dp->getPropertyName(2);

\# Removing selected property

$dp->remove($property_name);

\# Saving presentation

$save_format = new SaveFormat();

$pres->save($dataDir . "RemoveDP.pptx", $save_format->Pptx);

print "Remove document property, please check output file.";

}

```
## **Download Running Code**
Download **Managing Presentation Properties (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithPresentation/Properties.php)
