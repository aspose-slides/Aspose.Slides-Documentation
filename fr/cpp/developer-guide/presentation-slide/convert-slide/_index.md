---
title: Convertir une diapositive
type: docs
weight: 41
url: /fr/cpp/convert-slide/
keywords: 
- convertir une diapositive en image
- exporter une diapositive en tant qu'image
- enregistrer une diapositive en tant qu'image
- diapositive en image
- diapositive en PNG
- diapositive en JPEG
- diapositive en bitmap
- C++
- Aspose.Slides pour C++
description: "Convertir une diapositive PowerPoint en image (Bitmap, PNG ou JPG) en C++"
---

Aspose.Slides pour C++ vous permet de convertir des diapositives (dans des présentations) en images. Voici les formats d'image pris en charge : BMP, PNG, JPG (JPEG), GIF, et d'autres.

Pour convertir une diapositive en image, procédez comme suit :

1. Tout d'abord, définissez les paramètres de conversion et les objets de diapositive à convertir en utilisant :
   * l'interface [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) ou
   * l'interface [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options).

2. Deuxièmement, convertissez la diapositive en image en utilisant la méthode [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

## **À propos du Bitmap et d'autres formats d'image**

Un [Bitmap](https://reference.aspose.com/slides/cpp/class/system.drawing.bitmap) est un objet qui vous permet de travailler avec des images définies par des données de pixels. Vous pouvez utiliser une instance de cette classe pour enregistrer des images dans une large gamme de formats (BMP, JPG, PNG, etc.).

{{% alert title="Info" color="info" %}}

Aspose a récemment développé un convertisseur en ligne [Text to GIF](https://products.aspose.app/slides/text-to-gif).

{{% /alert %}}

## **Conversion des diapositives en Bitmap et enregistrement des images en PNG**

Ce code C++ vous montre comment convertir la première diapositive d'une présentation en un objet bitmap, puis comment enregistrer l'image au format PNG :

``` cpp 
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// Convertit la première diapositive de la présentation en un objet Bitmap
System::SharedPtr<IImage> image = pres->get_Slide(0)->GetImage();

// Enregistre l'image au format PNG
image->Save(u"Slide_0.png", ImageFormat::Png);
```

{{% alert title="Astuce" color="primary" %}} 

Vous pouvez convertir une diapositive en un objet bitmap, puis utiliser l'objet directement quelque part. Ou vous pouvez convertir une diapositive en bitmap et ensuite enregistrer l'image en JPEG ou dans tout autre format de votre choix.

{{% /alert %}}  

## **Conversion des diapositives en images avec des tailles personnalisées**

Vous pourriez avoir besoin d'obtenir une image d'une certaine taille. En utilisant un surchargement de [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/), vous pouvez convertir une diapositive en image avec des dimensions spécifiques (longueur et largeur).

Ce code d'exemple démontre la conversion proposée en utilisant la méthode [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) en C++ :

``` cpp 
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");
// Convertit la première diapositive de la présentation en un Bitmap avec la taille spécifiée
auto image = pres->get_Slide(0)->GetImage(Size(1820, 1040));
// Enregistre l'image au format JPEG
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);
```

## **Conversion des diapositives avec notes et commentaires en images**

Certaines diapositives contiennent des notes et des commentaires.

Aspose.Slides fournit deux interfaces—[ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) et [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options)—qui vous permettent de contrôler le rendu des diapositives de présentation en images. Les deux interfaces contiennent l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) qui vous permet d'ajouter des notes et des commentaires sur une diapositive lorsque vous convertissez cette diapositive en image.

{{% alert title="Info" color="info" %}} 

Avec l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options), vous pouvez spécifier votre position préférée pour les notes et les commentaires dans l'image résultante.

{{% /alert %}} 

Ce code C++ démontre le processus de conversion d'une diapositive avec des notes et des commentaires :

``` cpp 
auto pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");
// Crée les options de rendu
auto options = System::MakeObject<RenderingOptions>();
auto notesCommentsLayouting = options->get_NotesCommentsLayouting();
// Définit la position des notes sur la page
notesCommentsLayouting->set_NotesPosition(NotesPositions::BottomTruncated);
// Définit la position des commentaires sur la page 
notesCommentsLayouting->set_CommentsPosition(CommentsPositions::Right);
// Définit la largeur de la zone de sortie des commentaires
notesCommentsLayouting->set_CommentsAreaWidth(500);
// Définit la couleur de la zone des commentaires
notesCommentsLayouting->set_CommentsAreaColor(Color::get_AntiqueWhite());

// Convertit la première diapositive de la présentation en un objet Bitmap
auto image = pres->get_Slide(0)->GetImage(options, 2.f, 2.f);

// Enregistre l'image au format GIF
image->Save(u"Slide_Notes_Comments_0.gif", ImageFormat::Gif);
```

{{% alert title="Note" color="warning" %}} 

Dans tout processus de conversion de diapositive en image, vous ne pouvez pas passer la valeur BottomFull (pour spécifier la position des notes) à la méthode [set_NotesPositions()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) car le texte d'une note peut être long, ce qui signifie qu'il pourrait ne pas s'adapter à la taille d'image spécifiée.

{{% /alert %}} 

## **Conversion des diapositives en images en utilisant ITiffOptions**

L'interface [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) vous donne plus de contrôle (en termes de paramètres) sur l'image résultante. En utilisant cette interface, vous pouvez spécifier la taille, la résolution, la palette de couleurs, et d'autres paramètres pour l'image résultante.

Ce code C++ démontre un processus de conversion où ITiffOptions est utilisé pour produire une image en noir et blanc avec une résolution de 300 dpi et une taille de 2160 × 2800 :

``` cpp 
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");

// Obtient une diapositive par son index
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Crée un objet TiffOptions
System::SharedPtr<TiffOptions> options = System::MakeObject<TiffOptions>();
options->set_ImageSize(Size(2160, 2880));

// Définit la police utilisée en cas de police source non trouvée
options->set_DefaultRegularFont(u"Arial Black");

// Définit la position des notes sur la page 
options->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomTruncated);

// Définit le format de pixel (noir et blanc)
options->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);

// Définit la résolution
options->set_DpiX(300);
options->set_DpiY(300);

// Convertit la diapositive en un objet Bitmap
System::SharedPtr<Bitmap> image = slide->GetImage(options);

// Enregistre l'image au format BMP
image->Save(u"PresentationNotesComments.bmp", ImageFormat::Tiff);
```

## **Conversion de toutes les diapositives en images**

Aspose.Slides vous permet de convertir toutes les diapositives d'une seule présentation en images. Essentiellement, vous pouvez convertir la présentation (dans son intégralité) en images.

Ce code d'exemple vous montre comment convertir toutes les diapositives d'une présentation en images en C++ :

``` cpp 
// Chemin vers le répertoire de sortie
System::String outputDir = u"D:\\PresentationImages";

auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// Rendre la présentation en un tableau d'images diapositive par diapositive
for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
{
    // Contrôle des diapositives cachées (ne pas rendre les diapositives cachées)
    if (pres->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Convertit la diapositive en un objet Bitmap
    auto image = pres->get_Slide(i)->GetImage(2.f, 2.f);

    // Crée un nom de fichier pour une image
    auto outputFilePath = Path::Combine(outputDir, String(u"Slide_") + i + u".jpg");

    // Enregistre l'image au format PNG
    image->Save(outputFilePath, ImageFormat::Png);
}
```