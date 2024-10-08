---
title: Extraire du texte de la présentation
type: docs
weight: 90
url: /fr/androidjava/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

Il n'est pas rare que les développeurs aient besoin d'extraire le texte d'une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes sur toutes les diapositives d'une présentation. Cet article explique comment extraire du texte des présentations Microsoft PowerPoint PPTX en utilisant Aspose.Slides. 

{{% /alert %}} 
## **Extraire du texte d'une diapositive**
Aspose.Slides pour Android via Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Cette classe expose un certain nombre de méthodes statiques surchargées pour extraire tout le texte d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive dans une présentation PPTX, utilisez la méthode statique surchargée [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Cette méthode accepte l'objet Slide comme paramètre. Lors de l'exécution, la méthode Slide analyse tout le texte de la diapositive passée comme paramètre et renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame). Cela signifie que tout formatage de texte associé au texte est disponible. Le morceau de code suivant extrait tout le texte de la première diapositive de la présentation :

```java
//Instancier la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Obtenir un tableau d'objets ITextFrame de toutes les diapositives dans le PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Boucler à travers le tableau de TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Boucler à travers les paragraphes dans le ITextFrame actuel
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Boucler à travers les portions dans le IParagraph actuel
                for (IPortion port : para.getPortions()) {
                    //Afficher le texte dans la portion actuelle
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

## **Extraire du texte de la présentation**
Pour analyser le texte de l'ensemble de la présentation, utilisez la méthode statique [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) exposée par la classe SlideUtil. Elle prend deux paramètres :

1. Tout d'abord, un objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) qui représente la présentation à partir de laquelle le texte est extrait.
2. Deuxièmement, une valeur booléenne déterminant si la diapositive maître doit être incluse lors de l'analyse du texte de la présentation.
   La méthode renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame), complet avec des informations de formatage du texte. Le code ci-dessous analyse le texte et les informations de formatage d'une présentation, y compris les diapositives maîtres.

```java
//Instancier la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //Obtenir un tableau d'objets ITextFrame de toutes les diapositives dans le PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Boucler à travers le tableau de TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Boucler à travers les paragraphes dans le ITextFrame actuel
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Boucler à travers les portions dans le IParagraph actuel
            for (IPortion port : para.getPortions())
            {
                //Afficher le texte dans la portion actuelle
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

L'argument enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode) indique le mode pour organiser la sortie du résultat de texte et peut être défini sur les valeurs suivantes :
- [Unarranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - Le texte brut sans tenir compte de la position sur la diapositive
- [Arranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Arranged) - Le texte est positionné dans le même ordre que sur la diapositive

Le mode **Unarranged** peut être utilisé lorsque la vitesse est critique, il est plus rapide que le mode Arranged.

[IPresentationText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) représente le texte brut extrait de la présentation. Il contient une méthode [getSlidesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText#getSlidesText--) qui renvoie un tableau d'objets [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText). Chaque objet représente le texte sur la diapositive correspondante. L'objet [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) a les méthodes suivantes :

- [ISlideText.getText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getText--) - Le texte sur les formes de la diapositive
- [ISlideText.getMasterText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getMasterText--) - Le texte sur les formes de la page maître pour cette diapositive
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getLayoutText--) - Le texte sur les formes de la page de mise en page pour cette diapositive
- [ISlideText.getNotesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getNotesText--) - Le texte sur les formes de la page de notes pour cette diapositive

Il y a aussi une classe [SlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideText) qui implémente l'interface [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText).

La nouvelle API peut être utilisée comme ceci :

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```