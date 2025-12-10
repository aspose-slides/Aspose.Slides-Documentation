---
title: Gérer les sections de diapositives dans les présentations en .NET
linktitle: Section de diapositive
type: docs
weight: 100
url: /fr/net/slide-section/
keywords:
- créer une section
- ajouter une section
- modifier une section
- changer la section
- nom de la section
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Simplifiez la gestion des sections de diapositives dans PowerPoint et OpenDocument avec Aspose.Slides pour .NET - divisez, renommez et réorganisez pour optimiser les flux de travail PPTX et ODP."
---

Avec Aspose.Slides pour .NET, vous pouvez organiser une présentation PowerPoint en sections. Vous pouvez créer des sections qui contiennent des diapositives spécifiques. 

Il se peut que vous souhaitiez créer des sections et les utiliser pour organiser ou diviser les diapositives d’une présentation en parties logiques dans les situations suivantes :

- Lorsque vous travaillez sur une grande présentation avec d’autres personnes ou une équipe — et que vous devez attribuer certaines diapositives à un collègue ou à plusieurs membres de l’équipe. 
- Lorsque vous avez une présentation contenant de nombreuses diapositives — et que vous avez du mal à gérer ou à modifier son contenu en une seule fois.

Idéalement, vous devez créer une section qui regroupe des diapositives similaires — les diapositives ont quelque chose en commun ou peuvent être regroupées selon une règle—et donner à la section un nom qui décrit les diapositives qu’elle contient. 

## **Créer des sections dans les présentations**

Pour ajouter une section qui regroupera des diapositives dans une présentation, Aspose.Slides pour .NET fournit la méthode AddSection qui vous permet de spécifier le nom de la section que vous souhaitez créer ainsi que la diapositive à partir de laquelle la section commence. 

Ce code d’exemple vous montre comment créer une section dans une présentation en C#:
```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 sera terminée à newSlide2 et après celle-ci section2 commencera   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```


## **Modifier les noms des sections**

Après avoir créé une section dans une présentation PowerPoint, vous pouvez décider de changer son nom. 

Ce code d’exemple vous montre comment modifier le nom d’une section dans une présentation en C# en utilisant Aspose.Slides :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```


## **FAQ**

**Les sections sont‑elles conservées lors de l’enregistrement au format PPT (PowerPoint 97–2003) ?**

Non. Le format PPT ne prend pas en charge les métadonnées de section, de sorte que le regroupement des sections est perdu lors de l’enregistrement en .ppt.

**Une section entière peut‑elle être "masquée" ?**

Non. Seules les diapositives individuelles peuvent être masquées. Une section en tant qu'entité n’a aucun état « masqué ».

**Puis‑je rapidement trouver une section à partir d’une diapositive et, inversement, la première diapositive d’une section ?**

Oui. Une section est définie de façon unique par sa diapositive de départ ; à partir d’une diapositive, vous pouvez déterminer à quelle section elle appartient, et pour une section vous pouvez accéder à sa première diapositive.