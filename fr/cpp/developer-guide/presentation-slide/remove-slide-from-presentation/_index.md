---
title: Supprimer une diapositive de la présentation
type: docs
weight: 30
url: /fr/cpp/remove-slide-from-presentation/
keywords: "Supprimer diapositive, Delete slide, PowerPoint, Présentation, C++, Aspose.Slides"
description: "Supprimer une diapositive de PowerPoint par référence ou index en C++"

---

Si une diapositive (ou son contenu) devient redondante, vous pouvez la supprimer. Aspose.Slides fournit la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) qui encapsule [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/), qui est un dépôt pour toutes les diapositives d'une présentation. En utilisant des pointeurs (référence ou index) pour un objet [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/), vous pouvez spécifier la diapositive que vous souhaitez supprimer.

## **Supprimer une diapositive par référence**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez une référence de la diapositive que vous souhaitez supprimer via son ID ou son index.
1. Supprimez la diapositive référencée de la présentation.
1. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment supprimer une diapositive par sa référence :

```c++
	// Le chemin vers le répertoire des documents
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Instancie un objet Presentation qui représente un fichier de présentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Accède à une diapositive par son index dans la collection de diapositives
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Supprime une diapositive par sa référence
	pres->get_Slides()->Remove(slide);

	// Enregistre la présentation modifiée
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Supprimer une diapositive par index**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Supprimez la diapositive de la présentation par sa position index.
1. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment supprimer une diapositive par son index :

```c++
	// Le chemin vers le répertoire des documents
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Instancie un objet Presentation qui représente un fichier de présentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Supprime une diapositive par son index de diapositive
	pres->get_Slides()->RemoveAt(0);

	// Enregistre la présentation modifiée
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Supprimer une diapositive de disposition inutilisée**

Aspose.Slides fournit la méthode [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (de la classe [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) pour vous permettre de supprimer des diapositives de disposition indésirables et inutilisées. Ce code C++ vous montre comment supprimer une diapositive de disposition d'une présentation PowerPoint :

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Supprimer une diapositive maîtresse inutilisée**

Aspose.Slides fournit la méthode [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la classe [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) pour vous permettre de supprimer des diapositives maîtresses indésirables et inutilisées. Ce code C++ vous montre comment supprimer une diapositive maîtresse d'une présentation PowerPoint :

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```