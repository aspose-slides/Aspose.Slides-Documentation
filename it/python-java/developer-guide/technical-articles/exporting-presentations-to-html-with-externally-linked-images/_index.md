---
title: Esporta presentazioni in HTML con immagini collegate esternamente
type: docs
weight: 100
url: /it/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- esporta PowerPoint
- esporta OpenDocument
- esporta presentazione
- esporta diapositiva
- esporta PPT
- esporta PPTX
- esporta ODP
- PowerPoint in HTML
- OpenDocument in HTML
- presentazione in HTML
- diapositiva in HTML
- PPT in HTML
- PPTX in HTML
- ODP in HTML
- immagine collegata
- immagine collegata esternamente
- risorsa collegata
- risorsa esterna
- Python
- Java
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML in Python usando Aspose.Slides con immagini e altre risorse salvate come file collegati esternamente."
---
## **Panoramica**

Per impostazione predefinita, Aspose.Slides esporta una presentazione in un file HTML autonomo. Immagini e altre risorse vengono scritte direttamente nell'HTML, solitamente come dati Base64. Questo è comodo quando è necessario un unico file portatile, ma non è sempre il formato migliore per un sito web, un CMS o una pipeline di conversione lato server.

Usa risorse collegate esternamente quando desideri:

- ridurre le dimensioni del documento HTML;
- memorizzare nella cache immagini, font, audio o video separatamente in un browser o CDN;
- esaminare, sostituire, comprimere o post‑elaborare le risorse generate dopo l'esportazione;
- mantenere la struttura dell'output più vicina a quella che un'applicazione web si aspetta.

Per il flusso di lavoro generale di conversione HTML, vedere [Converti presentazioni PowerPoint in HTML](/slides/it/python-java/convert-powerpoint-to-html/). Questo articolo si concentra sulla parte di collegamento delle risorse dell'esportazione.

## **Come funziona l'esportazione delle risorse collegate**

`ILinkEmbedController` consente alla tua applicazione di decidere, risorsa per risorsa, se l'esportatore incorpora i dati nell'HTML o li salva esternamente scrivendo un collegamento.

L'interfaccia dispone di tre metodi:

- `ILinkEmbedController.getObjectStoringLocation` decide se una risorsa deve essere collegata o incorporata.
- `ILinkEmbedController.getUrl` restituisce l'URL che verrà scritto nell'HTML generato o in un'altra risorsa collegata.
- `ILinkEmbedController.saveExternal` scrive i dati della risorsa collegata su disco o in un altro destinazione di archiviazione.

Il percorso del file system e l'URL del browser sono considerazioni separate. Ad esempio, il campione qui sotto scrive i file di risorsa in `html-output/assets` su disco, mentre l'HTML contiene URL relativi come `assets/resource-1.svg`. Un browser risolve quegli URL rispetto al file che contiene il collegamento. Pertanto, un collegamento da `presentation.html` a un file SVG utilizza `assets/resource-1.svg`, mentre un collegamento da quel file SVG a un'immagine salvata nella stessa cartella `assets` utilizza `resource-4.jpg`.

## **Esporta HTML con risorse collegate**

Il seguente esempio Python crea una directory di output, salva il file HTML lì e memorizza le risorse collegate in una sottodirectory `assets`. Il controller collega le risorse comuni di immagini, font, audio, video e CSS quando Aspose.Slides fornisce o può dedurre un'estensione di file sicura. Le risorse non riconosciute rimangono incorporate.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Dopo l'esportazione, la cartella di output ha questa struttura:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

I file esatti dipendono dal contenuto della presentazione e dalle opzioni di esportazione. Ad esempio, le immagini raster sono comunemente esportate come JPEG o PNG. Aspose.Slides può scegliere un codec immagine diverso da quello usato nella presentazione di origine quando ciò produce un file più piccolo o più adatto. Le immagini con trasparenza sono esportate come PNG.

## **Scelta degli URL per il deployment**

Il campione utilizza un prefisso URL relativo: `assets/`. Se `presentation.html` viene aperto da `html-output/presentation.html`, il browser carica `html-output/assets/resource-1.svg`.

Quando una risorsa collegata fa riferimento a un'altra risorsa collegata, il campione utilizza il parametro `referrer` in `ILinkEmbedController.getUrl` e restituisce solo il nome del file. Ad esempio, se `resource-1.svg` e `resource-4.jpg` sono entrambi nella cartella `assets`, il file SVG dovrebbe fare riferimento a `resource-4.jpg`, non a `assets/resource-4.jpg`.

Utilizza un prefisso URL diverso quando i file sono distribuiti altrove:

- Usa `assets/` quando la directory delle risorse è accanto al file HTML.
- Usa `../assets/` quando la directory delle risorse è un livello sopra il file HTML.
- Usa `https://cdn.example.com/presentations/job-123/assets/` quando i file sono caricati su un CDN o su un server statico.

L'URL restituito da `ILinkEmbedController.getUrl` deve corrispondere alla posizione finale di distribuzione del file scritto da `ILinkEmbedController.saveExternal`. Nelle applicazioni server, utilizza una directory di output unica o un prefisso di archiviazione oggetti per ogni lavoro di conversione per evitare di sovrascrivere file da un'altra esportazione.

## **Quando incorporare invece**

L'HTML incorporato in Base64 è ancora utile quando l'output deve essere un unico file, ad esempio un allegato email, un'anteprima offline o un documento che verrà spostato senza una cartella di risorse di supporto. Le risorse collegate sono più adatte quando l'HTML sarà servito da un'applicazione web, memorizzato in un CMS, ottimizzato da una pipeline di build o memorizzato nella cache dai browser indipendentemente dall'HTML.

## **FAQ**

**Posso esternalizzare solo le immagini e mantenere le altre risorse incorporate?**

Sì. In `ILinkEmbedController.getObjectStoringLocation`, restituisci [LinkEmbedDecision.Link](https://reference.aspose.com/slides/it/python-java/aspose.slides/linkembeddecision/#Link) solo per i tipi di contenuto che desideri salvare come file separati, e restituisci [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/it/python-java/aspose.slides/linkembeddecision/#Embed) per tutto il resto.

**Perché l'estensione dell'immagine esportata differisce da quella della presentazione di origine?**

Aspose.Slides potrebbe ricodificare le immagini raster durante l'esportazione HTML per migliorare le dimensioni o la compatibilità con i browser. Ad esempio, un'immagine dal file di origine può essere scritta come JPEG o PNG a seconda del risultato renderizzato.

**Gli URL relativi funzionano dopo aver spostato il file HTML?**

Gli URL relativi funzionano solo quando la stessa struttura di cartelle relativa viene preservata. Se l'HTML fa riferimento a `assets/resource-1.png`, la cartella `assets` deve rimanere accanto al file HTML a meno che non generi un prefisso URL diverso.

**Le applicazioni server dovrebbero riutilizzare la stessa cartella di output?**

No. Usa una directory di output unica o un prefisso di archiviazione per ogni lavoro di conversione. Questo evita collisioni di nomi file e impedisce a un'esportazione di sovrascrivere le risorse generate da un'altra esportazione.