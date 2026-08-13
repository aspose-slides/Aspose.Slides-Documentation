---
title: Aggiungi Filigrane alle Presentazioni su Android
linktitle: Filigrana
type: docs
weight: 40
url: /it/androidjava/watermark/
keywords:
- filigrana
- filigrana di testo
- filigrana di immagine
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
- Android
- Java
- Aspose.Slides
description: "Gestisci filigrane di testo e immagine nelle presentazioni PowerPoint e OpenDocument su Android in Java per indicare una bozza, informazioni riservate e altro."
---
## **Introduzione**

**Un watermark** in una presentazione è un timbro di testo o immagine utilizzato su una diapositiva o su tutte le diapositive della presentazione. Di solito, un watermark è usato per indicare che la presentazione è una bozza (ad es., un watermark “Bozza”), che contiene informazioni riservate (ad es., un watermark “Confidenziale”), per specificare a quale azienda appartiene (ad es., un watermark “Nome Azienda”), per identificare l’autore della presentazione, ecc. Un watermark aiuta a prevenire violazioni di copyright indicando che la presentazione non deve essere copiata. I watermark sono usati sia nei formati di presentazione PowerPoint sia OpenOffice. In Aspose.Slides, è possibile aggiungere un watermark ai formati di file PowerPoint PPT, PPTX e OpenOffice ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/android-java/), esistono vari modi per creare watermark in documenti PowerPoint o OpenOffice e modificarne design e comportamento. L’aspetto comune è che, per aggiungere watermark di testo, si deve usare l’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/), e per aggiungere watermark di immagine, si usa la classe [PictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pictureframe/) o si riempie una forma watermark con un’immagine. `PictureFrame` implementa l’interfaccia [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/), consentendo di utilizzare tutte le impostazioni flessibili dell’oggetto forma. Poiché `ITextFrame` non è una forma e le sue impostazioni sono limitate, viene avvolto in un oggetto [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/).

Ci sono due modi per applicare un watermark: a una singola diapositiva o a tutte le diapositive della presentazione. Lo Slide Master è usato per applicare un watermark a tutte le diapositive della presentazione — il watermark viene aggiunto allo Slide Master, completamente progettato lì, e applicato a tutte le diapositive senza influire sul permesso di modificare il watermark su singole diapositive.

Un watermark è solitamente considerato non modificabile da altri utenti. Per impedire che il watermark (o piuttosto la forma genitore del watermark) venga modificato, Aspose.Slides fornisce funzionalità di blocco delle forme. Una forma specifica può essere bloccata su una diapositiva normale o su uno Slide Master. Quando la forma del watermark è bloccata sullo Slide Master, sarà bloccata su tutte le diapositive della presentazione.

È possibile impostare un nome per il watermark in modo che, in futuro, se si desidera eliminarlo, sia possibile trovarlo tra le forme della diapositiva per nome.

È possibile progettare il watermark in qualsiasi modo; tuttavia, di solito i watermark hanno caratteristiche comuni, come allineamento al centro, rotazione, posizione in primo piano, ecc. Vedremo come utilizzare queste caratteristiche negli esempi seguenti.

## **Watermark di Testo**

### **Aggiungere un Watermark di Testo a una Diapositiva**

Per aggiungere un watermark di testo in PPT, PPTX o ODP, è possibile prima aggiungere una forma alla diapositiva, quindi aggiungere un frame di testo a questa forma. Il frame di testo è rappresentato dall’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/). Questo tipo non eredita da [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/), che possiede un ampio set di proprietà per posizionare il watermark in modo flessibile. Pertanto, l’oggetto [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) è avvolto in un oggetto [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/). Per aggiungere testo watermark alla forma, usare il metodo [addTextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) come mostrato di seguito.

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
- [Come utilizzare la classe TextFrame](/slides/it/androidjava/text-formatting/)
{{% /alert %}}

### **Aggiungere un Watermark di Testo a una Presentazione**

