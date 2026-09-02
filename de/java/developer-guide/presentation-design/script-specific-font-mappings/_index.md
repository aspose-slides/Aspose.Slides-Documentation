---
title: Skript‑spezifische Theme‑Schriften verwalten in Java
linktitle: Skript‑spezifische Theme‑Schriften
type: docs
weight: 15
url: /de/java/script-specific-font-mappings/
keywords:
- skript‑spezifische Schrift
- Theme‑Schriftzuordnung
- mehrsprachige Präsentation
- Schriftsystem
- kyrillische Schrift
- arabische Schrift
- japanische Schrift
- georgische Schrift
- Thaana‑Schrift
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Untersuchen, hinzufügen, ersetzen und entfernen von skript‑spezifischen Schriftzuordnungen in PowerPoint‑Themes mit Aspose.Slides für Java."
---
## **Übersicht**

Ein Präsentationsthema kann für verschiedene Schriftsysteme unterschiedliche Schriftfamilien auswählen. Dadurch kann mehrsprachiger Text, der weiterhin die Theme‑Schriften verwendet, einem einheitlichen Schriftkonzept folgen und gleichzeitig geeignete Schriften für Kyrillisch, Arabisch, Japanisch, Georgisch, Thaana und andere Schriften verwenden.

Das Theme‑[IFontScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontscheme/) enthält eine Hauptschrift‑Sammlung, die typischerweise für Überschriften verwendet wird, und eine Nebenschrift‑Sammlung, die typischerweise für Fließtext verwendet wird. Zusätzlich zu ihren lateinischen und ostasiatischen Schrift‑Einstellungen stellen beide Sammlungen Zuordnungen von Schreiftsystem‑Tags zu Schriftfamiliennamen über das [IFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifonts/)‑Interface bereit.

Dieser Artikel zeigt, wie diese Zuordnungen im Master‑Theme der Präsentation inspiziert und geändert werden können und wie man überprüft, dass die Änderungen einen Speicher‑und‑Lade‑Durchlauf überstehen.

## **Skript‑Tags verstehen**

Die Methoden für Skript‑Schriften verwenden vier‑buchstabige BCP‑47‑Skript‑Subtags, um Schriftsysteme zu identifizieren. Häufige Werte sind:

| Skript‑Tag | Schriftsystem |
|---|---|
| `Cyrl` | Kyrillisch |
| `Arab` | Arabisch |
| `Hans` | Vereinfachtes Chinesisch |
| `Jpan` | Japanisch |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

Diese Zuordnungen gehören zum Theme‑Schrift‑Schema, nicht zu einzelnen Textabschnitten. Eine Präsentation kann unterschiedliche Zuordnungen für die Haupt‑ und Nebensammlungen definieren und kann für einige Skripte keine Zuordnungen enthalten.

## **Zugriff auf und Inspektion von Skript‑Schriftzuordnungen**

Verwenden Sie [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getMasterTheme--) , um das Theme auf Präsentationsebene zu erhalten. Die Methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontscheme/#getMajor--) und [IFontScheme.getMinor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontscheme/#getMinor--) geben die beiden [IFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifonts/)‑Sammlungen zurück.

