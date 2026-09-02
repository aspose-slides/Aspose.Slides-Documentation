---
title: Verwalten von skript-spezifischen Theme-Schriften in Python
linktitle: Skript-spezifische Theme-Schriften
type: docs
weight: 15
url: /de/python-net/script-specific-font-mappings/
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
- Aspose.Slides
description: "Untersuchen, hinzufügen, ersetzen und entfernen von skript-spezifischen Schriftzuordnungen in PowerPoint-Themen mit Aspose.Slides für Python via .NET."
---
## **Übersicht**

Ein Präsentationsthema kann verschiedene Schriftfamilien für unterschiedliche Schriftsysteme auswählen. Dadurch kann mehrsprachiger Text, der dennoch Themen­schriften verwendet, einem einheitlichen Schriftschema folgen und gleichzeitig geeignete Schriften für Kyrillisch, Arabisch, Japanisch, Georgisch, Thaana und andere Schriftsysteme nutzen.

Das [FontScheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/fontscheme/) des Themas enthält eine Haupt‑Schriftfamilien‑Sammlung, die typischerweise für Überschriften verwendet wird, und eine Neben‑Sammlung, die üblicherweise für Fließtext genutzt wird. Zusätzlich zu ihren lateinischen und ostasiatischen Schrift‑Eigenschaften stellen beide Sammlungen über die Klasse [Fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides/fonts/) Zuordnungen von Schriftsystem‑Tags zu Schriftfamiliennamen bereit.

Dieser Artikel zeigt, wie man diese Zuordnungen im Master‑Theme der Präsentation inspiziert und ändert und wie man überprüft, dass die Änderungen einen Speicher‑und‑Lade‑Zyklus überstehen.

## **Skript‑Tags verstehen**

Die Methoden für Skript‑Schriften verwenden vier‑buchstabige BCP 47‑Skript‑Subtags, um Schriftsysteme zu identifizieren. Gängige Werte sind:

| Skript‑Tag | Schriftsystem |
|---|---|
| `Cyrl` | Kyrillisch |
| `Arab` | Arabisch |
| `Hans` | Vereinfachtes Chinesisch |
| `Jpan` | Japanisch |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

Diese Zuordnungen gehören zum Theme‑Schrift‑Schema, nicht zu einzelnen Textabschnitten. Eine Präsentation kann unterschiedliche Zuordnungen für die Haupt‑ und Neben‑Sammlungen definieren und kann für manche Skripte Zuordnungen weglassen.

## **Zugriff auf und Inspektion von Skript‑Schrift‑Zuordnungen**

Verwenden Sie [Presentation.master_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/master_theme/), um das thema‑ Ebene‑Theme der Präsentation zu erhalten. Die Eigenschaften [FontScheme.major](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/fontscheme/major/) und [FontScheme.minor](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/fontscheme/minor/) liefern die beiden [Fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides/fonts/)‑Sammlungen.

