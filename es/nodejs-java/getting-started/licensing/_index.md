---
title: Licenciamiento
description: "Aspose.Slides for Node.js via Java ofrece diferentes planes de compra u ofrece una Prueba Gratuita y una Licencia Temporal de 30 días para evaluación utilizando las políticas de Licenciamiento y Suscripción."
type: docs
weight: 80
url: /es/nodejs-java/licensing/
---

A veces, para obtener los mejores resultados de evaluación, puede ser necesario un enfoque práctico. Por esta razón, Aspose.Slides ofrece diferentes planes de compra y también proporciona una Prueba Gratuita y una Licencia Temporal de 30 días para la evaluación.

{{% alert color="primary" %}}
Tenga en cuenta que existen varias políticas y prácticas generales que le orientan sobre cómo evaluar, licenciar adecuadamente y comprar nuestros productos. Puede encontrarlas en la sección ["Políticas de Compra y Preguntas Frecuentes"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Evaluar Aspose.Slides**
Puede descargar fácilmente Aspose.Slides para evaluación. El paquete de evaluación es idéntico al paquete comprado. La versión de evaluación simplemente se licencia después de agregar unas pocas líneas de código para aplicar la licencia. 

## **Limitaciones de la Versión de Evaluación**
La versión de evaluación de Aspose.Slides (sin una licencia especificada) proporciona la funcionalidad completa del producto, pero inserta una marca de agua de evaluación en la parte superior del documento al abrirlo y guardarlo. Además, está limitado a una diapositiva al extraer texto de las diapositivas de la presentación.

{{% alert color="primary" %}} 
Si desea probar Aspose.Slides sin las limitaciones de la versión de evaluación, puede solicitar una **Licencia Temporal de 30 Días**. Consulte [¿Cómo obtener una Licencia Temporal?](https://purchase.aspose.com/temporary-license) para más información.
{{% /alert %}} 

## **Acerca de la Licencia**
Puede descargar fácilmente una versión de evaluación de Aspose.Slides para Node.js a través de Java desde su [página de descarga](https://releases.aspose.com/slides/nodejs-java/). La versión de evaluación brinda **exactamente las mismas capacidades** que la versión con licencia de Aspose.Slides. Además, la versión de evaluación simplemente se licencia después de comprar una licencia y agregar un par de líneas de código para aplicarla.

La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, la cantidad de desarrolladores a los que está licenciada, la fecha de vencimiento de la suscripción, etc. El archivo está firmado digitalmente, por lo que no debe modificarse. Incluso la adición accidental de una línea en blanco extra al contenido del archivo lo invalidará.

Para evitar las limitaciones asociadas con la versión de evaluación, debe establecer una licencia antes de usar **Aspose.Slides**. Sólo es necesario establecer la licencia una vez por aplicación o proceso.

{{% alert color="primary" %}} 
Puede que desee consultar [Licenciamiento por Medición](https://docs.aspose.com/slides/nodejs-java/metered-licensing/).
{{% /alert %}} 

## **Licencia Adquirida**

Después de la compra, debe aplicar el archivo o flujo de licencia. 

{{% alert color="primary" %}}
Debe establecer la licencia:
* solo una vez por dominio de aplicación
* antes de usar cualquier otra clase de Aspose.Slides
{{% /alert %}}

{{% alert color="primary" %}}
Puede encontrar la información de precios en la página [“Información de Precios”](https://purchase.aspose.com/pricing/slides/family).
{{% /alert %}}

### **Establecer una Licencia en Aspose.Slides para Node.js a través de Java**

Las licencias pueden aplicarse desde estas ubicaciones:

* Ruta explícita
* Flujo
* Como Licencia por Medición – un nuevo mecanismo de licenciamiento

{{% alert color="primary" %}}
Utilice el método **setLicense** para licenciar un componente.

Aunque varias llamadas a **setLicense** no son dañinas, consumen recursos (procesador) innecesariamente.
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


Al llamar al método setLicense, el nombre de la licencia debe coincidir con el de su archivo de licencia. Por ejemplo, puede cambiar el nombre del archivo de licencia a "Aspose.Slides.lic.xml". Luego, en su código, debe pasar el nuevo nombre de la licencia (Aspose.Slides.lic.xml) al método setLicense.

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


## **Preguntas Frecuentes**

**¿Puedo aplicar la licencia en un entorno totalmente offline (sin acceso a Internet)?**

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se requiere conexión a Internet.

**¿Qué ocurre cuando expira la suscripción de un año? ¿Dejará de funcionar la biblioteca?**

No. La licencia es perpetua: puede seguir usando las versiones lanzadas antes de la fecha de finalización de su suscripción; simplemente no podrá usar versiones más recientes sin renovar.