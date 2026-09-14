---
title: Applicare o modificare i layout di slide in Python tramite Java
linktitle: Layout di slide
type: docs
weight: 60
url: /it/python-java/slide-layout/
keywords:
- layout di slide
- layout di contenuto
- segnaposto
- design della presentazione
- design della slide
- layout inutilizzato
- visibilità del piè di pagina
- slide titolo
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
- Python
- Java
- Aspose.Slides
description: "Applica, crea e modifica i layout di slide in Aspose.Slides per Python tramite Java, aggiungi segnaposti, rimuovi layout inutilizzati e controlla la visibilità del piè di pagina."
---
## **Panoramica**

Un layout di slide definisce le posizioni e la formattazione dei segnaposto come titoli, testo, immagini, grafici e tabelle. Applicare un layout conferisce alle slide una struttura coerente consentendo a ciascuna slide di contenere i propri contenuti.

I layout più comuni includono:

- **Slide Titolo**: contiene i segnaposto per titolo e sottotitolo.
- **Titolo e Contenuto**: contiene un segnaposto per il titolo e un segnaposto di contenuto generico.
- **Vuota**: non contiene segnaposto di contenuto ed è utile quando ogni forma viene posizionata manualmente.

## **Comprendere l’Ereditarietà dei Layout**

Una presentazione ha tre livelli correlati:

1. Una [slide master](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/) definisce il tema, la formattazione condivisa, gli sfondi e gli oggetti comuni.
2. Una [slide di layout](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/) appartiene a un master e definisce una disposizione specifica dei segnaposto.
3. Una [slide normale](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/) utilizza un layout e memorizza i contenuti inseriti per quella slide.

Una slide normale eredita tema e formattazione dal suo layout, e il layout eredita dal suo master. Un valore impostato direttamente su una slide normale sovrascrive il valore ereditato a quel livello. Quando viene creata una slide normale, le forme segnaposto vengono generate dal layout selezionato, mentre il contenuto inserito in quei segnaposto appartiene alla slide normale.

Aggiungi i segnaposto necessari a un layout prima di creare slide da esso. L’aggiunta successiva di un altro segnaposto a un layout non aggiunge automaticamente una forma segnaposto corrispondente alle slide normali esistenti.

Questa relazione comporta due conseguenze importanti:

- Modificare la formattazione ereditata o la geometria dei segnaposto esistenti su un layout può aggiornare ogni slide che dipende da esso. Prima di modificare un layout già in uso, verifica le slide dipendenti e revisiona la presentazione risultante.
- Un layout ancora utilizzato da una slide non può essere rimosso. Riassegna prima le slide dipendenti a un altro layout, o rimuovi solo i layout inutilizzati.

Per ulteriori informazioni sul livello superiore di questa gerarchia, consulta [Slide Master](/slides/it/python-java/slide-master/).

## **Selezionare e Applicare un Layout di Slide**

Usa un tipo di layout quando la presentazione segue le definizioni standard dei layout di PowerPoint. I nomi dei layout sono modificabili dall’utente e possono essere localizzati, quindi la selezione basata sul nome è meno affidabile a meno che non si controlli il modello sorgente.

