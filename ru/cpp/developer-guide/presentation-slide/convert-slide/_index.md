---
title: Перавображение слайдов презентации в изображения на C++
linktitle: Слайд в изображение
type: docs
weight: 41
url: /ru/cpp/convert-slide/
keywords: 
- конвертировать слайд
- экспортировать слайд
- слайд в изображение
- сохранить слайд как изображение
- слайд в PNG
- слайд в JPEG
- слайд в битмап
- слайд в TIFF
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Преобразование слайдов из PPT, PPTX и ODP в изображения на C++ с помощью Aspose.Slides — быстрое, высококачественное рендеринг с понятными примерами кода."
---
## **Введение**

Aspose.Slides для C++ позволяет легко преобразовывать слайды презентаций PowerPoint и OpenDocument в различные форматы изображений, включая BMP, PNG, JPG (JPEG), GIF и другие.

Чтобы преобразовать слайд в изображение, выполните следующие действия:

1. Определите нужные параметры конвертации и выберите слайды, которые хотите экспортировать, используя:
    - Интерфейс [ITiffOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/itiffoptions/), или
    - Интерфейс [IRenderingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/irenderingoptions/).
2. Сгенерируйте изображение слайда, вызвав метод [GetImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/getimage/).

[Bitmap](https://reference.aspose.com/slides/ru/cpp/system.drawing/bitmap/) — это объект, позволяющий работать с изображениями, определяемыми пиксельными данными. Экземпляр этого класса можно использовать для сохранения изображений в широком спектре форматов (BMP, JPG, PNG и т.д.).

## **Преобразование слайдов в битмапы и сохранение изображений в формате PNG**

Вы можете конвертировать слайд в объект Bitmap и использовать его непосредственно в приложении. Кроме того, можно конвертировать слайд в Bitmap, а затем сохранить изображение в JPEG или любом другом предпочтительном формате.

Этот код на C++ демонстрирует, как преобразовать первый слайд презентации в объект Bitmap и затем сохранить изображение в формате PNG:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Преобразовать первый слайд презентации в битмап.
auto image = presentation->get_Slide(0)->GetImage();

// Сохранить изображение в формате PNG.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Преобразование слайдов в изображения с пользовательскими размерами**

Возможно, вам понадобится изображение определённого размера. Используя перегрузку метода [GetImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/getimage/), можно преобразовать слайд в изображение с конкретными параметрами ширины и высоты. 

Этот пример кода демонстрирует, как это сделать:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Преобразовать первый слайд презентации в битмап с указанным размером.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Сохранить изображение в формате JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Преобразование слайдов с заметками и комментариями в изображения**

Некоторые слайды могут содержать заметки и комментарии.

Aspose.Slides предоставляет два интерфейса — [ITiffOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/itiffoptions/) и [IRenderingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/irenderingoptions/) — которые позволяют управлять рендерингом слайдов презентации в изображения. Оба интерфейса включают метод `set_SlidesLayoutOptions`, позволяющий настроить рендеринг заметок и комментариев на слайде при его конвертации в изображение.

С помощью класса [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/notescommentslayoutingoptions/) можно указать предпочтительное расположение заметок и комментариев в результирующем изображении.

Этот код на C++ демонстрирует, как конвертировать слайд с заметками и комментариями:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Загрузить файл презентации.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Установить положение заметок.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Установить положение комментариев.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Установить ширину области комментариев.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Установить цвет области комментариев.

// Создать параметры рендеринга.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Преобразовать первый слайд презентации в изображение.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Сохранить изображение в формате GIF.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Примечание" color="warning" %}} 
В процессе конвертации слайдов в изображения метод `set_NotesPosition` не может применить значение `BottomFull` (для указания положения заметок), поскольку текст заметки может быть слишком объёмным и не поместиться в заданный размер изображения.
{{% /alert %}} 

## **Преобразование слайдов в изображения с использованием опций TIFF**

Интерфейс [ITiffOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/itiffoptions/) предоставляет более тонкую настройку получаемого TIFF‑изображения, позволяя задавать такие параметры, как размер, разрешение, цветовая палитра и другие.

Этот код на C++ демонстрирует процесс конвертации, при котором опции TIFF используются для создания чёрно‑белого изображения с разрешением 300 DPI и размером 2160 × 2800:

```cpp 
// Загрузить файл презентации.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Получить первый слайд из презентации.
auto slide = presentation->get_Slide(0);

// Настроить параметры выходного TIFF‑изображения.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Установить размер изображения.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Установить формат пикселей (чёрно‑белый).
tiffOptions->set_DpiX(300);                                         // Установить горизонтальное разрешение.
tiffOptions->set_DpiY(300);                                         // Установить вертикальное разрешение.

// Преобразовать слайд в изображение с указанными параметрами.
auto image = slide->GetImage(tiffOptions);

// Сохранить изображение в формате TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Преобразование всех слайдов в изображения**

Aspose.Slides позволяет преобразовать все слайды презентации в изображения, фактически преобразуя всю презентацию в набор изображений.

Этот пример кода демонстрирует, как в C++ преобразовать все слайды презентации в изображения:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Отрисовать презентацию в изображения слайд за слайдом.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Обрабатывать скрытые слайды (не отрисовывать скрытые слайды).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Преобразовать слайд в изображение.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Сохранить изображение в формате JPEG.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Отрисовка цветных эмодзи**

{{% alert title="Примечание" color="warning" %}} 
Чтобы правильно отрисовывать цветные эмодзи при конвертации слайдов презентации в изображения, шрифты эмодзи, используемые в презентации, должны быть установлены и доступны на системе, выполняющей конвертацию. Например, если презентация использует **Segoe UI Emoji**, а этот шрифт отсутствует, эмодзи могут отображаться в монохроме на итоговых изображениях.
{{% /alert %}}

## **FAQ**

**Поддерживает ли Aspose.Slides рендеринг слайдов с анимацией?**

Нет, метод `GetImage` сохраняет только статическое изображение слайда без анимаций.

**Можно ли экспортировать скрытые слайды как изображения?**

Да, скрытые слайды можно обрабатывать так же, как обычные. Просто убедитесь, что они включены в цикл обработки.

**Можно ли сохранять изображения с тенями и эффектами?**

Да, Aspose.Slides поддерживает рендеринг теней, прозрачности и других графических эффектов при сохранении слайдов в виде изображений.