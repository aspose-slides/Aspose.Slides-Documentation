---
title: Criar e Aplicar Efeitos WordArt no .NET
linktitle: WordArt
type: docs
weight: 110
url: /pt/net/wordart/
keywords:
- WordArt
- criar WordArt
- modelo WordArt
- efeito WordArt
- efeito de sombra
- efeito de reflexão
- efeito de brilho
- transformação WordArt
- efeito 3D
- efeito de sombra externa
- efeito de sombra interna
- .NET
- C#
- Aspose.Slides
description: "Crie e personalize efeitos WordArt no Aspose.Slides para .NET. Este guia passo a passo ajuda os desenvolvedores a aprimorar apresentações com texto profissional em C#."
---
## **Visão geral**

Os efeitos de WordArt permitem estilizar o texto com preenchimentos, contornos, sombras, reflexos, brilho, transformações e formatação 3D. Este artigo explica como criar e personalizar esses efeitos em apresentações do PowerPoint usando Aspose.Slides for .NET, sem a necessidade de ter o Microsoft Office instalado.

## **Criar um Modelo WordArt Simples e Aplicá-lo ao Texto**

Os exemplos a seguir criam um estilo WordArt simples definindo o texto, a fonte, o preenchimento de padrão e o contorno.

Cada exemplo cria uma nova apresentação e adiciona um retângulo ao seu primeiro slide; nenhum arquivo de entrada é necessário. O primeiro exemplo define o texto como "Aspose.Slides". A posição e as dimensões da forma são medidas em pontos:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Defina a fonte como Arial Black em 36 pontos para tornar a formatação mais perceptível:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

