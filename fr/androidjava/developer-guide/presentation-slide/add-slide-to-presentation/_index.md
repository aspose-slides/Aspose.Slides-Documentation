---
title: Ajouter une diapositive à la présentation
type: docs
weight: 10
url: /fr/androidjava/add-slide-to-presentation/
---

## **Ajouter une diapositive à la présentation**
{{% alert color="primary" %}} 

Avant de parler de l'ajout de diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive **Maître / Mise en page** et d'autres diapositives **Normales**. Cela signifie qu'un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas supportés par Aspose.Slides pour Android via Java. Chaque diapositive a un Id unique et toutes les diapositives Normales sont disposées dans un ordre spécifié par l'indice basé sur zéro.

{{% /alert %}} 

Aspose.Slides pour Android via Java permet aux développeurs d'ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide à la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) en référant à la propriété [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) (collection d'objets Slide de contenu) exposée par l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Ajoutez une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant les méthodes [**addEmptySlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) exposées par l'objet [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection).
- Effectuez quelques travaux avec la nouvelle diapositive vide ajoutée.
- Enfin, écrivez le fichier de présentation en utilisant l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).

```java
// Instancier la classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation();
try {
    // Instancier la classe SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Ajouter une diapositive vide à la collection de diapositives
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Effectuer quelques travaux sur la diapositive nouvellement ajoutée

    // Sauvegarder le fichier PPTX sur le disque
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```