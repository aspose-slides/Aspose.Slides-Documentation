---
title: Cadre photo
type: docs
weight: 10
url: /cpp/picture-frame/
keywords: "Ajouter un cadre photo, créer un cadre photo, ajouter une image, créer une image, extraire une image, propriété StretchOff, mise en forme du cadre photo, propriétés du cadre photo, présentation PowerPoint, C++, CPP, Aspose.Slides pour C++"
description: "Ajouter un cadre photo à une présentation PowerPoint en C++"
---

Un cadre photo est une forme qui contient une image - c'est comme une image dans un cadre.

Vous pouvez ajouter une image à une diapositive à travers un cadre photo. De cette façon, vous pouvez formater l'image en formatant le cadre photo.

{{% alert  title="Conseil" color="primary" %}} 

Aspose fournit des convertisseurs gratuits - [JPEG vers PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) - qui permettent aux utilisateurs de créer des présentations rapidement à partir d'images.

{{% /alert %}} 

## **Créer un cadre photo**

1. Créez une instance de la [classe Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez une référence à une diapositive via son index.
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) associée à l'objet de présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) basé sur la largeur et la hauteur de l'image via la méthode `AddPictureFrame` exposée par l'objet de forme associé à la diapositive référencée.
6. Ajoutez un cadre photo (contenant l'image) à la diapositive.
7. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ vous montre comment créer un cadre photo :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Charge la présentation désirée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Charge l'image qui sera ajoutée à la collection d'images de la présentation
// Obtient l'image
auto image = Images::FromFile(filePath);

// Ajoute une image à la collection d'images de la présentation
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Ajoute un cadre photo à la diapositive
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Définit l'échelle relative de la hauteur et de la largeur
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Applique une certaine mise en forme au PictureFrame
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Écrit le fichier PPTX sur disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

Les cadres photo vous permettent de créer rapidement des diapositives de présentation basées sur des images. Lorsque vous combiner un cadre photo avec les options de sauvegarde d'Aspose.Slides, vous pouvez manipuler les opérations d'entrée/sortie pour convertir des images d'un format à un autre. Vous voudrez peut-être consulter ces pages : convertir [image en JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/) ; convertir [JPG en image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/) ; convertir [JPG en PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/) ; convertir [PNG en SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Créer un cadre photo avec une échelle relative**

En modifiant l'échelle relative d'une image, vous pouvez créer un cadre photo plus complexe.

1. Créez une instance de la [classe Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez une référence à une diapositive via son index.
3. Ajoutez une image à la collection d'images de la présentation.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) associée à l'objet de présentation qui sera utilisé pour remplir la forme.
5. Spécifiez la largeur et la hauteur relatives de l'image dans le cadre photo.
6. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ vous montre comment créer un cadre photo avec une échelle relative :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Charge la présentation désirée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Charge l'image à ajouter à la collection d'images de la présentation
// Obtient l'image
auto image = Images::FromFile(filePath);

// Ajoute une image à la collection d'images de la présentation
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Ajoute un cadre photo à la diapositive
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Définit l'échelle relative de la hauteur et de la largeur
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Écrit le fichier PPTX sur disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Extraire une image d'un cadre photo**

Vous pouvez extraire des images d'objets [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) et les enregistrer au format PNG, JPG et autres. L'exemple de code ci-dessous illustre comment extraire une image du document "sample.pptx" et l'enregistrer au format PNG.

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

## **Obtenir la transparence d'une image**

Aspose.Slides vous permet d'obtenir la transparence d'une image. Ce code C++ démontre l'opération :

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Transparence de l'image : ") + transparencyValue);
    }
}
```

## **Mise en forme du cadre photo**

Aspose.Slides fournit de nombreuses options de mise en forme qui peuvent être appliquées à un cadre photo. En utilisant ces options, vous pouvez modifier un cadre photo pour le faire correspondre à des exigences spécifiques.

1. Créez une instance de la [classe Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez une référence à une diapositive via son index.
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) associée à l'objet de présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un `PictureFrame` basé sur la largeur et la hauteur de l'image via la méthode [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) exposée par l'objet [IShapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) associé à la diapositive référencée.
6. Ajoutez le cadre photo (contenant l'image) à la diapositive.
7. Définissez la couleur de ligne du cadre photo.
8. Définissez la largeur de la ligne du cadre photo.
9. Faites pivoter le cadre photo en lui donnant une valeur positive ou négative.
   * Une valeur positive fait pivoter l'image dans le sens des aiguilles d'une montre.
   * Une valeur négative fait pivoter l'image dans le sens inverse des aiguilles d'une montre.
10. Ajoutez le cadre photo (contenant l'image) à la diapositive.
11. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ démontre le processus de mise en forme du cadre photo :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Charge la présentation désirée
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Charge l'image à ajouter à la collection d'images de la présentation
// Obtient l'image
auto image = Images::FromFile(filePath);

// Ajoute une image à la collection d'images de la présentation
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Ajoute un cadre photo à la diapositive
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Définit l'échelle relative de la hauteur et de la largeur
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Écrit le fichier PPTX sur disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Conseil" color="primary" %}}

Aspose a récemment développé un [Créateur de Collage gratuit](https://products.aspose.app/slides/collage). Si vous avez besoin de [fusionner des images JPG/JPEG](https://products.aspose.com/slides/collage/jpg) ou PNG, [créer des grilles à partir de photos](https://products.aspose.app/slides/collage/photo-grid), vous pouvez utiliser ce service.

{{% /alert %}}

## **Ajouter une image en tant que lien**

Pour éviter des tailles de présentation volumineuses, vous pouvez ajouter des images (ou des vidéos) via des liens au lieu d'incorporer directement les fichiers dans les présentations. Ce code C++ vous montre comment ajouter une image et une vidéo dans un espace réservé :

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

## **Recadrer une image**

Ce code C++ vous montre comment recadrer une image existante sur une diapositive : 

``` CPP
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

