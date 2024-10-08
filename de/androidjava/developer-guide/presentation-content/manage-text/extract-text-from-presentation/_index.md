---
title: Text aus Präsentation extrahieren
type: docs
weight: 90
url: /de/androidjava/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

Es ist nicht ungewöhnlich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Dazu müssen Sie den Text aus allen Formen auf allen Folien in einer Präsentation extrahieren. Dieser Artikel erklärt, wie man Text aus Microsoft PowerPoint PPTX-Präsentationen mit Aspose.Slides extrahiert. 

{{% /alert %}} 
## **Text aus Folie extrahieren**
Aspose.Slides für Android über Java bietet die [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) Klasse. Diese Klasse stellt eine Reihe von überladenen statischen Methoden zum Extrahieren des gesamten Texts aus einer Präsentation oder Folie zur Verfügung. Um den Text aus einer Folie in einer PPTX-Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) der [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) Klasse. Diese Methode akzeptiert das Slide-Objekt als Parameter. Bei der Ausführung scannt die Slide-Methode den gesamten Text von der als Parameter übergebenen Folie und gibt ein Array von [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) Objekten zurück. Dies bedeutet, dass alle mit dem Text verbundenen Textformatierungen verfügbar sind. Der folgende Codeextrakt extrahiert den gesamten Text von der ersten Folie der Präsentation:

```java
//Instatiere die Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Erhalte ein Array von ITextFrame-Objekten aus allen Folien in der PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Durchlaufe das Array von TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Durchlaufe die Absätze im aktuellen ITextFrame
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Durchlaufe die Teile im aktuellen IParagraph
                for (IPortion port : para.getPortions()) {
                    //Zeige den Text im aktuellen Teil an
                    System.out.println(port.getText());

                    //Zeige die Schriftgröße des Textes an
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //Zeige den Schriftartnamen des Textes an
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
Um den Text aus der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) der SlideUtil-Klasse. Es nimmt zwei Parameter:

1. Erstens ein [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) Objekt, das die Präsentation darstellt, aus der der Text extrahiert wird.
1. Zweitens ein boolescher Wert, der bestimmt, ob die Master-Folie bei der Texterfassung aus der Präsentation einbezogen werden soll. 
   Die Methode gibt ein Array von [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) Objekten zurück, das vollständige Informationen zur Textformatierung enthält. Der folgende Code scannt den Text und die Formatierungsinformationen aus einer Präsentation, einschließlich der Master-Folien.

```java
//Instatiere die Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    //Erhalte ein Array von ITextFrame-Objekten aus allen Folien in der PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Durchlaufe das Array von TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Durchlaufe die Absätze im aktuellen ITextFrame
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Durchlaufe die Teile im aktuellen IParagraph
            for (IPortion port : para.getPortions())
            {
                //Zeige den Text im aktuellen Teil an
                System.out.println(port.getText());

                //Zeige die Schriftgröße des Textes an
                System.out.println(port.getPortionFormat().getFontHeight());

                //Zeige den Schriftartnamen des Textes an
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

Das [TextExtractionArrangingMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode) Enum-Argument gibt den Modus an, um das Ausgabeergebnis des Textes zu organisieren und kann auf die folgenden Werte gesetzt werden:
- [Unarranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - Der rohe Text ohne Rücksicht auf die Position auf der Folie
- [Arranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Arranged) - Der Text ist in der gleichen Reihenfolge angeordnet wie auf der Folie

**Unarranged** Modus kann verwendet werden, wenn die Geschwindigkeit entscheidend ist, er ist schneller als der Arranged Modus.

[IPresentationText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) repräsentiert den rohen Text, der aus der Präsentation extrahiert wurde. Es enthält eine [getSlidesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText#getSlidesText--) Methode, die ein Array von [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) Objekten zurückgibt. Jedes Objekt repräsentiert den Text auf der entsprechenden Folie. [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) Objekt hat die folgenden Methoden:

- [ISlideText.getText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getText--) - Der Text auf den Formen der Folie
- [ISlideText.getMasterText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getMasterText--) - Der Text auf den Formen der Masterfolie für diese Folie
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getLayoutText--) - Der Text auf den Formen der Layoutfolie für diese Folie
- [ISlideText.getNotesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getNotesText--) - Der Text auf den Formen der Notizfolie für diese Folie

Es gibt auch eine [SlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideText) Klasse, die das [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) Interface implementiert.

Die neue API kann wie folgt verwendet werden:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```