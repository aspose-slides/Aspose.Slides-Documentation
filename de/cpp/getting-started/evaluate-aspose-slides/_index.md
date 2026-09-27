---
title: Aspose.Slides evaluieren
type: docs
weight: 110
url: /de/cpp/evaluate-aspose-slides/
keywords:
- Aspose.Slides evaluieren
- Aspose.Slides Evaluierung
- Evaluierungsversion
- volle Funktionalität
- Evaluierungs-Wasserzeichen
- Aspose.Slides kaufen
- Einschränkung
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Evaluieren Sie Aspose.Slides für C++ und entdecken Sie API-Funktionen für PowerPoint (PPT, PPTX) und OpenDocument (ODP) Präsentationen - starten Sie Ihre kostenlose Testphase."
---
## **Aspose.Slides Evaluierung**

Sie können Aspose.Slides zur Evaluierung herunterladen. Das Evaluierungspaket ist dasselbe wie das gekaufte Paket; es wird lizenziert, nachdem Sie ein paar Codezeilen hinzugefügt haben, um die Lizenz anzuwenden, wie im [Lizenzierung](/slides/de/cpp/licensing/) gezeigt.

Ohne Lizenz stellt Aspose.Slides seine volle Funktionalität im Evaluierungsmodus bereit, jedoch mit zwei Einschränkungen:

* Es fügt jeder gespeicherten Präsentation ein Evaluierungs‑Wasserzeichen‑Textfeld in die Mitte jeder Folie hinzu. Das Öffnen einer Präsentation fügt kein Wasserzeichen hinzu, aber ein zuvor gespeichertes Wasserzeichen wird als Form auf der Folie geladen. Wenn Sie also eine in Evaluierungsmodus gespeicherte Präsentation öffnen und erneut speichern, hat jede Folie zwei Wasserzeichen.
* Text, den Ihr Code aus einer Präsentation liest, wird auf die ersten paar Zeichen gekürzt, gefolgt von einem Hinweis auf die Evaluierungs‑Einschränkung. Das gilt für jede Folie und auch für Text, den Ihr Code gerade gesetzt hat. Text, den Ihr Code schreibt, wird vollständig gespeichert.

{{% alert color="info" title="Note" %}}
Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungs‑Version testen möchten, können Sie auch eine 30‑tägige temporäre Lizenz anfordern. Bitte beachten Sie [Wie erhält man eine temporäre Lizenz?](https://purchase.aspose.com/temporary-license)
{{% /alert %}}

## **FAQ**

### Kann ich mehrere Präsentationen parallel in verschiedenen Threads im Evaluierungsmodus testen?

Ja. Sie können verschiedene Dokumente parallel verarbeiten; Sie sollten das gleiche Präsentationsobjekt nicht [über Threads](/slides/de/cpp/multithreading/) teilen. Der Evaluierungsmodus hat darauf keinen Einfluss.

### Muss ich Microsoft PowerPoint installieren, um die Bibliothek auf einem Server oder in CI zu evaluieren?

Nein. Aspose.Slides ist eine eigenständige Engine und erfordert weder für die Evaluierung noch für die Produktion eine installierte PowerPoint‑Installation.

### Kann ich die Konvertierung von PPT/PPTX zu PDF und Bildern im Evaluierungsmodus vollständig testen?

Ja. Die [Konverter](/slides/de/cpp/convert-presentation/) funktionieren; die Ausgabe enthält ein Wasserzeichen.

### Kann ich eine temporäre Lizenz für Lasttests ohne Wasserzeichen verwenden?

Ja. Eine 30‑tägige temporäre Lizenz entfernt die Einschränkungen des Evaluierungsmodus und ermöglicht Tests ohne Wasserzeichen.