---
title: Extraire le texte d'une présentation
type: docs
weight: 90
url: /fr/java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

Il n'est pas rare que les développeurs aient besoin d'extraire le texte d'une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes sur toutes les diapositives d'une présentation. Cet article explique comment extraire le texte des présentations Microsoft PowerPoint PPTX en utilisant Aspose.Slides. 

{{% /alert %}} 
## **Extraire le texte de la diapositive**
Aspose.Slides pour Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Cette classe expose un certain nombre de méthodes statiques surchargées pour extraire l'ensemble du texte d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive dans une présentation PPTX, utilisez la méthode statique surchargée [getAllTextBoxes](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Cette méthode accepte l'objet Slide comme paramètre. Lors de l'exécution, la méthode Slide scanne tout le texte de la diapositive passée en paramètre et retourne un tableau d'objets [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame). Cela signifie que tout formatage de texte associé au texte est disponible. Le morceau de code suivant extrait tout le texte de la première diapositive de la présentation :

```java
//Instancier la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Obtenir un tableau d'objets ITextFrame à partir de toutes les diapositives dans le PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Parcourir le tableau de TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Parcourir les paragraphes dans l'ITextFrame actuel
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Parcourir les portions dans l'IParagraph actuel
                for (IPortion port : para.getPortions()) {
                    //Afficher le texte dans la portion actuelle
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

## **Extraire le texte de la présentation**
Pour scanner le texte de l'ensemble de la présentation, utilisez la méthode statique [getAllTextFrames](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) exposée par la classe SlideUtil. Elle prend deux paramètres :

1. D'abord, un objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) qui représente la présentation dont le texte est extrait.
1. Deuxièmement, une valeur booléenne déterminant si la diapositive maître doit être incluse lors du scan du texte de la présentation. La méthode retourne un tableau d'objets [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame), complet avec les informations de formatage du texte. Le code ci-dessous scanne le texte et les informations de formatage d'une présentation, y compris les diapositives maîtres.

```java
//Instancier la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //Obtenir un tableau d'objets ITextFrame à partir de toutes les diapositives dans le PPTX
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
                //Afficher le texte dans la portion actuelle
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
La nouvelle méthode statique getPresentationText a été ajoutée à la classe Presentation. Il y a trois surcharges pour cette méthode :

```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

L'argument de l'énumération [TextExtractionArrangingMode](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode) indique le mode d'organisation du résultat textuel et peut être défini sur les valeurs suivantes :
- [Unarranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - Le texte brut sans tenir compte de la position sur la diapositive
- [Arranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Arranged) - Le texte est positionné dans le même ordre que sur la diapositive

Le mode **Unarranged** peut être utilisé lorsque la vitesse est cruciale, il est plus rapide que le mode Arranged.

[IPresentationText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) représente le texte brut extrait de la présentation. Il contient une méthode [getSlidesText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText#getSlidesText--) qui retourne un tableau d'objets [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText). Chaque objet représente le texte sur la diapositive correspondante. L'objet [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) a les méthodes suivantes :

- [ISlideText.getText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getText--) - Le texte sur les formes de la diapositive
- [ISlideText.getMasterText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getMasterText--) - Le texte sur les formes de la page maître pour cette diapositive
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getLayoutText--) - Le texte sur les formes de la page de mise en page pour cette diapositive
- [ISlideText.getNotesText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getNotesText--) - Le texte sur les formes de la page de notes pour cette diapositive

Il y a également une classe [SlideText](https://reference.aspose.com/slides/java/com.aspose.slides/SlideText) qui implémente l'interface [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText).

La nouvelle API peut être utilisée comme ceci :

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```