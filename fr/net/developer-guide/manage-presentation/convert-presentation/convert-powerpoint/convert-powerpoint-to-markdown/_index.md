---
title: Convertir des présentations PowerPoint en Markdown avec .NET
linktitle: PowerPoint en Markdown
type: docs
weight: 140
url: /fr/net/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en MD
- présentation en MD
- diapositive en MD
- PPT en MD
- PPTX en MD
- enregistrer PowerPoint au format Markdown
- enregistrer présentation au format Markdown
- enregistrer diapositive au format Markdown
- enregistrer PPT au format MD
- enregistrer PPTX au format MD
- exporter PPT en MD
- exporter PPTX en MD
- "exportation d'image Markdown"
- "liens d'images CDN"
- PowerPoint
- présentation
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Convertir les présentations PPT et PPTX en Markdown sous .NET et contrôler où les images bitmap, métafichier et SVG exportées sont enregistrées et référencées."
---
## **Vue d'ensemble**

Aspose.Slides for .NET peut convertir des présentations PPT et PPTX en Markdown pour la documentation, les sites statiques, la migration de contenu et les flux de travail de contrôle de version. Vous pouvez choisir une variante de Markdown, contrôler la façon dont le contenu des diapositives est rendu et décider où les images exportées sont stockées ainsi que la façon dont le Markdown généré les référence.

Par défaut, l’exportation Markdown utilise une sortie texte uniquement. Pour exporter du contenu visuel, définissez la propriété [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions/exporttype/) sur la valeur `Sequential` ou `Visual` de l’énumération [MarkdownExportType](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownexporttype/). `Sequential` rend les éléments de diapositive séparément et dans l’ordre, tandis que `Visual` maintient les éléments groupés afin de préserver leur relation visuelle. La valeur `TextOnly` n’émet pas de ressources image, de sorte que les événements d’enregistrement d’image ne sont pas déclenchés dans ce mode.

## **Convertir une présentation en Markdown**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) puis appelez la méthode [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) avec la valeur `Md` de l’énumération [SaveFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Sélectionner une variante de Markdown**

La propriété [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions/flavor/) contrôle la spécification Markdown utilisée pour la sortie. L’énumération [Flavor](https://reference.aspose.com/slides/fr/net/aspose.slides.export/flavor/) comprend CommonMark, GitHub Flavored Markdown et d’autres variantes prises en charge.

L’exemple suivant exporte une présentation au format CommonMark :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Exporter les images en utilisant le comportement d’enregistrement local par défaut**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions/) propose deux propriétés pour les images enregistrées localement :

- [BasePath](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions/basepath/) indique le répertoire de base du document Markdown et de ses ressources.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) indique le sous‑répertoire des images. Sa valeur par défaut est `Images`.

L’exemple suivant rend le contenu visuel, écrit les images dans `output/assets` et crée des références d’image relatives dans le document Markdown :

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Ce comportement sert également de solution de secours lorsqu’un gestionnaire d’enregistrement d’image personnalisé renvoie `false`.

## **Personnaliser l’enregistrement des images et les liens Markdown**

Utilisez l’événement [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions/imagesaving/) pour les ressources bitmap et métafichier non SVG émises lors de l’exportation Markdown. Son délégué [MarkdownImageSavingHandler](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) reçoit l’objet [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/), son [ImageFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/imageformat/) et le lien Markdown généré sous forme de paramètre `ref string`. Enregistrez ou téléversez l’image avec le format fourni, puis remplacez `link` par la référence qui doit apparaître dans la sortie Markdown.

