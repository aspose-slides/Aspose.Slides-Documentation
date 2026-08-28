---
title: Gestire i paragrafi di testo PowerPoint in Java
linktitle: Gestisci Paragrafo
type: docs
weight: 40
url: /it/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- aggiungere testo
- aggiungere paragrafo
- gestire testo
- gestire paragrafo
- gestire punti
- rientro del paragrafo
- rientro sporgente
- punto del paragrafo
- elenco numerato
- elenco puntato
- proprietà del paragrafo
- importare HTML
- testo in HTML
- paragrafo in HTML
- paragrafo in immagine
- testo in immagine
- esportare paragrafo
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come creare e formattare paragrafi, porzioni, punti elenco, elenchi numerati, rientri, contenuti HTML e immagini dei paragrafi con Aspose.Slides per Java."
---
## **Panoramica**

Aspose.Slides per Java rappresenta il testo come una gerarchia di cornici di testo, paragrafi e porzioni:

* [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua raccolta di paragrafi.
* [IParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/) rappresenta un paragrafo in una cornice di testo e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [IPortion](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/) rappresenta una sequenza di testo entro un paragrafo. Ogni porzione può avere il proprio testo e la formattazione a livello di carattere.

Un paragrafo può quindi contenere testo con diversi caratteri, colori, dimensioni e altre formattazioni usando più porzioni.

## **Creare e formattare i paragrafi**

### **Creare paragrafi con più porzioni**

I passaggi seguenti creano una cornice di testo con tre paragrafi, ognuno contenente tre porzioni:

1. Creare un'istanza della classe [Presentation].
2. Accedere alla diapositiva pertinente tramite il suo indice.
3. Aggiungere una [IAutoShape] rettangolare alla diapositiva.
4. Accedere al [ITextFrame] della forma.
5. Utilizzare il paragrafo predefinito e aggiungere altri due oggetti [IParagraph] alla cornice di testo.
6. Aggiungere un numero sufficiente di oggetti [IPortion] affinché ogni paragrafo contenga tre porzioni. Il paragrafo predefinito contiene già una porzione vuota.
7. Impostare il testo di ciascuna porzione.
8. Applicare la formattazione a livello di carattere tramite [IPortion.getPortionFormat].
9. Salvare la presentazione modificata.

Questo esempio Java implementa i passaggi:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Creare elenchi puntati e numerati**

### **Creare un elenco puntato o numerato**

I punti elenco e la numerazione rendono più facile la scansione degli elementi correlati. In Aspose.Slides, le impostazioni dell'elenco sono definite tramite [IBulletFormat].

1. Creare un'istanza della classe [Presentation].
2. Accedere alla diapositiva pertinente tramite il suo indice.
3. Aggiungere una [IAutoShape] alla diapositiva selezionata.
4. Accedere al [ITextFrame] della forma.
5. Rimuovere il paragrafo predefinito dalla cornice di testo.
6. Creare un [Paragraph] per un punto simbolo.
7. Impostare [IBulletFormat.setType] su [BulletType.Symbol] e specificare il carattere del punto.
8. Impostare il testo del paragrafo, il rientro, il colore del punto e l'altezza del punto.
9. Aggiungere il paragrafo alla cornice di testo.
10. Creare un secondo paragrafo e impostare [IBulletFormat.setType] su [BulletType.Numbered].
11. Configurare lo stile del punto numerato e aggiungere il paragrafo alla cornice di testo.
12. Salvare la presentazione.

Questo esempio Java crea un punto simbolo e un punto numerato:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Utilizzare punti immagine**

I punti immagine ti consentono di utilizzare un'immagine personalizzata al posto di un simbolo o di un numero.

1. Creare un'istanza della classe [Presentation].
2. Accedere alla diapositiva pertinente tramite il suo indice.
3. Aggiungere una [IAutoShape] e accedere al suo [ITextFrame].
4. Rimuovere il paragrafo predefinito dalla cornice di testo.
5. Caricare l'immagine del punto e aggiungerla alla raccolta di immagini della presentazione come un [IPPImage].
6. Creare un [Paragraph] e impostarne il testo.
7. Impostare [IBulletFormat.setType] su [BulletType.Picture].
8. Assegnare l'immagine tramite [IBulletFormat.getPicture] e impostare l'altezza del punto.
9. Aggiungere il paragrafo alla cornice di testo.
10. Salvare la presentazione modificata.

Questo esempio Java crea un punto immagine:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Creare un elenco multilevel**

Impostare [IParagraphFormat.setDepth] per posizionare i paragrafi a diversi livelli di un elenco. Il livello superiore ha una profondità di `0`.

1. Creare una [Presentation] e accedere a una diapositiva.
2. Aggiungere una [IAutoShape] e cancellare il paragrafo predefinito dalla sua cornice di testo.
3. Creare quattro paragrafi e configurare i loro simboli di punto.
4. Im­postare i loro valori [IParagraphFormat.setDepth] a `0`, `1`, `2` e `3`.
5. Aggiungere i paragrafi alla cornice di testo e salvare la presentazione.

Questo esempio Java crea un elenco puntato a quattro livelli:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Iniziare gli elementi di un elenco numerato con valori personalizzati**

Utilizzare [IBulletFormat.setNumberedBulletStartWith] per impostare il numero iniziale visualizzato per un paragrafo numerato.

1. Creare una [Presentation] e aggiungere una [IAutoShape] a una diapositiva.
2. Rimuovere il paragrafo predefinito dalla cornice di testo della forma.
3. Creare tre paragrafi numerati.
4. Im­postare [IBulletFormat.setNumberedBulletStartWith] su `2`, `3` e `7` per i rispettivi paragrafi.
5. Aggiungere i paragrafi alla cornice di testo e salvare la presentazione.

Questo esempio Java assegna un numero di partenza personalizzato a ciascun paragrafo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controllare il layout del paragrafo e le proprietà di fine**

### **Impostare un rientro della prima riga**

Utilizzare [IParagraphFormat.setIndent] per controllare il rientro della prima riga di un paragrafo. Questo metodo sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga a destra, mentre le righe rimanenti rimangono allineate al corpo del paragrafo.

Utilizzare [IParagraphFormat.setMarginLeft] quando è necessario spostare l'intero paragrafo. Utilizzare [IParagraphFormat.setIndent] quando è necessario spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica diversi valori di [IParagraphFormat.setIndent] per dimostrare come il rientro della prima riga influisca sul layout del paragrafo.

1. Creare un'istanza della classe [Presentation].
2. Accedere alla diapositiva target.
3. Aggiungere una [IAutoShape] rettangolare alla diapositiva.
4. Accedere al [ITextFrame] della forma e rimuovere il paragrafo predefinito.
5. Creare diversi paragrafi e impostare valori diversi di [IParagraphFormat.setIndent] per ciascuno.
6. Aggiungere i paragrafi alla cornice di testo.
7. Salvare la presentazione modificata.

Questo codice mostra come impostare un rientro per un paragrafo:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il rientro della prima riga dei paragrafi](first_line_indent.png)

