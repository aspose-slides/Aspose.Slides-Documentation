---
title: Licencia
description: "Aspose.Slides for Node.js via Java ofrece diferentes planes de compra o brinda una Prueba Gratuita y una Licencia Temporal de 30 días para evaluación mediante políticas de Licenciamiento y Suscripción."
type: docs
weight: 80
url: /es/nodejs-java/licensing/
---

A veces, para obtener los mejores resultados de evaluación, puede ser necesario un enfoque práctico. Por este motivo, Aspose.Slides ofrece diferentes planes de compra y también brinda una Prueba Gratuita y una Licencia Temporal de 30 días para la evaluación.

{{% alert color="primary" %}}
Tenga en cuenta que existen varias políticas y prácticas generales que le guían sobre cómo evaluar, licenciar correctamente y comprar nuestros productos. Puede encontrarlas en la sección ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Evaluar Aspose.Slides**
Puede descargar fácilmente Aspose.Slides para evaluación. El paquete de evaluación es idéntico al paquete adquirido. La versión de evaluación simplemente se licencia después de agregar unas pocas líneas de código para aplicar la licencia. 

## **Limitaciones de la Versión de Evaluación**
La versión de evaluación de Aspose.Slides (sin una licencia especificada) proporciona la funcionalidad completa del producto, pero inserta una marca de agua de evaluación en la parte superior del documento al abrirlo y guardarlo. Además, está limitado a una diapositiva al extraer texto de las diapositivas de la presentación.

{{% alert color="primary" %}} 
Si desea probar Aspose.Slides sin las limitaciones de la versión de evaluación, puede solicitar una **Licencia Temporal de 30 Días**. Consulte [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) para obtener más información.
{{% /alert %}} 

## **Acerca de la Licencia**
Puede descargar fácilmente una versión de evaluación de Aspose.Slides for Node.js via Java desde su [download page](https://releases.aspose.com/slides/nodejs-java/). La versión de evaluación proporciona absolutamente **las mismas capacidades** que la versión con licencia de Aspose.Slides. Además, la versión de evaluación simplemente se licencia después de comprar una licencia y agregar un par de líneas de código para aplicarla.

La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de expiración de la suscripción, etc. El archivo está firmado digitalmente, por lo que no debe modificarlo. Incluso la adición inadvertida de un salto de línea extra al contenido del archivo lo invalidará.

Para evitar las limitaciones asociadas con la versión de evaluación, debe establecer una licencia antes de usar **Aspose.Slides**. Solo es necesario establecer la licencia una vez por aplicación o proceso.

{{% alert color="primary" %}} 
Es posible que desee ver [Metered Licensing](https://docs.aspose.com/slides/nodejs-java/metered-licensing/).
{{% /alert %}} 

## **Licencia Adquirida**

Después de la compra, debe aplicar el archivo o flujo de licencia. 

{{% alert color="primary" %}}
Debe establecer la licencia:
* solo una vez por dominio de aplicación
* antes de usar cualquier otra clase de Aspose.Slides
{{% /alert %}}

{{% alert color="primary" %}}
Puede encontrar información de precios en la página ["Pricing Information"](https://purchase.aspose.com/pricing/slides/family).
{{% /alert %}}

### **Establecer una Licencia en Aspose.Slides for Node.js via Java**

Las licencias pueden aplicarse desde estas ubicaciones:

* Ruta explícita
* Flujo
* Como Licencia Medida – un nuevo mecanismo de licenciamiento

{{% alert color="primary" %}}
Utilice el método **setLicense** para licenciar un componente.

Aunque múltiples llamadas a **setLicense** no son dañinas, son un desperdicio de recursos (procesador).
{{% /alert %}}

{{% alert color="warning" %}}
Las licencias nuevas pueden activar Aspose.Slides solo con la versión 21.4 o posterior. Las versiones anteriores usan un sistema de licenciamiento diferente y no reconocerán estas licencias.
{{% /alert %}}

#### **Aplicar una Licencia Usando un Archivo**

Este fragmento de código se usa para establecer un archivo de licencia:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

Al llamar al método setLicense, el nombre de la licencia debe ser el mismo que el de su archivo de licencia. Por ejemplo, puede cambiar el nombre del archivo de licencia a "Aspose.Slides.lic.xml". Luego, en su código, debe pasar el nuevo nombre de licencia (Aspose.Slides.lic.xml) al método setLicense.

#### **Aplicar una Licencia desde un Flujo**

Este fragmento de código se usa para aplicar una licencia desde un flujo:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```

## **Preguntas frecuentes**

**¿Puedo aplicar la licencia en un entorno completamente offline (sin acceso a internet)?**

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se requiere conexión a internet.

**¿Qué ocurre después de que expire la suscripción de un año? ¿Dejará de funcionar la biblioteca?**

No. La licencia es perpetua: puede seguir utilizando las versiones publicadas antes de la fecha de finalización de su suscripción; simplemente no podrá usar versiones más recientes sin renovar.