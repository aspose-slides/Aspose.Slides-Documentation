---
title: Begränsningar och API‑skillnader
type: docs
weight: 100
url: /sv/php-java/limitations-and-api-differences/
keywords:
- begränsning
- API‑skillnader
- paketjämförelse
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Jämför begränsningarna och API‑skillnaderna mellan Aspose.Slides för PHP via Java och Aspose.Slides för Java."
---
## **Offentliga API-skillnader**

Denna lista, med exempel på kodsegment, visar vissa skillnader mellan Aspose.Slides för Java och Aspose.Slides för PHP via Java‑API:er.

### **Importera bibliotek (paketjämförelser)**

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

### **Skapa en ny presentation**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **Enums eller konstanter**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Exempel**

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
        // Skapar ett Presentation-objekt som representerar en presentationsfil
        Presentation pres = new Presentation();
        try
        {
            // Hämtar den första bilden
            ISlide slide = pres.getSlides().get_Item(0);

            // Lägger till en autoshape med typ satt till linje
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
    // Hämtar den första bilden
    $slide = $pres->getSlides()->get_Item(0);

    // Lägger till en autoshape med typ satt till linje
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Övriga begränsningar för Aspose.Slides för PHP via Java‑API jämfört med Aspose.Slides för Java‑API**

Aspose.Slides‑namnrymder och de java‑klasser de använder är omslag skapade av PhpJavaBridge ovanpå Java‑klasserna med samma namn från paketet com.aspose.slides.

#### **1. Omslag av Java‑parametrar och argument**

Parametrarna och argumenten de returnerar och accepterar är omslag ovanpå Java‑klasserna med samma namn. Endast strängar och numeriska typer konverteras automatiskt. Arrayer, samlingar, byte‑värden och boolean‑värden konverteras inte.  

**Ett vanligt misstag:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. Utöka Java‑klass och instanceof‑operator**

Du kan inte utöka en Java‑klass från en PHP‑klass. Som en lösning kan du implementera sammansättning vid behov.
instanceof‑operatorn fungerar endast för en konkret klass. Den fungerar inte för ett gränssnitt eller en föräldraklass. 

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. En Java‑array är INTE en PHP‑array**

Java‑arrayskapning i PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. En Java‑arrays längd**

``` php
$data->length; - does NOT work
```
lösning
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. Java‑metoden Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```
lösning
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

#### **6. Java‑metoden Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - fungerar INTE
```
lösning
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```