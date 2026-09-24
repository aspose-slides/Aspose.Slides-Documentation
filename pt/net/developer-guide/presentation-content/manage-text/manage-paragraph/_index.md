---
title: Gerenciar Parágrafos de Texto do PowerPoint em .NET
linktitle: Gerenciar Parágrafo
type: docs
weight: 40
url: /pt/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- adicionar texto
- adicionar parágrafo
- gerenciar texto
- gerenciar parágrafo
- gerenciar marcador
- recuo de parágrafo
- recuo suspenso
- marcador de parágrafo
- lista numerada
- lista com marcadores
- propriedades do parágrafo
- importar HTML
- texto para HTML
- parágrafo para HTML
- parágrafo para imagem
- texto para imagem
- exportar parágrafo
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como criar e formatar parágrafos, trechos, marcadores, listas numeradas, recuos, conteúdo HTML e imagens de parágrafos com Aspose.Slides para .NET."
---
## **Visão geral**

Aspose.Slides for .NET representa o texto como uma hierarquia de quadros de texto, parágrafos e trechos:

* [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) representa o contêiner de texto em uma forma e fornece acesso à sua coleção de parágrafos.
* [IParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/) representa um único parágrafo em um quadro de texto e fornece acesso aos seus trechos e à formatação ao nível do parágrafo.
* [IPortion](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/) representa uma sequência de texto dentro de um parágrafo. Cada trecho pode ter seu próprio texto e formatação ao nível de caractere.

Um parágrafo, portanto, pode conter texto com diferentes fontes, cores, tamanhos e outras formatações usando vários trechos.

## **Criar e formatar parágrafos**

### **Criar parágrafos com múltiplos trechos**

Os passos a seguir criam um quadro de texto com três parágrafos, cada um contendo três trechos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Acesse a referência do slide relevante pelo seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) retangular ao slide.
4. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) da forma.
5. Use o parágrafo padrão e adicione mais dois objetos [IParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/) ao quadro de texto.
6. Adicione objetos [IPortion](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/) suficientes para que cada parágrafo contenha três trechos. O parágrafo padrão já contém um trecho vazio.
7. Defina o texto de cada trecho.
8. Aplique formatação ao nível de caractere através de [IPortion.PortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/portionformat/).
9. Salve a apresentação modificada.

Este exemplo em C# implementa as etapas:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **Criar listas com marcadores e numeração**

### **Criar uma lista com marcadores ou numeração**

Marcadores e numeração facilitam a leitura de itens relacionados. No Aspose.Slides, as configurações de lista são definidas através de [IBulletFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/).

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Acesse a referência do slide relevante pelo seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide selecionado.
4. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) da forma.
5. Remova o parágrafo padrão do quadro de texto.
6. Crie um [Paragraph](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraph/) para um marcador de símbolo.
7. Defina [IBulletFormat.Type](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/type/) como [BulletType.Symbol](https://reference.aspose.com/slides/pt/net/aspose.slides/bullettype/) e especifique o caractere do marcador.
8. Defina o texto do parágrafo, recuo, cor do marcador e altura do marcador.
9. Adicione o parágrafo ao quadro de texto.
10. Crie um segundo parágrafo e defina [IBulletFormat.Type](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/type/) como [BulletType.Numbered](https://reference.aspose.com/slides/pt/net/aspose.slides/bullettype/).
11. Configure o estilo de marcador numerado e adicione o parágrafo ao quadro de texto.
12. Salve a apresentação.

Este exemplo em C# cria um marcador de símbolo e um marcador numerado:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **Usar marcadores de imagem**

Marcadores de imagem permitem usar uma imagem personalizada em vez de um símbolo ou número.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Acesse a referência do slide relevante pelo seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) e acesse seu [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/).
4. Remova o parágrafo padrão do quadro de texto.
5. Carregue a imagem do marcador e adicione-a à coleção de imagens da apresentação como um [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/).
6. Crie um [Paragraph](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraph/) e defina seu texto.
7. Defina [IBulletFormat.Type](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/type/) como [BulletType.Picture](https://reference.aspose.com/slides/pt/net/aspose.slides/bullettype/).
8. Atribua a imagem através de [IBulletFormat.Picture](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/picture/) e defina a altura do marcador.
9. Adicione o parágrafo ao quadro de texto.
10. Salve a apresentação modificada.

Este exemplo em C# cria um marcador de imagem:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **Criar uma lista multinível**

Defina [IParagraphFormat.Depth](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/depth/) para posicionar parágrafos em diferentes níveis de uma lista. O nível superior tem profundidade `0`.

1. Crie uma [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e acesse um slide.
2. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) e limpe o parágrafo padrão do seu quadro de texto.
3. Crie quatro parágrafos e configure seus símbolos de marcador.
4. Defina seus valores de [IParagraphFormat.Depth](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/depth/) como `0`, `1`, `2` e `3`.
5. Adicione os parágrafos ao quadro de texto e salve a apresentação.

Este exemplo em C# cria uma lista de marcadores com quatro níveis:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **Iniciar itens de lista numerada com valores personalizados**

Use [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/numberedbulletstartwith/) para definir o número inicial exibido para um parágrafo numerado.

1. Crie uma [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) a um slide.
2. Limpe o parágrafo padrão do quadro de texto da forma.
3. Crie três parágrafos numerados.
4. Defina [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/pt/net/aspose.slides/ibulletformat/numberedbulletstartwith/) como `2`, `3` e `7` para os respectivos parágrafos.
5. Adicione os parágrafos ao quadro de texto e salve a apresentação.

Este exemplo em C# atribui um número inicial personalizado a cada parágrafo:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **Controlar layout e propriedades de fim do parágrafo**

### **Definir recuo da primeira linha**

Use a propriedade [IParagraphFormat.Indent](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/indent/) para controlar o recuo da primeira linha de um parágrafo. Essa propriedade move apenas a primeira linha em relação à margem esquerda do parágrafo. Um valor positivo desloca a primeira linha para a direita, enquanto as linhas restantes permanecem alinhadas ao corpo do parágrafo.

Use [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/marginleft/) quando precisar mover todo o parágrafo. Use [IParagraphFormat.Indent](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/indent/) quando precisar mover apenas a primeira linha.

O exemplo abaixo cria vários parágrafos e aplica valores diferentes de [IParagraphFormat.Indent](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/indent/) para demonstrar como o recuo da primeira linha afeta o layout do parágrafo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) .
2. Acesse o slide de destino.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) retangular ao slide.
4. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) da forma e remova o parágrafo padrão.
5. Crie vários parágrafos e defina valores diferentes de [Indent](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/indent/) para eles.
6. Adicione os parágrafos ao quadro de texto.
7. Salve a apresentação modificada.

