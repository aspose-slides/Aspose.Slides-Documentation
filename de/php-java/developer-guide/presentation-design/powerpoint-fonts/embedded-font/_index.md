---
title: Einbetten von Schriften in Präsentationen mittels PHP
linktitle: Eingebettete Schriften
type: docs
weight: 40
url: /de/php-java/embedded-font/
keywords:
- Schrift hinzufügen
- Schrift einbetten
- Schrift-Einbettung
- eingebettete Schrift abrufen
- eingebettete Schrift hinzufügen
- eingebettete Schrift entfernen
- eingebettete Schrift komprimieren
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie eingebettete Schriften in PowerPoint mit Aspose.Slides für PHP via Java. Schriften hinzufügen, abrufen, entfernen und komprimieren, um das Aussehen des Textes zu erhalten und die Dateigröße zu reduzieren."
---
## **Einleitung**

Durch das Einbetten von Schriften werden Schriftartdaten in einer PowerPoint‑Präsentation gespeichert. Unterstützt ein Betrachter eingebettete Schriften, kann er den Text mit diesen Schriften anzeigen, selbst wenn sie nicht auf dem Zielsystem installiert sind. Damit bleiben Zeilenumbrüche, Textabstände und das Folienlayout erhalten.

Aspose.Slides for PHP via Java ermöglicht das Abrufen, Hinzufügen und Entfernen eingebetteter Schriften über die [FontsManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/)‑Klasse, die von [Presentation::getFontsManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getFontsManager) zurückgegeben wird. Sie können die Größe eingebetteter Schriftartdaten außerdem reduzieren, indem Sie Zeichen entfernen, die in der Präsentation nicht verwendet werden.

Die nachfolgenden Beispiele arbeiten mit PPTX‑Dateien. Stellen Sie vor dem Einbetten einer Schrift sicher, dass deren Schriftartdaten für Aspose.Slides verfügbar sind und die Lizenz das Einbetten zulässt.

## **Abrufen und Entfernen eingebetteter Schriften**

Verwenden Sie [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts), um die in einer Präsentation gespeicherten Schriften aufzulisten. Um eine Schrift zu entfernen, übergeben Sie eine Schrift aus dieser Liste an [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) und speichern Sie anschließend die Präsentation.

Das folgende Beispiel listet die eingebetteten Schriften in `EmbeddedFonts.pptx` auf und entfernt Calibri, falls sie vorhanden ist:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Das Entfernen einer eingebetteten Schrift löscht deren gespeicherte Schriftartdaten; die der Texte zugewiesene Schrift bleibt unverändert. Ist die Schrift auf dem Zielsystem installiert, kann der Text sie weiterhin verwenden. Andernfalls kann bei der Wiedergabe eine [Schriftartensubstitution](/slides/de/php-java/font-substitution/) erforderlich sein, was das Layout beeinflussen kann.

## **Schriftdaten und Einbettungsberechtigungen überprüfen**

