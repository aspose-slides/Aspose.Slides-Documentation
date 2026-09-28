---
title: "Applica o Modifica Layout di Diapositiva in Java"
linktitle: "Layout di Diapositiva"
type: docs
weight: 60
url: /it/java/slide-layout/
keywords:
- layout di diapositiva
- layout di contenuto
- segnaposto
- progettazione della presentazione
- progettazione della diapositiva
- layout inutilizzato
- visibilità del piè di pagina
- diapositiva titolo
- titolo e contenuto
- intestazione di sezione
- due contenuti
- confronto
- solo titolo
- layout vuoto
- contenuto con didascalia
- immagine con didascalia
- titolo e testo verticale
- titolo verticale e testo
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Applica, crea e modifica layout di diapositiva in Aspose.Slides per Java, aggiungi segnaposto, rimuovi layout inutilizzati e controlla la visibilità del piè di pagina."
---
## **Panoramica**

Un layout di diapositiva definisce le posizioni e la formattazione dei segnaposto come titoli, testo, immagini, grafici e tabelle. Applicare un layout conferisce alle diapositive una struttura coerente consentendo a ciascuna diapositiva di contenere i propri contenuti.

I layout più comuni includono:

- **Slide Titolo**: Contiene segnaposto titolo e segnaposto sottotitolo.
- **Titolo e Contenuto**: Contiene un segnaposto titolo e un segnaposto contenuto a uso generale.
- **Vuota**: Non contiene segnaposto di contenuto ed è utile quando ogni forma sarà posizionata manualmente.

## **Comprendere l'Eredità del Layout**

Una presentazione ha tre livelli correlati:

1. Una [slide master](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslide/) definisce il tema, la formattazione condivisa, gli sfondi e gli oggetti comuni.
1. Una [slide layout](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/) appartiene a un master e definisce una disposizione specifica di segnaposto.
1. Una [slide normale](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/) utilizza un layout e memorizza i contenuti inseriti per quella slide.

Una slide normale eredita tema e formattazione dal suo layout, e il layout eredita dal suo master. Un valore impostato direttamente su una slide normale sovrascrive il valore ereditato a quel livello. Quando viene creata una slide normale, le forme dei segnaposto vengono generate dal layout selezionato, mentre il contenuto inserito in quei segnaposto appartiene alla slide normale.

Aggiungi i segnaposto richiesti a un layout prima di creare le diapositive da esso. L'aggiunta successiva di un altro segnaposto a un layout non aggiunge automaticamente una forma segnaposto corrispondente alle slide normali esistenti.

Questa relazione ha due importanti conseguenze:

- La modifica della formattazione ereditata o della geometria dei segnaposto esistenti su un layout può aggiornare ogni slide che dipende da esso. Prima di modificare un layout già in uso, verifica le slide dipendenti e rivedi la presentazione risultante.
- Un layout ancora utilizzato da una slide non può essere rimosso. Riassegna prima le slide dipendenti a un altro layout, oppure rimuovi solo i layout non utilizzati.

Per ulteriori informazioni sul livello superiore di questa gerarchia, vedi [Master della diapositiva](/slides/it/java/slide-master/).

Per nascondere loghi ereditati o forme decorative del master su una slide o tramite un layout condiviso, vedi [Controllare la visibilità della grafica master](/slides/it/java/slide-master/). L'esempio confronta due diapositive che utilizzano lo stesso master.

## **Selezionare e Applicare un Layout di Diapositiva**

Usa un tipo di layout quando la presentazione segue le definizioni di layout standard di PowerPoint. I nomi dei layout sono modificabili dall'utente e possono essere localizzati, quindi la selezione basata sul nome è meno affidabile a meno che tu non controlli il modello di origine.

L'esempio seguente cerca **Titolo e Contenuto** sul primo master. Se quel layout non è disponibile, ricade deliberatamente su **Vuota**. Il secondo controllo null è necessario perché una presentazione può contenere solo layout personalizzati. Il layout selezionato viene quindi applicato alla prima slide normale tramite il metodo [ISlide.setLayoutSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

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

Modificare il layout di una slide non rimuove le forme ordinarie aggiunte direttamente alla slide. Tuttavia, le posizioni dei segnaposto, la formattazione ereditata e la corrispondenza tra i segnaposto esistenti e il nuovo layout possono cambiare, quindi ispeziona l'output quando passi tra layout sostanzialmente diversi.

