---
title: Incorporare caratteri nelle presentazioni in Python via Java
linktitle: Caratteri incorporati
type: docs
weight: 40
url: /it/python-java/embedded-font/
keywords:
- aggiungi font
- incorpora font
- incorporamento dei font
- recupera font incorporato
- aggiungi font incorporato
- rimuovi font incorporato
- comprimi font incorporato
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Gestisci i caratteri incorporati in PowerPoint con Aspose.Slides per Python via Java. Aggiungi, recupera, rimuovi e comprimi i caratteri per preservare l’aspetto del testo e ridurre le dimensioni del file."
---
## **Introduzione**

L’incorporamento dei caratteri memorizza i dati del carattere all’interno di una presentazione PowerPoint. Quando un visualizzatore supporta i caratteri incorporati, può visualizzare il testo utilizzando tali caratteri anche se non sono installati sul sistema di destinazione. Questo aiuta a preservare le interruzioni di riga, la spaziatura del testo e il layout delle diapositive.

Aspose.Slides for Python via Java consente di recuperare, aggiungere e rimuovere i caratteri incorporati tramite la classe [FontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/) restituita da [Presentation.getFontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getFontsManager). È inoltre possibile ridurre le dimensioni dei dati dei caratteri incorporati rimuovendo i caratteri che la presentazione non utilizza.

Gli esempi seguenti funzionano con file PPTX. Prima di incorporare un carattere, assicurarsi che i dati del carattere siano disponibili per Aspose.Slides e che la licenza consenta l’incorporamento.

## **Ottieni e rimuovi i caratteri incorporati**

Utilizza [getEmbeddedFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) per elencare i caratteri memorizzati in una presentazione. Per rimuoverne uno, passa un carattere da quell’elenco a [removeEmbeddedFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont), quindi salva la presentazione.

L’esempio seguente elenca i caratteri incorporati in `EmbeddedFonts.pptx` e rimuove Calibri se presente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

Rimuovere un carattere incorporato elimina i dati del carattere memorizzati; non modifica il carattere assegnato al testo. Se il carattere è installato sul sistema di destinazione, il testo può comunque utilizzarlo. Altrimenti, il rendering potrebbe richiedere la sostituzione del carattere, il che può influire sul layout.

## **Ispeziona i dati del carattere e i permessi di incorporamento**

Usa la classe [FontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/) per esaminare i caratteri prima di incorporarli. Chiama [FontsManager.getFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getFonts) per recuperare i caratteri utilizzati nella presentazione. Per ciascun carattere, passa un oggetto [FontData](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontdata/) e il valore richiesto di [FontStyleType](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontstyletype/) a [FontsManager.getFontBytes](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getFontBytes). Il metodo restituisce i dati binari per quello stile di carattere, o `None` quando il carattere o lo stile richiesto non è disponibile. Non passare un risultato `None` a [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), poiché quel metodo richiede un array di byte.

