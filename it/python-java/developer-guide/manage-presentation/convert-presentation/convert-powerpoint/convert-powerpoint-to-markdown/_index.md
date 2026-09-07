---
title: Converti le presentazioni PowerPoint in Markdown in Python tramite Java
linktitle: PowerPoint in Markdown
type: docs
weight: 140
url: /it/python-java/convert-powerpoint-to-markdown/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in MD
- presentazione in MD
- diapositiva in MD
- PPT in MD
- PPTX in MD
- salva PowerPoint come Markdown
- salva presentazione come Markdown
- salva diapositiva come Markdown
- salva PPT come MD
- salva PPTX come MD
- esporta PPT in MD
- esporta PPTX in MD
- esportazione immagine Markdown
- collegamenti immagine CDN
- PowerPoint
- presentazione
- Markdown
- Python
- Java
- Aspose.Slides
description: "Converti le presentazioni PPT e PPTX in Markdown in Python tramite Java e controlla dove vengono salvate e referenziate le immagini bitmap, metafile e SVG esportate."
---
## **Panoramica**

Aspose.Slides per Python via Java può convertire presentazioni PPT e PPTX in Markdown per documentazione, siti statici, migrazione di contenuti e flussi di lavoro di controllo di versione. È possibile scegliere una variante di Markdown, controllare come viene renderizzato il contenuto delle diapositive e decidere dove vengono salvate le immagini esportate e come il Markdown generato le fa riferimento.

