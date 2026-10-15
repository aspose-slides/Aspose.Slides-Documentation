---
title: Gestire i paragrafi di testo PowerPoint su Android
linktitle: Gestisci Paragrafo
type: docs
weight: 40
url: /it/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
  - aggiungi testo
  - aggiungi paragrafo
  - gestire testo
  - gestire paragrafo
  - gestire punto elenco
  - rientro paragrafo
  - rientro sospeso
  - punto elenco paragrafo
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
description: "Scopri come creare e formattare paragrafi, porzioni, punti elenco, elenchi numerati, rientri, contenuti HTML e immagini dei paragrafi con Aspose.Slides per Android tramite Java."
---
## **Panoramica**

Aspose.Slides per Android tramite Java rappresenta il testo come una gerarchia di cornici di testo, paragrafi e porzioni:

* [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua collezione di paragrafi.
* [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) rappresenta un singolo paragrafo in una cornice di testo e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) rappresenta un blocco di testo all'interno di un paragrafo. Ogni porzione può avere il proprio testo e la formattazione a livello di carattere.

Un paragrafo può quindi contenere testo con caratteri, colori, dimensioni e altre formattazioni differenti utilizzando più porzioni.

## **Creare e Formattare i Paragrafi**

Create i paragrafi nella cornice di testo di una forma e utilizza le porzioni per formattare blocchi di testo individuali. Questa sezione mostra come combinare più porzioni all'interno di ciascun paragrafo e applicare colori, dimensioni di carattere e stili diversi.

### **Creare Paragrafi con Più Porzioni**

L'esempio Android tramite Java seguente crea tre paragrafi, ciascuno contenente tre blocchi di testo nella collezione restituita da [IParagraph.getPortions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getPortions--). Riutilizza il paragrafo predefinito e la sua porzione vuota, quindi aggiunge i paragrafi e le porzioni rimanenti. La formattazione viene applicata tramite [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--): la prima porzione di ogni paragrafo è rossa, grassetto e 15 punti; la seconda è blu, corsivo e 18 punti. La terza porzione mantiene la formattazione predefinita:

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

Organizza il testo dei paragrafi in elenchi con simboli, numeri o immagini personalizzate. Gli esempi in questa sezione coprono la formattazione dei punti elenco, gli elenchi a più livelli e i numeri di partenza personalizzati.

### **Creare un Elenco Puntato o Numerato**

I punti elenco e la numerazione facilitano la lettura di elementi correlati. In Aspose.Slides, le impostazioni dell'elenco sono definite tramite [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/).

Questo esempio Android tramite Java aggiunge un punto simbolico e un elemento numerato nella stessa cornice di testo. [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) seleziona il tipo di punto, mentre [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) fornisce il simbolo e [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) seleziona lo stile di numerazione. Entrambi gli elementi usano punti neri con un'altezza del 100 percento e un rientro del paragrafo di 25 punti:

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

### **Usare Punti Elenco con Immagine**

I punti elenco con immagine consentono di utilizzare un'immagine personalizzata al posto di un simbolo o di un numero.

Questo esempio Android tramite Java aggiunge un'immagine alla collezione di immagini della presentazione come [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) e la utilizza come punto elenco per il paragrafo. Chiama [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) per usare un punto immagine e assegna l'immagine tramite [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--). [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) è impostato al 100 percento per dimensionare il punto rispetto al testo del paragrafo:

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

### **Creare un Elenco a Multilivello**

Imposta [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) per posizionare i paragrafi a livelli diversi di un elenco. Il livello superiore ha una profondità di `0`.

Questo esempio Android tramite Java assegna valori di [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) da 0 a 3 a quattro paragrafi, creando una gerarchia all'interno di una singola cornice di testo. Ogni paragrafo utilizza un punto simbolico, con [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) alternato tra un punto rotondo e un trattino per distinguere i livelli adiacenti:

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

### **Impostare Valori Personalizzati per l'Inizio della Numerazione**

Usa [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) per definire il numero iniziale visualizzato per un paragrafo numerato.

Questo esempio Android tramite Java imposta [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) per utilizzare la numerazione per tre paragrafi e assegna valori di [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) di 2, 3 e 7. Il valore di partenza è configurato separatamente per ciascun paragrafo, consentendo di saltare numeri nella visualizzazione:

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

Regola i margini e i rientri dei paragrafi per controllare la posizione della prima linea e delle linee a capo. È inoltre possibile formattare il segno di fine paragrafo separatamente dalle porzioni di testo visibili.

### **Impostare un Rientro della Prima Linea**

Utilizza il metodo [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) per controllare il rientro della prima linea di un paragrafo. Questa impostazione sposta solo la prima linea rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima linea a destra, mentre le linee rimanenti rimangono allineate al corpo del paragrafo.

Usa [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) quando devi spostare l'intero paragrafo. Usa [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) quando devi spostare solo la prima linea.

