---
title: Extraire le texte d'une présentation
type: docs
weight: 90
url: /fr/cpp/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

Il n'est pas rare que les développeurs aient besoin d'extraire le texte d'une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes sur toutes les diapositives d'une présentation. Cet article explique comment extraire le texte des présentations Microsoft PowerPoint PPTX à l'aide d'Aspose.Slides. Le texte peut être extrait de plusieurs manières :

- [Extraire le texte d'une diapositive](/slides/fr/cpp/extracting-text-from-the-presentation/)
- [Extraire le texte en utilisant la méthode GetAllTextBoxes](/slides/fr/cpp/extracting-text-from-the-presentation/)
- [Extraction de texte catégorisée et rapide](/slides/fr/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extraire le texte d'une diapositive**
Aspose.Slides pour C++ fournit l'espace de noms Aspose.Slides.Util qui inclut la classe SlideUtil. Cette classe expose plusieurs méthodes statiques surchargées pour extraire tout le texte d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive d'une présentation PPTX, utilisez la méthode statique surchargée [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df) exposée par la classe SlideUtil. Cette méthode accepte l'objet Slide en paramètre.
Lors de son exécution, la méthode Slide scanne tout le texte de la diapositive passée en paramètre et renvoie un tableau d'objets TextFrame. Cela signifie que tout le formatage de texte associé au texte est disponible. Le morceau de code suivant extrait tout le texte de la première diapositive de la présentation :

``` cpp
// Le chemin vers le répertoire des documents.
System::String dataDir = GetDataPath();

// Instanciez la classe Presentation qui représente un fichier PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Obtenez un tableau d'objets ITextFrame de toutes les diapositives du PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Bouclez à travers le tableau de TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Bouclez à travers les paragraphes dans le ITextFrame actuel
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Bouclez à travers les portions dans le IParagraph actuel
		for (const auto& port : para->get_Portions())
		{
			// Affichez le texte dans la portion actuelle
			Console::WriteLine(port->get_Text());

			// Affichez la hauteur de la police du texte
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Affichez le nom de la police du texte
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```

## **Extraire le texte d'une présentation**
Pour scanner le texte de la présentation entière, utilisez la méthode statique [GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12) exposée par la classe SlideUtil. Elle prend deux paramètres :

1. Tout d'abord, un objet Presentation qui représente la présentation PPTX dont le texte est extrait.
1. Deuxièmement, une valeur booléenne déterminant si la diapositive maître doit être incluse lors de l'analyse du texte de la présentation.
   La méthode renvoie un tableau d'objets TextFrame, complet avec des informations de formatage du texte. Le code ci-dessous analyse le texte et les informations de formatage d'une présentation, y compris les diapositives maîtresses.

``` cpp
// Le chemin vers le répertoire des documents.
System::String dataDir = GetDataPath();

// Instanciez la classe Presentation qui représente un fichier PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Obtenez un tableau d'objets ITextFrame de toutes les diapositives du PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Bouclez à travers le tableau de TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Bouclez à travers les paragraphes dans le ITextFrame actuel
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Bouclez à travers les portions dans le IParagraph actuel
		for (const auto& port : para->get_Portions())
		{
			// Affichez le texte dans la portion actuelle
			Console::WriteLine(port->get_Text());

			// Affichez la hauteur de la police du texte
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Affichez le nom de la police du texte
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```

## **Extraction de texte catégorisée et rapide**
La nouvelle méthode statique GetPresentationText a été ajoutée à la classe Presentation. Il y a deux surcharges pour cette méthode :

``` cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode) override
 
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode) override
```

L'argument enum TextExtractionArrangingMode indique le mode d'organisation du résultat de texte et peut être défini sur les valeurs suivantes :  
Non organisé - Le texte brut sans tenir compte de la position sur la diapositive  
Organisé - Le texte est positionné dans le même ordre que sur la diapositive

Le mode non organisé peut être utilisé lorsque la rapidité est critique, il est plus rapide que le mode organisé.

PresentationText représente le texte brut extrait de la présentation. Il contient une méthode get_SlidesText() de l'espace de noms Aspose.Slides.Util qui renvoie un tableau d'objets ISlideText. Chaque objet représente le texte sur la diapositive correspondante. L'objet ISlideText a les méthodes suivantes :

get_Text() - Le texte sur les formes de la diapositive.  
get_MasterText() - Le texte sur les formes de la page maître pour cette diapositive.  
get_LayoutText() - Le texte sur les formes de la page de mise en page pour cette diapositive.  
get_NotesText() - Le texte sur les formes de la page de notes pour cette diapositive.

Il existe également une classe SlideText qui implémente l'interface ISlideText.

La nouvelle API peut être utilisée comme ceci :

``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```