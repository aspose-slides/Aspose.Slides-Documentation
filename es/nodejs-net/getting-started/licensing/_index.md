---
title: Licenciamiento
description: "Aspose.Slides para Node.js a través de .NET ofrece diferentes planes de compra o una Prueba Gratuita y una Licencia Temporal de 30 días para evaluación utilizando políticas de Licenciamiento y Suscripción."
type: docs
weight: 80
url: /nodejs-net/licensing/
---

A veces, para los mejores resultados de evaluación, puede ser necesario un enfoque práctico. Por esta razón, Aspose.Slides ofrece diferentes planes de compra y también una Prueba Gratuita y una Licencia Temporal de 30 días para evaluación.

{{% alert color="primary" %}}

Tenga en cuenta que existen una serie de políticas y prácticas generales que le guían sobre cómo evaluar, licenciar adecuadamente y comprar nuestros productos. Puede encontrarlas en la sección ["Políticas de Compra y Preguntas Frecuentes"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Evaluar Aspose.Slides**
Puede descargar fácilmente Aspose.Slides para evaluación. El paquete de evaluación es el mismo que el paquete comprado. La versión de evaluación simplemente se licencia después de que agregue algunas líneas de código para aplicar la licencia.

## **Limitación de la Versión de Evaluación**
La versión de evaluación de Aspose.Slides (sin una licencia especificada) proporciona la funcionalidad completa del producto, pero inserta una marca de agua de evaluación en la parte superior del documento al abrir y guardar. También está limitado a una diapositiva al extraer textos de las diapositivas de presentación.

{{% alert color="primary" %}} 

Si desea probar Aspose.Slides sin las limitaciones de la versión de evaluación, puede solicitar una **Licencia Temporal de 30 Días**. Consulte [¿Cómo obtener una Licencia Temporal?](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}} 

## **Acerca de la Licencia**
Puede descargar fácilmente una versión de evaluación de Aspose.Slides para Node.js a través de .NET desde su [página de descargas](https://releases.aspose.com/slides/nodejs-net/). La versión de evaluación proporciona **las mismas capacidades** que la versión licenciada de Aspose.Slides. Además, la versión de evaluación simplemente se licencia después de comprar una licencia y agregar un par de líneas de código para aplicar la licencia.

La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de expiración de la suscripción, etc. El archivo está digitalmente firmado, así que no lo modifique. Incluso una adición inadvertida de un salto de línea extra en el contenido del archivo lo invalidará.

Para evitar las limitaciones asociadas con la versión de evaluación, necesita establecer una licencia antes de usar **Aspose.Slides**. Solo se requiere establecer una licencia una vez por aplicación o proceso.

## Licencia Comprada

Después de la compra, necesita aplicar el archivo de licencia o el flujo.

{{% alert color="primary" %}}

Necesita establecer la licencia:
* solo una vez por dominio de aplicación
* antes de usar cualquier otra clase de Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Puede encontrar información sobre precios en la página [“Información de Precios”](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **Estableciendo una Licencia en Aspose.Slides para Node.js a través de .NET**

Las licencias se pueden aplicar desde estas ubicaciones:

* Ruta explícita
* Flujo
* Como una Licencia Medida – un nuevo mecanismo de licenciamiento

{{% alert color="primary" %}}

Utilice el método **setLicense** para licenciar un componente.

Si bien múltiples llamadas a **setLicense** no son dañinas, son un desperdicio de recursos (procesador).

{{% /alert %}}

#### **Aplicando una Licencia Usando un Archivo**

Este fragmento de código se utiliza para establecer un archivo de licencia:

**Node.js**

```javascript
// Importar el módulo Aspose.Slides para manipulación de archivos de PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Esta función configura la biblioteca Aspose.Slides con una licencia
function setupAsposeSlidesLicense() {
	
    // Inicializar la clase License del módulo Aspose.Slides
    var license = new asposeSlides.License();
    
    // Aplicar la licencia desde un archivo
    // Reemplace "your_license_file.lic" con la ruta a su archivo de licencia real
    license.setLicense("your_license_file.lic");
}

// Ejecutar la función para configurar la licencia para Aspose.Slides
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}

Al llamar al método setLicense, el nombre de la licencia debe ser el mismo que el de su archivo de licencia. Por ejemplo, puede cambiar el nombre del archivo de licencia a "Aspose.Slides.lic.xml". Luego, en su código, debe pasar el nuevo nombre de la licencia (Aspose.Slides.lic.xml) al método setLicense.

{{% /alert %}}