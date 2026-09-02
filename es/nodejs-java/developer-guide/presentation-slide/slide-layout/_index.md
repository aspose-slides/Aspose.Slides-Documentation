---
title: Aplicar o cambiar diseños de diapositivas en JavaScript
linktitle: Diseño de diapositiva
type: docs
weight: 60
url: /es/nodejs-java/slide-layout/
keywords:
- diseño de diapositiva
- diseño de contenido
- marcador de posición
- diseño de presentación
- diseño de diapositiva
- diseño no utilizado
- visibilidad del pie de página
- diapositiva de título
- título y contenido
- encabezado de sección
- dos contenidos
- comparación
- solo título
- diseño en blanco
- contenido con leyenda
- imagen con leyenda
- título y texto vertical
- título vertical y texto
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aplicar, crear y modificar diseños de diapositivas en Aspose.Slides para Node.js mediante Java, añadir marcadores de posición, eliminar diseños no utilizados y controlar la visibilidad del pie de página."
---
## **Visión general**

Una distribución de diapositiva define las posiciones y el formato de los marcadores de posición como títulos, texto, imágenes, gráficos y tablas. Aplicar una distribución proporciona a las diapositivas una estructura coherente al tiempo que permite que cada diapositiva contenga su propio contenido.

Los diseños más habituales incluyen:

- **Diapositiva de título**: Contiene marcadores de posición de título y subtítulo.
- **Título y contenido**: Contiene un marcador de posición de título y un marcador de posición de contenido de propósito general.
- **En blanco**: No contiene marcadores de posición de contenido y es útil cuando cada forma se posicionará manualmente.

## **Entender la herencia de diseños**

Una presentación tiene tres niveles relacionados:

1. Una [diapositiva maestra](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslide/) define el tema, el formato compartido, los fondos y los objetos comunes.
2. Una [diapositiva de diseño](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutslide/) pertenece a una maestra y define una disposición particular de marcadores de posición.
3. Una [diapositiva normal](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/) utiliza un diseño y almacena el contenido introducido para esa diapositiva.

Una diapositiva normal hereda el tema y formato de su diseño, y el diseño hereda de su maestra. Un valor establecido directamente en una diapositiva normal sobrescribe el valor heredado en ese nivel. Cuando se crea una diapositiva normal, sus formas de marcador de posición se generan a partir del diseño seleccionado, mientras que el contenido introducido en esos marcadores pertenece a la diapositiva normal.

Añada los marcadores de posición necesarios a un diseño antes de crear diapositivas a partir de él. Añadir otro marcador de posición a un diseño más tarde no añade automáticamente una forma de marcador correspondiente a las diapositivas normales existentes.

Esta relación tiene dos consecuencias importantes:

- Cambiar el formato heredado o la geometría de los marcadores de posición existentes en un diseño puede actualizar todas las diapositivas que dependen de él. Antes de editar un diseño que ya está en uso, inspeccione sus diapositivas dependientes y revise la presentación resultante.
- Un diseño que todavía es utilizado por una diapositiva no puede eliminarse. Reasigne sus diapositivas dependientes a otro diseño primero, o elimine solo los diseños no utilizados.

Para obtener más información sobre el nivel superior de esta jerarquía, consulte la [Maestra de diapositivas](/slides/es/nodejs-java/slide-master/).

## **Seleccionar y aplicar un diseño de diapositiva**

Utilice un valor de [SlideLayoutType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidelayouttype/) cuando la presentación siga las definiciones estándar de diseños de PowerPoint. Los nombres de los diseños son editables por el usuario y pueden localizarse, por lo que la selección basada en nombres es menos fiable a menos que controle la plantilla de origen.

