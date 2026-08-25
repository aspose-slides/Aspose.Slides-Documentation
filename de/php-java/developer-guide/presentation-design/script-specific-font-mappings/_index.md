---
title: Verwalten von skript-spezifischen Theme-Schriften in PHP
linktitle: Skript-spezifische Theme-Schriften
type: docs
weight: 15
url: /de/php-java/script-specific-font-mappings/
keywords:
- Skript-spezifische Schrift
- Theme-Schriftzuordnung
- Mehrsprachige Präsentation
- Schriftsystem
- Kyrillische Schrift
- Arabische Schrift
- Japanische Schrift
- Georgische Schrift
- Thaana-Schrift
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Untersuchen, hinzufügen, ersetzen und entfernen Sie skript-spezifische Schriftzuordnungen in PowerPoint-Themes mit Aspose.Slides für PHP über Java."
---
## **Übersicht**

Ein Präsentationsthema kann für verschiedene Schriftsysteme unterschiedliche Schriftfamilien auswählen. Dadurch kann mehrsprachiger Text, der weiterhin die Theme‑Schriften verwendet, einem koordinierten Schriftenplan folgen und gleichzeitig geeignete Schriften für Kyrillisch, Arabisch, Japanisch, Georgisch, Thaana und andere Skripte nutzen.

