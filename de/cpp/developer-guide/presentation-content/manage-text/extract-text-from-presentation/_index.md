---
title: Text aus Präsentation extrahieren
type: docs
weight: 90
url: /de/cpp/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

Es ist nicht ungewöhnlich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Um dies zu tun, müssen Sie den Text aus allen Formen auf allen Folien in einer Präsentation extrahieren. Dieser Artikel erklärt, wie Sie Text aus Microsoft PowerPoint PPTX-Präsentationen mit Aspose.Slides extrahieren können. Der Text kann auf folgende Weise extrahiert werden:

- [Text von einer Folie extrahieren](/slides/de/cpp/extracting-text-from-the-presentation/)
- [Text mit der GetAllTextBoxes-Methode extrahieren](/slides/de/cpp/extracting-text-from-the-presentation/)
- [Kategorisierte und schnelle Textextraktion](/slides/de/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Text von Folie extrahieren**
Aspose.Slides für C++ bietet den Namensraum Aspose.Slides.Util, der die Klasse SlideUtil enthält. Diese Klasse bietet eine Reihe von überladenen statischen Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie. Um den Text aus einer Folie in einer PPTX-Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df), die von der Klasse SlideUtil bereitgestellt wird. Diese Methode akzeptiert das Slide-Objekt als Parameter. 
Beim Ausführen durchforstet die Slide-Methode den gesamten Text von der Folie, die als Parameter übergeben wird, und gibt ein Array von TextFrame-Objekten zurück. Das bedeutet, dass alle mit dem Text verbundenen Textformatierungen verfügbar sind. Der folgende Code extrahiert den gesamten Text auf der ersten Folie der Präsentation:

``` cpp
// Der Pfad zum Dokumentenverzeichnis.
System::String dataDir = GetDataPath();

// Instanzieren Sie die Präsentationsklasse, die eine PPTX-Datei darstellt
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Erhalten Sie ein Array von ITextFrame-Objekten von allen Folien in der PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Schleife durch das Array von TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Schleife durch Absätze im aktuellen ITextFrame
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Schleife durch Portionen im aktuellen IParagraph
		for (const auto& port : para->get_Portions())
		{
			// Text im aktuellen Teil anzeigen
			Console::WriteLine(port->get_Text());

			// Schriftgröße des Textes anzeigen
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Schriftart des Textes anzeigen
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```

## **Text aus Präsentation extrahieren**
Um den Text aus der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12), die von der Klasse SlideUtil bereitgestellt wird. Sie akzeptiert zwei Parameter:

1. Zuerst ein Presentation-Objekt, das die PPTX-Präsentation repräsentiert, aus der der Text extrahiert wird.
1. Zweitens einen Boolean-Wert, der bestimmt, ob die Masterfolie in den Text einbezogen werden soll, wenn der Text aus der Präsentation gescannt wird.
   Die Methode gibt ein Array von TextFrame-Objekten zurück, das vollständige Informationen zur Textformatierung enthält. Der folgende Code scannt den Text und die Formatierungsinformationen aus einer Präsentation, einschließlich der Masterfolien.

``` cpp
// Der Pfad zum Dokumentenverzeichnis.
System::String dataDir = GetDataPath();

// Instanzieren Sie die Präsentationsklasse, die eine PPTX-Datei darstellt
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Erhalten Sie ein Array von ITextFrame-Objekten von allen Folien in der PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Schleife durch das Array von TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Schleife durch Absätze im aktuellen ITextFrame
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Schleife durch Portionen im aktuellen IParagraph
		for (const auto& port : para->get_Portions())
		{
			// Text im aktuellen Teil anzeigen
			Console::WriteLine(port->get_Text());

			// Schriftgröße des Textes anzeigen
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Schriftart des Textes anzeigen
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```

## **Kategorisierte und schnelle Textextraktion**
Die neue statische Methode GetPresentationText wurde zur Präsentationsklasse hinzugefügt. Es gibt zwei Überladungen für diese Methode:

``` cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode) override
 
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode) override
```

Das Argument der Enum TextExtractionArrangingMode gibt den Modus an, um die Ausgabe des Textergebnisses zu organisieren und kann auf folgende Werte gesetzt werden:  
Unarranged - Der rohe Text ohne Berücksichtigung der Position auf der Folie  
Arranged - Der Text ist in der gleichen Reihenfolge wie auf der Folie positioniert

Der Unarranged-Modus kann verwendet werden, wenn Geschwindigkeit entscheidend ist, er ist schneller als der Arranged-Modus.

PresentationText repräsentiert den aus der Präsentation extrahierten Rohtext. Es enthält eine Methode get_SlidesText() aus dem Namensraum Aspose.Slides.Util, die ein Array von ISlideText-Objekten zurückgibt. Jedes Objekt repräsentiert den Text auf der entsprechenden Folie. Das ISlideText-Objekt hat die folgenden Methoden:

get_Text() - Der Text auf den Formen der Folie.  
get_MasterText() - Der Text auf den Formen der Masterfolie für diese Folie.  
get_LayoutText() - Der Text auf den Formen der Layoutfolie für diese Folie.  
get_NotesText() - Der Text auf den Formen der Notizfolie für diese Folie.

Es gibt auch eine Klasse SlideText, die das ISlideText-Interface implementiert.

Die neue API kann folgendermaßen verwendet werden:

``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```