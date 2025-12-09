---
title: "Wie man Text aus PPT, PPTX und ODP mit Aspose.Slides extrahiert"
linktitle: Folien
type: docs
weight: 30
url: /de/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- Cloud-Plattformen
- Cloud-Integration
- Textextraktion
- Text extrahieren
- PPT
- PPTX
- ODP
- Präsentationsdateien
- plattformübergreifend
- Office-unabhängig
- Notizen und Kommentare
- Unternehmensindexierung
- Datenanreicherung
- .NET
- Aspose.Slides
description: "Text aus Präsentationen auf beliebten Cloud-Plattformen mit Aspose.Slides APIs extrahieren, Suche, Analyse und Export für PPT, PPTX und ODP automatisieren."
---

# Text extrahieren aus PPT, PPTX und ODP – Folien

Aspose.Slides bietet eine **leistungsstarke, hochgradige API** zum Extrahieren von Text aus Präsentationsdateien, einschließlich **PPT, PPTX und ODP**. Im Gegensatz zum Open XML SDK, das nur PPTX unterstützt und eine komplexe XML-Analyse erfordert, vereinfacht Aspose.Slides die Textextraktion, sodass Sie sich darauf konzentrieren können, den extrahierten Inhalt in Ihre Workflows zu integrieren.

## Schnelle Textextraktion mit PresentationFactory.Instance.GetPresentationText

Um Text aus einer Präsentation zu extrahieren, bietet die **Aspose.Slides API** die statische Methode `PresentationFactory.Instance.GetPresentationText`. Sie enthält mehrere Überladungen für die Arbeit mit einer Präsentationsdatei oder einem Datenstrom und erfasst Text aus **Folien, Master-Folien, Layouts, Notizen und Kommentaren**. Der extrahierte Text wird über das Interface `IPresentationText` abgerufen.

Beispielhafte Verwendung:
```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```


## Betriebsmodi für GetPresentationText

Die Methode `GetPresentationText` in `PresentationFactory` ermöglicht es Ihnen, die Textextraktion mithilfe des Parameters `TextExtractionArrangingMode` fein abzustimmen, der steuert, wie der Text in der Ausgabe organisiert wird.

### Verfügbare Modi:

- **TextExtractionArrangingMode.Unarranged** – Extrahiert Text in freier Form und ignoriert das ursprüngliche Folienlayout.  
- **TextExtractionArrangingMode.Arranged** – Bewahrt die Textreihenfolge gemäß seiner Platzierung auf jeder Folie.  

Beispiel zur Verwendung:
```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```


## Wichtige Vorteile der PresentationFactory-Methoden

- **Keine Notwendigkeit, gesamte Präsentationen zu laden**: Minimiert den Speicherverbrauch und erhöht die Verarbeitungsgeschwindigkeit.  
- **Optimiert für große Dateien**: Handhabt selbst umfangreiche Präsentationen effizient und extrahiert Text schnell.  
- **Ruft Notizen und Kommentare ab**: Enthält Benutzeranmerkungen für eine umfassende Inhaltsabdeckung.  
- **Ideal für Indexierung und Inhaltsanalyse**: Perfekt für Unternehmenssysteme, die automatisierte Verarbeitung und Datenanreicherung benötigen.  
- **Office-unabhängig**: Funktioniert ohne installierten Microsoft PowerPoint und bietet eine echte eigenständige Lösung.  
- **Multi-Format-Unterstützung**: Arbeitet nahtlos mit **PPT, PPTX und ODP**.  
- **Flexibles, leistungsstarkes API**: Bietet vielseitige Methoden für strukturierte Textextraktion.  
- **Vollständige Folienabdeckung**: Extrahiert Text aus **Layouts, Master-Folien, Standard-Folien, Hintergründen, Referenten-Notizen und Kommentaren**.  
- **Plattformübergreifende Kompatibilität**: Läuft auf **Windows, Linux, macOS** und in Cloud-Umgebungen.  
- **Hohe Leistung und Skalierbarkeit**: Geeignet für **SaaS-Anwendungen** und großskalige Unternehmensbereitstellungen.  

## Unterstützte Betriebssysteme

Aspose.Slides läuft auf einer Vielzahl von Betriebssystemen:

- **Windows** (z. B. Windows 7, 8, 10, 11 und Server-Editionen)  
- **Linux** (verschiedene Distributionen, einschließlich Ubuntu, Debian, Fedora, CentOS usw.)  
- **macOS** (einschließlich moderner Versionen wie 10.15 Catalina und höher)  

## Unterstützte Programmiersprachen

Aspose.Slides integriert sich in mehrere Plattformen und Sprachen:

- **C#** – Primär unterstützt über Aspose.Slides für .NET.  
- **Java** – Voll ausgestattete API verfügbar mit Aspose.Slides für Java.  
- **C++** – Nutzen Sie Aspose.Slides für leistungs-kritische C++-Anwendungen.  
- **Python über .NET** – Integrieren Sie die Aspose.Slides-Funktionalität mittels .NET-Interoperabilität.  
- **Andere .NET-kompatible Sprachen** – Verwenden Sie die Bibliothek in jeder von .NET unterstützten Umgebung.  

## Fazit

Aspose.Slides bietet **umfassende Textextraktion** für PowerPoint‑ und OpenDocument‑Präsentationen und unterstützt **verschiedene Dateiformate, intuitive Textstrukturierung und einfache Implementierung** im Vergleich zum Open XML SDK. Von **Folien und Notizen bis hin zu Vorlageninhalten** ist **Aspose.Slides** eine hocheffiziente, funktionsreiche Lösung zum Extrahieren und Verwalten von Präsentationstext.