---
title: Конвертировать слайды презентации в изображения на C++
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
- слайд в bitmap
- слайд в TIFF
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Конвертировать слайды из PPT, PPTX и ODP в изображения на C++ с помощью Aspose.Slides — быстрое, высококачественное рендеринг с понятными примерами кода."
---

## **Обзор**

Aspose.Slides for C++ позволяет легко преобразовывать слайды презентаций PowerPoint и OpenDocument в различные форматы изображений, включая BMP, PNG, JPG (JPEG), GIF и другие.

Чтобы преобразовать слайд в изображение, выполните следующие действия:

1. Определите желаемые параметры преобразования и выберите слайды, которые хотите экспортировать, используя:
    - интерфейс [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/), или
    - интерфейс [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/).
2. Сгенерируйте изображение слайда, вызвав метод [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

[Bitmap](https://reference.aspose.com/slides/cpp/system.drawing/bitmap/) — объект, позволяющий работать с изображениями, определяемыми данными пикселей. Вы можете использовать экземпляр этого класса для сохранения изображений в широком диапазоне форматов (BMP, JPG, PNG и т.д.).

## **Преобразование слайдов в Bitmap и сохранение изображений в PNG**

Вы можете преобразовать слайд в объект bitmap и использовать его напрямую в приложении. Кроме того, можно преобразовать слайд в bitmap, а затем сохранить изображение в JPEG или любом другом предпочтительном формате.

Следующий код C++ демонстрирует, как преобразовать первый слайд презентации в объект bitmap и затем сохранить изображение в формате PNG:
```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide in the presentation to a bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Save the image in the PNG format.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```


## **Преобразование слайдов в изображения с пользовательскими размерами**

Возможно, вам понадобится получить изображение определённого размера. Используя перегрузку метода [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/), вы можете преобразовать слайд в изображение с конкретными шириной и высотой.

Этот пример кода демонстрирует, как это сделать:
```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Преобразовать первый слайд презентации в bitmap с указанным размером.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Сохранить изображение в формате JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```


## **Преобразование слайдов с заметками и комментариями в изображения**

Некоторые слайды могут содержать заметки и комментарии.

Aspose.Slides предоставляет два интерфейса — [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) и [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/) — которые позволяют контролировать рендеринг слайдов презентации в изображения. Оба интерфейса включают метод `set_SlidesLayoutOptions`, который позволяет настроить рендеринг заметок и комментариев на слайде при его преобразовании в изображение.

С помощью класса [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) вы можете указать предпочтительное расположение заметок и комментариев в получаемом изображении.

Этот код C++ демонстрирует, как преобразовать слайд с заметками и комментариями:
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


{{% alert title="Note" color="warning" %}} 

В любом процессе преобразования слайдов в изображения метод [set_NotesPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) не может применить `BottomFull` (чтобы указать позицию для заметок), поскольку текст заметки может быть слишком большим, и он не помещается в указанный размер изображения.

{{% /alert %}} 

## **Преобразование слайдов в изображения с использованием TIFF‑опций**

Интерфейс [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) предоставляет более тонкий контроль над результирующим TIFF‑изображением, позволяя задавать такие параметры, как размер, разрешение, цветовая палитра и другие.

Этот код C++ демонстрирует процесс преобразования, где TIFF‑опции используются для вывода черно‑белого изображения с разрешением 300 DPI и размером 2160 × 2800:
```cpp 
// Загрузить файл презентации.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Получить первый слайд из презентации.
auto slide = presentation->get_Slide(0);

// Настроить параметры выходного TIFF-изображения.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Установить размер изображения.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Установить формат пикселей (чёрно-белый).
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

Aspose.Slides позволяет преобразовать все слайды презентации в изображения, фактически превращая всю презентацию в серию изображений.

Этот пример кода демонстрирует, как преобразовать все слайды презентации в изображения в C++:
```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Рендерить презентацию в изображения слайд за слайдом.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Управление скрытыми слайдами (не рендерить скрытые слайды).
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


## **FAQ**

**Поддерживает ли Aspose.Slides рендеринг слайдов с анимацией?**

Нет, метод `GetImage` сохраняет только статическое изображение слайда без анимаций.

**Можно ли экспортировать скрытые слайды в виде изображений?**

Да, скрытые слайды могут обрабатываться так же, как обычные. Просто убедитесь, что они включены в цикл обработки.

**Можно ли сохранять изображения с тенями и эффектами?**

Да, Aspose.Slides поддерживает рендеринг теней, прозрачности и других графических эффектов при сохранении слайдов в виде изображений.