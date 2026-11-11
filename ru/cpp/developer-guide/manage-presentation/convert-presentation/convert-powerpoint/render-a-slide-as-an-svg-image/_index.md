---
title: Экспортировать слайды презентации как SVG‑изображения в C++
linktitle: Слайд в SVG
type: docs
weight: 50
url: /ru/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint в SVG
- презентация в SVG
- слайд в SVG
- PPT в SVG
- PPTX в SVG
- параметры экспорта SVG
- интерактивный SVG
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Экспортировать слайды PowerPoint в SVG‑изображения на C++ и управлять шрифтами, текстом, изображениями, идентификаторами и событиями с помощью Aspose.Slides."
---
## **Обзор**

SVG — масштабируемый основанный на XML формат изображений, который хорошо подходит для веб‑публикаций, просмотров слайдов, рабочих процессов доступности и автоматической постобработки. Aspose.Slides для C++ экспортирует каждый слайд в отдельный файл SVG и позволяет управлять тем, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) когда экспортированный SVG должен быть компактным, предсказуемым во всех браузерах или готовым к интерактивному использованию.

## **Экспортировать слайд как SVG**

Создайте [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), выберите слайд и запишите его в поток. Следующий пример экспортирует каждый слайд презентации в отдельный файл SVG.

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

Имя файла использует [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) вместо индекса цикла. Вы также можете экспортировать отдельную форму с помощью [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/), когда просмотрщику слайдов или веб‑странице нужен только этот объект.

## **Настроить вывод SVG**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) управляет рендерингом SVG. Для текстовых рамок [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) включает текстовую рамку в область рендеринга, а [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) определяет, применяется ли вращение рамки. Установите [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) в `true`, когда текст должен отображаться без лигатур.

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

## **Управление текстом и шрифтами**

При экспорте слайдов в SVG вы можете контролировать, останется ли текст текстом или будет преобразован в векторную графику, а также как включаются или ссылаются внешние шрифты. Следующие параметры помогают сбалансировать визуальную согласованность, возможность выбора текста и зависимости шрифтов в экспортированном SVG.

### **Векторизовать весь текст**

Установите [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) в `true`, чтобы записать весь текст слайда в виде векторной графики. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным во всех браузерах, но текст больше нельзя будет выделять или искать как SVG‑текст.

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

### **Выберите способ обработки внешних шрифтов**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/), задающее способ обработки шрифтов, загружаемых извне. Выберите `AddLinksToFontFiles`, чтобы ссылаться на отдельные файлы шрифтов, `Embed`, чтобы включить данные шрифта в SVG, или `Vectorize`, чтобы рендерить только текст, использующий внешние шрифты, как графику. Проверьте лицензирование шрифтов перед их встраиванием.

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

## **Сократить размер встроенных изображений**

Используйте [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/), чтобы уменьшить разрешение встроенных изображений, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) чтобы исключить обрезанные области исходных изображений, и [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) чтобы управлять качеством JPEG‑кодирования. Эти настройки уменьшают размер файла за счёт точности изображения или сохранённых данных изображения.

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

## **Управление разрешением растеризации метафайлов**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) задаёт нижний предел разрешения при растеризации метафайлов во время экспорта SVG. Используйте его, чтобы балансировать между детализацией и размером файла, когда растеризуется изображение EMF или WMF. Он не определяет глобальное DPI для SVG и не заставляет каждый объект на слайде становиться растровым изображением.

Скачайте [metafile-rasterization.pptx](metafile-rasterization.pptx), который содержит изображение EMF с плотно расположенными диагональными линиями. Следующий пример экспортирует его первый слайд с тремя разрешениями растеризации через [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/). Все остальные параметры экспорта остаются одинаковыми, чтобы можно было сравнить результаты.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"metafile-rasterization.pptx");
auto slide = presentation->get_Slide(0);
const int resolutions[] = { 72, 150, 300 };

for (auto dpi : resolutions)
{
    auto svgOptions = MakeObject<SVGOptions>();
    svgOptions->set_MetafileRasterizationDpi(dpi);
    svgOptions->set_PicturesCompression(PicturesCompression::Dpi330);
    svgOptions->set_JpegQuality(90);

    auto svgFileName = String::Format(u"slide-{0}.svg", dpi);
    auto svgStream = File::Create(svgFileName);
    slide->WriteAsSvg(svgStream, svgOptions);
    svgStream->Dispose();
}

presentation->Dispose();
```

В результате EMF превратилось в один встроенный PNG в каждом SVG. Ниже приведены измерения для поставленной презентации; они не являются общей формулой преобразования DPI в пиксельные размеры.

| Разрешение растеризации метафайла DPI | Размеры встроенного PNG | Размер файла SVG (байт) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Сравнение ниже показывает одну и ту же область встроенного растра при одинаковом увеличенном размере отображения. Диагональные линии демонстрируют заметную пикселизацию при 72 DPI и более плавные края при более высоких разрешениях, в то время как размер SVG‑файла растёт. Увеличение значения не обязательно улучшает каждую деталь или изменяет каждое экспортированное изображение.

![Увеличенная детализация диагональных линий при 72, 150 и 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) управляет уменьшением разрешения изображения и может маскировать эффект изменения разрешения растеризации метафайла. [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) управляет качеством JPEG‑кодирования, а не разрешением растеризации метафайла.

## **Назначить стабильные идентификаторы формам и тексту**

Используйте [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/), чтобы установить [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) для каждой формы SVG. Чтобы также задать значения [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) для элементов текста `tspan`, реализуйте [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Назначьте любой из контроллеров с помощью [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

Следующий контроллер использует [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/), который стабилен на протяжении всей жизни формы, и повторяемый счётчик для её текстовых спанов. Это делает сгенерированные идентификаторы пригодными для постобработки неизменённой презентации.

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

## **Добавить обработчики событий SVG**

В [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) вызовите [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) с значением [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) , чтобы добавить обработчик JavaScript‑события к экспортируемой форме. Назначьте контроллер с помощью [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) и определите функцию JavaScript на странице или в SVG‑документе, который содержит результат.

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

Хост‑страница может определить JavaScript‑функцию, на которую ссылается обработчик. Присвоение идентификаторов и обработчиков событий позволяет создавать просмотрщики слайдов, улучшать доступность и реализовывать другие интерактивные рабочие процессы SVG.

## **Часто задаваемые вопросы**

**Когда следует использовать [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) вместо [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Используйте [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/), когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/), когда только текст, использующий внешние шрифты, должен быть преобразован в графику.

**Как лучше всего уменьшить размер SVG?**

Начните с сжатия встроенных изображений, удаления обрезанных областей изображений и выбора ссылок на файлы шрифтов, если целевая среда может их обслуживать. Проверьте результат, так как снижение разрешения изображения, уменьшение качества JPEG и векторизация текста каждое имеет свои компромиссы между качеством и размером.

**Можно ли модифицировать экспортированные элементы SVG после экспорта?**

Да. Назначьте идентификаторы через контроллер форматирования, а затем выберите соответствующие SVG‑элементы в вашем инструменте постобработки или скрипте браузера.