Este código mostra como definir o recuo de um parágrafo:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

O resultado:

![A indentação da primeira linha dos parágrafos](first_line_indent.png)

### **Definir recuo suspenso**

Um recuo suspenso é um layout de parágrafo em que a primeira linha começa à esquerda das linhas restantes. No Aspose.Slides, cria‑se esse efeito com a propriedade [IParagraphFormat.Indent](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/indent/). Defina `Indent` com um valor negativo para mover a primeira linha para a esquerda em relação ao corpo do parágrafo.

Na prática, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/marginleft/) define a posição esquerda do corpo do parágrafo, e [IParagraphFormat.Indent](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/indent/) define a posição da primeira linha em relação a essa margem. Para criar um recuo suspenso, defina um valor positivo em `MarginLeft` e um valor negativo em `Indent`.

Essa formatação é útil para bibliografias, referências, entradas de glossário e outros parágrafos onde linhas quebradas precisam alinhar‑se ao corpo do parágrafo em vez ao primeiro caractere da primeira linha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) .
2. Acesse o slide de destino.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) retangular ao slide.
4. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) da forma e remova o parágrafo padrão.
5. Crie parágrafos e defina um valor positivo de [MarginLeft](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/marginleft/) para cada parágrafo.
6. Defina um valor negativo de [Indent](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/indent/) para criar o efeito de recuo suspenso.
7. Adicione os parágrafos ao quadro de texto.
8. Salve a apresentação modificada.

Este código mostra como definir um recuo suspenso para um parágrafo:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

O resultado:

![O recuo suspenso dos parágrafos](hanging_indent.png)

### **Definir propriedades de execução do final do parágrafo**

A propriedade [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/endparagraphportionformat/) controla a formatação da marca de final do parágrafo. O exemplo a seguir atribui tamanho de fonte e fonte latina à marca de final do segundo parágrafo:

1. Carregue uma [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e acesse um slide.
2. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) e limpe seu parágrafo padrão.
3. Crie dois parágrafos e adicione trechos de texto a eles.
4. Crie um [PortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/portionformat/) para a marca de final do segundo parágrafo.
5. Defina [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseportionformat/fontheight/) e [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseportionformat/latinfont/).
6. Atribua o formato a [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/endparagraphportionformat/) e salve a apresentação.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **Contar linhas renderizadas**

Use [IParagraph.GetLinesCount](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/getlinescount/) para contar as linhas ocupadas por um parágrafo após o layout do texto, incluindo a quebra automática. Isso é útil ao verificar o comprimento e o layout do texto em modelos de apresentação.

Um parágrafo é um item em [ITextFrame.Paragraphs](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/paragraphs/), e pode ocupar várias linhas renderizadas. Uma quebra de linha explícita dentro de um parágrafo força uma nova linha sem criar outro parágrafo. A quebra automática cria linhas com base na largura disponível sem inserir quebras explícitas no texto. Portanto, contar parágrafos ou caracteres de quebra de linha não fornece a contagem de linhas renderizadas.

O exemplo a seguir cria uma forma de texto, conta suas linhas, estreita a forma e então substitui o texto por uma string mais curta. A quebra automática está ativada e o ajuste automático está desativado para que a largura da forma controle a quebra sem reduzir automaticamente o texto ou redimensionar a forma. As dimensões da forma são em pontos. Por fim, o exemplo adiciona outro parágrafo e soma as contagens de linhas em todo o quadro de texto.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

