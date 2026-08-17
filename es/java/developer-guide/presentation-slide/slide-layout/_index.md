---
title: Aplicar o cambiar diseños de diapositiva en Java
linktitle: Diseño de diapositiva
type: docs
weight: 60
url: /es/java/slide-layout/
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
- Java
- Aspose.Slides
description: "Aplicar, crear y modificar diseños de diapositiva en Aspose.Slides para Java, añadir marcadores de posición, eliminar diseños no utilizados y controlar la visibilidad del pie de página."
---
## **Visión general**

Un diseño de diapositiva define las posiciones y el formato de los marcadores de posición como títulos, texto, imágenes, gráficos y tablas. Aplicar un diseño otorga a las diapositivas una estructura coherente mientras permite que cada diapositiva contenga su propio contenido.

Los diseños más comunes incluyen:

- **Diapositiva de título**: Contiene marcadores de posición de título y subtítulo.
- **Título y contenido**: Contiene un marcador de posición de título y un marcador de posición de contenido de uso general.
- **En blanco**: No contiene marcadores de posición de contenido y es útil cuando cada forma se posicionará manualmente.

## **Comprender la herencia de diseños**

Una presentación tiene tres niveles relacionados:

1. Una [diapositiva maestra](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslide/) define el tema, el formato compartido, los fondos y los objetos comunes.
1. Una [diapositiva de diseño](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutslide/) pertenece a una maestra y define una disposición particular de marcadores de posición.
1. Una [diapositiva normal](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/) utiliza un diseño y almacena el contenido introducido para esa diapositiva.

Una diapositiva normal hereda el tema y el formato de su diseño, y el diseño hereda de su maestra. Un valor establecido directamente en una diapositiva normal sobrescribe el valor heredado en ese nivel. Cuando se crea una diapositiva normal, sus formas de marcador de posición se generan a partir del diseño seleccionado, mientras que el contenido introducido en esos marcadores pertenece a la diapositiva normal.

Añada los marcadores de posición requeridos a un diseño antes de crear diapositivas a partir de él. Añadir otro marcador de posición a un diseño más adelante no agrega automáticamente una forma de marcador de posición correspondiente a las diapositivas normales existentes.

Esta relación tiene dos consecuencias importantes:

- Cambiar el formato heredado o la geometría de los marcadores de posición existentes en un diseño puede actualizar cada diapositiva que dependa de él. Antes de editar un diseño que ya está en uso, inspeccione sus diapositivas dependientes y revise la presentación resultante.
- Un diseño que aún es utilizado por una diapositiva no puede eliminarse. Reasigne sus diapositivas dependientes a otro diseño primero, o elimine solo los diseños no utilizados.

Para obtener más información sobre el nivel superior de esta jerarquía, consulte [Slide Master](/slides/es/java/slide-master/).

## **Seleccionar y aplicar un diseño de diapositiva**

Utilice un tipo de diseño cuando la presentación siga las definiciones estándar de diseños de PowerPoint. Los nombres de los diseños son editables por el usuario y pueden localizarse, por lo que la selección basada en el nombre es menos fiable a menos que controle la plantilla de origen.

El siguiente ejemplo busca **Título y contenido** en la primera maestra. Si ese diseño no está disponible, recurre deliberadamente a **En blanco**. La segunda comprobación de nulo es necesaria porque una presentación puede contener solo diseños personalizados. El diseño seleccionado se aplica luego a la primera diapositiva normal mediante el método [ISlide.setLayoutSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Cambiar el diseño de una diapositiva no elimina las formas ordinarias añadidas directamente a la diapositiva. Sin embargo, las posiciones de los marcadores de posición, el formato heredado y la correspondencia entre los marcadores existentes y el nuevo diseño pueden cambiar, por lo que inspeccione el resultado al cambiar entre diseños sustancialmente diferentes.

## **Agregar una diapositiva de diseño**

La selección y la creación son operaciones separadas. El ejemplo anterior selecciona un diseño existente; no crea uno. Para crear un diseño, llame al método [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) en la colección de diseños de la maestra objetivo.

El siguiente ejemplo siempre agrega un nuevo diseño **Título y contenido** llamado `Report Title and Content`, y luego agrega una diapositiva normal basada en él. Los nombres de los diseños deben ser únicos dentro de la colección.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Agregue un diseño solo cuando la plantilla realmente necesite otra estructura reutilizable. Si ya existe un diseño adecuado, selecciónelo y reutilícelo en lugar de crear un duplicado.

## **Agregar marcadores de posición a una diapositiva de diseño**

El método [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) proporciona un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutplaceholdermanager/) para añadir formas de marcador de posición a un diseño.

