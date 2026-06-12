---
title: Esporta presentazioni in HTML con immagini collegate esternamente
type: docs
weight: 100
url: /it/net/exporting-presentations-to-html-with-externally-linked-images/
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
- .NET
- C#
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML su .NET utilizzando Aspose.Slides con immagini e altre risorse salvate come file collegati esternamente."
---
## **Panoramica**

Per impostazione predefinita, Aspose.Slides esporta una presentazione in un file HTML autonomo. Immagini e altre risorse vengono scritte direttamente nell'HTML, di solito come dati Base64. Questo è comodo quando serve un unico file portatile, ma non è sempre il formato migliore per un sito web, un CMS o una pipeline di conversione lato server.

Utilizza risorse collegate esternamente quando desideri:

- ridurre le dimensioni del documento HTML;
- memorizzare nella cache immagini, font, audio o video separatamente in un browser o CDN;
- ispezionare, sostituire, comprimere o post‑elaborare le risorse generate dopo l'esportazione;
- avvicinare la struttura di output a quella che si aspetta un'applicazione web.

Per il flusso di lavoro generale di conversione HTML, vedi [Converti presentazioni PowerPoint in HTML](/slides/it/net/convert-powerpoint-to-html/). Questo articolo si concentra sulla parte di collegamento delle risorse dell'esportazione.

## **Come funziona l'esportazione con risorse collegate**

[ILinkEmbedController](https://reference.aspose.com/slides/it/net/aspose.slides.export/ilinkembedcontroller/) consente alla tua applicazione di decidere, risorsa per risorsa, se l'esportatore incorpora i dati nell'HTML o li salva esternamente scrivendo un collegamento.

L'interfaccia dispone di tre metodi:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/it/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) decide se una risorsa deve essere collegata o incorporata.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/it/net/aspose.slides.export/ilinkembedcontroller/geturl/) restituisce l'URL che sarà scritto nell'HTML generato o in un'altra risorsa collegata.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/it/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) scrive i dati della risorsa collegata su disco o su un altro obiettivo di archiviazione.

Il percorso del file system e l'URL del browser sono preoccupazioni separate. Ad esempio, il campione qui sotto scrive i file di risorsa in `html-output/assets` sul disco, mentre l'HTML contiene URL relativi come `assets/resource-1.svg`. Un browser risolve quegli URL rispetto al file che contiene il collegamento. Pertanto, un collegamento da `presentation.html` a un file SVG utilizza `assets/resource-1.svg`, mentre un collegamento da quel file SVG a un'immagine salvata nella stessa cartella `assets` utilizza `resource-4.jpg`.

## **Esporta HTML con risorse collegate**

Il seguente esempio C# crea una directory di output, salva il file HTML lì e memorizza le risorse collegate in una sottodirectory `assets`. Il controller collega le comuni risorse immagine, font, audio, video e CSS quando Aspose.Slides le fornisce o può dedurre un’estensione di file sicura. Le risorse non riconosciute rimangono incorporate.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.IO;

var inputFilePath = "presentation.pptx";
var outputDirectory = "html-output";
var assetDirectoryName = "assets";
var assetDirectory = Path.Combine(outputDirectory, assetDirectoryName);

Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(assetDirectory);

var assetUrlPrefix = assetDirectoryName + "/";
var controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(string.Empty, false),
    SlideImageFormat = slideImageFormat
};

using var presentation = new Presentation(inputFilePath);

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

public sealed class ExternalResourceController : ILinkEmbedController
{
    private static readonly Dictionary<string, string> ExtensionsByContentType = new(StringComparer.OrdinalIgnoreCase)
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/gif"] = ".gif",
        ["image/bmp"] = ".bmp",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/x-emf"] = ".emf",
        ["image/x-wmf"] = ".wmf",
        ["font/woff"] = ".woff",
        ["font/woff2"] = ".woff2",
        ["font/ttf"] = ".ttf",
        ["application/font-woff"] = ".woff",
        ["application/vnd.ms-fontobject"] = ".eot",
        ["application/x-font-ttf"] = ".ttf",
        ["text/css"] = ".css",
        ["audio/mpeg"] = ".mp3",
        ["audio/mp4"] = ".m4a",
        ["audio/wav"] = ".wav",
        ["video/mp4"] = ".mp4",
        ["video/webm"] = ".webm"
    };

    private readonly string assetDirectory;
    private readonly string assetUrlPrefix;
    private readonly Dictionary<int, string> fileNamesByResourceId = new();

    public ExternalResourceController(string assetDirectory, string assetUrlPrefix)
    {
        if (string.IsNullOrWhiteSpace(assetDirectory))
        {
            throw new ArgumentException("The asset output directory must not be empty.", nameof(assetDirectory));
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
    }

    public LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        byte[] entityData,
        string semanticName,
        string contentType,
        string recommendedExtension)
    {
        var extension = ResolveExtension(contentType, recommendedExtension);
        if (extension == null)
        {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId[resourceId] = $"resource-{resourceId}{extension}";
        return LinkEmbedDecision.Link;
    }

    public string GetUrl(int resourceId, int referrer)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            return null;
        }

        if (fileNamesByResourceId.ContainsKey(referrer))
        {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    public void SaveExternal(int resourceId, byte[] entityData)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} was not registered for external storage.");
        }

        if (entityData == null || entityData.Length == 0)
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} contains no data and cannot be saved.");
        }

        Directory.CreateDirectory(assetDirectory);

        var filePath = Path.Combine(assetDirectory, fileName);
        File.WriteAllBytes(filePath, entityData);
    }

    private static string ResolveExtension(string contentType, string recommendedExtension)
    {
        if (!string.IsNullOrWhiteSpace(contentType) &&
            ExtensionsByContentType.TryGetValue(contentType, out var mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(contentType))
        {
            return null;
        }

        return NormalizeExtension(recommendedExtension);
    }

    private static bool IsSupportedContentType(string contentType)
    {
        return contentType != null &&
            (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("font/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
    }

    private static string NormalizeExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return null;
        }

        var extensionCharacters = extension.Trim().TrimStart('.');
        foreach (var character in extensionCharacters)
        {
            if (!char.IsLetterOrDigit(character))
            {
                return null;
            }
        }

        return "." + extensionCharacters.ToLowerInvariant();
    }

    private static string NormalizeUrlPrefix(string urlPrefix)
    {
        if (string.IsNullOrEmpty(urlPrefix))
        {
            return string.Empty;
        }

        var normalizedUrlPrefix = urlPrefix.Replace('\\', '/');
        return normalizedUrlPrefix.EndsWith("/")
            ? normalizedUrlPrefix
            : normalizedUrlPrefix + "/";
    }
}
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

