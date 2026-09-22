---
title: Salva presentazioni in Python via Java
linktitle: Salva presentazione
type: docs
weight: 80
url: /it/python-java/save-presentation/
keywords:
- salva PowerPoint
- salva OpenDocument
- salva presentazione
- salva diapositiva
- salva PPT
- salva PPTX
- salva ODP
- presentazione su file
- presentazione su stream
- tipo di visualizzazione predefinito
- Formato Strict Office Open XML
- modalità Zip64
- aggiornamento miniatura
- segnalazione avanzamento salvataggio
- Python
- Java
- Aspose.Slides
description: "Salva presentazioni PowerPoint e OpenDocument su file o stream in Python via Java con Aspose.Slides, e configura l'output PPTX e la segnalazione di avanzamento."
---
## **Panoramica**

Dopo aver creato una presentazione o [aperto una esistente](/slides/it/python-java/open-presentation/), usa il metodo [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) per scrivere il risultato. Aspose.Slides per Python via Java può salvare una presentazione in un file o stream in PowerPoint, OpenDocument, PDF e altri formati. Le sezioni seguenti coprono le operazioni di salvataggio standard e le opzioni disponibili per l'output PPTX.

## **Salvare le presentazioni su file**

Per salvare una presentazione su un file, passa il percorso di output e un valore [SaveFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/) al metodo [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save). Il valore del formato determina il tipo di file che Aspose.Slides crea.

Il seguente esempio crea una presentazione e la salva come file PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Aggiungi o modifica il contenuto della presentazione qui.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Salvare le presentazioni nel loro formato originale**

Per esempi di rilevamento file e stream, il comportamento delle presentazioni appena create e la distinzione tra formati di origine e di destinazione, vedere [Determinare il formato originale della presentazione](/slides/it/python-java/detect-presentation-source-format/).

In un'applicazione di elaborazione batch, il formato di input potrebbe non essere noto in anticipo. Dopo aver caricato un file, leggi il suo formato originale dal metodo [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSourceFormat). Passa il valore risultante [SourceFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/sourceformat/) a [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideutil/#toSaveFormat) per ottenere il corrispondente valore [SaveFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/), quindi usa [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) per scrivere la presentazione modificata.

Il seguente esempio completo elabora ogni file in una directory di input, aggiorna il suo titolo e lo salva in una directory di output nel formato da cui è stato caricato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideutil/#toSaveFormat) mappa PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP e PowerPoint XML ai rispettivi formati di salvataggio della presentazione. Mappa solo i formati sorgente della presentazione; non è destinato a selezionare formati di esportazione come PDF, HTML, TIFF o immagini. Passare un valore [SourceFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/sourceformat/) non supportato o non valido genera un [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

I file legacy PPT, PPS e POT utilizzano lo stesso contenitore binario. Quando una presentazione di questo tipo è caricata da uno stream senza estensione, un file PPS o POT può quindi essere identificato come PPT. Se è necessario conservare questi sottotipi legacy, mantieni separatamente il nome file originale o i metadati del formato e usali quando scegli il nome file e il formato di output.

## **Salvare le presentazioni su stream**

Per scrivere una presentazione senza fare affidamento su un percorso file definitivo, passa uno stream scrivibile e un valore [SaveFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/) al metodo [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save). Questo approccio è utile quando l'output deve essere restituito da un servizio web, memorizzato in un database o elaborato in memoria.

Il seguente esempio salva una nuova presentazione su un flusso file:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **Salvare le presentazioni con un tipo di visualizzazione predefinito**

