---
title: Gérer les sections de diapositives dans les présentations sur Android
linktitle: Section de diapositive
type: docs
weight: 90
url: /fr/androidjava/slide-section/
keywords:
- créer une section
- ajouter une section
- modifier une section
- changer de section
- nom de la section
- récupérer les diapositives de section
- traiter les diapositives de section
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Gérez les sections de diapositives avec Aspose.Slides pour Android via Java : créez, renommez, réorganisez, récupérez et traitez les diapositives de section dans les présentations PPTX."
---
## **Introduction**

Les sections organisent les diapositives consécutives en groupes nommés sans modifier le contenu des diapositives. Avec Aspose.Slides pour Android via Java, vous pouvez créer, réorganiser, renommer, inspecter et supprimer des sections via la méthode [Presentation.getSections](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getSections--).

Les sections sont particulièrement utiles lorsque :

- une grande présentation doit être divisée en sujets ou chapitres logiques ;
- différents groupes de diapositives sont assignés à différents collaborateurs ;
- les diapositives doivent être traitées, déplacées ou fusionnées en groupes.

Choisissez des noms de section concis qui décrivent le but des diapositives regroupées. Étant donné que les sections font partie de la structure de la présentation, utilisez les API de section pour déterminer l’appartenance plutôt que de la déduire des positions des diapositives.

## **Créer et gérer les sections**

Utilisez [ISectionCollection.addSection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) pour créer une section en spécifiant son nom et la diapositive de départ. Aspose.Slides détermine quelles diapositives appartiennent à la section à partir de la structure de sections actuelle de la présentation.

La même [ISectionCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isectioncollection/) vous permet également de :

- déplacer une section avec ses diapositives en utilisant [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- supprimer uniquement la définition de la section avec [ISectionCollection.removeSection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), ce qui conserve ses diapositives ;
- supprimer une section et ses diapositives avec [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-) ;
- ajouter une section vide à la fin avec [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

L'exemple suivant crée deux sections, déplace l'une d'elles, la supprime avec ses diapositives, puis ajoute une section vide :

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Après ces opérations, la présentation contient la section `Introduction` avec ses diapositives et une section vide `Appendix`. La section `Results` et ses diapositives ont été supprimées.

## **Renommer les sections**

Pour renommer une section, appelez sa méthode [ISection.setName](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isection/#setName-java.lang.String-). Les diapositives et la position de la section restent inchangées.

L'exemple suivant crée une section et modifie son nom :

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Récupérer les diapositives à partir des sections**

La méthode [Presentation.getSections](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getSections--) renvoie une [ISectionCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isectioncollection/) que vous pouvez parcourir. Pour chaque [ISection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isection/), appelez [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) afin d'obtenir les diapositives qui lui appartiennent actuellement. La méthode renvoie une [ISectionSlideCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isectionslidecollection/), qui fournit un compteur, un accès indexé et une itération.

L'exemple suivant crée deux sections remplies et une section vide, puis affiche le [nom](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isection/#getName--) , l'[identifiant](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isection/#getSectionId--) , la [diapositive de départ](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) , le nombre de diapositives et les numéros de diapositives de chaque section. Il utilise [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) pour lire la première diapositive et une instruction `for` améliorée pour traiter chaque diapositive. Pour la section vide, la collection renvoyée a une taille de zéro, la méthode n'est pas appelée et l'itération n'effectue aucune opération.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

L'appartenance à une section est déterminée par la structure des sections de la présentation. Ne calculez pas manuellement la plage d'une section à partir de [ISection.getStartedFromSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), des index de diapositives et de la diapositive de départ de la section suivante.

Les modifications structurelles peuvent modifier à la fois les diapositives renvoyées pour une section et leurs numéros. Cela inclut le réordonnancement des diapositives, le clonage d'une diapositive dans une section, le déplacement d'une section avec ses diapositives, la suppression de diapositives et la suppression de sections. L'exemple suivant appelle [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) après chaque modification de ce type au lieu de maintenir des hypothèses sur les anciennes limites de la section.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Appelez à nouveau [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) chaque fois que des diapositives ou des sections sont réordonnées, clonées, déplacées ou supprimées. Cela maintient le traitement ultérieur aligné sur la structure actuelle de la présentation.

Le format PPT (PowerPoint 97–2003) ne préserve pas les métadonnées de section. Utilisez ce flux de travail avec un format qui prend en charge les sections, comme le PPTX ; la conversion en PPT supprime la structure de sections nécessaire pour les itérations ultérieures.

## **FAQ**

**Les sections sont-elles conservées lors de l'enregistrement au format PPT (PowerPoint 97–2003) ?**

Non. Le format PPT ne prend pas en charge les métadonnées de section, ainsi le regroupement en sections est perdu lors de l'enregistrement au format .ppt.

**Une section entière peut-elle être « cachée » ?**

Non. Une section n’a aucun état de visibilité. Pour masquer son contenu, appelez [ISlide.setHidden](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islide/#setHidden-boolean-) pour chaque diapositive de la section.

**Comment puis‑je trouver la section qui contient une diapositive ?**

Parcourez la collection renvoyée par [Presentation.getSections](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getSections--), appelez [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) pour chaque section, et comparez les diapositives renvoyées avec la diapositive cible. Pour une section non vide, [ISection.getStartedFromSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) renvoie sa première diapositive ; pour une section vide, elle renvoie `null`.