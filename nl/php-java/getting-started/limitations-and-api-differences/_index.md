---
title: Beperkingen en API-verschillen
type: docs
weight: 100
url: /nl/php-java/limitations-and-api-differences/
keywords:
- beperking
- API-verschillen
- pakketvergelijking
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Vergelijk de beperkingen en API-verschillen tussen Aspose.Slides voor PHP via Java en Aspose.Slides voor Java."
---
## **Publieke API-verschillen**

Deze lijst, met voorbeeldcodefragmenten, toont enkele verschillen tussen Aspose.Slides voor Java en Aspose.Slides voor PHP via Java-API's.

### **Bibliotheek importeren (pakketvergelijkingen)**

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

### **Een nieuwe presentatie instantieren**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **Enums of constanten**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Voorbeeld**

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
        // Instantieert een Presentation‑object dat een presentatie‑bestand vertegenwoordigt
        Presentation pres = new Presentation();
        try
        {
            // Haalt de eerste dia op
            ISlide slide = pres.getSlides().get_Item(0);

            // Voegt een autovorm toe met type ingesteld op lijn
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
    // Haalt de eerste dia op
    $slide = $pres->getSlides()->get_Item(0);

    // Voegt een autovorm toe met type ingesteld op lijn
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Andere beperkingen van Aspose.Slides voor PHP via Java-API vergeleken met Aspose.Slides voor Java-API**

Aspose.Slides‑namespaces en de Java‑klassen die ze gebruiken, zijn wrappers die door de PhpJavaBridge zijn gemaakt bovenop de Java‑klassen met dezelfde naam uit het `com.aspose.slides`‑pakket.

#### **1. Omhullen van Java‑parameters en -argumenten**

De parameters en argumenten die ze retourneren en accepteren, zijn wrappers bovenop de Java‑klassen met dezelfde namen. Alleen strings en numerieke types worden automatisch geconverteerd. Arrays, collecties, bytes en booleans worden niet geconverteerd.  

**Een veelgemaakte fout:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. Java‑klasse uitbreiden en instanceof‑operator**

U kunt geen Java‑klasse uitbreiden vanuit een PHP‑klasse. Als tijdelijke oplossing kunt u compositie implementeren wanneer dat nodig is.  
De `instanceof`‑operator werkt alleen voor een concrete klasse. Hij werkt niet voor een interface of een bovenliggende klasse.  

[omweg](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Een Java-array is GEEN PHP-array**

Java‑arraycreatie in PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. De lengte van een Java-array**

``` php
$data->length; - does NOT work
```
omweg
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. De Java-methode Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```
omweg
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

#### **6. De Java-methode Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - does NOT work
```
omweg
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```