Aplicar um padrão [SmallGrid](https://reference.aspose.com/slides/pt/net/aspose.slides/patternstyle/) com primeiro plano laranja escuro e fundo branco, e então adicionar um contorno de texto preto com largura de 1 ponto:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

O texto resultante:

![O modelo WordArt simples](WordArt_template.png)

## **Aplicar Outros Efeitos WordArt**

Os exemplos a seguir demonstram como aplicar sombras, reflexos, brilho, transformações e efeitos 3D ao texto.

### **Aplicar Efeitos de Sombra Externa**

Uma sombra externa adiciona profundidade ao posicionar uma sombra atrás do texto. Você pode personalizar sua cor, direção, distância, raio de desfoque, escala e inclinação.

Este exemplo chama [EnableOuterShadowEffect](https://reference.aspose.com/slides/pt/net/aspose.slides/effectformat/enableoutershadoweffect/) e define uma sombra preta com raio de desfoque de 4 pontos, direção de 230 graus e distância de 30 pontos. Valores de escala de 100 preservam o tamanho da sombra, enquanto a inclinação horizontal a inclina em 20 graus. A transformação alfa define sua opacidade em 32%:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

O texto resultante:

![O efeito Sombra Externa](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Quando sombras externas e predefinidas são usadas juntas, apenas a sombra externa é aplicada.
- Se sombras externas e internas forem usadas simultaneamente, o efeito resultante depende da versão do PowerPoint. Por exemplo, no PowerPoint 2013, o efeito é dobrado, enquanto no PowerPoint 2007, apenas a sombra externa é aplicada.
{{% /alert %}}

### **Aplicar Efeitos de Reflexo**

Um reflexo cria uma cópia espelhada do texto. Ajuste sua posição, escala, desfoque e opacidade para controlar sua aparência.

Este exemplo chama [EnableReflectionEffect](https://reference.aspose.com/slides/pt/net/aspose.slides/effectformat/enablereflectioneffect/) e inverte o reflexo verticalmente com escala de -100%. Ele usa um raio de desfoque de 0.5 ponto e uma distância de 4.72 pontos. A opacidade diminui de 60% para 0.9% entre as posições 0% e 60% ao longo do reflexo:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableReflectionEffect();
portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
```

O texto resultante:

![O efeito Reflexo](reflection_effect.png)

### **Aplicar Efeitos de Brilho**

Um brilho adiciona um contorno suave colorido ao redor do texto. Ajuste sua cor, opacidade e raio para controlar o efeito.

Este exemplo chama [EnableGlowEffect](https://reference.aspose.com/slides/pt/net/aspose.slides/effectformat/enablegloweffect/) e aplica um brilho vermelho com 54% de opacidade e raio de 7 pontos:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

O texto resultante:

![O efeito Brilho](glow_effect.png)

### **Aplicar Transformações WordArt**

As transformações WordArt curvam, esticam ou distorcem um bloco de texto.

Defina [Transform](https://reference.aspose.com/slides/pt/net/aspose.slides/textframeformat/transform/) para [ArchUpPour](https://reference.aspose.com/slides/pt/net/aspose.slides/textshapetype/) para curvar todo o quadro de texto para cima:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

O texto resultante:

![A transformação WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET fornece um conjunto de [tipos de transformação](https://reference.aspose.com/slides/pt/net/aspose.slides/textshapetype/) predefinidos.
{{% /alert %}}

### **Aplicar Efeitos 3D a Formas e Texto**

Você pode aplicar efeitos 3D a uma forma ou ao seu texto. Biséis, extrusão, iluminação e configurações de câmera controlam a aparência resultante.

O exemplo a seguir usa [ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/threedformat/) para adicionar biséis circulares, extrusão laranja e contorno vermelho escuro ao retângulo. As dimensões do bisel, altura da extrusão, largura e profundidade do contorno são medidas em pontos. Um material plástico, iluminação equilibrada girada 40 graus ao redor do eixo Z, e uma câmera em perspectiva definem sua aparência:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
autoShape.TextFrame.Text = "Aspose.Slides";

autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelTop.Height = 12.5;
autoShape.ThreeDFormat.BevelTop.Width = 11;

autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
autoShape.ThreeDFormat.ExtrusionHeight = 6;

autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
autoShape.ThreeDFormat.ContourWidth = 1.5;

autoShape.ThreeDFormat.Depth = 3;

autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

A forma resultante:

![O efeito 3D da forma](shape_3D_effect.png)

Este exemplo aplica formatação 3D semelhante ao texto através de [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/textframeformat/threedformat/). Biséis menores modelam as bordas das letras, enquanto a extrusão e a iluminação conferem profundidade ao texto:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";

textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

O texto resultante:

![O efeito 3D do texto](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
A aplicação de efeitos 3D ao texto ou às suas formas — e a interação entre esses efeitos — é regida por regras específicas. Considere uma cena envolvendo tanto o texto quanto a forma que o contém. Um efeito 3D inclui a representação 3D do objeto e a cena na qual ele está colocado.

- Se uma cena estiver definida tanto para a forma quanto para o texto, a cena da forma tem prioridade e a cena do texto é ignorada.
- Se a forma não possui sua própria cena, mas tem uma representação 3D, a cena do texto é usada.
- Se a forma não tem efeito 3D algum, ela é tratada como plana, e o efeito 3D é aplicado apenas ao texto.

Esses comportamentos relacionam‑se às propriedades [ThreeDFormat.LightRig](https://reference.aspose.com/slides/pt/net/aspose.slides/threedformat/lightrig/) e [ThreeDFormat.Camera](https://reference.aspose.com/slides/pt/net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Para manter o texto plano e legível enquanto preserva a formatação 3D da forma, consulte [Keep Text Flat on a 3D Shape](/slides/pt/net/3d-presentation/) para uma comparação de ambas as configurações e um exemplo completo em C#.

## **Perguntas Frequentes**

**Posso usar efeitos WordArt com diferentes fontes ou scripts (por exemplo, árabe, chinês)?**

Sim, o Aspose.Slides for .NET oferece suporte a Unicode e funciona com todas as principais fontes e scripts. Efeitos WordArt como sombra, preenchimento e contorno podem ser aplicados independentemente do idioma, embora a disponibilidade da fonte e a renderização possam depender das fontes do sistema.

**Posso aplicar efeitos WordArt aos elementos do slide mestre?**

Sim, você pode aplicar efeitos WordArt às formas nos slides mestres, incluindo marcadores de posição de título, rodapés ou texto de fundo. Alterações feitas no layout mestre serão refletidas em todos os slides associados.

**Os efeitos WordArt afetam o tamanho do arquivo da apresentação?**

Um pouco. Efeitos WordArt como sombras, brilhos e preenchimentos em degradê podem aumentar ligeiramente o tamanho do arquivo devido à inclusão de metadados de formatação, mas a diferença costuma ser insignificante.

**Posso visualizar o resultado dos efeitos WordArt sem salvar a apresentação?**

Sim, você pode renderizar slides que contêm WordArt em imagens (por exemplo, PNG, JPEG) usando [ISlide.GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/getimage/), ou renderizar formas individuais usando [IShape.GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/getimage/). Isso permite visualizar o resultado na memória ou na tela antes de salvar ou exportar a apresentação completa.