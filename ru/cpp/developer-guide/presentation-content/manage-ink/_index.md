---
title: Управление объектами чернил презентации в C++
linktitle: Управление чернилами
type: docs
weight: 95
url: /ru/cpp/manage-ink/
keywords:
- чернила
- объект чернил
- отпечаток чернил
- управление чернилами
- рисование чернил
- рисование
- экспорт чернил
- рендеринг чернил
- скрыть чернила
- IInkOptions
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Управляйте объектами чернил PowerPoint, редактируйте отпечатки и свойства кисти, а также контролируйте внешний вид чернил при экспорте в PDF, HTML, SVG, TIFF и изображения с помощью Aspose.Slides для C++."
---
## **Введение**

PowerPoint предоставляет функцию чернил, позволяющую рисовать произвольные штрихи. Чернила могут использоваться для выделения других объектов, отображения связей и процессов, а также привлечения внимания к определённым элементам на слайде.

Пространство имён [Aspose.Slides.Ink](https://reference.aspose.com/slides/ru/cpp/aspose.slides.ink/) содержит классы и интерфейсы, необходимые для работы с объектами чернил. Например, интерфейс [IInk](https://reference.aspose.com/slides/ru/cpp/aspose.slides.ink/iink/) представляет объект чернил на слайде.

## **Различия между обычными объектами и объектами чернил**

Объекты на слайде PowerPoint обычно представлены объектами формы. В своей простейшей форме форма представляет собой контейнер, определяющий область самого объекта (его рамку), а также свойства, такие как размер контейнера, форма и фон. Для получения дополнительной информации см. [Shape Layout Format](https://docs.aspose.com/slides/ru/cpp/shape-manipulations/#access-layout-formats-for-shape).

Однако когда PowerPoint обрабатывает объект чернил, он игнорирует все свойства рамки объекта (контейнера), кроме его размеров. Размер области контейнера определяется стандартными методами [IShape::get_Width](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_width/) и [IShape::get_Height](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Отпечатки чернил**

Отпечаток чернил — основной элемент, используемый для записи траектории пера, когда пользователь пишет цифровые чернила. Отпечаток хранит последовательность связанных точек.

Самая простая форма кодирования указывает координаты X и Y каждой выборочной точки. Когда все связанные точки отрисовываются, они создают изображение, подобное этому:

![ink_powerpoint2](ink_powerpoint2.png)

## **Свойства кисти для рисования**

Кисть используется для рисования линий, соединяющих точки отпечатка чернил. Кисть имеет собственный цвет и размер, представленные методами [IInkBrush::get_Color](https://reference.aspose.com/slides/ru/cpp/aspose.slides.ink/iinkbrush/get_color/) и [IInkBrush::get_Size](https://reference.aspose.com/slides/ru/cpp/aspose.slides.ink/iinkbrush/get_size/).

### **Установить цвет кисти чернил**

Этот код C++ демонстрирует, как установить цвет кисти чернил:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **Установить размер кисти чернил**

Этот код C++ демонстрирует, как установить размер кисти чернил:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

Как правило, ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (соответствующая секция данных закрашена серым). Когда ширина и высота кисти совпадают, PowerPoint отображает её размер следующим образом:

![ink_powerpoint3](ink_powerpoint3.png)

Для наглядности увеличим высоту объекта чернил и рассмотрим важные размеры:

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (рамка) не учитывает размер кистей — он всегда предполагает, что толщина линии равна нулю (см. предыдущее изображение).

Следовательно, чтобы определить видимую область всего объекта чернил, необходимо учитывать размер кисти его отпечатков. Здесь целевой объект (отпечаток рукописного текста) масштабирован до размеров контейнера (рамки). При изменении размера контейнера размер кисти остаётся постоянным и наоборот.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint использует аналогичное поведение для текстовых объектов:

![ink_powerpoint6](ink_powerpoint6.png)

## **Управление отображением чернил при экспорте и рендеринге**

Aspose.Slides предоставляет интерфейс [IInkOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/iinkoptions/), позволяющий управлять тем, как объекты чернил выглядят в экспортированных или отрисованных выводах. Вы можете использовать его методы, чтобы полностью скрыть чернила или изменить способ интерпретации операций маски кисти чернил.

Параметры чернил доступны через параметры экспорта или рендеринга для нескольких форматов вывода:

| Вывод | Метод параметров чернил |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Slide image | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Те же два параметра доступны через эти методы:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/iinkoptions/set_hideink/) определяет, включаются ли объекты чернил в вывод. Его значение по умолчанию — `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) определяет, интерпретируется ли операция маски как непрозрачность при рендеринге кисти чернил. Значение по умолчанию — `true`; установите `false`, чтобы использовать операцию ROP вместо этого.

### **Скрыть объекты чернил в PDF‑выводе**

По умолчанию объекты чернил остаются видимыми при экспорте. Вызовите [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/iinkoptions/set_hideink/) с параметром `true`, когда требуется чистый вывод без рукописных аннотаций или другого содержимого чернил.

Следующий пример C++ экспортирует презентацию в PDF, скрывая все объекты чернил:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Скрыть объекты чернил при рендеринге слайда как изображения**

Чтобы скрыть объекты чернил при рендеринге слайдов в битовые изображения, настройте [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) и передайте параметры рендеринга методу [ISlide::GetImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/getimage/).

Следующий пример C++ рендерит первый слайд как PNG‑изображение без объектов чернил:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **Управление рендерингом маски чернил**

Метод [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) управляет тем, как операции маски интерпретируются при рендеринге кистей чернил. Значение по умолчанию — `true`, что использует непрозрачность. Вызовите метод с `false`, чтобы вместо этого использовать операцию ROP.

Следующий пример C++ экспортирует слайд в SVG и использует рендеринг на основе ROP для операций маски чернил:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

То же самое параметр можно применить через [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/get_inkoptions/), когда экспортируется презентация или рендерится слайд в TIFF.

### **Выбор: скрыть или сохранить чернила**

Используйте [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/iinkoptions/set_hideink/) с `true`, когда экспортируемый файл должен быть чистой версией аннотированной презентации, например, финальной копией, предназначенной для распространения без отметок ревью.

Оставьте чернила видимыми (настройка по умолчанию `false`), когда аннотации чернил являются частью предполагаемого содержимого, например, комментарии ревью, рукописные заметки, выделения или рисунки, которые должны оставаться видимыми в экспортированном результате. Это позволяет приложениям генерировать отдельные ревью‑и финальные версии из одной презентации без изменения исходных объектов чернил.

## **FAQ**

**Могу ли я изменить цвет или размер существующего штриха чернил?**

Да. Получите отпечаток с помощью [IInk::get_Traces](https://reference.aspose.com/slides/ru/cpp/aspose.slides.ink/iink/get_traces/), затем измените его [IInkTrace::get_Brush](https://reference.aspose.com/slides/ru/cpp/aspose.slides.ink/iinktrace/get_brush/). Вы можете вызвать [IInkBrush::set_Color](https://reference.aspose.com/slides/ru/cpp/aspose.slides.ink/iinkbrush/set_color/) и [IInkBrush::set_Size](https://reference.aspose.com/slides/ru/cpp/aspose.slides.ink/iinkbrush/set_size/) для кисти.

**Скрытие чернил изменяет исходную презентацию?**

Нет. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/iinkoptions/set_hideink/) влияет только на отрисованный или экспортированный результат; он не удаляет и не изменяет объекты чернил в исходной презентации.

**Какие форматы экспорта поддерживают параметры чернил?**

Вы можете настроить параметры чернил для PDF, HTML, SVG, TIFF и растровых изображений слайдов через соответствующие параметры экспорта или рендеринга, указанные выше.

**Дополнительные материалы**

* Для общего ознакомления с формами см. раздел [PowerPoint Shapes](https://docs.aspose.com/slides/ru/cpp/powerpoint-shapes/).
* Для получения дополнительной информации о эффективных значениях см. [Shape Effective Properties](https://docs.aspose.com/slides/ru/cpp/shape-effective-properties/#get-effective-font-height-value).
* Подробности экспорта PDF см. в [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ru/cpp/convert-powerpoint-to-pdf/).
* Подробности экспорта HTML см. в [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ru/cpp/convert-powerpoint-to-html/).
* Подробности экспорта SVG см. в [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ru/cpp/render-a-slide-as-an-svg-image/).
* Подробности экспорта TIFF см. в [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ru/cpp/convert-powerpoint-to-tiff/).
* Подробности рендеринга слайд‑в‑изображение см. в [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ru/cpp/convert-slide/).