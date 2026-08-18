---
title: Gestionar temas de presentaciones PowerPoint en Python
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/python-net/presentation-theme/
keywords:
- Tema PowerPoint
- Tema de presentación
- Tema de diapositiva
- Establecer tema
- Cambiar tema
- Gestionar tema
- Color del tema
- Paleta adicional
- Fuente del tema
- Estilo del tema
- Efecto del tema
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Domina los temas de presentación en Aspose.Slides para Python mediante .NET para crear, personalizar y convertir archivos PowerPoint con una identidad corporativa coherente."
---
## **Introducción**

Un tema de presentación define un conjunto coordinado de colores, tipografías, estilos de fondo, rellenos, líneas y efectos. Los objetos compatibles con temas hacen referencia a estas definiciones compartidas en lugar de almacenar cada propiedad visual como un valor fijo, por lo que un cambio de tema puede actualizar muchos objetos a la vez.

En Aspose.Slides, el tema a nivel de presentación está disponible a través de la propiedad [Presentation.master_theme](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/master_theme/). Una presentación también puede contener sobrescrituras de tema en niveles inferiores. Un maestro puede sobrescribir el tema de la presentación mediante [MasterThemeManager.override_theme](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/masterthememanager/override_theme/), un diseño puede sobrescribir su tema heredado mediante [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), y una diapositiva individual puede hacer lo mismo. En la práctica, el tema efectivo de una diapositiva se resuelve a través de esta cadena de herencia: tema de la presentación, sobrescritura del maestro, sobrescritura del diseño y sobrescritura de la diapositiva.

![Componentes del tema: colores, tipografías, estilos de fondo y efectos](theme-constituents.png)

Las secciones siguientes muestran los flujos de trabajo de tema más habituales: inspeccionar un tema, cambiar colores y tipografías, copiar o aplicar un tema, actualizar estilos de fondo y de efecto, y leer valores efectivos después de que se hayan resuelto la herencia y las sobrescrituras.

## **Inspeccionar un tema**

El objeto [MasterTheme](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/mastertheme/) expone las propiedades [color_scheme](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/mastertheme/font_scheme/) y [format_scheme](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/mastertheme/format_scheme/) del tema. Inspeccionar estas colecciones antes de modificarlas resulta especialmente útil cuando una presentación proviene de una fuente externa, ya que el número y el contenido de las entradas de estilo pueden variar.

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

Si un archivo utiliza varios maestros, no asuma que cada diapositiva tiene el mismo tema efectivo. Inspeccione el maestro asociado a la diapositiva y utilice el flujo de trabajo de tema efectivo que se muestra más adelante en este artículo cuando puedan existir sobrescrituras de diseño o de diapositiva.

## **Cambiar colores del tema**

