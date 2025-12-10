---
title: Gestion des en‑têtes et pieds de page de présentation en .NET
linktitle: En‑tête et pied de page
type: docs
weight: 140
url: /fr/net/presentation-header-and-footer/
keywords:
- en‑tête
- texte d'en‑tête
- pied de page
- texte du pied de page
- définir l'en‑tête
- définir le pied de page
- prospectus
- notes
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Utilisez Aspose.Slides pour .NET pour ajouter et personnaliser les en‑têtes et pieds de page dans les présentations PowerPoint et OpenDocument afin d’obtenir un rendu professionnel."
---

{{% alert color="primary" %}} 
[Aspose.Slides](/slides/fr/net/) fournit une prise en charge pour travailler avec le texte des en-têtes et pieds de page des diapositives qui sont réellement maintenus au niveau du maître de diapositive.
{{% /alert %}} 
[Aspose.Slides for .NET](/slides/fr/net/) propose la fonction de gestion des en-têtes et pieds de page à l'intérieur des diapositives de présentation. Ceux‑ci sont en fait gérés au niveau du maître de la présentation.
## **Gérer le texte des en‑têtes et pieds de page**
Les notes d’une diapositive spécifique peuvent être mises à jour comme le montre l’exemple ci‑dessous :
```c#
// Charger la présentation
Presentation pres = new Presentation("headerTest.pptx");

// Définir le pied de page
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Accéder et mettre à jour l'en-tête
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Enregistrer la présentation
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```

```c#
// Méthode pour définir le texte d'en-tête/pied de page
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```


## **Gérer les en‑têtes et pieds de page sur les diapositives de prospectus et de notes**
Aspose.Slides for .NET prend en charge les en‑têtes et pieds de page dans les diapositives de prospectus et de notes. Veuillez suivre les étapes ci‑dessous :

- Chargez une [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant une vidéo.
- Modifiez les paramètres d’en‑tête et de pied de page pour le maître des notes et toutes les diapositives de notes.
- Rendez visibles les espaces réservés Footer du maître des notes et de tous les enfants.
- Rendez visibles les espaces réservés Date et heure du maître des notes et de tous les enfants.
- Modifiez les paramètres d’en‑tête et de pied de page uniquement pour la première diapositive de notes.
- Rendez visible l’espace réservé Header de la diapositive de notes.
- Définissez le texte de l’espace réservé Header de la diapositive de notes.
- Définissez le texte de l’espace réservé Date‑time de la diapositive de notes.
- Enregistrez le fichier de présentation modifié.

Extrait de code fourni dans l’exemple ci‑dessous.
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Modifier les paramètres d'en-tête et de pied de page pour le maître des notes et toutes les diapositives de notes
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // rendre le maître des notes et tous les espaces reservés Footer enfants visibles
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // rendre le maître des notes et tous les espaces reservés Header enfants visibles
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // rendre le maître des notes et tous les espaces reservés SlideNumber enfants visibles
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // rendre le maître des notes et tous les espaces reservés Date et heure enfants visibles

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // definir le texte du maître des notes et de tous les espaces reservés Header enfants
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // definir le texte du maître des notes et de tous les espaces reservés Footer enfants
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // definir le texte du maître des notes et de tous les espaces reservés Date et heure enfants
	}

	// Modifier les paramètres d'en-tête et de pied de page pour la première diapositive de notes uniquement
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // rendre cet espace reservé Header de la diapositive de notes visible

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // rendre cet espace reservé Footer de la diapositive de notes visible

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // rendre cet espace reservé SlideNumber de la diapositive de notes visible

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // rendre cet espace reservé Date-time de la diapositive de notes visible

		headerFooterManager.SetHeaderText("New header text"); // definir le texte de l'espace reservé Header de la diapositive de notes
		headerFooterManager.SetFooterText("New footer text"); // definir le texte de l'espace reservé Footer de la diapositive de notes
		headerFooterManager.SetDateTimeText("New date and time text"); // definir le texte de l'espace reservé Date-time de la diapositive de notes
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **FAQ**

**Puis‑je ajouter un « en‑tête » aux diapositives ordinaires ?**

Dans PowerPoint, l’« en‑tête » n’existe que pour les notes et les prospectus ; sur les diapositives ordinaires, les éléments pris en charge sont le pied de page, la date/heure et le numéro de diapositive. Dans Aspose.Slides cela correspond aux mêmes limitations : en‑tête uniquement pour les notes/prospectus, et sur les diapositives — Footer/DateTime/SlideNumber.

**Que faire si la disposition ne contient pas de zone de pied de page—puis‑je activer sa visibilité ?**

Oui. Vérifiez la visibilité via le gestionnaire d’en‑tête/pied de page et activez‑la si nécessaire. Ces indicateurs et méthodes d’API sont prévus pour les cas où l’espace réservé est absent ou masqué.

**Comment faire commencer la numérotation des diapositives à une valeur autre que 1 ?**

Définissez le [numéro de première diapositive](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) de la présentation ; à partir de là, toute la numérotation est recalculée. Par exemple, vous pouvez commencer à 0 ou 10, et masquer le numéro sur la diapositive de titre.

**Que se passe‑t‑il avec les en‑têtes/pieds de page lors de l’exportation en PDF/images/HTML ?**

Ils sont rendus comme des éléments texte ordinaires de la présentation. Ainsi, si les éléments sont visibles sur les diapositives ou les pages de notes, ils apparaîtront également dans le format de sortie avec le reste du contenu.