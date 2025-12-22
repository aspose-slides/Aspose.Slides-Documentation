---
title: Supprimer des diapositives des présentations sur Android
linktitle: Supprimer une diapositive
type: docs
weight: 30
url: /fr/androidjava/remove-slide-from-presentation/
keywords:
- supprimer diapositive
- effacer diapositive
- supprimer diapositive inutilisée
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Supprimez facilement des diapositives des présentations PowerPoint et OpenDocument avec Aspose.Slides pour Android. Obtenez des exemples de code Java clairs et améliorez votre flux de travail."
---

Si une diapositive (ou son contenu) devient redondante, vous pouvez la supprimer. Aspose.Slides fournit la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) qui encapsule [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/), qui est un référentiel de toutes les diapositives d’une présentation. En utilisant des pointeurs (référence ou index) pour un objet [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) connu, vous pouvez spécifier la diapositive que vous souhaitez retirer.

## **Supprimer une diapositive par référence**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtenez une référence de la diapositive que vous souhaitez supprimer via son ID ou son index.
1. Supprimez la diapositive référencée de la présentation.
1. Enregistrez la présentation modifiée. 

Ce code Java vous montre comment supprimer une diapositive via sa référence :
```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("demo.pptx");
try {
    // Accède à une diapositive via son index dans la collection de diapositives
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Supprime une diapositive via sa référence
    pres.getSlides().remove(slide);
    
    // Enregistre la présentation modifiée
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Supprimer une diapositive par index**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Supprimez la diapositive de la présentation à l’aide de sa position d’index.
1. Enregistrez la présentation modifiée. 

Ce code Java vous montre comment supprimer une diapositive via son index :
```java
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("demo.pptx");
try {
    // Supprime une diapositive via son index
    pres.getSlides().removeAt(0);
    
    // Enregistre la présentation modifiée
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Supprimer les diapositives de mise en page inutilisées**

Aspose.Slides fournit la méthode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) qui vous permet de supprimer les mises en page de diapositives indésirables et inutilisées. Ce code Java vous montre comment supprimer une diapositive de mise en page d’une présentation PowerPoint :
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Supprimer les diapositives maîtres inutilisées**

Aspose.Slides fournit la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) qui vous permet de supprimer les diapositives maîtres indésirables et inutilisées. Ce code Java vous montre comment supprimer une diapositive maître d’une présentation PowerPoint :
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```


## **FAQ**

**Que se passe-t-il aux index des diapositives après la suppression d’une diapositive ?**  
Après la suppression, la [collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) se réindexe : chaque diapositive suivante décale d’une position vers la gauche, de sorte que les numéros d’index précédents deviennent obsolètes. Si vous avez besoin d’une référence stable, utilisez l’ID persistant de chaque diapositive plutôt que son index.

**L’ID d’une diapositive diffère-t-il de son index, et change-t-il lorsque les diapositives voisines sont supprimées ?**  
Oui. L’index correspond à la position de la diapositive et évolue lorsque des diapositives sont ajoutées ou supprimées. L’ID de la diapositive est un identifiant persistant et ne change pas lorsque d’autres diapositives sont supprimées.

**Comment la suppression d’une diapositive affecte-t-elle les sections de diapositives ?**  
Si la diapositive faisait partie d’une section, cette section contiendra simplement une diapositive de moins. La structure des sections reste intacte ; si une section devient vide, vous pouvez [supprimer ou réorganiser les sections](/slides/fr/androidjava/slide-section/) selon les besoins.

**Que se passe-t-il aux notes et commentaires attachés à une diapositive lorsqu’elle est supprimée ?**  
[Notes](/slides/fr/androidjava/presentation-notes/) et [commentaires](/slides/fr/androidjava/presentation-comments/) sont liés à cette diapositive spécifique et sont supprimés avec elle. Le contenu des autres diapositives n’est pas affecté.

**En quoi la suppression de diapositives diffère-t-elle du nettoyage des mises en page/maîtres inutilisés ?**  
La suppression retire des diapositives normales spécifiques du diaporama. Le nettoyage des mises en page/maîtres inutilisés supprime les diapositives de mise en page ou maîtres qui ne sont référencées par aucune diapositive, réduisant la taille du fichier sans modifier le contenu des diapositives restantes. Ces actions sont complémentaires : généralement on supprime d’abord, puis on nettoie.