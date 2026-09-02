---
title: Verwalten von skript-spezifischen Theme-Schriften auf Android
linktitle: Skript-spezifische Theme-Schriften
type: docs
weight: 15
url: /de/androidjava/script-specific-font-mappings/
keywords:
- skript-spezifische Schrift
- Theme-Schriftzuordnung
- mehrsprachige Präsentation
- Schriftsystem
- kyrillische Schrift
- arabische Schrift
- japanische Schrift
- georgische Schrift
- Thaana-Schrift
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Inspektieren, hinzufügen, ersetzen und entfernen von skript-spezifischen Schriftzuordnungen in PowerPoint-Themes mit Aspose.Slides für Android via Java."
---
## **Übersicht**

Ein Präsentationsthema kann für verschiedene Schriftsysteme unterschiedliche Schriftfamilien auswählen. Dadurch kann mehrsprachiger Text, der weiterhin die Thema‑Schriften verwendet, einem einheitlichen Schriftschema folgen und gleichzeitig geeignete Schriften für Kyrillisch, Arabisch, Japanisch, Georgisch, Thaana und andere Schriftsysteme nutzen.

Das [IFontScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontscheme/) des Themas enthält eine Hauptschrift‑Sammlung, die typischerweise für Überschriften verwendet wird, und eine Neben‑Schrift‑Sammlung, die typischerweise für Fließtext verwendet wird. Zusätzlich zu ihren Latino‑ und Ostasiatisch‑Schrifteinstellungen stellen beide Sammlungen Abbildungen von Schriftsystem‑Tags zu Schriftfamiliennamen über die [IFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifonts/)‑Schnittstelle bereit.

Dieser Artikel zeigt, wie man diese Abbildungen im Master‑Theme der Präsentation inspiziert und ändert und prüft, dass die Änderungen einen Speicher‑und‑Lade‑Zyklus überstehen.

## **Skript‑Tags verstehen**

Die Skript‑Schrift‑Methoden verwenden vier‑buchstabige BCP‑47‑Skript‑Subtags, um Schriftsysteme zu identifizieren. Gängige Werte sind:

| Skript‑Tag | Schriftsystem |
|---|---|
| `Cyrl` | Kyrillisch |
| `Arab` | Arabisch |
| `Hans` | Vereinfachtes Chinesisch |
| `Jpan` | Japanisch |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

Diese Abbildungen gehören zum Theme‑Schriftschema, nicht zu einzelnen Textabschnitten. Eine Präsentation kann unterschiedliche Abbildungen für die Haupt‑ und Neben‑Sammlungen definieren und für einige Skripte ganz auf Abbildungen verzichten.

## **Zugriff auf und Inspektion von Skript‑Schriftzuordnungen**

Verwenden Sie [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getMasterTheme--), um auf das themenbezogene Niveau der Präsentation zuzugreifen. Die Methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontscheme/#getMajor--) und [IFontScheme.getMinor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontscheme/#getMinor--) geben die beiden [IFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifonts/)‑Sammlungen zurück.

Rufen Sie [IFonts.getScriptFontMap](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) auf, um alle Abbildungen einer Sammlung zu erhalten. Um ein einzelnes Schriftsystem nachzuschlagen, rufen Sie [IFonts.getScriptFont](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) mit dessen Skript‑Tag auf. `getScriptFont` liefert `null`, wenn diese Sammlung die angeforderte Abbildung nicht definiert.

## **Zuordnungen ändern und Persistenz prüfen**

Verwenden Sie [IFonts.setScriptFont](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-), um eine Abbildung zu erstellen oder die aktuelle Schriftfamilie zu ersetzen. Verwenden Sie [IFonts.removeScriptFont](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-), um eine Abbildung zu entfernen.

Das folgende End‑zu‑End‑Beispiel liest alle vorhandenen Haupt‑ und Neben‑Abbildungen, schaut die japanische Hauptschrift nach, ändert die kyrillische Hauptschrift, entfernt die Thaana‑Neben‑Abbildung, speichert die Präsentation und öffnet sie erneut, um beide Änderungen zu überprüfen. Damit der Entfernungsschritt unabhängig vom Ausgangs‑Theme ist, erzeugt das Beispiel zunächst eine Thaana‑Abbildung nur, wenn noch keine definiert ist.

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

Die Überprüfung verwendet dasselbe `null`‑Verhalten wie ein gewöhnlicher Lookup: Nach dem Speichern der Entfernung liefert `getScriptFont("Thaa")` für die Neben‑Sammlung `null`.

## **Theme‑Zuordnungen von anderen Schriftarteinstellungen unterscheiden**

Skript‑spezifische Theme‑Zuordnungen nehmen an der Schriftauswahl teil, lösen jedoch ein anderes Problem als direkte Textformatierung, Substitution und Fallback:

