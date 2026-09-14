---
title: Gérer les sections de diapositives dans les présentations avec Python via Java
linktitle: Section de diapositive
type: docs
weight: 90
url: /fr/python-java/slide-section/
keywords:
- créer une section
- ajouter une section
- modifier une section
- changer de section
- nom de la section
- récupérer les diapositives de section
- traiter les diapositives de section
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Gérez les sections de diapositives avec Aspose.Slides pour Python via Java : créez, renommez, réorganisez, récupérez et traitez les diapositives de section dans les présentations PPTX."
---
## **Introduction**

Les sections organisent les diapositives consécutives en groupes nommés sans modifier le contenu des diapositives. Avec Aspose.Slides pour Python via Java, vous pouvez créer, réorganiser, renommer, inspecter et supprimer des sections via la méthode [Presentation.getSections](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSections).

Les sections sont particulièrement utiles lorsque :
- une grande présentation doit être divisée en sujets ou chapitres logiques ;
- différents groupes de diapositives sont affectés à différents collaborateurs ;
- les diapositives doivent être traitées, déplacées ou fusionnées en groupes.

Choisissez des noms de section concis qui décrivent le but des diapositives groupées. Étant donné que les sections font partie de la structure de la présentation, utilisez les API de section pour déterminer l’appartenance au lieu de la déduire des positions des diapositives.

## **Créer et gérer les sections**

Utilisez [SectionCollection.addSection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sectioncollection/#addSection) pour créer une section en spécifiant son nom et la diapositive de départ. Aspose.Slides détermine les diapositives appartenant à la section à partir de la structure actuelle des sections de la présentation.

La même [SectionCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sectioncollection/) vous permet également de :
- déplacer une section ainsi que ses diapositives en utilisant [reorderSectionWithSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- supprimer uniquement la définition de la section avec [removeSection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sectioncollection/#removeSection), ce qui conserve ses diapositives ;
- supprimer une section et ses diapositives avec [removeSectionWithSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sectioncollection/#removeSectionwithslides);
- ajouter une section vide à la fin avec [appendEmptySection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sectioncollection/#appendEmptySection).

L'exemple suivant crée deux sections, déplace l'une d'elles, la supprime avec ses diapositives, puis ajoute une section vide :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

Après ces opérations, la présentation contient la section `Introduction` avec ses diapositives et une section vide `Appendix`. La section `Results` et ses diapositives ont été supprimées.

## **Renommer les sections**

Pour renommer une section, appelez sa méthode [Section.setName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/section/#setName). Les diapositives de la section et sa position restent inchangées.

L'exemple suivant crée une section et modifie son nom :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **Récupérer les diapositives des sections**

La méthode [Presentation.getSections](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSections) renvoie une [SectionCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sectioncollection/) que vous pouvez parcourir. Pour chaque [Section](https://reference.aspose.com/slides/fr/python-java/aspose.slides/section/), appelez [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/section/#getSlidesListOfSection) afin d'obtenir les diapositives qui lui appartiennent actuellement. Cette méthode renvoie une [SectionSlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sectionslidecollection/), qui fournit un compteur, un accès indexé et une itération.

L'exemple suivant crée deux sections remplies et une section vide, puis affiche le [nom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/section/#getName), l'[identifiant](https://reference.aspose.com/slides/fr/python-java/aspose.slides/section/#getSectionId), la [diapositive de départ](https://reference.aspose.com/slides/fr/python-java/aspose.slides/section/#getStartedFromSlide), le nombre de diapositives et les numéros de diapositives de chaque section. Il utilise [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sectionslidecollection/#get_Item) pour lire la première diapositive et une instruction `for` pour traiter chaque diapositive. Pour la section vide, la collection renvoyée a une taille de zéro, la méthode n'est pas appelée et l'itération ne réalise aucune opération.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

L'appartenance à une section est déterminée par la structure des sections de la présentation. Ne calculez pas manuellement la plage d'une section à partir de [Section.getStartedFromSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/section/#getStartedFromSlide), des index de diapositives et de la diapositive de départ de la section suivante.

Les modifications structurelles peuvent changer à la fois les diapositives renvoyées pour une section et leurs numéros. Cela inclut le réarrangement des diapositives, le clonage d'une diapositive dans une section, le déplacement d'une section avec ses diapositives, la suppression de diapositives et la suppression de sections. L'exemple suivant appelle [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/section/#getSlidesListOfSection) après chaque modification au lieu de conserver des hypothèses sur les limites précédentes de la section.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

Appelez à nouveau [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/section/#getSlidesListOfSection) chaque fois que des diapositives ou des sections sont réordonnées, clonées, déplacées ou supprimées. Cela maintient le traitement ultérieur aligné avec la structure actuelle de la présentation.

Le format PPT (PowerPoint 97–2003) ne conserve pas les métadonnées de section. Utilisez ce flux de travail avec un format qui prend en charge les sections, tel que PPTX ; la conversion en PPT supprime la structure de section nécessaire aux itérations ultérieures.

## **FAQ**

**Les sections sont‑elles conservées lors de l'enregistrement au format PPT (PowerPoint 97–2003) ?**

Non. Le format PPT ne prend pas en charge les métadonnées de section, de sorte que le regroupement des sections est perdu lors de l'enregistrement au format .ppt.

**Une section entière peut‑elle être « masquée » ?**

Non. Une section n’a aucun état de visibilité. Pour masquer son contenu, appelez [Slide.setHidden](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#setHidden) pour chaque diapositive de la section.

**Comment trouver la section qui contient une diapositive ?**

Parcourez la collection renvoyée par [Presentation.getSections](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSections), appelez [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/section/#getSlidesListOfSection) pour chaque section, puis comparez les diapositives renvoyées avec la diapositive cible. Pour une section non vide, [Section.getStartedFromSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/section/#getStartedFromSlide) renvoie sa première diapositive ; pour une section vide, elle renvoie `None`.