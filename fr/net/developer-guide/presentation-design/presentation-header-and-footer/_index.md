---
title: Gérer les en-têtes et pieds de page de la présentation dans .NET
linktitle: En-tête et pied de page
type: docs
weight: 140
url: /fr/net/presentation-header-and-footer/
keywords:
- en-tête
- texte d'en-tête
- pied de page
- texte de pied de page
- définir l'en-tête
- définir le pied de page
- support
- notes
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Utilisez Aspose.Slides pour .NET pour ajouter et personnaliser les en-têtes et pieds de page dans les présentations PowerPoint et OpenDocument afin d'obtenir un aspect professionnel."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/fr/net/) offre la prise en charge pour travailler avec le texte des en-têtes et pieds de page des diapositives qui sont réellement maintenus au niveau du maître de diapositive.

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/fr/net/) fournit la fonctionnalité de gestion des en-têtes et pieds de page à l'intérieur des diapositives de présentation. Ceux-ci sont en fait gérés au niveau du maître de la présentation.
## **Gérer le texte d'en-tête et de pied de page**
Les notes d'une diapositive spécifique peuvent être mises à jour comme le montre l'exemple ci-dessous :
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
// Méthode pour définir le texte d'en-tête et de pied de page
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





## **Gérer les en-têtes et pieds de page dans les diapositives de support et de notes**
Aspose.Slides for .NET prend en charge les en-têtes et pieds de page dans les diapositives de support et de notes. Veuillez suivre les étapes ci-dessous :

- Chargez une [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant une vidéo.
- Modifiez les paramètres d'en-tête et de pied de page pour le maître des notes et toutes les diapositives de notes.
- Rendez le maître des diapositives de notes et tous les espaces réservés de pied de page enfants visibles.
- Rendez le maître des diapositives de notes et tous les espaces réservés de date et heure enfants visibles.
- Modifiez les paramètres d'en-tête et de pied de page uniquement pour la première diapositive de notes.
- Rendez l'espace réservé d'en-tête de la diapositive de notes visible.
- Définissez le texte de l'espace réservé d'en-tête de la diapositive de notes.
- Définissez le texte de l'espace réservé de date-heure de la diapositive de notes.
- Enregistrez le fichier de présentation modifié.

Extrait de code fourni dans l'exemple ci-dessous.
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Modifier les paramètres d'en-tête et de pied de page pour le maître des notes et toutes les diapositives de notes
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // rendre la diapositive maître des notes et tous les espaces réservés de pied de page enfants visibles
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // rendre la diapositive maître des notes et tous les espaces réservés d'en-tête enfants visibles
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // rendre la diapositive maître des notes et tous les espaces réservés de numéro de diapositive enfants visibles
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // rendre la diapositive maître des notes et tous les espaces réservés de date et d'heure enfants visibles

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // définir le texte pour la diapositive maître des notes et tous les espaces réservés d'en-tête enfants
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // définir le texte pour la diapositive maître des notes et tous les espaces réservés de pied de page enfants
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // définir le texte pour la diapositive maître des notes et tous les espaces réservés de date et d'heure enfants
	}

	// Modifier les paramètres d'en-tête et de pied de page uniquement pour la première diapositive de notes
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // rendre cet espace réservé d'en-tête de diapositive de notes visible

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // rendre cet espace réservé de pied de page de diapositive de notes visible

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // rendre cet espace réservé de numéro de diapositive de notes visible

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // rendre cet espace réservé de date-heure de diapositive de notes visible

		headerFooterManager.SetHeaderText("New header text"); // définir le texte pour l'espace réservé d'en-tête de la diapositive de notes
		headerFooterManager.SetFooterText("New footer text"); // définir le texte pour l'espace réservé de pied de page de la diapositive de notes
		headerFooterManager.SetDateTimeText("New date and time text"); // définir le texte pour l'espace réservé de date-heure de la diapositive de notes
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **FAQ**

**Puis-je ajouter un "en-tête" aux diapositives normales ?**

Dans PowerPoint, l'"en-tête" n'existe que pour les notes et les supports ; sur les diapositives normales, les éléments pris en charge sont le pied de page, la date/heure et le numéro de diapositive. Dans Aspose.Slides, cela correspond aux mêmes limitations : en-tête uniquement pour les notes/les supports, et sur les diapositives - pied de page/date-heure/numéro de diapositive.

**Que se passe-t-il si la mise en page ne contient pas de zone de pied de page - puis-je "activer" sa visibilité ?**

Oui. Vérifiez la visibilité via le gestionnaire d'en-tête/pied de page et activez-la si nécessaire. Ces indicateurs et méthodes d'API sont conçus pour les cas où l'espace réservé est absent ou masqué.

**Comment faire en sorte que le numéro de diapositive commence à une valeur autre que 1 ?**

Définissez le [numéro de première diapositive](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) de la présentation ; après cela, tous les numéros sont recalculés. Par exemple, vous pouvez commencer à 0 ou 10, et masquer le numéro sur la diapositive de titre.

**Que se passe-t-il aux en-têtes/pieds de page lors de l'exportation vers PDF/images/HTML ?**

Ils sont rendus comme des éléments de texte ordinaires de la présentation. Autrement dit, si les éléments sont visibles sur les pages de diapositives/notes, ils apparaîtront également dans le format de sortie avec le reste du contenu.