Per impostazione predefinita, l’esportazione Markdown utilizza solo testo. Per esportare contenuti visivi, impostare il tipo di esportazione con il metodo [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/it/python-java/aspose.slides/markdownsaveoptions/#setExportType) sul valore `Sequential` o `Visual` dell’enumerazione [MarkdownExportType](https://reference.aspose.com/slides/it/python-java/aspose.slides/markdownexporttype/). `Sequential` rende gli elementi delle diapositive separatamente e in ordine, mentre `Visual` mantiene gli elementi raggruppati insieme per preservare la loro relazione visiva. Il valore `TextOnly` non genera risorse immagine, quindi le callback di salvataggio immagine non vengono invocate in quella modalità.

## **Convertire una presentazione in Markdown**

Caricare il file sorgente con la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e quindi chiamare il metodo [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) con il valore `Md` dell’enumerazione [SaveFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Ogni esempio legge `presentation.pptx` dalla directory di lavoro corrente. Installare Aspose.Slides per Python via Java e un runtime Java compatibile prima di eseguire gli esempi. Avviare la JVM una sola volta per processo Python.

## **Selezionare una variante di Markdown**

Il metodo [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/it/python-java/aspose.slides/markdownsaveoptions/#setFlavor) controlla la specifica Markdown usata per l’output. L’enumerazione [Flavor](https://reference.aspose.com/slides/it/python-java/aspose.slides/flavor/) include CommonMark, GitHub Flavored Markdown e altre varianti supportate.

Il seguente esempio esporta una presentazione come CommonMark:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Esportare immagini con il comportamento predefinito di salvataggio locale**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/markdownsaveoptions/) fornisce due metodi per configurare le immagini salvate localmente:

- [setBasePath](https://reference.aspose.com/slides/it/python-java/aspose.slides/markdownsaveoptions/#setBasePath) specifica la directory base per il documento Markdown e le relative risorse.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/it/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) specifica la sottodirectory delle immagini. Il valore predefinito è `Images`.

Il seguente esempio rende contenuti visivi, scrive le immagini in `output/assets` e crea riferimenti relativi alle immagini nel documento Markdown:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Questo comportamento funge anche da fallback quando un gestore personalizzato di salvataggio immagini restituisce `False`.

## **Personalizzare il salvataggio delle immagini e i collegamenti Markdown**

Usare il metodo [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/it/python-java/aspose.slides/markdownsaveoptions/) per registrare una callback per le risorse bitmap e metafile non SVG emesse durante l’esportazione Markdown. La sua callback `MarkdownImageSavingHandler` riceve l’oggetto immagine, il valore [ImageFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/imageformat/) e il collegamento Markdown generato come parametro `String[]` a elemento unico. Salvare o caricare l’immagine con il formato fornito e sostituire `link[0]` con il riferimento che deve apparire nell’output Markdown.

Le risorse emesse in formato SVG sono gestite separatamente. Registrare una callback con il metodo [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/it/python-java/aspose.slides/markdownsaveoptions/). La sua callback `MarkdownSvgImageSavingHandler` riceve un oggetto [SvgImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/) e il parametro `String[] link`. Un SVG non possiede un argomento `ImageFormat`; scrivere o caricare i dati XML tramite il metodo [SvgImage.getSvgData](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/#getSvgData). In base alla modalità di esportazione e al raggruppamento visivo, uno SVG nella presentazione di origine può essere rasterizzato o combinato con altri contenuti; la risorsa non‑SVG risultante viene quindi passata alla callback di salvataggio immagine. Registrare entrambe le callback quando ogni risorsa visiva esportata richiede elaborazione personalizzata.

Il valore di ritorno del gestore determina chi elabora l’immagine:

- Restituire `True` dopo che il gestore ha salvato, caricato, trasformato o altrimenti processato l’immagine e ha assegnato un valore valido a `link[0]`. Aspose.Slides scrive quel valore nel documento Markdown e non esegue il salvataggio locale predefinito.
- Restituire `False` per consentire ad Aspose.Slides di salvare l’immagine localmente e generare il suo collegamento in base ai valori impostati con [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/it/python-java/aspose.slides/markdownsaveoptions/#setBasePath) e [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/it/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

{{% alert color="danger" title="Important" %}}

Un gestore che restituisce `True` si assume la responsabilità dell’immagine. Se restituisce `True` senza assegnare un collegamento valido e non vuoto, l’esportazione fallisce con un `InvalidOperationException`.

{{% /alert %}}

In Python, registrare queste callback con `jpype.JProxy`, implementando l’interfaccia di callback Java tramite il metodo `invoke`. L’argomento `link` è un array di stringhe Java mutabile: convertire `link[0]` in una stringa Python prima di elaborarla, quindi assegnare l’URL di sostituzione nuovamente a `link[0]`.

### **Salvare le immagini in una directory di origine CDN e utilizzare URL esterni**

Il seguente esempio tratta `cdn-origin/presentations/quarterly-report` come una directory di origine CDN montata o sincronizzata. Ogni gestore estrae il nome file generato, salva l’immagine in quella directory personalizzata e sostituisce il riferimento locale generato con un URL CDN pubblico. Il campione stesso non effettua upload di rete: l’URL diventa valido solo dopo che la directory è montata come origine CDN o i file sono pubblicati sul CDN. Per lo storage di oggetti, sostituire la scrittura su file system con l’operazione di upload dell’Sdk di storage e assegnare `link[0]` solo dopo che l’upload ha avuto successo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Il gestore bitmap restituisce deliberatamente `False` per le immagini più piccole di 128 × 128 pixel, così Aspose.Slides salva quelle immagini in `output/fallback-images` usando il comportamento predefinito. Risorse bitmap e metafile più grandi, così come le risorse SVG, sono gestite dal codice personalizzato. Per esempio, un riferimento locale generato come `fallback-images/image1.png` diventa `https://cdn.example.com/presentations/quarterly-report/image1.png`. I gestori usano percorsi del sistema operativo solo durante la scrittura dei file; i collegamenti scritti nel Markdown usano barre oblique e nomi file con escape URL. Applicare la stessa regola quando si costruiscono collegamenti relativi: usare `/`, non il separatore di directory specifico della piattaforma.

## **FAQ**

**Un unico gestore può elaborare sia immagini raster che SVG?**

No. Usare [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/it/python-java/aspose.slides/markdownsaveoptions/) per le risorse bitmap e metafile emesse e [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/it/python-java/aspose.slides/markdownsaveoptions/) per le risorse emesse come SVG. Il primo fornisce un oggetto immagine e un valore [ImageFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/imageformat/); il secondo fornisce un oggetto [SvgImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/) il cui dato SVG può essere letto con [SvgImage.getSvgData](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/#getSvgData). Uno SVG di origine rasterizzato durante l’esportazione è elaborato dalla callback di salvataggio immagine invece.

**Cosa succede quando un gestore di salvataggio immagine restituisce `False`?**

Aspose.Slides utilizza il comportamento di salvataggio locale predefinito. La posizione dell’immagine e il riferimento generato sono controllati dai valori impostati con [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/it/python-java/aspose.slides/markdownsaveoptions/#setBasePath) e [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/it/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

**Un gestore può fornire un URL senza salvare l’immagine localmente?**

Sì. Il gestore può caricare l’immagine su storage di oggetti o passarla a un altro servizio, assegnare l’URL risultante a `link[0]` e restituire `True`. Il gestore deve completare l’elaborazione da solo; restituire `True` impedisce il salvataggio locale predefinito.

**Perché l’esportazione Markdown genera un `InvalidOperationException` dal gestore?**

Questa eccezione si verifica quando il gestore restituisce `True` ma non fornisce un collegamento valido. Assegnare il percorso relativo o l’URL esterno che deve essere scritto nel Markdown prima di restituire `True`.

**Quale separatore di percorso devono usare i collegamenti alle immagini?**

Usare le barre oblique nei collegamenti Markdown e negli URL. Usare `pathlib.Path` solo per i percorsi del file system, quindi costruire o normalizzare il riferimento Markdown separatamente.

**I collegamenti ipertestuali vengono mantenuti durante l’esportazione Markdown?**

Sì. I [collegamenti ipertestuali](/slides/it/python-java/manage-hyperlinks/) nel testo sono preservati come normali collegamenti Markdown. Le [transizioni](/slides/it/python-java/slide-transition/) e le [animazioni](/slides/it/python-java/powerpoint-animation/) delle diapositive non vengono convertite.

**Le presentazioni possono essere convertite in Markdown in parallelo?**

È possibile elaborare file di presentazione diversi in parallelo, ma non condividere la stessa istanza di [Presentation](/slides/it/python-java/aspose.slides/presentation/) tra thread. Seguire le [linee guida per il multithreading](/slides/it/python-java/multithreading/) e usare un’istanza separata per ciascun file.