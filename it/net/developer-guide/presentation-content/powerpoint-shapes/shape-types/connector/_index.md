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
- collegare forme
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Consenti alle app .NET di disegnare, collegare e instradare automaticamente le linee nelle diapositive PowerPoint—ottieni il pieno controllo su connettori lineari, a gomito e curvi."
---
## **Introduzione**

Un connettore PowerPoint è una linea speciale che collega due forme tra loro e rimane attaccata alle forme anche quando queste vengono spostate o riposizionate su una determinata diapositiva.  

I connettori sono tipicamente collegati a *punti di connessione* (punti verdi), che esistono su tutte le forme per impostazione predefinita. I punti di connessione compaiono quando il cursore si avvicina a loro.  

*Punti di regolazione* (punti arancioni), presenti solo su alcuni connettori, sono utilizzati per modificare la posizione e la forma dei connettori.  

## **Tipi di connettori**

In PowerPoint è possibile utilizzare connettori lineari, ad angolo (a gomito) e curvi.  

Aspose.Slides fornisce questi connettori:

| Connettore                      | Immagine                                                        | Numero di punti di regolazione |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Collega le forme usando i connettori**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Aggiungi due [AutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/) alla diapositiva utilizzando il metodo `AddAutoShape` esposto dall'oggetto `Shapes`.
1. Aggiungi un connettore usando il metodo `AddConnector` esposto dall'oggetto `Shapes` specificando il tipo di connettore.
1. Collega le forme usando il connettore.
1. Chiama il metodo `Reroute` per applicare il percorso di connessione più breve.
1. Salva la presentazione.  

Questo codice C# mostra come aggiungere un connettore (un connettore a gomito) tra due forme (un'ellisse e un rettangolo):

```c#
 // Istanzia una classe Presentation che rappresenta un file PPTX
 using (Presentation input = new Presentation())
 {                
     // Accede alla raccolta di forme per una diapositiva specifica
     IShapeCollection shapes = input.Slides[0].Shapes;

     // Aggiunge una forma automatica Ellipse
     IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

     // Aggiunge una forma automatica Rectangle
     IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

     // Aggiunge una forma connettore alla raccolta di forme della diapositiva
     IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

     // Collega le forme utilizzando il connettore
     connector.StartShapeConnectedTo = ellipse;
     connector.EndShapeConnectedTo = rectangle;

     // Chiama Reroute che imposta il percorso automatico più breve tra le forme
     connector.Reroute();

     // Salva la presentazione
     input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
 }
```

{{%  alert title="NOTE"  color="warning"   %}} 
Il metodo `Connector.Reroute` riorganizza un connettore e lo costringe a seguire il percorso più breve possibile tra le forme. Per raggiungere questo scopo, il metodo può modificare i punti `StartShapeConnectionSiteIndex` e `EndShapeConnectionSiteIndex`. 
{{% /alert %}} 

## **Specificare un punto di connessione**

Se desideri che un connettore colleghi due forme utilizzando punti specifici sulle forme, devi specificare i punti di connessione preferiti in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Aggiungi due [AutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/) alla diapositiva utilizzando il metodo `AddAutoShape` esposto dall'oggetto `Shapes`.
1. Aggiungi un connettore usando il metodo `AddConnector` esposto dall'oggetto `Shapes` specificando il tipo di connettore.
1. Collega le forme usando il connettore.
1. Imposta i punti di connessione preferiti sulle forme.
1. Salva la presentazione.  

Questo codice C# dimostra un'operazione in cui viene specificato un punto di connessione preferito:

