---
title: "So extrahieren Sie Text aus PPT, PPTX und ODP mit Aspose.Slides"
linktitle: "Folien"
type: docs
weight: 30
url: /de/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- "Cloud-Plattformen"
- "Cloud-Integration"
- "Textextraktion"
- "Text extrahieren"
- "PPT"
- "PPTX"
- "ODP"
- "Präsentationsdateien"
- "plattformübergreifend"
- "Office-unabhängig"
- "Notizen und Kommentare"
- "Unternehmensindexierung"
- "Datenanreicherung"
- ".NET"
- "Aspose.Slides"
description: "Extrahieren Sie Text aus Präsentationen auf populären Cloud-Plattformen mit den Aspose.Slides APIs und automatisieren Sie Suche, Analyse und Export für PPT, PPTX und ODP."
---

## **Einführung**

Aspose.Slides bietet eine **leistungsstarke, hochrangige API** zum Extrahieren von Text aus Präsentationsdateien, einschließlich **PPT, PPTX und ODP**. Im Gegensatz zum Open XML SDK, das nur PPTX unterstützt und komplexe XML‑Parsing‑Vorgänge erfordert, vereinfacht Aspose.Slides die Textextraktion, sodass Sie sich darauf konzentrieren können, den extrahierten Inhalt in Ihre Workflows zu integrieren.

## **Schnelle Textextraktion mit PresentationFactory.Instance.GetPresentationText**

Um Text aus einer Präsentation zu extrahieren, bietet die **Aspose.Slides API** die statische Methode `PresentationFactory.Instance.GetPresentationText`. Sie enthält mehrere Überladungen für die Arbeit mit einer Präsentationsdatei oder einem Datenstrom und erfasst Text aus **Folien, Masterfolien, Layouts, Notizen und Kommentaren**. Der extrahierte Text wird über das Interface `IPresentationText` abgerufen.

Example usage:
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


## **Betriebsmodi für GetPresentationText**

Die Methode `GetPresentationText` in `PresentationFactory` ermöglicht es Ihnen, die Textextraktion mithilfe des Parameters `TextExtractionArrangingMode` fein abzustimmen, der steuert, wie der Text in der Ausgabe organisiert wird.

### **Verfügbare Modi**

- **TextExtractionArrangingMode.Unarranged** – Extrahiert Text in freier Form und ignoriert das ursprüngliche Folienlayout.  
- **TextExtractionArrangingMode.Arranged** – Bewahrt die Textreihenfolge gemäß seiner Platzierung auf jeder Folie.  

Usage example:
```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```


## **Wesentliche Vorteile der PresentationFactory-Methoden**

- **Keine Notwendigkeit, komplette Präsentationen zu laden**: Minimiert den Speicherverbrauch und erhöht die Verarbeitungsgeschwindigkeit.  
- **Optimiert für große Dateien**: Bewältigt selbst umfangreiche Präsentationen effizient und extrahiert Text schnell.  
- **Ruft Notizen und Kommentare ab**: Enthält Benutzeranmerkungen für eine umfassende Inhaltsabdeckung.  
- **Ideal für Indexierung und Inhaltsanalyse**: Perfekt für Unternehmenssysteme, die automatisierte Verarbeitung und Datenanreicherung benötigen.  
- **Office-unabhängig**: Arbeitet ohne installiertes Microsoft PowerPoint und bietet eine völlig eigenständige Lösung.  
- **Mehrformatunterstützung**: Funktioniert nahtlos mit **PPT, PPTX und ODP**.  
- **Flexible, leistungsstarke API**: Bietet vielseitige Methoden für die strukturierte Textextraktion.  
- **Vollständige Folienabdeckung**: Extrahiert Text aus **Layouts, Masterfolien, Standardfolien, Hintergründen, Referenten-Notizen und Kommentaren**.  
- **Plattformübergreifende Kompatibilität**: Läuft auf **Windows, Linux, macOS** und in Cloud‑Umgebungen.  
- **Hohe Leistung und Skalierbarkeit**: Geeignet für **SaaS‑Anwendungen** und groß angelegte Unternehmensbereitstellungen.  

## **Unterstützte Betriebssysteme**

Aspose.Slides läuft auf einer Vielzahl von Betriebssystemen:

- **Windows** (z. B. Windows 7, 8, 10, 11 und Server‑Editionen)  
- **Linux** (verschiedene Distributionen, darunter Ubuntu, Debian, Fedora, CentOS usw.)  
- **macOS** (einschließlich moderner Versionen wie 10.15 Catalina und neuer)  

## **Unterstützte Programmiersprachen**

Aspose.Slides integriert sich in mehrere Plattformen und Sprachen:

- **C#** – Hauptsächlich unterstützt über Aspose.Slides für .NET.  
- **Java** – Vollwertige API verfügbar mit Aspose.Slides für Java.  
- **C++** – Nutzen Sie Aspose.Slides für leistungskritische C++‑Anwendungen.  
- **Python via .NET** – Integrieren Sie die Funktionalität von Aspose.Slides über .NET‑Interoperabilität.  
- **Weitere .NET‑kompatible Sprachen** – Verwenden Sie die Bibliothek in jeder von .NET unterstützten Umgebung.  

## **Fazit**

Aspose.Slides liefert **umfassende Textextraktion** für PowerPoint‑ und OpenDocument‑Präsentationen und unterstützt **verschiedene Dateiformate, intuitive Textstrukturierung und unkomplizierte Implementierung** im Vergleich zum Open XML SDK. Von **Folien und Notizen bis hin zu Vorlageninhalten** ist **Aspose.Slides** eine hocheffiziente, funktionsreiche Lösung zum Extrahieren und Verwalten von Präsentationstexten.