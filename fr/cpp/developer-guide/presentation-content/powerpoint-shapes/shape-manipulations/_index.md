---
title: Gérer les formes de présentation en C++
linktitle: Manipulation de forme
type: docs
weight: 40
url: /fr/cpp/shape-manipulations/
keywords:
- forme PowerPoint
- forme de présentation
- forme sur diapositive
- trouver forme
- dupliquer forme
- supprimer forme
- masquer forme
- changer ordre de forme
- obtenir ID de forme interop
- texte alternatif de forme
- formats de mise en page de forme
- forme en SVG
- forme vers SVG
- aligner forme
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à créer, modifier et optimiser les formes dans Aspose.Slides pour C++ et à fournir des présentations PowerPoint haute performance."
---

## **Trouver une forme sur une diapositive**
Ce sujet décrit une technique simple pour faciliter les développeurs à trouver une forme spécifique sur une diapositive sans utiliser son Id interne. Il est important de savoir que les fichiers PowerPoint Presentation n’offrent aucun moyen d’identifier les formes sur une diapositive, sauf par un Id unique interne. Il semble difficile pour les développeurs de trouver une forme en utilisant son Id unique interne. Toutes les formes ajoutées aux diapositives possèdent un texte alternatif. Nous suggérons aux développeurs d’utiliser le texte alternatif pour trouver une forme spécifique. Vous pouvez utiliser MS PowerPoint pour définir le texte alternatif des objets que vous prévoyez de modifier ultérieurement.

Après avoir défini le texte alternatif d’une forme souhaitée, vous pouvez ouvrir cette présentation avec Aspose.Slides for C++ et parcourir toutes les formes ajoutées à une diapositive. À chaque itération, vous pouvez vérifier le texte alternatif de la forme ; la forme dont le texte alternatif correspond sera celle que vous recherchez. Pour illustrer cette technique de manière plus claire, nous avons créé une méthode, [FindShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) qui permet de trouver une forme spécifique dans une diapositive et renvoie simplement cette forme.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}


## **Cloner une forme**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenir la référence d’une diapositive en utilisant son indice.
3. Accéder à la collection de formes de la diapositive source.
4. Ajouter une nouvelle diapositive à la présentation.
5. Cloner les formes de la collection de formes de la diapositive source vers la nouvelle diapositive.
6. Enregistrer la présentation modifiée en tant que fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}


## **Supprimer une forme**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Accéder à la première diapositive.
3. Trouver la forme avec un AlternativeText spécifique.
4. Supprimer la forme.
5. Enregistrer le fichier sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}


## **Masquer une forme**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Accéder à la première diapositive.
3. Trouver la forme avec un AlternativeText spécifique.
4. Masquer la forme.
5. Enregistrer le fichier sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}



## **Modifier l’ordre des formes**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Accéder à la première diapositive.
3. Ajouter une forme.
4. Ajouter du texte dans le cadre de texte de la forme.
5. Ajouter une autre forme aux mêmes coordonnées.
6. Réordonner les formes.
7. Enregistrer le fichier sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}


## **Obtenir l’ID de forme Interop**
Aspose.Slides for C++ permet aux développeurs d’obtenir un identifiant de forme unique au niveau de la diapositive, contrairement à la propriété UniqueId qui donne un identifiant unique au niveau de la présentation. La propriété OfficeInteropShapeId a été ajoutée aux interfaces IShape et à la classe Shape. La valeur renvoyée par la propriété OfficeInteropShapeId correspond à la valeur de l’Id de l’objet Microsoft.Office.Interop.PowerPoint.Shape. Le code d’exemple est présenté ci‑dessous.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}


## **Définir la propriété AlternativeText**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Accéder à la première diapositive.
3. Ajouter n’importe quelle forme à la diapositive.
4. Effectuer des opérations avec la forme récemment ajoutée.
5. Parcourir les formes pour trouver une forme.
6. Définir l’AlternativeText.
7. Enregistrer le fichier sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}


