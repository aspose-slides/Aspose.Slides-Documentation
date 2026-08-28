---
title: Преобразование слайдов презентаций в изображения на C++
linktitle: Слайд в изображение
type: docs
weight: 41
url: /ru/cpp/convert-slide/
keywords:
- преобразовать слайд
- экспортировать слайд
- слайд в изображение
- сохранить слайд как изображение
- слайд в EMF
- слайд в PNG
- слайд в JPEG
- слайд в bitmap
- слайд в TIFF
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Преобразуйте слайды из презентаций PPT, PPTX и ODP в PNG, JPEG, GIF, TIFF, EMF и другие форматы изображений на C++ с помощью Aspose.Slides для C++."
---
## **Введение**

Aspose.Slides for C++ может рендерить отдельные слайды из презентаций PowerPoint и OpenDocument в форматах PNG, JPEG, GIF, TIFF и других форматов изображений.

Чтобы преобразовать слайд в изображение, выполните следующие шаги:

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Выберите слайд, который нужно отрендерить.
3. При необходимости настройте рендеринг с помощью класса [RenderingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/renderingoptions/) или [TiffOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/).
4. Вызовите метод [ISlide::GetImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/getimage/). Он возвращает объект [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/).
5. Вызовите метод [IImage::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/save/) и укажите формат вывода с помощью значения [ImageFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imageformat/).

## **Преобразование слайда в PNG-изображение**

Самый простой способ использует настройки рендеринга по умолчанию. Полученный объект [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/) можно обработать в памяти или сохранить в файл.

В следующем примере C++ первый слайд рендерится и сохраняется как PNG-изображение:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Преобразование слайдов в изображения с пользовательскими размерами**

Используйте перегрузку [ISlide::GetImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/getimage/), которая принимает значение [Size](https://reference.aspose.com/slides/ru/cpp/system.drawing/size/), чтобы отрендерить слайд с точными пиксельными размерами.

В следующем примере создаётся JPEG‑изображение размером 1820 × 1040:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Преобразование слайдов с заметками и комментариями в изображения**

По умолчанию изображения слайдов не включают заметки или комментарии. Присвойте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/notescommentslayoutingoptions/) методу [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/), чтобы управлять размещением заметок и комментариев.

В следующем примере усечённые заметки размещаются под слайдом, а комментарии — справа от него:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
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

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
Для преобразования слайдов в изображения не устанавливайте метод [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) в значение [BottomFull](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/notespositions/). Заметки могут содержать больше текста, чем может вместить фиксированный размер изображения. Вместо этого используйте [BottomTruncated](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Преобразование слайдов в изображения с использованием TIFF‑опций**

Класс [TiffOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/) позволяет управлять размером, разрешением и другими свойствами отрендеренного TIFF‑изображения.

В следующем примере первый слайд рендерится как TIFF‑изображение размером 2160 × 2880 с разрешением 300 DPI:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Преобразование всех слайдов в изображения**

Итерируйте коллекцию слайдов, чтобы преобразовать всю презентацию в последовательность изображений. Скрытые слайды включаются, если вы явно не пропустите их.

В следующем примере каждый слайд рендерится как JPEG‑изображение с горизонтальными и вертикальными коэффициентами масштабирования, равными 2:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Создание вывода в формате Enhanced Metafile**

Enhanced Metafile (EMF) полезен, когда необходимо обмениваться векторной графикой с Microsoft Office или другими Windows‑приложениями, поддерживающими Windows‑метафайлы. В отличие от растрового изображения, EMF может сохранять векторные операции рисования, которые масштабируются без потери чёткости. Однако EMF в основном является форматом совместимости для приложений с поддержкой Windows‑метафайлов, а не универсальным форматом обмена. Кроме того, сложное содержимое слайда, такое как растровые изображения и некоторые эффекты, может храниться в виде растровых элементов внутри контейнера векторного метафайла.

### **Экспорт слайда в EMF**

Метод [ISlide::WriteAsEmf](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/writeasemf/) записывает объект [ISlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/) в целевой поток в формате EMF. В следующем примере загружается презентация, выбирается первый слайд и записывается в поток EMF‑файла:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

Вызывающая сторона владеет потоком, переданным в [ISlide::WriteAsEmf](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/writeasemf/), и должна закрыть или освободить его. Aspose.Slides пишет в текущую позицию потока и оставляет его открытым.

### **Преобразование SVG‑изображения в EMF и добавление его в презентацию**

Используйте [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isvgimage/writeasemf/) для преобразования SVG‑контента в EMF. Полученные байты можно добавить в презентацию через [IImageCollection::AddImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimagecollection/addimage/) и разместить на слайде с помощью [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/addpictureframe/).

В следующем примере создаётся объект [SvgImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/svgimage/) из SVG‑разметки, преобразуется в EMF в памяти, вставляется в первый слайд и сохраняется презентация:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isvgimage/writeasemf/) не принимает владение над целевым потоком. После записи позиция потока находится в конце сгенерированных данных. В примере вызывается [MemoryStream::ToArray](https://reference.aspose.com/slides/ru/cpp/system.io/memorystream/toarray/) для получения полного буфера независимо от текущей позиции потока, затем этот массив байтов передаётся в [IImageCollection::AddImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimagecollection/addimage/). Оставляйте поток открытым, пока потребитель не завершит чтение, и закрывайте его после этого.

Генерация EMF доступна на операционных системах, поддерживаемых Aspose.Slides для C++, но рендеринг может различаться между платформами при отсутствии шрифтов или нативных графических зависимостей. Установите шрифты, используемые исходным содержимым, или настройте соответствующие замены, следуйте [требованиям к платформе](/slides/ru/cpp/system-requirements/) для Aspose.Slides для C++ и проверьте результат в целевом приложении, потребляющем EMF. Приложения для Linux и macOS часто имеют ограниченную или непоследовательную поддержку отображения и редактирования Windows‑метафайлов.

## **Отображение цветных эмодзи**

{{% alert title="Note" color="info" %}}
Чтобы правильно отобразить цветные эмодзи при преобразовании слайдов презентации в изображения, шрифты эмодзи, используемые в презентации, должны быть установлены и доступны в системе, выполняющей конвертацию. Например, если презентация использует **Segoe UI Emoji** и этот шрифт отсутствует, эмодзи могут отображаться монохромно в результирующих изображениях.
{{% /alert %}}

## **FAQ**

**Поддерживает ли Aspose.Slides рендеринг слайдов с анимациями?**

Нет. Метод [ISlide::GetImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/getimage/) рендерит статическое изображение слайда и не экспортирует анимации.

**Можно ли экспортировать скрытые слайды как изображения?**

Да. Скрытые слайды можно рендерить так же, как обычные. Включайте их в цикл обработки, как показано в примере выше.

**Сохраняются ли тени и другие эффекты на изображениях слайдов?**

Да. Aspose.Slides рендерит тени, прозрачность и другие поддерживаемые графические эффекты на изображениях слайдов.