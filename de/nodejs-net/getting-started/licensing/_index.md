---
title: Lizenzierung
description: "Wenden Sie eine Lizenzdatei auf Aspose.Slides für Node.js via .NET an, erfahren Sie, welche Beschränkungen die Evaluierungsversion hat, und erhalten Sie eine kostenlose 30-tägige Temporärlizenz zum Testen."
type: docs
weight: 80
url: /de/nodejs-net/licensing/
---
## **Übersicht**

Aspose.Slides für Node.js via .NET ist ein npm‑Paket sowohl für Evaluation als auch für den produktiven Einsatz. Ohne Lizenz läuft es im Evaluierungsmodus. Nachdem Sie eine Lizenz gekauft haben oder eine kostenlose 30‑tägige Temporärlizenz erhalten haben, wenden Sie sie mit wenigen Codezeilen an, und die Evaluierungsbeschränkungen gelten nicht mehr.

{{% alert color="info" title="Note" %}}
Allgemeine Richtlinien zur Evaluation, Lizenzierung und zum Kauf von Aspose‑Produkten finden Sie in den [Purchase Policies and FAQ](https://purchase.aspose.com/policies). Preise sind auf der Seite [Pricing Information](https://purchase.aspose.com/pricing/slides/de/family) aufgeführt.
{{% /alert %}}

## **Einschränkungen der Evaluierungsversion**

Die Evaluierungsversion bietet die volle Funktionalität des Produkts, jedoch mit zwei Einschränkungen:

- **Wasserzeichen.** Jede Folie jeder Präsentation, die Sie speichern, erhält ein Evaluierungs‑Wasserzeichen: ein gesperrtes Textfeld in der Mitte der Folie mit dem Text „Evaluation only.“ Das gleiche Wasserzeichen wird bei PDF-, XPS‑ und HTML‑Exporten sowie bei Folien‑Bildern eingefügt.
- **Abgekürzter Text.** Text, den Ihr Code aus einem Textfeld, Absatz oder Teil zurückliest, wird auf die ersten fünf Zeichen gekürzt, gefolgt von dem Hinweis „... text has been truncated due to evaluation version limitation.“ Markdown‑ und HTML5‑Exporte werden auf die gleiche Weise gekürzt. Der von Ihrem Code geschriebene Text wird vollständig gespeichert.

[Evaluieren Sie Aspose.Slides](/slides/de/nodejs-net/evaluate-aspose-slides/) beschreibt beide Einschränkungen im Detail und enthält ein Skript, das sie zeigt.

{{% alert color="success" title="Tip" %}}
Um Aspose.Slides ohne die Evaluierungsbeschränkungen zu testen, fordern Sie eine kostenlose **30‑tägige Temporärlizenz** an. Details finden Sie unter [How to get a Temporary License?](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Über die Lizenz**

Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie den Produktnamen, die Anzahl der lizenzierten Entwickler und das Ablaufdatum des Abonnements enthält. Die Datei ist digital signiert, daher dürfen Sie sie nicht ändern: Auch ein versehentlich hinzugefügter Zeilenumbruch macht sie ungültig.

## **Lizenz anwenden**

Wenden Sie die Lizenz mit der Methode `setLicense` der Klasse `License` an. Rufen Sie sie einmal pro Prozess auf, bevor Sie ein `Presentation`‑Objekt erstellen. Ein erneuter Aufruf schadet nicht, führt jedoch zu wiederholter Arbeit.

Das folgende Skript wendet eine Lizenz aus einer Datei namens `Aspose.Slides.lic` an. Ersetzen Sie den Namen durch den Namen oder den vollständigen Pfad Ihrer Lizenzdatei; die Datei kann beliebig benannt werden.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

Ein Dateiname oder relativer Pfad wird relativ zum aktuellen Verzeichnis aufgelöst, also dem Verzeichnis, von dem aus Sie `node` ausführen. Platzieren Sie die Lizenzdatei in Ihrem Projektordner und führen Sie Ihre Skripte von dort aus, oder übergeben Sie den vollständigen Pfad.

Wenn die Datei nicht gefunden wird oder keine gültige Lizenz ist, wirft `setLicense` einen Fehler, und Aspose.Slides bleibt im Evaluierungsmodus. Das Skript fängt den Fehler ab und gibt dessen Meldung aus. Bei einer fehlenden Datei beginnt die Meldung mit `License "Aspose.Slides.lic" doesn't exist or access is restricted.` und listet alle durchsuchen Pfade auf.

In diesem Paket wird eine Lizenz ausschließlich aus einer Datei angewendet. `License` akzeptiert keinen Stream, und das Paket stellt keine nutzungsabhängige Lizenzierung bereit. Für die von dem Paket umschlossene Klasse siehe [License](https://reference.aspose.com/slides/de/net/aspose.slides/license/) in der API‑Referenz von Aspose.Slides für .NET.