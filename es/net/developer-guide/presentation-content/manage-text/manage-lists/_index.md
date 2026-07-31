---
title: Administrar listas con viñetas y numeradas en presentaciones en .NET
linktitle: Administrar listas
type: docs
weight: 70
url: /es/net/manage-lists/
aliases:
  - /net/administrar-viñetas-y-listas-numeradas/
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
## **Resumen**

Aspose.Slides for .NET le permite crear y dar formato a listas con viñetas y numeradas en presentaciones de PowerPoint y OpenDocument. Un elemento de lista es un párrafo cuyas configuraciones de viñeta se controlan a través de su formato de párrafo.

Utilice la propiedad [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/paragraphformat/) para acceder a la configuración de lista a nivel de párrafo. El punto de entrada principal es [IParagraphFormat.Bullet](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/bullet/), que devuelve un objeto [IBulletFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/). Con este objeto, puede establecer el tipo de viñeta, símbolo, imagen, color, tamaño, estilo de numeración y número inicial.

Este artículo muestra cómo:

- crear una lista con viñetas usando un símbolo personalizado
- crear una viñeta de imagen
- crear una lista multinivel estableciendo la profundidad del párrafo
- crear una lista numerada
- inspeccionar y modificar el formato de lista en una presentación existente

## **Crear una lista con viñetas**

Para crear una lista con viñetas, añada objetos [IParagraph](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/) a un [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) y establezca [IBulletFormat.Type](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/type/) a [BulletType.Symbol](https://reference.aspose.com/slides/es/net/aspose.slides/bullettype/). A continuación, puede definir [IBulletFormat.Char](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/color/) y [IBulletFormat.Height](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/height/) para controlar la apariencia de la viñeta.

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

![The symbol bullets](symbol_bullets.png)

## **Crear una lista numerada**

Utilice listas numeradas cuando el orden de los elementos sea importante. Establezca [IBulletFormat.Type](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/type/) a [BulletType.Numbered](https://reference.aspose.com/slides/es/net/aspose.slides/bullettype/). También puede elegir un formato de numeración con [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/numberedbulletstyle/) o definir [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/numberedbulletstartwith/) cuando la lista deba comenzar con un valor distinto de 1.

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

![The numbered bullets](numbered_bullets.png)

## **Crear una viñeta de imagen**

Aspose.Slides le permite sustituir un símbolo de viñeta normal por una imagen. Las viñetas de imagen funcionan mejor con gráficos simples que siguen siendo legibles a un tamaño reducido, como iconos o pequeños archivos PNG transparentes.

{{% alert color="primary" %}}
Idealmente, si planea sustituir el símbolo de viñeta normal por una imagen, lo más adecuado es elegir un gráfico sencillo con fondo transparente. Ese tipo de imágenes funciona bien como símbolos de viñeta personalizados.

Tenga en cuenta que la imagen se reducirá a un tamaño muy pequeño. Por esa razón, recomendamos encarecidamente seleccionar una imagen que permanezca clara y visualmente eficaz cuando se utilice como viñeta en una lista.
{{% /alert %}}

Para crear una viñeta de imagen, añada una imagen a [Presentation.Images](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/images/) y asigne el objeto de imagen devuelto a [IBulletFormat.Picture](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/picture/). Establezca [IBulletFormat.Type](https://reference.aspose.com/slides/es/net/aspose.slides/ibulletformat/type/) a [BulletType.Picture](https://reference.aspose.com/slides/es/net/aspose.slides/bullettype/) antes de asignar la imagen.

Supongamos que tenemos un “image.png”:

![A picture for the bullets](picture_for_bullets.png)

El siguiente código C# muestra cómo crear viñetas de imagen en una diapositiva:

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

![The picture bullets](picture_bullets.png)

## **Crear una lista multinivel**

Utilice [IParagraphFormat.Depth](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/depth/) para colocar los elementos de la lista en diferentes niveles. El nivel 0 es el nivel superior, el nivel 1 se anida debajo de él, y así sucesivamente.

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

![The multilevel list](multilevel_list.png)

## **Modificar una lista existente**

Para cambiar el formato de lista en una presentación existente, acceda al párrafo objetivo y actualice sus ajustes de [IParagraphFormat.Bullet](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/bullet/). Las mismas propiedades que se usan para crear listas pueden emplearse para inspeccionar o modificar listas cargadas desde un archivo PPT, PPTX o ODP.

El siguiente código C# cambia el primer párrafo de un marco de texto para usar un estilo de lista numerada:

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

**¿Se pueden exportar listas con viñetas y numeradas a PDF o imágenes?**

Sí. Aspose.Slides conserva el formato de la lista cuando el formato de destino admite la disposición de texto y las características de viñetas correspondientes.

**¿Puedo editar listas en presentaciones existentes?**

Sí. Cargue la presentación, acceda al párrafo objetivo, inspeccione o actualice sus ajustes de [IParagraphFormat.Bullet](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/bullet/) y guarde la presentación.

**¿Pueden las listas contener texto no latino?**

Sí. El texto de los elementos de lista puede contener caracteres Unicode, por lo que puede crear listas en presentaciones multilingües. Asegúrese de que las fuentes utilizadas en la presentación admitan los caracteres que necesita.