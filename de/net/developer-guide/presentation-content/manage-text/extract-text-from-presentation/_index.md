---
title: Text aus Präsentation extrahieren
type: docs
weight: 90
url: /net/extract-text-from-presentation/
keywords: "Text von Folie extrahieren, Text aus PowerPoint extrahieren, C#, Csharp, Aspose.Slides für .NET"
description: "Text aus Folie oder PowerPoint-Präsentation in C# oder .NET extrahieren"
---

{{% alert color="primary" %}} 

Es ist nicht ungewöhnlich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Um dies zu tun, müssen Sie den Text aus allen Formen auf allen Folien in einer Präsentation extrahieren. Dieser Artikel erklärt, wie man Text aus Microsoft PowerPoint PPTX-Präsentationen mithilfe von Aspose.Slides extrahiert. Text kann auf folgende Arten extrahiert werden:

- [Text von einer Folie extrahieren](/slides/net/extracting-text-from-the-presentation/)
- [Text mit der GetAllTextBoxes-Methode extrahieren](/slides/net/extracting-text-from-the-presentation/)
- [Kategorisierte und schnelle Textextraktion](/slides/net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Text von Folie extrahieren**
Aspose.Slides für .NET bietet den Namespace Aspose.Slides.Util, der die Klasse SlideUtil enthält. Diese Klasse stellt eine Reihe von überladenen statischen Methoden zur Verfügung, um den gesamten Text aus einer Präsentation oder Folie zu extrahieren. Um den Text aus einer Folie in einer PPTX-Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextboxes), die von der Klasse SlideUtil bereitgestellt wird. Diese Methode akzeptiert das Slide-Objekt als Parameter. 
Bei der Ausführung scannt die Slide-Methode den gesamten Text von der als Parameter übergebenen Folie und gibt ein Array von TextFrame-Objekten zurück. Das bedeutet, dass alle Textformatierungen, die mit dem Text verbunden sind, verfügbar sind. Der folgende Code extrahiert allen Text auf der ersten Folie der Präsentation:

```c#
//Instatiate Presentation class that represents a PPTX file
Presentation pptxPresentation = new Presentation("demo.pptx");

//Get an Array of ITextFrame objects from all slides in the PPTX
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//Loop through the Array of TextFrames
for (int i = 0; i < textFramesPPTX.Length; i++)
{
	//Loop through paragraphs in current ITextFrame
	foreach (IParagraph para in textFramesPPTX[i].Paragraphs)
	{
		//Loop through portions in the current IParagraph
		foreach (IPortion port in para.Portions)
		{
			//Display text in the current portion
			Console.WriteLine(port.Text);

			//Display font height of the text
			Console.WriteLine(port.PortionFormat.FontHeight);

			//Display font name of the text
			if (port.PortionFormat.LatinFont != null)
				Console.WriteLine(port.PortionFormat.LatinFont.FontName);
		}
	}
}
```




## **Text aus Präsentation extrahieren**
Um den Text aus der gesamten Präsentation zu scannen, verwenden Sie die überladene statische Methode [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextframes), die von der Klasse SlideUtil bereitgestellt wird. Sie akzeptiert zwei Parameter:

1. Zuerst ein Präsentationsobjekt, das die PPTX-Präsentation darstellt, aus der der Text extrahiert wird.
1. Zweitens ein boolescher Wert, der angibt, ob die Masterfolie in den gescannten Text aus der Präsentation einbezogen werden soll.
   Die Methode gibt ein Array von TextFrame-Objekten zurück, das mit Informationen zur Textformatierung versehen ist. Der folgende Code scannt den Text und die Formatierungsinformationen aus einer Präsentation, einschließlich der Masterfolien.

```c#
//Instatiate Presentation class that represents a PPTX file
Presentation pptxPresentation = new Presentation("demo.pptx");

//Get an Array of ITextFrame objects from all slides in the PPTX
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//Loop through the Array of TextFrames
for (int i = 0; i < textFramesPPTX.Length; i++)

	//Loop through paragraphs in current ITextFrame
	foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

		//Loop through portions in the current IParagraph
		foreach (IPortion port in para.Portions)
		{
			//Display text in the current portion
			Console.WriteLine(port.Text);

			//Display font height of the text
			Console.WriteLine(port.PortionFormat.FontHeight);

			//Display font name of the text
			if (port.PortionFormat.LatinFont != null)
				Console.WriteLine(port.PortionFormat.LatinFont.FontName);
		}
```




## **Kategorisierte und schnelle Textextraktion**
Die neue statische Methode GetPresentationText wurde zur Präsentationsklasse hinzugefügt. Es gibt zwei Überladungen dieser Methode:

``` csharp
PresentationText GetPresentationText(Stream stream)
PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
```

Das Argument ExtractionMode enum gibt den Modus an, um die Ausgabe des Textergebnisses zu organisieren, und kann auf die folgenden Werte gesetzt werden:
Unarranged - Der rohe Text ohne Berücksichtigung der Position auf der Folie
Arranged - Der Text ist in derselben Reihenfolge wie auf der Folie angeordnet

Der Unarranged-Modus kann verwendet werden, wenn Geschwindigkeit entscheidend ist; er ist schneller als der Arranged-Modus.

PresentationText stellt den rohen Text dar, der aus der Präsentation extrahiert wurde. Er enthält eine SlidesText-Eigenschaft aus dem Namespace Aspose.Slides.Util, die ein Array von ISlideText-Objekten zurückgibt. Jedes Objekt repräsentiert den Text auf der entsprechenden Folie. ISlideText-Objjekte haben die folgenden Eigenschaften:

ISlideText.Text - Der Text auf den Formen der Folie
ISlideText.MasterText - Der Text auf den Formen der Masterseite für diese Folie
ISlideText.LayoutText - Der Text auf den Formen der Layoutseite für diese Folie
ISlideText.NotesText - Der Text auf den Formen der Notizseite für diese Folie

Es gibt auch eine Klasse SlideText, die das ISlideText-Interface implementiert.

Die neue API kann wie folgt verwendet werden:

```c#
IPresentationText text1 = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);
```