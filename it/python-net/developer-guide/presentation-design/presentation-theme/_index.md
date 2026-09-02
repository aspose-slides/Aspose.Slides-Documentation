---
title: Gestire i temi delle presentazioni PowerPoint in Python
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/python-net/presentation-theme/
keywords:
- Tema PowerPoint
- Tema della presentazione
- Tema della diapositiva
- Imposta tema
- Cambia tema
- Gestisci tema
- Tema esterno
- THMX
- Colore del tema
- Tavolozza aggiuntiva
- Carattere del tema
- Stile del tema
- Effetto del tema
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci i temi master delle presentazioni in Aspose.Slides per Python via .NET per creare, personalizzare e convertire file PowerPoint con un branding coerente."
---
## **Introduzione**

Un tema di presentazione definisce un insieme coordinato di colori, caratteri, stili di sfondo, riempimenti, linee ed effetti. Gli oggetti sensibili al tema fanno riferimento a queste definizioni condivise anziché memorizzare ogni proprietà visiva come valore fisso, così una modifica del tema può aggiornare molti oggetti contemporaneamente.

In Aspose.Slides, il tema a livello di presentazione è disponibile tramite la proprietà [Presentation.master_theme](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/master_theme/). Una presentazione può contenere anche sovrascritture del tema a livelli inferiori. Un master può sovrascrivere il tema della presentazione tramite [MasterThemeManager.override_theme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/masterthememanager/override_theme/), un layout può sovrascrivere il tema ereditato tramite [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), e una diapositiva individuale può fare lo stesso. In pratica, il tema effettivo per una diapositiva è risolto attraverso questa catena di ereditarietà: tema della presentazione, sovrascrittura del master, sovrascrittura del layout e sovrascrittura della diapositiva.

![Componenti del tema: colori, caratteri, stili di sfondo ed effetti](theme-constituents.png)

Le sezioni seguenti mostrano i flussi di lavoro più comuni sul tema: ispezionare un tema, modificare colori e caratteri, copiare o applicare un tema, aggiornare gli stili di sfondo ed effetti, e leggere i valori effettivi dopo che ereditarietà e sovrascritture sono state risolte.

## **Ispezionare un Tema**

L’oggetto [MasterTheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/mastertheme/) espone le proprietà [color_scheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/mastertheme/font_scheme/) e [format_scheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/mastertheme/format_scheme/). Ispezionare queste collezioni prima di modificarle è particolarmente utile quando una presentazione proviene da una fonte esterna, poiché il numero e il contenuto delle voci di stile possono variare.

L’esempio seguente legge le proprietà principali del tema e segnala quante impostazioni di sfondo, riempimento, linea ed effetto sono memorizzate nel tema:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

Se un file utilizza più master, non dare per scontato che ogni diapositiva abbia lo stesso tema effettivo. Ispeziona il master associato alla diapositiva e utilizza il flusso di lavoro sul tema efficace mostrato più avanti in questo articolo quando potrebbero essere presenti sovrascritture a livello di layout o diapositiva.

## **Modificare i Colori del Tema**

