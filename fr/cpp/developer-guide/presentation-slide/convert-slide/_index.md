---
title: Convertir les diapositives de présentation en images en C++
linktitle: Diapositive en image
type: docs
weight: 41
url: /fr/cpp/convert-slide/
keywords:
- convertir diapositive
- exporter diapositive
- diapositive en image
- enregistrer diapositive en image
- diapositive en PNG
- diapositive en JPEG
- diapositive en bitmap
- diapositive en TIFF
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Convertir des diapositives PPT, PPTX et ODP en images en C++ avec Aspose.Slides—rendu rapide et de haute qualité avec des exemples de code clairs."
---
## **Introduction**

Aspose.Slides for C++ vous permet de convertir facilement les diapositives de présentations PowerPoint et OpenDocument en divers formats d’image, y compris BMP, PNG, JPG (JPEG), GIF et d’autres.

Pour convertir une diapositive en image, suivez ces étapes :

1. Définissez les paramètres de conversion souhaités et sélectionnez les diapositives à exporter en utilisant :
    - l’interface [ITiffOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/itiffoptions/), ou
    - l’interface [IRenderingOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/irenderingoptions/).
2. Générez l’image de la diapositive en appelant la méthode [GetImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/getimage/).

Un [Bitmap](https://reference.aspose.com/slides/fr/cpp/system.drawing/bitmap/) est un objet qui vous permet de travailler avec des images définies par des données de pixels. Vous pouvez utiliser une instance de cette classe pour enregistrer des images dans une large gamme de formats (BMP, JPG, PNG, etc.).

## **Convertir des diapositives en bitmaps et enregistrer les images en PNG**

Vous pouvez convertir une diapositive en objet bitmap et l’utiliser directement dans votre application. Vous pouvez également convertir une diapositive en bitmap puis enregistrer l’image en JPEG ou dans tout autre format préféré.

Ce code C++ montre comment convertir la première diapositive d’une présentation en objet bitmap, puis enregistrer l’image au format PNG :

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Convertir la première diapositive de la présentation en bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Enregistrer l'image au format PNG.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Convertir des diapositives en images avec des tailles personnalisées**

Il se peut que vous ayez besoin d’obtenir une image d’une taille précise. En utilisant une surcharge de la méthode [GetImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/getimage/), vous pouvez convertir une diapositive en image avec des dimensions spécifiques (largeur et hauteur).

Ce code d’exemple montre comment procéder :

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Convertir la première diapositive de la présentation en bitmap avec la taille spécifiée.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Enregistrer l'image au format JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Convertir des diapositives avec notes et commentaires en images**

Certaines diapositives peuvent contenir des notes et des commentaires.

Aspose.Slides fournit deux interfaces—[ITiffOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/itiffoptions/) et [IRenderingOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/irenderingoptions/)—qui vous permettent de contrôler le rendu des diapositives de présentation en images. Les deux interfaces incluent la méthode `set_SlidesLayoutOptions`, qui vous permet de configurer le rendu des notes et des commentaires sur une diapositive lors de sa conversion en image.

Avec la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/notescommentslayoutingoptions/), vous pouvez spécifier la position souhaitée pour les notes et les commentaires dans l’image résultante.

Ce code C++ montre comment convertir une diapositive contenant des notes et des commentaires :

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Charger un fichier de présentation.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Définir la position des notes.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Définir la position des commentaires.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Définir la largeur de la zone de commentaires.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Définir la couleur de la zone de commentaires.

// Créer les options de rendu.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Convertir la première diapositive de la présentation en image.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Enregistrer l'image au format GIF.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

Dans tout processus de conversion diapositive‑vers‑image, la méthode [set_NotesPosition](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) ne peut pas appliquer `BottomFull` (pour spécifier la position des notes) car le texte d’une note peut être trop volumineux pour tenir dans la taille d’image spécifiée.

{{% /alert %}} 

## **Convertir des diapositives en images en utilisant les options TIFF**

L’interface [ITiffOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/itiffoptions/) offre un contrôle plus fin sur l’image TIFF résultante en vous permettant de spécifier des paramètres tels que la taille, la résolution, la palette de couleurs, etc.

Ce code C++ montre un processus de conversion où les options TIFF sont utilisées pour produire une image noir‑et‑blanc avec une résolution de 300 DPI et une taille de 2160 × 2800 :

```cpp 
// Charger un fichier de présentation.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Obtenir la première diapositive de la présentation.
auto slide = presentation->get_Slide(0);

// Configurer les paramètres de l'image TIFF de sortie.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Définir la taille de l'image.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Définir le format de pixel (noir et blanc).
tiffOptions->set_DpiX(300);                                         // Définir la résolution horizontale.
tiffOptions->set_DpiY(300);                                         // Définir la résolution verticale.

// Convertir la diapositive en image avec les options spécifiées.
auto image = slide->GetImage(tiffOptions);

// Enregistrer l'image au format TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Convertir toutes les diapositives en images**

Aspose.Slides vous permet de convertir toutes les diapositives d’une présentation en images, transformant ainsi l’ensemble de la présentation en une série d’images.

Ce code d’exemple montre comment convertir toutes les diapositives d’une présentation en images en C++ :

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Rendre la présentation en images diapositive par diapositive.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Contrôler les diapositives masquées (ne pas rendre les diapositives masquées).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Convertir la diapositive en image.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Enregistrer l'image au format JPEG.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Rendu des emoji couleur**

{{% alert title="Note" color="warning" %}} 
Pour rendre correctement les emoji couleur lors de la conversion de diapositives en images, les polices emoji utilisées dans la présentation doivent être installées et disponibles sur le système qui effectue la conversion. Par exemple, si la présentation utilise **Segoe UI Emoji** et que cette police est absente, les emoji peuvent apparaître en monochrome dans les images générées.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑il en charge le rendu des diapositives avec animations ?**

Non, la méthode `GetImage` enregistre uniquement une image statique de la diapositive, sans animations.

**Les diapositives masquées peuvent‑elles être exportées en images ?**

Oui, les diapositives masquées peuvent être traitées comme les diapositives normales. Assurez‑vous simplement qu’elles soient incluses dans la boucle de traitement.

**Les images peuvent‑elles être enregistrées avec des ombres et des effets ?**

Oui, Aspose.Slides prend en charge le rendu des ombres, de la transparence et d’autres effets graphiques lors de l’enregistrement des diapositives en images.