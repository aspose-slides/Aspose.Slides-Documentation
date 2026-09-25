---
title: Crea effetti 3D nelle presentazioni usando .NET
linktitle: Presentazione 3D
type: docs
weight: 232
url: /it/net/3d-presentation/
keywords:
- PowerPoint 3D
- presentazione 3D
- rotazione 3D
- profondità 3D
- estrusione 3D
- gradiente 3D
- testo 3D
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Applica e rendi gli effetti 3D per le forme e il testo di PowerPoint in .NET con Aspose.Slides. Configura telecamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides per .NET può creare, modificare, conservare e rendere la formattazione 3D in stile PowerPoint per forme e testo. Questo articolo copre gli effetti 3D come rotazione, estrusione, smussature, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="info" title="Note" %}}
Questo articolo riguarda gli effetti di formattazione 3D su forme e testo di PowerPoint. Non tratta l'inserimento o la modifica di file di modelli 3D autonomi. Quando esporti una diapositiva in un'immagine, PDF o HTML, Aspose.Slides rende quegli effetti 3D nell'output 2D esportato.
{{% /alert %}}

## **Concetti di Formattazione 3D**

Usa la proprietà [IShape.ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/properties/threedformat) per applicare la formattazione 3D a una forma. La proprietà espone [IThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat), che controlla la scena 3D per quella forma.

Per il testo, usa la proprietà [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/properties/threedformat). Questo applica la formattazione 3D al riquadro di testo invece che al corpo della forma.

Le proprietà più importanti sono:

| Proprietà | Cosa controlla | Quando usarla |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/camera) | Punto di vista, tipo di telecamera predefinito, rotazione, zoom e prospettiva. | Ruota l'oggetto nello spazio 3D o corrispondi a un preset di rotazione 3D di PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/lightrig) | Preset di illuminazione, direzione e rotazione della luce. | Modifica come appaiono le luci e le ombre sulla superficie 3D. |
| [Material](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/material) | Materiale della superficie, come piatto, opaco, plastica o metallo. | Rende la stessa geometria più piatta, morbida, lucida o metallica. |
| [ExtrusionHeight](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/extrusionheight) | Quanto la forma si estende all'indietro dalla sua faccia frontale. | Trasforma una forma piatta in un oggetto 3D visibilmente spesso. |
| [ExtrusionColor](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Colore dei lati estrusi. | Rende la profondità visibile o coordina il colore dei lati con il riempimento frontale. |
| [Depth](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/depth) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Regola finemente la profondità per forme o testo, specialmente insieme alle impostazioni di smussatura e materiale. |
| [BevelTop](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/beveltop) e [BevelBottom](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/bevelbottom) | Bordi sollevati o arrotondati sulle facce frontale e posteriore. | Aggiungi un bordo smussato o modellato invece di una faccia piatta e affilata. |
| [ContourColor](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/contourcolor) e [ContourWidth](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/contourwidth) | Contorno intorno all'oggetto 3D. | Evidenzia il contorno dell'oggetto nell'output renderizzato. |

## **Crea una Forma 3D**

Una forma solitamente necessita di quattro tipi di impostazioni prima di apparire convincente in 3D:

- Impostazioni della telecamera, perché la vista frontale predefinita può nascondere l'estrusione.  
- Impostazioni di illuminazione, perché la luce rende leggibili le facce e i lati.  
- Impostazioni del materiale, perché la superficie influisce su come la luce viene resa.  
- Impostazioni di estrusione o profondità, perché una forma piatta ha bisogno di spessore.  

Il seguente esempio crea un rettangolo, aggiunge testo alla sua faccia frontale e applica la formattazione 3D. I valori di rotazione della telecamera sono in gradi e l'altezza dell'estrusione è 100 punti. L'esempio rende la diapositiva in un'immagine PNG a dimensioni doppie rispetto al valore predefinito e salva la presentazione come PPTX.

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

L'immagine della diapositiva renderizzata mostra il rettangolo come un blocco 3D spesso:

![Rettangolo 3D blu renderizzato con testo 3D bianco sulla faccia frontale](img_01_01.png)

## **Ruota una Forma con la Telecamera**

In PowerPoint, la rotazione 3D è configurata dal pannello Rotazione 3-D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della telecamera.

![Pannello Rotazione 3-D di PowerPoint con i valori di rotazione X, Y e Z evidenziati](img_02_01.png)

In Aspose.Slides, accedi alla telecamera tramite [IThreeDFormat.Camera](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/camera). Questo esempio crea un rettangolo, seleziona una vista frontale ortografica e imposta le rotazioni X, Y e Z a 20, 30 e 40 gradi, rispettivamente. Configura la forma in memoria senza salvare un file:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Usa la telecamera quando devi cambiare il modo in cui lo spettatore vede l'oggetto. Non modifica la geometria 2D della forma sulla diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

## **Aggiungi Estrusione e Profondità**

L'estrusione rende una forma spessa estendendola dietro la faccia frontale. In PowerPoint, il controllo della profondità imposta questo spessore visibile e il controllo del colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint mappati alle proprietà di colore e altezza dell'estrusione](img_02_02.png)

