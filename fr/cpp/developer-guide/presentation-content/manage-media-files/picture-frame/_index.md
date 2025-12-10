---
title: Gérer les cadres image dans les présentations avec C++
linktitle: Cadre image
type: docs
weight: 10
url: /fr/cpp/picture-frame/
keywords:
- cadre image
- ajouter un cadre image
- créer un cadre image
- ajouter une image
- créer une image
- extraire une image
- image matricielle
- image vectorielle
- recadrer une image
- zone recadrée
- propriété StretchOff
- mise en forme du cadre image
- propriétés du cadre image
- mise à l'échelle relative
- effet d'image
- ratio d'aspect
- transparence d'image
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Ajoutez des cadres image aux présentations PowerPoint et OpenDocument avec Aspose.Slides pour C++. Rationalisez votre flux de travail et améliorez la conception des diapositives."
---

Un cadre image est une forme qui contient une image — c’est comme une photo dans un cadre. 

Vous pouvez ajouter une image à une diapositive via un cadre image. Ainsi, vous pouvez formater l’image en formatant le cadre image.

{{% alert title="Astuce" color="primary" %}} 
Aspose propose des convertisseurs gratuits—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent aux utilisateurs de créer rapidement des présentations à partir d’images. 
{{% /alert %}} 

## **Créer un cadre image**

1. Créez une instance de la classe [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d’une diapositive via son indice. 
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) associée à l’objet de présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l’image.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) basé sur la largeur et la hauteur de l’image via la méthode `AddPictureFrame` exposée par l’objet forme associé à la diapositive référencée.
6. Ajoutez le cadre image (contenant l’image) à la diapositive.
7. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code C++ montre comment créer un cadre image :
```c++
// Le chemin du répertoire des documents.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Charge la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Charge l'image qui sera ajoutée à la collection d'images de la présentation
// Obtient l'image
auto image = Images::FromFile(filePath);

// Ajoute une image à la collection d'images de la présentation
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Ajoute un cadre image à la diapositive
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Définit la largeur et la hauteur à l'échelle relative
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Applique un formatage au PictureFrame
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//Enregistre le fichier PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert color="warning" %}} 
Les cadres image vous permettent de créer rapidement des diapositives de présentation à partir d’images. Lorsque vous combinez le cadre image avec les options d’enregistrement d’Aspose.Slides, vous pouvez manipuler les opérations d’entrée/sortie pour convertir les images d’un format à un autre. Vous pouvez consulter ces pages : convert [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).
{{% /alert %}}

## **Créer un cadre image avec mise à l’échelle relative**

En modifiant la mise à l’échelle relative d’une image, vous pouvez créer un cadre image plus complexe. 

1. Créez une instance de la classe [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d’une diapositive via son indice. 
3. Ajoutez une image à la collection d’images de la présentation.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) associée à l’objet de présentation qui sera utilisé pour remplir la forme.
5. Spécifiez la largeur et la hauteur relatives de l’image dans le cadre image.
6. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code C++ montre comment créer un cadre image avec mise à l’échelle relative :
```c++
// Le chemin du répertoire des documents.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Charge la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Charge l'image qui sera ajoutée à la collection d'images de la présentation
// Obtient l'image
auto image = Images::FromFile(filePath);

// Ajoute une image à la collection d'images de la présentation
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Ajoute un cadre image à la diapositive
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Définit la largeur et la hauteur à l'échelle relative
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Enregistre le fichier PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Extraire des images matricielles à partir de cadres image**

Vous pouvez extraire des images matricielles des objets [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) et les enregistrer aux formats PNG, JPG et autres. L’exemple de code ci‑dessous montre comment extraire une image du document "sample.pptx" et l’enregistrer au format PNG.
```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```


## **Extraire les images SVG à partir de cadres image**

