---
title: Section de Diapositive
type: docs
weight: 100
url: /fr/python-net/slide-section/
keywords: "Créer une section, Ajouter une section, Modifier le nom de la section, Présentation PowerPoint, Python, Aspose.Slides"
description: "Ajouter et modifier une section dans une présentation PowerPoint en Python"
---

Avec Aspose.Slides pour Python via .NET, vous pouvez organiser une présentation PowerPoint en sections. Vous pouvez créer des sections qui contiennent des diapositives spécifiques.

Vous voudrez peut-être créer des sections et les utiliser pour organiser ou diviser les diapositives d'une présentation en parties logiques dans ces situations :

- Lorsque vous travaillez sur une grande présentation avec d'autres personnes ou une équipe—et que vous devez attribuer certaines diapositives à un collègue ou à des membres de l'équipe.
- Lorsque vous avez affaire à une présentation qui contient de nombreuses diapositives—et que vous avez du mal à gérer ou à éditer son contenu en une seule fois.

Idéalement, vous devriez créer une section qui regroupe des diapositives similaires—les diapositives ont quelque chose en commun ou peuvent exister dans un groupe basé sur une règle—et donner à la section un nom qui décrit les diapositives qu'elle contient.

## Création de Sections dans les Présentations

Pour ajouter une section qui contiendra des diapositives dans une présentation, Aspose.Slides pour Python via .NET fournit la méthode AddSection qui vous permet de spécifier le nom de la section que vous souhaitez créer et la diapositive à partir de laquelle la section commence.

Ce code d'exemple vous montre comment créer une section dans une présentation en Python :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    defaultSlide = pres.slides[0]
    newSlide1 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide2 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide3 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide4 = pres.slides.add_empty_slide(pres.layout_slides[0])

    section1 = pres.sections.add_section("Section 1", newSlide1)
    # section1 se terminera à newSlide2 et après cela section2 commencera 
    section2 = pres.sections.add_section("Section 2", newSlide3) 
      
    
    pres.save("pres-sections.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.reorder_section_with_slides(section2, 0)
    pres.save("pres-sections-moved.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.remove_section_with_slides(section2)
    
    pres.sections.append_empty_section("Dernière section vide")
    
    pres.save("pres-section-with-empty.pptx",slides.export.SaveFormat.PPTX)
```

## Changement des Noms des Sections

Après avoir créé une section dans une présentation PowerPoint, vous pouvez décider de changer son nom.

Ce code d'exemple vous montre comment changer le nom d'une section dans une présentation en Python en utilisant Aspose.Slides :

```py
import aspose.slides as slides

with slides.Presentation("pres-sections.pptx") as pres:
   section = pres.sections[0]
   section.name = "Ma section"
```