| Mechanismus | Zweck | Auswirkung einer Änderung der Theme‑Zuordnung |
|---|---|---|
| Skript‑spezifische Theme‑Schriftzuordnung | Wählt eine Haupt‑ oder Neben‑Theme‑Schrift für ein Schriftsystem. | Text, der weiterhin die entsprechende Theme‑Schrift nutzt, kann auf die neue zugeordnete Familie aufgelöst werden. |
| Schrift explizit einem Textabschnitt zugewiesen | Fixiert die geforderte Schriftfamilie für diesen Abschnitt, anstatt das Theme zu benutzen. | Der Abschnitt bleibt möglicherweise unverändert, weil seine direkte Formatierung die Theme‑Auswahl überschreibt. |
| Schrift‑Substitution | Ersetzt eine geforderte Schrift, wenn diese nicht verfügbar ist oder eine Substitutionsregel greift. | Sie greift nach einer Schriftanfrage; sie definiert die Theme‑Skript‑Zuordnung nicht neu. |
| Schrift‑Fallback | Liefert Glyphen, die die ausgewählte Schrift nicht enthält, häufig für bestimmte Unicode‑Bereiche. | Sie füllt fehlende Glyphen ab; sie ändert nicht die gespeicherte Theme‑Zuordnung. |

Weitere Informationen zu den letzten beiden Mechanismen finden Sie unter [Font Substitution](/slides/de/androidjava/font-substitution/) und [Fallback Fonts](/slides/de/androidjava/fallback-font/).

Eine Änderung einer Zuordnung in [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getMasterTheme--) wirkt sich nur auf Inhalte aus, deren effektive Formatierung noch von diesem Theme abhängt. Text kann stattdessen eine Theme‑Überschreibung von einem Master, Layout oder einer Folie erben oder eine explizit zugewiesene Schrift verwenden. Untersuchen Sie diese Ebenen, wenn das sichtbare Ergebnis nicht der Präsentation‑Ebene‑Zuordnung folgt.

## **Zu­geordnete Schriftarten verfügbar machen und Ergebnis validieren**

Eine Skript‑Zuordnung speichert nur einen Schrift­familien‑Namen; sie installiert oder lädt die zugehörige Schriftdatei nicht. Für konsistentes Rendern und Export muss jede zugeordnete Schrift in der Umgebung installiert oder Aspose.Slides über eine benutzerdefinierte Quelle bereitgestellt werden, z. B. über [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) oder [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Siehe [Custom Fonts](/slides/de/androidjava/custom-font/) für die verfügbaren Lademöglichkeiten.

Die Überprüfung der gespeicherten Zuordnung bestätigt nur, dass die Theme‑Definition erhalten blieb. Sie beweist nicht, dass die Schrift verfügbar ist, alle benötigten Glyphen enthält oder das gewünschte Layout erzeugt. Rendern Sie repräsentativen Text für jedes erforderliche Schriftsystem in ein Bild oder PDF und prüfen Sie die Ausgabe. So werden fehlende Schriften, unvollständige Glyphen‑Abdeckung, Fallback‑Verhalten und Layout‑Änderungen erkannt, bevor die Präsentation verteilt wird. Siehe [Convert PowerPoint Presentations](/slides/de/androidjava/convert-powerpoint/) für Render‑ und Exportbeispiele.

## **FAQ**

**Was gibt `getScriptFont` zurück, wenn ein Skript nicht zugeordnet ist?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) gibt `null` zurück, wenn die angeforderte Skript‑Zuordnung in dieser Haupt‑ oder Neben‑Schrift‑Sammlung nicht definiert ist.

**Fügt `setScriptFont` eine zweite Zuordnung hinzu, wenn das Skript bereits existiert?**

Nein. [IFonts.setScriptFont](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) erstellt die Zuordnung, wenn sie fehlt, und ersetzt die zugeordnete Schriftfamilie, wenn das gleiche Skript‑Tag bereits vorhanden ist.

**Warum hat das Ändern einer Theme‑Zuordnung manchen Text nicht geändert?**

Der Text hat möglicherweise eine explizit zugewiesene Schrift, erbt ein anderes Theme durch eine Überschreibung oder wird während des Renderns von Substitution oder Fallback beeinflusst. Eine Präsentation‑Ebene‑Skript‑Zuordnung steuert nur Text, dessen effektive Formatierung noch auf diese Theme‑Schrift‑Sammlung verweist.

**Reicht das Speichern und erneute Öffnen aus, um mehrsprachige Ausgabe zu validieren?**

Nein. Das erneute Öffnen prüft die Persistenz der Theme‑Daten. Zusätzlich sollten Sie repräsentativen Text aus jedem erforderlichen Schriftsystem rendern, um zu bestätigen, dass die zugeordneten Schriften verfügbar sind und die notwendigen Glyphen enthalten.