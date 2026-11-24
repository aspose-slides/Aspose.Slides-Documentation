---
title: Gestionar temas de presentaciones de PowerPoint en Python
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/python-net/presentation-theme/
keywords:
- tema de PowerPoint
- tema de presentación
- tema de diapositiva
- establecer tema
- cambiar tema
- gestionar tema
- tema externo
- THMX
- color del tema
- paleta adicional
- fuente del tema
- estilo del tema
- efecto del tema
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Domina los temas de presentación en Aspose.Slides para Python mediante .NET para crear, personalizar y convertir archivos PowerPoint con una marca coherente."
---
## **Introducción**

Un tema de presentación define un conjunto coordinado de colores, fuentes, estilos de fondo, rellenos, líneas y efectos. Los objetos con conocimiento del tema hacen referencia a estas definiciones compartidas en lugar de almacenar cada propiedad visual como un valor fijo, por lo que un cambio de tema puede actualizar muchos objetos a la vez.

En Aspose.Slides, el tema a nivel de presentación está disponible a través de la propiedad [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/). Una presentación también puede contener anulaciones de tema en niveles inferiores. Un maestro puede anular el tema de la presentación mediante [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/), un diseño puede anular su tema heredado mediante [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), y una diapositiva individual puede hacer lo mismo. En la práctica, el tema efectivo para una diapositiva se resuelve mediante esta cadena de herencia: tema de presentación, anulación del maestro, anulación del diseño y anulación de la diapositiva.

![Componentes del tema: colores, fuentes, estilos de fondo y efectos](theme-constituents.png)

Las secciones siguientes muestran los flujos de trabajo más comunes relacionados con temas: inspeccionar un tema, cambiar colores y fuentes, copiar o aplicar un tema, actualizar estilos de fondo y de efecto, y leer valores efectivos después de que se haya resuelto la herencia y las anulaciones.

## **Inspeccionar un tema**

El objeto [MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) expone las propiedades del tema : [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/) y [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/). Inspeccionar estas colecciones antes de modificarlas resulta especialmente útil cuando una presentación proviene de una fuente externa, ya que el número y el contenido de las entradas de estilo pueden variar.

El siguiente ejemplo lee las propiedades principales del tema e informa cuántos estilos de fondo, relleno, línea y efecto están almacenados en el tema:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme

    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

Si un archivo utiliza varios maestros, no asuma que cada diapositiva tiene el mismo tema efectivo. Inspeccione el maestro asociado a la diapositiva y utilice el flujo de trabajo de tema efectivo que se muestra más adelante en este artículo cuando puedan existir anulaciones a nivel de diseño o de diapositiva.

## **Cambiar colores del tema**

Los rellenos, líneas y textos con conocimiento del tema pueden referirse a un color lógico de la enumeración [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/). Cuando cambia la entrada correspondiente en el [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) del tema, todos los objetos que todavía hacen referencia a ese color del tema se resuelven contra el nuevo valor. Los objetos que utilizan un color RGB directo no se modifican mediante una actualización de color del tema.

El siguiente ejemplo de extremo a extremo crea una forma que utiliza `ACCENT4`, cambia el color `accent4` del tema a rojo, guarda la presentación, la vuelve a abrir e imprime el color de relleno efectivo:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    presentation.master_theme.color_scheme.accent4.color = draw.Color.red

    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

Como el rectángulo sigue vinculado a `ACCENT4`, su color visible pasa a rojo después de cambiar el tema. Si sustituye el color del esquema por un color directo en la forma, los cambios posteriores de `accent4` ya no afectarán a ese relleno.

### **Usar colores de la paleta adicional**

PowerPoint deriva variantes más claras y más oscuras de un color del tema aplicando transformaciones de color. Aspose.Slides expone estas transformaciones a través de la enumeración [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/).

![Colores principales del tema y colores más claros y más oscuros generados a partir de la paleta adicional](additional-palette-colors.png)

**1** - Colores principales del tema.  
**2** - Variantes más claras y más oscuras producidas a partir de los colores principales del tema.

El siguiente ejemplo crea seis rectángulos basados en `ACCENT4`, aplica transformaciones de luminancia a cinco de ellos y guarda el resultado:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

Estas variantes siguen basándose en el color del tema. Si `accent4` cambia más adelante, los colores transformados se recalculan a partir del nuevo valor de `accent4`.

### **Mapear valores de `SchemeColor` a ranuras de `ColorScheme`**

