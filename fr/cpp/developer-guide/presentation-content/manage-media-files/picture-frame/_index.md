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
- ajouter une image
- créer une image
- extraire une image
- image matricielle
- image vectorielle
- recadrer l'image
- zone recadrée
- propriété StretchOff
- mise en forme du cadre d'image
- propriétés du cadre d'image
- échelle relative
- effet d'image
- ratio d'aspect
- transparence de l'image
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Ajoutez des cadres d'image aux présentations PowerPoint et OpenDocument avec Aspose.Slides pour C++. Rationalisez votre flux de travail et améliorez la conception des diapositives."
---
## **Introduction**

Un cadre d'image est une forme qui contient une image — c'est comme une image dans un cadre.  

Vous pouvez ajouter une image à une diapositive via un cadre d'image. Ainsi, vous pouvez mettre en forme l'image en mettant en forme le cadre d'image.

{{% alert  title="Tip" color="info" %}} 

Aspose propose des convertisseurs gratuits—[JPEG to PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt)—qui permettent de créer rapidement des présentations à partir d'images. 

{{% /alert %}} 

## **Créer un cadre d'image**

1. Créez une instance de la [Presentation class](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive via son index. 
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_image_collection) associée à l'objet présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.picture_frame) basé sur la largeur et la hauteur de l'image via la méthode `AddPictureFrame` exposée par l'objet forme associé à la diapositive référencée.
6. Ajoutez un cadre d'image (contenant l'image) à la diapositive.
7. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code C++ montre comment créer un cadre d'image :

```c++
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
#include <Util/Images.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Le chemin du répertoire des documents.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Charge la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Charge l'image qui sera ajoutée à la collection d'images de la présentation
// Récupère l'image
auto image = Images::FromFile(filePath);

// Ajoute une image à la collection d'images de la présentation
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Ajoute un cadre d'image à la diapositive
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Définit la largeur et la hauteur de l'échelle relative
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Applique un certain formatage au cadre d'image
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Écrit le fichier PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

Les cadres d'image vous permettent de créer rapidement des diapositives de présentation à partir d'images. En combinant le cadre d'image avec les options d'enregistrement d'Aspose.Slides, vous pouvez manipuler les opérations d'entrée/sortie pour convertir les images d'un format à un autre. Vous pouvez consulter ces pages : convert [image to JPG](https://products.aspose.com/slides/fr/cpp/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/fr/cpp/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/fr/cpp/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/fr/cpp/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/fr/cpp/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/fr/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Créer un cadre d'image avec une échelle relative**

En modifiant l'échelle relative d'une image, vous pouvez créer un cadre d'image plus sophistiqué.  

1. Créez une instance de la [Presentation class](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive via son index. 
3. Ajoutez une image à la collection d'images de la présentation.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_image_collection) associée à l'objet présentation qui sera utilisé pour remplir la forme.
5. Spécifiez la largeur et la hauteur relatives de l'image dans le cadre d'image.
6. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code C++ montre comment créer un cadre d'image avec une échelle relative :

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Le chemin du répertoire des documents.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Charge la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Charge l'image à ajouter à la collection d'images de la présentation
// Récupère l'image
auto image = Images::FromFile(filePath);

// Ajoute une image à la collection d'images de la présentation
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Ajoute un cadre d'image à la diapositive
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Définit la largeur et la hauteur de l'échelle relative
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Écrit le fichier PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Extraire des images matricielles des cadres d'image**

Vous pouvez extraire des images matricielles des objets [PictureFrame](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.picture_frame) et les enregistrer au format PNG, JPG et autres. L'exemple de code ci‑dessous montre comment extraire une image du document « sample.pptx » et l'enregistrer au format PNG.

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_Image();

    image->Save(u"slide_1_shape_1.png", ImageFormat::Png);
}

presentation->Dispose();
```

## **Extraire des images SVG des cadres d'image**

Lorsqu'une présentation contient des graphiques SVG placés à l'intérieur de formes [PictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pictureframe/), Aspose.Slides pour C++ vous permet de récupérer les images vectorielles originales avec une fidélité totale. En parcourant la collection de formes de la diapositive, vous pouvez identifier chaque [PictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pictureframe/), vérifier si l'[IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) sous‑jacent contient du contenu SVG, puis enregistrer cette image sur disque ou dans un flux au format SVG natif.

