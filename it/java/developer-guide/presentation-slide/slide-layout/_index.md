---
title: "Applicare o Modificare i Layout delle Diapositive in Java"
linktitle: "Layout di Diapositiva"
type: docs
weight: 60
url: /it/java/slide-layout/
keywords:
- "layout diapositiva"
- "layout contenuto"
- "segnaposto"
- "design della presentazione"
- "design della diapositiva"
- "layout non utilizzato"
- "visibilità piè di pagina"
- "diapositiva titolo"
- "titolo e contenuto"
- "intestazione sezione"
- "due contenuti"
- "confronto"
- "solo titolo"
- "layout vuoto"
- "contenuto con didascalia"
- "immagine con didascalia"
- "titolo e testo verticale"
- "titolo verticale e testo"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- "Java"
- "Aspose.Slides"
description: "Applica, crea e modifica i layout delle diapositive in Aspose.Slides per Java, aggiungi segnaposti, rimuovi layout non utilizzati e controlla la visibilità del piè di pagina."
---
## **Panoramica**

Un layout di diapositiva definisce le posizioni e la formattazione dei segnaposti come titoli, testo, immagini, grafici e tabelle. Applicare un layout fornisce alle diapositive una struttura coerente consentendo a ciascuna diapositiva di contenere il proprio contenuto.

I layout più comuni includono:

- **Title Slide**: Contiene segnaposti per titolo e sottotitolo.
- **Title and Content**: Contiene un segnaposto per il titolo e un segnaposto di contenuto generico.
- **Blank**: Non contiene segnaposti di contenuto ed è utile quando ogni forma verrà posizionata manualmente.

## **Comprendere l'ereditarietà dei layout**

Una presentazione ha tre livelli correlati:

1. Una [master slide](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslide/) definisce il tema, la formattazione condivisa, gli sfondi e gli oggetti comuni.
1. Una [layout slide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/) appartiene a un master e definisce una particolare disposizione dei segnaposti.
1. Una [normal slide](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/) utilizza un layout e memorizza il contenuto inserito per quella diapositiva.

Una normal slide eredita tema e formattazione dal suo layout, e il layout eredita dal suo master. Un valore impostato direttamente su una normal slide sovrascrive il valore ereditato a quel livello. Quando una normal slide viene creata, le forme dei segnaposti vengono generate dal layout selezionato, mentre il contenuto inserito in quei segnaposti appartiene alla normal slide.

Aggiungi i segnaposti richiesti a un layout prima di creare le diapositive da esso. Aggiungere un altro segnaposto a un layout in seguito non aggiunge automaticamente una forma di segnaposto corrispondente alle diapositive normali esistenti.

Questa relazione ha due importanti conseguenze:

- Modificare la formattazione ereditata o la geometria dei segnaposti esistenti su un layout può aggiornare tutte le diapositive che dipendono da esso. Prima di modificare un layout già in uso, ispeziona le diapositive dipendenti e rivedi la presentazione risultante.
- Un layout che è ancora utilizzato da una diapositiva non può essere rimosso. Riassegna prima le diapositive dipendenti a un altro layout, oppure rimuovi solo i layout non utilizzati.

Per ulteriori informazioni sul livello più alto di questa gerarchia, vedi [Slide Master](/slides/it/java/slide-master/).

## **Selezionare e Applicare un Layout di Diapositiva**

Utilizza un tipo di layout quando la presentazione segue le definizioni standard dei layout di PowerPoint. I nomi dei layout sono modificabili dall'utente e possono essere localizzati, quindi la selezione basata sul nome è meno affidabile a meno che tu non controlli il modello di origine.

L'esempio seguente cerca **Title and Content** sul primo master. Se quel layout non è disponibile, ricade deliberatamente su **Blank**. Il secondo controllo null è necessario perché una presentazione può contenere solo layout personalizzati. Il layout selezionato viene quindi applicato alla prima normal slide tramite il metodo [ISlide.setLayoutSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Modificare il layout di una diapositiva non rimuove le forme ordinarie aggiunte direttamente alla diapositiva. Tuttavia, le posizioni dei segnaposti, la formattazione ereditata e la corrispondenza tra i segnaposti esistenti e il nuovo layout possono cambiare, quindi ispeziona l'output quando passi da layout sostanzialmente diversi.

