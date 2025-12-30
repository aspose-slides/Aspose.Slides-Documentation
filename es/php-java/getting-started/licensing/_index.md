---
title: Licenciamiento
type: docs
weight: 80
url: /es/php-java/licensing/
keywords:
- licencia
- licencia temporal
- establecer licencia
- usar licencia
- validar licencia
- archivo de licencia
- versión de evaluación
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Aplica, gestiona y soluciona problemas de licencias en Aspose.Slides para PHP a través de Java. Garantiza un acceso ininterrumpido a todas las funcionalidades con nuestra guía paso a paso de licenciamiento."
---

A veces, para obtener los mejores resultados de evaluación, puede ser necesario un enfoque práctico. Por esta razón, Aspose.Slides ofrece diferentes planes de compra y también proporciona una versión de prueba gratuita y una Licencia Temporal de 30 días para la evaluación.

{{% alert color="primary" %}}
Nota: existen diversas políticas y prácticas generales que le indican cómo evaluar, licenciar correctamente y adquirir nuestros productos. Puede encontrarlas en la sección [Políticas de compra y preguntas frecuentes](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Evaluar Aspose.Slides**
Puede descargar Aspose.Slides para evaluación de forma sencilla. El paquete de evaluación es idéntico al paquete adquirido. La versión de evaluación simplemente se licencian añadiendo unas pocas líneas de código para aplicar la licencia.

## **Limitación de la versión de evaluación**
La versión de evaluación de Aspose.Slides (sin especificar una licencia) proporciona la funcionalidad completa del producto, pero inserta una marca de agua de evaluación en la parte superior del documento al abrirlo y guardarlo. Además, está limitado a una diapositiva al extraer texto de las presentaciones.

{{% alert color="primary" %}} 
Si desea probar Aspose.Slides sin las limitaciones de la versión de evaluación, puede solicitar una **Licencia Temporal de 30 días**. Consulte [¿Cómo obtener una licencia temporal?](https://purchase.aspose.com/temporary-license) para más información.
{{% /alert %}} 

## **Acerca de la licencia**
Puede descargar fácilmente una versión de evaluación de Aspose.Slides para PHP vía Java desde su [página de descarga](https://packagist.org/packages/aspose/slides). La versión de evaluación ofrece absolutamente **las mismas capacidades** que la versión con licencia de Aspose.Slides. Además, la versión de evaluación simplemente se licencian después de adquirir una licencia y añadir un par de líneas de código para aplicar la licencia.

La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciado, la fecha de vencimiento de la suscripción, etc. El archivo está firmado digitalmente, por lo que no debe modificarlo. Incluso la adición inadvertida de una línea extra al contenido del archivo lo invalidará.

Para evitar las limitaciones asociadas a la versión de evaluación, debe establecer una licencia antes de usar **Aspose.Slides**. Sólo es necesario establecer la licencia una vez por aplicación o proceso.

{{% alert color="primary" %}} 
Puede consultar [Licenciamiento por consumo](https://docs.aspose.com/slides/php-java/metered-licensing/).
{{% /alert %}} 

## **Licencia adquirida**

Tras la compra, debe aplicar el archivo o flujo de la licencia.

{{% alert color="primary" %}}
Debe establecer la licencia:
* una sola vez por dominio de aplicación
* antes de usar cualquier otra clase de Aspose.Slides
{{% /alert %}}

{{% alert color="primary" %}}
Puede encontrar la información de precios en la página de ["Información de precios"](https://purchase.aspose.com/pricing/slides/family).
{{% /alert %}}

### **Establecer una licencia en Aspose.Slides para PHP vía Java**

Las licencias pueden aplicarse desde estas ubicaciones:

* Ruta explícita
* Flujo
* Como Licencia por consumo – un nuevo mecanismo de licenciamiento

{{% alert color="primary" %}}
Utilice el método **setLicense** para licenciar un componente.

Aunque múltiples llamadas a **setLicense** no son dañinas, representan un desperdicio de recursos (procesador).
{{% /alert %}}

{{% alert color="warning" %}}
Las licencias nuevas pueden activar Aspose.Slides sólo a partir de la versión 21.4 o posterior. Las versiones anteriores usan un sistema de licenciamiento diferente y no reconocerán estas licencias.
{{% /alert %}}

#### **Aplicar una licencia mediante un archivo**

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


Al llamar al método setLicense, el nombre de la licencia debe coincidir con el de su archivo de licencia. Por ejemplo, puede cambiar el nombre del archivo de licencia a "Aspose.Slides.lic.xml". Luego, en su código, debe pasar el nuevo nombre de licencia (Aspose.Slides.lic.xml) al método setLicense.

#### **Aplicar una licencia desde un flujo**

Este fragmento de código se usa para aplicar una licencia desde un flujo:
```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```


## **Preguntas frecuentes**

**¿Puedo aplicar la licencia en un entorno totalmente offline (sin acceso a internet)?**

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se necesita conexión a internet.

**¿Qué ocurre después de que expira la suscripción de un año? ¿La biblioteca deja de funcionar?**

No. La licencia es perpetua: puede seguir usando versiones publicadas antes de la fecha de finalización de su suscripción; simplemente no podrá usar versiones más recientes sin renovar.