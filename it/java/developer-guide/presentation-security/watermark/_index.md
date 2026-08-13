---
title: Aggiungere Filigrane alle Presentazioni in Java
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
description: "Gestisci filigrane di testo e immagine in presentazioni PowerPowerPoint e OpenDocument in Java per indicare una bozza, informazioni riservate, copyright e altro."
---
## **Introduzione**

**Una filigrana** in una presentazione è un timbro di testo o immagine usato su una diapositiva o su tutte le diapositive della presentazione. Di solito una filigrana viene utilizzata per indicare che la presentazione è una bozza (ad es., una filigrana “Bozza”), che contiene informazioni riservate (ad es., una filigrana “Confidenziale”), per specificare a quale azienda appartiene (ad es., una filigrana “Nome Azienda”), per identificare l’autore della presentazione, ecc. Una filigrana aiuta a prevenire violazioni di copyright indicando che la presentazione non deve essere copiata. Le filigrane sono usate sia nei formati di presentazione PowerPoint sia OpenOffice. In Aspose.Slides è possibile aggiungere una filigrana ai formati di file PowerPoint PPT, PPTX e OpenOffice ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/java/), esistono vari modi per creare filigrane in documenti PowerPoint o OpenOffice e per modificarne design e comportamento. L’aspetto comune è che per aggiungere filigrane di testo, si deve usare l’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/), e per aggiungere filigrane immagine, si utilizza la classe [PictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/pictureframe/) o si riempie una forma filigrana con un’immagine. `PictureFrame` implementa l’interfaccia [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/), consentendo di usare tutte le impostazioni flessibili dell’oggetto forma. Poiché `ITextFrame` non è una forma e le sue impostazioni sono limitate, viene incapsulato in un oggetto [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/).

Ci sono due modi per applicare una filigrana: a una singola diapositiva o a tutte le diapositive della presentazione. Lo Slide Master è usato per applicare una filigrana a tutte le diapositive della presentazione — la filigrana è aggiunta allo Slide Master, progettata completamente lì, e applicata a tutte le diapositive senza influire sul permesso di modificare la filigrana sulle diapositive individuali.

Una filigrana è generalmente considerata non modificabile da altri utenti. Per impedire che la filigrana (o meglio la forma madre della filigrana) venga modificata, Aspose.Slides fornisce la funzionalità di blocco della forma. Una forma specifica può essere bloccata su una diapositiva normale o su uno Slide Master. Quando la forma della filigrana è bloccata sullo Slide Master, sarà bloccata su tutte le diapositive della presentazione.

È possibile impostare un nome per la filigrana in modo che in futuro, se si desidera eliminarla, sia possibile trovarla tra le forme della diapositiva per nome.

È possibile progettare la filigrana in qualsiasi modo; tuttavia, di solito le filigrane hanno caratteristiche comuni, come l’allineamento al centro, la rotazione, la posizione in primo piano, ecc. Considereremo come utilizzare queste caratteristiche negli esempi seguenti.

## **Filigrana di Testo**

### **Aggiungere una filigrana di testo a una diapositiva**

Per aggiungere una filigrana di testo in PPT, PPTX o ODP, è possibile prima aggiungere una forma alla diapositiva, quindi aggiungere un frame di testo a quella forma. Il frame di testo è rappresentato dall’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/). Questo tipo non eredita da [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/), che dispone di un’ampia serie di proprietà per posizionare la filigrana in modo flessibile. Pertanto, l’oggetto [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) è incapsulato in un oggetto [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/). Per aggiungere il testo della filigrana alla forma, utilizzare il metodo [addTextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) come mostrato di seguito.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Vedi anche" %}} 
- [Come usare la classe TextFrame](/slides/it/java/text-formatting/)
{{% /alert %}}

### **Aggiungere una filigrana di testo a una presentazione**

