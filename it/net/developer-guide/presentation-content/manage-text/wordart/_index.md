---
title: Crea e applica effetti WordArt in .NET
linktitle: WordArt
type: docs
weight: 110
url: /it/net/wordart/
keywords:
- WordArt
- crea WordArt
- modello WordArt
- effetto WordArt
- effetto ombra
- effetto riflesso
- effetto bagliore
- trasformazione WordArt
- effetto 3D
- effetto ombra esterna
- effetto ombra interna
- .NET
- C#
- Aspose.Slides
description: "Crea e personalizza gli effetti WordArt in Aspose.Slides per .NET. Questa guida passo-passo aiuta gli sviluppatori a migliorare le presentazioni con testo professionale in C#."
---
## **Panoramica**

Gli effetti WordArt consentono di formattare il testo con riempimenti, contorni, ombre, riflessi, bagliore, trasformazioni e formattazione 3D. Questo articolo spiega come creare e personalizzare questi effetti nelle presentazioni PowerPoint usando Aspose.Slides per .NET, senza Microsoft Office installato.

## **Crea un modello WordArt semplice e applicalo al testo**

Gli esempi seguenti creano uno stile WordArt semplice impostando il testo, il carattere, il riempimento a motivo e il contorno.

Ogni esempio crea una nuova presentazione e aggiunge un rettangolo alla sua prima diapositiva; non è necessario un file di input. Il primo esempio imposta il testo a "Aspose.Slides". La posizione e le dimensioni della forma sono misurate in punti:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Imposta il carattere a Arial Black a 36 punti per rendere la formattazione più evidente:

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

