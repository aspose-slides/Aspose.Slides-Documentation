---
title: Limitations and API Differences
type: docs
weight: 100
url: /php-java/limitations-and-api-differences/
keywords:
- limitation
- API differences
- package comparison
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Compare the limitations and API differences between Aspose.Slides for PHP via Java and Aspose.Slides for Java."
---


## **Public API Differences**

This list, using sample code segments, demonstrates certain differences between Aspose.Slides for Java and Aspose.Slides for PHP via Java APIs.

### **Importing library (Package Comparisons)**

**Aspose.Slides for Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides for PHP via Java**

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\sldes;
use aspose\sldes\Presentation;
```

### **Instantiating a New Presentation**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **Enums or Constants**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Example**

**Aspose.Slides for Java**

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

public class Test
{
    public static void main(String[] args) throws Exception
    {
        // Instantiates a Presentation object that represents a presentation file
        Presentation pres = new Presentation();
        try
        {
            // Gets the first slide
            ISlide slide = pres.getSlides().get_Item(0);

            // Adds an autoshape with type set to line
            slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
            pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
        }
        finally
        {
            if (pres != null) pres.dispose();
        }
    }
}
```

**Aspose.Slides for PHP via Java**

```php
<?php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$pres = new Presentation();
try
{
    // Gets the first slide
    $slide = $pres->getSlides()->get_Item(0);

    // Adds an autoshape with type set to line
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Other Limitations of Aspose.Slides for PHP via Java API Compared to Aspose.Slides for Java API**

Aspose.Slides namespaces and the java classes they use are wrappers created by the PhpJavaBridge on top of the Java classes with the same name from the com.aspose.slides package.

#### **1. Wrapping Java Parameters and Arguments**

The parameters and arguments they return and accept are wrappers on top of the Java classes with the same names. Only strings and numeric types are converted automatically. Arrays, collections, bytes, and booleans are not converted.  

**A common mistake:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. Extending Java Class and Instanceof Operator**

You cannot extend a Java class from a PHP class. As a workaround, you can implement composition when needed.
The instanceof operator only works for a concrete class. It does not work for a class’s interface or parent class. 

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. A Java Array Is NOT a PHP Array**

Java array creation in PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. A Java Array Length**

``` php
$data->length; - does NOT work
```
workaround
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. The Java Method Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```
workaround
``` php
$file = new Java("java.io.File", "embedOle.html");
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = new JavaClass("java.lang.Byte");
$htmlBytes = $Array->newInstance($Byte, $Array->getLength($file));
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file));
    $dis->readFully($htmlBytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
```

#### **6. The Java Method Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - does NOT work
```
workaround
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```
