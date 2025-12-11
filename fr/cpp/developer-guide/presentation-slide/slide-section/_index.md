---
title: "Gérer les sections de diapositives dans les présentations avec C++"
linktitle: "Section de diapositive"
type: docs
weight: 100
url: /fr/cpp/slide-section/
keywords:
  - "créer une section"
  - "ajouter une section"
  - "modifier une section"
  - "changer la section"
  - "nom de la section"
  - "PowerPoint"
  - "OpenDocument"
  - "présentation"
  - "C++"
  - "Aspose.Slides"
description: "Simplifiez la gestion des sections de diapositives dans PowerPoint et OpenDocument avec Aspose.Slides pour C++ — divisez, renommez et réorganisez pour optimiser les flux de travail PPTX et ODP."
---

Avec Aspose.Slides for C++, vous pouvez organiser une présentation PowerPoint en sections. Vous pouvez créer des sections qui contiennent des diapositives spécifiques. 

Vous pouvez souhaiter créer des sections et les utiliser pour organiser ou diviser les diapositives d’une présentation en parties logiques dans les situations suivantes :

- Lorsque vous travaillez sur une grande présentation avec d’autres personnes ou une équipe — et que vous devez attribuer certaines diapositives à un collègue ou à des membres de l’équipe. 
- Lorsque vous avez une présentation contenant de nombreuses diapositives — et que vous avez du mal à gérer ou à modifier son contenu en une seule fois.

Idéalement, vous devez créer une section qui regroupe des diapositives similaires — les diapositives ont un point commun ou peuvent exister dans un groupe selon une règle — et donner à la section un nom qui décrit les diapositives qu’elle contient. 

## **Créer des sections dans les présentations**

Pour ajouter une section qui contiendra des diapositives dans une présentation, Aspose.Slides for C++ fournit la méthode AddSection qui vous permet de spécifier le nom de la section à créer et la diapositive à partir de laquelle la section débute. 

Ce code d’exemple montre comment créer une section dans une présentation en C++ :
``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 sera terminée à newSlide2 et après cela section2 commencera   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```


## **Modifier le nom des sections**

Après avoir créé une section dans une présentation PowerPoint, vous pouvez décider de changer son nom. 

Ce code d’exemple montre comment modifier le nom d’une section dans une présentation en C++ en utilisant Aspose.Slides :
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```


## **FAQ**

**Les sections sont‑elles conservées lors de l’enregistrement au format PPT (PowerPoint 97–2003) ?**

Non. Le format PPT ne prend pas en charge les métadonnées de sections, de sorte que le groupement des sections est perdu lors de l’enregistrement en .ppt.

**Une section entière peut‑elle être « masquée » ?**

Non. Seules les diapositives individuelles peuvent être masquées. Une section en tant qu’entité n’a pas d’état « masqué ».

**Puis‑je retrouver rapidement une section à partir d’une diapositive et, inversement, la première diapositive d’une section ?**

Oui. Une section est définie de façon unique par sa diapositive de départ ; à partir d’une diapositive, vous pouvez déterminer à quelle section elle appartient, et pour une section vous pouvez accéder à sa première diapositive.