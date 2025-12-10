---
title: Gérer les sections de diapositives dans les présentations avec Java
linktitle: Section de diapositive
type: docs
weight: 90
url: /fr/java/slide-section/
keywords:
- créer une section
- ajouter une section
- modifier une section
- changer de section
- nom de section
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Simplifiez les sections de diapositives dans PowerPoint et OpenDocument avec Aspose.Slides for Java — fractionnez, renommez et réordonnez pour optimiser les flux de travail PPTX et ODP."
---

Avec Aspose.Slides for Java, vous pouvez organiser une presentation PowerPoint en sections. Vous pouvez creer des sections qui contiennent des diapositives specifiques.

Vous pouvez souhaiter creer des sections et les utiliser pour organiser ou diviser les diapositives d'une presentation en parties logiques dans les situations suivantes :
- Lorsque vous travaillez sur une grande presentation avec d'autres personnes ou une equipe - et que vous devez attribuer certaines diapositives a un collegue ou a plusieurs membres de l'equipe.
- Lorsque vous traitez une presentation contenant de nombreuses diapositives - et que vous avez du mal a en gerer ou a en modifier le contenu en une fois.

Ideally, vous devez creer une section qui regroupe des diapositives similaires - les diapositives ont quelque chose en commun ou peuvent etre regroupées selon une regle - et donner a la section un nom qui décrit les diapositives qu'elle contient.

## **Creer des sections dans les presentations**

Pour ajouter une section qui regroupera des diapositives dans une presentation, Aspose.Slides for Java fournit la methode [addSection()](https://reference.aspose.com/slides/java/com.aspose.slides.ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) qui vous permet de specifier le nom de la section que vous souhaitez creer ainsi que la diapositive a partir de laquelle la section debut.
Ce code d'exemple vous montre comment creer une section dans une presentation en Java :
```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 se terminera à newSlide2 et après cela, section2 commencera   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modifier les noms des sections**

Apres avoir cree une section dans une presentation PowerPoint, vous pouvez decider de modifier son nom.
Ce code d'exemple vous montre comment changer le nom d'une section dans une presentation en Java en utilisant Aspose.Slides :
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Les sections sont-elles conservees lors de l'enregistrement au format PPT (PowerPoint 97-2003) ?**
Non. Le format PPT ne prend pas en charge les metadonnees de section, de sorte que le regroupement des sections est perdu lors de l'enregistrement en .ppt.

**Une section entiere peut-elle etre "masquee" ?**
Non. Seules les diapositives individuelles peuvent etre masquees. Une section en tant qu'entite n'a aucun etat "masquee".

**Puis-je rapidement trouver une section a partir d'une diapositive et, inversement, la premiere diapositive d'une section ?**
Oui. Une section est definie de maniere unique par sa diapositive de depart; a partir d'une diapositive, vous pouvez determiner a quelle section elle appartient, et pour une section, vous pouvez acceder a sa premiere diapositive.