---
title: Licencias
description: "Aspose.Slides para PHP a través de Java ofrece diferentes planes de compra o proporciona una Prueba Gratuita y una Licencia Temporal de 30 días para evaluación utilizando políticas de Licencias y Suscripciones."
type: docs
weight: 80
url: /php-java/licensing/
---

A veces, para obtener los mejores resultados de evaluación, puede ser necesario un enfoque práctico. Por esta razón, Aspose.Slides ofrece diferentes planes de compra y también ofrece una Prueba Gratuita y una Licencia Temporal de 30 días para evaluación.

{{% alert color="primary" %}}

Tenga en cuenta que hay una serie de políticas y prácticas generales que le guían sobre cómo evaluar, licenciar correctamente y comprar nuestros productos. Puede encontrarlas en la sección ["Políticas de Compra y Preguntas Frecuentes"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Evaluar Aspose.Slides**
Puede descargar fácilmente Aspose.Slides para su evaluación. El paquete de evaluación es el mismo que el paquete comprado. La versión de evaluación simplemente se licencia después de que agregue algunas líneas de código para aplicar la licencia.

## **Limitación de la Versión de Evaluación**
La versión de evaluación de Aspose.Slides (sin una licencia especificada) proporciona la funcionalidad completa del producto, pero inserta una marca de agua de evaluación en la parte superior del documento al abrir y guardar. También se limita a una diapositiva al extraer textos de las diapositivas de presentación.

{{% alert color="primary" %}} 

Si desea probar Aspose.Slides sin las limitaciones de la versión de evaluación, puede solicitar una **Licencia Temporal de 30 Días**. Consulte [¿Cómo obtener una Licencia Temporal?](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}} 

## **Acerca de la Licencia**
Puede descargar fácilmente una versión de evaluación de Aspose.Slides para PHP a través de Java desde su [página de descarga](https://packagist.org/packages/aspose/slides). La versión de evaluación proporciona **las mismas capacidades** que la versión licenciada de Aspose.Slides. Además, la versión de evaluación simplemente se licencia después de que compre una licencia y agregue un par de líneas de código para aplicar la licencia.

La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de caducidad de la suscripción, etc. El archivo está digitalmente firmado, así que no modifique el archivo. Incluso la adición inadvertida de un salto de línea adicional al contenido del archivo lo invalidará.

Para evitar las limitaciones asociadas a la versión de evaluación, necesita establecer una licencia antes de usar **Aspose.Slides**. Solo se requiere establecer una licencia una vez por aplicación o proceso.

## Licencia Comprada

Después de la compra, necesita aplicar el archivo o flujo de licencia.

{{% alert color="primary" %}}

Necesita establecer la licencia:
* solo una vez por dominio de aplicación
* antes de usar cualquier otra clase de Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Puede encontrar información de precios en la página [“Información de Precios”](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **Estableciendo una Licencia en Aspose.Slides para PHP a través de Java**

Las licencias pueden aplicarse desde estos lugares:

* Ruta explícita
* Flujo
* Como Licencia Medida – un nuevo mecanismo de licenciamiento

{{% alert color="primary" %}}

Use el método **setLicense** para licenciar un componente.

Si bien múltiples llamadas a **setLicense** no son dañinas, son un desperdicio de recursos (procesador).

{{% /alert %}}

#### **Aplicando una Licencia Usando un Archivo**

Este fragmento de código se usa para establecer un archivo de licencia:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

Al llamar al método setLicense, el nombre de la licencia debe ser el mismo que el de su archivo de licencia. Por ejemplo, puede cambiar el nombre del archivo de licencia a "Aspose.Slides.lic.xml". Luego, en su código, debe pasar el nuevo nombre de la licencia (Aspose.Slides.lic.xml) al método setLicense.

#### **Aplicando una Licencia desde un Flujo**

Este fragmento de código se usa para aplicar una licencia desde un flujo:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

#### Aplicar Licencia Medida

Aspose.Slides permite a los desarrolladores aplicar una clave medida. Este es un nuevo mecanismo de licenciamiento.

El nuevo mecanismo de licenciamiento se utilizará junto con el método de licenciamiento existente. Aquellos clientes que deseen ser facturados según el uso de las características de la API pueden utilizar la Licencia Medida.

Después de completar todos los pasos necesarios para obtener este tipo de licencia, recibirá las claves, no el archivo de licencia. Esta clave medida se puede aplicar usando la clase **Metered** especialmente introducida para este propósito.

El siguiente ejemplo de código muestra cómo establecer claves públicas y privadas medidas:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Metered;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

# Crear una instancia de la clase Metered
$metered = new Metered();

# Acceder a la propiedad set_metered_key y pasar claves públicas y privadas como parámetros
$metered->setMeteredKey("*****", "*****");

# Obtener la cantidad de datos medidos antes de llamar a la API
$amountbefore = Metered::getConsumptionQuantity();
# Mostrar información
echo "<script>console.log('Cantidad Consumida Antes: " . java_values($amountbefore) . "' );</script>";

# Cargar el documento desde el disco.
$pres = new Presentation();
# Obtener el recuento de páginas del documento
echo "<script>console.log('Cantidad Consumida Después: " . java_values($pres->getSlides()->size()) . "' );</script>";
# guardar como PDF
$pres->save("out_pdf.pdf", SaveFormat::Pdf);

# Obtener la cantidad de datos medidos después de llamar a la API
$amountafter = Metered::getConsumptionQuantity();
# Mostrar información
echo "<script>console.log('Cantidad Consumida Después: " . java_values($amountafter) . "' );</script>";
?>
```

{{% alert color="primary" %}}

Tenga en cuenta que debe tener una conexión a Internet estable para el correcto uso de la Licencia Medida, ya que el mecanismo Medido requiere la constante interacción con nuestros servicios para cálculos correctos. Para más detalles, consulte la sección [“Preguntas Frecuentes sobre Licencias Medidas”](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}