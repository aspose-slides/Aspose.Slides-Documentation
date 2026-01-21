---
title: Erweiterte Textextraktion aus Präsentationen in Java
linktitle: Text extrahieren
type: docs
weight: 90
url: /de/java/extract-text-from-presentation/
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
- Java
- Aspose.Slides
description: "Extrahieren Sie schnell Text aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java. Folgen Sie unserer einfachen, schrittweisen Anleitung, um Zeit zu sparen."
---

{{% alert color="primary" %}} 

Es ist nicht ungewöhnlich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Dazu müssen Sie den Text aus allen Formen auf allen Folien einer Präsentation extrahieren. Dieser Artikel erklärt, wie Sie Text aus Microsoft PowerPoint PPTX‑Präsentationen mithilfe von Aspose.Slides extrahieren. 

{{% /alert %}} 
## **Text aus Folien extrahieren**
Aspose.Slides für Java stellt die Klasse [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil) bereit. Diese Klasse bietet eine Reihe von überladenen statischen Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie. Um den Text aus einer Folie in einer PPTX‑Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [getAllTextBoxes](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) der Klasse [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Diese Methode akzeptiert das Slide‑Objekt als Parameter.  
Bei ihrer Ausführung scannt die Slide‑Methode den gesamten Text der als Parameter übergebenen Folie und gibt ein Array von [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)‑Objekten zurück. Das bedeutet, dass jegliche mit dem Text verbundene Formatierung verfügbar ist. Der folgende Codeabschnitt extrahiert den gesamten Text der ersten Folie der Präsentation:
```java
//Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Erhalten Sie ein Array von ITextFrame-Objekten aus allen Folien in der PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Durchlaufen Sie das Array von TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Durchlaufen Sie die Absätze im aktuellen ITextFrame
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Durchlaufen Sie die Portionen im aktuellen IParagraph
                for (IPortion port : para.getPortions()) {
                    //Geben Sie den Text im aktuellen Portion aus
                    System.out.println(port.getText());

                    //Geben Sie die Schriftgröße des Textes aus
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //Geben Sie den Schriftartnamen des Textes aus
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


## **Text aus Präsentationen extrahieren**
Um den Text aus der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [getAllTextFrames](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) der SlideUtil‑Klasse. Sie nimmt zwei Parameter entgegen:

1. Erstens ein [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged)‑Objekt, das die Präsentation repräsentiert, aus der der Text extrahiert werden soll.  
2. Zweitens ein boolescher Wert, der bestimmt, ob die Masterfolie in den Scan des Textes der Präsentation einbezogen werden soll.  

Die Methode gibt ein Array von [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)‑Objekten zurück, einschließlich der Textformatierungsinformationen. Der nachstehende Code scannt den Text und die Formatierungsinformationen aus einer Präsentation, einschließlich der Masterfolien.
```java
//Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt
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
            //Durchlaufen Sie die Portionen im aktuellen IParagraph
            for (IPortion port : para.getPortions())
            {
                //Geben Sie den Text im aktuellen Portion aus
                System.out.println(port.getText());

                //Geben Sie die Schriftgröße des Textes aus
                System.out.println(port.getPortionFormat().getFontHeight());

                //Geben Sie den Schriftartnamen des Textes aus
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


## **FAQ**

**Wie schnell verarbeitet Aspose.Slides große Präsentationen bei der Textextraktion?**

Aspose.Slides ist auf hohe Leistung optimiert und verarbeitet selbst [große Präsentationen](/slides/de/java/open-presentation/) effizient, sodass es sich für Echtzeit‑ oder Batch‑Szenarien eignet.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja, Aspose.Slides unterstützt das Extrahieren von Text aus Tabellen, Diagrammen und anderen komplexen Folienelementen, sodass Sie sämtlichen Textinhalt leicht zugreifen und analysieren können.

**Benötige ich eine spezielle Aspose.Slides‑Lizenz, um Text aus Präsentationen zu extrahieren?**

Sie können Text mit der kostenlosen Testversion von Aspose.Slides extrahieren, allerdings gibt es Einschränkungen, etwa die Verarbeitung einer begrenzten Anzahl von Folien. Für uneingeschränkte Nutzung und zur Verarbeitung größerer Präsentationen wird der Erwerb einer Voll‑Lizenz empfohlen.