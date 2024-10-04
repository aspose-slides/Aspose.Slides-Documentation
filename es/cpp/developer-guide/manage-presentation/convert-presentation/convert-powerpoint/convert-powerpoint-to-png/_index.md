---
title: Convertir PowerPoint a PNG
type: docs
weight: 30
url: /cpp/convert-powerpoint-to-png/
keywords: PowerPoint a PNG, PPT a PNG, PPTX a PNG, C++, Aspose.Slides para C++
description: Convertir presentación de PowerPoint a PNG
---

## **Acerca de la Conversión de PowerPoint a PNG**

El formato PNG (Portable Network Graphics) no es tan popular como JPEG (Joint Photographic Experts Group), pero sigue siendo muy popular.

**Caso de uso:** Cuando tienes una imagen compleja y el tamaño no es un problema, PNG es un mejor formato de imagen que JPEG.

{{% alert title="Consejo" color="primary" %}} Puede que quieras revisar los **Convertidores de PowerPoint a PNG** gratuitos de Aspose: [PPTX a PNG](https://products.aspose.app/slides/conversion/pptx-to-png) y [PPT a PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Son una implementación en vivo del proceso descrito en esta página. {{% /alert %}}

## **Convertir PowerPoint a PNG**

Sigue estos pasos:

1. Instancia la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén el objeto de la diapositiva de la colección [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) bajo la interfaz [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide).
3. Utiliza el método [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) para obtener la miniatura de cada diapositiva.
4. Utiliza el método [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) para guardar la miniatura de la diapositiva en el formato PNG.

Este código C++ te muestra cómo convertir una presentación de PowerPoint a PNG:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **Convertir PowerPoint a PNG con Dimensiones Personalizadas**

Si deseas obtener archivos PNG en torno a una cierta escala, puedes establecer los valores para `desiredX` y `desiredY`, que determinan las dimensiones de la miniatura resultante.

Este código en C++ demuestra la operación descrita:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **Convertir PowerPoint a PNG con Tamaño Personalizado**

Si deseas obtener archivos PNG en torno a un cierto tamaño, puedes pasar tus argumentos preferidos de `ancho` y `alto` para `ImageSize`.

Este código te muestra cómo convertir un PowerPoint a PNG mientras especificas el tamaño para las imágenes:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```