---
title: Incorporare i Font nelle Presentazioni con Python
linktitle: Font Incorporati
type: docs
weight: 40
url: /it/python-net/embedded-font/
keywords:
- aggiungere font
- incorporare font
- incorporamento dei font
- ottenere font incorporato
- aggiungere font incorporato
- rimuovere font incorporato
- comprimere font incorporato
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Gestisci i font incorporati in PowerPoint con Aspose.Slides for Python via .NET. Usa Python per aggiungere, recuperare, rimuovere e comprimere i font per preservare l'aspetto del testo e ridurre le dimensioni del file."
---
## **Introduzione**

L'incorporamento dei caratteri memorizza i dati del carattere all'interno di una presentazione PowerPoint. Quando un visualizzatore supporta i caratteri incorporati, può visualizzare il testo usando tali caratteri anche se non sono installati sul sistema di destinazione. Questo aiuta a preservare le interruzioni di riga, la spaziatura del testo e il layout delle diapositive.

Aspose.Slides for Python via .NET consente di recuperare, aggiungere e rimuovere caratteri incorporati tramite la proprietà [fonts_manager](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/fonts_manager/) di un oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/). È inoltre possibile ridurre le dimensioni dei dati dei caratteri incorporati rimuovendo i caratteri non utilizzati nella presentazione.

Gli esempi seguenti funzionano con file PPTX. Prima di incorporare un carattere, assicurati che i suoi dati siano disponibili per Aspose.Slides e che la sua licenza ne consenta l'incorporamento.

## **Ottenere e Rimuovere i Font Incorporati**

Utilizza [get_embedded_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) per elencare i font memorizzati in una presentazione. Per rimuoverne uno, passa un font da tale elenco a [remove_embedded_font](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/remove_embedded_font/), quindi salva la presentazione.

Il seguente esempio elenca i font incorporati in `EmbeddedFonts.pptx` e rimuove Calibri se presente:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

Rimuovere un font incorporato elimina i dati del font memorizzati; non modifica il font assegnato al testo. Se il font è installato sul sistema di destinazione, il testo può comunque usarlo. Altrimenti, il rendering potrebbe richiedere la [sostituzione dei font](/slides/it/python-net/font-substitution/), il che può influire sul layout.

## **Ispezionare i Dati del Font e le Autorizzazioni di Incorporamento**

Utilizza la classe [FontsManager](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/) per ispezionare i font prima di incorporarli. Chiama [get_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_fonts/) per recuperare i font utilizzati nella presentazione. Per ciascun font, passa un oggetto [FontData](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontdata/) e il valore di [FontStyleType](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontstyletype/) richiesto a [get_font_bytes](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_font_bytes/). Il metodo restituisce i dati binari per quello stile di font, o `None` quando il font o lo stile richiesto non è disponibile. Non passare un risultato `None` a [get_font_embedding_level](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_font_embedding_level/), poiché quel metodo richiede un array di byte.

