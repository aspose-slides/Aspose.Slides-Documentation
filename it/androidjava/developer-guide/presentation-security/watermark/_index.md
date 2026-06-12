---
title: Aggiungi Watermark alle Presentazioni su Android
linktitle: Filigrana
type: docs
weight: 40
url: /it/androidjava/watermark/
keywords:
- filigrana
- filigrana di testo
- filigrana di immagine
- aggiungere filigrana
- modificare filigrana
- rimuovere filigrana
- eliminare filigrana
- aggiungere filigrana a PPT
- aggiungere filigrana a PPTX
- aggiungere filigrana a ODP
- rimuovere filigrana da PPT
- rimuovere filigrana da PPTX
- rimuovere filigrana da ODP
- eliminare filigrana da PPT
- eliminare filigrana da PPTX
- eliminare filigrana da ODP
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Gestisci le filigrane di testo e immagine nelle presentazioni PowerPoint e OpenDocument su Android in Java per indicare una bozza, informazioni riservate e altro."
---
## **Introduzione**

**Un watermark** in una presentazione è un timbro di testo o immagine utilizzato su una diapositiva o su tutte le diapositive della presentazione. Di solito, un watermark serve a indicare che la presentazione è una bozza (ad es. un watermark “Bozza”), che contiene informazioni riservate (ad es. un watermark “Confidenziale”), a specificare a quale azienda appartiene (ad es. un watermark “Nome Azienda”), a identificare l’autore della presentazione, ecc. Un watermark aiuta a prevenire violazioni di copyright indicando che la presentazione non deve essere copiata. I watermark sono utilizzati sia nei formati di presentazione PowerPoint sia in OpenOffice. In Aspose.Slides, è possibile aggiungere un watermark ai formati di file PowerPoint PPT, PPTX e OpenOffice ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/android-java/), esistono diversi modi per creare watermark in documenti PowerPoint o OpenOffice e modificare il loro design e comportamento. L’aspetto comune è che, per aggiungere watermark di testo, occorre utilizzare l’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/), mentre per aggiungere watermark di immagine si usa la classe [PictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pictureframe/) o si riempie una forma di watermark con un’immagine. `PictureFrame` implementa l’interfaccia [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/), consentendo di utilizzare tutte le impostazioni flessibili dell’oggetto forma. Poiché `ITextFrame` non è una forma e le sue impostazioni sono limitate, viene avvolto in un oggetto [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/).

Ci sono due modalità di applicazione di un watermark: a una singola diapositiva o a tutte le diapositive della presentazione. Lo Slide Master è usato per applicare un watermark a tutte le diapositive: il watermark viene aggiunto allo Slide Master, progettato completamente lì e applicato a tutte le diapositive senza influire sul permesso di modificare il watermark nelle diapositive individuali.

Un watermark è solitamente considerato non modificabile da altri utenti. Per impedire che il watermark (o più precisamente la forma padre del watermark) venga modificato, Aspose.Slides fornisce la funzionalità di blocco delle forme. Una forma specifica può essere bloccata su una diapositiva normale o su uno Slide Master. Quando la forma del watermark è bloccata sullo Slide Master, sarà bloccata su tutte le diapositive della presentazione.

È possibile assegnare un nome al watermark così che, in futuro, se si desidera eliminarlo, lo si possa trovare tra le forme della diapositiva tramite il nome.

È possibile progettare il watermark in qualsiasi modo; tuttavia, di solito i watermark condividono caratteristiche comuni, come l’allineamento al centro, la rotazione, la posizione in primo piano, ecc. Di seguito vedremo come utilizzare questi aspetti negli esempi.

## **Watermark di Testo**

### **Aggiungere un Watermark di Testo a una Diapositiva**

Per aggiungere un watermark di testo in PPT, PPTX o ODP, è possibile prima aggiungere una forma alla diapositiva, quindi aggiungere un frame di testo a tale forma. Il frame di testo è rappresentato dall’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/). Questo tipo non eredita da [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/), che dispone di un ampio set di proprietà per posizionare il watermark in modo flessibile. Pertanto, l’oggetto [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) viene avvolto in un oggetto [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/). Per aggiungere il testo del watermark alla forma, utilizza il metodo [addTextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) come mostrato di seguito.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Vedi anche" %}} 
- [How to Use the TextFrame Class](/slides/it/androidjava/text-formatting/)
{{% /alert %}}

### **Aggiungere un Watermark di Testo a una Presentazione**

