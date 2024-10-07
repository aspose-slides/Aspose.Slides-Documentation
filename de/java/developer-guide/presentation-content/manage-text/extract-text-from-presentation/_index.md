---
title: Text aus Präsentation extrahieren
type: docs
weight: 90
url: /java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

Es ist nicht ungewöhnlich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Um dies zu tun, müssen Sie den Text aus allen Formen auf allen Folien in einer Präsentation extrahieren. Dieser Artikel erklärt, wie man Text aus Microsoft PowerPoint PPTX-Präsentationen mithilfe von Aspose.Slides extrahiert.

{{% /alert %}} 
## **Text aus Folie extrahieren**
Aspose.Slides für Java stellt die [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil) Klasse bereit. Diese Klasse bietet eine Reihe von überladenen statischen Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie. Um den Text aus einer Folie in einer PPTX-Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [getAllTextBoxes](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) der [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil) Klasse. Diese Methode akzeptiert das Slide-Objekt als Parameter. Bei der Ausführung scannt die Methode Slide den gesamten Text von der als Parameter übergebenen Folie und gibt ein Array von [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) Objekten zurück. Das bedeutet, dass alle Textformatierungen, die mit dem Text verbunden sind, verfügbar sind. Der folgende Code extrahiert den gesamten Text von der ersten Folie der Präsentation:

```java
//Instatiate Presentation class that represents a PPTX file
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Get an Array of ITextFrame objects from all slides in the PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Loop through the Array of TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Loop through paragraphs in current ITextFrame
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Loop through portions in the current IParagraph
                for (IPortion port : para.getPortions()) {
                    //Display text in the current portion
                    System.out.println(port.getText());

                    //Display font height of the text
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //Display font name of the text
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

## **Text aus Präsentation extrahieren**
Um den Text aus der gesamten Präsentation zu scannen, verwenden Sie die
 [getAllTextFrames](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) statische Methode der SlideUtil-Klasse. Sie benötigt zwei Parameter:

1. Erstens ein [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) Objekt, das die Präsentation darstellt, aus der der Text extrahiert wird.
2. Zweitens ein boolescher Wert, der bestimmt, ob die Master-Folie beim Scannen des Textes aus der Präsentation einbezogen werden soll.
   Die Methode gibt ein Array von [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) Objekten zurück, die vollständige Informationen zur Textformatierung enthalten. Der folgende Code scannt den Text und die Formatierungsinformationen aus einer Präsentation, einschließlich der Master-Folien.

```java
//Instatiate Presentation class that represents a PPTX file
Presentation pres = new Presentation("demo.pptx");
try {
    //Get an Array of ITextFrame objects from all slides in the PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Loop through the Array of TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Loop through paragraphs in current ITextFrame
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Loop through portions in the current IParagraph
            for (IPortion port : para.getPortions())
            {
                //Display text in the current portion
                System.out.println(port.getText());

                //Display font height of the text
                System.out.println(port.getPortionFormat().getFontHeight());

                //Display font name of the text
                if (port.getPortionFormat().getLatinFont() != null)
                    System.out.println(port.getPortionFormat().getLatinFont().getFontName());
            }
        }
    }
} finally {
    pres.dispose();
}
```

## **Kategorisierte und schnelle Textextraktion**
Die neue statische Methode getPresentationText wurde zur Präsentationsklasse hinzugefügt. Es gibt drei Überladungen für diese Methode:

```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

Das [TextExtractionArrangingMode](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode) Enum-Argument gibt den Modus an, um die Ausgabe des Textergebnisses zu organisieren und kann auf folgende Werte gesetzt werden:
- [Unarranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - Der roher Text ohne Berücksichtigung der Position auf der Folie
- [Arranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Arranged) - Der Text ist in der gleichen Reihenfolge positioniert wie auf der Folie

**Unarranged**-Modus kann verwendet werden, wenn Geschwindigkeit entscheidend ist, da er schneller ist als der Arranged-Modus.

[IPresentationText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) repräsentiert den rohen Text, der aus der Präsentation extrahiert wurde. Es enthält eine [getSlidesText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText#getSlidesText--) Methode, die ein Array von [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) Objekten zurückgibt. Jedes Objekt repräsentiert den Text auf der entsprechenden Folie. [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) Objekte haben die folgenden Methoden:

- [ISlideText.getText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getText--) - Der Text auf den Formen der Folie
- [ISlideText.getMasterText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getMasterText--) - Der Text auf den Formen der Masterseite für diese Folie
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getLayoutText--) - Der Text auf den Formen der Layoutseite für diese Folie
- [ISlideText.getNotesText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getNotesText--) - Der Text auf den Formen der Notizenseite für diese Folie

Es gibt auch eine [SlideText](https://reference.aspose.com/slides/java/com.aspose.slides/SlideText) Klasse, die das [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) Interface implementiert.

Die neue API kann folgendermaßen verwendet werden:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```