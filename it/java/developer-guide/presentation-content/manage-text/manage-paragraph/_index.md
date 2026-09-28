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
- aggiungi testo
- aggiungi paragrafo
- gestisci testo
- gestisci paragrafo
- gestisci punto elenco
- rientro paragrafo
- rientro sporgente
- punto elenco
- elenco numerato
- elenco puntato
- proprietà paragrafo
- importa HTML
- testo in HTML
- paragrafo in HTML
- paragrafo in immagine
- testo in immagine
- esporta paragrafo
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Impara come creare e formattare paragrafi, porzioni, punti elenco, elenchi numerati, rientri, contenuto HTML e immagini dei paragrafi con Aspose.Slides per Java."
---
## **Panoramica**

Aspose.Slides for Java rappresenta il testo come una gerarchia di riquadri di testo, paragrafi e porzioni:

* [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua collezione di paragrafi.
* [IParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/) rappresenta un paragrafo in un riquadro di testo e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [IPortion](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/) rappresenta un run di testo all'interno di un paragrafo. Ogni porzione può avere il proprio testo e la formattazione a livello di carattere.

Un paragrafo può quindi contenere testo con diversi caratteri, colori, dimensioni e altra formattazione usando più porzioni.

## **Crea e formatta i paragrafi**

### **Crea paragrafi con più porzioni**

I seguenti passaggi creano un riquadro di testo con tre paragrafi, ciascuno contenente tre porzioni:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Accedi alla diapositiva pertinente tramite il suo indice.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) della forma.
5. Usa il paragrafo predefinito e aggiungi altri due oggetti [IParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/) al riquadro di testo.
6. Aggiungi un numero sufficiente di oggetti [IPortion](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/) per ciascun paragrafo affinché contenga tre porzioni. Il paragrafo predefinito contiene già una porzione vuota.
7. Imposta il testo di ogni porzione.
8. Applica la formattazione a livello di carattere tramite [IPortion.getPortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/#getPortionFormat--).
9. Salva la presentazione modificata.

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

## **Crea elenchi puntati e numerati**

### **Crea un elenco puntato o numerato**

I punti elenco e la numerazione rendono gli elementi correlati più facili da leggere. In Aspose.Slides, le impostazioni dell'elenco sono definite tramite [IBulletFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/).

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Accedi alla diapositiva pertinente tramite il suo indice.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla diapositiva selezionata.
4. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) della forma.
5. Rimuovi il paragrafo predefinito dal riquadro di testo.
6. Crea un [Paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraph/) per un punto simbolo.
7. Imposta [IBulletFormat.setType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#setType-int-) su [BulletType.Symbol](https://reference.aspose.com/slides/it/java/com.aspose.slides/bullettype/) e specifica il carattere del punto.
8. Imposta il testo del paragrafo, il rientro, il colore del punto e l'altezza del punto.
9. Aggiungi il paragrafo al riquadro di testo.
10. Crea un secondo paragrafo e imposta [IBulletFormat.setType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#setType-int-) su [BulletType.Numbered](https://reference.aspose.com/slides/it/java/com.aspose.slides/bullettype/).
11. Configura lo stile del punto numerato e aggiungi il paragrafo al riquadro di testo.
12. Salva la presentazione.

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

### **Usa punti immagine**

I punti immagine consentono di utilizzare un'immagine personalizzata al posto di un simbolo o di un numero.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Accedi alla diapositiva pertinente tramite il suo indice.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) e accedi al suo [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/).
4. Rimuovi il paragrafo predefinito dal riquadro di testo.
5. Carica l'immagine del punto e aggiungila alla collezione di immagini della presentazione come [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/).
6. Crea un [Paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraph/) e imposta il suo testo.
7. Imposta [IBulletFormat.setType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#setType-int-) su [BulletType.Picture](https://reference.aspose.com/slides/it/java/com.aspose.slides/bullettype/).
8. Assegna l'immagine tramite [IBulletFormat.getPicture](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#getPicture--) e imposta l'altezza del punto.
9. Aggiungi il paragrafo al riquadro di testo.
10. Salva la presentazione modificata.

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

### **Crea un elenco a più livelli**

Imposta [IParagraphFormat.setDepth](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setDepth-short-) per posizionare i paragrafi a diversi livelli di un elenco. Il livello più alto ha una profondità di `0`.

1. Crea una [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e accedi a una diapositiva.
2. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) e rimuovi il paragrafo predefinito dal suo riquadro di testo.
3. Crea quattro paragrafi e configura i loro simboli di punto.
4. Imposta i loro valori [IParagraphFormat.setDepth](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setDepth-short-) su `0`, `1`, `2` e `3`.
5. Aggiungi i paragrafi al riquadro di testo e salva la presentazione.

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

### **Inizia gli elementi di un elenco numerato con valori personalizzati**

Usa [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) per impostare il numero iniziale visualizzato per un paragrafo numerato.

1. Crea una [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) a una diapositiva.
2. Rimuovi il paragrafo predefinito dal riquadro di testo della forma.
3. Crea tre paragrafi numerati.
4. Imposta [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) su `2`, `3` e `7` per i rispettivi paragrafi.
5. Aggiungi i paragrafi al riquadro di testo e salva la presentazione.

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

## **Controllo del layout del paragrafo e delle proprietà di fine**

### **Imposta un rientro della prima riga**

Usa [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setIndent-float-) per controllare il rientro della prima riga di un paragrafo. Questo metodo sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga a destra, mentre le righe rimanenti rimangono allineate al corpo del paragrafo.

Usa [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) quando devi spostare l'intero paragrafo. Usa [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setIndent-float-) quando devi spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica diversi valori di [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setIndent-float-) per dimostrare come il rientro della prima riga influisce sul layout del paragrafo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Accedi alla diapositiva target.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) della forma e rimuovi il paragrafo predefinito.
5. Crea diversi paragrafi e imposta valori diversi di [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setIndent-float-) per ciascuno.
6. Aggiungi i paragrafi al riquadro di testo.
7. Salva la presentazione modificata.

Questo codice mostra come impostare un rientro del paragrafo:

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

### **Imposta un rientro sporgente**

Un rientro sporgente è un layout di paragrafo in cui la prima riga inizia a sinistra rispetto alle righe rimanenti. In Aspose.Slides, crei questo effetto con [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Passa un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) definisce la posizione sinistra del corpo del paragrafo, e [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setIndent-float-) definisce la posizione della prima riga rispetto a quel margine. Per creare un rientro sporgente, passa un valore positivo a `setMarginLeft` e un valore negativo a `setIndent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Accedi alla diapositiva target.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) della forma e rimuovi il paragrafo predefinito.
5. Crea paragrafi e passa un valore positivo a [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) per ciascun paragrafo.
6. Passa un valore negativo a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setIndent-float-) per creare l'effetto di rientro sporgente.
7. Aggiungi i paragrafi al riquadro di testo.
8. Salva la presentazione modificata.

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

### **Imposta le proprietà di esecuzione alla fine del paragrafo**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) controlla la formattazione del segno di fine paragrafo. Il seguente esempio assegna una dimensione del carattere e un font latino al segno di fine del secondo paragrafo:

1. Carica una [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e accedi a una diapositiva.
2. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) e cancella il suo paragrafo predefinito.
3. Crea due paragrafi e aggiungi porzioni di testo a ciascuno.
4. Crea un [PortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/portionformat/) per il segno di fine del secondo paragrafo.
5. Imposta [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) e [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Assegna il formato con [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) e salva la presentazione.

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

## **Conta le linee renderizzate**

Per le regole di paragrafo che influenzano l'avvolgimento automatico e la punteggiatura alla fine delle righe, vedere [Controllo dell'interruzione di riga](/slides/it/java/text-formatting/#control-line-breaking) e [Controllo della punteggiatura sospesa](/slides/it/java/text-formatting/#control-hanging-punctuation).

Usa [IParagraph.getLinesCount](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/#getLinesCount--) per contare le righe occupate da un paragrafo dopo il layout del testo, includendo l'avvolgimento automatico. Questo è utile quando si verifica la lunghezza del testo e il layout nei modelli di presentazione.

Un paragrafo è un elemento in [ITextFrame.getParagraphs](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#getParagraphs--) e può occupare diverse righe renderizzate. Un'interruzione di linea esplicita all'interno di un paragrafo forza una nuova riga senza creare un altro paragrafo. L'avvolgimento automatico crea righe in base alla larghezza disponibile senza inserire interruzioni di linea esplicite nel testo. Pertanto, contare i paragrafi o i caratteri di interruzione di riga non fornisce il conteggio delle righe renderizzate.

Il seguente esempio crea una forma di testo, ne conta le righe, restringe la forma e poi sostituisce il testo con una stringa più corta. L'avvolgimento è abilitato e l'autoadattamento è disabilitato in modo che la larghezza della forma controlli l'avvolgimento senza ridurre automaticamente il testo o ridimensionare la forma. Le dimensioni della forma sono in punti. Infine, l'esempio aggiunge un altro paragrafo e somma i conteggi delle righe nell'intero riquadro di testo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Con questo testo e queste dimensioni, restringere la forma aumenta il conteggio delle righe, mentre sostituire il testo con la stringa corta lo riduce. I conteggi esatti possono variare in base alla disponibilità e sostituzione dei font, alla dimensione del carattere, ai margini, all'indentazione, all'avvolgimento e alle impostazioni di autoadattamento. Usa i font e le impostazioni di layout previste per l'ambiente di destinazione quando verifichi un modello.

Il solo conteggio delle righe non determina se il testo supera il contenitore. Anche l'altezza disponibile, l'altezza delle linee, la spaziatura del paragrafo e delle linee e il comportamento di autoadattamento sono importanti; anche una singola riga può superare la larghezza disponibile quando l'avvolgimento è disabilitato.

## **Importa ed esporta il contenuto del paragrafo**

### **Importa testo HTML nei paragrafi**

Usa [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) per convertire il markup HTML in paragrafi e porzioni in un riquadro di testo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Accedi a una diapositiva e aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/).
3. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) della forma e rimuovi il suo paragrafo predefinito.
4. Leggi il file HTML sorgente.
5. Passa la stringa HTML a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Salva la presentazione modificata.

Questo esempio Java importa HTML in un riquadro di testo:

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

### **Esporta il testo del paragrafo in HTML**

Usa [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) per esportare un intervallo selezionato di paragrafi come HTML.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e carica la presentazione desiderata.
2. Accedi alla diapositiva e trova la [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) che contiene il testo.
3. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) della forma.
4. Chiama [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) con l'indice del paragrafo iniziale e il numero di paragrafi da esportare.
5. Scrivi la stringa HTML restituita in un file.

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

### **Renderizza un paragrafo come immagine**

[IParagraph.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/#getImage--) renderizza direttamente un singolo paragrafo e restituisce un [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/). Salva il risultato in un file o stream con [IImage.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Non è necessario renderizzare la forma contenente o ritagliare manualmente una bitmap.

[IParagraph.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/#getImage--) può restituire `null` se il paragrafo non può essere trovato nella sua collezione genitore, non ha limiti di rendering validi, o non può essere renderizzato. Controlla il risultato prima di salvarlo e rilascia l'immagine restituita dopo l'uso.

#### **Renderizza un paragrafo alla scala predefinita**

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, dove la prima forma è una casella di testo contenente tre paragrafi.

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

Il seguente esempio renderizza il secondo paragrafo in una forma di testo regolare alla scala predefinita e salva l'immagine restituita in formato PNG. Il blocco `finally` garantisce che l'immagine venga rilasciata correttamente.

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

#### **Renderizza un paragrafo in una cella di tabella con scala**

Usa la sovraccarico di [IParagraph.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/#getImage-float-float-) che accetta i parametri `float scaleX` e `float scaleY` per impostare i fattori di scala orizzontale e verticale. Il seguente esempio crea una tabella, renderizza il paragrafo nella sua prima cella a una larghezza e altezza doppie rispetto al valore predefinito, e salva il risultato come immagine PNG.

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

Un fattore di scala di `1` mantiene quell'asse alla sua dimensione pixel predefinita. Per esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono circa il doppio delle dimensioni predefinite, risultando in quattro volte più pixel. Fattori più grandi producono generalmente testo più nitido per lo zoom o uscite ad alta risoluzione, ma aumentano anche l'uso di memoria e le dimensioni del file. Fattori inferiori a `1` producono immagini più piccole con meno dettaglio. Usa fattori uguali per preservare il rapporto d'aspetto del paragrafo; fattori orizzontali e verticali diversi allungano l'output indipendentemente.

Renderizzare un'intera forma con [IShape.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getImage--) è ancora utile quando l'output deve includere il riempimento, il bordo o altro contesto visivo della forma. Per un'immagine solo del paragrafo, usa [IParagraph.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Posso disabilitare completamente l'interruzione di riga all'interno di un riquadro di testo?**

Sì. Imposta [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) per disabilitare l'avvolgimento in modo che le righe non si interrompano ai bordi del riquadro di testo.

**Come posso ottenere i limiti esatti sullo slide di un paragrafo specifico?**

Usa [IParagraph.getRect](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/#getRect--) per recuperare il rettangolo di delimitazione del paragrafo. [IPortion.getRect](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/#getRect--) fornisce i limiti di una singola porzione.

**Dove è controllato l'allineamento del paragrafo (sinistra, destra, centro o giustificato)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) è un'impostazione a livello di paragrafo e si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare la lingua di correzione per parte di un paragrafo?**

Sì. Imposta [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) per le singole porzioni, così un paragrafo può contenere testo in più lingue.