---
title: Esporta presentazioni in XAML con Python
linktitle: Presentazione a XAML
type: docs
weight: 30
url: /it/python-net/export-to-xaml/
keywords:
- esporta PowerPoint
- esporta OpenDocument
- esporta presentazione
- converti PowerPoint
- converti OpenDocument
- converti presentazione
- PowerPoint in XAML
- OpenDocument in XAML
- presentazione in XAML
- PPT in XAML
- PPTX in XAML
- ODP in XAML
- salva PPT come XAML
- salva PPTX come XAML
- salva ODP come XAML
- esporta PPT in XAML
- esporta PPTX in XAML
- esporta ODP in XAML
- Python
- Aspose.Slides
description: "Converti diapositive PowerPoint e OpenDocument in XAML con Python usando Aspose.Slides—soluzione rapida, senza Office, che mantiene intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare presentazioni PowerPoint in XAML usando Aspose.Slides. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export.xaml/xamloptions/), inclusa l'esportazione delle diapositive nascoste. L'articolo risponde inoltre a alcune domande comuni relative ai caratteri di fallback, alla compatibilità dello stack XAML e al comportamento di esportazione delle diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di markup basato su XML utilizzato per descrivere le interfacce utente in framework come WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

È possibile lavorare con i file XAML in un designer visuale oppure scrivere e modificare il markup direttamente.

## **Esporta presentazioni in XAML con opzioni predefinite**

Il seguente esempio Python mostra come esportare una presentazione in XAML con le impostazioni predefinite:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

Per impostazione predefinita, le diapositive esportate vengono salvate in una sottocartella `pres` della directory di lavoro corrente del processo, come restituito da [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd). La cartella viene creata automaticamente e anche le eventuali immagini richieste vengono salvate lì.

Il nome della cartella di output viene preso dal nome del file di origine senza estensione. Per `pres.pptx`, i file di output sono denominati `pres/Slide_1.xaml`, `pres/Slide_2.xaml` e così via. Anche se si fornisce un percorso assoluto alla presentazione di input, la cartella di output viene creata in modo relativo alla directory di lavoro corrente, anziché accanto al file di input.

## **Esporta presentazioni in XAML con opzioni personalizzate**

Utilizzare la classe [XamlOptions] per controllare come Aspose.Slides esporta una presentazione in XAML.

Per includere le diapositive nascoste nell'output XAML, impostare la proprietà [export_hidden_slides] su `True`, come mostrato nel seguente esempio Python:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Acquisisci tutti gli artefatti XAML generati**

Un'esportazione XAML può produrre un documento XAML per ogni diapositiva esportata, oltre a immagini separate e risorse di supporto. Conservare tutti questi file durante l'archiviazione o la trasmissione di un'esportazione.

Gli esempi seguenti utilizzano il salvataggio predefinito del file system in una directory temporanea, quindi raccolgono i file generati.

### **Comprendere il ciclo di vita dell'esportazione**

- Avviare l'esportazione con il sovraccarico specifico XAML di [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) che accetta le opzioni XAML. Leggere i file generati solo dopo che ha restituito con successo.
- Conservare il percorso relativo di ciascun artefatto perché XAML può fare riferimento a risorse usando percorsi relativi.
- Leggere gli artefatti come byte. Le immagini e altre risorse binarie non devono essere decodificate come testo.
- Segnalare il successo complessivo solo dopo che la raccolta e qualsiasi operazione di archiviazione successiva sono completate. Permettere agli errori di archiviazione di raggiungere il chiamante e pulire l'output parziale se la persistenza fallisce.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) è impostato per impostazione predefinita su `False`, il che esclude i documenti XAML delle diapositive nascoste. Impostandolo su `True` le includi così come le risorse necessarie per la loro esportazione. Il numero di risorse dipende dalla presentazione; non presumere un file per diapositiva.

{{% alert color="warning" title="Warning" %}}
Gli esempi cambiano temporaneamente la directory di lavoro corrente del processo, il che influisce su tutti i thread. Eseguire ogni esportazione in un processo worker dedicato, oppure assicurarsi che nessun altro lavoro nel processo dipenda dalla directory corrente durante l'esportazione. Una directory temporanea unica da sola non rende sicure le esportazioni concorrenti nello stesso processo.
{{% /alert %}}

### **Esporta in memoria e ispeziona gli artefatti**

Questo esempio completo carica `pres.pptx`, lo esporta in una directory temporanea, raccoglie ogni artefatto in un dizionario di nomi relativi e byte, e stampa il suo nome, tipo e conteggio dei byte. Conserva la struttura delle directory generate e rimuove i file temporanei dopo la raccolta. Il percorso di input viene risolto prima di cambiare la directory di lavoro.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Decodifica solo XAML, e solo quando è necessaria l'ispezione testuale.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