## **Aggiungere una Diapositiva Layout**

Selezione e creazione sono operazioni separate. L'esempio precedente seleziona un layout esistente; non ne crea uno. Per creare un layout, chiama il metodo [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) sulla collezione di layout del master di destinazione.

L'esempio seguente aggiunge sempre un nuovo layout **Title and Content** chiamato `Report Title and Content`, quindi aggiunge una normal slide basata su di esso. I nomi dei layout devono essere unici all'interno della collezione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aggiungi un layout solo quando il modello necessita realmente di un'altra struttura riutilizzabile. Se esiste già un layout adatto, selezionalo e riutilizzalo invece di crearne un duplicato.

## **Aggiungere Segnaposti a una Diapositiva Layout**

Il metodo [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) fornisce un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/) per aggiungere forme di segnaposto a un layout.

| Segnaposto PowerPoint | `ILayoutPlaceholderManager` Method |
| --------------------- | ---------------------------------- |
| ![Contenuto](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Contenuto (Verticale)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Testo](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Testo (Verticale)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Immagine](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Grafico](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabella](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Immagine online](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

L'esempio seguente verifica che il layout **Blank** esista, aggiunge quattro segnaposti ad esso e quindi crea una normal slide che utilizza il layout modificato. L'ordine è intenzionale: i segnaposti vengono aggiunti prima della creazione della normal slide, così Aspose.Slides può generare le corrispondenti forme di segnaposto su quella diapositiva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![I segnaposti sulla diapositiva layout](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modificare la formattazione ereditata o la geometria dei segnaposti di layout esistenti può influire sulle diapositive dipendenti. Un segnaposto di layout appena aggiunto non viene retrofittato nelle normal slide esistenti. Prova le modifiche al layout su una copia della presentazione e ispeziona ogni diapositiva dipendente.
{{% /alert %}}

## **Rimuovere le Diapositive Layout Inutilizzate**

Utilizza il metodo [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) per rimuovere i layout a cui nessuna normal slide fa riferimento. Il metodo lascia intatti i layout ancora in uso.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per rimuovere un layout specifico, utilizza prima il suo metodo [hasDependingSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) o [getDependingSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#getDependingSlides--). Riassegna eventuali diapositive dipendenti prima di chiamare [ILayoutSlide.remove](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#remove--). Tentare di rimuovere un layout in uso genera una [PptxEditException](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptxeditexception/).

## **Controllare la Visibilità del Footer su una Diapositiva Layout**

Un layout ha i propri segnaposti per footer, numero diapositiva e data/ora. Utilizza il metodo [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) per controllare quei segnaposti per un layout. Questo è utile quando, ad esempio, i layout di contenuto devono mostrare i footer ma i layout di titolo no.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controllare la Visibilità del Footer su un Master e i Suoi Layout Figlio**

Per applicare impostazioni di footer coerenti su tutta la gerarchia di un master, utilizza il metodo [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) . I metodi di propagazione di [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslideheaderfootermanager/) operano sul master e sui suoi layout dipendenti e sulle normal slide; non si rivolgono a una sola normal slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual è la differenza tra una Master Slide e una Layout Slide?**

Una master slide definisce il tema della presentazione e la formattazione condivisa. Una layout slide appartiene a una master e definisce una disposizione riutilizzabile di segnaposti. Le normal slide utilizzano questi layout e memorizzano il contenuto specifico della diapositiva.

**Posso copiare una Layout Slide da una presentazione a un'altra?**

Sì. Aggiungi una copia alla collezione di destinazione con il metodo [addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) . Quando copi tra presentazioni, verifica anche i caratteri, i temi, le immagini e le altre risorse utilizzate dal layout di origine.

**Cosa succede se modifico un layout già in uso?**

Le diapositive dipendenti ereditano le modifiche al layout a meno che non sovrascrivano localmente la formattazione o gli oggetti interessati. La geometria dei segnaposti e lo stile ereditato possono quindi cambiare su molte diapositive contemporaneamente. Usa [getDependingSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) per identificare le diapositive interessate prima di modificare il layout.

**Cosa succede se rimuovo un layout ancora in uso?**

Aspose.Slides genera un'eccezione [PptxEditException](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptxeditexception/). Riassegna prima le diapositive dipendenti, oppure utilizza [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) per rimuovere solo i layout non referenziati.