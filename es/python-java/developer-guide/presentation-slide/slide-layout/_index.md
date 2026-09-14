---
title: Aplicar o cambiar diseños de diapositiva en Python a través de Java
linktitle: Diseño de diapositiva
type: docs
weight: 60
url: /es/python-java/slide-layout/
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
- Python
- Java
- Aspose.Slides
description: "Aplicar, crear y modificar diseños de diapositiva en Aspose.Slides para Python a través de Java, añadir marcadores de posición, eliminar diseños no utilizados y controlar la visibilidad del pie de página."
---
## **Visión general**

Una disposición de diapositiva define las posiciones y el formato de los marcadores de posición, como títulos, texto, imágenes, gráficos y tablas. Aplicar una disposición otorga a las diapositivas una estructura coherente mientras permite que cada diapositiva contenga su propio contenido.

Los diseños más comunes incluyen:

- **Diapositiva de título**: Contiene marcadores de posición de título y subtítulo.
- **Título y contenido**: Contiene un marcador de posición de título y un marcador de posición de contenido de uso general.
- **En blanco**: No contiene marcadores de posición de contenido y es útil cuando cada forma se posicionará manualmente.

## **Entender la herencia de diseños**

Una presentación tiene tres niveles relacionados:

1. Una [diapositiva maestra](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/) define el tema, el formato compartido, los fondos y los objetos comunes.
1. Una [diapositiva de diseño](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutslide/) pertenece a una maestra y define una disposición particular de marcadores de posición.
1. Una [diapositiva normal](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/) utiliza un diseño y almacena el contenido introducido para esa diapositiva.

Una diapositiva normal hereda el tema y el formato de su diseño, y el diseño hereda de su maestra. Un valor establecido directamente en una diapositiva normal sobrescribe el valor heredado en ese nivel. Cuando se crea una diapositiva normal, sus formas de marcador de posición se generan a partir del diseño seleccionado, mientras que el contenido introducido en esos marcadores pertenece a la diapositiva normal.

Añada los marcadores de posición necesarios a un diseño antes de crear diapositivas a partir de él. Añadir otro marcador de posición a un diseño posteriormente no agrega automáticamente una forma de marcador correspondiente a las diapositivas normales existentes.

Esta relación tiene dos consecuencias importantes:

- Cambiar el formato heredado o la geometría de los marcadores de posición existentes en un diseño puede actualizar todas las diapositivas que dependen de él. Antes de editar un diseño que ya está en uso, inspeccione sus diapositivas dependientes y revise la presentación resultante.
- Un diseño que todavía es utilizado por una diapositiva no puede eliminarse. Reasigne sus diapositivas dependientes a otro diseño primero, o elimine sólo los diseños no utilizados.

Para obtener más información sobre el nivel superior de esta jerarquía, consulte [Diapositiva maestra](/slides/es/python-java/slide-master/).

## **Seleccionar y aplicar un diseño de diapositiva**

Utilice un tipo de diseño cuando la presentación sigue las definiciones estándar de diseños de PowerPoint. Los nombres de los diseños son editables por el usuario y pueden localizarse, por lo que la selección basada en nombres es menos fiable a menos que controle la plantilla origen.

