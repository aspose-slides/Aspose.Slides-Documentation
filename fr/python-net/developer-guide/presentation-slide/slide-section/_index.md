---
title: Gérer les sections de diapositives dans les présentations avec Python
linktitle: Section de diapositive
type: docs
weight: 100
url: /fr/python-net/slide-section/
keywords:
- créer une section
- ajouter une section
- modifier une section
- changer de section
- nom de la section
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Simplifiez les sections de diapositives dans PowerPoint et OpenDocument avec Aspose.Slides for Python — séparez, renommez et réordonnez pour optimiser les flux de travail PPTX et ODP."
---

## **Vue d'ensemble**

Avec Aspose.Slides pour Python, vous pouvez organiser une présentation PowerPoint en sections qui regroupent des diapositives spécifiques.

Vous pouvez vouloir créer des sections pour organiser ou diviser une présentation en parties logiques dans les situations suivantes :

- Lorsque vous travaillez sur une grande présentation avec une équipe et devez attribuer certaines diapositives à des collègues spécifiques.
- Lorsque vous avez une présentation contenant de nombreuses diapositives et que vous avez du mal à tout gérer ou à tout modifier en même temps.

Idéalement, créez des sections qui regroupent des diapositives liées — celles qui partagent un thème, un sujet ou un but — et attribuez à chaque section un nom qui reflète clairement son contenu. 

## **Créer des sections dans les présentations**

Pour ajouter une [Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/) qui regroupe des diapositives dans une présentation, Aspose.Slides fournit la méthode [add_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectioncollection/add_section/). Elle vous permet de spécifier le nom de la section et la diapositive où la section commence.

L’exemple Python suivant montre comment créer une section dans une présentation :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # La section 1 se termine à la diapositive 2 ; la section 2 commence à la diapositive 3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **Modifier les noms des sections**

Après avoir créé une [Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/) dans une présentation PowerPoint, vous pouvez décider de changer son nom.

L’exemple Python suivant montre comment renommer une section dans une présentation :

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **FAQ**

**Les sections sont-elles préservées lors de l'enregistrement au format PPT (PowerPoint 97–2003) ?**

Non. Le format PPT ne prend pas en charge les métadonnées de sections, ainsi le regroupement des sections est perdu lors de l'enregistrement au format .ppt.

**Une section entière peut-elle être « masquée » ?**

Non. Seules les diapositives individuelles peuvent être masquées. Une section en tant qu'entité n'a aucun état « masqué ».

**Puis-je rapidement trouver une section à partir d'une diapositive et, inversement, la première diapositive d'une section ?**

Oui. Une section est définie de manière unique par sa diapositive de départ ; à partir d'une diapositive, vous pouvez déterminer à quelle section elle appartient, et pour une section vous pouvez accéder à sa première diapositive.