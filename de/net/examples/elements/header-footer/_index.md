---
title: Kopf- und Fußzeile
type: docs
weight: 220
url: /de/net/examples/elements/elements/header-footer/
keywords:
- Beispiel für Kopf- und Fußzeile
- Kopf- und Fußzeile hinzufügen
- Kopf- und Fußzeile aktualisieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Steuern Sie Kopf- und Fußzeilen in C# mit Aspose.Slides: Datum/Uhrzeit, Folienzahlen und Fußzeilentext hinzufügen oder bearbeiten, Platzhalter in PPT, PPTX und ODP anzeigen oder ausblenden."
---

Zeigt, wie man Fußzeilen hinzufügt und Platzhalter für Datum und Uhrzeit mit **Aspose.Slides for .NET** aktualisiert.

## Fußzeile hinzufügen

Text zum Fußzeilenbereich einer Folie hinzufügen und sichtbar machen.
```csharp
static void Add_Header_Footer()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```


## Datum und Uhrzeit aktualisieren

Den Platzhalter für Datum und Uhrzeit auf einer Folie ändern.
```csharp
static void Update_Date_Time()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```