Das Theme‑[FontScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontscheme/) enthält eine Hauptschrift‑Sammlung, die typischerweise für Überschriften verwendet wird, und eine Neben‑Schrift‑Sammlung, die typischerweise für Fließtext verwendet wird. Zusätzlich zu ihren lateinischen und ostasiatischen Schlüsseleinstellungen stellen beide [Fonts](https://reference.aspose.com/slides/de/php-java/aspose.slides/fonts/)‑Sammlungen Zuordnungen von Schriftsystem‑Tags zu Schriftfamiliennamen bereit.

Dieser Artikel zeigt, wie man diese Zuordnungen im Master‑Theme der Präsentation inspiziert und ändert und prüft, dass die Änderungen einen Speicher‑und‑Lade‑Durchlauf überstehen.

## **Verstehen von Skript‑Tags**

Die Methoden für Skript‑Schriften verwenden vier‑buchstabige BCP‑47‑Skript‑Subtags, um Schriftsysteme zu identifizieren. Gängige Werte sind:

| Skript‑Tag | Schriftsystem |
|---|---|
| `Cyrl` | Kyrillisch |
| `Arab` | Arabisch |
| `Hans` | Vereinfachtes Chinesisch |
| `Jpan` | Japanisch |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

Diese Zuordnungen gehören zum Theme‑Schriftenplan, nicht zu einzelnen Textabschnitten. Eine Präsentation kann unterschiedliche Zuordnungen für die Haupt‑ und Neben‑Sammlungen definieren und kann Zuordnungen für einige Skripte weglassen.

## **Zugriff und Inspektion von Skript‑Schrift‑Zuordnungen**

Verwenden Sie [Presentation::getMasterTheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getMasterTheme), um das Theme auf Präsentationsebene zu erhalten. Die Methoden [MasterTheme::getFontScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontscheme/#getMajor) und [FontScheme::getMinor](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontscheme/#getMinor) liefern Zugriff auf die beiden [Fonts](https://reference.aspose.com/slides/de/php-java/aspose.slides/fonts/)‑Sammlungen.

Rufen Sie [Fonts::getScriptFontMap](https://reference.aspose.com/slides/de/php-java/aspose.slides/fonts/#getScriptFontMap) auf, um alle Zuordnungen einer Sammlung abzurufen. Um ein bestimmtes Schriftsystem nachzuschlagen, rufen Sie [Fonts::getScriptFont](https://reference.aspose.com/slides/de/php-java/aspose.slides/fonts/#getScriptFont) mit dessen Skript‑Tag auf. `Fonts::getScriptFont` gibt `null` zurück, wenn die Sammlung die angeforderte Zuordnung nicht definiert.

## **Zuordnungen ändern und Persistenz überprüfen**

Verwenden Sie [Fonts::setScriptFont](https://reference.aspose.com/slides/de/php-java/aspose.slides/fonts/#setScriptFont), um eine Zuordnung zu erstellen oder die aktuelle Schriftfamilie zu ersetzen. Verwenden Sie [Fonts::removeScriptFont](https://reference.aspose.com/slides/de/php-java/aspose.slides/fonts/#removeScriptFont), um eine Zuordnung zu entfernen.

Das folgende End‑zu‑End‑Beispiel liest alle bestehenden Haupt‑ und Neben‑Zuordnungen, sucht die japanische Hauptschrift, ändert die kyrillische Hauptschrift, entfernt die Thaana‑Neben‑Zuordnung, speichert die Präsentation und öffnet sie erneut, um beide Änderungen zu überprüfen. Damit der Entfernungs‑Schritt unabhängig vom Ausgangs‑Theme ist, erstellt das Beispiel zunächst nur dann eine Thaana‑Zuordnung, wenn noch keine definiert ist.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

Die Verifizierung verwendet dasselbe `null`‑Verhalten wie ein gewöhnlicher Lookup: Nach dem Speichern der Entfernung gibt `Fonts::getScriptFont("Thaa")` für die Neben‑Sammlung `null` zurück.

## **Unterscheiden von Theme‑Zuordnungen und anderen Schrift­einstellungen**

Skript‑spezifische Theme‑Zuordnungen nehmen am Schriftauswahl‑Prozess teil, lösen jedoch ein anderes Problem als direkte Textformatierung, Schrift‑Substitution und Fallback:

| Mechanismus | Zweck | Effekt einer Änderung einer Theme‑Zuordnung |
|---|---|---|
| Skript‑spezifische Theme‑Schrift‑Zuordnung | Wählt eine Haupt‑ oder Neben‑Theme‑Schrift für ein Schriftsystem. | Text, der weiterhin die entsprechende Theme‑Schrift verwendet, kann zur neuen zugeordneten Familie aufgelöst werden. |
| Schrift ausdrücklich einem Textabschnitt zugewiesen | Fixiert die angeforderte Schriftfamilie für diesen Abschnitt, anstatt sich auf das Theme zu verlassen. | Der Abschnitt bleibt möglicherweise unverändert, weil seine direkte Formatierung die Theme‑Auswahl überschreibt. |
| Schrift‑Substitution | Ersetzt eine angeforderte Schrift, wenn diese nicht verfügbar ist oder eine Substitutions‑Regel greift. | Sie wirkt nach einer Schriftanforderung; sie definiert die Theme‑Skript‑Zuordnung nicht neu. |
| Schrift‑Fallback | Liefert Glyphen, die die ausgewählte Schrift nicht enthält, häufig für bestimmte Unicode‑Bereiche. | Sie füllt fehlende Glyphen ab; sie ändert nicht die gespeicherte Theme‑Zuordnung. |

Weitere Informationen zu den beiden letzten Mechanismen finden Sie unter [Font Substitution](/slides/de/php-java/font-substitution/) und [Fallback Fonts](/slides/de/php-java/fallback-font/).

Das Ändern einer Zuordnung in [Presentation::getMasterTheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getMasterTheme) wirkt sich nur auf Inhalte aus, deren effektive Formatierung noch von diesem Theme abhängt. Text kann stattdessen eine Theme‑Überschreibung von einem Master, Layout oder einer Folie erben oder eine explizit zugewiesene Schrift verwenden. Prüfen Sie diese Ebenen, wenn das sichtbare Ergebnis nicht der Präsentation‑Ebene‑Zuordnung folgt.

## **Zuordnungen bereitstellen und Ergebnis validieren**

Eine Skript‑Zuordnung speichert einen Schriftfamiliennamen; sie installiert oder lädt die entsprechende Schriftdatei nicht. Für konsistentes Rendern und Export muss jede zugeordnete Schrift in der Umgebung installiert oder Aspose.Slides über eine benutzerdefinierte Quelle bereitgestellt werden, z. B. über [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsloader/#loadExternalFonts) oder [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Siehe [Custom Fonts](/slides/de/php-java/custom-font/) für die verfügbaren Lade‑Optionen.

Die Überprüfung der gespeicherten Zuordnung bestätigt nur, dass die Theme‑Definition erhalten blieb. Sie beweist nicht, dass die Schrift verfügbar ist, alle benötigten Glyphen enthält oder das gewünschte Layout erzeugt. Rendern Sie repräsentativen Text für jedes erforderliche Schriftsystem zu einem Bild oder PDF und inspizieren Sie die Ausgabe. So werden fehlende Schriften, unvollständige Glyphen‑Abdeckung, Fallback‑Verhalten und Layout‑Änderungen erkannt, bevor die Präsentation verteilt wird. Siehe [Convert PowerPoint Presentations](/slides/de/php-java/convert-powerpoint/) für Render‑ und Export‑Beispiele.

## **FAQ**

**Was gibt `Fonts::getScriptFont` zurück, wenn ein Skript nicht zugeordnet ist?**

[Fonts::getScriptFont](https://reference.aspose.com/slides/de/php-java/aspose.slides/fonts/#getScriptFont) gibt `null` zurück, wenn die angeforderte Skript‑Zuordnung in dieser Haupt‑ oder Neben‑Schrift‑Sammlung nicht definiert ist.

**Fügt `Fonts::setScriptFont` eine zweite Zuordnung hinzu, wenn das Skript bereits existiert?**

Nein. [Fonts::setScriptFont](https://reference.aspose.com/slides/de/php-java/aspose.slides/fonts/#setScriptFont) erstellt die Zuordnung, wenn sie fehlt, und ersetzt die zugeordnete Schriftfamilie, wenn das gleiche Skript‑Tag bereits vorhanden ist.

**Warum änderte das Ändern einer Theme‑Zuordnung nicht manchen Text?**

Der Text könnte eine explizit zugewiesene Schrift haben, eine andere Theme‑Überschreibung erben oder während des Renderns von Substitution oder Fallback betroffen sein. Eine Präsentation‑Ebene‑Skript‑Zuordnung steuert nur Text, dessen effektive Formatierung noch auf diese Theme‑Schrift‑Sammlung verweist.

**Reicht das Speichern und erneute Öffnen aus, um die mehrsprachige Ausgabe zu validieren?**

Nein. Das erneute Öffnen prüft die Persistenz der Theme‑Daten. Zusätzlich sollten repräsentative Texte aus jedem erforderlichen Schriftsystem gerendert werden, um zu bestätigen, dass die zugeordneten Schriften verfügbar sind und die notwendigen Glyphen enthalten.