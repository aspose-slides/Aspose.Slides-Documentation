---
title: Gestisci i connettori nelle presentazioni usando JavaScript
linktitle: Connettore
type: docs
weight: 10
url: /it/nodejs-java/connector/
keywords:
- connettore
- tipo di connettore
- punto di connettore
- linea del connettore
- angolo del connettore
- collegare forme
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Consenti alle app JavaScript di disegnare, collegare e instradare automaticamente linee nelle diapositive PowerPoint—ottieni il pieno controllo su connettori lineari, a gomito e curvi."
---
## **Introduzione**

Un connettore PowerPoint è una linea speciale che collega due forme insieme e rimane attaccata alle forme anche quando queste vengono spostate o riposizionate su una diapositiva.  

I connettori sono tipicamente collegati a *punti di connessione* (punti verdi), che esistono su tutte le forme per impostazione predefinita. I punti di connessione appaiono quando il cursore si avvicina a essi.  

*Punti di regolazione* (punti arancioni), presenti solo su alcuni connettori, sono usati per modificare le posizioni e le forme dei connettori.

## **Tipi di connettori**

In PowerPoint, è possibile utilizzare connettori lineari, a gomito (angolati) e curvi.  

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

1. Crea un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Aggiungi due [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape) alla diapositiva usando il metodo `addAutoShape` esposto dall'oggetto `Shapes`.
1. Aggiungi un connettore usando il metodo `addConnector` esposto dall'oggetto `Shapes` definendo il tipo di connettore.
1. Collega le forme usando il connettore.
1. Chiama il metodo `reroute` per applicare il percorso di connessione più breve.
1. Salva la presentazione. 

