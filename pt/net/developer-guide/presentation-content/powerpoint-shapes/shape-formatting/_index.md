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
- preenchimento gradiente
- preenchimento de padrão
- preenchimento de imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência de forma
- renderização de forma em preto e branco
- renderização de forma em escala de cinza
- rotacionar forma
- efeito de chanfrado 3D
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

Em PowerPoint, você pode adicionar formas aos slides. Como as formas são compostas por linhas, você pode formatá‑las modificando ou aplicando efeitos aos seus contornos. Além disso, você pode formatar formas especificando configurações que controlam como seus interiores são preenchidos.

![Formato da forma no PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for .NET fornece interfaces e propriedades que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar linhas**

Usando Aspose.Slides, você pode especificar um estilo de linha personalizado para uma forma. As etapas a seguir descrevem o procedimento:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ao slide.
1. Defina o [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) da forma.
1. Defina a largura da linha.
1. Defina o [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) da linha.
1. Defina a cor da linha para a forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código C# a seguir demonstra como formatar um `AutoShape` retangular:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancia a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Obtém o primeiro slide.
    ISlide slide = presentation.Slides[0];

    // Adiciona uma forma automática do tipo Retângulo.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Define a cor de preenchimento para a forma retangular.
    shape.FillFormat.FillType = FillType.NoFill;

    // Aplica formatação às linhas do retângulo.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Define a cor da linha do retângulo.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Salva o arquivo PPTX no disco.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

O resultado:

![Linhas formatadas na apresentação](formatted-lines.png)

## **Aplicar efeitos de esboço às linhas da forma**

Um efeito de esboço faz com que a linha da forma pareça desenhada à mão. Use [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) para acessar as configurações da linha, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) para acessar as configurações de esboço e [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) para selecionar um valor da enumeração [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

O código C# a seguir mostra como aplicar o efeito [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/), ler o valor atribuído explicitamente e remover o efeito com [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

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

O valor retornado por `ISketchFormat.SketchType` representa a configuração atribuída diretamente à forma. Se a formatação da linha puder ser herdada de um tema, slide mestre ou slide de layout, use [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), acesse [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) e leia [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). O valor efetivo reflete a formatação realmente aplicada após a resolução da herança:

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

* Round
* Miter
* Bevel

Por padrão, quando o PowerPoint une duas linhas em um ângulo (como em um canto de forma), ele usa a configuração **Round**. Entretanto, se você estiver desenhando uma forma com ângulos agudos, pode preferir a opção **Miter**.

![Estilo de junção na apresentação](join-style-powerpoint.png)

O código C# a seguir demonstra como três retângulos (conforme a imagem acima) foram criados usando as configurações de tipo de junção Miter, Bevel e Round:

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

    // Definir a cor de preenchimento para cada forma retangular.
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

## **Preenchimento gradiente**

No PowerPoint, Preenchimento Gradiente é uma opção de formatação que permite aplicar uma mescla contínua de cores a uma forma. Por exemplo, você pode aplicar duas ou mais cores de modo que uma gradualmente desapareça na outra.

Veja como aplicar um preenchimento gradiente a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) da forma como `Gradient`.
1. Adicione suas duas cores preferidas com posições definidas usando os métodos `Add` da coleção de parada de gradiente exposta pela interface [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/).
1. Salve a apresentação modificada como um arquivo PPTX.

O código C# a seguir demonstra como aplicar um efeito de preenchimento gradiente a uma elipse:

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

    // Aplicar formatação de gradiente à elipse.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Definir a direção do gradiente.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Adicionar duas paradas de gradiente.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Salvar o arquivo PPTX no disco.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

O resultado:

![Elipse com preenchimento gradiente](gradient-fill.png)

Se um gradiente parecer diferente em uma imagem exportada em comparação ao PowerPoint, veja [Choose a Gradient Rendering Style](/slides/pt/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Você pode selecionar um estilo de renderização sem alterar o preenchimento gradiente armazenado na apresentação.

## **Preenchimento de padrão**

No PowerPoint, Preenchimento de Padrão é uma opção de formatação que permite aplicar um design de duas cores — como pontos, listras, cruzes ou xadrez — a uma forma. Você pode escolher cores personalizadas para o primeiro plano e fundo do padrão.

Aspose.Slides oferece mais de 45 estilos de padrão predefinidos que podem ser aplicados a formas para melhorar o apelo visual de suas apresentações. Mesmo após selecionar um padrão predefinido, ainda é possível especificar as cores exatas a serem usadas.

Veja como aplicar um preenchimento de padrão a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) da forma como `Pattern`.
1. Escolha um estilo de padrão entre as opções predefinidas.
1. Defina a [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) do padrão.
1. Defina a [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) do padrão.
1. Salve a apresentação modificada como um arquivo PPTX.

