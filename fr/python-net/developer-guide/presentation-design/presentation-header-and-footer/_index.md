---
title: Gérer les en‑têtes et pieds de page de présentation avec Python
linktitle: En‑tête et pied de page
type: docs
weight: 140
url: /fr/python-net/presentation-header-and-footer/
keywords:
- en‑tête
- texte d’en‑tête
- pied de page
- texte du pied de page
- définir l’en‑tête
- définir le pied de page
- tracts
- notes
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Utilisez Aspose.Slides pour Python via .NET afin d’ajouter et de personnaliser les en‑têtes et pieds de page dans les présentations PowerPoint et OpenDocument pour un rendu professionnel."
---

## **Vue d'ensemble**

Aspose.Slides pour Python vous permet de contrôler les espaces réservés d’en‑tête et de pied de page dans l’ensemble d’une présentation avec une portée précise. Le texte du pied de page, la date/heure et les numéros de diapositive sont gérés au niveau du masque et peuvent être appliqués globalement ou ajustés diapositive par diapositive. Les en‑têtes sont pris en charge sur les notes et les annexes, où vous pouvez activer ou désactiver leur visibilité et définir le texte de l’en‑tête, du pied de page, de la date/heure et des numéros de page via le gestionnaire dédié d’en‑tête et de pied de page du masque de notes ou des diapositives de notes individuelles. Cet article décrit les principaux modèles pour mettre à jour ces espaces réservés et propager les modifications de manière cohérente dans l’ensemble de votre jeu de diapositives.

## **Gérer le texte d’en‑ête et de pied de page**

Dans cette section, vous apprendrez à gérer le contenu des en‑têtes et pieds de page dans une présentation — activer ou modifier le pied de page, la date et l’heure, et les numéros de diapositive. Nous présenterons brièvement les portées d’application de ces paramètres (l’ensemble de la présentation, des diapositives individuelles, et les vues notes/annexes) et montrerons comment utiliser l’API Aspose.Slides pour les mettre à jour rapidement et de façon cohérente.

L’exemple de code ci‑dessous ouvre une présentation, active et définit le texte du pied de page, met à jour le texte de l’en‑tête sur le masque de notes, puis enregistre le fichier.

```py
import aspose.slides as slides

# Function to set the header text.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Load the presentation.
with slides.Presentation("sample.pptx") as presentation:
    # Set the footer.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Access and update the header.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gérer les en‑têtes et pieds de page sur les diapositives de notes**

Dans cette section, vous apprendrez à gérer les en‑têtes et pieds de page spécifiquement pour les diapositives de notes dans Aspose.Slides. Nous couvrirons l’activation des espaces réservés correspondants, la définition du texte des pieds de page, de la date/heure et des numéros de page, ainsi que l’application cohérente de ces modifications sur le masque de notes et les pages de notes individuelles.

Suivez les étapes ci‑dessous :

1. Chargez un fichier de présentation.  
2. Obtenez la diapositive maître de notes et son [gestionnaire d’en‑tête & pied de page](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).  
3. Sur la diapositive maître de notes, activez la visibilité de l’En‑tête, du Pied de page, du Numéro de diapositive et de la Date‑heure pour le maître et toutes les diapositives de notes enfants.  
4. Sur la diapositive maître de notes, définissez le texte de l’En‑tête, du Pied de page et de la Date‑heure pour le maître et toutes les diapositives de notes enfants.  
5. Obtenez la diapositive de notes de la première diapositive de la présentation et son [gestionnaire d’en‑tête & pied de page](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).  
6. Pour cette première diapositive de notes uniquement, assurez‑vous que l’En‑tête, le Pied de page, le Numéro de diapositive et la Date‑heure sont visibles (activez ceux qui sont désactivés).  
7. Pour cette première diapositive de notes uniquement, définissez le texte de l’En‑tête, du Pied de page et de la Date‑heure.  
8. Enregistrez la présentation au format PPTX.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Make the master notes slide and all child header, footer, slide number, and date/time placeholders visible.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Set text on the master notes slide and all child header, footer, and date/time placeholders.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Change header, footer, slide number, and date/time settings for the first notes slide only.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Ensure the header, footer, slide number, and date/time placeholders are visible.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Set text on the notes slide header, footer, and date/time placeholders.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Puis‑je ajouter un « en‑tête » aux diapositives normales ?**

Dans PowerPoint, l’« En‑tête » n’existe que pour les notes et les annexes ; sur les diapositives normales, les éléments pris en charge sont le pied de page, la date/heure et le numéro de diapositive. Dans Aspose.Slides cela reflète les mêmes limitations : l’en‑tête uniquement pour les Notes/Annexes, et sur les diapositives — Pied de page/Date‑heure/Numéro de diapositive.

**Et si la mise en page ne contient pas de zone de pied de page—puis‑je « activer » sa visibilité ?**

Oui. Vérifiez la visibilité via le gestionnaire d’en‑tête/pied de page et activez‑la si nécessaire. Ces indicateurs et méthodes de l’API sont prévus pour les cas où l’espace réservé est absent ou masqué.

**Comment faire en sorte que le numéro de diapositive commence à une valeur autre que 1 ?**

Définissez le [premier numéro de diapositive](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) de la présentation ; après cela, toute la numérotation est recalculée. Par exemple, vous pouvez commencer à 0 ou 10, et masquer le numéro sur la diapositive de titre.

**Que se passe‑t‑il pour les en‑têtes/pieds de page lors de l’exportation en PDF/images/HTML ?**

Ils sont rendus comme des éléments texte normaux de la présentation. Autrement dit, si les éléments sont visibles sur les diapositives ou les pages de notes, ils apparaîtront également dans le format de sortie avec le reste du contenu.