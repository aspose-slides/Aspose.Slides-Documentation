---
title: Gérer les sections de diapositive dans les présentations avec JavaScript
linktitle: Section de diapositive
type: docs
weight: 90
url: /fr/nodejs-java/slide-section/
keywords:
- créer une section
- ajouter une section
- modifier une section
- changer une section
- nom de section
- récupérer les diapositives de section
- traiter les diapositives de section
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Gérez les sections de diapositives avec Aspose.Slides pour Node.js via Java : créez, renommez, réorganisez, récupérez et traitez les diapositives de section dans les présentations PPTX."
---
## **Introduction**

Les sections organisent des diapositives consécutives en groupes nommés sans modifier le contenu des diapositives. Avec Aspose.Slides pour Node.js via Java, vous pouvez créer, réorganiser, renommer, inspecter et supprimer des sections via la méthode [Presentation.getSections](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getSections).

Les sections sont particulièrement utiles lorsque :

- une présentation volumineuse doit être divisée en sujets ou chapitres logiques ;
- différents groupes de diapositives sont attribués à différents collaborateurs ;
- les diapositives doivent être traitées, déplacées ou fusionnées en groupes.

Choisissez des noms de section concis qui décrivent le but des diapositives groupées. Comme les sections font partie de la structure de la présentation, utilisez les API de section pour déterminer l'appartenance plutôt que de la déduire des positions des diapositives.

## **Create and Manage Sections**

Utilisez [SectionCollection.addSection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sectioncollection/#addSection) pour créer une section en spécifiant son nom et la diapositive de départ. Aspose.Slides détermine quelles diapositives appartiennent à la section à partir de la structure de sections actuelle de la présentation.

La même [SectionCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sectioncollection/) vous permet également de :

- déplacer une section avec ses diapositives en utilisant [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) ;
- supprimer uniquement la définition de la section avec [SectionCollection.removeSection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sectioncollection/#removeSection), ce qui conserve ses diapositives ;
- supprimer une section et ses diapositives avec [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides) ;
- ajouter une section vide à la fin avec [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection) .

L’exemple suivant crée deux sections, déplace l’une d’elles, la supprime avec ses diapositives et ajoute une section vide :

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Après ces opérations, la présentation contient la section `Introduction` avec ses diapositives et une section vide `Appendix`. La section `Results` et ses diapositives ont été supprimées.

## **Rename Sections**

Pour renommer une section, appelez sa méthode [Section.setName](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/section/#setName). Les diapositives et la position de la section restent inchangées.

L’exemple suivant crée une section et modifie son nom :

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Retrieve Slides from Sections**

La méthode [Presentation.getSections](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getSections) renvoie une [SectionCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sectioncollection/) à laquelle vous pouvez accéder par indice. Pour chaque [Section](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/section/), appelez [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/section/#getSlidesListOfSection) afin d’obtenir les diapositives qui lui appartiennent actuellement. La méthode renvoie une [SectionSlideCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sectionslidecollection/), qui fournit un compte et un accès indexé.

L’exemple suivant crée deux sections remplies et une section vide, puis affiche le [name](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/section/#getName), l’[identifier](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/section/#getSectionId), la [starting slide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/section/#getStartedFromSlide), le nombre de diapositives et les numéros de diapositives de chaque section. Il utilise [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) pour lire à la fois la première diapositive et chaque diapositive de la collection. Pour la section vide, la collection renvoyée a une taille de zéro, l’accès indexé est ignoré et la boucle ne réalise aucune opération.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

L’appartenance à une section est déterminée par la structure de sections de la présentation. Ne calculez pas manuellement la plage d’une section à partir de [Section.getStartedFromSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/section/#getStartedFromSlide), des index de diapositives et de la diapositive de départ de la section suivante.

Les modifications structurelles peuvent modifier à la fois les diapositives renvoyées pour une section et leurs numéros de diapositives. Cela inclut le réordonnancement des diapositives, le clonage d’une diapositive dans une section, le déplacement d’une section avec ses diapositives, la suppression de diapositives et la suppression de sections. L’exemple suivant appelle [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/section/#getSlidesListOfSection) après chaque changement au lieu de conserver des hypothèses sur les anciennes limites de la section.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Appelez à nouveau [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/section/#getSlidesListOfSection) chaque fois que des diapositives ou des sections sont réordonnées, clonées, déplacées ou supprimées. Cela maintient le traitement ultérieur aligné sur la structure actuelle de la présentation.

Le format PPT (PowerPoint 97–2003) ne conserve pas les métadonnées de section. Utilisez ce flux de travail avec un format qui prend en charge les sections, tel que PPTX ; la conversion vers PPT supprime la structure de sections nécessaire aux itérations ultérieures.

## **FAQ**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**  
Non. Le format PPT ne prend pas en charge les métadonnées de section, ainsi le regroupement par sections est perdu lors de l’enregistrement au format .ppt.

**Can an entire section be "hidden"?**  
Non. Une section n’a aucun état de visibilité. Pour masquer son contenu, appelez [Slide.setHidden](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#setHidden) pour chaque diapositive de la section.

**How can I find the section that contains a slide?**  
Accédez à chaque section de la collection renvoyée par [Presentation.getSections](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getSections), appelez [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/section/#getSlidesListOfSection) pour chaque section, et comparez les diapositives retournées avec la diapositive cible. Pour une section non vide, [Section.getStartedFromSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/section/#getStartedFromSlide) renvoie sa première diapositive ; pour une section vide, elle renvoie `null`.