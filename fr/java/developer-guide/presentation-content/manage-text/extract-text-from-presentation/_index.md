---
title: Extraction avancée du texte à partir de présentations en Java
linktitle: Extraire le texte
type: docs
weight: 90
url: /fr/java/extract-text-from-presentation/
keywords:
- extraire le texte
- extraire le texte d’une diapositive
- extraire le texte d’une présentation
- extraire le texte de PowerPoint
- extraire le texte d’OpenDocument
- extraire le texte de PPT
- extraire le texte de PPTX
- extraire le texte d’ODP
- récupérer le texte
- récupérer le texte d’une diapositive
- récupérer le texte d’une présentation
- récupérer le texte de PowerPoint
- récupérer le texte d’OpenDocument
- récupérer le texte de PPT
- récupérer le texte de PPTX
- récupérer le texte d’ODP
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Extrayez rapidement le texte des présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour Java. Suivez notre guide simple et étape par étape pour gagner du temps."
---

{{% alert color="primary" %}} 

Il n’est pas rare que les développeurs aient besoin d’extraire le texte d’une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes sur toutes les diapositives d’une présentation. Cet article explique comment extraire le texte des présentations Microsoft PowerPoint PPTX à l’aide d’Aspose.Slides. 

{{% /alert %}} 
## **Extract Text from Slides**
Aspose.Slides for Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Cette classe expose un certain nombre de méthodes statiques surchargées pour extraire le texte complet d’une présentation ou d’une diapositive. Pour extraire le texte d’une diapositive dans une présentation PPTX, 
utilisez la méthode statique surchargée [getAllTextBoxes](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Cette méthode accepte l’objet Slide comme paramètre.
Lors de son exécution, la méthode Scan du texte complet de la diapositive passée en paramètre et renvoie un tableau d’objets [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame). Cela signifie que tout formatage de texte associé au texte est disponible. Le fragment de code suivant extrait tout le texte de la première diapositive de la présentation :
```java
//Instancier la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Obtenir un tableau d'objets ITextFrame provenant de toutes les diapositives du PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Boucler sur le tableau de TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Boucler sur les paragraphes du ITextFrame actuel
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Boucler sur les portions du IParagraph actuel
                for (IPortion port : para.getPortions()) {
                    //Afficher le texte de la portion actuelle
                    System.out.println(port.getText());

                    //Afficher la hauteur de la police du texte
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //Afficher le nom de la police du texte
                    if (port.getPortionFormat().getLatinFont() != null)
                        System.out.println(port.getPortionFormat().getLatinFont().getFontName());
                }
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **Extract Text from Presentations**
Pour analyser le texte de l’ensemble de la présentation, utilisez la 
[ getAllTextFrames](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) méthode statique exposée par la classe SlideUtil. Elle prend deux paramètres :

1. Tout d’abord, un objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) qui représente la présentation dont le texte est extrait.
1. Deuxièmement, une valeur booléenne déterminant si la diapositive maîtresse doit être incluse lors de l’analyse du texte de la présentation.  
   La méthode renvoie un tableau d’objets [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) complet avec les informations de formatage du texte. Le code ci‑dessous analyse le texte et les informations de formatage d’une présentation, y compris les diapositives maîtresses.
```java
//Instancier la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //Obtenir un tableau d'objets ITextFrame à partir de toutes les diapositives du PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Boucler sur le tableau de TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Boucler sur les paragraphes du ITextFrame actuel
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Boucler sur les portions du IParagraph actuel
            for (IPortion port : para.getPortions())
            {
                //Afficher le texte de la portion actuelle
                System.out.println(port.getText());

                //Afficher la hauteur de la police du texte
                System.out.println(port.getPortionFormat().getFontHeight());

                //Afficher le nom de la police du texte
                if (port.getPortionFormat().getLatinFont() != null)
                    System.out.println(port.getPortionFormat().getLatinFont().getFontName());
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **Categorized and Fast Text Extraction**
La nouvelle méthode statique getPresentationText a été ajoutée à la classe Presentation. Il existe trois surcharges pour cette méthode :
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[IPresentationText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText#getSlidesText--) method which returns an array of [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) objects. Every object represent the text on the corresponding slide. [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) object have the following methods:

- [ISlideText.getText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getText--) - The text on the slide's shapes
- [ISlideText.getMasterText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getMasterText--) - The text on the master page's shapes for this slide
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [ISlideText.getNotesText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getNotesText--) - The text on the notes page's shapes for this slide

The new API can be used like this:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```


## **FAQ**

**How fast does Aspose.Slides process large presentations during text extraction?**

Aspose.Slides est optimisé pour des performances élevées et traite efficacement même les [large presentations](/slides/fr/java/open-presentation/), ce qui le rend adapté aux scénarios de traitement en temps réel ou en masse.

**Can Aspose.Slides extract text from tables and charts within presentations?**

Oui, Aspose.Slides prend entièrement en charge l’extraction de texte à partir des tableaux, graphiques et autres éléments complexes de diapositives, vous permettant d’accéder et d’analyser facilement tout le contenu textuel.

**Do I need a special Aspose.Slides license to extract text from presentations?**

Vous pouvez extraire le texte à l’aide de la version d’évaluation gratuite d’Aspose.Slides, bien qu’elle comporte certaines limitations, comme le traitement d’un nombre limité de diapositives. Pour une utilisation illimitée et la prise en charge de présentations plus volumineuses, l’achat d’une licence complète est recommandé.