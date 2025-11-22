---
title: Administrar gráficos SmartArt en presentaciones usando Python
linktitle: Gráficos SmartArt
type: docs
weight: 20
url: /es/python-net/manage-smartart-shape/
keywords:
- Objeto SmartArt
- Gráfico SmartArt
- Estilo SmartArt
- Color SmartArt
- Crear SmartArt
- Agregar SmartArt
- Editar SmartArt
- Cambiar SmartArt
- Acceder a SmartArt
- Tipo de diseño SmartArt
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Automatice la creación, edición y estilo de SmartArt en PowerPoint con Python a través de .NET usando Aspose.Slides, ofreciendo ejemplos de código concisos y guía centrada en el rendimiento."
---

## **Crear formas SmartArt**

Aspose.Slides for Python a través de .NET le permite agregar formas SmartArt personalizadas a las diapositivas desde cero. La API facilita esto. Para agregar una forma SmartArt a una diapositiva:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga la diapositiva objetivo por su índice.
3. Agregue una forma SmartArt, especificando su tipo de diseño.
4. Guarde la presentación modificada como un archivo PPTX.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:
    # Acceder a la diapositiva de la presentación.
    slide = presentation.slides[0]
    # Añadir una forma SmartArt.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Guardar la presentación en disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Acceder a formas SmartArt en diapositivas**

El siguiente código demuestra cómo acceder a las formas SmartArt en una diapositiva. El ejemplo recorre cada forma en la diapositiva y verifica si es un objeto [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Cargar un archivo de presentación.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Recorrer cada forma en la primera diapositiva.
    for shape in presentation.slides[0].shapes:
        # Verificar si la forma es una forma SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Imprimir el nombre de la forma.
            print("Shape name:", shape.name)
```


## **Acceder a formas SmartArt con un tipo de diseño especificado**

El siguiente ejemplo muestra cómo acceder a una forma SmartArt con un tipo de diseño especificado. Tenga en cuenta que no puede cambiar el tipo de diseño de un SmartArt; es de solo lectura y se establece cuando se crea la forma.

1. Cree una instancia de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargue la presentación que contiene la forma SmartArt.
2. Obtenga una referencia a la primera diapositiva por índice.
3. Recorra cada forma en la primera diapositiva.
4. Verifique si la forma es un objeto [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).
5. Si el tipo de diseño de la forma SmartArt coincide con el que necesita, realice las acciones requeridas.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Recorrer cada forma en la primera diapositiva.
    for shape in presentation.slides[0].shapes:
        # Verificar si la forma es una forma SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Verificar el tipo de diseño SmartArt.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```


## **Cambiar el estilo de la forma SmartArt**

El siguiente ejemplo muestra cómo localizar formas SmartArt y cambiar su estilo:

1. Cree una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargue el archivo que contiene la(s) forma(s) SmartArt.
2. Obtenga una referencia a la primera diapositiva por índice.
3. Recorra cada forma en la primera diapositiva.
4. Encuentre la forma SmartArt con el estilo especificado.
5. Asigne el nuevo estilo a la forma SmartArt.
6. Guarde la presentación.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Recorrer cada forma en la primera diapositiva.
    for shape in presentation.slides[0].shapes:
        # Verificar si la forma es una forma SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Verificar el estilo SmartArt.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Cambiar el estilo SmartArt.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Guardar la presentación.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Cambiar el estilo de color de las formas SmartArt**

Este ejemplo muestra cómo cambiar el estilo de color de una forma SmartArt. El código de ejemplo localiza una forma SmartArt con un estilo de color especificado y la actualiza.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargue la presentación que contiene la(s) forma(s) SmartArt.
2. Obtenga una referencia a la primera diapositiva por índice.
3. Recorra cada forma en la primera diapositiva.
4. Verifique si la forma es un objeto [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).
5. Localice la forma SmartArt con el estilo de color especificado.
6. Establezca el nuevo estilo de color para esa forma SmartArt.
7. Guarde la presentación.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Recorrer cada forma en la primera diapositiva.
    for shape in presentation.slides[0].shapes:
        # Verificar si la forma es una forma SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Verificar el tipo de color.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Cambiar el tipo de color.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Guardar la presentación.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Puedo animar SmartArt como un solo objeto?**

Sí. SmartArt es una forma, por lo que puede aplicar [animaciones estándar](/slides/es/python-net/powerpoint-animation/) a través de la API de animaciones (entrada, salida, énfasis, rutas de movimiento) al igual que con otras formas.

**¿Cómo puedo encontrar un SmartArt específico en una diapositiva si no conozco su ID interno?**

Establezca y use el Texto alternativo (AltText) y busque la forma por ese valor; esta es una forma recomendada de localizar la forma objetivo.

**¿Puedo agrupar SmartArt con otras formas?**

Sí. Puede agrupar SmartArt con otras formas (imágenes, tablas, etc.) y luego [manipular el grupo](/slides/es/python-net/group/).

**¿Cómo obtengo una imagen de un SmartArt específico (p.ej., para una vista previa o informe)?**

Exporte una miniatura/imagen de la forma; la biblioteca puede [renderizar formas individuales](/slides/es/python-net/create-shape-thumbnails/) a archivos raster (PNG/JPG/TIFF).

**¿Se preservará la apariencia de SmartArt al convertir toda la presentación a PDF?**

Sí. El motor de renderizado apunta a alta fidelidad para la [exportación a PDF](/slides/es/python-net/convert-powerpoint-to-pdf/), con una variedad de opciones de calidad y compatibilidad.