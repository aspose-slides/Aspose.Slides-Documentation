---
title: Crear y aplicar efectos WordArt en Python
linktitle: WordArt
type: docs
weight: 110
url: /es/python-net/wordart/
keywords:
- WordArt
- crear WordArt
- plantilla WordArt
- efecto WordArt
- efecto sombra
- efecto visualización
- efecto brillo
- transformación WordArt
- efecto 3D
- efecto sombra exterior
- efecto sombra interior
- Python
- Aspose.Slides
description: "Aprenda a crear y personalizar efectos WordArt en Aspose.Slides para Python a través de .NET. Esta guía paso a paso ayuda a los desarrolladores a mejorar presentaciones con texto elegante y profesional en Python."
---

## **¿Acerca de WordArt?**
WordArt o Word Art es una característica que permite aplicar efectos a textos para que destaquen. Con WordArt, por ejemplo, puedes contornear un texto o rellenarlo con un color (o degradado), añadirle efectos 3D, etc. También puedes sesgar, doblar y estirar la forma de un texto. 

{{% alert color="primary" %}} 

WordArt permite tratar un texto como si fuera un objeto gráfico. WordArt consiste en efectos o modificaciones especiales realizadas a textos para que sean más atractivos o notables. 

{{% /alert %}} 

**WordArt en Microsoft PowerPoint**

Para usar WordArt en Microsoft PowerPoint, debes seleccionar una de las plantillas WordArt predefinidas. Una plantilla WordArt es un conjunto de efectos que se aplica a un texto o a su forma. 

**WordArt en Aspose.Slides**

En Aspose.Slides para Python a través de .NET 20.10, implementamos soporte para WordArt y mejoramos la característica en versiones posteriores de Aspose.Slides para Python a través de .NET. 

Con Aspose.Slides para Python a través de .NET, puedes crear fácilmente tu propia plantilla WordArt (un efecto o combinación de efectos) en Python y aplicarla a los textos. 

## Crear una plantilla WordArt simple y aplicarla a un texto

**Usando Aspose.Slides** 

Primero, creamos un texto simple con este código Python: 

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
Ahora, establecemos la altura de fuente del texto a un valor mayor para que el efecto sea más visible mediante este código:

```py
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Usando Microsoft PowerPoint**

Ve al menú de efectos WordArt en Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Desde el menú de la derecha, puedes elegir un efecto WordArt predefinido. Desde el menú de la izquierda, puedes especificar la configuración para un nuevo WordArt. 

Estos son algunos de los parámetros u opciones disponibles:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aquí, aplicamos el color de patrón SmallGrid al texto y añadimos un borde de texto negro de 1 pulgada de ancho con este código:

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

## Aplicar otros efectos WordArt

**Usando Microsoft PowerPoint**

Desde la interfaz del programa, puedes aplicar estos efectos a un texto, bloque de texto, forma o elemento similar:

![todo:image_alt_text](image-20200930114129-5.png)

Por ejemplo, los efectos Sombra, Reflexión y Brillo pueden aplicarse a un texto; los efectos Formato 3D y Rotación 3D pueden aplicarse a un bloque de texto; la propiedad Bordes suaves puede aplicarse a un objeto Forma (todavía tiene efecto cuando no se establece la propiedad Formato 3D). 

### Aplicar efectos de sombra

Aquí, nos centramos en establecer propiedades relacionadas solo con el texto. Aplicamos el efecto de sombra a un texto con este código en Python:

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

La API de Aspose.Slides admite tres tipos de sombras: OuterShadow, InnerShadow y PresetShadow. 

Con PresetShadow, puedes aplicar una sombra a un texto (usando valores predefinidos). 

**Usando Microsoft PowerPoint**

En PowerPoint, solo puedes usar un tipo de sombra. Aquí tienes un ejemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Usando Aspose.Slides**

Aspose.Slides realmente permite aplicar dos tipos de sombras a la vez: InnerShadow y PresetShadow.

**Notas:**

- Cuando se usan conjuntamente OuterShadow y PresetShadow, solo se aplica el efecto OuterShadow. 
- Si se usan simultáneamente OuterShadow y InnerShadow, el efecto resultante o aplicado depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013, el efecto se duplica. Pero en PowerPoint 2007, se aplica el efecto OuterShadow. 

### Aplicar reflexión a textos

Añadimos reflexión al texto con este fragmento de código en Python:

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

### Aplicar efecto de brillo a textos

Aplicamos el efecto de brillo al texto para que resalte con este código:

```py
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

El resultado de la operación:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Puedes cambiar los parámetros de sombra, reflexión y brillo. Las propiedades de los efectos se establecen por separado en cada porción del texto. 

{{% /alert %}} 

### Usar transformaciones en WordArt

