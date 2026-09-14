---
title: Verwalten von skript-spezifischen Theme-Schriften in Python via Java
linktitle: Skript-spezifische Theme-Schriften
type: docs
weight: 15
url: /de/python-java/script-specific-font-mappings/
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
- Python
- Java
- Aspose.Slides
description: "Untersuchen, hinzufügen, ersetzen und entfernen von skript-spezifischen Schriftzuordnungen in PowerPoint-Themes mit Aspose.Slides für Python via Java."
---
## **Übersicht**

Ein Präsentationsthema kann für verschiedene Schriftsysteme unterschiedliche Schriftfamilien auswählen. So kann mehrsprachiger Text, der weiterhin Themen‑Schriften verwendet, ein abgestimmtes Schriftschema verfolgen und gleichzeitig geeignete Schriften für Kyrillisch, Arabisch, Japanisch, Georgisch, Thaana und andere Skripte einsetzen.

Das [FontScheme](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontscheme/) des Themas enthält eine Haupt‑Schriftfamilien‑Sammlung, die typischerweise für Überschriften verwendet wird, und eine Neben‑Sammlung, die typischerweise für Fließtext verwendet wird. Zusätzlich zu ihren lateinischen und ostasiatischen Schrifteinstellungen stellen beide Sammlungen über die Klasse [Fonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fonts/) Zuordnungen von Schreibsystem‑Tags zu Schriftfamilien‑Namen bereit.

Dieser Artikel zeigt, wie Sie diese Zuordnungen im Master‑Theme der Präsentation inspizieren und ändern und prüfen, dass die Änderungen einen Speicher‑und‑Wieder‑Ladevorgang überstehen.

## **Skript‑Tags verstehen**

Die Schriftmethoden verwenden vier‑buchstabige BCP‑47‑Skript‑Subtags, um Schriftsysteme zu identifizieren. Gängige Werte sind:

| Skript‑Tag | Schriftsystem |
|---|---|
| `Cyrl` | Kyrillisch |
| `Arab` | Arabisch |
| `Hans` | vereinfachtes Chinesisch |
| `Jpan` | Japanisch |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

Diese Zuordnungen gehören zum Theme‑Schriftschema, nicht zu einzelnen Textabschnitten. Eine Präsentation kann unterschiedliche Zuordnungen für die Haupt‑ und Neben‑Sammlungen definieren und für einige Skripte keine Zuordnungen vorsehen.

## **Zugriff und Inspektion von Skript‑Schriftzuordnungen**

