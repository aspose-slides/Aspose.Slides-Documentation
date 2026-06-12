---
title: Aggiungere filigrane alle presentazioni in Java
linktitle: Filigrana
type: docs
weight: 40
url: /it/java/watermark/
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
- Java
- Aspose.Slides
description: "Gestisci filigrane di testo e immagine in presentazioni PowerPoint e OpenDocument in Java per indicare una bozza, informazioni riservate, copyright e altro."
---
## **Introduzione**

**Una filigrana** in una presentazione è un timbro di testo o immagine utilizzato su una diapositiva o su tutte le diapositive della presentazione. Di solito, una filigrana viene usata per indicare che la presentazione è una bozza (ad es., una filigrana “Bozza”), che contiene informazioni riservate (ad es., una filigrana “Confidenziale”), per specificare a quale azienda appartiene (ad es., una filigrana “Nome Azienda”), per identificare l’autore della presentazione, ecc. Una filigrana aiuta a prevenire violazioni di copyright indicando che la presentazione non deve essere copiata. Le filigrane sono utilizzate sia nei formati di presentazione PowerPoint sia in quelli OpenOffice. In Aspose.Slides, è possibile aggiungere una filigrana ai formati di file PowerPoint PPT, PPTX e OpenOffice ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/java/), esistono diversi modi per creare filigrane in documenti PowerPoint o OpenOffice e modificare il loro design e comportamento. L’aspetto comune è che, per aggiungere filigrane di testo, si deve usare l’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/), e per aggiungere filigrane immagine, si utilizza la classe [PictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/pictureframe/) oppure si riempie una forma di filigrana con un’immagine. `PictureFrame` implementa l’interfaccia [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/) , consentendo di utilizzare tutte le impostazioni flessibili dell’oggetto forma. Poiché `ITextFrame` non è una forma e le sue impostazioni sono limitate, viene avvolto in un oggetto [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/).

Ci sono due modi per applicare una filigrana: a una singola diapositiva o a tutte le diapositive della presentazione. Lo Slide Master viene usato per applicare una filigrana a tutte le diapositive — la filigrana viene aggiunta allo Slide Master, completamente progettata lì, e applicata a tutte le diapositive senza influire sul permesso di modificare la filigrana su diapositive individuali.

Una filigrana è solitamente considerata non modificabile da altri utenti. Per impedire che la filigrana (o piuttosto la forma padre della filigrana) venga modificata, Aspose.Slides fornisce la funzionalità di blocco delle forme. Una forma specifica può essere bloccata su una diapositiva normale o su uno Slide Master. Quando la forma della filigrana è bloccata sullo Slide Master, sarà bloccata su tutte le diapositive della presentazione.

È possibile impostare un nome per la filigrana in modo che, in futuro, se si desidera eliminarla, sia possibile trovarla tra le forme della diapositiva tramite nome.

È possibile progettare la filigrana in qualsiasi modo; tuttavia, di solito le filigrane hanno caratteristiche comuni, come allineamento centrale, rotazione, posizione in primo piano, ecc. Considereremo come usare queste caratteristiche negli esempi seguenti.

## **Filigrana di Testo**

### **Aggiungere una Filigrana di Testo a una Diapositiva**

Per aggiungere una filigrana di testo in PPT, PPTX o ODP, è possibile prima aggiungere una forma alla diapositiva, quindi aggiungere un frame di testo a questa forma. Il frame di testo è rappresentato dall’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/). Questo tipo non eredita da [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/), che dispone di un ampio set di proprietà per posizionare la filigrana in modo flessibile. Pertanto, l’oggetto [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) è avvolto in un oggetto [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/). Per aggiungere il testo della filigrana alla forma, utilizzare il metodo [addTextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) come mostrato di seguito.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Vedi anche" %}} 
- [Come usare la classe TextFrame](/slides/it/java/text-formatting/)
{{% /alert %}}

### **Aggiungere una Filigrana di Testo a una Presentazione**

