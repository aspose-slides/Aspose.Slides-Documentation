---
title: Extraction avancée de texte des présentations en Java
linktitle: Extraire du texte
type: docs
weight: 90
url: /fr/java/extract-text-from-presentation/
keywords:
- extraire du texte
- extraire du texte d'une diapositive
- extraire du texte d'une présentation
- extraire du texte de PowerPoint
- extraire du texte d'OpenDocument
- extraire du texte de PPT
- extraire du texte de PPTX
- extraire du texte d'ODP
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
- Java
- Aspose.Slides
description: "Extrayez rapidement du texte des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Java. Suivez notre guide simple, étape par étape, pour gagner du temps."
---

{{% alert color="primary" %}} 

Il n'est pas rare que les développeurs aient besoin d'extraire le texte d'une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes sur toutes les diapositives d'une présentation. Cet article explique comment extraire le texte des présentations Microsoft PowerPoint PPTX à l'aide d'Aspose.Slides. 

{{% /alert %}} 
## **Extraire le texte des diapositives**
Aspose.Slides for Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Cette classe expose un certain nombre de méthodes statiques surchargées pour extraire le texte complet d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive d'une présentation PPTX, utilisez la méthode statique surchargée [getAllTextBoxes](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Cette méthode accepte l'objet Slide comme paramètre.  
Lors de l'exécution, la méthode Slide parcourt tout le texte de la diapositive passée en paramètre et renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame). Cela signifie que toute mise en forme du texte associée est disponible. Le morceau de code suivant extrait tout le texte de la première diapositive de la présentation :
```java
//Instancier la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Obtenir un tableau d'objets ITextFrame provenant de toutes les diapositives du PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Parcourir le tableau de TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Parcourir les paragraphes dans l'ITextFrame actuel
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Parcourir les portions dans l'IParagraph actuel
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


## **Extraire le texte des présentations**
Pour parcourir le texte de toute la présentation, utilisez la méthode statique [getAllTextFrames](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) exposée par la classe SlideUtil. Elle prend deux paramètres :

1. Tout d'abord, un objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) qui représente la présentation dont le texte est extrait.  
2. Ensuite, une valeur booléenne déterminant si la diapositive maître doit être incluse lors du parcours du texte de la présentation.  
   La méthode renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) complet avec les informations de mise en forme du texte. Le code ci‑dessous parcourt le texte et les informations de mise en forme d'une présentation, y compris les diapositives maîtres.
```java
//Instancier la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //Obtenir un tableau d'objets ITextFrame provenant de toutes les diapositives du PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Parcourir le tableau de TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Parcourir les paragraphes dans l'ITextFrame actuel
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Parcourir les portions dans l'IParagraph actuel
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


## **FAQ**

**Quelle est la rapidité d'Aspose.Slides pour traiter de grandes présentations lors de l'extraction de texte ?**  

Aspose.Slides est optimisé pour des performances élevées et traite efficacement même les [grandes présentations](/slides/fr/java/open-presentation/), ce qui le rend adapté aux scénarios de traitement en temps réel ou en batch.  

**Aspose.Slides peut‑il extraire le texte des tableaux et des graphiques dans les présentations ?**  

Oui, Aspose.Slides prend entièrement en charge l'extraction de texte à partir des tableaux, des graphiques et d'autres éléments de diapositive complexes, vous permettant d'accéder facilement à l'intégralité du contenu textuel et de l'analyser.  

**Ai‑je besoin d'une licence spéciale Aspose.Slides pour extraire le texte des présentations ?**  

Vous pouvez extraire le texte avec la version d'essai gratuite d'Aspose.Slides, bien qu'elle comporte certaines limitations, comme le traitement d'un nombre limité de diapositives. Pour une utilisation illimitée et pour gérer des présentations plus volumineuses, l'achat d'une licence complète est recommandé.