Verwenden Sie [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getMasterTheme), um das themenbezogene Objekt der Präsentation zu erhalten. Die Methoden [FontScheme.getMajor](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontscheme/#getMajor) und [FontScheme.getMinor](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontscheme/#getMinor) geben die beiden [Fonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fonts/)‑Sammlungen zurück.

Rufen Sie [Fonts.getScriptFontMap](https://reference.aspose.com/slides/de/python-java/aspose.slides/fonts/#getScriptFontMap) auf, um alle Zuordnungen einer Sammlung abzurufen. Um ein bestimmtes Schriftsystem nachzuschlagen, rufen Sie [Fonts.getScriptFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/fonts/#getScriptFont) mit dessen Skript‑Tag auf. `getScriptFont` liefert `None`, wenn die Sammlung die gewünschte Zuordnung nicht definiert.

## **Zuordnungen ändern und Persistenz prüfen**

Verwenden Sie [Fonts.setScriptFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/fonts/#setScriptFont), um eine Zuordnung zu erstellen oder die aktuelle Schriftfamilie zu ersetzen. Verwenden Sie [Fonts.removeScriptFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/fonts/#removeScriptFont), um eine Zuordnung zu entfernen.

Das folgende End‑zu‑Ende‑Beispiel liest alle vorhandenen Haupt‑ und Neben‑Zuordnungen, sucht die japanische Hauptschrift, ändert die kyrillische Hauptschrift, entfernt die Thaana‑Neben‑Zuordnung, speichert die Präsentation und öffnet sie erneut, um beide Änderungen zu verifizieren. Damit der Entfernungsschritt unabhängig vom Ausgangsthema ist, erzeugt das Beispiel zunächst nur dann eine Thaana‑Zuordnung, wenn noch keine definiert ist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

Die Verifizierung verwendet dasselbe `None`‑Verhalten wie ein gewöhnlicher Nachschlag: Nach dem Speichern der Entfernung liefert `getScriptFont("Thaa")` für die Neben‑Sammlung `None`.

## **Themenzuordnungen von anderen Schrifteinstellungen unterscheiden**

Skript‑spezifische Themenzuordnungen nehmen an der Schriftauswahl teil, lösen jedoch ein anderes Problem als direkte Textformatierung, Substitution und Fallback:

| Mechanismus | Zweck | Auswirkung einer Änderung einer Themenzuordnung |
|---|---|---|
| Skript‑spezifische Themen‑Schriftzuordnung | Wählt eine Haupt‑ oder Neben‑Themen‑Schrift für ein Schriftsystem. | Text, der weiterhin die entsprechende Themen‑Schrift nutzt, kann auf die neu zugeordnete Familie aufgelöst werden. |
| Schrift explizit einem Textabschnitt zugewiesen | Fixiert die gewünschte Schriftfamilie für diesen Abschnitt, anstatt das Thema zu verwenden. | Der Abschnitt bleibt unverändert, weil seine direkte Formatierung die Themenwahl überschreibt. |
| Schrift‑Substitution | Ersetzt eine gewünschte Schrift, wenn diese nicht verfügbar ist oder eine Substitutionsregel greift. | Sie greift nach der Anforderung einer Schrift; sie definiert die Themen‑Skript‑Zuordnung nicht neu. |
| Schrift‑Fallback | Liefert Glyphen, die die ausgewählte Schrift nicht enthält, häufig für bestimmte Unicode‑Bereiche. | Sie ergänzt fehlende Glyphen; sie ändert nicht die gespeicherte Themen‑Zuordnung. |

Weitere Informationen zu den beiden letzten Mechanismen finden Sie unter [Font Substitution](/slides/de/python-java/font-substitution/) und [Fallback Fonts](/slides/de/python-java/fallback-font/).

Das Ändern einer Zuordnung über [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getMasterTheme) wirkt nur auf Inhalte, deren effektive Formatierung noch von diesem Theme abhängt. Text kann stattdessen ein Themen‑Override von einem Master, Layout oder einer Folie erben oder eine explizit zugewiesene Schrift verwenden. Untersuchen Sie diese Ebenen, wenn das sichtbare Ergebnis nicht der Präsentations‑Thema‑Zuordnung folgt.

## **Zuordnete Schriften verfügbar machen und Ergebnis validieren**

Eine Skript‑Zuordnung speichert nur den Namen einer Schriftfamilie; sie installiert oder lädt die entsprechende Schriftdatei nicht. Für konsistentes Rendern und Export muss jede zugeordnete Schrift in der Umgebung installiert oder Aspose.Slides über eine benutzerdefinierte Quelle bereitgestellt werden, z. B. über [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsloader/#loadExternalFonts) oder [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Siehe [Custom Fonts](/slides/de/python-java/custom-font/) für die verfügbaren Ladeoptionen.

Die Prüfung der gespeicherten Zuordnung bestätigt nur, dass die Themen‑Definition erhalten blieb. Sie beweist nicht, dass die Schrift verfügbar ist, alle erforderlichen Glyphen enthält oder das gewünschte Layout erzeugt. Rendern Sie repräsentativen Text für jedes benötigte Schriftsystem in ein Bild oder PDF und prüfen Sie die Ausgabe. So werden fehlende Schriften, unvollständige Glyphen‑Abdeckung, Fallback‑Verhalten und Layout‑Änderungen erkannt, bevor die Präsentation verteilt wird. Siehe [Convert PowerPoint Presentations](/slides/de/python-java/convert-powerpoint/) für Beispiele zum Rendern und Exportieren.

## **FAQ**

**Was gibt `getScriptFont` zurück, wenn ein Skript nicht zugeordnet ist?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/fonts/#getScriptFont) gibt `None` zurück, wenn die gewünschte Skript‑Zuordnung in dieser Haupt‑ oder Neben‑Schrift‑Sammlung nicht definiert ist.

**Fügt `setScriptFont` eine zweite Zuordnung hinzu, wenn das Skript bereits existiert?**

Nein. [Fonts.setScriptFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/fonts/#setScriptFont) erstellt die Zuordnung, wenn sie fehlt, und ersetzt die zugeordnete Schriftfamilie, wenn derselbe Skript‑Tag bereits vorhanden ist.

**Warum änderte das Ändern einer Themen‑Zuordnung nicht den Text?**

Der Text kann eine explizit zugewiesene Schrift haben, ein anderes Theme über ein Override erben oder während des Renderns von Substitution bzw. Fallback betroffen sein. Eine skript‑spezifische Zuordnung auf Präsentationsebene steuert nur Text, dessen effektive Formatierung noch auf diese Themen‑Schrift‑Sammlung verweist.

**Reicht ein Speichern und erneutes Öffnen aus, um die mehrsprachige Ausgabe zu validieren?**

Nein. Das erneute Öffnen bestätigt nur die Persistenz der Themen‑Daten. Zusätzlich sollten Sie repräsentativen Text aus jedem erforderlichen Schriftsystem rendern, um sicherzustellen, dass die zugeordneten Schriften verfügbar sind und die nötigen Glyphen enthalten.