La enumeración [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) utiliza `TEXT1`, `BACKGROUND1`, `TEXT2` y `BACKGROUND2`, mientras que [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) expone las mismas ranuras del tema como `dark1`, `light1`, `dark2` y `light2`. La asignación es fija:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Estos son nombres alternativos para las mismas ranuras del tema; no son valores que se conviertan dinámicamente de una forma a otra.

## **Cambiar fuentes del tema**

Un esquema de fuentes del tema contiene un conjunto de fuentes principal para encabezados y un conjunto de fuentes secundario para el texto del cuerpo. Las propiedades [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) y [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) exponen esos conjuntos.

Los identificadores de fuentes de tema compatibles con PowerPoint pueden usarse en el formato de texto:

* `+mn-lt` - Fuente del cuerpo latina (Minor Latin Font)
* `+mj-lt` - Fuente del encabezado latina (Major Latin Font)
* `+mn-ea` - Fuente del cuerpo del Este de Asia (Minor East Asian Font)
* `+mj-ea` - Fuente del encabezado del Este de Asia (Major East Asian Font)
* `+mn-cs` - Fuente del cuerpo de guiones complejos (Minor Complex Script Font)
* `+mj-cs` - Fuente del encabezado de guiones complejos (Major Complex Script Font)

El siguiente ejemplo crea un encabezado que utiliza la fuente latina mayor del tema y una línea de cuerpo que utiliza la fuente latina menor del tema. A continuación cambia las fuentes del tema y guarda el resultado:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")

    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")

    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")

    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

El encabezado sigue la fuente mayor y el texto del cuerpo sigue la fuente menor. Un texto que tenga un nombre de fuente explícito en lugar de un identificador de tema no cambiará automáticamente cuando el esquema de fuentes del tema cambie.

