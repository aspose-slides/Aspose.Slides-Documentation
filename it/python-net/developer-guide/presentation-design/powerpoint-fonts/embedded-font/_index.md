---
title: Incorpora i font nelle presentazioni con Python
linktitle: Incorporamento font
type: docs
weight: 40
url: /it/python-net/embedded-font/
keywords:
- aggiungere font
- incorporare font
- incorporazione font
- ottenere font incorporato
- aggiungere font incorporato
- rimuovere font incorporato
- comprimere font incorporato
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Incorpora i font TrueType nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python tramite .NET, garantendo un rendering accurato su tutte le piattaforme."
---
## **Introduzione**

**Incorporare i caratteri in PowerPoint** garantisce che la presentazione mantenga l'aspetto previsto su sistemi diversi. Sia che si utilizzino caratteri unici per creatività o standard, l'incorporamento dei font evita interruzioni di testo e layout.

Se hai usato un font di terze parti o non standard perché hai voluto essere creativo nel tuo lavoro, hai ancora più motivi per incorporare il font. Altrimenti (senza font incorporati), i testi o i numeri nelle diapositive, il layout, lo stile, ecc. possono cambiare o trasformarsi in rettangoli confusi. 

Utilizza le classi [FontsManager](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontdata/), e [Compress](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/) per gestire i font incorporati.

## **Recuperare e Rimuovere i Font Incorporati**

Recupera o rimuovi i font incorporati da una presentazione senza sforzo con i metodi [get_embedded_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) e [remove_embedded_font](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Questo codice Python mostra come recuperare e rimuovere i font incorporati da una presentazione:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Rendering della diapositiva che contiene un frame di testo che utilizza il font incorporato 'FunSized'.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Ottieni tutti i font incorporati.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Trova il font 'Calibri'.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Rimuovi il font 'Calibri'.
    fonts_manager.remove_embedded_font(font_data)

    # Rendering della diapositiva; il font 'Calibri' sarà sostituito con uno esistente.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Salva la presentazione senza il font 'Calibri' incorporato su disco.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Aggiungere Font Incorporati**

Utilizzando l'enumerazione [EmbedFontCharacters](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/embedfontcharacters/) e due overload del metodo [add_embedded_font](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/add_embedded_font/), puoi selezionare la regola di incorporamento preferita per inserire i font in una presentazione. Questo codice Python mostra come incorporare e aggiungere font a una presentazione:

```python
import aspose.slides as slides

# Carica una presentazione.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Salva la presentazione su disco.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprimere i Font Incorporati**

Ottimizza la dimensione del file comprimendo i font incorporati usando [compress_embedded_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Esempio di codice per la compressione:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Come posso capire se un carattere specifico nella presentazione verrà comunque sostituito durante il rendering nonostante l'incorporamento?**

Controlla le [informazioni di sostituzione](/slides/it/python-net/font-substitution/) nel gestore dei font e le [regole di fallback/sostituzione](/slides/it/python-net/fallback-font/): se il font non è disponibile o è limitato, verrà utilizzato un fallback.

**Vale la pena incorporare i font di "sistema" come Arial/Calibri?**

Di solito no—sono quasi sempre disponibili. Tuttavia, per la massima portabilità in ambienti "leggeri" (Docker, un server Linux senza font preinstallati), incorporare i font di sistema può eliminare il rischio di sostituzioni inaspettate.