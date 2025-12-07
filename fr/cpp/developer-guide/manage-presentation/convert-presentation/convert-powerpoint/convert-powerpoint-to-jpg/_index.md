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

## **Aperçu**

La conversion des présentations PowerPoint et OpenDocument en images JPG facilite le partage des diapositives, l'optimisation des performances et l'intégration du contenu dans des sites Web ou des applications. Aspose.Slides for C++ vous permet de transformer les fichiers PPTX, PPT et ODP en images JPEG de haute qualité. Ce guide explique les différentes méthodes de conversion.

Grâce à ces fonctionnalités, il est facile de mettre en œuvre votre propre visualiseur de présentations et de créer une vignette pour chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives de la présentation contre la copie ou présenter la présentation en mode lecture seule. Aspose.Slides permet de convertir l'intégralité de la présentation ou une diapositive spécifique en formats d'image.

## **Convertir les diapositives de présentation en images JPG**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Récupérez l'objet diapositive de type [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) à partir de la collection de diapositives de la présentation.
3. Créez une image de la diapositive en utilisant la méthode [ISlide.GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).
4. Appelez la méthode [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) sur l'objet image. Passez le nom du fichier de sortie et le format d'image en arguments.

{{% alert color="primary" %}} 

**Remarque :** la conversion de PPT, PPTX ou ODP en JPG diffère de la conversion vers d'autres formats dans l'API Aspose.Slides for C++. Pour les autres formats, vous utilisez généralement la méthode [IPresentation.Save](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/save/). Cependant, pour la conversion en JPG, vous devez utiliser la méthode [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

{{% /alert %}} 
```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Créez une image de la diapositive à l'échelle spécifiée.
    auto image = slide->GetImage(scaleX, scaleY);

    // Enregistrez l'image sur le disque au format JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **Convertir les diapositives en JPG avec des dimensions personnalisées**

Pour modifier les dimensions des images JPG résultantes, vous pouvez définir la taille de l'image en la transmettant à la méthode [ISlide.GetImage(Size)](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). Cela vous permet de générer des images avec des valeurs de largeur et de hauteur spécifiques, garantissant que le résultat répond à vos exigences de résolution et de ratio d'aspect. Cette flexibilité est particulièrement utile lors de la génération d'images pour des applications Web, des rapports ou de la documentation, où des dimensions d'image précises sont requises.
```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Créez une image de diapositive de la taille spécifiée.
    auto image = slide->GetImage(imageSize);

    // Enregistrez l'image sur le disque au format JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **Rendre les commentaires lors de l'enregistrement des diapositives en images**

Aspose.Slides for C++ fournit une fonctionnalité qui permet de rendre les commentaires sur les diapositives d'une présentation lors de leur conversion en images JPG. Cette fonctionnalité est particulièrement utile pour conserver les annotations, les retours ou les discussions ajoutés par les collaborateurs dans les présentations PowerPoint. En activant cette option, vous assurez que les commentaires sont visibles dans les images générées, facilitant ainsi la revue et le partage des retours sans avoir à ouvrir le fichier de présentation original.

Supposons que nous disposions d'un fichier de présentation, "sample.pptx", contenant une diapositive avec des commentaires :

![La diapositive avec commentaires](slide_with_comments.png)

Le code C++ suivant convertit la diapositive en image JPG tout en conservant les commentaires :
```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Définir les options des commentaires de la diapositive.
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

![L'image JPG avec commentaires](image_with_comments.png)

## **Voir aussi**

Voir d'autres options pour convertir PPT, PPTX ou ODP en images, telles que :

- [Convertir PowerPoint en GIF](/slides/fr/cpp/convert-powerpoint-to-animated-gif/)
- [Convertir PowerPoint en PNG](/slides/fr/cpp/convert-powerpoint-to-png/)
- [Convertir PowerPoint en TIFF](/slides/fr/cpp/convert-powerpoint-to-tiff/)
- [Convertir PowerPoint en SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit PowerPoint en images JPG, essayez ces convertisseurs en ligne gratuits : PowerPoint [PPTX en JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT en JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}}

![Convertisseur en ligne gratuit PPTX vers JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose propose une [application Web GRATUITE de collage](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc.

En appliquant les mêmes principes décrits dans cet article, vous pouvez convertir des images d'un format à un autre. Pour plus d'informations, consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Cette méthode prend‑elle en charge la conversion en lot ?**

Oui, Aspose.Slides permet la conversion en lot de plusieurs diapositives en JPG en une seule opération.

**La conversion prend‑elle en charge SmartArt, les graphiques et d’autres objets complexes ?**

Oui, Aspose.Slides rend tout le contenu, y compris SmartArt, les graphiques, les tableaux, les formes, etc. Cependant, la précision du rendu peut varier légèrement par rapport à PowerPoint, notamment lorsque des polices personnalisées ou manquantes sont utilisées.

**Existe‑t‑il des limites au nombre de diapositives pouvant être traitées ?**

Aspose.Slides lui‑même n’impose aucune limite stricte au nombre de diapositives que vous pouvez traiter. Cependant, vous pouvez rencontrer une erreur de manque de mémoire lorsque vous travaillez avec de grandes présentations ou des images à haute résolution.