Les ressources émises au format SVG sont gérées séparément. Abonnez‑vous à l’événement [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/), dont le délégué [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) reçoit un objet [ISvgImage](https://reference.aspose.com/slides/fr/net/aspose.slides/isvgimage/) et le paramètre `ref string link`. Un SVG n’a pas d’argument `ImageFormat` ; écrivez ou téléversez ses données XML depuis la propriété [ISvgImage.SvgData](https://reference.aspose.com/slides/fr/net/aspose.slides/isvgimage/svgdata/) à la place. En fonction du mode d’exportation et du regroupement visuel, un SVG présent dans la présentation source peut être rasterisé ou combiné avec d’autres contenus ; la ressource non SVG résultante est alors transmise à `ImageSaving`. Abonnez‑vous aux deux événements lorsque chaque ressource visuelle exportée nécessite un traitement personnalisé.

La valeur de retour du gestionnaire détermine qui traite l’image :

- Retournez `true` après que le gestionnaire a enregistré, téléversé, transformé ou autrement traité l’image et a attribué une valeur valide à `link`. Aspose.Slides écrit cette valeur dans le document Markdown et n’effectue pas son enregistrement local par défaut.
- Retournez `false` pour laisser Aspose.Slides enregistrer l’image localement et générer son lien selon [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions/basepath/) et [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

{{% alert color="warning" title="Important" %}}

Un gestionnaire qui renvoie `true` assume la responsabilité de l’image. S’il renvoie `true` sans attribuer un lien valide et non vide, l’exportation échoue avec une `InvalidOperationException`.

{{% /alert %}}

### **Enregistrer les images dans un répertoire d’origine CDN et utiliser des URL externes**

L’exemple suivant traite `cdn-origin/presentations/quarterly-report` comme un répertoire d’origine CDN monté ou synchronisé. Chaque gestionnaire extrait le nom de fichier généré, enregistre l’image dans ce répertoire personnalisé et remplace la référence locale générée par une URL publique CDN. L’exemple lui‑même ne réalise aucun téléversement réseau : l’URL devient valide uniquement après que le répertoire a été monté comme origine CDN ou que ses fichiers ont été publiés sur le CDN. Pour le stockage d’objets, remplacez l’écriture sur le système de fichiers par l’opération de téléversement du SDK de stockage et attribuez `link` uniquement après le succès du téléversement.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Le gestionnaire bitmap renvoie délibérément `false` pour les images plus petites que 128 × 128 pixels, de sorte qu’Aspose.Slides enregistre ces images dans `output/fallback-images` en utilisant le comportement par défaut. Les ressources bitmap et métafichier plus grandes, ainsi que les ressources SVG, sont traitées par le code personnalisé. Par exemple, une référence locale générée telle que `fallback-images/image1.png` devient `https://cdn.example.com/presentations/quarterly-report/image1.png`. Les gestionnaires utilisent uniquement les chemins du système d’exploitation lors de l’écriture des fichiers ; les liens inscrits dans le Markdown utilisent des barres obliques (`/`) et des noms de fichiers échappés pour les URL. Appliquez la même règle lors de la construction de liens relatifs : utilisez `/`, pas le séparateur de répertoire spécifique à la plateforme.

## **FAQ**

**Un gestionnaire peut‑il traiter à la fois les images raster et les images SVG ?**

Non. Utilisez [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions/imagesaving/) pour les ressources bitmap et métafichier émises et [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) pour les ressources émises en SVG. Le premier fournit un objet [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/) et un [ImageFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/imageformat/) ; le second fournit un objet [ISvgImage](https://reference.aspose.com/slides/fr/net/aspose.slides/isvgimage/) dont les données SVG peuvent être lues via [ISvgImage.SvgData](https://reference.aspose.com/slides/fr/net/aspose.slides/isvgimage/svgdata/). Un SVG source rasterisé pendant l’exportation est traité par `ImageSaving` à la place.

**Que se passe‑t‑il lorsqu’un gestionnaire d’enregistrement d’image renvoie `false` ?**

Aspose.Slides utilise son comportement d’enregistrement local par défaut. L’emplacement de l’image et la référence générée sont contrôlés par [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions/basepath/) et [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/fr/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

**Un gestionnaire peut‑il fournir une URL sans enregistrer l’image localement ?**

Oui. Le gestionnaire peut téléverser l’image vers un stockage d’objets ou la transmettre à un autre service, attribuer l’URL résultante à `link` et renvoyer `true`. Le gestionnaire doit effectuer lui‑même tout le traitement ; renvoyer `true` empêche l’enregistrement local par défaut.

**Pourquoi l’exportation Markdown lève‑t‑elle une `InvalidOperationException` provenant d’un gestionnaire ?**

Cette exception se produit lorsque le gestionnaire renvoie `true` mais ne fournit pas de lien valide. Assignez le chemin relatif ou l’URL externe qui doit être écrit dans le Markdown avant de renvoyer `true`.

**Quel séparateur de chemin les liens d’image doivent‑ils utiliser ?**

Utilisez des barres obliques (`/`) dans les liens Markdown et les URL. Utilisez `Path.Combine` uniquement pour les chemins du système de fichiers, puis construisez ou normalisez séparément la référence Markdown.

**Les hyperliens sont‑ils conservés lors de l’exportation Markdown ?**

Oui. Les [hyperliens](/slides/fr/net/manage-hyperlinks/) texte sont conservés sous forme de liens Markdown standard. Les [transitions](/slides/fr/net/slide-transition/) de diapositive et les [animations](/slides/fr/net/powerpoint-animation/) ne sont pas converties.

**Les présentations peuvent‑elles être converties en Markdown en parallèle ?**

Vous pouvez traiter différents fichiers de présentation en parallèle, mais ne partagez pas la même instance de [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) entre les threads. Suivez les [directives de multithreading](/slides/fr/net/multithreading/) et utilisez une instance distincte pour chaque fichier.