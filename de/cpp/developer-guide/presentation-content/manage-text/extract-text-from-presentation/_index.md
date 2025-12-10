---
title: Erweiterte Textextraktion aus Präsentationen in C++
linktitle: Text extrahieren
type: docs
weight: 90
url: /de/cpp/extract-text-from-presentation/
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
- C++
- Aspose.Slides
description: "Extrahieren Sie schnell Text aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++. Folgen Sie unserer einfachen, schrittweisen Anleitung, um Zeit zu sparen."
---

{{% alert color="primary" %}} 

Es ist nicht ungewöhnlich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Dazu muss der Text aus allen Formen auf allen Folien einer Präsentation extrahiert werden. Dieser Artikel erklärt, wie Text aus Microsoft PowerPoint PPTX‑Präsentationen mit Aspose.Slides extrahiert wird. Text kann auf folgende Weise extrahiert werden:

- [Text aus einer Folie extrahieren](/slides/de/cpp/extracting-text-from-the-presentation/)
- [Text mit der GetAllTextBoxes‑Methode extrahieren](/slides/de/cpp/extracting-text-from-the-presentation/)
- [Kategorisierte und schnelle Textextraktion](/slides/de/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Text aus einer Folie extrahieren**
Aspose.Slides for C++ stellt den Namespace Aspose.Slides.Util bereit, der die Klasse SlideUtil enthält. Diese Klasse bietet mehrere überladene statische Methoden zum Extrahieren des gesamten Texts aus einer Präsentation oder Folie. Um den Text aus einer Folie in einer PPTX‑Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df), die von der SlideUtil‑Klasse bereitgestellt wird. Diese Methode akzeptiert das Slide‑Objekt als Parameter.
Bei der Ausführung scannt die Slide‑Methode den gesamten Text der übergebenen Folie und gibt ein Array von TextFrame‑Objekten zurück. Das bedeutet, dass alle mit dem Text verbundenen Formatierungen verfügbar sind. Der folgende Code extrahiert den gesamten Text der ersten Folie der Präsentation:
``` cpp
// Der Pfad zum Dokumentenverzeichnis.
System::String dataDir = GetDataPath();

// Instanziieren der Presentation-Klasse, die eine PPTX-Datei darstellt
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Ein Array von ITextFrame-Objekten aus allen Folien im PPTX erhalten
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Durch das Array von TextFrames iterieren
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Durch die Absätze im aktuellen ITextFrame iterieren
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Durch die Portionen im aktuellen IParagraph iterieren
		for (const auto& port : para->get_Portions())
		{
			// Text im aktuellen Portion anzeigen
			Console::WriteLine(port->get_Text());

			// Schriftgröße des Textes anzeigen
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Schriftname des Textes anzeigen
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```


## **Text aus einer Präsentation extrahieren**
Um den Text der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12), die von der SlideUtil‑Klasse bereitgestellt wird. Sie nimmt zwei Parameter entgegen:

1. Zunächst ein Presentation‑Objekt, das die PPTX‑Präsentation darstellt, aus der der Text extrahiert wird.
2. Zweitens ein boolescher Wert, der bestimmt, ob die Master‑Folien mit einbezogen werden sollen, wenn der Text aus der Präsentation gescannt wird.

Die Methode gibt ein Array von TextFrame‑Objekten zurück, das vollständige Textformatierungsinformationen enthält. Der untenstehende Code scannt Text und Formatierungsinformationen einer Präsentation, einschließlich der Master‑Folien.
``` cpp
// Der Pfad zum Dokumentenverzeichnis.
System::String dataDir = GetDataPath();

// Instanziieren der Presentation-Klasse, die eine PPTX-Datei darstellt
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Ein Array von ITextFrame-Objekten aus allen Folien im PPTX erhalten
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Durch das Array von TextFrames iterieren
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Durch die Absätze im aktuellen ITextFrame iterieren
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Durch die Portionen im aktuellen IParagraph iterieren
		for (const auto& port : para->get_Portions())
		{
			// Text im aktuellen Portion anzeigen
			Console::WriteLine(port->get_Text());

			// Schriftgröße des Textes anzeigen
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Schriftname des Textes anzeigen
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```


## **Kategorisierte und schnelle Textextraktion**
Die neue statische Methode GetPresentationText wurde der Presentation‑Klasse hinzugefügt. Für diese Methode gibt es zwei Überladungen:
``` cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode) override
 
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode) override
```


Der Enumerationsparameter TextExtractionArrangingMode gibt den Modus zur Anordnung des Textergebnisses an und kann die folgenden Werte annehmen:  
Unarranged – Der Rohtext ohne Rücksicht auf die Position auf der Folie  
Arranged – Der Text wird in derselben Reihenfolge positioniert wie auf der Folie

Der Modus Unarranged kann verwendet werden, wenn Geschwindigkeit entscheidend ist; er ist schneller als der Modus Arranged.

PresentationText repräsentiert den rohen Text, der aus der Präsentation extrahiert wurde. Es enthält die Methode get_SlidesText() aus dem Namespace Aspose.Slides.Util, die ein Array von ISlideText‑Objekten zurückgibt. Jedes Objekt repräsentiert den Text der entsprechenden Folie. Das ISlideText‑Objekt verfügt über die folgenden Methoden:

get_Text() – Der Text in den Formen der Folie.  
get_MasterText() – Der Text in den Formen der Master‑Seite für diese Folie.  
get_LayoutText() – Der Text in den Formen der Layout‑Seite für diese Folie.  
get_NotesText() – Der Text in den Formen der Notizenseite für diese Folie.

Es gibt außerdem die Klasse SlideText, die das ISlideText‑Interface implementiert.

Die neue API kann wie folgt verwendet werden:
``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```


## **FAQ**

**Wie schnell verarbeitet Aspose.Slides große Präsentationen bei der Textextraktion?**

Aspose.Slides ist für hohe Leistung optimiert und verarbeitet selbst große Präsentationen effizient, sodass es sich für Echtzeit‑ oder Batch‑Szenarien eignet.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja, Aspose.Slides unterstützt das vollständige Extrahieren von Text aus Tabellen, Diagrammen und anderen komplexen Folienelementen, sodass Sie allen Textinhalt problemlos zugreifen und analysieren können.

**Benötige ich eine spezielle Aspose.Slides‑Lizenz, um Text aus Präsentationen zu extrahieren?**

Sie können Text mit der kostenlosen Testversion von Aspose.Slides extrahieren, die jedoch Einschränkungen wie die Verarbeitung einer begrenzten Folienzahl hat. Für uneingeschränkte Nutzung und zur Verarbeitung größerer Präsentationen wird der Erwerb einer Voll‑Lizenz empfohlen.