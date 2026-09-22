---
title: Recuperar y actualizar la información de la presentación en JavaScript
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
description: "Explora diapositivas, estructura y metadatos en presentaciones PowerPoint y OpenDocument usando JavaScript para obtener información más rápida y auditorías de contenido más inteligentes."
---
## **Visión general**

Aspose.Slides puede identificar el formato de una presentación y leer sus metadatos del documento sin crear un modelo de objeto de presentación completo. Esto es útil cuando necesitas clasificar archivos, crear un inventario o inspeccionar propiedades antes de decidir si cargar y procesar el contenido de la presentación.

Este artículo muestra la inspección ligera mediante [PresentationFactory](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationfactory/) y [PresentationInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/), así como actualizaciones específicas mediante [DocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/).

## **Comprobar el formato de una presentación**

Si ya tienes una presentación cargada, consulta [Determine the Original Presentation Format](/slides/es/nodejs-java/detect-presentation-source-format/) para la detección tras la carga y las limitaciones de los flujos heredados PPT, PPS y POT.

Utiliza [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) para inspeccionar un archivo sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/). El método [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/getloadformat/) informa del formato detectado, como PPTX, PPT u ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **Crear un inventario ligero de presentaciones**

Cuando procesas muchos archivos de presentación, puede que necesites un inventario compacto para validación, indexación o un sistema de gestión documental. En este caso, usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) para obtener un objeto [PresentationInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/), y luego llama a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) para leer los metadatos del documento. Este enfoque no crea una instancia de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) ni requiere que recorras el modelo de objeto completo de la presentación.

Las propiedades extendidas expuestas por [DocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/) proporcionan los siguientes valores de inventario:

| Método | Valor del inventario |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/#getSlides) | Número total de diapositivas. |
| [getHiddenSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Número de diapositivas ocultas. |
| [getNotes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/#getNotes) | Número de diapositivas que contienen notas. |
| [getParagraphs](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Número total de párrafos, cuando estén disponibles. |
| [getWords](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/#getWords) | Número total de palabras. |
| [getMultimediaClips](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Número total de clips de audio y vídeo. |

El siguiente ejemplo lee estos valores sin crear un objeto [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) y muestra un inventario compacto. También combina [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) con [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) para visualizar grupos de contenido como fuentes, temas y títulos de diapositivas.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Cada [HeadingPair](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/headingpair/) proporciona un nombre de grupo a través de [HeadingPair.getName](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/headingpair/#getName) y el número de elementos en ese grupo mediante [HeadingPair.getCount](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) devuelve una matriz plana y ordenada, por lo que debes consumir el número de títulos consecutivos especificado por cada par de encabezado.

### **Metadatos almacenados y limitaciones de formato**

Las propiedades de inventario devueltas por [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) reflejan los metadatos disponibles en el documento fuente. Aspose.Slides no carga ni recorre el modelo de objeto de la presentación para recalcular estos valores en esta llamada. Las propiedades faltantes se representan con valores predeterminados, y los valores almacenados pueden estar desactualizados si la aplicación que guardó por último el archivo no actualizó sus propiedades de documento.

- **PPTX:** El formato proporciona propiedades de documento extendidas para recuentos de diapositivas, notas, diapositivas ocultas, párrafos, palabras y multimedia, así como pares de encabezado y títulos de partes. La disponibilidad depende de qué propiedades haya escrito el productor del documento.
- **PPT:** El formato binario puede almacenar propiedades de resumen de documento correspondientes. Si una propiedad está ausente o no fue actualizada por el productor del documento, Aspose.Slides devuelve su valor almacenado o predeterminado en lugar de calcularlo a partir de las diapositivas.
- **ODP:** Los metadatos de OpenDocument proporcionan estadísticas generales del documento, como recuentos de páginas, párrafos y palabras, pero estos valores no se asignan a todas las propiedades extendidas específicas de PowerPoint. Los metadatos de diapositivas ocultas, diapositivas con notas, multimedia, pares de encabezado y títulos de partes pueden no estar disponibles, y las propiedades de inventario pueden devolver valores predeterminados. No consideres que un valor cero o una matriz vacía sea prueba autoritativa de que el contenido correspondiente está ausente.

Utiliza el enfoque de metadatos ligeros para inventarios y comprobaciones preliminares. Carga la presentación y examina su modelo de objeto en vivo cuando el resultado debe reflejar cambios en memoria o cuando necesites verificar el contenido real de la presentación.

## **Actualizar propiedades de la presentación**

Las propiedades devueltas por [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) también pueden modificarse sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/). Aplica los cambios con [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/), y luego escribe la presentación vinculada con [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

La siguiente imagen muestra las propiedades originales del documento.

![Propiedades originales del documento de la presentación PowerPoint](input_properties.png)

El siguiente ejemplo modifica el título y la hora de la última guardado y escribe el resultado en un archivo nuevo:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

La siguiente imagen muestra las propiedades del documento actualizadas.

![Propiedades del documento modificadas de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

Para comprobaciones de seguridad relacionadas y configuraciones de protección, consulta los siguientes artículos:

- [Presentaciones protegidas con contraseña](/slides/es/nodejs-java/password-protected-presentation/)
- [Presentaciones protegidas contra escritura](/slides/es/nodejs-java/write-protected-presentation/)

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Carga la presentación y utiliza [Presentation.getFontsManager](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getfontsmanager/). Llama a [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) para obtener las fuentes incrustadas y a [FontsManager.getFonts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/getfonts/) para obtener las fuentes usadas por la presentación. Compara ambos resultados para encontrar fuentes que son necesarias para la renderización pero no están incrustadas.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Cuando los metadatos del documento almacenados son suficientes, lee [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) a través de [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) y [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Esto es adecuado para un inventario ligero. Si la presentación ha sido modificada en memoria, los metadatos almacenados pueden faltar o estar desactualizados, o necesitas verificar valores en vivo; en ese caso, recorre [Presentation.getSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getslides/) e inspecciona el método [Slide.getHidden](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/gethidden/) de cada diapositiva.

**¿Puedo detectar si se usa un tamaño y orientación de diapositiva personalizados, y si difieren de los valores predeterminados?**

Sí. Carga la presentación y llama a [Presentation.getSlideSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getslidesize/). Usa [SlideSize.getType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidesize/getsize/) y [SlideSize.getOrientation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidesize/getorientation/) para comparar la configuración actual con el preset y dimensiones esperados.

**¿Existe una forma rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Localiza cada [Chart](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/) y llama a [ChartData.getDataSourceType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). Para un libro de trabajo externo, llama a [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). El tipo de fuente de datos y la ruta identifican una referencia externa, pero verificar si el objetivo está disponible requiere una comprobación de recursos separada.

**¿Cómo puedo evaluar las diapositivas «pesadas» que pueden ralentizar la renderización o la exportación a PDF?**

No hay una única propiedad de complejidad. Recorre [Presentation.getSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getslides/) y la colección [BaseSlide.getShapes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslide/#getShapes) de cada diapositiva. Utiliza el recuento de formas y la presencia de imágenes grandes, efectos, animaciones o multimedia como señales de filtrado, y mide una renderización o exportación representativa antes de considerar una diapositiva como un cuellos de botella de rendimiento confirmado.