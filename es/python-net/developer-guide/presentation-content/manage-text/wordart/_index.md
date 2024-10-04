---
title: WordArt
type: docs
weight: 110
url: /python-net/wordart/
keywords: "WordArt, Word Art, Crear WordArt, plantilla de WordArt, efectos de WordArt, efectos de sombra, efectos de visualización, efectos de resplandor, transformaciones de WordArt, efectos 3D, efectos de sombra exterior, efectos de sombra interior, Python, Aspose.Slides para Python a través de .NET"
description: "Añadir, manipular y gestionar WordArt y efectos en presentaciones de PowerPoint en Python o Aspose.Slides para Python a través de .NET"
---

## **¿Qué es WordArt?**
WordArt o Word Art es una función que te permite aplicar efectos a los textos para hacerlos destacar. Con WordArt, por ejemplo, puedes contornear un texto o rellenarlo con un color (o degradado), añadirle efectos 3D, etc. También puedes inclinar, doblar y estirar la forma de un texto.

{{% alert color="primary" %}} 

WordArt te permite tratar un texto como lo harías con un objeto gráfico. WordArt consiste en efectos o modificaciones especiales realizadas a los textos para hacerlos más atractivos o notorios.

{{% /alert %}} 

**WordArt en Microsoft PowerPoint**

Para usar WordArt en Microsoft PowerPoint, debes seleccionar una de las plantillas de WordArt predefinidas. Una plantilla de WordArt es un conjunto de efectos que se aplica a un texto o su forma.

**WordArt en Aspose.Slides**

En Aspose.Slides para Python a través de .NET 20.10, implementamos soporte para WordArt y realizamos mejoras a la función en versiones posteriores de Aspose.Slides para Python a través de .NET.

Con Aspose.Slides para Python a través de .NET, puedes crear fácilmente tu propia plantilla de WordArt (un efecto o combinación de efectos) en Python y aplicarla a los textos.

## Creando una Plantilla de WordArt Sencilla y Aplicándola a un Texto

**Usando Aspose.Slides** 

Primero, creamos un texto simple usando este código en Python: 

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
Ahora, establecemos la altura de la fuente del texto a un valor más grande para hacer que el efecto sea más notable a través de este código:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Usando Microsoft PowerPoint**

Ve al menú de efectos de WordArt en Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Desde el menú de la derecha, puedes elegir un efecto de WordArt predefinido. Desde el menú de la izquierda, puedes especificar la configuración para un nuevo WordArt. 

Estos son algunos de los parámetros u opciones disponibles:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aquí, aplicamos el color del patrón SmallGrid al texto y añadimos un borde de texto negro de 1 de ancho utilizando este código:

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

El texto resultante:

![todo:image_alt_text](image-20200930114108-4.png)

## Aplicando Otros Efectos de WordArt

**Usando Microsoft PowerPoint**

Desde la interfaz del programa, puedes aplicar estos efectos a un texto, bloque de texto, forma o elemento similar:

![todo:image_alt_text](image-20200930114129-5.png)

Por ejemplo, se pueden aplicar efectos de Sombra, Reflexión y Resplandor a un texto; efectos de Formato 3D y Rotación 3D a un bloque de texto; la propiedad de Bordes Suaves se puede aplicar a un Objeto de Forma (todavía tiene un efecto cuando no se establece ninguna propiedad de Formato 3D). 

### Aplicando Efectos de Sombra

Aquí, pretendemos establecer las propiedades relacionadas únicamente con un texto. Aplicamos el efecto de sombra a un texto utilizando este código en Python:

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

La API de Aspose.Slides soporta tres tipos de sombras: OuterShadow, InnerShadow y PresetShadow. 

Con PresetShadow, puedes aplicar una sombra para un texto (usando valores predefinidos). 

**Usando Microsoft PowerPoint**

En PowerPoint, puedes usar un tipo de sombra. Aquí hay un ejemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Usando Aspose.Slides**

Aspose.Slides en realidad te permite aplicar dos tipos de sombras a la vez: InnerShadow y PresetShadow.

**Notas:**

- Cuando se utilizan juntos OuterShadow y PresetShadow, solo se aplica el efecto de OuterShadow. 
- Si se utilizan simultáneamente OuterShadow e InnerShadow, el efecto resultante o aplicado depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013, el efecto se duplica. Pero en PowerPoint 2007, se aplica el efecto de OuterShadow. 

### Aplicando Efectos de Visualización a Textos

