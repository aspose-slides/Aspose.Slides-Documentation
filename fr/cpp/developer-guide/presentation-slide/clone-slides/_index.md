---
title: Cloner les diapositives d'une présentation en C++
linktitle: Cloner les diapositives
type: docs
weight: 40
url: /fr/cpp/clone-slides/
keywords:
- cloner diapositive
- copier diapositive
- enregistrer diapositive
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Dupliquez rapidement les diapositives PowerPoint avec Aspose.Slides for C++. Suivez nos exemples de code clairs pour automatiser la création de PPT en quelques secondes et éliminer le travail manuel."
---
## **Introduction**

Le clonage est le processus consistant à faire une copie exacte ou une réplique de quelque chose. Aspose.Slides for C++ permet également de créer une copie ou un clone de n'importe quelle diapositive, puis d'insérer cette diapositive clonée dans la présentation actuelle ou dans toute autre présentation ouverte. Le processus de clonage de diapositive crée une nouvelle diapositive qui peut être modifiée par les développeurs sans modifier la diapositive originale. Il existe plusieurs façons possibles de cloner une diapositive :

- Cloner à la fin d'une présentation.
- Cloner à une autre position dans la même présentation.
- Cloner à la fin d'une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner à une position spécifique dans une autre présentation.

Dans Aspose.Slides for C++, (une collection d'objets [ISlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/) ) exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) fournit les méthodes [AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) et [InsertClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/insertclone/) pour effectuer les types de clonage de diapositive ci‑dessus.

## **Cloner une diapositive à la fin d'une présentation**
Si vous souhaitez cloner une diapositive puis l'utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) selon les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/) en faisant référence à la collection Slides exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/) et transmettez la diapositive à cloner comme paramètre à la méthode [AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/).
1. Enregistrez le fichier de présentation modifié.

Dans l'exemple ci‑dessous, nous avons cloné une diapositive (située à la première position – indice zéro – de la présentation) à la fin de la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Cloner une diapositive à une autre position dans une présentation**
Si vous souhaitez cloner une diapositive puis l'utiliser dans le même fichier de présentation mais à une position différente, utilisez la méthode [InsertClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/insertclone/) :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
1. Instanciez la classe en faisant référence à la collection **Slides** exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
1. Appelez la méthode [InsertClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/insertclone/) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/) et transmettez la diapositive à cloner ainsi que l'indice de la nouvelle position comme paramètres à la méthode [InsertClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/insertclone/).
1. Enregistrez la présentation modifiée au format PPTX.

Dans l'exemple ci‑dessous, nous avons cloné une diapositive (située à l'indice zéro – position 1 – de la présentation) à l'indice 1 – position 2 – de la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Cloner une diapositive à la fin d'une autre présentation**
Si vous devez cloner une diapositive d'une présentation et l'utiliser dans une autre présentation, à la fin des diapositives existantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) contenant la présentation dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/) en faisant référence à la collection **Slides** exposée par l'objet Presentation de la présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/) et transmettez la diapositive de la présentation source comme paramètre à la méthode [AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l'exemple ci‑dessous, nous avons cloné une diapositive (à partir du premier indice de la présentation source) à la fin de la présentation de destination.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Cloner une diapositive à une autre position dans une autre présentation**
Si vous devez cloner une diapositive d'une présentation et l'utiliser dans une autre présentation, à une position spécifique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) contenant la présentation dans laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/) en faisant référence à la collection Slides exposée par l'objet Presentation de la présentation de destination.
1. Appelez la méthode [InsertClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/insertclone/) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/) et transmettez la diapositive de la présentation source ainsi que la position souhaitée comme paramètres à la méthode [InsertClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/insertclone/).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l'exemple ci‑dessous, nous avons cloné une diapositive (à partir de l'indice zéro de la présentation source) à l'indice 1 (position 2) de la présentation de destination.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Cloner une diapositive à une position spécifique dans une autre présentation**
Si vous devez cloner une diapositive avec sa diapositive maîtresse d’une présentation et l’utiliser dans une autre présentation, vous devez d’abord cloner la diapositive maîtresse désirée de la présentation source vers la présentation de destination. Ensuite, utilisez cette diapositive maîtresse pour cloner la diapositive avec maître. La méthode **AddClone(ISlide, IMasterSlide)** attend la diapositive maîtresse de la présentation de destination plutôt que celle de la source. Pour cloner la diapositive avec maître, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) contenant la présentation de destination dans laquelle la diapositive sera clonée.
1. Accédez à la diapositive à cloner ainsi qu'à sa diapositive maîtresse.
1. Instanciez la classe [IMasterSlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslidecollection/) en faisant référence à la collection Masters exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) de la présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) exposée par l'objet [IMasterSlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslidecollection/) et transmettez le maître de la source PPTX à cloner comme paramètre à la méthode [AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/) en référant la collection Slides exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) de la présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/) et transmettez la diapositive de la source ainsi que la diapositive maîtresse comme paramètres à la méthode [AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l'exemple ci‑dessous, nous avons cloné une diapositive avec maître (située à l'indice zéro de la présentation source) à la fin de la présentation de destination en utilisant le maître de la diapositive source.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Cloner une diapositive à la fin d’une section spécifiée**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation mais dans une section différente, utilisez la méthode [**AddClone()**](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) exposée par l'interface [**ISlideCollection**](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/). Aspose.Slides for C++ permet de cloner une diapositive de la première section puis d'insérer cette diapositive clonée dans la seconde section de la même présentation.

Le fragment de code suivant montre comment cloner une diapositive et insérer la diapositive clonée dans une section spécifiée.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Assurer la correspondance de la taille des diapositives**

Lors du clonage de diapositives dans une autre présentation, assurez‑vous que la présentation de destination a la même taille de diapositive que la source. Si les tailles diffèrent, Aspose.Slides ne redimensionne pas automatiquement les formes clonées — leurs coordonnées et dimensions d'origine sont conservées, ce qui peut entraîner un mauvais alignement du contenu ou un débordement au‑delà des limites de la diapositive.

Vous pouvez définir la taille de diapositive de la présentation de destination pour qu’elle corresponde à celle de la source avant de cloner le maître et la diapositive :

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

Effectuez cette opération avant de cloner le maître et la diapositive.

## **FAQ**

**Les notes du présentateur et les commentaires des réviseurs sont-ils clonés ?**

Oui. La page de notes et les commentaires de révision sont inclus dans le clone. Si vous ne les voulez pas, [supprimez‑les](/slides/fr/cpp/presentation-notes/) après l’insertion.

**Comment les graphiques et leurs sources de données sont‑ils gérés ?**

L’objet graphique, son formatage et les données intégrées sont copiés. Si le graphique était lié à une source externe (par ex. un classeur OLE intégré), ce lien est préservé en tant qu’[objet OLE](/slides/fr/cpp/manage-ole/). Après le déplacement entre fichiers, vérifiez la disponibilité des données et le comportement de rafraîchissement.

**Puis‑je contrôler la position d’insertion et les sections du clone ?**

Oui. Vous pouvez insérer le clone à un indice de diapositive précis et le placer dans une [section](/slides/fr/cpp/slide-section/) choisie. Si la section cible n’existe pas, créez‑la d’abord puis déplacez la diapositive dedans.