L'exemple de code suivant montre comment extraire une image SVG d'un cadre d'image :

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
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
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **Obtenir la transparence d'une image**

Aspose.Slides vous permet d'obtenir l'effet de transparence appliqué à une image. Ce code C++ montre l'opération :

```c++
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="info" %}} 
Tous les effets appliqués aux images sont disponibles dans [Aspose::Slides::Effects](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/).
{{% /alert %}}

## **Obtenir la luminosité et le contraste d'une image**

Aspose.Slides vous permet d'obtenir l'effet de luminosité et de contraste appliqué à une image. L'interface [ILuminance](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iluminance/) représente cet effet de transformation d'image.

Ce code C++ montre comment obtenir les paramètres de luminosité et de contraste d'un cadre d'image :

```c++
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **Mise en forme du cadre d'image**

Aspose.Slides propose de nombreuses options de mise en forme qui peuvent être appliquées à un cadre d'image. En utilisant ces options, vous pouvez modifier un cadre d'image pour qu'il réponde à des exigences spécifiques.

1. Créez une instance de la [Presentation class](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive via son index. 
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_image_collection) associée à l'objet présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un `PictureFrame` basé sur la largeur et la hauteur de l'image via la méthode [AddPictureFrame](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) exposée par l'objet [IShapes](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_shape_collection) associé à la diapositive référencée.
6. Ajoutez le cadre d'image (contenant l'image) à la diapositive.
7. Définissez la couleur du contour du cadre d'image.
8. Définissez la largeur du contour du cadre d'image.
9. Faites pivoter le cadre d'image en lui attribuant une valeur positive ou négative.
   * Une valeur positive fait pivoter l'image dans le sens des aiguilles d'une montre. 
   * Une valeur négative fait pivoter l'image dans le sens inverse des aiguilles d'une montre.
10. Ajoutez le cadre d'image (contenant l'image) à la diapositive.
11. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code C++ montre le processus de mise en forme du cadre d'image :

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Le chemin du répertoire des documents.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Charge la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Charge l'image à ajouter à la collection d'images de la présentation
// Récupère l'image
auto image = Images::FromFile(filePath);

// Ajoute une image à la collection d'images de la présentation
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Ajoute un cadre d'image à la diapositive
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Définit la largeur et la hauteur de l'échelle relative
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Écrit le fichier PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="info" %}}

