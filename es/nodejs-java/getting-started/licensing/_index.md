---
title: Licenciamiento
type: docs
weight: 80
url: /es/nodejs-java/licensing/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aplique, gestione y solucione problemas de licencias en Aspose.Slides para Node.js. Garantice un acceso ininterrumpido a todas las funciones con nuestra guía paso a paso de licenciamiento."
---
## **Introducción**

A veces, para obtener los mejores resultados de evaluación, puede ser necesario un enfoque práctico. Por esta razón, Aspose.Slides ofrece diferentes planes de compra y también brinda una Prueba Gratuita y una Licencia Temporal de 30 días para la evaluación.

{{% alert color="info" title="Note" %}}
Tenga en cuenta que existen una serie de políticas y prácticas generales que le guían sobre cómo evaluar, licenciar correctamente y adquirir nuestros productos. Puede encontrarlas en la sección ["Políticas de compra y preguntas frecuentes"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Evaluar Aspose.Slides**
Puede descargar fácilmente Aspose.Slides para evaluación. El paquete de evaluación es idéntico al paquete comprado. La versión de evaluación simplemente se licencia después de agregar unas pocas líneas de código para aplicar la licencia. 

## **Limitaciones de la versión de evaluación**
La versión de evaluación de Aspose.Slides (sin una licencia especificada) ofrece la funcionalidad completa del producto, con dos limitaciones:

* Añade un cuadro de texto de marca de agua de evaluación a cada diapositiva de cada presentación que guarda.
* El texto de más de cinco caracteres que su código lee de una presentación se recorta a sus primeros cinco caracteres, seguido de `... text has been truncated due to evaluation version limitation.` El texto de cinco caracteres o menos se devuelve sin cambios, y el texto que su código escribe se guarda completo.

{{% alert color="info" title="Note" %}}
Si desea probar Aspose.Slides sin las limitaciones de la versión de evaluación, puede solicitar una **Licencia Temporal de 30 días**. Consulte [¿Cómo obtener una Licencia Temporal?](https://purchase.aspose.com/temporary-license) para obtener más información.
{{% /alert %}}

## **Acerca de la licencia**
Puede descargar fácilmente una versión de evaluación de Aspose.Slides para Node.js a través de Java desde su [página de descarga](https://releases.aspose.com/slides/nodejs-java/). La versión de evaluación tiene las mismas características que la versión con licencia, con las limitaciones descritas anteriormente. Además, la versión de evaluación simplemente se licencia después de comprar una licencia y agregar un par de líneas de código para aplicar la licencia.

La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciado, la fecha de caducidad de la suscripción, etc. El archivo está firmado digitalmente, por lo que no debe modificarlo. Incluso la adición accidental de una línea extra al contenido del archivo lo invalidará.

Para evitar las limitaciones asociadas a la versión de evaluación, debe establecer una licencia antes de usar **Aspose.Slides**. Solo es necesario establecer una licencia una vez por aplicación o proceso.

{{% alert color="info" title="Note" %}}
Puede que desee consultar [Licenciamiento por consumo](/slides/es/nodejs-java/metered-licensing/).
{{% /alert %}}

## **Licencia comprada**

Después de la compra, debe aplicar el archivo o flujo de licencia. 

{{% alert color="info" title="Note" %}}
Debe establecer la licencia:
* solo una vez por proceso
* antes de usar cualquier otra clase de Aspose.Slides
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Puede encontrar información de precios en la página [“Información de precios”](https://purchase.aspose.com/pricing/slides/family).
{{% /alert %}}

### **Establecer una licencia en Aspose.Slides para Node.js a través de Java**

Las licencias pueden aplicarse desde estas ubicaciones:

* Ruta explícita
* Flujo
* Como Licencia por consumo – un nuevo mecanismo de licenciamiento

{{% alert color="info" title="Note" %}}
Utilice el método **setLicense** para licenciar un componente.

Aunque varias llamadas a **setLicense** no son dañinas, son un desperdicio de recursos (procesador).
{{% /alert %}}

#### **Aplicar una licencia usando un archivo**

Este fragmento de código se utiliza para establecer un archivo de licencia:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides se ejecuta en una máquina virtual Java que mantiene Node.js en ejecución, por lo que debe finalizar el proceso explícitamente.
process.exit(0);
```

Al llamar al método setLicense, el nombre de la licencia debe coincidir con el de su archivo de licencia. Por ejemplo, puede cambiar el nombre del archivo de licencia a "Aspose.Slides.lic.xml". Luego, en su código, debe pasar el nuevo nombre de licencia (Aspose.Slides.lic.xml) al método setLicense. Si el archivo falta o no contiene una licencia válida, [setLicense](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/) lanza una excepción, lo que termina el script con un error.

#### **Aplicar una licencia desde un flujo**

Para aplicar una licencia desde un flujo, pase el objeto [License](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/) y un flujo legible al método estático [setLicenseFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/). El flujo se lee de forma asíncrona, y la devolución de llamada recibe un error si el flujo no contiene una licencia válida:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides se ejecuta en una máquina virtual Java que mantiene Node.js en ejecución, por lo que se debe finalizar el proceso explícitamente.
    process.exit(0);
});
```

La licencia se aplica cuando se ha leído todo el flujo, justo antes de que se ejecute la devolución de llamada, por lo que debe iniciar otro trabajo de Aspose.Slides desde la devolución de llamada.

Ambas muestras llaman a `process.exit(0)` al finalizar, porque la máquina virtual Java que ejecuta Aspose.Slides mantiene Node.js en ejecución. En una aplicación, continue con su código de Aspose.Slides en lugar de terminar el proceso.

## **Preguntas frecuentes**

### ¿Puedo aplicar la licencia en un entorno completamente offline (sin acceso a internet)?
Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se requiere conexión a internet.

### ¿Qué ocurre después de que expire la suscripción de un año? ¿Dejará de funcionar la biblioteca?
No. La licencia es perpetua: puede seguir usando las versiones publicadas antes de la fecha de finalización de su suscripción; simplemente no podrá usar versiones más recientes sin renovar.