Las colecciones mayor y menor también pueden contener asignaciones de fuentes para sistemas de escritura individuales, como cirílico, árabe, japonés, georgiano y thaana. Para inspeccionar, agregar, sustituir o eliminar estas asignaciones, consulte [Script-Specific Theme Fonts](/slides/es/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Para obtener más información sobre fuentes de presentación, consulte [PowerPoint Fonts](/slides/es/python-net/powerpoint-fonts/).
{{% /alert %}}

### **Resolver referencias de fuentes del tema**

Al inspeccionar texto, [FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) puede contener una referencia al tema como `+mn-lt` en lugar de un nombre de familia de fuente. Llame a [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) con el [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) apropiado para resolver esa referencia. Los prefijos `+mj` y `+mn` seleccionan los conjuntos de fuentes mayor y menor; los sufijos `-lt`, `-ea` y `-cs` seleccionan sus fuentes latina, del Este de Asia y de guiones complejos, respectivamente.

Obtenga el tema efectivo mediante [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) en el objeto cuyo tema se aplica al texto inspeccionado. Para texto ordinario en una diapositiva, use `slide.create_theme_effective` de modo que el contexto incluya el tema heredado de esa diapositiva y las anulaciones locales. Al inspeccionar un diseño o un maestro, use su propio tema efectivo. No asuma que el tema del primer maestro se aplique a todas las diapositivas.

El siguiente ejemplo crea una porción de texto que hace referencia explícita a la fuente latina menor. Inicializa un esquema de fuentes de diapositiva mediante [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) y establece las familias latinas mayor y menor en `Arial` y `Calibri`, haciendo reproducible el resultado sin un archivo de entrada.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

La salida es `+mn-lt -> Calibri` seguido de `Verdana -> Verdana`. La referencia almacenada permanece sin cambios, mientras que un nombre de familia explícito se devuelve tal cual. Si la porción usara `+mj-lt`, se resolvería a `Arial` en este tema.

Resolver una referencia de tema identifica la familia de fuentes especificada por el tema. No verifica la disponibilidad de la fuente ni determina el archivo de fuente que finalmente se use después de la sustitución o la sustitución de glifos en la renderización. Consulte [Font Selection Sequence](/slides/es/python-net/font-selection-sequence/) y [Font Substitution](/slides/es/python-net/font-substitution/) para esos pasos independientes.

## **Copiar o aplicar un tema**

Los flujos de trabajo a continuación resuelven diferentes problemas relacionados con temas.

### **Aplicar un tema externo a las diapositivas dependientes de un maestro**

Use [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) cuando tenga un archivo de tema de PowerPoint (`.thmx`) y desee reestilizar cada diapositiva que dependa de un maestro concreto. Seleccione el maestro de la colección [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) ([MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) y pase la ruta del archivo de tema al método.

El método realiza las siguientes operaciones:

1. Crea un nuevo maestro de diapositiva basado en el maestro seleccionado.  
1. Aplica el tema externo al nuevo maestro.  
1. Asigna el nuevo maestro a todas las diapositivas que previamente dependían del maestro seleccionado.  
1. Devuelve el nuevo [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/).

El siguiente ejemplo aplica un tema externo a las diapositivas que dependen del primer maestro y guarda la presentación:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Un tema inválido, corrupto o no compatible puede generar una [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) o una de sus subclases relacionadas con el formato. Valide las rutas suministradas por los usuarios, gestione los fallos de acceso al sistema de archivos y guarde la presentación solo después de que el tema se haya aplicado correctamente.

Solo se reasignan las diapositivas que dependían del maestro seleccionado. Las diapositivas asociadas a otros maestros conservan sus maestros y temas existentes. Los colores, fuentes, rellenos, líneas, fondos y efectos conscientes del tema se resuelven contra el tema externo. Los colores, fuentes, rellenos y demás formatos asignados directamente pueden permanecer sin cambios. Las anulaciones a nivel de diseño y a nivel de diapositiva también pueden tener prioridad sobre los valores heredados del nuevo maestro.

El tema puede hacer referencia a fuentes que no estén disponibles en el entorno de ejecución. Para garantizar una renderización y exportación coherentes, instale las fuentes requeridas, proporciónelas mediante [custom font sources](/slides/es/python-net/custom-font/), o configure la [font substitution](/slides/es/python-net/font-substitution/).

Este es un flujo de trabajo directo a nivel de maestro: el método acepta la ruta a un archivo `.thmx` y no requiere crear manualmente anulaciones de tema a nivel de diapositiva o de diseño.

### **Aplicar diferentes temas externos en una presentación con varios maestros**

Cuando el maestro relevante no se conoce de antemano, obténgalo de una diapositiva representativa mediante [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) y [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/). Guarde las referencias de los maestros originales antes de aplicar cualquier tema, ya que cada llamada crea otro maestro en la presentación.

El siguiente ejemplo utiliza diapositivas de dos secciones para localizar sus maestros y aplica un tema externo diferente a cada grupo:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")

            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

La primera llamada afecta solo a las diapositivas que dependían de `first_group_master`, y la segunda afecta solo a las que dependían de `second_group_master`. Las diapositivas pertenecientes a cualquier otro maestro no se reestilizan.

### **Conservar un tema de origen al mover diapositivas**

Si desea mover una diapositiva a otra presentación y conservar su diseño original, clone el maestro de origen en la presentación de destino con [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/), luego clone la diapositiva con [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) y el maestro clonado. Esto transporta el maestro, sus diseños y el tema asociado juntos.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]

        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)

        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

Este es el flujo de trabajo recomendado cuando la diapositiva de origen debe verse idéntica en el destino. Simplemente clonar contenido sobre un maestro de destino no relacionado puede cambiar los colores, fuentes, fondos y efectos controlados por el tema.

### **Aplicar valores del tema a una diapositiva existente**

Si la diapositiva de destino debe permanecer en su maestro y diseño actuales, inicialice una anulación a nivel de diapositiva a partir del tema de origen. Los métodos [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) y [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) copian los tres componentes principales del tema en la anulación.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]

        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)

        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

Esto cambia el tema usado por esa diapositiva sin modificar el tema heredado por las demás diapositivas. Para eliminar la anulación local y volver a los valores heredados, llame a [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/).

### **Aplicar una anulación de tema a un diseño**

Una anulación a nivel de diseño se aplica a las diapositivas que usan ese diseño, a menos que una diapositiva concreta tenga su propia anulación. Los mismos métodos de inicialización pueden usarse a través del [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/) del diseño:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)

        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

Utilice un tema a nivel de maestro o de presentación cuando muchos diseños y diapositivas deban compartir la misma base de diseño, una anulación de diseño cuando una familia de diseños necesite un estilo diferente, y una anulación de diapositiva solo para excepciones verdaderas. Un exceso de anulaciones a nivel de diapositiva dificulta predecir los cambios de tema globales posteriores.

## **Actualizar estilos de fondo del tema**

