---
title: Verwalten skript­spezifischer Themen­schriften in .NET
linktitle: Skript­spezifische Themen­schriften
type: docs
weight: 15
url: /de/net/script-specific-font-mappings/
keywords:
- skript­spezifische Schrift
- Themen­schriftzuordnung
- mehrsprachige Präsentation
- Schriftsystem
- kyrillische Schrift
- arabische Schrift
- japanische Schrift
- georgische Schrift
- Thaana‑Schrift
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Skript­spezifische Schriftzuordnungen in PowerPoint‑Themen mit Aspose.Slides für .NET untersuchen, hinzufügen, ersetzen und entfernen."
---
## **Übersicht**

Ein Präsentationsthema kann für verschiedene Schriftsysteme unterschiedliche Schriftfamilien auswählen. Dadurch kann mehrsprachiger Text, der weiterhin Themen‑Schriftarten verwendet, einem einheitlichen Schriftartenschema folgen und gleichzeitig geeignete Schriften für Kyrillisch, Arabisch, Japanisch, Georgisch, Thaana und andere Schriften verwenden.

Das [IFontScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/ifontscheme/) enthält eine Haupt‑Schriftartensammlung, die typischerweise für Überschriften verwendet wird, und eine Neben‑Schriftartensammlung, die typischerweise für Fließtext verwendet wird. Zusätzlich zu ihren lateinischen und ostasiatischen Schriftarteigenschaften stellen beide Sammlungen Zuordnungen von Schriftsystem‑Tags zu Schriftfamiliennamen über die [IFonts](https://reference.aspose.com/slides/de/net/aspose.slides/ifonts/)‑Schnittstelle bereit.

Dieser Artikel zeigt, wie man diese Zuordnungen im Master‑Thema der Präsentation inspiziert und ändert und überprüft, dass die Änderungen einen Speicher‑und‑Lade‑Durchlauf überstehen.

## **Skript‑Tags verstehen**

Die Methoden für Skript‑Schriften verwenden vierstellige BCP 47‑Skript‑Subtags, um Schriftsysteme zu identifizieren. Häufige Werte sind:

| Skript‑Tag | Schriftsystem |
|---|---|
| `Cyrl` | Kyrillisch |
| `Arab` | Arabisch |
| `Hans` | Vereinfachtes Chinesisch |
| `Jpan` | Japanisch |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

Diese Zuordnungen gehören zum Schriftartenschema des Themas, nicht zu einzelnen Textabschnitten. Eine Präsentation kann unterschiedliche Zuordnungen für die Haupt‑ und Neben‑Sammlungen definieren und manche Skripte weglassen.

## **Zugriff auf und Untersuchung von Skript‑Schrift‑Zuordnungen**

Verwenden Sie [Presentation.MasterTheme](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/mastertheme/), um auf das thema‑ebene Thema zuzugreifen. Die Eigenschaften [FontScheme.Major](https://reference.aspose.com/slides/de/net/aspose.slides.theme/fontscheme/major/) und [FontScheme.Minor](https://reference.aspose.com/slides/de/net/aspose.slides.theme/fontscheme/minor/) geben die beiden [IFonts](https://reference.aspose.com/slides/de/net/aspose.slides/ifonts/)‑Sammlungen zurück.

Rufen Sie [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/de/net/aspose.slides/fonts/getscriptfontmap/) auf, um alle Zuordnungen aus einer Sammlung zu erhalten. Um ein bestimmtes Schriftsystem nachzuschlagen, rufen Sie [IFonts.GetScriptFont](https://reference.aspose.com/slides/de/net/aspose.slides/fonts/getscriptfont/) mit seinem Skript‑Tag auf. `GetScriptFont` gibt `null` zurück, wenn diese Sammlung die angeforderte Zuordnung nicht definiert.

## **Zuordnungen ändern und Persistenz überprüfen**

Verwenden Sie [IFonts.SetScriptFont](https://reference.aspose.com/slides/de/net/aspose.slides/fonts/setscriptfont/), um eine Zuordnung zu erstellen oder die aktuelle Schriftfamilie zu ersetzen. Verwenden Sie [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/de/net/aspose.slides/fonts/removescriptfont/), um eine Zuordnung zu entfernen.

Das folgende End‑zu‑Ende‑Beispiel liest alle vorhandenen Haupt‑ und Neben‑Zuordnungen, sucht die japanische Hauptschrift, ändert die kyrillische Hauptschrift, entfernt die Thaana‑Neben‑Zuordnung, speichert die Präsentation und öffnet sie erneut, um beide Änderungen zu überprüfen. Um den Entfernungs‑Schritt unabhängig vom Anfangsthema zu machen, erstellt das Beispiel zunächst eine Thaana‑Zuordnung nur dann, wenn noch keine definiert ist.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

Die Verifizierung verwendet das gleiche `null`‑Verhalten wie ein gewöhnlicher Lookup: Nach dem Speichern der Entfernung gibt `GetScriptFont("Thaa")` für die Neben‑Sammlung `null` zurück.

## **Thema‑Zuordnungen von anderen Schrift‑Einstellungen unterscheiden**

Skript‑spezifische Thema‑Zuordnungen nehmen an der Schriftauswahl teil, lösen jedoch ein anderes Problem als direkte Textformatierung, Substitution und Fallback:

| Mechanismus | Zweck | Auswirkung einer Änderung der Thema‑Zuordnung |
|---|---|---|
| Skript‑spezifische Thema‑Schriftzuordnung | Wählt eine Haupt‑ oder Neben‑Thema‑Schrift für ein Schriftsystem. | Text, der weiterhin die entsprechende Thema‑Schrift verwendet, kann auf die neue zugeordnete Familie aufgelöst werden. |
| Schriftart, die einem Textabschnitt explizit zugewiesen ist | Legt die gewünschte Schriftfamilie für diesen Abschnitt fest, anstatt das Thema zu verwenden. | Der Abschnitt bleibt möglicherweise unverändert, weil seine direkte Formatierung die Themenwahl überschreibt. |
| Schrift‑Substitution | Ersetzt eine gewünschte Schrift, wenn diese nicht verfügbar ist oder eine Substitutionsregel greift. | Sie greift nach einer Schriftanfrage; sie definiert die Thema‑Skript‑Zuordnung nicht neu. |
| Schrift‑Fallback | Liefert Glyphen, die die ausgewählte Schrift nicht enthält, häufig für bestimmte Unicode‑Bereiche. | Sie füllt fehlende Glyphen ab; sie ändert die gespeicherte Thema‑Zuordnung nicht. |

Weitere Informationen zu den letzten beiden Mechanismen finden Sie unter [Font Substitution](/slides/de/net/font-substitution/) und [Fallback Fonts](/slides/de/net/fallback-font/).

Eine Änderung einer Zuordnung in [Presentation.MasterTheme](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/mastertheme/) wirkt sich nur auf Inhalte aus, deren effektive Formatierung noch von diesem Thema abhängt. Text kann stattdessen eine Thema‑Überschreibung von einem Master, Layout oder einer Folie erben oder eine explizit zugewiesene Schrift verwenden. Untersuchen Sie diese Ebenen, wenn das sichtbare Ergebnis nicht der Mapping‑Definition auf Präsentationsebene folgt.

## **Gemappte Schriften verfügbar machen und Ergebnis validieren**

Eine Skript‑Zuordnung speichert nur einen Schriftfamiliennamen; sie installiert oder lädt die entsprechende Schriftdatei nicht. Für konsistente Darstellung und Export muss jede gemappte Schrift in der Umgebung installiert oder Aspose.Slides über eine benutzerdefinierte Quelle wie [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/de/net/aspose.slides/fontsloader/loadexternalfonts/) oder [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/documentlevelfontsources/) bereitgestellt werden. Siehe [Custom Fonts](/slides/de/net/custom-font/) für die verfügbaren Ladeoptionen.

Das Verifizieren der gespeicherten Zuordnung bestätigt lediglich, dass die Themen‑Definition erhalten blieb. Es beweist nicht, dass die Schrift verfügbar ist, alle erforderlichen Glyphen enthält oder das gewünschte Layout erzeugt. Rendern Sie repräsentativen Text für jedes notwendige Schriftsystem zu einem Bild oder PDF und prüfen Sie die Ausgabe. So werden fehlende Schriften, unvollständige Glyphenabdeckung, Fallback‑Verhalten und Layout‑Änderungen noch vor der Verteilung der Präsentation erkannt. Siehe [Convert PowerPoint Presentations](/slides/de/net/convert-powerpoint/) für Beispiele zum Rendern und Exportieren.

## **FAQ**

**Was gibt `GetScriptFont` zurück, wenn ein Skript nicht gemappt ist?**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/de/net/aspose.slides/fonts/getscriptfont/) gibt `null` zurück, wenn die gewünschte Skript‑Zuordnung in dieser Haupt‑ oder Neben‑Schriftartensammlung nicht definiert ist.

**Fügt `SetScriptFont` eine zweite Zuordnung hinzu, wenn das Skript bereits existiert?**

Nein. [IFonts.SetScriptFont](https://reference.aspose.com/slides/de/net/aspose.slides/fonts/setscriptfont/) erstellt die Zuordnung, wenn sie fehlt, und ersetzt die gemappte Schriftfamilie, wenn der gleiche Skript‑Tag bereits vorhanden ist.

**Warum hat das Ändern einer Thema‑Zuordnung manchen Text nicht beeinflusst?**

Der Text kann eine explizit zugewiesene Schrift haben, eine andere Thema‑Überschreibung erben oder durch Substitution bzw. Fallback beim Rendern beeinflusst werden. Eine Skript‑Zuordnung auf Präsentationsebene steuert nur Text, dessen effektive Formatierung noch auf diese Thema‑Schriftartensammlung verweist.

**Reicht das Speichern und erneute Öffnen aus, um mehrsprachige Ausgabe zu validieren?**

Nein. Das erneute Öffnen bestätigt nur die Persistenz der Themen‑Daten. Zusätzlich sollten repräsentative Texte aus jedem notwendigen Schriftsystem gerendert werden, um sicherzustellen, dass die gemappten Schriften verfügbar sind und die erforderlichen Glyphen enthalten.