Questo codice JavaScript mostra come aggiungere un connettore (un connettore piegato) tra due forme (un'ellisse e un rettangolo):

```javascript
// Istanzia una classe di presentazione che rappresenta il file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla raccolta di forme per una diapositiva specifica
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Aggiunge una forma automatica Ellisse
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Aggiunge una forma automatica Rettangolo
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Aggiunge una forma di connettore alla raccolta di forme della diapositiva
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Collega le forme usando il connettore
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Chiama reroute che imposta il percorso più breve automatico tra le forme
    connector.reroute();
    // Salva la presentazione
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Il metodo `Connector.reroute` riorienta un connettore e lo costringe a prendere il percorso più breve possibile tra le forme. Per raggiungere il suo scopo, il metodo può modificare i punti `setStartShapeConnectionSiteIndex` e `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Specifica punto di connessione**

Se desideri che un connettore colleghi due forme usando punti specifici sulle forme, devi specificare i punti di connessione preferiti in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Aggiungi due [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape) alla diapositiva usando il metodo `addAutoShape` esposto dall'oggetto `Shapes`.
1. Aggiungi un connettore usando il metodo `addConnector` esposto dall'oggetto `Shapes` definendo il tipo di connettore.
1. Collega le forme usando il connettore.
1. Imposta i punti di connessione preferiti sulle forme.
1. Salva la presentazione.

Questo codice JavaScript dimostra un'operazione in cui viene specificato un punto di connessione preferito:

```javascript
// Istanzia una classe di presentazione che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla raccolta di forme per una diapositiva specifica
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Aggiunge una forma automatica Ellisse
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Aggiunge una forma automatica Rettangolo
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Aggiunge una forma di connettore alla raccolta di forme della diapositiva
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Collega le forme usando il connettore
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Imposta l'indice del punto di connessione preferito sulla forma Ellisse
    var wantedIndex = 6;
    // Verifica se l'indice preferito è inferiore al conteggio massimo dei punti di connessione
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // Imposta il punto di connessione preferito sulla forma automatica Ellisse
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // Salva la presentazione
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Regola punto del connettore**

Puoi regolare un connettore esistente tramite i suoi punti di regolazione. Solo i connettori con punti di regolazione possono essere modificati in questo modo. Vedi la tabella sotto **[Tipi di connettori.](/slides/it/nodejs-java/connector/#types-of-connectors)**

### **Caso semplice**

Considera un caso in cui un connettore tra due forme (A e B) passa attraverso una terza forma (C):

![connector-obstruction](connector-obstruction.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Per evitare o aggirare la terza forma, possiamo regolare il connettore spostando la sua linea verticale verso sinistra in questo modo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Casi complessi** 

Per eseguire regolazioni più complesse, devi tenere in considerazione questi aspetti:

* Il punto regolabile di un connettore è strettamente collegato a una formula che calcola e determina la sua posizione. Pertanto, le modifiche alla posizione del punto possono alterare la forma del connettore.
* I punti di regolazione di un connettore sono definiti in un ordine rigoroso in un array. I punti di regolazione sono numerati dal punto di partenza del connettore al suo punto finale.
* I valori dei punti di regolazione riflettono la percentuale della larghezza/altezza della forma del connettore. 
  * La forma è limitata dai punti di inizio e fine del connettore moltiplicati per 1000. 
  * Il primo punto, il secondo punto e il terzo punto definiscono rispettivamente la percentuale dalla larghezza, la percentuale dall'altezza e di nuovo la percentuale dalla larghezza.
* Per i calcoli che determinano le coordinate dei punti di regolazione di un connettore, devi considerare la rotazione del connettore e il suo riflesso. **Nota** che l'angolo di rotazione per tutti i connettori mostrati sotto **[Tipi di connettori](/slides/it/nodejs-java/connector/#types-of-connectors)** è 0.

#### **Caso 1**

Considera un caso in cui due oggetti di riquadro di testo sono collegati tra loro tramite un connettore:

![connector-shape-complex](connector-shape-complex.png)

```javascript
// Istanzia una classe di presentazione che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    var sld = pres.getSlides().get_Item(0);
    // Aggiunge forme che saranno unite tramite un connettore
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Aggiunge un connettore
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // Specifica la direzione del connettore
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // Specifica il colore del connettore
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Specifica lo spessore della linea del connettore
    connector.getLineFormat().setWidth(3);
    // Collega le forme insieme con il connettore
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // Ottiene i punti di regolazione per il connettore
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Regolazione**

Possiamo modificare i valori dei punti di regolazione del connettore aumentando la percentuale corrispondente di larghezza e altezza del 20% e del 200%, rispettivamente:

```javascript
// Cambia i valori dei punti di regolazione
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Il risultato:

![connector-adjusted-1](connector-adjusted-1.png)

Per definire un modello che ci permetta di determinare le coordinate e la forma delle singole parti del connettore, creiamo una forma che corrisponda alla componente orizzontale del connettore al punto `connector.getAdjustments().get_Item(0)`:

```javascript
// Disegna la componente verticale del connettore
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```

Il risultato:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Caso 2**

Nel **Caso 1**, abbiamo dimostrato un'operazione di regolazione semplice del connettore usando principi di base. In situazioni normali, devi tenere in considerazione la rotazione del connettore e il suo aspetto (che sono impostati da `connector.getRotation()`, `connector.getFrame().getFlipH()` e `connector.getFrame().getFlipV()`). Ora dimostreremo il processo.

Prima, aggiungiamo un nuovo oggetto di riquadro di testo (**To 1**) alla diapositiva (per scopi di collegamento) e creiamo un nuovo connettore (verde) che lo collega agli oggetti già creati.

```javascript
// Crea un nuovo oggetto di binding
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Crea un nuovo connettore
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// Collega gli oggetti usando il connettore appena creato
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Ottiene i punti di regolazione del connettore
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Cambia i valori dei punti di regolazione
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Il risultato:

![connector-adjusted-3](connector-adjusted-3.png)

Secondo, creiamo una forma che corrisponda alla componente orizzontale del connettore che passa attraverso il nuovo punto di regolazione del connettore `connector.getAdjustments().get_Item(0)`. Useremo i valori dei dati del connettore per `connector.getRotation()`, `connector.getFrame().getFlipH()`, e `connector.getFrame().getFlipV()` e applicheremo la nota formula di conversione delle coordinate per la rotazione attorno a un punto dato x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

```javascript
// Salva le coordinate del connettore
x = connector.getX();
y = connector.getY();
// Corregge le coordinate del connettore nel caso appaiano
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// Usa il valore del punto di regolazione come coordinata
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Converte le coordinate poiché Sin(90) = 1 e Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// Determina la larghezza della componente orizzontale usando il valore del secondo punto di regolazione
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Il risultato:

![connector-adjusted-4](connector-adjusted-4.png)

Abbiamo dimostrato calcoli che coinvolgono regolazioni semplici e punti di regolazione complessi (punti di regolazione con angoli di rotazione). Con le conoscenze acquisite, puoi sviluppare il tuo modello (o scrivere codice) per ottenere un oggetto `GraphicsPath` o persino impostare i valori dei punti di regolazione di un connettore basati su coordinate specifiche della diapositiva.

## **Trova l'angolo delle linee del connettore**

1. Crea un'istanza della classe.
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Accedi alla forma della linea del connettore.
1. Usa la larghezza, l'altezza, l'altezza del frame della forma e la larghezza del frame della forma per calcolare l'angolo.

Questo codice JavaScript dimostra un'operazione in cui abbiamo calcolato l'angolo per una forma di linea del connettore:

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**Come posso capire se un connettore può essere "incollato" a una forma specifica?**

Verifica che la forma esponga i [punti di connessione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Se non ce ne sono o il conteggio è zero, l'incollaggio non è disponibile; in tal caso, usa estremità libere e posizionale manualmente. È consigliabile controllare il conteggio dei punti prima di collegare.

**Cosa succede a un connettore se elimino una delle forme collegate?**

Le sue estremità verranno staccate; il connettore rimane sulla diapositiva come una linea ordinaria con inizio/fine liberi. Puoi eliminarlo oppure riassegnare le connessioni e, se necessario, [reroute](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/connector/reroute/).

**I collegamenti dei connettori vengono conservati quando si copia una diapositiva in un'altra presentazione?**

In genere sì, a condizione che anche le forme di destinazione vengano copiate. Se la diapositiva viene inserita in un altro file senza le forme collegate, le estremità diventano libere e dovrai ricollegarle.