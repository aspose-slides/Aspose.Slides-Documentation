---
title: Gestire i segnaposti nelle presentazioni con Python
linktitle: Gestire i segnaposti
type: docs
weight: 10
url: /it/python-net/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- testo di prompt
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Gestisci senza sforzo i segnaposti in Aspose.Slides per Python tramite .NET: sostituisci testo, personalizza i prompt e imposta la trasparenza dell'immagine in PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di gestire i segnaposti delle presentazioni programmaticamente. Questo articolo spiega come trovare i segnaposti nelle diapositive e modificare il loro testo, impostare un testo di prompt personalizzato per i layout dei segnaposti e regolare la trasparenza di un'immagine usata come sfondo del segnaposto. Include anche una breve FAQ che chiarisce la differenza tra segnaposti di base e forme locali, spiega come le modifiche ai segnaposti possono essere applicate tramite layout o master e indica la gestione dei segnaposti di intestazione e piè di pagina.

## **Modifica del testo nei segnaposti**

Utilizzando Aspose.Slides per Python, è possibile trovare e modificare i segnaposti nelle diapositive di una presentazione. Aspose.Slides consente di modificare il testo in un segnaposto.

**Prerequisito:** È necessaria una presentazione che contenga un segnaposto. È possibile creare tale presentazione con Microsoft PowerPoint.

Ecco come utilizzare Aspose.Slides per sostituire il testo in un segnaposto:

1. Istanziare la classe [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e passare la presentazione come argomento.
1. Ottenere un riferimento alla diapositiva per indice.
1. Iterare tra le forme per trovare il segnaposto.
1. Modificare il testo utilizzando il [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) associato all'[AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/).
1. Salvare la presentazione modificata.

Questo codice Python mostra come modificare il testo in un segnaposto:

```python
import aspose.slides as slides

# Istanziare la classe Presentation.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # Accedere alla prima diapositiva.
    slide = presentation.slides[0]

    # Iterare tra le forme per trovare i segnaposti.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Cambiare il testo in ogni segnaposto.
            shape.text_frame.text = "This is Placeholder"

    # Salvare la presentazione su disco.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta il testo di prompt per un segnaposto**

I layout standard e predefiniti includono il testo di prompt del segnaposto come **Fare clic per aggiungere un titolo** o **Fare clic per aggiungere un sottotitolo**. Con Aspose.Slides, è possibile sostituire questi prompt con il proprio testo nei layout dei segnaposti.

Il seguente esempio Python mostra come impostare il testo di prompt per un segnaposto:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Iterare tra le forme per trovare i segnaposti.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la trasparenza dell'immagine in un segnaposto**

 Aspose.Slides consente di impostare la trasparenza di un'immagine di sfondo in un segnaposto di testo. Regolando la trasparenza dell'immagine in quel frame, è possibile far risaltare il testo o l'immagine, a seconda dei loro colori.

Il seguente esempio Python mostra come impostare la trasparenza di un'immagine di sfondo all'interno di una forma:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **FAQ**

**Cos'è un segnaposto di base e in che modo differisce da una forma locale su una diapositiva?**

Un segnaposto di base è la forma originale su un layout o master da cui la forma della diapositiva eredita—tipo, posizione e parte della formattazione provengono da essa. Una forma locale è indipendente; se non esiste un segnaposto di base, l'ereditarietà non si applica.

**Come posso aggiornare tutti i titoli o le didascalie in tutta la presentazione senza iterare su ogni diapositiva?**

Modificare il segnaposto corrispondente sul layout o sul master. Le diapositive basate su quei layout/master erediteranno automaticamente la modifica.

**Come controllare i segnaposti standard di intestazione/piè di pagina—data e ora, numero diapositiva e testo del piè di pagina?**

Utilizzare i gestori HeaderFooter nello scopo appropriato (diapositive normali, layout, master, note/volantini) per attivare o disattivare tali segnaposti e impostarne il contenuto.