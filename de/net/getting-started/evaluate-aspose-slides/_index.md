---
title: Aspose.Slides evaluieren
type: docs
weight: 120
url: /de/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides bewerten
- Aspose.Slides Bewertung
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

Sie können Aspose.Slides ganz einfach zum Testen herunterladen. Das Evaluierungspaket ist identisch mit dem erworbenen Paket. Die Evaluierungsversion wird einfach lizenziert, sobald Sie ein paar Codezeilen hinzufügen, um die Lizenz zu aktivieren. 

Die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) bietet die volle Produktfunktionalität, fügt jedoch beim Öffnen und Speichern ein Evaluierungswasserzeichen oben im Dokument ein. Außerdem sind Sie beim Extrahieren von Texten aus Präsentationsfolien auf eine Folie beschränkt.


![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 

Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungsversion testen möchten, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie unter [Wie erhält man eine temporäre Lizenz?](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Evaluierungspaket installieren**

```bash
dotnet add package Aspose.Slides.NET
```

## **Lizenz anwenden**

Dies sind die „einige Codezeilen“, die das Evaluierungspaket in ein lizenziertes umwandeln. Wenden Sie die Lizenz einmal beim Anwendungsstart an, bevor ein `Presentation`‑Objekt erstellt wird – eine zuvor erstellte Präsentation behält das Evaluierungswasserzeichen bei.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` akzeptiert außerdem einen `Stream`, was die bessere Option ist, wenn die Lizenz als eingebettete Ressource und nicht als Datei auf dem Datenträger bereitgestellt wird. Ist der Pfad falsch oder ist die Datei abgelaufen, wirft der Aufruf eine Ausnahme, sodass Fehler sofort beim Start sichtbar werden, anstatt stillschweigend in den Evaluierungsmodus zurückzukehren.

Sobald die Lizenz angewendet ist, verschwindet das Wasserzeichen und die Beschränkung auf die Textextraktion von einer Folie wird aufgehoben.

## **FAQ**

### Kann ich mehrere Präsentationen parallel in verschiedenen Threads im Evaluierungsmodus testen?

Ja. Sie können verschiedene Dokumente parallel verarbeiten; Sie sollten nicht dasselbe Präsentationsobjekt [across threads](/slides/de/net/multithreading/) teilen. Der Evaluierungsmodus beeinträchtigt dies nicht.

### Muss ich Microsoft PowerPoint installieren, um die Bibliothek auf einem Server oder in CI zu evaluieren?

Nein. Aspose.Slides ist eine eigenständige Engine und erfordert weder für die Evaluierung noch für die Produktion eine installierte PowerPoint-Version.

### Kann ich die Konvertierung von PPT/PPTX zu PDF und Bildern im Evaluierungsmodus vollständig testen?

Ja. Die [converters](/slides/de/net/convert-presentation/) funktionieren; die Ausgabe enthält ein Wasserzeichen.

### Kann ich eine temporäre Lizenz für Lasttests ohne Wasserzeichen verwenden?

Ja. Eine 30‑tägige temporäre Lizenz entfernt die Einschränkungen des Evaluierungsmodus und ermöglicht Tests ohne Wasserzeichen.