Se si desidera aggiungere una filigrana di testo all’intera presentazione (cioè a tutte le diapositive contemporaneamente), aggiungerla al [MasterSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/masterslide/). Il resto della logica è lo stesso di quando si aggiunge una filigrana a una singola diapositiva — creare un oggetto [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) e quindi aggiungere la filigrana utilizzando il metodo [addTextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Vedi anche" %}} 
- [Come usare lo Slide Master](/slides/it/java/slide-master/)
{{% /alert %}}

### **Impostare la Trasparenza della Forma della Filigrana**

Per impostazione predefinita, la forma rettangolare è stilizzata con colori di riempimento e di linea. Le seguenti righe di codice rendono la forma trasparente.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Impostare il Font per una Filigrana di Testo**

È possibile cambiare il font della filigrana di testo come mostrato di seguito.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Impostare il Colore del Testo della Filigrana**

Per impostare il colore del testo della filigrana, utilizzare questo codice:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **Centrare una Filigrana di Testo**

È possibile centrare la filigrana su una diapositiva; per farlo, eseguire quanto segue:

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

L’immagine sotto mostra il risultato finale.

![La filigrana di testo](text_watermark.png)

## **Filigrana Immagine**

### **Aggiungere una Filigrana Immagine a una Presentazione**

Per aggiungere una filigrana immagine a una diapositiva della presentazione, è possibile eseguire quanto segue:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Bloccare una Filigrana dalla Modifica**

Se è necessario impedire la modifica di una filigrana, utilizzare il metodo [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) sulla forma. Con questa proprietà, è possibile proteggere la forma dall’essere selezionata, ridimensionata, riposizionata, raggruppata con altri elementi, bloccare il suo testo dalla modifica e molto altro:

```java
// Blocca la forma della filigrana dalla modifica
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Portare una Filigrana in Primo Piano**

In Aspose.Slides, l’ordine Z delle forme può essere impostato tramite il metodo [IShapeCollection.reorder](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Per farlo, è necessario chiamare questo metodo dall’elenco delle diapositive della presentazione e passare il riferimento della forma e il suo numero di ordine al metodo. In questo modo è possibile portare una forma in primo piano o inviarla in fondo alla diapositiva. Questa funzionalità è particolarmente utile se si deve posizionare una filigrana davanti alla presentazione:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Impostare la Rotazione della Filigrana**

Ecco un esempio di codice su come regolare la rotazione della filigrana affinché sia posizionata diagonalmente sulla diapositiva:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Impostare un Nome per una Filigrana**

Aspose.Slides consente di impostare il nome di una forma. Utilizzando il nome della forma, è possibile accedervi in futuro per modificarla o eliminarla. Per impostare il nome della forma della filigrana, assegnarlo al metodo [IAutoShape.setName](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("watermark");
```

### **Rimuovere una Filigrana**

Per rimuovere la forma della filigrana, utilizzare il metodo [IAutoShape.getName](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getName--) per trovarla tra le forme della diapositiva. Quindi, passare la forma della filigrana al metodo [IShapeCollection.remove](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

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

**Che cos’è una filigrana e perché dovrei usarla?**

Una filigrana è una sovrapposizione di testo o immagine applicata alle diapositive che aiuta a proteggere la proprietà intellettuale, a migliorare il riconoscimento del brand o a prevenire l’uso non autorizzato delle presentazioni.

**Posso aggiungere una filigrana a tutte le diapositive di una presentazione?**

Sì, Aspose.Slides consente di aggiungere programmaticamente una filigrana a ciascuna diapositiva di una presentazione. È possibile iterare su tutte le diapositive e applicare le impostazioni della filigrana individualmente.

**Come posso regolare la trasparenza della filigrana?**

È possibile regolare la trasparenza della filigrana modificando le impostazioni di riempimento ([getFillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getFillFormat--)) della forma. Questo garantisce che la filigrana sia discreta e non distragga dal contenuto della diapositiva.

**Quali formati immagine sono supportati per le filigrane?**

Aspose.Slides supporta vari formati immagine come PNG, JPEG, GIF, BMP, SVG e altri.

**Posso personalizzare il font e lo stile di una filigrana di testo?**

Sì, è possibile scegliere qualsiasi font, dimensione e stile per adattarsi al design della presentazione e mantenere la coerenza del brand.

**Come faccio a cambiare la posizione o l’orientamento di una filigrana?**

È possibile regolare la posizione e l’orientamento della filigrana programmaticamente modificando le coordinate, le dimensioni e le proprietà di rotazione della forma.