Aspose a récemment développé un [Collage Maker gratuit](https://products.aspose.app/slides/fr/collage). Si vous avez besoin de [fusionner des images JPG/JPEG](https://products.aspose.app/slides/fr/collage/jpg) ou PNG, ou de [créer des grilles à partir de photos](https://products.aspose.app/slides/fr/collage/photo-grid), vous pouvez utiliser ce service. 

{{% /alert %}}

## **Ajouter une image en tant que lien**

Pour éviter des tailles de présentation trop importantes, vous pouvez ajouter des images (ou des vidéos) via des liens au lieu d’intégrer directement les fichiers dans les présentations. Ce code C++ montre comment ajouter une image et une vidéo dans un espace réservé :

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IVideoFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/collections/list.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Rogner des images**

Ce code C++ montre comment rogner une image existante sur une diapositive : 

``` CPP
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// Crée un nouvel objet image
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(u"image.png"));

auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

presentation->Save(u"cropped.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Supprimer les zones rognées d'un cadre d'image**

Si vous souhaitez supprimer les zones rognées d'une image contenue dans un cadre, vous pouvez utiliser la méthode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Cette méthode renvoie l'image rognée ou l'image d'origine si le rognage n'est pas nécessaire.

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Obtient le PictureFrame de la première diapositive
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Supprime les zones rognées de l'image du PictureFrame et renvoie l'image rognée
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Enregistre le résultat
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 

La méthode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ajoute l'image rognée à la collection d'images de la présentation. Si l'image n'est utilisée que dans le [PictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pictureframe/) traité, cette configuration peut réduire la taille de la présentation. Sinon, le nombre d'images dans la présentation résultante augmentera.

Cette méthode convertit les métafichiers WMF/EMF en images PNG raster lors de l'opération de rognage. 

{{% /alert %}}

## **Compresser des images**

Vous pouvez compresser une image dans une présentation à l'aide de la méthode [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipicturefillformat/compressimage/).
Cette méthode compresse une image en réduisant sa taille en fonction de la taille de la forme et de la résolution spécifiée, avec la possibilité de supprimer les zones rognées.

Elle ajuste la taille et la résolution de l'image de façon similaire à la fonction **Picture Format -> Compress Pictures -> Resolution** de PowerPoint.

Les exemples C++ suivants montrent comment compresser une image dans une présentation en spécifiant une résolution cible et, éventuellement, en supprimant les zones rognées :

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Compresse l'image avec une résolution cible de 150 DPI (résolution Web) et supprime les zones rognées.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Vérifie le résultat de la compression.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ou en utilisant directement une valeur DPI personnalisée :

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Compresse l'image à 150 DPI (résolution Web), en supprimant les zones rognées.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}

La méthode convertit l'image à une résolution inférieure en fonction de la taille de la forme et du DPI fourni. Les zones rognées peuvent également être supprimées pour optimiser la taille du fichier.
Si l'image est un métafile (WMF/EMF) ou SVG, la compression ne sera pas appliquée. De plus, la qualité JPEG est préservée ou légèrement réduite en fonction de la résolution, de la même façon que PowerPoint gère les JPEG haute résolution.

{{% /alert %}}

## **Verrouiller le rapport d'aspect**

Si vous souhaitez qu'une forme contenant une image conserve son ratio d'aspect même après modification des dimensions de l'image, vous pouvez utiliser la méthode [set_AspectRatioLocked()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) pour définir le paramètre *Lock Aspect Ratio*. 

Ce code C++ montre comment verrouiller le ratio d'aspect d'une forme :

```c++
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

Ce paramètre *Lock Aspect Ratio* ne préserve que le ratio d'aspect de la forme et non celui de l'image qu'elle contient.

{{% /alert %}}

## **Utiliser la propriété StretchOff**

En utilisant les propriétés [StretchOffsetLeft](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) et [StretchOffsetBottom](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) de l'interface [IPictureFillFormat](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_picture_fill_format) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.picture_fill_format), vous pouvez spécifier un rectangle de remplissage. 

Lorsque l'étirement d'une image est spécifié, un rectangle source est mis à l'échelle pour s'adapter au rectangle de remplissage indiqué. Chaque bord du rectangle de remplissage est défini par un décalage en pourcentage par rapport au bord correspondant de la boîte englobante de la forme. Un pourcentage positif indique un retrait. Un pourcentage négatif indique un dépassement.

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez un rectangle `AutoShape`. 
4. Créez une image.
5. Définissez le type de remplissage de la forme.
6. Définissez le mode de remplissage d'image de la forme.
7. Ajoutez une image de remplissage à la forme.
8. Spécifiez les décalages d'image par rapport au bord correspondant de la boîte englobante de la forme
9. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code C++ montre un processus utilisant la propriété StretchOff :

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Définit l'image étirée de chaque côté dans le corps de la forme
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

### How can I find out which image formats are supported for PictureFrame?

Aspose.Slides supporte à la fois les images matricielles (PNG, JPEG, BMP, GIF, etc.) et les images vectorielles (par exemple, SVG) via l'objet image assigné à un [PictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pictureframe/). La liste des formats pris en charge se recoupe généralement avec les capacités du moteur de conversion de diapositives et d'images.

### How will adding dozens of large images affect PPTX size and performance?

Intégrer de grandes images augmente la taille du fichier et l'utilisation de la mémoire ; lier les images aide à réduire la taille de la présentation mais nécessite que les fichiers externes restent accessibles. Aspose.Slides offre la possibilité d’ajouter des images par lien pour réduire la taille du fichier.

### How can I lock an image object from accidental moving/resizing?

Utilisez les [verrous de forme](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pictureframe/get_pictureframelock/) pour un [PictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pictureframe/) (par exemple, désactiver le déplacement ou le redimensionnement). Le mécanisme de verrouillage est décrit pour les formes dans un [article de protection](/slides/fr/cpp/applying-protection-to-presentation/) séparé et est pris en charge pour divers types de formes, y compris les [PictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pictureframe/).

### Is SVG vector fidelity preserved when exporting a presentation to PDF/images?

Aspose.Slides permet d’extraire un SVG d’un [PictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pictureframe/) en tant que vecteur original. Lors de l’[exportation vers PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/) ou les formats raster [/slides/fr/cpp/convert-powerpoint-to-png/], le résultat peut être rasterisé selon les paramètres d’exportation ; le fait que le SVG original soit stocké en vecteur est confirmé par le comportement d’extraction.