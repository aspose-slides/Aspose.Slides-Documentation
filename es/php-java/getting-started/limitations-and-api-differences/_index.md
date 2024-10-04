---
title: Limitaciones y Diferencias en la API
type: docs
weight: 100
url: /php-java/limitations-and-api-differences/
---


## **Diferencias en la API Pública**

Esta lista, utilizando fragmentos de código de ejemplo, demuestra ciertas diferencias entre Aspose.Slides para Java y Aspose.Slides para PHP a través de las API de Java.

### **Importando biblioteca (Comparaciones de paquetes)**

**Aspose.Slides para Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides para PHP a través de Java**

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\sldes;
use aspose\sldes\Presentation;
```

### **Instanciando una nueva Presentación**

**Aspose.Slides para Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides para PHP a través de Java**

```php
$presentation = new Presentation();
```

### **Enums o Constantes**

**Aspose.Slides para Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides para PHP a través de Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Ejemplo**

**Aspose.Slides para Java**

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

            // Agrega una forma automática con el tipo establecido en línea
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

**Aspose.Slides para PHP a través de Java**

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

    // Agrega una forma automática con el tipo establecido en línea
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Otras Limitaciones de Aspose.Slides para PHP a través de la API de Java en comparación con la API de Aspose.Slides para Java**

Los espacios de nombres de Aspose.Slides y las clases de java que utilizan son envoltorios creados por el PhpJavaBridge sobre las clases de Java con el mismo nombre del paquete com.aspose.slides.

#### 1. **Envolviendo parámetros y argumentos de java**

Los parámetros y argumentos que devuelven y aceptan son envoltorios sobre las clases de Java con los mismos nombres. Solo los tipos de cadena y numéricos se convierten automáticamente. Los arreglos, colecciones, bytes y booleanos no se convierten.  

**Un error común:**
``` php
if ($node->isAssistant()) - ¡incorrecto!
if (java_values($node->isAssistant())) - ¡correcto!
```

#### 2. **Extendiendo clase de Java y operador instanceof**

No puedes extender una clase de Java desde una clase PHP. Como solución alternativa, puedes implementar composición cuando sea necesario.
El operador instanceof solo funciona para una clase concreta. No funciona para la interfaz o clase padre de una clase. 

[solución alternativa](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### 3. **Un arreglo de Java NO es un arreglo de PHP**

Creación de arreglos de Java en PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### 4. **Longitud de un arreglo de Java**

``` php
$data->length; - NO funciona
```
solución alternativa
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### 5. **El método de Java Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - NO funciona
```
solución alternativa
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

#### 6. **El método de Java Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - NO funciona
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