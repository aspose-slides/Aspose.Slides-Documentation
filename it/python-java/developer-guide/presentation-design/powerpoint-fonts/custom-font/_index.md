---
title: Personalizza i font di PowerPoint in Python tramite Java
linktitle: Font Personalizzato
type: docs
weight: 20
url: /it/python-java/custom-font/
keywords:
- font
- font personalizzato
- font esterno
- caricare font
- gestire i font
- cartella dei font
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Personalizza i font nelle diapositive PowerPoint con Aspose.Slides per Python tramite Java per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides consente di utilizzare font personalizzati nelle presentazioni senza installarli sul sistema operativo. È possibile caricare i font da cartelle personalizzate, fornire font per una presentazione specifica tramite font a livello di documento, oppure caricare font esterni direttamente da dati binari.

I font caricati sono utilizzati quando una presentazione viene renderizzata o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo aiuta a mantenere l'output della presentazione coerente tra ambienti diversi. L'articolo spiega anche come ispezionare le cartelle dei font utilizzate da Aspose.Slides e come svuotare la cache dei font dopo aver lavorato con font esterni.

Registrare font personalizzati per il rendering è separato dall'incorporamento dei font in un file PPTX. Se un font deve essere memorizzato all'interno della presentazione stessa, utilizzare esplicitamente le funzionalità di embedding dei font.

Un tema di presentazione può fare riferimento a diverse famiglie di font per sistemi di scrittura individuali. Queste associazioni memorizzano i nomi dei font ma non installano né caricano i file dei font. Vedere [Script-Specific Theme Fonts](/slides/it/python-java/script-specific-font-mappings/) per gestire le associazioni e utilizzare le opzioni di caricamento di seguito per rendere i font di riferimento disponibili per un rendering coerente.

{{% alert color="info" title="Nota" %}}

Aspose.Slides consente di caricare questi font usando il metodo [loadExternalFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsloader/#loadExternalFonts):

* Font TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Font OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carica Font Personalizzati**

Aspose.Slides consente di caricare i font utilizzati in una presentazione senza installarli sul sistema. Questo influisce sull'output di esportazione—come PDF, immagini e altri formati supportati—perché i documenti risultanti appaiano coerenti tra ambienti diversi. I font vengono caricati da directory personalizzate.

1. Specificare una o più cartelle che contengono i file dei font.
2. Chiamare il metodo statico [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsloader/#loadExternalFonts) per caricare i font da quelle cartelle.
3. Caricare e renderizzare/esportare la presentazione.
4. Chiamare [FontsLoader.clearCache](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsloader/#clearCache) per svuotare la cache dei font.

Il seguente esempio di codice dimostra il processo di caricamento dei font:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Definisci le cartelle che contengono i file dei font personalizzati.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Carica i font personalizzati dalle cartelle specificate.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Renderizza/esporta la presentazione usando i font caricati.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # Cancella la cache dei font dopo che il lavoro è terminato.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Nota" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsloader/#loadExternalFonts) aggiunge cartelle aggiuntive ai percorsi di ricerca dei font, ma non modifica l'ordine di inizializzazione dei font.  
I font vengono inizializzati in questo ordine:

1. Il percorso predefinito dei font del sistema operativo.  
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Ottieni Cartelle dei Font Personalizzati**

Aspose.Slides fornisce il metodo [getFontFolders](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsloader/#getFontFolders) per consentire di trovare le cartelle dei font. Questo metodo restituisce le cartelle aggiunte tramite il metodo [loadExternalFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsloader/#loadExternalFonts) e le cartelle dei font di sistema.

Questo codice Python mostra come usare [getFontFolders](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsloader/#getFontFolders):

```python
from asposeslides.api import FontsLoader

# Ottieni le cartelle aggiunte tramite loadExternalFonts e le cartelle dei font di sistema.
font_folders = FontsLoader.getFontFolders()
```

## **Specifica Font Personalizzati Usati con una Presentazione**

Aspose.Slides fornisce il metodo [getDocumentLevelFontSources](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) per consentire di specificare font esterni che saranno utilizzati con la presentazione.

Questo codice Python mostra come usare il metodo [getDocumentLevelFontSources](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources):

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Lavora con la presentazione.
    # CustomFont1, CustomFont2 e i font da assets/fonts e global/fonts
    # e le loro sottocartelle sono disponibili per la presentazione.
    pass
finally:
    presentation.dispose()
```

## **Gestisci Font Esternamente**

Aspose.Slides fornisce il metodo [loadExternalFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsloader/#loadExternalFont) per consentire di caricare font esterni da dati binari.

Questo codice Python dimostra il processo di caricamento di un font da un array di byte:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # I font esterni vengono caricati durante la durata della presentazione.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **FAQ**

**I font personalizzati influenzano l'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?**

Sì. I font collegati sono utilizzati dal motore di rendering per tutti i formati di esportazione.

**I font personalizzati vengono incorporati automaticamente nel PPTX risultante?**

No. Registrare un font per il rendering non è lo stesso che incorporarlo in un PPTX. Se è necessario che il font sia incluso nel file della presentazione, è necessario utilizzare esplicitamente le [funzionalità di embedding](/slides/it/python-java/embedded-font/).

**Posso controllare il comportamento di fallback quando un font personalizzato non possiede alcuni glifi?**

Sì. Configura la [sostituzione dei font](/slides/it/python-java/font-substitution/), le [regole di sostituzione](/slides/it/python-java/font-replacement/) e i [set di fallback](/slides/it/python-java/fallback-font/) per definire esattamente quale font viene usato quando il glifo richiesto è mancante.

**Posso usare i font in contenitori Linux/Docker senza installarli a livello di sistema?**

Sì. Puntare alle proprie cartelle di font o caricare i font da array di byte elimina qualsiasi dipendenza dalle directory dei font di sistema nell'immagine del contenitore.

**E per quanto riguarda le licenze—posso incorporare qualsiasi font personalizzato senza restrizioni?**

Sei responsabile della conformità alle licenze dei font. I termini variano; alcune licenze vietano l'incorporamento o l'uso commerciale. Consulta sempre l'EULA del font prima di distribuire gli output.