El siguiente ejemplo busca **Título y contenido** en la primera maestra. Si ese diseño no está disponible, recurre deliberadamente a **En blanco**. La segunda comprobación de nulo es necesaria porque una presentación puede contener solo diseños personalizados. El diseño seleccionado se aplica entonces a la primera diapositiva normal mediante el método [Slide.setLayoutSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#setLayoutSlide).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Cambiar el diseño de una diapositiva no elimina las formas normales añadidas directamente a la diapositiva. Sin embargo, las posiciones de los marcadores de posición, el formato heredado y la correspondencia entre los marcadores existentes y el nuevo diseño pueden cambiar, por lo que debe inspeccionar el resultado al cambiar entre diseños sustancialmente diferentes.

## **Añadir una diapositiva de diseño**

Seleccionar y crear son operaciones separadas. El ejemplo anterior selecciona un diseño existente; no lo crea. Para crear un diseño, llame al método [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) en la colección de diseños de la maestra objetivo.

El siguiente ejemplo siempre añade un nuevo diseño **Título y contenido** llamado `Report Title and Content`, y luego añade una diapositiva normal basada en él. Los nombres de los diseños deben ser únicos dentro de la colección.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Añada un diseño solo cuando la plantilla realmente necesite otra estructura reutilizable. Si ya existe un diseño adecuado, selecciónelo y reutilícelo en lugar de crear un duplicado.

## **Añadir marcadores de posición a una diapositiva de diseño**

El método [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) proporciona un [LayoutPlaceholderManager](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutplaceholdermanager/) para añadir formas de marcador de posición a un diseño.

| Marcador de posición de PowerPoint | Método de `LayoutPlaceholderManager` |
| ----------------------------------- | ------------------------------------- |
| ![Contenido](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Contenido (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Texto](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Texto (Vertical)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Imagen](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Gráfico](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabla](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Medios](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Imagen en línea](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

El siguiente ejemplo verifica que el diseño **En blanco** exista, añade cuatro marcadores de posición a él, y luego crea una diapositiva normal que utiliza el diseño modificado. El orden es intencional: los marcadores de posición se añaden antes de crear la diapositiva normal, de modo que Aspose.Slides pueda generar las formas de marcador correspondientes en esa diapositiva.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Los marcadores en la diapositiva de diseño](add_placeholders.png)

{{% alert color="warning" title="Advertencia" %}}
Cambiar el formato heredado o la geometría de los marcadores de posición del diseño existentes puede afectar a las diapositivas dependientes. Un marcador de posición de diseño recién añadido no se retroalimenta en las diapositivas normales existentes. Pruebe los cambios de diseño en una copia de la presentación e inspeccione cada diapositiva dependiente.
{{% /alert %}}

## **Eliminar diseños de diapositiva no utilizados**

Utilice el método [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) para eliminar los diseños que no son referenciados por ninguna diapositiva normal. El método deja intactos los diseños que aún están en uso.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para eliminar un diseño específico, primero utilice su método [hasDependingSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) o [getDependingSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Reasigne cualquier diapositiva dependiente antes de llamar a [LayoutSlide.remove](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutslide/#remove). Intentar eliminar un diseño en uso genera una [PptxEditException](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxeditexception/).

## **Controlar la visibilidad del pie de página en una diapositiva de diseño**

Un diseño tiene sus propios marcadores de posición de pie de página, número de diapositiva y fecha/hora. Utilice el método [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) para controlar esos marcadores de posición para un diseño. Esto es útil cuando, por ejemplo, los diseños de contenido deben mostrar pies de página pero los diseños de título no.

El siguiente ejemplo selecciona un diseño de forma segura y hace visibles sus elementos de pie de página:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar la visibilidad del pie de página en una maestra y sus diseños secundarios**

Para aplicar configuraciones de pie de página coherentes en toda una jerarquía de maestras, utilice el método [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Los métodos de propagación de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslideheaderfootermanager/) actúan sobre la maestra y sus diapositivas de diseño y diapositivas normales dependientes; no se dirigen a una sola diapositiva normal.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de diseño?**

Una diapositiva maestra define el tema de la presentación y el formato compartido. Una diapositiva de diseño pertenece a una maestra y define una disposición reutilizable de marcadores de posición. Las diapositivas normales utilizan esos diseños y almacenan el contenido específico de cada diapositiva.

**¿Puedo copiar una diapositiva de diseño de una presentación a otra?**

Sí. Añada una copia a la colección de destino con el método [addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Al copiar entre presentaciones, también verifique fuentes, temas, imágenes y otros recursos utilizados por el diseño de origen.

**¿Qué ocurre cuando modifico un diseño que ya está en uso?**

Las diapositivas dependientes heredan los cambios del diseño a menos que sobrescriban localmente el formato o los objetos afectados. La geometría de los marcadores de posición y el estilo heredado pueden cambiar, por lo tanto, en muchas diapositivas a la vez. Utilice [getDependingSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) para identificar las diapositivas afectadas antes de editar el diseño.

**¿Qué ocurre si elimino un diseño que todavía está en uso?**

Aspose.Slides lanza una [PptxEditException](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxeditexception/). Reasigne primero las diapositivas dependientes, o utilice [removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) para eliminar solo los diseños sin referencia.