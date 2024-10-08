---
title: Einschränkungen und API-Unterschiede
type: docs
weight: 100
url: /de/php-java/einschraenkungen-und-api-unterschiede/
---


## **Öffentliche API-Unterschiede**

Diese Liste, die Beispielcode-Segmente verwendet, demonstriert bestimmte Unterschiede zwischen Aspose.Slides für Java und Aspose.Slides für PHP über Java-APIs.

### **Bibliothek importieren (Paketvergleiche)**

**Aspose.Slides für Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides für PHP über Java**

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\sldes;
use aspose\sldes\Presentation;
```

### **Erstellen einer neuen Präsentation**

**Aspose.Slides für Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides für PHP über Java**

```php
$presentation = new Presentation();
```

### **Enums oder Konstanten**

**Aspose.Slides für Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides für PHP über Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Beispiel**

**Aspose.Slides für Java**

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

public class Test
{
    public static void main(String[] args) throws Exception
    {
        // Erstellt ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
        Presentation pres = new Presentation();
        try
        {
            // Holt die erste Folie
            ISlide slide = pres.getSlides().get_Item(0);

            // Fügt eine Autoshape mit Typ auf Linie gesetzt hinzu
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

**Aspose.Slides für PHP über Java**

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
    // Holt die erste Folie
    $slide = $pres->getSlides()->get_Item(0);

    // Fügt eine Autoshape mit Typ auf Linie gesetzt hinzu
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Weitere Einschränkungen von Aspose.Slides für PHP über Java API im Vergleich zu Aspose.Slides für Java API**

Die Aspose.Slides-Namensräume und die Java-Klassen, die sie verwenden, sind Wrapper, die von der PhpJavaBridge über den Java-Klassen mit demselben Namen aus dem com.aspose.slides-Paket erstellt wurden.

#### 1. **Wrapper für Java-Parameter und Argumente**

Die Parameter und Argumente, die sie zurückgeben und akzeptieren, sind Wrapper über den Java-Klassen mit denselben Namen. Nur Strings und numerische Typen werden automatisch konvertiert. Arrays, Sammlungen, Bytes und Booleans werden nicht konvertiert.  

**Ein häufiger Fehler:**
``` php
if ($node->isAssistant()) - falsch!
if (java_values($node->isAssistant())) - richtig!
```

#### 2. **Erweiterung der Java-Klasse und instanceof-Operator**

Sie können eine Java-Klasse nicht von einer PHP-Klasse aus erweitern. Als Workaround können Sie bei Bedarf Komposition implementieren.
Der instanceof-Operator funktioniert nur für eine konkrete Klasse. Er funktioniert nicht für die Schnittstelle oder die Elternklasse einer Klasse. 

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### 3. **Ein Java-Array ist kein PHP-Array**

Java-Array-Erstellung in PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### 4. **Länge eines Java-Arrays**

``` php
$data->length; - funktioniert NICHT
```
Workaround
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### 5. **Die Java-Methode Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - funktioniert NICHT
```
Workaround
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

#### 6. **Die Java-Methode Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - funktioniert NICHT
```
Workaround
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```