---
title: Добавить водяной знак в презентацию на C#
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
- добавить водяной знак в презентацию
- добавить водяной знак в PPT
- добавить водяной знак в PPTX
- добавить водяной знак в ODP
- удалить водяной знак из презентации
- удалить водяной знак из PPT
- удалить водяной знак из PPTX
- удалить водяной знак из ODP
- удалить водяной знак из презентации
- удалить водяной знак из PPT
- удалить водяной знак из PPTX
- удалить водяной знак из ODP
- PowerPoint
- OpenDocument
- презентация
- C#
- Csharp
- Aspose.Slides for .NET
description: "Узнайте, как управлять текстовыми и графическими водяными знаками в презентациях PowerPoint и OpenDocument на C#, чтобы обозначать черновик, конфиденциальную информацию, авторские права и многое другое."
---

## **Обзор**

**Водяной знак** в презентации — это текстовый или графический штамп, используемый на отдельном слайде или на всех слайдах презентации. Обычно водяной знак используется для указания, что презентация является черновиком (например, водяной знак «Черновик»), содержит конфиденциальную информацию (например, «Конфиденциально»), относится к определённой компании (например, «Название компании»), идентифицирует автора презентации и т.д. Водяной знак помогает предотвратить нарушения авторских прав, указывая, что презентацию нельзя копировать. Водяные знаки используются как в форматах PowerPoint, так и в OpenDocument. В Aspose.Slides вы можете добавить водяной знак в файлы PowerPoint PPT, PPTX и OpenDocument ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/net/) существует несколько способов создания водяных знаков в документах PowerPoint или OpenDocument и изменения их дизайна и поведения. Общий момент — для добавления текстовых водяных знаков следует использовать интерфейс [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), а для добавления графических — класс [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) или заполнить форму водяного знака изображением. `PictureFrame` реализует интерфейс [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape), что позволяет использовать все гибкие параметры объекта формы. Поскольку `ITextFrame` не является формой и его параметры ограничены, он оборачивается в объект [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape).

Есть два способа применения водяного знака: к отдельному слайду или ко всем слайдам презентации. Для применения к каждому слайду используется Slide Master — водяной знак добавляется в Slide Master, полностью оформляется там и применяется ко всем слайдам, не влияя на возможность изменения водяного знака на отдельных слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (точнее, родительской формы знака), Aspose.Slides предоставляет функциональность блокировки формы. Конкретную форму можно заблокировать как на обычном слайде, так и на Slide Master. Когда форма водяного знака заблокирована на Slide Master, она будет заблокирована на всех слайдах презентации.

Вы можете задать имя водяному знаку, чтобы в дальнейшем, при необходимости удалить его, найти форму по имени в коллекции форм слайда.

Водяной знак можно оформить как угодно; однако обычно у водяных знаков есть общие черты: центрирование, вращение, расположение спереди и т.д. Мы рассмотрим, как использовать эти возможности в примерах ниже.

## **Текстовый водяной знак**

### **Добавление текстового водяного знака на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала добавьте форму на слайд, затем добавьте в эту форму текстовый фрейм. Текстовый фрейм представлен интерфейсом [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe). Этот тип не наследуется от [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), который имеет широкий набор свойств для гибкого позиционирования водяного знака. Поэтому объект [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) оборачивается в объект [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Чтобы добавить текст водяного знака в форму, используйте метод [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe), как показано ниже.
```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Добавьте водяной знак на слайд.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class?](/slides/ru/net/text-formatting/)
{{% /alert %}}

### **Добавление текстового водяного знака в презентацию**

Если нужно добавить текстовый водяной знак ко всей презентации (то есть сразу на все слайды), добавьте его в [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/). Остальная логика такая же, как при добавлении водяного знака на отдельный слайд — создайте объект [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) и затем добавьте в него водяной знак с помощью метода [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe).
```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Добавьте водяной знак на мастер-слайд.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master?](/slides/ru/net/slide-master/)
{{% /alert %}}

### **Установка прозрачности формы водяного знака**

По умолчанию прямоугольная форма имеет цвета заливки и линии. Это значит, что после добавления водяного знака он может отображаться с плотным фоном или границей, отвлекая внимание от содержимого слайда. Чтобы водяной знак оставался ненавязчивым и не мешал визуальному оформлению, форму можно сделать полностью прозрачной.

Следующие строки кода делают форму прозрачной, удаляя как цвет заливки, так и цвет границы:
```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```


### **Установка шрифта для текстового водяного знака**

Перед тем как применить текстовый водяной знак к слайду, важно настроить его внешний вид так, чтобы он гармонировал с общим дизайном. Вы можете изменить тип и размер шрифта, чтобы водяной знак был и читаемым, и эстетичным. Настройка шрифта также помогает укрепить фирменный стиль или просто подобрать соответствие стилю презентации.

