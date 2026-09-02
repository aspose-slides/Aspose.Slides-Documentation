---
title: Convertir des présentations PowerPoint en Markdown en C++
linktitle: PowerPoint vers Markdown
type: docs
weight: 140
url: /fr/cpp/convert-powerpoint-to-markdown/
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
- enregistrer PowerPoint en tant que Markdown
- enregistrer présentation en tant que Markdown
- enregistrer diapositive en tant que Markdown
- enregistrer PPT en MD
- enregistrer PPTX en MD
- exporter PPT en MD
- exporter PPTX en MD
- export d'images Markdown
- liens d'images CDN
- PowerPoint
- présentation
- Markdown
- C++
- Aspose.Slides
description: "Convertir des présentations PPT et PPTX en Markdown avec C++ et contrôler où les images bitmap, métafichier et SVG exportées sont enregistrées et référencées."
---
## **Aperçu**

Aspose.Slides for C++ peut convertir des présentations PPT et PPTX en Markdown pour la documentation, les sites statiques, la migration de contenu et les flux de travail de contrôle de version. Vous pouvez choisir une variante de Markdown, contrôler la façon dont le contenu des diapositives est rendu, et décider où les images exportées sont stockées et comment le Markdown généré les référence.

Par défaut, l’exportation Markdown utilise une sortie texte uniquement. Pour exporter du contenu visuel, définissez la méthode [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) sur la valeur `Sequential` ou `Visual` de l’énumération [MarkdownExportType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/markdownexporttype/). `Sequential` rend les éléments de diapositive séparément et dans l’ordre, alors que `Visual` regroupe les éléments afin de préserver leur relation visuelle. La valeur `TextOnly` n’émet pas de ressources image, de sorte que les événements d’enregistrement d’image ne sont pas invoqués dans ce mode.

## **Convertir une présentation en Markdown**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) , puis appelez la méthode [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) avec la valeur `Md` de l’énumération [SaveFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveformat/).

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Sélectionner une variante de Markdown**

La méthode [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) contrôle la spécification Markdown utilisée pour la sortie. L’énumération [Flavor](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/flavor/) comprend CommonMark, GitHub Flavored Markdown et d’autres variantes prises en charge.

L’exemple suivant exporte une présentation au format CommonMark :

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **Exporter des images en utilisant le comportement de sauvegarde local par défaut**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/markdownsaveoptions/) propose deux méthodes pour configurer les images enregistrées localement :

- [set_BasePath](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) spécifie le répertoire de base du document Markdown et de ses ressources.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) spécifie le sous‑répertoire des images. Sa valeur par défaut est `Images`.

L’exemple suivant rend le contenu visuel, écrit les images dans `output/assets` et crée des références d’image relatives dans le document Markdown :

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Ce comportement sert également de solution de repli lorsqu’un gestionnaire d’enregistrement d’image personnalisé renvoie `false`.

## **Personnaliser l'enregistrement d'images et les liens Markdown**

Utilisez l’événement `MarkdownSaveOptions::ImageSaving` pour les ressources bitmap et métafichier non SVG émises lors de l’exportation Markdown. Son délégué [MarkdownImageSavingHandler](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) reçoit l’objet [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/), son [ImageFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imageformat/), et le lien Markdown généré sous forme de paramètre `System::String&`. Enregistrez ou téléversez l’image avec le format fourni, puis remplacez `link` par la référence qui doit apparaître dans la sortie Markdown.

Les ressources émises au format SVG sont traitées séparément. Abonnez‑vous à l’événement `MarkdownSaveOptions::SvgImageSaving`, dont le délégué [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) reçoit un objet [ISvgImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isvgimage/) et le paramètre `System::String& link`. Un SVG n’a pas d’argument `ImageFormat` ; écrivez ou téléversez ses données XML via la méthode [ISvgImage::get_SvgData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isvgimage/get_svgdata/). Selon le mode d’exportation et le groupement visuel, un SVG présent dans la présentation source peut être rasterisé ou combiné avec d’autres contenus ; la ressource non SVG résultante est alors transmise à `ImageSaving`. Abonnez‑vous aux deux événements lorsque chaque ressource visuelle exportée nécessite un traitement personnalisé.

La valeur de retour du gestionnaire détermine qui traite l’image :

