---
title: Gestisci caselle di testo nelle presentazioni su Android
linktitle: Gestisci casella di testo
type: docs
weight: 20
url: /it/androidjava/manage-textbox/
keywords:
- casella di testo
- riquadro di testo
- aggiungi testo
- aggiorna testo
- crea casella di testo
- verifica casella di testo
- aggiungi colonna di testo
- aggiungi collegamento ipertestuale
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Crea, identifica, formatta e aggiorna le caselle di testo nelle presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Android via Java."
---
## **Introduzione**

In Aspose.Slides for Android via Java, il testo delle diapositive è memorizzato nei riquadri di testo che appartengono alle forme. L’interfaccia [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) rappresenta la forma più comune contenente testo e espone il suo testo tramite il metodo [IAutoShape.getTextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/#getTextFrame--).

{{% alert color="info" title="Nota" %}}
Ogni forma automatica implementa [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/), ma non tutte le forme sono forme automatiche o supportano un riquadro di testo. Quando si elabora una presentazione esistente, verificare che una forma implementi [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) prima di accedere al suo testo.
{{% /alert %}}

## **Crea una casella di testo su una diapositiva**

Per creare una casella di testo, aggiungere una forma automatica a una diapositiva, aggiungere del testo al suo riquadro di testo e salvare la presentazione. Il seguente esempio crea una casella di testo rettangolare:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le coordinate e le dimensioni passate a [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) sono misurate in punti. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) inizializza il riquadro di testo con il testo fornito.

## **Verifica se una forma è una casella di testo**

Usare il metodo [IAutoShape.isTextBox](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/#isTextBox--) per determinare se una forma automatica è trattata come una casella di testo. Ciò è utile quando una presentazione contiene sia forme automatiche con testo sia forme puramente grafiche.

![A text box and a shape](istextbox.png)

Il seguente esempio ispeziona ogni forma automatica in una presentazione:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Una forma automatica appena aggiunta non è considerata una casella di testo finché non contiene testo non vuoto. È possibile fornire quel testo tramite [IAutoShape.addTextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) o [ITextFrame.setText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-). L’aggiunta o l’assegnazione di una stringa vuota fa sì che [IAutoShape.isTextBox](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/#isTextBox--) restituisca `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Le prime due chiamate stampano `true`; le ultime due stampano `false`.

## **Trova la forma che possiede un riquadro di testo**

Il codice generico di elaborazione del testo può ricevere un [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) senza sapere quale oggetto della presentazione lo contenga. Usare il metodo di sola lettura [ITextFrame.getParentShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#getParentShape--) per tornare alla sua [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/) proprietaria.

Per un riquadro di testo di proprietà di una forma automatica o di un’altra forma con testo, [ITextFrame.getParentShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#getParentShape--) restituisce il proprietario e [ITextFrame.getParentCell](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#getParentCell--) restituisce `null`. Verificare il valore restituito prima di accedervi. Per identificare sia i proprietari delle forme sia quelli delle celle di tabella, incluse le forme associate a nodi SmartArt, vedere [Search and Replace Text](/slides/it/androidjava/search-and-replace-text/).

## **Aggiungi colonne a una casella di testo**

Il metodo [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) divide il riquadro di testo in colonne, mentre [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) imposta lo spazio tra le colonne in punti. Entrambe le impostazioni appartengono a [ITextFrameFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/) e possono essere modificate tramite il riquadro di testo di una casella di testo esistente. Il testo fluisce tra le colonne all’interno della stessa forma; non continua in un’altra forma.

Il seguente esempio crea una casella di testo a tre colonne con 10 punti tra le colonne, salva la presentazione e legge le impostazioni memorizzate dal file di output:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Estrai il testo da colonne individuali**

Usare [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) per recuperare il testo assegnato a ciascuna colonna visiva in un riquadro di testo esistente. Il metodo restituisce una stringa per ogni colonna, nell’ordine di lettura basato sulle colonne. Un riquadro di testo a colonna singola produce un array con un solo elemento, e una colonna vuota è rappresentata da una stringa vuota. Le stringhe contengono solo testo semplice; la formattazione a livello di porzione non viene preservata.

Ciò è utile quando è necessario:

- Estrarre il testo mantenendo l’ordine di lettura basato sulle colonne.
- Indicizzare o confrontare il contenuto di diapositive a più colonne.
- Esportare ogni colonna in un file separato, campo di database o altra destinazione.
- Analizzare come il testo viene ridistribuito dopo aver modificato il conteggio delle colonne con [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-), la spaziatura con [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), il carattere o le dimensioni del riquadro di testo.

Il metodo segnala il testo distribuito all’interno del corrente [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/); non fluisce automaticamente il testo tra forme o caselle di testo separate. La distribuzione delle colonne può dipendere dai caratteri disponibili e da altre impostazioni di layout del testo, quindi assicurarsi che i caratteri richiesti siano disponibili quando è importante ottenere risultati coerenti.

Il seguente esempio carica una presentazione, trova la prima forma automatica a più colonne con un riquadro di testo, legge il conteggio delle colonne configurato e scrive il testo di ogni colonna in un file separato. Le forme che non forniscono un riquadro di testo vengono saltate.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Aggiorna il testo**

Per aggiornare il testo in tutta la presentazione, scorrere le diapositive e le forme, selezionare le forme automatiche e quindi modificare le loro porzioni di testo. Lavorare a livello di porzione consente di modificare sia il testo sia la formattazione dei caratteri.

Il seguente esempio sostituisce ogni occorrenza di `years` con `months` nel testo delle forme automatiche e rende grassetto ogni porzione interessata:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Questo attraversamento aggiorna il testo solo nelle forme automatiche. Il testo memorizzato in tabelle, grafici, SmartArt o forme raggruppate richiede l’attraversamento delle collezioni di quegli oggetti.

## **Aggiungi una casella di testo con un collegamento ipertestuale**

È possibile assegnare un collegamento ipertestuale a una specifica porzione di testo, in modo che solo quel testo funzioni da link cliccabile. Usare [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) per associare la porzione a un URL esterno.

Il seguente esempio crea testo collegato e lo salva in una presentazione:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual è la differenza tra una casella di testo e un segnaposto di testo su una diapositiva master o layout?**

Un [segnaposto](/slides/it/androidjava/manage-placeholder/) può ereditare la sua posizione e formattazione da una [diapositiva master](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/masterslide/) o da una [diapositiva layout](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/layoutslide/). Una casella di testo normale è una forma indipendente sulla diapositiva in cui è stata creata e non acquisisce il comportamento del segnaposto quando il layout cambia.

**Come posso sostituire il testo senza modificarlo in grafici, tabelle o SmartArt?**

Limitare l’attraversamento alle forme che implementano [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/), come mostrato nell’esempio Aggiorna il testo. Grafici, tabelle e SmartArt memorizzano il testo nei propri modelli di oggetti, quindi non vengono modificati da quel ciclo.