I controlli delle estensioni sono utili per l'ispezione; conservare tutti gli artefatti, inclusi tipi di risorse sconosciuti. Lasciare i byte invariati durante l'archiviazione o la trasmissione. Decodificare solo XAML che necessita di elaborazione testuale. Questo approccio utilizza spazio su disco temporaneo così come la memoria per l'esportazione raccolta.

### **Impacchetta gli artefatti raccolti in un archivio ZIP**

Questo esempio indipendente raccoglie l'esportazione, ne valida i nomi e scrive i byte originali in un archivio ZIP. Un nome di archivio unico separa i lavori di esportazione. Le voci ZIP utilizzano slash in avanti e mantengono le directory relative. Nomi non sicuri o nomi che collidono dopo la normalizzazione rifiutano l'intero pacchetto prima della scrittura.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # La directory ZIP è stata finalizzata prima di segnalare il successo.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

L'esempio utilizza [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) per scrivere un archivio locale dopo aver raccolto l'esportazione temporanea. Per l'archiviazione remota, sostituire la fase di scrittura dell'archivio con il caricamento dei byte raccolti. Utilizzare un identificatore di lavoro di esportazione più il nome relativo completo dell'artefatto come chiave dell'oggetto, oppure memorizzare l'identificatore del lavoro, il nome relativo e i dati binari in una riga di database. Pubblicare il lavoro solo dopo che tutti i caricamenti sono completati o la transazione del database è confermata. Pulire l'output parziale se la persistenza fallisce.

Per presentazioni di grandi dimensioni, elaborare i file temporanei uno alla volta dopo l'esportazione invece di raccogliere tutti i loro byte in un dizionario. Questo evita una copia aggiuntiva in memoria dell'intera esportazione, ma non elimina i requisiti di memoria dell'esportatore.

### **Conservare i nomi delle risorse e verificare i riferimenti**

- Normalizzare i separatori di percorso quando la destinazione lo richiede, ma conservare le directory relative. Non mantenere solo il nome finale del file a meno che ogni nome generato sia noto per essere unico e i riferimenti alle risorse rimangano validi.
- Applicare la convalida del nome specifica per la destinazione. Quando si scrivono file sparsi, rifiutare percorsi assoluti e segmenti di attraversamento, risolvere la destinazione e verificare che rimanga sotto la directory di esportazione prevista. Utilizzare una directory controllata dall'applicazione senza collegamenti simbolici che potrebbero reindirizzare le scritture.
- Utilizzare uno spazio dei nomi di archiviazione separato per ogni lavoro di esportazione. Rilevare collisioni dopo la normalizzazione dei separatori e in base alle regole di sensibilità al maiuscolo/minuscolo della destinazione.
- Prima della pubblicazione, analizzare ogni documento XAML come XML e ispezionare i suoi riferimenti a risorse basate su file, come gli attributi immagine `Source` o `ImageSource`. Risolvere ogni URI relativo rispetto alla directory dell'artefatto XAML contenente, normalizzare il nome di archiviazione risultante e confermare che la chiave corrispondente nel dizionario, la voce ZIP o l'oggetto archiviato esista. Trattare gli URI esterni e le espressioni di markup XAML separatamente dai nomi di file relativi.

Ad esempio, se `pres/Slide_1.xaml` fa riferimento a `images/image1.png`, la risorsa archiviata deve essere disponibile come `pres/images/image1.png`. Conservare solo `image1.png` romperebbe tale relazione. Per l'archiviazione di oggetti, conservare la stessa struttura sotto il prefisso del lavoro e rendere quegli URL di risorsa accessibili al consumatore XAML. Riaprire lo ZIP completato per verificare i nomi delle voci e i byte delle risorse, e caricare diapositive rappresentative nell'ambiente XAML di destinazione per confermare che le immagini vengano risolte correttamente.

## **FAQ**

**Come posso garantire caratteri prevedibili se il carattere originale non è disponibile sulla macchina?**

Impostare [default_regular_font](https://reference.aspose.com/slides/it/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) in [XamlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export.xaml/xamloptions/) — viene utilizzato come carattere di fallback durante l'esportazione quando l'originale è mancante. Questo non garantisce che lo XAML generato faccia riferimento al carattere di fallback o che il carattere sia disponibile sulla macchina di destinazione. Assicurarsi che i caratteri a cui fa riferimento lo XAML siano disponibili nell'ambiente in cui viene visualizzato.

**Lo XAML esportato è destinato solo a WPF o può essere utilizzato anche in altri stack XAML?**

Aspose.Slides esporta XAML WPF tramite la sua API pubblica. La compatibilità con altri stack XAML, come UWP e Xamarin.Forms, non è garantita. Testare il markup generato nell'ambiente di destinazione.

**Le diapositive nascoste sono supportate e come posso evitarne l'esportazione per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. È possibile controllare questo comportamento tramite [export_hidden_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) in [XamlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export.xaml/xamloptions/) — mantenerlo disabilitato se non è necessario esportarle.