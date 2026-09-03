---
title: Embed Fonts in Presentations in JavaScript
linktitle: Embedded Fonts
type: docs
weight: 40
url: /de/nodejs-java/embedded-font/
keywords:
- Schrift hinzufügen
- Schrift einbetten
- Schrifteinbettung
- eingebettete Schrift abrufen
- eingebettete Schrift hinzufügen
- eingebettete Schrift entfernen
- eingebettete Schrift komprimieren
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie eingebettete Schriften in PowerPoint mit Aspose.Slides für Node.js via Java. Fügen Sie Schriften hinzu, rufen Sie sie ab, entfernen Sie sie und komprimieren Sie sie, um das Erscheinungsbild von Text zu bewahren und die Dateigröße zu reduzieren."
---
## **Einleitung**

Einbetten von Schriften speichert die Schriftartdaten innerhalb einer PowerPoint‑Präsentation. Wenn ein Betrachter eingebettete Schriften unterstützt, kann er Text mit diesen Schriften anzeigen, selbst wenn sie nicht im Zielsystem installiert sind. Das hilft, Zeilenumbrüche, Textabstände und das Folienlayout beizubehalten.

Aspose.Slides für Node.js via Java ermöglicht das Abrufen, Hinzufügen und Entfernen eingebetteter Schriften über die [FontsManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/)‑Klasse, die von [Presentation.getFontsManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getfontsmanager/) zurückgegeben wird. Sie können die Größe eingebetteter Schriftartdaten zudem verringern, indem Sie nicht verwendete Zeichen entfernen.

Die nachfolgenden Beispiele arbeiten mit PPTX‑Dateien. Stellen Sie vor dem Einbetten einer Schrift sicher, dass die Schriftartdaten Aspose.Slides zur Verfügung stehen und dass Ihre Lizenz das Einbetten erlaubt.

## **Einbetten und Entfernen von Schriften**

Verwenden Sie [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/), um die in einer Präsentation gespeicherten Schriften aufzulisten. Um eine Schrift zu entfernen, übergeben Sie eine Schrift aus dieser Liste an [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/), und speichern Sie anschließend die Präsentation.

Das folgende Beispiel listet die eingebetteten Schriften in `EmbeddedFonts.pptx` auf und entfernt Calibri, falls sie vorhanden ist:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Das Entfernen einer eingebetteten Schrift entfernt deren gespeicherte Schriftartdaten; die dem Text zugewiesene Schrift bleibt unverändert. Ist die Schrift auf dem Zielsystem installiert, kann der Text sie weiterhin verwenden. Andernfalls kann beim Rendern eine [font substitution](/slides/de/nodejs-java/font-substitution/) erforderlich sein, was das Layout beeinflussen kann.

## **Untersuchen von Schriftartdaten und Einbettungsrechten**

