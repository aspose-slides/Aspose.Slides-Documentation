---
title: Gérer les cadres d'image dans les présentations avec C++
linktitle: Cadre d'image
type: docs
weight: 10
url: /fr/cpp/picture-frame/
keywords:
- cadre d'image
- ajouter un cadre d'image
- créer un cadre d'image
- image incorporée
- image liée
- extraire l'image
- image matricielle
- image SVG
- recadrer l'image
- supprimer les zones recadrées
- compresser l'image
- StretchOffset
- mise en forme du cadre d'image
- échelle relative
- effet d'image
- rapport d'aspect
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Créer, formater, lier, recadrer, extraire et compresser les cadres d'image dans les présentations avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Un cadre d'image est une forme de diapositive qui affiche une image. Dans Aspose.Slides, la ressource image et la forme qui l'affiche sont des objets distincts : une [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) possède des ressources d'images incorporées via sa [image collection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_images/), tandis qu'un [IPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframe/) contrôle la position, la taille, le format de ligne, la rotation, le recadrage, les effets d'image et les autres paramètres au niveau du cadre.

Cette séparation est utile lorsqu'une même image est affichée plusieurs fois. Ajoutez l'image à la présentation une fois, conservez le [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) retourné, et utilisez cette ressource image lors de la création de cadres d'image.

Les cadres d'image peuvent contenir des images matricielles telles que PNG ou JPEG ainsi que des images vectorielles SVG. Ils peuvent également référencer des images liées au lieu de stocker les octets d'image dans la présentation. Ce choix influence la portabilité, la taille du fichier, l'extraction et le comportement d'exportation, il est donc utile de décider comment l'image doit être stockée avant d'appliquer le formatage ou l'optimisation.

## **Ajouter et formater une image incorporée**

Pour une image incorporée, ajoutez les données d'image à la présentation et créez un cadre d'image avec [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shapecollection/addpictureframe/). L'image fait alors partie du package de la présentation, de sorte que la présentation reste autonome lorsqu'elle est déplacée vers un autre ordinateur.

L'exemple suivant ajoute une image JPEG, crée un cadre aux dimensions natives de l'image et applique un format de ligne ainsi qu'une rotation :

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le cadre d'image contrôle la géométrie affichée ; changer la taille du cadre ne modifie pas les dimensions en pixels d'origine stockées dans la ressource image incorporée. Cette distinction devient importante lors d'un recadrage ou d'une compression d'image ultérieure.

## **Utiliser une échelle relative**

[IPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframe/) expose le redimensionnement relatif en largeur et en hauteur pour le cadre. Une valeur de `1.0` correspond à 100 % de la taille d'origine de l'image. L'échelle relative est utile lorsqu'un flux de travail doit préserver une relation avec la taille de l'image source au lieu de calculer manuellement les dimensions finales.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

L'échelle relative modifie les paramètres de mise à l'échelle du cadre ; elle ne rééchantillonne ni ne compresse pas l'image incorporée.

## **Images incorporées et liées**

Une image incorporée stocke les données d'image à l'intérieur de la présentation et constitue donc le choix le plus sûr pour la portabilité et le rendu prévisible. Une image liée stocke un emplacement externe via le chemin de lien [ISlidesPicture](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidespicture/) au lieu d'incorporer les données d'image de la même façon.

Les images liées peuvent réduire la quantité de données d'image stockées dans le PPTX, mais elles introduisent une dépendance externe. Le fichier lié doit rester accessible à l'application qui ouvre ou rend la présentation. Si le chemin change, si le fichier est déplacé ou si la ressource est indisponible, l'image liée peut ne pas s'afficher comme prévu. Pour les présentations qui doivent être envoyées par courriel, archivées ou rendues dans des environnements isolés, les images incorporées sont généralement plus fiables.

### **Ajouter une image liée**

L'exemple suivant crée un cadre d'image et le pointe vers un fichier image local. Il ne traite que le lien d'image ; le lien vidéo est un flux média distinct et n'est intentionnellement pas mêlé à cet exemple.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Utilisez les liens lorsque la gestion de fichiers externes est intentionnelle. Ne les utilisez pas simplement comme substitut à la compression : un petit PPTX avec des dépendances d'image cassées est généralement moins utile qu'une présentation plus volumineuse et autonome.

## **Extraire des images depuis des cadres d'image**

Avant d'extraire une image d'une présentation existante, vérifiez qu'une forme est réellement un [IPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframe/) et qu'elle contient une image incorporée. Les cadres d'image liés peuvent ne pas contenir d'octets d'image exploitables de la même façon.

### **Extraire une image matricielle**

