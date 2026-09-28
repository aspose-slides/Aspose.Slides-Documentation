---
title: Applica o modifica layout diapositive in Python tramite Java
linktitle: Layout diapositiva
type: docs
weight: 60
url: /it/python-java/slide-layout/
keywords:
- layout diapositiva
- layout contenuto
- segnaposto
- progettazione presentazione
- progettazione diapositiva
- layout inutilizzato
- visibilità piè di pagina
- diapositiva titolo
- titolo e contenuto
- intestazione sezione
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
description: "Applica, crea e modifica i layout diapositive in Aspose.Slides per Python tramite Java, aggiungi segnaposto, rimuovi layout inutilizzati e controlla la visibilità del piè di pagina."
---
## **Panoramica**

Un layout di diapositiva definisce le posizioni e la formattazione dei segnaposto come titoli, testo, immagini, grafici e tabelle. Applicare un layout conferisce alle diapositive una struttura coerente consentendo al contempo a ciascuna diapositiva di contenere il proprio contenuto.

I layout più comuni includono:

- **Titolo diapositiva**: contiene segnaposto per titolo e sottotitolo.
- **Titolo e contenuto**: contiene un segnaposto per il titolo e un segnaposto di contenuto di uso generale.
- **Vuota**: non contiene segnaposto di contenuto ed è utile quando ogni forma verrà posizionata manualmente.

## **Comprendere l'ereditarietà dei layout**

Una presentazione ha tre livelli correlati:

1. Un [master slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/) definisce il tema, la formattazione condivisa, gli sfondi e gli oggetti comuni.
2. Un [layout slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/) appartiene a un master e definisce una particolare disposizione dei segnaposto.
3. Una [normal slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/) utilizza un layout e memorizza il contenuto inserito per quella diapositiva.

Una normal slide eredita tema e formattazione dal proprio layout, e il layout eredita dal master. Un valore impostato direttamente su una normal slide sovrascrive il valore ereditato a quel livello. Quando una normal slide viene creata, le forme dei segnaposto sono generate dal layout selezionato, mentre il contenuto inserito in quei segnaposto appartiene alla normal slide.

Aggiungi i segnaposto richiesti a un layout prima di creare diapositive da esso. L'aggiunta successiva di un altro segnaposto a un layout non aggiunge automaticamente una forma segnaposto corrispondente alle normal slide esistenti.

Questa relazione ha due conseguenze importanti:

- Modificare la formattazione ereditata o la geometria dei segnaposto esistenti su un layout può aggiornare ogni diapositiva che dipende da esso. Prima di modificare un layout già in uso, ispeziona le diapositive dipendenti e rivedi la presentazione risultante.
- Un layout ancora utilizzato da una diapositiva non può essere rimosso. Riassegna prima le diapositive dipendenti a un altro layout, o rimuovi solo i layout non utilizzati.

Per ulteriori informazioni sul livello superiore di questa gerarchia, vedere [Slide Master](/slides/it/python-java/slide-master/).

Per nascondere i loghi ereditati o le forme decorative del master su una diapositiva o tramite un layout condiviso, vedere [Control the Visibility of Master Graphics](/slides/it/python-java/slide-master/). L'esempio confronta due diapositive che utilizzano lo stesso master.

## **Selezionare e applicare un layout di diapositiva**

Utilizza un tipo di layout quando la presentazione segue le definizioni standard dei layout di PowerPoint. I nomi dei layout sono modificabili dall'utente e possono essere localizzati, quindi la selezione basata sul nome è meno affidabile a meno che non si controlli il modello di origine.

L'esempio seguente cerca **Titolo e contenuto** sul primo master. Se quel layout non è disponibile, ricade deliberatamente su **Vuota**. Il secondo controllo per `None` è necessario perché una presentazione può contenere solo layout personalizzati. Il layout selezionato viene quindi applicato alla prima normal slide tramite il metodo [Slide.setLayoutSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#setLayoutSlide).

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

Modificare il layout di una diapositiva non rimuove le forme ordinarie aggiunte direttamente alla diapositiva. Tuttavia, le posizioni dei segnaposto, la formattazione ereditata e la corrispondenza tra i segnaposto esistenti e il nuovo layout possono cambiare, quindi verifica l'output quando passi da layout sostanzialmente diversi.

## **Aggiungere una diapositiva di layout**

Selezione e creazione sono operazioni separate. L'esempio precedente seleziona un layout esistente; non ne crea uno. Per creare un layout, chiama il metodo [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterlayoutslidecollection/#add) sulla collezione di layout del master di destinazione.

