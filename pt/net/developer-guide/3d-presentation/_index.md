---
title: Criar efeitos 3D em apresentações usando .NET
linktitle: Apresentação 3D
type: docs
weight: 232
url: /pt/net/3d-presentation/
keywords:
- PowerPoint 3D
- Apresentação 3D
- Rotação 3D
- Profundidade 3D
- Extrusão 3D
- Gradiente 3D
- Texto 3D
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aplicar e renderizar efeitos 3D para formas e texto do PowerPoint em .NET com Aspose.Slides. Configurar câmera, iluminação, material, extrusão, preenchimentos e texto 3D."
---
## **Visão geral**

Aspose.Slides for .NET pode criar, editar, preservar e renderizar formatação 3D no estilo PowerPoint para formas e texto. Este artigo aborda efeitos 3D como rotação, extrusão, chanfros, iluminação, material, preenchimentos gradientes ou de imagem e texto 3D.

{{% alert color="primary" %}}
Este artigo trata de efeitos de formatação 3D em formas e texto do PowerPoint. Não se trata de inserir ou editar arquivos de modelo 3D independentes. Quando você exporta um slide para uma imagem, PDF ou HTML, o Aspose.Slides renderiza esses efeitos 3D na saída 2D exportada.
{{% /alert %}}

## **Conceitos de Formatação 3D**

Use a propriedade [IShape.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/properties/threedformat) para aplicar formatação 3D a uma forma. A propriedade expõe [IThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat), que controla a cena 3D para essa forma.

Para texto, use a propriedade [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/properties/threedformat). Isso aplica formatação 3D ao quadro de texto em vez do corpo da forma.

As propriedades mais importantes são:

