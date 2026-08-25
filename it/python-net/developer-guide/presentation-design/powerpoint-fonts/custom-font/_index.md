---
title: Personalizza i caratteri di PowerPoint in Python
linktitle: Carattere personalizzato
type: docs
weight: 20
url: /it/python-net/custom-font/
keywords:
- carattere
- carattere personalizzato
- carattere esterno
- caricamento carattere
- gestire i caratteri
- cartella dei caratteri
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Incorpora caratteri personalizzati nelle diapositive PowerPoint con Aspose.Slides per Python tramite .NET per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides per Python consente di fornire caratteri personalizzati a runtime in modo che le presentazioni vengano renderizzate correttamente anche quando i caratteri richiesti non sono installati sul sistema host. Durante l'esportazione in PDF o immagini, è possibile fornire cartelle di font o dati di font in memoria per preservare il layout del testo, le metriche dei glifi e la tipografia. Questo rende il rendering lato server prevedibile su ambienti diversi, elimina le dipendenze di sistema relative ai caratteri e impedisce fallback indesiderati o riorganizzazioni del testo. L'articolo mostra come registrare le origini dei font.

Un tema di presentazione può fare riferimento a famiglie di caratteri diverse per singoli sistemi di scrittura. Queste mappature memorizzano i nomi dei font ma non installano né caricano i file dei font. Vedi [Script-Specific Theme Fonts](/slides/it/python-net/script-specific-font-mappings/) per gestire le mappature e utilizza le opzioni di caricamento qui sotto per rendere disponibili i font di riferimento per un rendering coerente.

Aspose.Slides consente di caricare i seguenti caratteri usando i metodi `load_external_font` e `load_external_fonts` della classe [FontsLoader](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsloader/):

- Font TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).
- Font OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Caricare Font Personalizzati**

Aspose.Slides permette di caricare i font utilizzati in una presentazione senza installarli sul sistema. Questo influisce sull'output di esportazione—come PDF, immagini e altri formati supportati—così i documenti risultanti appaiono coerenti su tutti gli ambienti. I font vengono caricati da cartelle personalizzate.

1. Specificare una o più cartelle che contengono i file dei font.
2. Chiamare il metodo statico [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsloader/load_external_fonts/) per caricare i font da quelle cartelle.
3. Caricare e renderizzare/esportare la presentazione.
4. Chiamare [FontsLoader.clear_cache](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsloader/clear_cache/) per svuotare la cache dei font.

Il seguente esempio di codice mostra il processo di caricamento dei font:

```py
import aspose.slides as slides

# Definisci le cartelle che contengono i file dei font personalizzati.
font_folders = ["fonts", "external_fonts"]

# Carica i font personalizzati dalle cartelle specificate.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Renderizza/esporta la presentazione (ad es., in PDF, immagini o altri formati) usando i font caricati.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Svuota la cache dei font dopo aver terminato il lavoro.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsloader/load_external_fonts/) aggiunge cartelle aggiuntive ai percorsi di ricerca dei font, ma non modifica l'ordine di inizializzazione dei font.  
I font vengono inizializzati in questo ordine:

1. Il percorso predefinito dei font del sistema operativo.  
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsloader/).  
{{%/alert %}}

## **Ottenere la Cartella dei Font Personalizzati**

Aspose.Slides fornisce il metodo `get_font_folders` per recuperare le cartelle dei font. Restituisce sia le cartelle aggiunte tramite `load_external_fonts` sia le cartelle dei font di sistema.

Questo codice Python mostra come utilizzare `get_font_folders`:

```python
import aspose.slides as slides

# Questa chiamata restituisce le cartelle controllate per i file dei font.
# Queste includono le cartelle aggiunte tramite il metodo load_external_fonts e le cartelle di sistema dei font.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Specificare Font Personalizzati per una Presentazione**

Aspose.Slides fornisce la proprietà `document_level_font_sources`, che consente di specificare i font esterni da utilizzare con una presentazione.

Il seguente esempio Python mostra come usare `document_level_font_sources`:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Lavora con la presentazione.
    # CustomFont1, CustomFont2 e i font dalle cartelle assets\fonts e global\fonts (e le loro sottocartelle) sono disponibili per la presentazione.
    # ...
    print(len(presentation.slides))
```

## **Caricare Font Esterni da Dati Binari**

Aspose.Slides fornisce il metodo `load_external_font` per caricare font esterni da dati binari.

Il seguente esempio Python dimostra il caricamento di un font da un array di byte:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Carica i font esterni da array di byte.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # I font esterni sono disponibili per tutta la durata di questa istanza di presentazione.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **FAQ**

### I font personalizzati influenzano l'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?

Sì. I font collegati vengono utilizzati dal motore di rendering per tutti i formati di esportazione.

### I font personalizzati vengono incorporati automaticamente nel PPTX risultante?

No. Registrare un font per il rendering non è la stessa cosa di incorporarlo in un PPTX. Se è necessario che il font sia presente all'interno del file della presentazione, è necessario utilizzare le [funzionalità di incorporamento](/slides/it/python-net/embedded-font/).

### Posso controllare il comportamento di fallback quando un font personalizzato non dispone di alcuni glifi?

Sì. Configura la [sostituzione dei font](/slides/it/python-net/font-substitution/), le [regole di sostituzione](/slides/it/python-net/font-replacement/) e i [set di fallback](/slides/it/python-net/fallback-font/) per definire esattamente quale font utilizzare quando il glifo richiesto è mancante.

### Posso usare i font in container Linux/Docker senza installarli a livello di sistema?

Sì. Indica le tue cartelle di font o carica i font da array di byte. Questo elimina qualsiasi dipendenza dalle directory di sistema nel container.

### Cosa riguarda la licenza—posso incorporare qualsiasi font personalizzato senza restrizioni?

Sei responsabile della conformità alle licenze dei font. I termini variano; alcune licenze vietano l'incorporamento o l'uso commerciale. Consulta sempre l'EULA del font prima di distribuire i risultati.