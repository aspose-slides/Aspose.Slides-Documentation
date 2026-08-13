---
title: Добавление водяных знаков в презентации на .NET
linktitle: Водяной знак
type: docs
weight: 40
url: /ru/net/watermark/
keywords:
- водяной знак
- текстовый водяной знак
- изображение водяного знака
- добавить водяной знак
- изменить водяной знак
- удалить водяной знак
- удалить водяной знак
- добавить водяной знак в PPT
- добавить водяной знак в PPTX
- добавить водяной знак в ODP
- удалить водяной знак из PPT
- удалить водяной знак из PPTX
- удалить водяной знак из ODP
- удалить водяной знак из PPT
- удалить водяной знак из PPTX
- удалить водяной знак из ODP
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте текстовыми и графическими водяными знаками в презентациях PowerPoint и OpenDocument на .NET, указывая черновик, конфиденциальную информацию, авторские права и многое другое."
---
## **Введение**

**Водяной знак** в презентации — это текстовая или графическая штампа, используемая на отдельном слайде или во всех слайдах презентации. Обычно водяной знак используется для указания, что презентация является черновиком (например, водяной знак “Draft”), содержит конфиденциальную информацию (например, водяной знак “Confidential”), указывает, к какой компании относится (например, водяной знак “Company Name”), идентифицирует автора презентации и т.д. Водяной знак помогает предотвратить нарушения авторских прав, указывая, что презентацию нельзя копировать. Водяные знаки используются как в PowerPoint, так и в форматах OpenDocument. В Aspose.Slides вы можете добавить водяной знак к файлам PowerPoint PPT, PPTX и OpenDocument ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/ru/net/) доступны различные способы создания водяных знаков в документах PowerPoint или OpenDocument и изменения их дизайна и поведения. Общее требование: для добавления текстовых водяных знаков следует использовать интерфейс [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/), а для добавления графических водяных знаков — класс [PictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/pictureframe/) или заполнить форму водяного знака изображением. `PictureFrame` реализует интерфейс [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape), позволяя использовать все гибкие настройки объекта формы. Поскольку `ITextFrame` не является формой и имеет ограниченные настройки, он оборачивается в объект [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape).

Существует два способа применения водяного знака: к отдельному слайду или ко всем слайдам презентации. Для применения водяного знака ко всем слайдам используется мастер слайдов — водяной знак добавляется в Slide Master, полностью оформляется там и применяется ко всем слайдам без ограничения возможности изменения водяного знака на отдельных слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Чтобы предотвратить изменение водяного знака (а точнее его родительской формы), Aspose.Slides предоставляет возможность блокировать форму. Конкретную форму можно заблокировать на обычном слайде или на мастере слайдов. Когда форма водяного знака заблокирована на Slide Master, она будет заблокирована на всех слайдах презентации.

Можно задать имя водяному знаку, чтобы в будущем, при необходимости удалить его, найти его среди форм слайда по имени.

Водяной знак можно оформить любым способом; однако обычно у него есть общие свойства, такие как выравнивание по центру, вращение, расположение по переднему плану и т.п. Мы рассмотрим, как использовать эти свойства в примерах ниже.

## **Текстовый водяной знак**

### **Добавление текстового водяного знака на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала добавьте форму на слайд, затем добавьте в эту форму текстовый фрейм. Текстовый фрейм представляется интерфейсом [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe). Этот тип не наследуется от [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/), который имеет широкий набор свойств для гибкого позиционирования водяного знака. Поэтому объект [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe) оборачивается в объект [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/). Чтобы добавить текст водяного знака в форму, используйте метод [AddTextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/methods/addtextframe), как показано ниже.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Добавить водяной знак на слайд.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Смотрите также" %}} 
- [How to Use the TextFrame Class?](/slides/ru/net/text-formatting/)
{{% /alert %}}

### **Добавление текстового водяного знака в презентацию**

