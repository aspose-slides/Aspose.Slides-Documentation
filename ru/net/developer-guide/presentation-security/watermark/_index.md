---
title: Водяной знак
type: docs
weight: 40
url: /net/watermark/
keywords: "Водяной знак, добавить водяной знак, текстовый водяной знак, изображение водяного знака, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавление текстового и изображенческого водяного знака в презентацию PowerPoint на C# или .NET"
---

## **О водяном знаке**
**Водяной знак** в презентации — это текстовая или изображенческая метка, используемая на слайде или на всех слайдах презентации. Обычно водяной знак используется для указания на то, что презентация является черновиком (например, водяной знак "Черновик"); что она содержит конфиденциальную информацию (например, водяной знак "Конфиденциально"); для указания, к какой компании она принадлежит (например, водяной знак "Название компании"); для идентификации автора презентации и т.д. Водяной знак помогает предотвратить нарушение авторских прав на презентацию, указывая, что презентацию нельзя копировать. Водяные знаки используются как в формате PowerPoint, так и OpenOffice. В Aspose.Slides вы можете добавить водяной знак в форматы файлов PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/net/) существуют различные способы создания водяного знака в PowerPoint или OpenOffice, обернуть его в разные формы, изменить дизайн и поведение и т.д. Общее то, что для добавления текстовых водяных знаков вы должны использовать класс [**TextFrame**](https://reference.aspose.com/slides/net/aspose.slides/textframe), а для добавления изображенческого водяного знака - [**PictureFrame**](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/). PictureFrame реализует интерфейс [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) и может использовать все преимущества гибких настроек объекта формы. TextFrame не является формой, и его настройки ограничены. Поэтому рекомендуется обернуть TextFrame в объект [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape).

Существует два способа применения водяного знака: к одному слайду и ко всем слайдам презентации. Мастер слайдов используется для применения водяного знака ко всем слайдам презентации - водяной знак добавляется в Мастер слайдов, полностью проектируется там и применяется ко всем слайдам без изменения разрешения на изменение водяного знака на слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (или точнее, родительской формы водяного знака), Aspose.Slides предоставляет функциональность блокировки форм. Определенная форма может быть заблокирована на обычном слайде или на Мастере слайдов. Когда форма водяного знака блокируется на Мастере слайдов - она будет заблокирована на всех слайдах презентации.

Вы можете установить имя водяного знака, чтобы в будущем, если вы захотите удалить водяной знак, вы могли найти его в формах слайда по имени.

Вы можете оформлять водяной знак любым образом, однако обычно существуют общие особенности внутри водяных знаков, такие как: центрирование, вращение, передний план и т.д. Мы рассмотрим, как их использовать в примерах ниже.
## **Текстовый водяной знак**
### **Добавление текстового водяного знака на слайд**
Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, вы можете сначала добавить форму на слайд, а затем добавить текстовую рамку в эту форму. Текстовая рамка представлена типом [**TextFrame**](https://reference.aspose.com/slides/net/aspose.slides/textframe). Этот тип не наследуется от [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), который имеет широкий набор свойств для гибкой настройки водяного знака. Поэтому рекомендуется обернуть объект [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) в объект [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Чтобы добавить водяной знак в форму, используйте метод [**AddTextFrame**](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) с переданным текстом водяного знака:

``` csharp

 using (var presentation = new Presentation())

{

	ISlide slide = presentation.Slides[0];

	IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 0, 0, 0, 0);

	ITextFrame watermarkTextFrame = watermarkShape.AddTextFrame("Водяной знак");

}

```



{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать ](/slides/net/slide-master/)[TextFrame](/slides/net/adding-and-formatting-text/)
{{% /alert %}}

### **Добавление текстового водяного знака в презентацию**
Если вы хотите добавить водяной знак в презентацию (то есть, на все слайды сразу), добавьте его в [**MasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/masterslide/). Вся другая логика остается такой же, как и в случае добавления водяного знака на один слайд - создайте объект [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) и затем добавьте в него водяной знак с помощью метода [**AddTextFrame**](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe):

``` csharp

 using (var presentation = new Presentation())

{

	IMasterSlide master = pres.Masters[0];

	IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 0, 0, 0, 0);

	ITextFrame watermarkTextFrame = watermarkShape.AddTextFrame("Водяной знак");

}

```


{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать ](/slides/net/slide-master/)[Мастер слайдов](/slides/net/slide-master/)
{{% /alert %}}

### **Изменение шрифта текстового водяного знака**
Вы можете изменить шрифт текстового водяного знака:

``` csharp

 int alpha = 150, red = 200, green = 200, blue = 200;

IPortion watermarkPortion = watermarkTextFrame.Paragraphs[0].Portions[0];

watermarkPortion.PortionFormat.FontHeight = 52;

```


### **Установка прозрачности текстового водяного знака**
Чтобы установить прозрачность текстового водяного знака, используйте следующий код:

``` csharp

 int alpha = 150, red = 200, green = 200, blue = 200;

IPortion watermarkPortion = watermarkTextFrame.Paragraphs[0].Portions[0];

watermarkPortion.PortionFormat.FillFormat.FillType = FillType.Solid;

watermarkPortion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(alpha, red, green, blue);

```


### **Центрирование текстового водяного знака**
Можно центрировать водяной знак на слайде, и для этого вы можете сделать следующее:

``` csharp

 PointF center = new PointF(presentation.SlideSize.Size.Width / 2, presentation.SlideSize.Size.Height / 2);

float width = 300;

float height = 300;

float x = center.X - width / 2;

float y = center.Y - height / 2;

//...

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, x, y, width, height);

```


## **Изображенческий водяной знак**
### **Добавление изображенческого водяного знака в презентацию**
Чтобы добавить изображенческий водяной знак на все слайды презентации, вы можете сделать следующее:

``` csharp

 IPPImage image = presentation.Images.AddImage(File.ReadAllBytes("watermark.png"));


// ...

watermarkShape.FillFormat.FillType = FillType.Picture;

watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;

watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

```



## **Блокировка водяного знака от редактирования**
Если необходимо предотвратить редактирование водяного знака, используйте свойство [**AutoShape.ShapeLock**](https://reference.aspose.com/slides/net/aspose.slides/autoshape/properties/shapelock) на форме, которая его оборачивает. С помощью этого свойства вы можете защитить форму от выделения, изменения размера, изменения положения, группировки с другими элементами, заблокировать ее текст от редактирования и многое другое:

``` csharp

 // Блокировка форм от изменения

watermarkShape.ShapeLock.SelectLocked = true;

watermarkShape.ShapeLock.SizeLocked = true;

watermarkShape.ShapeLock.TextLocked = true;

watermarkShape.ShapeLock.PositionLocked = true;

watermarkShape.ShapeLock.GroupingLocked = true;

```



{{% alert color="primary" title="Смотрите также" %}} 
- [Как заблокировать формы от редактирования](/slides/net/presentation-locking/)
{{% /alert %}}

## **Вынести водяной знак на передний план**
В Aspose.Slides порядок наложения форм можно установить с помощью метода [**SlideCollection.Reorder**](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/reorder/methods/1). Для этого вам нужно вызвать этот метод из списка слайдов презентации и передать ссылку на форму и ее номер порядка в метод. Таким образом, можно поместить форму на передний план или на задний план слайда. Эта функция особенно полезна, если вам нужно разместить водяной знак на переднем плане презентации:

``` csharp

 slide.Shapes.Reorder(slide.Shapes.Count - 1, watermarkShape);

```


## **Установка вращения водяного знака**
Вот пример того, как установить вращение водяного знака (и его родительской формы):

``` csharp

 float h = presentation.SlideSize.Size.Height;

float w = presentation.SlideSize.Size.Width;

watermarkShape.X = Convert.ToInt32((w - watermarkShape.Width) / 2);

watermarkShape.Y = Convert.ToInt32((h - watermarkShape.Height) / 2);

watermarkShape.Rotation = calculateRotation(h, w);



private int calculateRotation(float height, float width)

{

	double pageHeight = Convert.ToDouble(height);

	double pageWidth = Convert.ToDouble(width);

	double rotation = Math.Atan((pageHeight / pageWidth)) * 180 / Math.PI;

	return Convert.ToInt32(rotation);

}

```


## **Установка имени водяного знака**
Aspose.Slides позволяет установить имя формы. По имени формы вы можете получить к ней доступ в будущем, чтобы изменить или удалить. Чтобы установить имя родительской формы водяного знака - установите его в свойство [**AutoShape.Name**](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name):

``` csharp

 watermarkShape.Name = "водяной знак";

```


## **Удаление водяного знака**
Чтобы удалить форму водяного знака и ее дочерние элементы с слайда, используйте свойство [AutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name), чтобы найти его в формах слайда. Затем передайте форму водяного знака в метод [**ShapeCollection.Remove**](https://reference.aspose.com/net/cells/aspose.cells.drawing/shapecollection/methods/remove):

``` csharp

 for (int i = 0; i < slide.Shapes.Count; i++)

{

	AutoShape shape = (AutoShape)slide.Shapes[i];

	if (String.Compare(shape.Name, "водяной знак", StringComparison.Ordinal) == 0)

	{

		slide.Shapes.Remove(watermarkShape);

	}

}

```


## **Живой пример**
Вы можете ознакомиться с **бесплатными** онлайн-инструментами **Aspose.Slides** [**Добавить водяной знак**](https://products.aspose.app/slides/watermark) и [**Удалить водяной знак**](https://products.aspose.app/slides/watermark/remove-watermark). 

![todo:image_alt_text](slides-watermark.png)