---
title: Supprimer une diapositive d'une présentation
type: docs
weight: 30
url: /fr/nodejs-java/remove-slide-from-presentation/
keywords: "Supprimer diapositive, Supprimer diapositive, PowerPoint, Présentation, Java, Aspose.Slides"
description: "Supprimer une diapositive PowerPoint par référence ou indice en JavaScript"
---

Si une diapositive (ou son contenu) devient redondante, vous pouvez la supprimer. Aspose.Slides fournit la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) qui englobe [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/), un référentiel de toutes les diapositives d’une présentation. En utilisant des pointeurs (référence ou indice) pour un objet [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/), vous pouvez spécifier la diapositive que vous souhaitez retirer.

## **Supprimer une diapositive par référence**

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence de la diapositive que vous souhaitez supprimer via son ID ou son indice.
1. Supprimer la diapositive référencée de la présentation.
1. Enregistrer la présentation modifiée. 

Ce code JavaScript montre comment supprimer une diapositive via sa référence :
```javascript
// Instancie un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Accède à une diapositive via son indice dans la collection de diapositives
    var slide = pres.getSlides().get_Item(0);
    // Supprime une diapositive via sa référence
    pres.getSlides().remove(slide);
    // Enregistre la présentation modifiée
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Supprimer une diapositive par indice**

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Supprimer la diapositive de la présentation via sa position d’indice.
1. Enregistrer la présentation modifiée. 

Ce code JavaScript montre comment supprimer une diapositive via son indice :
```javascript
// Instancie un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Supprime une diapositive via son indice de diapositive
    pres.getSlides().removeAt(0);
    // Enregistre la présentation modifiée
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Supprimer les diapositives de mise en page inutilisées**

Aspose.Slides fournit la méthode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides-aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)) qui vous permet de supprimer les mises en page indésirables et inutilisées. Ce code JavaScript montre comment supprimer une mise en page d’une présentation PowerPoint :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Supprimer les diapositives maîtres inutilisées**

Aspose.Slides fournit la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)) qui vous permet de supprimer les maîtres indésirables et inutilisés. Ce code JavaScript montre comment supprimer un maître d’une présentation PowerPoint :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Que se passe-t-il pour les indices de diapositives après la suppression d’une diapositive ?**

Après la suppression, la [collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) se réindexe : chaque diapositive suivante se décale d’une position vers la gauche, de sorte que les numéros d’index précédents deviennent obsolètes. Si vous avez besoin d’une référence stable, utilisez l’ID persistant de chaque diapositive plutôt que son indice.

**L’ID d’une diapositive est‑il différent de son indice, et change‑t‑il lorsque les diapositives voisines sont supprimées ?**

Oui. L’indice correspond à la position de la diapositive et varie lorsqu’on ajoute ou supprime des diapositives. L’ID de la diapositive est un identificateur persistant et ne change pas lorsque d’autres diapositives sont supprimées.

**Comment la suppression d’une diapositive affecte‑t‑elle les sections de diapositives ?**

Si la diapositive appartenait à une section, cette section contiendra simplement une diapositive de moins. La structure de la section reste intacte ; si une section devient vide, vous pouvez [supprimer ou réorganiser les sections](/slides/fr/nodejs-java/slide-section/) selon les besoins.

**Que se passe‑t‑il pour les notes et les commentaires attachés à une diapositive lorsqu’elle est supprimée ?**

[Notes](/slides/fr/nodejs-java/presentation-notes/) et [comments](/slides/fr/nodejs-java/presentation-comments/) sont liés à cette diapositive spécifique et sont supprimés avec elle. Le contenu des autres diapositives n’est pas affecté.

**En quoi la suppression de diapositives diffère‑t‑elle du nettoyage des mises en page/maîtres inutilisés ?**

La suppression retire des diapositives normales spécifiques du diaporama. Le nettoyage des mises en page/maîtres inutilisés supprime les diapositives de mise en page ou maîtres qui ne sont référencées par aucune diapositive, réduisant ainsi la taille du fichier sans modifier le contenu des diapositives restantes. Ces actions sont complémentaires : généralement, on supprime d’abord, puis on nettoie.