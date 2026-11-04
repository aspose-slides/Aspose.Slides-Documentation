---
title: Applica effetti forma nelle presentazioni in .NET
linktitle: Effetto forma
type: docs
weight: 30
url: /it/net/shape-effect/
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
description: "Trasforma i tuoi file PPT e PPTX con effetti forma avanzati utilizzando Aspose.Slides per .NET—crea diapositive accattivanti e professionali in pochi secondi."
---
## **Introduzione**

Mentre gli effetti in PowerPoint possono essere usati per far risaltare una forma, differiscono da [riempimenti](/slides/it/net/shape-formatting/#gradient-fill) o contorni. Usando gli effetti di PowerPoint, è possibile creare riflessi convincenti su una forma, diffondere l’aura di una forma, ecc.

![Effetto forma](shape-effect.png)

PowerPoint fornisce sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma.

Alcune combinazioni di effetti hanno un aspetto migliore di altre. Per questo motivo, PowerPoint offre opzioni sotto **Preset**. Le opzioni Preset sono essenzialmente una combinazione già collaudata di due o più effetti. In questo modo, scegliendo un preset, non dovrai perdere tempo a testare o combinare effetti diversi per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applica un effetto ombra**

Aspose.Slides per .NET supporta ombre esterne e interne per le forme. È possibile personalizzare colore, direzione, distanza e raggio di sfocatura per adattarli al design della presentazione.

### **Applica un'ombra esterna**

Usa un'ombra esterna per far risaltare una scheda o un pannello sullo sfondo della diapositiva. L'ombra si estende oltre i bordi della forma, creando l'impressione che la forma sia sollevata sopra la diapositiva. Regola colore, direzione, distanza e raggio di sfocatura per corrispondere all'illuminazione e allo stile del tuo modello.

Questo codice C# mostra come applicare l'[effetto ombra esterna](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) a un rettangolo:

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

![Effetto ombra](shadow_effect.png)

### **Applica un'ombra interna**

Quando riproduci lo stile visivo di un modello, usa un'ombra interna per dare a una scheda o a un pannello un aspetto incassato. Un'ombra esterna si estende fuori dalla forma e la fa apparire sollevata, mentre un'ombra interna ombreggia l'interno dei suoi bordi.

Chiama [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), quindi configura [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Valori più alti producono bordi più morbidi.

Questo esempio C# crea una scheda azzurro chiaro con un'ombra interna grigio scuro e la salva come file PPTX:

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

![Rettangolo blu chiaro con ombra interna](inner_shadow_effect.png)

Per rimuovere l'ombra interna, chiama [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) sul formato effetto della forma.

## **Applica un effetto riflesso**

Per applicare un effetto riflesso in Aspose.Slides per .NET, puoi aggiungere un riflesso speculare alle forme, regolando parametri come distanza, trasparenza e dimensione. Questo effetto migliora l'estetica delle presentazioni conferendo alle forme un aspetto più levigato e sofisticato. È facile da implementare con codice semplice, consentendo un'applicazione rapida su più elementi per un design coerente.

Questo codice C# mostra come applicare l'[effetto riflesso](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) a una forma:

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

![Effetto riflesso](reflection_effect.png)

## **Applica un effetto bagliore**

Per applicare un effetto bagliore a una forma in Aspose.Slides per .NET, è possibile aggiungere un'aura luminosa soffusa intorno alle forme, regolando proprietà come colore e dimensione. Questo effetto aiuta le forme a risaltare e aggiunge un elemento visivo accattivante alla presentazione. È facile da implementare con poco codice, migliorando l'aspetto complessivo delle diapositive.

Questo codice C# mostra come applicare l'[effetto bagliore](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) a una forma:

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

![Effetto bagliore](glow_effect.png)

## **Applica un effetto bordi morbidi**

Per applicare un effetto bordi morbidi in Aspose.Slides per .NET, è possibile creare una transizione liscia e sfocata attorno ai bordi di una forma. Questo effetto aggiunge un aspetto più sottile e raffinato, perfetto per design che richiedono un aspetto delicato. È possibile regolare facilmente parametri come il raggio per ottenere l'effetto desiderato su varie forme nella presentazione.

Questo codice C# mostra come applicare gli [effetti bordi morbidi](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) a una forma:

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

![Effetto bordi morbidi](soft_edges_effect.png)

## **Applica un effetto sfocatura**

Usa la sfocatura della forma per ammorbidire il riempimento e il contorno di una forma mantenendola modificabile. Chiama [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) sul formato effetto della forma. Il raggio è misurato in punti (1/72 di pollice): utilizza un valore non negativo, con valori più alti che producono una sfocatura più intensa. Un raggio pari a zero non altera l'aspetto.

L'impostazione [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) controlla i limiti visibili dell'effetto. Con `false`, la sfocatura è limitata ai bordi dipinti originari, includendo il contorno. Con `true`, la sfocatura può estendersi oltre tali limiti. Nessuna delle due impostazioni modifica la posizione o le dimensioni della forma.

Il confronto sotto utilizza lo stesso riempimento, contorno e dimensioni della forma in tutto il documento. La riga superiore usa `grow = false`; la riga inferiore usa `grow = true`.

![Rettangolo originale confrontato con raggi di sfocatura di 5 e 15 punti, con grow disabilitato e abilitato](shape_blur_comparison.png)

Questo esempio C# crea un rettangolo arancione con un contorno blu scuro, applica una sfocatura di 5 punti, quindi la aggiorna a 15 punti chiamando nuovamente [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/). Salva entrambi gli stati sfocati, poi chiama [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) e salva la forma senza sfocatura.

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

La sfocatura della forma influenza insieme riempimento e contorno. Un effetto bordi morbidi attenua i bordi della forma, mentre la sfocatura dell'ombra ammorbidisce solo l'ombra. Gli effetti di trasformazione delle immagini operano sul contenuto dell'immagine; questo esempio applica la sfocatura direttamente al formato effetto della forma senza convertire la forma in immagine.

## **FAQ**

**Posso applicare più effetti alla stessa forma?**

Sì, è possibile combinare diversi effetti, come ombra, riflesso e bagliore, su una singola forma per creare un aspetto più dinamico.

**Su quali forme posso applicare gli effetti?**

È possibile applicare gli effetti a varie forme, incluse forme automatiche, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro ancora.

**Posso applicare effetti a forme raggruppate?**

Sì, è possibile applicare effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.