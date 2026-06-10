---
title: Korlátok és API különbségek
type: docs
weight: 100
url: /hu/php-java/limitations-and-api-differences/
keywords:
- korlát
- API különbségek
- csomag összehasonlítás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Hasonlítsa össze a korlátokat és az API különbségeket az Aspose.Slides for PHP via Java és az Aspose.Slides for Java között."
---
## **Nyilvános API különbségek**

Ez a lista, mintakód szegmenseket használva, bizonyos különbségeket mutat be az Aspose.Slides for Java és az Aspose.Slides for PHP via Java API-k között.

### **Könyvtár importálása (Csomag összehasonlítások)**

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

### **Új prezentáció példányosítása**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **Enumok vagy állandók**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Példa**

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
        // Létrehoz egy Presentation objektumot, amely egy prezentációfájlt képvisel
        Presentation pres = new Presentation();
        try
        {
            // Lekéri az első diát
            ISlide slide = pres.getSlides().get_Item(0);

            // Hozzáad egy autóalakzatot, amelynek típusa vonal
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
    // Lekéri az első diát
    $slide = $pres->getSlides()->get_Item(0);

    // Hozzáad egy autóalakzatot, amelynek típusa vonal
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Az Aspose.Slides for PHP via Java API többi korlátozása az Aspose.Slides for Java API-hoz képest**

Az Aspose.Slides névterek és a használatukban lévő Java osztályok a PhpJavaBridge által a com.aspose.slides csomag azonos nevű Java osztályai fölött létrehozott wrapper-ek.

#### **1. Java paraméterek és argumentumok becsomagolása**

A visszaadott és elfogadott paraméterek és argumentumok wrapper-ek a Java osztályok azonos nevén. Csak a karakterláncok és numerikus típusok konvertálódnak automatikusan. A tömbök, gyűjtemények, bájtok és logikai értékek nem konvertálódnak.  

**Gyakori hiba:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. Java osztály kiterjesztése és az instanceof operátor**

Nem lehet egy PHP osztályból kiterjeszteni egy Java osztályt. Megoldásként szükség esetén kompozíciót valósíthat meg. Az instanceof operátor csak konkrét osztályra működik, nem működik egy osztály interfészére vagy ősosztályára.  

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. A Java tömb NEM egy PHP tömb**

Java tömb létrehozása PHP-ben:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. A Java tömb hossza**

``` php
$data->length; - does NOT work
```
workaround
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. A Java Files.readAllBytes metódus**

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

#### **6. A Java Files.write metódus**

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