[EmbeddingLevel](https://reference.aspose.com/slides/it/python-java/aspose.slides/embeddinglevel/) è un’enumerazione a flag che segnala le restrizioni di incorporamento memorizzate nel carattere:

- `Installable` consente l’incorporamento e l’installazione permanente su un altro sistema, secondo la licenza del carattere.
- `Restricted` proibisce l’incorporamento a meno che non sia ottenuto il permesso dal proprietario legale del carattere quando è l’unico flag di permesso d’uso.
- `PreviewPrint` consente l’uso temporaneo per visualizzazione e stampa; un documento contenente il carattere deve essere di sola lettura.
- `Editable` consente l’uso temporaneo e permette al documento di essere modificato e salvato.
- `NoSubsetting` è una restrizione aggiuntiva che proibisce l’incorporamento di un sottoinsieme dei glifi. Incorpora tutti i caratteri quando questo flag è presente.
- `BitmapOnly` è una restrizione aggiuntiva che consente di incorporare solo le versioni bitmap dei caratteri, non i dati contornati. Se il carattere non dispone di versioni bitmap, non può essere incorporato.

I primi quattro valori descrivono il permesso d’uso, mentre `NoSubsetting` e `BitmapOnly` possono essere combinati con essi. Verifica i modificatori con operazioni bitwise. Poiché `Installable` è zero, maschera i bit di permesso d’uso e confronta il risultato con `Installable` invece di controllarlo come flag. I caratteri attuali dovrebbero impostare al massimo un bit di permesso d’uso. Per compatibilità con caratteri più vecchi che impostano più di uno, l’aiutante qui sotto seleziona il permesso meno restrittivo: `Editable`, poi `PreviewPrint`, poi `Restricted`.

L’esempio seguente verifica i dati regolari, grassetto, corsivo e grassetto‑corsivo disponibili per ogni carattere restituito da `getFonts`. Salta gli stili non disponibili, i caratteri con restrizioni, i caratteri solo bitmap, i caratteri limitati a anteprima e stampa perché l’output rimane modificabile, e i caratteri già incorporati. Se uno stile disponibile ha `NoSubsetting`, incorpora tutti i caratteri per quella famiglia di caratteri.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Questa ispezione riporta le restrizioni codificate in ogni file di carattere. Non concede una licenza, non dimostra che il carattere sia stato ottenuto legalmente, né sostituisce la verifica del contratto di licenza del carattere prima di distribuire una copia incorporata.

## **Aggiungi caratteri incorporati**

Utilizza [addEmbeddedFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) per incorporare un carattere. Le sue overload accettano un oggetto [FontData](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontdata/) oppure un array di byte contenente i dati del carattere. L’enumerazione [EmbedFontCharacters](https://reference.aspose.com/slides/it/python-java/aspose.slides/embedfontcharacters/) controlla quali caratteri vengono inclusi:

- [All](https://reference.aspose.com/slides/it/python-java/aspose.slides/embedfontcharacters/) incorpora tutti i caratteri nel carattere. Usa questa opzione quando i destinatari devono modificare la presentazione e inserire nuovo testo.
- [OnlyUsed](https://reference.aspose.com/slides/it/python-java/aspose.slides/embedfontcharacters/) incorpora solo i caratteri utilizzati nella presentazione per ridurre le dimensioni del file. Scegli questa opzione per una presentazione finale destinata principalmente alla visualizzazione.

L’esempio seguente utilizza [getFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getFonts) per recuperare i caratteri utilizzati in `Fonts.pptx` e incorpora quelli non ancora incorporati. I caratteri da aggiungere devono essere disponibili sulla macchina che esegue il codice. I caratteri già incorporati mantengono il set di caratteri corrente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Comprimi i caratteri incorporati**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/compress/#compressEmbeddedFonts) riduce i dati dei caratteri incorporati rimuovendo i caratteri non utilizzati. Opera sui caratteri già incorporati, quindi la riduzione di dimensione dipende da quanti dati di carattere non usati contiene la presentazione.

L’esempio seguente comprime i caratteri in `EmbeddedFonts.pptx` e salva il risultato in un file separato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Conserva il file originale se i destinatari potrebbero aver bisogno di aggiungere testo in seguito. I caratteri rimossi durante la compressione non sono più disponibili dal carattere incorporato, anche se inizialmente erano stati incorporati tutti i caratteri.

## **FAQ**

**Come posso verificare se un carattere incorporato verrà comunque sostituito durante il rendering?**

Chiama [getSubstitutions](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getSubstitutions) nell’ambiente in cui esegui il rendering della presentazione per vedere quali caratteri Aspose.Slides sostituirà. Controlla anche le impostazioni di sostituzione dei caratteri e le regole di fallback. Il fallback gestisce i caratteri mancanti, quindi l’incorporamento di un carattere non risolve i caratteri che il carattere stesso non contiene.

**Devo incorporare caratteri comuni come Arial e Calibri?**

Decidi in base all’ambiente di destinazione. Se i caratteri richiesti sono disponibili su ogni macchina che apre o rende la presentazione, incorporarli potrebbe aggiungere dimensioni inutili al file. Se i destinatari o i server potrebbero non avere quei caratteri, incorporarli può aiutare a preservare l’aspetto previsto, purché le loro licenze lo consentano.