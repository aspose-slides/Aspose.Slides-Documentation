---
title: Aspose.Slides evaluieren
type: docs
weight: 120
url: /de/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides evaluieren
- Aspose.Slides Bewertung
- Evaluierungsversion
- Vollständige Funktionalität
- Evaluierungswasserzeichen
- Aspose.Slides kaufen
- Einschränkung
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Evaluieren Sie Aspose.Slides für .NET und erkunden Sie API-Funktionen für PowerPoint (PPT, PPTX) und OpenDocument (ODP) Präsentationen - starten Sie Ihre kostenlose Testversion."
---
## **Aspose.Slides Evaluation**

Sie können Aspose.Slides ganz einfach zum Testen herunterladen. Das Evaluierungspaket ist identisch mit dem erworbenen Paket. Die Evaluierungsversion wird einfach lizenziert, wenn Sie ein paar Codezeilen hinzufügen, um die Lizenz anzuwenden.

Die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) bietet die volle Funktionalität des Produkts, fügt jedoch beim Öffnen und Speichern ein Evaluierungswasserzeichen oben im Dokument ein. Außerdem sind Sie beim Extrahieren von Texten aus Präsentationsfolien auf eine Folie beschränkt.

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="primary" %}} 

Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungsversion testen möchten, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie unter [How to get a Temporary License?](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Install the Evaluation Package**

```bash
dotnet add package Aspose.Slides.NET
```

## **Apply a License**

Dies sind die „ein paar Codezeilen“, die das Evaluierungspaket in ein lizenziertes Paket verwandeln. Wenden Sie die Lizenz einmal beim Anwendungsstart an, bevor irgendein `Presentation`‑Objekt erstellt wird — eine zuvor erstellte Präsentation behält das Evaluierungswasserzeichen.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` akzeptiert außerdem einen `Stream`, was die bessere Option ist, wenn die Lizenz als eingebettete Ressource und nicht als Datei auf dem Datenträger bereitgestellt wird. Ist der Pfad falsch oder ist die Datei abgelaufen, wirft der Aufruf eine Ausnahme, sodass Fehler sofort beim Starten sichtbar werden statt stillschweigend in den Evaluierungsmodus zurückzukehren.

Nachdem die Lizenz angewendet wurde, verschwindet das Wasserzeichen und die Beschränkung auf einen Folientext‑Extraktions‑Slide wird aufgehoben.

## **FAQ**

### Kann ich im Evaluierungsmodus mehrere Präsentationen parallel in verschiedenen Threads testen?

Ja. Sie können verschiedene Dokumente parallel verarbeiten; Sie sollten das gleiche Präsentationsobjekt nicht über Threads hinweg teilen [/slides/de/net/multithreading/](across threads). Der Evaluierungsmodus hat darauf keinen Einfluss.

### Muss ich Microsoft PowerPoint installieren, um die Bibliothek auf einem Server oder in CI zu evaluieren?

Nein. Aspose.Slides ist eine eigenständige Engine und erfordert weder für die Evaluierung noch für die Produktion eine installierte PowerPoint‑Version.

### Kann ich die Konvertierung von PPT/PPTX zu PDF und Bildern im Evaluierungsmodus vollständig testen?

Ja. Die [converters](/slides/de/net/convert-presentation/) funktionieren; die Ausgabe enthält ein Wasserzeichen.

### Kann ich eine temporäre Lizenz für Lasttests ohne Wasserzeichen verwenden?

Ja. Eine 30‑tägige temporäre Lizenz entfernt die Einschränkungen des Evaluierungsmodus und ermöglicht Tests ohne Wasserzeichen.