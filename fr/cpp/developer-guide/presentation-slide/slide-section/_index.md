---
title: Section de diapositive
type: docs
weight: 100
url: /fr/cpp/slide-section/
---

Avec Aspose.Slides pour C++, vous pouvez organiser une présentation PowerPoint en sections. Vous pouvez créer des sections qui contiennent des diapos spécifiques.

Vous pouvez souhaiter créer des sections et les utiliser pour organiser ou diviser les diapositives d'une présentation en parties logiques dans ces situations :

- Lorsque vous travaillez sur une grande présentation avec d'autres personnes ou une équipe—et que vous devez attribuer certaines diapositives à un collègue ou à certains membres de l'équipe.
- Lorsque vous gérez une présentation qui contient de nombreuses diapositives—et que vous avez du mal à gérer ou à modifier son contenu à la fois.

Idéalement, vous devriez créer une section contenant des diapositives similaires—les diapositives ont quelque chose en commun ou peuvent exister dans un groupe basé sur une règle—et donner à la section un nom qui décrit les diapositives à l'intérieur.

## Création de sections dans les présentations

Pour ajouter une section qui contiendra des diapositives dans une présentation, Aspose.Slides pour C++ fournit la méthode AddSection qui vous permet de spécifier le nom de la section que vous prévoyez de créer et la diapositive à partir de laquelle la section commence.

Ce code d'exemple montre comment créer une section dans une présentation en C++ :

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 se terminera à newSlide2 et après cela, section2 commencera   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Dernière section vide");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## Changement des noms de sections

Après avoir créé une section dans une présentation PowerPoint, vous pouvez décider de changer son nom.

Ce code d'exemple vous montre comment changer le nom d'une section dans une présentation en C++ utilisant Aspose.Slides :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"Ma section");
```