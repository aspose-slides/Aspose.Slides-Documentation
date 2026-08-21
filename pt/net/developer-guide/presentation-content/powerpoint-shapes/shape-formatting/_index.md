---
title: Formatar formas do PowerPoint em .NET
linktitle: Formatação de Forma
type: docs
weight: 20
url: /pt/net/shape-formatting/
keywords:
- formatar forma
- formatar linha
- efeito de esboço
- linha de forma esboçada
- formatar estilo de junção
- preenchimento degradê
- preenchimento de padrão
- preenchimento com imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência da forma
- renderização de forma em preto e branco
- renderização de forma em tons de cinza
- rotacionar forma
- efeito de chanframento 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a formatar formas do PowerPoint em C# usando Aspose.Slides — defina estilos de preenchimento, linha e efeito para arquivos PPT e PPTX com precisão e controle total."
---
## **Introdução**

No PowerPoint, você pode adicionar formas aos slides. Como as formas são compostas por linhas, você pode formatá‑las modificando ou aplicando efeitos aos seus contornos. Além disso, você pode formatar as formas especificando configurações que controlam como seus interiores são preenchidos.

![Formato de forma no PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for .NET fornece interfaces e propriedades que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar linhas**

Usando Aspose.Slides, você pode especificar um estilo de linha personalizado para uma forma. As etapas a seguir descrevem o procedimento:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
4. Defina o [line style](https://reference.aspose.com/slides/pt/net/aspose.slides/linestyle/) da forma.
5. Defina a espessura da linha.
6. Defina o [dash style](https://reference.aspose.com/slides/pt/net/aspose.slides/linedashstyle/) da linha.
7. Defina a cor da linha para a forma.
8. Salve a apresentação modificada como um arquivo PPTX.

O código C# a seguir demonstra como formatar um `AutoShape` retângulo:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Obter o primeiro slide.
    ISlide slide = presentation.Slides[0];

    // Adicionar uma forma automática do tipo Retângulo.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Definir a cor de preenchimento para a forma retângulo.
    shape.FillFormat.FillType = FillType.NoFill;

    // Aplicar formatação às linhas do retângulo.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Definir a cor da linha do retângulo.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Salvar o arquivo PPTX no disco.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

O resultado:

![As linhas formatadas na apresentação](formatted-lines.png)

## **Aplicar efeitos de esboço às linhas da forma**

Um efeito de esboço faz com que a linha de uma forma pareça desenhada à mão. Use [IShape.LineFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/lineformat/) para acessar as configurações de linha, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ilineformat/sketchformat/) para acessar as configurações de esboço e [ISketchFormat.SketchType](https://reference.aspose.com/slides/pt/net/aspose.slides/isketchformat/sketchtype/) para selecionar um valor da enumeração [LineSketchType](https://reference.aspose.com/slides/pt/net/aspose.slides/linesketchtype/).

O código C# a seguir mostra como aplicar o efeito [LineSketchType.Curved](https://reference.aspose.com/slides/pt/net/aspose.slides/linesketchtype/) , ler o valor atribuído explicitamente e remover o efeito com [LineSketchType.None](https://reference.aspose.com/slides/pt/net/aspose.slides/linesketchtype/):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

O valor retornado por `ISketchFormat.SketchType` representa a configuração atribuída diretamente à forma. Se a formatação da linha puder ser herdada de um tema, slide mestre ou slide de layout, use [ILineFormat.GetEffective](https://reference.aspose.com/slides/pt/net/aspose.slides/ilineformat/geteffective/), acesse [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ilineformateffectivedata/sketchformat/), e leia [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/pt/net/aspose.slides/isketchformateffectivedata/sketchtype/). O valor efetivo reflete a formatação que realmente é aplicada após a resolução da herança:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Formatar estilos de junção**

Aqui estão as três opções de tipo de junção:

* Arredondado
* Bisel
* Chanfrado

Por padrão, quando o PowerPoint une duas linhas em um ângulo (como no canto de uma forma), ele usa a configuração **Arredondado**. No entanto, se você estiver desenhando uma forma com ângulos agudos, pode preferir a opção **Bisel**.

![O estilo de junção na apresentação](join-style-powerpoint.png)

O código C# a seguir demonstra como três retângulos (conforme mostrados na imagem acima) foram criados usando as configurações de tipo de junção Bisel, Chanfrado e Arredondado:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Obter o primeiro slide.
    ISlide slide = presentation.Slides[0];

    // Adicionar três formas automáticas do tipo Retângulo.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Definir a cor de preenchimento para cada forma retângulo.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Definir a largura da linha.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Definir a cor da linha de cada retângulo.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Definir o estilo de junção.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Adicionar texto a cada retângulo.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Salvar o arquivo PPTX no disco.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Preenchimento degradê**

No PowerPoint, Preenchimento degradê é uma opção de formatação que permite aplicar uma mistura contínua de cores a uma forma. Por exemplo, você pode aplicar duas ou mais cores de modo que uma se desvaneça gradualmente na outra.

Veja como aplicar um preenchimento degradê a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
4. Defina o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) da forma para `Gradient`.
5. Adicione as duas cores preferidas com posições definidas usando os métodos `Add` da coleção de paradas de degradê exposta pela interface [IGradientFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/igradientformat/).
6. Salve a apresentação modificada como um arquivo PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Obter o primeiro slide.
    ISlide slide = presentation.Slides[0];

    // Adicionar uma forma automática do tipo Elipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplicar formatação de degradê à elipse.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Definir a direção do degradê.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Adicionar duas paradas de degradê.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Salvar o arquivo PPTX no disco.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

![A elipse com preenchimento degradê](gradient-fill.png)

## **Preenchimento de padrão**

No PowerPoint, Preenchimento de padrão é uma opção de formatação que permite aplicar um design de duas cores — como pontos, listras, xadrez ou checagens — a uma forma. Você pode escolher cores personalizadas para o primeiro plano e o plano de fundo do padrão.

O Aspose.Slides oferece mais de 45 estilos de padrão predefinidos que você pode aplicar a formas para melhorar o apelo visual de suas apresentações. Mesmo após selecionar um padrão predefinido, você ainda pode especificar as cores exatas que ele deve usar.

Veja como aplicar um preenchimento de padrão a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
4. Defina o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) da forma para `Pattern`.
5. Escolha um estilo de padrão entre as opções predefinidas.
6. Defina a [Background Color](https://reference.aspose.com/slides/pt/net/aspose.slides/ipatternformat/backcolor/) do padrão.
7. Defina a [Foreground Color](https://reference.aspose.com/slides/pt/net/aspose.slides/ipatternformat/forecolor/) do padrão.
8. Salve a apresentação modificada como um arquivo PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Obter o primeiro slide.
    ISlide slide = presentation.Slides[0];

    // Adicionar uma forma automática do tipo Retângulo.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Definir o tipo de preenchimento como Padrão.
    shape.FillFormat.FillType = FillType.Pattern;

    // Definir o estilo de padrão.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Definir as cores de fundo e de primeiro plano do padrão.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Salvar o arquivo PPTX no disco.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

![O retângulo com preenchimento de padrão](pattern-fill.png)

## **Preenchimento com imagem**

No PowerPoint, Preenchimento com imagem é uma opção de formatação que permite inserir uma imagem dentro de uma forma — usando efetivamente a imagem como fundo da forma.

Veja como usar Aspose.Slides para aplicar um preenchimento com imagem a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
4. Defina o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) da forma para `Picture`.
5. Defina o modo de preenchimento de imagem para `Tile` (ou outro modo preferido).
6. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) a partir da imagem que deseja usar.
7. Atribua essa imagem à propriedade `Picture.Image` do `PictureFillFormat` da forma.
8. Salve a apresentação modificada como um arquivo PPTX.

Suponha que tenhamos um arquivo "lotus.png" com a seguinte imagem:

![A imagem lotus](lotus.png)

O código C# a seguir demonstra como preencher uma forma com a imagem:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Obter o primeiro slide.
    ISlide slide = presentation.Slides[0];

    // Adicionar uma forma automática do tipo Retângulo.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Definir o tipo de preenchimento como Imagem.
    shape.FillFormat.FillType = FillType.Picture;

    // Definir o modo de preenchimento da imagem.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Carregar uma imagem e adicioná-la aos recursos da apresentação.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Definir a imagem.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Salvar o arquivo PPTX no disco.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

O resultado:

![A forma com preenchimento com imagem](picture-fill.png)

### **Imagem em mosaico como textura**

Se você quiser definir uma imagem em mosaico como textura e personalizar o comportamento de mosaico, pode usar as seguintes propriedades da interface [IPictureFillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/) e da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/picturefillmode/): Define o modo de preenchimento da imagem — `Tile` ou `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/tilealignment/): Especifica o alinhamento das telhas dentro da forma.
- [TileFlip](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/tileflip/): Controla se a telha é invertida horizontalmente, verticalmente ou ambas.
- [TileOffsetX](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/tileoffsetx/): Define o deslocamento horizontal da telha (em pontos) a partir da origem da forma.
- [TileOffsetY](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/tileoffsety/): Define o deslocamento vertical da telha (em pontos) a partir da origem da forma.
- [TileScaleX](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/tilescalex/): Define a escala horizontal da telha como porcentagem.
- [TileScaleY](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/tilescaley/): Define a escala vertical da telha como porcentagem.

O exemplo de código a seguir mostra como adicionar uma forma retângulo com preenchimento de imagem em mosaico e configurar as opções de telha:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Obter o primeiro slide.
    ISlide firstSlide = presentation.Slides[0];

    // Adicionar uma forma automática retângulo.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Definir o tipo de preenchimento da forma como Imagem.
    shape.FillFormat.FillType = FillType.Picture;

    // Carregar a imagem e adicioná‑la aos recursos da apresentação.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Atribuir a imagem à forma.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Configurar o modo de preenchimento da imagem e as propriedades de mosaico.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Salvar o arquivo PPTX no disco.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

O resultado:

![As opções de mosaico](tile-options.png)

## **Preenchimento de cor sólida**

No PowerPoint, Preenchimento de cor sólida é uma opção de formatação que preenche uma forma com uma única cor uniforme. Essa cor de fundo simples é aplicada sem gradientes, texturas ou padrões.

Para aplicar um preenchimento de cor sólida a uma forma usando Aspose.Slides, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
4. Defina o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) da forma para `Solid`.
5. Atribua a cor de preenchimento desejada à forma.
6. Salve a apresentação modificada como um arquivo PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Obter o primeiro slide.
    ISlide slide = presentation.Slides[0];

    // Adicionar uma forma automática do tipo Retângulo.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Definir o tipo de preenchimento como Sólido.
    shape.FillFormat.FillType = FillType.Solid;

    // Definir a cor de preenchimento.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Salvar o arquivo PPTX no disco.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

O resultado:

![A forma com preenchimento de cor sólida](solid-color-fill.png)

## **Definir transparência**

No PowerPoint, ao aplicar um preenchimento de cor sólida, degradê, imagem ou textura em formas, você também pode definir um nível de transparência para controlar a opacidade do preenchimento. Um valor de transparência mais alto deixa a forma mais translúcida, permitindo que o plano de fundo ou objetos subjacentes sejam parcialmente visíveis.

O Aspose.Slides permite definir o nível de transparência ajustando o valor alfa na cor usada para o preenchimento. Veja como fazer isso:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
4. Defina o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) para `Solid`.
5. Use `Color.FromArgb(alpha, baseColor)` para definir uma cor com transparência (o componente `alpha` controla a transparência).
6. Salve a apresentação.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Obter o primeiro slide.
    ISlide slide = presentation.Slides[0];

    // Adicionar uma forma automática retângulo sólida.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Adicionar uma forma automática retângulo transparente sobre a forma sólida.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Salvar o arquivo PPTX no disco.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

O resultado:

![A forma transparente](shape-transparency.png)

## **Rotacionar formas**

O Aspose.Slides permite rotacionar formas em apresentações PowerPoint. Isso pode ser útil ao posicionar elementos visuais com necessidades específicas de alinhamento ou design.

Para rotacionar uma forma em um slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
4. Defina a propriedade `Rotation` da forma para o ângulo desejado.
5. Salve a apresentação.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Obter o primeiro slide.
    ISlide slide = presentation.Slides[0];

    // Adicionar uma forma automática do tipo Retângulo.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotacionar a forma em 5 graus.
    shape.Rotation = 5;

    // Salvar o arquivo PPTX no disco.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

O resultado:

![A rotação da forma](shape-rotation.png)

## **Adicionar efeitos de chanframento 3D**

O Aspose.Slides permite aplicar efeitos de chanframento 3D a formas configurando suas propriedades [ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/threedformat/).

Para adicionar efeitos de chanframento 3D a uma forma, siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
4. Configure o [ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/threedformat/) da forma para definir as configurações de chanframento.
5. Salve a apresentação.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Criar uma instância da classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adicionar uma forma ao slide.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Definir as propriedades ThreeDFormat da forma.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Salvar a apresentação como um arquivo PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

O resultado:

![O efeito de chanframento 3D](3D-bevel-effect.png)

## **Adicionar efeitos de rotação 3D**

O Aspose.Slides permite aplicar efeitos de rotação 3D a formas configurando suas propriedades [ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/threedformat/).

Para aplicar rotação 3D a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
4. Defina o [CameraType](https://reference.aspose.com/slides/pt/net/aspose.slides/icamera/cameratype/) e o [LightType](https://reference.aspose.com/slides/pt/net/aspose.slides/ilightrig/lighttype/) da forma para definir a rotação 3D.
5. Salve a apresentação.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Criar uma instância da classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Salvar a apresentação como um arquivo PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

O resultado:

![O efeito de rotação 3D](3D-rotation-effect.png)

## **Controlar renderização em preto e branco para formas**

A propriedade [IShape.BlackWhiteMode](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/blackwhitemode/) especifica como uma forma individual é renderizada quando uma apresentação é visualizada ou processada em modo preto e branco. Ela não habilita a exibição em preto e branco por si só, e não altera o preenchimento, linha ou outra formatação da forma no modo de cor normal.

Use um valor da enumeração [BlackWhiteMode](https://reference.aspose.com/slides/pt/net/aspose.slides/blackwhitemode/) para selecionar o comportamento desejado. Por exemplo, `Automatic` permite que o aplicativo de renderização escolha a conversão, `Gray` e `LightGray` utilizam coloração em tons de cinza, `BlackWhite` usa apenas preto e branco, `Black` e `White` forçam uma única cor, `Color` preserva a coloração normal e `Hidden` omite a forma no modo preto e branco. `NotDefined` significa que nenhum modo de nível de forma foi atribuído.

O código C# a seguir cria uma forma colorida e faz com que ela apareça cinza no modo de exibição em preto e branco:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Mantenha o preenchimento laranja no modo de cor, mas renderize a forma com coloração cinza no modo preto e branco.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

No modo de cor normal, o retângulo mantém seu preenchimento laranja. Em um fluxo de trabalho de exibição em preto e branco, ele usa coloração cinza porque seu modo está definido como `Gray`. Isso permite que você preserve um slide em cores completas ao definir uma aparência distinta para impressão, visualização ou outros fluxos de trabalho que respeitam as configurações de exibição em preto e branco da apresentação.

## **Redefinir formatação**

O código C# a seguir mostra como redefinir a formatação de um slide e reverter a posição, tamanho e formatação de todas as formas com marcadores de posição no [LayoutSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutslide/) para suas configurações padrão:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Redefinir cada forma no slide que tem um marcador de posição no layout.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**A formatação de forma afeta o tamanho final do arquivo da apresentação?**

Somente minimamente. Imagens e mídia incorporadas ocupam a maior parte do espaço do arquivo, enquanto parâmetros de forma, como cores, efeitos e degradês, são armazenados como metadados e praticamente não aumentam o tamanho.

**Como posso detectar formas em um slide que compartilham formatação idêntica para que eu possa agrupá‑las?**

Compare as principais propriedades de formatação de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, trate seus estilos como idênticos e agrupe logicamente essas formas, o que simplifica a gestão de estilos posteriormente.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilização em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um conjunto de slides modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizáveis necessárias e reaplique sua formatação onde for requerido.