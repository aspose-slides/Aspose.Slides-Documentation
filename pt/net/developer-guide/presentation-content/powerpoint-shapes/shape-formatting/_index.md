---
title: Formatar formas do PowerPoint em .NET
linktitle: Formatação de Formas
type: docs
weight: 20
url: /pt/net/shape-formatting/
keywords:
- formatar forma
- formatar linha
- formatar estilo de junção
- preenchimento em gradiente
- preenchimento de padrão
- preenchimento de imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência da forma
- rotacionar forma
- efeito de bisel 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a formatar formas do PowerPoint em C# usando Aspose.Slides—defina estilos de preenchimento, linha e efeito para arquivos PPT e PPTX com precisão e controle total."
---
## **Introdução**

No PowerPoint, você pode adicionar formas a slides. Como as formas são compostas por linhas, você pode formatá‑las modificando ou aplicando efeitos aos seus contornos. Além disso, você pode formatar formas especificando configurações que controlam como seus interiores são preenchidos.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET fornece interfaces e propriedades que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar Linhas**

Usando Aspose.Slides, você pode especificar um estilo de linha personalizado para uma forma. Os passos a seguir descrevem o procedimento:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
1. Defina o [estilo de linha](https://reference.aspose.com/slides/pt/net/aspose.slides/linestyle/) da forma.
1. Defina a largura da linha.
1. Defina o [estilo de traço](https://reference.aspose.com/slides/pt/net/aspose.slides/linedashstyle/) da linha.
1. Defina a cor da linha da forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O seguinte código C# demonstra como formatar um `AutoShape` retangular:

```c#
 // Instanciar a classe Presentation que representa um arquivo de apresentação.
 using (Presentation presentation = new Presentation())
 {
     // Obter o primeiro slide.
     ISlide slide = presentation.Slides[0];
 
     // Adicionar uma forma automática do tipo Retângulo.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
 
     // Definir a cor de preenchimento para a forma retangular.
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

![The formatted lines in the presentation](formatted-lines.png)

## **Formatar Estilos de Junção**

Aqui estão as três opções de tipo de junção:

* Round
* Miter
* Bevel

Por padrão, quando o PowerPoint une duas linhas em um ângulo (como em um canto de forma), ele usa a configuração **Round**. No entanto, se você estiver desenhando uma forma com ângulos agudos, pode preferir a opção **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

O seguinte código C# demonstra como três retângulos (conforme mostrados na imagem acima) foram criados usando as configurações de junção Miter, Bevel e Round:

```c#
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

## **Preenchimento em Gradiente**

No PowerPoint, Preenchimento em Gradiente é uma opção de formatação que permite aplicar uma mescla contínua de cores a uma forma. Por exemplo, você pode aplicar duas ou mais cores de modo que uma desapareça gradualmente na outra.

Veja como aplicar um preenchimento em gradiente a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) da forma como `Gradient`.
1. Adicione suas duas cores preferidas com posições definidas usando os métodos `Add` da coleção de paradas de gradiente exposta pela interface [IGradientFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/igradientformat/).
1. Salve a apresentação modificada como um arquivo PPTX.

O seguinte código C# demonstra como aplicar um efeito de preenchimento em gradiente a uma elipse:

```c#
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

![The ellipse with gradient fill](gradient-fill.png)

## **Preenchimento de Padrão**

No PowerPoint, Preenchimento de Padrão é uma opção de formatação que permite aplicar um desenho de duas cores — como pontos, listras, cruzamentos ou quadriculados — a uma forma. Você pode escolher cores personalizadas para o primeiro plano e o plano de fundo do padrão.

Aspose.Slides fornece mais de 45 estilos de padrão predefinidos que você pode aplicar a formas para melhorar a aparência visual de suas apresentações. Mesmo após selecionar um padrão predefinido, ainda é possível especificar as cores exatas a serem usadas.

Veja como aplicar um preenchimento de padrão a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) da forma como `Pattern`.
1. Escolha um estilo de padrão entre as opções predefinidas.
1. Defina a [Background Color](https://reference.aspose.com/slides/pt/net/aspose.slides/ipatternformat/backcolor/) do padrão.
1. Defina a [Foreground Color](https://reference.aspose.com/slides/pt/net/aspose.slides/ipatternformat/forecolor/) do padrão.
1. Salve a apresentação modificada como um arquivo PPTX.

O seguinte código C# demonstra como aplicar um preenchimento de padrão a um retângulo:

```c#
 // Instanciar a classe Presentation que representa um arquivo de apresentação.
 using (Presentation presentation = new Presentation())
 {
     // Obter o primeiro slide.
     ISlide slide = presentation.Slides[0];
 
     // Adicionar uma forma automática do tipo Retângulo.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
 
     // Definir o tipo de preenchimento como Padrão.
     shape.FillFormat.FillType = FillType.Pattern;
 
     // Definir o estilo do padrão.
     shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
 
     // Definir as cores de fundo e de primeiro plano do padrão.
     shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
     shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;
 
     // Salvar o arquivo PPTX no disco.
     presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
 }
```

O resultado:

![The rectangle with pattern fill](pattern-fill.png)

## **Preenchimento de Imagem**

No PowerPoint, Preenchimento de Imagem é uma opção de formatação que permite inserir uma imagem dentro de uma forma — usando efetivamente a imagem como plano de fundo da forma.

Veja como usar Aspose.Slides para aplicar um preenchimento de imagem a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) da forma como `Picture`.
1. Defina o modo de preenchimento de imagem como `Tile` (ou outro modo preferido).
1. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) a partir da imagem que deseja usar.
1. Atribua essa imagem à propriedade `Picture.Image` do `PictureFillFormat` da forma.
1. Salve a apresentação modificada como um arquivo PPTX.

Suponha que tenhamos um arquivo "lotus.png" com a seguinte imagem:

![The lotus picture](lotus.png)

O seguinte código C# demonstra como preencher uma forma com a imagem:

```c#
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

![The shape with picture fill](picture-fill.png)

### **Imagem em Mosaico como Textura**

Se quiser definir uma imagem em mosaico como textura e personalizar o comportamento de mosaico, pode usar as propriedades a seguir da interface [IPictureFillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/) e da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/picturefillmode/): Define o modo de preenchimento de imagem — `Tile` ou `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/tilealignment/): Especifica o alinhamento dos mosaicos dentro da forma.
- [TileFlip](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/tileflip/): Controla se o mosaico é invertido horizontalmente, verticalmente ou ambos.
- [TileOffsetX](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/tileoffsetx/): Define o deslocamento horizontal do mosaico (em pontos) a partir da origem da forma.
- [TileOffsetY](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/tileoffsety/): Define o deslocamento vertical do mosaico (em pontos) a partir da origem da forma.
- [TileScaleX](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/tilescalex/): Define a escala horizontal do mosaico em porcentagem.
- [TileScaleY](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/tilescaley/): Define a escala vertical do mosaico em porcentagem.

O seguinte exemplo de código mostra como adicionar uma forma retangular com preenchimento de imagem em mosaico e configurar as opções de mosaico:

```c#
 // Instanciar a classe Presentation que representa um arquivo de apresentação.
 using (Presentation presentation = new Presentation())
 {
     // Obter o primeiro slide.
     ISlide firstSlide = presentation.Slides[0];
 
     // Adicionar uma forma automática retangular.
     IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
 
     // Definir o tipo de preenchimento da forma como Imagem.
     shape.FillFormat.FillType = FillType.Picture;
 
     // Carregar a imagem e adicioná-la aos recursos da apresentação.
     IPPImage presentationImage;
     using (IImage sourceImage = Images.FromFile("lotus.png"))
         presentationImage = presentation.Images.AddImage(sourceImage);
 
     // Atribuir a imagem à forma.
     IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
     pictureFillFormat.Picture.Image = presentationImage;
 
     // Configurar o modo de preenchimento da imagem e as propriedades de ladrilhamento.
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

![The tile options](tile-options.png)

## **Preenchimento de Cor Sólida**

No PowerPoint, Preenchimento de Cor Sólida é uma opção de formatação que preenche uma forma com uma única cor uniforme. Essa cor de plano de fundo simples é aplicada sem gradientes, texturas ou padrões.

Para aplicar um preenchimento de cor sólida a uma forma usando Aspose.Slides, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) da forma como `Solid`.
1. Atribua a cor de preenchimento preferida à forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O seguinte código C# demonstra como aplicar um preenchimento de cor sólida a um retângulo em um slide do PowerPoint:

