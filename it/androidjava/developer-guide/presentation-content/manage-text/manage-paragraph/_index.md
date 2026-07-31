---
title: Gestire i paragrafi di testo PowerPoint su Android
linktitle: Gestire paragrafo
type: docs
weight: 40
url: /it/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
keywords:
- aggiungere testo
- aggiungere paragrafo
- gestire testo
- gestire paragrafo
- gestire punto elenco
- rientro del paragrafo
- rientro sospeso
- punto elenco del paragrafo
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
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Domina la formattazione dei paragrafi con Aspose.Slides per Android—ottimizza allineamento, spaziatura e stile nelle presentazioni PPT, PPTX e ODP in Java."
---
## **Introduzione**

Aspose.Slides fornisce tutte le interfacce e le classi necessarie per lavorare con i testi, i paragrafi e le porzioni di PowerPoint in Java.

* Aspose.Slides fornisce l'interfaccia [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) per consentire l'aggiunta di oggetti che rappresentano un paragrafo. Un oggetto `ITextFame` può contenere uno o più paragrafi (ogni paragrafo viene creato tramite un ritorno a capo).
* Aspose.Slides fornisce l'interfaccia [IParagraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/) per consentire l'aggiunta di oggetti che rappresentano porzioni. Un oggetto `IParagraph` può contenere una o più porzioni (collezione di oggetti iPortions).
* Aspose.Slides fornisce l'interfaccia [IPortion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/) per consentire l'aggiunta di oggetti che rappresentano testi e le loro proprietà di formattazione.

Un oggetto `IParagraph` è in grado di gestire testi con diverse proprietà di formattazione tramite i relativi oggetti `IPortion`.

## **Aggiungere più paragrafi contenenti più porzioni di testo**

