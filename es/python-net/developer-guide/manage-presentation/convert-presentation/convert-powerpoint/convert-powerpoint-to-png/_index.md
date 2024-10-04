---
title: Convertir PowerPoint a PNG
type: docs
weight: 30
url: /es/python-net/convert-powerpoint-to-png/
keywords: PowerPoint a PNG, PPT a PNG, PPTX a PNG, Python, Aspose.Slides para Python a través de .NET
description: Convertir presentación de PowerPoint a PNG
---

## **Sobre la Conversión de PowerPoint a PNG**

El formato PNG (Portable Network Graphics) no es tan popular como JPEG (Joint Photographic Experts Group), pero sigue siendo muy popular.

**Caso de uso:** Cuando tienes una imagen compleja y el tamaño no es un problema, PNG es un mejor formato de imagen que JPEG.

{{% alert title="Consejo" color="primary" %}} Puede que quieras revisar los **Conversores de PowerPoint a PNG** gratuitos de Aspose: [PPTX a PNG](https://products.aspose.app/slides/conversion/pptx-to-png) y [PPT a PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Son una implementación en vivo del proceso descrito en esta página. {{% /alert %}}

## **Convertir PowerPoint a PNG**

Sigue estos pasos:

1. Instancia la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén el objeto de la diapositiva de la colección [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) bajo la interfaz [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Usa el método [ISlide.GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) para obtener la miniatura de cada diapositiva.
4. Usa el método [IPresentation.SaveMethod(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) para guardar la miniatura de la diapositiva en formato PNG.

Este código en Python te muestra cómo convertir una presentación de PowerPoint a PNG:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image() as image:
        image.save("slide_{i}.png".format(i = index), slides.ImageFormat.PNG)
```

## **Convertir PowerPoint a PNG con Dimensiones Personalizadas**

Si deseas obtener archivos PNG alrededor de una cierta escala, puedes establecer los valores para `desiredX` y `desiredY`, que determinan las dimensiones de la miniatura resultante.

Este código en Python demuestra la operación descrita:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

scaleX = 2
scaleY = 2
for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image(scaleX, scaleY) as image:
        image.save("slide_{index}.png".format(index=index), slides.ImageFormat.PNG)
```

## **Convertir PowerPoint a PNG con Tamaño Personalizado**

Si deseas obtener archivos PNG alrededor de un cierto tamaño, puedes pasar tus argumentos preferidos de `width` y `height` para `ImageSize`.

Este código te muestra cómo convertir un PowerPoint a PNG mientras especificas el tamaño para las imágenes:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

size = drawing.Size(960, 720)

for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image(size) as image:
        image.save("slide_{index}.png".format(index=index), slides.ImageFormat.PNG)
```