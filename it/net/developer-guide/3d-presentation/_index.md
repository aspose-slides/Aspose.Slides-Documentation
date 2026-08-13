---
title: Crea effetti 3D nelle presentazioni con .NET
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
description: "Applica e renderizza effetti 3D per forme e testo PowerPoint in .NET con Aspose.Slides. Configura fotocamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides per .NET può creare, modificare, conservare e renderizzare la formattazione 3D in stile PowerPoint per forme e testo. Questo articolo tratta gli effetti 3D come rotazione, estrusione, smussi, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="info" %}}
Questo articolo tratta degli effetti di formattazione 3D su forme e testo di PowerPoint. Non riguarda l'inserimento o la modifica di file modello 3D autonomi. Quando si esporta una diapositiva in un'immagine, PDF o HTML, Aspose.Slides renderizza quegli effetti 3D nell'output 2D esportato.
{{% /alert %}}

## **Concetti di Formattazione 3D**

Utilizzare la proprietà [IShape.ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/properties/threedformat) per applicare la formattazione 3D a una forma. La proprietà espone [IThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat), che controlla la scena 3D per quella forma.

Per il testo, utilizzare la proprietà [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/properties/threedformat). Questo applica la formattazione 3D al riquadro di testo invece che al corpo della forma.

Le proprietà più importanti sono:

| Proprietà | Cosa controlla | Quando usarla |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/camera) | Punto di vista, tipo di fotocamera predefinito, rotazione, zoom e prospettiva. | Ruotare l'oggetto nello spazio 3D o corrispondere a un preset di rotazione 3D di PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/lightrig) | Preset di luce, direzione e rotazione della luce. | Modificare il modo in cui le luci e le ombre appaiono sulla superficie 3D. |
| [Material](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/material) | Materiale della superficie, ad esempio piatto, opaco, plastica o metallo. | Far apparire la stessa geometria più piatta, più morbida, lucida o metallica. |
| [ExtrusionHeight](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/extrusionheight) | Quanto la forma si estende all'indietro dalla sua faccia frontale. | Trasformare una forma piatta in un oggetto 3D visibilmente spesso. |
| [ExtrusionColor](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Colore dei lati estrusi. | Rendere visibile la profondità o coordinare il colore laterale con il riempimento frontale. |
| [Depth](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/depth) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Regolare finemente la profondità per forme o testo, specialmente in combinazione con impostazioni di smusso e materiale. |
| [BevelTop](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/beveltop) e [BevelBottom](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/bevelbottom) | Bordi rialzati o arrotondati sulle facce frontale e posteriore. | Aggiungere un bordo smussato o modellato invece di una faccia piatta e netta. |
| [ContourColor](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/contourcolor) e [ContourWidth](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/contourwidth) | Contorno intorno all'oggetto 3D. | Evidenziare il contorno dell'oggetto nell'output renderizzato. |

## **Crea una Forma 3D**

Una forma di solito richiede quattro tipi di impostazioni prima di apparire convincentemente 3D:

- Impostazioni della fotocamera, perché la visualizzazione frontale predefinita può nascondere l'estrusione.  
- Impostazioni della luce, perché l'illuminazione rende leggibili le facce e i lati.  
- Impostazioni del materiale, perché la superficie influisce su come la luce viene renderizzata.  
- Impostazioni di estrusione o profondità, perché una forma piatta ha bisogno di spessore.  

Il seguente esempio crea un rettangolo, aggiunge testo alla sua faccia frontale, applica la formattazione 3D, salva la presentazione come PPTX e renderizza la diapositiva in un'immagine PNG.

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

## **Ruota una Forma con la Fotocamera**

In PowerPoint, la rotazione 3D è configurata dal pannello Rotazione 3-D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della fotocamera.

![Pannello Rotazione 3-D di PowerPoint con i valori di rotazione X, Y e Z evidenziati](img_02_01.png)

In Aspose.Slides, impostare il tipo di fotocamera e la rotazione tramite [IThreeDFormat.Camera](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/camera):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Utilizzare la fotocamera quando è necessario cambiare il modo in cui lo spettatore vede l'oggetto. Non modifica la geometria 2D della forma sulla diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

## **Aggiungi Estrusione e Profondità**

L'estrusione fa apparire una forma spessa estendendola dietro la faccia frontale. In PowerPoint, il controllo della profondità imposta questa spessore visibile, e il controllo del colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint mappati alle proprietà colore estrusione e altezza estrusione](img_02_02.png)

Impostare [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/extrusionheight) per lo spessore e [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/extrusioncolor) per il colore laterale:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Utilizzare [IThreeDFormat.Depth](https://reference.aspose.com/slides/it/net/aspose.slides/ithreedformat/properties/depth) quando è necessario lavorare direttamente con il valore di profondità di PowerPoint o combinare la profondità con smusso, materiale ed effetti testo. In molti scenari di forme, `ExtrusionHeight` è l'impostazione più chiara perché esprime direttamente l'estrusione visibile.

## **Usa Riempimenti a Gradiente o Immagine con Effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. È possibile applicare un colore solido, un gradiente, un motivo o un riempimento immagine alla faccia frontale e continuare a utilizzare le stesse impostazioni di fotocamera, luce, materiale ed estrusione.

Questo esempio applica un riempimento a gradiente alla forma e un colore di estrusione più scuro ai lati:

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

L'output renderizzato mantiene il gradiente sulla faccia frontale e renderizza l'estrusione separatamente:

![Rettangolo 3D renderizzato con riempimento a gradiente dal blu all'arancione e estrusione arancione](img_02_03.png)

Per utilizzare invece un riempimento immagine, aggiungere l'immagine alla presentazione e assegnarla al riempimento della forma:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

L'immagine è renderizzata sulla faccia frontale, mentre l'estrusione è renderizzata come superficie laterale 3D:

![Rettangolo 3D renderizzato con riempimento foto sulla faccia frontale e estrusione arancione](img_02_04.png)

## **Applica Formattazione 3D al Testo**

La formattazione 3D della forma influisce sul corpo della forma. La formattazione 3D del testo influisce sul riquadro di testo. Questo è utile per effetti simili a WordArt in cui le lettere stesse necessitano di estrusione, materiale, illuminazione e impostazioni della fotocamera.

Il seguente esempio crea testo con un riempimento a motivo, applica una trasformazione WordArt e configura le impostazioni 3D su [ITextFrameFormat](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat):

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

Il testo è renderizzato come lettere 3D curve ed estruse:

![Testo 3D renderizzato con trasformazione WordArt ad arco, riempimento a motivo arancione e estrusione scura](img_02_05.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides conserva la formattazione 3D quando si salva nei formati PowerPoint come PPTX. Quando si esegue il rendering o l'esportazione in formati a layout fisso, la scena 3D viene rasterizzata o disegnata nell'output come risultato 2D. Questo vale quando si renderizzano le diapositive in [PNG](/slides/it/net/convert-powerpoint-to-png/), si esporta in [PDF](/slides/it/net/convert-powerpoint-to-pdf/), si esporta in [HTML](/slides/it/net/convert-powerpoint-to-html/), o si generano fotogrammi per [conversione video](/slides/it/net/convert-powerpoint-to-video/).

- Le immagini e i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.  
- L'aspetto finale dipende dalla combinazione di fotocamera, rig luce, materiale, estrusione, riempimento e scala della diapositiva.  
- Se è necessario ispezionare i valori di formattazione ereditati o basati sul tema, leggere le [proprietà effective shape](/slides/it/net/shape-effective-properties/).  
- Alcuni formati di output non possono memorizzare la formattazione 3D modificabile di PowerPoint. In quei formati, il risultato visivo è renderizzato invece di essere conservato come impostazioni 3D modificabili.

## **FAQ**

### Può Aspose.Slides creare presentazioni 3D interattive?

Aspose.Slides crea e renderizza gli effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportate scene 3D interattive che lo spettatore possa ruotare. In PPTX, la formattazione 3D rimane modificabile in PowerPoint dove il formato la supporta.

### Qual è la differenza tra un modello 3D e un effetto 3D?

Un modello 3D è un oggetto 3D separato inserito in una presentazione. Un effetto 3D è una formattazione applicata a una forma o a un testo PowerPoint standard, come rotazione, estrusione, smusso, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

### Quali impostazioni sono richieste per una forma 3D visibile?

Come minimo, impostare una rotazione della fotocamera e oppure l'estrusione o la profondità. In pratica, impostare anche un rig luce e un materiale affinché le facce renderizzate abbiano evidenti riflessi e ombre.

### Posso applicare effetti 3D sia a forme che a testo?

Sì. Utilizzare [IShape.ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/properties/threedformat) per il corpo della forma e [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/properties/threedformat) per il testo.

### Gli effetti 3D appariranno quando si esporta in immagini, PDF, HTML o fotogrammi video?

Sì. Aspose.Slides renderizza gli effetti 3D quando produce immagini delle diapositive, output PDF, output HTML e fotogrammi utilizzati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D modificabile.

### Posso leggere i valori finali 3D dopo l'applicazione dell'ereditarietà e delle impostazioni del tema?

Sì. Utilizzare le API di formattazione effective descritte in [Shape Effective Properties](/slides/it/net/shape-effective-properties/) per leggere i valori finali di fotocamera, rig luce, smusso e relativi valori 3D.