Los rellenos de fondo del tema se almacenan en [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint puede presentar más opciones de fondo en su interfaz de usuario que el número de definiciones de relleno almacenadas físicamente en esta colección, porque la UI puede combinar los rellenos del tema con colores del tema y otras referencias de estilo.

![Galería de estilos de fondo de PowerPoint para un tema de presentación](presentation-design_8.png)

Antes de usar un estilo de fondo, inspeccione la colección almacenada y el [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/) actual. `style_index` usa `0` para indicar ningún relleno temático; los valores positivos son referencias a estilos de fondo temáticos. Esto difiere del índice de una colección de Python, donde `[0]` representa el primer elemento almacenado. No asuma que cada presentación contiene el mismo número de estilos de relleno de fondo.

El siguiente ejemplo informa el número de estilos de relleno de fondo disponibles, asigna una referencia de fondo temático al primer maestro y guarda la presentación:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:

    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")

    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")

    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1

    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

El resultado visible depende de la entrada de tema a la que haga referencia el maestro y de cualquier anulación de fondo a nivel de diseño o diapositiva. Si una diapositiva usa su propio fondo, cambiar solo el fondo del maestro puede no afectar a esa diapositiva. Use [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) cuando necesite conocer el fondo final tras aplicar la herencia.

{{% alert color="warning" title="Warning" %}}
No trate `style_index` como un índice de colección basado en cero. Evite también codificar un número de estilo de un archivo y suponer que tendrá la misma apariencia en otro archivo; las definiciones de estilo del tema son específicas de cada presentación.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para formateo directo de fondos y herencia de fondos, consulte [Presentation Background](/slides/es/python-net/presentation-background/).
{{% /alert %}}

## **Actualizar efectos del tema**

Un esquema de formato del tema contiene colecciones separadas de [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/), y [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/). Los temas típicos de Office suelen contener tres entradas principales de estilo que corresponden visualmente a formatos sutiles, moderados e intensos, pero el código debe inspeccionar cada colección en lugar de asumir un recuento fijo.

![Efectos temáticos sutiles, moderados e intensos aplicados a la misma forma](presentation-design_10.png)

Al acceder a estas colecciones en Python, el índice de la colección es cero basado: `[0]` es el primer estilo almacenado y `[2]` es el tercero. Los índices de referencia de estilo de una forma son un concepto separado, expuesto a través de [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/). Modificar un estilo del tema afecta a las formas que hacen referencia a ese estilo del tema; las formas con formato directo pueden permanecer sin cambios.

El siguiente ejemplo verifica que existan las entradas de estilo requeridas, cambia el primer estilo de línea, cambia el tercer estilo de relleno, habilita una sombra externa en el tercer estilo de efecto y guarda el resultado:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")

    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

Para las formas que hacen referencia a estas ranuras, el primer estilo de línea del tema se vuelve rojo, el tercer estilo de relleno del tema pasa a ser verde bosque sólido y el tercer estilo de efecto gana una sombra externa con una distancia de 10 puntos. El resultado visual exacto sigue dependiendo de qué ranuras de estilo referencia cada forma y si el formato directo sobrescribe el tema.

![Estilos de efecto del tema después de cambiar la línea, el relleno y la sombra](presentation-design_11.png)

## **Seleccionar estilos de relleno y línea del tema para una forma**

Una forma puede seleccionar su relleno y contorno de forma independiente mediante [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) y [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/). Para ambas propiedades, el índice `1` selecciona la primera entrada en la colección temática correspondiente (`fill_styles[0]` o `line_styles[0]`), y el índice `2` selecciona la segunda entrada.

El siguiente ejemplo define dos rellenos (oro y azul celeste) y dos contornos (azul oscuro a 6 pt y rojo oscuro a 12 pt) en el tema predeterminado de una nueva presentación. Guarda la diapositiva en tres etapas para que pueda comparar los resultados en PowerPoint.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| Estilos iniciales | Cambiar el contorno derecho | Editar el primer relleno del tema |
|:---:|:---:|:---:|
| ![Rectángulos oro y azul celeste con contornos finos azul oscuro coincidentes](theme-style-initial.png) | ![El rectángulo azul celeste ahora tiene un contorno grueso rojo oscuro](theme-style-line-changed.png) | ![El rectángulo izquierdo ahora es verde y ambos contornos permanecen sin cambios](theme-style-fill-changed.png) |

Seleccionar un estilo de línea diferente solo cambia el contorno del rectángulo derecho. Editar el primer relleno del tema actualiza todas las formas que lo usan. En este caso, solo el rectángulo izquierdo se vuelve verde.

En una forma existente, un color de relleno, color de línea o ancho de línea local pueden sobrescribir esa parte del estilo del tema. Si cambiar un índice de estilo no produce un efecto visible, compruebe el [direct formatting](/slides/es/python-net/shape-formatting/) de la forma.

## **Determinar si un relleno sólido efectivo usa un color del tema**

Un relleno puede almacenarse directamente en un objeto o heredarse de un párrafo, diseño, maestro, estilo de tema u otro nivel de formato. Llame a [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) para resolver esa jerarquía en un objeto inmutable [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/). Primero compruebe [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Sólo cuando sea `FillType.SOLID` debe leer las propiedades del relleno sólido.

Para un relleno sólido, [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) devuelve el valor RGB final después de heredar, buscar en el tema y aplicar transformaciones de color. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) devuelve la ranura lógica correspondiente de [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/), como `TEXT1` o `ACCENT6`. Un valor de `SchemeColor.NOT_DEFINED` indica que el relleno sólido efectivo no se basa en un color de esquema. En un flujo de trabajo donde los rellenos son colores de tema o colores RGB directos, este valor identifica un relleno RGB directo.

No utilice solo el valor local de [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) para clasificar un relleno. Por ejemplo, una porción de texto puede no tener un color de esquema definido localmente, de modo que su valor local sea `NOT_DEFINED`, mientras que su relleno efectivo hereda un color del tema y se resuelve a `TEXT1` o `ACCENT6`. Por el contrario, `solid_fill_scheme_color` le indica qué ranura lógica del tema produjo el color efectivo, pero no le dice si esa ranura proviene del objeto, párrafo, diseño, maestro u otro nivel de la jerarquía de formato.

El siguiente ejemplo carga una presentación, audita los rellenos de forma y los rellenos de porción de texto, imprime cada valor RGB final y el color de esquema asociado, y marca los rellenos sólidos que no seguirán los cambios de color del tema:

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

La rama `NOT_DEFINED` proporciona una lista de auditoría de rellenos sólidos que no responderán a los cambios en las ranuras de color del tema. Revise esos objetos cuando una presentación deba seguir una nueva paleta de marca. El valor RGB informado sigue mostrando la apariencia actual, mientras que el valor de esquema explica si esa apariencia está vinculada al tema.

Los objetos de formato efectivo son instantáneas. Después de cambiar el tema de la presentación, una anulación de tema o cualquier formato heredado, llame a `get_effective` nuevamente y lea un nuevo objeto `IFillFormatEffectiveData` antes de comparar o informar colores.

## **Leer valores efectivos del tema**

Los objetos de tema sin procesar le indican lo que está definido en un nivel determinado. Los valores efectivos le muestran lo que una diapositiva o forma utiliza realmente después de que se haya resuelto la herencia y las anulaciones locales. Para una diapositiva, llame a [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Para un fondo, use [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/), y para un relleno, use [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/).

El siguiente ejemplo lee el tema efectivo, el fondo y el primer relleno de forma de una diapositiva:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()

    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")

    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

Utilice datos efectivos para diagnósticos de renderizado, validación y comparaciones. Si solo inspecciona [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/), puede pasar por alto una anulación de maestro, diseño, diapositiva o forma que cambie la apariencia final.

## **Preguntas frecuentes**

**¿Aplicar un tema externo afecta a todas las diapositivas de la presentación?**

No. [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) reasigna solo las diapositivas que dependen del maestro seleccionado. Las diapositivas que usan otros maestros conservan sus temas existentes.

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el maestro?**

Sí. Use el [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) de la diapositiva e inicialice su tema de anulación. El cambio permanece local a esa diapositiva; las demás diapositivas continúan heredando sus temas actuales.

**¿Cuál es la forma más segura de trasladar un tema de una presentación a otra?**

Al mover una diapositiva y conservar su apariencia de origen, clone el maestro de origen en el destino y clone la diapositiva con ese maestro mediante [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) y [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/). Esto mantiene juntos el maestro, los diseños y el tema.

**¿Cómo puedo ver los valores efectivos después de la herencia y las anulaciones?**

Utilice [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) para un tema de diapositiva o de diseño y los métodos de datos efectivos correspondientes para objetos de formato, como [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) y [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/). Estas API devuelven los valores resueltos tras aplicar la herencia y las anulaciones.