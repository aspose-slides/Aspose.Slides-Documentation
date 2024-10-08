---
title: Mise en page de diapositive
type: docs
weight: 60
url: /fr/androidjava/slide-layout/
keyword: "Définir la taille des diapositives, définir les options de diapositive, spécifier la taille de la diapositive, visibilité du pied de page, pied de page enfant, mise à l'échelle du contenu, taille de page, Java, Aspose.Slides"
description: "Définir la taille et les options des diapositives PowerPoint en Java"
---

Une mise en page de diapositive contient les zones de texte réservées et les informations de formatage pour tout le contenu qui apparaît sur une diapositive. La mise en page détermine les zones de contenu disponibles et leur position.

Les mises en page de diapositives vous permettent de créer et de concevoir des présentations rapidement (qu'elles soient simples ou complexes). Voici quelques-unes des mises en page de diapositives les plus populaires utilisées dans les présentations PowerPoint :

* **Mise en page de diapositive de titre**. Cette mise en page se compose de deux zones de texte réservées. Une zone réservée est pour le titre et l'autre pour le sous-titre.
* **Mise en page de titre et contenu**. Cette mise en page contient une zone réservée relativement petite en haut pour le titre et une zone réservée plus grande pour le contenu principal (graphique, paragraphes, liste à puces, liste numérotée, images, etc.).
* **Mise en page vierge**. Cette mise en page ne contient pas de zones réservées, ce qui vous permet de créer des éléments à partir de zéro.

Étant donné qu'un maître de diapositive est la diapositive hiérarchique supérieure qui stocke des informations sur les mises en page de diapositives, vous pouvez utiliser la diapositive maître pour accéder aux mises en page de diapositives et y apporter des modifications. Une diapositive de mise en page peut être accédée par type ou par nom. De même, chaque diapositive a un identifiant unique, qui peut être utilisé pour y accéder.

Alternativement, vous pouvez apporter des modifications directement à une mise en page de diapositive spécifique dans une présentation.

* Pour vous permettre de travailler avec des mises en page de diapositives (y compris celles dans des diapositives maîtres), Aspose.Slides fournit des propriétés comme [getLayoutSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) et [getMasters()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) sous la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
* Pour effectuer des tâches similaires, Aspose.Slides fournit [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslideheaderfootermanager/), et de nombreux autres types.

{{% alert title="Info" color="info" %}}

Pour plus d'informations sur la gestion des diapositives maîtres en particulier, consultez l'article [Maître de diapositive](https://docs.aspose.com/slides/androidjava/slide-master/).

{{% /alert %}}

## **Ajouter une mise en page de diapositive à la présentation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Accédez à la [collection MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
1. Parcourez les diapositives de mise en page existantes pour confirmer que la diapositive de mise en page requise existe déjà dans la collection de diapositives de mise en page. Sinon, ajoutez la diapositive de mise en page que vous souhaitez.
1. Ajoutez une diapositive vide basée sur la nouvelle diapositive de mise en page.
1. Enregistrez la présentation.

Ce code Java vous montre comment ajouter une mise en page de diapositive à une présentation PowerPoint :

```java
// Instancie une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("AccessSlides.pptx");
try {
    // Parcourt les types de diapositives de mise en page
    IMasterLayoutSlideCollection layoutSlides = pres.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;

    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // La situation où une présentation ne contient pas certains types de mise en page.
        // Le fichier de présentation ne contient que des mises en page vierges et personnalisées.
        // Mais les diapositives de mise en page de types personnalisés ont des noms de diapositives différents,
        // comme "Titre", "Titre et contenu", etc. Et il est possible d'utiliser ces
        // noms pour la sélection de diapositives de mise en page.
        // Vous pouvez également utiliser un ensemble de types de formes de zones réservées. Par exemple,
        // La diapositive de titre doit avoir uniquement le type de zone réservée de titre, etc.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName() == "Titre et Objet") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }
        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName() == "Titre") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }
            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Titre et Objet");
                }
            }
        }
    }

    // Ajoute une diapositive vide avec la diapositive de mise en page ajoutée
    pres.getSlides().insertEmptySlide(0, layoutSlide);

    // Enregistre la présentation sur le disque
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Supprimer une diapositive de mise en page inutilisée**

Aspose.Slides fournit la méthode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) de la classe [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) pour vous permettre de supprimer des diapositives de mise en page indésirables et inutilisées. Ce code Java vous montre comment supprimer une diapositive de mise en page d'une présentation PowerPoint :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la taille et le type pour une mise en page de diapositive**

Pour vous permettre de définir la taille et le type d'une diapositive de mise en page spécifique, Aspose.Slides fournit les propriétés [getType()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getType--) et [getSize()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getSize--) (de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)). Ce Java démontre l'opération :

```java
// Instancie un objet Presentation qui représente le fichier de présentation
Presentation presentation = new Presentation("demo.pptx");
try {
    Presentation auxPresentation = new Presentation();
    try {
        // Définit la taille de la diapositive pour la présentation générée sur celle de la source
        auxPresentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit);
        //getType());
        auxPresentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);
        
        // Clone la diapositive requise
        auxPresentation.getSlides().addClone(presentation.getSlides().get_Item(0));
        auxPresentation.getSlides().removeAt(0);
        
        // Enregistre la présentation sur le disque
        auxPresentation.save("size.pptx", SaveFormat.Pptx);
    } finally {
        auxPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Définir la visibilité du pied de page à l'intérieur de la diapositive**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive par son index.
1. Réglez la zone réservée du pied de page de la diapositive sur visible. 
1. Réglez la zone réservée de date-heure sur visible. 
1. Enregistrez la présentation. 

Ce code Java vous montre comment définir la visibilité pour un pied de page de diapositive (et effectuer des tâches similaires) :

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.getSlides().get_Item(0).getHeaderFooterManager();
    if (!headerFooterManager.isFooterVisible()) // La méthode isFooterVisible est utilisée pour indiquer qu'une zone réservée de pied de page est manquante
    {
        headerFooterManager.setFooterVisibility(true); // La méthode setFooterVisibility est utilisée pour définir une zone réservée de pied de page de diapositive sur visible
    }
    if (!headerFooterManager.isSlideNumberVisible()) // La méthode isSlideNumberVisible est utilisée pour indiquer qu'une zone réservée du numéro de page de diapositive est manquante
    {
        headerFooterManager.setSlideNumberVisibility(true); // La méthode setSlideNumberVisibility est utilisée pour définir une zone réservée du numéro de page de diapositive sur visible
    }
    if (!headerFooterManager.isDateTimeVisible()) // La méthode isDateTimeVisible est utilisée pour indiquer qu'une zone réservée de date-heure de diapositive est manquante
    {
        headerFooterManager.setDateTimeVisibility(true); // La méthode SetFooterVisibility est utilisée pour définir une zone réservée de date-heure de diapositive sur visible
    }
    headerFooterManager.setFooterText("Texte du pied de page"); // La méthode SetFooterText est utilisée pour définir un texte pour une zone réservée de pied de page de diapositive.
    headerFooterManager.setDateTimeText("Texte de date et d'heure"); // La méthode SetDateTimeText est utilisée pour définir un texte pour une zone réservée de date-heure de diapositive.
} finally {
    presentation.dispose();
}
```

## **Définir la visibilité du pied de page enfant à l'intérieur de la diapositive**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtenez une référence pour la diapositive maître par son index. 
1. Réglez la diapositive maître et toutes les zones réservées de pied de page enfant sur visibles.
1. Définissez un texte pour la diapositive maîtresse et toutes les zones réservées de pied de page enfant. 
1. Définissez un texte pour la diapositive maîtresse et toutes les zones réservées de date-heure enfant. 
1. Enregistrez la présentation. 

Ce code Java démontre l'opération :

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true); // La méthode setFooterAndChildFootersVisibility est utilisée pour définir la diapositive maître et toutes les zones réservées de pied de page enfant comme visibles
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // La méthode setSlideNumberAndChildSlideNumbersVisibility est utilisée pour définir la diapositive maître et toutes les zones réservées de numéro de page enfant comme visibles
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // La méthode setDateTimeAndChildDateTimesVisibility est utilisée pour définir une diapositive maître et toutes les zones réservées de date-heure enfant comme visibles

    headerFooterManager.setFooterAndChildFootersText("Texte du pied de page"); // La méthode setFooterAndChildFootersText est utilisée pour définir des textes pour la diapositive maître et toutes les zones réservées de pied de page enfant
    headerFooterManager.setDateTimeAndChildDateTimesText("Texte de date et d'heure"); // La méthode setDateTimeAndChildDateTimesText est utilisée pour définir le texte pour la diapositive maître et toutes les zones réservées de date-heure enfant
} finally {
    presentation.dispose();
}
```

## **Définir la taille de la diapositive par rapport à la mise à l'échelle du contenu**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et chargez la présentation contenant la diapositive dont vous souhaitez définir la taille.
1. Créez une autre instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) pour générer une nouvelle présentation.
1. Obtenez la référence de la diapositive (de la première présentation) par son index.
1. Réglez la zone réservée du pied de page de diapositive sur visible. 
1. Réglez la zone réservée de date-heure sur visible. 
1. Enregistrez la présentation. 

