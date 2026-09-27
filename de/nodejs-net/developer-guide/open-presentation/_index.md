---
title: Präsentationen in Node.js via .NET öffnen
linktitle: Präsentation öffnen
type: docs
weight: 20
url: /de/nodejs-net/open-presentation/
keywords:
- Präsentation öffnen
- PowerPoint öffnen
- PPTX öffnen
- PPT öffnen
- ODP öffnen
- Präsentation laden
- Präsentation aus Buffer
- Folienzahl
- Präsentation konvertieren
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Öffnen Sie PPTX-, PPT- und ODP-Präsentationen in JavaScript mit Aspose.Slides für Node.js via .NET: Laden Sie sie von einem Dateipfad oder einem Buffer, lesen Sie die Folienzahl und speichern Sie sie in einem anderen Format."
---
## **Übersicht**

Aspose.Slides for Node.js via .NET öffnet PowerPoint‑ und OpenDocument‑Präsentationen, z. B. PPTX-, PPT‑ und ODP‑Dateien, entweder von einem Dateipfad oder von einem Node.js `Buffer`. Dieser Artikel zeigt beide Methoden, liest die Anzahl der Folien und speichert eine geöffnete Präsentation in einem anderen Format.

Die Beispiele gehen davon aus, dass sich im Projektordner eine Präsentation namens `sample.pptx` befindet, die Sie in [Installation](/slides/de/nodejs-net/installation/) eingerichtet haben. Jede PowerPoint‑Präsentation funktioniert. Speichern Sie jedes Beispiel als `.js`‑Datei im Projektordner und führen Sie es dort mit `node` aus.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET besitzt keine eigene API‑Referenz. Es spiegelt die Aspose.Slides for .NET‑API mit camelCase‑Namen wider, sodass die API‑Links in diesem Artikel zu den entsprechenden Klassen und Mitgliedern in der [Aspose.Slides for .NET API‑Referenz](https://reference.aspose.com/slides/net/) führen.
{{% /alert %}}

## **Präsentation aus einer Datei öffnen**

Um eine Präsentation zu öffnen, übergeben Sie ihren Pfad dem Konstruktor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Aspose.Slides erkennt das Format anhand des Dateiinhalts und nicht anhand der Erweiterung, sodass derselbe Code PPTX‑, PPT‑ und ODP‑Dateien öffnen kann. Ein relativer Pfad wird gegenüber dem aktuellen Arbeitsverzeichnis aufgelöst, das das Projektverzeichnis ist, wenn Sie das Skript dort ausführen.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Das Skript gibt die Anzahl der Folien in `sample.pptx` aus, z. B. `Slide count: 9`. Die `count`‑Eigenschaft der [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)‑Sammlung enthält auch versteckte Folien. Rufen Sie `dispose` in einem `finally`‑Block auf, wie gezeigt, damit die .NET‑Ressourcen hinter der Präsentation freigegeben werden, selbst wenn Ihr Code fehlschlägt.

## **Präsentation aus einem Buffer öffnen**

Wenn eine Präsentation aus einer Datenbank, einem HTTP‑Upload oder einer anderen Quelle stammt, die Ihnen Bytes statt eines Dateipfads liefert, übergeben Sie einen Node.js `Buffer` als zweites Konstruktorargument und `null` als erstes. Das folgende Beispiel lädt `sample.pptx` in einen Buffer, um eine solche Quelle zu simulieren:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Das Skript gibt dieselbe Folienanzahl wie im vorherigen Beispiel aus. Das zweite Argument muss ein `Buffer` sein. Für jeden anderen Typ, etwa ein `Uint8Array`, meldet der Konstruktor keinen Fehler; er erzeugt stattdessen eine neue Präsentation mit einer leeren Folie. Konvertieren Sie andere Binärtypen zuerst mit `Buffer.from`.

## **Präsentation in ein anderes Format speichern**

Um eine Präsentation in ein anderes Präsentationsformat zu konvertieren, öffnen Sie sie und speichern sie mit einem anderen [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)-Wert. Das folgende Beispiel gibt das von Aspose.Slides erkannte Format aus, das die Eigenschaft [sourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) zurückgibt, und speichert die Präsentation als OpenDocument‑Präsentation:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

Das Skript gibt `Source format: Pptx` aus und schreibt `sample.odp`, das dieselben Folien enthält. `sourceFormat` gibt `Ppt`, `Pptx` oder `Odp` zurück. Um stattdessen als PDF oder als Bilder zu speichern, siehe [Convert PowerPoint to PDF](/slides/de/nodejs-net/convert-powerpoint-to-pdf/) und [Convert Slides to Images](/slides/de/nodejs-net/convert-slide/).

## **FAQ**

**Wie öffne ich eine passwortgeschützte Präsentation?**

Erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)-Objekt, setzen Sie dessen [password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/)-Eigenschaft und übergeben Sie das Objekt als drittes Konstruktorargument: `new Presentation("protected.pptx", null, loadOptions)`. Ohne das richtige Passwort wirft der Konstruktor einen Fehler.

**Warum wirft der Konstruktor einen `Error` mit leerer Meldung?**

Wenn der `Presentation`‑Konstruktor in .NET fehlschlägt, etwa weil die Datei fehlt, keine Präsentation ist oder ein anderes Passwort benötigt wird, erhält JavaScript einen `Error` mit leerer Meldung. Überprüfen Sie vor dem Öffnen einer Datei, ob sie relativ zum Arbeitsverzeichnis existiert, z. B. mit `fs.existsSync`.

**Welche Formate kann ich öffnen?**

PowerPoint‑ und OpenDocument‑Präsentationsformate, einschließlich PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP und FODP.