---
title: Gerenciar Listas com Marcadores e Numeradas em Apresentações no .NET
linktitle: Gerenciar Listas
type: docs
weight: 70
url: /pt/net/manage-lists/
keywords:
- marcador
- lista com marcadores
- lista numerada
- marcador de símbolo
- marcador de imagem
- marcador personalizado
- lista multinível
- criar marcador
- adicionar marcador
- adicionar lista
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a criar e formatar listas com marcadores, de imagem, multiníveis e numeradas em apresentações PowerPoint e OpenDocument usando Aspose.Slides para .NET."
---
## **Visão geral**

Aspose.Slides for .NET permite criar e formatar listas com marcadores e numeradas em apresentações do PowerPoint e OpenDocument. Um item de lista é um parágrafo cujas configurações de marcador são controladas por meio do seu formato de parágrafo.

Use a propriedade [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/paragraphformat/) para acessar as configurações de lista no nível do parágrafo. O ponto de entrada principal é [IParagraphFormat.Bullet](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/bullet/), que devolve um objeto [IBulletFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/). Com esse objeto, você pode definir o tipo de marcador, símbolo, imagem, cor, tamanho, estilo de numeração e número inicial.

Este artigo mostra como:

- criar uma lista com marcadores usando um símbolo personalizado
- criar um marcador de imagem
- criar uma lista multinível definindo a profundidade do parágrafo
- criar uma lista numerada
- inspecionar e alterar a formatação de lista em uma apresentação existente

## **Criar uma lista com marcadores**

Para criar uma lista com marcadores, adicione objetos [IParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/) a um [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) e defina [IBulletFormat.Type](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/type/) como [BulletType.Symbol](https://reference.aspose.com/slides/pt/net/aspose.slides/bullettype/). Em seguida, você pode definir [IBulletFormat.Char](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/color/) e [IBulletFormat.Height](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/height/) para controlar a aparência do marcador.

O código C# a seguir demonstra como criar uma lista com marcadores em um slide:

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

O resultado:

![Os marcadores de símbolo](symbol_bullets.png)

## **Criar uma lista numerada**

Use listas numeradas quando a ordem dos itens for importante. Defina [IBulletFormat.Type](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/type/) como [BulletType.Numbered](https://reference.aspose.com/slides/pt/net/aspose.slides/bullettype/). Você também pode escolher um formato de numeração com [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/numberedbulletstyle/) ou definir [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/numberedbulletstartwith/) quando a lista deve iniciar a partir de um valor diferente de 1.

O código C# a seguir mostra como criar uma lista numerada em um slide:

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

O resultado:

![Os marcadores numerados](numbered_bullets.png)

## **Criar um marcador de imagem**

Aspose.Slides permite substituir um símbolo de marcador regular por uma imagem. Marcadores de imagem funcionam melhor com imagens simples que permanecem legíveis em tamanho pequeno, como ícones ou arquivos PNG transparentes pequenos.

{{% alert color="primary" %}}
Idealmente, se você planeja substituir o símbolo de marcador regular por uma imagem, é melhor escolher um gráfico simples com fundo transparente. Essas imagens funcionam bem como símbolos de marcador personalizados.

Lembre-se de que a imagem será reduzida a um tamanho muito pequeno. Por esse motivo, recomendamos fortemente selecionar uma imagem que continue clara e visualmente eficaz quando usada como marcador em uma lista.
{{% /alert %}}

Para criar um marcador de imagem, adicione uma imagem a [Presentation.Images](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/images/) e atribua o objeto de imagem retornado a [IBulletFormat.Picture](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/picture/). Defina [IBulletFormat.Type](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/type/) como [BulletType.Picture](https://reference.aspose.com/slides/pt/net/aspose.slides/bullettype/) antes de atribuir a imagem.

Vamos supor que temos um "image.png":

![Uma imagem para os marcadores](picture_for_bullets.png)

O código C# a seguir mostra como criar marcadores de imagem em um slide:

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

O resultado:

![Os marcadores de imagem](picture_bullets.png)

## **Criar uma lista multinível**

Use [IParagraphFormat.Depth](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/depth/) para colocar os itens da lista em diferentes níveis. O nível 0 é o nível superior, o nível 1 está aninhado abaixo dele e assim por diante.

O código C# a seguir mostra como criar uma lista com marcadores multinível:

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

O resultado:

![A lista multinível](multilevel_list.png)

## **Alterar uma lista existente**

Para alterar a formatação de lista em uma apresentação existente, acesse o parágrafo alvo e atualize suas configurações [IParagraphFormat.Bullet](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/bullet/). As mesmas propriedades usadas para criar listas podem ser usadas para inspecionar ou modificar listas carregadas de um arquivo PPT, PPTX ou ODP.

O código C# a seguir altera o primeiro parágrafo em um quadro de texto para usar um estilo de lista numerada:

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

## **FAQ**

**As listas com marcadores e numeradas podem ser exportadas para PDF ou imagens?**

Sim. Aspose.Slides preserva a formatação da lista quando o formato de destino oferece suporte ao layout de texto e aos recursos de marcador correspondentes.

**Posso editar listas em apresentações existentes?**

Sim. Carregue a apresentação, acesse o parágrafo alvo, inspecione ou atualize suas configurações [IParagraphFormat.Bullet](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/bullet/) e salve a apresentação.

**As listas podem conter texto não‑latino?**

Sim. O texto dos itens de lista pode conter caracteres Unicode, permitindo criar listas em apresentações multilíngues. Certifique‑se de que as fontes usadas na apresentação suportem os caracteres necessários.