Añadimos visualización al texto a través de este ejemplo de código en Python:

```py 
    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5 
    portion.portion_format.effect_format.reflection_effect.distance = 4.72 
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0 
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90 
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100 
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT  
```

### Aplicando Efecto de Resplandor a Textos

Aplicamos el efecto de resplandor al texto para hacerlo brillar o destacar utilizando este código:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

El resultado de la operación:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Puedes cambiar los parámetros para sombra, visualización y resplandor. Las propiedades de los efectos se establecen en cada porción del texto por separado. 

{{% /alert %}} 

### Usando Transformaciones en WordArt

Usamos la propiedad Transform (inherente en todo el bloque de texto) a través de este código:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

El resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Tanto Microsoft PowerPoint como Aspose.Slides para Python a través de .NET proporcionan una cierta cantidad de tipos de transformación predefinidos. 

{{% /alert %}} 

**Usando PowerPoint**

Para acceder a tipos de transformación predefinidos, ve a: **Formato** -> **Efecto de Texto** -> **Transformar**

**Usando Aspose.Slides**

Para seleccionar un tipo de transformación, utiliza el enumerado TextShapeType. 

### Aplicando efectos 3D a Textos y Formas

Establecemos un efecto 3D en una forma de texto usando este código de muestra:

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

El texto resultante y su forma:

![todo:image_alt_text](image-20200930114816-9.png)

Aplicamos un efecto 3D al texto con este código en Python:

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

El resultado de la operación:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

La aplicación de efectos 3D a textos o sus formas e interacciones entre efectos se basa en ciertas reglas. 

Considera una escena para un texto y la forma que contiene ese texto. El efecto 3D contiene la representación del objeto 3D y la escena en la que se colocó el objeto. 

- Cuando la escena está configurada para tanto la figura como el texto, la escena de la figura tiene una mayor prioridad: se ignora la escena del texto. 
- Cuando la figura carece de su propia escena pero tiene representación 3D, se utiliza la escena del texto. 
- De lo contrario—cuando la forma originalmente no tiene efecto 3D—la forma es plana y el efecto 3D solo se aplica al texto. 

Las descripciones están conectadas a las propiedades [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) y [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

{{% /alert %}} 

## **Aplicar Efectos de Sombra Exterior a Textos**
Aspose.Slides para Python a través de .NET proporciona las clases [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) y [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/) que te permiten aplicar efectos de sombra a un texto llevado por TextFrame. Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén la referencia de una diapositiva usando su índice.
3. Añade una AutoShape de tipo Rectángulo a la diapositiva.
4. Accede al TextFrame asociado con la AutoShape.
5. Establece el FillType de la AutoShape a NoFill.
6. Instancia la clase OuterShadow.
7. Establece el BlurRadius de la sombra.
8. Establece la Dirección de la sombra.
9. Establece la Distancia de la sombra.
10. Establece el RectanglelAlign a TopLeft.
11. Establece el PresetColor de la sombra a Negro.
12. Escribe la presentación como un archivo PPTX.

Este código de muestra en Python—una implementación de los pasos anteriores—te muestra cómo aplicar el efecto de sombra exterior a un texto:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Obtener referencia de la diapositiva
    sld = pres.slides[0]

    # Añadir una AutoShape de tipo Rectángulo
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Añadir TextFrame al Rectángulo
    ashp.add_text_frame("Aspose TextBox")

    # Desactivar el relleno de la forma en caso de que queramos obtener la sombra del texto
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Añadir sombra exterior y establecer todos los parámetros necesarios
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    # Escribir la presentación en disco
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Aplicar Efecto de Sombra Interior a Formas**
Sigue estos pasos:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
2. Obtén una referencia de la diapositiva.
3. Añade una AutoShape de tipo Rectángulo.
4. Habilita InnerShadowEffect.
5. Establece todos los parámetros necesarios.
6. Establece el ColorType como Esquema.
7. Establece el Color del Esquema.
8. Escribe la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

Este código de muestra (basado en los pasos anteriores) te muestra cómo añadir un conector entre dos formas en Python:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Obtener referencia de una diapositiva
    slide = presentation.slides[0]

    # Añadir una AutoShape de tipo Rectángulo
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Añadir TextFrame al Rectángulo
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Habilitar inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Establecer todos los parámetros necesarios
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Establecer ColorType como Esquema
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Establecer Color del Esquema
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Guardar Presentación
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```