Utilizamos la propiedad Transform (inherente a todo el bloque de texto) con este código:
```py
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

El resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Tanto Microsoft PowerPoint como Aspose.Slides para Python a través de .NET proporcionan un número determinado de tipos de transformación predefinidos. 

{{% /alert %}} 

**Usando PowerPoint**

Para acceder a los tipos de transformación predefinidos, ve a: **Formato** → **Efecto de texto** → **Transformar** 

**Usando Aspose.Slides**

Para seleccionar un tipo de transformación, usa el enumerado TextShapeType. 

### Aplicar efectos 3D a textos y formas

Establecemos un efecto 3D a una forma de texto con este ejemplo de código:

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

El texto y su forma resultantes:

![todo:image_alt_text](image-20200930114816-9.png)

Aplicamos un efecto 3D al texto con este código Python:

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

La aplicación de efectos 3D a textos o a sus formas y la interacción entre efectos siguen ciertas reglas. 

Considera una escena para un texto y la forma que contiene ese texto. El efecto 3D incluye la representación del objeto 3D y la escena donde se coloca el objeto. 

- Cuando la escena está configurada tanto para la figura como para el texto, la escena de la figura tiene mayor prioridad—la escena del texto se ignora. 
- Cuando la figura no tiene su propia escena pero posee representación 3D, se usa la escena del texto. 
- En caso contrario—cuando la forma originalmente no tiene efecto 3D—la forma permanece plana y el efecto 3D solo se aplica al texto. 

Las descripciones están vinculadas a las propiedades [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) y [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/). 

{{% /alert %}} 

## **Aplicar efectos de sombra exterior a textos**
Aspose.Slides para Python a través de .NET proporciona las clases [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) y [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/) que permiten aplicar efectos de sombra a un texto contenido en TextFrame. Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. Obtén la referencia de una diapositiva usando su índice. 
3. Añade una AutoShape de tipo Rectángulo a la diapositiva. 
4. Accede al TextFrame asociado a la AutoShape. 
5. Establece el FillType de la AutoShape a NoFill. 
6. Instancia la clase OuterShadow 
7. Define el BlurRadius de la sombra. 
8. Define la Direction de la sombra. 
9. Define la Distance de la sombra. 
10. Establece RectangleAlign a TopLeft. 
11. Define PresetColor de la sombra a Black. 
12. Guarda la presentación como archivo PPTX. 

Este código de ejemplo en Python—una implementación de los pasos anteriores—muestra cómo aplicar el efecto de sombra exterior a un texto:

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

    # Desactivar el relleno de forma por si queremos la sombra del texto
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Añadir sombra exterior y establecer todos los parámetros necesarios
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    # Guardar la presentación en disco
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Aplicar efecto de sombra interior a formas**
Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. Obtén una referencia de la diapositiva. 
3. Añade una AutoShape de tipo Rectángulo. 
4. Habilita InnerShadowEffect. 
5. Define todos los parámetros necesarios. 
6. Establece ColorType como Scheme. 
7. Define Scheme Color. 
8. Guarda la presentación como archivo [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Este código de ejemplo (basado en los pasos anteriores) muestra cómo añadir un conector entre dos formas en Python:

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

    # Definir todos los parámetros necesarios
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Establecer ColorType como Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Definir Scheme Color
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Guardar presentación
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
``` 

## **Preguntas frecuentes**

**¿Puedo usar efectos WordArt con diferentes fuentes o scripts (p. ej., árabe, chino)?**

Sí, Aspose.Slides admite Unicode y funciona con todas las fuentes y scripts principales. Los efectos WordArt como sombra, relleno y contorno pueden aplicarse sin importar el idioma, aunque la disponibilidad de fuentes y el renderizado pueden depender de las fuentes del sistema.

**¿Puedo aplicar efectos WordArt a elementos del patrón de diapositivas?**

Sí, puedes aplicar efectos WordArt a formas en las diapositivas patrón, incluidos marcadores de posición de título, pies de página o texto de fondo. Los cambios realizados en el diseño maestro se reflejarán en todas las diapositivas asociadas.

**¿Los efectos WordArt afectan al tamaño del archivo de la presentación?**

Un poco. Los efectos WordArt como sombras, brillos y rellenos degradados pueden aumentar ligeramente el tamaño del archivo debido a los metadatos de formato añadidos, pero la diferencia suele ser insignificante.

**¿Puedo previsualizar el resultado de los efectos WordArt sin guardar la presentación?**

Sí, puedes renderizar diapositivas que contengan WordArt a imágenes (p. ej., PNG, JPEG) usando el método `get_image` de las clases [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) o [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/). Esto te permite previsualizar el resultado en memoria o en pantalla antes de guardar o exportar la presentación completa.