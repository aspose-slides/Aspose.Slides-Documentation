---
title: Convertir PPT, PPTX y ODP a JPG en Python
linktitle: Diapositivas a JPG
type: docs
weight: 60
url: /es/python-net/convert-powerpoint-to-jpg/
keywords:
- convertir PowerPoint a JPG
- convertir presentación a JPG
- convertir diapositiva a JPG
- convertir PPT a JPG
- convertir PPTX a JPG
- convertir ODP a JPG
- PowerPoint a JPG
- presentación a JPG
- diapositiva a JPG
- PPT a JPG
- PPTX a JPG
- ODP a JPG
- convertir PowerPoint a JPEG
- convertir presentación a JPEG
- convertir diapositiva a JPEG
- convertir PPT a JPEG
- convertir PPTX a JPEG
- convertir ODP a JPEG
- PowerPoint a JPEG
- presentación a JPEG
- diapositiva a JPEG
- PPT a JPEG
- PPTX a JPEG
- ODP a JPEG
- Python
- Aspose.Slides
description: "Aprende a transformar tus diapositivas de presentaciones de PowerPoint y OpenDocument en imágenes JPEG de alta calidad con solo unas pocas líneas de código en Python. Optimiza presentaciones para la web, el intercambio y el archivado. ¡Lee la guía completa ahora!"
---

## **Acerca de la conversión de PowerPoint a JPG**
Con [**Aspose.Slides .NET API**](https://products.aspose.com/slides/python-net/) puedes convertir presentaciones PowerPoint PPT o PPTX a imagen JPG en Python. También es posible convertir PPT/PPTX a BMP, PNG o SVG en Python. Con estas funciones es fácil implementar tu propio visor de presentaciones, crear  la miniatura para cada diapositiva. Esto puede ser útil si deseas proteger las diapositivas de la presentación contra derechos de autor, demostrar la presentación en modo de solo lectura. Aspose.Slides permite convertir toda la presentación o una diapositiva determinada en formatos de imagen.

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte PowerPoint a imágenes JPG, puede que desees probar estos convertidores online gratuitos: PowerPoint [PPTX a JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) y [PPT a JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:texto_alt_imagen](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX a JPG**
Aquí están los pasos para convertir PPT/PPTX a JPG:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén el objeto de diapositiva de tipo [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) de la colección [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
3. Crea la miniatura de cada diapositiva y luego conviértela en JPG. [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) se utiliza para obtener una miniatura de una diapositiva, devuelve [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) como resultado. El método [GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) debe ser llamado desde la diapositiva necesaria de tipo [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/), los escalados de la miniatura resultante se pasan al método.
4. Después de obtener la miniatura de la diapositiva, llama al método [**IImage.Save(string filename, ImageFormat format)**](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) desde el objeto de la miniatura. Pasa el nombre del archivo resultante y el formato de imagen.

{{% alert color="primary" %}} 
**Nota**: La conversión de PPT/PPTX a JPG es diferente de la conversión a otros tipos en Aspose.Slides .NET API. Para otros tipos, generalmente usas el método [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/), pero aquí necesitas el método [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8).
{{% /alert %}} 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for sld in pres.slides:
    with sld.get_image(1, 1) as bmp:
        bmp.save("Slide_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

## **Convertir PowerPoint PPT/PPTX a JPG con dimensiones personalizadas**
Para cambiar la dimensión de la miniatura resultante y la imagen JPG, puedes establecer los valores de *ScaleX* y *ScaleY* pasándolos al método [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/):

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

desiredX = 1200
desiredY = 800
scaleX = (float)(1.0 / pres.slide_size.size.width) * desiredX
scaleY = (float)(1.0 / pres.slide_size.size.height) * desiredY

for sld in pres.slides:
    with sld.get_image(scaleX, scaleY) as bmp:
        bmp.save("Slide_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

{{% alert title="Consejo" color="primary" %}}

Aspose ofrece una aplicación web de collage [GRATIS](https://products.aspose.app/slides/collage). Usando este servicio online, puedes combinar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid), y más. 

Usando los mismos principios descritos en este artículo, puedes convertir imágenes de un formato a otro. Para más información, consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Ver también**

Ve otras opciones para convertir PPT/PPTX en imagen como:

- [Conversión de PPT/PPTX a SVG](/slides/es/python-net/render-a-slide-as-an-svg-image/).