Puoi specificare la visualizzazione con cui PowerPoint apre inizialmente una presentazione salvata. Usa il metodo [ViewProperties.setLastView](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#setLastView) con un valore [ViewType](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewtype/) prima del salvataggio.

Il seguente esempio configura la visualizzazione Slide Master come visualizzazione iniziale:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Salvare le presentazioni nel formato Strict Office Open XML**

Per creare un file PPTX conforme al profilo Strict di Office Open XML, crea un'istanza [PptxOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pptxoptions/) e usa il suo metodo [setConformance](https://reference.aspose.com/slides/it/python-java/aspose.slides/pptxoptions/#setConformance) con [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/it/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Quindi passa le opzioni al metodo [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Salvare le presentazioni in formato Office Open XML in modalità Zip64**

Un archivio ZIP standard limita la dimensione compressa e non compressa di ogni voce, la dimensione totale dell'archivio e il numero di voci. Poiché un file PPTX è un archivio ZIP, una presentazione molto grande può superare tali limiti. Le estensioni ZIP64 aumentano i limiti di dimensione e conteggio delle voci.

Usa il metodo [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/it/python-java/aspose.slides/pptxoptions/#setZip64Mode) per controllare se Aspose.Slides scrive le estensioni ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/it/python-java/aspose.slides/zip64mode/#IfNecessary) usa ZIP64 solo quando la presentazione supera i limiti standard ZIP. Questa è la modalità predefinita.
- [Never](https://reference.aspose.com/slides/it/python-java/aspose.slides/zip64mode/#Never) disabilita le estensioni ZIP64.
- [Always](https://reference.aspose.com/slides/it/python-java/aspose.slides/zip64mode/#Always) scrive sempre le estensioni ZIP64.

Il seguente esempio abilita sempre le estensioni ZIP64 per la presentazione di output:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Se [Zip64Mode.Never](https://reference.aspose.com/slides/it/python-java/aspose.slides/zip64mode/#Never) viene utilizzato e la presentazione non può rientrare nei limiti standard ZIP, l'operazione di salvataggio genera un [PptxException](https://reference.aspose.com/slides/it/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Salvare le presentazioni in formato Office Open XML con livelli di compressione**

Per l'output PPTX, puoi bilanciare velocità di salvataggio e dimensione file usando il metodo [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/it/python-java/aspose.slides/pptxoptions/#setCompressionLevel). La classe [CompressionLevel](https://reference.aspose.com/slides/it/python-java/aspose.slides/compressionlevel/) fornisce questi valori:

- [None](https://reference.aspose.com/slides/it/python-java/aspose.slides/compressionlevel/#None) memorizza i dati senza compressione.
- [Level1](https://reference.aspose.com/slides/it/python-java/aspose.slides/compressionlevel/#Level1) fornisce la compressione più veloce e l'output compresso più grande.
- [Level2](https://reference.aspose.com/slides/it/python-java/aspose.slides/compressionlevel/#Level2) fino a [Level5](https://reference.aspose.com/slides/it/python-java/aspose.slides/compressionlevel/#Level5) favoriscono progressivamente un output più piccolo rispetto alla velocità di salvataggio.
- [Level6](https://reference.aspose.com/slides/it/python-java/aspose.slides/compressionlevel/#Level6) bilancia velocità di salvataggio e dimensione file. Questo è il livello predefinito.
- [Level7](https://reference.aspose.com/slides/it/python-java/aspose.slides/compressionlevel/#Level7) e [Level8](https://reference.aspose.com/slides/it/python-java/aspose.slides/compressionlevel/#Level8) favoriscono ulteriormente un output più piccolo rispetto alla velocità di salvataggio.
- [Level9](https://reference.aspose.com/slides/it/python-java/aspose.slides/compressionlevel/#Level9) fornisce la compressione più forte e richiede più tempo di elaborazione.

Il seguente esempio salva una presentazione senza compressione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

Il seguente esempio utilizza il livello di compressione massimo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Salvare le presentazioni senza aggiornare la miniatura**

Quando una presentazione viene salvata come PPTX, il metodo [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/it/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controlla la sua miniatura del documento:

- `True` rigenera la miniatura durante l'operazione di salvataggio. Questo è il valore predefinito.
- `False` preserva la miniatura esistente. Se la presentazione non ha miniatura, Aspose.Slides non ne genera una.

Il seguente esempio salva una presentazione senza aggiornare la sua miniatura:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Disabilitare l'aggiornamento della miniatura può ridurre il tempo necessario per salvare un file PPTX.
{{% /alert %}}

## **Segnalare l'avanzamento del salvataggio in percentuale**

Per monitorare un'operazione di salvataggio, registra un handler di progresso Python tramite `jpype.JProxy` e passalo al metodo [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides quindi chiama il metodo `reporting` dell'handler con i valori di avanzamento durante l'esportazione.

Il seguente esempio segnala l'avanzamento di un'esportazione PDF nella console:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose fornisce un [PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) gratuito costruito con l'API Aspose.Slides. Salva le diapositive selezionate da una presentazione come file PPT o PPTX separati.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il salvataggio incrementale o “fast save”?**

No. Ogni operazione di salvataggio scrive un file di output completo anziché aggiornare solo le parti modificate.

**Più thread possono salvare la stessa istanza di Presentation?**

No. Un'istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) non è thread-safe. Accedi e salva ogni istanza da un solo thread alla volta.

**Cosa succede ai collegamenti ipertestuali e ai file collegati esternamente quando salvo una presentazione?**

[Hyperlinks](/slides/it/python-java/manage-hyperlinks/) rimangono nella presentazione. Aspose.Slides non copia i file collegati esternamente, quindi la presentazione salvata deve comunque poter accedere alle loro posizioni.

**Posso salvare i metadati del documento come autore, titolo, azienda e data di creazione?**

Sì. Imposta le [document properties](/slides/it/python-java/presentation-properties/) appropriate prima del salvataggio, e Aspose.Slides le scrive nel file di output.