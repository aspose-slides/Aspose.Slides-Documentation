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

Aspose.Slides for .NET pode criar, editar, preservar e renderizar formatação 3D no estilo PowerPoint para formas e texto. Este artigo aborda efeitos 3D como rotação, extrusão, chanfrados, iluminação, material, preenchimentos em gradiente ou imagem, e texto 3D.

{{% alert color="info" title="Note" %}}
Este artigo trata de efeitos de formatação 3D em formas e texto do PowerPoint. Não se trata de inserir ou editar arquivos de modelo 3D independentes. Quando você exporta um slide para uma imagem, PDF ou HTML, o Aspose.Slides renderiza esses efeitos 3D na saída 2D exportada.
{{% /alert %}}

## **Conceitos de Formatação 3D**

Use a propriedade [IShape.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/properties/threedformat) para aplicar formatação 3D a uma forma. A propriedade expõe [IThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat), que controla a cena 3D para essa forma.

Para texto, use a propriedade [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/properties/threedformat). Isso aplica formatação 3D ao quadro de texto em vez do corpo da forma.

As propriedades mais importantes são:

| Propriedade | O que controla | Quando usar |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/camera) | Ponto de vista, tipo de câmera predefinido, rotação, zoom e perspectiva. | Gire o objeto no espaço 3D ou combine com um preset de rotação 3D do PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/lightrig) | Predefinição de luz, direção e rotação da luz. | Altera como realces e sombras aparecem na superfície 3D. |
| [Material](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/material) | Material da superfície, como plano, fosco, plástico ou metal. | Faz a mesma geometria parecer mais plana, suave, brilhante ou metálica. |
| [ExtrusionHeight](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/extrusionheight) | Quão longe a forma se estende para trás a partir de sua face frontal. | Transforma uma forma plana em um objeto 3D visivelmente espesso. |
| [ExtrusionColor](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Cor das faces extrudidas. | Torna a profundidade visível ou coordena a cor das laterais com o preenchimento frontal. |
| [Depth](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/depth) | Profundidade 3D adicional usada pela formatação 3D do PowerPoint. | Ajusta finamente a profundidade para formas ou texto, especialmente em conjunto com configurações de chanfrado e material. |
| [BevelTop](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/beveltop) e [BevelBottom](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/bevelbottom) | Bordas elevadas ou arredondadas nas faces frontal e traseira. | Adiciona uma borda suavizada ou moldada em vez de uma face plana e pontiaguda. |
| [ContourColor](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/contourcolor) e [ContourWidth](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/contourwidth) | Contorno ao redor do objeto 3D. | Enfatiza o contorno do objeto na saída renderizada. |

## **Criar uma Forma 3D**

Uma forma geralmente precisa de quatro tipos de configurações antes de parecer convincentemente 3D:

- Configurações de câmera, porque a visualização frontal padrão pode esconder a extrusão.
- Configurações de iluminação, porque a luz torna as faces e os lados legíveis.
- Configurações de material, porque a superfície afeta como a luz é renderizada.
- Configurações de extrusão ou profundidade, porque uma forma plana precisa de espessura.

O exemplo a seguir cria um retângulo, adiciona texto à sua face frontal e aplica formatação 3D. Os valores de rotação da câmera estão em graus, e a altura da extrusão é 100 pontos. O exemplo renderiza o slide para uma imagem PNG com o dobro das dimensões padrão e salva a apresentação como PPTX.

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

## **Rotacionar uma Forma com a Câmera**

No PowerPoint, uma rotação 3D é configurada no painel 3-D Rotation. Os valores de rotação X, Y e Z correspondem à rotação definida via API da câmera.

![Painel de Rotação 3-D do PowerPoint com valores de rotação X, Y e Z destacados](img_02_01.png)

No Aspose.Slides, acesse a câmera através de [IThreeDFormat.Camera](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/camera). Este exemplo cria um retângulo, seleciona uma visualização frontal ortográfica e define suas rotações X, Y e Z para 20, 30 e 40 graus, respectivamente. Ele configura a forma na memória sem salvar um arquivo:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Use a câmera quando precisar alterar como o visualizador vê o objeto. Ela não altera a geometria 2D da forma no slide. Ela altera o ponto de vista 3D usado pelo PowerPoint e pelo Aspose.Slides ao renderizar.

## **Adicionar Extrusão e Profundidade**

A extrusão faz uma forma parecer espessa ao estendê-la atrás da face frontal. No PowerPoint, o controle de profundidade define essa espessura visível, e o controle de cor define a cor das faces laterais.

![Controles de profundidade do PowerPoint mapeados para as propriedades cor da extrusão e altura da extrusão](img_02_02.png)

Defina [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/extrusionheight) para a espessura e [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/extrusioncolor) para a cor das laterais. Este exemplo dá ao retângulo uma extrusão de 100 pontos com lados roxos e gira a câmera para revelar sua espessura. Ele configura a forma na memória sem salvar um arquivo:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

A propriedade [IThreeDFormat.Depth](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/depth) define a profundidade de uma forma 3D. A propriedade [ExtrusionHeight](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/properties/extrusionheight) controla a altura do efeito de extrusão, como mostrado neste exemplo.

## **Usar Preenchimentos em Gradiente ou Imagem com Efeitos 3D**

A formatação 3D é independente do preenchimento da forma. Você pode aplicar uma cor sólida, gradiente, padrão ou preenchimento de imagem à face frontal e ainda usar as mesmas configurações de câmera, luz, material e extrusão.

Este exemplo aplica um gradiente de azul para laranja na face frontal e uma cor laranja escura na extrusão de 150 pontos. As paradas do gradiente em 0 e 100 marcam o início e o fim do gradiente. Os valores de rotação da câmera estão em graus. O slide é renderizado para uma imagem PNG com o dobro das dimensões padrão:

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

![Retângulo 3D renderizado com preenchimento de gradiente azul-para-laranja e extrusão laranja](img_02_03.png)

Para usar um preenchimento com imagem, adicione a imagem à apresentação e atribua-a ao preenchimento da forma. Este exemplo requer um arquivo existente chamado "image.jpg" no diretório de trabalho. Ele estica a imagem para preencher o retângulo, aplica uma extrusão de 150 pontos e define a rotação da câmera em graus. Ele configura a forma na memória sem salvar ou renderizar um arquivo:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

A imagem é renderizada na face frontal, enquanto a extrusão é renderizada como a superfície lateral 3D:

![Retângulo 3D renderizado com preenchimento fotográfico na face frontal e extrusão laranja](img_02_04.png)

## **Aplicar Formatação 3D ao Texto**

A formatação 3D de forma afeta o corpo da forma. A formatação 3D de texto afeta o quadro de texto. Isso é útil para efeitos semelhantes ao WordArt onde as próprias letras precisam de extrusão, material, iluminação e configurações de câmera.

O exemplo a seguir cria texto com um padrão de grade laranja e branco, aplica um arco ascendente e configura as definições 3D através de [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/properties/threedformat). A altura da extrusão e a profundidade estão em pontos, e a rotação da luz está em graus. O preenchimento e o contorno da forma são ocultados para que apenas o texto fique visível. O exemplo renderiza uma imagem PNG com o dobro das dimensões padrão do slide e salva a apresentação como PPTX:

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

![Texto 3D renderizado com transformação WordArt arqueada, preenchimento de padrão laranja e extrusão escura](img_02_05.png)

## **Manter o Texto Plano em uma Forma 3D**

Para manter o texto legível ao preservar a aparência 3D de uma forma, defina [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/keeptextflat/) através de [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/textframeformat/). Quando o valor é `true`, o texto permanece fora da cena 3D. Quando é `false`, o texto participa da cena e segue sua orientação 3D.

Essa configuração não remove a formatação 3D da forma: sua câmera, iluminação, material e extrusão permanecem configurados via [IShape.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/threedformat/). Também difere da rotação comum. [IShape.Rotation](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/rotation/) rotaciona a forma no plano do slide, enquanto [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/rotationangle/) controla a rotação customizada do texto dentro de sua caixa delimitadora. Manter o texto fora da cena 3D não redefine nenhum desses ângulos.

O exemplo autocontido a seguir cria um retângulo azul com texto e o duplica ao lado do original. Ambas as formas têm a mesma formatação 3D; apenas a configuração de texto difere: `false` à esquerda e `true` à direita. Os ângulos da câmera estão em graus, e a altura da extrusão é 40 pontos. O exemplo salva a apresentação como PPTX e renderiza o slide de comparação para PNG com o dobro das dimensões padrão.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

À esquerda, o texto segue a orientação 3D. À direita, ele permanece plano e mais fácil de ler. Ambos os retângulos mantêm a mesma extrusão visível e orientação 3D.

![Retângulos 3D lado a lado: KeepTextFlat é false à esquerda e true à direita](keep_text_flat.png)

## **Comportamento de Exportação e Renderização**

Aspose.Slides preserva a formatação 3D ao salvar em formatos PowerPoint como PPTX. Ao renderizar ou exportar para formatos de layout fixo, a cena 3D é rasterizada ou desenhada na saída como um resultado 2D. Isso se aplica quando você renderiza slides para [PNG](/slides/pt/net/convert-powerpoint-to-png/), exporta para [PDF](/slides/pt/net/convert-powerpoint-to-pdf/), exporta para [HTML](/slides/pt/net/convert-powerpoint-to-html/), ou gera quadros para [conversão de vídeo](/slides/pt/net/convert-powerpoint-to-video/).

Mantenha estes pontos em mente:

- Imagens e PDFs exportados não são interativos. O objeto não pode ser rotacionado pelo visualizador após a exportação.
- A aparência final depende da combinação de câmera, rig de luz, material, extrusão, preenchimento e escala do slide.
- Se precisar inspecionar valores de formatação herdados ou baseados em tema, leia as [propriedades efetivas de forma](/slides/pt/net/shape-effective-properties/).
- Alguns formatos de saída não podem armazenar a formatação 3D editável do PowerPoint. Nesses formatos, o resultado visual é renderizado em vez de preservado como configurações 3D editáveis.

## **FAQ**

**O Aspose.Slides pode criar apresentações 3D interativas?**

Aspose.Slides cria e renderiza efeitos 3D do PowerPoint para formas e texto. Não torna imagens, PDFs ou páginas HTML exportados em cenas 3D interativas que um visualizador possa girar. No PPTX, a formatação 3D permanece editável no PowerPoint onde o formato a suporta.

**Qual é a diferença entre um modelo 3D e um efeito 3D?**

Um modelo 3D é um objeto 3D separado inserido na apresentação. Um efeito 3D é formatação aplicada a uma forma ou texto regular do PowerPoint, como rotação, extrusão, chanfrado, iluminação e material. Este artigo cobre efeitos 3D.

**Quais configurações são necessárias para uma forma 3D visível?**

No mínimo, defina uma rotação de câmera e extrusão ou profundidade. Na prática, também configure um rig de luz e material para que as faces renderizadas tenham realces e sombras claros.

**Posso aplicar efeitos 3D tanto a formas quanto a texto?**

Sim. Use [IShape.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/properties/threedformat) para o corpo da forma e [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/properties/threedformat) para o texto.

**Os efeitos 3D aparecerão ao exportar para imagens, PDF, HTML ou quadros de vídeo?**

Sim. Aspose.Slides renderiza efeitos 3D ao gerar imagens de slide, saída PDF, saída HTML e quadros usados para conversão de vídeo. A saída exportada contém a aparência renderizada, não um objeto 3D editável.

**Posso ler os valores 3D finais após a aplicação de herança e configurações de tema?**

Sim. Use as APIs de formatação efetiva descritas em [Propriedades Efetivas de Forma](/slides/pt/net/shape-effective-properties/) para ler a câmera final, rig de luz, chanfrado e valores 3D relacionados.