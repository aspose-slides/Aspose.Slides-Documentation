---
title: Gestire elenchi puntati e numerati nelle presentazioni in Java
linktitle: Gestire gli elenchi
type: docs
weight: 60
url: /it/java/manage-lists/
keywords:
- pallino
- elenco puntato
- elenco numerato
- pallino simbolo
- pallino immagine
- pallino personalizzato
- elenco multilivello
- creare pallino
- aggiungere pallino
- aggiungere elenco
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri come creare e formattare elenchi puntati, con immagine, multilivello e numerati nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Java."
---
## **Panoramica**

Aspose.Slides per Java consente di creare e formattare elenchi puntati e numerati in presentazioni PowerPoint e OpenDocument. Un elemento di elenco è un paragrafo le cui impostazioni di elenco sono controllate tramite il formato del paragrafo.

Usa il metodo [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/#getParagraphFormat--) per accedere alle impostazioni di elenco a livello di paragrafo. Il punto di ingresso principale è [IParagraphFormat.getBullet](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#getBullet--), che restituisce un oggetto [IBulletFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/). Con questo oggetto è possibile impostare il tipo di pallino, il simbolo, l'immagine, il colore, la dimensione, lo stile di numerazione e il numero di avvio.

Questo articolo mostra come:

- creare un elenco puntato con un simbolo personalizzato
- creare un puntatore immagine
- creare un elenco multilivello impostando la profondità del paragrafo
- creare un elenco numerato
- esaminare e modificare la formattazione dell'elenco in una presentazione esistente

## **Creare un elenco puntato**

Per creare un elenco puntato, aggiungi oggetti [IParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/) a un [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) e imposta [IBulletFormat.setType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#setType-byte-) su [BulletType.Symbol](https://reference.aspose.com/slides/it/java/com.aspose.slides/bullettype/#Symbol). Puoi quindi impostare [IBulletFormat.setChar](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#getColor--) e [IBulletFormat.setHeight](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#setHeight-float-) per controllare l'aspetto del pallino.

Il seguente codice Java dimostra come creare un elenco puntato in una diapositiva:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Simboli puntati](symbol_bullets.png)

## **Creare un elenco numerato**

Usa gli elenchi numerati quando l'ordine degli elementi è importante. Imposta [IBulletFormat.setType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#setType-byte-) su [BulletType.Numbered](https://reference.aspose.com/slides/it/java/com.aspose.slides/bullettype/#Numbered). Puoi anche scegliere un formato di numerazione con [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) o impostare [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) quando l'elenco deve iniziare da un valore diverso da 1.

Il seguente codice Java mostra come creare un elenco numerato in una diapositiva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Elenchi numerati](numbered_bullets.png)

## **Creare un puntatore immagine**

Aspose.Slides consente di sostituire un normale simbolo di pallino con un'immagine. I puntatori immagine funzionano meglio con immagini semplici che rimangono leggibili a piccole dimensioni, come icone o piccoli file PNG trasparenti.

{{% alert color="info" %}}
Idealmente, se prevedi di sostituire il normale simbolo di pallino con un'immagine, è consigliabile scegliere una grafica semplice con sfondo trasparente. Questo tipo di immagini funziona bene come simboli di pallino personalizzati.

Tieni presente che l'immagine verrà ridotta a una dimensione molto piccola. Per questo motivo, raccomandiamo vivamente di selezionare un'immagine che rimanga chiara ed efficace visualmente quando viene utilizzata come pallino in un elenco.
{{% /alert %}}

Per creare un puntatore immagine, aggiungi un'immagine a [Presentation.getImages](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getImages--) e assegna l'oggetto immagine restituito a [IBulletFormat.getPicture](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#getPicture--). Imposta [IBulletFormat.setType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#setType-byte-) su [BulletType.Picture](https://reference.aspose.com/slides/it/java/com.aspose.slides/bullettype/#Picture) prima di assegnare l'immagine.

Supponiamo di avere un "image.png":

![Un'immagine per i puntatori](picture_for_bullets.png)

Il seguente codice Java mostra come creare puntatori immagine in una diapositiva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Puntatori immagine](picture_bullets.png)

## **Creare un elenco multilivello**

Usa [IParagraphFormat.setDepth](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setDepth-short-) per posizionare gli elementi dell'elenco a livelli diversi. Il livello 0 è il livello superiore, il livello 1 è annidato sotto di esso e così via.

Il seguente codice Java mostra come creare un elenco puntato multilivello:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'elenco multilivello](multilevel_list.png)

## **Modificare un elenco esistente**

Per modificare la formattazione di un elenco in una presentazione esistente, accedi al paragrafo target e aggiorna le impostazioni di [IParagraphFormat.getBullet](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#getBullet--). Le stesse proprietà utilizzate per creare gli elenchi possono essere usate per esaminare o modificare gli elenchi caricati da un file PPT, PPTX o ODP.

Il seguente codice Java modifica il primo paragrafo in un frame di testo per utilizzare uno stile di elenco numerato:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### È possibile esportare elenchi puntati e numerati in PDF o immagini?

Sì. Aspose.Slides mantiene la formattazione degli elenchi quando il formato di destinazione supporta la disposizione del testo e le funzionalità di pallino corrispondenti.

### Posso modificare gli elenchi nelle presentazioni esistenti?

Sì. Carica la presentazione, accedi al paragrafo target, esamina o aggiorna le sue impostazioni di [IParagraphFormat.getBullet](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#getBullet--), e salva la presentazione.

### Gli elenchi possono contenere testo non latino?

Sì. Il testo degli elementi di elenco può contenere caratteri Unicode, così puoi creare elenchi in presentazioni multilingue. Assicurati che i caratteri utilizzati nella presentazione supportino i caratteri di cui hai bisogno.