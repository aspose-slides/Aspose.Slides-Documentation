---
title: Ajouter une diapositive à la présentation
type: docs
weight: 10
url: /java/add-slide-to-presentation/
---

## **Ajouter une diapositive à la présentation**
{{% alert color="primary" %}} 

Avant de parler de l'ajout de diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive **Maître / Mise en page** et d'autres diapositives **Normales**. Cela signifie qu'un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas supportés par Aspose.Slides pour Java. Chaque diapositive a un identifiant unique et toutes les diapositives normales sont arrangées selon un ordre spécifié par l'index basé sur zéro.

{{% /alert %}} 

Aspose.Slides pour Java permet aux développeurs d'ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide à la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) en faisant référence à la propriété [Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) (collection d'objets de diapositives de contenu) exposée par l'objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Ajoutez une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant la méthode [**addEmptySlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection).
- Faites quelque chose avec la nouvelle diapositive vide ajoutée.
- Enfin, écrivez le fichier de présentation en utilisant l'objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).

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
    // Faire quelque chose sur la nouvelle diapositive ajoutée

    // Enregistrer le fichier PPTX sur le disque
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```