## **Aggiungere un Layout di Diapositiva**

Selezione e creazione sono operazioni separate. L'esempio precedente seleziona un layout esistente; non ne crea uno. Per creare un layout, chiama il metodo [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) sulla collezione di layout del master di destinazione.

L'esempio seguente aggiunge sempre un nuovo layout **Titolo e Contenuto** chiamato `Report Title and Content`, quindi aggiunge una slide normale basata su di esso. I nomi dei layout devono essere unici all'interno della collezione.

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

Aggiungi un layout solo quando il modello necessita veramente di un'altra struttura riutilizzabile. Se esiste già un layout adatto, selezionalo e riutilizzalo invece di crearne un duplicato.

## **Aggiungere Segnaposto a un Layout di Diapositiva**

Il metodo [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) fornisce un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/) per aggiungere forme segnaposto a un layout.

| Segnaposto PowerPoint              | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Contenuto](content.png)          | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Contenuto (Verticale)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Testo](text.png)                 | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Testo (Verticale)](textV.png)    | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Immagine](picture.png)           | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Grafico](chart.png)              | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabella](table.png)              | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)          | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png)                | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Immagine online](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

L'esempio seguente verifica che il layout **Vuota** esista, aggiunge quattro segnaposto a esso e poi crea una slide normale che utilizza il layout modificato. L'ordine è intenzionale: i segnaposto vengono aggiunti prima che la slide normale sia creata, così Aspose.Slides può generare le forme segnaposto corrispondenti su quella slide.

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

![I segnaposto nella slide di layout](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modificare la formattazione ereditata o la geometria dei segnaposto esistenti su un layout può influenzare le slide dipendenti. Un segnaposto di layout appena aggiunto non viene retroattivamente inserito nelle slide normali esistenti. Prova le modifiche al layout su una copia della presentazione e controlla ogni slide dipendente.
{{% /alert %}}

## **Rimuovere Layout di Diapositiva Non Utilizzati**

Usa il metodo [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) per rimuovere i layout a cui nessuna slide normale fa riferimento. Il metodo lascia intatti i layout ancora in uso.

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

Per rimuovere un layout specifico, utilizza prima il suo metodo [hasDependingSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) o [getDependingSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#getDependingSlides--). Riassegna le slide dipendenti prima di chiamare [ILayoutSlide.remove](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#remove--). Tentare di rimuovere un layout in uso genera una [PptxEditException](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptxeditexception/).

## **Controllare la Visibilità del Piè di Pagina su una Slide Layout**

Un layout possiede i propri segnaposto per piè di pagina, numero di slide e data/ora. Usa il metodo [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) per controllare quei segnaposto su un singolo layout. È utile quando, ad esempio, i layout di contenuto devono mostrare i piè di pagina ma i layout di titolo no.

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

## **Controllare la Visibilità del Piè di Pagina su un Master e sui Suoi Layout Figli**

Per applicare impostazioni di piè di pagina coerenti su tutta la gerarchia del master, usa il metodo [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--). I metodi di propagazione di [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslideheaderfootermanager/) operano sul master e sui suoi layout dipendenti e sulle slide normali; non si applicano a una singola slide normale.

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

**Qual è la differenza tra una Slide Master e una Slide Layout?**

Una slide master definisce il tema della presentazione e la formattazione condivisa. Una slide layout appartiene a un master e definisce una disposizione riutilizzabile di segnaposto. Le slide normali utilizzano quei layout e memorizzano i contenuti specifici della slide.

**Posso copiare una Slide Layout da una presentazione a un'altra?**

Sì. Aggiungi una copia alla collezione di destinazione con il metodo [addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Quando copi tra presentazioni, verifica anche i font, i temi, le immagini e le altre risorse utilizzate dal layout di origine.

**Cosa succede quando modifico un layout già in uso?**

Le slide dipendenti ereditano le modifiche al layout a meno che non sovrascrivano localmente la formattazione o gli oggetti interessati. La geometria dei segnaposto e lo stile ereditato possono quindi cambiare su molte slide contemporaneamente. Usa [getDependingSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) per identificare le slide interessate prima di modificare il layout.

**Cosa succede se rimuovo un layout ancora in uso?**

Aspose.Slides genera una [PptxEditException](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptxeditexception/). Riassegna prima le slide dipendenti, oppure usa [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) per rimuovere solo i layout non referenziati.