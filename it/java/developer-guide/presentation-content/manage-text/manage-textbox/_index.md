---
title: Gestire le caselle di testo nelle presentazioni con Java
linktitle: Gestire casella di testo
type: docs
weight: 20
url: /it/java/manage-textbox/
keywords:
- casella di testo
- riquadro di testo
- aggiungere testo
- aggiornare testo
- creare casella di testo
- verificare casella di testo
- aggiungere colonna di testo
- aggiungere collegamento ipertestuale
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Aspose.Slides for Java rende facile creare, modificare e clonare le caselle di testo nei file PowerPoint e OpenDocument, migliorando l'automazione delle presentazioni."
---
## **Introduzione**

I testi sulle diapositive sono solitamente contenuti in caselle di testo o forme. Pertanto, per aggiungere un testo a una diapositiva, è necessario aggiungere una casella di testo e poi inserire del testo all’interno della casella. Aspose.Slides for Java fornisce l’interfaccia [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAutoShape) che consente di aggiungere una forma contenente del testo.

{{% alert title="Info" color="info" %}}

Aspose.Slides fornisce anche l’interfaccia [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape) che consente di aggiungere forme alle diapositive. Tuttavia, non tutte le forme aggiunte tramite l’interfaccia `IShape` possono contenere testo. Le forme aggiunte tramite l’interfaccia [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAutoShape) possono invece contenere testo. 

{{% /alert %}}

{{% alert title="Nota" color="warning" %}} 

Pertanto, quando si lavora con una forma a cui si desidera aggiungere testo, è opportuno verificare e confermare che sia stata convertita tramite l’interfaccia `IAutoShape`. Solo così sarà possibile lavorare con [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/TextFrame), proprietà di `IAutoShape`. Vedere la sezione [Aggiornare il testo](https://docs.aspose.com/slides/it/java/manage-textbox/#update-text) su questa pagina. 

{{% /alert %}}

## **Creare una casella di testo su una diapositiva**

Per creare una casella di testo su una diapositiva, seguite questi passaggi:

1. Create un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation). 
2. Ottenete un riferimento alla prima diapositiva della presentazione appena creata. 
3. Aggiungete un oggetto [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAutoShape) con `ShapeType` impostato su `Rectangle` nella posizione desiderata sulla diapositiva e ottenete il riferimento all’oggetto `IAutoShape` appena aggiunto. 
4. Aggiungete la proprietà `TextFrame` all’oggetto `IAutoShape` che conterrà del testo. Nell’esempio seguente, abbiamo aggiunto questo testo: *Aspose TextBox*
5. Infine, salvate il file PPTX tramite l’oggetto `Presentation`. 

Questo codice Java—un’implementazione dei passaggi sopra—mostra come aggiungere testo a una diapositiva:

```java
// Instanzia la presentazione
Presentation pres = new Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiunge un AutoShape con tipo impostato su Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Aggiunge TextFrame al rettangolo
    ashp.addTextFrame(" ");

    // Accede al frame di testo
    ITextFrame txtFrame = ashp.getTextFrame();

    // Crea l'oggetto Paragraph per il frame di testo
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Crea un oggetto Portion per il paragrafo
    IPortion portion = para.getPortions().get_Item(0);

    // Imposta il testo
    portion.setText("Aspose TextBox");

    // Salva la presentazione su disco
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Verificare la presenza di una forma casella di testo**

Aspose.Slides fornisce il metodo [isTextBox](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/#isTextBox--) dell’interfaccia [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) che consente di esaminare le forme e identificare le caselle di testo.

![Text box and shape](istextbox.png)

Questo codice Java mostra come verificare se una forma è stata creata come casella di testo: 

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Nota che, se si aggiunge semplicemente un’autoshape usando il metodo `addAutoShape` dell’interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/), il metodo `isTextBox` dell’autoshape restituirà `false`. Tuttavia, dopo aver aggiunto testo all’autoshape usando il metodo `addTextFrame` o il metodo `setText`, la proprietà `isTextBox` restituirà `true`.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() restituisce false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() restituisce true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() restituisce false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() restituisce true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() restituisce false
shape3.addTextFrame("");
// shape3.isTextBox() restituisce false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() restituisce false
shape4.getTextFrame().setText("");
// shape4.isTextBox() restituisce false
```

## **Aggiungere colonne a una casella di testo**

