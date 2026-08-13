---
title: Преобразование PPT и PPTX в JPG на C++
linktitle: PowerPoint в JPG
type: docs
weight: 60
url: /ru/cpp/convert-powerpoint-to-jpg/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в JPG
- презентация в JPG
- слайд в JPG
- PPT в JPG
- PPTX в JPG
- сохранить PowerPoint как JPG
- сохранить презентацию как JPG
- сохранить слайд как JPG
- сохранить PPT как JPG
- сохранить PPTX как JPG
- экспортировать PPT в JPG
- экспортировать PPTX в JPG
- C++
- Aspose.Slides
description: "Преобразуйте слайды PowerPoint (PPT, PPTX) в изображения JPG высокого качества на C++ с помощью Aspose.Slides, используя быстрые и надёжные примеры кода."
---
## **Введение**

Преобразование презентаций PowerPoint и OpenDocument в изображения JPG упрощает совместное использование слайдов, оптимизацию производительности и встраивание контента в веб‑сайты или приложения. Aspose.Slides for C++ позволяет преобразовать файлы PPTX, PPT и ODP в изображения JPEG высокого качества. В этом руководстве объясняются различные методы конвертации.

Благодаря этим возможностям легко реализовать собственный просмотрщик презентаций и создавать миниатюру для каждого слайда. Это может быть полезно, если нужно защитить слайды от копирования или демонстрировать презентацию в режиме только для чтения. Aspose.Slides позволяет конвертировать всю презентацию или отдельный слайд в графические форматы.

## **Преобразование слайдов презентации в изображения JPG**

Ниже перечислены шаги для преобразования файла PPT, PPTX или ODP в JPG:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите объект слайда типа [ISlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/) из коллекции слайдов презентации.
3. Создайте изображение слайда с помощью метода [ISlide.GetImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/getimage/).
4. Вызовите метод [IImage.Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/save/) у объекта изображения. Передайте имя выходного файла и формат изображения в качестве аргументов.

{{% alert color="info" %}} 
**Примечание:** Конвертация PPT, PPTX или ODP в JPG отличается от конвертации в другие форматы в API Aspose.Slides for C++. Для других форматов обычно используется метод [IPresentation.Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/save/). Однако для конвертации в JPG необходимо использовать метод [IImage.Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/save/).
{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Создайте изображение слайда с указанным масштабом.
    auto image = slide->GetImage(scaleX, scaleY);

    // Сохраните изображение на диск в формате JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Преобразование слайдов в JPG с заданными размерами**

Чтобы изменить размеры получаемых JPG‑изображений, можно задать размер изображения, передав его в метод [ISlide.GetImage(Size)](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). Это позволяет генерировать изображения с конкретной шириной и высотой, обеспечивая соответствие требуемому разрешению и соотношению сторон. Такая гибкость особенно полезна при создании изображений для веб‑приложений, отчетов или документации, где требуются точные размеры изображения.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Создайте изображение слайда заданного размера.
    auto image = slide->GetImage(imageSize);

    // Сохраните изображение на диск в формате JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Отображение комментариев при сохранении слайдов как изображений**

Aspose.Slides for C++ предоставляет возможность отрисовывать комментарии на слайдах презентации при их преобразовании в JPG‑изображения. Эта функция особенно полезна для сохранения аннотаций, отзывов или обсуждений, добавленных сотрудниками в презентациях PowerPoint. Включив эту опцию, вы гарантируете, что комментарии будут видны на созданных изображениях, что упрощает их просмотр и обмен обратной связью без необходимости открывать исходный файл презентации.

Предположим, у нас есть файл презентации «sample.pptx» со слайдом, содержащим комментарии:

![Слайд с комментариями](slide_with_comments.png)

Следующий код C++ преобразует слайд в JPG‑изображение с сохранением комментариев:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Установить параметры для комментариев слайда.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Преобразовать первый слайд в изображение.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

Результат:

![JPG‑изображение с комментариями](image_with_comments.png)

## **См. также**

Смотрите другие варианты конвертации PPT, PPTX или ODP в изображения, такие как:

- [Преобразование PowerPoint в GIF](/slides/ru/cpp/convert-powerpoint-to-animated-gif/)
- [Преобразование PowerPoint в PNG](/slides/ru/cpp/convert-powerpoint-to-png/)
- [Преобразование PowerPoint в TIFF](/slides/ru/cpp/convert-powerpoint-to-tiff/)
- [Преобразование PowerPoint в SVG](/slides/ru/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
Чтобы увидеть, как Aspose.Slides конвертирует PowerPoint в JPG‑изображения, попробуйте эти бесплатные онлайн‑конвертеры: PowerPoint [PPTX в JPG](https://products.aspose.app/slides/ru/conversion/pptx-to-jpg) и [PPT в JPG](https://products.aspose.app/slides/ru/conversion/ppt-to-jpg). 
{{% /alert %}}

![Бесплатный онлайн‑конвертер PPTX в JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}
Aspose предоставляет [БЕСПЛАТНОЕ веб‑приложение Collage](https://products.aspose.app/slides/ru/collage). С помощью этого онлайн‑сервиса вы можете объединять [JPG в JPG](https://products.aspose.app/slides/ru/collage/jpg) или PNG в PNG, создавать [фото‑коллажи](https://products.aspose.app/slides/ru/collage/photo-grid) и т. д.

Используя те же принципы, описанные в этой статье, вы можете конвертировать изображения из одного формата в другой. Дополнительную информацию см. на этих страницах: конвертация [изображения в JPG](https://products.aspose.com/slides/ru/cpp/conversion/image-to-jpg/); конвертация [JPG в изображение](https://products.aspose.com/slides/ru/cpp/conversion/jpg-to-image/); конвертация [JPG в PNG](https://products.aspose.com/slides/ru/cpp/conversion/jpg-to-png/), конвертация [PNG в JPG](https://products.aspose.com/slides/ru/cpp/conversion/png-to-jpg/); конвертация [PNG в SVG](https://products.aspose.com/slides/ru/cpp/conversion/png-to-svg/), конвертация [SVG в PNG](https://products.aspose.com/slides/ru/cpp/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

### Поддерживает ли этот метод пакетную конвертацию?

Да, Aspose.Slides позволяет выполнять пакетную конвертацию нескольких слайдов в JPG за одну операцию.

### Поддерживает ли конвертация SmartArt, диаграммы и другие сложные объекты?

Да, Aspose.Slides отрисовывает всё содержимое, включая SmartArt, диаграммы, таблицы, фигуры и прочее. Однако точность рендеринга может немного отличаться от PowerPoint, особенно при использовании пользовательских или отсутствующих шрифтов.

### Есть ли ограничения на количество слайдов, которые можно обработать?

Сам Aspose.Slides не накладывает строгих ограничений на количество обрабатываемых слайдов. Однако при работе с большими презентациями или изображениями высокого разрешения может возникнуть ошибка «недостаточно памяти».