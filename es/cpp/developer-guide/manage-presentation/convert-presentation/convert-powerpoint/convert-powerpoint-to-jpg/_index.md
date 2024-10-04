---
title: Convertir Powerpoint PPT a JPG
type: docs
weight: 60
url: /cpp/convert-powerpoint-to-jpg/
keywords:
- Convertir presentación de PowerPoint
- JPG
- JPEG
- PowerPoint a JPG
- PowerPoint a JPEG
- PPT a JPG
- PPTX a JPG
- PPT a JPEG
- PPTX a JPEG
- C++
- Aspose.Slides
description: "Convertir PowerPoint a JPG: PPT a JPG, PPTX a JPG en C++"
---

## **Convertir Presentación a Conjunto de Imágenes**

En algunos casos, es necesario convertir toda la presentación en un conjunto de imágenes, 
lo mismo que permite PowerPoint. El código C++ muestra cómo convertir una presentación a imágenes JPG:

```c++
auto imageScale = 1.0f;

auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : pres->get_Slides())
{
    // Crea una imagen a escala completa
    System::SharedPtr<IImage> image = slide->GetImage(imageScale, imageScale);

    // Guarda la imagen en disco en formato JPEG
    auto imageFileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(imageFileName, ImageFormat::Jpeg);

    image->Dispose();
}

pres->Dispose();
```

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte PowerPoint a imágenes JPG, puede que desee probar estos convertidores en línea gratuitos: PowerPoint [PPTX a JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) y [PPT a JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

## Convertir PowerPoint PPT/PPTX a JPG con Dimensiones Personalizadas**

Para cambiar la dimensión de la miniatura resultante y la imagen JPG, puede establecer los valores de *ScaleX* y *ScaleY* pasando `float scaleX, float Y` al método [**ISlide::GetImage()**](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagefloat-float-method):

```c++
auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

// Define dimensiones
int32_t desiredX = 1200, desiredY = 800;

// Obtiene los valores escalados de X e Y
float scaleX = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Width()) * desiredX;
float scaleY = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Height()) * desiredY;

for (auto&& slide : pres->get_Slides())
{
    // Crea una imagen a escala completa
    System::SharedPtr<IImage> image = slide->GetImage(scaleX, scaleY);

    // Guarda la imagen en disco en formato JPEG
    auto imageFileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(imageFileName, ImageFormat::Jpeg);

    image->Dispose();
}

pres->Dispose();
```

{{% alert title="Consejo" color="primary" %}}

Aspose proporciona una [aplicación web de collage GRATIS](https://products.aspose.app/slides/collage). Usando este servicio en línea, puede combinar imágenes [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid), y más. 

Usando los mismos principios descritos en este artículo, puede convertir imágenes de un formato a otro. Para más información, consulte estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Ver también**

Vea otras opciones para convertir PPT/PPTX en imágenes como:

- [Conversión de PPT/PPTX a SVG](/slides/cpp/render-a-slide-as-an-svg-image/)