L'esempio seguente assegna a tre paragrafi lo stesso [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) di 20 punti e valori di [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) di 0, 20 e 40 punti. Le prime linee iniziano a offset progressivamente più ampi, mentre le linee a capo mantengono lo stesso margine sinistro:

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

Un rientro sospeso è un layout di paragrafo in cui la prima linea inizia a sinistra delle linee successive. In Aspose.Slides, crei questo effetto con la proprietà [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Imposta `Indent` a un valore negativo per spostare la prima linea a sinistra rispetto al corpo del paragrafo.

In pratica, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) definisce la posizione sinistra del corpo del paragrafo, e [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) definisce la posizione della prima linea rispetto a quel margine. Per creare un rientro sospeso, imposta un valore positivo di `MarginLeft` e un valore negativo di `Indent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le linee a capo devono essere allineate sotto il corpo del paragrafo anziché sotto il primo carattere della prima linea.

L'esempio Android tramite Java seguente abbina valori di [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) di 40 e 60 punti a valori di [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) di -20 e -30 punti. In ogni paragrafo, la prima linea inizia a sinistra delle linee a capo; il secondo paragrafo presenta un rientro sospeso più profondo:

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

Il metodo [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) controlla la formattazione del segno di fine paragrafo. L'esempio seguente crea un [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) con [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) impostato a 48 punti e [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) impostato a Times New Roman. Assegna questo formato al segno di fine del secondo paragrafo, lasciando inalterate le porzioni di testo visibili:

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

Per le regole dei paragrafi che influenzano l'avvolgimento automatico e la punteggiatura a fine riga, vedere [Control Line Breaking](/slides/it/androidjava/text-formatting/#control-line-breaking) e [Control Hanging Punctuation](/slides/it/androidjava/text-formatting/#control-hanging-punctuation).

Usa [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) per contare le linee occupate da un paragrafo dopo il layout del testo, includendo l'avvolgimento automatico. Questo è utile quando si verifica la lunghezza del testo e il layout nei modelli di presentazione.

Un paragrafo è un elemento di [ITextFrame.getParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParagraphs--), e può occupare diverse linee renderizzate. Un'interruzione di riga esplicita all'interno di un paragrafo forza una nuova linea senza creare un altro paragrafo. L'avvolgimento automatico crea linee basate sulla larghezza disponibile senza inserire interruzioni di riga esplicite nel testo. Quindi contare i paragrafi o i caratteri di interruzione di riga non fornisce il conteggio delle linee renderizzate.

L'esempio seguente crea una forma di testo, ne conta le linee, restringe la forma e poi sostituisce il testo con una stringa più corta. L'esempio abilita l'avvolgimento con [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) e disabilita l'autofit con [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) in modo che la larghezza della forma controlli l'avvolgimento senza ridurre automaticamente il testo o ridimensionare la forma. Ogni misurazione usa [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--). Le dimensioni della forma sono espresse in punti. Infine, l'esempio aggiunge un altro paragrafo e somma i conteggi delle linee nell'intera cornice di testo.

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

Con questo testo e queste dimensioni, restringere la forma aumenta il conteggio delle linee, mentre sostituire il testo con la stringa breve lo riduce. I conteggi esatti possono variare in base alla disponibilità e alla sostituzione dei caratteri, alla dimensione del carattere, ai margini, all'indentazione, all'avvolgimento e alle impostazioni di autofit. Usa i caratteri e le impostazioni di layout pensati per l'ambiente di destinazione quando verifichi un modello.

Il numero di linee da solo non determina se il testo supera i limiti del contenitore. Anche l'altezza disponibile, le altezze delle linee, la spaziatura dei paragrafi e delle linee e il comportamento di autofit sono importanti; anche una singola linea può eccedere la larghezza disponibile quando l'avvolgimento è disabilitato.

## **Importare ed Esportare il Contenuto dei Paragrafi**

Usa HTML per inserire testo in una presentazione o per esportare paragrafi esistenti da utilizzare all'esterno. Questa sezione mostra anche come renderizzare paragrafi individuali come immagini, inclusi paragrafi nelle celle di tabelle.

### **Importare Testo HTML nei Paragrafi**

Usa [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) per convertire il markup HTML in paragrafi e porzioni in una cornice di testo.

Questo esempio Android tramite Java legge HTML da un file e passa il markup a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-). Cancella il paragrafo predefinito della cornice di testo in modo che la cornice contenga solo il contenuto importato. La forma rettangolare lascia un margine di 10 punti su ciascun lato della diapositiva:

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

Usa [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) per esportare un intervallo selezionato di paragrafi come HTML. Quando riutilizzi il testo della presentazione su un sito web, potresti voler conservare l'enfasi locale senza trasportare lo stile di carattere, dimensione o casella di testo della presentazione. Imposta [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) per controllare fino a che punto l'esportatore segue l'ereditarietà della formattazione.

Scarica [la presentazione di esempio](text-inheritance.pptx) e posizionala nella directory di lavoro dell'applicazione. La sua prima diapositiva contiene una forma di testo con la frase "Inherited text; explicit red 18pt". L'input utilizza deliberatamente diversi livelli di formattazione:

- Lo stile di testo predefinito della presentazione fornisce Calibri a 28 pt.
- Lo stile di testo di primo livello della cornice fornisce testo blu e corsivo.
- Il paragrafo imposta esplicitamente il testo in grassetto.
- La seconda porzione, "explicit red 18pt", imposta esplicitamente il testo rosso e una dimensione di 18 pt.

L'esempio completo seguente esporta gli stessi paragrafi tre volte. Passa [TextToHtmlConversionOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/) al metodo di esportazione e scrive ogni risultato in un file HTML UTF‑8 separato:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
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

L'HTML generato contiene il seguente CSS per la prima porzione, "Inherited text; ". La tabella elenca le dichiarazioni rilevanti; altre proprietà generate sono omesse per chiarezza.

| Output | CSS rilevante per la prima porzione | Aspetto |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Testo blu, grassetto, corsivo a 28 pt in Calibri, se quel carattere è disponibile. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Testo blu, grassetto, corsivo; la pagina o il browser fornisce famiglia e dimensione del carattere. |
| `ParagraphOnly.html` | `font-weight:bold` | Testo in grassetto; la pagina o il browser fornisce famiglia, dimensione, colore e stile corsivo. |

La seconda porzione conserva `color:#ff0000`, `font-size:18pt` e `font-weight:bold` in tutti e tre gli output. Conserva anche il corsivo in `All` e `TextBox`, ma non in `ParagraphOnly`. Limitare l'ereditarietà quindi non rimuove la formattazione assegnata esplicitamente a un paragrafo o a una porzione.