Com esse texto e essas dimensões, estreitar a forma aumenta a contagem de linhas, enquanto substituir o texto pela string curta a reduz. Contagens exatas podem variar com a disponibilidade de fontes e substituição, tamanho da fonte, margens, recuo, quebra automática e configurações de ajuste automático. Use as fontes e configurações de layout previstas para o ambiente de destino ao validar um modelo.

A contagem de linhas por si só não determina se o texto excede seu contêiner. A altura disponível, alturas das linhas, espaçamento de parágrafos e linhas, e o comportamento de ajuste automático também são importantes; mesmo uma única linha pode ultrapassar a largura disponível quando a quebra automática está desativada.

## **Importar e exportar conteúdo de parágrafos**

### **Importar texto HTML para parágrafos**

Use [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraphcollection/addfromhtml/) para converter marcação HTML em parágrafos e trechos em um quadro de texto.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) .
2. Acesse um slide e adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) .
3. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) da forma e limpe seu parágrafo padrão.
4. Leia o arquivo HTML de origem.
5. Passe a string HTML para [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraphcollection/addfromhtml/) .
6. Salve a apresentação modificada.

Este exemplo em C# importa HTML para um quadro de texto:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **Exportar texto de parágrafo para HTML**

Use [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraphcollection/exporttohtml/) para exportar um intervalo selecionado de parágrafos como HTML.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) e carregue a apresentação desejada.
2. Acesse o slide e encontre o [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) que contém o texto.
3. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) da forma.
4. Chame [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraphcollection/exporttohtml/) passando o índice do parágrafo inicial e o número de parágrafos a exportar.
5. Grave a string HTML retornada em um arquivo.

Este exemplo em C# exporta todos os parágrafos da primeira forma de texto:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **Renderizar um parágrafo como imagem**

[IParagraph.GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/getimage/) renderiza um parágrafo individualmente e retorna um [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/). Salve o resultado em um arquivo ou fluxo com [IImage.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/save/). Não é necessário renderizar a forma que contém o parágrafo ou recortar manualmente um bitmap.

[IParagraph.GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/getimage/) pode retornar `null` se o parágrafo não for encontrado na coleção pai, não possuir limites de renderização válidos ou não puder ser renderizado. Verifique o resultado antes de salvá‑lo e libere a imagem retornada após o uso.

#### **Renderizar um parágrafo na escala padrão**

Suponha que temos um arquivo de apresentação chamado sample.pptx com um slide, onde a primeira forma é uma caixa de texto contendo três parágrafos.

![A caixa de texto com três parágrafos](paragraph_to_image_input.png)

O exemplo a seguir renderiza o segundo parágrafo em uma forma de texto regular na escala padrão e salva a imagem retornada em formato PNG. A declaração `using` garante que a imagem seja descartada corretamente.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

O resultado:

![A imagem do parágrafo](paragraph_to_image_output.png)

#### **Renderizar um parágrafo em célula de tabela com escala**

Use a sobrecarga de [IParagraph.GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/getimage/) que aceita os parâmetros `float scaleX` e `float scaleY` para definir os fatores de escala horizontal e vertical. O exemplo a seguir cria uma tabela, renderiza o parágrafo em sua primeira célula com o dobro da largura e altura padrão e salva o resultado como imagem PNG.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

Um fator de escala `1` mantém esse eixo no tamanho padrão de pixel. Por exemplo, `2` para ambos os fatores produz uma imagem cuja largura e altura são aproximadamente duas vezes as dimensões padrão, resultando em quatro vezes mais pixels. Fatores maiores geralmente produzem texto mais nítido para zoom ou saída de alta resolução, mas também aumentam o uso de memória e o tamanho do arquivo. Fatores abaixo de `1` produzem imagens menores com menos detalhes. Use fatores iguais para preservar a proporção do parágrafo; fatores horizontais e verticais diferentes esticam a saída independentemente.

Renderizar uma forma inteira com [IShape.GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/getimage/) continua útil quando a saída deve incluir o preenchimento, borda ou outro contexto visual da forma. Para uma imagem apenas do parágrafo, use [IParagraph.GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/getimage/) .

## **FAQ**

**Posso desativar completamente a quebra automática de linha dentro de um quadro de texto?**

Sim. Defina [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/wraptext/) para desativar a quebra, de modo que as linhas não se quebrem nas bordas do quadro de texto.

**Como obter os limites exatos de um parágrafo específico no slide?**

Use [IParagraph.GetRect](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/getrect/) para recuperar o retângulo delimitador do parágrafo. [IPortion.GetRect](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/getrect/) fornece os limites de um trecho individual.

**Onde é controlado o alinhamento do parágrafo (esquerda, direita, centralizado ou justificado)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/alignment/) é uma configuração ao nível do parágrafo e se aplica a todo o parágrafo, independentemente da formatação individual dos trechos.

**Posso definir o idioma de revisão para parte de um parágrafo?**

Sim. Defina [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseportionformat/languageid/) para trechos individuais, permitindo que um parágrafo contenha texto em vários idiomas.