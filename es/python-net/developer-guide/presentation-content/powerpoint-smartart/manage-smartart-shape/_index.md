---
title: Administrar forma de SmartArt
type: docs
weight: 20
url: /es/python-net/manage-smartart-shape/
keywords: "forma de SmartArt, estilo de forma de SmartArt, estilo de color de forma de SmartArt, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Administrar SmartArt en presentaciones de PowerPoint en Python"
---

## **Crear forma de SmartArt**
Aspose.Slides para Python a través de .NET ahora facilita agregar formas de SmartArt personalizadas en sus diapositivas desde cero. Aspose.Slides para Python a través de .NET ha proporcionado la API más simple para crear formas de SmartArt de la manera más fácil. Para crear una forma de SmartArt en una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue una forma de SmartArt estableciendo su LayoutType.
- Escriba la presentación modificada como un archivo PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Instanciar la presentación
with slides.Presentation() as pres:
    # Acceder a la diapositiva de la presentación
    slide = pres.slides[0]

    # Agregar forma de Smart Art
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Guardar presentación
    pres.save("SimpleSmartArt_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Acceder a la forma de SmartArt en la diapositiva**
El siguiente código se utilizará para acceder a las formas de SmartArt agregadas en la diapositiva de la presentación. En el código de muestra, recorreremos cada forma dentro de la diapositiva y verificaremos si es una forma de SmartArt. Si la forma es del tipo SmartArt, entonces la convertiremos a una instancia de SmartArt.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Cargar la presentación deseada
with slides.Presentation(path + "SmartArt.pptx") as pres:

    # Recorrer cada forma dentro de la primera diapositiva
    for shape in pres.slides[0].shapes:
        # Verificar si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Convertir forma a SmartArtEx
            print("Nombre de la forma:" + shape.name)
```



## **Acceder a la forma de SmartArt con un tipo de diseño particular**
El siguiente código de muestra ayudará a acceder a la forma de SmartArt con un LayoutType particular. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt, ya que es de solo lectura y se establece solo cuando se agrega la forma de SmartArt.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma de SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verifique si la forma es del tipo SmartArt y convierta la forma seleccionada a SmartArt si es SmartArt.
- Verifique la forma de SmartArt con un LayoutType particular y realice lo que se deba hacer a continuación.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Recorrer cada forma dentro de la primera diapositiva
    for shape in presentation.slides[0].shapes:
        # Verificar si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Verificar diseño de SmartArt
            if shape.layout == art.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Hacer algo aquí....")
```



## **Cambiar el estilo de forma de SmartArt**
El siguiente código de muestra ayudará a acceder a la forma de SmartArt con un LayoutType particular.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma de SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verifique si la forma es del tipo SmartArt y convierta la forma seleccionada a SmartArt si es SmartArt.
- Encuentre la forma de SmartArt con un estilo particular.
- Establezca el nuevo estilo para la forma de SmartArt.
- Guarde la presentación.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Recorrer cada forma dentro de la primera diapositiva
    for shape in presentation.slides[0].shapes:
        # Verificar si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Verificar estilo de SmartArt
            if shape.quick_style == art.SmartArtQuickStyleType.SIMPLE_FILL:
                # Cambiar estilo de SmartArt
                smart.quick_style = art.SmartArtQuickStyleType.CARTOON

    # Guardar presentación
    presentation.save("ChangeSmartArtStyle_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Cambiar el estilo de color de la forma de SmartArt**
En este ejemplo, aprenderemos a cambiar el estilo de color para cualquier forma de SmartArt. En el siguiente código de muestra se accederá a la forma de SmartArt con un estilo de color particular y se cambiará su estilo.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma de SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verifique si la forma es del tipo SmartArt y convierta la forma seleccionada a SmartArt si es SmartArt.
- Encuentre la forma de SmartArt con un estilo de color particular.
- Establezca el nuevo estilo de color para la forma de SmartArt.
- Guarde la presentación.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Recorrer cada forma dentro de la primera diapositiva
    for shape in presentation.slides[0].shapes:
        # Verificar si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Verificar tipo de color de SmartArt
            if shape.color_style == art.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Cambiar tipo de color de SmartArt
                shape.color_style = art.SmartArtColorType.COLORFUL_ACCENT_COLORS

    # Guardar presentación
    presentation.save("ChangeSmartArtColorStyle_out.pptx", slides.export.SaveFormat.PPTX)
```