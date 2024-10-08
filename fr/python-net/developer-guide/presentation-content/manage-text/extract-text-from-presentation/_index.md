---
title: Extraire du texte d'une présentation
type: docs
weight: 90
url: /fr/python-net/extract-text-from-presentation/
keywords: "Extraire du texte d'une diapositive, Extraire du texte d'un PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Extraire du texte d'une diapositive ou d'une présentation PowerPoint en Python"
---

{{% alert color="primary" %}} 

Il n'est pas rare que les développeurs aient besoin d'extraire le texte d'une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes sur toutes les diapositives d'une présentation. Cet article explique comment extraire du texte à partir de présentations Microsoft PowerPoint PPTX en utilisant Aspose.Slides. Le texte peut être extrait de plusieurs manières :

- [Extraire le texte d'une diapositive](/slides/fr/python-net/extracting-text-from-the-presentation/)
- [Extraire du texte en utilisant la méthode GetAllTextBoxes](/slides/fr/python-net/extracting-text-from-the-presentation/)
- [Extraction de texte catégorisée et rapide](/slides/fr/python-net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extraire du texte d'une diapositive**
Aspose.Slides pour Python via .NET fournit l'espace de noms Aspose.Slides.Util qui inclut la classe SlideUtil. Cette classe expose un certain nombre de méthodes statiques surchargées pour extraire l'intégralité du texte d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive dans une présentation PPTX, 
utilisez la méthode statique surchargée [GetAllTextBoxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) exposée par la classe SlideUtil. Cette méthode accepte l'objet Slide comme paramètre.
Lors de l'exécution, la méthode Slide scanne tout le texte de la diapositive passée comme paramètre et renvoie un tableau d'objets TextFrame. Cela signifie que tout formatage de texte associé au texte est disponible. Le code suivant extrait tout le texte de la première diapositive de la présentation :

```py
import aspose.slides as slides

#Instancier la classe Presentation qui représente un fichier PPTX
with slides.Presentation("pres.pptx") as pptxPresentation:
    # Obtenez un tableau d'objets ITextFrame de toutes les diapositives dans le PPTX
    textFramesPPTX = slides.util.SlideUtil.get_all_text_boxes(pptxPresentation.slides[0])
    
    # Boucle à travers le tableau de TextFrames
    for i in range(len(textFramesPPTX)):
	    # Boucle à travers les paragraphes dans l'ITextFrame actuel
        for para in textFramesPPTX[i].paragraphs:
            # Boucle à travers les portions dans l'IParagraph actuel
            for port in para.portions:
			    # Afficher le texte dans la portion actuelle
                print(port.text)

    			# Afficher la hauteur de police du texte
                print(port.portion_format.font_height)

			    # Afficher le nom de la police du texte
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **Extraire du texte d'une présentation**
Pour scanner le texte de l'ensemble de la présentation, utilisez la méthode statique [GetAllTextFrames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) exposée par la classe SlideUtil. Elle prend deux paramètres :

1. Tout d'abord, un objet Presentation qui représente la présentation PPTX dont le texte est extrait.
1. Deuxièmement, une valeur booléenne déterminant si la diapositive maître doit être incluse lors du scan du texte à partir de la présentation.
   La méthode renvoie un tableau d'objets TextFrame, complet avec des informations sur le formatage du texte. Le code ci-dessous scanne le texte et les informations de formatage d'une présentation, y compris les diapositives maîtresses.

```py
import aspose.slides as slides

#Instancier la classe Presentation qui représente un fichier PPTX
with slides.Presentation("pres.pptx") as pptxPresentation:
    # Obtenez un tableau d'objets ITextFrame de toutes les diapositives dans le PPTX
    textFramesPPTX = slides.util.SlideUtil.get_all_text_frames(pptxPresentation, True)
    
    # Boucle à travers le tableau de TextFrames
    for i in range(len(textFramesPPTX)):
	    # Boucle à travers les paragraphes dans l'ITextFrame actuel
        for para in textFramesPPTX[i].paragraphs:
            # Boucle à travers les portions dans l'IParagraph actuel
            for port in para.portions:
			    # Afficher le texte dans la portion actuelle
                print(port.text)

    			# Afficher la hauteur de police du texte
                print(port.portion_format.font_height)

			    # Afficher le nom de la police du texte
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **Extraction de texte catégorisée et rapide**
La nouvelle méthode statique GetPresentationText a été ajoutée à la classe Presentation. Il existe deux surcharges pour cette méthode :

```py
slides.Presentation.get_presentation_text(stream)
slides.Presentation.get_presentation_text(stream, mode)      
```

L'argument ExtractionMode enum indique le mode pour organiser la sortie du résultat textuel et peut être défini sur les valeurs suivantes :
Non arrangé - Le texte brut sans tenir compte de la position sur la diapositive
Arrangé - Le texte est positionné dans le même ordre que sur la diapositive

Le mode non arrangé peut être utilisé lorsque la vitesse est critique, il est plus rapide que le mode arrangé.

PresentationText représente le texte brut extrait de la présentation. Il contient une propriété `slides_text` de l'espace de noms Aspose.Slides.Util qui renvoie un tableau d'objets SlideText. Chaque objet représente le texte sur la diapositive correspondante. L'objet SlideText a les propriétés suivantes :

SlideText.text - Le texte sur les formes de la diapositive
SlideText.master_text - Le texte sur les formes de la page maître pour cette diapositive
SlideText.layout_text - Le texte sur les formes de la page de mise en page pour cette diapositive
SlideText.notes_text - Le texte sur les formes de la page de notes pour cette diapositive


La nouvelle API peut être utilisée de cette manière :

```py
import aspose.slides as slides

text1 = slides.PresentationFactory().get_presentation_text("pres.pptx", slides.TextExtractionArrangingMode.UNARRANGED)
print(text1.slides_text[0].text)
print(text1.slides_text[0].layout_text)
print(text1.slides_text[0].master_text)
print(text1.slides_text[0].notes_text)
```