---
title: Kopfzeile Fußzeile
type: docs
weight: 220
url: /de/net/examples/elements/header-footer/
keywords:
- Kopfzeile Fußzeile
- Kopfzeile Fußzeile hinzufügen
- Kopfzeile Fußzeile aktualisieren
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Steuern Sie Folienkopfzeilen und -fußzeilen mit Aspose.Slides für .NET: Fügen Sie Datumsangaben, Folienzahlen und benutzerdefinierten Text in PPT, PPTX und ODP mit C#‑Beispielen hinzu."
---
Dieser Artikel zeigt, wie man Fußzeilen hinzufügt und Platzhalter für Datum und Uhrzeit aktualisiert, wobei **Aspose.Slides for .NET** verwendet wird.

## **Fußzeile hinzufügen**

Fügen Sie Text zum Fußzeilenbereich einer Folie hinzu und machen Sie ihn sichtbar.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Datum und Uhrzeit aktualisieren**

Ändern Sie den Platzhalter für Datum und Uhrzeit auf einer Folie.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```