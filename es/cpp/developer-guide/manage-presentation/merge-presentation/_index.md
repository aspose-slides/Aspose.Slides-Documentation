---
title: Combinar Presentación - API de PowerPoint de C++
linktitle: Combinar Presentación
type: docs
weight: 40
url: /es/cpp/merge-presentation/
keywords: "Combinar PowerPoint, PPTX, PPT, combinar PowerPoint, combinar presentación, combinar presentación, C++"
description: El artículo explica cómo puedes combinar o fusionar presentaciones de PowerPoint utilizando la API o biblioteca de PowerPoint de C++.
---

{{% alert  title="Consejo" color="primary" %}} 

Es posible que desees consultar la aplicación **Merger gratuita de Aspose** [aquí](https://products.aspose.app/slides/merger). Permite a las personas combinar presentaciones de PowerPoint en el mismo formato (PPT a PPT, PPTX a PPTX, etc.) y fusionar presentaciones en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Fusión de Presentaciones**

Cuando combinas una presentación con otra, estás efectivamente combinando sus diapositivas en una sola presentación para obtener un solo archivo. 

{{% alert title="Información" color="info" %}}

La mayoría de los programas de presentación (PowerPoint u OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esta manera. 

[**Aspose.Slides para C++**](https://products.aspose.com/slides/cpp/), sin embargo, te permite combinar presentaciones de diferentes maneras. Puedes fusionar presentaciones con todas sus formas, estilos, textos, formatos, comentarios, animaciones, etc., sin tener que preocuparte por la pérdida de calidad o datos. 

**Vea también**

[Clonar Diapositivas](https://docs.aspose.com/slides/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Qué Se Puede Combinar**

Con Aspose.Slides, puedes combinar 

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación
* presentaciones en un formato (PPT a PPT, PPTX a PPTX, etc.) y en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.) entre sí. 

{{% alert title="Nota" color="warning" %}} 

Además de presentaciones, Aspose.Slides te permite fusionar otros archivos:

* [Imágenes](https://products.aspose.com/slides/cpp/merger/image-to-image/), como [JPG a JPG](https://products.aspose.com/slides/cpp/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/cpp/merger/png-to-png/)
* Documentos, como [PDF a PDF](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/cpp/merger/html-to-html/)
* Y dos archivos diferentes como [imagen a PDF](https://products.aspose.com/slides/cpp/merger/image-to-pdf/) o [JPG a PDF](https://products.aspose.com/slides/cpp/merger/jpg-to-pdf/) o [TIFF a PDF](https://products.aspose.com/slides/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opciones de Fusión**

Puedes aplicar opciones que determinan si

* cada diapositiva en la presentación de salida mantiene un estilo único
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida. 

Para fusionar presentaciones, Aspose.Slides proporciona métodos [AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (de la interfaz [ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection)). Hay varias implementaciones de los métodos `AddClone` que definen los parámetros del proceso de fusión de presentaciones. Cada objeto Presentación tiene una colección [Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), por lo que puedes llamar un método `AddClone` desde la presentación a la que deseas fusionar diapositivas. 

El método `AddClone` devuelve un objeto `ISlide`, que es un clon de la diapositiva de origen. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas de origen. Por lo tanto, puedes realizar cambios en las diapositivas resultantes (por ejemplo, aplicar estilos u opciones de formato o diseños) sin preocuparte de que las presentaciones de origen se vean afectadas. 

## **Fusionar Presentaciones** 

Aspose.Slides proporciona el método [**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) que te permite combinar diapositivas mientras las diapositivas mantienen sus diseños y estilos (parámetros por defecto). 

Este código C++ te muestra cómo fusionar presentaciones:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Fusionar Presentaciones con Maestro de Diapositivas**

Aspose.Slides proporciona el método [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) que te permite combinar diapositivas mientras aplicas una plantilla de presentación de maestro de diapositivas. De esta manera, si es necesario, puedes cambiar el estilo de las diapositivas en la presentación de salida. 

Este código en C++ demuestra la operación descrita:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Nota" color="warning" %}} 

El diseño de la diapositiva para el maestro de diapositivas se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `AddClone` está establecido en verdadero, se utiliza el diseño de la diapositiva de origen. De lo contrario, se lanzará una excepción [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

Si deseas que las diapositivas en la presentación de salida tengan un diseño diferente, usa el método [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) en su lugar al fusionar. 

## **Fusionar Diapositivas Específicas de Presentaciones**

Este código C++ te muestra cómo seleccionar y combinar diapositivas específicas de diferentes presentaciones para obtener una sola presentación de salida:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Fusionar Presentaciones Con Diseño de Diapositiva**

Este código C++ te muestra cómo combinar diapositivas de presentaciones mientras aplicas tu diseño de diapositiva preferido a ellas para obtener una presentación de salida:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Fusionar Presentaciones Con Diferentes Tamaños de Diapositivas**

{{% alert title="Nota" color="warning" %}} 

No puedes fusionar presentaciones con diferentes tamaños de diapositivas. 

{{% /alert %}}

Para fusionar 2 presentaciones con diferentes tamaños de diapositivas, debes redimensionar una de las presentaciones para que su tamaño coincida with el tamaño de la otra presentación. 

Este código de muestra demuestra la operación descrita:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Fusionar Diapositivas a Sección de Presentación**

Este código C++ te muestra cómo fusionar una diapositiva específica a una sección en una presentación:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

La diapositiva se agrega al final de la sección. 

{{% alert title="Consejo" color="primary" %}}

Aspose proporciona una [aplicación web Collage GRATUITA](https://products.aspose.app/slides/collage). Utilizando este servicio en línea, puedes fusionar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid), y más. 

{{% /alert %}}