Applica un motivo [SmallGrid](https://reference.aspose.com/slides/it/net/aspose.slides/patternstyle/) con un primo piano arancione scuro e uno sfondo bianco, quindi aggiungi un contorno del testo nero con larghezza di 1 punto:

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

Il testo risultante:

![Il modello WordArt semplice](WordArt_template.png)

## **Applica altri effetti WordArt**

Gli esempi seguenti mostrano come applicare ombre, riflessi, bagliori, trasformazioni e effetti 3D al testo.

### **Applica effetti di ombra esterna**

Un'ombra esterna aggiunge profondità posizionando un'ombra dietro il testo. Puoi personalizzare il colore, la direzione, la distanza, il raggio di sfocatura, la scala e l'inclinazione.

Questo esempio chiama [EnableOuterShadowEffect](https://reference.aspose.com/slides/it/net/aspose.slides/effectformat/enableoutershadoweffect/) e imposta un'ombra nera con un raggio di sfocatura di 4 punti, una direzione di 230 gradi e una distanza di 30 punti. I valori di scala pari a 100 conservano le dimensioni dell'ombra, mentre l'inclinazione orizzontale la inclina di 20 gradi. La trasformazione alpha imposta l'opacità al 32%:

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

Il testo risultante:

![L'effetto Ombra Esterna](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Quando ombre esterne e predefinite sono usate insieme, viene applicata solo l'ombra esterna.
- Se ombre esterne e interne vengono usate simultaneamente, l'effetto risultante dipende dalla versione di PowerPoint. Ad esempio, in PowerPoint 2013 l'effetto è raddoppiato, mentre in PowerPoint 2007 viene applicata solo l'ombra esterna.
{{% /alert %}}

### **Applica effetti di riflessione**

Una riflessione crea una copia speculare del testo. Regola posizione, scala, sfocatura e opacità per controllarne l'aspetto.

Questo esempio chiama [EnableReflectionEffect](https://reference.aspose.com/slides/it/net/aspose.slides/effectformat/enablereflectioneffect/) e capovolge verticalmente la riflessione con una scala del -100 %. Utilizza un raggio di sfocatura di 0,5 punti e una distanza di 4,72 punti. L'opacità diminuisce dal 60 % allo 0,9 % tra le posizioni 0 % e 60 % lungo la riflessione:

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

Il testo risultante:

![L'effetto Riflesso](reflection_effect.png)

### **Applica effetti di bagliore**

Un bagliore aggiunge un contorno colorato soffuso intorno al testo. Regola colore, opacità e raggio per controllarne l'effetto.

Questo esempio chiama [EnableGlowEffect](https://reference.aspose.com/slides/it/net/aspose.slides/effectformat/enablegloweffect/) e applica un bagliore rosso con opacità del 54 % e raggio di 7 punti:

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

Il testo risultante:

![L'effetto Bagliore](glow_effect.png)

### **Applica trasformazioni WordArt**

Le trasformazioni WordArt curvano, allungano o deformano un blocco di testo.

Imposta [Transform](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat/transform/) a [ArchUpPour](https://reference.aspose.com/slides/it/net/aspose.slides/textshapetype/) per curvare l'intero riquadro di testo verso l'alto:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Il testo risultante:

![La trasformazione WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides per .NET fornisce un insieme di [tipi di trasformazione](https://reference.aspose.com/slides/it/net/aspose.slides/textshapetype/) predefiniti.
{{% /alert %}}

### **Applica effetti 3D a forme e testo**

Puoi applicare effetti 3D a una forma o al suo testo. Smussi, estrusione, illuminazione e impostazioni della telecamera controllano l'aspetto risultante.

L'esempio seguente utilizza [ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/threedformat/) per aggiungere smussi circolari, estrusione arancione e un contorno rosso scuro al rettangolo. Le dimensioni dello smusso, l'altezza dell'estrusione, la larghezza del contorno e la profondità sono misurate in punti. Un materiale plastico, illuminazione bilanciata ruotata di 40 gradi attorno all'asse Z e una telecamera prospettica ne definiscono l'aspetto:

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

La forma risultante:

![L'effetto 3D della forma](shape_3D_effect.png)

Questo esempio applica una formattazione 3D simile al testo tramite [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat/threedformat/). Smussi più piccoli modellano i bordi delle lettere, mentre estrusione e illuminazione conferiscono profondità al testo:

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

Il testo risultante:

![L'effetto 3D del testo](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
L'applicazione di effetti 3D al testo o alle sue forme — e l'interazione tra questi effetti — è governata da regole specifiche. Considera una scena che coinvolge sia il testo sia la forma che lo contiene. Un effetto 3D include la rappresentazione 3D dell'oggetto e la scena in cui è posizionato.

- Se una scena è impostata sia per la forma sia per il testo, la scena della forma ha priorità e quella del testo è ignorata.
- Se la forma non ha una sua scena ma possiede una rappresentazione 3D, viene utilizzata la scena del testo.
- Se la forma non ha alcun effetto 3D, viene trattata come piatta e l'effetto 3D viene applicato solo al testo.

Questi comportamenti riguardano le proprietà [ThreeDFormat.LightRig](https://reference.aspose.com/slides/it/net/aspose.slides/threedformat/lightrig/) e [ThreeDFormat.Camera](https://reference.aspose.com/slides/it/net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Per mantenere il testo piatto e leggibile conservando la formattazione 3D della forma, consulta [Mantieni il testo piatto su una forma 3D](/slides/it/net/3d-presentation/) per un confronto tra entrambe le impostazioni e un esempio completo in C#.

## **FAQ**

**Posso usare gli effetti WordArt con caratteri o script diversi (ad es. arabo, cinese)?**

Sì, Aspose.Slides per .NET supporta Unicode e funziona con tutti i principali caratteri e script. Gli effetti WordArt come ombra, riempimento e contorno possono essere applicati indipendentemente dalla lingua, sebbene la disponibilità dei caratteri e il rendering possano dipendere dai caratteri di sistema.

**Posso applicare gli effetti WordArt agli elementi del master della diapositiva?**

Sì, puoi applicare gli effetti WordArt alle forme nei master delle diapositive, inclusi i segnaposto del titolo, i piè di pagina o il testo di sfondo. Le modifiche al layout master verranno propagate a tutte le diapositive associate.

**Gli effetti WordArt influiscono sulle dimensioni del file della presentazione?**

Leggermente. Effetti come ombre, bagliori e riempimenti sfumati possono aumentare marginalmente le dimensioni del file a causa dei metadati di formattazione aggiunti, ma la differenza è solitamente trascurabile.

**Posso visualizzare un'anteprima del risultato degli effetti WordArt senza salvare la presentazione?**

Sì, puoi generare le diapositive contenenti WordArt in immagini (ad es. PNG, JPEG) usando [ISlide.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/islide/getimage/), o rendere immagini delle singole forme con [IShape.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/getimage/). Questo consente di visualizzare l'anteprima in memoria o sullo schermo prima di salvare o esportare l'intera presentazione.