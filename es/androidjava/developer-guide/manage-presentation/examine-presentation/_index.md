---
title: Recuperar y actualizar la información de la presentación en Android
linktitle: Información de la presentación
type: docs
weight: 30
url: /es/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Explore diapositivas, estructura y metadatos en presentaciones PowerPoint y OpenDocument usando Java para obtener conocimientos más rápidos y auditorías de contenido más inteligentes."
---
## **Descripción general**

Aspose.Slides puede identificar el formato de una presentación y leer sus metadatos de documento sin crear un modelo de objetos de presentación completo. Esto es útil cuando necesita clasificar archivos, crear un inventario o inspeccionar propiedades antes de decidir si cargar y procesar el contenido de la presentación.

Este artículo muestra la inspección ligera mediante [PresentationFactory](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationfactory/) y [IPresentationInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationinfo/), así como actualizaciones específicas mediante [IDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/).

## **Comprobar el formato de una presentación**

Si ya tiene una presentación cargada, consulte [Determine the Original Presentation Format](/slides/es/androidjava/detect-presentation-source-format/) para la detección después de cargar y las limitaciones de los flujos heredados PPT, PPS y POT.

Utilice [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) para inspeccionar un archivo sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/). El método [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) informa del formato detectado, como PPTX, PPT u ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Crear un inventario de presentaciones ligero**

Cuando procesa muchos archivos de presentación, puede necesitar un inventario compacto para validación, indexación o un sistema de gestión documental. En este escenario, use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) para obtener un objeto [IPresentationInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationinfo/) y, a continuación, llame a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) para leer los metadatos del documento. Este enfoque no crea una instancia de [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) ni requiere recorrer todo el modelo de objetos de la presentación.

Las propiedades extendidas expuestas por [IDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/) proporcionan los siguientes valores de inventario:

| Método | Valor de inventario |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | Número total de diapositivas. |
| [getHiddenSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Número de diapositivas ocultas. |
| [getNotes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | Número de diapositivas que contienen notas. |
| [getParagraphs](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | Número total de párrafos, cuando está disponible. |
| [getWords](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | Número total de palabras. |
| [getMultimediaClips](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Número total de clips de audio y vídeo. |

El siguiente ejemplo lee estos valores sin crear un objeto [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) y muestra un inventario compacto. También combina [getHeadingPairs](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) con [getTitlesOfParts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) para mostrar grupos de contenido como fuentes, temas y títulos de diapositivas.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Cada [IHeadingPair](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iheadingpair/) suministra un nombre de grupo y el número de elementos en ese grupo. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) devuelve una matriz plana y ordenada, por lo que se deben consumir la cantidad de títulos consecutivos especificados por cada par de encabezado.

### **Metadatos almacenados y limitaciones de formato**

Las propiedades de inventario devueltas por [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) reflejan los metadatos disponibles en el documento de origen. Aspose.Slides no carga ni recorre el modelo de objetos de la presentación para recalcular estos valores en esta llamada. Las propiedades ausentes se representan con valores predeterminados, y los valores almacenados pueden estar obsoletos si la aplicación que guardó el archivo por última vez no actualizó sus propiedades de documento.

- **PPTX:** El formato proporciona propiedades de documento extendidas para recuentos de diapositivas, notas, diapositivas ocultas, párrafos, palabras y multimedia, así como pares de encabezados y títulos de partes. La disponibilidad depende de qué propiedades fueron escritas por el productor del documento.
- **PPT:** El formato binario puede almacenar propiedades de resumen de documento correspondientes. Si una propiedad está ausente o no fue actualizada por el productor del documento, Aspose.Slides devuelve su valor almacenado o predeterminado en lugar de calcularlo a partir de las diapositivas.
- **ODP:** Los metadatos de OpenDocument proporcionan estadísticas generales del documento, como recuentos de páginas, párrafos y palabras, pero estos valores no se corresponden con todas las propiedades extendidas específicas de PowerPoint. Los metadatos de diapositivas ocultas, notas, multimedia, pares de encabezados y títulos de partes pueden no estar disponibles, y las propiedades de inventario pueden devolver valores predeterminados. No trate un valor cero o una matriz vacía como prueba concluyente de que el contenido correspondiente está ausente.

Utilice el enfoque de metadatos ligero para inventarios y verificaciones preliminares. Cargue la presentación e inspeccione su modelo de objetos en tiempo real cuando el resultado deba reflejar cambios en memoria o cuando necesite verificar el contenido real de la presentación.

## **Actualizar propiedades de la presentación**

Las propiedades devueltas por [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) también pueden modificarse sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/). Aplique los cambios con [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) y, a continuación, escriba la presentación vinculada con [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

La siguiente imagen muestra las propiedades originales del documento.

![Propiedades originales del documento de la presentación PowerPoint](input_properties.png)

El siguiente ejemplo modifica el título y la fecha de última guardado y escribe el resultado en un archivo nuevo:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

![Propiedades modificadas del documento de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

Para verificaciones de seguridad relacionadas y configuraciones de protección, consulte los siguientes artículos:

- [Presentaciones protegidas con contraseña](/slides/es/androidjava/password-protected-presentation/)
- [Presentaciones protegidas contra escritura](/slides/es/androidjava/write-protected-presentation/)

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Cargue la presentación y use [Presentation.getFontsManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getFontsManager--). Llame a [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) para obtener las fuentes incrustadas y a [IFontsManager.getFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) para obtener las fuentes utilizadas por la presentación. Compare los dos resultados para encontrar fuentes necesarias para el renderizado que no estén incrustadas.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Cuando los metadatos del documento almacenado son suficientes, lea [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) a través de [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) y [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Esto es adecuado para un inventario ligero. Si la presentación ha sido modificada en memoria, los metadatos almacenados pueden faltar o estar obsoletos, o necesita verificar valores en tiempo real; recorra [Presentation.getSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getSlides--) e inspeccione el método [ISlide.getHidden](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islide/#getHidden--) de cada diapositiva.

**¿Puedo detectar si se utiliza un tamaño y orientación de diapositiva personalizados, y si difieren de los valores predeterminados?**

Sí. Cargue la presentación y llame a [Presentation.getSlideSize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getSlideSize--). Utilice [ISlideSize.getType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidesize/#getSize--) y [ISlideSize.getOrientation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidesize/#getOrientation--) para comparar la configuración actual con el preset y dimensiones esperados.

**¿Existe una forma rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Ubique cada [Chart](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/chart/) y llame a [IChartData.getDataSourceType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--). Para un libro de trabajo externo, llame a [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). El tipo de origen de datos y la ruta identifican una referencia externa, pero verificar si el objetivo está disponible requiere una comprobación de recursos independiente.

**¿Cómo puedo evaluar las diapositivas 'pesadas' que pueden ralentizar el renderizado o la exportación a PDF?**

No existe una única propiedad de complejidad. Recorra [Presentation.getSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getSlides--) y la colección [IBaseSlide.getShapes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseslide/#getShapes--) de cada diapositiva. Use el recuento de formas y la presencia de imágenes grandes, efectos, animaciones o multimedia como señales de filtrado, y mida una renderización o exportación representativa antes de considerar una diapositiva como un cuello de botella de rendimiento confirmado.