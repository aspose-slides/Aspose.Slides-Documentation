---
title: Aggiungere filigrane alle presentazioni in JavaScript
linktitle: Filigrana
type: docs
weight: 40
url: /it/nodejs-java/watermark/
keywords:
- filigrana
- filigrana di testo
- filigrana immagine
- aggiungi filigrana
- modifica filigrana
- rimuovi filigrana
- elimina filigrana
- aggiungi filigrana a PPT
- aggiungi filigrana a PPTX
- aggiungi filigrana a ODP
- rimuovi filigrana da PPT
- rimuovi filigrana da PPTX
- rimuovi filigrana da ODP
- elimina filigrana da PPT
- elimina filigrana da PPTX
- elimina filigrana da ODP
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci filigrane di testo e immagine in presentazioni PowerPowerPoint e OpenDocument in Node.js per indicare una bozza, informazioni confidenziali, copyright e altro."
---
## **Introduzione**

**Un watermark** in una presentazione è un timbro di testo o immagine utilizzato su una diapositiva o su tutte le diapositive della presentazione. Solitamente, un watermark viene usato per indicare che la presentazione è una bozza (ad es., un watermark "Bozza"), che contiene informazioni riservate (ad es., un watermark "Confidenziale"), per specificare a quale azienda appartiene (ad es., un watermark "Nome Azienda"), per identificare l'autore della presentazione, ecc. Un watermark aiuta a prevenire violazioni del copyright indicando che la presentazione non deve essere copiata. I watermark sono usati sia nei formati di presentazione PowerPoint che OpenOffice. In Aspose.Slides, è possibile aggiungere un watermark ai formati di file PowerPoint PPT, PPTX e OpenOffice ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/nodejs-java/), esistono diversi modi per creare watermark in documenti PowerPoint o OpenOffice e modificarne il design e il comportamento. L'aspetto comune è che, per aggiungere watermark di testo, si dovrebbe usare il tipo [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/), e per aggiungere watermark di immagine, utilizzare la classe [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/) oppure riempire una forma di watermark con un'immagine. `PictureFrame` implementa il tipo [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/), consentendo di utilizzare tutte le impostazioni flessibili dell'oggetto forma. Poiché `TextFrame` non è una forma e le sue impostazioni sono limitate, viene avvolto in un oggetto [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/).

Ci sono due modalità per applicare un watermark: su una singola diapositiva o su tutte le diapositive della presentazione. Lo Slide Master viene utilizzato per applicare un watermark a tutte le diapositive — il watermark viene aggiunto allo Slide Master, completamente progettato lì, e applicato a tutte le diapositive senza influenzare il permesso di modificare il watermark su diapositive individuali.

Un watermark è generalmente considerato non modificabile da altri utenti. Per impedire che il watermark (o più precisamente la forma genitore del watermark) venga modificato, Aspose.Slides fornisce la funzionalità di blocco della forma. Una forma specifica può essere bloccata su una diapositiva normale o su uno Slide Master. Quando la forma del watermark è bloccata sullo Slide Master, sarà bloccata su tutte le diapositive della presentazione.

È possibile impostare un nome per il watermark in modo che in futuro, se si desidera eliminarlo, sia possibile trovarlo tra le forme della diapositiva per nome.

È possibile progettare il watermark in qualsiasi modo; tuttavia, di solito ci sono caratteristiche comuni nei watermark, come l'allineamento centrato, la rotazione, la posizione in primo piano, ecc. Considereremo come utilizzare questi elementi negli esempi seguenti.

## **Watermark di Testo**

### **Aggiungere un Watermark di Testo alla Diapositiva**
Per aggiungere un watermark di testo in PPT, PPTX o ODP, è possibile prima aggiungere una forma alla diapositiva, quindi aggiungere un frame di testo a tale forma. Il frame di testo è rappresentato dal tipo [**TextFrame**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrame). Questo tipo non è ereditato da [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape), che dispone di un ampio set di proprietà per posizionare il watermark in modo flessibile. Pertanto, l’oggetto [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrame) è avvolto in un oggetto [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape). Per aggiungere il testo del watermark alla forma, utilizzare il metodo [**addTextFrame**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) con il testo del watermark passato come parametro:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Vedi anche" %}} 
- Come usare [TextFrame](/slides/it/nodejs-java/text-formatting/).
{{% /alert %}}

### **Aggiungere un Watermark di Testo alla Presentazione**