El siguiente ejemplo busca **Título y contenido** en la primera maestra. Si ese diseño no está disponible, recurre deliberadamente a **En blanco**. La segunda comprobación de `None` es necesaria porque una presentación puede contener sólo diseños personalizados. El diseño seleccionado se aplica entonces a la primera diapositiva normal mediante el método [Slide.setLayoutSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#setLayoutSlide).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Cambiar el diseño de una diapositiva no elimina las formas ordinarias añadidas directamente a la diapositiva. Sin embargo, las posiciones de los marcadores, el formato heredado y la correspondencia entre los marcadores existentes y el nuevo diseño pueden cambiar, por lo que debe inspeccionar el resultado al alternar entre diseños sustancialmente diferentes.

## **Añadir una diapositiva de diseño**

La selección y la creación son operaciones separadas. El ejemplo anterior selecciona un diseño existente; no crea uno. Para crear un diseño, llame al método [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterlayoutslidecollection/#add) en la colección de diseños de la maestra de destino.

El siguiente ejemplo siempre añade un nuevo diseño **Título y contenido** llamado `Report Title and Content`, y luego añade una diapositiva normal basada en él. Los nombres de los diseños deben ser únicos dentro de la colección.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Añada un diseño sólo cuando la plantilla realmente necesite otra estructura reutilizable. Si ya existe un diseño adecuado, selecciónelo y reutilícelo en lugar de crear un duplicado.

## **Añadir marcadores de posición a una diapositiva de diseño**

El método [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutslide/#getPlaceholderManager) proporciona un [LayoutPlaceholderManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutplaceholdermanager/) para añadir formas de marcador de posición a un diseño.

| Marcador de posición de PowerPoint | [LayoutPlaceholderManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutplaceholdermanager/) Método |
| ----------------------------------- | ---------------------------------- |
| ![Contenido](content.png)           | [addContentPlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Contenido (vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Texto](text.png)                  | [addTextPlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Texto (vertical)](textV.png)      | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Imagen](picture.png)              | [addPicturePlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Gráfico](chart.png)               | [addChartPlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabla](table.png)                 | [addTablePlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [addSmartArtPlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Multimedia](media.png)            | [addMediaPlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Imagen en línea](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

El siguiente ejemplo verifica que el diseño **En blanco** exista, añade cuatro marcadores de posición a él y luego crea una diapositiva normal que utiliza el diseño modificado. El orden es intencional: los marcadores se añaden antes de crear la diapositiva normal, de modo que Aspose.Slides pueda generar las formas de marcador correspondientes en esa diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Los marcadores de posición en la diapositiva de diseño](add_placeholders.png)

{{% alert color="warning" title="Advertencia" %}}
Cambiar el formato heredado o la geometría de los marcadores de posición del diseño existente puede afectar a las diapositivas dependientes. Un marcador de posición de diseño recién añadido no se retroalimenta en las diapositivas normales existentes. Pruebe los cambios de diseño en una copia de la presentación e inspeccione cada diapositiva dependiente.
{{% /alert %}}

## **Eliminar diseños de diapositiva no utilizados**

Utilice el método [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) para eliminar los diseños que no son referenciados por ninguna diapositiva normal. El método deja intactos los diseños que aún están en uso.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para eliminar un diseño específico, primero utilice su método [hasDependingSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutslide/#hasDependingSlides) o [getDependingSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutslide/#getDependingSlides). Reasigne cualquier diapositiva dependiente antes de llamar a [LayoutSlide.remove](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutslide/#remove). Intentar eliminar un diseño en uso genera una [PptxEditException](https://reference.aspose.com/slides/es/python-java/aspose.slides/pptxeditexception/).

## **Controlar la visibilidad del pie de página en una diapositiva de diseño**

Un diseño tiene sus propios marcadores de pie de página, número de diapositiva y fecha/hora. Utilice el método [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) para controlar esos marcadores en un diseño. Esto es útil cuando, por ejemplo, los diseños de contenido deben mostrar pies de página pero los diseños de título no.

El siguiente ejemplo selecciona un diseño de forma segura y hace visibles sus elementos de pie de página:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controlar la visibilidad del pie de página en una maestra y sus diseños secundarios**

Para aplicar configuraciones de pie de página coherentes en toda la jerarquía de una maestra, utilice el método [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Los métodos de propagación de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslideheaderfootermanager/) actúan sobre la maestra y sus diapositivas de diseño y diapositivas normales dependientes; no se dirigen a una única diapositiva normal.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de diseño?**

Una diapositiva maestra define el tema y el formato compartido de la presentación. Una diapositiva de diseño pertenece a una maestra y define una disposición reutilizable de marcadores de posición. Las diapositivas normales utilizan esos diseños y almacenan el contenido específico de cada diapositiva.

**¿Puedo copiar una diapositiva de diseño de una presentación a otra?**

Sí. Añada una copia a la colección de destino mediante el método [addClone](https://reference.aspose.com/slides/es/python-java/aspose.slides/globallayoutslidecollection/#addClone). Al copiar entre presentaciones, también verifique fuentes, temas, imágenes y otros recursos utilizados por el diseño de origen.

**¿Qué ocurre cuando modifico un diseño que ya está en uso?**

Las diapositivas dependientes heredan los cambios del diseño a menos que sobrescriban localmente el formato o los objetos afectados. La geometría de los marcadores y el estilo heredado pueden cambiar en muchas diapositivas a la vez. Utilice [getDependingSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutslide/#getDependingSlides) para identificar las diapositivas afectadas antes de editar el diseño.

**¿Qué ocurre si elimino un diseño que sigue en uso?**

Aspose.Slides lanza una [PptxEditException](https://reference.aspose.com/slides/es/python-java/aspose.slides/pptxeditexception/). Reasigne primero las diapositivas dependientes, o utilice [removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) para eliminar sólo los diseños no referenciados.