---
title: Fortgeschrittene Textextraktion aus Präsentationen unter Android
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
- Text aus Folie abrufen
- Text aus Präsentation abrufen
- Text aus PowerPoint abrufen
- Text aus OpenDocument abrufen
- Text aus PPT abrufen
- Text aus PPTX abrufen
- Text aus ODP abrufen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Extrahieren Sie schnell Text aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android via Java. Folgen Sie unserer einfachen Schritt-für-Schritt-Anleitung, um Zeit zu sparen."
---

{{% alert color="primary" %}} 

Es ist nicht ungewöhnlich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Dazu müssen Sie den Text aus allen Formen auf allen Folien einer Präsentation extrahieren. Dieser Artikel erklärt, wie man Text aus Microsoft PowerPoint PPTX‑Präsentationen mit Aspose.Slides extrahiert. 

{{% /alert %}} 
## **Text aus einer Folie extrahieren**
Aspose.Slides for Android via Java stellt die Klasse [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) bereit. Diese Klasse bietet eine Reihe überladener statischer Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie. Um den Text aus einer Folie in einer PPTX‑Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) der Klasse [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Diese Methode akzeptiert das Slide‑Objekt als Parameter.
Bei der Ausführung scannt die Slide‑Methode den gesamten Text der übergebenen Folie und gibt ein Array von [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)‑Objekten zurück. Das bedeutet, dass alle Textformatierungen erhalten bleiben. Der folgende Codeabschnitt extrahiert den gesamten Text der ersten Folie der Präsentation:
```java
//Instanzieren Sie die Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Holen Sie ein Array von ITextFrame-Objekten von allen Folien in der PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Durchlaufen Sie das Array von TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Durchlaufen Sie die Absätze im aktuellen ITextFrame
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Durchlaufen Sie die Teile im aktuellen IParagraph
                for (IPortion port : para.getPortions()) {
                    //Zeigen Sie den Text im aktuellen Teil an
                    System.out.println(port.getText());

                    //Zeigen Sie die Schriftgröße des Textes an
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //Zeigen Sie den Schriftartnamen des Textes an
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
Um den Text der gesamten Präsentation zu durchsuchen, verwenden Sie die statische Methode [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) der SlideUtil‑Klasse. Sie akzeptiert zwei Parameter:

1. Zunächst ein [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged)‑Objekt, das die Präsentation repräsentiert, aus der der Text extrahiert werden soll.
1. Zweitens ein boolescher Wert, der bestimmt, ob die Masterfolie in die Texterfassung der Präsentation einbezogen werden soll.
   Die Methode gibt ein Array von [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)‑Objekten zurück, das die Textformatierungsinformationen enthält. Der Code unten durchsucht den Text und die Formatierungsinformationen einer Präsentation, einschließlich der Masterfolien.
```java
//Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation("demo.pptx");
try {
    //Holen Sie ein Array von ITextFrame-Objekten aus allen Folien in der PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Durchlaufen Sie das Array von TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Durchlaufen Sie die Absätze im aktuellen ITextFrame
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Durchlaufen Sie die Abschnitte im aktuellen IParagraph
            for (IPortion port : para.getPortions())
            {
                //Geben Sie den Text im aktuellen Abschnitt aus
                System.out.println(port.getText());

                //Geben Sie die Schriftgröße des Textes aus
                System.out.println(port.getPortionFormat().getFontHeight());

                //Geben Sie den Namen der Schriftart des Textes aus
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
Die neue statische Methode getPresentationText wurde zur Presentation‑Klasse hinzugefügt. Es gibt drei Überladungen für diese Methode:
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

**Wie schnell verarbeitet Aspose.Slides große Präsentationen bei der Textextraktion?**

Aspose.Slides ist für hohe Leistung optimiert und verarbeitet selbst [große Präsentationen](/slides/de/androidjava/open-presentation/) effizient, wodurch es für Echtzeit- oder Batch‑Verarbeitungsszenarien geeignet ist.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja, Aspose.Slides unterstützt das Extrahieren von Text aus Tabellen, Diagrammen und anderen komplexen Folienelementen vollständig, sodass Sie problemlos auf sämtliche textuelle Inhalte zugreifen und diese analysieren können.

**Benötige ich eine spezielle Aspose.Slides‑Lizenz, um Text aus Präsentationen zu extrahieren?**

Sie können Text mit der kostenlosen Testversion von Aspose.Slides extrahieren, jedoch gibt es dabei einige Einschränkungen, zum Beispiel die Verarbeitung nur einer begrenzten Anzahl von Folien. Für uneingeschränkte Nutzung und zur Verarbeitung größerer Präsentationen wird der Kauf einer vollständigen Lizenz empfohlen.