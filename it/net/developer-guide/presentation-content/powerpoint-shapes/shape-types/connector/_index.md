---
title: Gestire i connettori nelle presentazioni in .NET
linktitle: Connettore
type: docs
weight: 10
url: /it/net/connector/
keywords:
- connettore
- tipo di connettore
- punto del connettore
- linea del connettore
- angolo del connettore
- sito di connessione
- punto di regolazione
- collegare forme
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come aggiungere, collegare, ricalcolare, regolare e ispezionare connettori PowerPoint lineari, piegati e curvi con Aspose.Slides per .NET."
---
## **Panoramica**

Un connettore è una linea che può rimanere collegata a due forme quando una delle forme si sposta. Le sue estremità si collegano a siti di connessione, rappresentati da punti verdi in PowerPoint. Alcuni connettori piegati e curvi espongono anche punti di regolazione, rappresentati da punti arancioni, che controllano la posizione dei singoli segmenti del connettore.

Aspose.Slides rappresenta i connettori tramite l’interfaccia [IConnector](https://reference.aspose.com/slides/it/net/aspose.slides/iconnector/). È possibile crearli, collegare le loro estremità alle forme, scegliere i siti di connessione, ricalcolare il percorso e modificare la geometria dei connettori che possiedono punti di regolazione.

## **Tipi di connettore**

L’enumerazione [ShapeType](https://reference.aspose.com/slides/it/net/aspose.slides/shapetype/) include preset di connettori lineari, piegati e curvi. La tabella seguente mostra le geometrie di connettore disponibili e il numero di punti di regolazione definiti da ciascun preset.

| Connettore | Immagine | Numero di punti di regolazione |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Il numero e il significato dei punti di regolazione fanno parte del preset di connettore selezionato. Non presumere che due tipi diversi di connettore espongano la stessa disposizione della raccolta.

## **Collegare due forme**

Utilizzare [IShapeCollection.AddConnector](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addconnector/) per aggiungere un connettore e impostare le proprietà [StartShapeConnectedTo](https://reference.aspose.com/slides/it/net/aspose.slides/connector/startshapeconnectedto/) e [EndShapeConnectedTo](https://reference.aspose.com/slides/it/net/aspose.slides/connector/endshapeconnectedto/). Dopo che entrambe le estremità sono collegate, [IConnector.Reroute](https://reference.aspose.com/slides/it/net/aspose.slides/iconnector/reroute/) seleziona un percorso breve tra le forme.

L’esempio seguente collega un’ellisse e un rettangolo con un connettore piegato:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;
connector.Reroute();

presentation.Save("connected-shapes.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}

Chiamare `Reroute` può modificare i valori di [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/it/net/aspose.slides/connector/startshapeconnectionsiteindex/) e [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/it/net/aspose.slides/connector/endshapeconnectionsiteindex/). Assegnare siti di connessione specifici dopo il ricalcolo se tali siti devono rimanere fissi.

{{% /alert %}}

## **Scegliere un sito di connessione**

Ogni forma collegabile restituisce il proprio numero di siti tramite [ConnectionSiteCount](https://reference.aspose.com/slides/it/net/aspose.slides/shape/connectionsitecount/). Convalidare un indice di sito zero‑based desiderato prima di assegnarlo a un’estremità del connettore; il conteggio dei siti varia a seconda della geometria della forma.

Questo esempio collega il connettore a un sito specifico sull’ellisse quando tale sito esiste:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;

uint preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse.ConnectionSiteCount)
{
    connector.StartShapeConnectionSiteIndex = preferredSiteIndex;
}
else
{
    Console.WriteLine($"The ellipse has only {ellipse.ConnectionSiteCount} connection sites.");
}

presentation.Save("specific-connection-site.pptx", SaveFormat.Pptx);
```

## **Regolare un punto del connettore**

I connettori con punti di regolazione li espongono tramite [IGeometryShape.Adjustments](https://reference.aspose.com/slides/it/net/aspose.slides/igeometryshape/adjustments/). Esaminare ogni [IAdjustValue](https://reference.aspose.com/slides/it/net/aspose.slides/iadjustvalue/) e controllare il suo [Type](https://reference.aspose.com/slides/it/net/aspose.slides/adjustvalue/type/) prima di modificare il suo [RawValue](https://reference.aspose.com/slides/it/net/aspose.slides/adjustvalue/rawvalue/). Le regole generali per identificare le regolazioni di forme preset sono descritte in [Shape Manipulation](/slides/it/net/shape-manipulations/).

Il numero, l’ordine, il significato e l’intervallo di valori validi delle regolazioni del connettore dipendono dal preset del connettore. La proprietà `Type` è sola lettura, mentre il valore di regolazione è scrivibile. La proprietà [Name](https://reference.aspose.com/slides/it/net/aspose.slides/adjustvalue/name/) (sola lettura) fornisce un’identificazione aggiuntiva quando un connettore contiene più di una regolazione dello stesso tipo semantico.

### **Percorso attorno a un ostacolo**

Nel layout seguente, un connettore `BentConnector5` tra due forme attraversa una terza forma:

![connector-obstruction](connector-obstruction.png)

Questo codice crea il connettore ostacolato:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

presentation.Save("connector-obstruction.pptx", SaveFormat.Pptx);
```

Spostare la piega verticale modifica il percorso in modo che il connettore aggiri l’ostacolo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Invece di presumere che l’indice di raccolta `1` rappresenti sempre la piega verticale, questo esempio ricerca `ConnectorBendPositionY` e lo modifica solo quando è presente il tipo semantico previsto:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend is null)
{
    Console.WriteLine("The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend.RawValue = 60000;
    presentation.Save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
}
```

Un `BentConnector5` ha due regolazioni `ConnectorBendPositionX` e una regolazione `ConnectorBendPositionY`. Se il tipo necessario compare più volte, ispezionare `Name` e la geometria nota di quel preset prima di sceglierne uno. Se una regolazione restituisce `ShapeAdjustmentType.Custom`, trattare il suo significato e intervallo come specifici del preset e non modificarla finché il relativo contratto non è noto.

## **Collegare i valori di regolazione alla geometria del connettore**

Per i connettori piegati, i valori di regolazione possono essere usati per stimare le posizioni dei singoli segmenti. Questi calcoli sono specifici del preset del connettore:

- `BentConnector4` normalmente espone una regolazione `ConnectorBendPositionX` e una `ConnectorBendPositionY`.
- Per queste posizioni di piega, `RawValue / 100000f` produce la frazione della larghezza o altezza del frame del connettore usata negli esempi seguenti.
- Un frame del connettore può essere ruotato o capovolto, quindi le coordinate del frame devono essere trasformate prima di confrontarle con le coordinate della diapositiva.

Gli esempi seguenti usano `Type` per identificare prima le regolazioni. Non trattano gli indici di raccolta come identificatori portabili.

### **Connettore non ruotato**

Il layout iniziale contiene due forme di testo collegate da un `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Questo esempio ispeziona il connettore e ottiene le sue regolazioni di piega orizzontale e verticale:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
targetShape.TextFrame.Text = "To";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
}
```

Per modificare entrambe le pieghe, individuare ogni tipo previsto e modificare i valori solo dopo aver trovato entrambi:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;
    presentation.Save("connector-adjusted.pptx", SaveFormat.Pptx);
}
```

Il risultato è un connettore i cui segmenti orizzontale e verticale si sono spostati:

![connector-adjusted-1](connector-adjusted-1.png)

Una volta conosciuti i tipi semantici, i loro valori possono essere convertiti in coordinate del frame del connettore. Questo esempio disegna un rettangolo sottile sul segmento verticale controllato dalle due regolazioni di piega:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    var x = connector.X + connector.Width * horizontalBend.RawValue / 100000f;
    var y = connector.Y;
    var height = connector.Height * verticalBend.RawValue / 100000f;
    slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 1, height);
    presentation.Save("connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

La forma guida segna il segmento calcolato:

![connector-adjusted-2](connector-adjusted-2.png)

### **Connettore ruotato o capovolto**

Quando la stessa geometria del connettore è orientata verticalmente, i valori di [Frame](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/it/net/aspose.slides/shapeframe/fliph/) e [FlipV](https://reference.aspose.com/slides/it/net/aspose.slides/shapeframe/flipv/) influenzano la conversione dalle coordinate del frame del connettore a quelle della diapositiva.

Questo esempio crea e regola il connettore orientato verticalmente:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
targetShape.TextFrame.Text = "To 1";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        adjustment.RawValue += 20000;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        adjustment.RawValue += 200000;
    }
}

presentation.Save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
```

Il connettore regolato appare verticalmente tra le forme:

![connector-adjusted-3](connector-adjusted-3.png)

Per un angolo di rotazione arbitrario `alpha`, ruotare un punto del frame del connettore `(x, y)` attorno al centro del frame `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Il codice seguente gestisce l’orientamento a 90 gradi usato in questo esempio e disegna una guida rossa sul segmento corrispondente del connettore:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;

    var x = connector.X;
    var y = connector.Y;
    if (connector.Frame.FlipH == NullableBool.True)
    {
        x += connector.Width;
    }
    if (connector.Frame.FlipV == NullableBool.True)
    {
        y += connector.Height;
    }

    x += connector.Width * horizontalBend.RawValue / 100000f;
    var rotatedX = connector.Frame.CenterX - y + connector.Frame.CenterY;
    var rotatedY = x - connector.Frame.CenterX + connector.Frame.CenterY;
    var segmentWidth = connector.Height * verticalBend.RawValue / 100000f;
    var guide = slide.Shapes.AddAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    guide.LineFormat.FillFormat.FillType = FillType.Solid;
    guide.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

La guida rossa segna il segmento calcolato dopo la trasformazione delle coordinate:

![connector-adjusted-4](connector-adjusted-4.png)

Queste formule descrivono i preset usati negli esempi, non un modello di connettore universale. Convalidare i tipi di regolazione, l’orientamento del frame e gli intervalli di valore prima di applicare lo stesso calcolo a un preset diverso.

## **Trovare l’angolo di direzione di un connettore**

La direzione di un connettore lineare può essere calcolata dalla sua larghezza e altezza, tenendo conto dei ribaltamenti orizzontali e verticali. L’esempio seguente restituisce l’angolo in senso orario rispetto all’asse orizzontale positivo nelle coordinate della diapositiva:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

var flipH = connector.Frame.FlipH == NullableBool.True;
var flipV = connector.Frame.FlipV == NullableBool.True;
var deltaX = connector.Width * (flipH ? -1 : 1);
var deltaY = connector.Height * (flipV ? -1 : 1);
var angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

if (angle < 0)
{
    angle += 360;
}

Console.WriteLine($"Connector direction: {angle:F2} degrees");
```

## **FAQ**

**Come posso capire se un connettore può essere collegato a una forma?**

Controllare la proprietà `ConnectionSiteCount` della forma. Un valore positivo indica che la forma espone siti di connessione. Convalidare l’indice del sito selezionato prima di assegnarlo a una delle estremità del connettore.

**Posso identificare una regolazione del connettore tramite il suo indice di raccolta?**

Un indice è significativo solo per un preset di connettore noto e la relativa disposizione della raccolta. Verificare `IAdjustValue.Type` prima di modificare un valore e usare `IAdjustValue.Name` come informazione aggiuntiva quando lo stesso tipo semantico compare più volte.

**Cosa accade quando una forma collegata viene eliminata?**

L’estremità corrispondente del connettore diventa scollegata. Il connettore rimane sulla diapositiva e può essere eliminato, posizionato come linea libera o collegato a un’altra forma.

**I collegamenti dei connettori vengono mantenuti quando una diapositiva è copiata?**

In genere i collegamenti sono mantenuti quando le forme collegate vengono copiate insieme alla diapositiva. Se un connettore viene copiato senza una delle forme target, l’estremità interessata deve essere ricollegata.