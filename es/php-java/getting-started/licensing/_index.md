---
title: Licencias
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
description: "Aplicar, gestionar y solucionar problemas de licencias en Aspose.Slides para PHP a través de Java. Garantiza el acceso ininterrumpido a todas las funciones con nuestra guía paso a paso de licenciamiento."
---
## **Introducción**

A veces, para obtener los mejores resultados de evaluación, puede ser necesario un enfoque práctico. Por este motivo, Aspose.Slides ofrece diferentes planes de compra y también proporciona una Prueba Gratuita y una Licencia Temporal de 30 días para la evaluación.

{{% alert color="info" title="Nota" %}}
Ten en cuenta que existen varias políticas y prácticas generales que te guían sobre cómo evaluar, licenciar correctamente y comprar nuestros productos. Puedes encontrarlas en la sección ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Evaluar Aspose.Slides**
Puedes descargar Aspose.Slides fácilmente para su evaluación. El paquete de evaluación es idéntico al paquete adquirido. La versión de evaluación simplemente se licencia después de añadir unas pocas líneas de código para aplicar la licencia. 

## **Limitaciones de la versión de evaluación**
La versión de evaluación de Aspose.Slides (sin una licencia especificada) ofrece la funcionalidad completa del producto, con dos limitaciones:

* Añade un cuadro de texto con marca de agua de evaluación en el centro de cada diapositiva de cada presentación que se guarda.
* El texto que tu código lee de una presentación se trunca a sus primeros caracteres, seguido de un aviso sobre la limitación de la evaluación. El texto que tu código escribe se guarda completo.

{{% alert color="info" title="Nota" %}}
Si deseas probar Aspose.Slides sin las limitaciones de la versión de evaluación, puedes solicitar una **Licencia Temporal de 30 días**. Consulta [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) para más información.
{{% /alert %}} 

## **Acerca de la licencia**
Puedes descargar fácilmente una versión de evaluación de Aspose.Slides para PHP a través de Java desde su [download page](https://packagist.org/packages/aspose/slides). La versión de evaluación proporciona **las mismas capacidades** que la versión con licencia de Aspose.Slides. Además, la versión de evaluación simplemente se licencia después de comprar una licencia y añadir un par de líneas de código para aplicarla.

La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de expiración de la suscripción, etc. El archivo está firmado digitalmente, por lo que no debe modificarse. Incluso la adición accidental de un salto de línea extra al contenido del archivo lo invalidará.

Para evitar las limitaciones asociadas a la versión de evaluación, debes establecer una licencia antes de usar **Aspose.Slides**. Sólo es necesario establecer la licencia una vez por aplicación o proceso.

{{% alert color="info" title="Nota" %}}
Puede que quieras consultar [Metered Licensing](/slides/es/php-java/metered-licensing/).
{{% /alert %}} 

## **Licencia comprada**

Después de la compra, necesitas aplicar el archivo o flujo de licencia. 

{{% alert color="info" title="Nota" %}}
Debes establecer la licencia:
* sólo una vez por dominio de aplicación
* antes de usar cualquier otra clase de Aspose.Slides
{{% /alert %}}

{{% alert color="info" title="Nota" %}}
Puedes encontrar información de precios en la página de ["Pricing Information"](https://purchase.aspose.com/pricing/slides/family).
{{% /alert %}}

### **Establecer una licencia en Aspose.Slides para PHP a través de Java**

Las licencias pueden aplicarse desde estas ubicaciones:

* Ruta explícita
* Flujo
* Como Licencia por consumo – un nuevo mecanismo de licenciamiento

{{% alert color="info" title="Nota" %}}
Utiliza el método **setLicense** para licenciar un componente.

Aunque varias llamadas a **setLicense** no son perjudiciales, suponen un desperdicio de recursos (procesador).
{{% /alert %}}

{{% alert color="warning" title="Advertencia" %}}
Las licencias nuevas pueden activar Aspose.Slides sólo a partir de la versión 21.4 o posterior. Las versiones anteriores usan un sistema de licenciamiento diferente y no reconocerán estas licencias.
{{% /alert %}}

#### **Aplicar una licencia mediante un archivo**

Este fragmento de código se usa para establecer un archivo de licencia:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/es/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

El ejemplo supone que el archivo de licencia está junto al script y pasa su ruta absoluta: Aspose.Slides se ejecuta dentro de Tomcat, por lo que no resuelve una ruta relativa respecto a la carpeta de tu script. Al llamar al método setLicense, el nombre de la licencia debe ser idéntico al de tu archivo de licencia. Por ejemplo, puedes cambiar el nombre del archivo de licencia a "Aspose.Slides.lic.xml". Entonces, en tu código, deberás pasar el nuevo nombre de licencia (Aspose.Slides.lic.xml) al método setLicense.

#### **Aplicar una licencia desde un flujo**

Este fragmento de código se usa para aplicar una licencia desde un flujo:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/es/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **Preguntas frecuentes**

### ¿Puedo aplicar la licencia en un entorno completamente offline (sin acceso a internet)?

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se requiere conexión a internet.

### ¿Qué ocurre cuando expira la suscripción de un año? ¿Dejará de funcionar la biblioteca?

No. La licencia es perpetua: puedes seguir usando las versiones publicadas antes de la fecha de finalización de tu suscripción; simplemente no podrás usar versiones más recientes sin renovar.