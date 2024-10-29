---
title: Accéder à la diapositive dans la présentation
type: docs
weight: 20
url: /fr/cpp/access-slide-in-presentation/
keywords: "Accéder à la présentation PowerPoint, Accéder à la diapositive, Modifier les propriétés de la diapositive, Changer la position de la diapositive, Définir le numéro de la diapositive, index, ID, position  C++, CPP, Aspose.Slides"
description: "Accéder à la diapositive PowerPoint par index, ID ou position en C++. Modifier les propriétés de la diapositive"
---

Aspose.Slides vous permet d'accéder aux diapositives de deux manières : par index et par ID.

## **Accéder à la diapositive par index**

Toutes les diapositives d'une présentation sont disposées numériquement en fonction de la position de la diapositive en commençant par 0. La première diapositive est accessible par l'index 0 ; la deuxième diapositive est accessible par l'index 1 ; etc.

La classe Presentation, représentant un fichier de présentation, expose toutes les diapositives sous forme de collection [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) (collection d'objets [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)). Ce code C++ vous montre comment accéder à une diapositive via son index : 

```c++
	// Le chemin vers le répertoire des documents.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instancie la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtient la référence d'une diapositive par son index
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Accéder à la diapositive par ID**

Chaque diapositive d'une présentation a un ID unique qui lui est associé. Vous pouvez utiliser la méthode [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) (exposée par la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)) pour cibler cet ID. Ce code C++ vous montre comment fournir un ID de diapositive valide et accéder à cette diapositive via la méthode [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) :

```c++
	// Le chemin vers le répertoire des documents.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instancie la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtient un ID de diapositive
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Accède à la diapositive par son ID
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Changer la position de la diapositive**

Aspose.Slides vous permet de changer la position d'une diapositive. Par exemple, vous pouvez spécifier que la première diapositive doit devenir la deuxième diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive (dont vous souhaitez changer la position) par son index.
1. Définissez une nouvelle position pour la diapositive via la propriété [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/).
1. Enregistrez la présentation modifiée.

Ce code C++ démontre une opération dans laquelle la diapositive à la position 1 est déplacée à la position 2 :

```c++
	// Le chemin vers le répertoire des documents.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Instancie la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtient la diapositive dont la position va être changée
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Définit la nouvelle position pour la diapositive
	slide->set_SlideNumber(2);

	// Enregistre la présentation modifiée
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

La première diapositive est devenue la deuxième ; la deuxième diapositive est devenue la première. Lorsque vous changez la position d'une diapositive, les autres diapositives sont automatiquement ajustées.

## **Définir le numéro de diapositive**

En utilisant la propriété [set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) (exposée par la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)), vous pouvez spécifier un nouveau numéro pour la première diapositive d'une présentation. Cette opération entraîne un recalcul des autres numéros de diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez le numéro de la diapositive.
1. Définissez le numéro de la diapositive.
1. Enregistrez la présentation modifiée.

Ce code C++ démontre une opération où le numéro de la première diapositive est défini sur 10 : 

```c++
	// Le chemin vers le répertoire des documents.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	// Instancie la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtient le numéro de la première diapositive
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Définit le numéro de la diapositive
	pres->set_FirstSlideNumber(2);
	
	// Enregistre la présentation modifiée
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Si vous préférez ignorer la première diapositive, vous pouvez commencer la numérotation à partir de la deuxième diapositive (et masquer la numérotation pour la première diapositive) de cette manière :

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Définit le numéro pour la première diapositive de la présentation
presentation->set_FirstSlideNumber(0);

// Affiche les numéros de diapositive pour toutes les diapositives
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Masque le numéro de diapositive pour la première diapositive
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Enregistre la présentation modifiée
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```