Lorsque une présentation contient des graphiques SVG placés à l’intérieur de formes [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) , Aspose.Slides for C++ vous permet de récupérer les images vectorielles d’origine avec une fidélité complète. En parcourant la collection de formes de la diapositive, vous pouvez identifier chaque [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/), vérifier si l’objet [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) sous‑jacent contient du contenu SVG, puis enregistrer cette image sur disque ou dans un flux au format SVG natif.

L’exemple de code suivant montre comment extraire une image SVG d’un cadre image :
```cpp
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


## **Obtenir la transparence d’une image**

Aspose.Slides vous permet d’obtenir l’effet de transparence appliqué à une image. Ce code C++ montre l’opération :
```c++
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


{{% alert color="primary" %}} 
Tous les effets appliqués aux images se trouvent dans [Aspose::Slides::Effects](https://reference.aspose.com/slides/cpp/aspose.slides.effects/).
{{% /alert %}}

## **Mise en forme du cadre image**

Aspose.Slides propose de nombreuses options de mise en forme applicables à un cadre image. En utilisant ces options, vous pouvez modifier un cadre image pour qu’il réponde à des exigences spécifiques.

1. Créez une instance de la classe [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d’une diapositive via son indice. 
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) associée à l’objet de présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l’image.
5. Créez un `PictureFrame` basé sur la largeur et la hauteur de l’image via la méthode [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) exposée par l’objet [IShapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) associé à la diapositive référencée.
6. Ajoutez le cadre image (contenant l’image) à la diapositive.
7. Définissez la couleur de la bordure du cadre image.
8. Définissez la largeur de la bordure du cadre image.
9. Faites pivoter le cadre image en lui donnant une valeur positive ou négative.  
   * Une valeur positive fait pivoter l’image dans le sens des aiguilles d’une montre.  
   * Une valeur négative fait pivoter l’image dans le sens inverse des aiguilles d’une montre.
10. Ajoutez le cadre image (contenant l’image) à la diapositive.
11. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code C++ montre le processus de mise en forme du cadre image :
```c++
// Le chemin du répertoire des documents.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Charge la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Charge l'image à ajouter à la collection d'images de la présentation
// Obtient l'image
auto image = Images::FromFile(filePath);

// Ajoute une image à la collection d'images de la présentation
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Ajoute un cadre image à la diapositive
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Définit la largeur et la hauteur à l'échelle relative
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Enregistre le fichier PPTX sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert title="Astuce" color="primary" %}}

Aspose a récemment développé un [free Collage Maker](https://products.aspose.app/slides/collage). Si vous avez besoin de [merge JPG/JPEG](https://products.aspose.app/slides/collage/jpg) ou d’images PNG, de [create grids from photos](https://products.aspose.app/slides/collage/photo-grid), vous pouvez utiliser ce service. 
{{% /alert %}}

## **Ajouter une image sous forme de lien**

Pour éviter des tailles de présentation trop importantes, vous pouvez ajouter des images (ou des vidéos) via des liens au lieu d’incorporer directement les fichiers dans les présentations. Ce code C++ montre comment ajouter une image et une vidéo dans un espace réservé :
```cpp
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


## **Recadrer des images**

Ce code C++ montre comment recadrer une image existante sur une diapositive : 
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Crée un nouvel objet image
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Ajoute un PictureFrame à une diapositive
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Recadre l'image (valeurs en pourcentage)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Enregistre le résultat
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Supprimer les zones recadrées d’une image**

Si vous voulez supprimer les zones recadrées d’une image contenue dans un cadre, vous pouvez utiliser la méthode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Cette méthode renvoie l’image recadrée ou l’image d’origine si le recadrage n’est pas nécessaire.

Ce code C++ montre l’opération : 
```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Gets the PictureFrame from the first slide
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Deletes cropped areas of the PictureFrame image and returns the cropped image
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Saves the result
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```


{{% alert title="NOTE" color="warning" %}} 

La méthode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ajoute l’image recadrée à la collection d’images de la présentation. Si l’image n’est utilisée que dans le [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) traité, cette configuration peut réduire la taille de la présentation. Sinon, le nombre d’images dans la présentation résultante augmentera.

Cette méthode convertit les fichiers métas WMF/EMF en image PNG raster lors de l’opération de recadrage. 
{{% /alert %}}

## **Verrouiller le ratio d’aspect**

Si vous désirez qu’une forme contenant une image conserve son ratio d’aspect même après modification des dimensions de l’image, vous pouvez utiliser la méthode [set_AspectRatioLocked()](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) pour définir le paramètre *Lock Aspect Ratio*. 

Ce code C++ montre comment verrouiller le ratio d’aspect d’une forme :
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// définir la forme pour qu'elle conserve le ratio d'aspect lors du redimensionnement
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```


{{% alert title="NOTE" color="warning" %}} 

Ce paramètre *Lock Aspect Ratio* ne préserve que le ratio de la forme et non celui de l’image qu’elle contient.
{{% /alert %}}

## **Utiliser la propriété StretchOff**

En utilisant les propriétés [StretchOffsetLeft](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) et [StretchOffsetBottom](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) de l’interface [IPictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format), vous pouvez spécifier un rectangle de remplissage. 

Lorsque l’étirement d’une image est spécifié, un rectangle source est mis à l’échelle pour s’adapter au rectangle de remplissage spécifié. Chaque bord du rectangle de remplissage est défini par un pourcentage de décalage par rapport au bord correspondant de la boîte englobante de la forme. Un pourcentage positif indique un retrait. Un pourcentage négatif indique une extension.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d’une diapositive via son indice.
3. Ajoutez un rectangle `AutoShape`. 
4. Créez une image.
5. Définissez le type de remplissage de la forme.
6. Définissez le mode de remplissage d’image de la forme.
7. Ajoutez une image définie pour remplir la forme.
8. Spécifiez les décalages d’image par rapport au bord correspondant de la boîte englobante de la forme.
9. Enregistrez la présentation modifiée en tant que fichier PPTX.
  
Ce code C++ montre un processus dans lequel la propriété StretchOff est utilisée :
```cpp
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

**Comment savoir quels formats d’image sont pris en charge pour PictureFrame ?**

Aspose.Slides prend en charge les images matricielles (PNG, JPEG, BMP, GIF, etc.) ainsi que les images vectorielles (par exemple SVG) via l’objet image qui est affecté à un [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/). La liste des formats pris en charge se recoupe généralement avec les capacités du moteur de conversion de diapositives et d’images.

**Comment l’ajout de dizaines d’images volumineuses affecte‑t‑il la taille et les performances du PPTX ?**

L’incorporation d’images volumineuses augmente la taille du fichier et la consommation de mémoire ; le raccordement d’images aide à réduire la taille de la présentation mais nécessite que les fichiers externes restent accessibles. Aspose.Slides offre la possibilité d’ajouter des images par lien afin de diminuer la taille du fichier.

**Comment verrouiller un objet image contre tout déplacement/redimensionnement accidentel ?**

Utilisez les verrous de forme ([shape locks](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/get_pictureframelock/)) pour un [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) (par exemple, désactiver le déplacement ou le redimensionnement). Le mécanisme de verrouillage est décrit pour les formes dans un article séparé sur la [protection](/slides/fr/cpp/applying-protection-to-presentation/) et est pris en charge pour divers types de formes, y compris les [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/).

**La fidélité vectorielle SVG est‑elle préservée lors de l’exportation d’une présentation vers PDF/images ?**

Aspose.Slides permet d’extraire un SVG d’un [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) tel qu‑il a été créé. Lors de l’[exportation vers PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/) ou vers des formats raster [/slides/cpp/convert-powerpoint-to-png/], le résultat peut être rasterisé en fonction des paramètres d’exportation ; le fait que le SVG original soit stocké en tant que vecteur est confirmé par le comportement d’extraction.