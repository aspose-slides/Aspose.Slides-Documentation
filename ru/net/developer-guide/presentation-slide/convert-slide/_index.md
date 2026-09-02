---
title: Конвертировать слайды презентации в изображения в .NET
linktitle: Слайд в изображение
type: docs
weight: 41
url: /ru/net/convert-slide/
keywords:
- конвертировать слайд
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
- .NET
- C#
- Aspose.Slides
description: "Преобразуйте слайды из презентаций PPT, PPTX и ODP в форматы PNG, JPEG, GIF, TIFF, EMF и другие графические форматы на C# с помощью Aspose.Slides для .NET."
---
## **Введение**

Aspose.Slides for .NET может отображать отдельные слайды из презентаций PowerPoint и OpenDocument в форматах PNG, JPEG, GIF, TIFF и других графических форматов.

Чтобы преобразовать слайд в изображение, выполните следующие шаги:

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
2. Выберите слайд, который вы хотите отобразить.
3. При необходимости настройте рендеринг с помощью класса [RenderingOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/renderingoptions/) или [TiffOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/tiffoptions/).
4. Вызовите метод [GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/getimage/). Он возвращает объект [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/).
5. Вызовите метод [IImage.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/save/) и укажите формат вывода значением [ImageFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/imageformat/).

## **Преобразовать слайд в PNG‑изображение**

Самое простое преобразование использует настройки рендеринга по умолчанию. Полученный объект [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) можно обработать в памяти или сохранить в файл.

Следующий пример на C# отображает первый слайд и сохраняет его как PNG‑изображение:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Преобразовать слайды в изображения с пользовательскими размерами**

Используйте перегрузку [GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/getimage/), которая принимает значение [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) для рендеринга слайда с точными пиксельными размерами.

Следующий пример создает JPEG‑изображение размером 1820 × 1040:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Преобразовать слайды с приметками и комментариями в изображения**

По умолчанию изображения слайдов не включают приметки или комментарии. Присвойте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/notescommentslayoutingoptions/) свойству [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/renderingoptions/slideslayoutoptions/), чтобы контролировать размещение приметок и комментариев.

Следующий пример помещает усечённые приметки под слайдом, а комментарии — справа от него:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
Для преобразования слайдов в изображения не устанавливайте свойство [NotesPosition](https://reference.aspose.com/slides/ru/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) в значение [BottomFull](https://reference.aspose.com/slides/ru/net/aspose.slides.export/notespositions/). Примечания могут содержать больше текста, чем позволяет фиксированный размер изображения. Используйте вместо этого [BottomTruncated](https://reference.aspose.com/slides/ru/net/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Преобразовать слайды в изображения с использованием параметров TIFF**

Класс [TiffOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/tiffoptions/) позволяет управлять размером, разрешением и другими свойствами генерируемого TIFF‑изображения.

Следующий пример отображает первый слайд как TIFF‑изображение размером 2160 × 2880 при 300 DPI:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **Преобразовать все слайды в изображения**

Пройдите по коллекции слайдов, чтобы преобразовать всю презентацию в набор изображений. Скрытые слайды включаются, если явно не пропустить их.

Следующий пример отображает каждый слайд как JPEG‑изображение с горизонтальными и вертикальными коэффициентами масштабирования, равными 2:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **Создать вывод в формате Enhanced Metafile**

Enhanced Metafile (EMF) полезен, когда векторная графика должна быть передана в Microsoft Office или другие Windows‑приложения, поддерживающие Windows‑метафайлы. В отличие от растрового изображения, EMF сохраняет векторные операции рисования, которые масштабируются без потери резкости. Однако EMF в основном является форматом совместимости для приложений с поддержкой Windows‑метафайлов, а не универсальным форматом обмена. Кроме того, сложное содержимое слайда, такое как растровые изображения и некоторые эффекты, может храниться в виде растровых элементов внутри векторного контейнера метафайла.

### **Экспортировать слайд в EMF**

Метод [ISlide.WriteAsEmf](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/writeasemf/) записывает объект [ISlide](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/) в целевой поток в формате EMF. Следующий пример загружает презентацию, выбирает первый слайд и записывает его в поток файла EMF:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

Вызывающий код владеет потоком, переданным в [ISlide.WriteAsEmf](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/writeasemf/), и должен закрыть или освободить его. Aspose.Slides записывает в текущую позицию потока и оставляет поток открытым.

### **Преобразовать SVG‑изображение в EMF и добавить его в презентацию**

Используйте [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage/writeasemf/) для преобразования SVG‑содержимого в EMF. Полученные байты можно добавить в презентацию через [IImageCollection.AddImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimagecollection/addimage/) и разместить на слайде с помощью [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addpictureframe/).

Следующий пример создаёт объект [SvgImage](https://reference.aspose.com/slides/ru/net/aspose.slides/svgimage/) из SVG‑разметки, преобразует его во временный EMF, вставляет метафайл на первый слайд и сохраняет презентацию:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage/writeasemf/) не принимает владение целевым потоком. После записи позиция потока находится в конце сгенерированных данных. Сбросьте `Position` в начало перед передачей того же потокового объекта читателю, как показано выше. Оставляйте поток открытым, пока потребитель не завершит чтение, а затем освобождайте его. Альтернативно, вызовите `ToArray` и передайте полученный массив байтов в [IImageCollection.AddImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimagecollection/addimage/); `ToArray` возвращает полный буфер независимо от текущей позиции потока.

Генерация EMF доступна на операционных системах, поддерживаемых выбранной сборкой Aspose.Slides for .NET, однако рендеринг может различаться на разных платформах, если шрифты или нативные графические зависимости недоступны. Установите шрифты, используемые в исходном содержимом, или настройте соответствующие подстановки, соблюдайте [требования к платформе](/slides/ru/net/system-requirements/) для вашего пакета Aspose.Slides и проверьте результат в целевом приложении, потребляющем EMF. Приложения для Linux и macOS часто имеют ограниченную или непоследовательную поддержку отображения и редактирования Windows‑метафайлов.

## **Отображение цветных эмодзи**

{{% alert title="Note" color="info" %}}
Чтобы правильно отобразить цветные эмодзи при преобразовании слайдов презентации в изображения, шрифты эмодзи, использованные в презентации, должны быть установлены и доступны системе, выполняющей преобразование. Например, если презентация использует **Segoe UI Emoji**, а этот шрифт отсутствует, эмодзи могут отображаться монохромно в итоговых изображениях.
{{% /alert %}}

## **FAQ**

**Поддерживает ли Aspose.Slides отображение слайдов с анимациями?**

Нет. Метод [GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/getimage/) создаёт статическое изображение слайда и не экспортирует анимацию.

**Можно ли экспортировать скрытые слайды в виде изображений?**

Да. Скрытые слайды могут быть отрисованы так же, как обычные. Включите их в цикл обработки, как показано в примере выше.

**Сохраняются ли тени и другие эффекты на изображениях слайдов?**

Да. Aspose.Slides сохраняет тени, прозрачность и другие поддерживаемые графические эффекты в изображениях слайдов.