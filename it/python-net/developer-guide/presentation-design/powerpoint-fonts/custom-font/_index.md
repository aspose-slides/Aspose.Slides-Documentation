---
title: Personalizza i caratteri PowerPoint in Python
linktitle: Font personalizzato
type: docs
weight: 20
url: /it/python-net/custom-font/
keywords:
- carattere
- carattere personalizzato
- carattere esterno
- caricare carattere
- gestire i caratteri
- cartella dei caratteri
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Incorpora caratteri personalizzati nelle diapositive PowerPoint con Aspose.Slides per Python tramite .NET per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides per Python consente di fornire caratteri personalizzati a runtime in modo che le presentazioni vengano renderizzate correttamente anche quando i caratteri richiesti non sono installati sul sistema host. Durante l'esportazione in PDF o immagini, è possibile fornire cartelle dei caratteri o dati dei caratteri in memoria per preservare il layout del testo, le metriche dei glifi e la tipografia. Questo rende il rendering lato server prevedibile su ambienti diversi, elimina le dipendenze dei caratteri a livello di OS e impedisce fallback indesiderati o riformattazioni. L'articolo mostra come registrare le sorgenti dei caratteri.

Aspose.Slides consente di caricare i seguenti caratteri usando i metodi `load_external_font` e `load_external_fonts` della classe [FontsLoader](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsloader/):

- Caratteri TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).
- Caratteri OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Carica caratteri personalizzati**

Aspose.Slides consente di caricare i caratteri utilizzati in una presentazione senza installarli sul sistema. Ciò influisce sull'output di esportazione—come PDF, immagini e altri formati supportati—così i documenti risultanti appaiono coerenti tra gli ambienti. I caratteri vengono caricati da directory personalizzate.

1. Specifica una o più cartelle che contengono i file dei caratteri.
2. Chiama il metodo statico [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsloader/load_external_fonts/) per caricare i caratteri da quelle cartelle.
3. Carica e renderizza/esporta la presentazione.
4. Chiama [FontsLoader.clear_cache](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsloader/clear_cache/) per svuotare la cache dei caratteri.

La seguente esempio di codice dimostra il processo di caricamento dei caratteri:

```py
import aspose.slides as slides

# Definisci le cartelle che contengono i file dei caratteri personalizzati.
font_folders = [ external_font_folder1, external_font_folder2 ]

# Carica i caratteri personalizzati dalle cartelle specificate.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Esegui il render/esporta la presentazione (ad es., in PDF, immagini o altri formati) utilizzando i caratteri caricati.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Svuota la cache dei caratteri al termine del lavoro.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Nota" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsloader/load_external_fonts/) aggiunge cartelle aggiuntive ai percorsi di ricerca dei caratteri, ma non modifica l'ordine di inizializzazione dei caratteri.
I caratteri sono inizializzati in questo ordine:

1. Il percorso predefinito dei caratteri del sistema operativo.
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Ottieni la cartella dei caratteri personalizzati**

Aspose.Slides fornisce il metodo `get_font_folders` per recuperare le cartelle dei caratteri. Restituisce sia le cartelle aggiunte tramite `load_external_fonts` sia le cartelle dei caratteri di sistema.

Questo codice Python mostra come utilizzare `get_font_folders`:

```python
import aspose.slides as slides

# Questa chiamata restituisce le cartelle controllate per i file dei caratteri.
# Queste includono le cartelle aggiunte tramite il metodo load_external_fonts e le cartelle dei caratteri di sistema.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Specifica caratteri personalizzati per una presentazione**

Aspose.Slides fornisce la proprietà `document_level_font_sources`, che consente di specificare caratteri esterni da utilizzare con una presentazione.

Il seguente esempio Python mostra come utilizzare `document_level_font_sources`:

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
    # CustomFont1, CustomFont2 e i caratteri dalle cartelle assets\fonts e global\fonts (e le loro sottocartelle) sono disponibili per la presentazione.
    # ...
    print(len(presentation.slides))
```

## **Carica caratteri esterni da dati binari**

Aspose.Slides fornisce il metodo `load_external_font` per caricare caratteri esterni da dati binari.

Il seguente esempio Python dimostra il caricamento di un carattere da un array di byte:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Carica i caratteri esterni da array di byte.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
        # I caratteri esterni sono disponibili per tutta la durata di questa istanza di presentazione.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **FAQ**

**I caratteri personalizzati influiscono sull'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?**  
Sì. I caratteri collegati sono utilizzati dal renderer in tutti i formati di esportazione.

**I caratteri personalizzati vengono incorporati automaticamente nel PPTX risultante?**  
No. Registrare un carattere per il rendering non è lo stesso di incorporarlo in un PPTX. Se hai bisogno che il carattere sia incluso nel file della presentazione, devi utilizzare le [funzionalità di incorporamento](/slides/it/python-net/embedded-font/).

**Posso controllare il comportamento di fallback quando un carattere personalizzato manca di alcuni glifi?**  
Sì. Configura la [sostituzione dei caratteri](/slides/it/python-net/font-substitution/), le [regole di sostituzione](/slides/it/python-net/font-replacement/) e i [set di fallback](/slides/it/python-net/fallback-font/) per definire esattamente quale carattere viene usato quando il glifo richiesto è mancante.

**Posso usare i caratteri in contenitori Linux/Docker senza installarli a livello di sistema?**  
Sì. Puntare alle proprie cartelle dei caratteri o caricare i caratteri da array di byte. Questo elimina qualsiasi dipendenza dalle directory dei caratteri di sistema nell'immagine del contenitore.

**E per quanto riguarda le licenze—posso incorporare qualsiasi carattere personalizzato senza restrizioni?**  
Sei responsabile della conformità alle licenze dei caratteri. I termini variano; alcune licenze vietano l'incorporamento o l'uso commerciale. Rivedi sempre il contratto di licenza (EULA) del carattere prima di distribuire i risultati.