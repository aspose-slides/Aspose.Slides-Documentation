---
title: Examinar presentación
type: docs
weight: 30
url: /es/nodejs-java/examine-presentation/
keywords:
- PowerPoint
- presentación
- formato de presentación
- propiedades de la presentación
- propiedades del documento
- obtener propiedades
- leer propiedades
- cambiar propiedades
- modificar propiedades
- PPTX
- PPT
- JavaScript
- Node
description: "Leer y modificar las propiedades de la presentación PowerPoint en Node"
---

Aspose.Slides for Node.js via Java le permite examinar una presentación para descubrir sus propiedades y comprender su comportamiento.

{{% alert title="Info" color="info" %}} 

Las clases [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo) y [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/) contienen las propiedades y métodos usados en las operaciones aquí.

{{% /alert %}} 

## **Comprobar el formato de una presentación**

Antes de trabajar con una presentación, es posible que desee averiguar en qué formato (PPT, PPTX, ODP y otros) se encuentra la presentación en este momento.

Puede comprobar el formato de una presentación sin cargarla. Vea este código JavaScript:
```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```


## **Obtener propiedades de la presentación**

Este código JavaScript le muestra cómo obtener las propiedades de la presentación (información sobre la presentación):
```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```


Puede ver las [propiedades bajo DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) de la clase.

## **Actualizar propiedades de la presentación**

Aspose.Slides proporciona el método [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) que le permite realizar cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento mostradas a continuación.

![Propiedades originales del documento de la presentación PowerPoint](input_properties.png)

Este ejemplo de código le muestra cómo editar algunas propiedades de la presentación:
```javascript
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

Para obtener más información sobre una presentación y sus atributos de seguridad, puede encontrar útiles los siguientes enlaces:

- [Comprobando si una presentación está cifrada](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Comprobando si una presentación está protegida contra escritura (solo lectura)](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Comprobando si una presentación está protegida con contraseña antes de cargarla](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmando la contraseña usada para proteger una presentación](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Busque la [información de fuentes incrustadas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) a nivel de presentación, luego compare esas entradas con el conjunto de [fuentes realmente usadas en el contenido](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/) para identificar qué fuentes son críticas para la renderización.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Itere a través de la [colección de diapositivas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) y examine la [bandera de visibilidad](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/gethidden/) de cada diapositiva.

**¿Puedo detectar si se usa un tamaño y orientación de diapositiva personalizados, y si difieren de los valores predeterminados?**

Sí. Compare el [tamaño de diapositiva actual](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslidesize/) y la orientación con los valores predeterminados; esto ayuda a anticipar el comportamiento al imprimir o exportar.

**¿Existe una forma rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Recorra todos los [gráficos](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/), verifique su [fuente de datos](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), y observe si los datos son internos o basados en enlaces, incluyendo enlaces rotos.

**¿Cómo puedo evaluar las diapositivas “pesadas” que pueden ralentizar la renderización o la exportación a PDF?**

Para cada diapositiva, cuente los objetos y busque imágenes grandes, transparencias, sombras, animaciones y contenido multimedia; asigne una puntuación de complejidad aproximada para identificar posibles cuellos de botella de rendimiento.