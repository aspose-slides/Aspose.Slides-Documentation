---
title: Fusionar presentaciones de forma eficiente en C++
linktitle: Fusionar presentaciones
type: docs
weight: 40
url: /es/cpp/merge-presentation/
keywords:
- fusionar PowerPoint
- fusionar presentaciones
- fusionar diapositivas
- fusionar PPT
- fusionar PPTX
- fusionar ODP
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- C++
- Aspose.Slides
description: "Fusión sin esfuerzo de presentaciones PowerPoint (PPT, PPTX) y OpenDocument (ODP) con Aspose.Slides para C++, optimizando su flujo de trabajo."
---

{{% alert  title="Tip" color="primary" %}} 

Tal vez quiera probar **Aspose free online** [Merger app](https://products.aspose.app/slides/merger). Permite a los usuarios combinar presentaciones de PowerPoint en el mismo formato (PPT a PPT, PPTX a PPTX, etc.) y combinar presentaciones en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Fusión de presentaciones**

Al fusionar una presentación con otra, está combinando efectivamente sus diapositivas en una sola presentación para obtener un archivo. 

{{% alert title="Info" color="info" %}}

La mayoría de los programas de presentación (PowerPoint u OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esta manera. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) , sin embargo, le permite combinar presentaciones de diferentes formas. Puede combinar presentaciones con todas sus formas, estilos, textos, formato, comentarios, animaciones, etc., sin preocuparse por la pérdida de calidad o datos. 

**Ver también**

[Clone Slides](https://docs.aspose.com/slides/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Qué se puede fusionar**

Con Aspose.Slides, puede fusionar 

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación
* presentaciones en un mismo formato (PPT a PPT, PPTX a PPTX, etc.) y en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.) entre sí. 

{{% alert title="Note" color="warning" %}} 

Además de las presentaciones, Aspose.Slides permite combinar otros archivos:

* [Imágenes](https://products.aspose.com/slides/cpp/merger/image-to-image/), como [JPG to JPG](https://products.aspose.com/slides/cpp/merger/jpg-to-jpg/) o [PNG to PNG](https://products.aspose.com/slides/cpp/merger/png-to-png/)
* Documentos, como [PDF to PDF](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/) o [HTML to HTML](https://products.aspose.com/slides/cpp/merger/html-to-html/)
* Y dos archivos diferentes, como [image to PDF](https://products.aspose.com/slides/cpp/merger/image-to-pdf/) o [JPG to PDF](https://products.aspose.com/slides/cpp/merger/jpg-to-pdf/) o [TIFF to PDF](https://products.aspose.com/slides/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opciones de fusión**

Puede aplicar opciones que determinan si

* cada diapositiva en la presentación de salida conserva un estilo único
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida. 

Para combinar presentaciones, Aspose.Slides proporciona métodos [AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (de la interfaz [ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection)). Hay varias implementaciones de los métodos `AddClone` que definen los parámetros del proceso de fusión de presentaciones. Cada objeto Presentation tiene una colección [Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), por lo que puede llamar a un método `AddClone` desde la presentación a la que desea combinar diapositivas. 

El método `AddClone` devuelve un objeto `ISlide`, que es una réplica de la diapositiva origen. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas de la fuente. Por lo tanto, puede modificar las diapositivas resultantes (por ejemplo, aplicar estilos, opciones de formato o diseños) sin preocuparse de que las presentaciones de origen se vean afectadas. 

## **Fusionar presentaciones** 

Aspose.Slides proporciona el método [**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) que permite combinar diapositivas mientras las diapositivas conservan sus diseños y estilos (parámetros predeterminados). 

Este código C++ le muestra cómo fusionar presentaciones:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


## **Fusionar presentaciones con un maestro de diapositivas**

Aspose.Slides proporciona el método [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) que permite combinar diapositivas aplicando una plantilla de maestro de diapositivas. De este modo, si es necesario, puede cambiar el estilo de las diapositivas en la presentación de salida. 

Este código C++ demuestra la operación descrita:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 

El diseño de diapositiva para el maestro se determina automáticamente. Cuando no se puede determinar un diseño adecuado, si el parámetro booleano `allowCloneMissingLayout` del método `AddClone` está establecido en true, se utiliza el diseño de la diapositiva origen. De lo contrario, se lanzará una [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

Si desea que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, utilice el método [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) en su lugar al combinar. 

## **Fusionar diapositivas específicas de presentaciones**

Combinar diapositivas específicas de varias presentaciones es útil para crear paquetes de diapositivas personalizados. Aspose.Slides C++ permite seleccionar e importar solo las diapositivas que necesita. La API preserva el formato, el diseño y la apariencia de las diapositivas originales.

El siguiente código C++ crea una nueva presentación, agrega diapositivas de título de dos presentaciones distintas y guarda el resultado en un archivo:
```cpp
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```

```cpp
auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```


## **Fusionar presentaciones con un diseño de diapositiva**

Este código C++ le muestra cómo combinar diapositivas de presentaciones aplicando su diseño de diapositiva preferido para obtener una única presentación de salida:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


## **Fusionar presentaciones con diferentes tamaños de diapositiva**

{{% alert title="Note" color="warning" %}} 

No se pueden fusionar presentaciones con diferentes tamaños de diapositiva. 

{{% /alert %}}

Para fusionar 2 presentaciones con diferentes tamaños de diapositiva, debe cambiar el tamaño de una de las presentaciones para que coincida con el de la otra. 

Este código de ejemplo demuestra la operación descrita:
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


## **Fusionar diapositivas a una sección de presentación**

Este código C++ le muestra cómo fusionar una diapositiva específica a una sección en una presentación:
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

{{% alert title="Tip" color="primary" %}}

Aspose ofrece una [FREE Collage web app](https://products.aspose.app/slides/collage). Con este servicio en línea, puede combinar [JPG to JPG](https://products.aspose.app/slides/collage/jpg) o PNG to PNG imágenes, crear [photo grids](https://products.aspose.app/slides/collage/photo-grid), y más. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Se conservan las notas del orador al fusionar?**

Sí. Al clonar diapositivas, Aspose.Slides traslada todos los elementos de la diapositiva, incluidas notas, formato y animaciones.

**¿Se transfieren los comentarios y sus autores?**

Los comentarios, como parte del contenido de la diapositiva, se copian con la diapositiva. Las etiquetas de autor de los comentarios se conservan como objetos de comentario en la presentación resultante.

**¿Qué ocurre si la presentación origen está protegida con contraseña?**

Debe [abrirse con la contraseña](/slides/es/cpp/password-protected-presentation/) mediante [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/); tras cargarla, esas diapositivas pueden clonarse de forma segura en un archivo de destino sin protección (o también protegido).

**¿Qué tan seguro es el proceso de fusión en entornos multihilo?**

No utilice la misma instancia de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) desde [múltiples hilos](/slides/es/cpp/multithreading/). La regla recomendada es "un documento — un hilo"; diferentes archivos pueden procesarse en paralelo en hilos independientes.