I file effettivi dipendono dal contenuto della presentazione e dalle opzioni di esportazione. Ad esempio, le immagini raster sono comunemente esportate come JPEG o PNG. Aspose.Slides può scegliere un codec immagine diverso da quello usato nella presentazione originale quando ciò produce un file più piccolo o più adatto. Le immagini con trasparenza sono esportate come PNG.

## **Scelta degli URL per il deployment**

Il campione utilizza un prefisso URL relativo: `assets/`. Se `presentation.html` viene aperto da `html-output/presentation.html`, il browser carica `html-output/assets/resource-1.svg`.

Quando una risorsa collegata fa riferimento a un'altra risorsa collegata, il campione usa il parametro `referrer` in [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/it/net/aspose.slides.export/ilinkembedcontroller/geturl/) e restituisce solo il nome file. Per esempio, se `resource-1.svg` e `resource-4.jpg` sono entrambi nella cartella `assets`, il file SVG dovrebbe fare riferimento a `resource-4.jpg`, non a `assets/resource-4.jpg`.

Usa un prefisso URL diverso quando i file sono distribuiti altrove:

- Usa `assets/` quando la directory delle risorse è accanto al file HTML.
- Usa `../assets/` quando la directory delle risorse è un livello sopra il file HTML.
- Usa `https://cdn.example.com/presentations/job-123/assets/` quando i file sono caricati su una CDN o su un server di file statici.

L'URL restituito da [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/it/net/aspose.slides.export/ilinkembedcontroller/geturl/) deve corrispondere alla posizione finale di distribuzione del file scritto da [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/it/net/aspose.slides.export/ilinkembedcontroller/saveexternal/). Nelle applicazioni server, utilizza una directory di output o un prefisso di archiviazione univoco per ogni lavoro di conversione per evitare di sovrascrivere file da un’altra esportazione.

## **Quando incorporare invece**

L'HTML incorporato in Base64 è ancora utile quando l'output deve essere un unico file, ad esempio un allegato email, un'anteprima offline o un documento che verrà spostato senza una cartella di risorse di supporto. Le risorse collegate sono più adatte quando l'HTML sarà servito da un'applicazione web, archiviato in un CMS, ottimizzato da una pipeline di build o memorizzato nella cache dei browser indipendentemente dall'HTML.

## **FAQ**

**Posso esternalizzare solo le immagini e mantenere le altre risorse incorporate?**

Sì. In [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/it/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/), restituisci `LinkEmbedDecision.Link` solo per i tipi di contenuto che desideri salvare come file separati, e restituisci `LinkEmbedDecision.Embed` per tutto il resto.

**Perché l'estensione dell'immagine esportata differisce da quella della presentazione originale?**

Aspose.Slides può ricodificare le immagini raster durante l'esportazione HTML per migliorare le dimensioni o la compatibilità con i browser. Ad esempio, un'immagine del file di origine può essere scritta come JPEG o PNG a seconda del risultato renderizzato.

**Gli URL relativi funzionano dopo aver spostato il file HTML?**

Gli URL relativi funzionano solo quando viene preservita la stessa struttura di cartelle relativa. Se l'HTML fa riferimento a `assets/resource-1.png`, la cartella `assets` deve rimanere accanto al file HTML a meno che tu non generi un prefisso URL diverso.

**Le applicazioni server dovrebbero riutilizzare la stessa cartella di output?**

No. Usa una directory di output o un prefisso di archiviazione univoco per ogni lavoro di conversione. Questo evita collisioni di nomi file e impedisce a un'esportazione di sovrascrivere le risorse generate da un'altra esportazione.