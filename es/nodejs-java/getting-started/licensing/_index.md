---
title: Licenciamiento
description: "Aspose.Slides para Node.js a través de Java ofrece diferentes planes de compra o una Prueba Gratuita y una Licencia Temporal de 30 días para evaluación utilizando políticas de Licenciamiento y Suscripción."
type: docs
weight: 80
url: /es/nodejs-java/licensing/
---

A veces, para los mejores resultados de evaluación, puede ser necesario un enfoque práctico. Por esta razón, Aspose.Slides ofrece diferentes planes de compra y también una Prueba Gratuita y una Licencia Temporal de 30 días para evaluación.

{{% alert color="primary" %}}

Tenga en cuenta que hay una serie de políticas y prácticas generales que le guían sobre cómo evaluar, licenciar correctamente y comprar nuestros productos. Puede encontrarlas en la sección ["Políticas de Compra y Preguntas Frecuentes"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Evaluar Aspose.Slides**
Puede descargar fácilmente Aspose.Slides para evaluación. El paquete de evaluación es el mismo que el paquete comprado. La versión de evaluación simplemente se convierte en licenciada después de que agregue algunas líneas de código para aplicar la licencia.

## **Limitación de la Versión de Evaluación**
La versión de evaluación de Aspose.Slides (sin una licencia especificada) proporciona toda la funcionalidad del producto, pero inserta una marca de agua de evaluación en la parte superior del documento al abrir y guardar. También se limita a una diapositiva al extraer textos de las diapositivas de presentación.

{{% alert color="primary" %}} 

Si desea probar Aspose.Slides sin las limitaciones de la versión de evaluación, puede solicitar una **Licencia Temporal de 30 Días**. Consulte [¿Cómo obtener una Licencia Temporal?](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}} 

## **Acerca de la Licencia**
Puede descargar fácilmente una versión de evaluación de Aspose.Slides para Node.js a través de Java desde su [página de descarga](https://releases.aspose.com/slides/nodejs-java/). La versión de evaluación proporciona absolutamente **las mismas capacidades** que la versión licenciada de Aspose.Slides. Además, la versión de evaluación simplemente se convierte en licenciada después de que compre una licencia y agregue un par de líneas de código para aplicar la licencia.

La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de caducidad de la suscripción, etc. El archivo está firmado digitalmente, así que no modifique el archivo. Incluso una adición inadvertida de un salto de línea adicional al contenido del archivo lo invalidará.

Para evitar las limitaciones asociadas con la versión de evaluación, debe configurar una licencia antes de usar **Aspose.Slides**. Solo se requiere establecer una licencia una vez por aplicación o proceso.

## Licencia Comprada

Después de la compra, debe aplicar el archivo o flujo de licencia. 

{{% alert color="primary" %}}

Debe establecer la licencia:
* solo una vez por dominio de aplicación
* antes de usar cualquier otra clase de Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Puede encontrar información sobre precios en la página [“Información sobre Precios”](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **Configurando una Licencia en Aspose.Slides para Node.js a través de Java**

Las licencias se pueden aplicar desde estas ubicaciones:

* Ruta explícita
* Flujo
* Como Licencia Medida – un nuevo mecanismo de licenciamiento

{{% alert color="primary" %}}

Use el método **setLicense** para licenciar un componente.

Aunque múltiples llamadas a **setLicense** no son perjudiciales, son un desperdicio de recursos (procesador).

{{% /alert %}}

#### **Aplicando una Licencia Usando un Archivo**

Este fragmento de código se utiliza para establecer un archivo de licencia:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

Al llamar al método setLicense, el nombre de la licencia debe ser el mismo que el de su archivo de licencia. Por ejemplo, puede cambiar el nombre del archivo de licencia a "Aspose.Slides.lic.xml". Luego, en su código, debe pasar el nuevo nombre de licencia (Aspose.Slides.lic.xml) al método setLicense.

#### **Aplicando una Licencia desde un Flujo**

Este fragmento de código se utiliza para aplicar una licencia desde un flujo:

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

#### Aplicar Licencia Medida

Aspose.Slides permite a los desarrolladores aplicar una clave medida. Este es un nuevo mecanismo de licenciamiento.

El nuevo mecanismo de licenciamiento se usará junto con el método de licenciamiento existente. Aquellos clientes que deseen ser facturados según el uso de las características de la API pueden utilizar la Licencia Medida.

Después de completar todos los pasos necesarios para obtener este tipo de licencia, recibirá las claves, no el archivo de licencia. Esta clave medida se puede aplicar utilizando la clase **Metered** especialmente introducida para este propósito.

El siguiente ejemplo de código muestra cómo establecer las claves públicas y privadas medidas:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

# Crear una instancia de la clase Metered CAD
var metered = new aspose.slides.Metered();

# Acceder a la propiedad set_metered_key y pasar las claves públicas y privadas como parámetros
metered.setMeteredKey("*****", "*****");

# Obtener la cantidad de datos medidos antes de llamar a la API
var amountbefore = aspose.slides.Metered.getConsumptionQuantity();
# Mostrar información
console.log('Cantidad Consumida Antes: " + amountbefore + "' );

# Cargar el documento desde el disco.
var pres = new aspose.slides.Presentation();
# Obtener el recuento de páginas del documento
console.log('Cantidad Consumida Después: " +  pres.getSlides().size()) + "' );
# guardar como PDF
pres.save("out_pdf.pdf", aspose.slides.SaveFormat.Pdf);

# Obtener la cantidad de datos medidos después de llamar a la API
var amountafter = aspose.slides.Metered.getConsumptionQuantity();
# Mostrar información
console.log('Cantidad Consumida Después: " + amountafter + "' );
```

{{% alert color="primary" %}}

Tenga en cuenta que debe tener una conexión a Internet estable para el uso correcto de la licencia medida, ya que el mecanismo medido requiere una interacción constante con nuestros servicios para cálculos correctos. Para más detalles, consulte la sección [“Preguntas Frecuentes sobre Licencias Medidas”](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}