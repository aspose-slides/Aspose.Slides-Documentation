---
title: En-tête et pied de page de la présentation
type: docs
weight: 140
url: /fr/net/presentation-header-and-footer/
keywords: "En-tête, pied de page, définir l’en-tête, définir le pied de page, définir l’en-tête et le pied de page, Présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "En-tête et pied de page PowerPoint en C# ou .NET"
---

{{% alert color="primary" %}}

[Aspose.Slides](/slides/fr/net/) offre la prise en charge du texte des en‑têtes et pieds de page des diapositives, qui sont en fait gérés au niveau du maître de diapositive.

{{% /alert %}}

[Aspose.Slides for .NET](/slides/fr/net/) propose la fonctionnalité de gestion des en‑têtes et pieds de page dans les diapositives de présentation. Ceux‑ci sont effectivement gérés au niveau du maître de présentation.
## **Manage Header and Footer Text**
Les notes d’une diapositive spécifique peuvent être mises à jour comme indiqué dans l’exemple ci‑dessous :
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


## **Manage Header and Footer in Handout and Notes Slides**
Aspose.Slides for .NET prend en charge les en‑têtes et pieds de page dans les diapositives de documents et de notes. Veuillez suivre les étapes ci‑dessous :

- Charger une [Présentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant une vidéo.
- Modifier les paramètres d’en‑tête et de pied de page pour le maître des notes et toutes les diapositives de notes.
- Rendre visibles les espaces réservés du pied de page du maître des notes et de tous les éléments enfants.
- Rendre visibles les espaces réservés de la date et de l’heure du maître des notes et de tous les éléments enfants.
- Modifier les paramètres d’en‑tête et de pied de page uniquement pour la première diapositive de notes.
- Rendre visible l’espace réservé de l’en‑tête de la diapositive de notes.
- Ajouter du texte à l’espace réservé de l’en‑tête de la diapositive de notes.
- Ajouter du texte à l’espace réservé de la date‑heure de la diapositive de notes.
- Enregistrer le fichier de présentation modifié.

Extrait de code fourni dans l’exemple ci‑dessous.
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Modifier les paramètres d’en‑tête et de pied de page pour le maître des notes et toutes les diapositives de notes
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // rendre le maître des notes et tous les espaces réservés de l’en‑tête enfants visibles
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // rendre le maître des notes et tous les espaces réservés du pied de page enfants visibles
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // rendre le maître des notes et tous les espaces réservés du numéro de diapositive enfants visibles
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // rendre le maître des notes et tous les espaces réservés de date et heure enfants visibles

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // définir le texte du maître des notes et de tous les espaces réservés d’en‑tête enfants
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // définir le texte du maître des notes et de tous les espaces réservés de pied de page enfants
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // définir le texte du maître des notes et de tous les espaces réservés de date et heure enfants
	}

	// Modifier les paramètres d’en‑tête et de pied de page pour la première diapositive de notes uniquement
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // rendre cet espace réservé d’en‑tête de diapositive de notes visible

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // rendre cet espace réservé de pied de page de diapositive de notes visible

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // rendre cet espace réservé de numéro de diapositive de diapositive de notes visible

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // rendre cet espace réservé de date‑heure de diapositive de notes visible

		headerFooterManager.SetHeaderText("New header text"); // définir le texte de l’espace réservé d’en‑tête de la diapositive de notes
		headerFooterManager.SetFooterText("New footer text"); // définir le texte de l’espace réservé de pied de page de la diapositive de notes
		headerFooterManager.SetDateTimeText("New date and time text"); // définir le texte de l’espace réservé de date‑heure de la diapositive de notes
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
        
 }
```


## **FAQ**

**Puis‑je ajouter un « en‑tête » aux diapositives ordinaires ?**

Dans PowerPoint, l’« en‑tête » n’existe que pour les notes et les documents ; sur les diapositives ordinaires, les éléments pris en charge sont le pied de page, la date/heure et le numéro de diapositive. Dans Aspose.Slides cela reflète les mêmes limitations : en‑tête uniquement pour les notes/document, et sur les diapositives — pied de page/date‑heure/numéro de diapositive.

**Si la disposition ne contient pas de zone de pied de page, puis‑je « activer » sa visibilité ?**

Oui. Vérifiez la visibilité via le gestionnaire d’en‑tête/pied de page et activez‑la si nécessaire. Ces indicateurs et méthodes d’API sont conçus pour les cas où l’espace réservé est manquant ou masqué.

**Comment faire commencer la numérotation des diapositives à une valeur autre que 1 ?**

Définissez le [numéro de première diapositive] (https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) de la présentation ; ensuite, toute la numérotation est recalculée. Par exemple, vous pouvez commencer à 0 ou 10, et masquer le numéro sur la diapositive de titre.

**Que se passe‑t‑il avec les en‑têtes/pieds de page lors de l’exportation en PDF/images/HTML ?**

Ils sont rendus comme des éléments de texte ordinaires de la présentation. Ainsi, si les éléments sont visibles sur les diapositives ou les pages de notes, ils apparaîtront également dans le format de sortie avec le reste du contenu.