### **Impostare un rientro sporgente**

Un rientro sporgente è un layout di paragrafo in cui la prima riga inizia a sinistra delle righe successive. In Aspose.Slides, si crea questo effetto con [IParagraphFormat.setIndent]. Passare un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [IParagraphFormat.setMarginLeft] definisce la posizione sinistra del corpo del paragrafo, e [IParagraphFormat.setIndent] definisce la posizione della prima riga rispetto a quel margine. Per creare un rientro sporgente, passare un valore positivo a `setMarginLeft` e un valore negativo a `setIndent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe a capo devono allinearsi al corpo del paragrafo anziché al primo carattere della prima riga.

1. Creare un'istanza della classe [Presentation].
2. Accedere alla diapositiva target.
3. Aggiungere una [IAutoShape] rettangolare alla diapositiva.
4. Accedere al [ITextFrame] della forma e rimuovere il paragrafo predefinito.
5. Creare paragrafi e passare un valore positivo a [IParagraphFormat.setMarginLeft] per ciascun paragrafo.
6. Passare un valore negativo a [IParagraphFormat.setIndent] per creare l'effetto di rientro sporgente.
7. Aggiungere i paragrafi alla cornice di testo.
8. Salvare la presentazione modificata.

Questo codice mostra come impostare un rientro sporgente per un paragrafo:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il rientro sporgente dei paragrafi](hanging_indent.png)

### **Impostare le proprietà di esecuzione della fine del paragrafo**

[IParagraph.setEndParagraphPortionFormat] controlla la formattazione del segno di fine paragrafo. L'esempio seguente assegna una dimensione del carattere e un carattere latino al segno di fine del secondo paragrafo:

1. Caricare una [Presentation] e accedere a una diapositiva.
2. Aggiungere una [IAutoShape] e cancellare il suo paragrafo predefinito.
3. Creare due paragrafi e aggiungere loro porzioni di testo.
4. Creare un [PortionFormat] per il segno di fine del secondo paragrafo.
5. Impostare [IBasePortionFormat.setFontHeight] e [IBasePortionFormat.setLatinFont].
6. Assegnare il formato con [IParagraph.setEndParagraphPortionFormat] e salvare la presentazione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Importare ed esportare il contenuto del paragrafo**

### **Importare testo HTML nei paragrafi**

Utilizzare [ParagraphCollection.addFromHtml] per convertire il markup HTML in paragrafi e porzioni in una cornice di testo.

1. Creare un'istanza della classe [Presentation].
2. Accedere a una diapositiva e aggiungere una [IAutoShape].
3. Accedere al [ITextFrame] della forma e cancellare il paragrafo predefinito.
4. Leggere il file HTML di origine.
5. Passare la stringa HTML a [ParagraphCollection.addFromHtml].
6. Salvare la presentazione modificata.

Questo esempio Java importa HTML in una cornice di testo:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Esportare il testo del paragrafo in HTML**

Utilizzare [ParagraphCollection.exportToHtml] per esportare un intervallo selezionato di paragrafi come HTML.

1. Creare un'istanza della classe [Presentation] e caricare la presentazione desiderata.
2. Accedere alla diapositiva e trovare la [IAutoShape] che contiene il testo.
3. Accedere al [ITextFrame] della forma.
4. Chiamare [ParagraphCollection.exportToHtml] passando l'indice del paragrafo iniziale e il numero di paragrafi da esportare.
5. Scrivere la stringa HTML restituita in un file.

Questo esempio Java esporta tutti i paragrafi dalla prima forma di testo:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Renderizzare un paragrafo come immagine**

[IParagraph.getImage] renderizza direttamente un singolo paragrafo e restituisce un [IImage]. Salvare il risultato in un file o stream con [IImage.save]. Non è necessario renderizzare la forma contenente o ritagliare manualmente un bitmap.

[IParagraph.getImage] può restituire `null` se il paragrafo non può essere trovato nella sua collezione genitore, non ha limiti di rendering validi, o non può essere renderizzato. Verificare il risultato prima di salvarlo e rilasciare l'immagine restituita dopo l'uso.

#### **Renderizzare un paragrafo alla scala predefinita**

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, dove la prima forma è una casella di testo contenente tre paragrafi.

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

L'esempio seguente renderizza il secondo paragrafo in una forma di testo regolare alla scala predefinita e salva l'immagine restituita in formato PNG. Il blocco `finally` garantisce che l'immagine venga rilasciata correttamente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'immagine del paragrafo](paragraph_to_image_output.png)

#### **Renderizzare un paragrafo in una cella di tabella con scaling**

Utilizzare la sovraccarico di [IParagraph.getImage] che accetta i parametri `float scaleX` e `float scaleY` per impostare i fattori di scala orizzontale e verticale. L'esempio seguente crea una tabella, renderizza il paragrafo nella sua prima cella al doppio della larghezza e altezza predefinite, e salva il risultato come immagine PNG.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Un fattore di scala di `1` mantiene quell'asse alla sua dimensione pixel predefinita. Per esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono circa il doppio delle dimensioni predefinite, risultando in quattro volte più pixel. Fattori più grandi generalmente producono testo più nitido per lo zoom o output ad alta risoluzione, ma aumentano anche l'uso di memoria e la dimensione del file. Fattori inferiori a `1` producono immagini più piccole con meno dettagli. Utilizzare fattori uguali per preservare il rapporto d'aspetto del paragrafo; fattori orizzontali e verticali diversi allungano l'output in maniera indipendente.

Renderizzare un'intera forma con [IShape.getImage] rimane utile quando l'output deve includere il riempimento, il bordo o altro contesto visivo della forma. Per un'immagine solo del paragrafo, utilizzare [IParagraph.getImage].

## **FAQ**

**Posso disabilitare completamente l'andare a capo automatico all'interno di una cornice di testo?**

Sì. Impostare [ITextFrameFormat.setWrapText] per disabilitare l'andare a capo in modo che le linee non si interruttano ai bordi della cornice di testo.

**Come posso ottenere i limiti precisi sullo slide di un paragrafo specifico?**

Utilizzare [IParagraph.getRect] per recuperare il rettangolo di delimitazione del paragrafo. [IPortion.getRect] fornisce i limiti di una singola porzione.

**Dove è controllato l'allineamento del paragrafo (sinistra, destra, centro o giustificato)?**

[IParagraphFormat.setAlignment] è una impostazione a livello di paragrafo e si applica a tutto il paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare la lingua di correzione per una parte di un paragrafo?**

Sì. Impostare [IBasePortionFormat.setLanguageId] per le singole porzioni, così un paragrafo può contenere testo in più lingue.