---
title: Applicare effetti di forma nelle presentazioni in .NET
linktitle: Effetto Forma
type: docs
weight: 30
url: /it/net/shape-effect/
keywords:
- effetto forma
- effetto ombra
- effetto riflessione
- effetto bagliore
- effetto bordi morbidi
- formato effetto
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Trasforma i tuoi file PPT e PPTX con effetti forma avanzati utilizzando Aspose.Slides per .NET—crea diapositive notevoli e professionali in pochi secondi."
---
## **Introduzione**

Mentre gli effetti in PowerPoint possono essere usati per far risaltare una forma, differiscono da [riempimenti](/slides/it/net/shape-formatting/#gradient-fill) o contorni. Utilizzando gli effetti di PowerPoint, è possibile creare riflessi convincenti su una forma, diffondere il bagliore di una forma, ecc.

![Effetto forma](shape-effect.png)

PowerPoint fornisce sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma.

Alcune combinazioni di effetti hanno un aspetto migliore di altre. Per questo motivo, PowerPoint offre opzioni sotto **Preset**. Le opzioni Preset sono essenzialmente una combinazione già nota e gradevole di due o più effetti. In questo modo, selezionando un preset, non dovrai perdere tempo a testare o combinare effetti diversi per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applica un effetto ombra**

Aspose.Slides per .NET supporta ombre esterne e interne per le forme. È possibile personalizzare il loro colore, direzione, distanza e raggio di sfocatura per corrispondere al design della presentazione.

### **Applica un'ombra esterna**

Utilizza un'ombra esterna per far risaltare una scheda o un pannello sullo sfondo della diapositiva. L'ombra si estende oltre i bordi della forma, creando l'impressione che la forma sia sollevata sopra la diapositiva. Regola colore, direzione, distanza e raggio di sfocatura per adeguarli all'illuminazione e allo stile del modello.

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

#### **Controlla la direzione dell'ombra quando una forma ruota**

Per impostazione predefinita, [RotateShadowWithShape](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/rotateshadowwithshape/) è `true`, quindi l'ombra ruota con la forma. Per far sì che forme con rotazioni diverse sembrino illuminate dalla stessa direzione, impostare questa proprietà su `false` e assegnare alle loro ombre la stessa [Direction](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/direction/).

L'esempio crea due frecce con ombre grigie spostate a destra (`Direction = 0`). Quindi duplica la diapositiva e ruota entrambe le frecce di 90° in senso orario.

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

Nella seconda diapositiva, la freccia sinistra proietta la sua ombra verso il basso, mentre la freccia destra projetta ancora la sua ombra verso destra. La direzione configurata rimane 0° per entrambe le ombre.

![Rendering PowerPoint prima e dopo una rotazione di 90°. Entrambe le ombre partono da destra. Dopo la rotazione, l'ombra si sposta sotto la freccia sinistra e rimane a destra della freccia destra.](arrow-shadow-rotation.png)

### **Applica un'ombra interna**

Quando si riproduce lo stile visivo di un modello, utilizzare un'ombra interna per dare a una scheda o a un pannello un aspetto incassato. Un'ombra esterna si estende al di fuori della forma e la fa apparire sollevata, mentre un'ombra interna ombreggia l'interno dei suoi bordi.

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

![Rettangolo azzurro chiaro con un'ombra interna](inner_shadow_effect.png)

Per rimuovere l'ombra interna, chiama [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) sul formato effetto della forma.

### **Applica, modifica e rimuovi un'ombra predefinita**

Chiama [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) e imposta [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) su un [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) denominato. Per cambiare stile, modifica il preset sulla stessa forma. Chiama [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) per rimuovere l'ombra mantenendo il riempimento e il contorno.

Questo esempio conserva una copia del rettangolo a ogni fase. Entrambe le ombre sono spostate di 10 punti. Una direzione di 225° posiziona la prima ombra sopra e a sinistra del rettangolo, e 45° posiziona la seconda sotto e a destra.

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

| Originale | Primo preset | Secondo preset | Dopo rimozione |
| :---: | :---: | :---: | :---: |
| ![Nessuna ombra](preset_shadow_original.png) | ![Ombra in alto a sinistra](preset_shadow_top_left.png) | ![Ombra in basso a destra](preset_shadow_bottom_right.png) | ![Nessuna ombra dopo la rimozione](preset_shadow_removed.png) |

## **Applica un effetto di riflessione**

Per applicare un effetto di riflessione in Aspose.Slides per .NET, è possibile aggiungere una riflessione simile a uno specchio alle forme, regolando parametri come distanza, trasparenza e dimensione. Questo effetto migliora l'estetica delle presentazioni conferendo alle forme un aspetto più curato e sofisticato. È facile da implementare con codice semplice, consentendo un'applicazione rapida su più elementi per un design coerente.

Questo codice C# mostra come applicare l'[effetto di riflessione](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) a una forma:

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

![Effetto di riflessione](reflection_effect.png)

## **Applica un effetto di bagliore**

Per applicare un effetto di bagliore a una forma in Aspose.Slides per .NET, è possibile aggiungere un'aura soffice e luminosa attorno alle forme, regolando proprietà come colore e dimensione. Questo effetto aiuta a far risaltare le forme e aggiunge un elemento visivo attraente e accattivante alla presentazione. È facile da implementare con poco codice, migliorando l'aspetto complessivo delle diapositive.

Questo codice C# mostra come applicare l'[effetto di bagliore](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) a una forma:

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

![Effetto di bagliore](glow_effect.png)

## **Applica un effetto bordi morbidi**

Per applicare un effetto bordi morbidi in Aspose.Slides per .NET, è possibile creare una transizione liscia e sfocata attorno ai bordi di una forma. Questo effetto aggiunge un aspetto più delicato e raffinato, perfetto per progetti che richiedono un aspetto gentile e più morbido. È possibile regolare facilmente parametri come il raggio per ottenere l'effetto desiderato su varie forme nella presentazione.

Questo codice C# mostra come applicare i [bordi morbidi](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) a una forma:

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

## **Applica un effetto di sfocatura**

Utilizza la sfocatura della forma per ammorbidire il riempimento e il contorno della forma mantenendola modificabile. Chiama [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) sul formato effetto della forma. Il raggio è misurato in punti (1/72 di pollice): usa un valore non negativo, con valori più grandi che producono una sfocatura più intensa. Un raggio pari a zero mantiene inalterato l'aspetto.

L'impostazione [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) controlla i limiti visibili dell'effetto. Con `false`, la sfocatura è ritagliata ai limiti originali dipinti, compreso il contorno. Con `true`, la sfocatura può estendersi oltre tali limiti. Nessuna delle due impostazioni modifica la posizione o le dimensioni della forma.

Il confronto qui sotto utilizza lo stesso riempimento, contorno e dimensioni della forma in tutto. La riga superiore usa `grow = false`; la riga inferiore usa `grow = true`.

![Rettangolo originale confrontato con raggi di sfocatura di 5 e 15 punti, con grow disabilitato e abilitato](shape_blur_comparison.png)

Questo esempio C# crea un rettangolo arancione con un contorno blu scuro, applica una sfocatura di 5 punti e poi la aggiorna a 15 punti richiamando nuovamente [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/). Salva entrambi gli stati sfocati, quindi chiama [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) e salva la forma senza sfocatura.

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

La sfocatura della forma agisce simultaneamente sul riempimento e sul contorno. Un effetto bordi morbidi attenua i bordi della forma, mentre la sfocatura dell'ombra ammorbidisce solo l'ombra. Gli effetti di trasformazione delle immagini operano sul contenuto dell'immagine; questo esempio applica la sfocatura direttamente al formato effetto della forma senza convertire la forma in un'immagine.

## **FAQ**

**Posso applicare più effetti alla stessa forma?**

Sì, è possibile combinare diversi effetti, come ombra, riflessione e bagliore, su una singola forma per ottenere un aspetto più dinamico.

**Su quali forme posso applicare gli effetti?**

È possibile applicare effetti a varie forme, incluse le forme automatiche, i grafici, le tabelle, le immagini, gli oggetti SmartArt, gli oggetti OLE e altro ancora.

**Posso applicare effetti a forme raggruppate?**

Sì, è possibile applicare effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.