## **Supprimer les zones recadrées d'une image**

Si vous souhaitez supprimer les zones recadrées d'une image contenue dans un cadre, vous pouvez utiliser la méthode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Cette méthode retourne l'image recadrée ou l'image d'origine si le recadrage est inutile.

Ce code C++ illustre l'opération : 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Obtient le PictureFrame de la première diapositive
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Supprime les zones recadrées de l'image du PictureFrame et retourne l'image recadrée
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Enregistre le résultat
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 

La méthode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ajoute l'image recadrée à la collection d'images de la présentation. Si l'image est uniquement utilisée dans le [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) traité, cette configuration peut réduire la taille de la présentation. Sinon, le nombre d'images dans la présentation résultante augmentera.

Cette méthode convertit les fichiers WMF/EMF métaphores en images PNG raster lors de l'opération de recadrage. 

{{% /alert %}}

## **Verrouiller le rapport d'aspect**

Si vous souhaitez qu'une forme contenant une image conserve son rapport d'aspect même après avoir modifié les dimensions de l'image, vous pouvez utiliser la méthode [set_AspectRatioLocked()](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) pour définir le paramètre *Verrouiller le rapport d'aspect*.

Ce code C++ vous montre comment verrouiller le rapport d'aspect d'une forme :

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// définit la forme pour préserver le rapport d'aspect lors du redimensionnement
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

Ce paramètre *Verrouiller le rapport d'aspect* préserve uniquement le rapport d'aspect de la forme et non de l'image qu'elle contient.

{{% /alert %}}

## **Utiliser la propriété StretchOff**

En utilisant les propriétés [StretchOffsetLeft](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) et [StretchOffsetBottom](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) de l'interface [IPictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format), vous pouvez spécifier un rectangle de remplissage.

Lorsque l'étirement d'une image est spécifié, un rectangle source est mis à l'échelle pour s'adapter au rectangle de remplissage spécifié. Chaque bord du rectangle de remplissage est défini par un décalage en pourcentage par rapport à l'extrémité correspondante de la boîte englobante de la forme. Un pourcentage positif spécifie un retrait. Un pourcentage négatif spécifie un dépassement.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez une référence à une diapositive via son index.
3. Ajoutez une forme de rectangle `AutoShape`. 
4. Créez une image.
5. Définissez le type de remplissage de la forme.
6. Définissez le mode de remplissage d'image de la forme.
7. Ajoutez une image définie pour remplir la forme.
8. Spécifiez les décalages d'image par rapport à l'extrémité correspondante de la boîte englobante de la forme.
9. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ démontre un processus dans lequel une propriété StretchOff est utilisée :

``` cpp
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