Если нужно добавить текстовый водяной знак ко всей презентации (т.е. сразу на все слайды), добавьте его в [MasterSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/masterslide/). Остальная логика такая же, как при добавлении водяного знака на отдельный слайд — создайте объект [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) и затем добавьте в него водяной знак с помощью метода [AddTextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Добавить водяной знак на мастер слайд.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Смотрите также" %}} 
- [How to Use the Slide Master?](/slides/ru/net/slide-master/)
{{% /alert %}}

### **Установка прозрачности формы водяного знака**

По умолчанию прямоугольная форма имеет цвета заливки и линии. Это означает, что при добавлении водяного знака он может отображаться с сплошным фоном или границей, которые могут отвлекать внимание от содержимого слайда. Чтобы водяной знак оставался незаметным и не влиял на визуальный дизайн презентации, можно сделать форму полностью прозрачной.

Следующие строки кода делают форму прозрачной, удаляя как цвет заливки, так и цвет границы:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Установка шрифта для текстового водяного знака**

Перед применением текстового водяного знака к слайду важно настроить его внешний вид так, чтобы он гармонировал с общим дизайном. Вы можете изменить тип и размер шрифта, чтобы водяной знак был легко читаемым и эстетически приятным. Настройка шрифта также помогает укрепить фирменный стиль или просто подогнать его под стиль презентации.

Ниже показан фрагмент кода, демонстрирующий, как задать конкретный латинский шрифт и установить нужную высоту шрифта:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Установка цвета текста водяного знака**

Перед применением водяного знака убедитесь, что цвет текста установлен таким образом, чтобы он гармонично сочетался с содержимым слайда и не доминировал над ним. Регулируя прозрачность цвета (альфа) вместе с компонентами красного, зелёного и синего, можно создать нежный полупрозрачный водяной знак, который виден, но не навязчив. Этот подход позволяет сосредоточиться на основной части презентации, одновременно защищая контент.

Чтобы задать цвет текста водяного знака, используйте следующий код:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Центрирование текстового водяного знака**

Правильное центрирование текстового водяного знака может существенно улучшить общую эстетику презентации, обеспечивая симметричное размещение водяного знака независимо от размеров слайда. Такой подход придаёт слайдам профессиональный вид и гарантирует, что водяной знак не будет мешать основному содержимому.

Ниже приведён фрагмент кода, показывающий, как вычислить центральную позицию слайда и разместить текстовый водяной знак соответственно:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

Изображение ниже показывает конечный результат.

![Текстовый водяной знак](text_watermark.png)

## **Графический водяной знак**

### **Добавление графического водяного знака в презентацию**

Во многих случаях графический водяной знак может стать уникальным элементом бренда или более визуально привлекательной альтернативой текстовому знаку. Перед добавлением водяного знака убедитесь, что файл изображения доступен (например, PNG с поддержкой прозрачности). Ниже приведён пример, демонстрирующий загрузку изображения из файловой системы, его добавление в презентацию и последующее применение в качестве водяного знака через свойства заливки формы.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Блокировка водяного знака от редактирования**

Если необходимо запретить редактирование водяного знака, используйте свойство [IAutoShape.ShapeLock](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/properties/shapelock) формы. С помощью этого свойства можно защитить форму от выбора, изменения размеров, перемещения, группировки с другими элементами, блокировать её текст от редактирования и многое другое:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Заблокировать форму водяного знака от изменений.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Перемещение водяного знака на передний план**

В Aspose.Slides порядок накладывания форм (Z‑order) можно задать методом [IShapeCollection.Reorder](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/reorder/#reorder). Для этого вызовите метод из списка слайдов презентации, передав в него ссылку на форму и её номер позиции. Таким образом можно переместить форму на передний план или отправить её назад. Эта возможность особенно полезна, когда требуется разместить водяной знак поверх содержимого презентации:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Установка вращения водяного знака**

Регулирование угла вращения вашего водяного знака может существенно улучшить визуальное воздействие и незаметность презентации. Диагональный водяной знак, например, будет менее навязчивым, одновременно обеспечивая надёжную защиту от несанкционированного использования. Ниже представлен пример, который вычисляет подходящий угол на основе размеров слайда, чтобы водяной знак был размещён по диагонали. Динамический расчёт обеспечивает эффективность водяного знака независимо от размеров слайдов.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Задание имени водяному знаку**

Aspose.Slides позволяет задать имя формы. Используя имя формы, в дальнейшем можно получить к ней доступ для изменения или удаления. Чтобы задать имя формы водяного знака, присвойте его свойству [IAutoShape.Name](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/properties/name):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **Удаление водяного знака**

Чтобы удалить форму водяного знака, используйте свойство [IAutoShape.Name](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/properties/name) для поиска её среди форм слайда. Затем передайте найденную форму в метод [IShapeCollection.Remove](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/remove/):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **Рабочий пример**

Вы можете попробовать бесплатные онлайн‑инструменты Aspose.Slides : [Add Watermark](https://products.aspose.app/slides/ru/watermark) и [Remove Watermark](https://products.aspose.app/slides/ru/watermark/remove-watermark).

![Онлайн‑инструменты для добавления и удаления водяных знаков](online_tools.png)

## **FAQ**

### Что такое водяной знак и зачем он нужен?

Водяной знак — это наложение текста или изображения на слайды, которое помогает защищать интеллектуальную собственность, усиливать узнаваемость бренда или предотвращать несанкционированное использование презентаций.

### Можно ли добавить водяной знак ко всем слайдам презентации?

Да, Aspose.Slides позволяет программно добавить водяной знак на каждый слайд презентации. Можно пройтись по всем слайдам и применить настройки водяного знака индивидуально.

### Как изменить прозрачность водяного знака?

Прозрачность водяного знака регулируется изменением настроек заливки ([FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/fillformat/)) формы. Это обеспечивает нежный вид водяного знака без отвлечения от содержимого слайда.

### Какие форматы изображений поддерживаются для водяных знаков?

Aspose.Slides поддерживает различные форматы изображений, такие как PNG, JPEG, GIF, BMP, SVG и другие.

### Можно ли настроить шрифт и стиль текстового водяного знака?

Да, вы можете выбрать любой шрифт, размер и стиль, чтобы они соответствовали дизайну вашей презентации и поддерживали фирменный стиль.

### Как изменить позицию или ориентацию водяного знака?

Позицию и ориентацию водяного знака можно программно изменить, изменив координаты, размеры и свойства вращения формы.