Los rellenos, líneas y textos compatibles con temas pueden referirse a un color lógico de la enumeración [SchemeColor](https://reference.aspose.com/slides/es/python-net/aspose.slides/schemecolor/). Cuando cambia la entrada correspondiente en el [ColorScheme](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/colorscheme/) del tema, todos los objetos que siguen referenciando ese color de tema se resuelven contra el nuevo valor. Los objetos que utilizan un color RGB directo no se ven afectados por una actualización del color del tema.

El siguiente ejemplo de extremo a extremo crea una forma que usa `ACCENT4`, cambia el color `accent4` del tema a rojo, guarda la presentación, la vuelve a abrir y muestra el color de relleno efectivo:

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

Porque el rectángulo sigue vinculado a `ACCENT4`, su color visible se vuelve rojo después de cambiar el tema. Si sustituye el color del esquema por un color directo en la forma, los cambios posteriores de `accent4` ya no afectarán a ese relleno.

### **Usar colores de la paleta adicional**

PowerPoint genera variantes más claras y más oscuras a partir de un color del tema aplicando transformaciones de color. Aspose.Slides expone estas transformaciones mediante la enumeración [ColorTransformOperation](https://reference.aspose.com/slides/es/python-net/aspose.slides/colortransformoperation/).

![Colores principales del tema y colores más claros y oscuros generados a partir de la paleta adicional](additional-palette-colors.png)

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

Estas variantes siguen basadas en el color del tema. Si `accent4` cambia más tarde, los colores transformados se recalculan a partir del nuevo valor de `accent4`.

### **Mapear valores de `SchemeColor` a ranuras de `ColorScheme`**

La enumeración [SchemeColor](https://reference.aspose.com/slides/es/python-net/aspose.slides/schemecolor/) utiliza `TEXT1`, `BACKGROUND1`, `TEXT2` y `BACKGROUND2`, mientras que [ColorScheme](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/colorscheme/) expone las mismas ranuras del tema como `dark1`, `light1`, `dark2` y `light2`. El mapeo es fijo:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Estos son nombres alternativos para las mismas ranuras del tema; no son valores que se convierten dinámicamente de una forma a otra.

## **Cambiar tipografías del tema**

Un esquema tipográfico del tema contiene un conjunto de tipografías principal para los encabezados y un conjunto secundario para el texto del cuerpo. Las propiedades [FontScheme.major](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/fontscheme/major/) y [FontScheme.minor](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/fontscheme/minor/) exponen esos conjuntos.

Los identificadores de tipografía compatibles con PowerPoint pueden usarse en el formato de texto:

* `+mn-lt` - Fuente del cuerpo latino (Minor Latin Font)
* `+mj-lt` - Fuente del encabezado latino (Major Latin Font)
* `+mn-ea` - Fuente del cuerpo este‑asiática (Minor East Asian Font)
* `+mj-ea` - Fuente del encabezado este‑asiática (Major East Asian Font)

El siguiente ejemplo crea un encabezado que utiliza la tipografía latina mayor del tema y una línea de cuerpo que utiliza la tipografía latina menor del tema. A continuación cambia las tipografías del tema y guarda el resultado:

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

El encabezado sigue la tipografía mayor y el texto del cuerpo sigue la tipografía menor. El texto que tenga un nombre de tipografía explícito en lugar de un identificador de tema no cambiará automáticamente cuando el esquema tipográfico del tema se modifique.

{{% alert color="info" title="Consejo" %}}
Para obtener más información sobre las tipografías en presentaciones, consulte [Fuentes de PowerPoint](/slides/es/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Copiar o aplicar un tema**

Existen dos flujos de trabajo habituales, y resuelven problemas diferentes.

### **Preservar un tema de origen al mover diapositivas**

Si desea mover una diapositiva a otra presentación y preservar su diseño original, clone el maestro de origen en la presentación de destino con [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslidecollection/add_clone/), y luego clone la diapositiva con [SlideCollection.add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/) y el maestro clonado. Esto lleva el maestro, sus diseños y el tema asociado juntos.

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

Este es el flujo de trabajo preferido cuando la diapositiva de origen debe verse igual en el destino. Simplemente clonar contenido sobre un maestro de destino no relacionado puede cambiar los colores, tipografías, fondos y efectos controlados por el tema.

### **Aplicar valores de tema a una diapositiva existente**

Si la diapositiva de destino debe permanecer en su maestro y diseño actuales, inicialice una sobrescritura a nivel de diapositiva a partir del tema de origen. Los métodos [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) y [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) copian los tres componentes principales del tema en la sobrescritura.

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

Esto cambia el tema usado por esa diapositiva sin modificar el tema heredado por otras diapositivas. Para eliminar la sobrescritura local y volver a los valores heredados, llame a [OverrideTheme.clear](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/overridetheme/clear/).

### **Aplicar una sobrescritura de tema a un diseño**

Una sobrescritura a nivel de diseño se aplica a las diapositivas que usan ese diseño, a menos que una diapositiva concreta tenga su propia sobrescritura. Los mismos métodos de inicialización pueden usarse a través del [LayoutSlideThemeManager](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/layoutslidethememanager/) del diseño:

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

Use un tema a nivel de maestro o de presentación cuando muchos diseños y diapositivas deben compartir el mismo diseño base, una sobrescritura de diseño cuando una familia de diseños necesita un estilo diferente, y una sobrescritura de diapositiva solo para excepciones reales. Un exceso de sobrescrituras a nivel de diapositiva dificulta predecir los cambios globales de tema posteriores.

## **Actualizar estilos de fondo del tema**

Los rellenos de fondo del tema se almacenan en [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint puede presentar más opciones de fondo en su interfaz que el número de definiciones de relleno almacenadas físicamente en esta colección, porque la IU puede combinar rellenos de tema con colores de tema y otras referencias de estilo.

![Galería de estilos de fondo de PowerPoint para un tema de presentación](presentation-design_8.png)

Antes de usar un estilo de fondo, inspeccione la colección almacenada y el [Background.style_index](https://reference.aspose.com/slides/es/python-net/aspose.slides/background/style_index/) actual. `style_index` usa `0` para indicar que no hay relleno temático; los valores positivos son referencias a estilos de fondo temáticos. Esto difiere del índice de una colección de Python, donde `[0]` representa el primer elemento almacenado. No asuma que cada presentación contiene el mismo número de estilos de relleno de fondo.

El siguiente ejemplo informa cuántos rellenos de fondo están disponibles, asigna una referencia de fondo temático al primer maestro y guarda la presentación:

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

El resultado visible depende de la entrada del tema referenciada por el maestro y de cualquier sobrescritura de fondo en el diseño o la diapositiva. Si una diapositiva usa su propio fondo, cambiar solo el fondo del maestro puede no afectar a esa diapositiva. Utilice [Background.get_effective](https://reference.aspose.com/slides/es/python-net/aspose.slides/background/get_effective/) cuando necesite conocer el fondo final después de aplicada la herencia.

{{% alert color="warning" title="Advertencia" %}}
No trate `style_index` como un índice de colección basado en cero. Además, evite codificar un número de estilo de un archivo y asumir que tiene la misma apariencia en otro archivo; las definiciones de estilo del tema son específicas de cada presentación.
{{% /alert %}}

{{% alert color="info" title="Consejo" %}}
Para formateo directo de fondo y herencia de fondo, consulte [Fondo de la presentación](/slides/es/python-net/presentation-background/).
{{% /alert %}}

## **Actualizar efectos del tema**

Un esquema de formato del tema contiene colecciones separadas de [FormatScheme.fill_styles](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/formatscheme/line_styles/) y [FormatScheme.effect_styles](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/formatscheme/effect_styles/). Los temas típicos de Office suelen contener tres entradas de estilo principales que corresponden visualmente a formatos sutiles, moderados e intensos, pero el código debe inspeccionar cada colección en lugar de asumir un recuento fijo.

![Efectos de tema sutiles, moderados e intensos aplicados a la misma forma](presentation-design_10.png)

Cuando accede a estas colecciones en Python, el índice de la colección es basado en cero: `[0]` es el primer estilo almacenado y `[2]` es el tercero. Los índices de referencia de estilo de una forma son un concepto separado, expuesto a través de [IShapeStyle](https://reference.aspose.com/slides/es/python-net/aspose.slides/ishapestyle/). Modificar un estilo de tema afecta a las formas que hacen referencia a ese estilo; las formas con formato directo pueden permanecer sin cambios.

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

Para las formas que referencian estas ranuras, el primer estilo de línea del tema se vuelve rojo, el tercer estilo de relleno del tema se vuelve verde bosque sólido, y el tercer estilo de efecto adquiere una sombra externa con una distancia de 10 puntos. El resultado visual exacto sigue dependiendo de qué ranuras de estilo referencia cada forma y de si el formato directo sobrescribe al tema.

![Estilos de efecto del tema después de cambiar línea, relleno y ajustes de sombra](presentation-design_11.png)

## **Leer valores efectivos del tema**

Los objetos de tema crudos indican lo que está definido en un nivel concreto. Los valores efectivos indican lo que realmente usa una diapositiva o forma después de que se hayan resuelto la herencia y las sobrescrituras locales. Para una diapositiva, llame a [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Para un fondo, use [Background.get_effective](https://reference.aspose.com/slides/es/python-net/aspose.slides/background/get_effective/), y para un relleno, use [FillFormat.get_effective](https://reference.aspose.com/slides/es/python-net/aspose.slides/fillformat/get_effective/).

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

Utilice los datos efectivos para diagnósticos de renderizado, validación y comparaciones. Si solo inspecciona [Presentation.master_theme](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/master_theme/), puede pasar por alto una sobrescritura de maestro, diseño, diapositiva o forma que cambie la apariencia final.

## **Preguntas frecuentes**

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el maestro?**

Sí. Utilice el [SlideThemeManager](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/slidethememanager/) de la diapositiva e inicialice su tema sobrescrito. El cambio permanece local a esa diapositiva; las demás diapositivas continúan heredando sus temas actuales.

**¿Cuál es la forma más segura de transportar un tema de una presentación a otra?**

Al mover una diapositiva y preservar su apariencia original, clone el maestro de origen en el destino y clone la diapositiva con ese maestro mediante [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslidecollection/add_clone/) y [SlideCollection.add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_clone/). Esto mantiene juntos el maestro, los diseños y el tema.

**¿Cómo puedo ver los valores efectivos después de la herencia y las sobrescrituras?**

Utilice [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) para un tema de diapositiva o diseño y los métodos de datos efectivos correspondientes para objetos de formato, como [Background.get_effective](https://reference.aspose.com/slides/es/python-net/aspose.slides/background/get_effective/) y [FillFormat.get_effective](https://reference.aspose.com/slides/es/python-net/aspose.slides/fillformat/get_effective/). Estas API devuelven los valores resueltos después de aplicarse la herencia y las sobrescrituras.