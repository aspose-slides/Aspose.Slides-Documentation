---
title: Aspose.Slides evaluieren
type: docs
weight: 120
url: /de/nodejs-java/evaluate-aspose-slides/
keywords:
- Aspose.Slides evaluieren
- Aspose.Slides Evaluierung
- Evaluierungsversion
- volle Funktionalität
- Evaluierungswasserzeichen
- Aspose.Slides erwerben
- Einschränkung
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Evaluieren Sie Aspose.Slides für Node.js über Java und erkunden Sie API‑Funktionen für PowerPoint (PPT, PPTX) und OpenDocument (ODP) Präsentationen – starten Sie Ihre kostenlose Probe."
---
## **Aspose.Slides Evaluierung**

Sie können Aspose.Slides zur Evaluierung herunterladen. Das Evaluierungspaket ist identisch mit dem erworbenen Paket; es wird lizenziert, nachdem Sie ein paar Codezeilen hinzugefügt haben, um die Lizenz anzuwenden. Zur Installation siehe [Installation](/slides/de/nodejs-java/installation/).

Ohne Lizenz bietet Aspose.Slides seine volle Funktionalität im Evaluierungsmodus, jedoch mit zwei Einschränkungen: Es fügt jeder Folie jeder gespeicherten Präsentation ein Evaluierungswasserzeichen‑Textfeld hinzu, und Text, der länger als fünf Zeichen ist und den Ihr Code aus einer Präsentation liest, wird auf die ersten fünf Zeichen gekürzt, gefolgt von `... text has been truncated due to evaluation version limitation.` Texte mit fünf Zeichen oder weniger werden unverändert zurückgegeben, und Text, den Ihr Code schreibt, wird vollständig gespeichert. Jeder Speicher‑Vorgang fügt ein Wasserzeichen hinzu, sodass eine Präsentation, die im Evaluierungsmodus geöffnet und erneut gespeichert wird, pro Speicher­vorgang ein Wasserzeichen auf jeder Folie enthält.

{{% alert color="info" title="Note" %}}
Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungsversion testen möchten, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie unter [Wie man eine temporäre Lizenz erhält?](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **FAQ**

### Kann ich mehrere Präsentationen parallel über verschiedene Threads im Evaluierungsmodus testen?

Ja. Sie können verschiedene Dokumente parallel verarbeiten; Sie sollten das gleiche Präsentationsobjekt nicht [über Threads](/slides/de/nodejs-java/multithreading/) teilen. Der Evaluierungsmodus hat darauf keinen Einfluss.

### Muss ich Microsoft PowerPoint installieren, um die Bibliothek auf einem Server oder in CI zu evaluieren?

Nein. Aspose.Slides ist eine eigenständige Engine und erfordert weder für die Evaluierung noch für den Produktionseinsatz eine installierte PowerPoint-Version.

### Kann ich die Konvertierung von PPT/PPTX zu PDF und Bildern im Evaluierungsmodus vollständig testen?

Ja. Die [Konverter](/slides/de/nodejs-java/convert-presentation/) funktionieren; die Ausgabe enthält ein Wasserzeichen.

### Kann ich eine temporäre Lizenz für Lasttests ohne Wasserzeichen verwenden?

Ja. Eine 30‑tägige temporäre Lizenz entfernt die Einschränkungen des Evaluierungsmodus und ermöglicht Tests ohne Wasserzeichen.