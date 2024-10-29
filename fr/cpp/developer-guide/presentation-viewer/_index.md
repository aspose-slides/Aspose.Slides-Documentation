---
title: Visionneuse de Présentation
type: docs
weight: 50
url: /fr/cpp/presentation-viewer/
keywords: 
- voir présentation PowerPoint
- voir ppt
- voir PPTX
- C++
- Aspose.Slides pour C++
description: "Voir la présentation PowerPoint en C++"
---

## **Générer une Image SVG à partir d'une Diapositive**
Aspose.Slides pour C++ est utilisé pour créer des fichiers de présentation, complets avec des diapositives. Ces diapositives peuvent être visualisées en ouvrant les présentations avec Microsoft PowerPoint. Mais parfois, les développeurs peuvent également avoir besoin de visualiser les diapositives en tant qu'images SVG dans leur visionneuse d'images préférée. Dans de tels cas, Aspose.Slides pour C++ permet d'exporter une diapositive individuelle au format SVG. Cet article décrit comment utiliser cette fonctionnalité. Pour générer une image SVG à partir de n'importe quelle diapositive souhaitée avec Aspose.Slides.Pptx pour C++, veuillez suivre les étapes ci-dessous :

- Créez une instance de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) classe.
- Obtenez la référence de la diapositive souhaitée en utilisant son ID ou son index.
- Obtenez l'image SVG dans un flux mémoire.
- Enregistrez le flux mémoire dans un fichier.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSlidesSVGImage-CreateSlidesSVGImage.cpp" >}}
## **Générer un SVG avec des IDS de Formes Personnalisées**
Désormais, Aspose.Slides pour C++ peut être utilisé pour générer un SVG à partir d'une diapositive avec un ID de forme personnalisé. Ces diapositives peuvent être visualisées en ouvrant des présentations avec Microsoft PowerPoint. Mais parfois, les développeurs peuvent également avoir besoin de visualiser les diapositives en tant qu'images SVG dans leur visionneuse d'images préférée. Dans de tels cas, Aspose.Slides pour C++ permet d'exporter une diapositive individuelle au format SVG. À cet effet, la propriété ID a été ajoutée à ISvgShape pour prendre en charge les IDs personnalisés des formes dans le SVG généré. Pour mettre en œuvre cette fonctionnalité, un CustomSvgShapeFormattingController a été introduit que vous pouvez utiliser pour définir l'ID de la forme.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GeneratingSVGWithCustomShapeIDS-GeneratingSVGWithCustomShapeIDS.cpp" >}}

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomSvgShapeFormattingController-CustomSvgShapeFormattingController.cpp" >}}


## **Créer une Image Miniature de Diapositive**
Aspose.Slides pour C++ est utilisé pour créer des fichiers de présentation contenant des diapositives. Ces diapositives peuvent être visualisées en ouvrant des fichiers de présentation avec Microsoft PowerPoint. Mais parfois, les développeurs peuvent avoir besoin de visualiser les diapositives sous forme d'images à l'aide de leur visionneuse d'images préférée. Dans de tels cas, Aspose.Slides pour C++ vous aide à générer des images miniatures des diapositives. Pour générer la miniature de n'importe quelle diapositive souhaitée en utilisant Aspose.Slides pour C++ :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) classe.
1. Obtenez la référence de n'importe quelle diapositive souhaitée en utilisant son ID ou son index.
1. Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée.
1. Enregistrez l'image miniature dans n'importe quel format d'image souhaité.

```cpp
// Instancier la classe Presentation
auto presentation = MakeObject<Presentation>(u"ThumbnailFromSlide.pptx");

// Accédez à la première diapositive
auto slide = presentation->get_Slide(0);

// Créer une image à échelle complète
auto image = slide->GetImage(1, 1);
image->Save(u"Thumbnail_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Créer une Miniature avec des Dimensions Définies par l'Utilisateur**
1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) classe.
1. Obtenez la référence de n'importe quelle diapositive souhaitée en utilisant son ID ou son index.
1. Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée.
1. Enregistrez l'image miniature dans n'importe quel format d'image souhaité.

```cpp
// Instancier la classe Presentation
auto presentation = MakeObject<Presentation>(u"ThumbnailWithUserDefinedDimensions.pptx");

// Accédez à la première diapositive
auto slide = presentation->get_Slide(0);

// Dimensions définies par l'utilisateur
auto desiredX = 1200;
auto desiredY = 800;

auto slideSize = presentation->get_SlideSize()->get_Size();

// Obtention de la valeur mise à l'échelle de X et Y
auto scaleX = (float)(1.0 / slideSize.get_Width()) * desiredX;
auto scaleY = (float)(1.0 / slideSize.get_Height()) * desiredY;

// Créer une image à échelle personnalisée
auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"Thumbnail2_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Créer une Miniature à partir de la Diapositive dans la Vue Notes**
Pour générer la miniature de n'importe quelle diapositive souhaitée dans la Vue Notes à l'aide d'Aspose.Slides pour C++ :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) classe.
1. Obtenez la référence de n'importe quelle diapositive souhaitée en utilisant son ID ou son index.
1. Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée dans la vue Notes.
1. Enregistrez l'image miniature dans n'importe quel format d'image souhaité.

Le code ci-dessous produit une miniature de la première diapositive d'une présentation en Vue Notes.

```cpp
// Instancier la classe Presentation
auto presentation = MakeObject<Presentation>(u"ThumbnailFromSlideInNotes.pptx");

// Accédez à la première diapositive
auto slide = presentation->get_Slide(0);

// Dimensions définies par l'utilisateur
auto desiredX = 1200;
auto desiredY = 800;

auto slideSize = presentation->get_SlideSize()->get_Size();

// Obtention de la valeur mise à l'échelle de X et Y
auto scaleX = (float)(1.0 / slideSize.get_Width()) * desiredX;
auto scaleY = (float)(1.0 / slideSize.get_Height()) * desiredY;

// Créer une image à échelle complète
auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"Notes_tnail_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```