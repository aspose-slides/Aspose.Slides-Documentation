---
title: Extrahieren von Text aus der Präsentation
type: docs
weight: 60
url: /cpp/extracting-text-from-the-presentation/
---

{{% alert color="primary" %}} 

Es ist nicht ungewöhnlich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Dazu müssen Sie den Text aus allen Formen auf allen Folien in einer Präsentation extrahieren. Dieser Artikel erklärt, wie man Text aus Microsoft PowerPoint PPTX-Präsentationen mit Aspose.Slides extrahiert. Der Text kann auf folgende Weise extrahiert werden:

[Text aus einer Folie extrahieren](/slides/cpp/extracting-text-from-the-presentation/)
[Text mit der GetAllTextBoxes-Methode extrahieren](/slides/cpp/extracting-text-from-the-presentation/)
[Kategorisierte und schnelle Textextraktion](/slides/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Text aus einer Folie extrahieren**
Aspose.Slides für C++ bietet den Namespace Aspose.Slides.Util, der die Klasse PresentationScanner enthält. Diese Klasse stellt eine Reihe überladener statischer Methoden zur Verfügung, um den gesamten Text aus einer Präsentation oder Folie zu extrahieren. Um den Text aus einer Folie in einer PPTX-Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [GetAllTextBoxes](http://docs.aspose.com/display/slidesnet/PresentationScanner+Members), die von der Klasse PresentationScanner bereitgestellt wird. Diese Methode akzeptiert das Slide-Objekt als Parameter.
Bei der Ausführung scannt die Slide-Methode den gesamten Text der als Parameter übergebenen Folie und gibt ein Array von TextFrame-Objekten zurück. Das bedeutet, dass alle mit dem Text verbundenen Textformatierungen verfügbar sind. Der folgende Code extrahiert den gesamten Text auf der ersten Folie der Präsentation:

**C#**

``` cpp

 //Instantiieren Sie die Präsentationsklasse, die eine PPTX-Datei darstellt

Presentation pptxPresentation = new Presentation(path + "demo.pptx");


//Ein Array von TextFrameEx-Objekten von der ersten Folie erhalten

ITextFrame[] textFramesSlideOne = SlideUtil.GetAllTextBoxes(pptxPresentation.Slides[0]);

//Durch das Array von TextFrames iterieren

for (int i = 0; i < textFramesSlideOne.Length; i++)

    //Durch die Absätze im aktuellen TextFrame iterieren

    foreach (Paragraph para in textFramesSlideOne[i].Paragraphs)

        //Durch die Abschnitte im aktuellen Absatz iterieren

        foreach (Portion port in para.Portions)

        {

            //Text im aktuellen Abschnitt anzeigen

            Console.WriteLine(port.Text);

            //Schriftgröße des Textes anzeigen

            Console.WriteLine(port.PortionFormat.FontHeight);

            //Schriftart des Textes anzeigen

            Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }

```

## **Text aus der gesamten Präsentation extrahieren**
Um den Text aus der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [GetAllTextFrames](http://docs.aspose.com/display/slidesnet/PresentationScanner+Members), die von der Klasse PresentationScanner bereitgestellt wird. Sie nimmt zwei Parameter entgegen:

1. Zuerst ein Präsentationsobjekt, das die PPTX-Präsentation darstellt, aus der der Text extrahiert wird.
1. Zweitens ein boolescher Wert, der bestimmt, ob die Masterfolie einbezogen werden soll, wenn der Text aus der Präsentation gescannt wird.
   Die Methode gibt ein Array von TextFrame-Objekten zurück, das vollständige Informationen zur Textformatierung enthält. Der folgende Code scannt den Text und die Formatierungsinformationen aus einer Präsentation, einschließlich der Masterfolien.

**C#**

``` cpp

 //Instantiieren Sie die Präsentationsklasse, die eine PPTX-Datei darstellt

Presentation pptxPresentation = new Presentation(path + "demo.pptx");

//Ein Array von ITextFrame-Objekten von allen Folien in der PPTX erhalten

ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//Durch das Array von TextFrames iterieren

for (int i = 0; i < textFramesPPTX.Length; i++)

    //Durch die Absätze im aktuellen ITextFrame iterieren

    foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

        //Durch die Abschnitte im aktuellen IParagraph iterieren

        foreach (IPortion port in para.Portions)

        {

            //Text im aktuellen Abschnitt anzeigen

            Console.WriteLine(port.Text);

            //Schriftgröße des Textes anzeigen

            Console.WriteLine(port.PortionFormat.FontHeight);

            //Schriftart des Textes anzeigen

            if (port.PortionFormat.LatinFont != null)

                Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }

```

## **Kategorisierte und schnelle Textextraktion**
Die neue statische Methode GetPresentationText wurde zur Präsentationsklasse hinzugefügt. Es gibt zwei Überladungen für diese Methode:

``` cpp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

```

Das Enum-Argument ExtractionMode gibt den Modus an, um das Ergebnis der Textextraktion zu organisieren und kann auf die folgenden Werte gesetzt werden:
Unarranged - Der rohe Text ohne Berücksichtigung der Position auf der Folie
Arranged - Der Text ist in der gleichen Reihenfolge positioniert wie auf der Folie

Der Unarranged-Modus kann verwendet werden, wenn Geschwindigkeit entscheidend ist, er ist schneller als der Arranged-Modus.

PresentationText repräsentiert den rohen Text, der aus der Präsentation extrahiert wurde. Es enthält eine SlidesText-Eigenschaft aus dem Aspose.Slides.Util-Namespace, die ein Array von ISlideText-Objekten zurückgibt. Jedes Objekt repräsentiert den Text auf der entsprechenden Folie. Das ISlideText-Objekt hat die folgenden Eigenschaften:

ISlideText.Text - Der Text auf den Formen der Folie
ISlideText.MasterText - Der Text auf den Formen der Masterseite für diese Folie
ISlideText.LayoutText - Der Text auf den Formen der Layoutseite für diese Folie
ISlideText.NotesText - Der Text auf den Formen der Notizenseite für diese Folie

Es gibt auch eine Klasse SlideText, die das ISlideText-Interface implementiert.

Die neue API kann folgendermaßen verwendet werden:

``` cpp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);

```