L’esempio seguente cerca **Titolo e Contenuto** nel primo master. Se quel layout non è disponibile, ricade deliberatamente su **Vuota**. Il secondo controllo per `None` è necessario perché una presentazione può contenere solo layout personalizzati. Il layout selezionato viene poi applicato alla prima slide normale tramite il metodo [Slide.setLayoutSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#setLayoutSlide).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Cambiare il layout di una slide non rimuove le forme ordinarie aggiunte direttamente alla slide. Tuttavia, le posizioni dei segnaposto, la formattazione ereditata e la corrispondenza tra i segnaposto esistenti e il nuovo layout possono cambiare, quindi verifica l’output quando si passa da layout sostanzialmente diversi.

## **Aggiungere una Slide di Layout**

Selezione e creazione sono operazioni separate. L’esempio precedente seleziona un layout esistente; non ne crea uno. Per creare un layout, chiama il metodo [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterlayoutslidecollection/#add) sulla raccolta di layout del master di destinazione.

L’esempio seguente aggiunge sempre un nuovo layout **Titolo e Contenuto** denominato `Report Title and Content`, poi aggiunge una slide normale basata su di esso. I nomi dei layout devono essere univoci all’interno della raccolta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aggiungi un layout solo quando il modello richiede realmente un’altra struttura riutilizzabile. Se esiste già un layout adatto, selezionalo e riutilizzalo invece di creare un duplicato.

## **Aggiungere Segnaposto a una Slide di Layout**

Il metodo [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#getPlaceholderManager) restituisce un [LayoutPlaceholderManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/) per aggiungere forme segnaposto a un layout.

| Segnaposto PowerPoint              | [LayoutPlaceholderManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/) Metodo |
| ----------------------------------- | ---------------------------------- |
| ![Content](content.png)             | [addContentPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [addTextPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [addPicturePlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [addChartPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [addTablePlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [addSmartArtPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [addMediaPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

L’esempio seguente verifica che il layout **Vuota** esista, aggiunge quattro segnaposto e poi crea una slide normale che utilizza il layout modificato. L’ordine è intenzionale: i segnaposto vengono aggiunti prima della creazione della slide normale, così Aspose.Slides può generare le forme segnaposto corrispondenti su quella slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![I segnaposto sulla slide di layout](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modificare la formattazione ereditata o la geometria dei segnaposto esistenti su un layout può influire sulle slide dipendenti. Un segnaposto di layout aggiunto di recente non viene retroattivamente inserito nelle slide normali esistenti. Testa le modifiche al layout su una copia della presentazione e controlla ogni slide dipendente.
{{% /alert %}}

## **Rimuovere le Slide di Layout Non Utilizzate**

Usa il metodo [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) per rimuovere i layout a cui nessuna slide normale fa riferimento. Il metodo lascia intatti i layout ancora in uso.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per rimuovere un layout specifico, utilizza prima il suo metodo [hasDependingSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#hasDependingSlides) o [getDependingSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#getDependingSlides). Riassegna le slide dipendenti prima di chiamare [LayoutSlide.remove](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#remove). Tentare di rimuovere un layout in uso genera una [PptxEditException](https://reference.aspose.com/slides/it/python-java/aspose.slides/pptxeditexception/).

## **Controllare la Visibilità del Footer su una Slide di Layout**

Un layout ha i propri segnaposto per footer, numero di slide e data/ora. Usa il metodo [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) per controllare questi segnaposto su un singolo layout. È utile, ad esempio, quando i layout di contenuto devono mostrare i footer ma i layout di titolo no.

L’esempio seguente seleziona in modo sicuro un layout e rende visibili i suoi elementi di footer:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controllare la Visibilità del Footer su un Master e le Sue Slide di Layout Figlie**

Per applicare impostazioni di footer coerenti su tutta la gerarchia del master, usa il metodo [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#getHeaderFooterManager). I metodi di propagazione di [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslideheaderfootermanager/) operano sul master e sulle slide di layout e slide normali dipendenti; non si rivolgono a una singola slide normale.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Qual è la differenza tra una Slide Master e una Slide di Layout?**

Una slide master definisce il tema della presentazione e la formattazione condivisa. Una slide di layout appartiene a un master e definisce una disposizione riutilizzabile di segnaposto. Le slide normali usano questi layout e memorizzano i contenuti specifici della slide.

**Posso copiare una Slide di Layout da una presentazione all’altra?**

Sì. Aggiungi una copia alla raccolta di destinazione con il metodo [addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/globallayoutslidecollection/#addClone). Quando copi tra presentazioni, verifica anche i caratteri, i temi, le immagini e le altre risorse usate dal layout di origine.

**Cosa succede se modifico un Layout già in uso?**

Le slide dipendenti ereditano le modifiche al layout, a meno che non sovrascrivano localmente la formattazione o gli oggetti interessati. La geometria dei segnaposto e lo stile ereditato possono quindi cambiare su molte slide simultaneamente. Usa [getDependingSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#getDependingSlides) per identificare le slide interessate prima di modificare il layout.

**Cosa succede se rimuovo un Layout ancora in uso?**

Aspose.Slides lancia una [PptxEditException](https://reference.aspose.com/slides/it/python-java/aspose.slides/pptxeditexception/). Riassegna prima le slide dipendenti, o usa [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) per rimuovere solo i layout non referenziati.