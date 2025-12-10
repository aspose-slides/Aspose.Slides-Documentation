---
title: Accéder aux diapositives de présentation en Java
linktitle: Accéder à la diapositive
type: docs
weight: 20
url: /fr/java/access-slide-in-presentation/
keywords:
- accès diapositive
- indice diapositive
- id diapositive
- position diapositive
- modifier position
- propriétés diapositive
- numéro diapositive
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Apprenez comment accéder et gérer les diapositives dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Java. Augmentez votre productivité grâce à des exemples de code."
---

Aspose.Slides vous permet d'accéder aux diapositives de deux manières : par index et par ID.

## **Accéder à une diapositive par index**

Toutes les diapositives d'une présentation sont organisées numériquement en fonction de la position de la diapositive, en commençant à 0. La première diapositive est accessible via l'index 0 ; la deuxième diapositive est accessible via l'index 1 ; etc.

La classe Presentation, qui représente un fichier de présentation, expose toutes les diapositives sous forme d'une collection [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) (collection d'objets [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/)). Ce code Java vous montre comment accéder à une diapositive par son index :
```java
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("demo.pptx");
try {
    // Accède à une diapositive en utilisant son indice de diapositive
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```


## **Accéder à une diapositive par ID**

Chaque diapositive d'une présentation possède un ID unique qui lui est associé. Vous pouvez utiliser la méthode [getSlideById](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlideById-long-) (exposée par la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)) pour cibler cet ID. Ce code Java vous montre comment fournir un ID de diapositive valide et accéder à cette diapositive via la méthode [getSlideById](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlideById-long-) :
```java
// Crée une instance d'un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("demo.pptx");
try {
    // Obtient l'ID d'une diapositive
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Accède à la diapositive via son ID
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```


## **Modifier la position d'une diapositive**

Aspose.Slides vous permet de modifier la position d'une diapositive. Par exemple, vous pouvez spécifier que la première diapositive devienne la deuxième.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenir la référence de la diapositive (dont vous souhaitez modifier la position) via son index
1. Définir une nouvelle position pour la diapositive via la propriété [setSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#setSlideNumber-int-).
1. Enregistrer la présentation modifiée.

Ce code Java montre une opération où la diapositive en position 1 est déplacée vers la position 2 :
```java
// Crée une instance d'un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Obtient la diapositive dont la position sera modifiée
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Définit la nouvelle position pour la diapositive
    sld.setSlideNumber(2);
    
    // Enregistre la présentation modifiée
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


La première diapositive est devenue la deuxième ; la deuxième diapositive est devenue la première. Lorsque vous modifiez la position d’une diapositive, les autres diapositives sont automatiquement ajustées.

## **Définir le numéro de diapositive**

En utilisant la propriété [setFirstSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (exposée par la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)), vous pouvez spécifier un nouveau numéro pour la première diapositive d'une présentation. Cette opération entraîne le recalcul des numéros des autres diapositives.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenir le numéro de la diapositive.
1. Définir le numéro de la diapositive.
1. Enregistrer la présentation modifiée.

Ce code Java montre une opération où le numéro de la première diapositive est fixé à 10 :
```java
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Obtient le numéro de la diapositive
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Définit le numéro de la diapositive
    pres.setFirstSlideNumber(10);
	
    // Enregistre la présentation modifiée
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Si vous préférez sauter la première diapositive, vous pouvez démarrer la numérotation à partir de la deuxième diapositive (et masquer la numérotation de la première diapositive) de cette manière :
```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Définit le numéro de la première diapositive de la présentation
    presentation.setFirstSlideNumber(0);

    // Affiche les numéros de diapositive pour toutes les diapositives
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Masque le numéro de diapositive de la première diapositive
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Enregistre la présentation modifiée
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**Le numéro de diapositive vu par l'utilisateur correspond-il à l'index de la collection basé sur zéro ?**

Le numéro affiché sur une diapositive peut commencer à une valeur arbitraire (par exemple, 10) et n’a pas besoin de correspondre à l’index ; la relation est contrôlée par le paramètre [first slide number](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) de la présentation.

**Les diapositives masquées affectent-elles l’indexation ?**

Oui. Une diapositive masquée reste dans la collection et est comptée dans l’indexation ; « masquée » fait référence à l’affichage, pas à sa position dans la collection.

**L’index d’une diapositive change-t-il lorsque d’autres diapositives sont ajoutées ou supprimées ?**

Oui. Les index reflètent toujours l’ordre actuel des diapositives et sont recalculés lors des opérations d’insertion, de suppression et de déplacement.