Se si desidera aggiungere una filigrana di testo all’intera presentazione (cioè a tutte le diapositive contemporaneamente), aggiungerla al [MasterSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/masterslide/). Il resto della logica è lo stesso di quando si aggiunge una filigrana a una singola diapositiva — creare un oggetto [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) e poi aggiungere la filigrana usando il metodo [addTextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Vedi anche" %}} 
- [Come usare lo Slide Master](/slides/it/java/slide-master/)
{{% /alert %}}

### **Impostare la trasparenza della forma filigrana**

Per impostazione predefinita, la forma rettangolare è stilizzata con colori di riempimento e di contorno. Le righe di codice seguenti rendono la forma trasparente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **Impostare il carattere per una filigrana di testo**

È possibile cambiare il carattere della filigrana di testo come mostrato di seguito.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **Impostare il colore del testo della filigrana**

Per impostare il colore del testo della filigrana, utilizzare questo codice:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **Centrare una filigrana di testo**

È possibile centrare la filigrana su una diapositiva; per farlo, eseguire quanto segue:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

L’immagine sottostante mostra il risultato finale.

![La filigrana testuale](text_watermark.png)

## **Filigrana Immagine**

### **Aggiungere una filigrana immagine a una presentazione**

Per aggiungere una filigrana immagine a una diapositiva della presentazione, è possibile eseguire quanto segue:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **Bloccare una filigrana dalla modifica**

Se è necessario impedire la modifica di una filigrana, utilizzare il metodo [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) sulla forma. Con questa proprietà è possibile proteggere la forma da selezione, ridimensionamento, riposizionamento, raggruppamento con altri elementi, bloccare il testo dalla modifica e molto altro:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Blocca la forma della filigrana dalla modifica
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **Portare una filigrana in primo piano**

In Aspose.Slides, l’ordine Z delle forme può essere impostato tramite il metodo [IShapeCollection.reorder](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Per farlo, è necessario chiamare questo metodo dall’elenco delle diapositive della presentazione e passare il riferimento della forma e il suo numero di ordine nel metodo. In questo modo è possibile portare una forma in primo piano o inviarla sullo sfondo della diapositiva. Questa funzionalità è particolarmente utile se si deve posizionare una filigrana davanti alla presentazione:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **Impostare la rotazione della filigrana**

Ecco un esempio di codice su come regolare la rotazione della filigrana affinché sia posizionata diagonalmente sulla diapositiva:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **Impostare un nome per una filigrana**

Aspose.Slides consente di impostare il nome di una forma. Utilizzando il nome della forma, è possibile accedervi in futuro per modificarla o eliminarla. Per impostare il nome della forma filigrana, assegnarlo al metodo [IAutoShape.setName](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **Rimuovere una filigrana**

Per rimuovere la forma filigrana, utilizzare il metodo [IAutoShape.getName](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getName--) per trovarla tra le forme della diapositiva. Quindi passare la forma filigrana al metodo [IShapeCollection.remove](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **FAQ**

### Cos’è una filigrana e perché dovrei usarla?

Una filigrana è una sovrapposizione di testo o immagine applicata alle diapositive che aiuta a proteggere la proprietà intellettuale, migliorare il riconoscimento del brand o prevenire l’uso non autorizzato delle presentazioni.

### Posso aggiungere una filigrana a tutte le diapositive di una presentazione?

Sì, Aspose.Slides consente di aggiungere programmaticamente una filigrana a ogni diapositiva di una presentazione. È possibile iterare tutte le diapositive e applicare le impostazioni della filigrana individualmente.

### Come posso regolare la trasparenza della filigrana?

È possibile regolare la trasparenza della filigrana modificando le impostazioni di riempimento ([getFillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getFillFormat--)) della forma. Questo garantisce che la filigrana sia discreta e non distragga dal contenuto della diapositiva.

### Quali formati immagine sono supportati per le filigrane?

Aspose.Slides supporta vari formati immagine come PNG, JPEG, GIF, BMP, SVG e molti altri.

### Posso personalizzare il carattere e lo stile di una filigrana di testo?

Sì, è possibile scegliere qualsiasi carattere, dimensione e stile per adattarsi al design della presentazione e mantenere la coerenza del brand.

### Come posso modificare la posizione o l’orientamento di una filigrana?

È possibile regolare la posizione e l’orientamento della filigrana programmaticamente modificando le coordinate, le dimensioni e le proprietà di rotazione della forma.