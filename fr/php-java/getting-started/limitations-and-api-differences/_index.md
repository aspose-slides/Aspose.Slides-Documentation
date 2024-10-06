---
title: Limitations et différences d'API
type: docs
weight: 100
url: /php-java/limitations-and-api-differences/
---


## **Differences de l'API publique**

Cette liste, utilisant des segments de code exemples, démontre certaines différences entre Aspose.Slides pour Java et Aspose.Slides pour PHP via des API Java.

### **Importation de bibliothèque (comparaisons de packages)**

**Aspose.Slides pour Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides pour PHP via Java**

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\sldes;
use aspose\sldes\Presentation;
```

### **Instanciation d'une nouvelle présentation**

**Aspose.Slides pour Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides pour PHP via Java**

```php
$presentation = new Presentation();
```

### **Enums ou constantes**

**Aspose.Slides pour Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides pour PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Exemple**

**Aspose.Slides pour Java**

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

**Aspose.Slides pour PHP via Java**

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

### **Autres limitations d'Aspose.Slides pour PHP via l'API Java par rapport à Aspose.Slides pour l'API Java**

Les espaces de noms d'Aspose.Slides et les classes Java qu'ils utilisent sont des wrappers créés par le PhpJavaBridge sur les classes Java ayant le même nom à partir du package com.aspose.slides.

#### 1. **Enveloppement des paramètres et arguments java**

Les paramètres et arguments qu'ils retournent et acceptent sont des wrappers au-dessus des classes Java ayant les mêmes noms. Seules les chaînes et les types numériques sont convertis automatiquement. Les tableaux, collections, octets et booléens ne sont pas convertis.  

**Une erreur courante :**
``` php
if ($node->isAssistant()) - faux !
if (java_values($node->isAssistant())) - correct !
```

#### 2. **Étendre une classe Java et opérateur instanceof**

Vous ne pouvez pas étendre une classe Java à partir d'une classe PHP. Comme solution de contournement, vous pouvez mettre en œuvre la composition si nécessaire.
L'opérateur instanceof ne fonctionne que pour une classe concrète. Il ne fonctionne pas pour l'interface d'une classe ou la classe parente. 

[solution de contournement](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### 3. **Un tableau Java n'est PAS un tableau PHP**

Création de tableau Java en PHP :
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### 4. **Longueur d'un tableau Java**

``` php
$data->length; - ne fonctionne PAS
```
solution de contournement
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### 5. **La méthode Java Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - ne fonctionne PAS
```
solution de contournement
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

#### 6. **La méthode Java Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - ne fonctionne PAS
```
solution de contournement
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```