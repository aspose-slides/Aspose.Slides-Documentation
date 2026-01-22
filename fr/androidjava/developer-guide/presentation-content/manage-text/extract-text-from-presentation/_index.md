---
title: Extraction avancée de texte à partir de présentations sur Android
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
Aspose.Slides for Android via Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Cette classe expose un certain nombre de méthodes statiques surchargées pour extraire le texte complet d’une présentation ou d’une diapositive. Pour extraire le texte d’une diapositive dans une présentation PPTX, utilisez la méthode statique surchargée [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Cette méthode accepte l’objet Slide comme paramètre.
Lors de l'exécution, la méthode Slide analyse le texte complet de la diapositive passée en paramètre et renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame). Cela signifie que tout formatage du texte associé est disponible. Le fragment de code suivant extrait tout le texte de la première diapositive de la présentation :
```java
//Instancier la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Obtenir un tableau d'objets ITextFrame à partir de toutes les diapositives du PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Parcourir le tableau de TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Parcourir les paragraphes du ITextFrame actuel
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Parcourir les portions du IParagraph actuel
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


## **Extraire le texte d'une présentation**
Pour analyser le texte de l'ensemble de la présentation, utilisez la méthode statique [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) exposée par la classe SlideUtil. Elle prend deux paramètres :
1. Tout d'abord, un objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) qui représente la présentation dont le texte est extrait.
1. Deuxièmement, une valeur booléenne déterminant si la diapositive maître doit être incluse lors de l'analyse du texte de la présentation.
La méthode renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame), complet avec les informations de formatage du texte. Le code ci‑dessous analyse le texte et les informations de formatage d'une présentation, y compris les diapositives maîtres.
```java
//Instancier la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //Obtenir un tableau d'objets ITextFrame à partir de toutes les diapositives du PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Parcourir le tableau de TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Parcourir les paragraphes du ITextFrame actuel
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Parcourir les portions du IParagraph actuel
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


## **Extraction de texte catégorisée et rapide**
La nouvelle méthode statique getPresentationText a été ajoutée à la classe Presentation. Il existe trois surcharges pour cette méthode :
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```


## **FAQ**

**Quelle rapidité Aspose.Slides offre-t-il pour le traitement de grandes présentations lors de l'extraction de texte ?**

Aspose.Slides est optimisé pour des performances élevées et traite efficacement même les [grandes présentations](/slides/fr/androidjava/open-presentation/), ce qui le rend adapté aux scénarios de traitement en temps réel ou en masse.

**Aspose.Slides peut-il extraire du texte des tableaux et des graphiques au sein des présentations ?**

Oui, Aspose.Slides prend entièrement en charge l'extraction de texte à partir des tableaux, des graphiques et d'autres éléments de diapositive complexes, vous permettant d'accéder facilement à tout le contenu textuel et de l'analyser.

**Ai-je besoin d'une licence spéciale Aspose.Slides pour extraire du texte des présentations ?**

Vous pouvez extraire du texte avec la version d'essai gratuite d'Aspose.Slides, bien qu'elle comporte certaines limitations, comme le traitement d'un nombre limité de diapositives. Pour une utilisation sans restriction et pour gérer des présentations plus volumineuses, l'achat d'une licence complète est recommandé.