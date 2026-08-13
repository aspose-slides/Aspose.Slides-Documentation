---
title: "Optimiser la gestion des images dans les présentations avec C++"
linktitle: "Gérer les images"
type: docs
weight: 10
url: /fr/cpp/image/
keywords:
- ajouter une image
- ajouter une image
- ajouter un bitmap
- remplacer une image
- remplacer une image
- depuis le web
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- ressources SVG externes
- résolveur SVG
- images SVG liées
- polices SVG
- ajouter EMF
- ajouter WMF
- ajouter TIFF
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Simplifiez la gestion des images dans PowerPoint et OpenDocument avec Aspose.Slides pour C++, en optimisant les performances et en automatisant votre flux de travail."
---
## **Introduction**

Les images rendent les présentations plus attrayantes et visuellement plaisantes. Dans Microsoft PowerPoint, vous pouvez insérer des images dans les diapositives à partir de fichiers, d'Internet ou d'autres sources. De même, Aspose.Slides vous permet d'ajouter des images aux diapositives de présentation de plusieurs manières. 

{{% alert title="Tip" color="info" %}} 

Aspose propose des convertisseurs gratuits —[JPEG vers PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt)—qui vous permettent de créer rapidement des présentations à partir d'images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si vous souhaitez ajouter une image sous forme de cadre d’image — notamment si vous prévoyez de la redimensionner, d’appliquer des effets ou d’utiliser d’autres options de mise en forme standard — consultez [Picture Frame](/slides/fr/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Vous pouvez convertir des images d’un format à un autre. Consultez les pages suivantes : convertissez [image en JPG](https://products.aspose.com/slides/fr/cpp/conversion/image-to-jpg/), [JPG en image](https://products.aspose.com/slides/fr/cpp/conversion/jpg-to-image/), [JPG en PNG](https://products.aspose.com/slides/fr/cpp/conversion/jpg-to-png/), [PNG en JPG](https://products.aspose.com/slides/fr/cpp/conversion/png-to-jpg/), [PNG en SVG](https://products.aspose.com/slides/fr/cpp/conversion/png-to-svg/), et [SVG en PNG](https://products.aspose.com/slides/fr/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides prend en charge les images dans les formats populaires tels que JPEG, PNG, BMP, GIF et d’autres. 

## **Ajouter des images stockées localement aux diapositives**

Vous pouvez ajouter une ou plusieurs images stockées sur votre ordinateur à une diapositive de présentation. Le code d’exemple C++ suivant montre comment ajouter une image à une diapositive :

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Ajouter des images depuis le Web aux diapositives**

Si l’image que vous souhaitez ajouter à une diapositive n’est pas stockée sur votre ordinateur, vous pouvez l’ajouter directement depuis le Web. 

Le code d’exemple C++ suivant montre comment ajouter une image depuis le Web à une diapositive :

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Ajouter des images aux masques de diapositives**

Un masque de diapositive stocke et contrôle des informations telles que le thème et la mise en page des diapositives qui l’utilisent. Lorsque vous ajoutez une image à un masque de diapositive, l’image apparaît sur chaque diapositive basée sur ce masque. 

Le code d’exemple C++ suivant montre comment ajouter une image à un masque de diapositive :

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Ajouter des images comme arrière-plan des diapositives**