Ниже пример кода, показывающего, как задать определённый латинский шрифт и высоту шрифта для водяного знака:
```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```


### **Установка цвета текста водяного знака**

Перед применением водяного знака убедитесь, что цвет текста установлен так, чтобы он сочетался с содержимым слайда и не доминировал. Регулирование прозрачности (альфа‑канала) вместе с компонентами красного, зелёного и синего позволяет создать ненавязчивый полупрозрачный водяной знак, который виден, но не отвлекает. Этот подход сохраняет фокус на основной презентации, одновременно защищая контент.

Для установки цвета текста водяного знака используйте следующий код:
```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```


### **Центрирование текстового водяного знака**

Правильное центрирование текстового водяного знака может значительно улучшить эстетическое восприятие презентации, обеспечивая симметричное расположение независимо от размеров слайда. Такой подход придаёт слайдам профессиональный вид и гарантирует, что водяной знак не будет мешать основному содержимому.

Ниже пример кода, демонстрирующего, как вычислить центральную позицию слайда и разместить текстовый водяной знак соответственно:
```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


Изображение ниже показывает итоговый результат.

![The text watermark](text_watermark.png)

## **Графический водяной знак**

### **Добавление графического водяного знака в презентацию**

Во многих случаях графический водяной знак может обеспечить уникальный фирменный элемент или более визуально привлекательную альтернативу текстовому знаку. Перед добавлением убедитесь, что файл изображения доступен (например, PNG для прозрачности). В следующем примере показывается, как загрузить изображение из файловой системы, добавить его в презентацию и применить как водяной знак с помощью свойств заливки формы.
```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```


## **Блокировка водяного знака от редактирования**

Если необходимо предотвратить редактирование водяного знака, используйте свойство [IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock) формы. С его помощью можно запретить выбор формы, изменение её размеров, перемещение, группировку с другими элементами, блокировать её текст от редактирования и многое другое:
```cs
// Заблокировать форму водяного знака от изменения.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```


## **Перемещение водяного знака на передний план**

В Aspose.Slides порядок Z‑уровня форм можно задать методом [IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder). Для этого вызовите метод из списка слайдов презентации, передав ссылку на форму и её номер порядка. Так можно переместить форму на передний план или отправить её назад. Эта возможность особенно полезна, когда нужно разместить водяной знак спереди презентации:
```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```


## **Установка вращения водяного знака**

Регулирование вращения водяного знака может существенно улучшить визуальный эффект и тонкость его восприятия. Диагональный водяной знак, например, менее навязчив, но всё равно обеспечивает надёжную защиту от неавторизованного использования. В следующем примере рассчитывается подходящий угол на основе размеров слайда, чтобы водяной знак разместился по диагонали. Такое динамическое вычисление гарантирует эффективность знака независимо от размеров слайдов.
```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```


## **Задание имени для водяного знака**

Aspose.Slides позволяет задать имя форме. С помощью имени формы её можно найти в будущем для изменения или удаления. Чтобы задать имя форме водяного знака, присвойте его свойству [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name):
```cs
watermarkShape.Name = "watermark";
```


## **Удаление водяного знака**

Чтобы удалить форму водяного знака, используйте свойство [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) для её поиска в коллекции форм слайда. Затем передайте найденную форму в метод [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/):
```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```


## **Онлайн‑пример**

Вы можете попробовать бесплатные онлайн‑инструменты Aspose.Slides — [Add Watermark](https://products.aspose.app/slides/watermark) и [Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark).

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**Что такое водяной знак и зачем он нужен?**

Водяной знак — это текстовое или графическое наложение на слайды, которое помогает защитить интеллектуальную собственность, усилить узнаваемость бренда или предотвратить несанкционированное использование презентаций.

**Можно ли добавить водяной знак ко всем слайдам презентации?**

Да, Aspose.Slides позволяет программно добавить водяной знак на каждый слайд презентации. Можно пройтись по всем слайдам и применить настройки водяного знака индивидуально.

**Как отрегулировать прозрачность водяного знака?**

Прозрачность регулируется изменением настроек заливки ([FillFormat](https://reference.aspose.com/slides/net/aspose.slides/shape/fillformat/)) формы. Это делает водяной знак ненавязчивым и не отвлекает от содержимого слайда.

**Какие форматы изображений поддерживаются для водяных знаков?**

Aspose.Slides поддерживает PNG, JPEG, GIF, BMP, SVG и другие форматы.

**Можно ли настроить шрифт и стиль текстового водяного знака?**

Да, можно выбрать любой шрифт, размер и стиль, чтобы он соответствовал дизайну презентации и поддерживал фирменный стиль.

**Как изменить позицию или ориентацию водяного знака?**

Позицию и ориентацию можно программно изменить, изменяя координаты, размеры и свойства вращения формы.