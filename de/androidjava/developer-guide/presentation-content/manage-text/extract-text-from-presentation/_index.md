---
title: Erweiterte Textextraktion aus Präsentationen auf Android
linktitle: Text extrahieren
type: docs
weight: 90
url: /de/androidjava/extract-text-from-presentation/
keywords:
- Text extrahieren
- Text aus Folie extrahieren
- Text aus Präsentation extrahieren
- Text aus PowerPoint extrahieren
- Text aus OpenDocument extrahieren
- Text aus PPT extrahieren
- Text aus PPTX extrahieren
- Text aus ODP extrahieren
- Text abrufen
- Text von Folie abrufen
- Text von Präsentation abrufen
- Text von PowerPoint abrufen
- Text von OpenDocument abrufen
- Text von PPT abrufen
- Text von PPTX abrufen
- Text von ODP abrufen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Schnelles Extrahieren von Text aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android via Java. Befolgen Sie unsere einfache, Schritt-für-Schritt-Anleitung, um Zeit zu sparen."
---

{{% alert color="primary" %}} 

Es ist nicht ungewöhnlich, dass Entwickler den Text einer Präsentation extrahieren müssen. Dazu müssen Sie den Text aus allen Formen auf allen Folien einer Präsentation extrahieren. Dieser Artikel erklärt, wie Sie Text aus Microsoft PowerPoint PPTX‑Präsentationen mit Aspose.Slides extrahieren. 

{{% /alert %}} 
## **Text aus einer Folie extrahieren**
Aspose.Slides für Android via Java bietet die Klasse [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Diese Klasse stellt eine Reihe überladener statischer Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie bereit. Um den Text aus einer Folie in einer PPTX‑Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) der Klasse [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Diese Methode akzeptiert das Slide‑Objekt als Parameter.
Bei der Ausführung scannt die Slide‑Methode den gesamten Text der übergebenen Folie und gibt ein Array von [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)‑Objekten zurück. Das bedeutet, dass jegliche Textformatierung, die mit dem Text verbunden ist, verfügbar ist. 
Der folgende Codeabschnitt extrahiert den gesamten Text der ersten Folie der Präsentation:
```java
//Instanziiere die Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Erhalte ein Array von ITextFrame-Objekten aus allen Folien in der PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Durchlaufe das Array von TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Durchlaufe Absätze im aktuellen ITextFrame
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Durchlaufe Teile im aktuellen IParagraph
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


## **Text aus einer Präsentation extrahieren**
Um den Text der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) der SlideUtil‑Klasse. Sie nimmt zwei Parameter entgegen:

1. Erstens ein [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged)‑Objekt, das die Präsentation darstellt, aus der der Text extrahiert wird.
1. Zweitens ein boolescher Wert, der bestimmt, ob die Masterfolie beim Scannen des Textes aus der Präsentation einbezogen werden soll.
   Die Methode gibt ein Array von [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)‑Objekten zurück, das die Textformatierungsinformationen enthält. Der unten stehende Code scannt den Text und die Formatierungsinformationen einer Präsentation, einschließlich der Masterfolien.
```java
//Instanziiere die Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    //Erhalte ein Array von ITextFrame-Objekten aus allen Folien in der PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Durchlaufe das Array von TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Durchlaufe Absätze im aktuellen ITextFrame
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Durchlaufe Teile im aktuellen IParagraph
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
Die neue statische Methode getPresentationText wurde der Klasse Presentation hinzugefügt. Es gibt drei Überladungen für diese Methode:
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

The new API can be used like this:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```



## **FAQ**

**Wie schnell verarbeitet Aspose.Slides große Präsentationen bei der Textextraktion?**

Aspose.Slides ist für hohe Leistungsfähigkeit optimiert und verarbeitet selbst [large presentations](/slides/de/androidjava/open-presentation/) effizient, wodurch es für Echtzeit‑ oder Batch‑Verarbeitungsszenarien geeignet ist.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja, Aspose.Slides unterstützt das Extrahieren von Text aus Tabellen, Diagrammen und anderen komplexen Folienelementen, sodass Sie alle textuellen Inhalte leicht zugreifen und analysieren können.

**Benötige ich eine spezielle Aspose.Slides‑Lizenz, um Text aus Präsentationen zu extrahieren?**

Sie können Text mit der kostenlosen Testversion von Aspose.Slides extrahieren, jedoch hat diese bestimmte Einschränkungen, wie die Verarbeitung nur einer begrenzten Anzahl von Folien. Für uneingeschränkte Nutzung und die Verarbeitung größerer Präsentationen wird der Kauf einer Volllizenz empfohlen.