Imposta [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/extrusionheight) per lo spessore e [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/extrusioncolor) per il colore laterale. Questo esempio assegna al rettangolo un'estrusione di 100 punti con lati viola e ruota la telecamera per mostrarne lo spessore. Configura la forma in memoria senza salvare un file:

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

La proprietà [IThreeDFormat.Depth](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/depth) imposta la profondità di una forma 3D. La proprietà [ExtrusionHeight](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/extrusionheight) controlla l'altezza dell'effetto di estrusione, come mostrato in questo esempio.

## **Usa Riempimenti a Gradiente o Immagine con Effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. Puoi applicare un colore solido, un gradiente, un motivo o un riempimento immagine alla faccia frontale e continuare a usare le stesse impostazioni di telecamera, luce, materiale ed estrusione.

Questo esempio applica un gradiente dal blu all'arancione alla faccia frontale e un colore arancione scuro all'estrusione di 150 punti. Le fermate del gradiente a 0 e 100 marcano l'inizio e la fine del gradiente. I valori di rotazione della telecamera sono in gradi. La diapositiva è renderizzata in un'immagine PNG a dimensioni doppie rispetto al valore predefinito:

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

L'output renderizzato mantiene il gradiente sulla faccia frontale e rende l'estrusione separatamente:

![Rettangolo 3D renderizzato con riempimento a gradiente blu-arancione ed estrusione arancione](img_02_03.png)

Per usare un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma. Questo esempio richiede un file esistente denominato "image.jpg" nella directory di lavoro. Stira l'immagine per riempire il rettangolo, applica un'estrusione di 150 punti e imposta la rotazione della telecamera in gradi. Configura la forma in memoria senza salvare o renderizzare un file:

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

L'immagine è renderizzata sulla faccia frontale, mentre l'estrusione è renderizzata come superficie laterale 3D:

![Rettangolo 3D renderizzato con riempimento foto sulla faccia frontale ed estrusione arancione](img_02_04.png)

## **Applica Formattazione 3D al Testo**

La formattazione 3D della forma influisce sul corpo della forma. La formattazione 3D del testo influisce sul riquadro di testo. Questo è utile per effetti simili a WordArt dove le lettere stesse hanno bisogno di estrusione, materiale, illuminazione e impostazioni della telecamera.

Il seguente esempio crea testo con un motivo a griglia arancione‑bianco, applica un arco verso l'alto e configura le impostazioni 3D tramite [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/properties/threedformat). L'altezza dell'estrusione e la profondità sono in punti, e la rotazione della luce è in gradi. Il riempimento e il contorno della forma sono nascosti in modo che sia visibile solo il testo. L'esempio renderizza un'immagine PNG a dimensioni doppie rispetto alla diapositiva predefinita e salva la presentazione come PPTX:

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

Il testo è renderizzato come lettere curvate ed estruse in 3D:

![Testo 3D renderizzato con trasformazione WordArt arcuata, riempimento a trama arancione e estrusione scura](img_02_05.png)