Se si desidera aggiungere un watermark di testo all’intera presentazione (cioè a tutte le diapositive contemporaneamente), aggiungerlo allo [MasterSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/masterslide/). Il resto della logica è lo stesso di quando si aggiunge un watermark a una singola diapositiva — creare un oggetto [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) e poi aggiungere il watermark usando il metodo [addTextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

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
- [Come utilizzare lo Slide Master](/slides/it/androidjava/slide-master/)
{{% /alert %}}

### **Impostare la Trasparenza della Forma del Watermark**

Per impostazione predefinita, la forma rettangolare è stilizzata con colori di riempimento e contorno. Le righe di codice seguenti rendono la forma trasparente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **Impostare il Font per un Watermark di Testo**

È possibile modificare il font del watermark di testo come mostrato di seguito.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **Impostare il Colore del Testo del Watermark**

Per impostare il colore del testo del watermark, usare questo codice:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **Centrare un Watermark di Testo**

È possibile centrare il watermark su una diapositiva; per farlo, eseguire quanto segue:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

L’immagine sottostante mostra il risultato finale.

![Il watermark di testo](text_watermark.png)

## **Watermark di Immagine**

### **Aggiungere un Watermark di Immagine a una Presentazione**

Per aggiungere un watermark di immagine a una diapositiva della presentazione, è possibile eseguire quanto segue:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **Bloccare un Watermark dalla Modifica**

Se è necessario impedire la modifica di un watermark, usare il metodo [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) sulla forma. Con questa proprietà è possibile proteggere la forma da selezione, ridimensionamento, riposizionamento, raggruppamento con altri elementi, blocco del testo dalla modifica e molto altro:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // Blocca la forma della filigrana dalla modifica
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **Portare un Watermark in Primo Piano**

In Aspose.Slides, l’ordine Z delle forme può essere impostato tramite il metodo [IShapeCollection.reorder](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) . Per farlo, è necessario chiamare questo metodo dall’elenco delle diapositive della presentazione e passare il riferimento della forma e il suo numero d’ordine al metodo. In questo modo è possibile portare una forma in primo piano o spostarla sullo sfondo della diapositiva. Questa funzionalità è particolarmente utile se si deve posizionare un watermark davanti alla presentazione:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **Impostare la Rotazione del Watermark**

Ecco un esempio di codice su come regolare la rotazione del watermark in modo che sia posizionato diagonalmente sulla diapositiva:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **Impostare un Nome per un Watermark**

Aspose.Slides consente di impostare il nome di una forma. Utilizzando il nome della forma, è possibile accedervi in futuro per modificarla o eliminarla. Per impostare il nome della forma watermark, assegnarlo al metodo [IAutoShape.setName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **Rimuovere un Watermark**

Per rimuovere la forma watermark, usare il metodo [IAutoShape.getName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getName--) per trovarla tra le forme della diapositiva. Quindi, passare la forma watermark al metodo [IShapeCollection.remove](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Cos'è un watermark e perché dovrei usarlo?

Un watermark è una sovrapposizione di testo o immagine applicata alle diapositive che aiuta a proteggere la proprietà intellettuale, migliorare il riconoscimento del marchio o impedire l’uso non autorizzato delle presentazioni.

### Posso aggiungere un watermark a tutte le diapositive di una presentazione?

Sì, Aspose.Slides consente di aggiungere programmaticamente un watermark a ogni diapositiva di una presentazione. È possibile iterare tutte le diapositive e applicare le impostazioni del watermark singolarmente.

### Come posso regolare la trasparenza del watermark?

È possibile regolare la trasparenza del watermark modificando le impostazioni di riempimento ([getFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getFillFormat--)) della forma. Questo garantisce che il watermark sia discreto e non distolga l’attenzione dal contenuto della diapositiva.

### Quali formati immagine sono supportati per i watermark?

Aspose.Slides supporta vari formati immagine come PNG, JPEG, GIF, BMP, SVG e altri.

### Posso personalizzare il font e lo stile di un watermark di testo?

Sì, è possibile scegliere qualsiasi font, dimensione e stile per adattarsi al design della presentazione e mantenere la coerenza del marchio.

### Come posso cambiare la posizione o l’orientamento di un watermark?

È possibile modificare la posizione e l’orientamento del watermark programmaticamente modificando le coordinate, le dimensioni e le proprietà di rotazione della forma.