L'API moderne d'image utilise directement [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/). L'exemple suivant trouve la première image matricielle incorporée sur une diapositive et l'enregistre au format PNG :

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

Sauvegarder via [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/) convertit l'image extraite vers le format de sortie demandé. Si vous avez besoin des octets encodés stockés dans la présentation plutôt que d'un fichier matriciel converti, utilisez les données binaires de la ressource image.

### **Extraire une image SVG**

Pour une image SVG, le [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) expose un objet [ISvgImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isvgimage/). Cela vous permet de récupérer directement les données SVG au lieu de rasteriser d'abord l'image.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

Conserver le contenu SVG sous forme de SVG préserve la source vectorielle dans la présentation. Les exportations matricielles telles que PNG ou JPEG rendent nécessairement ce contenu vectoriel en pixels. L'exportation de diapositives au format PDF ou SVG est également une opération de rendu, de sorte que les graphiques exportés ne doivent pas être considérés comme une copie octet pour octet du SVG incorporé ; utilisez les données [ISvgImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isvgimage/) incorporées lorsque la ressource vectorielle d'origine est requise.

## **Recadrer une image**

Le recadrage modifie la partie de l'image visible à l'intérieur du cadre. Les valeurs de recadrage sur [IPictureFillFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipicturefillformat/) sont des pourcentages des dimensions de l'image source. Le recadrage ne supprime pas immédiatement les pixels cachés de l'image incorporée ; il ne fait que changer la région visible.

L'exemple suivant trouve en toute sécurité un cadre d'image et applique les valeurs de recadrage :

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Comme les données d'image cachées sont toujours présentes, le recadrage peut être modifié ultérieurement sans perdre les pixels d'origine. Si la taille du fichier est plus importante que la réversibilité, les régions recadrées peuvent être supprimées physiquement comme décrit dans la section suivante.

## **Supprimer les données d'image recadrées**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) supprime les données d'image situées en dehors du rectangle de recadrage actuel et renvoie la ressource image résultante. Cela peut réduire la taille du fichier, mais il s'agit d'une optimisation destructive : une fois la présentation enregistrée, les pixels supprimés ne sont plus disponibles pour une opération de décadrage ultérieure.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

La méthode peut ajouter une nouvelle ressource image à la présentation. Si l'image d'origine est également utilisée par d'autres cadres d'image, ces cadres conservent toujours leur ressource existante, de sorte que la suppression des zones recadrées ne réduit pas nécessairement le nombre total d'images. Le recadrage de contenu WMF ou EMF avec cette méthode rasterise le résultat recadré en PNG.

## **Compresser les images matricielles**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipicturefillformat/compressimage/) réduit la résolution de l'image matricielle par rapport à la taille à laquelle l'image est affichée. Elle peut également supprimer les zones recadrées dans la même opération. La méthode renvoie `true` lorsque l'image a été redimensionnée ou recadrée et `false` lorsqu'aucune modification n'était nécessaire.

Utilisez une valeur prédéfinie de [PicturesCompression](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/picturescompression/) lorsqu'une résolution cible standard suffit :

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Une valeur DPI positive personnalisée peut être passée à la place d'une valeur d'énumération lorsqu'une cible précise est requise.

La compression s'applique aux images matricielles. Le contenu SVG et les métafichiers ne sont pas réduits par ce flux de travail de compression matricielle. Gardez également à l'esprit que la résolution inférieure et les zones recadrées supprimées ne peuvent pas être récupérées à partir de la présentation optimisée. Choisissez une résolution cible basée sur la plus grande taille à laquelle l'image sera réellement visualisée ou exportée plutôt que d'appliquer le DPI le plus bas globalement.

## **Inspecter les effets d'image**

Les effets d'image sont stockés sur l'image utilisée par le cadre. La collection de transformations d'image peut contenir des effets tels que la modulation alpha fixe pour la transparence et la luminance pour la luminosité et le contraste. L'exemple ci‑dessous lit en toute sécurité les deux types d'effets du premier cadre d'image d'une diapositive :

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

Ces effets modifient la façon dont l'image est rendue dans le cadre ; ils ne réécrivent pas les octets d'image incorporés d'origine.

## **Verrouiller la géométrie du cadre d'image**

