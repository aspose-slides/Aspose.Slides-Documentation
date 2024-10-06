---
title: Supprimer une diapositive de la présentation
type: docs
weight: 30
url: /java/remove-slide-from-presentation/
keywords: "Supprimer diapositive, Effacer diapositive, PowerPoint, Présentation, Java, Aspose.Slides"
description: "Supprimer une diapositive de PowerPoint par référence ou par index en Java"

---

Si une diapositive (ou son contenu) devient redondante, vous pouvez la supprimer. Aspose.Slides fournit la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) qui encapsule [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/), qui est un référentiel pour toutes les diapositives d'une présentation. En utilisant des pointeurs (référence ou index) pour un objet [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/), vous pouvez spécifier la diapositive que vous souhaitez supprimer.

## **Supprimer une diapositive par référence**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenez une référence de la diapositive que vous souhaitez supprimer par son ID ou son index.
1. Supprimez la diapositive référencée de la présentation.
1. Enregistrez la présentation modifiée.

Ce code Java vous montre comment supprimer une diapositive par sa référence :

```java
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("demo.pptx");
try {
    // Accède à une diapositive par son index dans la collection de diapositives
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Supprime une diapositive par sa référence
    pres.getSlides().remove(slide);
    
    // Enregistre la présentation modifiée
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Supprimer une diapositive par index**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Supprimez la diapositive de la présentation par sa position d'index.
1. Enregistrez la présentation modifiée.

Ce code Java vous montre comment supprimer une diapositive par son index :

```java
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("demo.pptx");
try {
    // Supprime une diapositive par son index
    pres.getSlides().removeAt(0);
    
    // Enregistre la présentation modifiée
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Supprimer une diapositive de mise en page inutilisée**

Aspose.Slides fournit la méthode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) pour vous permettre de supprimer des diapositives de mise en page non désirées et inutilisées. Ce code Java vous montre comment supprimer une diapositive de mise en page d'une présentation PowerPoint :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Supprimer une diapositive maître inutilisée**

Aspose.Slides fournit la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) pour vous permettre de supprimer des diapositives maîtres non désirées et inutilisées. Ce code Java vous montre comment supprimer une diapositive maître d'une présentation PowerPoint :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedMasterSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```