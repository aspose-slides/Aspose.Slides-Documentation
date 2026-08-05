---
title: Gestire i paragrafi di testo PowerPoint in Java
linktitle: Gestire paragrafi
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
- gestire punto elenco
- indentazione paragrafo
- indentazione sospesa
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
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Gestisci la formattazione dei paragrafi con Aspose.Slides per Java—ottimizza allineamento, spaziatura e stile nelle presentazioni PPT, PPTX e ODP in Java."
---
## **Introduzione**

Aspose.Slides fornisce tutte le interfacce e le classi di cui hai bisogno per lavorare con i testi, i paragrafi e le parti di PowerPoint in Java.

* Aspose.Slides fornisce l'interfaccia [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) per consentirti di aggiungere oggetti che rappresentano un paragrafo. Un oggetto `ITextFame` può contenere uno o più paragrafi (ogni paragrafo è creato tramite un ritorno a capo).
* Aspose.Slides fornisce l'interfaccia [IParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/) per consentirti di aggiungere oggetti che rappresentano parti. Un oggetto `IParagraph` può contenere una o più parti (collezione di oggetti iPortions).
* Aspose.Slides fornisce l'interfaccia [IPortion](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/) per consentirti di aggiungere oggetti che rappresentano testi e le loro proprietà di formattazione. 

Un oggetto `IParagraph` è in grado di gestire testi con diverse proprietà di formattazione tramite i relativi oggetti `IPortion` sottostanti.

## **Aggiungere più paragrafi contenenti più parti**

Questi passaggi mostrano come aggiungere un frame di testo contenente 3 paragrafi e ciascun paragrafo contenente 3 parti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Accedi al riferimento della slide desiderata tramite il suo indice.
3. Aggiungi un rettangolo [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla slide.
4. Ottieni l'ITextFrame associato a [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/).
5. Crea due oggetti [IParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/) e aggiungili alla collezione `IParagraphs` di [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/).
6. Crea tre oggetti [IPortion](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/) per ciascun nuovo `IParagraph` (due oggetti Portion per il paragrafo predefinito) e aggiungi ogni oggetto `IPortion` alla collezione IPortion di ciascun `IParagraph`.
7. Imposta del testo per ogni parte.
8. Applica le funzionalità di formattazione desiderate a ogni parte utilizzando le proprietà di formattazione esposte dall'oggetto `IPortion`.
9. Salva la presentazione modificata.

```java
// Istanziare una classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accesso alla prima slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiungere un AutoShape di tipo Rettangolo
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Accedere al TextFrame dell'AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Creare paragrafi e parti con diversi formati di testo
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

Le liste puntate ti aiutano a organizzare e presentare le informazioni in modo rapido ed efficiente. I paragrafi con punti elenco sono sempre più facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Accedi al riferimento della slide desiderata tramite il suo indice.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla slide selezionata.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) dell'autoshape. 
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo usando la classe [Paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraph/).
7. Imposta il `Type` del punto elenco per il paragrafo su `Symbol` e imposta il carattere del punto.
8. Imposta il `Text` del paragrafo.
9. Imposta l'`Indent` del paragrafo per il punto.
10. Imposta un colore per il punto.
11. Imposta un'altezza per il punto.
12. Aggiungi il nuovo paragrafo alla collezione di paragrafi del `TextFrame`.
13. Aggiungi il secondo paragrafo e ripeti il processo descritto nei passaggi 7‑12.
14. Salva la presentazione.

```java
// Istanzia una classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accede alla prima slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Aggiunge e accede all'Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al text frame dell'autoshape
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

    // Imposta l'indentazione del punto
    para.getParagraphFormat().setIndent(25);

    // Imposta il colore del punto
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // imposta IsBulletHardColor su true per usare un colore del punto personalizzato

    // Imposta l'altezza del punto
    para.getParagraphFormat().getBullet().setHeight(100);

    // Aggiunge il paragrafo al text frame
    txtFrm.getParagraphs().add(para);

    // Crea il secondo paragrafo
    Paragraph para2 = new Paragraph();

    // Imposta il tipo e lo stile del punto elenco del paragrafo
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Aggiunge il testo al paragrafo
    para2.setText("This is numbered bullet");

    // Imposta l'indentazione del punto
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // imposta IsBulletHardColor su true per usare un colore del punto personalizzato

    // Imposta l'altezza del punto
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Aggiunge il paragrafo al text frame
    txtFrm.getParagraphs().add(para2);
    
    // Salva la presentazione modificata
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestire i punti elenco con immagine**

Le liste puntate ti aiutano a organizzare e presentare le informazioni in modo rapido ed efficiente. I paragrafi con immagini sono facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Accedi al riferimento della slide desiderata tramite il suo indice.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla slide.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) dell'autoshape. 
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo usando la classe [Paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraph/).
7. Carica l'immagine in [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/).
8. Imposta il tipo di punto su [Picture](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/) e imposta l'immagine.
9. Imposta il `Text` del Paragraph.
10. Imposta l'`Indent` del Paragraph per il punto.
11. Imposta un colore per il punto.
12. Imposta un'altezza per il punto.
13. Aggiungi il nuovo paragrafo alla collezione di paragrafi del `TextFrame`.
14. Aggiungi il secondo paragrafo e ripeti il processo basandoti sui passaggi precedenti.
15. Salva la presentazione modificata.

