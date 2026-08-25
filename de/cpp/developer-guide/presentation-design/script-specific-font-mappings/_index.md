---
title: Verwalten skript-spezifischer Theme-Schriften in C++
linktitle: Skript-spezifische Theme-Schriften
type: docs
weight: 15
url: /de/cpp/script-specific-font-mappings/
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
- C++
- Aspose.Slides
description: "Untersuchen, hinzufügen, ersetzen und entfernen skript-spezifischer Schriftzuordnungen in PowerPoint-Themes mit Aspose.Slides für C++."
---
## **Overview**

Ein Präsentationsthema kann für verschiedene Schriftsysteme unterschiedliche Schriftfamilien auswählen. Dadurch kann mehrsprachiger Text, der weiterhin die Themenschriften verwendet, einem koordinierten Schriftschema folgen und gleichzeitig geeignete Schriften für Kyrillisch, Arabisch, Japanisch, Georgisch, Thaana und andere Schriften verwenden.

Das [IFontScheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ifontscheme/) des Themas enthält eine Hauptschrift‑Sammlung, die typischerweise für Überschriften verwendet wird, und eine Neben­schrift‑Sammlung, die üblicherweise für Fließtext genutzt wird. Zusätzlich zu ihren lateinischen und ostasiatischen Schrifteigenschaften stellen beide Sammlungen Zuordnungen von Schreibsystem‑Tags zu Schriftfamiliennamen über die [IFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifonts/)‑Schnittstelle bereit.

Dieser Artikel zeigt, wie man diese Zuordnungen im Master‑Thema der Präsentation inspiziert und ändert und prüft, dass die Änderungen einen Speicher‑und‑Lade‑Zyklus überstehen.

## **Understand Script Tags**

Die Methoden für Skript‑Schriften verwenden vier‑buchstabige BCP‑47‑Skript‑Subtags, um Schriftsysteme zu identifizieren. Gängige Werte sind:

| Skript‑Tag | Schriftsystem |
|---|---|
| `Cyrl` | Kyrillisch |
| `Arab` | Arabisch |
| `Hans` | Vereinfachtes Chinesisch |
| `Jpan` | Japanisch |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

Diese Zuordnungen gehören zum Theme‑Schrift‑Schema, nicht zu einzelnen Textabschnitten. Eine Präsentation kann unterschiedliche Zuordnungen für die Haupt‑ und Neben‑Sammlungen definieren und für einige Schriften auch keine Zuordnung hinterlegen.

## **Access and Inspect Script Font Mappings**

Verwenden Sie [Presentation::get_MasterTheme](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_mastertheme/), um das themenbezogene Objekt der Präsentation zu erhalten. Die Methoden [FontScheme::get_Major](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/fontscheme/get_major/) und [FontScheme::get_Minor](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/fontscheme/get_minor/) geben die beiden [IFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifonts/)‑Sammlungen zurück.

