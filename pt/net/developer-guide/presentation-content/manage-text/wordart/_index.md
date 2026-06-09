---
title: Criar e Aplicar Efeitos de WordArt em .NET
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
- efeito de exibição
- efeito de brilho
- transformação WordArt
- efeito 3D
- efeito de sombra externa
- efeito de sombra interna
- .NET
- C#
- Aspose.Slides
description: "Crie e personalize efeitos de WordArt no Aspose.Slides para .NET. Este guia passo a passo ajuda os desenvolvedores a aprimorar apresentações com texto profissional em C#."
---
## **Visão geral**

Os efeitos de WordArt permitem que você adicione texto visualmente atraente e estilizado às suas apresentações do PowerPoint. Com o Aspose.Slides para .NET, os desenvolvedores podem criar, personalizar e gerenciar WordArt programaticamente, assim como no Microsoft PowerPoint—sem precisar do Office instalado. Este artigo fornece uma visão geral sobre como trabalhar com WordArt em .NET, incluindo como aplicar transformações de texto, estilos de preenchimento, contornos, sombras e outras opções de formatação para tornar o conteúdo da sua apresentação mais expressivo e envolvente. O WordArt permite tratar o texto como um objeto gráfico. Ele consiste em efeitos ou modificações especiais aplicadas ao texto para torná‑lo mais atraente ou perceptível.

## **Criar um modelo simples de WordArt e aplicá‑lo ao texto**

Nesta seção, exploraremos como criar um modelo simples de WordArt e aplicá‑lo ao texto usando o Aspose.Slides para .NET. O WordArt oferece uma maneira fácil de melhorar a aparência do texto com efeitos visuais marcantes e estilos. Ao aprender as etapas básicas de criação e uso do WordArt, você pode adaptar rapidamente essas técnicas a qualquer projeto, tornando suas apresentações mais vibrantes e memoráveis.

Primeiro, criamos um texto simples usando o seguinte código C#:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

Agora, definimos a altura da fonte do texto para um valor maior para que o efeito seja mais perceptível usando o seguinte código:

```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```

Aqui, aplicamos o preenchimento de padrão SmallGrid ao texto e adicionamos um contorno preto com largura 1 usando o seguinte código:

```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

O texto resultante:

![O modelo simples de WordArt](WordArt_template.png)

## **Aplicar outros efeitos de WordArt**

Além das transformações básicas, o Aspose.Slides para .NET permite aplicar uma variedade de efeitos avançados de WordArt para melhorar a aparência do seu texto. Isso inclui contornos, preenchimentos, sombras, reflexos e efeitos de brilho. Ao combinar esses recursos, você pode criar estilos de texto que chamam a atenção nas suas apresentações. Esta seção demonstra como aplicar esses efeitos programaticamente usando exemplos de código simples e claros.

### **Aplicar efeitos de sombra externa**

Os efeitos de sombra externa ajudam o texto a se destacar ao adicionar uma sombra atrás do contorno, criando sensação de profundidade e separação do fundo. O Aspose.Slides para .NET permite aplicar e personalizar sombras externas no texto WordArt com facilidade. Nesta seção, você aprenderá a definir a cor da sombra, direção, distância, raio de desfoque e mais para alcançar o impacto visual desejado.

O trecho de código C# a seguir aplica um efeito de sombra ao texto criado acima.

```cs
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

![O efeito de sombra externa](outer_shadow_effect.png)

{{% alert color="primary" %}} 

- Quando OuterShadow e PresetShadow são usados juntos, somente o efeito OuterShadow é aplicado.
- Se OuterShadow e InnerShadow forem usados simultaneamente, o efeito resultante depende da versão do PowerPoint. Por exemplo, no PowerPoint 2013 o efeito é dobrado, enquanto no PowerPoint 2007 somente o efeito OuterShadow é aplicado.

{{% /alert %}}

### **Aplicar efeitos de reflexão**

Nesta seção, exploraremos como aplicar efeitos de reflexão em seus slides usando o Aspose.Slides para .NET. Os efeitos de reflexão podem ser uma maneira eficaz de dar ao seu texto ou formas um visual elegante e moderno, ajudando os elementos-chave a se destacarem e adicionando profundidade à sua apresentação. Ao compreender o processo de aplicação e personalização desses efeitos, você pode adaptá‑los facilmente às necessidades de design e aos requisitos de marca.

Adicione um efeito de reflexão ao texto usando este exemplo de código C#:

