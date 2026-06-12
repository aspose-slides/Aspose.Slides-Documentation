---
title: Applicare o Modificare i Layout di Diapositiva in Python
linktitle: Layout di Diapositiva
type: docs
weight: 60
url: /it/python-net/slide-layout/
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
- Python
- Aspose.Slides
description: "Scopri come gestire e personalizzare i layout di diapositiva in Aspose.Slides per Python tramite .NET. Esplora i tipi di layout, il controllo dei segnaposto, la visibilità del piè di pagina e la manipolazione dei layout attraverso esempi di codice in Python."
---
## **Introduzione**

Un layout di diapositiva definisce la disposizione delle caselle segnaposto e la formattazione del contenuto di una diapositiva. Controlla quali segnaposto sono disponibili e dove appaiono. I layout di diapositiva ti aiutano a progettare presentazioni rapidamente e in modo coerente—che tu stia creando qualcosa di semplice o più complesso. Alcuni dei layout di diapositiva più comuni in PowerPoint includono:

**Layout di Diapositiva Titolo** – Include due segnaposto di testo: uno per il titolo e uno per il sottotitolo.

**Layout Titolo e Contenuto** – Presenta un segnaposto titolo più piccolo in alto e uno più grande sotto per il contenuto principale (come testo, punti elenco, grafici, immagini e altro).

**Layout Vuoto** – Non contiene segnaposto, offrendoti il pieno controllo per progettare la diapositiva da zero.

I layout di diapositiva fanno parte di un master di diapositiva, che è la diapositiva di livello superiore che definisce gli stili di layout per la presentazione. Puoi accedere e modificare i layout diapositive tramite il master di diapositiva—tramite il loro tipo, nome o ID univoco. In alternativa, puoi modificare un layout diapositive specifico direttamente nella presentazione.

