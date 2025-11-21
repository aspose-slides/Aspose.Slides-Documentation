---
title: Ajouter une diapositive à la présentation
type: docs
weight: 10
url: /fr/nodejs-java/add-slide-to-presentation/
---

## **Ajouter une diapositive à la présentation**
{{% alert color="primary" %}} 

Avant de parler de l'ajout de diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive **Master / Layout** et d'autres diapositives **Normal**. Cela signifie qu'un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides for Node.js via Java. Chaque diapositive possède un Id unique et toutes les diapositives Normal sont disposées dans un ordre spécifié par l'index à base zéro.

{{% /alert %}} 

Aspose.Slides for Node.js via Java permet aux développeurs d'ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide dans la présentation, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Instancier la classe [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) en définissant une référence à la propriété [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) (collection d'objets Slide de contenu) exposée par l'objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Ajouter une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant la méthode [**addEmptySlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) exposée par l'objet [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection).
- Effectuer des opérations avec la nouvelle diapositive vide ajoutée.
- Enfin, enregistrer le fichier de présentation en utilisant l'objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
```javascript
// Instancier la classe Presentation qui représente le fichier de présentation
var pres = new aspose.slides.Presentation();
try {
    // Instancier la classe SlideCollection
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Ajouter une diapositive vide à la collection Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Effectuer des opérations sur la diapositive nouvellement ajoutée
    // Enregistrer le fichier PPTX sur le disque
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **FAQ**

**Puis-je insérer une nouvelle diapositive à une position spécifique, et pas seulement à la fin ?**

Oui. La bibliothèque prend en charge les collections de diapositives et les opérations [insert](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/insertclone/) vous permettant d'ajouter une diapositive à l'index requis plutôt qu'à la fin uniquement.

**Les thèmes/styles sont-ils conservés lors de l'ajout d'une diapositive basée sur une disposition ?**

Oui. Une disposition hérite du formatage de son maître, et la nouvelle diapositive hérite de la disposition sélectionnée et de son maître associé.

**Quelle diapositive est présente dans une nouvelle présentation « vide » avant d'ajouter des diapositives ?**

Une présentation nouvellement créée contient déjà une diapositive vierge avec l'index zéro. Cela est important à prendre en compte lors du calcul des indices d'insertion.

**Comment choisir la disposition « appropriée » pour une nouvelle diapositive si le maître propose de nombreuses options ?**

En général, choisissez le [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) qui correspond à la structure requise ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidelayouttype/)). Si une telle disposition est absente, vous pouvez [add it to the master](/slides/fr/nodejs-java/slide-layout/) puis l'utiliser.