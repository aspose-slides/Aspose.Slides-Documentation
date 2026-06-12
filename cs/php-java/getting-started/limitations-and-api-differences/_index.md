---
title: Omezení a rozdíly v API
type: docs
weight: 100
url: /cs/php-java/limitations-and-api-differences/
keywords:
- omezení
- rozdíly API
- porovnání balíčků
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Porovnejte omezení a rozdíly v API mezi Aspose.Slides for PHP via Java a Aspose.Slides for Java."
---
## **Rozdíly v veřejném API**

Tento seznam, pomocí ukázkových útržků kódu, ukazuje určité rozdíly mezi Aspose.Slides for Java a Aspose.Slides for PHP prostřednictvím Java API.

### **Import knihovny (porovnání balíčků)**

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

### **Vytvoření nové prezentace**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **Výčty nebo konstanty**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Příklad**

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
        // Vytvoří objekt Presentation, který představuje soubor prezentace
        Presentation pres = new Presentation();
        try
        {
            // Získá první snímek
            ISlide slide = pres.getSlides().get_Item(0);

            // Přidá automatický tvar typu čára
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
    // Získá první snímek
    $slide = $pres->getSlides()->get_Item(0);

    // Přidá automatický tvar typu čára
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Další omezení Aspose.Slides for PHP přes Java API ve srovnání s Aspose.Slides for Java API**

Namespace Aspose.Slides a Java třídy, které používají, jsou obaly vytvořené PhpJavaBridge nad Java třídami se stejným názvem z balíčku com.aspose.slides.

#### **1. Zabalování Java parametrů a argumentů**

Parametry a argumenty, které vrací a přijímají, jsou obaly nad Java třídami se stejnými názvy. Automaticky jsou konvertovány pouze řetězce a číselné typy. Pole, kolekce, bajty a boolovské hodnoty nejsou konvertovány.  

**Častá chyba:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. Dědičnost Java třídy a operátor instanceof**

Nelze rozšířit Java třídu z PHP třídy. Jako obcházení můžete v případě potřeby použít kompozici. Operátor instanceof funguje jen pro konkrétní třídu. Nepracuje pro rozhraní nebo rodičovskou třídu.

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Java pole NENÍ PHP pole**

Vytvoření Java pole v PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. Délka Java pole**

``` php
$data->length; - does NOT work
```
obcházení
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. Java metoda Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```
obcházení
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

#### **6. Java metoda Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - does NOT work
```
obcházení
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```