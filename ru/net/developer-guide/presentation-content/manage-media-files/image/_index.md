---
title: Оптимизация управления изображениями в презентациях на .NET
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/net/image/
keywords:
- добавить изображение
- добавить картинку
- заменить изображение
- коллекция изображений
- рамка изображения
- связанное изображение
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- SVG в фигуры
- внешние ресурсы SVG
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как добавлять, переиспользовать, связывать, заменять и управлять растровыми и SVG‑изображениями в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET."
---
## **Введение**

Aspose.Slides for .NET предоставляет несколько способов работы с изображениями, каждый из которых имеет своё назначение. Вы можете хранить изображение в презентации, отображать его в рамке изображения, использовать его в качестве фона слайда, ссылки на внешнее изображение, заменять общий ресурс изображения или преобразовывать SVG‑контент в редактируемые фигуры.

В этой статье рассматриваются ресурсы изображений и их использование в презентации. Для обрезки, прозрачности, эффектов, растягивания и другого форматирования, применяемого к отдельной рамке изображения, см. [Picture Frame](/slides/ru/net/picture-frame/).

## **Понимание модели изображений**

Следующие концепции API тесно связаны, но не являются взаимозаменяемыми:

- **[коллекция изображений презентации]**(https://reference.aspose.com/slides/ru/net/aspose.slides/iimagecollection/) хранит ресурсы изображений, используемые в презентации. Для добавления данных изображения и получения ресурса **[IPPImage]**(https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) используйте **[ImageCollection.AddImage]**(https://reference.aspose.com/slides/ru/net/aspose.slides/imagecollection/addimage/).
- **[рамка изображения]**(https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/) — это фигура, отображающая изображение на слайде, макете или образце. Для размещения ресурса изображения на слайде используйте **[IShapeCollection.AddPictureFrame]**(https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addpictureframe/).
- **фон слайда** использует изображение как часть заполнения слайда, а не как фигуру, поэтому он не ведёт себя как рамка изображения.
- **[IPPImage.ReplaceImage]**(https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/replaceimage/) заменяет ресурс изображения. Если несколько элементов презентации используют этот ресурс, они все используют замену.
- Преобразование SVG в фигуры создаёт редактируемые фигуры слайда. После преобразования контент более не управляется как один ресурс изображения.

Типичный порядок действий выглядит так: добавить данные изображения в коллекцию изображений, получить **[IPPImage]**, а затем использовать этот ресурс в одной или нескольких рамках изображения или заполнениях.

## **Добавление встроенного изображения**

Чтобы вставить локальное изображение, прочитайте файл, добавьте его данные в коллекцию изображений и создайте рамку изображения, использующую возвращённый `IPPImage`.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Изображение, добавленное таким способом, встраивается в презентацию, поэтому полученный файл не зависит от доступности исходного файла изображения.

### **Добавление изображения из интернета**

Если изображение доступно по HTTP или HTTPS, загрузите его байты с помощью `HttpClient`, добавьте их в коллекцию изображений презентации и используйте возвращённый ресурс изображения так же, как локальное изображение.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

В долгоживущих приложениях переиспользуйте `HttpClient`, а не создавайте новый экземпляр для каждого запроса. Также проверяйте удалённые URL, размеры ответов и типы содержимого, если источник не доверенный.

## **Повторное использование изображений на разных слайдах**

Если одно и то же изображение требуется более одного раза, добавьте его в презентацию один раз и переиспользуйте полученный **[IPPImage]** при создании дополнительных рамок изображения. Это избавляет от повторной загрузки одних и тех же исходных данных и делает явными отношения между общим ресурсом изображения и его использованием.

Для графики, которой нужно автоматически отображаться на многих слайдах (например, логотип компании), рассмотрите возможность размещения рамки изображения на **[slide master]**(/slides/ru/net/slide-master/) или макете вместо добавления эквивалентной фигуры на каждый слайд.

## **Использование изображения в качестве фона слайда**

Фоновое изображение назначается заполнению слайда; оно не добавляется как фигура‑рамка. Это удобно, когда изображение должно покрывать весь фон слайда и не должно манипулироваться как обычный объект слайда.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

Для дополнительных вариантов фонового оформления, включая фон образцов и макетов, см. [Presentation Background](/slides/ru/net/presentation-background/).

## **Встроенные и связанные изображения**

Встроенные и связанные изображения имеют разные компромиссы по переносимости и размеру файла:

- **Встроенное изображение:** данные изображения хранятся внутри презентации. Презентация самодостаточна, но размер файла включает данные изображения.
- **Связанное изображение:** презентация хранит путь или URL к внешнему изображению. Это может уменьшить размер презентации, но внешний ресурс должен оставаться доступным при открытии или рендеринге презентации.

Связанную картинку можно создать, присвоив внешний путь или URL через **[ISlidesPicture.LinkPathLong]**(https://reference.aspose.com/slides/ru/net/aspose.slides/islidespicture/linkpathlong/), вместо встраивания данных изображения.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Используйте связанные изображения только тогда, когда среда развертывания может надёжно получать внешний ресурс. Для презентаций, которые должны работать офлайн или перемещаться между системами, встроенные изображения обычно безопаснее.

## **Работа с SVG‑изображениями**

SVG — векторный формат, поэтому он полезен для значков, схем и другой графики, которой требуется масштабирование без потери деталей, характерных для растровых изображений. Aspose.Slides поддерживает SVG как ресурс изображения и как источник редактируемых фигур слайда.

### **Добавление SVG в качестве изображения**

Создайте **[SvgImage]**(https://reference.aspose.com/slides/ru/net/aspose.slides/svgimage/), добавьте её в коллекцию изображений и разместите полученный ресурс изображения в рамке изображения.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **SVG‑файлы с внешними ресурсами**

SVG может ссылаться на внешние изображения, таблицы стилей или шрифты. Для таких случаев **[SvgImage]** предоставляет конструкторы, принимающие **[IExternalResourceResolver]**(https://reference.aspose.com/slides/ru/net/aspose.slides.import/iexternalresourceresolver/) и базовый URI. Разрешитель может сопоставлять относительный URI с допустимым абсолютным URI и возвращать поток для запрошенного ресурса.

Разрешитель делает внешние ресурсы доступными во время обработки SVG Aspose.Slides, но не переписывает SVG в автономный документ. Если SVG должен оставаться переносимым, внедрите требуемые ресурсы непосредственно в SVG, например, используя URI‑схему `data:` для связанных изображений.

Когда SVG‑файлы поступают из ненадёжных источников, ограничьте схемы, расположения файлов и хосты, к которым разрешён доступ. Сетевые разрешители также должны применять тайм‑ауты, ограничения размера ответов и проверку содержимого.

### **Преобразование SVG в редактируемые фигуры**

Aspose.Slides может преобразовать SVG в группу редактируемых фигур слайда, аналогично соответствующей команде PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Для выполнения преобразования используйте перегрузку **[IShapeCollection.AddGroupShape]**(https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addgroupshape/), принимающую **[ISvgImage]**.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

Применяйте преобразование SVG‑в‑фигуры, когда отдельные векторные элементы требуют редактирования как фигур PowerPoint. Если SVG нужен только для отображения, оставьте его как изображение — это проще и избавляет от создания множества отдельных фигур.

## **Замена существующего ресурса изображения**

Используйте **[IPPImage.ReplaceImage]**(https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/replaceimage/), когда нужно заменить существующий ресурс изображения. Это особенно удобно для общих графических элементов, таких как логотипы.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Если несколько рамок изображения, фоновых заливок, образцов или макетов используют один и тот же ресурс, его замена обновит все эти использования. Если должна измениться только одна рамка, назначьте ей другое изображение вместо замены общего ресурса.

`ReplaceImage` также предоставляет перегрузки, принимающие **[IImage]**(https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) или иной **[IPPImage]**(https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/).

## **Практические рекомендации по управлению изображениями**

### **Контроль размера презентации**

Большие растровые изображения могут значительно увеличить размер презентации. Используйте исходные изображения с размерами, соответствующими их предполагаемому месту отображения, переиспользуйте общие ресурсы изображений там, где это возможно, и избегайте встраивания повторяющихся копий одного и того же графического файла высокого разрешения.

Для уже размещённых в рамках растровых картинок можно использовать **[IPictureFillFormat.CompressImage]**(https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/compressimage/) — это уменьшит данные изображения в соответствии с выбранным разрешением и параметрами обрезки. Это обработка рамки изображения, а не управление коллекцией изображений, поэтому см. [Picture Frame](/slides/ru/net/picture-frame/) для сопутствующих операций форматирования.

### **Выбор между встроенным и связанным содержимым**

Встраивание делает презентацию переносимой, поскольку все необходимые данные изображений находятся в файле. Связывание может уменьшить размер файла, но вводит внешнюю зависимость. Используйте ссылки только тогда, когда такая зависимость приемлема и стабильна.

### **Повторное использование общего фирменного оформления**

Для повторяющихся логотипов, водяных знаков или декоративных графических элементов используйте один ресурс изображения и переиспользуйте его. Если графика относится к дизайну презентации, а не к содержимому слайда, разместите её на образце или макете, чтобы она наследовалась соответствующими слайдами.

### **Сохранение переносимости SVG‑ресурсов**

Самодостаточный SVG легче перемещать и рендерить последовательно, чем SVG, зависящий от внешних файлов или сетевых ресурсов. По возможности внедряйте необходимые ресурсы перед импортом SVG. Преобразуйте SVG в фигуры только тогда, когда отдельные векторные элементы нуждаются в редактировании.

### **Использование современного кроссплатформенного API изображений**

Для нового кода .NET используйте API Aspose.Slides **[IImage]**(https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) и **[Images]**(https://reference.aspose.com/slides/ru/net/aspose.slides/images/) вместо `System.Drawing.Image` или `Bitmap`. См. раздел [Modern API](/slides/ru/net/modern-api/) для рекомендаций по миграции.

WMF и EMF требуют особого внимания. При передаче этих форматов через **[IImage]**, **[ImageCollection.AddImage]**(https://reference.aspose.com/slides/ru/net/aspose.slides/imagecollection/addimage/) преобразует метафайл в растровое представление PNG перед вставкой. Если важно сохранить данные метафайла, используйте потоковую перегрузку **[ImageCollection.AddImage]**. Генерация EMF‑контента из электронных таблиц или других продуктов — отдельный процесс интеграции и выходит за рамки этой статьи.

## **FAQ**

**В чём разница между коллекцией изображений и рамкой изображения?**

Коллекция изображений хранит переиспользуемые ресурсы изображений. Рамка изображения — это фигура слайда, отображающая один из этих ресурсов и предоставляющая специфическое для картинок форматирование, такое как обрезка и эффекты.

**Как лучше всего заменить один и тот же логотип во всех местах?**

Если логотип уже общим ресурсом изображения, замените его с помощью **[IPPImage.ReplaceImage]**. Для фирменного оформления на уровне всей презентации также можно разместить логотип на образце или макете, что уменьшит дублирование контента на слайдах.

**Почему связанное изображение исчезает на другом компьютере?**

Связанная картинка зависит от внешнего файла или URL. Если ресурс недоступен с другого компьютера, связанное изображение будет недоступно. Встраивайте изображение, когда презентация должна быть автономной.

**Можно ли отредактировать вставленный SVG как фигуры PowerPoint?**

Да. Преобразуйте SVG с помощью **[IShapeCollection.AddGroupShape]**; полученная группа будет содержать редактируемые фигуры слайда вместо одного SVG‑изображения.

**Как сделать презентацию с множеством изображений менее объёмной?**

Переиспользуйте общие ресурсы изображений, избегайте избыточно больших растровых источников, при необходимости сжимайте подходящие растровые картинки, размещайте повторяющийся фирменный контент на образцах или макетах и используйте связанные изображения только тогда, когда внешняя зависимость приемлема.