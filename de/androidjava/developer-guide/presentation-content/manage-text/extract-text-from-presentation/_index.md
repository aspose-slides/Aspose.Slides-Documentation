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
description: "Schnelles Extrahieren von Text aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android via Java. Befolgen Sie unsere einfache, schrittweise Anleitung, um Zeit zu sparen."
---

{{% alert color="primary" %}} 
Es ist nicht ungewöhnlich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Dafür müssen Sie den Text aus allen Formen auf allen Folien einer Präsentation extrahieren. Dieser Artikel erklärt, wie man Text aus Microsoft PowerPoint PPTX‑Präsentationen mit Aspose.Slides extrahiert. 
{{% /alert %}} 
## **Text aus einer Folie extrahieren**
Aspose.Slides für Android via Java stellt die [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil)-Klasse bereit. Diese Klasse bietet mehrere überladene statische Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie. Um den Text aus einer Folie in einer PPTX‑Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) der [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil)-Klasse. Diese Methode akzeptiert das Slide‑Objekt als Parameter.  
Bei der Ausführung scannt die Slide‑Methode den gesamten Text der übergebenen Folie und gibt ein Array von [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)-Objekten zurück. Das bedeutet, dass alle mit dem Text verknüpften Formatierungen verfügbar sind. Der folgende Code extrahiert den gesamten Text der ersten Folie der Präsentation:
```java
//Instanziiere Presentation-Klasse, die eine PPTX-Datei repräsentiert
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
                //Durchlaufe die Abschnitte im aktuellen IParagraph
                for (IPortion port : para.getPortions()) {
                    //Gib den Text im aktuellen Abschnitt aus
                    System.out.println(port.getText());

                    //Gib die Schriftgröße des Textes aus
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //Gib den Schriftartnamen des Textes aus
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
Um den Text aus der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) der SlideUtil‑Klasse. Sie nimmt zwei Parameter entgegen:

1. Zuerst ein [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged)-Objekt, das die Präsentation darstellt, aus der der Text extrahiert wird.  
2. Zweitens ein boolescher Wert, der bestimmt, ob die Master‑Folien in den Scan einbezogen werden sollen.  
Die Methode gibt ein Array von [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)-Objekten zurück, inklusive Textformatierungsinformationen. Der nachstehende Code scannt den Text und die Formatierungsinformationen einer Präsentation, einschließlich der Master‑Folien.
```java
//Instanziiere Presentation-Klasse, die eine PPTX-Datei repräsentiert
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
            //Durchlaufe die Portionen im aktuellen IParagraph
            for (IPortion port : para.getPortions())
            {
                //Gib den Text in der aktuellen Portion aus
                System.out.println(port.getText());

                //Gib die Schriftgröße des Textes aus
                System.out.println(port.getPortionFormat().getFontHeight());

                //Gib den Schriftartnamen des Textes aus
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
Die neue statische Methode getPresentationText wurde der Presentation‑Klasse hinzugefügt. Es gibt drei Überladungen für diese Methode:
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```


## **FAQ**

**Wie schnell verarbeitet Aspose.Slides große Präsentationen bei der Textextraktion?**

Aspose.Slides ist für hohe Leistung optimiert und verarbeitet sogar [große Präsentationen](/slides/de/androidjava/open-presentation/) effizient, was es für Echtzeit- oder Batch‑Verarbeitungsszenarien geeignet macht.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja, Aspose.Slides unterstützt das Extrahieren von Text aus Tabellen, Diagrammen und anderen komplexen Folienelementen, sodass Sie alle textlichen Inhalte einfach zugreifen und analysieren können.

**Benötige ich eine spezielle Aspose.Slides‑Lizenz, um Text aus Präsentationen zu extrahieren?**

Sie können Text mit der kostenlosen Testversion von Aspose.Slides extrahieren, jedoch gibt es einige Einschränkungen, z. B. die Verarbeitung nur einer begrenzten Anzahl von Folien. Für uneingeschränkte Nutzung und zur Verarbeitung größerer Präsentationen wird der Kauf einer Volllizenz empfohlen.