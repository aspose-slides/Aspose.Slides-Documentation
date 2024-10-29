---
title: Section de Diapositive
type: docs
weight: 90
url: /fr/php-java/slide-section/
---

Avec Aspose.Slides pour PHP via Java, vous pouvez organiser une présentation PowerPoint en sections. Vous pouvez créer des sections qui contiennent des diapos spécifiques.

Vous pouvez vouloir créer des sections et les utiliser pour organiser ou diviser les diapos dans une présentation en parties logiques dans ces situations :

- Lorsque vous travaillez sur une grande présentation avec d'autres personnes ou une équipe et que vous devez attribuer certaines diapos à un collègue ou à des membres de l'équipe.
- Lorsque vous traitez une présentation qui contient de nombreuses diapos et que vous avez du mal à gérer ou à modifier son contenu en même temps.

Idéalement, vous devriez créer une section qui regroupe des diapos similaires—les diapos ont quelque chose en commun ou peuvent exister en groupe basé sur une règle—et donner à la section un nom qui décrit les diapos qu'elle contient.

## Création de Sections dans les Présentations

Pour ajouter une section qui accueillera des diapos dans une présentation, Aspose.Slides pour PHP via Java fournit la méthode [addSection()](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) qui vous permet de spécifier le nom de la section que vous souhaitez créer et la diapo à partir de laquelle la section commence.

Ce code d'exemple vous montre comment créer une section dans une présentation :

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 se terminera à newSlide2 et après cela section2 commencera

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Dernière section vide");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Changement des Noms des Sections

Après avoir créé une section dans une présentation PowerPoint, vous pouvez décider de changer son nom.

Ce code d'exemple vous montre comment changer le nom d'une section dans une présentation en utilisant Aspose.Slides :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("Ma section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```