Apri i file nello stesso browser per confrontarli. Nei due modi limitati, le proprietà CSS omesse sono risolte dallo stile della pagina di destinazione o dalle impostazioni predefinite del browser, quindi l'aspetto risultante dipende da dove è usato l'HTML.

### **Renderizzare un Paragrafo come Immagine**

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) renderizza direttamente un singolo paragrafo e restituisce un [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/). Salva il risultato in un file o stream con [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Non è necessario renderizzare la forma contenente o ritagliare manualmente un bitmap.

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) può restituire `null` se il paragrafo non è presente nella collezione genitore, non ha limiti di rendering validi o non può essere renderizzato. Controlla il risultato prima di salvarlo e rilascia l'immagine restituita dopo l'uso.

#### **Renderizzare un Paragrafo alla Scala Predefinita**

L'esempio utilizza una presentazione con una diapositiva la cui prima forma è una casella di testo contenente tre paragrafi.

![The text box with three paragraphs](paragraph_to_image_input.png)

L'esempio seguente seleziona il secondo paragrafo all'indice 1 e chiama [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) senza parametri di scala. Verifica che la forma contenga il paragrafo richiesto e che il rendering restituisca un'immagine prima di chiamare [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) per salvarla in formato PNG. Il blocco `finally` rilascia l'immagine dopo l'uso.

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

Usa la sovraccarico di [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) che accetta i parametri `float scaleX` e `float scaleY` per impostare i fattori di scala orizzontale e verticale. L'esempio seguente crea una tabella, renderizza il paragrafo nella sua prima cella a doppia larghezza e altezza rispetto al valore predefinito, e salva il risultato come immagine PNG.

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

Un fattore di scala pari a `1` mantiene quell'asse alla dimensione pixel predefinita. Ad esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono circa il doppio delle dimensioni predefinite, risultando in quattro volte più pixel. Fattori maggiori producono generalmente testo più nitido per zoom o output ad alta risoluzione, ma aumentano anche l'uso di memoria e le dimensioni del file. Fattori inferiori a `1` generano immagini più piccole con meno dettagli. Usa fattori uguali per preservare il rapporto d'aspetto del paragrafo; fattori orizzontali e verticali diversi allungano l'output in modo indipendente.

Renderizzare un'intera forma con [IShape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getImage--) rimane utile quando l'output deve includere il riempimento, il bordo o altri contesti visivi della forma. Per un'immagine contenente solo il paragrafo, usa [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Posso disabilitare completamente l'avvolgimento delle linee all'interno di una cornice di testo?**

Sì. Imposta [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) per disabilitare l'avvolgimento in modo che le linee non vengano interrotte ai bordi della cornice di testo.

**Come posso ottenere i limiti esatti sullo slide di un paragrafo specifico?**

Usa [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getRect--) per recuperare il rettangolo di delimitazione del paragrafo. [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getRect--) fornisce i limiti di una singola porzione.

**Dove è controllato l'allineamento del paragrafo (sinistra, destra, centro o giustificato)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) è un'impostazione a livello di paragrafo e si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

Per allineare verticalmente porzioni di dimensioni di carattere diverse all'interno di ogni linea, vedi [Align Fonts Within a Line](/slides/it/androidjava/text-formatting/#align-fonts-within-a-line).

**Posso impostare la lingua di correzione per una parte di un paragrafo?**

Sì. Imposta [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) per le singole porzioni, così un paragrafo può contenere testo in più lingue.