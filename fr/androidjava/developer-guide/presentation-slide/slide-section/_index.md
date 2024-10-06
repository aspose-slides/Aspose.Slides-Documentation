---
title: Section diapositive
type: docs
weight: 90
url: /androidjava/slide-section/
---

Avec Aspose.Slides pour Android via Java, vous pouvez organiser une présentation PowerPoint en sections. Vous pouvez créer des sections contenant des diapositives spécifiques.

Vous pouvez vouloir créer des sections et les utiliser pour organiser ou diviser les diapositives d'une présentation en parties logiques dans ces situations :

- Lorsque vous travaillez sur une grande présentation avec d'autres personnes ou une équipe—et que vous devez assigner certaines diapositives à un collègue ou à des membres de l'équipe.
- Lorsque vous traitez une présentation qui contient de nombreuses diapositives—et que vous avez des difficultés à gérer ou à éditer son contenu en une seule fois.

Idéalement, vous devriez créer une section qui regroupe des diapositives similaires—les diapositives ont quelque chose en commun ou peuvent exister dans un groupe basé sur une règle—et donner à la section un nom qui décrit les diapositives qu'elle contient.

## Création de Sections dans les Présentations

Pour ajouter une section qui accueillera des diapositives dans une présentation, Aspose.Slides pour Android via Java fournit la méthode [addSection()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) qui vous permet de spécifier le nom de la section que vous souhaitez créer et la diapositive à partir de laquelle la section commence.

Ce code exemple vous montre comment créer une section dans une présentation en Java :

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 se terminera à newSlide2 et après elle section2 commencera   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Dernière section vide");

    pres.save("pres-section-with-empty.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Changement des Noms de Sections

Après avoir créé une section dans une présentation PowerPoint, vous pouvez décider de changer son nom.

Ce code exemple vous montre comment changer le nom d'une section dans une présentation en Java en utilisant Aspose.Slides :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("Ma section");
} finally {
    if (pres != null) pres.dispose();
}
```