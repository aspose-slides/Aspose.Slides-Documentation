---
title: Text aus Präsentation extrahieren
type: docs
weight: 90
url: /de/python-net/extract-text-from-presentation/
keywords: "Text aus Folie extrahieren, Text aus PowerPoint extrahieren, Python, Aspose.Slides für Python über .NET"
description: "Text aus Folie oder PowerPoint-Präsentation in Python extrahieren"
---

{{% alert color="primary" %}} 

Es ist nicht unüblich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Um dies zu tun, müssen Sie den Text aus allen Formen auf allen Folien einer Präsentation extrahieren. Dieser Artikel erklärt, wie man Text aus Microsoft PowerPoint PPTX-Präsentationen mit Aspose.Slides extrahiert. Text kann auf folgende Weise extrahiert werden:

- [Text aus einer Folie extrahieren](/slides/de/python-net/extracting-text-from-the-presentation/)
- [Text mit der Methode GetAllTextBoxes extrahieren](/slides/de/python-net/extracting-text-from-the-presentation/)
- [Kategorisierte und schnelle Textextraktion](/slides/de/python-net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Text aus Folie extrahieren**
Aspose.Slides für Python über .NET bietet den Namensraum Aspose.Slides.Util, der die Klasse SlideUtil enthält. Diese Klasse stellt eine Reihe von überladenen statischen Methoden zur Verfügung, um den gesamten Text aus einer Präsentation oder Folie zu extrahieren. Um den Text aus einer Folie in einer PPTX-Präsentation zu extrahieren, verwenden Sie die [GetAllTextBoxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) überladene statische Methode der Klasse SlideUtil. Diese Methode akzeptiert das Slide-Objekt als Parameter.
Bei der Ausführung scannt die Slide-Methode den gesamten Text aus der übergebenen Folie und gibt ein Array von TextFrame-Objekten zurück. Das bedeutet, dass alle mit dem Text verbundenen Textformatierungen verfügbar sind. Der folgende Code extrahiert den gesamten Text auf der ersten Folie der Präsentation:

```py
import aspose.slides as slides

#Instanziere die Präsentationsklasse, die eine PPTX-Datei darstellt
with slides.Presentation("pres.pptx") as pptxPresentation:
    # Holen Sie sich ein Array von ITextFrame-Objekten von allen Folien in der PPTX
    textFramesPPTX = slides.util.SlideUtil.get_all_text_boxes(pptxPresentation.slides[0])
    
    # Schleifen Sie durch das Array von TextFrames
    for i in range(len(textFramesPPTX)):
	    # Schleifen Sie durch Absätze im aktuellen ITextFrame
        for para in textFramesPPTX[i].paragraphs:
            # Schleifen Sie durch Teile im aktuellen IParagraph
            for port in para.portions:
			    # Zeigen Sie den Text im aktuellen Teil an
                print(port.text)

    			# Zeigen Sie die Schriftgröße des Textes an
                print(port.portion_format.font_height)

			    # Zeigen Sie den Schriftartnamen des Textes an
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **Text aus Präsentation extrahieren**
Um den Text aus der gesamten Präsentation zu scannen, verwenden Sie die
 [GetAllTextFrames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) statische Methode der Klasse SlideUtil. Sie nimmt zwei Parameter:

1. Zuerst ein Presentation-Objekt, das die PPTX-Präsentation darstellt, aus der der Text extrahiert wird.
2. Zweitens ein boolescher Wert, der bestimmt, ob die Masterfolie einbezogen werden soll, wenn der Text aus der Präsentation gescannt wird.
   Die Methode gibt ein Array von TextFrame-Objekten zurück, das mit Informationen zur Textformatierung versehen ist. Der folgende Code scannt den Text und die Formatierungsinformationen aus einer Präsentation, einschließlich der Masterfolien.

```py
import aspose.slides as slides

#Instanziere die Präsentationsklasse, die eine PPTX-Datei darstellt
with slides.Presentation("pres.pptx") as pptxPresentation:
    # Holen Sie sich ein Array von ITextFrame-Objekten von allen Folien in der PPTX
    textFramesPPTX = slides.util.SlideUtil.get_all_text_frames(pptxPresentation, True)
    
    # Schleifen Sie durch das Array von TextFrames
    for i in range(len(textFramesPPTX)):
	    # Schleifen Sie durch Absätze im aktuellen ITextFrame
        for para in textFramesPPTX[i].paragraphs:
            # Schleifen Sie durch Teile im aktuellen IParagraph
            for port in para.portions:
			    # Zeigen Sie den Text im aktuellen Teil an
                print(port.text)

    			# Zeigen Sie die Schriftgröße des Textes an
                print(port.portion_format.font_height)

			    # Zeigen Sie den Schriftartnamen des Textes an
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **Kategorisierte und schnelle Textextraktion**
Die neue statische Methode GetPresentationText wurde zur Präsentationsklasse hinzugefügt. Es gibt zwei Überladungen für diese Methode:

```py
slides.Presentation.get_presentation_text(stream)
slides.Presentation.get_presentation_text(stream, mode)      
```

Das ExtractedMode-Enum-Argument gibt den Modus an, um die Ausgabe des Textergebnisses zu organisieren, und kann auf folgende Werte gesetzt werden:
Nicht angeordnet - Der Rohtext ohne Berücksichtigung der Position auf der Folie
Angeordnet - Der Text ist in derselben Reihenfolge positioniert wie auf der Folie

Der nicht angeordnete Modus kann verwendet werden, wenn Geschwindigkeit entscheidend ist; er ist schneller als der angeordnete Modus.

PresentationText repräsentiert den Rohtext, der aus der Präsentation extrahiert wurde. Es enthält eine `slides_text`-Eigenschaft aus dem Namensraum Aspose.Slides.Util, die ein Array von SlideText-Objekten zurückgibt. Jedes Objekt repräsentiert den Text auf der entsprechenden Folie. Das SlideText-Objekt hat folgende Eigenschaften:

SlideText.text - Der Text auf den Formen der Folie
SlideText.master_text - Der Text auf den Formen der Masterfolie für diese Folie
SlideText.layout_text - Der Text auf den Formen der Layoutfolie für diese Folie
SlideText.notes_text - Der Text auf den Formen der Notizfolie für diese Folie


Die neue API kann wie folgt verwendet werden:

```py
import aspose.slides as slides

text1 = slides.PresentationFactory().get_presentation_text("pres.pptx", slides.TextExtractionArrangingMode.UNARRANGED)
print(text1.slides_text[0].text)
print(text1.slides_text[0].layout_text)
print(text1.slides_text[0].master_text)
print(text1.slides_text[0].notes_text)
```