```c#
 // Istanzia una classe Presentation che rappresenta un file PPTX
 using (Presentation presentation = new Presentation())
 {
     // Accede alla raccolta di forme per una diapositiva specifica
     IShapeCollection shapes = presentation.Slides[0].Shapes;

     // Aggiunge una forma connettore alla raccolta di forme della diapositiva
     IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

     // Aggiunge una forma automatica Ellipse
     IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

     // Aggiunge una forma automatica Rectangle
     IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

     // Collega le forme usando il connettore
     connector.StartShapeConnectedTo = ellipse;
     connector.EndShapeConnectedTo = rectangle;

     // Imposta l'indice del punto di connessione preferito sulla forma Ellipse
     uint wantedIndex = 6;

     // Verifica se l'indice preferito è minore del conteggio massimo degli indici di sito
     if (ellipse.ConnectionSiteCount > wantedIndex)
     {
         // Imposta il punto di connessione preferito sulla forma automatica Ellipse
         connector.StartShapeConnectionSiteIndex = wantedIndex;
     }

     // Salva la presentazione
     presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
 }
```

## **Regolare un punto del connettore**

Puoi regolare un connettore esistente attraverso i suoi punti di regolazione. Solo i connettori con punti di regolazione possono essere modificati in questo modo. Vedi la tabella sotto **[Tipi di connettori.](/slides/it/net/connector/#types-of-connectors)** 

### **Caso semplice**

Considera un caso in cui un connettore tra due forme (A e B) passa attraverso una terza forma (C):

![connector-obstruction](connector-obstruction.png)

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

Per evitare o aggirare la terza forma, possiamo regolare il connettore spostando la sua linea verticale verso sinistra in questo modo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Casi complessi** 

Per eseguire regolazioni più complesse, devi tenere conto di questi aspetti:

* Un punto regolabile di un connettore è fortemente legato a una formula che calcola e determina la sua posizione. Pertanto, le modifiche alla posizione del punto possono alterare la forma del connettore.  
* I punti di regolazione di un connettore sono definiti in un ordine rigoroso in un array. I punti di regolazione sono numerati dal punto di inizio del connettore a quello di fine.  
* I valori dei punti di regolazione riflettono la percentuale della larghezza/altezza della forma del connettore.  
  * La forma è delimitata dai punti di inizio e fine del connettore moltiplicati per 1000.  
  * Il primo punto, il secondo punto e il terzo punto definiscono rispettivamente la percentuale della larghezza, la percentuale dell'altezza e nuovamente la percentuale della larghezza.  
* Per i calcoli che determinano le coordinate dei punti di regolazione di un connettore, devi considerare la rotazione del connettore e la sua riflessione. **Nota** che l'angolo di rotazione per tutti i connettori mostrati sotto **[Tipi di connettori](/slides/it/net/connector/#types-of-connectors)** è 0.  

#### **Caso 1**

Considera un caso in cui due oggetti di casella di testo sono collegati tra loro tramite un connettore:

![connector-shape-complex](connector-shape-complex.png)

```c#
// Istanzia una classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
// Ottiene la prima diapositiva nella presentazione
ISlide sld = pres.Slides[0];
// Aggiunge forme che saranno unite tramite un connettore
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// Aggiunge un connettore
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Specifica la direzione del connettore
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Specifica il colore del connettore
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Specifica lo spessore della linea del connettore
connector.LineFormat.Width = 3;

// Collega le forme insieme con il connettore
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Ottiene i punti di regolazione per il connettore
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**Regolazione**

Possiamo modificare i valori dei punti di regolazione del connettore aumentando rispettivamente la percentuale di larghezza e di altezza del 20% e del 200%:

```c#
// Modifica i valori dei punti di regolazione
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Il risultato:

![connector-adjusted-1](connector-adjusted-1.png)

Per definire un modello che ci permetta di determinare le coordinate e la forma delle singole parti del connettore, creiamo una forma che corrisponda alla componente orizzontale del connettore al punto `connector.Adjustments[0]`:

```c#
// Disegna la componente verticale del connettore

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Il risultato:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Caso 2**

Nel **Caso 1**, abbiamo dimostrato un'operazione di regolazione semplice del connettore usando principi di base. In situazioni normali, devi considerare la rotazione del connettore e la sua visualizzazione (impostate da `connector.Rotation`, `connector.Frame.FlipH` e `connector.Frame.FlipV`). Ora dimostreremo il processo.

Innanzitutto, aggiungiamo un nuovo oggetto di casella di testo (**To 1**) alla diapositiva (per scopi di connessione) e creiamo un nuovo connettore (verde) che lo collega agli oggetti già creati.

```c#
// Crea un nuovo oggetto di binding
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// Crea un nuovo connettore
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Collega gli oggetti usando il connettore appena creato
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Ottiene i punti di regolazione del connettore
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Modifica i valori dei punti di regolazione
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Il risultato:

![connector-adjusted-3](connector-adjusted-3.png)

Secondo, creiamo una forma che corrisponda alla componente orizzontale del connettore che passa attraverso il nuovo punto di regolazione del connettore `connector.Adjustments[0]`. Useremo i valori dei dati del connettore per `connector.Rotation`, `connector.Frame.FlipH` e `connector.Frame.FlipV` e applicheremo la nota formula di conversione delle coordinate per la rotazione attorno a un punto dato x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Nella nostra situazione, l'angolo di rotazione dell'oggetto è 90 gradi e il connettore è visualizzato verticalmente, quindi questo è il codice corrispondente:

```c#
 // Salva le coordinate del connettore
 x = connector.X;
 y = connector.Y;
 // Corregge le coordinate del connettore nel caso appaia
 if (connector.Frame.FlipH == NullableBool.True)
 {
     x += connector.Width;
 }
 if (connector.Frame.FlipV == NullableBool.True)
 {
     y += connector.Height;
 }
 // Utilizza il valore del punto di regolazione come coordinata
 x += connector.Width * adjValue_0.RawValue / 100000;
 // Converte le coordinate poiché Sin(90) = 1 e Cos(90) = 0
 float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
 float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
 // Determina la larghezza della componente orizzontale usando il valore del secondo punto di regolazione
 float width = connector.Height * adjValue_1.RawValue / 100000;
 IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
 shape.LineFormat.FillFormat.FillType = FillType.Solid;
 shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

Il risultato:

![connector-adjusted-4](connector-adjusted-4.png)

Abbiamo dimostrato calcoli che coinvolgono regolazioni semplici e punti di regolazione complessi (punti di regolazione con angoli di rotazione). Utilizzando le conoscenze acquisite, puoi sviluppare il tuo modello (o scrivere del codice) per ottenere un oggetto `GraphicsPath` o persino impostare i valori dei punti di regolazione di un connettore basati su coordinate specifiche della diapositiva.

## **Trovare l'angolo delle linee del connettore**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Accedi alla forma della linea del connettore.
1. Utilizza la larghezza, l'altezza della linea, l'altezza del frame della forma e la larghezza del frame della forma per calcolare l'angolo.

Questo codice C# dimostra un'operazione in cui abbiamo calcolato l'angolo per una forma di linea del connettore:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**Come posso capire se un connettore può essere "incollato" a una forma specifica?**

Verifica che la forma esponga i [connection sites](https://reference.aspose.com/slides/it/net/aspose.slides/shape/connectionsitecount/). Se non ce ne sono o il conteggio è zero, l'incollaggio non è disponibile; in tal caso, utilizza estremità libere e posizionale manualmente. È consigliabile controllare il conteggio dei siti prima di collegare.

**Cosa succede a un connettore se elimino una delle forme collegate?**

Le sue estremità verranno scollegate; il connettore rimane nella diapositiva come una linea ordinaria con estremità libere. Puoi eliminarlo o riassegnare le connessioni e, se necessario, [reroute](https://reference.aspose.com/slides/it/net/aspose.slides/connector/reroute/).

**I collegamenti dei connettori vengono conservati quando si copia una diapositiva in un'altra presentazione?**

In generale sì, a condizione che anche le forme di destinazione vengano copiate. Se la diapositiva viene inserita in un altro file senza le forme collegate, le estremità diventano libere e sarà necessario ricollegarle.