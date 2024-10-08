---
title: En-tête et Pied de Page de Présentation
type: docs
weight: 140
url: /fr/net/presentation-header-and-footer/
keywords: "En-tête, pied de page, définir en-tête, définir pied de page, définir en-tête et pied de page, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "En-tête et pied de page PowerPoint en C# ou .NET"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/fr/net/) fournit un support pour travailler avec le texte des en-têtes et pieds de page des diapositives qui sont en fait maintenus au niveau du maître de diapositive.

{{% /alert %}} 

[Aspose.Slides pour .NET](/slides/fr/net/) fournit la fonctionnalité de gestion des en-têtes et pieds de page à l'intérieur des diapositives de présentation. Ceux-ci sont en fait gérés au niveau du maître de présentation.
## **Gérer le Texte de l'En-tête et du Pied de Page**
Les notes d'une diapositive spécifique peuvent être mises à jour comme indiqué dans l'exemple ci-dessous :

```c#
// Charger la Présentation
Presentation pres = new Presentation("headerTest.pptx");

// Définir le Pied de Page
pres.HeaderFooterManager.SetAllFootersText("Mon texte de pied de page");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Accéder et Mettre à Jour l'En-tête
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Enregistrer la présentation
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// Méthode pour définir le Texte de l'En-tête/Pied de Page
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "Salut nouveau en-tête";
            }
        }
    }
}
```




## **Gérer l'En-tête et le Pied de Page dans les Diapositives de Remise et de Notes**
Aspose.Slides pour .NET prend en charge les En-têtes et Pieds de Page dans les diapositives de remise et de notes. Veuillez suivre les étapes ci-dessous :

- Charger une [Présentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant une vidéo.
- Changer les paramètres d'En-tête et de Pied de Page pour le maître de notes et toutes les diapositives de notes.
- Rendre visible le maître de notes et tous les espaces réservés de Pied de Page enfants.
- Rendre visible le maître de notes et tous les espaces réservés de date et d'heure enfants.
- Changer les paramètres d'En-tête et de Pied de Page uniquement pour la première diapositive de notes.
- Rendre visible l'espace réservé de l'En-tête de la diapositive de notes.
- Définir le texte pour l'espace réservé de l'En-tête de la diapositive de notes.
- Définir le texte pour l'espace réservé de date et heure de la diapositive de notes.
- Écrire le fichier de présentation modifié.

Extrait de code fourni dans l'exemple ci-dessous.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Changer les paramètres d'En-tête et de Pied de Page pour le maître de notes et toutes les diapositives de notes
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // rendre visible le maître de notes et tous les espaces réservés de Pied de Page enfants
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // rendre visible le maître de notes et tous les espaces réservés d'En-tête enfants
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // rendre visible le maître de notes et tous les espaces réservés de numéros de diapositive enfants
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // rendre visible le maître de notes et tous les espaces réservés de date et d'heure enfants

		headerFooterManager.SetHeaderAndChildHeadersText("Texte de l'en-tête"); // définir le texte pour le maître de notes et tous les espaces réservés d'En-tête enfants
		headerFooterManager.SetFooterAndChildFootersText("Texte du pied de page"); // définir le texte pour le maître de notes et tous les espaces réservés de Pied de Page enfants
		headerFooterManager.SetDateTimeAndChildDateTimesText("Texte de date et d'heure"); // définir le texte pour le maître de notes et tous les espaces réservés de date et d'heure enfants
	}

	// Changer les paramètres d'En-tête et de Pied de Page uniquement pour la première diapositive de notes
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // rendre visible cet espace réservé d'En-tête de la diapositive de notes

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // rendre visible cet espace réservé de Pied de Page de la diapositive de notes

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // rendre visible cet espace réservé de Numéro de Diapositive de la diapositive de notes

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // rendre visible cet espace réservé de Date-heure de la diapositive de notes

		headerFooterManager.SetHeaderText("Nouveau texte d'en-tête"); // définir le texte pour l'espace réservé d'En-tête de la diapositive de notes
		headerFooterManager.SetFooterText("Nouveau texte de pied de page"); // définir le texte pour l'espace réservé de Pied de Page de la diapositive de notes
		headerFooterManager.SetDateTimeText("Nouveau texte de date et d'heure"); // définir le texte pour l'espace réservé de Date-heure de la diapositive de notes
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```