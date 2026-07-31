---
title: Erweiterte Textextraktion aus Präsentationen in C++
linktitle: Text extrahieren
type: docs
weight: 90
url: /de/cpp/extract-text-from-presentation/
aliases:
  - /cpp/extracting-text-from-the-presentation/
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
description: "Extrahieren Sie schnell Text aus PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für C++. Folgen Sie unserer einfachen Schritt‑für‑Schritt‑Anleitung, um Zeit zu sparen."
---
## **Übersicht**

Das Extrahieren von Text aus Präsentationen ist eine gängige, aber wesentliche Aufgabe für Entwickler, die mit Folieninhalten arbeiten. Unabhängig davon, ob Sie mit Microsoft PowerPoint‑Dateien im PPT‑ oder PPTX‑Format oder mit OpenDocument‑Präsentationen (ODP) arbeiten, kann der Zugriff auf und das Abrufen von Textdaten für Analysen, Automatisierung, Indexierung oder Inhaltsmigration von entscheidender Bedeutung sein.

Dieser Artikel bietet eine umfassende Anleitung, wie Sie Text effizient aus verschiedenen Präsentationsformaten, einschließlich PPT, PPTX und ODP, mithilfe von Aspose.Slides für C++ extrahieren können. Sie lernen, wie Sie systematisch durch die Präsentationselemente iterieren, um den benötigten Textinhalt genau zu erhalten.

## **Text aus einer Folie extrahieren**

Aspose.Slides für C++ stellt den [Aspose.Slides.Util](https://reference.aspose.com/slides/de/cpp/aspose.slides.util/)‑Namensraum bereit, der die Klasse [SlideUtil](https://reference.aspose.com/slides/de/cpp/aspose.slides.util/slideutil/) enthält. Diese Klasse bietet mehrere überladene statische Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie. Um Text aus einer Folie einer Präsentation zu extrahieren, verwenden Sie die Methode [GetAllTextBoxes](https://reference.aspose.com/slides/de/cpp/aspose.slides.util/slideutil/getalltextboxes/). Diese Methode akzeptiert ein Objekt vom Typ [IBaseSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslide/) als Parameter. Beim Aufruf durchsucht die Methode die gesamte Folie nach Text und gibt ein Array von Objekten vom Typ [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) zurück, wobei sämtliche Textformatierungen beibehalten werden.

Der folgende Codeausschnitt extrahiert den gesamten Text aus der ersten Folie der Präsentation:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Text aus einer Präsentation extrahieren**

Um den Text aus der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [GetAllTextFrames](https://reference.aspose.com/slides/de/cpp/aspose.slides.util/slideutil/getalltextframes/) der Klasse [SlideUtil](https://reference.aspose.com/slides/de/cpp/aspose.slides.util/slideutil/). Sie akzeptiert zwei Parameter:

1. Erstens ein [IPresentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/)‑Objekt, das eine PowerPoint‑ oder OpenDocument‑Präsentation darstellt, aus der Text extrahiert wird.
2. Zweitens ein `Boolean`‑Wert, der angibt, ob die Masterfolien beim Scannen des Textes aus der Präsentation einbezogen werden sollen.

Die Methode gibt ein Array von Objekten vom Typ [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) zurück, einschließlich Informationen zur Textformatierung. Der untenstehende Code scannt den Text und die Formatierungsdetails einer Präsentation, einschließlich der Masterfolien.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Kategorisierte und schnelle Textextraktion**

Die Klasse [PresentationFactory](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentationfactory/) bietet ebenfalls Methoden zum Extrahieren des gesamten Textes aus Präsentationen:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

Das Enum‑Argument [TextExtractionArrangingMode](https://reference.aspose.com/slides/de/cpp/aspose.slides/textextractionarrangingmode/) gibt den Modus zur Anordnung des Textextraktionsergebnisses an und kann auf die folgenden Werte gesetzt werden:
- `Unarranged` - Der Rohtext, ohne Rücksicht auf seine Position auf der Folie.
- `Arranged` - Der Text wird in derselben Reihenfolge wie auf der Folie angeordnet.

Der unarranged‑Modus kann verwendet werden, wenn Geschwindigkeit entscheidend ist; er ist schneller als der arranged‑Modus.

`IPresentationText` repräsentiert den rohen Text, der aus der Präsentation extrahiert wurde. Seine Methode `get_SlidesText()` gibt ein Array von Objekten vom Typ [ISlideText](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidetext/) zurück. Jedes Objekt repräsentiert den Text auf der entsprechenden Folie. Das Objekt vom Typ [ISlideText](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidetext/) verfügt über die folgenden Methoden:

- `get_Text()` - Der Text innerhalb der Formen der Folie.
- `get_MasterText()` - Der Text innerhalb der Formen der Masterfolie, die mit dieser Folie verbunden sind.
- `get_LayoutText()` - Der Text innerhalb der Formen der Layoutfolie, die mit dieser Folie verbunden sind.
- `get_NotesText()` - Der Text innerhalb der Formen der Notizfolie, die mit dieser Folie verbunden sind.
- `get_CommentsText()` - Der Text innerhalb von Kommentaren, die mit dieser Folie verbunden sind.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **FAQ**

**Wie schnell verarbeitet Aspose.Slides große Präsentationen beim Textextrahieren?**

Aspose.Slides ist für hohe Leistung optimiert und kann selbst [große Präsentationen](/slides/de/cpp/open-presentation/) verarbeiten, wodurch es sich für Echtzeit‑ oder Massenszenarien eignet.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja. Aspose.Slides kann Text aus vielen Folienelementen extrahieren, einschließlich Tabellen und diagrammbezogenen Objekten, sodass Sie auf textuelle Inhalte in gängigen Präsentationsstrukturen zugreifen und diese analysieren können.

**Benötige ich eine spezielle Aspose.Slides-Lizenz, um Text aus Präsentationen zu extrahieren?**

Sie können Text mit der kostenlosen Testversion von Aspose.Slides extrahieren, obwohl diese [bestimmte Einschränkungen](/slides/de/cpp/licensing/) hat, z. B. die Verarbeitung einer begrenzten Anzahl von Folien. Für uneingeschränkte Nutzung und zur Verarbeitung größerer Präsentationen wird der Kauf einer vollen Lizenz empfohlen.