---
title: Aspose.Slides evaluieren
type: docs
weight: 120
url: /de/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides evaluieren
- Aspose.Slides Bewertung
- Evaluierungs-Version
- volle Funktionalität
- Evaluierungs-Wasserzeichen
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
## **Aspose.Slides Evaluation**

Sie können Aspose.Slides zur Evaluierung herunterladen. Das Evaluierungspaket ist identisch mit dem erworbenen Paket; es wird lizenziert, sobald Sie ein paar Code‑Zeilen hinzufügen, um die Lizenz anzuwenden.

Ohne Lizenz stellt Aspose.Slides seine volle Funktionalität im Evaluierungs‑Modus bereit, jedoch mit zwei Einschränkungen: Es fügt jeder Folie jeder gespeicherten Präsentation ein Textfeld mit einem Evaluierungs‑Wasserzeichen hinzu, und Text, den Ihr Code aus einer Präsentation liest, wird auf die ersten wenigen Zeichen gekürzt und mit einem Hinweis auf die Evaluierungs‑Einschränkung versehen. Text, den Ihr Code schreibt, wird vollständig gespeichert.

![Eine Folie mit dem Evaluierungswasserzeichen](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Hinweis" %}}
Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungs‑Version testen möchten, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie unter [Wie erhalte ich eine temporäre Lizenz?](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Evaluierungspaket installieren**

```bash
dotnet add package Aspose.Slides.NET
```

Unter Linux und macOS können Sie stattdessen das Paket Aspose.Slides.NET6.CrossPlatform verwenden; siehe [Installation](/slides/de/net/installation/).

## **Lizenz anwenden**

Dies sind die „einige Code‑Zeilen“, die das Evaluierungspaket in ein lizenziertes verwandeln. Wenden Sie die Lizenz einmal beim Anwendungsstart an, bevor ein `Presentation`‑Objekt erstellt wird – eine bereits erstellte Präsentation behält das Evaluierungs‑Wasserzeichen bei.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` akzeptiert zudem einen `Stream`, was die bessere Option ist, wenn die Lizenz als eingebettete Ressource und nicht als Datei auf der Festplatte bereitgestellt wird. Ist der Pfad falsch oder ist die Datei abgelaufen, wirft der Aufruf eine Ausnahme, sodass Fehler sofort beim Start sichtbar werden, anstatt stillschweigend in den Evaluierungs‑Modus zurückzukehren.

Nachdem die Lizenz angewendet wurde, enthalten gespeicherte Präsentationen das Wasserzeichen nicht mehr, und Texte werden vollständig ausgelesen.

## **FAQ**

### Kann ich mehrere Präsentationen gleichzeitig in verschiedenen Threads im Evaluierungs‑Modus testen?

Ja. Sie können verschiedene Dokumente parallel verarbeiten; das gleiche Präsentations‑Objekt sollten Sie nicht über mehrere Threads hinweg teilen [über Threads hinweg](/slides/de/net/multithreading/). Der Evaluierungs‑Modus hat darauf keinen Einfluss.

### Muss ich Microsoft PowerPoint installieren, um die Bibliothek auf einem Server oder in CI zu evaluieren?

Nein. Aspose.Slides ist eine eigenständige Engine und benötigt weder für die Evaluierung noch für den Produktionseinsatz PowerPoint.

### Kann ich die Konvertierung von PPT/PPTX zu PDF und Bildern im Evaluierungs‑Modus vollständig testen?

Ja. Die [Konverter](/slides/de/net/convert-presentation/) funktionieren; die Ausgabe enthält ein Wasserzeichen.

### Kann ich eine temporäre Lizenz für Lasttests ohne Wasserzeichen verwenden?

Ja. Eine 30‑tägige temporäre Lizenz entfernt die Einschränkungen des Evaluierungs‑Modus und ermöglicht Tests ohne Wasserzeichen.