---
title: Gérer les En-têtes et Pieds de Page de Présentation avec Python
linktitle: En-tête et Pied de page
type: docs
weight: 140
url: /fr/python-net/presentation-header-and-footer/
keywords:
- en-tête
- texte d'en-tête
- pied de page
- texte de pied de page
- définir l'en-tête
- définir le pied de page
- support de cours
- notes
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Utilisez Aspose.Slides pour Python via .NET pour ajouter et personnaliser les en-têtes et pieds de page dans les présentations PowerPoint et OpenDocument afin d'obtenir un aspect professionnel."
---

## **Aperçu**

Aspose.Slides for Python vous permet de contrôler les espaces réservés d’en‑tête et de pied de page dans une présentation avec une portée précise. Le texte du pied de page, la date/heure et les numéros de diapositive sont gérés au niveau du maître et peuvent être appliqués globalement ou ajustés par diapositive. Les en‑têtes sont prises en charge sur les notes et les supports de cours, où vous pouvez activer la visibilité et définir le texte pour l’en‑tête, le pied de page, la date/heure et les numéros de page via le gestionnaire dédié d’en‑tête et de pied de page sur la diapositive maîtresse de notes ou les diapositives de notes individuelles. Cet article décrit les principaux modèles pour mettre à jour ces espaces réservés et propager les changements de façon cohérente dans votre présentation.

## **Gérer le texte de l’en-tête et du pied de page**

Dans cette section, vous apprendrez à gérer le contenu de l’en‑tête et du pied de page d’une présentation — activer ou modifier le pied de page, la date et l’heure, ainsi que les numéros de diapositive. Nous décrirons brièvement les portées d’application de ces paramètres (toute la présentation, les diapositives individuelles et les vues notes/supports) et montrerons comment utiliser l’API Aspose.Slides pour les mettre à jour rapidement et de façon cohérente.

L’exemple de code ci‑dessous ouvre une présentation, active et définit le texte du pied de page, met à jour le texte de l’en‑tête sur la diapositive maîtresse de notes, puis enregistre le fichier.

```py
import aspose.slides as slides

# Fonction pour définir le texte de l’en-tête.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Charger la présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Définir le pied de page.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Accéder et mettre à jour l’en-tête.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Enregistrer la présentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gérer l’en-tête et le pied de page sur les diapositives de notes**

Dans cette section, vous apprendrez à gérer les en‑têtes et pieds de page spécifiquement pour les diapositives de notes dans Aspose.Slides. Nous couvrirons l’activation des espaces réservés pertinents, la définition du texte pour les pieds de page, la date/heure et les numéros de page, ainsi que l’application cohérente de ces changements sur le maître de notes et les pages de notes individuelles.

Suivez les étapes ci-dessous :

1. Charger un fichier de présentation.
2. Obtenir la diapositive maîtresse de notes et son [gestionnaire d’en‑tête et de pied de page](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).
3. Sur la diapositive maîtresse de notes, activer la visibilité de l’en‑tête, du pied de page, du numéro de diapositive et de la date/heure pour la maîtresse et toutes les diapositives de notes enfants.
4. Sur la diapositive maîtresse de notes, définir le texte de l’en‑tête, du pied de page et de la date/heure pour la maîtresse et toutes les diapositives de notes enfants.
5. Obtenir la diapositive de notes de la première diapositive de la présentation et son [gestionnaire d’en‑tête et de pied de page](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).
6. Pour cette première diapositive de notes uniquement, s’assurer que l’en‑tête, le pied de page, le numéro de diapositive et la date/heure sont visibles (activer ceux qui sont désactivés).
7. Pour cette première diapositive de notes uniquement, définir le texte de l’en‑tête, du pied de page et de la date/heure.
8. Enregistrer la présentation au format PPTX.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Rendre visibles les espaces réservés d’en‑tête, de pied de page, de numéro de diapositive et de date/heure de la diapositive maîtresse de notes et de tous les enfants.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Définir le texte sur la diapositive maîtresse de notes et sur tous les espaces réservés d’en‑tête, de pied de page et de date/heure des enfants.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Modifier les paramètres d’en‑tête, de pied de page, de numéro de diapositive et de date/heure uniquement pour la première diapositive de notes.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # S’assurer que les espaces réservés d’en‑tête, de pied de page, de numéro de diapositive et de date/heure sont visibles.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Définir le texte sur les espaces réservés d’en‑tête, de pied de page et de date/heure de la diapositive de notes.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Enregistrer la présentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Puis-je ajouter un « en‑tête » aux diapositives normales ?**

Dans PowerPoint, l'« en‑tête » n'existe que pour les notes et les supports de cours ; sur les diapositives normales, les éléments pris en charge sont le pied de page, la date/heure et le numéro de diapositive. Dans Aspose.Slides, les mêmes limitations s'appliquent : l'en‑tête uniquement pour les notes/supports de cours, et sur les diapositives — pied de page/date‑heure/numéro de diapositive.

**Que faire si la disposition ne contient pas de zone de pied de page—puis-je « activer » sa visibilité ?**

Oui. Vérifiez la visibilité via le gestionnaire d’en‑tête et de pied de page et activez‑la si nécessaire. Ces indicateurs et méthodes de l’API sont conçus pour les cas où l’espace réservé est absent ou masqué.

**Comment faire commencer le numéro de diapositive à une valeur autre que 1 ?**

Définissez le [numéro de première diapositive](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) de la présentation ; ensuite, toute la numérotation est recalculée. Par exemple, vous pouvez commencer à 0 ou à 10, et masquer le numéro sur la diapositive de titre.

**Que se passe-t-il aux en‑têtes/pieds de page lors de l’exportation en PDF/images/HTML ?**

Ils sont rendus comme des éléments texte ordinaires de la présentation. Ainsi, si les éléments sont visibles sur les diapositives ou les pages de notes, ils apparaîtront également dans le format de sortie avec le reste du contenu.