---
title: Mise en Page des Diapositives
type: docs
weight: 60
url: /fr/cpp/mise-en-page-des-diapositives/
keyword: "Définir la taille des diapositives, définir les options des diapositives, spécifier la taille des diapositives, visibilité du pied de page, pied de page enfant, mise à l'échelle du contenu, taille de page, C++, CPP, Aspose.Slides"
description: "Définir la taille et les options des diapositives PowerPoint en C++"
---

Une mise en page de diapositive contient les zones de remplacement et les informations de mise en forme pour tout le contenu qui apparaît sur une diapositive. La mise en page détermine les espaces réservés au contenu disponibles et où ils sont placés. 

Les mises en page de diapositives vous permettent de créer et de concevoir des présentations rapidement (qu'elles soient simples ou complexes). Voici quelques-unes des mises en page de diapositives les plus populaires utilisées dans les présentations PowerPoint : 

* **Mise en Page de Diapositive de Titre**. Cette mise en page se compose de deux espaces réservés pour du texte. Un espace réservé est pour le titre et l'autre est pour le sous-titre. 
* **Mise en Page de Titre et Contenu**. Cette mise en page contient un espace réservé relativement petit en haut pour le titre et un plus grand espace réservé pour le contenu principal (graphique, paragraphes, liste à puces, liste numérotée, images, etc).
* **Mise en Page Vide**. Cette mise en page n'a pas d'espaces réservés, ce qui vous permet de créer des éléments à partir de zéro. 

Étant donné qu'une maîtrise de diapositive est la diapositive hiérarchique principale qui stocke des informations sur les mises en page de diapositives, vous pouvez utiliser la diapositive maître pour accéder aux mises en page de diapositives et y apporter des modifications. Une mise en page de diapositive peut être accédée par type ou par nom. De même, chaque diapositive a un identifiant unique, qui peut être utilisé pour y accéder. 

Alternativement, vous pouvez apporter des modifications directement à une mise en page de diapositive spécifique dans une présentation. 

* Pour vous permettre de travailler avec des mises en page de diapositives (y compris celles des diapositives maîtresses), Aspose.Slides fournit des propriétés comme [get_LayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) et [get_Masters()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) sous la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). 
* Pour effectuer des tâches connexes, Aspose.Slides fournit [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/baseslideheaderfootermanager/), et de nombreux autres types. 

{{% alert title="Info" color="info" %}}

Pour plus d'informations sur le travail avec les diapositives maîtresses en particulier, consultez l'article [Maître de Diapositive](https://docs.aspose.com/slides/cpp/slide-master/).

{{% /alert %}}

## **Ajouter une Mise en Page de Diapositive à la Présentation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Accédez à la [collection MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Parcourez les diapositives de mise en page existantes pour confirmer que la mise en page requise existe déjà dans la collection de diapositives de mise en page. Sinon, ajoutez la diapositive de mise en page souhaitée. 
1. Ajoutez une diapositive vide basée sur la nouvelle diapositive de mise en page.
1. Enregistrez la présentation. 

Ce code C++ vous montre comment ajouter une mise en page de diapositive à une présentation PowerPoint :

```c++
	// Le chemin vers le répertoire des documents.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/AddLayoutSlides.pptx";

	// Instancie une classe Presentation qui représente le fichier de présentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	// Parcourt les types de diapositives de mise en page
	SharedPtr<IMasterLayoutSlideCollection> layoutSlides = pres->get_Masters()->idx_get(0)->get_LayoutSlides();


	SharedPtr<ILayoutSlide> layoutSlide;
	if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != NULL)
	{
		layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
	}
	else if (layoutSlides->GetByType(SlideLayoutType::Title) != NULL)
	{
		layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
	}

	if (layoutSlide == NULL)
	{
		// La situation où une présentation ne contient pas certains types de mise en page.
		// Le fichier de présentation ne contient que des types de mise en page vides et personnalisés.
		// Mais les diapositives de mise en page avec des types personnalisés ont des noms de diapositive différents,
		// comme "Titre", "Titre et Contenu", etc. Et il est possible d'utiliser ces
		// noms pour la sélection de la diapositive de mise en page.
		// Vous pouvez également utiliser un ensemble de types de formes d'espace réservé. Par exemple,
		// La diapositive de titre ne doit avoir que le type d'espace réservé pour le titre, etc.

		for (int i = 0; i<layoutSlides->get_Count(); i++)
		{
			SharedPtr<ILayoutSlide> titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

			if (titleAndObjectLayoutSlide->get_Name().Equals(u"Titre et Objet"))
			{
				layoutSlide = titleAndObjectLayoutSlide;
				break;
			}
		}

		if (layoutSlide == NULL)
		{
			for (int i = 0; i < layoutSlides->get_Count(); i++)
			{
				SharedPtr<ILayoutSlide> titleLayoutSlide = layoutSlides->idx_get(i);

				if (titleLayoutSlide->get_Name().Equals(u"Titre"))
				{
					layoutSlide = titleLayoutSlide;
					break;
				}
			}

			if (layoutSlide == NULL)
			{
				layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
				if (layoutSlide == NULL)
				{
					layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Titre et Objet");
				}
			}
		}
	}

	// Ajoute une diapositive vide avec la diapositive de mise en page ajoutée  
	pres->get_Slides()->InsertEmptySlide(0, layoutSlide);

	// Enregistre la présentation sur le disque
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Supprimer une Diapositive de Mise en Page Non Utilisée**

Aspose.Slides fournit la méthode [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) de la classe [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) pour vous permettre de supprimer les diapositives de mise en page indésirables et non utilisées. Ce code C++ vous montre comment supprimer une diapositive de mise en page d'une présentation PowerPoint :

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);

```


## **Définir la Taille et le Type pour une Mise en Page de Diapositive**

Pour vous permettre de définir la taille et le type pour une diapositive de mise en page spécifique, Aspose.Slides fournit les propriétés [get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/) et [get_Size()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_size/) (de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)). Ce C++ illustre l'opération :