| Propriedade | O que controla | Quando usar |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/camera) | Ponto de vista, tipo de câmera predefinido, rotação, zoom e perspectiva. | Gire o objeto no espaço 3D ou corresponda a um preset de rotação 3D do PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/lightrig) | Predefinição de luz, direção e rotação da luz. | Altere como os realces e sombras aparecem na superfície 3D. |
| [Material](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/material) | Material da superfície, como plano, fosco, plástico ou metal. | Faça a mesma geometria parecer mais plana, suave, brilhante ou metálica. |
| [ExtrusionHeight](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/extrusionheight) | Quão longe a forma se estende para trás a partir de sua face frontal. | Transforme uma forma plana em um objeto 3D visivelmente espesso. |
| [ExtrusionColor](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Cor dos lados extrudados. | Torne a profundidade visível ou coordene a cor dos lados com o preenchimento frontal. |
| [Depth](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/depth) | Profundidade 3D adicional usada pela formatação 3D do PowerPoint. | Ajuste fino da profundidade para formas ou texto, especialmente junto com as configurações de chanfro e material. |
| [BevelTop](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/beveltop) e [BevelBottom](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/bevelbottom) | Bordas elevadas ou arredondadas nas faces frontal e traseira. | Adicione uma borda suavizada ou moldada em vez de uma face plana e afiada. |
| [ContourColor](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/contourcolor) e [ContourWidth](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/contourwidth) | Contorno ao redor do objeto 3D. | Enfatize o contorno do objeto na saída renderizada. |

## **Criar uma Forma 3D**

Uma forma geralmente precisa de quatro tipos de configurações antes de parecer convincentemente 3D:

- Configurações de câmera, pois a vista frontal padrão pode ocultar a extrusão.
- Configurações de luz, pois a iluminação torna as faces e lados legíveis.
- Configurações de material, pois a superfície afeta como a luz é renderizada.
- Configurações de extrusão ou profundidade, pois uma forma plana precisa de espessura.

O exemplo a seguir cria um retângulo, adiciona texto à sua face frontal, aplica formatação 3D, salva a apresentação como PPTX e renderiza o slide para uma imagem PNG.

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

A imagem do slide renderizado mostra o retângulo como um bloco 3D espesso:

![Retângulo 3D azul renderizado com texto 3D branco na face frontal](img_01_01.png)

## **Girar uma Forma com a Câmera**

No PowerPoint, a rotação 3D é configurada a partir do painel 3-D Rotation. Os valores de rotação X, Y e Z correspondem à rotação que você define através da API de câmera.

![Painel 3-D Rotation do PowerPoint com valores de rotação X, Y e Z destacados](img_02_01.png)

No Aspose.Slides, defina o tipo de câmera e rotação através de [IThreeDFormat.Camera](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/camera):

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Use a câmera quando precisar alterar como o visualizador vê o objeto. Ela não altera a geometria 2D da forma no slide. Ela altera o ponto de vista 3D usado pelo PowerPoint e pelo Aspose.Slides ao renderizar.

## **Adicionar Extrusão e Profundidade**

A extrusão faz uma forma parecer espessa ao estendê-la por trás da face frontal. No PowerPoint, o controle de profundidade define essa espessura visível, e o controle de cor define a cor das faces laterais.

![Controles de profundidade do PowerPoint mapeados para as propriedades cor da extrusão e altura da extrusão](img_02_02.png)

Defina [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/extrusionheight) para a espessura e [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/extrusioncolor) para a cor dos lados:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Use [IThreeDFormat.Depth](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/depth) quando precisar trabalhar diretamente com o valor de profundidade do PowerPoint ou combinar profundidade com chanfro, material e efeitos de texto. Em muitos cenários de forma, `ExtrusionHeight` é a configuração mais clara porque expressa diretamente a extrusão visível.

## **Usar Preenchimentos em Gradiente ou Imagem com Efeitos 3D**

A formatação 3D é independente do preenchimento da forma. Você pode aplicar uma cor sólida, gradiente, padrão ou preenchimento de imagem à face frontal e ainda usar as mesmas configurações de câmera, luz, material e extrusão.

Este exemplo aplica um preenchimento em gradiente à forma e uma cor de extrusão mais escura aos lados:

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

![Retângulo 3D renderizado com preenchimento em gradiente azul para laranja e extrusão laranja](img_02_03.png)

Para usar um preenchimento de imagem, adicione a imagem à apresentação e atribua-a ao preenchimento da forma:

```csharp
var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

![Retângulo 3D renderizado com preenchimento fotográfico na face frontal e extrusão laranja](img_02_04.png)

## **Aplicar Formatação 3D ao Texto**

A formatação 3D da forma afeta o corpo da forma. A formatação 3D do texto afeta o quadro de texto. Isso é útil para efeitos semelhantes ao WordArt, onde as próprias letras precisam de extrusão, material, iluminação e configurações de câmera.

O exemplo a seguir cria texto com preenchimento de padrão, aplica uma transformação WordArt e configura as definições 3D em [ITextFrameFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat):

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

![Texto 3D renderizado com uma transformação WordArt arqueada, preenchimento de padrão laranja e extrusão escura](img_02_05.png)

## **Comportamento de Exportação e Renderização**

O Aspose.Slides preserva a formatação 3D ao salvar em formatos PowerPoint como PPTX. Ao renderizar ou exportar para formatos de layout fixo, a cena 3D é rasterizada ou desenhada na saída como um resultado 2D. Isso se aplica quando você renderiza slides para [PNG](/slides/pt/net/convert-powerpoint-to-png/), exporta para [PDF](/slides/pt/net/convert-powerpoint-to-pdf/), exporta para [HTML](/slides/pt/net/convert-powerpoint-to-html/), ou gera frames para [conversão de vídeo](/slides/pt/net/convert-powerpoint-to-video/).

- Imagens e PDFs exportados não são interativos. O objeto não pode ser girado pelo visualizador após a exportação.
- A aparência final depende da combinação de câmera, rig de luz, material, extrusão, preenchimento e escala do slide.
- Se precisar inspecionar valores de formatação herdados ou baseados em tema, leia as [propriedades efetivas da forma](/slides/pt/net/shape-effective-properties/).
- Alguns formatos de saída não podem armazenar a formatação 3D editável do PowerPoint. Nesses formatos, o resultado visual é renderizado em vez de preservado como configurações 3D editáveis.

## **Perguntas Frequentes**

**O Aspose.Slides pode criar apresentações 3D interativas?**

O Aspose.Slides cria e renderiza efeitos 3D do PowerPoint para formas e texto. Ele não transforma imagens, PDFs ou páginas HTML exportadas em cenas 3D interativas que o visualizador possa girar. No PPTX, a formatação 3D permanece editável no PowerPoint onde o formato a suporta.

**Qual é a diferença entre um modelo 3D e um efeito 3D?**

Um modelo 3D é um objeto 3D separado inserido em uma apresentação. Um efeito 3D é uma formatação aplicada a uma forma ou texto do PowerPoint comum, como rotação, extrusão, chanfro, iluminação e material. Este artigo aborda efeitos 3D.

**Quais configurações são necessárias para uma forma 3D visível?**

No mínimo, defina uma rotação de câmera e extrusão ou profundidade. Na prática, também configure um rig de luz e material para que as faces renderizadas tenham realces e sombras claros.

**Posso aplicar efeitos 3D tanto a formas quanto a texto?**

Sim. Use [IShape.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/properties/threedformat) para o corpo da forma e [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/properties/threedformat) para o texto.

**Os efeitos 3D aparecerão ao exportar para imagens, PDF, HTML ou frames de vídeo?**

Sim. O Aspose.Slides renderiza os efeitos 3D ao produzir imagens de slides, saída PDF, saída HTML e frames usados para conversão de vídeo. A saída exportada contém a aparência renderizada, não um objeto 3D editável.

**Posso ler os valores finais de 3D após a aplicação de herança e configurações de tema?**

Sim. Use as APIs de formatação efetiva descritas em [Propriedades Efetivas da Forma](/slides/pt/net/shape-effective-properties/) para ler a câmera final, rig de luz, chanfro e valores 3D relacionados.