Verwenden Sie die [FontsManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/)‑Klasse, um Schriften vor dem Einbetten zu untersuchen. Rufen Sie [FontsManager::getFonts](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/#getFonts) auf, um die in der Präsentation verwendeten Schriften zu erhalten. Für jede Schrift übergeben Sie ein [FontData](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontdata/)-Objekt und den erforderlichen [FontStyleType](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontstyletype/)-Wert an [FontsManager::getFontBytes](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/#getFontBytes). Die Methode liefert die Binärdaten für diesen Schriftstil zurück oder `null`, wenn die angeforderte Schrift oder der Stil nicht verfügbar ist. Übergeben Sie kein `null`‑Ergebnis an [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), da diese Methode ein Byte‑Array erwartet.

[EmbeddingLevel](https://reference.aspose.com/slides/de/php-java/aspose.slides/embeddinglevel/) ist eine Flags‑Aufzählung, die die in der Schrift gespeicherten Einbettungsbeschränkungen meldet:

- `Installable` erlaubt das Einbetten und die permanente Installation auf einem anderen System, vorbehaltlich der Schriftlizenz.
- `Restricted` verbietet das Einbetten, es sei denn, es wird eine Erlaubnis vom Rechtsinhaber der Schrift eingeholt, wenn es das einzige Nutzungs‑Flag ist.
- `PreviewPrint` erlaubt temporäre Nutzung zum Anzeigen und Drucken; ein Dokument, das die Schrift enthält, muss schreibgeschützt sein.
- `Editable` erlaubt temporäre Nutzung und gestattet das Bearbeiten und Speichern des Dokuments.
- `NoSubsetting` ist eine zusätzliche Einschränkung, die das Einbetten nur eines Teils der Glyphen verbietet. Alle Zeichen müssen eingebettet werden, wenn dieses Flag gesetzt ist.
- `BitmapOnly` ist eine zusätzliche Einschränkung, die nur das Einbetten von Bitmap‑Schlägen erlaubt, nicht aber von Konturdaten. Hat die Schrift keine Bitmap‑Schläge, kann sie nicht eingebettet werden.

Die ersten vier Werte beschreiben die Nutzungserlaubnis, während `NoSubsetting` und `BitmapOnly` mit ihnen kombiniert werden können. Prüfen Sie die Modifikatoren mit Bit‑Operationen. Da `Installable` den Wert 0 hat, maskieren Sie die Nutzungs‑Bits und vergleichen das Ergebnis mit `Installable`, anstatt das Flag direkt zu prüfen. Aktuelle Schriften sollten höchstens ein Nutzungs‑Bit setzen. Für die Kompatibilität mit älteren Schriften, die mehrere Bits setzen, wählt die untenstehende Hilfsfunktion die am wenigsten restriktive Erlaubnis: `Editable`, dann `PreviewPrint`, dann `Restricted`.

Das folgende Beispiel prüft die regulären, fetten, kursiven und fett‑kursiven Daten, die für jede von `FontsManager::getFonts` zurückgegebene Schrift verfügbar sind. Nicht verfügbare Stile, eingeschränkte Schriften, nur‑Bitmap‑Schriften, Schriften, die ausschließlich für Vorschau und Druck freigegeben sind (da das Ergebnis editierbar bleibt) sowie bereits eingebettete Schriften werden übersprungen. Hat ein verfügbarer Stil das Flag `NoSubsetting`, werden für diese Schriftfamilie alle Zeichen eingebettet.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Diese Untersuchung meldet die in jeder Schriftdatei kodierten Beschränkungen. Sie vergibt keine Lizenz, beweist nicht, dass Sie die Schrift legal erworben haben, und ersetzt nicht die Prüfung der Lizenzvereinbarung der Schrift, bevor Sie eine eingebettete Kopie verteilen.

## **Eingebettete Schriften hinzufügen**

Verwenden Sie [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/#addEmbeddedFont), um eine Schrift einzubetten. Die Überladungen akzeptieren entweder ein [FontData](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontdata/)-Objekt oder ein Byte‑Array mit den Schriftartdaten. Die Aufzählung [EmbedFontCharacters](https://reference.aspose.com/slides/de/php-java/aspose.slides/embedfontcharacters/) steuert, welche Zeichen eingebettet werden:

- [All](https://reference.aspose.com/slides/de/php-java/aspose.slides/embedfontcharacters/) bettet alle Zeichen der Schrift ein. Verwenden Sie diese Option, wenn Empfänger die Präsentation bearbeiten und neuen Text eingeben müssen.
- [OnlyUsed](https://reference.aspose.com/slides/de/php-java/aspose.slides/embedfontcharacters/) bettet nur die in der Präsentation verwendeten Zeichen ein, um die Dateigröße zu reduzieren. Wählen Sie diese Option für eine fertige Präsentation, die hauptsächlich zur Ansicht bestimmt ist.

Das folgende Beispiel ruft mit [FontsManager::getFonts](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/#getFonts) die in `Fonts.pptx` verwendeten Schriften ab und bettet jene ein, die noch nicht eingebettet sind. Die hinzuzufügenden Schriften müssen auf dem ausführenden Rechner verfügbar sein. Bereits eingebettete Schriften behalten ihre aktuellen Zeichensätze bei.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Eingebettete Schriften komprimieren**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/de/php-java/aspose.slides/compress/#compressEmbeddedFonts) reduziert eingebettete Schriftartdaten, indem nicht genutzte Zeichen entfernt werden. Die Methode wirkt auf bereits eingebettete Schriften, sodass die Reduktion von der Menge nicht verwendeter Schriftartdaten in der Präsentation abhängt.

Das folgende Beispiel komprimiert die Schriften in `EmbeddedFonts.pptx` und speichert das Ergebnis in einer separaten Datei:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bewahren Sie die Originaldatei auf, wenn Empfänger später Text hinzufügen müssen. Während der Komprimierung entfernte Zeichen stehen aus der eingebetteten Schrift nicht mehr zur Verfügung, selbst wenn Sie ursprünglich alle Zeichen eingebettet hatten.

## **FAQ**

**Wie kann ich prüfen, ob eine eingebettete Schrift während der Wiedergabe noch ersetzt wird?**

Rufen Sie [FontsManager::getSubstitutions](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/#getSubstitutions) in der Umgebung auf, in der Sie die Präsentation rendern, um zu sehen, welche Schriften Aspose.Slides ersetzen wird. Prüfen Sie außerdem die Einstellungen zur [Schriftartensubstitution](/slides/de/php-java/font-substitution/) und die Regeln zur [Schriftfallback](/slides/de/php-java/fallback-font/). Der Fallback behandelt fehlende Zeichen, sodass das Einbetten einer Schrift nicht automatisch Zeichen löst, die in der Schrift selbst nicht enthalten sind.

**Sollte ich gängige Schriften wie Arial und Calibri einbetten?**

Entscheiden Sie basierend auf der Zielumgebung. Sind die benötigten Schriften auf jedem Gerät, das die Präsentation öffnet oder rendert, verfügbar, kann das Einbetten unnötig die Dateigröße erhöhen. Fehlen die Schriften bei Empfängern oder Servern, kann das Einbetten helfen, das beabsichtigte Aussehen zu bewahren, sofern die Lizenzen dies erlauben.