[EmbeddingLevel](https://reference.aspose.com/slides/it/python-net/aspose.slides/embeddinglevel/) è un'enumerazione a flag che riporta le restrizioni di incorporamento memorizzate nel font:

- `INSTALLABLE` consente l'incorporamento e l'installazione permanente su un altro sistema, soggetto alla licenza del font.
- `RESTRICTED` vieta l'incorporamento a meno che non si ottenga l'autorizzazione dal proprietario legale del font quando è l'unico flag di permesso d'uso.
- `PREVIEW_PRINT` consente l'uso temporaneo per la visualizzazione e la stampa; un documento contenente il font deve essere di sola lettura.
- `EDITABLE` consente l'uso temporaneo e permette al documento di essere modificato e salvato.
- `NO_SUBSETTING` è una restrizione aggiuntiva che vieta l'incorporamento di solo un sottoinsieme di glifi. Incorpora tutti i caratteri quando questo flag è presente.
- `BITMAP_ONLY` è una restrizione aggiuntiva che consente di incorporare solo bitmap, non dati di contorno. Se il font non dispone di bitmap, non può essere incorporato.

I primi quattro valori descrivono il permesso d'uso, mentre `NO_SUBSETTING` e `BITMAP_ONLY` possono essere combinati con essi. Controlla i modificatori con operazioni bitwise. Poiché `INSTALLABLE` è zero, maschera i bit di permesso d'uso e confronta il risultato con `INSTALLABLE`. I font attuali dovrebbero impostare al massimo un bit di permesso d'uso. Per compatibilità con font più vecchi che impostano più di un bit, l'helper riportato di seguito seleziona il permesso meno restrittivo: `EDITABLE`, poi `PREVIEW_PRINT`, poi `RESTRICTED`.

Il seguente esempio verifica i dati regolari, grassetto, corsivo e grassetto-corsivo disponibili per ogni font restituito da `get_fonts`. Salta gli stili non disponibili, i font limitati, i font solo bitmap, i font limitati a anteprima e stampa perché l'output rimane modificabile, e i font già incorporati. Se qualche stile disponibile ha `NO_SUBSETTING`, incorpora tutti i caratteri per quella famiglia di font.

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Questa ispezione riporta le restrizioni codificate in ciascun file di font. Non concede una licenza, non dimostra che tu abbia ottenuto legalmente il font, né sostituisce il controllo dell'accordo di licenza del font prima di distribuire una copia incorporata.

## **Aggiungere Font Incorporati**

Utilizza [add_embedded_font](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/add_embedded_font/) per incorporare un font. Le sue sovraccariche accettano sia un oggetto [FontData](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontdata/) sia un array di byte contenente i dati del font. L'enumerazione [EmbedFontCharacters](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/embedfontcharacters/) controlla quali caratteri vengono inclusi:

- [ALL](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/embedfontcharacters/) incorpora tutti i caratteri del font. Usa questa opzione quando i destinatari devono modificare la presentazione e inserire nuovo testo.
- [ONLY_USED](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/embedfontcharacters/) incorpora solo i caratteri usati nella presentazione per ridurre le dimensioni del file. Scegli questa opzione per una presentazione finale destinata principalmente alla visualizzazione.

Il seguente esempio utilizza [get_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_fonts/) per recuperare i font usati in `Fonts.pptx` e incorpora quelli non ancora incorporati. I font da aggiungere devono essere disponibili sulla macchina che esegue il codice. I font già incorporati mantengono i loro set di caratteri attuali.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprimere Font Incorporati**

[compress_embedded_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) riduce i dati dei font incorporati rimuovendo i caratteri non utilizzati. Funziona su font già incorporati, quindi la riduzione delle dimensioni dipende da quanti dati di font non usati contiene la presentazione.

Il seguente esempio comprime i font in `EmbeddedFonts.pptx` e salva il risultato in un file separato:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Conserva il file originale se i destinatari potrebbero dover aggiungere testo in seguito. I caratteri rimossi durante la compressione non sono più disponibili dal font incorporato, anche se inizialmente hai incorporato tutti i caratteri.

## **FAQ**

**Come posso verificare se un font incorporato verrà comunque sostituito durante il rendering?**

Chiama [get_substitutions](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_substitutions/) nell'ambiente in cui renderizzi la presentazione per vedere quali font Aspose.Slides sostituirà. Controlla anche le impostazioni di [sostituzione dei font](/slides/it/python-net/font-substitution/) e le regole di [fallback dei font](/slides/it/python-net/fallback-font/). Il fallback gestisce i caratteri mancanti, quindi incorporare un font non risolve i caratteri che il font stesso non contiene.

**Devo incorporare font comuni come Arial e Calibri?**

Base la decisione sull'ambiente di destinazione. Se i font richiesti sono disponibili su ogni macchina che apre o rende la presentazione, incorporarli potrebbe aumentare inutilmente le dimensioni del file. Se i destinatari o i server potrebbero non avere tali font, incorporarli può aiutare a preservare l'aspetto previsto, a condizione che le loro licenze lo consentano.