- Retournez `true` après que le gestionnaire a enregistré, téléversé, transformé ou autrement traité l’image et a assigné une valeur valide à `link`. Aspose.Slides écrit cette valeur dans le document Markdown et n’effectue pas son enregistrement local par défaut.
- Retournez `false` pour laisser Aspose.Slides enregistrer l’image localement et générer son lien selon [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) et [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Un gestionnaire qui retourne `true` assume la responsabilité de l’image. S’il retourne `true` sans assigner un lien valide et non vide, l’exportation échoue avec une `InvalidOperationException`.
{{% /alert %}}

### **Enregistrer les images dans un répertoire d'origine CDN et utiliser des URL externes**

L’exemple suivant considère `cdn-origin/presentations/quarterly-report` comme un répertoire d’origine CDN monté ou synchronisé. Chaque gestionnaire extrait le nom de fichier généré, enregistre l’image dans ce répertoire personnalisé et remplace la référence locale générée par une URL publique CDN. L’échantillon lui‑même n’effectue aucun téléversement réseau : l’URL ne devient valide qu’après que le répertoire a été monté comme origine CDN ou que ses fichiers ont été publiés sur le CDN. Pour le stockage d’objets, remplacez l’écriture sur le système de fichiers par l’opération de téléversement du SDK de stockage et assignez `link` uniquement après la réussite du téléversement.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Le gestionnaire bitmap renvoie délibérément `false` pour les images inférieures à 128 × 128 pixels, de sorte qu’Aspose.Slides enregistre ces images dans `output/fallback-images` en utilisant le comportement par défaut. Les ressources bitmap et métafichier plus grandes, ainsi que les ressources SVG, sont traitées par le code personnalisé. Par exemple, une référence locale générée telle que `fallback-images/image1.png` devient `https://cdn.example.com/presentations/quarterly-report/image1.png`. Les gestionnaires n’utilisent les chemins du système d’exploitation que pour écrire les fichiers ; les liens écrits dans le Markdown utilisent des barres obliques (`/`) et des noms de fichiers échappés pour les URL. Appliquez la même règle lors de la construction de liens relatifs : utilisez `/`, pas le séparateur de répertoire spécifique à la plateforme.

## **FAQ**

**Un gestionnaire peut-il traiter à la fois les images raster et les images SVG ?**

Non. Utilisez `MarkdownSaveOptions::ImageSaving` pour les ressources bitmap et métafichier émises et `MarkdownSaveOptions::SvgImageSaving` pour les ressources émises au format SVG. Le premier fournit un objet [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/) et un [ImageFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imageformat/); le second fournit un objet [ISvgImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isvgimage/) dont les données SVG peuvent être lues avec [ISvgImage::get_SvgData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isvgimage/get_svgdata/). Un SVG source rasterisé pendant l’exportation est traité par `ImageSaving` à la place.

**Que se passe-t-il lorsqu'un gestionnaire d'enregistrement d'image renvoie `false` ?**

Aspose.Slides utilise son comportement d’enregistrement local par défaut. L’emplacement de l’image et la référence générée sont contrôlés par [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) et [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**Un gestionnaire peut-il fournir une URL sans enregistrer l'image localement ?**

Oui. Le gestionnaire peut téléverser l’image vers un stockage d’objets ou la transmettre à un autre service, assigner l’URL résultante à `link` et retourner `true`. Le gestionnaire doit effectuer lui‑-même le traitement ; retourner `true` empêche l’enregistrement local par défaut.

**Pourquoi l'exportation Markdown lève-t-elle une `InvalidOperationException` provenant d'un gestionnaire ?**

Cette exception se produit lorsque le gestionnaire renvoie `true` sans fournir de lien valide. Assignez le chemin relatif ou l’URL externe qui doit être écrit dans le Markdown avant de retourner `true`.

**Quel séparateur de chemin les liens d'image doivent-ils utiliser ?**

Utilisez des barres obliques (`/`) dans les liens Markdown et les URL. N’utilisez `Path::Combine` que pour les chemins du système de fichiers, puis construisez ou normalisez la référence Markdown séparément.

**Les hyperliens sont-ils conservés lors de l'exportation Markdown ?**

Oui. Le texte [hyperlinks](/slides/fr/cpp/manage-hyperlinks/) est conservé sous forme de liens Markdown standards. Les [transitions](/slides/fr/cpp/slide-transition/) et [animations](/slides/fr/cpp/powerpoint-animation/) des diapositives ne sont pas convertis.

**Les présentations peuvent-elles être converties en Markdown en parallèle ?**

Vous pouvez traiter différents fichiers de présentation en parallèle, mais ne partagez pas la même instance de [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) entre les threads. Suivez les [multithreading guidelines](/slides/fr/cpp/multithreading/) et utilisez une instance distincte pour chaque fichier.