```c++
	// Le chemin vers le répertoire des documents.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/CloneToAnotherPresentationWithSetSizeAndType.pptx";
	// Instancie un objet Presentation qui représente un fichier de présentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	SharedPtr<Presentation> destPres = MakeObject<Presentation>();

	// Accède à la diapositive par ID depuis la collection
	SharedPtr<ISlideCollection> slideCollection = destPres->get_Slides();
	
	// Définit la taille de la diapositive pour la présentation générée à celle de la source
	destPres->get_SlideSize()->SetSize(pres->get_SlideSize()->get_Type(), Aspose::Slides::SlideSizeScaleType::DoNotScale);

	slideCollection->InsertClone(1, pres->get_Slides()->idx_get(0));

	// Enregistre la présentation sur le disque
	destPres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Définir la Visibilité du Pied de Page à l'Intérieur de la Diapositive**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Réglez l'espace réservé pour le pied de page de la diapositive sur visible. 
1. Réglez l'espace réservé pour la date-heure sur visible. 
1. Enregistrez la présentation. 

Ce code C++ vous montre comment définir la visibilité pour un pied de page de diapositive (et effectuer des tâches connexes) :

```c++
 // Le chemin vers le répertoire des documents.
const String outPath = u"../out/HeaderFooterManager_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// Instancie une classe SlideCollection
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

//	SharedPtr<IBaseSlideHeaderFooterManager> headerFooterManager = presentation->get_Slides()->idx_get(0)->get_HeaderFooterManager();
SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
if (!headerFooterManager->get_IsFooterVisible()) // La propriété IsFooterVisible est utilisée pour indiquer qu'un espace réservé pour le pied de page de diapositive est manquant
{
	headerFooterManager->SetFooterVisibility(true); // La méthode SetFooterVisibility est utilisée pour définir un espace réservé pour le pied de page de diapositive sur visible
}
if (!headerFooterManager->get_IsSlideNumberVisible()) // La propriété IsSlideNumberVisible est utilisée pour indiquer qu'un espace réservé pour le numéro de diapositive est manquant
{
	headerFooterManager->SetSlideNumberVisibility(true); // La méthode SetSlideNumberVisibility est utilisée pour définir un espace réservé pour le numéro de diapositive sur visible
}
if (!headerFooterManager->get_IsDateTimeVisible()) // La propriété IsDateTimeVisible est utilisée pour indiquer qu'un espace réservé pour la date-heure est manquant
{
	headerFooterManager->SetDateTimeVisibility(true); // La méthode SetFooterVisibility est utilisée pour définir un espace réservé pour la date-heure sur visible
}
headerFooterManager->SetFooterText(u"Texte du pied de page"); // La méthode SetFooterText est utilisée pour définir un texte pour un espace réservé de pied de page de diapositive
headerFooterManager->SetDateTimeText(u"Texte de date et heure"); // La méthode SetDateTimeText est utilisée pour définir un texte pour un espace réservé de date-heure de diapositive.


