---
title: Aplicar efeitos de forma em apresentações em .NET
linktitle: Efeito de forma
type: docs
weight: 30
url: /pt/net/shape-effect/
keywords:
- efeito de forma
- efeito de sombra
- efeito de reflexão
- efeito de brilho
- efeito de bordas suaves
- formato de efeito
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Transforme seus arquivos PPT e PPTX com efeitos de forma avançados usando Aspose.Slides para .NET — crie slides impressionantes e profissionais em segundos."
---
## **Introdução**

Embora os efeitos no PowerPoint possam ser usados para fazer uma forma se destacar, eles diferem de [fills](/slides/pt/net/shape-formatting/#gradient-fill) ou contornos. Usando os efeitos do PowerPoint, você pode criar reflexos convincentes em uma forma, espalhar o brilho de uma forma, etc.

![Efeito de forma](shape-effect.png)

O PowerPoint fornece seis efeitos que podem ser aplicados a formas. Você pode aplicar um ou mais efeitos a uma forma.

Algumas combinações de efeitos ficam melhores que outras. Por esse motivo, o PowerPoint tem opções em **Preset**. As opções de Preset são essencialmente uma combinação conhecida de boa aparência de dois ou mais efeitos. Dessa forma, ao selecionar um preset, você não precisará perder tempo testando ou combinando diferentes efeitos para encontrar uma combinação agradável.

Aspose.Slides fornece propriedades e métodos na classe [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) que permitem aplicar os mesmos efeitos a formas em apresentações do PowerPoint.

## **Aplicar um efeito de sombra**

Aspose.Slides for .NET oferece sombras externas e internas para formas. Você pode personalizar sua cor, direção, distância e raio de desfoque para combinar com o design da sua apresentação.

### **Aplicar uma sombra externa**

Use uma sombra externa para fazer um cartão ou painel se destacar em relação ao plano de fundo do slide. A sombra se estende além das bordas da forma, criando a impressão de que a forma está elevada acima do slide. Ajuste sua cor, direção, distância e raio de desfoque para combinar com a iluminação e o estilo do seu modelo.

Este código C# mostra como aplicar o [efeito de sombra externa](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) a um retângulo:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![Efeito de sombra](shadow_effect.png)

#### **Controlar a direção da sombra quando uma forma gira**

Por padrão, [RotateShadowWithShape](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/rotateshadowwithshape/) é `true`, portanto a sombra gira com a forma. Para fazer formas com rotações diferentes parecerem iluminadas da mesma direção, defina esta propriedade como `false` e dê às sombras a mesma [Direction](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/direction/).

O exemplo cria duas setas com sombras cinzas deslocadas para a direita (`Direction = 0`). Em seguida, duplica o slide e gira ambas as setas 90° no sentido horário.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var before = presentation.Slides[0];

var left = before.Shapes.AddAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
left.FillFormat.FillType = FillType.Solid;
left.FillFormat.SolidFillColor.Color = Color.SteelBlue;
left.LineFormat.FillFormat.FillType = FillType.NoFill;

left.EffectFormat.EnableOuterShadowEffect();
var shadow = left.EffectFormat.OuterShadowEffect;
shadow.ShadowColor.Color = Color.Gray;
shadow.Direction = 0;
shadow.Distance = 42;
shadow.BlurRadius = 0;
shadow.RotateShadowWithShape = true;

var right = before.Shapes.AddClone(left);
right.X = 395;
right.EffectFormat.OuterShadowEffect.RotateShadowWithShape = false;

var after = presentation.Slides.AddClone(before);
foreach (var arrow in after.Shapes)
    arrow.Rotation = 90;

presentation.Save("arrow_shadows.pptx", SaveFormat.Pptx);
```

No segundo slide, a seta esquerda projeta sua sombra para baixo, enquanto a seta direita ainda projeta sua sombra para a direita. A direção configurada permanece 0° para ambas as sombras.

![Renderização do PowerPoint antes e depois de uma rotação de 90°. Ambas as sombras começam à direita. Após a rotação, a sombra move‑se abaixo da seta esquerda e permanece à direita da seta direita.](arrow-shadow-rotation.png)

### **Aplicar uma sombra interna**

Ao reproduzir o estilo visual de um modelo, use uma sombra interna para dar a um cartão ou painel uma aparência rebaixada. Uma sombra externa se estende fora da forma e faz com que ela pareça elevada, enquanto uma sombra interna sombreia o interior de suas bordas.

Chame [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), então configure [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Valores maiores produzem bordas mais suaves.

Este exemplo C# cria um cartão azul claro com uma sombra interna cinza escura e o salva como arquivo PPTX:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![Retângulo azul claro com sombra interna](inner_shadow_effect.png)

Para remover a sombra interna, chame [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) no formato de efeito da forma.

### **Aplicar, alterar e remover uma sombra predefinida**

Chame [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) e defina [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) para um [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) nomeado. Para trocar estilos, altere o preset na mesma forma. Chame [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) para remover a sombra mantendo o preenchimento e o contorno.

Este exemplo mantém uma cópia do retângulo em cada etapa. Ambas as sombras são deslocadas em 10 pontos. Uma direção de 225° coloca a primeira sombra acima e à esquerda do retângulo, e 45° coloca a segunda abaixo e à direita.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| Original | Primeira predefinição | Segunda predefinição | Após remoção |
| :---: | :---: | :---: | :---: |
| ![Sem sombra](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![Sem sombra após remoção](preset_shadow_removed.png) |

## **Aplicar um efeito de reflexão**

Para aplicar um efeito de reflexão no Aspose.Slides for .NET, você pode adicionar uma reflexão semelhante a um espelho nas formas, ajustando parâmetros como distância, transparência e tamanho. Este efeito melhora a estética de suas apresentações ao dar às formas um aspecto mais polido e sofisticado. É fácil de implementar com código simples, permitindo aplicação rápida em vários elementos para um design consistente.

Este código C# mostra como aplicar o [efeito de reflexão](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) a uma forma:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![Efeito de reflexão](reflection_effect.png)

## **Aplicar um efeito de brilho**

Para aplicar um efeito de brilho a uma forma no Aspose.Slides for .NET, você pode adicionar uma aura suave e luminosa ao redor das formas, ajustando propriedades como cor e tamanho. Este efeito ajuda a fazer as formas se destacarem e adiciona um elemento visual atraente e chamativo à sua apresentação. É fácil de implementar com pouco código, aprimorando a aparência geral dos seus slides.

Este código C# mostra como aplicar o [efeito de brilho](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) a uma forma:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Efeito de brilho](glow_effect.png)

## **Aplicar um efeito de bordas suaves**

Para aplicar um efeito de bordas suaves no Aspose.Slides for .NET, você pode criar uma transição lisa e desfocada ao redor das bordas de uma forma. Este efeito adiciona um aspecto mais sutil e refinado, perfeito para designs que precisam de uma aparência delicada e macia. Você pode ajustar facilmente parâmetros como raio para obter o efeito desejado em várias formas da sua apresentação.

Este código C# mostra como aplicar o [efeito de bordas suaves](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) a uma forma:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Efeito de bordas suaves](soft_edges_effect.png)

## **Aplicar um efeito de desfoque**

Use o desfoque de forma para suavizar o preenchimento e o contorno de uma forma mantendo-a editável. Chame [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) no formato de efeito da forma. O raio é medido em pontos (1/72 polegada): use um valor não negativo, sendo que valores maiores produzem desfoque mais intenso. Um raio de zero deixa a aparência inalterada.

A configuração [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) controla os limites visíveis do efeito. Com `false`, o desfoque é recortado aos limites originais pintados, incluindo o contorno. Com `true`, o desfoque pode se estender além desses limites. Nenhuma das configurações altera a posição ou as dimensões da forma.

A comparação abaixo usa o mesmo preenchimento, contorno e dimensões da forma em todos os casos. A linha superior usa `grow = false`; a linha inferior usa `grow = true`.

![Retângulo original comparado com raios de desfoque de 5 e 15 pontos, com grow desativado e ativado](shape_blur_comparison.png)

Este exemplo C# cria um retângulo laranja com contorno azul escuro, aplica um desfoque de 5 pontos e depois o atualiza para um desfoque de 15 pontos chamando [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) novamente. Ele salva ambos os estados desfocados, então chama [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) e salva a forma sem desfoque.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

O desfoque de forma afeta o preenchimento e o contorno juntos. Um efeito de bordas suaves desfoca as bordas da forma, enquanto o desfoque da sombra suaviza apenas a sombra. Os efeitos de transformação de imagem operam no conteúdo da imagem; este exemplo aplica desfoque diretamente ao formato de efeito da forma sem converter a forma em imagem.

## **FAQ**

**Posso aplicar múltiplos efeitos à mesma forma?**

Sim, você pode combinar diferentes efeitos, como sombra, reflexão e brilho, em uma única forma para criar uma aparência mais dinâmica.

**A quais formas posso aplicar efeitos?**

Você pode aplicar efeitos a várias formas, incluindo autoshapes, gráficos, tabelas, imagens, objetos SmartArt, objetos OLE e muito mais.

**Posso aplicar efeitos a formas agrupadas?**

Sim, você pode aplicar efeitos a formas agrupadas. O efeito será aplicado a todo o grupo.