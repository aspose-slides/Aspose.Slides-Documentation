---
title: Extraction avancée de texte depuis les présentations sur Android
linktitle: Extraire le texte
type: docs
weight: 90
url: /fr/androidjava/extract-text-from-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Extrayez rapidement le texte des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Android via Java. Suivez notre guide simple, étape par étape, pour gagner du temps."
---

{{% alert color="primary" %}} 

Il n'est pas rare que les développeurs aient besoin d'extraire le texte d'une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes sur toutes les diapositives d'une présentation. Cet article explique comment extraire le texte des présentations Microsoft PowerPoint PPTX à l'aide d'Aspose.Slides. 

{{% /alert %}} 
## **Extraire le texte d'une diapositive**
Aspose.Slides for Android via Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Cette classe expose un certain nombre de méthodes statiques surchargées permettant d'extraire le texte complet d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive dans une présentation PPTX, utilisez la méthode statique surchargée [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Cette méthode accepte l'objet Slide comme paramètre.  
Lors de son exécution, la méthode Slide parcourt tout le texte de la diapositive passée en paramètre et renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame). Cela signifie que toute la mise en forme du texte est disponible. Le morceau de code suivant extrait tout le texte de la première diapositive de la présentation :
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

                    //Afficher la hauteur de police du texte
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


## **Extraire le texte d'une présentation**
Pour parcourir le texte de l'ensemble de la présentation, utilisez la méthode statique [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) exposée par la classe SlideUtil. Elle prend deux paramètres :

1. Tout d'abord, un objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) représentant la présentation dont le texte doit être extrait.  
2. Ensuite, une valeur booléenne déterminant si la diapositive maître doit être incluse lors du parcours du texte de la présentation.  

La méthode renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) contenant les informations de mise en forme du texte. Le code ci‑dessous parcourt le texte et les informations de mise en forme d'une présentation, y compris les diapositives maîtres.
```java
//Instancier la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //Obtenir un tableau d'objets ITextFrame depuis toutes les diapositives du PPTX
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

                //Afficher la hauteur de police du texte
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


## **Extraction de texte catégorisée et rapide**
La nouvelle méthode statique getPresentationText a été ajoutée à la classe Presentation. Il existe trois surcharges pour cette méthode :
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[IPresentationText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText#getSlidesText--) method which returns an array of [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) objects. Every object represent the text on the corresponding slide. [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) object have the following methods:

- [ISlideText.getText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getText--) - The text on the slide's shapes
- [ISlideText.getMasterText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getMasterText--) - The text on the master page's shapes for this slide
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [ISlideText.getNotesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getNotesText--) - The text on the notes page's shapes for this slide

There is also a [SlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideText) class which implements the [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) interface.

The new API can be used like this:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```


## **FAQ**

**Quelle est la rapidité d'Aspose.Slides lors du traitement de grandes présentations pendant l'extraction du texte ?**

Aspose.Slides est optimisé pour les hautes performances et traite efficacement même les [grandes présentations](/slides/fr/androidjava/open-presentation/), ce qui le rend adapté aux scénarios de traitement en temps réel ou en lots.

**Aspose.Slides peut‑il extraire du texte des tableaux et des graphiques dans les présentations ?**

Oui, Aspose.Slides prend en charge l'extraction du texte des tableaux, des graphiques et d'autres éléments de diapositive complexes, vous permettant d'accéder et d'analyser facilement tout le contenu textuel.

**Ai‑je besoin d’une licence spéciale Aspose.Slides pour extraire le texte des présentations ?**

Vous pouvez extraire le texte avec la version d'essai gratuite d'Aspose.Slides, bien qu'elle comporte certaines limitations, comme le traitement d'un nombre limité de diapositives. Pour une utilisation sans restriction et pour gérer des présentations plus volumineuses, il est recommandé d'acheter une licence complète.