```java
// Istanzia una classe Presentation che rappresenta un file PPTX
Presentation presentation = new Presentation();
try {
    // Accede alla prima slide
    ISlide slide = presentation.getSlides().get_Item(0);

    // Istanzia l'immagine per i puntini elenco
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Aggiunge e accede all'Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al textframe dell'autoshape
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

    // Aggiunge il paragrafo al text frame
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

Le liste puntate ti aiutano a organizzare e presentare le informazioni in modo rapido ed efficiente. I punti elenco a più livelli sono facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Accedi al riferimento della slide desiderata tramite il suo indice.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) nella nuova slide.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) dell'autoshape. 
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraph/) e imposta la profondità a 0.
7. Crea la seconda istanza di paragrafo tramite la classe `Paragraph` e imposta la profondità a 1.
8. Crea la terza istanza di paragrafo tramite la classe `Paragraph` e imposta la profondità a 2.
9. Crea la quarta istanza di paragrafo tramite la classe `Paragraph` e imposta la profondità a 3.
10. Aggiungi i nuovi paragrafi alla collezione di paragrafi del `TextFrame`.
11. Salva la presentazione modificata.

```java
// Instanzia una classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accede alla prima slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiunge e accede all'Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al text frame dell'autoshape creato
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

L'interfaccia [IBulletFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/) fornisce la proprietà [NumberedBulletStartWith](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) e altre che consentono di gestire paragrafi con numerazione o formattazione personalizzata. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Accedi alla slide che contiene il paragrafo.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla slide.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) dell'autoshape.
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraph/) e imposta [NumberedBulletStartWith] a 2.
7. Crea la seconda istanza di paragrafo tramite la classe `Paragraph` e imposta `NumberedBulletStartWith` a 3.
8. Crea la terza istanza di paragrafo tramite la classe `Paragraph` e imposta `NumberedBulletStartWith` a 7.
9. Aggiungi i nuovi paragrafi alla collezione di paragrafi del `TextFrame`.
10. Salva la presentazione modificata.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al text frame dell'autoshape creato
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

Usa il metodo [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setIndent-float-) per controllare l'indentazione della prima riga di un paragrafo. Questo metodo sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga a destra, mentre le righe rimanenti rimangono allineate al corpo del paragrafo.

Usa [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) quando è necessario spostare l'intero paragrafo. Usa [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setIndent-float-) quando è necessario spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica valori di indentazione differenti per dimostrare come l'indentazione della prima riga influisca sul layout del paragrafo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Accedi alla slide di destinazione.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/) rettangolare alla slide.
4. Aggiungi un [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/) vuoto alla forma e rimuovi il paragrafo predefinito.
5. Crea diversi paragrafi e imposta valori di [Indent](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setIndent-float-) differenti per ciascuno.
6. Aggiungi i paragrafi al text frame.
7. Salva la presentazione modificata.

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

