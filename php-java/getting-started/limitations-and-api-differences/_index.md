---
title: Limitations and API Differences
type: docs
weight: 100
url: /php-java/limitations-and-api-differences/
---


## **Public API Differences**

This list, using sample code segments, demonstrates certain differences between Aspose.Slides for Java and Aspose.Slides for PHP via Java APIs.

### **Importing library (Package Comparisons)**

**Aspose.Slides for Java**

``` php
 import com.aspose.slides.*;
```php

```

**Aspose.Slides for PHP via Java**

``` php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\sldes;
use aspose\sldes\Presentation;
```php

```

### **Instantiating a new Presentation**

**Aspose.Slides for Java**

``` php
Presentation presentation = new Presentation();
```php

```

**Aspose.Slides for PHP via Java**

``` php
$presentation = new Presentation();
```php

```

### **Enums or Constants**

**Aspose.Slides for Java**

``` php
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```php

```

**Aspose.Slides for PHP via Java**

``` php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle->SOLID);
```php

```

### **Example**

**Aspose.Slides for Java**


**Aspose.Slides for PHP via Java**


``` php
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
    $pres->save("NewPresentation_out.pptx", SaveFormat->Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>

### **Other Limitations of Aspose.Slides for PHP via Java API compared to Aspose.Slides for Java API**

Aspose.Slides namespaces and the java classes they use are wrappers created by the PhpJavaBridge on top of the Java classes with the same name from the com.aspose.slides package.

#### 1. **Wrapping java parameters and arguments**

The parameters and arguments they return and accept are wrappers on top of the Java classes with the same names. Only strings and numeric types are converted automatically. Arrays, collections, bytes, and booleans are not converted.  

**A common mistake:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### 2. **Extending Java class and instanceof operator**

You cannot extend a Java class from a PHP class. As a workaround, you can implement composition when needed.
The instanceof operator only works for a concrete class. It does not work for a class’s interface or parent class. 

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### 3. **A Java array is NOT a PHP array**

Java array creation in PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### 4. **A Java array length**

``` php
$data->length; - does NOT work
```
workaround
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### 5. **The Java method Files.readAllBytes**

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