I riempimenti, le linee e il testo sensibili al tema possono fare riferimento a un colore logico presente nell’enumerazione [SchemeColor](https://reference.aspose.com/slides/it/python-net/aspose.slides/schemecolor/). Quando si modifica la voce corrispondente nella [ColorScheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/colorscheme/) del tema, tutti gli oggetti che ancora fanno riferimento a quel colore di tema sono risolti sul nuovo valore. Gli oggetti che usano un colore RGB diretto non vengono modificati da un aggiornamento del colore del tema.

L’esempio end‑to‑end seguente crea una forma che utilizza `ACCENT4`, cambia il colore `accent4` del tema in rosso, salva la presentazione, la riapre e stampa il colore di riempimento effettivo:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

Poiché il rettangolo rimane collegato a `ACCENT4`, il suo colore visibile diventa rosso dopo che il tema è stato modificato. Se si sostituisce il colore di schema con un colore diretto sulla forma, le modifiche successive a `accent4` non influenzeranno più quel riempimento.

### **Usare i Colori della Tavolozza Aggiuntiva**

PowerPoint deriva varianti più chiare e più scure da un colore del tema applicando trasformazioni colore. Aspose.Slides espone queste trasformazioni tramite l’enumerazione [ColorTransformOperation](https://reference.aspose.com/slides/it/python-net/aspose.slides/colortransformoperation/).

![Colori principali del tema e varianti più chiare e più scure generate dalla tavolozza aggiuntiva](additional-palette-colors.png)

**1** – Colori principali del tema.  
**2** – Varianti più chiare e più scure prodotte dai colori principali del tema.

L’esempio seguente crea sei rettangoli basati su `ACCENT4`, applica trasformazioni di luminanza a cinque di essi e salva il risultato:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

Queste varianti rimangono basate sul colore del tema. Se `accent4` cambia in seguito, i colori trasformati vengono ricalcolati dal nuovo valore `accent4`.

### **Mappare i Valori di `SchemeColor` negli Slot di `ColorScheme`**

L’enumerazione [SchemeColor](https://reference.aspose.com/slides/it/python-net/aspose.slides/schemecolor/) utilizza `TEXT1`, `BACKGROUND1`, `TEXT2` e `BACKGROUND2`, mentre [ColorScheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/colorscheme/) espone gli stessi slot del tema come `dark1`, `light1`, `dark2` e `light2`. La mappatura è fissa:

* `TEXT1` = `dark1`  
* `BACKGROUND1` = `light1`  
* `TEXT2` = `dark2`  
* `BACKGROUND2` = `light2`

Questi sono nomi alternativi per gli stessi slot del tema; non sono valori convertiti dinamicamente da una forma all’altra.

## **Modificare i Caratteri del Tema**

Uno schema di caratteri del tema contiene un set di caratteri principale per i titoli e un set secondario per il corpo del testo. Le proprietà [FontScheme.major](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/fontscheme/major/) e [FontScheme.minor](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/fontscheme/minor/) espongono quei set.

Gli identificatori di caratteri del tema compatibili con PowerPoint possono essere usati nella formattazione del testo:

* `+mn-lt` – Carattere del corpo Latin (Minor Latin Font)  
* `+mj-lt` – Carattere del titolo Latin (Major Latin Font)  
* `+mn-ea` – Carattere del corpo East Asian (Minor East Asian Font)  
* `+mj-ea` – Carattere del titolo East Asian (Major East Asian Font)

L’esempio seguente crea un titolo che utilizza il carattere Latin principale del tema e una riga di corpo che utilizza il carattere Latin secondario. Quindi modifica i caratteri del tema e salva il risultato:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

Il titolo segue il carattere principale e il testo del corpo segue il carattere secondario. Il testo che ha un nome di carattere esplicito invece di un identificatore del tema non cambierà automaticamente quando lo schema di caratteri del tema varia.

Le raccolte di caratteri principali e secondari possono anche contenere mappature di caratteri per singoli sistemi di scrittura, come cirilico, arabo, giapponese, georgiano e thaana. Per ispezionare, aggiungere, sostituire o rimuovere queste mappature, vedere [Script‑Specific Theme Fonts](/slides/it/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Suggerimento" %}}

Per ulteriori informazioni sui caratteri delle presentazioni, vedere [PowerPoint Fonts](/slides/it/python-net/powerpoint-fonts/).

{{% /alert %}}

## **Copiare o Applicare un Tema**

I flussi di lavoro seguenti risolvono diversi problemi legati al tema.

### **Applicare un Tema Esterno alle Diapositive Dipendenti da un Master**

Usare [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) quando si dispone di un file tema PowerPoint (`.thmx`) e si vuole riformattare ogni diapositiva che dipende da un master specifico. Selezionare il master dalla collezione [Presentation.masters](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/masters/), che implementa [MasterSlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslidecollection/), e passare il percorso del file tema al metodo.

Il metodo esegue le seguenti operazioni:

1. Crea un nuovo master slide basato sul master selezionato.  
1. Applica il tema esterno al nuovo master.  
1. Assegna il nuovo master a tutte le diapositive che in precedenza dipendevano dal master selezionato.  
1. Restituisce il nuovo [IMasterSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasterslide/).

L’esempio seguente applica un tema esterno alle diapositive che dipendono dal primo master e salva la presentazione:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Un tema non valido, corrotto o non supportato può generare una [PptxException](https://reference.aspose.com/slides/it/python-net/aspose.slides/pptxexception/) o una delle sue sottoclassi legate al formato. Convalidare i percorsi forniti dagli utenti, gestire i fallimenti di accesso al file system e salvare la presentazione solo dopo che il tema è stato applicato correttamente.

Solo le diapositive che dipendevano dal master selezionato vengono riassegnate. Le diapositive associate ad altri master mantengono i loro master e temi esistenti. I colori, i caratteri, i riempimenti, le linee, gli sfondi e gli effetti sensibili al tema vengono risolti rispetto al tema esterno. I colori, i caratteri, i riempimenti e altre formattazioni assegnate direttamente possono rimanere invariati. Le sovrascritture a livello di layout e diapositiva possono anche avere la precedenza sui valori ereditati dal nuovo master.

Il tema può fare riferimento a caratteri non disponibili nell’ambiente di runtime. Per una resa ed esportazione coerenti, installare i caratteri richiesti, fornirli tramite [custom font sources](/slides/it/python-net/custom-font/), o configurare la [font substitution](/slides/it/python-net/font-substitution/).

Questo è un flusso di lavoro diretto a livello di master: il metodo accetta un percorso di file `.thmx` e non richiede la creazione manuale di sovrascritture a livello di layout o diapositiva.

### **Applicare Temi Esterni Differenti in una Presentazione Multi‑Master**

Quando il master pertinente non è noto in anticipo, ottenerlo da una diapositiva rappresentativa tramite [Slide.layout_slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/layout_slide/) e [LayoutSlide.master_slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutslide/master_slide/). Conservare i riferimenti ai master originali prima di applicare i temi, poiché ogni chiamata crea un nuovo master nella presentazione.

L’esempio seguente utilizza diapositive di due sezioni per individuare i rispettivi master e applica un tema esterno diverso a ciascun gruppo:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

La prima chiamata influisce solo sulle diapositive che dipendevano da `first_group_master`, e la seconda solo su quelle che dipendevano da `second_group_master`. Le diapositive appartenenti a qualsiasi altro master non vengono riformattate.

### **Conservare il Tema di Origine Quando Si Spostano Diapositive**

Se si desidera spostare una diapositiva in un’altra presentazione conservandone il design originale, clonare il master di origine nella presentazione di destinazione con [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslidecollection/add_clone/), quindi clonare la diapositiva con [SlideCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/) e il master clonato. In questo modo il master, i suoi layout e il tema associato vengono trasferiti insieme.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

Questo è il flusso di lavoro consigliato quando la diapositiva di origine deve apparire identica nella destinazione. Clonare semplicemente il contenuto su un master di destinazione non correlato può modificare colori, caratteri, sfondi ed effetti determinati dal tema.

### **Applicare Valori di Tema a una Diapositiva Esistente**

Se la diapositiva di destinazione deve rimanere sul suo master e layout attuali, inizializzare una sovrascrittura a livello di diapositiva dal tema di origine. I metodi [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) e [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) copiano i tre componenti principali del tema nella sovrascrittura.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

Ciò modifica il tema usato da quella diapositiva senza alterare il tema ereditato dalle altre diapositive. Per rimuovere la sovrascrittura locale e tornare ai valori ereditati, chiamare [OverrideTheme.clear](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/overridetheme/clear/).

### **Applicare una Sovrascrittura di Tema a un Layout**

Una sovrascrittura a livello di layout si applica alle diapositive che usano quel layout, a meno che una specifica diapositiva non abbia una sua sovrascrittura. Gli stessi metodi di inizializzazione possono essere usati tramite il [LayoutSlideThemeManager](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/layoutslidethememanager/) del layout:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

Usare un tema a livello di master o di presentazione quando molti layout e diapositive devono condividere lo stesso design di base, una sovrascrittura di layout quando una famiglia di layout richiede una stilistica diversa, e una sovrascrittura di diapositiva solo per eccezioni reali. Un eccesso di sovrascritture a livello di diapositiva rende più difficile prevedere le variazioni successive del tema globale.

## **Aggiornare gli Stili di Sfondo del Tema**

Gli sfondi del tema sono memorizzati in [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint può presentare più scelte di sfondo nella sua interfaccia rispetto al numero di definizioni di riempimento effettivamente memorizzate in questa collezione, perché l’interfaccia può combinare riempimenti di tema con colori di tema e altri riferimenti di stile.

![Galleria di stili di sfondo di PowerPoint per un tema di presentazione](presentation-design_8.png)

Prima di utilizzare uno stile di sfondo, ispezionare la collezione memorizzata e l’attuale [Background.style_index](https://reference.aspose.com/slides/it/python-net/aspose.slides/background/style_index/). `style_index` utilizza `0` per nessun riempimento tematico; valori positivi sono riferimenti a stili di sfondo tematici. Questo è diverso dall’indicizzazione di una collezione Python, dove `[0]` indica il primo elemento memorizzato. Non assumere che ogni presentazione contenga lo stesso numero di stili di riempimento di sfondo.

L’esempio seguente segnala il conteggio dei riempimenti di sfondo disponibili, assegna un riferimento di sfondo tematico al primo master e salva la presentazione:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato visibile dipende dalla voce del tema a cui il master fa riferimento e da eventuali sovrascritture di sfondo a livello di layout o diapositiva. Se una diapositiva utilizza un proprio sfondo, modificare solo lo sfondo del master potrebbe non influenzare quella diapositiva. Usare [Background.get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/background/get_effective/) quando è necessario conoscere lo sfondo finale dopo l’applicazione dell’eredità.

{{% alert color="warning" title="Attenzione" %}}

Non trattare `style_index` come indice zero‑based di una collezione. Evita inoltre di codificare un numero di stile da un file e presumere che abbia lo stesso aspetto in un altro file; le definizioni di stile del tema sono specifiche della presentazione.

{{% /alert %}}

{{% alert color="info" title="Suggerimento" %}}

Per formattazione diretta dello sfondo e ereditarietà dello sfondo, vedere [Presentation Background](/slides/it/python-net/presentation-background/).

{{% /alert %}}

## **Aggiornare gli Effetti del Tema**

Uno schema di formato del tema contiene collezioni separate per [FormatScheme.fill_styles](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/formatscheme/line_styles/) e [FormatScheme.effect_styles](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/formatscheme/effect_styles/). I temi tipici di Office spesso includono tre voci principali che corrispondono visivamente a formattazioni sottili, moderate e intense, ma il codice dovrebbe ispezionare ogni collezione invece di presumere un conteggio fisso.

![Effetti del tema sottili, moderati e intensi applicati alla stessa forma](presentation-design_10.png)

Quando si accede a queste collezioni in Python, l’indice della collezione è zero‑based: `[0]` è il primo stile memorizzato e `[2]` è il terzo. Gli indici di riferimento di stile di una forma sono un concetto separato, esposti tramite [IShapeStyle](https://reference.aspose.com/slides/it/python-net/aspose.slides/ishapestyle/). Modificare uno stile del tema influisce sulle forme che lo riferiscono; le forme con formattazione diretta possono rimanere invariate.

L’esempio seguente verifica che le voci di stile richieste esistano, modifica il primo stile di linea, il terzo stile di riempimento, abilita un’ombreggiatura esterna nel terzo stile di effetto e salva il risultato:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

Per le forme che fanno riferimento a questi slot, il primo stile di linea del tema diventa rosso, il terzo stile di riempimento del tema diventa verde foresta solido, e il terzo stile di effetto acquisisce un’ombreggiatura esterna con distanza di 10 punti. Il risultato visivo esatto dipende comunque da quali slot di stile ogni forma utilizza e se una formattazione diretta sovrascrive il tema.

![Stili di effetto del tema dopo la modifica di linea, riempimento e impostazioni di ombra](presentation-design_11.png)

## **Determinare Se un Riempimento Solido Effettivo Usa un Colore del Tema**

Un riempimento può essere memorizzato direttamente su un oggetto o ereditato da un paragrafo, layout, master, stile del tema o un altro livello di formattazione. Chiamare [FillFormat.get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/fillformat/get_effective/) per risolvere quella gerarchia in un oggetto immutabile [IFillFormatEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/ifillformateffectivedata/). Prima verificare [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Solo quando è `FillType.SOLID` si devono leggere le proprietà del riempimento solido.

Per un riempimento solido, [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) restituisce il valore RGB finale dopo ereditarietà, ricerca nel tema e applicazione delle trasformazioni colore. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) restituisce lo slot logico corrispondente di [SchemeColor](https://reference.aspose.com/slides/it/python-net/aspose.slides/schemecolor/), come `TEXT1` o `ACCENT6`. Un valore `SchemeColor.NOT_DEFINED` indica che il riempimento solido effettivo non si basa su un colore di schema. In un flusso di lavoro dove i riempimenti sono o colori di tema o colori RGB diretti, questo valore identifica un riempimento RGB diretto.

Non utilizzare soltanto il valore locale [IColorFormat.scheme_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/icolorformat/scheme_color/) per classificare un riempimento. Per esempio, una porzione di testo può non avere un colore di schema definito localmente, quindi il suo valore locale è `NOT_DEFINED`, mentre il suo riempimento effettivo eredita un colore di tema e si risolve in `TEXT1` o `ACCENT6`. Al contrario, `solid_fill_scheme_color` indica quale slot logico del tema ha prodotto il colore effettivo, ma non specifica se quello slot proviene dall’oggetto, dal paragrafo, dal layout, dal master o da un altro livello della gerarchia di formattazione.

L’esempio seguente carica una presentazione, verifica i riempimenti di forme e di porzioni di testo, stampa ogni valore RGB finale e il colore di schema associato, e segna i riempimenti solidi che non seguiranno le modifiche ai colori del tema:

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

Il ramo `NOT_DEFINED` fornisce un elenco di audit di riempimenti solidi che non risponderanno a cambiamenti negli slot di colore del tema. Revisionare quegli oggetti quando una presentazione deve adeguarsi a una nuova tavolozza di brand. Il valore RGB segnalato mostra ancora l’aspetto corrente, mentre il valore di schema spiega se tale aspetto è collegato al tema.

Gli oggetti di formato effettivo sono istantanee. Dopo aver modificato il tema della presentazione, una sovrascrittura di tema, o qualsiasi formattazione ereditata, chiamare nuovamente `get_effective` e leggere un nuovo oggetto `IFillFormatEffectiveData` prima di confrontare o segnalare i colori.

## **Leggere i Valori Effettivi del Tema**

Gli oggetti tema grezzi indicano ciò che è definito a un determinato livello. I valori effettivi indicano ciò che una diapositiva o una forma utilizza realmente dopo l’eredità e le sovrascritture locali. Per una diapositiva, chiamare [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Per uno sfondo, usare [Background.get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/background/get_effective/), e per un riempimento, usare [FillFormat.get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/fillformat/get_effective/).

L’esempio seguente legge il tema effettivo, lo sfondo e il primo riempimento della forma da una diapositiva:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

Utilizzare i dati effettivi per diagnostica di rendering, convalida e confronti. Se si ispeziona solo [Presentation.master_theme](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/master_theme/), si possono trascurare master, layout, diapositive o sovrascritture di forma che modificano l’aspetto finale.

## **FAQ**

**L’applicazione di un tema esterno influisce su ogni diapositiva della presentazione?**

No. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) riassegna solo le diapositive che dipendono dal master selezionato. Le diapositive che usano altri master conservano i loro temi esistenti.

**Posso applicare un tema a una singola diapositiva senza modificare il master?**

Sì. Utilizzare il [SlideThemeManager](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/slidethememanager/) della diapositiva e inizializzare la sua sovrascrittura di tema. La modifica rimane locale a quella diapositiva; le altre diapositive continuano a ereditare i loro temi attuali.

**Qual è il modo più sicuro per trasferire un tema da una presentazione all’altra?**

Quando si sposta una diapositiva e si conserva il design di origine, clonare il master di origine nella destinazione e clonare la diapositiva con quel master usando [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslidecollection/add_clone/) e [SlideCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/). In questo modo il master, i layout e il tema rimangono insieme.

**Come posso vedere i valori effettivi dopo l’eredità e le sovrascritture?**

Usare [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) per un tema di diapositiva o layout e i metodi corrispondenti per i dati effettivi di oggetti di formato, come [Background.get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/background/get_effective/) e [FillFormat.get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/fillformat/get_effective/). Queste API restituiscono i valori risolti dopo l’applicazione di ereditarietà e sovrascritture.