```cs
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

![O efeito de reflexão](reflection_effect.png)

### **Aplicar efeitos de brilho**

Nesta seção, exploraremos como aplicar um efeito de brilho ao texto usando o Aspose.Slides para .NET. O efeito de brilho pode fazer seu texto se destacar com um contorno luminoso, aprimorando o apelo visual dos seus slides. Ajustando configurações como cor e intensidade, você pode adaptar facilmente o brilho ao seu design e às necessidades de marca, garantindo que os pontos chave da sua apresentação capturem a atenção do público.

Aplique um efeito de brilho ao texto para fazê‑lo brilhar ou se destacar usando o seguinte código:

```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

O texto resultante:

![O efeito de brilho](glow_effect.png)

### **Aplicar transformações de WordArt**

Nesta seção, exploraremos como usar transformações no WordArt com o Aspose.Slides para .NET. As transformações permitem dobrar, esticar ou deformar o texto, criando efeitos únicos e visualmente impressionantes. Ao dominar essas técnicas, você pode adaptar facilmente formas e estilos de texto ao seu branding ou visão criativa, garantindo uma apresentação convincente e polida.

Use a propriedade `Transform` (que se aplica a todo o bloco de texto) com o seguinte código:

```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

O texto resultante:

![A transformação de WordArt](transform_effect.png)

{{% alert color="primary" %}} 

O Aspose.Slides para .NET fornece um conjunto de [tipos de transformação](https://reference.aspose.com/slides/pt/net/aspose.slides/textshapetype/) predefinidos.

{{% /alert %}} 

### **Aplicar efeitos 3D a formas e texto**

Criar visuais realistas e chamativos pode melhorar significativamente o impacto de suas apresentações. Nesta seção, exploraremos como aplicar efeitos tridimensionais (3D) a formas usando o Aspose.Slides para .NET. Ao manipular parâmetros como profundidade, ângulo e iluminação, você pode produzir transformações 3D impressionantes que capturam imediatamente a atenção do público. Seja para realces sutis ou ilusões dramáticas, esses recursos oferecem maneiras flexíveis de elevar seu design e transmitir ideias de forma mais cativante.

Use o código de exemplo a seguir para definir um efeito 3D na forma:

```cs
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

Use o código de exemplo a seguir para definir um efeito 3D no texto:

```cs
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

O texto resultante:

![O efeito 3D do texto](text_3D_effect.png)

{{% alert color="primary" %}} 

A aplicação de efeitos 3D ao texto ou às suas formas—e a interação entre esses efeitos—é regida por regras específicas. Considere uma cena envolvendo tanto um texto quanto a forma que contém esse texto. Um efeito 3D inclui a representação 3D do objeto e a cena na qual ele está inserido.

- Se uma cena for definida tanto para a forma quanto para o texto, a cena da forma tem prioridade e a cena do texto é ignorada.
- Se a forma não possuir sua própria cena, mas tiver uma representação 3D, a cena do texto será usada.
- Se a forma não possuir nenhum efeito 3D, ela será tratada como plana, e o efeito 3D será aplicado somente ao texto.

Esses comportamentos relacionam‑se às propriedades [ThreeDFormat.LightRig](https://reference.aspose.com/slides/pt/net/aspose.slides/threedformat/lightrig/) e [ThreeDFormat.Camera](https://reference.aspose.com/slides/pt/net/aspose.slides/threedformat/camera/).

{{% /alert %}} 

## **Perguntas frequentes**

**Posso usar efeitos de WordArt com fontes ou scripts diferentes (por exemplo, árabe, chinês)?**

Sim, o Aspose.Slides para .NET oferece suporte a Unicode e funciona com todas as fontes e scripts principais. Efeitos de WordArt como sombra, preenchimento e contorno podem ser aplicados independentemente do idioma, embora a disponibilidade da fonte e a renderização possam depender das fontes do sistema.

**Posso aplicar efeitos de WordArt aos elementos do slide mestre?**

Sim, você pode aplicar efeitos de WordArt a formas nos slides mestres, incluindo marcadores de posição de título, rodapés ou texto de fundo. Alterações feitas no layout mestre serão refletidas em todos os slides associados.

**Os efeitos de WordArt afetam o tamanho do arquivo da apresentação?**

Um pouco. Efeitos de WordArt como sombras, brilhos e preenchimentos em degradê podem aumentar ligeiramente o tamanho do arquivo devido ao metadata de formatação adicional, mas a diferença costuma ser insignificante.

**Posso visualizar o resultado dos efeitos de WordArt sem salvar a apresentação?**

Sim, você pode renderizar slides que contêm WordArt em imagens (por exemplo, PNG, JPEG) usando o método `GetImage` das interfaces [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/) ou [ISlide](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/). Isso permite visualizar o resultado na memória ou na tela antes de salvar ou exportar a apresentação completa.