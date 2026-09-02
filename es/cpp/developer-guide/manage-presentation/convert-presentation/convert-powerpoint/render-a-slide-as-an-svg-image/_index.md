---
title: Renderizar diapositivas de presentación como imágenes SVG en C++
linktitle: Diapositiva a SVG
type: docs
weight: 50
url: /es/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint a SVG
- presentación a SVG
- diapositiva a SVG
- PPT a SVG
- PPTX a SVG
- opciones de exportación SVG
- SVG interactivo
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Exporta diapositivas de PowerPoint como imágenes SVG en C++ y controla fuentes, texto, imágenes, ID y eventos con Aspose.Slides."
---
## **Visión general**

SVG es un formato de imagen escalable basado en XML que funciona bien para la publicación web, visores de diapositivas, flujos de trabajo de accesibilidad y procesamiento automatizado posterior. Aspose.Slides para C++ exporta cada diapositiva a un archivo SVG separado y le permite controlar cómo se escriben el texto, las fuentes, las imágenes y los elementos SVG.

Utilice [SVGOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/) cuando el SVG exportado debe ser compacto, predecible en todos los navegadores o estar listo para uso interactivo.

## **Exportar una diapositiva como SVG**

Cree una [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/), seleccione una diapositiva y escríbala en un flujo. El siguiente ejemplo exporta cada diapositiva de una presentación como un archivo SVG separado.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

El nombre de archivo utiliza [ISlide::get_SlideNumber](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/get_slidenumber/) en lugar del índice del bucle. También puede exportar una forma individual con [IShape::WriteAsSvg](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/writeassvg/) cuando un visor de diapositivas o una página web necesita solo esa forma.

## **Configurar la salida SVG**

[SVGOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/) controla la renderización de SVG. Para los marcos de texto, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/set_useframesize/) incluye el marco de texto en el área de renderizado, y [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/set_useframerotation/) determina si se aplica la rotación del marco. Establezca [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) a `true` cuando el texto deba renderizarse sin ligaduras.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Controlar texto y fuentes**

### **Vectorizar todo el texto**

Establezca [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) a `true` para escribir todo el texto de la diapositiva como gráficos vectoriales. Esto elimina las dependencias de fuentes y hace que el resultado visual sea más consistente en distintos navegadores, pero el texto ya no será seleccionable ni buscable como texto SVG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **Elija cómo se manejan las fuentes externas**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) utiliza un valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgexternalfontshandling/) para las fuentes que se cargan externamente. Elija `AddLinksToFontFiles` para referenciar archivos de fuentes separados, `Embed` para incluir los datos de la fuente en el SVG, o `Vectorize` para representar solo el texto que utiliza fuentes externas como gráficos. Verifique la licencia de las fuentes antes de incrustarlas.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **Reducir el tamaño de imágenes incrustadas**

Utilice [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/set_picturescompression/) para reducir la resolución de las imágenes incrustadas, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) para omitir áreas recortadas de la fuente y [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/set_jpegquality/) para controlar la calidad de codificación JPEG. Estos ajustes reducen el tamaño del archivo a costa de la fidelidad de la imagen o de los datos de imagen retenidos.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Asignar ID estables a formas y texto**

Utilice [ISvgShapeFormattingController](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/isvgshapeformattingcontroller/) para establecer [ISvgShape::set_Id](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/isvgshape/set_id/) para cada forma SVG. Para establecer valores [ISvgTSpan::set_Id](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/isvgtspan/set_id/) en los elementos de texto `tspan` también, implemente [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Asigne cualquiera de los controladores con [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

El siguiente controlador utiliza [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_officeinteropshapeid/), que es estable durante la vida útil de la forma, y un contador repetible para sus `tspan` de texto. Esto hace que los ID generados sean adecuados para el post‑proceso de una presentación sin cambios.

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Añadir manejadores de eventos SVG**

En un [ISvgShapeFormattingController](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/isvgshapeformattingcontroller/), llame a [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/isvgshape/seteventhandler/) con un valor [SvgEvent](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgevent/) para añadir un manejador de eventos JavaScript a una forma exportada. Asigne el controlador con [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) y defina la función JavaScript en la página o documento SVG que aloje el resultado.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

La página anfitriona puede definir la función JavaScript referenciada por el manejador. Asignar ID y manejadores de eventos permite visores de diapositivas, mejoras de accesibilidad y otros flujos de trabajo interactivos con SVG.

## **Preguntas frecuentes**

**¿Cuándo debería usar [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) en lugar de [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Utilice [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) cuando todo el texto debe ser independiente de las fuentes. Utilice [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgexternalfontshandling/) cuando solo el texto que usa fuentes externas debería convertirse en gráficos.

**¿Cuál es la mejor manera de hacer un SVG más pequeño?**

Comience comprimiendo las imágenes incrustadas, eliminando las áreas recortadas de las imágenes y eligiendo archivos de fuentes vinculados cuando el entorno de destino pueda servirlos. Pruebe el resultado porque la menor resolución de la imagen, la menor calidad JPEG y el texto vectorizado tienen cada uno diferentes compromisos entre calidad y tamaño.

**¿Puedo modificar los elementos SVG exportados después de la exportación?**

Sí. Asigne IDs mediante un controlador de formato y, a continuación, seleccione los elementos SVG correspondientes en su herramienta de post‑proceso o script del navegador.