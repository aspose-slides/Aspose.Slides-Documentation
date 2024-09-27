---
title: Конвертация слайда
type: docs
weight: 41
url: /ru/cpp/convert-slide/
keywords: "Конвертация слайда в изображение, экспорт слайда как изображение, сохранение слайда как изображение, слайд в изображение, слайд в PNG, слайд в JPEG, слайд в Bitmap, C++, Aspose.Slides"
description: "Конвертация слайда PowerPoint в изображение (Bitmap, PNG или JPG) на C++"
---

Aspose.Slides для C++ позволяет вам конвертировать слайды (в презентациях) в изображения. Поддерживаемые форматы изображений: BMP, PNG, JPG (JPEG), GIF и другие.

Чтобы конвертировать слайд в изображение, выполните следующие действия:

1. Сначала конвертируйте слайд в Bitmap, используя метод [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/)
2. Затем установите дополнительные параметры для конвертации и конвертируемых объектов слайда через
   * интерфейс [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) или
   * интерфейс [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options).

## **О Bitmap и других форматах изображений**

[Bitmap](https://reference.aspose.com/slides/cpp/class/system.drawing.bitmap) — это объект, который позволяет работать с изображениями, определяемыми данными пикселей. Вы можете использовать экземпляр этого класса для сохранения изображений в широком диапазоне форматов (BMP, JPG, PNG и др.).

{{% alert title="Информация" color="info" %}}

Aspose недавно разработал онлайн-конвертер [Text to GIF](https://products.aspose.app/slides/text-to-gif).

{{% /alert %}}

## **Конвертация слайдов в Bitmap и сохранение изображений в PNG**

Этот код на C++ показывает, как конвертировать первый слайд презентации в объект bitmap, а затем сохранить изображение в формате PNG:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// Конвертируем первый слайд презентации в объект Bitmap
System::SharedPtr<IImage> image = pres->get_Slide(0)->GetImage();
                 
// Сохраняем изображение в формате PNG
image->Save(u"Slide_0.png", ImageFormat::Png);
```

{{% alert title="Совет" color="primary" %}} 

Вы можете конвертировать слайд в объект bitmap и затем использовать его непосредственно где-либо. Либо вы можете конвертировать слайд в bitmap и затем сохранить изображение в JPEG или любом другом предпочитаемом вами формате.

{{% /alert %}}  

## **Конвертация слайдов в изображения с пользовательскими размерами**

Вам может понадобиться получить изображение определенного размера. Используя перегрузку метода [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/), вы можете конвертировать слайд в изображение с заданными размерами (длиной и шириной).

Этот пример кода демонстрирует предложенную конвертацию, используя метод [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) на C++:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");
// Конвертируем первый слайд в презентации в Bitmap с указанным размером
auto image = pres->get_Slide(0)->GetImage(Size(1820, 1040));
// Сохраняем изображение в формате JPEG
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);
```

## **Конвертация слайдов с заметками и комментариями в изображения**

Некоторые слайды содержат заметки и комментарии.

Aspose.Slides предоставляет два интерфейса — [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) и [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options) — которые позволяют вам управлять рендерингом слайдов презентации в изображения. Оба интерфейса содержат интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options), который позволяет вам добавлять заметки и комментарии на слайд при конвертации этого слайда в изображение.

{{% alert title="Информация" color="info" %}} 

С помощью интерфейса [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) вы можете указать предпочитаемое положение для заметок и комментариев в результирующем изображении.

{{% /alert %}} 

Этот код на C++ демонстрирует процесс конвертации слайда с заметками и комментариями:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");
// Создаем параметры рендеринга
auto options = System::MakeObject<RenderingOptions>();
auto notesCommentsLayouting = options->get_NotesCommentsLayouting();
// Устанавливаем положение заметок на странице
notesCommentsLayouting->set_NotesPosition(NotesPositions::BottomTruncated);
// Устанавливаем положение комментариев на странице 
notesCommentsLayouting->set_CommentsPosition(CommentsPositions::Right);
// Устанавливаем ширину области вывода комментариев
notesCommentsLayouting->set_CommentsAreaWidth(500);
// Устанавливаем цвет области комментариев
notesCommentsLayouting->set_CommentsAreaColor(Color::get_AntiqueWhite());

// Конвертируем первый слайд презентации в объект Bitmap
auto image = pres->get_Slide(0)->GetImage(options, 2.f, 2.f);

// Сохраняем изображение в формате GIF
image->Save(u"Slide_Notes_Comments_0.gif", ImageFormat::Gif);
```

{{% alert title="Примечание" color="warning" %}} 

В процессе конвертации любого слайда в изображение вы не можете передать значение BottomFull (чтобы указать положение для заметок) методу [set_NotesPositions()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options), поскольку текст заметки может быть большим, и он может не поместиться в заданный размер изображения.

{{% /alert %}} 

## **Конвертация слайдов в изображения с использованием ITiffOptions**

Интерфейс [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) дает вам больше контроля (в терминах параметров) над результирующим изображением. С помощью этого интерфейса вы можете указать размер, разрешение, цветовую палитру и другие параметры для результирующего изображения.

Этот код на C++ демонстрирует процесс конвертации, где используется ITiffOptions для вывода черно-белого изображения с разрешением 300 dpi и размером 2160 × 2800:

``` cpp 
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");

// Получаем слайд по его индексу
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Создаем объект TiffOptions
System::SharedPtr<TiffOptions> options = System::MakeObject<TiffOptions>();
options->set_ImageSize(Size(2160, 2880));

// Устанавливаем шрифт, используемый в случае отсутствия исходного шрифта
options->set_DefaultRegularFont(u"Arial Black");

// Устанавливаем положение заметок на странице 
options->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomTruncated);

// Устанавливаем формат пикселей (черно-белый)
options->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);

// Устанавливаем разрешение
options->set_DpiX(300);
options->set_DpiY(300);

// Конвертируем слайд в объект Bitmap
System::SharedPtr<Bitmap> image = slide->GetImage(options);

// Сохраняем изображение в формате BMP
image->Save(u"PresentationNotesComments.bmp", ImageFormat::Tiff);
```

## **Конвертация всех слайдов в изображения**

Aspose.Slides позволяет вам конвертировать все слайды в одной презентации в изображения. По сути, вы получаете возможность конвертировать презентацию (целиком) в изображения.

Этот пример кода показывает, как конвертировать все слайды в презентации в изображения на C++:

``` cpp 
// Путь к выходному каталогу
System::String outputDir = u"D:\\PresentationImages";

auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// Рендеринг презентации в массив изображений слайда за слайдом
for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
{
    // Контроль скрытых слайдов (не рендерить скрытые слайды)
    if (pres->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Конвертируем слайд в объект Bitmap
    auto image = pres->get_Slide(i)->GetImage(2.f, 2.f);

    // Создаем имя файла для изображения
    auto outputFilePath = Path::Combine(outputDir, String(u"Slide_") + i + u".jpg");

    // Сохраняем изображение в формате PNG
    image->Save(outputFilePath, ImageFormat::Png);
}
```