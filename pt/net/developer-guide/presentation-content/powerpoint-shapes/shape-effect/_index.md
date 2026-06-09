---
title: Aplicar efeitos de forma em apresentações em .NET
linktitle: Efeito de Forma
type: docs
weight: 30
url: /pt/net/shape-effect
keywords:
- efeito de forma
- efeito de sombra
- efeito de reflexo
- efeito de brilho
- efeito de bordas suaves
- formato de efeito
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Transforme seus arquivos PPT e PPTX com efeitos avançados de forma usando Aspose.Slides para .NET—crie slides impressionantes e profissionais em segundos."
---
## **Introdução**

Embora os efeitos no PowerPoint possam ser usados para fazer uma forma se destacar, eles diferem de [preenchimentos](/slides/pt/net/shape-formatting/#gradient-fill) ou contornos. Usando os efeitos do PowerPoint, você pode criar reflexos convincentes em uma forma, espalhar o brilho de uma forma, etc.

<img src="shape-effect.png" alt="efeito de forma" style="zoom:50%;" />

PowerPoint oferece seis efeitos que podem ser aplicados a formas. Você pode aplicar um ou mais efeitos a uma forma.

Algumas combinações de efeitos ficam melhores que outras. Por esse motivo, o PowerPoint tem opções em **Preset**. As opções de Preset são essencialmente combinações já testadas de dois ou mais efeitos que apresentam boa aparência. Dessa forma, ao selecionar um preset, você não precisará perder tempo testando ou combinando diferentes efeitos para encontrar uma combinação agradável.

Aspose.Slides fornece propriedades e métodos na classe [EffectFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/effectformat/) que permitem aplicar os mesmos efeitos a formas em apresentações do PowerPoint.

## **Aplicar um Efeito de Sombra**

Para aplicar um efeito de sombra a uma forma no Aspose.Slides for .NET, você pode ajustar facilmente parâmetros como cor, raio de desfoque e direção. Isso confere às suas formas uma aparência mais dinâmica e profissional, adicionando profundidade e foco. Usando trechos de código simples, você pode aplicar esses efeitos a múltiplas formas, aprimorando o apelo visual geral de suas apresentações.

Este código C# mostra como aplicar o [efeito de sombra externa](https://reference.aspose.com/slides/pt/net/aspose.slides/effectformat/outershadoweffect/) a um retângulo:

```c#
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

## **Aplicar um Efeito de Reflexo**

Para aplicar um efeito de reflexo no Aspose.Slides for .NET, você pode adicionar um reflexo semelhante a um espelho nas formas, ajustando parâmetros como distância, transparência e tamanho. Esse efeito melhora a estética de suas apresentações ao conferir às formas um aspecto mais polido e sofisticado. É fácil de implementar com código simples, permitindo a aplicação rápida em vários elementos para um design consistente.

Este código C# mostra como aplicar o [efeito de reflexo](https://reference.aspose.com/slides/pt/net/aspose.slides/effectformat/reflectioneffect/) a uma forma:

```c#
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

![Efeito de reflexo](reflection_effect.png)

## **Aplicar um Efeito de Brilho**

Para aplicar um efeito de brilho a uma forma no Aspose.Slides for .NET, você pode adicionar uma aura suave e luminosa ao redor das formas, ajustando propriedades como cor e tamanho. Esse efeito ajuda as formas a se destacarem e adiciona um elemento visual atraente e chamativo à sua apresentação. É fácil de implementar com código mínimo, aprimorando a aparência geral dos seus slides.

Este código C# mostra como aplicar o [efeito de brilho](https://reference.aspose.com/slides/pt/net/aspose.slides/effectformat/gloweffect/) a uma forma:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Efeito de brilho](glow_effect.png)

## **Aplicar um Efeito de Bordas Suaves**

Para aplicar um efeito de bordas suaves no Aspose.Slides for .NET, você pode criar uma transição lisa e desfocada ao redor das bordas de uma forma. Esse efeito confere uma aparência mais sutil e refinada, perfeita para designs que necessitam de um visual delicado e mais suave. Você pode ajustar facilmente parâmetros como raio para alcançar o efeito desejado em várias formas da sua apresentação.

Este código C# mostra como aplicar os [bordas suaves](https://reference.aspose.com/slides/pt/net/aspose.slides/effectformat/softedgeeffect/) a uma forma:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Efeito de bordas suaves](soft_edges_effect.png)

## **Perguntas Frequentes**

**Posso aplicar múltiplos efeitos à mesma forma?**

Sim, você pode combinar diferentes efeitos, como sombra, reflexo e brilho, em uma única forma para criar uma aparência mais dinâmica.

**Quais formas posso aplicar efeitos?**

Você pode aplicar efeitos a várias formas, incluindo autoshapes, gráficos, tabelas, imagens, objetos SmartArt, objetos OLE e muito mais.

**Posso aplicar efeitos a formas agrupadas?**

Sim, você pode aplicar efeitos a formas agrupadas. O efeito será aplicado a todo o grupo.