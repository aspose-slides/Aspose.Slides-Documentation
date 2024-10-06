---
title: En-tête et pied de page de présentation
type: docs
weight: 140
url: /cpp/presentation-header-and-footer/
keywords: "En-tête et pied de page dans PowerPoint"
description: "En-tête et pied de page dans PowerPoint avec Aspose.Slides."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/cpp/) fournit une prise en charge pour travailler avec le texte des en-têtes et des pieds de page qui sont en fait maintenus au niveau du maître de diapositives.

{{% /alert %}} 

[Aspose.Slides pour C++](/slides/cpp/) fournit la fonctionnalité pour gérer les en-têtes et pieds de page à l'intérieur des diapositives de présentation. Ceux-ci sont en fait gérés au niveau du maître de présentation.
## **Gérer le texte des en-têtes et des pieds de page**
Les notes d'une diapositive spécifique peuvent être mises à jour comme montré dans l'exemple ci-dessous :

``` cpp
// Fonction pour définir le texte de l'en-tête / du pied de page
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"Salut, nouveau en-tête");
            }
        }
    }
}
```

``` cpp
// Charger la présentation
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Définir le pied de page
pres->get_HeaderFooterManager()->SetAllFootersText(u"Mon texte de pied de page");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Accéder et mettre à jour l'en-tête
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Enregistrer la présentation
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **Gérer l'en-tête et le pied de page dans les diapositives de remise et de notes**
Aspose.Slides pour C++ prend en charge les en-têtes et pieds de page dans les diapositives de remise et de notes. Veuillez suivre les étapes ci-dessous :

- Charger une [présentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) contenant une vidéo.
- Modifier les paramètres d'en-tête et de pied de page pour le maître de notes et toutes les diapositives de notes.
- Rendre la diapositive de notes maître et tous les espaces réservés pour les pieds de page visibles.
- Rendre la diapositive de notes maître et tous les espaces réservés pour la date et l'heure visibles.
- Modifier les paramètres d'en-tête et de pied de page pour la première diapositive de notes uniquement.
- Rendre l'espace réservé pour l'en-tête de la diapositive de notes visible.
- Définir le texte pour l'espace réservé de l'en-tête de la diapositive de notes.
- Définir le texte pour l'espace réservé de date-heure de la diapositive de notes.
- Écrire le fichier de présentation modifié.

Extrait de code fourni dans l'exemple ci-dessous.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Modifier les paramètres d'en-tête et de pied de page pour le maître de notes et toutes les diapositives de notes
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// rendre visible la diapositive de notes maître et tous les espaces réservés pour les pieds de page
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// rendre visible la diapositive de notes maître et tous les espaces réservés pour les en-têtes
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// rendre visible la diapositive de notes maître et tous les espaces réservés pour les numéros de diapositives
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// rendre visible la diapositive de notes maître et tous les espaces réservés pour la date et l'heure
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// définir le texte pour la diapositive de notes maître et tous les espaces réservés pour les en-têtes
	headerFooterManager->SetHeaderAndChildHeadersText(u"Texte de l'en-tête");
	// définir le texte pour la diapositive de notes maître et tous les espaces réservés pour les pieds de page
	headerFooterManager->SetFooterAndChildFootersText(u"Texte du pied de page");
	// définir le texte pour la diapositive de notes maître et tous les espaces réservés pour la date et l'heure
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Texte de la date et de l'heure");
}

// Modifier les paramètres d'en-tête et de pied de page pour la première diapositive de notes uniquement
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// rendre cet espace réservé d'en-tête de diapositive de notes visible
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// rendre cet espace réservé de pied de page de diapositive de notes visible
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// rendre cet espace réservé de numéro de diapositive de notes visible
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// rendre cet espace réservé de date-heure de diapositive de notes visible
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// définir le texte pour l'espace réservé d'en-tête de la diapositive de notes
	headerFooterManager->SetHeaderText(u"Nouveau texte d'en-tête");
	// définir le texte pour l'espace réservé de pied de page de la diapositive de notes
	headerFooterManager->SetFooterText(u"Nouveau texte de pied de page");
	// définir le texte pour l'espace réservé de date-heure de la diapositive de notes
	headerFooterManager->SetDateTimeText(u"Nouveau texte de date et d'heure");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```