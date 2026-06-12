---
title: Diapositiva di layout
type: docs
weight: 20
url: /it/python-net/examples/elements/layout-slide/
keywords:
- diapositiva di layout
- aggiungi diapositiva di layout
- accedi a diapositiva di layout
- rimuovi diapositiva di layout
- diapositiva di layout inutilizzata
- clona diapositiva di layout
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Usa Python per gestire le diapositive di layout con Aspose.Slides: crea, applica, clona, rinomina e personalizza segnaposti e temi nelle presentazioni per PPT, PPTX e ODP."
---
Questo articolo dimostra come lavorare con **Layout Slides** in Aspose.Slides per Python tramite .NET. Una diapositiva di layout definisce il design e la formattazione ereditati dalle diapositive normali. È possibile aggiungere, accedere, clonare e rimuovere le diapositive di layout, nonché eliminare quelle inutilizzate per ridurre le dimensioni della presentazione.

## **Aggiungi una diapositiva di layout**

È possibile creare una diapositiva di layout personalizzata per definire una formattazione riutilizzabile.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Crea una diapositiva di layout con il tipo e il nome specificati.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Suggerimento 1:** Le diapositive di layout fungono da modelli per le diapositive individuali. È possibile definire gli elementi comuni una sola volta e riutilizzarli in molte diapositive.

> 💡 **Suggerimento 2:** Quando aggiungi forme o testo a una diapositiva di layout, tutte le diapositive basate su quel layout visualizzeranno automaticamente questo contenuto condiviso.
> Lo screenshot sottostante mostra due diapositive, ognuna delle quali eredita una casella di testo dalla stessa diapositiva di layout.

![Diapositive che ereditano contenuto di layout](layout-slide-result.png)

## **Accedi a una diapositiva di layout**

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Accesso tramite indice.
        first_layout_slide = presentation.layout_slides[0]

        # Accesso tramite tipo di layout.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Rimuovi una diapositiva di layout**

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Ottieni una diapositiva di layout per tipo e rimuovila.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Rimuovi le diapositive di layout non utilizzate**

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Rimuove automaticamente tutte le diapositive di layout non referenziate da alcuna diapositiva.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Clona una diapositiva di layout**

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Ottieni una diapositiva di layout esistente per tipo.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Clona la diapositiva di layout alla fine della collezione di diapositive di layout.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Riepilogo:** Le diapositive di layout sono strumenti potenti per gestire una formattazione coerente tra le diapositive. Aspose.Slides consente il pieno controllo su creazione, gestione e ottimizzazione delle diapositive di layout.