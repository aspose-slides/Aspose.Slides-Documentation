---
title: Manipulations de Formes
type: docs
weight: 40
url: /cpp/shape-manipulations/
---

## **Trouver une Forme dans une Diapositive**
Ce sujet décrira une technique simple pour faciliter aux développeurs la recherche d'une forme spécifique sur une diapositive sans utiliser son Id interne. Il est important de savoir que les fichiers de présentation PowerPoint ne disposent d'aucune méthode pour identifier les formes sur une diapositive, sauf un Id unique interne. Il semble difficile pour les développeurs de trouver une forme en utilisant son Id unique interne. Toutes les formes ajoutées aux diapositives ont un texte alternatif. Nous suggérons aux développeurs d'utiliser le texte alternatif pour trouver une forme spécifique. Vous pouvez utiliser MS PowerPoint pour définir le texte alternatif pour les objets que vous prévoyez de modifier à l'avenir.

Après avoir défini le texte alternatif de la forme désirée, vous pouvez ensuite ouvrir cette présentation en utilisant Aspose.Slides pour C++ et itérer à travers toutes les formes ajoutées à une diapositive. À chaque itération, vous pouvez vérifier le texte alternatif de la forme et la forme avec le texte alternatif correspondant serait celle requise par vous. Pour démontrer cette technique de manière plus efficace, nous avons créé une méthode, [FindShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) qui fait le tour afin de trouver une forme spécifique dans une diapositive et retourne simplement cette forme.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}


## **Cloner une Forme**
Pour cloner une forme sur une diapositive en utilisant Aspose.Slides pour C++ :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) classe.
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Accédez à la collection de formes de la diapositive source.
1. Ajoutez une nouvelle diapositive à la présentation.
1. Clonez les formes de la collection de formes de la diapositive source vers la nouvelle diapositive.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

L'exemple ci-dessous ajoute une forme groupée à une diapositive.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}


## **Supprimer une Forme**
Aspose.Slides pour C++ permet aux développeurs de supprimer n'importe quelle forme. Pour supprimer la forme d'une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) classe.
1. Accédez à la première diapositive.
1. Trouvez la forme avec un AlternativeText spécifique.
1. Supprimez la forme.
1. Enregistrez le fichier sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}


## **Cacher une Forme**
Aspose.Slides pour C++ permet aux développeurs de cacher n'importe quelle forme. Pour cacher la forme d'une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) classe.
1. Accédez à la première diapositive.
1. Trouvez la forme avec un AlternativeText spécifique.
1. Cachez la forme.
1. Enregistrez le fichier sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}



## **Changer l'Ordre des Formes**
Aspose.Slides pour C++ permet aux développeurs de réorganiser les formes. La réorganisation des formes spécifie quelle forme est à l'avant ou quelle forme est à l'arrière. Pour réorganiser la forme d'une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) classe.
1. Accédez à la première diapositive.
1. Ajoutez une forme.
1. Ajoutez du texte dans le cadre de texte de la forme.
1. Ajoutez une autre forme avec les mêmes coordonnées.
1. Réorganisez les formes.
1. Enregistrez le fichier sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}


## **Obtenir l'ID de la Forme Interop**
Aspose.Slides pour C++ permet aux développeurs d'obtenir un identifiant unique de forme dans le scope de la diapositive par rapport à la propriété UniqueId, qui permet d'obtenir un identifiant unique dans le scope de la présentation. La propriété OfficeInteropShapeId a été ajoutée aux interfaces IShape et à la classe Shape respectivement. La valeur retournée par la propriété OfficeInteropShapeId correspond à la valeur de l'Id de l'objet Microsoft.Office.Interop.PowerPoint.Shape. Ci-dessous, un exemple de code est donné.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}


## **Définir la Propriété AlternativeText**
Aspose.Slides pour C++ permet aux développeurs de définir l'AlternateText de n'importe quelle forme. Pour définir l'AlternateText d'une forme, veuillez suivre les étapes ci-dessous :

1. Créez une instance de [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) classe.
1. Accédez à la première diapositive.
1. Ajoutez n'importe quelle forme à la diapositive.
1. Faites quelques travaux avec la forme nouvellement ajoutée.
1. Parcourez les formes pour trouver une forme.
1. Définissez le AlternativeText.
1. Enregistrez le fichier sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}


## **Accéder aux Formats de Mise en Page pour une Forme**
Aspose.Slides pour C++ permet aux développeurs d'accéder aux formats de mise en page pour une forme. Cet article démontre comment vous pouvez accéder aux propriétés **FillFormat** et **LineFormat** pour une forme.

Ci-dessous, un exemple de code est donné.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Rendre une Forme en tant que SVG**
Maintenant, Aspose.Slides pour C++ prend en charge le rendu d'une forme en tant que svg. La méthode WriteAsSvg (et ses surcharges) a été ajoutée à la classe Shape et à l'interface IShape. Cette méthode permet d'enregistrer le contenu de la forme en tant que fichier SVG. L'extrait de code ci-dessous montre comment exporter la forme d'une diapositive vers un fichier SVG.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Alignement des Formes**
Aspose.Slides permet d'aligner les formes soit par rapport aux marges de la diapositive, soit l'une par rapport à l'autre. À cet effet, une méthode surchargée [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) a été ajoutée. L'énumération [ShapesAlignmentType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) définit les options d'alignement possibles.

**Exemple 1**

Le code source ci-dessous aligne les formes avec les indices 1, 2 et 4 le long de la bordure supérieure de la diapositive.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**Exemple 2**

L'exemple ci-dessous montre comment aligner l'intégralité de la collection de formes par rapport à la toute dernière forme de la collection.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```