---
title: Accéder aux diapositives de présentation en C++
linktitle: Accéder à la diapositive
type: docs
weight: 20
url: /fr/cpp/access-slide-in-presentation/
keywords:
- accéder à la diapositive
- indice de diapositive
- ID de diapositive
- position de diapositive
- modifier la position
- propriétés de diapositive
- numéro de diapositive
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez à accéder et à gérer les diapositives dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour C++. Augmentez votre productivité grâce à des exemples de code."
---

Aspose.Slides vous permet d’accéder aux diapositives de deux manières : par indice et par ID.

## **Accéder à une diapositive par indice**

Toutes les diapositives d’une présentation sont organisées numériquement selon la position de la diapositive en commençant par 0. La première diapositive est accessible via l’indice 0 ; la deuxième via l’indice 1 ; etc.

La classe Presentation, qui représente un fichier de présentation, expose toutes les diapositives sous forme d’une collection [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) (collection d’objets [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) ). Ce code C++ vous montre comment accéder à une diapositive par son indice :
```c++
	// Le chemin vers le répertoire des documents.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instancie la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtient une référence à une diapositive via son indice
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```


## **Accéder à une diapositive par ID**

Chaque diapositive d’une présentation possède un ID unique qui lui est associé. Vous pouvez utiliser la méthode [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) (exposée par la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)) pour cibler cet ID. Ce code C++ vous montre comment fournir un ID de diapositive valide et accéder à cette diapositive via la méthode [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) :
```c++
	// Le chemin vers le répertoire des documents.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instancie la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtient l'ID d'une diapositive
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Accède à la diapositive via son ID
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```


## **Modifier la position d’une diapositive**

Aspose.Slides vous permet de modifier la position d’une diapositive. Par exemple, vous pouvez spécifier que la première diapositive devienne la deuxième.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive (dont vous voulez changer la position) via son indice.
1. Définissez une nouvelle position pour la diapositive via la propriété [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/).
1. Enregistrez la présentation modifiée.

Ce code C++ montre une opération où la diapositive en position 1 est déplacée en position 2 :
```c++
	// Le chemin vers le répertoire des documents.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Instancie la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtient la diapositive dont la position sera modifiée
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Définit la nouvelle position de la diapositive
	slide->set_SlideNumber(2);

	// Enregistre la présentation modifiée
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


La première diapositive est devenue la deuxième ; la deuxième diapositive est devenue la première. Lorsque vous modifiez la position d’une diapositive, les autres diapositives sont automatiquement ajustées.

## **Définir le numéro de diapositive**

En utilisant la propriété [set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) (exposée par la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)), vous pouvez spécifier un nouveau numéro pour la première diapositive d’une présentation. Cette opération entraîne le recalcul des numéros des autres diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez le numéro de la diapositive.
1. Définissez le numéro de la diapositive.
1. Enregistrez la présentation modifiée.

Ce code C++ montre une opération où le numéro de la première diapositive est fixé à 10 :
```c++
	// Le chemin vers le répertoire des documents.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Instancie la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtient le numéro de la diapositive
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Définit le numéro de la diapositive
	pres->set_FirstSlideNumber(2);
	
	// Enregistre la présentation modifiée
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


Si vous préférez ignorer la première diapositive, vous pouvez commencer la numérotation à partir de la deuxième diapositive (et masquer la numérotation pour la première) de cette manière :
```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Le numéro de diapositive affiché à l’utilisateur correspond‑il à l’indice basé sur zéro de la collection ?**

Le numéro affiché sur une diapositive peut commencer à une valeur arbitraire (par ex., 10) et n’a pas besoin de correspondre à l’indice ; la relation est contrôlée par le paramètre [first slide number](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) de la présentation.

**Les diapositives masquées affectent‑elles l’indexation ?**

Oui. Une diapositive masquée reste dans la collection et est comptée dans l’indexation ; « masquée » fait référence à l’affichage, pas à sa position dans la collection.

**L’indice d’une diapositive change‑t‑il lorsque d’autres diapositives sont ajoutées ou supprimées ?**

Oui. Les indices reflètent toujours l’ordre actuel des diapositives et sont recalculés lors des opérations d’insertion, de suppression et de déplacement.