---
title: Extraire le texte de la présentation
type: docs
weight: 90
url: /net/extract-text-from-presentation/
keywords: "Extraire le texte de la diapositive, Extraire le texte de PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Extraire le texte de la diapositive ou de la présentation PowerPoint en C# ou .NET"
---

{{% alert color="primary" %}} 

Il n'est pas rare que les développeurs aient besoin d'extraire le texte d'une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes sur toutes les diapositives d'une présentation. Cet article explique comment extraire le texte des présentations Microsoft PowerPoint PPTX en utilisant Aspose.Slides. Le texte peut être extrait de plusieurs manières :

- [Extraire le texte d'une diapositive](/slides/net/extracting-text-from-the-presentation/)
- [Extraire le texte en utilisant la méthode GetAllTextBoxes](/slides/net/extracting-text-from-the-presentation/)
- [Extraction de texte classée et rapide](/slides/net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extraire le texte d'une diapositive**
Aspose.Slides pour .NET fournit l'espace de noms Aspose.Slides.Util qui inclut la classe SlideUtil. Cette classe expose un certain nombre de méthodes statiques surchargées pour extraire l'intégralité du texte d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive dans une présentation PPTX, 
utilisez la méthode statique surchargée [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextboxes) exposée par la classe SlideUtil. Cette méthode accepte l'objet Slide comme paramètre. 
Lors de son exécution, la méthode Slide scanne tout le texte de la diapositive passée en paramètre et renvoie un tableau d'objets TextFrame. Cela signifie que toute mise en forme de texte associée au texte est disponible. Le code suivant extrait tout le texte de la première diapositive de la présentation :

```c#
//Instancier la classe Presentation qui représente un fichier PPTX
Presentation pptxPresentation = new Presentation("demo.pptx");

//Obtenir un tableau d'objets ITextFrame de toutes les diapositives dans le PPTX
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//Boucler à travers le tableau de TextFrames
for (int i = 0; i < textFramesPPTX.Length; i++)
{
	//Boucler à travers les paragraphes dans le ITextFrame actuel
	foreach (IParagraph para in textFramesPPTX[i].Paragraphs)
	{
		//Boucler à travers les portions dans le IParagraph actuel
		foreach (IPortion port in para.Portions)
		{
			//Afficher le texte dans la portion actuelle
			Console.WriteLine(port.Text);

			//Afficher la hauteur de police du texte
			Console.WriteLine(port.PortionFormat.FontHeight);

			//Afficher le nom de la police du texte
			if (port.PortionFormat.LatinFont != null)
				Console.WriteLine(port.PortionFormat.LatinFont.FontName);
		}
	}
}
```




## **Extraire le texte de la présentation**
Pour scanner le texte de l'ensemble de la présentation, utilisez la méthode statique [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextframes) exposée par la classe SlideUtil. Elle prend deux paramètres :

1. Tout d'abord, un objet Presentation qui représente la présentation PPTX dont le texte est extrait.
1. Deuxièmement, une valeur booléenne déterminant si la diapositive maître doit être incluse lors du scan du texte de la présentation. 
   La méthode renvoie un tableau d'objets TextFrame, complet avec des informations de mise en forme du texte. Le code ci-dessous scanne le texte et les informations de mise en forme d'une présentation, y compris les diapositives maîtresses.

```c#
//Instancier la classe Presentation qui représente un fichier PPTX
Presentation pptxPresentation = new Presentation("demo.pptx");

//Obtenir un tableau d'objets ITextFrame de toutes les diapositives dans le PPTX
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//Boucler à travers le tableau de TextFrames
for (int i = 0; i < textFramesPPTX.Length; i++)

	//Boucler à travers les paragraphes dans le ITextFrame actuel
	foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

		//Boucler à travers les portions dans le IParagraph actuel
		foreach (IPortion port in para.Portions)
		{
			//Afficher le texte dans la portion actuelle
			Console.WriteLine(port.Text);

			//Afficher la hauteur de police du texte
			Console.WriteLine(port.PortionFormat.FontHeight);

			//Afficher le nom de la police du texte
			if (port.PortionFormat.LatinFont != null)
				Console.WriteLine(port.PortionFormat.LatinFont.FontName);
		}
```




## **Extraction de texte classée et rapide**
La nouvelle méthode statique GetPresentationText a été ajoutée à la classe Presentation. Il existe deux surcharges pour cette méthode :

```csharp
PresentationText GetPresentationText(Stream stream)
PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
```

L'argument enum ExtractionMode indique le mode d'organisation de la sortie du résultat texte et peut être défini sur les valeurs suivantes :
Non arrangé - Le texte brut sans respect de la position sur la diapositive
Arrangé - Le texte est positionné dans le même ordre que sur la diapositive

Le mode non arrangé peut être utilisé lorsque la vitesse est critique, il est plus rapide que le mode arrangé.

PresentationText représente le texte brut extrait de la présentation. Il contient une propriété SlidesText de l'espace de noms Aspose.Slides.Util qui renvoie un tableau d'objets ISlideText. Chaque objet représente le texte de la diapositive correspondante. L'objet ISlideText a les propriétés suivantes :

ISlideText.Text - Le texte sur les formes de la diapositive
ISlideText.MasterText - Le texte sur les formes de la page maître pour cette diapositive
ISlideText.LayoutText - Le texte sur les formes de la page de mise en page pour cette diapositive
ISlideText.NotesText - Le texte sur les formes de la page de notes pour cette diapositive

Il existe également une classe SlideText qui implémente l'interface ISlideText.

La nouvelle API peut être utilisée de cette façon :

```c#
IPresentationText text1 = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);
```