Les paramètres du [IPictureFrameLock](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframelock/) contrôlent quelles opérations d'édition sont désactivées pour un cadre d'image. Par exemple, le [verrouillage du rapport d'aspect](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) préserve les proportions de la forme lors du redimensionnement.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le verrouillage s'applique à la forme du cadre d'image. Il ne force pas l'image source à être rééchantillonnée ou modifiée de façon permanente au même rapport d'aspect.

## **Ajuster les valeurs StretchOffset**

Lorsque le mode de remplissage d'image est « stretch », les valeurs de stretch‑offset sur [IPictureFillFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipicturefillformat/) définissent le rectangle de remplissage relatif à la boîte englobante du cadre d'image. Des pourcentages positifs créent un retrait depuis un bord, tandis que des pourcentages négatifs créent un débordement.

Ceci diffère du recadrage. Les valeurs de recadrage sélectionnent quelle partie de l'image source est visible ; les offsets de stretch modifient le rectangle dans lequel le remplissage d'image visible est étiré.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Utilisez les offsets de stretch pour le placement du remplissage. Utilisez les propriétés de recadrage lorsque l'objectif est de masquer les bords de l'image source.

## **Stockage, taille du fichier et considérations d'exportation**

Les principaux compromis sont plus faciles à gérer lorsque le stockage d'image et le formatage du cadre d'image sont traités séparément :

- **Images incorporées** rendent la présentation autonome et sont les plus fiables pour le partage et le rendu côté serveur, mais les grandes images matricielles augmentent la taille du PPTX et l'utilisation de la mémoire.
- **Images liées** peuvent garder le package plus petit, mais la présentation dépend de la disponibilité des fichiers externes aux chemins ou emplacements stockés.
- **Recadrage** est initialement non destructif. Les pixels cachés restent incorporés jusqu'à ce que les zones recadrées soient explicitement supprimées ou éliminées lors de la compression.
- **Compression** peut réduire sensiblement la taille du fichier pour les images matricielles surdimensionnées, mais elle sacrifie la résolution source. Elle doit être appliquée après que la taille finale sur la diapositive soit connue.
- **Images SVG** doivent rester au format SVG lorsque la préservation vectorielle est importante. Extrayez le SVG incorporé directement lorsque vous avez besoin de la ressource vectorielle elle‑même. Les exportations de diapositives en mode raster convertissent toujours la diapositive rendue en pixels.
- **Images répétées** doivent réutiliser une ressource [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) existante lorsque cela est possible au lieu de charger à nouveau le même fichier dans le flux de travail de la présentation.

Pour les présentations volumineuses, l'optimisation des images est généralement la plus efficace lorsqu'elle est effectuée sélectivement : conservez les logos et diagrammes sous forme de contenu vectoriel, compressez les photographies en fonction de leur taille d'affichage réelle, supprimez les pixels recadrés uniquement lorsque l'édition ultérieure n'est pas requise, et évitez les liens externes sauf si la gestion des dépendances fait partie de la conception du déploiement.

## **FAQ**

**Quelle est la différence entre un cadre d'image et une ressource d'image ?**

Un [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) représente une ressource image associée à la présentation. Un [IPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframe/) est une forme sur une diapositive qui affiche une image et stocke la géométrie et le formatage au niveau du cadre tels que la taille, la rotation, les valeurs de recadrage, les effets et les verrous.

**Dois‑je incorporer ou lier les images ?**

Incorporez les images lorsque la présentation doit être portable, archivées ou rendues sans accès à des ressources externes. Liez les images uniquement lorsque le maintien des fichiers image en dehors du PPTX est intentionnel et que les emplacements externes peuvent être maintenus de façon fiable.

**Le recadrage réduit‑il la taille du fichier PPTX ?**

Pas en soi. Les paramètres de recadrage normaux masquent des parties de l'image source tout en conservant les pixels sous‑jacents. Utilisez [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ou la compression d'image avec suppression des zones recadrées lorsque ces pixels peuvent être éliminés définitivement.

**Puis‑je restaurer la qualité de l'image après compression ?**

Non. La compression peut réduire la résolution raster stockée, et la suppression des zones recadrées élimine les données d'image. Conservez l'image source originale en dehors de la présentation si un futur travail en haute résolution peut être requis.

**Comment les images SVG doivent‑elles être gérées ?**

Conservez le contenu SVG au format SVG lorsque la fidélité vectorielle compte. L'[ISvgImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isvgimage/) incorporé peut être extrait directement. Rendre une diapositive vers un format raster tel que PNG ou JPEG rasterise le SVG dans le cadre de l'image de la diapositive.

**Comment éviter les casts non sécurisés lors de la lecture de diapositives existantes ?**

Vérifiez le type de forme avant d'utiliser les membres spécifiques au cadre d'image. Testez la forme avec [IPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframe/) avant d'effectuer un cast à l'exécution, et affectez le résultat du cast à une variable locale avant d'accéder aux membres spécifiques au cadre d'image.