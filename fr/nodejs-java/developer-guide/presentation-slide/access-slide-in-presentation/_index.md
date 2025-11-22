---
title: Accéder à la diapositive dans la présentation
type: docs
weight: 20
url: /fr/nodejs-java/access-slide-in-presentation/
keywords: "Accéder à une présentation PowerPoint, accéder à la diapositive, modifier les propriétés de la diapositive, changer la position de la diapositive, définir le numéro de diapositive, index, ID, position Java, Aspose.Slides"
description: "Accéder à la diapositive PowerPoint par index, ID ou position en JavaScript. Modifier les propriétés de la diapositive"
---

Aspose.Slides vous permet d'accéder aux diapositives de deux manières : par index et par ID.

## **Accéder à une diapositive par index**

Toutes les diapositives d'une présentation sont organisées numériquement en fonction de la position de la diapositive, à partir de 0. La première diapositive est accessible via l'index 0 ; la deuxième diapositive via l'index 1 ; etc.

La classe Presentation, qui représente un fichier de présentation, expose toutes les diapositives sous forme d'une collection [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) (collection d'objets [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/)). Ce code JavaScript montre comment accéder à une diapositive par son index :
```javascript
// Instancie un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Accède à une diapositive en utilisant son indice
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```


## **Accéder à une diapositive par ID**

Chaque diapositive d'une présentation possède un ID unique qui lui est associé. Vous pouvez utiliser la méthode [getSlideById](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlideById-long-) (exposée par la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)) pour cibler cet ID. Ce code JavaScript montre comment fournir un ID de diapositive valide et accéder à cette diapositive via la méthode [getSlideById](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlideById-long-) :
```javascript
// Instancie un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Obtient l'ID d'une diapositive
    var id = pres.getSlides().get_Item(0).getSlideId();
    // Accède à la diapositive via son ID
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```


## **Modifier la position d'une diapositive**

Aspose.Slides permet de changer la position d'une diapositive. Par exemple, vous pouvez spécifier que la première diapositive devienne la deuxième.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Récupérez la référence de la diapositive (celle dont vous voulez changer la position) via son index.
1. Définissez une nouvelle position pour la diapositive via la propriété [setSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#setSlideNumber-int-).
1. Enregistrez la présentation modifiée.

Ce code JavaScript illustre une opération où la diapositive à la position 1 est déplacée vers la position 2 :
```javascript
// Instancie un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Obtient la diapositive dont la position sera modifiée
    var sld = pres.getSlides().get_Item(0);
    // Définit la nouvelle position de la diapositive
    sld.setSlideNumber(2);
    // Enregistre la présentation modifiée
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


La première diapositive est devenue la deuxième ; la deuxième diapositive est devenue la première. Lorsque vous modifiez la position d’une diapositive, les autres diapositives sont automatiquement ajustées.

## **Définir le numéro de diapositive**

En utilisant la propriété [setFirstSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (exposée par la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)), vous pouvez spécifier un nouveau numéro pour la première diapositive d’une présentation. Cette opération entraîne le recalcul des numéros des autres diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Récupérez le numéro de la diapositive.
1. Définissez le numéro de la diapositive.
1. Enregistrez la présentation modifiée.

Ce code JavaScript montre une opération où le numéro de la première diapositive est fixé à 10 :
```javascript
// Instancie un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // Obtient le numéro de la diapositive
    var firstSlideNumber = pres.getFirstSlideNumber();
    // Définit le numéro de la diapositive
    pres.setFirstSlideNumber(10);
    // Enregistre la présentation modifiée
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Si vous souhaitez ignorer la première diapositive, vous pouvez commencer la numérotation à partir de la deuxième diapositive (et masquer la numérotation pour la première) de cette manière :
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // Définit le numéro pour la première diapositive de la présentation
    // Affiche les numéros de diapositive pour toutes les diapositives
    // Masque le numéro de diapositive pour la première diapositive
    // Enregistre la présentation modifiée
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**Le numéro de diapositive affiché à l'utilisateur correspond-il à l'index de la collection basé sur zéro ?**

Le numéro affiché sur une diapositive peut commencer à une valeur arbitraire (par ex. 10) et ne doit pas forcément correspondre à l'index ; la relation est contrôlée par le paramètre [first slide number](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) de la présentation.

**Les diapositives masquées affectent-elles l'indexation ?**

Oui. Une diapositive masquée reste dans la collection et est comptée dans l'indexation ; « masqué » se réfère à l'affichage, pas à sa position dans la collection.

**L'index d’une diapositive change-t-il lorsque d’autres diapositives sont ajoutées ou supprimées ?**

Oui. Les index reflètent toujours l’ordre actuel des diapositives et sont recalculés lors des opérations d’insertion, de suppression et de déplacement.