## **Mantieni il Testo Piatti su una Forma 3D**

Per mantenere il testo leggibile preservando l'aspetto 3D della forma, imposta [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/keeptextflat/) tramite [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/textframeformat/). Quando il valore è `true`, il testo rimane fuori dalla scena 3D. Quando è `false`, il testo partecipa alla scena e segue la sua orientazione 3D.

Questa impostazione non rimuove la formattazione 3D della forma: la sua telecamera, illuminazione, materiale ed estrusione rimangono configurati tramite [IShape.ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/threedformat/). È anche diversa dalla rotazione ordinaria. [IShape.Rotation](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/rotation/) ruota la forma nel piano della diapositiva, mentre [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/rotationangle/) controlla la rotazione personalizzata del testo all'interno del suo riquadro. Tenere il testo fuori dalla scena 3D non resetta nessuno di questi angoli.

Il seguente esempio autonomo crea un rettangolo blu con testo e lo clona accanto all'originale. Entrambe le forme hanno la stessa formattazione 3D; solo l'impostazione del testo differisce: `false` a sinistra e `true` a destra. Gli angoli della telecamera sono in gradi e l'altezza dell'estrusione è 40 punti. L'esempio salva la presentazione come PPTX e renderizza la diapositiva di confronto in PNG a dimensioni doppie rispetto al valore predefinito.

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

A sinistra, il testo segue l'orientazione 3D. A destra, rimane piatto e più facile da leggere. Entrambi i rettangoli mantengono la stessa estrusione visibile e orientazione 3D.

![Rettangoli 3D affiancati: KeepTextFlat è false a sinistra e true a destra](keep_text_flat.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides conserva la formattazione 3D quando salva in formati PowerPoint come PPTX. Quando si renderizza o si esporta in formati a layout fisso, la scena 3D è rasterizzata o disegnata nell'output come risultato 2D. Ciò vale quando renderizzi diapositive in [PNG](/slides/it/net/convert-powerpoint-to-png/), esporti in [PDF](/slides/it/net/convert-powerpoint-to-pdf/), esporti in [HTML](/slides/it/net/convert-powerpoint-to-html/), o generi frame per la [video conversion](/slides/it/net/convert-powerpoint-to-video/).

- Le immagini e i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.  
- L'aspetto finale dipende dalla combinazione di telecamera, rig luce, materiale, estrusione, riempimento e scala della diapositiva.  
- Se devi ispezionare i valori di formattazione ereditati o basati sul tema, leggi le [proprietà effective della forma](/slides/it/net/shape-effective-properties/).  
- Alcuni formati di output non possono memorizzare la formattazione 3D di PowerPoint editabile. In quei formati, il risultato visivo è renderizzato anziché conservato come impostazioni 3D modificabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e rende gli effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportate in scene 3D interattive che lo spettatore può ruotare. In PPTX, la formattazione 3D rimane modificabile in PowerPoint dove il formato lo supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito nella presentazione. Un effetto 3D è una formattazione applicata a una forma o a un testo PowerPoint regolare, come rotazione, estrusione, smussatura, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Al minimo, imposta una rotazione della telecamera e almeno estrusione o profondità. Nella pratica, imposta anche un rig luce e un materiale affinché le facce renderizzate abbiano luci e ombre chiare.

**Posso applicare effetti 3D sia alle forme che al testo?**

Sì. Usa [IShape.ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/properties/threedformat) per il corpo della forma e [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/properties/threedformat) per il testo.

**Gli effetti 3D appariranno quando si esporta in immagini, PDF, HTML o frame video?**

Sì. Aspose.Slides rende gli effetti 3D quando produce immagini delle diapositive, output PDF, output HTML e frame usati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D modificabile.

**Posso leggere i valori 3D finali dopo che sono state applicate le impostazioni di eredità e del tema?**

Sì. Usa le API di formattazione effective descritte nelle [proprietà effective della forma](/slides/it/net/shape-effective-properties/) per leggere la telecamera finale, il rig luce, la smussatura e i valori 3D correlati.