Rufen Sie [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/de/cpp/aspose.slides/fonts/getscriptfontmap/) auf, um alle Zuordnungen einer Sammlung zu erhalten. Um ein bestimmtes Schriftsystem nachzuschlagen, rufen Sie [Fonts::GetScriptFont](https://reference.aspose.com/slides/de/cpp/aspose.slides/fonts/getscriptfont/) mit dessen Skript‑Tag auf. `GetScriptFont` liefert einen Null‑String, wenn die Sammlung die gewünschte Zuordnung nicht definiert.

## **Modify Mappings and Verify Persistence**

Verwenden Sie [Fonts::SetScriptFont](https://reference.aspose.com/slides/de/cpp/aspose.slides/fonts/setscriptfont/), um eine Zuordnung zu erstellen oder die aktuelle Schriftfamilie zu ersetzen. Verwenden Sie [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/de/cpp/aspose.slides/fonts/removescriptfont/), um eine Zuordnung zu entfernen.

Das folgende End‑to‑End‑Beispiel liest alle vorhandenen Haupt‑ und Neben‑Zuordnungen, sucht die japanische Hauptschrift, ändert die kyrillische Hauptschrift, entfernt die Thaana‑Neben‑Zuordnung, speichert die Präsentation und öffnet sie erneut, um beide Änderungen zu prüfen. Damit der Entfernungs‑Schritt unabhängig vom Ausgangsthema ist, erstellt das Beispiel zunächst nur dann eine Thaana‑Zuordnung, wenn noch keine definiert ist.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

Die Verifikation verwendet das gleiche Null‑String‑Verhalten wie ein regulärer Lookup: Nach dem Speichern der Entfernung gibt `GetScriptFont(u"Thaa")` einen Null‑String für die Neben‑Sammlung zurück.

## **Distinguish Theme Mappings from Other Font Settings**

Skript‑spezifische Theme‑Zuordnungen nehmen an der Schriftartauswahl teil, lösen jedoch ein anderes Problem als direkte Textformatierung, Substitution und Fallback:

| Mechanismus | Zweck | Auswirkung einer Änderung einer Theme‑Zuordnung |
|---|---|---|
| Skript‑spezifische Theme‑Schriftzuordnung | Wählt eine Haupt‑ oder Neben‑Theme‑Schrift für ein Schriftsystem. | Text, der weiterhin die entsprechende Theme‑Schrift verwendet, kann zur neuen zugeordneten Familie aufgelöst werden. |
| Schriftart, die einem Textabschnitt explizit zugewiesen ist | Fixiert die gewünschte Schriftfamilie für diesen Abschnitt, anstatt das Theme zu verwenden. | Der Abschnitt bleibt möglicherweise unverändert, weil die direkte Formatierung die Theme‑Auswahl überschreibt. |
| Schriftart‑Substitution | Ersetzt eine gewünschte Schrift, wenn diese nicht verfügbar ist oder eine Substitutionsregel greift. | Sie greift nach der Anforderung einer Schrift; sie definiert die Theme‑Skript‑Zuordnung nicht neu. |
| Schriftart‑Fallback | Liefert Glyphen, die die ausgewählte Schrift nicht enthält, häufig für bestimmte Unicode‑Bereiche. | Sie füllt fehlende Glyphen ab; sie ändert die gespeicherte Theme‑Zuordnung nicht. |

Weitere Informationen zu den letzten beiden Mechanismen finden Sie unter [Font Substitution](/slides/de/cpp/font-substitution/) und [Fallback Fonts](/slides/de/cpp/fallback-font/).

Das Ändern einer Zuordnung über [Presentation::get_MasterTheme](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_mastertheme/) wirkt sich nur auf Inhalte aus, deren effektive Formatierung noch von diesem Theme abhängt. Text kann stattdessen eine Theme‑Überschreibung von einem Master, Layout oder einer Folie erben oder eine explizit zugewiesene Schriftart verwenden. Prüfen Sie diese Ebenen, wenn das sichtbare Ergebnis nicht der Präsentations‑Theme‑Zuordnung folgt.

## **Make Mapped Fonts Available and Validate the Result**

Eine Skript‑Zuordnung speichert nur den Namen einer Schriftfamilie; sie installiert oder lädt die zugehörige Schriftdatei nicht. Für konsistentes Rendern und Export muss jede zugeordnete Schrift im System installiert oder Aspose.Slides über eine benutzerdefinierte Quelle wie [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/loadexternalfonts/) oder [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) bereitgestellt werden. Siehe [Custom Fonts](/slides/de/cpp/custom-font/) für die verfügbaren Ladeoptionen.

Die Überprüfung der gespeicherten Zuordnung bestätigt nur, dass die Theme‑Definition erhalten blieb. Sie beweist nicht, dass die Schrift verfügbar ist, alle benötigten Glyphen enthält oder das gewünschte Layout erzeugt. Rendern Sie repräsentativen Text für jedes erforderliche Schriftsystem zu einem Bild oder PDF und prüfen Sie die Ausgabe. So werden fehlende Schriften, unvollständige Glyphen‑Abdeckung, Fallback‑Verhalten und Layout‑Änderungen vor der Verteilung der Präsentation erkannt. Siehe [Convert PowerPoint Presentations](/slides/de/cpp/convert-powerpoint/) für Render‑ und Exportbeispiele.

## **FAQ**

**Was gibt `GetScriptFont` zurück, wenn ein Skript nicht zugeordnet ist?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/de/cpp/aspose.slides/fonts/getscriptfont/) liefert einen Null‑String, wenn die gewünschte Skript‑Zuordnung in dieser Haupt‑ oder Neben‑Schrift‑Sammlung nicht definiert ist.

**Fügt `SetScriptFont` eine zweite Zuordnung hinzu, wenn das Skript bereits existiert?**

Nein. [Fonts::SetScriptFont](https://reference.aspose.com/slides/de/cpp/aspose.slides/fonts/setscriptfont/) erstellt die Zuordnung, wenn sie fehlt, und ersetzt die zugeordnete Schriftfamilie, wenn derselbe Skript‑Tag bereits vorhanden ist.

**Warum hat das Ändern einer Theme‑Zuordnung nicht den Text geändert?**

Der Text kann eine explizit zugewiesene Schriftart besitzen, ein anderes Theme durch eine Überschreibung erben oder von Substitution bzw. Fallback während des Renderns betroffen sein. Eine Präsentations‑Ebene‑Skript‑Zuordnung steuert nur Text, dessen effektive Formatierung noch auf diese Theme‑Schrift‑Sammlung verweist.

**Reicht das Speichern und erneute Öffnen aus, um die mehrsprachige Ausgabe zu validieren?**

Nein. Das erneute Öffnen bestätigt lediglich die Persistenz der Theme‑Daten. Zusätzlich sollte repräsentativer Text aus jedem benötigten Schriftsystem gerendert werden, um sicherzustellen, dass die zugeordneten Schriften verfügbar sind und die notwendigen Glyphen enthalten.