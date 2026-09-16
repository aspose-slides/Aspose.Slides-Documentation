---
title: Esporta presentazioni in XAML con Python via Java
linktitle: Presentazione a XAML
type: docs
weight: 30
url: /it/python-java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in XAML con Aspose.Slides for Python via Java. Usa le opzioni predefinite o includi le diapositive nascoste."
---
## **Panoramica**

Questo articolo spiega come esportare presentazioni PowerPoint in XAML utilizzando Aspose.Slides for Python via Java. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/), inclusa l'esportazione delle diapositive nascoste. L'articolo risponde inoltre a qualche domanda frequente relativa ai font di fallback, alla compatibilità con gli stack XAML e al comportamento di esportazione delle diapositive nascoste.

Gli esempi richiedono Aspose.Slides for Python via Java e un runtime Java compatibile. Posizionare `pres.pptx` nella directory di lavoro corrente. Ogni esempio avvia la JVM solo se non è già in esecuzione.

## **Informazioni su XAML**

XAML è un linguaggio di markup basato su XML utilizzato per descrivere interfacce utente in framework come WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

È possibile lavorare con i file XAML in un designer visuale o scrivere e modificare direttamente il markup.

## **Esporta presentazioni in XAML con le opzioni predefinite**

Il seguente esempio Python mostra come esportare una presentazione in XAML con le impostazioni predefinite:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

Per impostazione predefinita, le diapositive esportate vengono salvate in una sottocartella `pres` della directory di lavoro corrente del processo. La cartella viene creata automaticamente e anche le eventuali immagini richieste vengono salvate lì.

Il nome della cartella di output è ricavato dal nome del file sorgente senza estensione. Per `pres.pptx`, i file di output sono denominati `pres/Slide_1.xaml`, `pres/Slide_2.xaml` e così via. Anche se si passa un percorso assoluto alla presentazione di input, la cartella di output viene creata in relazione alla directory di lavoro corrente, non accanto al file di input.

## **Esporta presentazioni in XAML con opzioni personalizzate**

Utilizzare la classe [XamlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/) per controllare il modo in cui Aspose.Slides esporta una presentazione in XAML.

