---
title: Verwalten von Skript-spezifischen Themen-Schriften in JavaScript
linktitle: Skript-spezifische Themen-Schriften
type: docs
weight: 15
url: /de/nodejs-java/script-specific-font-mappings/
keywords:
- skript-spezifische Schrift
- Thema-Schriftzuordnung
- mehrsprachige Präsentation
- Schriftsystem
- kyrillische Schrift
- arabische Schrift
- japanische Schrift
- georgische Schrift
- Thaana-Schrift
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skript-spezifische Schriftzuordnungen in PowerPoint-Themen mit Aspose.Slides für Node.js untersuchen, hinzufügen, ersetzen und entfernen."
---
## **Überblick**

Ein Präsentationsthema kann für verschiedene Schriftsysteme unterschiedliche Schriftfamilien auswählen. Dadurch kann mehrsprachiger Text, der weiterhin die Themen‑schriftarten verwendet, einem einheitlichen Schriftschema folgen und gleichzeitig geeignete Schriften für Kyrillisch, Arabisch, Japanisch, Georgisch, Thaana und andere Skripte nutzen.

Das [FontScheme] enthält eine Hauptschrift‑sammlung, die typischerweise für Überschriften verwendet wird, und eine Nebenschrift‑sammlung, die typischerweise für Fließtext verwendet wird. Zusätzlich zu ihren Latin‑ und Ostasien‑Schrifteinstellungen geben beide Sammlungen Zuordnungen von Schriftsystem‑Tags zu Schriftfamiliennamen über die Klasse [Fonts] frei.

Dieser Artikel zeigt, wie man diese Zuordnungen im Master‑Thema der Präsentation untersucht und ändert sowie überprüft, dass die Änderungen einen Speicher‑und‑Lade‑Durchlauf überstehen.

## **Skript‑Tags verstehen**

Die Skript‑Schrift‑Methoden verwenden vier‑buchstabige BCP‑47‑Skript‑Subtags, um Schriftsysteme zu identifizieren. Häufige Werte sind:

| Skript‑Tag | Schriftsystem |
|---|---|
| `Cyrl` | Kyrillisch |
| `Arab` | Arabisch |
| `Hans` | Vereinfachtes Chinesisch |
| `Jpan` | Japanisch |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

Diese Zuordnungen gehören zum Themen‑Schrift‑Schema, nicht zu einzelnen Textabschnitten. Eine Präsentation kann verschiedene Zuordnungen für die Haupt‑ und Nebensammlung definieren und für manche Skripte keine Zuordnung vorsehen.

## **Zugriff auf und Untersuchung von Skript‑Schriftzuordnungen**

Verwenden Sie [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getmastertheme/), um das themenbezogene Präsentations‑Thema zu erhalten. Die Methoden [FontScheme.getMajor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontscheme/) und [FontScheme.getMinor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontscheme/) geben die beiden [Fonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fonts/)‑Sammlungen zurück.

Rufen Sie [Fonts.getScriptFontMap](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fonts/) auf, um alle Zuordnungen einer Sammlung abzurufen. Um ein Schriftsystem nachzuschlagen, rufen Sie [Fonts.getScriptFont](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fonts/) mit dessen Skript‑Tag auf. `getScriptFont` gibt `null` zurück, wenn diese Sammlung die angeforderte Zuordnung nicht definiert.

## **Zuordnungen ändern und Persistenz überprüfen**

Verwenden Sie [Fonts.setScriptFont](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fonts/), um eine Zuordnung zu erstellen oder die aktuelle Schriftfamilie zu ersetzen. Verwenden Sie [Fonts.removeScriptFont](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fonts/), um eine Zuordnung zu entfernen.

Das folgende End‑zu‑Ende‑Beispiel liest alle vorhandenen Haupt‑ und Neben‑Zuordnungen, sucht die japanische Hauptschriftart, ändert die kyrillische Hauptschriftart, entfernt die Thaana‑Neben‑Zuordnung, speichert die Präsentation und öffnet sie erneut, um beide Änderungen zu überprüfen. Um den Entfernungsschritt unabhängig vom ursprünglichen Thema zu machen, erstellt das Beispiel zunächst eine Thaana‑Zuordnung nur dann, wenn noch keine definiert ist.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Die Überprüfung verwendet dasselbe `null`‑Verhalten wie ein regulärer Nachschlagvorgang: Nachdem die Entfernung gespeichert wurde, gibt `getScriptFont("Thaa")` `null` für die Neben‑Sammlung zurück.

## **Unterscheiden Sie Themen‑Zuordnungen von anderen Schrift‑Einstellungen**

Skript‑spezifische Themen‑Zuordnungen wirken bei der Schriftauswahl mit, lösen jedoch ein anderes Problem als direkte Textformatierung, Substitution und Fallback:

| Mechanismus | Zweck | Auswirkung einer Änderung der Themen‑Zuordnung |
|---|---|---|
| Skript‑spezifische Themen‑Schriftzuordnung | Wählt eine Haupt‑ oder Neben‑Themaschrift für ein Schriftsystem aus. | Text, der weiterhin die entsprechende Themen‑Schrift verwendet, kann zur neuen zugeordneten Familie aufgelöst werden. |
| Schrift, die einem Textabschnitt explizit zugewiesen ist | Legt die gewünschte Schriftfamilie für diesen Abschnitt fest, anstatt sich auf das Thema zu verlassen. | Der Abschnitt kann unverändert bleiben, weil seine direkte Formatierung die Themenwahl überschreibt. |
| Schrift‑Substitution | Ersetzt eine angeforderte Schrift, wenn diese nicht verfügbar ist oder eine Substitutionsregel zutrifft. | Sie wirkt, nachdem eine Schrift angefordert wurde; sie definiert die Skript‑Zuordnung des Themas nicht neu. |
| Schrift‑Fallback | Stellt Glyphen bereit, die die ausgewählte Schrift nicht enthält, häufig für bestimmte Unicode‑Bereiche. | Sie füllt fehlende Glyphen‑Abdeckung; sie ändert die gespeicherte Themen‑Zuordnung nicht. |

Für weitere Informationen zu den letzten beiden Mechanismen siehe [Font Substitution](/slides/de/nodejs-java/font-substitution/) und [Fallback Fonts](/slides/de/nodejs-java/fallback-font/).

Das Ändern einer Zuordnung in [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getmastertheme/) wirkt sich nur auf Inhalte aus, deren effektive Formatierung noch von diesem Thema abhängt. Text kann stattdessen eine Themen‑Überschreibung von einem Master, Layout oder Folie erben oder eine explizit zugewiesene Schrift verwenden. Untersuchen Sie diese Ebenen, wenn das sichtbare Ergebnis nicht der Präsentations‑Themen‑Zuordnung folgt.

## **Verfügbarmachen von zugeordneten Schriften und Ergebnis validieren**

Eine Skript‑Zuordnung speichert einen Schriftfamilien‑Namen; sie installiert oder lädt die zugehörige Schriftdatei nicht. Für konsistentes Rendering und Export muss jede zugeordnete Schrift im Umfeld installiert oder Aspose.Slides über eine benutzerdefinierte Quelle wie [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) oder [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/) bereitgestellt werden. Siehe [Custom Fonts](/slides/de/nodejs-java/custom-font/) für die verfügbaren Lademöglichkeiten.

Das Überprüfen der gespeicherten Zuordnung bestätigt nur, dass die Themen‑Definition erhalten blieb. Es beweist nicht, dass die Schrift verfügbar ist, alle erforderlichen Glyphen enthält oder das gewünschte Layout erzeugt. Rendern Sie repräsentativen Text für jedes erforderliche Schriftsystem in ein Bild oder PDF und prüfen Sie die Ausgabe. So werden fehlende Schriften, unvollständige Glyphen‑Abdeckung, Fallback‑Verhalten und Layout‑Änderungen erkannt, bevor die Präsentation verteilt wird. Siehe [Convert PowerPoint Presentations](/slides/de/nodejs-java/convert-powerpoint/) für Beispiele zu Rendering und Export.

## **FAQ**

**Was gibt `getScriptFont` zurück, wenn ein Skript nicht zugeordnet ist?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fonts/) gibt `null` zurück, wenn die angeforderte Skript‑Zuordnung in dieser Haupt‑ oder Neben‑Schrift‑Sammlung nicht definiert ist.

**Fügt `setScriptFont` eine zweite Zuordnung hinzu, wenn das Skript bereits existiert?**

Nein. [Fonts.setScriptFont](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fonts/) erstellt die Zuordnung, wenn sie fehlt, und ersetzt die zugeordnete Schriftfamilie, wenn derselbe Skript‑Tag bereits vorhanden ist.

**Warum hat das Ändern einer Themen‑Zuordnung manchen Text nicht verändert?**

Der Text kann eine explizit zugewiesene Schrift haben, ein anderes Thema über eine Überschreibung erben oder während des Renderns von Substitution oder Fallback betroffen sein. Eine Skript‑Zuordnung auf Präsentationsebene steuert nur Text, dessen effektive Formatierung noch auf diese Themen‑Schrift‑Sammlung verweist.

**Reicht das Speichern und erneute Öffnen aus, um mehrsprachige Ausgabe zu validieren?**

Nein. Das erneute Öffnen überprüft die Persistenz der Themen‑Daten. Außerdem sollten Sie repräsentativen Text aus jedem erforderlichen Schriftsystem rendern, um zu bestätigen, dass die zugeordneten Schriften verfügbar sind und die notwendigen Glyphen enthalten.