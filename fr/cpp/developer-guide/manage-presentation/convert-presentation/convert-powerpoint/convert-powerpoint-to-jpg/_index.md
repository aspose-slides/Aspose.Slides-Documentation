---
title: Convertir PPT et PPTX en JPG en C++
linktitle: PowerPoint en JPG
type: docs
weight: 60
url: /fr/cpp/convert-powerpoint-to-jpg/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en JPG
- présentation en JPG
- diapositive en JPG
- PPT en JPG
- PPTX en JPG
- enregistrer PowerPoint en JPG
- enregistrer présentation en JPG
- enregistrer diapositive en JPG
- enregistrer PPT en JPG
- enregistrer PPTX en JPG
- exporter PPT en JPG
- exporter PPTX en JPG
- C++
- Aspose.Slides
description: "Convertissez les diapositives PowerPoint (PPT, PPTX) en images JPG de haute qualité en C++ avec Aspose.Slides en utilisant des exemples de code rapides et fiables."
---
## **Introduction**

Convertir des présentations PowerPoint et OpenDocument en images JPG facilite le partage des diapositives, l'optimisation des performances et l'intégration du contenu dans des sites Web ou des applications. Aspose.Slides for C++ vous permet de transformer des fichiers PPTX, PPT et ODP en images JPEG de haute qualité. Ce guide explique les différentes méthodes de conversion.

Avec ces fonctionnalités, il est facile de mettre en œuvre votre propre visualiseur de présentations et de créer une miniature pour chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives contre la copie ou présenter la présentation en mode lecture seule. Aspose.Slides vous permet de convertir l’ensemble de la présentation ou une diapositive spécifique en formats d’image.

## **Convertir les diapositives de présentation en images JPG**

Voici les étapes pour convertir un fichier PPT, PPTX ou ODP en JPG :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
1. Obtenez l’objet diapositive du type [ISlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/) à partir de la collection de diapositives de la présentation.
1. Créez une image de la diapositive en utilisant la méthode [ISlide.GetImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/getimage/).
1. Appelez la méthode [IImage.Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/save/) sur l’objet image. Passez le nom du fichier de sortie et le format d’image en tant qu’arguments.

{{% alert color="info" %}} 

**Remarque :** La conversion PPT, PPTX ou ODP en JPG diffère de la conversion vers d’autres formats dans l’API Aspose.Slides for C++. Pour d’autres formats, vous utilisez généralement la méthode [IPresentation.Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/save/). Cependant, pour la conversion en JPG, vous devez utiliser la méthode [IImage.Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/save/).

{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Créer une image de diapositive à l'échelle spécifiée.
    auto image = slide->GetImage(scaleX, scaleY);

    // Enregistrer l'image sur le disque au format JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Convertir les diapositives en JPG avec des dimensions personnalisées**

Pour modifier les dimensions des images JPG résultantes, vous pouvez définir la taille de l’image en la passant à la méthode [ISlide.GetImage(Size)](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). Cela vous permet de générer des images avec des valeurs de largeur et de hauteur spécifiques, garantissant que la sortie répond à vos exigences en termes de résolution et de ratio d’aspect. Cette flexibilité est particulièrement utile lors de la génération d’images pour des applications Web, des rapports ou de la documentation, où des dimensions d’image précises sont requises.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Créer une image de diapositive de la taille spécifiée.
    auto image = slide->GetImage(imageSize);

    // Enregistrer l'image sur le disque au format JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Rendu des commentaires lors de l’enregistrement des diapositives en images**

Aspose.Slides for C++ propose une fonctionnalité qui vous permet de rendre les commentaires sur les diapositives d’une présentation lors de leur conversion en images JPG. Cette fonctionnalité est particulièrement utile pour conserver les annotations, les retours ou les discussions ajoutées par des collaborateurs dans les présentations PowerPoint. En activant cette option, vous assurez que les commentaires sont visibles dans les images générées, ce qui facilite la révision et le partage des retours sans avoir à ouvrir le fichier de présentation d’origine.

Supposons que nous ayons un fichier de présentation, "sample.pptx", contenant une diapositive avec des commentaires :

![La diapositive avec commentaires](slide_with_comments.png)

Le code C++ suivant convertit la diapositive en image JPG tout en conservant les commentaires :

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Définir les options pour les commentaires de la diapositive.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Convertir la première diapositive en image.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

Le résultat :

![L’image JPG avec commentaires](image_with_comments.png)

## **Voir aussi**

Voir d’autres options pour convertir PPT, PPTX ou ODP en images, telles que :

- [Convertir PowerPoint en GIF](/slides/fr/cpp/convert-powerpoint-to-animated-gif/)
- [Convertir PowerPoint en PNG](/slides/fr/cpp/convert-powerpoint-to-png/)
- [Convertir PowerPoint en TIFF](/slides/fr/cpp/convert-powerpoint-to-tiff/)
- [Convertir PowerPoint en SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Pour voir comment Aspose.Slides convertit PowerPoint en images JPG, essayez ces convertisseurs en ligne gratuits : PowerPoint [PPTX vers JPG](https://products.aspose.app/slides/fr/conversion/pptx-to-jpg) et [PPT vers JPG](https://products.aspose.app/slides/fr/conversion/ppt-to-jpg). 

{{% /alert %}}

![Convertisseur en ligne gratuit PPTX vers JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose propose une [application Web GRATUITE de collage](https://products.aspose.app/slides/fr/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG vers JPG](https://products.aspose.app/slides/fr/collage/jpg) ou PNG vers PNG, créer des [grilles de photos](https://products.aspose.app/slides/fr/collage/photo-grid), etc. 

En appliquant les mêmes principes décrits dans cet article, vous pouvez convertir des images d’un format à un autre. Pour plus d’informations, consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/fr/cpp/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/fr/cpp/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/fr/cpp/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/fr/cpp/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/fr/cpp/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/fr/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

### Cette méthode prend‑elle en charge la conversion par lots ?

Oui, Aspose.Slides permet la conversion par lots de plusieurs diapositives en JPG en une seule opération.

### La conversion prend‑elle en charge SmartArt, les graphiques et d’autres objets complexes ?

Oui, Aspose.Slides rend tout le contenu, y compris SmartArt, les graphiques, les tableaux, les formes, etc. Cependant, la précision du rendu peut varier légèrement par rapport à PowerPoint, notamment lorsqu’on utilise des polices personnalisées ou manquantes.

### Existe‑t‑il des limites au nombre de diapositives pouvant être traitées ?

Aspose.Slides ne fixe aucune limite stricte au nombre de diapositives que vous pouvez traiter. Cependant, vous pouvez rencontrer des erreurs de mémoire insuffisante lors du traitement de présentations volumineuses ou d’images haute résolution.