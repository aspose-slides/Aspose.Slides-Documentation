---
title: Gestire i paragrafi di testo PowerPoint su Android
linktitle: Gestire Paragrafo
type: docs
weight: 40
url: /it/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
- aggiungere testo
- aggiungere paragrafo
- gestire testo
- gestire paragrafo
- gestire punto elenco
- rientro paragrafo
- rientro sospeso
- punto elenco
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
- Android
- Java
- Aspose.Slides
description: "Scopri come creare e formattare paragrafi, porzioni, punti elenco, elenchi numerati, rientri, contenuti HTML e immagini di paragrafi con Aspose.Slides per Android tramite Java."
---
## **Panoramica**

Aspose.Slides per Android tramite Java rappresenta il testo come una gerarchia di cornici di testo, paragrafi e porzioni:

* [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua raccolta di paragrafi.
* [IParagraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/) rappresenta un singolo paragrafo in una cornice di testo e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [IPortion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/) rappresenta un intervallo di testo all'interno di un paragrafo. Ogni porzione può avere la propria formattazione di carattere.

Un paragrafo può quindi contenere testo con caratteri, colori, dimensioni e altre formattazioni diverse utilizzando più porzioni.

## **Creare e Formattare i Paragrafi**

### **Creare Paragrafi con più Porzioni**

I passaggi seguenti creano una cornice di testo con tre paragrafi, ciascuno contenente tre porzioni:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedere alla diapositiva pertinente tramite il suo indice.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedere alla [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) della forma.
5. Utilizzare il paragrafo predefinito e aggiungere altri due oggetti [IParagraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/) alla cornice di testo.
6. Aggiungere sufficienti oggetti [IPortion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/) affinché ogni paragrafo contenga tre porzioni. Il paragrafo predefinito contiene già una porzione vuota.
7. Impostare il testo di ogni porzione.
8. Applicare la formattazione a livello di carattere tramite [IPortion.getPortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. Salvare la presentazione modificata.

Questo esempio Android tramite Java implementa i passaggi:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Creare Elenchi Puntati e Numerati**

### **Creare un Elenco Puntato o Numerato**

I punti elenco e la numerazione rendono gli elementi correlati più facili da leggere. In Aspose.Slides, le impostazioni dell'elenco sono definite tramite [IBulletFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibulletformat/).

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedere alla diapositiva pertinente tramite il suo indice.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva selezionata.
4. Accedere alla [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) della forma.
5. Rimuovere il paragrafo predefinito dalla cornice di testo.
6. Creare un [Paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraph/) per un punto elenco simbolico.
7. Impostare [IBulletFormat.setType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibulletformat/#setType-int-) su [BulletType.Symbol](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/bullettype/) e specificare il carattere del punto.
8. Impostare il testo del paragrafo, l'indentazione, il colore del punto e l'altezza del punto.
9. Aggiungere il paragrafo alla cornice di testo.
10. Creare un secondo paragrafo e impostare [IBulletFormat.setType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibulletformat/#setType-int-) su [BulletType.Numbered](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/bullettype/).
11. Configurare lo stile del punto numerato e aggiungere il paragrafo alla cornice di testo.
12. Salvare la presentazione.

Questo esempio Android tramite Java crea un punto simbolico e un punto numerato:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Utilizzare Punti Immagine**

I punti immagine consentono di usare un'immagine personalizzata al posto di un simbolo o di un numero.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedere alla diapositiva pertinente tramite il suo indice.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) e accedere alla sua [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/).
4. Rimuovere il paragrafo predefinito dalla cornice di testo.
5. Caricare l'immagine del punto elenco e aggiungerla alla raccolta di immagini della presentazione come [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/).
6. Creare un [Paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraph/) e impostarne il testo.
7. Impostare [IBulletFormat.setType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibulletformat/#setType-int-) su [BulletType.Picture](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/bullettype/).
8. Assegnare l'immagine tramite [IBulletFormat.getPicture](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibulletformat/#getPicture--) e impostare l'altezza del punto.
9. Aggiungere il paragrafo alla cornice di testo.
10. Salvare la presentazione modificata.

Questo esempio Android tramite Java crea un punto immagine:

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

### **Creare un Elenco Multilivello**

Impostare [IParagraphFormat.setDepth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) per posizionare i paragrafi a livelli diversi di un elenco. Il livello superiore ha una profondità di `0`.

1. Creare una [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) e accedere a una diapositiva.
2. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) e cancellare il paragrafo predefinito dalla sua cornice di testo.
3. Creare quattro paragrafi e configurare i loro simboli di punto elenco.
4. Impostare i valori di [IParagraphFormat.setDepth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) a `0`, `1`, `2` e `3`.
5. Aggiungere i paragrafi alla cornice di testo e salvare la presentazione.

Questo esempio Android tramite Java crea un elenco puntato a quattro livelli:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Avviare gli Elementi Numerati con Valori Personalizzati**

Utilizzare [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) per impostare il numero iniziale visualizzato per un paragrafo numerato.

1. Creare una [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) e aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) a una diapositiva.
2. Cancellare il paragrafo predefinito dalla cornice di testo della forma.
3. Creare tre paragrafi numerati.
4. Impostare [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) a `2`, `3` e `7` per i rispettivi paragrafi.
5. Aggiungere i paragrafi alla cornice di testo e salvare la presentazione.

Questo esempio Android tramite Java assegna un numero di partenza personalizzato a ciascun paragrafo:

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

## **Controllare il Layout del Paragrafo e le Proprietà di Fine**

### **Impostare un Rientro della Prima Riga**

Utilizzare [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) per controllare il rientro della prima riga di un paragrafo. Questo metodo sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga verso destra, mentre le righe rimanenti rimangono allineate al corpo del paragrafo.

Utilizzare [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) quando è necessario spostare l'intero paragrafo. Utilizzare [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) quando è necessario spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica valori diversi di [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) per dimostrare come il rientro della prima riga influisce sul layout del paragrafo.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedere alla diapositiva di destinazione.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedere alla [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) della forma e rimuovere il paragrafo predefinito.
5. Creare diversi paragrafi e impostare valori diversi di [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) per ciascuno.
6. Aggiungere i paragrafi alla cornice di testo.
7. Salvare la presentazione modificata.

Questo codice mostra come impostare un rientro del paragrafo:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **Impostare un Rientro Sospeso**

Un rientro sospeso è un layout di paragrafo in cui la prima riga inizia a sinistra delle righe successive. In Aspose.Slides, si crea questo effetto con [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Passare un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

Nella pratica, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) definisce la posizione sinistra del corpo del paragrafo, e [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) definisce la posizione della prima riga rispetto a quel margine. Per creare un rientro sospeso, impostare un valore positivo su `setMarginLeft` e un valore negativo su `setIndent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedere alla diapositiva di destinazione.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedere alla [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) della forma e rimuovere il paragrafo predefinito.
5. Creare paragrafi e impostare un valore positivo su [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) per ciascun paragrafo.
6. Passare un valore negativo su [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) per creare l'effetto di rientro sospeso.
7. Aggiungere i paragrafi alla cornice di testo.
8. Salvare la presentazione modificata.

Questo codice mostra come impostare un rientro sospeso per un paragrafo:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **Impostare le Proprietà di Fine Paragrafo**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) controlla la formattazione del segno di fine paragrafo. L'esempio seguente assegna una dimensione del carattere e un carattere latino al segno di fine del secondo paragrafo:

1. Caricare una [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) e accedere a una diapositiva.
2. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) e cancellare il suo paragrafo predefinito.
3. Creare due paragrafi e aggiungere porzioni di testo a ciascuno.
4. Creare una [PortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portionformat/) per il segno di fine del secondo paragrafo.
5. Impostare [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) e [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Assegnare il formato con [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) e salvare la presentazione.

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

## **Contare le Linee Renderizzate**

Utilizzare [IParagraph.getLinesCount](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) per contare le linee occupate da un paragrafo dopo il layout del testo, includendo il wrapping automatico. Questo è utile quando si verifica la lunghezza del testo e il layout nei modelli di presentazione.

Un paragrafo è un elemento in [ITextFrame.getParagraphs](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#getParagraphs--), e può occupare diverse linee renderizzate. Un'interruzione di riga esplicita all'interno di un paragrafo forza una nuova riga senza creare un nuovo paragrafo. Il wrapping automatico genera linee in base alla larghezza disponibile senza inserire interruzioni di riga esplicite nel testo. Pertanto, contare i paragrafi o i caratteri di interruzione di riga non fornisce il conteggio delle linee renderizzate.

L'esempio seguente crea una forma di testo, conta le sue linee, restringe la forma, quindi sostituisce il testo con una stringa più breve. Il wrapping è abilitato e l'autofit è disabilitato in modo che la larghezza della forma controlli il wrapping senza ridurre automaticamente il testo o ridimensionare la forma. Le dimensioni della forma sono in punti. Infine, l'esempio aggiunge un altro paragrafo e somma i conteggi delle linee all'interno della cornice di testo.

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

Con questo testo e queste dimensioni, restringere la forma aumenta il conteggio delle linee, mentre sostituire il testo con la stringa corta lo riduce. I conteggi esatti possono variare in base alla disponibilità dei caratteri e alle loro sostituzioni, alla dimensione dei caratteri, ai margini, all'indentazione, al wrapping e alle impostazioni di autofit. Utilizzare i caratteri e le impostazioni di layout previste per l'ambiente di destinazione quando si verifica un modello.

Il solo conteggio delle linee non determina se il testo supera i limiti del contenitore. Anche l'altezza disponibile, le altezze delle linee, la spaziatura dei paragrafi e delle linee e il comportamento di autofit sono importanti; anche una singola linea può superare la larghezza disponibile quando il wrapping è disabilitato.

## **Importare ed Esportare il Contenuto dei Paragrafi**

### **Importare Testo HTML nei Paragrafi**

Utilizzare [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) per convertire il markup HTML in paragrafi e porzioni all'interno di una cornice di testo.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedere a una diapositiva e aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/).
3. Accedere alla [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) della forma e cancellare il paragrafo predefinito.
4. Leggere il file HTML di origine.
5. Passare la stringa HTML a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Salvare la presentazione modificata.

Questo esempio Android tramite Java importa HTML in una cornice di testo:

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

### **Esportare il Testo del Paragrafo in HTML**

Utilizzare [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) per esportare un intervallo selezionato di paragrafi come HTML.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) e caricare la presentazione desiderata.
2. Accedere alla diapositiva e trovare la [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) che contiene il testo.
3. Accedere alla [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) della forma.
4. Chiamare [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) con l'indice del paragrafo iniziale e il numero di paragrafi da esportare.
5. Scrivere la stringa HTML restituita in un file.

Questo esempio Android tramite Java esporta tutti i paragrafi dalla prima forma di testo:

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

### **Renderizzare un Paragrafo come Immagine**

[IParagraph.getImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/#getImage--) renderizza direttamente un singolo paragrafo e restituisce un [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/). Salvare il risultato in un file o stream con [IImage.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Non è necessario renderizzare la forma contenente o ritagliare manualmente un bitmap.

[IParagraph.getImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/#getImage--) può restituire `null` se il paragrafo non viene trovato nella sua raccolta genitore, non ha limiti di rendering validi o non può essere renderizzato. Verificare il risultato prima di salvarlo e rilasciare l'immagine restituita dopo l'uso.

#### **Renderizzare un Paragrafo alla Scala Predefinita**

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, in cui la prima forma è una casella di testo contenente tre paragrafi.

![The text box with three paragraphs](paragraph_to_image_input.png)

L'esempio seguente renderizza il secondo paragrafo in una forma di testo normale alla scala predefinita e salva l'immagine restituita in formato PNG. Il blocco `finally` garantisce che l'immagine venga rilasciata correttamente.

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

![The paragraph image](paragraph_to_image_output.png)

#### **Renderizzare un Paragrafo in una Cella di Tabella con Scaling**

Utilizzare la variante di [IParagraph.getImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) che accetta i parametri `float scaleX` e `float scaleY` per impostare i fattori di scala orizzontale e verticale. L'esempio seguente crea una tabella, renderizza il paragrafo nella sua prima cella con il doppio della larghezza e dell'altezza predefinite e salva il risultato come immagine PNG.

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

Un fattore di scala di `1` mantiene quell'asse alla sua dimensione pixel predefinita. Ad esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono circa il doppio delle dimensioni predefinite, risultando in quattro volte più pixel. Fattori più grandi producono generalmente testo più nitido per lo zoom o per output ad alta risoluzione, ma aumentano anche l'uso di memoria e la dimensione del file. Fattori inferiori a `1` producono immagini più piccole con meno dettagli. Utilizzare fattori uguali per preservare le proporzioni del paragrafo; fattori orizzontali e verticali diversi allungano l'output in modo indipendente.

Renderizzare un'intera forma con [IShape.getImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getImage--) resta utile quando l'output deve includere il riempimento, il bordo o altro contesto visivo della forma. Per un'immagine solo del paragrafo, utilizzare [IParagraph.getImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Posso disabilitare completamente il wrapping delle linee all'interno di una cornice di testo?**

Sì. Impostare [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) per disabilitare il wrapping in modo che le linee non si interrompano ai bordi della cornice di testo.

**Come posso ottenere le coordinate esatte di un paragrafo specifico sulla diapositiva?**

Utilizzare [IParagraph.getRect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/#getRect--) per recuperare il rettangolo di delimitazione del paragrafo. [IPortion.getRect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/#getRect--) fornisce i limiti di una singola porzione.

**Dove è controllato l'allineamento del paragrafo (sinistra, destra, centro o giustificato)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) è un'impostazione a livello di paragrafo e si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare la lingua di correzione per una parte di un paragrafo?**

Sì. Impostare [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) per le singole porzioni, così un paragrafo può contenere testo in più lingue.