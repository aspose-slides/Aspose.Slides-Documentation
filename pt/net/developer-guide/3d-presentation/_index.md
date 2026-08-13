---
title: Criar efeitos 3D em apresentações usando .NET
linktitle: Apresentação 3D
type: docs
weight: 232
url: /pt/net/3d-presentation/
keywords:
- PowerPoint 3D
- apresentação 3D
- rotação 3D
- profundidade 3D
- extrusão 3D
- gradiente 3D
- texto 3D
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aplicar e renderizar efeitos 3D para formas e texto do PowerPoint em .NET com Aspose.Slides. Configurar câmera, iluminação, material, extrusão, preenchimentos e texto 3D."
---
## **Visão geral**

Aspose.Slides for .NET pode criar, editar, preservar e renderizar formatação 3D no estilo PowerPoint para formas e texto. Este artigo cobre efeitos 3D como rotação, extrusão, biséis, iluminação, material, preenchimentos em gradiente ou imagem e texto 3D.

{{% alert color="info" %}}
Este artigo trata de efeitos de formatação 3D em formas e texto do PowerPoint. Não se trata de inserir ou editar arquivos de modelo 3D independentes. Quando você exporta um slide para uma imagem, PDF ou HTML, Aspose.Slides renderiza esses efeitos 3D na saída 2D exportada.
{{% /alert %}}

## **Conceitos de formatação 3D**

Use a propriedade [IShape.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/properties/threedformat) para aplicar formatação 3D a uma forma. A propriedade expõe [IThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat), que controla a cena 3D para essa forma.

Para texto, use a propriedade [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/properties/threedformat). Isso aplica formatação 3D ao quadro de texto em vez do corpo da forma.

As propriedades mais importantes são:

| Propriedade | O que controla | Quando usar |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/camera) | Ponto de vista, tipo de câmera predefinida, rotação, zoom e perspectiva. | Rotacione o objeto no espaço 3D ou combine com um preset de rotação 3D do PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/lightrig) | Predefinição de luz, direção e rotação da luz. | Altere como realces e sombras aparecem na superfície 3D. |
| [Material](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/material) | Material da superfície, como plano, fosco, plástico ou metal. | Faça a mesma geometria parecer mais plana, suave, brilhante ou metálica. |
| [ExtrusionHeight](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/extrusionheight) | Quão longe a forma se estende para trás a partir de sua face frontal. | Transforme uma forma plana em um objeto 3D visivelmente espesso. |
| [ExtrusionColor](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Cor das laterais extrudadas. | Torne a profundidade visível ou coordene a cor lateral com o preenchimento frontal. |
| [Depth](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/depth) | Profundidade 3D adicional usada pela formatação 3D do PowerPoint. | Ajuste fino da profundidade para formas ou texto, especialmente junto com configurações de bisel e material. |
| [BevelTop](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/beveltop) e [BevelBottom](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/bevelbottom) | Bordas elevadas ou arredondadas nas faces frontal e traseira. | Adicione uma borda suavizada ou moldada em vez de uma face plana e afiada. |
| [ContourColor](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/contourcolor) e [ContourWidth](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/contourwidth) | Contorno ao redor do objeto 3D. | Enfatize o contorno do objeto na saída renderizada. |

## **Criar uma forma 3D**

Uma forma normalmente precisa de quatro tipos de configurações antes de parecer convincentemente 3D:

- Configurações de câmera, pois a visualização frontal padrão pode ocultar a extrusão.
- Configurações de luz, pois a iluminação torna as faces e laterais legíveis.
- Configurações de material, pois a superfície afeta como a luz é renderizada.
- Configurações de extrusão ou profundidade, pois uma forma plana precisa de espessura.

O exemplo a seguir cria um retângulo, adiciona texto à sua face frontal, aplica formatação 3D, salva a apresentação como PPTX e renderiza o slide para uma imagem PNG.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Rotacionar uma forma com a câmera**

No PowerPoint, a rotação 3D é configurada no painel de Rotação 3-D. Os valores de rotação X, Y e Z correspondem à rotação definida através da API de câmera.

![Painel de Rotação 3-D do PowerPoint com valores de rotação X, Y e Z destacados](img_02_01.png)

No Aspose.Slides, defina o tipo de câmera e a rotação através de [IThreeDFormat.Camera](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/camera):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Use a câmera quando precisar alterar como o visualizador vê o objeto. Ela não altera a geometria da forma 2D no slide. Ela altera o ponto de vista 3D usado pelo PowerPoint e pelo Aspose.Slides ao renderizar.

## **Adicionar extrusão e profundidade**

A extrusão faz uma forma parecer espessa ao estendê-la por trás da face frontal. No PowerPoint, o controle de profundidade define essa espessura visível, e o controle de cor define a cor das faces laterais.

![Controles de profundidade do PowerPoint mapeados para as propriedades cor da extrusão e altura da extrusão](img_02_02.png)

Defina [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/extrusionheight) para a espessura e [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/extrusioncolor) para a cor lateral:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Use [IThreeDFormat.Depth](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/depth) quando precisar trabalhar diretamente com o valor de profundidade do PowerPoint ou combinar profundidade com bisel, material e efeitos de texto. Em muitos cenários de forma, `ExtrusionHeight` é a configuração mais clara porque expressa diretamente a extrusão visível.

## **Usar preenchimentos em gradiente ou imagem com efeitos 3D**

A formatação 3D é independente do preenchimento da forma. Você pode aplicar uma cor sólida, gradiente, padrão ou preenchimento de imagem à face frontal e ainda usar as mesmas configurações de câmera, luz, material e extrusão.

Este exemplo aplica um preenchimento em gradiente à forma e uma cor de extrusão mais escura às laterais:

```csharp
using System.Drawing;
using Aspose.Slides;

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

A saída renderizada mantém o gradiente na face frontal e renderiza a extrusão separadamente:

![Retângulo 3D renderizado com preenchimento em gradiente azul para laranja e extrusão laranja](img_02_03.png)

Para usar um preenchimento de imagem, adicione a imagem à apresentação e atribua-a ao preenchimento da forma:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

A imagem é renderizada na face frontal, enquanto a extrusão é renderizada como a superfície lateral 3D:

![Retângulo 3D renderizado com preenchimento fotográfico na face frontal e extrusão laranja](img_02_04.png)

## **Aplicar formatação 3D ao texto**

A formatação 3D de forma afeta o corpo da forma. A formatação 3D de texto afeta o quadro de texto. Isso é útil para efeitos semelhantes ao WordArt, onde as próprias letras precisam de extrusão, material, iluminação e configurações de câmera.

O exemplo a seguir cria texto com preenchimento de padrão, aplica uma transformação WordArt e configura as configurações 3D em [ITextFrameFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat):

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

O texto é renderizado como letras curvadas e extrudadas em 3D:

![Texto 3D renderizado com transformação WordArt arqueada, preenchimento de padrão laranja e extrusão escura](img_02_05.png)

## **Comportamento de exportação e renderização**

Aspose.Slides preserva a formatação 3D ao salvar em formatos do PowerPoint como PPTX. Ao renderizar ou exportar para formatos de layout fixo, a cena 3D é rasterizada ou desenhada na saída como um resultado 2D. Isso se aplica quando você renderiza slides para [PNG](/slides/pt/net/convert-powerpoint-to-png/), exporta para [PDF](/slides/pt/net/convert-powerpoint-to-pdf/), exporta para [HTML](/slides/pt/net/convert-powerpoint-to-html/), ou gera quadros para [conversão de vídeo](/slides/pt/net/convert-powerpoint-to-video/).

- Imagens e PDFs exportados não são interativos. O objeto não pode ser rotacionado pelo visualizador após a exportação.
- A aparência final depende da combinação de câmera, rig de luz, material, extrusão, preenchimento e dimensionamento do slide.
- Se precisar inspecionar valores de formatação herdados ou baseados em tema, leia as [propriedades efetivas de forma](/slides/pt/net/shape-effective-properties/).
- Alguns formatos de saída não podem armazenar a formatação 3D editável do PowerPoint. Nesses formatos, o resultado visual é renderizado em vez de preservado como configurações 3D editáveis.

## **FAQ**

### O Aspose.Slides pode criar apresentações 3D interativas?

Aspose.Slides cria e renderiza efeitos 3D do PowerPoint para formas e texto. Não torna imagens, PDFs ou páginas HTML exportadas em cenas 3D interativas que o visualizador possa rotacionar. No PPTX, a formatação 3D permanece editável no PowerPoint onde o formato a suporta.

### Qual é a diferença entre um modelo 3D e um efeito 3D?

Um modelo 3D é um objeto 3D separado inserido em uma apresentação. Um efeito 3D é formatação aplicada a uma forma ou texto do PowerPoint regular, como rotação, extrusão, bisel, iluminação e material. Este artigo trata de efeitos 3D.

### Quais configurações são necessárias para uma forma 3D visível?

No mínimo, defina uma rotação de câmera e extrusão ou profundidade. Na prática, também defina um rig de luz e material para que as faces renderizadas tenham realces e sombras claros.

### Posso aplicar efeitos 3D tanto a formas quanto a texto?

Sim. Use [IShape.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/properties/threedformat) para o corpo da forma e [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/properties/threedformat) para o texto.

### Os efeitos 3D aparecerão ao exportar para imagens, PDF, HTML ou quadros de vídeo?

Sim. Aspose.Slides renderiza efeitos 3D ao produzir imagens de slides, saída PDF, saída HTML e quadros usados na conversão de vídeo. A saída exportada contém a aparência renderizada, não um objeto 3D editável.

### Posso ler os valores 3D finais após a aplicação de herança e configurações de tema?

Sim. Use as APIs de formatação efetiva descritas em [Propriedades efetivas de forma](/slides/pt/net/shape-effective-properties/) para ler a câmera final, rig de luz, bisel e valores 3D relacionados.