Ce code Java démontre l'opération :

```java
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation presentation = new Presentation("demo.pptx");
try {
    // Définit la taille de la diapositive pour les présentations générées sur celle de la source
    presentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit); // La méthode SetSize est utilisée pour définir la taille de la diapositive avec une échelle de contenu pour assurer l'adéquation
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // La méthode SetSize est utilisée pour définir la taille de la diapositive avec une taille maximale du contenu

    // Enregistre la présentation sur le disque
    presentation.save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir la taille de page lors de la génération de PDF**

Certaines présentations (comme les affiches) sont souvent converties en documents PDF. Si vous souhaitez convertir votre PowerPoint en PDF pour accéder aux meilleures options d'impression et d'accessibilité, vous voulez définir vos diapositives à des tailles qui conviennent aux documents PDF (A4, par exemple).

Aspose.Slides fournit la classe [SlideSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/) pour vous permettre de spécifier vos paramètres préférés pour les diapositives. Ce code Java vous montre comment utiliser la propriété [getType()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getType--) (de la classe `SlideSize`) pour définir une taille de papier spécifique pour les diapositives dans une présentation :

```java
// Instancie un objet Presentation qui représente un fichier de présentation 
Presentation presentation = new Presentation();
try {
    // Définit la propriété SlideSize.Type  
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);
    
    // Définit différentes propriétés pour les options PDF
    PdfOptions opts = new  PdfOptions();
    opts.setSufficientResolution(600);
    
    // Enregistre la présentation sur le disque
    presentation.save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
} finally {
    presentation.dispose();
}
```