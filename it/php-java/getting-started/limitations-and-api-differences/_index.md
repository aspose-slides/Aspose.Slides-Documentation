---
title: Limitazioni e differenze API
type: docs
weight: 100
url: /it/php-java/limitations-and-api-differences/
keywords:
- limitazione
- differenze API
- confronto dei pacchetti
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Confronta le limitazioni e le differenze dell'API tra Aspose.Slides per PHP via Java e Aspose.Slides per Java."
---
## **Differenze dell'API Pubblica**

Questo elenco, utilizzando segmenti di codice di esempio, mostra alcune differenze tra Aspose.Slides per Java e Aspose.Slides per PHP tramite le API Java.

### **Importazione della libreria (Confronto dei pacchetti)**

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

### **Creazione di una nuova presentazione**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **Enum o Costanti**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Esempio**

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
        // Istanzia un oggetto Presentation che rappresenta un file di presentazione
        Presentation pres = new Presentation();
        try
        {
            // Ottiene la prima diapositiva
            ISlide slide = pres.getSlides().get_Item(0);

            // Aggiunge una forma automatica con tipo impostato a linea
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
    // Ottiene la prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);

    // Aggiunge una forma automatica con tipo impostato a linea
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Altre limitazioni di Aspose.Slides per PHP tramite API Java rispetto ad Aspose.Slides per Java API**

Gli spazi dei nomi Aspose.Slides e le classi Java che utilizzano sono wrapper creati da PhpJavaBridge sopra le classi Java con lo stesso nome dal pacchetto com.aspose.slides.

#### **1. Avvolgere parametri e argomenti Java**

I parametri e gli argomenti che restituiscono e accettano sono wrapper sopra le classi Java con gli stessi nomi. Solo stringhe e tipi numerici vengono convertiti automaticamente. Array, collezioni, byte e booleani non vengono convertiti.  

**Un errore comune:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. Estendere una classe Java e operatore instanceof**

Non è possibile estendere una classe Java da una classe PHP. Come soluzione alternativa, è possibile implementare la composizione quando necessario.  
L'operatore instanceof funziona solo per una classe concreta. Non funziona per l'interfaccia o la classe padre di una classe.  

[soluzione](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Un array Java NON è un array PHP**

Creazione di un array Java in PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. Lunghezza di un array Java**

``` php
$data->length; - does NOT work
```
soluzione
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. Il metodo Java Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```
soluzione
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

#### **6. Il metodo Java Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - non funziona
```
soluzione
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```