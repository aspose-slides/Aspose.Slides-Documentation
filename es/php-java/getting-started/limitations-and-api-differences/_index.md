---
title: Limitaciones y Diferencias de la API
type: docs
weight: 100
url: /es/php-java/limitations-and-api-differences/
keywords:
- limitación
- diferencias de API
- comparación de paquetes
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Comparar las limitaciones y diferencias de la API entre Aspose.Slides for PHP via Java y Aspose.Slides for Java."
---

## **Diferencias de la API Pública**

Esta lista, usando fragmentos de código de ejemplo, muestra ciertas diferencias entre Aspose.Slides for Java y Aspose.Slides for PHP a través de las API de Java.

### **Importar biblioteca (Comparaciones de paquetes)**

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


### **Instanciar una nueva presentación**

**Aspose.Slides for Java**
```java
Presentation presentation = new Presentation();
```


**Aspose.Slides for PHP via Java**
```php
$presentation = new Presentation();
```


### **Enumeraciones o Constantes**

**Aspose.Slides for Java**
```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```


**Aspose.Slides for PHP via Java**
```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```


### **Ejemplo**

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
        // Instancia un objeto Presentation que representa un archivo de presentación
        Presentation pres = new Presentation();
        try
        {
            // Obtiene la primera diapositiva
            ISlide slide = pres.getSlides().get_Item(0);

            // Añade una forma automática con el tipo establecido como línea
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
    // Obtiene la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);

    // Añade una forma automática con el tipo establecido como línea
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pppt);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```


### **Otras limitaciones de Aspose.Slides for PHP a través de la API Java comparada con la API de Aspose.Slides for Java**

Los espacios de nombres de Aspose.Slides y las clases java que utilizan son envoltorios creados por PhpJavaBridge sobre las clases Java con el mismo nombre del paquete com.aspose.slides.

#### **1. Envolviendo parámetros y argumentos de Java**

Los parámetros y argumentos que devuelven y aceptan son envoltorios sobre las clases Java con los mismos nombres. Sólo las cadenas y los tipos numéricos se convierten automáticamente. Los arreglos, colecciones, bytes y booleanos no se convierten.  

**Un error común:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```


#### **2. Extender una clase Java y el operador instanceof**

No puedes extender una clase Java desde una clase PHP. Como solución alternativa, puedes implementar composición cuando sea necesario. El operador instanceof sólo funciona para una clase concreta. No funciona para la interfaz o clase padre de una clase.  

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Un arreglo Java NO es un arreglo PHP**

Creación de un arreglo Java en PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```


#### **4. Longitud de un arreglo Java**
``` php
$data->length; - does NOT work
```

solución alternativa
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```


#### **5. El método Java Files.readAllBytes**
```php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```

solución alternativa
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


#### **6. El método Java Files.write**
``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - does NOT work
```

solución alternativa
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```
