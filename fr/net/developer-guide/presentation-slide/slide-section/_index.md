---
title: Section de Diapositive
type: docs
weight: 100
url: /net/slide-section/
keywords: "Créer section, Ajouter section, Modifier le nom de section, Présentation PowerPoint, C#, Csharp, .NET, Aspose.Slides"
description: "Ajouter et modifier une section dans une présentation PowerPoint en C# ou .NET"
---

Avec Aspose.Slides pour .NET, vous pouvez organiser une présentation PowerPoint en sections. Vous pouvez créer des sections qui contiennent des diapositives spécifiques.

Vous voudrez peut-être créer des sections et les utiliser pour organiser ou diviser des diapositives dans une présentation en parties logiques dans ces situations :

- Lorsque vous travaillez sur une grande présentation avec d'autres personnes ou une équipe—et vous devez attribuer certaines diapositives à un collègue ou à d'autres membres de l'équipe.
- Lorsque vous traitez une présentation contenant de nombreuses diapositives—et que vous avez du mal à gérer ou à modifier son contenu en une seule fois.

Idéalement, vous devriez créer une section qui abrite des diapositives similaires—les diapositives ont quelque chose en commun ou peuvent exister dans un groupe basé sur une règle—et donner à la section un nom qui décrit les diapositives qu'elle contient.

## Création de Sections dans les Présentations

Pour ajouter une section qui abritera des diapositives dans une présentation, Aspose.Slides pour .NET fournit la méthode AddSection qui vous permet de spécifier le nom de la section que vous souhaitez créer et la diapositive à partir de laquelle la section commence.

Ce code d'exemple montre comment créer une section dans une présentation en C# :

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 sera terminée à newSlide2 et après elle section2 commencera   

    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Dernière section vide");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## Changer les Noms des Sections

Après avoir créé une section dans une présentation PowerPoint, vous pouvez décider de changer son nom.

Ce code d'exemple montre comment changer le nom d'une section dans une présentation en C# utilisant Aspose.Slides :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "Ma section";
}
```