L'esempio seguente aggiunge sempre un nuovo layout **Titolo e contenuto** denominato `Report Title and Content`, quindi aggiunge una normal slide basata su di esso. I nomi dei layout devono essere unici all'interno della collezione.

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

Aggiungi un layout solo quando il modello necessita realmente di un'altra struttura riutilizzabile. Se esiste già un layout adatto, selezionalo e riutilizzalo invece di crearne uno duplicato.

## **Aggiungere segnaposto a una diapositiva di layout**

Il metodo [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#getPlaceholderManager) fornisce un [LayoutPlaceholderManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/) per aggiungere forme segnaposto a un layout.

| Segnaposto PowerPoint | [LayoutPlaceholderManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/) Metodo |
| ---------------------- | ----------------------------------- |
| ![Contenuto](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Contenuto (Verticale)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Testo](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Testo (Verticale)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Immagine](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Grafico](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabella](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Immagine online](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

L'esempio seguente verifica che il layout **Vuota** esista, aggiunge quattro segnaposto a esso e quindi crea una normal slide che utilizza il layout modificato. L'ordine è intenzionale: i segnaposto vengono aggiunti prima che la normal slide sia creata, così Aspose.Slides può generare le forme segnaposto corrispondenti su quella diapositiva.

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

![I segnaposto sulla diapositiva di layout](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modificare la formattazione ereditata o la geometria dei segnaposto di layout esistenti può influire sulle diapositive dipendenti. Un segnaposto di layout appena aggiunto non viene retrofittato nelle normal slide esistenti. Prova le modifiche al layout su una copia della presentazione e ispeziona ogni diapositiva dipendente.
{{% /alert %}}

## **Rimuovere layout diapositive non utilizzati**

Utilizza il metodo [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) per rimuovere i layout a cui nessuna normal slide fa riferimento. Il metodo lascia intatti i layout ancora in uso.

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

Per rimuovere un layout specifico, usa prima il suo metodo [hasDependingSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#hasDependingSlides) o [getDependingSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#getDependingSlides). Riassegna le eventuali diapositive dipendenti prima di chiamare [LayoutSlide.remove](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#remove). Tentare di rimuovere un layout in uso genera una [PptxEditException](https://reference.aspose.com/slides/it/python-java/aspose.slides/pptxeditexception/).

## **Controllare la visibilità del piè di pagina su una diapositiva di layout**

Un layout ha i propri segnaposto per piè di pagina, numero diapositiva e data/ora. Usa il metodo [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) per controllare questi segnaposto per un singolo layout. Questo è utile quando, ad esempio, i layout di contenuto dovrebbero mostrare i piè di pagina ma i layout di titolo no.

L'esempio seguente seleziona in modo sicuro un layout e rende visibili gli elementi del piè di pagina:

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

## **Controllare la visibilità del piè di pagina su un master e i suoi layout figli**

Per applicare impostazioni di piè di pagina coerenti su un'intera gerarchia di master, utilizza il metodo [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#getHeaderFooterManager). I metodi di propagazione di [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslideheaderfootermanager/) operano sul master e sulle sue diapositive di layout dipendenti e su quelle normali; non si applicano a una sola normal slide.

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

**Qual è la differenza tra un Master Slide e un Layout Slide?**

Un master slide definisce il tema della presentazione e la formattazione condivisa. Un layout slide appartiene a un master e definisce una disposizione riutilizzabile di segnaposto. Le normal slide utilizzano quei layout e memorizzano il contenuto specifico della diapositiva.

**Posso copiare un Layout Slide da una presentazione a un'altra?**

Sì. Aggiungi una copia alla collezione di destinazione con il metodo [addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/globallayoutslidecollection/#addClone). Quando copi tra presentazioni, verifica anche i caratteri, i temi, le immagini e le altre risorse utilizzate dal layout di origine.

**Cosa succede se modifico un layout già in uso?**

Le diapositive dipendenti ereditano le modifiche al layout a meno che non sovrascrivano localmente la formattazione o gli oggetti interessati. La geometria dei segnaposto e lo stile ereditato possono quindi cambiare su molte diapositive contemporaneamente. Usa [getDependingSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#getDependingSlides) per identificare le diapositive interessate prima di modificare il layout.

**Cosa succede se rimuovo un layout ancora in uso?**

Aspose.Slides genera una [PptxEditException](https://reference.aspose.com/slides/it/python-java/aspose.slides/pptxeditexception/). Riassegna prima le diapositive dipendenti, oppure utilizza [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) per rimuovere solo i layout non referenziati.