O código C# a seguir demonstra como aplicar um preenchimento de padrão a um retângulo:

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

    // Definir as cores de fundo e do primeiro plano do padrão.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Salvar o arquivo PPTX no disco.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

O resultado:

![Retângulo com preenchimento de padrão](pattern-fill.png)

## **Preenchimento de imagem**

No PowerPoint, Preenchimento de Imagem é uma opção de formatação que permite inserir uma imagem dentro de uma forma — efetivamente usando a imagem como plano de fundo da forma.

Veja como usar Aspose.Slides para aplicar um preenchimento de imagem a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) da forma como `Picture`.
1. Defina o modo de preenchimento de imagem como `Tile` (ou outro modo preferido).
1. Crie um objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) a partir da imagem que deseja usar.
1. Atribua esta imagem à propriedade `Picture.Image` do `PictureFillFormat` da forma.
1. Salve a apresentação modificada como um arquivo PPTX.

Suponha que temos um arquivo "lotus.png" com a seguinte imagem:

![A imagem do lótus](lotus.png)

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

    // Definir o tipo de preenchimento como Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Definir o modo de preenchimento de imagem.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Carregar uma imagem e adicioná‑la aos recursos da apresentação.
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

![Forma com preenchimento de imagem](picture-fill.png)

### **Imagem em azulejo como textura**

