---
title: Gérer les en-têtes et pieds de page de la présentation en C++
linktitle: En-tête et pied de page
type: docs
weight: 140
url: /fr/cpp/presentation-header-and-footer/
keywords:
- en-tête
- texte d'en-tête
- pied de page
- texte de pied de page
- définir l'en-tête
- définir le pied de page
- version imprimée
- notes
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Utilisez Aspose.Slides for C++ pour ajouter et personnaliser les en-têtes et pieds de page dans les présentations PowerPoint et OpenDocument afin d'obtenir un aspect professionnel."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/fr/cpp/) fournit la prise en charge de la gestion du texte des en-têtes et pieds de page des diapositives, qui sont en fait maintenus au niveau du masque des diapositives.

{{% /alert %}} 

[Aspose.Slides for C++](/slides/fr/cpp/) offre la fonctionnalité de gestion des en-têtes et pieds de page dans les diapositives d’une présentation. Ceux‑ci sont en fait gérés au niveau du masque de la présentation.
## **Gérer le texte d'en-tête et de pied de page**
Les notes d'une diapositive spécifique peuvent être mises à jour comme indiqué dans l'exemple ci‑dessous :
``` cpp
// Fonction pour définir le texte de l'en-tête/pied de page
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Charger la présentation
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Définir le pied de page
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
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


## **Gérer les en-têtes et pieds de page sur les diapositives de version imprimée et de notes**
Aspose.Slides for C++ prend en charge les en‑têtes et pieds de page dans les diapositives de version imprimée et les notes. Veuillez suivre les étapes ci‑dessous :

- Charger une [Presentation ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) contenant une vidéo.
- Modifier les paramètres d’en‑tête et de pied de page pour le masque des notes et toutes les diapositives de notes.
- Rendre visibles les espaces réservés du pied de page du masque des notes et de toutes les diapositives enfants.
- Rendre visibles les espaces réservés de date et d’heure du masque des notes et de toutes les diapositives enfants.
- Modifier les paramètres d’en‑tête et de pied de page uniquement pour la première diapositive de notes.
- Rendre visible l’espace réservé de l’en‑tête de la diapositive de notes.
- Définir le texte de l’espace réservé de l’en‑tête de la diapositive de notes.
- Définir le texte de l’espace réservé de date‑heure de la diapositive de notes.
- Enregistrer le fichier de présentation modifié.

Extrait de code fourni dans l’exemple ci‑dessous.
``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Modifier les paramètres d'en-tête et de pied de page pour le masque des notes et toutes les diapositives de notes
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// rendre visible la diapositive maître des notes et tous les espaces réservés du pied de page enfants
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// rendre visible la diapositive maître des notes et tous les espaces réservés de l'en-tête enfants
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// rendre visible la diapositive maître des notes et tous les espaces réservés du numéro de diapositive enfants
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// rendre visible la diapositive maître des notes et tous les espaces réservés de la date et heure enfants
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// définir le texte de la diapositive maître des notes et de tous les espaces réservés d'en-tête enfants
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// définir le texte de la diapositive maître des notes et de tous les espaces réservés de pied de page enfants
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// définir le texte de la diapositive maître des notes et de tous les espaces réservés de date et heure enfants
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Modifier les paramètres d'en-tête et de pied de page pour la première diapositive de notes uniquement
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// rendre visible cet espace réservé d'en-tête de la diapositive de notes
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// rendre visible cet espace réservé de pied de page de la diapositive de notes
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// rendre visible cet espace réservé de numéro de diapositive de la diapositive de notes
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// rendre visible cet espace réservé de date-heure de la diapositive de notes
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// définir le texte de l'espace réservé d'en-tête de la diapositive de notes
	headerFooterManager->SetHeaderText(u"New header text");
	// définir le texte de l'espace réservé de pied de page de la diapositive de notes
	headerFooterManager->SetFooterText(u"New footer text");
	// définir le texte de l'espace réservé de date-heure de la diapositive de notes
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Puis‑je ajouter un « en‑tête » aux diapositives normales ?**

Dans PowerPoint, l’« en‑tête » existe uniquement pour les notes et les versions imprimées ; sur les diapositives normales, les éléments pris en charge sont le pied de page, la date/heure et le numéro de diapositive. Dans Aspose.Slides, cela correspond aux mêmes limites : en‑tête uniquement pour les notes/version imprimée, et sur les diapositives — pied de page/date‑heure/numéro de diapositive.

**Que se passe‑t‑il si la disposition ne contient pas de zone de pied de page — puis‑je « activer » sa visibilité ?**

Oui. Vérifiez la visibilité via le gestionnaire d’en‑tête/pied de page et activez‑la si nécessaire. Ces indicateurs et méthodes de l’API sont conçus pour les cas où l’espace réservé est manquant ou masqué.

**Comment faire commencer la numérotation des diapositives à une valeur autre que 1 ?**

Définissez le [numéro de première diapositive](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) de la présentation ; après cela, toute la numérotation est recalculée. Par exemple, vous pouvez commencer à 0 ou 10, et masquer le numéro sur la diapositive de titre.

**Que devient les en‑têtes/pieds de page lors de l’exportation en PDF/images/HTML ?**

Ils sont rendus comme des éléments de texte ordinaires de la présentation. Ainsi, si les éléments sont visibles sur les diapositives ou les pages de notes, ils apparaîtront également dans le format de sortie avec le reste du contenu.