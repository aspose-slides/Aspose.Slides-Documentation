---
title: Gestire le caselle di testo nelle presentazioni su Android
linktitle: Gestire casella di testo
type: docs
weight: 20
url: /it/androidjava/manage-textbox/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides per Android via Java semplifica la creazione, la modifica e la clonazione di caselle di testo in file PowerPoint e OpenDocument, migliorando l'automazione delle tue presentazioni."
---
## **Introduzione**

I testi nelle diapositive sono tipicamente presenti in caselle di testo o forme. Pertanto, per aggiungere del testo a una diapositiva, è necessario aggiungere una casella di testo e poi inserire del testo all’interno della casella. Aspose.Slides per Android via Java fornisce l’interfaccia [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAutoShape) che consente di aggiungere una forma contenente del testo.

{{% alert title="Info" color="info" %}}
Aspose.Slides fornisce anche l’interfaccia [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape) che consente di aggiungere forme alle diapositive. Tuttavia, non tutte le forme aggiunte tramite l’interfaccia `IShape` possono contenere testo. Le forme aggiunte tramite l’interfaccia [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAutoShape) possono contenere testo.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Pertanto, quando si lavora con una forma a cui si desidera aggiungere testo, potrebbe essere necessario verificare e confermare che sia stata convertita tramite l’interfaccia `IAutoShape`. Solo così sarà possibile utilizzare [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextFrame), che è una proprietà di `IAutoShape`. Vedi la sezione [Update Text](https://docs.aspose.com/slides/it/androidjava/manage-textbox/#update-text) in questa pagina.
{{% /alert %}}

## **Creare una casella di testo su una diapositiva**

Per creare una casella di testo su una diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottieni un riferimento alla prima diapositiva nella presentazione appena creata. 
3. Aggiungi un oggetto [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAutoShape) con [ShapeType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) impostato a `Rectangle` in una posizione specificata sulla diapositiva e ottieni il riferimento all'oggetto `IAutoShape` appena aggiunto.
4. Aggiungi la proprietà `TextFrame` all'oggetto `IAutoShape` che conterrà del testo. Nell'esempio seguente, abbiamo aggiunto questo testo: *Aspose TextBox*
5. Infine, scrivi il file PPTX tramite l'oggetto `Presentation`. 

Questo codice Java—un'implementazione dei passaggi precedenti—mostra come aggiungere testo a una diapositiva:

```java
// Istanzia la presentazione
Presentation pres = new Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiunge un AutoShape con tipo impostato a Rettangolo
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Aggiunge TextFrame al rettangolo
    ashp.addTextFrame(" ");

    // Accede al riquadro di testo
    ITextFrame txtFrame = ashp.getTextFrame();

    // Crea l'oggetto Paragraph per il riquadro di testo
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

## **Verificare una forma di casella di testo**

Aspose.Slides fornisce il metodo [isTextBox](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/#isTextBox--) dell’interfaccia [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) che consente di esaminare le forme e identificare le caselle di testo.

![Casella di testo e forma](istextbox.png)

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

Nota che se si aggiunge semplicemente un'autoshape usando il metodo `addAutoShape` dell’interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/), il metodo `isTextBox` dell’autoshape restituirà `false`. Tuttavia, dopo aver aggiunto del testo all’autoshape usando il metodo `addTextFrame` o il metodo `setText`, la proprietà `isTextBox` restituisce `true`.

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

Aspose.Slides fornisce le proprietà [ColumnCount](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) e [ColumnSpacing](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (dall’interfaccia [ITextFrameFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrameFormat) e dalla classe [TextFrameFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextFrameFormat)) che consentono di aggiungere colonne alle caselle di testo. È possibile specificare il numero di colonne in una casella di testo e impostare la spaziatura in punti tra le colonne.

Questo codice Java dimostra l'operazione descritta: 

```java
Presentation pres = new Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiunge un AutoShape con tipo impostato a Rettangolo
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

## **Aggiungere colonne a un riquadro di testo**
Aspose.Slides per Android via Java fornisce la proprietà [ColumnCount](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (dall’interfaccia [ITextFrameFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrameFormat)) che consente di aggiungere colonne nei riquadri di testo. Attraverso questa proprietà è possibile specificare il numero desiderato di colonne in un riquadro di testo.

Questo codice Java mostra come aggiungere una colonna all'interno di un riquadro di testo:

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

Questo codice Java dimostra un'operazione in cui tutti i testi in una presentazione vengono aggiornati o modificati:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Verifica se la forma supporta il riquadro di testo (IAutoShape).
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Itera attraverso i paragrafi nel riquadro di testo
                {
                    for (IPortion portion : paragraph.getPortions()) //Itera attraverso ogni porzione nel paragrafo
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Cambia il testo
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Cambia la formattazione
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

## **Aggiungere una casella di testo con un collegamento ipertestuale** 

È possibile inserire un collegamento all'interno di una casella di testo. Quando la casella di testo viene cliccata, gli utenti vengono indirizzati ad aprire il collegamento. 

Per aggiungere una casella di testo contenente un collegamento, segui questi passaggi:

1. Crea un'istanza della classe `Presentation`. 
2. Ottieni un riferimento alla prima diapositiva nella presentazione appena creata. 
3. Aggiungi un oggetto `AutoShape` con `ShapeType` impostato a `Rectangle` in una posizione specificata sulla diapositiva e ottieni un riferimento all'oggetto AutoShape appena aggiunto.
4. Aggiungi un `TextFrame` all'oggetto `AutoShape` che contiene *Aspose TextBox* come testo predefinito. 
5. Istanzia la classe `IHyperlinkManager`. 
6. Assegna l'oggetto `IHyperlinkManager` alla proprietà [HyperlinkClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) associata alla porzione desiderata del `TextFrame`.
7. Infine, scrivi il file PPTX tramite l'oggetto `Presentation`. 

Questo codice Java—un'implementazione dei passaggi precedenti—mostra come aggiungere una casella di testo con un collegamento ipertestuale a una diapositiva:

```java
// Istanzia una classe Presentation che rappresenta un PPTX
Presentation pres = new Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiunge un oggetto AutoShape con tipo impostato a Rettangolo
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Converte la forma in AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Accede alla proprietà ITextFrame associata all'AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Aggiunge del testo al riquadro
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Imposta il collegamento ipertestuale per il testo della porzione
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

**Qual è la differenza tra una casella di testo e un segnaposto di testo quando si lavora con le diapositive master?**

Un [placeholder](/slides/it/androidjava/manage-placeholder/) eredita lo stile/posizione dal [master](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/masterslide/) e può essere sovrascritto nei [layout](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/layoutslide/), mentre una casella di testo regolare è un oggetto indipendente su una diapositiva specifica e non cambia quando si cambiano i layout.

**Come posso eseguire una sostituzione di testo di massa su tutta la presentazione senza modificare il testo all'interno di grafici, tabelle e SmartArt?**

Limita l’iterazione alle auto‑shape che possiedono riquadri di testo ed escludi gli oggetti incorporati ([chart](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/smartart/)) attraversando le loro collezioni separatamente o saltando quei tipi di oggetti.