Se si desidera aggiungere un watermark di testo all'intera presentazione (cioè a tutte le diapositive contemporaneamente), aggiungerlo al [**MasterSlide**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/MasterSlide). Il resto della logica è identico a quello per aggiungere un watermark a una singola diapositiva — creare un oggetto [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape) e poi aggiungere il watermark usando il metodo [**addTextFrame**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-):

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Vedi anche" %}} 
- [Come usare ](/slides/it/nodejs-java/slide-master/)[Slide Master](/slides/it/nodejs-java/slide-master/)
{{% /alert %}}

### **Impostare la Trasparenza della Forma del Watermark**

Di default, la forma rettangolare è stilizzata con colori di riempimento e bordo. Le righe di codice seguenti rendono la forma trasparente.

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **Impostare il Font per un Watermark di Testo**

È possibile cambiare il font del watermark di testo come mostrato di seguito.

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Impostare il Colore del Testo del Watermark**

Per impostare il colore del testo del watermark, utilizzare questo codice:

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **Centrare il Watermark di Testo**
È possibile centrare il watermark su una diapositiva e per farlo si può eseguire quanto segue:

```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

L'immagine sottostante mostra il risultato finale.

![The text watermark](text_watermark.png)

## **Watermark di Immagine**

### **Aggiungere un Watermark di Immagine a una Presentazione**

Per aggiungere un watermark di immagine a tutte le diapositive della presentazione, è possibile procedere come segue:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **Bloccare un Watermark dalla Modifica**

Se è necessario impedire la modifica di un watermark, utilizzare il metodo [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape#getShapeLock--) sulla forma. Con questa proprietà è possibile proteggere la forma da selezione, ridimensionamento, riposizionamento, raggruppamento con altri elementi, bloccare il suo testo dalla modifica e molto altro:

```javascript
// Blocca la forma del watermark dalla modifica
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **Portare un Watermark in Primo Piano**

In Aspose.Slides, l'ordine Z delle forme può essere impostato tramite il metodo [**SlideCollection.reorder**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-). Per farlo, è necessario chiamare questo metodo dall'elenco delle diapositive della presentazione e passare il riferimento della forma e il suo numero d'ordine al metodo. In questo modo, è possibile portare una forma in primo piano o inviarla sullo sfondo della diapositiva. Questa funzionalità è particolarmente utile se si deve posizionare un watermark davanti alla presentazione:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Impostare la Rotazione del Watermark**

Ecco un esempio di codice su come regolare la rotazione del watermark in modo che sia posizionato diagonalmente sulla diapositiva:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **Impostare un Nome per un Watermark**

Aspose.Slides consente di impostare il nome di una forma. Utilizzando il nome della forma, è possibile accedervi in futuro per modificarla o eliminarla. Per impostare il nome della forma watermark, assegnarlo al metodo [**AutoShape.getName**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#getName--):

```javascript
watermarkShape.setName("watermark");
```

### **Rimuovere un Watermark**

Per rimuovere la forma watermark, utilizzare il metodo [AutoShape.getName](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#getName--) per trovarla tra le forme della diapositiva. Quindi, passare la forma watermark al metodo [**ShapeCollection.remove**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-):

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **FAQ**

**Che cos'è un watermark e perché dovrei usarlo?**

Un watermark è una sovrapposizione di testo o immagine applicata alle diapositive che aiuta a proteggere la proprietà intellettuale, migliorare il riconoscimento del marchio o prevenire l'uso non autorizzato delle presentazioni.

**Posso aggiungere un watermark a tutte le diapositive di una presentazione?**

Sì, Aspose.Slides consente di aggiungere un watermark a ogni diapositiva di una presentazione. È possibile iterare su tutte le diapositive e applicare le impostazioni del watermark individualmente.

**Come posso regolare la trasparenza del watermark?**

È possibile regolare la trasparenza del watermark modificando le [impostazioni di riempimento](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getfillformat/) della forma. Questo garantisce che il watermark sia discreto e non distolga l'attenzione dal contenuto della diapositiva.

**Quali formati di immagine sono supportati per i watermark?**

Aspose.Slides supporta vari formati immagine come PNG, JPEG, GIF, BMP, SVG e altri.

**Posso personalizzare il font e lo stile di un watermark di testo?**

Sì, è possibile scegliere qualsiasi font, dimensione e stile per adattarsi al design della presentazione e mantenere la coerenza del marchio.

**Come cambiare la posizione o l'orientamento di un watermark?**

È possibile regolare la posizione e l'orientamento del watermark modificando le coordinate, le dimensioni e le proprietà di rotazione della forma.