![L'indentazione della prima riga dei paragrafi](first_line_indent.png)

## **Impostare l'indentazione sospesa per un paragrafo**

Una hanging indent è un layout di paragrafo in cui la prima riga inizia a sinistra delle righe successive. In Aspose.Slides, crei questo effetto con il metodo [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Imposta l'indentazione a un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) definisce la posizione sinistra del corpo del paragrafo, e [IParagraphFormat.setIndent](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setIndent-float-) definisce la posizione della prima riga rispetto a quel margine. Per creare un'indentazione sospesa, imposta un valore positivo per `MarginLeft` e un valore negativo per `Indent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Accedi alla slide di destinazione.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/) rettangolare alla slide.
4. Aggiungi un [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/) vuoto alla forma e rimuovi il paragrafo predefinito.
5. Crea paragrafi e imposta un valore positivo di [MarginLeft](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) per ciascun paragrafo.
6. Imposta un valore negativo di [Indent](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setIndent-float-) per creare l'effetto di indentazione sospesa.
7. Aggiungi i paragrafi al text frame.
8. Salva la presentazione modificata.

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

![L'indentazione sospesa dei paragrafi](hanging_indent.png)

## **Gestire le proprietà di fine paragrafo**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni il riferimento per la slide contenente il paragrafo tramite la sua posizione.
1. Aggiungi un rettangolo [autoshape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla slide.
1. Aggiungi un [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) con due paragrafi al rettangolo.
1. Imposta `FontHeight` e il tipo di Font per i paragrafi.
1. Imposta le proprietà End per i paragrafi.
1. Scrivi la presentazione modificata come file PPTX.

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

Aspose.Slides offre supporto migliorato per l'importazione di testo HTML nei paragrafi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Accedi al riferimento della slide desiderata tramite il suo indice.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla slide.
4. Aggiungi e accedi al [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) dell'`autoshape`.
5. Rimuovi il paragrafo predefinito nel `ITextFrame`.
6. Leggi il file HTML di origine con un TextReader.
7. Crea la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraph/).
8. Aggiungi il contenuto del file HTML letto dal TextReader alla [ParagraphCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraphcollection/) del TextFrame.
9. Salva la presentazione modificata.

```java
// Crea un'istanza di presentazione vuota
Presentation pres = new Presentation();
try {
    // Accedi alla prima slide predefinita della presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiungi l'AutoShape per contenere il contenuto HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Aggiungi il text frame alla forma
    ashape.addTextFrame("");

    // Cancella tutti i paragrafi nel text frame aggiunto
    ashape.getTextFrame().getParagraphs().clear();

    // Carica il file HTML usando lo stream reader
    TextReader tr = new StreamReader("file.html");

    // Aggiungi il testo dal stream reader HTML nel text frame
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Salva la presentazione
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Esportare il testo del paragrafo in HTML**

Aspose.Slides offre supporto migliorato per l'esportazione di testi (contenuti nei paragrafi) in HTML.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e carica la presentazione desiderata.
2. Accedi al riferimento della slide desiderata tramite il suo indice.
3. Accedi alla forma contenente il testo da esportare in HTML.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/) della forma.
5. Crea un'istanza di `StreamWriter` e aggiungi il nuovo file HTML.
6. Fornisci un indice iniziale a StreamWriter ed esporta i paragrafi desiderati.

```java
// Carica il file di presentazione
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Accede alla prima slide predefinita della presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Indice desiderato
    int index = 0;

    // Accesso alla forma aggiunta
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Creazione del file HTML di output
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Estrazione del primo paragrafo come HTML
    // Scrittura dei dati dei paragrafi in HTML fornendo l'indice di inizio del paragrafo, il numero totale di paragrafi da copiare
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Salvare un paragrafo come immagine**

In questa sezione, esploreremo due esempi che dimostrano come salvare un paragrafo di testo, rappresentato dall'interfaccia [IParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/), come immagine. Entrambi gli esempi includono l'ottenimento dell'immagine di una forma contenente il paragrafo usando i metodi `getImage` dell'interfaccia [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/), il calcolo dei limiti del paragrafo all'interno della forma e l'esportazione come immagine bitmap. Questi approcci consentono di estrarre parti specifiche del testo da presentazioni PowerPoint e salvarle come immagini separate, utili in diversi scenari.

Supponiamo di avere un file di presentazione chiamato sample.pptx con una slide, dove la prima forma è una casella di testo contenente tre paragrafi.

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

**Esempio 1**

In questo esempio, otteniamo il secondo paragrafo come immagine. Per farlo, estraiamo l'immagine della forma dalla prima slide della presentazione e calcoliamo i limiti del secondo paragrafo nel text frame della forma. Il paragrafo viene quindi ridisegnato su una nuova immagine bitmap, salvata in formato PNG. Questo metodo è particolarmente utile quando si desidera salvare un paragrafo specifico come immagine separata preservandone le dimensioni e la formattazione esatte.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Salva la forma in memoria come bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Crea un bitmap della forma dalla memoria.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Calcola i confini del secondo paragrafo.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // Calcola le coordinate e le dimensioni per l'immagine di output (dimensione minima - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Ritaglia il bitmap della forma per ottenere solo il bitmap del paragrafo.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

![L'immagine del paragrafo](paragraph_to_image_output.png)

**Esempio 2**

In questo esempio, estendiamo l'approccio precedente aggiungendo fattori di scala all'immagine del paragrafo. La forma viene estratta dalla presentazione e salvata come immagine con un fattore di scala pari a `2`. Questo consente un'uscita a risoluzione più alta durante l'esportazione del paragrafo. I limiti del paragrafo vengono quindi calcolati considerando la scala. La scalatura è particolarmente utile quando è necessaria un'immagine più dettagliata, ad esempio per materiale stampato di alta qualità.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Salva la forma in memoria come bitmap con scaling.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Crea un bitmap della forma dalla memoria.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Calcola i confini del secondo paragrafo.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Calcola le coordinate e le dimensioni per l'immagine di output (dimensione minima - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Ritaglia il bitmap della forma per ottenere solo il bitmap del paragrafo.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Posso disabilitare completamente l'andata a capo all'interno di un TextFrame?**

Sì. Usa l'impostazione di wrapping del TextFrame ([setWrapText](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) per disattivare l'andata a capo, in modo che le linee non vengano interrotte ai bordi del frame.

**Come posso ottenere le coordinate esatte sullo slide di un paragrafo specifico?**

Puoi recuperare il rettangolo di delimitazione del paragrafo (e anche di una singola parte) per conoscere la sua posizione e dimensione precise sullo slide.

**Dove viene controllato l'allineamento del paragrafo (sinistra/destra/centrato/giustificato)?**

[Alignment](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraphformat/#setAlignment-int-) è un'impostazione a livello di paragrafo in [ParagraphFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraphformat/); viene applicata all'intero paragrafo indipendentemente dalla formattazione delle singole parti.

**Posso impostare la lingua del controllo ortografico solo per una parte di un paragrafo (ad esempio, una parola)?**

Sì. La lingua è impostata a livello di parte ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), quindi più lingue possono coesistere all'interno di un singolo paragrafo.