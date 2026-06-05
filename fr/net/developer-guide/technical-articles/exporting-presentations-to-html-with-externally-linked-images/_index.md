---
title: Exporter des présentations en HTML avec des images liées externes
type: docs
weight: 100
url: /fr/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter présentation
- exporter diapositive
- exporter PPT
- exporter PPTX
- exporter ODP
- PowerPoint vers HTML
- OpenDocument vers HTML
- présentation vers HTML
- diapositive vers HTML
- PPT vers HTML
- PPTX vers HTML
- ODP vers HTML
- image liée
- image liée externement
- ressource liée
- ressource externe
- .NET
- C#
- Aspose.Slides
description: "Exporter des présentations PowerPoint et OpenDocument en HTML dans .NET en utilisant Aspose.Slides avec les images et autres ressources enregistrées comme fichiers externes liés."
---
## **Vue d'ensemble**

Par défaut, Aspose.Slides exporte une présentation vers un fichier HTML autonome. Les images et autres ressources sont écrites directement dans le HTML, généralement sous forme de données Base64. Cela est pratique lorsque vous avez besoin d’un seul fichier portable, mais ce n’est pas toujours le meilleur format pour un site Web, un CMS ou un pipeline de conversion côté serveur.

Utilisez des ressources liées externes lorsque vous souhaitez :

- réduire la taille du document HTML ;
- mettre en cache les images, polices, audio ou vidéo séparément dans un navigateur ou un CDN ;
- inspecter, remplacer, compresser ou post‑traiter les ressources générées après l’exportation ;
- conserver une structure de sortie plus proche de ce qu’une application Web attend.

Pour le flux de travail général de conversion HTML, voir [Convertir des présentations PowerPoint en HTML](/slides/fr/net/convert-powerpoint-to-html/). Cet article se concentre sur la partie liaison des ressources de l’exportation.

## **Comment fonctionne l'exportation de ressources liées**

[ILinkEmbedController](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ilinkembedcontroller/) permet à votre application de décider, ressource par ressource, si l'exportateur intègre les données dans le HTML ou les enregistre à l'extérieur et écrit un lien.

L’interface possède trois méthodes :

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) détermine si une ressource doit être liée ou intégrée.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ilinkembedcontroller/geturl/) renvoie l’URL qui sera écrite dans le HTML généré ou dans une autre ressource liée.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) écrit les données de la ressource liée sur le disque ou vers une autre cible de stockage.

Le chemin du système de fichiers et l’URL du navigateur sont des préoccupations distinctes. Par exemple, l’exemple ci‑dessous écrit les fichiers de ressources dans `html-output/assets` sur le disque, tandis que le HTML contient des URL relatives comme `assets/resource-1.svg`. Un navigateur résout ces URL par rapport au fichier qui contient le lien. Ainsi, un lien de `presentation.html` vers un fichier SVG utilise `assets/resource-1.svg`, tandis qu’un lien depuis ce fichier SVG vers une image enregistrée dans le même dossier `assets` utilise `resource-4.jpg`.

## **Exporter du HTML avec des ressources liées**

L’exemple C# suivant crée un répertoire de sortie, enregistre le fichier HTML à cet emplacement, et stocke les ressources liées dans un sous‑dossier `assets`. Le contrôleur lie les ressources d’image, de police, audio, vidéo et CSS courantes lorsque Aspose.Slides fournit ou peut déduire une extension de fichier sûre. Les ressources non reconnues restent intégrées.

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

Après l’exportation, le dossier de sortie a la structure suivante :

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

Les fichiers exacts dépendent du contenu de la présentation et des options d’exportation. Par exemple, les images matricielles sont généralement exportées en JPEG ou PNG. Aspose.Slides peut choisir un codec d’image différent de celui utilisé dans la présentation source lorsqu’il produit un fichier plus petit ou plus adapté. Les images avec transparence sont exportées en PNG.

## **Choix des URL pour le déploiement**

L’exemple utilise un préfixe d’URL relatif : `assets/`. Si `presentation.html` est ouvert depuis `html-output/presentation.html`, le navigateur charge `html-output/assets/resource-1.svg`.

Lorsque une ressource liée fait référence à une autre ressource liée, l’exemple utilise le paramètre `referrer` dans [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ilinkembedcontroller/geturl/) et ne renvoie que le nom de fichier. Par exemple, si `resource-1.svg` et `resource-4.jpg` sont tous deux dans le dossier `assets`, le fichier SVG doit référencer `resource-4.jpg`, et non `assets/resource-4.jpg`.

Utilisez un préfixe d’URL différent lorsque les fichiers sont déployés ailleurs :

- Utilisez `assets/` lorsque le répertoire des actifs se trouve à côté du fichier HTML.
- Utilisez `../assets/` lorsque le répertoire des actifs est un niveau au-dessus du fichier HTML.
- Utilisez `https://cdn.example.com/presentations/job-123/assets/` lorsque les fichiers sont téléchargés vers un CDN ou un serveur de fichiers statiques.

L’URL renvoyée par [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ilinkembedcontroller/geturl/) doit correspondre à l’emplacement final déployé du fichier écrit par [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ilinkembedcontroller/saveexternal/). Dans les applications serveur, utilisez un répertoire de sortie unique ou un préfixe de stockage d’objet pour chaque travail de conversion afin d’éviter d’écraser les fichiers d’une autre exportation.

## **Quand intégrer plutôt**

Le HTML intégré en Base64 reste utile lorsque la sortie doit être un seul fichier, comme une pièce jointe d’e‑mail, un aperçu hors ligne ou un document qui sera déplacé sans dossier d’actifs associé. Les ressources liées sont plus appropriées lorsque le HTML sera servi par une application Web, stocké dans un CMS, optimisé par un pipeline de construction ou mis en cache par les navigateurs de façon indépendante du HTML.

## **FAQ**

**Puis‑je externaliser uniquement les images et garder les autres ressources intégrées ?**

Oui. Dans [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/), renvoyez `LinkEmbedDecision.Link` uniquement pour les types de contenu que vous souhaitez enregistrer comme fichiers séparés, et renvoyez `LinkEmbedDecision.Embed` pour tout le reste.

**Pourquoi l’extension de l’image exportée diffère‑t‑elle de celle de la présentation source ?**

Aspose.Slides peut ré‑encoder les images matricielles lors de l’exportation HTML afin d’améliorer la taille ou la compatibilité navigateur. Par exemple, une image du fichier source peut être écrite en JPEG ou PNG selon le résultat rendu.

**Les URL relatives fonctionnent‑elles après avoir déplacé le fichier HTML ?**

Les URL relatives ne fonctionnent que lorsque la même structure de dossiers relative est préservée. Si le HTML référence `assets/resource-1.png`, le dossier `assets` doit rester à côté du fichier HTML sauf si vous générez un préfixe d’URL différent.

**Les applications serveur doivent‑elles réutiliser le même dossier de sortie ?**

Non. Utilisez un répertoire de sortie unique ou un préfixe de stockage pour chaque travail de conversion. Cela évite les collisions de noms de fichiers et empêche une exportation d’écraser les ressources générées par une autre exportation.