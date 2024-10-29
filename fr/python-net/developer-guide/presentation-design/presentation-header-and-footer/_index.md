---
title: En-tête et pied de page de présentation
type: docs
weight: 140
url: /fr/python-net/presentation-header-and-footer/
keywords: "En-tête, pied de page, définir en-tête, définir pied de page, définir en-tête et pied de page, présentation PowerPoint, Python, Aspose.Slides for Python via .NET"
description: "En-tête et pied de page PowerPoint en Python"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/fr/python-net/) fournit un support pour travailler avec le texte des en-têtes et des pieds de page des diapositives qui sont en fait maintenus au niveau du maître de diapositive.

{{% /alert %}} 

[Aspose.Slides for Python via .NET](/slides/fr/python-net/) fournit la fonctionnalité de gestion des en-têtes et des pieds de page à l'intérieur des diapositives de présentation. Ceux-ci sont en fait gérés au niveau du maître de présentation.
## **Gérer le texte de l'en-tête et du pied de page**
Les notes de certaines diapositives spécifiques peuvent être mises à jour comme le montre l'exemple ci-dessous :

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Méthode pour définir le texte de l'en-tête/pied de page
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Bonjour, nouvel en-tête"

# Charger la présentation
with slides.Presentation("combined_with_master.pptx") as pres:
    # Définir le pied de page
    pres.header_footer_manager.set_all_footers_text("Mon texte de pied de page")
    pres.header_footer_manager.set_all_footers_visibility(True)

    # Accéder et mettre à jour l'en-tête
    masterNotesSlide = pres.master_notes_slide_manager.master_notes_slide
    if masterNotesSlide is not None:
        update_header_footer_text(masterNotesSlide)

    # enregistrer la présentation
    pres.save("HeaderFooter-out.pptx", slides.export.SaveFormat.PPTX)
```




## **Gérer l'en-tête et le pied de page dans les diapositives de distribution et de notes**
Aspose.Slides for Python via .NET prend en charge l'en-tête et le pied de page dans les diapositives de distribution et de notes. Veuillez suivre les étapes ci-dessous :

- Charger une [présentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contenant une vidéo.
- Modifier les paramètres d'en-tête et de pied de page pour le maître de notes et toutes les diapositives de notes.
- Définir le maître de la diapositive de notes et rendre tous les espaces réservés de pied de page visibles.
- Définir le maître de la diapositive de notes et rendre tous les espaces réservés de date et heure visibles.
- Modifier les paramètres d'en-tête et de pied de page uniquement pour la première diapositive de notes.
- Rendre l'espace réservé de l'en-tête de la diapositive de notes visible.
- Définir le texte pour l'espace réservé de l'en-tête de la diapositive de notes.
- Définir le texte pour l'espace réservé de date et d'heure de la diapositive de notes.
- Écrire le fichier de présentation modifié.

Extrait de code fourni dans l'exemple ci-dessous.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("combined_with_master.pptx") as presentation:
	masterNotesSlide = presentation.master_notes_slide_manager.master_notes_slide
	if masterNotesSlide != None:
		headerFooterManager = masterNotesSlide.header_footer_manager

		# rendre le maître de la diapositive de notes et tous les espaces réservés de pied de page visibles
		headerFooterManager.set_header_and_child_headers_visibility(True) 
		headerFooterManager.set_footer_and_child_footers_visibility(True) 
		headerFooterManager.set_slide_number_and_child_slide_numbers_visibility(True) 
		headerFooterManager.set_date_time_and_child_date_times_visibility(True)

		# définir le texte pour le maître de la diapositive de notes et tous les espaces réservés d'en-tête
		headerFooterManager.set_header_and_child_headers_text("Texte d'en-tête") 
		headerFooterManager.set_footer_and_child_footers_text("Texte de pied de page") 
		headerFooterManager.set_date_time_and_child_date_times_text("Texte de date et d'heure") 

	# Modifier les paramètres d'en-tête et de pied de page uniquement pour la première diapositive de notes
	notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
	if notesSlide != None:
		headerFooterManager = notesSlide.header_footer_manager

		# rendre l'espace réservé de l'en-tête de la diapositive de notes visible

		if not headerFooterManager.is_header_visible:
			headerFooterManager.set_header_visibility(True) 

		if not headerFooterManager.is_footer_visible:
			headerFooterManager.set_footer_visibility(True) 

		if not headerFooterManager.is_slide_number_visible:
			headerFooterManager.set_slide_number_visibility(True) 

		if not headerFooterManager.is_date_time_visible:
			headerFooterManager.set_date_time_visibility(True) 

		# définir le texte pour l'espace réservé de l'en-tête de la diapositive de notes
		headerFooterManager.set_header_text("Nouveau texte d'en-tête") 
		headerFooterManager.set_footer_text("Nouveau texte de pied de page") 
		headerFooterManager.set_date_time_text("Nouveau texte de date et d'heure") 
	presentation.save("testresult.pptx",slides.export.SaveFormat.PPTX)
```