Per salvare l'output in una posizione personalizzata, implementare `IXamlOutputSaver` e passare un'istanza della propria implementazione al metodo [setOutputSaver](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/#setOutputSaver) di [XamlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/).

Per includere le diapositive nascoste nell'output XAML, chiamare [setExportHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) con `True`, come mostrato nel seguente esempio Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Cattura tutti gli artefatti XAML generati**

Un'esportazione XAML può produrre un documento XAML per ogni diapositiva esportata più immagini separate e risorse di supporto. Assegnare un `IXamlOutputSaver` personalizzato a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/#setOutputSaver) per ricevere questi artefatti invece di utilizzare il salvataggio predefinito su file system. Avviare l'esportazione con la sovraccarico di [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) specifico per XAML che accetta le opzioni XAML.

In Python, utilizzare `jpype.JProxy` per implementare l'interfaccia Java `IXamlOutputSaver`. Convertire il percorso di callback in `str` e copiare l'array di byte Java in `bytes` Python prima di restituirlo, come dimostrato di seguito.

### **Comprendere il ciclo di vita del callback**

L'esportatore chiama `IXamlOutputSaver.save` separatamente per ogni artefatto generato:

- `path` identifica l'artefatto e può includere directory relative. Conservare queste informazioni perché XAML può fare riferimento a risorse usando percorsi relativi.
- `data` contiene i byte dell'artefatto. Immagini e altre risorse binarie non devono essere decodificate come testo.
- Il saver è responsabile di conservare o persistere i dati prima di restituire. Gli esempi copiano ogni array di byte in memoria appartenente all'applicazione.
- Considerare l'esportazione completata con successo solo quando l'operazione di salvataggio della presentazione restituisce e tutti i callback sono terminati correttamente. Non ignorare errori di archiviazione né avviare scritture di background non monitorate. Se la persistenza avviene successivamente, segnalare il successo complessivo solo dopo che anche quell'operazione è riuscita.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) si applica anche a un saver personalizzato. L'impostazione predefinita, `False`, esclude i documenti XAML delle diapositive nascoste. Impostare `True` li include insieme a tutte le risorse necessarie per la loro esportazione. Il conteggio delle risorse dipende dalla presentazione; non presumere un callback per diapositiva o un ordine di callback fisso.

### **Esporta in memoria e ispeziona gli artefatti**

Questo esempio completo carica `pres.pptx`, raccoglie ogni artefatto in un dizionario Python di nomi e valori `bytes` immutabili, e stampa il nome, il tipo e il conteggio dei byte. Mantiene esattamente i nomi forniti. I nomi duplicati rendono la raccolta non valida anziché sovrascrivere silenziosamente un artefatto. L'esempio verifica questo prima di utilizzare i risultati.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Decodifica solo XAML, e solo quando è necessaria l'ispezione testuale.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

I controlli di estensione sono utili per l'ispezione; conservare tutti gli artefatti, inclusi i tipi di risorse sconosciuti. Lasciare i byte invariati quando li si archivia o trasmette. Utilizzare `bytes.decode` con UTF-8 solo per XAML che necessita di elaborazione testuale.

### **Impacchetta gli artefatti raccolti in un archivio ZIP**

Questo esempio indipendente raccoglie l'esportazione, ne valida i nomi e scrive i byte originali in un archivio ZIP. Un nome di archivio unico separa i job di esportazione concorrenti. Le voci ZIP usano barre oblique e conservano le directory relative. Nomi non sicuri o che collidono dopo la normalizzazione rifiutano l'intero pacchetto prima della scrittura.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # La chiusura finalizza la directory ZIP prima che il successo venga segnalato.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

L'esempio utilizza `zipfile.ZipFile` di Python per scrivere un archivio locale; l'esportatore stesso non scrive file XAML o immagini sparsi. Per l'archiviazione remota, sostituire la fase di scrittura dell'archivio con upload degli array di byte raccolti. Utilizzare un identificatore del job di esportazione più il nome relativo completo dell'artefatto come chiave blob, oppure salvare l'identificatore del job, il nome relativo e i dati binari in una riga di database. Pubblicare il job solo dopo che tutti gli upload sono completati o la transazione del database è confermata. Pulire l'output parziale se la persistenza fallisce.

Per presentazioni di grandi dimensioni, un saver personalizzato può persistere ogni artefatto direttamente nello storage dell'applicazione per evitare di mantenere una copia aggiuntiva dell'intera esportazione in memoria. Mantenere ogni callback sincrono dal punto di vista dell'esportatore: restituire solo dopo che la destinazione ha accettato i byte e consentire ai fallimenti di raggiungere il chiamante.

### **Conserva i nomi delle risorse e verifica i riferimenti**

- Normalizzare i separatori di percorso quando la destinazione lo richiede, ma conservare le directory relative. Non utilizzare solo `pathlib.Path.name` a meno che ogni nome generato sia noto per essere unico e i riferimenti alle risorse rimangano validi.
- Applicare la convalida dei nomi specifica della destinazione. Quando si scrivono file sparsi, rifiutare percorsi radicati e segmenti di traversata, risolvere la destinazione con `pathlib.Path.resolve` e verificare che rimanga sotto la directory di esportazione prevista, includendo il separatore di directory nel controllo di contenimento. Utilizzare una directory controllata dall'applicazione senza link simbolici che possano reindirizzare le scritture.
- Usare un saver e uno spazio dei nomi di storage separati per ogni job di esportazione. Rilevare collisioni dopo la normalizzazione dei separatori e secondo le regole di case‑sensitivity della destinazione.
- Prima della pubblicazione, analizzare ogni documento XAML come XML e ispezionare i riferimenti alle risorse basati su file, come gli attributi `Source` o `ImageSource` delle immagini. Risolvere ogni URI relativo rispetto alla directory dell'artefatto XAML contenente, normalizzare il nome di storage risultante e confermare che la chiave della mappa corrispondente, la voce ZIP o l'oggetto memorizzato esista. Trattare separatamente gli URI esterni e le espressioni di markup XAML rispetto ai nomi di file relativi.

Ad esempio, se `pres/Slide_1.xaml` fa riferimento a `images/image1.png`, la risorsa memorizzata deve essere disponibile come `pres/images/image1.png`. Conservare solo `image1.png` romperebbe quella relazione. Per lo storage a oggetti, preservare la stessa struttura sotto il prefisso del job e rendere quegli URL di risorsa accessibili al consumatore XAML. Riaprire lo ZIP completato per verificare i nomi delle voci e i byte delle risorse, e caricare diapositive rappresentative nell'ambiente XAML di destinazione per confermare che le immagini vengano risolte correttamente.

## **FAQ**

**Come posso garantire font prevedibili se il font originale non è disponibile sulla macchina?**

Chiamare [setDefaultRegularFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/) — viene usato come font di fallback durante l'esportazione quando l'originale è mancante. Questo non garantisce che lo XAML generato faccia riferimento al font di fallback o che il font sia disponibile sulla macchina di destinazione. Assicurarsi che i font referenziati dallo XAML siano presenti nell'ambiente in cui viene visualizzato.

**Lo XAML esportato è destinato solo a WPF o può essere usato anche in altri stack XAML?**

Aspose.Slides esporta XAML WPF tramite la sua API pubblica. La compatibilità con altri stack XAML, come UWP e Xamarin.Forms, non è garantita. Testare il markup generato nell'ambiente di destinazione.

**Le diapositive nascoste sono supportate e come posso impedirne l'esportazione per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. È possibile controllare questo comportamento tramite [setExportHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) in [XamlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/) — mantenerlo disabilitato se non è necessario esportarle.