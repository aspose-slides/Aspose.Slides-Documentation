---
title: "Limitations et différences d'API"
type: docs
weight: 100
url: /fr/php-java/limitations-and-api-differences/
keywords:
  - "limitation"
  - "différences d'API"
  - "comparaison de packages"
  - "PowerPoint"
  - "OpenDocument"
  - "présentation"
  - "PHP"
  - "Aspose.Slides"
description: "Comparez les limitations et les différences d'API entre Aspose.Slides pour PHP via Java et Aspose.Slides pour Java."
---

## **Différences d'API publiques**

Cette liste, en utilisant des extraits de code d'exemple, démontre certaines différences entre Aspose.Slides for Java et Aspose.Slides for PHP via les API Java.

### **Importation de la bibliothèque (Comparaison des packages)**

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


### **Instanciation d'une nouvelle présentation**

**Aspose.Slides for Java**
```java
Presentation presentation = new Presentation();
```


**Aspose.Slides for PHP via Java**
```php
$presentation = new Presentation();
```


### **Énumérations ou constantes**

**Aspose.Slides for Java**
```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```


**Aspose.Slides for PHP via Java**
```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```


### **Exemple**

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
        // Instancie un objet Presentation qui représente un fichier de présentation
        Presentation pres = new Presentation();
        try
        {
            // Obtient la première diapositive
            ISlide slide = pres.getSlides().get_Item(0);

            // Ajoute une forme auto de type ligne
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
    // Obtient la première diapositive
    $slide = $pres->getSlides()->get_Item(0);

    // Ajoute une forme auto de type ligne
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```


### **Autres limitations d'Aspose.Slides pour PHP via l'API Java comparées à l'API Java d'Aspose.Slides**

Les espaces de noms Aspose.Slides et les classes Java qu'ils utilisent sont des wrappers créés par PhpJavaBridge au-dessus des classes Java portant le même nom du package com.aspose.slides.

#### **1. Encapsulation des paramètres et arguments Java**

Les paramètres et arguments qu'ils renvoient et acceptent sont des wrappers au-dessus des classes Java portant les mêmes noms. Seules les chaînes et les types numériques sont convertis automatiquement. Les tableaux, collections, octets et booléens ne sont pas convertis.  

**Une erreur courante :**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```


#### **2. Hériter d'une classe Java et opérateur instanceof**

Vous ne pouvez pas étendre une classe Java depuis une classe PHP. Comme solution de contournement, vous pouvez implémenter la composition si nécessaire.  
L'opérateur instanceof ne fonctionne que pour une classe concrète. Il ne fonctionne pas pour l'interface ou la classe parente d'une classe.  

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Un tableau Java n’est PAS un tableau PHP**

Création d'un tableau Java en PHP :
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```


#### **4. Longueur d'un tableau Java**
``` php
$data->length; - does NOT work
```

solution de contournement
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```


#### **5. La méthode Java Files.readAllBytes**
``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```

solution de contournement
```php
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


#### **6. La méthode Java Files.write**
``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - ne fonctionne pas
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
