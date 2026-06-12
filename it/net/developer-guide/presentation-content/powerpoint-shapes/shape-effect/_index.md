---
title: Applicare effetti di forma nelle presentazioni in .NET
linktitle: Effetto Forma
type: docs
weight: 30
url: /it/net/shape-effect
keywords:
- effetto forma
- effetto ombra
- effetto riflesso
- effetto bagliore
- effetto bordi morbidi
- formato effetto
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Trasforma i tuoi file PPT e PPTX con effetti forma avanzati usando Aspose.Slides per .NET—crea slide sorprendenti e professionali in pochi secondi."
---
## **Introduzione**

Mentre gli effetti in PowerPoint possono essere usati per far risaltare una forma, essi differiscono da [riempimenti](/slides/it/net/shape-formatting/#gradient-fill) o contorni. Utilizzando gli effetti di PowerPoint, è possibile creare riflessi realistici su una forma, diffondere il bagliore di una forma, ecc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

PowerPoint offre sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma.

Alcune combinazioni di effetti risultano più gradevoli di altre. Per questo motivo, PowerPoint dispone di opzioni sotto **Preset**. Le opzioni Preset rappresentano essenzialmente una combinazione nota e gradevole di due o più effetti. In questo modo, selezionando un preset, non sarà necessario perdere tempo a testare o combinare effetti diversi per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/it/net/aspose.slides/effectformat/) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applica un effetto ombra**

Per applicare un effetto ombra a una forma in Aspose.Slides per .NET, è possibile regolare facilmente parametri come colore, raggio di sfocatura e direzione. Questo conferisce alle forme un aspetto più dinamico e professionale, aggiungendo profondità e messa a fuoco. Utilizzando semplici frammenti di codice, è possibile applicare questi effetti a più forme, migliorando l'appeal visivo complessivo delle presentazioni.

Questo codice C# mostra come applicare l'[effetto ombra esterna](https://reference.aspose.com/slides/it/net/aspose.slides/effectformat/outershadoweffect/) a un rettangolo:

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

![Effetto ombra](shadow_effect.png)

## **Applica un effetto riflesso**

Per applicare un effetto riflesso in Aspose.Slides per .NET, è possibile aggiungere un riflesso simile a uno specchio alle forme, regolando parametri come distanza, trasparenza e dimensione. Questo effetto migliora l’estetica delle presentazioni conferendo alle forme un aspetto più raffinato e sofisticato. È facile da implementare con semplice codice, consentendo un’applicazione rapida a più elementi per un design coerente.

Questo codice C# mostra come applicare l'[effetto riflesso](https://reference.aspose.com/slides/it/net/aspose.slides/effectformat/reflectioneffect/) a una forma:

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

![Effetto riflesso](reflection_effect.png)

## **Applica un effetto bagliore**

Per applicare un effetto bagliore a una forma in Aspose.Slides per .NET, è possibile aggiungere una morbida aurea luminosa attorno alle forme, regolando proprietà come colore e dimensione. Questo effetto aiuta a far risaltare le forme e aggiunge un elemento visivo attraente ai vostri slide. È facile da implementare con un minimo di codice, migliorando l'aspetto complessivo delle vostre presentazioni.

Questo codice C# mostra come applicare l'[effetto bagliore](https://reference.aspose.com/slides/it/net/aspose.slides/effectformat/gloweffect/) a una forma:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Effetto bagliore](glow_effect.png)

## **Applica un effetto bordi morbidi**

Per applicare un effetto bordi morbidi in Aspose.Slides per .NET, è possibile creare una transizione fluida e sfocata attorno ai bordi di una forma. Questo effetto aggiunge un aspetto più sottile e raffinato, perfetto per design che richiedono un aspetto delicato e più soffice. È possibile regolare facilmente parametri come il raggio per ottenere l’effetto desiderato su varie forme nella presentazione.

Questo codice C# mostra come applicare i [bordi morbidi](https://reference.aspose.com/slides/it/net/aspose.slides/effectformat/softedgeeffect/) a una forma:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Effetto bordi morbidi](soft_edges_effect.png)

## **FAQ**

**Posso applicare più effetti alla stessa forma?**

Sì, è possibile combinare diversi effetti, come ombra, riflesso e bagliore, su un’unica forma per creare un aspetto più dinamico.

**A quali forme posso applicare gli effetti?**

È possibile applicare gli effetti a varie forme, incluse forme autogeneriche, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro ancora.

**Posso applicare gli effetti a forme raggruppate?**

Sì, è possibile applicare gli effetti a forme raggruppate. L’effetto verrà applicato all’intero gruppo.