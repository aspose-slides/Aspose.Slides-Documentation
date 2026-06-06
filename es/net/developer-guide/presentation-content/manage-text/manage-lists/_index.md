---
title: Gestionar listas con viñetas y numeradas en presentaciones en .NET
linktitle: Gestionar listas
type: docs
weight: 70
url: /es/net/manage-lists/
keywords:
- viñeta
- lista con viñetas
- lista numerada
- viñeta de símbolo
- viñeta de imagen
- viñeta personalizada
- lista multinivel
- crear viñeta
- añadir viñeta
- añadir lista
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a crear y dar formato a listas con viñetas, de imagen, multinivel y numeradas en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para .NET."
---
## **Visión general**

Aspose.Slides for .NET le permite crear y dar formato a listas con viñetas y numeradas en presentaciones de PowerPoint y OpenDocument. Un elemento de lista es un párrafo cuyas configuraciones de viñeta se controlan a través de su formato de párrafo.

Utilice la propiedad [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/paragraphformat/) para acceder a la configuración de listas a nivel de párrafo. El punto de entrada principal es [IParagraphFormat.Bullet](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/bullet/), que devuelve un objeto [IBulletFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/). Con este objeto, puede establecer el tipo de viñeta, el símbolo, la imagen, el color, el tamaño, el estilo de numeración y el número de inicio.

Este artículo muestra cómo:

- crear una lista con viñetas con un símbolo personalizado
- crear una viñeta con imagen
- crear una lista multinivel estableciendo la profundidad del párrafo
- crear una lista numerada
- examinar y cambiar el formato de lista en una presentación existente

## **Crear una lista con viñetas**

Para crear una lista con viñetas, añada objetos [IParagraph](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/) a un [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) y establezca [IBulletFormat.Type](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/type/) a [BulletType.Symbol](https://reference.aspose.com/slides/es/net/aspose.slides/bullettype/). Luego puede establecer [IBulletFormat.Char](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/color/) y [IBulletFormat.Height](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/height/) para controlar la apariencia de la viñeta.

El siguiente código C# muestra cómo crear una lista con viñetas en una diapositiva:

```csharp
static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

El resultado:

![Las viñetas de símbolos](symbol_bullets.png)

## **Crear una lista numerada**

Utilice listas numeradas cuando el orden de los elementos sea importante. Establezca [IBulletFormat.Type](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/type/) a [BulletType.Numbered](https://reference.aspose.com/slides/es/net/aspose.slides/bullettype/). También puede elegir un formato de numeración con [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/numberedbulletstyle/) o establecer [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/numberedbulletstartwith/) cuando la lista debe comenzar con un valor distinto de 1.

El siguiente código C# muestra cómo crear una lista numerada en una diapositiva:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

El resultado:

![Las viñetas numeradas](numbered_bullets.png)

## **Crear una viñeta con imagen**

Aspose.Slides le permite sustituir un símbolo de viñeta habitual por una imagen. Las viñetas con imagen funcionan mejor con imágenes simples que siguen siendo legibles en tamaños pequeños, como iconos o archivos PNG transparentes de pequeño tamaño.

 {{% alert color="primary" %}}
Idealmente, si planea sustituir el símbolo de viñeta regular por una imagen, es mejor elegir un gráfico sencillo con fondo transparente. Estas imágenes funcionan bien como símbolos de viñeta personalizados.
{{% /alert %}}

Para crear una viñeta con imagen, añada una imagen a [Presentation.Images](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/images/) y asigne el objeto de imagen devuelto a [IBulletFormat.Picture](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/picture/). Establezca [IBulletFormat.Type](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/type/) a [BulletType.Picture](https://reference.aspose.com/slides/es/net/aspose.slides/bullettype/) antes de asignar la imagen.

Supongamos que tenemos un "image.png":

![Una imagen para las viñetas](picture_for_bullets.png)

El siguiente código C# muestra cómo crear viñetas con imagen en una diapositiva:

```csharp
static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

El resultado:

![Las viñetas con imagen](picture_bullets.png)

## **Crear una lista multinivel**

Utilice [IParagraphFormat.Depth](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/depth/) para colocar los elementos de la lista en diferentes niveles. El nivel 0 es el nivel superior, el nivel 1 está anidado bajo él, y así sucesivamente.

El siguiente código C# muestra cómo crear una lista con viñetas multinivel:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

El resultado:

![La lista multinivel](multilevel_list.png)

## **Cambiar una lista existente**

Para cambiar el formato de lista en una presentación existente, acceda al párrafo objetivo y actualice sus configuraciones [IParagraphFormat.Bullet](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/bullet/). Las mismas propiedades utilizadas para crear listas pueden usarse para examinar o modificar listas cargadas desde un archivo PPT, PPTX o ODP.

El siguiente código C# cambia el primer párrafo en un marco de texto para usar un estilo de lista numerada:

```csharp
using var presentation = new Presentation("input.pptx");

var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **Preguntas frecuentes**

**¿Pueden exportarse las listas con viñetas y numeradas a PDF o imágenes?**

Sí. Aspose.Slides conserva el formato de la lista cuando el formato de destino admite la disposición de texto y las características de viñetas correspondientes.

**¿Puedo editar listas en presentaciones existentes?**

Sí. Cargue la presentación, acceda al párrafo objetivo, examine o actualice sus configuraciones [IParagraphFormat.Bullet](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/bullet/), y guarde la presentación.

**¿Pueden las listas contener texto no latino?**

Sí. El texto de los elementos de la lista puede contener caracteres Unicode, por lo que puede crear listas en presentaciones multilingües. Asegúrese de que las fuentes utilizadas en la presentación admitan los caracteres que necesita.