Questi passaggi mostrano come aggiungere un riquadro di testo contenente 3 paragrafi, ognuno dei quali contenente 3 porzioni:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedere al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungere un rettangolo [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
4. Ottenere l'ITextFrame associato al [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/).
5. Creare due oggetti [IParagraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/) e aggiungerli alla collezione `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/).
6. Creare tre oggetti [IPortion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/) per ogni nuovo `IParagraph` (due oggetti Portion per il paragrafo predefinito) e aggiungere ciascun oggetto `IPortion` alla collezione IPortion di ogni `IParagraph`.
7. Impostare del testo per ciascuna porzione.
8. Applicare le funzionalità di formattazione desiderate a ciascuna porzione usando le proprietà di formattazione esposte dall'oggetto `IPortion`.
9. Salvare la presentazione modificata.

Questo codice Java è un'implementazione dei passaggi per aggiungere paragrafi contenenti porzioni:

```java
// Istanziare una classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accesso alla prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiungere un AutoShape di tipo Rettangolo
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Accedere al TextFrame dell'AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Creare paragrafi e porzioni con formati di testo diversi
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    // Scrivere il PPTX su disco
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestire i punti elenco dei paragrafi**

Le liste con punti elenco aiutano a organizzare e presentare le informazioni rapidamente ed efficientemente. I paragrafi puntati sono sempre più facili da leggere e comprendere.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedere al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungere una [autoshape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva selezionata.
4. Accedere al [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) dell'autoshape.
5. Rimuovere il paragrafo predefinito nel `TextFrame`.
6. Creare la prima istanza di paragrafo usando la classe [Paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraph/).
7. Impostare il `Type` del punto elenco per il paragrafo su `Symbol` e impostare il carattere del punto elenco.
8. Impostare il `Text` del paragrafo.
9. Impostare l'`Indent` del paragrafo per il punto elenco.
10. Impostare un colore per il punto elenco.
11. Impostare un'altezza per il punto elenco.
12. Aggiungere il nuovo paragrafo alla collezione di paragrafi del `TextFrame`.
13. Aggiungere il secondo paragrafo e ripetere il processo indicato nei passaggi da 7 a 13.
14. Salvare la presentazione.

```java
// Istanzia una classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accede alla prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Aggiunge e accede all'Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al riquadro di testo dell'autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Rimuove il paragrafo predefinito
    txtFrm.getParagraphs().removeAt(0);

    // Crea un paragrafo
    Paragraph para = new Paragraph();

    // Imposta lo stile del punto elenco del paragrafo e il simbolo
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Imposta il testo del paragrafo
    para.setText("Welcome to Aspose.Slides");

    // Imposta l'indentazione del punto elenco
    para.getParagraphFormat().setIndent(25);

    // Imposta il colore del punto elenco
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // imposta IsBulletHardColor a true per usare il proprio colore del punto elenco

    // Imposta l'altezza del punto elenco
    para.getParagraphFormat().getBullet().setHeight(100);

    // Aggiunge il paragrafo al riquadro di testo
    txtFrm.getParagraphs().add(para);

    // Crea il secondo paragrafo
    Paragraph para2 = new Paragraph();

    // Imposta il tipo e lo stile del punto elenco del paragrafo
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Aggiunge il testo del paragrafo
    para2.setText("This is numbered bullet");

    // Imposta l'indentazione del punto elenco
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // imposta IsBulletHardColor a true per usare il proprio colore del punto elenco

    // Imposta l'altezza del punto elenco
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Aggiunge il paragrafo al riquadro di testo
    txtFrm.getParagraphs().add(para2);
    
    // Salva la presentazione modificata
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestire i punti elenco con immagine**

Le liste con punti elenco aiutano a organizzare e presentare le informazioni rapidamente ed efficientemente. I paragrafi con immagine sono facili da leggere e comprendere.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedere al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungere una [autoshape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
4. Accedere al [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) dell'autoshape.
5. Rimuovere il paragrafo predefinito nel `TextFrame`.
6. Creare la prima istanza di paragrafo usando la classe [Paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraph/).
7. Caricare l'immagine in [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/).
8. Impostare il tipo di punto elenco su [Picture](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/) e impostare l'immagine.
9. Impostare il `Text` del paragrafo.
10. Impostare l'`Indent` del paragrafo per il punto elenco.
11. Impostare un colore per il punto elenco.
12. Impostare un'altezza per il punto elenco.
13. Aggiungere il nuovo paragrafo alla collezione di paragrafi del `TextFrame`.
14. Aggiungere il secondo paragrafo e ripetere il processo basato sui passaggi precedenti.
15. Salvare la presentazione modificata.

```java
// Istanzia una classe Presentation che rappresenta un file PPTX
Presentation presentation = new Presentation();
try {
    // Accede alla prima diapositiva
    ISlide slide = presentation.getSlides().get_Item(0);

    // Istanzia l'immagine per i punti elenco
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Aggiunge e accede all'Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al TextFrame dell'autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Rimuove il paragrafo predefinito
    textFrame.getParagraphs().removeAt(0);

    // Crea un nuovo paragrafo
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Imposta lo stile del punto elenco del paragrafo e l'immagine
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Imposta l'altezza del punto elenco
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Aggiunge il paragrafo al TextFrame
    textFrame.getParagraphs().add(paragraph);

    // Scrive la presentazione come file PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Scrive la presentazione come file PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Gestire i punti elenco a più livelli**

Le liste con punti elenco aiutano a organizzare e presentare le informazioni rapidamente ed efficientemente. I punti elenco a più livelli sono facili da leggere e comprendere.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedere al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungere una [autoshape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) nella nuova diapositiva.
4. Accedere al [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) dell'autoshape.
5. Rimuovere il paragrafo predefinito nel `TextFrame`.
6. Creare la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraph/) e impostare la profondità a 0.
7. Creare la seconda istanza di paragrafo tramite la classe `Paragraph` e impostare la profondità a 1.
8. Creare la terza istanza di paragrafo tramite la classe `Paragraph` e impostare la profondità a 2.
9. Creare la quarta istanza di paragrafo tramite la classe `Paragraph` e impostare la profondità a 3.
10. Aggiungere i nuovi paragrafi alla collezione di paragrafi del `TextFrame`.
11. Salvare la presentazione modificata.

```java
// Istanzia una classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accede alla prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiunge e accede all'Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al riquadro di testo dell'autoshape creato
    ITextFrame text = aShp.addTextFrame("");

    // Cancella il paragrafo predefinito
    text.getParagraphs().clear();

    // Aggiunge il primo paragrafo
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Imposta il livello del punto elenco
    para1.getParagraphFormat().setDepth((short)0);

    // Aggiunge il secondo paragrafo
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Imposta il livello del punto elenco
    para2.getParagraphFormat().setDepth((short)1);

    // Aggiunge il terzo paragrafo
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Imposta il livello del punto elenco
    para3.getParagraphFormat().setDepth((short)2);

    // Aggiunge il quarto paragrafo
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Imposta il livello del punto elenco
    para4.getParagraphFormat().setDepth((short)3);

    // Aggiunge i paragrafi alla collezione
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Scrive la presentazione come file PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestire un paragrafo con un elenco numerato personalizzato**

L'interfaccia [IBulletFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibulletformat/) fornisce la proprietà [NumberedBulletStartWith](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) e altre che consentono di gestire paragrafi con numerazione o formattazione personalizzata.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedere alla diapositiva contenente il paragrafo.
3. Aggiungere una [autoshape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
4. Accedere al [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) dell'autoshape.
5. Rimuovere il paragrafo predefinito nel `TextFrame`.
6. Creare la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraph/) e impostare [NumberedBulletStartWith](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) a 2.
7. Creare la seconda istanza di paragrafo tramite la classe `Paragraph` e impostare `NumberedBulletStartWith` a 3.
8. Creare la terza istanza di paragrafo tramite la classe `Paragraph` e impostare `NumberedBulletStartWith` a 7.
9. Aggiungere i nuovi paragrafi alla collezione di paragrafi del `TextFrame`.
10. Salvare la presentazione modificata.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al riquadro di testo dell'autoshape creata
    ITextFrame textFrame = shape.getTextFrame();

    // Rimuove il paragrafo predefinito esistente
    textFrame.getParagraphs().removeAt(0);

    // Prima lista
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Impostare l'indentazione della prima riga per un paragrafo**

Utilizzare il metodo [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) per controllare l'indentazione della prima riga di un paragrafo. Questo metodo sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga a destra, mentre le righe rimanenti rimangono allineate al corpo del paragrafo.

Usare [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) quando è necessario spostare l'intero paragrafo. Usare [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) quando è necessario spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica valori di indentazione differenti per dimostrare come l'indentazione della prima riga influisce sul layout del paragrafo.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedere alla diapositiva di destinazione.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Aggiungere un [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframe/) vuoto alla forma e rimuovere il paragrafo predefinito.
5. Creare diversi paragrafi e impostare valori di [Indent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) diversi per ciascuno.
6. Aggiungere i paragrafi al riquadro di testo.
7. Salvare la presentazione modificata.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Il risultato:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Impostare l'indentazione sospesa per un paragrafo**

Un'indentazione sospesa è un layout di paragrafo in cui la prima riga inizia a sinistra delle righe successive. In Aspose.Slides, questo effetto si ottiene con il metodo [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Impostare l'indentazione a un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) definisce la posizione sinistra del corpo del paragrafo, e [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) definisce la posizione della prima riga rispetto a quel margine. Per creare un'indentazione sospesa, impostare un valore positivo per `MarginLeft` e un valore negativo per `Indent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe avvolte devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedere alla diapositiva di destinazione.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Aggiungere un [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframe/) vuoto alla forma e rimuovere il paragrafo predefinito.
5. Creare paragrafi e impostare un valore positivo di [MarginLeft](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) per ciascun paragrafo.
6. Impostare un valore negativo di [Indent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) per creare l'effetto di indentazione sospesa.
7. Aggiungere i paragrafi al riquadro di testo.
8. Salvare la presentazione modificata.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Il risultato:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Gestire le proprietà End del paragrafo**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere il riferimento per la diapositiva contenente il paragrafo tramite la sua posizione.
1. Aggiungere un rettangolo [autoshape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Aggiungere un [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) con due paragrafi al rettangolo.
1. Impostare `FontHeight` e il tipo di carattere per i paragrafi.
1. Impostare le proprietà End per i paragrafi.
1. Scrivere la presentazione modificata come file PPTX.

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Importare testo HTML nei paragrafi**

Aspose.Slides fornisce un supporto avanzato per l'importazione di testo HTML nei paragrafi.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedere al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungere una [autoshape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
4. Aggiungere e accedere al [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) dell'autoshape.
5. Rimuovere il paragrafo predefinito nel `ITextFrame`.
6. Leggere il file HTML di origine in un TextReader.
7. Creare la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraph/).
8. Aggiungere il contenuto del file HTML letto dal TextReader alla [ParagraphCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraphcollection/) del TextFrame.
9. Salvare la presentazione modificata.

```java
// Crea un'istanza vuota di presentazione
Presentation pres = new Presentation();
try {
    // Accedi alla diapositiva predefinita iniziale della presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiunge l'AutoShape per contenere il contenuto HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Aggiunge il riquadro di testo alla forma
    ashape.addTextFrame("");

    // Cancella tutti i paragrafi nel riquadro di testo aggiunto
    ashape.getTextFrame().getParagraphs().clear();

    // Carica il file HTML usando lo stream reader
    TextReader tr = new StreamReader("file.html");

    // Aggiunge il testo dallo stream reader HTML nel riquadro di testo
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Salva la presentazione
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Esportare il testo del paragrafo in HTML**

Aspose.Slides fornisce un supporto avanzato per l'esportazione di testi (contenuti nei paragrafi) in HTML.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) e caricare la presentazione desiderata.
2. Accedere al riferimento della diapositiva pertinente tramite il suo indice.
3. Accedere alla forma contenente il testo da esportare in HTML.
4. Accedere al [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframe/) della forma.
5. Creare un'istanza di `StreamWriter` e aggiungere il nuovo file HTML.
6. Fornire un indice di partenza a StreamWriter ed esportare i paragrafi desiderati.

```java
// Carica il file di presentazione
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Accedi alla diapositiva predefinita iniziale della presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Indice desiderato
    int index = 0;

    // Accesso alla forma aggiunta
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Creazione del file HTML di output
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Estrazione del primo paragrafo come HTML
    // Scrittura dei dati dei paragrafi in HTML fornendo l'indice di avvio del paragrafo, il numero totale di paragrafi da copiare
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Salvare un paragrafo come immagine**

In questa sezione, esploreremo due esempi che dimostrano come salvare un paragrafo di testo, rappresentato dall'interfaccia [IParagraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/), come immagine. Entrambi gli esempi includono l'ottenimento dell'immagine di una forma contenente il paragrafo tramite i metodi `getImage` dell'interfaccia [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/), il calcolo dei limiti del paragrafo all'interno della forma e l'esportazione come immagine bitmap. Questi approcci consentono di estrarre parti specifiche del testo da presentazioni PowerPoint e salvarle come immagini separate, utili in vari scenari.

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, in cui la prima forma è una casella di testo contenente tre paragrafi.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Esempio 1**

In questo esempio, otteniamo il secondo paragrafo come immagine. Per farlo, estraiamo l'immagine della forma dalla prima diapositiva della presentazione e quindi calcoliamo i limiti del secondo paragrafo nel riquadro di testo della forma. Il paragrafo viene quindi ridisegnato su una nuova immagine bitmap, che viene salvata in formato PNG. Questo metodo è particolarmente utile quando si deve salvare un paragrafo specifico come immagine separata mantenendo esattamente le dimensioni e la formattazione del testo.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Salva la forma in memoria come bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Crea una bitmap della forma dalla memoria.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Calcola i confini del secondo paragrafo.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // Calcola le coordinate e le dimensioni per l'immagine di output (dimensione minima - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Ritaglia la bitmap della forma per ottenere solo la bitmap del paragrafo.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Il risultato:

![The paragraph image](paragraph_to_image_output.png)

**Esempio 2**

In questo esempio, estendiamo l'approccio precedente aggiungendo fattori di scala all'immagine del paragrafo. La forma viene estratta dalla presentazione e salvata come immagine con un fattore di scala di `2`. Ciò consente di ottenere un'output a risoluzione più alta durante l'esportazione del paragrafo. I limiti del paragrafo sono poi calcolati tenendo conto della scala. La scalatura può risultare particolarmente utile quando è necessaria un'immagine più dettagliata, ad esempio per materiale stampato di alta qualità.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Salva la forma in memoria come bitmap con scalatura.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Crea una bitmap della forma dalla memoria.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Calcola i confini del secondo paragrafo.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // Calcola le coordinate e le dimensioni per l'immagine di output (dimensione minima - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Ritaglia la bitmap della forma per ottenere solo la bitmap del paragrafo.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Posso disabilitare completamente l'andare a capo automatico all'interno di un TextFrame?**

Sì. Utilizzare l'impostazione di wrapping del TextFrame ([setWrapText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) per disattivare il wrapping così le righe non verranno interrotte ai bordi del frame.

**Come posso ottenere i limiti esatti sullo slide di un paragrafo specifico?**

È possibile recuperare il rettangolo di delimitazione del paragrafo (e anche di una singola porzione) per conoscere la sua posizione e dimensione precise sulla diapositiva.

**Dove è controllato l'allineamento del paragrafo (sinistra/destra/centro/giustifica)?**

[Alignment](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) è un'impostazione a livello di paragrafo in [ParagraphFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraphformat/); si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare una lingua per il controllo ortografico solo per parte di un paragrafo (ad esempio, una parola)?**

Sì. La lingua si imposta a livello di porzione ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), quindi più lingue possono coesistere all'interno di un unico paragrafo.