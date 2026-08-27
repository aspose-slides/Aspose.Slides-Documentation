---
title: Gestire le caselle di testo nelle presentazioni su Android
linktitle: Gestire casella di testo
type: docs
weight: 20
url: /it/androidjava/manage-textbox/
keywords:
- casella di testo
- frame di testo
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
description: "Aspose.Slides per Android tramite Java consente di creare, modificare e clonare facilmente le caselle di testo in file PowerPoint e OpenDocument, migliorando l'automazione delle tue presentazioni."
---
## **Introduzione**

I testi nelle diapositive si trovano tipicamente in caselle di testo o forme. Pertanto, per aggiungere del testo a una diapositiva, è necessario aggiungere una casella di testo e poi inserire del testo all'interno della casella. Aspose.Slides per Android tramite Java fornisce l'interfaccia [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAutoShape) che consente di aggiungere una forma contenente del testo.

{{% alert title="Info" color="info" %}}
Aspose.Slides fornisce inoltre l'interfaccia [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape) che consente di aggiungere forme alle diapositive. Tuttavia, non tutte le forme aggiunte tramite l'interfaccia `IShape` possono contenere testo. Le forme aggiunte tramite l'interfaccia [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAutoShape), invece, possono contenere testo.
{{% /alert %}}

{{% alert title="Nota" color="warning" %}} 
Pertanto, quando si lavora con una forma a cui si desidera aggiungere testo, è opportuno verificare e confermare che sia stata castata tramite l'interfaccia `IAutoShape`. Solo allora sarà possibile lavorare con [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextFrame), proprietà di `IAutoShape`. Consulta la sezione [Update Text](https://docs.aspose.com/slides/it/androidjava/manage-textbox/#update-text) in questa pagina.
{{% /alert %}}

## **Creare una casella di testo su una diapositiva**

Per creare una casella di testo su una diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottieni un riferimento alla prima diapositiva nella presentazione appena creata. 
3. Aggiungi un oggetto [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAutoShape) con [ShapeType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) impostato su `Rectangle` in una posizione specificata sulla diapositiva e ottieni il riferimento all'oggetto `IAutoShape` appena aggiunto.
4. Aggiungi la proprietà `TextFrame` all'oggetto `IAutoShape` che conterrà del testo. Nell'esempio seguente, abbiamo aggiunto questo testo: *Aspose TextBox*
5. Infine, scrivi il file PPTX tramite l'oggetto `Presentation`. 

Questo codice Java—un'implementazione dei passaggi sopra—mostra come aggiungere testo a una diapositiva:

```java
import com.aspose.slides.*;

// Istanzia la presentazione
Presentation pres = new Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiunge un AutoShape con tipo impostato a Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Aggiunge TextFrame al Rectangle
    ashp.addTextFrame(" ");

    // Accede al TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();

    // Crea l'oggetto Paragraph per il TextFrame
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

## **Verificare una forma casella di testo**

Aspose.Slides fornisce il metodo [isTextBox](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/#isTextBox--) dell'interfaccia [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) , consentendo di esaminare le forme e identificare le caselle di testo.

![Casella di testo e forma](istextbox.png)

Questo codice Java mostra come verificare se una forma è stata creata come casella di testo: 

```java
import com.aspose.slides.*;

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

Nota che se si aggiunge semplicemente un'autoshape usando il metodo `addAutoShape` dell'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/) , il metodo `isTextBox` dell'autoshape restituirà `false`. Tuttavia, dopo aver aggiunto testo all'autoshape utilizzando il metodo `addTextFrame` o il metodo `setText`, la proprietà `isTextBox` restituisce `true`.

