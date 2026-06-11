---
title: Ograniczenia i różnice w API
type: docs
weight: 100
url: /pl/php-java/limitations-and-api-differences/
keywords:
- ograniczenie
- różnice API
- porównanie pakietów
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: Porównaj ograniczenia i różnice w API między Aspose.Slides for PHP via Java a Aspose.Slides for Java.
---
## **Różnice w publicznym API**

Ta lista, z użyciem fragmentów przykładowego kodu, demonstruje pewne różnice pomiędzy Aspose.Slides for Java i Aspose.Slides for PHP przy użyciu interfejsów API Java.

### **Importowanie biblioteki (Porównania pakietów)**

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

### **Tworzenie nowej prezentacji**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **Wyliczenia lub stałe**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Przykład**

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
        // Tworzy obiekt Presentation, który reprezentuje plik prezentacji
        Presentation pres = new Presentation();
        try
        {
            // Pobiera pierwszy slajd
            ISlide slide = pres.getSlides().get_Item(0);

            // Dodaje autokształt typu linia
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
    // Pobiera pierwszy slajd
    $slide = $pres->getSlides()->get_Item(0);

    // Dodaje autokształt typu linia
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Inne ograniczenia Aspose.Slides for PHP przy użyciu API Java w porównaniu do Aspose.Slides for Java API**

Przestrzenie nazw Aspose.Slides oraz klasy Java, z których korzystają, są wrapperami utworzonymi przez PhpJavaBridge na bazie klas Java o tej samej nazwie z pakietu com.aspose.slides.

#### **1. Opakowywanie parametrów i argumentów Java**

Parametry i argumenty, które zwracają i przyjmują, są wrapperami bazującymi na klasach Java o tych samych nazwach. Tylko ciągi znaków i typy liczbowe są konwertowane automatycznie. Tablice, kolekcje, bajty i wartości logiczne nie są konwertowane.  

**Typowy błąd:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. Rozszerzanie klasy Java i operator instanceof**

Nie możesz rozszerzyć klasy Java w klasie PHP. Jako obejście możesz zastosować kompozycję w razie potrzeby.  
Operator instanceof działa tylko dla konkretnej klasy. Nie działa dla interfejsu klasy ani klasy nadrzędnej.  

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Tablica Java NIE jest tablicą PHP**

Tworzenie tablicy Java w PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. Długość tablicy Java**

``` php
$data->length; - does NOT work
```
obejście
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. Metoda Java Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```
obejście
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

#### **6. Metoda Java Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - does NOT work
```
obejście
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```