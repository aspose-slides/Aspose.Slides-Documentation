---
title: Extraction avancée de texte à partir de présentations en C++
linktitle: Extraire le texte
type: docs
weight: 90
url: /fr/cpp/extract-text-from-presentation/
keywords:
- extraire le texte
- extraire le texte d'une diapositive
- extraire le texte d'une présentation
- extraire le texte de PowerPoint
- extraire le texte d'OpenDocument
- extraire le texte de PPT
- extraire le texte de PPTX
- extraire le texte d'ODP
- récupérer le texte
- récupérer le texte d'une diapositive
- récupérer le texte d'une présentation
- récupérer le texte de PowerPoint
- récupérer le texte d'OpenDocument
- récupérer le texte de PPT
- récupérer le texte de PPTX
- récupérer le texte d'ODP
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Extrayez rapidement le texte des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour C++. Suivez notre guide simple, étape par étape, pour gagner du temps."
---

{{% alert color="primary" %}} 

Il n’est pas rare que les développeurs aient besoin d’extraire le texte d’une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes de toutes les diapositives d’une présentation. Cet article explique comment extraire le texte des présentations Microsoft PowerPoint PPTX à l’aide d’Aspose.Slides. Le texte peut être extrait de la façon suivante :

- [Extraction du texte d’une diapositive](/slides/fr/cpp/extracting-text-from-the-presentation/)
- [Extraction du texte avec la méthode GetAllTextBoxes](/slides/fr/cpp/extracting-text-from-the-presentation/)
- [Extraction du texte, catégorisée et rapide](/slides/fr/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extraire du texte d’une diapositive**
Aspose.Slides for C++ fournit l’espace de noms Aspose.Slides.Util qui comprend la classe SlideUtil. Cette classe expose un certain nombre de méthodes statiques surchargées pour extraire le texte complet d’une présentation ou d’une diapositive. Pour extraire le texte d’une diapositive dans une présentation PPTX, utilisez la méthode statique surchargée [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df) exposée par la classe SlideUtil. Cette méthode accepte l’objet Slide en tant que paramètre. Lors de l’exécution, la méthode Slide parcourt tout le texte de la diapositive passée en paramètre et renvoie un tableau d’objets TextFrame. Cela signifie que tout formatage du texte associé est disponible. Le fragment de code suivant extrait tout le texte de la première diapositive de la présentation :
``` cpp
// Le chemin du répertoire des documents.
System::String dataDir = GetDataPath();

// Instancier la classe Presentation qui représente un fichier PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Récupérer un tableau d'objets ITextFrame à partir de toutes les diapositives du PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Parcourir le tableau de TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Parcourir les paragraphes du ITextFrame actuel
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Parcourir les portions du IParagraph actuel
		for (const auto& port : para->get_Portions())
		{
			// Afficher le texte de la portion actuelle
			Console::WriteLine(port->get_Text());

			// Afficher la hauteur de la police du texte
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Afficher le nom de la police du texte
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```


## **Extraire du texte d’une présentation**
Pour analyser le texte de l’ensemble de la présentation, utilisez la méthode statique [GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12) exposée par la classe SlideUtil. Elle prend deux paramètres :

1. D’abord, un objet Presentation qui représente la présentation PPTX dont le texte est extrait.
2. Deuxièmement, une valeur booléenne déterminant si la diapositive maître doit être incluse lors de l’analyse du texte de la présentation.  
   La méthode renvoie un tableau d’objets TextFrame, complet avec les informations de formatage du texte. Le code ci‑dessous analyse le texte et les informations de formatage d’une présentation, y compris les diapositives maîtres.
``` cpp
// Le chemin du répertoire des documents.
System::String dataDir = GetDataPath();

// Instancier la classe Presentation qui représente un fichier PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Récupérer un tableau d'objets ITextFrame à partir de toutes les diapositives du PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Parcourir le tableau de TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Parcourir les paragraphes du ITextFrame actuel
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Parcourir les portions du IParagraph actuel
		for (const auto& port : para->get_Portions())
		{
			// Afficher le texte de la portion actuelle
			Console::WriteLine(port->get_Text());

			// Afficher la hauteur de la police du texte
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Afficher le nom de la police du texte
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```


## **Extraction du texte, catégorisée et rapide**
Une nouvelle méthode statique GetPresentationText a été ajoutée à la classe Presentation. Il existe deux surcharges pour cette méthode :
``` cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode) override
 
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode) override
```


L’argument d’énumération TextExtractionArrangingMode indique le mode d’organisation du résultat textuel et peut être défini sur les valeurs suivantes :
Unarranged - Le texte brut sans tenir compte de la position sur la diapositive  
Arranged - Le texte est disposé dans le même ordre que sur la diapositive

Le mode Unarranged peut être utilisé lorsque la rapidité est cruciale, il est plus rapide que le mode Arranged.

PresentationText représente le texte brut extrait de la présentation. Il contient une méthode get_SlidesText() de l’espace de noms Aspose.Slides.Util qui renvoie un tableau d’objets ISlideText. Chaque objet représente le texte de la diapositive correspondante. L’objet ISlideText possède les méthodes suivantes :

get_Text() - Le texte des formes de la diapositive.  
get_MasterText() - Le texte des formes de la page maître pour cette diapositive.  
get_LayoutText() - Le texte des formes de la page de mise en page pour cette diapositive.  
get_NotesText() - Le texte des formes de la page de notes pour cette diapositive.

Il existe également une classe SlideText qui implémente l’interface ISlideText.

La nouvelle API peut être utilisée comme suit :
``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```


## **FAQ**

**Quelle est la vitesse d’Aspose.Slides lors du traitement de grandes présentations pendant l’extraction de texte ?**  
Aspose.Slides est optimisé pour des performances élevées et traite efficacement même les grandes présentations, ce qui le rend adapté aux scénarios de traitement en temps réel ou par lots.

**Aspose.Slides peut‑il extraire le texte des tableaux et des graphiques dans les présentations ?**  
Oui, Aspose.Slides prend entièrement en charge l’extraction de texte à partir de tableaux, de graphiques et d’autres éléments de diapositive complexes, vous permettant d’accéder et d’analyser facilement tout le contenu textuel.

**Ai‑je besoin d’une licence spéciale Aspose.Slides pour extraire le texte des présentations ?**  
Vous pouvez extraire le texte avec la version d’essai gratuite d’Aspose.Slides, bien qu’elle présente certaines limitations, comme le traitement d’un nombre limité de diapositives. Pour une utilisation illimitée et pour gérer de plus grandes présentations, il est recommandé d’acheter une licence complète.