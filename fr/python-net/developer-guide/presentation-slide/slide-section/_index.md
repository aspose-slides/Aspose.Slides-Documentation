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
- changer une section
- nom de la section
- récupérer les diapositives de section
- traiter les diapositives de section
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Gérez les sections de diapositives avec Aspose.Slides pour Python via .NET : créez, renommez, réorganisez, récupérez et traitez les diapositives de section dans les présentations PPTX."
---
## **Introduction**

Les sections organisent des diapositives consécutives en groupes nommés sans modifier le contenu des diapositives. Avec Aspose.Slides for Python via .NET, vous pouvez créer, réorganiser, renommer, inspecter et supprimer des sections via la propriété Presentation.sections.

Les sections sont particulièrement utiles lorsque :

- une grande présentation doit être divisée en sujets ou chapitres logiques ;
- différents groupes de diapositives sont attribués à différents collaborateurs ;
- les diapositives doivent être traitées, déplacées ou fusionnées par groupes.

Choisissez des noms de sections concis qui décrivent le but des diapositives groupées. Parce que les sections font partie de la structure de la présentation, utilisez les API de sections pour déterminer l’appartenance au lieu de la déduire à partir des positions des diapositives.

## **Créer et gérer des sections**

Utilisez [SectionCollection.add_section](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sectioncollection/add_section/) pour créer une section en spécifiant son nom et la diapositive de départ. Aspose.Slides détermine quelles diapositives appartiennent à la section à partir de la structure actuelle des sections de la présentation.

Le même [SectionCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sectioncollection/) vous permet également de :

- déplacer une section avec ses diapositives en utilisant [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/) ;
- supprimer uniquement la définition de la section avec [SectionCollection.remove_section](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sectioncollection/remove_section/), ce qui conserve ses diapositives ;
- supprimer une section et ses diapositives avec [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sectioncollection/remove_section_with_slides/) ;
- ajouter une section vide à la fin avec [SectionCollection.append_empty_section](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sectioncollection/append_empty_section/) .

L’exemple suivant crée deux sections, déplace l’une d’elles, la supprime ainsi que ses diapositives, puis ajoute une section vide :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

Après ces opérations, la présentation contient la section `Introduction` avec ses diapositives et une section vide `Appendix`. La section `Results` et ses diapositives ont été supprimées.

## **Renommer les sections**

Pour renommer une section, définissez sa propriété [Section.name](https://reference.aspose.com/slides/fr/python-net/aspose.slides/section/name/). Les diapositives et la position de la section restent inchangées.

L’exemple suivant crée une section et modifie son nom :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **Récupérer les diapositives d’une section**

La propriété [Presentation.sections](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/sections/) renvoie un [SectionCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sectioncollection/) que vous pouvez parcourir. Pour chaque [Section](https://reference.aspose.com/slides/fr/python-net/aspose.slides/section/), appelez [Section.get_slides_list_of_section](https://reference.aspose.com/slides/fr/python-net/aspose.slides/section/get_slides_list_of_section/) afin d’obtenir les diapositives qui lui appartiennent actuellement. La méthode renvoie un [SectionSlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sectionslidecollection/), qui fournit un compteur, un accès indexé et l’itération.

L’exemple suivant crée deux sections remplies et une section vide, puis affiche le [name](https://reference.aspose.com/slides/fr/python-net/aspose.slides/section/name/), l’[identifier](https://reference.aspose.com/slides/fr/python-net/aspose.slides/section/section_id/), la [starting slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/section/started_from_slide/), le nombre de diapositives et les numéros de diapositives de chaque section. Il utilise l’accès indexé pour lire la première diapositive et une boucle `for` pour traiter chaque diapositive. Pour la section vide, la collection renvoyée a un compteur de zéro, l’indice n’est pas accédé et l’itération ne produit aucune étape.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

L’appartenance à une section est déterminée par la structure des sections de la présentation. Ne calculez pas manuellement l’étendue d’une section à partir de [Section.started_from_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/section/started_from_slide/), des index de diapositives et de la diapositive de départ de la section suivante.

Les modifications structurelles peuvent changer à la fois les diapositives renvoyées pour une section et leurs numéros de diapositive. Cela inclut le réordonnancement des diapositives, le clonage d’une diapositive dans une section, le déplacement d’une section avec ses diapositives, la suppression de diapositives et la suppression de sections. L’exemple suivant appelle [Section.get_slides_list_of_section](https://reference.aspose.com/slides/fr/python-net/aspose.slides/section/get_slides_list_of_section/) après chaque modification au lieu de conserver des hypothèses sur les limites précédentes de la section.

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

Appelez [Section.get_slides_list_of_section](https://reference.aspose.com/slides/fr/python-net/aspose.slides/section/get_slides_list_of_section/) à nouveau chaque fois que des diapositives ou des sections sont réordonnées, clonées, déplacées ou supprimées. Cela maintient le traitement ultérieur aligné sur la structure actuelle de la présentation.

Le format PPT (PowerPoint 97–2003) ne conserve pas les métadonnées de section. Utilisez ce flux de travail avec un format qui prend en charge les sections, comme le PPTX ; la conversion en PPT supprime la structure de sections nécessaire à une itération ultérieure.

## **FAQ**

**Les sections sont‑elles conservées lors de l’enregistrement au format PPT (PowerPoint 97–2003) ?**

Non. Le format PPT ne prend pas en charge les métadonnées de section, ainsi le regroupement par sections est perdu lors de l’enregistrement au format .ppt.

**Une section entière peut‑elle être « masquée » ?**

Non. Une section n’a aucun état de visibilité. Pour masquer son contenu, définissez la propriété [Slide.hidden](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/hidden/) pour chaque diapositive de la section.

**Comment trouver la section qui contient une diapositive ?**

Parcourez [Presentation.sections](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/sections/), appelez [Section.get_slides_list_of_section](https://reference.aspose.com/slides/fr/python-net/aspose.slides/section/get_slides_list_of_section/) pour chaque section, et comparez les diapositives renvoyées avec la diapositive cible. Pour une section non vide, [Section.started_from_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/section/started_from_slide/) renvoie sa première diapositive ; pour une section vide, elle renvoie `None`.