Se desideri aggiungere un watermark di testo all’intera presentazione (cioè a tutte le diapositive contemporaneamente), aggiungilo allo [MasterSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/masterslide/). Il resto della logica è identico a quello per aggiungere un watermark a una singola diapositiva: crea un oggetto [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) e poi aggiungi il watermark usando il metodo [addTextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Vedi anche" %}} 
- [How to Use the Slide Master](/slides/it/androidjava/slide-master/)
{{% /alert %}}

### **Impostare la Trasparenza della Forma del Watermark**

Per impostazione predefinita, la forma rettangolare è stilizzata con colori di riempimento e di linea. Le righe di codice seguenti rendono la forma trasparente.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Impostare il Font per un Watermark di Testo**

È possibile modificare il font del watermark di testo come mostrato di seguito.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Impostare il Colore del Testo del Watermark**

Per impostare il colore del testo del watermark, utilizza questo codice:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **Centrare un Watermark di Testo**

È possibile centrare il watermark su una diapositiva; per farlo, puoi eseguire le operazioni seguenti:

```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

L’immagine sottostante mostra il risultato finale.

![The text watermark](text_watermark.png)

## **Watermark di Immagine**

### **Aggiungere un Watermark di Immagine a una Presentazione**

Per aggiungere un watermark di immagine a una diapositiva della presentazione, è possibile procedere come segue:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Bloccare un Watermark dalla Modifica**

Se è necessario impedire la modifica di un watermark, utilizza il metodo [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) sulla forma. Con questa proprietà è possibile proteggere la forma da selezione, ridimensionamento, riposizionamento, raggruppamento con altri elementi, blocco del testo dalla modifica e molto altro:

```java
// Blocca la forma del watermark dalla modifica
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Portare un Watermark in Primo Piano**

In Aspose.Slides, l’ordine Z delle forme può essere impostato tramite il metodo [IShapeCollection.reorder](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Per farlo, devi chiamare questo metodo dall’elenco delle diapositive della presentazione e passare il riferimento della forma e il suo numero d’ordine al metodo. In questo modo è possibile portare una forma in primo piano o inviarla sullo sfondo della diapositiva. Questa funzionalità è particolarmente utile se devi posizionare un watermark davanti alla presentazione:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Impostare la Rotazione del Watermark**

Ecco un esempio di codice su come regolare la rotazione del watermark affinché sia posizionato diagonalmente sulla diapositiva:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Impostare un Nome per un Watermark**

Aspose.Slides consente di impostare il nome di una forma. Utilizzando il nome della forma, è possibile accedervi in futuro per modificarla o eliminarla. Per impostare il nome della forma del watermark, assegnalo al metodo [IAutoShape.setName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("watermark");
```

### **Rimuovere un Watermark**

Per rimuovere la forma del watermark, utilizza il metodo [IAutoShape.getName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getName--) per trovarla tra le forme della diapositiva. Quindi, passa la forma del watermark al metodo [IShapeCollection.remove](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **FAQ**

**Che cos’è un watermark e perché dovrei usarlo?**

Un watermark è una sovrapposizione di testo o immagine applicata alle diapositive che aiuta a proteggere la proprietà intellettuale, a migliorare il riconoscimento del brand o a prevenire l’uso non autorizzato delle presentazioni.

**Posso aggiungere un watermark a tutte le diapositive di una presentazione?**

Sì, Aspose.Slides consente di aggiungere programmaticamente un watermark a ogni diapositiva di una presentazione. È possibile iterare su tutte le diapositive e applicare le impostazioni del watermark singolarmente.

**Come posso regolare la trasparenza del watermark?**

Puoi regolare la trasparenza del watermark modificando le impostazioni di riempimento ([getFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getFillFormat--)) della forma. In questo modo il watermark risulta delicato e non distoglie l’attenzione dal contenuto della diapositiva.

**Quali formati immagine sono supportati per i watermark?**

Aspose.Slides supporta vari formati immagine come PNG, JPEG, GIF, BMP, SVG e altri.

**Posso personalizzare il font e lo stile di un watermark di testo?**

Sì, puoi scegliere qualsiasi font, dimensione e stile per adattare il watermark al design della tua presentazione e mantenere la coerenza del brand.

**Come faccio a cambiare la posizione o l’orientamento di un watermark?**

Puoi modificare programmaticamente la posizione e l’orientamento del watermark cambiando le coordinate, le dimensioni e le proprietà di rotazione della forma.