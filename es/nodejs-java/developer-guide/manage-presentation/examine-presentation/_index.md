---
title: Recuperar y actualizar información de la presentación en JavaScript
linktitle: Información de la presentación
type: docs
weight: 30
url: /es/nodejs-java/examine-presentation/
keywords:
- formato de presentación
- propiedades de la presentación
- propiedades del documento
- obtener propiedades
- leer propiedades
- cambiar propiedades
- modificar propiedades
- actualizar propiedades
- examinar PPTX
- examinar PPT
- examinar ODP
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Explore diapositivas, estructura y metadatos en presentaciones PowerPoint y OpenDocument usando JavaScript para obtener información más rápida y auditorías de contenido más inteligentes."
---
## **Visión general**

Este artículo muestra cómo inspeccionar la información de una presentación en Aspose.Slides. Explica cómo determinar el formato actual de una presentación sin cargar el archivo completo, leer sus propiedades de documento y actualizar esas propiedades cuando sea necesario.

Los ejemplos se basan en las API [PresentationInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/) y [DocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/) y demuestran operaciones típicas para trabajar con los metadatos de una presentación.

## **Comprobar el formato de una presentación**

Antes de trabajar con una presentación, puede que desee averiguar en qué formato (PPT, PPTX, ODP y otros) se encuentra la presentación en este momento.

Puede comprobar el formato de una presentación sin cargarla. Vea este código JavaScript:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Obtener propiedades de la presentación**

Este código JavaScript muestra cómo obtener las propiedades de la presentación (información sobre la presentación):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

Puede que desee ver las [properties bajo la clase DocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Actualizar propiedades de la presentación**

Aspose.Slides proporciona el método [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) que permite modificar las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades de documento mostradas a continuación.

![Propiedades originales del documento de la presentación PowerPoint](input_properties.png)

Este ejemplo de código muestra cómo editar algunas propiedades de la presentación:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Los resultados de cambiar las propiedades del documento se muestran a continuación.

![Propiedades modificadas del documento de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, pueden resultarle útiles estos enlaces:

- [Presentaciones protegidas con contraseña](/slides/es/nodejs-java/password-protected-presentation/)
- [Presentaciones protegidas contra escritura](/slides/es/nodejs-java/write-protected-presentation/)

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Busque información sobre [embedded-font](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) a nivel de presentación, y luego compare esas entradas con el conjunto de [fuentes realmente utilizadas en el contenido](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/getfonts/) para identificar qué fuentes son críticas para el renderizado.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Itere a través de la [slide collection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidecollection/) y examine la [visibility flag](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/gethidden/) de cada diapositiva.

**¿Puedo detectar si se utilizan tamaños y orientaciones de diapositiva personalizados, y si difieren de los predeterminados?**

Sí. Compare el [slide size](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getslidesize/) y la orientación actuales con los valores predeterminados; esto ayuda a anticipar el comportamiento para la impresión y exportación.

**¿Existe una forma rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Recorra todos los [charts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/), verifique su [data source](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) y observe si los datos son internos o basados en enlaces, incluidos los enlaces rotos.

**¿Cómo puedo evaluar las diapositivas “pesadas” que pueden ralentizar el renderizado o la exportación a PDF?**

Para cada diapositiva, cuente los objetos y busque imágenes grandes, transparencias, sombras, animaciones y contenido multimedia; asigne una puntuación de complejidad aproximada para señalar posibles cuellos de botella de rendimiento.