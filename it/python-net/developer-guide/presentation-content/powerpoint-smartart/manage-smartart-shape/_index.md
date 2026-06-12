---
title: Gestire le grafiche SmartArt nelle presentazioni usando Python
linktitle: Grafica SmartArt
type: docs
weight: 20
url: /it/python-net/manage-smartart-shape/
keywords:
- oggetto SmartArt
- grafica SmartArt
- stile SmartArt
- colore SmartArt
- creare SmartArt
- aggiungere SmartArt
- modificare SmartArt
- cambiare SmartArt
- accedere a SmartArt
- tipo di layout SmartArt
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Automatizza la creazione, la modifica e lo styling di SmartArt in PowerPoint con Python tramite .NET usando Aspose.Slides, con esempi di codice concisi e linee guida incentrate sulle prestazioni."
---
## **Panoramica**

Aspose.Slides ti consente di creare e gestire grafiche SmartArt nelle presentazioni PowerPoint in modo programmatico. Questo articolo spiega come aggiungere una forma SmartArt a una diapositiva, accedere alle forme SmartArt esistenti, trovare SmartArt per un tipo di layout specifico e aggiornare il suo aspetto visivo modificando lo stile SmartArt o lo stile colore.

Gli esempi mostrano come lavorare con le forme SmartArt attraverso la collezione di forme della diapositiva della presentazione, verificare se una forma è SmartArt e quindi modificare o ispezionare le sue proprietà.

## **Creare forme SmartArt**

Aspose.Slides per Python tramite .NET consente di aggiungere forme SmartArt personalizzate alle diapositive da zero. L'API rende questo semplice. Per aggiungere una forma SmartArt a una diapositiva:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni la diapositiva di destinazione per indice.
3. Aggiungi una forma SmartArt, specificando il suo tipo di layout.
4. Salva la presentazione modificata come file PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Istanziare la classe Presentation.
with slides.Presentation() as presentation:
    # Accedere alla diapositiva della presentazione.
    slide = presentation.slides[0]
    # Aggiungere una forma SmartArt.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Salvare la presentazione su disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedere a forme SmartArt sulle diapositive**

Il codice seguente dimostra come accedere alle forme SmartArt su una diapositiva. Il campione itera attraverso ogni forma sulla diapositiva e verifica se è un oggetto [SmartArt](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartart/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Carica un file di presentazione.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Itera attraverso ogni forma nella prima diapositiva.
    for shape in presentation.slides[0].shapes:
        # Verifica se la forma è una forma SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Stampa il nome della forma.
            print("Shape name:", shape.name)
```

## **Accedere a forme SmartArt con un tipo di layout specificato**

L'esempio seguente mostra come accedere a una forma SmartArt con un tipo di layout specificato. Nota che non è possibile modificare il tipo di layout di una SmartArt: è di sola lettura e viene impostato quando la forma viene creata.

1. Crea un'istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica la presentazione che contiene la forma SmartArt.
2. Ottieni un riferimento alla prima diapositiva per indice.
3. Itera su ogni forma nella prima diapositiva.
4. Verifica se la forma è un oggetto [SmartArt](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartart/).
5. Se il tipo di layout della forma SmartArt corrisponde a quello necessario, esegui le azioni richieste.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Itera attraverso ogni forma nella prima diapositiva.
    for shape in presentation.slides[0].shapes:
        # Verifica se la forma è una forma SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Verifica il tipo di layout SmartArt.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **Modificare lo stile della forma SmartArt**

L'esempio seguente mostra come individuare le forme SmartArt e modificarne lo stile:

1. Crea un [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica il file che contiene le forme SmartArt.
2. Ottieni un riferimento alla prima diapositiva per indice.
3. Itera su ogni forma nella prima diapositiva.
4. Trova la forma SmartArt con lo stile specificato.
5. Assegna il nuovo stile alla forma SmartArt.
6. Salva la presentazione.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Itera attraverso ogni forma nella prima diapositiva.
    for shape in presentation.slides[0].shapes:
        # Verifica se la forma è una forma SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Verifica lo stile SmartArt.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Modifica lo stile SmartArt.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Salva la presentazione.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Modificare lo stile colore delle forme SmartArt**

Questo esempio mostra come modificare lo stile colore di una forma SmartArt. Il codice di esempio individua una forma SmartArt con uno stile colore specificato e la aggiorna.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica la presentazione che contiene le forme SmartArt.
2. Ottieni un riferimento alla prima diapositiva per indice.
3. Itera su ogni forma nella prima diapositiva.
4. Verifica se la forma è un oggetto [SmartArt](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartart/).
5. Individua la forma SmartArt con lo stile colore specificato.
6. Imposta il nuovo stile colore per quella forma SmartArt.
7. Salva la presentazione.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Itera attraverso ogni forma nella prima diapositiva.
    for shape in presentation.slides[0].shapes:
        # Verifica se la forma è una forma SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Verifica il tipo di colore.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Modifica il tipo di colore.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Salva la presentazione.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso animare SmartArt come un unico oggetto?**

Sì. SmartArt è una forma, quindi puoi applicare le [animazioni standard](/slides/it/python-net/powerpoint-animation/) tramite l'API di animazione (entrata, uscita, enfatizzazione, percorsi di movimento) proprio come per le altre forme.

**Come posso trovare una SmartArt specifica su una diapositiva se non conosco il suo ID interno?**

Imposta e utilizza il Testo alternativo (AltText) e cerca la forma per quel valore—questo è il modo consigliato per individuare la forma target.

**Posso raggruppare SmartArt con altre forme?**

Sì. Puoi raggruppare SmartArt con altre forme (immagini, tabelle, ecc.) e poi [manipolare il gruppo](/slides/it/python-net/group/).

**Come ottengo un'immagine di una SmartArt specifica (ad esempio per un'anteprima o un rapporto)?**

Esporta una miniatura/immagine della forma; la libreria può [renderizzare forme individuali](/slides/it/python-net/create-shape-thumbnails/) in file raster (PNG/JPG/TIFF).

**L'aspetto di SmartArt sarà preservato quando si converte l'intera presentazione in PDF?**

Sì. Il motore di rendering punta a un'alta fedeltà per l'[esportazione PDF](/slides/it/python-net/convert-powerpoint-to-pdf/), con una gamma di opzioni di qualità e compatibilità.