```java
import com.aspose.slides.*;

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

## **Trovare la forma che possiede un TextFrame**

Nel codice generico di elaborazione del testo, potresti ricevere un oggetto [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) senza conoscere già a quale oggetto della presentazione appartenga. Utilizza il metodo [ITextFrame.getParentShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#getParentShape--) per tornare alla [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/) proprietaria.

Per un TextFrame che appartiene a un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) o a un'altra forma contenente testo, [ITextFrame.getParentShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#getParentShape--) restituisce il proprietario mentre [ITextFrame.getParentCell](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#getParentCell--) restituisce `null`. Entrambi i metodi forniscono navigazione in sola lettura, quindi la loro chiamata non modifica la proprietà. Verifica sempre che il valore restituito non sia `null` prima di accedere alla forma.

Per un esempio completo che identifica i proprietari di forma e di cella di tabella, inclusi le forme associate ai nodi SmartArt, vedi [Search and Replace Text](/slides/it/androidjava/search-and-replace-text/).

## **Aggiungere colonne a una casella di testo**

Aspose.Slides fornisce le proprietà [ColumnCount](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) e [ColumnSpacing](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (dall'interfaccia [ITextFrameFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrameFormat) e dalla classe [TextFrameFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextFrameFormat)) che consentono di aggiungere colonne alle caselle di testo. È possibile specificare il numero di colonne in una casella di testo e impostare la spaziatura in punti tra le colonne.

Questo codice Java dimostra l'operazione descritta: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiunge un AutoShape con tipo impostato a Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Aggiunge TextFrame al Rectangle
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

## **Aggiungere colonne a un TextFrame**
Aspose.Slides per Android tramite Java fornisce la proprietà [ColumnCount](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (dall'interfaccia [ITextFrameFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrameFormat)) che consente di aggiungere colonne nei TextFrame. Attraverso questa proprietà, è possibile specificare il numero desiderato di colonne in un TextFrame.

Questo codice Java mostra come aggiungere una colonna all'interno di un TextFrame:

```java
import com.aspose.slides.*;

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
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiornare il testo**

Aspose.Slides consente di modificare o aggiornare il testo contenuto in una casella di testo o tutti i testi contenuti in una presentazione. 

Questo codice Java dimostra un'operazione in cui tutti i testi di una presentazione vengono aggiornati o modificati:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Verifica se la forma supporta il TextFrame (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Itera i paragrafi nel TextFrame
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

## **Aggiungere una casella di testo con un collegamento ipertestuale** 

È possibile inserire un collegamento all'interno di una casella di testo. Quando la casella di testo viene cliccata, gli utenti vengono indirizzati ad aprire il collegamento. 

 Per aggiungere una casella di testo contenente un collegamento, segui questi passaggi:

1. Crea un'istanza della classe `Presentation`. 
2. Ottieni un riferimento alla prima diapositiva nella presentazione appena creata. 
3. Aggiungi un oggetto `AutoShape` con `ShapeType` impostato su `Rectangle` in una posizione specificata sulla diapositiva e ottieni un riferimento all'oggetto AutoShape appena aggiunto.
4. Aggiungi un `TextFrame` all'oggetto `AutoShape` e imposta il testo della sua prima porzione. Nell'esempio seguente, abbiamo usato questo testo: *Aspose.Slides*
5. Ottieni l'oggetto [IHyperlinkManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkmanager/) dal `PortionFormat` della porzione desiderata del `TextFrame`.
6. Chiama [setExternalHyperlinkClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) su quell'oggetto per impostare il collegamento che si apre quando il testo viene cliccato.
7. Infine, scrivi il file PPTX tramite l'oggetto `Presentation`. 

Questo codice Java—un'implementazione dei passaggi sopra—mostra come aggiungere una casella di testo con un collegamento ipertestuale a una diapositiva:

```java
import com.aspose.slides.*;

// Istanzia una classe Presentation che rappresenta un PPTX
Presentation pres = new Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiunge un oggetto AutoShape con tipo impostato a Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Esegue il cast della forma a AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Accede alla proprietà ITextFrame associata all'AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Aggiunge del testo al frame
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

Un [placeholder](/slides/it/androidjava/manage-placeholder/) eredita lo stile/posizione dal [master](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/masterslide/) e può essere sovrascritto sui [layouts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/layoutslide/), mentre una casella di testo regolare è un oggetto indipendente su una diapositiva specifica e non cambia quando si passano i layout.

**Come posso eseguire una sostituzione massiva del testo su tutta la presentazione senza modificare il testo all'interno di grafici, tabelle e SmartArt?**

Limita l'iterazione alle auto-shape che possiedono TextFrame ed escludi gli oggetti incorporati ([chart](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/smartart/)) attraversando le loro collezioni separatamente o saltando quei tipi di oggetti.