Aspose.Slides fornisce le proprietà [ColumnCount](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) e [ColumnSpacing](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (dall’interfaccia [ITextFrameFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITextFrameFormat) e dalla classe [TextFrameFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/TextFrameFormat)) che consentono di aggiungere colonne alle caselle di testo. È possibile specificare il numero di colonne in una casella di testo e impostare la spaziatura, in punti, tra le colonne. 

Questo codice Java dimostra l’operazione descritta: 

```java
Presentation pres = new Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiunge un AutoShape con tipo impostato su Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Aggiunge TextFrame al rettangolo
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Ottiene il formato del testo del TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Specifica il numero di colonne nel TextFrame
    format.setColumnCount(3);

    // Specifica la spaziatura tra le colonne
    format.setColumnSpacing(10);

    // Salva la presentazione
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungere colonne a un Text Frame**

Aspose.Slides for Java fornisce la proprietà [ColumnCount](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (dall’interfaccia [ITextFrameFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITextFrameFormat)) che consente di aggiungere colonne nei Text Frame. Tramite questa proprietà è possibile specificare il numero desiderato di colonne in un Text Frame. 

Questo codice Java mostra come aggiungere una colonna all’interno di un Text Frame:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiornare il testo**

Aspose.Slides consente di modificare o aggiornare il testo contenuto in una casella di testo o tutti i testi contenuti in una presentazione. 

Questo codice Java dimostra un’operazione in cui tutti i testi di una presentazione vengono aggiornati o modificati:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Verifica se la forma supporta il text frame (IAutoShape).
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Itera i paragrafi nel text frame
                {
                    for (IPortion portion : paragraph.getPortions()) //Itera ogni porzione nel paragrafo
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Modifica il testo
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Modifica la formattazione
                    }
                }
            }
        }
    }

    //Salva la presentazione modificata
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungere una casella di testo con collegamento ipertestuale** 

È possibile inserire un collegamento all’interno di una casella di testo. Quando la casella di testo viene cliccata, gli utenti vengono indirizzati all’apertura del collegamento. 

Per aggiungere una casella di testo contenente un collegamento, seguite questi passaggi:

1. Create un’istanza della classe `Presentation`. 
2. Ottenete un riferimento alla prima diapositiva della presentazione appena creata. 
3. Aggiungete un oggetto `AutoShape` con `ShapeType` impostato su `Rectangle` nella posizione desiderata sulla diapositiva e ottenete il riferimento all’oggetto AutoShape appena aggiunto.
4. Aggiungete un `TextFrame` all’oggetto `AutoShape` che contiene *Aspose TextBox* come testo predefinito. 
5. Istanziate la classe `IHyperlinkManager`. 
6. Assegnate l’oggetto `IHyperlinkManager` alla proprietà [HyperlinkClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/Shape#getHyperlinkClick--) associata alla porzione desiderata del `TextFrame`. 
7. Infine, salvate il file PPTX tramite l’oggetto `Presentation`. 

Questo codice Java—un’implementazione dei passaggi sopra—mostra come aggiungere una casella di testo con collegamento ipertestuale a una diapositiva:

```java
// Instanzia una classe Presentation che rappresenta un PPTX
Presentation pres = new Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiunge un oggetto AutoShape con tipo impostato su Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Converte la forma in AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Accede alla proprietà ITextFrame associata all'AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Aggiunge del testo al frame
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Imposta l'Hyperlink per il testo della porzione
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Salva la presentazione PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Qual è la differenza tra una casella di testo e un segnaposto testo quando si lavora con le diapositive master?**

Un [segnaposto](/slides/it/java/manage-placeholder/) eredita stile/posizione dal [master](https://reference.aspose.com/slides/it/java/com.aspose.slides/masterslide/) e può essere sovrascritto nei [layout](https://reference.aspose.com/slides/it/java/com.aspose.slides/layoutslide/), mentre una casella di testo normale è un oggetto indipendente su una diapositiva specifica e non cambia quando si cambiano i layout.

**Come posso eseguire una sostituzione massiva del testo nell’intera presentazione senza modificare il testo all’interno di grafici, tabelle e SmartArt?**

Limitate l’iterazione alle autoshape che possiedono Text Frame ed escludete gli oggetti incorporati ([chart](https://reference.aspose.com/slides/it/java/com.aspose.slides/chart/), [table](https://reference.aspose.com/slides/it/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/smartart/)) attraversando le loro collezioni separatamente o saltando quei tipi di oggetti.