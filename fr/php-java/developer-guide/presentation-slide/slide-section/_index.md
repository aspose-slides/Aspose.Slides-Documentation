---
title: Gérer les sections de diapositives dans les présentations avec PHP
linktitle: Section de diapositive
type: docs
weight: 90
url: /fr/php-java/slide-section/
keywords:
- créer une section
- ajouter une section
- modifier une section
- changer une section
- nom de la section
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Simplifiez la gestion des sections de diapositives dans PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java — divisez, renommez et réorganisez pour optimiser les flux de travail PPTX et ODP."
---

Avec Aspose.Slides pour PHP via Java, vous pouvez organiser une présentation PowerPoint en sections. Vous pouvez créer des sections qui contiennent des diapositives spécifiques.

Vous pouvez souhaiter créer des sections et les utiliser pour organiser ou diviser les diapositives d’une présentation en parties logiques dans les situations suivantes :
- Lorsque vous travaillez sur une grande présentation avec d’autres personnes ou une équipe — et que vous devez attribuer certaines diapositives à un collègue ou à des membres de l’équipe.
- Lorsque vous avez une présentation contenant de nombreuses diapositives — et que vous avez du mal à gérer ou à modifier son contenu en une fois.

Idéalement, vous devez créer une section qui regroupe des diapositives similaires — les diapositives ont quelque chose en commun ou peuvent exister dans un groupe basé sur une règle — et donner à la section un nom qui décrit les diapositives qu’elle contient. 

## **Créer des sections dans les présentations**

Pour ajouter une section qui regroupera des diapositives dans une présentation, Aspose.Slides pour PHP via Java fournit la méthode [addSection()](https://reference.aspose.com/slides/php-java/aspose.slides/sectioncollection/#addSection) qui vous permet de spécifier le nom de la section que vous souhaitez créer ainsi que la diapositive à partir de laquelle la section débute.

Ce code d’exemple vous montre comment créer une section dans une présentation :
```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3); // section1 se terminera à newSlide2 et après cela, section2 commencera

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Modifier les noms des sections**

Après avoir créé une section dans une présentation PowerPoint, vous pouvez décider de modifier son nom. 

Ce code d’exemple vous montre comment changer le nom d’une section dans une présentation à l’aide d’Aspose.Slides :
```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Les sections sont‑elles conservées lors de l’enregistrement au format PPT (PowerPoint 97–2003) ?**

Non. Le format PPT ne prend pas en charge les métadonnées de sections, ainsi le regroupement des sections est perdu lors de l’enregistrement au format .ppt.

**Une section entière peut‑elle être « masquée » ?**

Non. Seules les diapositives individuelles peuvent être masquées. Une section en tant qu’entité n’a aucun état « masqué ».

**Puis‑je rapidement trouver une section à partir d’une diapositive et, inversement, la première diapositive d’une section ?**

Oui. Une section est définie de façon unique par sa diapositive de départ ; à partir d’une diapositive, vous pouvez déterminer à quelle section elle appartient, et pour une section vous pouvez accéder à sa première diapositive.