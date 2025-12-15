---
title: Ajouter des diapositives aux présentations sur Android
linktitle: Ajouter une diapositive
type: docs
weight: 10
url: /fr/androidjava/add-slide-to-presentation/
keywords:
- ajouter une diapositive
- créer une diapositive
- diapositive vide
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Ajoutez facilement des diapositives à vos présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides for Android via Java — insertion de diapositives fluide et efficace en quelques secondes."
---

## **Ajouter une diapositive à une présentation**
{{% alert color="primary" %}} 

Avant de parler d'ajout de diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive **Master / Layout** et d'autres diapositives **Normal**. Cela signifie qu'un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides for Android via Java. Chaque diapositive possède un Id unique et toutes les Diapositives Normal sont organisées dans un ordre spécifié par l'index basé sur zéro.

{{% /alert %}} 

Aspose.Slides for Android via Java permet aux développeurs d'ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide dans la présentation, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Instancier la classe [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) en définissant une référence à la propriété [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) (collection d'objets Slide de contenu) exposée par l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Ajouter une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant la méthode [**addEmptySlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection).
- Effectuer des opérations sur la diapositive vide nouvellement ajoutée.
- Enfin, écrire le fichier de présentation en utilisant l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
```java
// Instancier la classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation();
try {
    // Instancier la classe SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Ajouter une diapositive vide à la collection Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Effectuer des opérations sur la diapositive nouvellement ajoutée

    // Enregistrer le fichier PPTX sur le disque
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **FAQ**

**Puis-je insérer une nouvelle diapositive à une position spécifique, et pas seulement à la fin ?**

Oui. La bibliothèque prend en charge les collections de diapositives et les opérations [insert](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) de sorte que vous pouvez ajouter une diapositive à l'index requis plutôt qu'à la fin uniquement.

**Les thèmes/styles sont-ils conservés lors de l'ajout d'une diapositive basée sur une disposition ?**

Oui. Une disposition hérite du formatage de son master, et la nouvelle diapositive hérite de la disposition sélectionnée et de son master associé.

**Quelle diapositive est présente dans une nouvelle présentation « vide » avant d'ajouter des diapositives ?**

Une présentation nouvellement créée contient déjà une diapositive vierge avec l'index zéro. Cela est important à prendre en compte lors du calcul des indices d'insertion.

**Comment choisir la disposition « correcte » pour une nouvelle diapositive si le master propose de nombreuses options ?**

En général, choisissez le [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) qui correspond à la structure requise ([Titre et contenu, Deux contenus, etc.](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidelayouttype/)). Si une telle disposition est absente, vous pouvez [l’ajouter au master](/slides/fr/androidjava/slide-layout/) et l'utiliser ensuite.