## **Accéder aux formats de mise en page d’une forme**
Aspose.Slides for C++ permet aux développeurs d’accéder aux formats de mise en page d’une forme. Cet article montre comment accéder aux propriétés **FillFormat** et **LineFormat** d’une forme.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Rendre une forme au format SVG**
Aspose.Slides for C++ prend désormais en charge le rendu d’une forme au format SVG. La méthode WriteAsSvg (et ses surcharges) a été ajoutée à la classe Shape et à l’interface IShape. Cette méthode permet d’enregistrer le contenu de la forme dans un fichier SVG. L’extrait de code ci‑dessous montre comment exporter la forme d’une diapositive vers un fichier SVG.
``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```


## **Alignement des formes**
Aspose.Slides permet d’aligner les formes soit par rapport aux marges de la diapositive, soit les unes par rapport aux autres. À cet effet, une méthode surchargée [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) a été ajoutée. L’énumération [ShapesAlignmentType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) définit les options d’alignement possibles.

**Example 1**

Le code source ci‑dessous aligne les formes d’indices 1, 2 et 4 le long du bord supérieur de la diapositive. 
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


**Example 2**

L’exemple ci‑dessous montre comment aligner l’ensemble de la collection de formes par rapport à la forme la plus basse de la collection.
``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```


## **Propriétés de retournement**
Dans Aspose.Slides, la classe [ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/) permet de contrôler le miroir horizontal et vertical des formes via ses propriétés `flipH` et `flipV`. Les deux propriétés sont de type [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/), acceptant les valeurs `True` pour indiquer un retournement, `False` pour aucun retournement, ou `NotDefined` pour utiliser le comportement par défaut. Ces valeurs sont accessibles depuis le [Frame](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_frame/) d’une forme.

Pour modifier les paramètres de retournement, une nouvelle instance de [ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/) est créée avec la position et la taille actuelles de la forme, les valeurs souhaitées pour `flipH` et `flipV`, ainsi que l’angle de rotation. L’affectation de cette instance au [Frame](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_frame/) de la forme et l’enregistrement de la présentation appliquent les transformations de miroir et les enregistrent dans le fichier de sortie.

Supposons que nous ayons un fichier sample.pptx dont la première diapositive contient une seule forme avec les paramètres de retournement par défaut, comme illustré ci‑dessous.

![The shape to be flipped](shape_to_be_flipped.png)

L’exemple de code suivant récupère les propriétés de retournement actuelles de la forme et la retourne à la fois horizontalement et verticalement.
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Récupérer la propriété de retournement horizontal de la forme.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Récupérer la propriété de retournement vertical de la forme.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Retourner horizontalement.
auto flipV = NullableBool::True; // Retourner horizontalement.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Le résultat:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Puis-je combiner des formes (union/intersection/soustraction) sur une diapositive comme dans un éditeur de bureau ?**

Il n’existe pas d’API d’opération booléenne intégrée. Vous pouvez l’approximer en construisant vous‑même le contour souhaité — par exemple, calculer la géométrie résultante (via [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)) et créer une nouvelle forme avec ce contour, en supprimant éventuellement les originales.

**Comment contrôler l’ordre d’empilement (z‑order) afin qu’une forme reste toujours « au premier plan » ?**

Modifiez l’ordre d’insertion/déplacement dans la collection [shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) de la diapositive. Pour des résultats prévisibles, finalisez le z‑order après toutes les autres modifications de la diapositive.

**Puis-je « verrouiller » une forme pour empêcher les utilisateurs de la modifier dans PowerPoint ?**

Oui. Définissez les [drapeaux de protection au niveau de la forme](/slides/fr/cpp/applying-protection-to-presentation/) (par ex., verrouiller la sélection, le déplacement, le redimensionnement, les modifications de texte). Si nécessaire, répliquez les restrictions sur le masque ou la disposition. Notez qu’il s’agit d’une protection au niveau de l’interface utilisateur, pas d’une fonction de sécurité ; pour une protection plus forte, combinez‑la avec des restrictions au niveau du fichier comme les [recommandations en lecture seule ou les mots de passe](/slides/fr/cpp/password-protected-presentation/).