Verwenden Sie die [FontsManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/)‑Klasse, um Schriften vor dem Einbetten zu prüfen. Rufen Sie [FontsManager.getFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getfonts/) auf, um die in der Präsentation verwendeten Schriften zu erhalten. Für jede Schrift übergeben Sie ein [FontData](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontdata/)-Objekt und den erforderlichen [FontStyleType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontstyletype/)-Wert an [FontsManager.getFontBytes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/#getFontBytes). Die Methode liefert die Binärdaten für diesen Schriftschnitt zurück oder `null`, wenn die gewünschte Schrift oder der Stil nicht verfügbar ist. Übergeben Sie kein `null`‑Ergebnis an [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), da diese Methode ein Byte‑Array erwartet. In Node.js konvertieren Sie das zurückgegebene JavaScript‑Array mit `java.newArray` in ein Java‑Byte‑Array, bevor Sie es an `getFontEmbeddingLevel` übergeben.

[EmbeddingLevel](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/embeddinglevel/) gibt die Einbettungsbeschränkungen an, die in der Schrift als Flags gespeichert sind:

- `Installable` erlaubt das Einbetten und die permanente Installation auf einem anderen System, vorbehaltlich der Schriftlizenz.
- `Restricted` verbietet das Einbetten, es sei denn, es wird eine Erlaubnis vom Rechtsinhaber der Schrift eingeholt, wenn es das einzige Nutzungs‑Flag ist.
- `PreviewPrint` erlaubt die temporäre Verwendung zum Anzeigen und Drucken; ein Dokument, das die Schrift enthält, muss schreibgeschützt sein.
- `Editable` erlaubt die temporäre Verwendung und gestattet, das Dokument zu bearbeiten und zu speichern.
- `NoSubsetting` ist eine zusätzliche Beschränkung, die das Einbetten nur eines Teils der Glyphen untersagt. Betten Sie alle Zeichen ein, wenn dieses Flag gesetzt ist.
- `BitmapOnly` ist eine zusätzliche Beschränkung, die nur das Einbetten von Bitmap‑Strikes erlaubt, nicht jedoch von Outline‑Daten. Hat die Schrift keine Bitmap‑Strikes, kann sie nicht eingebettet werden.

Die ersten vier Werte beschreiben die Nutzungserlaubnis, während `NoSubsetting` und `BitmapOnly` mit ihnen kombiniert werden können. Prüfen Sie die Modifikatoren mit Bit‑Operatoren. Da `Installable` den Wert 0 hat, maskieren Sie die Nutzungs‑Bits und vergleichen das Ergebnis mit `Installable`, anstatt das Flag direkt zu prüfen. Aktuelle Schriften sollten höchstens ein Nutzungs‑Flag setzen. Für die Kompatibilität mit älteren Schriften, die mehr als eines setzen, wählt die unten stehende Hilfsmethode die am wenigsten restriktive Erlaubnis: `Editable`, dann `PreviewPrint`, dann `Restricted`.

Das folgende Beispiel prüft die regulären, fetten, kursiven und fett‑kursiven Daten, die für jede von `getFonts` zurückgegebene Schrift verfügbar sind. Es überspringt nicht verfügbare Stile, eingeschränkte Schriften, nur‑Bitmap‑Schriften, Schriften, die nur für Vorschau und Druck erlaubt sind (da das Ergebnis editierbar bleiben soll) und bereits eingebettete Schriften. Hat ein verfügbarer Stil das Flag `NoSubsetting`, werden alle Zeichen für diese Schriftfamilie eingebettet.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diese Prüfung meldet die in jeder Schriftdatei codierten Einschränkungen. Sie gewährt keine Lizenz, beweist nicht, dass Sie die Schrift legal erworben haben, und ersetzt nicht die Überprüfung der Lizenzvereinbarung, bevor Sie eine eingebettete Kopie verbreiten.

## **Einbetten von Schriften**

Verwenden Sie [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/), um eine Schrift einzubetten. Die Überladungen akzeptieren entweder ein [FontData](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontdata/)-Objekt oder ein Byte‑Array mit den Schriftartdaten. [EmbedFontCharacters](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/embedfontcharacters/) steuert, welche Zeichen eingeschlossen werden:

- `All` bettet alle Zeichen der Schrift ein. Verwenden Sie diese Option, wenn Empfänger die Präsentation bearbeiten und neuen Text eingeben müssen.
- `OnlyUsed` bettet nur die in der Präsentation verwendeten Zeichen ein, um die Dateigröße zu reduzieren. Wählen Sie diese Option für eine fertige Präsentation, die hauptsächlich zur Ansicht bestimmt ist.

Das folgende Beispiel verwendet [FontsManager.getFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getfonts/), um die in `Fonts.pptx` genutzten Schriften abzurufen, und bettet jene, die noch nicht eingebettet sind, ein. Die hinzuzufügenden Schriften müssen auf dem ausführenden Rechner verfügbar sein. Bereits eingebettete Schriften behalten ihr aktuelles Zeichen‑Set bei.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Komprimieren eingebetteter Schriften**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/compressembeddedfonts/) reduziert die Daten eingebetteter Schriften, indem ungenutzte Zeichen entfernt werden. Die Methode arbeitet an bereits eingebetteten Schriften, sodass die Größenreduktion davon abhängt, wie viele ungenutzte Schriftartdaten die Präsentation enthält.

Das folgende Beispiel komprimiert die Schriften in `EmbeddedFonts.pptx` und speichert das Ergebnis als separate Datei:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bewahren Sie die Originaldatei auf, wenn Empfänger später Text hinzufügen müssen. Während der Komprimierung entfernte Zeichen stehen aus der eingebetteten Schrift nicht mehr zur Verfügung, selbst wenn Sie ursprünglich alle Zeichen eingebettet haben.

## **FAQ**

**Wie kann ich prüfen, ob eine eingebettete Schrift während des Renderns trotzdem substituiert wird?**

Rufen Sie [FontsManager.getSubstitutions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) in der Umgebung auf, in der Sie die Präsentation rendern, um zu sehen, welche Schriften Aspose.Slides ersetzt. Prüfen Sie außerdem die Einstellungen zur [font substitution](/slides/de/nodejs-java/font-substitution/) und die Regeln zur [font fallback](/slides/de/nodejs-java/fallback-font/). Fallback behandelt fehlende Zeichen, sodass das Einbetten einer Schrift nicht fehlende Zeichen ergänzt, die die Schrift selbst nicht enthält.

**Sollte ich gängige Schriften wie Arial und Calibri einbetten?**

Entscheiden Sie basierend auf der Zielumgebung. Sind die benötigten Schriften auf jedem Gerät, das die Präsentation öffnet oder rendert, verfügbar, kann das Einbetten unnötig die Dateigröße erhöhen. Wenn Empfänger oder Server diese Schriften möglicherweise nicht haben, kann das Einbetten helfen, das gewünschte Aussehen zu bewahren, vorausgesetzt, die Lizenzen erlauben dies.