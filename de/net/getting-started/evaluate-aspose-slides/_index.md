---
title: Aspose.Slides evaluieren
type: docs
weight: 75
url: /de/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides evaluieren
- Aspose.Slides Evaluierung
- Evaluierungsversion
- volle Funktionalität
- Evaluierungswasserzeichen
- Aspose.Slides kaufen
- Einschränkung
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Evaluieren Sie Aspose.Slides für .NET und entdecken Sie API-Funktionen für PowerPoint (PPT, PPTX) und OpenDocument (ODP) Präsentationen - starten Sie Ihre kostenlose Testversion."
---
## **Aspose.Slides Evaluierung**

Sie können Aspose.Slides zur Evaluierung herunterladen. Das Evaluierungspaket ist identisch mit dem erworbenen Paket; es wird lizenziert, nachdem Sie ein paar Codezeilen hinzugefügt haben, um die Lizenz zu aktivieren.

Ohne Lizenz stellt Aspose.Slides seine volle Funktionalität im Evaluierungsmodus bereit, jedoch mit zwei Einschränkungen: Es fügt jeder Folie jeder gespeicherten Präsentation ein Wasserzeichen‑Textfeld hinzu, und Text, den Ihr Code aus einer Präsentation liest, wird auf die ersten Zeichen gekürzt, gefolgt von einem Hinweis auf die Evaluierungsbeschränkung. Text, den Ihr Code schreibt, wird vollständig gespeichert.

![A slide with the evaluation watermark](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}

Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungsversion testen möchten, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie unter [How to get a Temporary License?](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Installieren des Evaluierungspakets**

```bash
dotnet add package Aspose.Slides.NET
```

Unter Linux und macOS können Sie stattdessen das Aspose.Slides.NET6.CrossPlatform‑Paket verwenden; siehe [Installation](/slides/de/net/installation/).

## **Lizenz anwenden**

Dies sind die „einige Codezeilen“, die das Evaluierungspaket in ein lizenziertes verwandeln. Wenden Sie die Lizenz einmal beim Anwendungsstart an, bevor ein `Presentation`‑Objekt erstellt wird — eine bereits erstellte Präsentation behält das Evaluierungswasserzeichen.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` akzeptiert außerdem einen `Stream`, was die bessere Option ist, wenn die Lizenz als eingebettete Ressource statt einer Datei auf der Festplatte bereitgestellt wird. Ist der Pfad falsch oder ist die Datei abgelaufen, wirft der Aufruf eine Ausnahme, sodass Fehler sofort beim Start sichtbar werden anstatt stillschweigend in den Evaluierungsmodus zurückzuwechseln.

Nachdem die Lizenz angewendet wurde, enthalten gespeicherte Präsentationen das Wasserzeichen nicht mehr und der Text wird vollständig gelesen.

## **FAQ**

### Kann ich mehrere Präsentationen parallel in verschiedenen Threads im Evaluierungsmodus testen?

Ja. Sie können verschiedene Dokumente parallel verarbeiten; Sie sollten das gleiche Präsentationsobjekt nicht über mehrere Threads hinweg teilen [across threads](/slides/de/net/multithreading/). Der Evaluierungsmodus beeinflusst das nicht.

### Muss ich Microsoft PowerPoint installieren, um die Bibliothek auf einem Server oder in CI zu evaluieren?

Nein. Aspose.Slides ist eine eigenständige Engine und erfordert weder PowerPoint für die Evaluierung noch für die Produktion.

### Kann ich die Konvertierung von PPT/PPTX zu PDF und Bildern im Evaluierungsmodus vollständig testen?

Ja. Die [converters](/slides/de/net/convert-presentation/) funktionieren; das Ergebnis enthält ein Wasserzeichen.

### Kann ich eine temporäre Lizenz für Lasttests ohne Wasserzeichen verwenden?

Ja. Eine 30‑tägige temporäre Lizenz entfernt die Einschränkungen des Evaluierungsmodus und ermöglicht Tests ohne Wasserzeichen.