```c#
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

![The shape with solid color fill](solid-color-fill.png)

## **Definir Transparência**

No PowerPoint, ao aplicar um preenchimento sólido, em gradiente, de imagem ou de textura a formas, você também pode definir um nível de transparência para controlar a opacidade do preenchimento. Um valor de transparência maior torna a forma mais translúcida, permitindo que o fundo ou objetos subjacentes fiquem parcialmente visíveis.

Aspose.Slides permite definir o nível de transparência ajustando o valor alfa na cor usada para o preenchimento. Veja como fazer isso:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) como `Solid`.
1. Use `Color.FromArgb(alpha, baseColor)` para definir uma cor com transparência (o componente `alpha` controla a transparência).
1. Salve a apresentação.

O seguinte código C# demonstra como aplicar uma cor de preenchimento transparente a um retângulo:

```c#
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

![The transparent shape](shape-transparency.png)

## **Rotacionar Formas**

Aspose.Slides permite rotacionar formas em apresentações do PowerPoint. Isso pode ser útil ao posicionar elementos visuais com requisitos específicos de alinhamento ou design.

Para rotacionar uma forma em um slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
1. Defina a propriedade `Rotation` da forma para o ângulo desejado.
1. Salve a apresentação.

O seguinte código C# demonstra como rotacionar uma forma em 5 graus:

```c#
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

![The shape rotation](shape-rotation.png)

## **Adicionar Efeitos de Bisel 3D**

Aspose.Slides permite aplicar efeitos de bisel 3D a formas configurando as propriedades do [ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/threedformat/).

Para adicionar efeitos de bisel 3D a uma forma, siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
1. Configure o [ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/threedformat/) da forma para definir as configurações de bisel.
1. Salve a apresentação.

O seguinte código C# mostra como aplicar efeitos de bisel 3D a uma forma:

```c#
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

![The 3D bevel effect](3D-bevel-effect.png)

## **Adicionar Efeitos de Rotação 3D**

Aspose.Slides permite aplicar efeitos de rotação 3D a formas configurando as propriedades do [ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/threedformat/).

Para aplicar rotação 3D a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) ao slide.
1. Defina o [CameraType](https://reference.aspose.com/slides/pt/net/aspose.slides/icamera/cameratype/) e o [LightType](https://reference.aspose.com/slides/pt/net/aspose.slides/ilightrig/lighttype/) da forma para definir a rotação 3D.
1. Salve a apresentação.

O seguinte código C# demonstra como aplicar efeitos de rotação 3D a uma forma:

```c#
// Criar uma instância da classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Salvar a apresentação como um arquivo PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

O resultado:

![The 3D rotation effect](3D-rotation-effect.png)

## **Redefinir Formatação**

O seguinte código C# mostra como redefinir a formatação de um slide e reverter a posição, tamanho e formatação de todas as formas com marcadores de posição no [LayoutSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutslide/) para suas configurações padrão:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Redefinir cada forma no slide que tem um placeholder no layout.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**A formatação de formas afeta o tamanho final do arquivo da apresentação?**

Apenas minimamente. Imagens incorporadas e mídia ocupam a maior parte do espaço do arquivo, enquanto parâmetros de forma como cores, efeitos e gradientes são armazenados como metadados e quase não aumentam o tamanho.

**Como posso detectar formas em um slide que compartilham formatação idêntica para poder agrupá‑las?**

Compare as principais propriedades de formatação de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, considere os estilos idênticos e agrupe logicamente essas formas, simplificando a gestão de estilos posteriormente.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilizar em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um slide‑modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas necessárias e reaplique a formatação onde for preciso.