| Marcador de posición de PowerPoint | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Contenido](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Contenido (vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Texto](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Texto (vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Imagen](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Gráfico](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabla](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Multimedia](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Imagen en línea](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

El siguiente ejemplo verifica que el diseño **En blanco** exista, agrega cuatro marcadores de posición a él y luego crea una diapositiva normal que utiliza el diseño modificado. El orden es intencional: los marcadores de posición se añaden antes de crear la diapositiva normal, de modo que Aspose.Slides pueda generar las formas de marcador de posición correspondientes en esa diapositiva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Los marcadores de posición en la diapositiva de diseño](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Cambiar el formato heredado o la geometría de los marcadores de posición del diseño existentes puede afectar a las diapositivas dependientes. Un marcador de posición de diseño añadido recientemente no se retroalimenta en las diapositivas normales existentes. Pruebe los cambios de diseño en una copia de la presentación e inspeccione cada diapositiva dependiente.
{{% /alert %}}

## **Eliminar diseños de diapositiva no utilizados**

Utilice el método [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) para eliminar los diseños que no son referenciados por ninguna diapositiva normal. El método deja intactos los diseños que aún se están usando.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para eliminar un diseño específico, primero utilice su método [hasDependingSlides](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) o [getDependingSlides](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutslide/#getDependingSlides--). Reasigne cualquier diapositiva dependiente antes de llamar a [ILayoutSlide.remove](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutslide/#remove--). Intentar eliminar un diseño en uso genera una [PptxEditException](https://reference.aspose.com/slides/es/java/com.aspose.slides/pptxeditexception/).

## **Controlar la visibilidad del pie de página en una diapositiva de diseño**

Un diseño tiene sus propios marcadores de posición de pie de página, número de diapositiva y fecha‑hora. Utilice el método [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) para controlar esos marcadores de posición en un diseño. Esto es útil cuando, por ejemplo, los diseños de contenido deben mostrar pies de página pero los diseños de título no.

El siguiente ejemplo selecciona un diseño de forma segura y hace visibles sus elementos de pie de página:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar la visibilidad del pie de página en una maestra y sus diseños hijos**

Para aplicar configuraciones de pie de página coherentes en toda una jerarquía de maestras, utilice el método [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Los métodos de propagación de [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslideheaderfootermanager/) actúan sobre la maestra y sus diapositivas de diseño dependientes y diapositivas normales; no se enfocan en una sola diapositiva normal.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de diseño?**

Una diapositiva maestra define el tema y el formato compartido de la presentación. Una diapositiva de diseño pertenece a una maestra y define una disposición reutilizable de marcadores de posición. Las diapositivas normales utilizan esos diseños y almacenan contenido específico de cada diapositiva.

**¿Puedo copiar una diapositiva de diseño de una presentación a otra?**

Sí. Añada una copia a la colección de destino con el método [addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Al copiar entre presentaciones, también verifique fuentes, temas, imágenes y otros recursos utilizados por el diseño de origen.

**¿Qué ocurre cuando modifico un diseño que ya está en uso?**

Las diapositivas dependientes heredan los cambios del diseño a menos que anulen localmente el formato o los objetos afectados. Por lo tanto, la geometría de los marcadores de posición y el estilo heredado pueden cambiar en muchas diapositivas a la vez. Utilice [getDependingSlides](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) para identificar las diapositivas afectadas antes de editar el diseño.

**¿Qué ocurre si elimino un diseño que todavía está en uso?**

Aspose.Slides lanza una [PptxEditException](https://reference.aspose.com/slides/es/java/com.aspose.slides/pptxeditexception/). Reasigne primero las diapositivas dependientes, o utilice [removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) para eliminar solo los diseños sin referencias.