Se você quiser definir uma imagem em azulejo como textura e personalizar o comportamento do mosaico, pode usar as seguintes propriedades da interface [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) e da classe [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Define o modo de preenchimento da imagem — `Tile` ou `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Especifica o alinhamento dos azulejos dentro da forma.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Controla se o azulejo é invertido horizontalmente, verticalmente ou ambos.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Define o deslocamento horizontal do azulejo (em pontos) a partir da origem da forma.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Define o deslocamento vertical do azulejo (em pontos) a partir da origem da forma.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Define a escala horizontal do azulejo como porcentagem.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Define a escala vertical do azulejo como porcentagem.

O exemplo de código a seguir mostra como adicionar uma forma retangular com preenchimento de imagem em azulejo e configurar as opções de azulejo:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation())
{
    // Obter o primeiro slide.
    ISlide firstSlide = presentation.Slides[0];

    // Adicionar uma forma automática retangular.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Definir o tipo de preenchimento da forma como Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Carregar a imagem e adicioná-la aos recursos da apresentação.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Atribuir a imagem à forma.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Configurar o modo de preenchimento de imagem e as propriedades de mosaico.
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

![Opções de azulejo](tile-options.png)

## **Preenchimento de cor sólida**

No PowerPoint, Preenchimento de Cor Sólida é uma opção de formatação que preenche uma forma com uma única cor uniforme. Esse fundo simples é aplicado sem gradientes, texturas ou padrões.

Para aplicar um preenchimento de cor sólida a uma forma usando Aspose.Slides, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) da forma como `Solid`.
1. Atribua a cor de preenchimento desejada à forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código C# a seguir demonstra como aplicar um preenchimento de cor sólida a um retângulo em um slide do PowerPoint:

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

    // Definir o tipo de preenchimento como Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Definir a cor de preenchimento.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Salvar o arquivo PPTX no disco.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

O resultado:

![Forma com preenchimento de cor sólida](solid-color-fill.png)

## **Definir transparência**

No PowerPoint, ao aplicar um preenchimento sólido, gradiente, imagem ou textura a formas, você também pode definir um nível de transparência para controlar a opacidade do preenchimento. Um valor de transparência mais alto torna a forma mais translúcida, permitindo que o fundo ou objetos subjacentes sejam parcialmente visíveis.

Aspose.Slides permite definir o nível de transparência ajustando o valor alfa da cor usada no preenchimento. Veja como fazer isso:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) como `Solid`.
1. Use `Color.FromArgb(alpha, baseColor)` para definir uma cor com transparência (o componente `alpha` controla a transparência).
1. Salve a apresentação.

O código C# a seguir demonstra como aplicar uma cor de preenchimento transparente a um retângulo:

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

    // Adicionar uma forma automática retangular sólida.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Adicionar uma forma automática retangular transparente sobre a forma sólida.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Salvar o arquivo PPTX no disco.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

O resultado:

![Forma transparente](shape-transparency.png)

## **Rotacionar formas**

Aspose.Slides permite rotacionar formas em apresentações do PowerPoint. Isso pode ser útil ao posicionar elementos visuais com necessidades específicas de alinhamento ou design.

Para rotacionar uma forma em um slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ao slide.
1. Defina a propriedade `Rotation` da forma para o ângulo desejado.
1. Salve a apresentação.

O código C# a seguir demonstra como rotacionar uma forma em 5 graus:

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

![Rotação da forma](shape-rotation.png)

## **Adicionar efeitos de chanfrado 3D**

Aspose.Slides permite aplicar efeitos de chanfrado 3D a formas configurando as propriedades do [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

Para adicionar efeitos de chanfrado 3D a uma forma, siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ao slide.
1. Configure o [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) da forma para definir as configurações de chanfrado.
1. Salve a apresentação.

O código C# a seguir mostra como aplicar efeitos de chanfrado 3D a uma forma:

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

![Efeito de chanfrado 3D](3D-bevel-effect.png)

## **Adicionar efeitos de rotação 3D**

Aspose.Slides permite aplicar efeitos de rotação 3D a formas configurando as propriedades do [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

Para aplicar rotação 3D a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ao slide.
1. Defina o [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) e o [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) da forma para definir a rotação 3D.
1. Salve a apresentação.

O código C# a seguir demonstra como aplicar efeitos de rotação 3D a uma forma:

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

![Efeito de rotação 3D](3D-rotation-effect.png)

## **Controlar renderização em preto e branco para formas**

A propriedade [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) especifica como uma forma individual é renderizada quando uma apresentação é visualizada ou processada em modo preto e branco. Ela não habilita a exibição em preto e branco por si só e não altera o preenchimento, linha ou outra formatação da forma em modo de cor normal.

Use um valor da enumeração [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) para selecionar o comportamento desejado. Por exemplo, `Automatic` deixa o aplicativo de renderização escolher a conversão, `Gray` e `LightGray` utilizam coloração cinza, `BlackWhite` usa apenas preto e branco, `Black` e `White` forçam uma única cor, `Color` preserva a coloração normal e `Hidden` omite a forma no modo preto e branco. `NotDefined` indica que nenhum modo está atribuído ao nível da forma.

O código C# a seguir cria uma forma colorida e faz com que ela apareça cinza no modo de exibição preto e branco:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Manter o preenchimento laranja no modo colorido, mas renderizar a forma com coloração cinza no modo preto e branco.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Em modo de cor normal, o retângulo mantém seu preenchimento laranja. Em um fluxo de trabalho de exibição preto e branco, ele usa coloração cinza porque seu modo está definido como `Gray`. Isso permite que você preserve um slide em cores completas ao definir uma aparência distinta para impressão, visualização ou outros fluxos que respeitam as configurações de exibição em preto e branco da apresentação.

## **Redefinir formatação**

O código C# a seguir mostra como redefinir a formatação de um slide e restaurar a posição, tamanho e formatação de todas as formas com marcadores no [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) para suas configurações padrão:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Redefinir cada forma no slide que possui um placeholder no layout.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**A formatação de formas afeta o tamanho final do arquivo da apresentação?**

Apenas minimamente. Imagens e mídia incorporadas ocupam a maior parte do espaço do arquivo, enquanto parâmetros de forma como cores, efeitos e gradientes são armazenados como metadados e praticamente não aumentam o tamanho.

**Como posso detectar formas em um slide que compartilham formatação idêntica para agrupá‑las?**

Compare as principais propriedades de formatação de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, considere os estilos como idênticos e agrupe logicamente essas formas, o que simplifica o gerenciamento de estilos posteriormente.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilização em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um slide mestre de modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas necessárias e reaplique sua formatação onde for preciso.