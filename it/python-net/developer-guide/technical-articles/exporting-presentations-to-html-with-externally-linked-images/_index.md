---
title: Esporta presentazioni in HTML con immagini collegate esternamente in Python
linktitle: Esporta presentazioni in HTML con immagini collegate esternamente
type: docs
weight: 100
url: /it/python-net/exporting-presentations-to-html-with-externally-linked-images/
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
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML in Python utilizzando Aspose.Slides con immagini salvate come file collegati esternamente."
---
## **Panoramica**

Per impostazione predefinita, Aspose.Slides esporta una presentazione in un file HTML autonomo. Immagini e altre risorse vengono scritte direttamente nell'HTML, solitamente come dati Base64. Questo è comodo quando è necessario un unico file portabile, ma non è sempre il formato migliore per un sito web, un CMS o una pipeline di conversione lato server.

Usa immagini collegate esternamente quando desideri:

- ridurre le dimensioni del documento HTML;
- memorizzare nella cache le immagini separatamente in un browser o CDN;
- ispezionare, sostituire, comprimere o post‑elaborare le immagini generate dopo l'esportazione;
- mantenere la struttura di output più vicina a quella che si aspetta un'applicazione web.

Per il flusso di lavoro generale di conversione HTML, vedi [Converti presentazioni PowerPoint in HTML](/slides/it/python-net/convert-powerpoint-to-html/). Questo articolo si concentra sulla parte di collegamento delle immagini dell'esportazione.

## **Come funziona l'esportazione di immagini collegate**

In .NET e Java, [ILinkEmbedController](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/ilinkembedcontroller/) rappresenta l'interfaccia di callback usata dall'esportatore per decidere se una risorsa deve essere incorporata o collegata. In Python tramite .NET, le classi Python non possono attualmente implementare direttamente questa interfaccia di callback .NET, quindi il flusso di lavoro pratico è:

1. Esporta la presentazione in HTML con [HtmlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/htmloptions/).
1. Usa [SlideImageFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/slideimageformat/) con [SVGOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/svgoptions/) affinché le diapositive siano rappresentate come SVG nell'HTML.
1. Sposta i dati immagine Base64 dagli URL `data:` dell'HTML in file separati.
1. Sostituisci gli URL originali `data:` con collegamenti relativi come `assets/resource-1.jpg`.

Il percorso del file system e l'URL del browser sono preoccupazioni separate. Per esempio, il campione qui sotto scrive i file immagine in `html-output/assets` sul disco, mentre l'HTML contiene URL relativi come `assets/resource-1.jpg`. Un browser risolve quegli URL rispetto al file HTML che contiene il collegamento.

## **Esporta HTML con immagini collegate**

Il seguente esempio Python crea una directory di output, salva il file HTML lì, archivia le immagini estratte in una sottocartella `assets` e riscrive gli URL immagine Base64 in collegamenti relativi. L'esempio estrae i formati immagine Base64 più comuni quando Aspose.Slides fornisce un'estensione di file sicura. Gli URL dei dati non riconosciuti rimangono incorporati.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

Dopo l'esportazione, la cartella di output può avere questa struttura:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

I file esatti dipendono dal contenuto della presentazione e dalle opzioni di esportazione. Per esempio, le immagini raster vengono generalmente esportate come JPEG o PNG. Aspose.Slides può scegliere un codec immagine diverso da quello usato nella presentazione di origine quando ciò produce un file più piccolo o più adatto. Le immagini con trasparenza sono esportate come PNG.

## **Scelta degli URL per il deployment**

Il campione utilizza un prefisso URL relativo: `assets/`. Se `presentation.html` viene aperto da `html-output/presentation.html`, il browser carica `html-output/assets/resource-1.jpg`.

Usa un nome di directory degli asset diverso o riscrivi i collegamenti generati quando i file vengono distribuiti altrove:

- Usa `assets/` quando la directory degli asset è accanto al file HTML.
- Usa `../assets/` quando la directory degli asset è un livello sopra il file HTML.
- Usa `https://cdn.example.com/presentations/job-123/assets/` quando i file sono caricati su un CDN o un server di file statici.

Nelle applicazioni server, utilizza una directory di output o un prefisso di storage unico per ciascun lavoro di conversione per evitare di sovrascrivere file di un'altra esportazione.

## **Quando incorporare invece**

L'HTML con immagini Base64 incorporate è ancora utile quando l'output deve essere un unico file, ad esempio un allegato email, un'anteprima offline o un documento che verrà spostato senza una cartella di asset di supporto. Le immagini collegate sono più adatte quando l'HTML sarà servito da un'applicazione web, memorizzato in un CMS, ottimizzato da una pipeline di build o memorizzato nella cache dei browser indipendentemente dall'HTML.

## **FAQ**

**Posso esternalizzare solo le immagini e mantenere le altre risorse incorporate?**

Sì. Il campione estrae solo gli URL dati Base64 `image/*` i cui tipi di contenuto sono elencati in `EXTENSIONS_BY_CONTENT_TYPE`. Gli altri URL dati rimangono incorporati.

**Perché l'estensione dell'immagine esportata differisce da quella della presentazione di origine?**

Aspose.Slides può ricodificare le immagini raster durante l'esportazione HTML per migliorare le dimensioni o la compatibilità con i browser. Per esempio, un'immagine del file di origine può essere scritta come JPEG o PNG a seconda del risultato renderizzato.

**Gli URL relativi funzionano dopo aver spostato il file HTML?**

Gli URL relativi funzionano solo quando la stessa struttura di cartelle relative è preservata. Se l'HTML fa riferimento a `assets/resource-1.png`, la cartella `assets` deve rimanere accanto al file HTML a meno che non si generi un prefisso URL diverso.

**Le applicazioni server devono riutilizzare la stessa cartella di output?**

No. Usa una directory di output o un prefisso di storage unico per ciascun lavoro di conversione. Questo evita collisioni di nomi file e impedisce a un'esportazione di sovrascrivere le risorse generate da un'altra esportazione.