Rufen Sie [Fonts.get_script_font_map](https://reference.aspose.com/slides/de/python-net/aspose.slides/fonts/get_script_font_map/) auf, um alle Zuordnungen einer Sammlung abzurufen. Um ein bestimmtes Schriftsystem zu suchen, rufen Sie [Fonts.get_script_font](https://reference.aspose.com/slides/de/python-net/aspose.slides/fonts/get_script_font/) mit dessen Skript‑Tag auf. `get_script_font` liefert `None`, wenn die Sammlung die angeforderte Zuordnung nicht definiert.

## **Zuordnungen ändern und Persistenz prüfen**

Verwenden Sie [Fonts.set_script_font](https://reference.aspose.com/slides/de/python-net/aspose.slides/fonts/set_script_font/), um eine Zuordnung zu erstellen oder die aktuelle Schriftfamilie zu ersetzen. Mit [Fonts.remove_script_font](https://reference.aspose.com/slides/de/python-net/aspose.slides/fonts/remove_script_font/) können Sie eine Zuordnung entfernen.

Das folgende End‑zu‑End‑Beispiel liest alle vorhandenen Haupt‑ und Neben‑Zuordnungen, sucht die japanische Hauptschrift, ändert die kyrillische Hauptschrift, entfernt die Thaana‑Neben‑Zuordnung, speichert die Präsentation und öffnet sie erneut, um beide Änderungen zu prüfen. Damit der Entfernungs‑Schritt unabhängig vom Ausgangs‑Theme ist, erzeugt das Beispiel zunächst eine Thaana‑Zuordnung nur, wenn noch keine definiert ist.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

Die Prüfung nutzt dasselbe `None`‑Verhalten wie eine normale Suche: Nach dem Speichern der Entfernung gibt `get_script_font("Thaa")` für die Neben‑Sammlung `None` zurück.

## **Theme‑Zuordnungen von anderen Schrift‑Einstellungen unterscheiden**

Skript‑spezifische Theme‑Zuordnungen wirken sich auf die Schriftauswahl aus, lösen jedoch ein anderes Problem als direkte Textformatierung, Substitution und Fallback:

| Mechanismus | Zweck | Auswirkung der Änderung einer Theme‑Zuordnung |
|---|---|---|
| Skript‑spezifische Theme‑Schrift‑Zuordnung | Wählt eine Haupt‑ oder Neben‑Theme‑Schrift für ein Schriftsystem. | Text, der weiterhin die entsprechende Theme‑Schrift verwendet, kann zur neuen zugeordneten Familie aufgelöst werden. |
| Schriftart explizit einem Textabschnitt zugewiesen | Fixiert die gewünschte Schriftfamilie für diesen Abschnitt statt auf das Theme zu vertrauen. | Der Abschnitt bleibt möglicherweise unverändert, weil seine direkte Formatierung die Theme‑Auswahl überschreibt. |
| Schrift‑Substitution | Ersetzt eine gewünschte Schrift, wenn sie nicht verfügbar ist oder eine Substitutions‑Regel greift. | Sie greift nach der Anforderung einer Schrift; sie definiert die Theme‑Skript‑Zuordnung nicht neu. |
| Schrift‑Fallback | Liefert Glyphen, die die ausgewählte Schrift nicht enthält, oft für bestimmte Unicode‑Bereiche. | Sie ergänzt fehlende Glyphen; sie ändert die gespeicherte Theme‑Zuordnung nicht. |

Weitere Informationen zu den letzten beiden Mechanismen finden Sie unter [Font Substitution](/slides/de/python-net/font-substitution/) und [Fallback Fonts](/slides/de/python-net/fallback-font/).

Eine Änderung in [Presentation.master_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/master_theme/) wirkt sich nur auf Inhalte aus, deren effektive Formatierung noch von diesem Theme abhängt. Text kann stattdessen ein Theme‑Override von einem Master, Layout oder einer Folie erben oder eine explizit zugewiesene Schrift verwenden. Prüfen Sie diese Ebenen, wenn das sichtbare Ergebnis nicht der Präsentations‑Theme‑Zuordnung folgt.

## **Zu­geordnete Schriften verfügbar machen und Ergebnis validieren**

Eine Skript‑Zuordnung speichert nur den Namen einer Schriftfamilie; sie installiert oder lädt die zugehörige Schriftdatei nicht. Für konsistentes Rendern und Export muss jede zugeordnete Schrift in der Umgebung installiert oder Aspose.Slides über eine benutzerdefinierte Quelle wie [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsloader/load_external_fonts/) oder [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/document_level_font_sources/) bereitgestellt werden. Siehe [Custom Fonts](/slides/de/python-net/custom-font/) für die verfügbaren Lademöglichkeiten.

Das Überprüfen der gespeicherten Zuordnung bestätigt nur, dass die Theme‑Definition beibehalten wurde. Sie beweist nicht, dass die Schrift verfügbar ist, alle erforderlichen Glyphen enthält oder das gewünschte Layout erzeugt. Rendern Sie repräsentativen Text für jedes benötigte Schriftsystem in ein Bild oder PDF und prüfen Sie die Ausgabe. So werden fehlende Schriften, unvollständige Glyphen‑Abdeckung, Fallback‑Verhalten und Layout‑Änderungen erkannt, bevor die Präsentation verteilt wird. Siehe [Convert PowerPoint Presentations](/slides/de/python-net/convert-powerpoint/) für Render‑ und Export‑Beispiele.

## **FAQ**

**Was liefert `get_script_font`, wenn ein Skript nicht zugeordnet ist?**

[Fonts.get_script_font](https://reference.aspose.com/slides/de/python-net/aspose.slides/fonts/get_script_font/) liefert `None`, wenn die gewünschte Skript‑Zuordnung in dieser Haupt‑ oder Neben‑Schrift‑Sammlung nicht definiert ist.

**Fügt `set_script_font` eine zweite Zuordnung hinzu, wenn das Skript bereits existiert?**

Nein. [Fonts.set_script_font](https://reference.aspose.com/slides/de/python-net/aspose.slides/fonts/set_script_font/) erstellt die Zuordnung, wenn sie fehlt, und ersetzt die zugeordnete Schriftfamilie, wenn das gleiche Skript‑Tag bereits vorhanden ist.

**Warum hat das Ändern einer Theme‑Zuordnung manchen Text nicht beeinflusst?**

Der Text hat möglicherweise eine explizit zugewiesene Schrift, erbt ein anderes Theme über ein Override oder wird während des Renderns von Substitution oder Fallback betroffen. Eine Präsentations‑Level‑Skript‑Zuordnung steuert nur Text, dessen effektive Formatierung noch auf diese Theme‑Schrift‑Sammlung verweist.

**Reicht das Speichern und erneute Öffnen aus, um mehrsprachige Ausgabe zu validieren?**

Nein. Das erneute Öffnen bestätigt nur die Persistenz der Theme‑Daten. Zusätzlich sollte repräsentativer Text aus jedem benötigten Schriftsystem gerendert werden, um zu prüfen, ob die zugeordneten Schriften verfügbar sind und die notwendigen Glyphen enthalten.