Vous pouvez utiliser une image comme arrière‑plan pour une ou plusieurs diapositives. Pour plus de détails, consultez *[Setting Images as Backgrounds for Slides](/slides/fr/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajouter du SVG aux présentations**

Le contenu SVG peut être ajouté à une présentation à l’aide de la classe [SvgImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/svgimage/) . L’objet [ISvgImage] résultant peut ensuite être ajouté à la collection d’images de la présentation et utilisé pour créer un cadre d’image. 

L’exemple C++ suivant importe une chaîne SVG autonome. Toutes les images, styles et autres ressources utilisés par ce SVG sont intégrés directement dans le contenu SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Importer du contenu SVG avec des ressources externes**

Les fichiers SVG exportés depuis des outils de conception, éditeurs de diagrammes, systèmes d’icônes et pipelines Web peuvent référencer des ressources stockées en dehors du document SVG. Par exemple, un SVG peut contenir un lien d’image tel que `images/photo.png`, une valeur CSS `url(...)` ou une URL de police. 

Pour importer ce type de contenu SVG, créez une implémentation de [IExternalResourceResolver](https://reference.aspose.com/slides/fr/cpp/aspose.slides.import/iexternalresourceresolver/) et transmettez‑la, ainsi qu’une URI de base, à un constructeur `SvgImage` approprié. L’URI de base identifie l’emplacement du document SVG et est utilisée pour résoudre les liens relatifs. 

L’interface [ISvgImage] fournit l’accès aux informations concernant le SVG importé :

- `get_SvgContent()` renvoie le balisage SVG sous forme de chaîne.
- `get_SvgData()` renvoie le contenu SVG sous forme de tableau d’octets.
- `get_BaseUri()` renvoie l’URI de base utilisée pour les liens relatifs.
- `get_ExternalResourceResolver()` renvoie le résolveur attribué à l’image SVG.

### **Implémenter un résolveur de ressources externes**

Le résolveur possède deux méthodes :

- [ResolveUri](https://reference.aspose.com/slides/fr/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) combine l’URI de base et un lien de ressource relatif et renvoie une URI absolue. Retournez une chaîne nulle lorsque le lien ne peut pas être résolu ou n’est pas autorisé.
- [GetEntity](https://reference.aspose.com/slides/fr/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) renvoie un flux lisible pour une URI de ressource absolue. Retournez `nullptr` lorsque la ressource est manquante, bloquée ou indisponible. Un flux de secours peut également être renvoyé si nécessaire.

Le résolveur suivant charge les ressources liées uniquement à partir d’un répertoire local autorisé. Les ressources réseau et les chemins en dehors du répertoire autorisé sont bloqués. Une image de secours facultative est renvoyée pour les liens d’image non résolus.

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // Ce résolveur autorise intentionnellement uniquement les fichiers locaux.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // Utilisez une solution de secours uniquement pour les ressources d'image. Retourner un flux d'image
        // pour une police ou une feuille de style manquante ne serait pas valide.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **Résoudre les ressources liées lors de l’importation SVG**

Supposons que `assets/diagram.svg` contienne une référence relative telle que :

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

L’exemple C++ suivant transmet l’URI du fichier SVG comme URI de base et fournit un résolveur personnalisé. Le résolveur convertit le lien d’image relatif en URI absolue et renvoie un flux contenant la ressource liée pendant qu’Aspose.Slides traite le SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// L'URI de base représente l'emplacement du document SVG.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La classe `SvgImage` propose également des surcharges qui acceptent les données SVG sous forme de tableau d’octets ou de flux, ainsi qu’un résolveur de ressources externes et une URI de base.

{{% alert title="Important" color="warning" %}}

Le résolveur de ressources rend les ressources externes disponibles pendant qu’Aspose.Slides traite et rend le SVG. Il ne modifie pas le balisage SVG original ni n’incorpore automatiquement les ressources résolues.

Lorsque un `ISvgImage` est ajouté à la collection d’images de la présentation, le fichier PPTX peut contenir à la fois la représentation SVG originale et une image raster de secours. Une ressource liée peut apparaître dans l’image de secours générée tandis qu’un lien relatif tel que `images/photo.png` reste inchangé dans le SVG stocké. Une application qui rend la représentation SVG native peut donc omettre le contenu lié lorsque la ressource externe originale n’est pas disponible.

{{% /alert %}}

### **Créer une image SVG portable**

Pour créer une image SVG qui ne dépend pas de fichiers externes, rendez le SVG autonome avant de créer le `SvgImage`. Par exemple, remplacez les URL d’image liées par des URI `data:` contenant les données de l’image :

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Après que toutes les ressources requises soient intégrées dans le contenu SVG, créez le `SvgImage`, ajoutez‑le à la collection d’images de la présentation et insérez‑le dans un cadre d’image comme indiqué dans l’exemple précédent.

### **Gérer les ressources manquantes ou bloquées**

Retournez une chaîne nulle depuis `ResolveUri` lorsqu’une URI de ressource est invalide, interdite ou ne peut pas être résolue. Retournez `nullptr` depuis `GetEntity` lorsque la ressource ne peut pas être lue. Aspose.Slides continue de traiter le SVG sans cette ressource lorsque cela est possible.

Un flux de secours peut être renvoyé pour une ressource manquante, mais son contenu doit être compatible avec le type de ressource demandé. Par exemple, renvoyez un flux d’image uniquement pour une image manquante, pas pour une police ou une feuille de style.

{{% alert title="Security" color="warning" %}}

Ne résolvez pas des chemins de fichiers arbitraires ou des URL réseau non restreintes provenant de fichiers SVG non fiables. Restreignez les schémas, répertoires et hôtes autorisés. Pour les ressources réseau, appliquez également des délais d’attente de connexion, des limites de taille de réponse et une validation du contenu.

{{% /alert %}}

## **Convertir un SVG en un ensemble de formes**
Aspose.Slides peut convertir un SVG en un ensemble de formes, similaire à la fonctionnalité correspondante dans PowerPoint :

![PowerPoint Popup Menu](img_01_01.png)

Cette fonctionnalité est fournie par une surcharge de la méthode [AddGroupShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/) de l’interface [IShapeCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/) qui accepte un objet [ISvgImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isvgimage/) en premier argument.

Le code d’exemple C++ suivant montre comment utiliser cette méthode pour convertir un fichier SVG en un ensemble de formes :

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// Nom du fichier SVG source
auto svgFileName = System::String(u"sample.svg");

// Nom du fichier de sortie de la présentation
auto outPptxPath = System::String(u"presentation.pptx");

// Créer une nouvelle présentation
auto presentation = System::MakeObject<Presentation>();

// Lire le contenu du fichier SVG
auto svgContent = File::ReadAllText(svgFileName);

// Créer un objet SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Obtenir la taille de la diapositive
auto slideSize = presentation->get_SlideSize()->get_Size();

// Convertir l'image SVG en groupe de formes et l'adapter à la taille de la diapositive
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Enregistrer la présentation au format PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Ajouter des images au format EMF aux diapositives**
Aspose.Slides for C++ vous permet de générer des images EMF à partir de feuilles de calcul Excel avec Aspose.Cells et de les ajouter aux diapositives de présentation. 

Le code d’exemple C++ suivant montre comment procéder :

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells pour C++ doit être démarré avant que ses types ne soient utilisés.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Rendre la feuille de calcul en EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells renvoie la page rendue sous forme de tampon, que Aspose.Slides ajoute en tant qu’image.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **Remplacer des images dans la collection d’images**

Aspose.Slides vous permet de remplacer les images stockées dans la collection d’images d’une présentation, y compris celles utilisées par les formes de diapositives. Cette section décrit plusieurs façons de mettre à jour les images de la collection. Vous pouvez remplacer une image à l’aide de données brutes d’octets, d’une instance [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/) ou d’une autre image déjà présente dans la collection. 

Suivez les étapes ci‑dessous :

1. Chargez le fichier de présentation contenant des images à l’aide de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) .
2. Chargez une nouvelle image à partir d’un fichier dans un tableau d’octets.
3. Remplacez l’image cible par la nouvelle image en utilisant le tableau d’octets.
4. Dans la deuxième approche, chargez l’image dans un objet [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/) et remplacez l’image cible par cet objet.
5. Dans la troisième approche, remplacez l’image cible par une image déjà existante dans la collection d’images de la présentation.
6. Enregistrez la présentation modifiée au format PPTX.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Première méthode.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Deuxième méthode.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Troisième méthode.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Enregistrez la présentation dans un fichier.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Avec le convertisseur gratuit [Text to GIF](https://products.aspose.app/slides/fr/text-to-gif) d’Aspose, vous pouvez facilement animer du texte et créer des GIF à partir de texte. 

{{% /alert %}}

## **FAQ**

**La résolution d'origine de l'image reste‑t‑elle intacte après l’insertion ?**

Oui. Les pixels source sont conservés, mais l’apparence finale dépend de la façon dont le [picture](/slides/fr/cpp/picture-frame/) est mis à l’échelle sur la diapositive et de toute compression appliquée lors de l’enregistrement.

**Quelle est la meilleure façon de remplacer le même logo sur des dizaines de diapositives en une seule fois ?**

Placez le logo sur le masque de diapositive ou une disposition et remplacez‑le dans la collection d’images de la présentation — les modifications se propageront à tous les éléments qui utilisent cette ressource.

**Une SVG insérée peut‑elle être convertie en formes éditables ?**

Oui. Vous pouvez convertir un SVG en un groupe de formes, après quoi chaque partie devient éditable avec les propriétés standard des formes.

**Comment définir une image comme arrière‑plan pour plusieurs diapositives en même temps ?**

[Attribuez l’image comme arrière‑plan](/slides/fr/cpp/presentation-background/) sur le masque de diapositive ou la mise en page concernée—toutes les diapositives utilisant ce masque/mise en page hériteront de l’arrière‑plan.

**Comment empêcher une présentation de devenir trop volumineuse à cause de nombreuses images ?**

Réutilisez une seule ressource d’image au lieu de duplicata, choisissez des résolutions raisonnables, appliquez une compression lors de l’enregistrement et conservez les graphismes répétitifs sur le masque lorsque cela est approprié.