Rufen Sie [IFonts.getScriptFontMap](https://reference.aspose.com/slides/de/java/com.aspose.slides/fonts/#getScriptFontMap--) auf, um alle Zuordnungen einer Sammlung abzurufen. Um ein bestimmtes Schriftsystem nachzuschlagen, rufen Sie [IFonts.getScriptFont](https://reference.aspose.com/slides/de/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) mit dessen Skript‑Tag auf. `getScriptFont` gibt `null` zurück, wenn diese Sammlung die angeforderte Zuordnung nicht definiert.

## **Zuordnungen ändern und Persistenz prüfen**

Verwenden Sie [IFonts.setScriptFont](https://reference.aspose.com/slides/de/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-), um eine Zuordnung zu erstellen oder die aktuelle Schriftfamilie zu ersetzen. Verwenden Sie [IFonts.removeScriptFont](https://reference.aspose.com/slides/de/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-), um eine Zuordnung zu entfernen.

Das folgende End‑to‑End‑Beispiel liest alle bestehenden Haupt‑ und Neben‑Zuordnungen, sucht die japanische Hauptschrift, ändert die kyrillische Hauptschrift, entfernt die Thaana‑Neben‑Zuordnung, speichert die Präsentation und öffnet sie erneut, um beide Änderungen zu prüfen. Damit der Entfernungsschritt unabhängig vom ursprünglichen Theme ist, erstellt das Beispiel nur dann eine Thaana‑Zuordnung, wenn noch keine definiert ist.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Die Überprüfung verwendet dasselbe `null`‑Verhalten wie ein gewöhnlicher Lookup: Nach dem Speichern der Entfernung gibt `getScriptFont("Thaa")` für die Neben‑Sammlung `null` zurück.

## **Unterscheiden von Theme‑Zuordnungen und anderen Schrift‑Einstellungen**

Skript‑spezifische Theme‑Schriftzuordnungen nehmen am Schriftauswahlprozess teil, lösen jedoch ein anderes Problem als direkte Textformatierung, Ersetzung und Fallback:

| Mechanismus | Zweck | Auswirkung einer Änderung der Theme‑Zuordnung |
|---|---|---|
| Skript‑spezifische Theme‑Schriftzuordnung | Wählt für ein Schriftsystem die Haupt‑ oder Nebenthemeschrift aus. | Text, der weiterhin die entsprechende Theme‑Schrift verwendet, kann zur neuen zugeordneten Familie aufgelöst werden. |
| Schriftart, die einem Textabschnitt explizit zugewiesen ist | Legt die gewünschte Schriftfamilie für diesen Abschnitt fest, anstatt sich auf das Theme zu verlassen. | Der Abschnitt kann unverändert bleiben, weil seine direkte Formatierung die Theme‑Auswahl überschreibt. |
| Schriftart‑Ersetzung | Ersetzt eine angeforderte Schrift, wenn diese nicht verfügbar ist oder wenn eine Ersetzungsregel zutrifft. | Sie greift, nachdem eine Schrift angefordert wurde; sie definiert die Skript‑Zuordnung des Themes nicht neu. |
| Schrift‑Fallback | Stellt Glyphen bereit, die die ausgewählte Schrift nicht enthält, häufig für bestimmte Unicode‑Bereiche. | Sie füllt fehlende Glyphen ab; sie ändert nicht die gespeicherte Theme‑Zuordnung. |

Weitere Informationen zu den letzten beiden Mechanismen finden Sie unter [Font Substitution](/slides/de/java/font-substitution/) und [Fallback Fonts](/slides/de/java/fallback-font/).

Das Ändern einer Zuordnung in [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getMasterTheme--) wirkt sich nur auf Inhalte aus, deren effektive Formatierung noch von diesem Theme abhängt. Text kann stattdessen eine Theme‑Überschreibung von einem Master, Layout oder Folie erben oder eine explizit zugewiesene Schrift verwenden. Untersuchen Sie diese Ebenen, wenn das sichtbare Ergebnis nicht der Präsentationsebene‑Zuordnung folgt.

## **Zuordnete Schriften verfügbar machen und Ergebnis validieren**

Eine Skript‑Zuordnung speichert einen Schriftfamiliennamen; sie installiert oder lädt die entsprechende Schriftdatei nicht. Für konsistente Darstellung und Export muss jede zugeordnete Schrift in der Umgebung installiert oder Aspose.Slides über eine benutzerdefinierte Quelle wie [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) oder [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--) bereitgestellt werden. Siehe [Custom Fonts](/slides/de/java/custom-font/) für die verfügbaren Ladeoptionen.

Das Verifizieren der gespeicherten Zuordnung bestätigt lediglich, dass die Theme‑Definition erhalten blieb. Es beweist nicht, dass die Schrift verfügbar ist, alle benötigten Glyphen enthält oder das beabsichtigte Layout erzeugt. Rendern Sie repräsentativen Text für jedes erforderliche Schriftsystem zu einem Bild oder PDF und prüfen Sie die Ausgabe. Dadurch werden fehlende Schriften, unvollständige Glyphenabdeckung, Fallback‑Verhalten und Layout‑Änderungen vor der Verteilung der Präsentation erkannt. Siehe [Convert PowerPoint Presentations](/slides/de/java/convert-powerpoint/) für Beispiele zu Rendering und Export.

## **FAQ**

**Was gibt `getScriptFont` zurück, wenn ein Skript nicht zugeordnet ist?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/de/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) gibt `null` zurück, wenn die angeforderte Skript‑Zuordnung in dieser Haupt‑ oder Nebenschrift‑Sammlung nicht definiert ist.

**Fügt `setScriptFont` eine zweite Zuordnung hinzu, wenn das Skript bereits existiert?**

Nein. [IFonts.setScriptFont](https://reference.aspose.com/slides/de/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) erstellt die Zuordnung, wenn sie fehlt, und ersetzt die zugeordnete Schriftfamilie, wenn derselbe Skript‑Tag bereits vorhanden ist.

**Warum hat das Ändern einer Theme‑Zuordnung manchen Text nicht geändert?**

Der Text kann eine explizit zugewiesene Schrift haben, eine andere Theme‑Überschreibung über eine Override erben oder während des Renderns von Ersetzung bzw. Fallback betroffen sein. Eine Skript‑Zuordnung auf Präsentationsebene steuert nur Text, dessen effektive Formatierung noch auf diese Theme‑Schrift‑Sammlung verweist.

**Reicht das Speichern und erneute Öffnen aus, um mehrsprachige Ausgaben zu validieren?**

Nein. Das erneute Öffnen bestätigt nur die Persistenz der Theme‑Daten. Zusätzlich sollten repräsentative Texte aus jedem erforderlichen Schriftsystem gerendert werden, um sicherzustellen, dass die zugeordneten Schriften verfügbar sind und die notwendigen Glyphen enthalten.