Per lavorare con i layout diapositive in Aspose.Slides per Python, puoi usare:
- Proprietà come [layout_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/layout_slides/) e [masters](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/masters/) sotto la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/)
- Tipi come [LayoutSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutplaceholdermanager/), e [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Per saperne di più su come lavorare con i master di diapositiva, consulta l'articolo [Gestire i master di diapositive PowerPoint in Python](/slides/it/python-net/slide-master/).
{{% /alert %}}

## **Aggiungere Layout di Diapositive alle Presentazioni**

Per personalizzare l'aspetto e la struttura delle tue diapositive, potresti dover aggiungere nuovi layout diapositive a una presentazione. Aspose.Slides per Python ti consente di verificare se un layout specifico esiste già, aggiungerne uno nuovo se necessario e utilizzarlo per inserire diapositive basate su quel layout.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Accedi al [MasterLayoutSlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterlayoutslidecollection/).
1. Verifica se il layout diapositive desiderato esiste già nella collezione. In caso contrario, aggiungi il layout diapositive necessario.
1. Aggiungi una diapositiva vuota basata sul nuovo layout diapositive.
1. Salva la presentazione.

```python
import aspose.slides as slides

# Istanziare la classe Presentation per aprire il file della presentazione.
with slides.Presentation("sample.pptx") as presentation:
    # Scorrere i tipi di layout di diapositiva per selezionare un layout di diapositiva.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Situazione in cui la presentazione non contiene tutti i tipi di layout.
        # Il file della presentazione contiene solo i layout Blank e Custom.
        # Tuttavia, i layout diapositive con tipi personalizzati possono avere nomi riconoscibili,
        # come "Title", "Title and Content", ecc., che possono essere usati per la selezione del layout di diapositiva.
        # Puoi anche fare affidamento su un insieme di tipi di forme segnaposto.
        # Ad esempio, una diapositiva Title dovrebbe avere solo il tipo di segnaposto Title, e così via.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Aggiungere una diapositiva vuota usando il layout di diapositiva aggiunto.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Salvare la presentazione su disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Rimuovere Layout di Diapositive Non Utilizzati**

Aspose.Slides fornisce il metodo [remove_unused_layout_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) della classe [Compress](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/) per consentirti di eliminare i layout diapositive indesiderati e non utilizzati.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungere Segnaposto ai Layout di Diapositiva**

Aspose.Slides fornisce la proprietà [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutslide/placeholder_manager/) che consente di aggiungere nuovi segnaposto a un layout diapositive.

Questo gestore contiene metodi per i seguenti tipi di segnaposto:

| Segnaposto PowerPoint | Metodo [LayoutPlaceholderManager](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutplaceholdermanager/) |
| --------------------- | ------------------------------------------------------------ |
| ![Contenuto](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Contenuto (Verticale)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Testo](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Testo (Verticale)](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Immagine](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Grafico](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Tabella](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Media](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Immagine Online](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

Il seguente codice Python mostra come aggiungere nuove forme segnaposto al layout Vuoto:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Ottieni il layout di diapositiva vuoto.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Ottieni il gestore dei segnaposto del layout di diapositiva.
    placeholder_manager = layout.placeholder_manager

    # Aggiungi diversi segnaposto al layout di diapositiva vuoto.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Aggiungi una nuova diapositiva con il layout vuoto.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![I segnaposto sul layout della diapositiva](add_placeholders.png)

## **Impostare la Visibilità del Piè di Pagina per un Layout di Diapositiva**

Nelle presentazioni PowerPoint, gli elementi del piè di pagina come data, numero diapositiva e testo personalizzato possono essere mostrati o nascosti a seconda del layout della diapositiva. Aspose.Slides per Python ti consente di controllare la visibilità di questi segnaposto del piè di pagina. Questo è utile quando desideri che alcuni layout mostrino le informazioni del piè di pagina mentre altri rimangano puliti e minimali.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento al layout diapositive tramite il suo indice.
3. Imposta il segnaposto del piè di pagina della diapositiva su visibile.
4. Imposta il segnaposto del numero diapositiva su visibile.
5. Imposta il segnaposto data/ora su visibile.
6. Salva la presentazione.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **Impostare la Visibilità del Piè di Pagina Figlio per una Diapositiva**

Nelle presentazioni PowerPoint, gli elementi del piè di pagina come data, numero diapositiva e testo personalizzato possono essere controllati a livello di master per garantire coerenza su tutti i layout diapositive. Aspose.Slides per Python ti permette di impostare la visibilità e il contenuto di questi segnaposto del piè di pagina sul master e propagare queste impostazioni a tutti i layout figli. Questo approccio assicura uniformità delle informazioni del piè di pagina in tutta la presentazione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento al master della diapositiva tramite il suo indice.
3. Imposta i segnaposto del piè di pagina del master e di tutti i layout figli su visibili.
4. Imposta i segnaposto del numero diapositiva del master e di tutti i layout figli su visibili.
5. Imposta i segnaposto data/ora del master e di tutti i layout figli su visibili.
6. Salva la presentazione.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Qual è la differenza tra un master slide e un layout slide?**

Un master slide definisce il tema generale e la formattazione predefinita, mentre i layout slide definiscono disposizioni specifiche di segnaposto per diversi tipi di contenuto.

**Posso copiare un layout slide da una presentazione all'altra?**

Sì, puoi clonare un layout slide dalla collezione [layout_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/layout_slides/) di una presentazione e inserirlo in un'altra utilizzando il metodo `add_clone`.

**Cosa succede se elimino un layout slide ancora utilizzato da una diapositiva?**

Se provi a eliminare un layout slide che è ancora referenziato da almeno una diapositiva nella presentazione, Aspose.Slides genererà un'eccezione [PptxEditException](https://reference.aspose.com/slides/it/python-net/aspose.slides/pptxeditexception/). Per evitare ciò, utilizza [remove_unused_layout_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) che rimuove in modo sicuro solo i layout slide non in uso.