---
title: Конвертировать слайды PowerPoint в PNG на C++
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/cpp/convert-powerpoint-to-png/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в PNG
- презентацию в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- C++
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в высококачественные изображения PNG быстро с помощью Aspose.Slides для C++, обеспечивая точные, автоматические результаты."
---
## **Обзор**

В этой статье объясняется, как преобразовать слайды презентации в изображения PNG с помощью Aspose.Slides для C++. Вы можете загружать презентации в форматах PPT, PPTX и ODP, отрисовывать каждый слайд и сохранять его как отдельное изображение PNG.

Приведённые ниже примеры демонстрируют рендеринг с масштабом по умолчанию, увеличение масштаба, указание размеров вывода в пикселях и выбор стиля рендеринга градиента.

## **Конвертировать PowerPoint в PNG**

Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и получите доступ к её слайдам через аксессор [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/). Пример отрисовывает каждый слайд с помощью [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) без параметров, чтобы создать миниатюру. Затем вызывается [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) с [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) для сохранения каждого отрисованного слайда в виде изображения PNG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Перегрузка [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) без параметров рендерит с масштабом 0.2. Например, слайд размером 720 × 540 пунктов создаёт миниатюру 144 × 108 пикселей. Чтобы управлять размерами вывода, используйте перегрузки с коэффициентами масштабирования или указанием явного размера изображения, показанные ниже.
{{% /alert %}}

## **Конвертировать PowerPoint в PNG с пользовательскими размерами**

Передайте горизонтальные и вертикальные коэффициенты масштабирования в [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/), чтобы контролировать размеры рендеринга. В этом примере оба коэффициента равны 2, поэтому слайд размером 720 × 540 пунктов создаёт изображение 1440 × 1080 пикселей. Равные коэффициенты сохраняют аспектное соотношение слайда. Каждое изображение сохраняется в формате PNG с помощью [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Конвертировать PowerPoint в PNG с пользовательским размером**

Чтобы указать размеры вывода в пикселях, передайте размер в [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) вместо коэффициентов масштабирования. Этот пример отрисовывает каждый слайд в 960 × 720 пикселей и сохраняет результат с помощью [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Выбирайте размеры, соответствующие аспектному соотношению слайда, чтобы избежать растягивания изображения.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Выбрать стиль рендеринга градиента**

Предположим, что слайд содержит градиентные заливки, но переходы в экспортированном PNG выглядят светлее или иначе, чем в PowerPoint. Вы можете использовать метод [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) класса [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) для выбора способа рендеринга градиентов.

Скачайте [gradient-styles.pptx](gradient-styles.pptx) и поместите его в рабочий каталог приложения. Его первый слайд содержит два линейных градиента: от бирюзового к оранжевому вверху и от синего к жёлтому внизу. Каждый градиент имеет две остановки — на 0 % и 100 %.

Следующий пример загружает эту презентацию и рендерит один и тот же первый слайд в обоих режимах с помощью [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

| Default | PowerPointUI |
| --- | --- |
| ![Градиенты от бирюзового к оранжевому и от синего к жёлтому, отрендеренные с Default](gradient-Default.png) | ![Те же градиенты, отрендеренные с PowerPointUI](gradient-PowerPointUI.png) |

В этом примере `Default` генерирует более светлые промежуточные цвета, тогда как `PowerPointUI` генерирует более тёмные промежуточные цвета. Разница зависит от цветов и остановок в градиенте.

Выберите `Default`, когда стандартный вывод Aspose.Slides соответствует вашим требованиям. Попробуйте `PowerPointUI`, если вашей приоритет — соответствовать внешнему виду в PowerPoint. Сравните оба результата с желаемым результатом; ни один режим не является универсально предпочтительным.

## **Часто задаваемые вопросы**

**Как я могу экспортировать конкретную форму, например диаграмму или изображение, вместо всего слайда?**

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/cpp/shape-thumbnails/), позволяя отрисовать форму в виде изображения PNG.

**Поддерживается ли параллельное конвертирование на сервере?**

Да. Используйте отдельный экземпляр презентации для каждого потока или процесса; [не делитесь одним экземпляром между потоками](/slides/ru/cpp/multithreading/).

**Каковы ограничения оценки при экспорте в PNG?**

В режиме оценки к выходным изображениям добавляется водяной знак и применяются [другие ограничения](/slides/ru/cpp/licensing/), пока лицензия не будет активирована.