// Enregistre la présentation sur le disque
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Définir la Visibilité du Pied de Page Enfant à l'Intérieur de la Diapositive**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez une référence pour la diapositive maître par son index. 
1. Définissez la diapositive maître et tous les espaces réservés pour les pieds de page enfant sur visible.
1. Définissez un texte pour la diapositive maître et tous les espaces réservés pour les pieds de page enfant. 
1. Définissez un texte pour la diapositive maître et tous les espaces réservés pour la date-heure enfant. 
1. Enregistrez la présentation. 

Ce code C++ illustre l'opération :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/SetChildFooter_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// Instancie une classe SlideCollection
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true); // La méthode SetFooterAndChildFootersVisibility est utilisée pour définir la diapositive maître et tous les espaces réservés pour les pieds de page enfant sur visible
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true); // La méthode SetSlideNumberAndChildSlideNumbersVisibility est utilisée pour définir la diapositive maître et tous les espaces réservés pour les numéros de page enfant sur visible
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true); // La méthode SetDateTimeAndChildDateTimesVisibility est utilisée pour définir une diapositive maître et tous les espaces réservés pour la date-heure enfant sur visible

headerFooterManager->SetFooterAndChildFootersText(u"Texte du pied de page"); // La méthode SetFooterAndChildFootersText est utilisée pour définir des textes pour la diapositive maître et tous les espaces réservés pour les pieds de page enfant
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Texte de date et heure"); // La méthode SetDateTimeAndChildDateTimesText est utilisée pour définir un texte pour la diapositive maître et tous les espaces réservés pour la date-heure enfant

presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Définir la Taille de la Diapositive par Rapport à la Mise à l'Échelle du Contenu**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et chargez la présentation contenant la diapositive dont vous souhaitez définir la taille. 
1. Créez une autre instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) pour générer une nouvelle présentation. 
1. Obtenez la référence à la diapositive (de la première présentation) par son index.
1. Réglez l'espace réservé pour le pied de page sur visible. 
1. Réglez l'espace réservé pour la date-heure sur visible. 
1. Enregistrez la présentation. 

Ce code C++ illustre l'opération : 

```c++
// Le chemin vers le répertoire des documents.
const String templatePath = u"../templates/AccessSlides.pptx";
const String outPath = u"../out/SetSlideSizeScale_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);
SharedPtr<Presentation> auxPresentation = MakeObject<Presentation>();

// Instancie une classe SlideCollection
SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);

// Définit la taille de la diapositive pour les présentations générées à celle de la source
auxPresentation->get_SlideSize()->SetSize(540, 720, SlideSizeScaleType::EnsureFit); // La méthode SetSize est utilisée pour définir la taille de la diapositive avec une mise à l'échelle du contenu pour garantir l'ajustement
auxPresentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize); // La méthode SetSize est utilisée pour définir la taille de la diapositive avec la taille maximale du contenu

auxPresentation->get_Slides()->InsertClone(0, slide);
auxPresentation->get_Slides()->RemoveAt(0);

// Enregistre la présentation
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Définir la Taille de Page lors de la Génération de PDF**

Certaines présentations (comme des affiches) sont souvent converties en documents PDF. Si vous souhaitez convertir votre PowerPoint en PDF pour accéder aux meilleures options d'impression et d'accessibilité, vous souhaitez définir vos diapositives à des tailles adaptées aux documents PDF (A4, par exemple).

Aspose.Slides fournit la classe [SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/) pour vous permettre de spécifier vos paramètres préférés pour les diapositives. Ce code C++ vous montre comment utiliser la propriété [get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/) (de la classe `SlideSize`) pour définir une taille de papier spécifique pour les diapositives dans une présentation :

```c++
// Le chemin vers le répertoire des documents.
	const String outPath = u"../out/SetPDFPageSize_out.pptx";

	// Instancie un objet Presentation qui représente un fichier de présentation 
	SharedPtr<Presentation>pres = MakeObject<Presentation>();

	// Définit la propriété SlideSize.Type 
	pres->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);

	// Définit différentes propriétés des options PDF
	Aspose::Slides::Export::PdfOptions opts = Aspose::Slides::Export::PdfOptions();
	opts.set_SufficientResolution (600);

	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pdf, &opts);
```