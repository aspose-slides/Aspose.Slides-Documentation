---
title: Text aus Präsentationen extrahieren
type: docs
weight: 60
url: /de/cpp/extracting-text-from-the-presentation/
keywords:
- Text extrahieren
- Text abrufen
- Folie
- Textfeld
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text aus Folien oder gesamten Präsentationen in Aspose.Slides für C++ extrahieren und Inhalte aus PPT, PPTX und ODP programmgesteuert verarbeiten können."
---

{{% alert color="primary" %}} 

Es kommt häufig vor, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Dazu müssen Sie den Text aus allen Formen auf allen Folien einer Präsentation extrahieren. Dieser Artikel erklärt, wie Sie Text aus Microsoft PowerPoint PPTX‑Präsentationen mit Aspose.Slides extrahieren können. Text kann auf folgende Weise extrahiert werden:

[Text aus einer Folie extrahieren](/slides/de/cpp/extracting-text-from-the-presentation/)
[Text mit der GetAllTextBoxes‑Methode extrahieren](/slides/de/cpp/extracting-text-from-the-presentation/)
[Kategorisierte und schnelle Textextraktion](/slides/de/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Text aus einer Folie extrahieren**
Aspose.Slides für C++ stellt den Namespace Aspose.Slides.Util bereit, der die Klasse PresentationScanner enthält. Diese Klasse bietet mehrere überladene statische Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie. Um den Text aus einer Folie einer PPTX‑Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextboxes/) der Klasse PresentationScanner. Diese Methode akzeptiert das Slide‑Objekt als Parameter.
Bei der Ausführung scannt die Slide‑Methode den gesamten Text der übergebenen Folie und gibt ein Array von TextFrame‑Objekten zurück. Das bedeutet, dass alle mit dem Text verbundenen Formatierungen verfügbar sind. Der folgende Code extrahiert den gesamten Text der ersten Folie der Präsentation:

**C#**
``` cpp
 //Instanzieren Sie die PresentationEx-Klasse, die eine PPTX-Datei darstellt
Presentation pptxPresentation = new Presentation(path + "demo.pptx");

//Get an Array of TextFrameEx objects from the first slide
ITextFrame[] textFramesSlideOne = SlideUtil.GetAllTextBoxes(pptxPresentation.Slides[0]);

 //Durchlaufen Sie das Array von TextFrames
for (int i = 0; i < textFramesSlideOne.Length; i++)
    //Durchlaufen Sie die Absätze im aktuellen TextFrame
    foreach (Paragraph para in textFramesSlideOne[i].Paragraphs)
        //Durchlaufen Sie die Portionen im aktuellen Absatz
        foreach (Portion port in para.Portions)
        {
            //Text im aktuellen Portion anzeigen
            Console.WriteLine(port.Text);
            //Schriftgröße des Textes anzeigen
            Console.WriteLine(port.PortionFormat.FontHeight);
            //Schriftname des Textes anzeigen
            Console.WriteLine(port.PortionFormat.LatinFont.FontName);
        }
```



## **Text aus der gesamten Präsentation extrahieren**
Um den Text aus der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [GetAllTextFrames](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextframes/) der Klasse PresentationScanner. Sie akzeptiert zwei Parameter:

1. Zunächst ein Presentation‑Objekt, das die PPTX‑Präsentation repräsentiert, aus der der Text extrahiert wird.
2. Zweitens ein Boolean‑Wert, der bestimmt, ob die Master‑Folien beim Scannen des Textes mit einbezogen werden sollen.  
   Die Methode gibt ein Array von TextFrame‑Objekten zurück, das die Textformatierungsinformationen enthält. Der nachstehende Code scannt den Text und die Formatierungsinformationen einer Präsentation, einschließlich der Master‑Folien.

**C#**
``` cpp

 //Instanziiere Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pptxPresentation = new Presentation(path + "demo.pptx");

 //Erhalte ein Array von ITextFrame-Objekten aus allen Folien der PPTX
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

 //Durchlaufe das Array von TextFrames
for (int i = 0; i < textFramesPPTX.Length; i++)

    //Durchlaufe Absätze im aktuellen ITextFrame
    foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

        //Durchlaufe Portionen im aktuellen IParagraph
        foreach (IPortion port in para.Portions)

        {
            //Text im aktuellen Portion anzeigen
            Console.WriteLine(port.Text);
            //Schriftgröße des Textes anzeigen
            Console.WriteLine(port.PortionFormat.FontHeight);
            //Schriftname des Textes anzeigen
            if (port.PortionFormat.LatinFont != null)
                Console.WriteLine(port.PortionFormat.LatinFont.FontName);
        }

```



## **Kategorisierte und schnelle Textextraktion**
Die neue statische Methode GetPresentationText wurde zur Klasse Presentation hinzugefügt. Für diese Methode gibt es zwei Überladungen:
``` cpp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)


```


Das Argument des Enumerationstyps ExtractionMode gibt den Modus zur Organisation des Ausgabetextes an und kann auf folgende Werte gesetzt werden:
Unarranged – Der Rohtext ohne Rücksicht auf die Position auf der Folie  
Arranged – Der Text wird in derselben Reihenfolge wie auf der Folie angeordnet

Der Unarranged‑Modus kann verwendet werden, wenn Geschwindigkeit entscheidend ist; er ist schneller als der Arranged‑Modus.

PresentationText stellt den aus der Präsentation extrahierten Rohtext dar. Es enthält eine SlidesText‑Eigenschaft aus dem Namespace Aspose.Slides.Util, die ein Array von ISlideText‑Objekten zurückgibt. Jedes Objekt repräsentiert den Text auf der entsprechenden Folie. Das ISlideText‑Objekt verfügt über die folgenden Eigenschaften:

ISlideText.Text – Der Text auf den Formen der Folie  
ISlideText.MasterText – Der Text auf den Formen der Master‑Seite für diese Folie  
ISlideText.LayoutText – Der Text auf den Formen der Layout‑Seite für diese Folie  
ISlideText.NotesText – Der Text auf den Formen der Notizenseite für diese Folie  

Zusätzlich gibt es die Klasse SlideText, die das ISlideText‑Interface implementiert.

Die neue API kann wie folgt verwendet werden:
``` cpp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);


```
