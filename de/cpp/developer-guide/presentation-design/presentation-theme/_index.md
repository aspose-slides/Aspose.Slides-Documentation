---
title: Präsentationsthemen in C++ verwalten
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/cpp/presentation-theme/
keywords:
- PowerPoint-Thema
- Präsentationsthema
- Folienthema
- Thema festlegen
- Thema ändern
- Thema verwalten
- externes Thema
- THMX
- Themenfarbe
- zusätzliche Palette
- Themenschrift
- Themenstil
- Themeneffekt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für C++ zum Erstellen, Anpassen und Konvertieren von PowerPoint-Dateien mit konsistenter Markenidentität."
---
## **Einführung**

Ein Präsentationsthema definiert ein koordiniertes Set von Farben, Schriften, Hintergrundstilen, Füllungen, Linien und Effekten. Themenbewusste Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass eine Themenänderung viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das Präsentation‑Thema über [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/) verfügbar. Eine Präsentation kann außerdem Themen‑Überschreibungen auf tieferen Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) überschreiben, während ein Layout oder eine einzelne Folie [IOverrideThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) verwendet. In der Praxis wird das effektive Thema für eine Folie über diese Vererbungskette aufgelöst: Präsentationsthema, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Themenkomponenten: Farben, Schriften, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gebräuchlichsten Themen‑Workflows: ein Thema untersuchen, Farben und Schriften ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Auflösung von Vererbung und Überschreibungen auslesen.

## **Ein Thema untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/)‑Objekt stellt die Methoden [get_ColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) und [get_FormatScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) des Themas bereit. Das Untersuchen dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themas und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Thema gespeichert sind:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

Wenn eine Datei mehrere Master verwendet, darf man nicht davon ausgehen, dass jede Folie dasselbe effektive Thema hat. Untersuchen Sie den Master, der der Folie zugeordnet ist, und verwenden Sie den effektiven‑Thema‑Workflow, der später in diesem Artikel gezeigt wird, wenn Layout‑ oder Folien‑Overrides vorhanden sein können.

## **Themenfarben ändern**

Themen‑bewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag in dem [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) des Themas ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Update der Themenfarbe nicht geändert.

Das folgende End‑to‑End‑Beispiel erstellt eine Form, die `Accent4` verwendet, ändert die Themenfarbe `Accent4` zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die effektive Füllfarbe aus:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Themenänderung Rot. Wenn Sie die Schemafarben auf der Form durch eine direkte Farbe ersetzen, wirken spätere Änderungen an `Accent4` sich nicht mehr auf diese Füllung aus.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Themenfarbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über [ColorTransformOperation](https://reference.aspose.com/slides/cpp/aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und aus der zusätzlichen Palette erzeugte hellere und dunklere Farben](additional-palette-colors.png)

**1** – Hauptthemenfarben.

**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt werden.

Das folgende Beispiel erstellt sechs Rechtecke basierend auf `Accent4`, wendet Luminanz‑Transformationen auf fünf davon an und speichert das Ergebnis:

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

Diese Varianten bleiben auf der Themenfarbe basierend. Ändert sich `Accent4` später, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **Mapping von `SchemeColor`‑Werten zu `IColorScheme`‑Slots**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) dieselben Themenslots als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Das Mapping ist festgelegt:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenslots; sie sind keine Werte, die dynamisch von einer Form in eine andere konvertiert werden.

## **Themenschriften ändern**

Ein Themen‑Schrift‑Schema enthält einen Hauptschrift‑Satz für Überschriften und einen Neben‑Schrift‑Satz für Fließtext. Die Methoden [FontScheme::get_Major](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_major/) und [FontScheme::get_Minor](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_minor/) stellen diese Sätze bereit.

PowerPoint‑kompatible Themen‑Schrift‑Bezeichner können in der Textformatierung verwendet werden:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)
* `+mn-cs` – Body Font Complex Script (Minor Complex Script Font)
* `+mj-cs` – Heading Font Complex Script (Major Complex Script Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latein‑Schrift des Themas verwendet, und eine Textzeile, die die Neben‑Latein‑Schrift verwendet. Anschließend werden die Themen­schriften geändert und das Ergebnis gespeichert:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

Die Überschrift folgt der Hauptschrift und der Fließtext der Nebenschrift. Text, dem ein expliziter Schriftname anstelle eines Themen‑Bezeichners zugewiesen ist, wechselt nicht automatisch, wenn das Themen‑Schrift‑Schema geändert wird.

Der Haupt‑ und der Neben‑Schrift‑Sammlung können ebenfalls Schrift‑Mappings für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Mappings siehe [Script‑Specific Theme Fonts](/slides/de/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Weitere Informationen zu Präsentations­schriften finden Sie unter [PowerPoint Fonts](/slides/de/cpp/powerpoint-fonts/).
{{% /alert %}}

### **Theme‑Schrift‑Referenzen auflösen**

Beim Untersuchen von Text kann [IFontData::get_FontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/get_fontname/) einen Themen‑Verweis wie `+mn-lt` anstelle eines Schriftfamiliennamens enthalten. Rufen Sie [IFontData::GetFontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/getfontname/) zusammen mit dem passenden [IThemeEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeeffectivedata/) auf, um diesen Verweis aufzulösen. Die Präfixe `+mj` und `+mn` wählen den Haupt‑ bzw. Neben‑Schrift‑Satz; die Suffixe `-lt`, `-ea` und `-cs` wählen deren Latein‑, Ostasiatisch‑ bzw. Komplex‑Skript‑Schriften.

Ermitteln Sie das effektive Thema über [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) auf dem Objekt, dessen Thema für den zu untersuchenden Text gilt. Für normalen Text auf einer Folie verwenden Sie `slide->CreateThemeEffective()`, sodass der Kontext das geerbte Thema der Folie und lokale Overrides einschließt. Beim Untersuchen eines Layouts oder Masters verwenden Sie dessen eigenes effektives Thema. Gehen Sie nicht davon aus, dass das Thema des ersten Masters für jede Folie gilt.

Das folgende Beispiel erstellt einen Textabschnitt, der explizit die Neben‑Latein‑Schrift referenziert. Es initialisiert das Folien‑Schrift‑Schema über [IOverrideTheme::InitFontSchemeFromInherited](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) und setzt die Haupt‑ und Neben‑Latein‑Familien auf `Arial` bzw. `Calibri`, wodurch das Ergebnis reproduzierbar ist, ohne eine Eingabedatei zu benötigen.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto theme = slide->get_ThemeManager()->get_OverrideTheme();
theme->InitFontSchemeFromInherited();
theme->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Arial"));
theme->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Calibri"));

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 60.0f);
shape->get_TextFrame()->set_Text(u"Text using the minor theme font");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

auto font = portion->get_PortionFormat()->get_LatinFont();
auto effectiveTheme = slide->CreateThemeEffective();
auto resolvedFontName = font->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", font->get_FontName(), resolvedFontName);

auto explicitFont = MakeObject<FontData>(u"Verdana");
auto explicitFontName = explicitFont->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", explicitFont->get_FontName(), explicitFontName);
```

Die Ausgabe ist `+mn-lt -> Calibri` gefolgt von `Verdana -> Verdana`. Die gespeicherte Referenz bleibt unverändert, während ein expliziter Familienname unverändert zurückgegeben wird. Verwendete der Abschnitt `+mj-lt`, würde er in diesem Thema zu `Arial` aufgelöst.

Das Auflösen einer Themen‑Referenz ermittelt die durch das Thema angegebene Schriftfamilie. Es wird nicht geprüft, ob die Schrift verfügbar ist oder welche Schriftdatei letztlich nach Substitution oder Glyph‑Fallback beim Rendern verwendet wird. Siehe [Font Selection Sequence](/slides/de/cpp/font-selection-sequence/) und [Font Substitution](/slides/de/cpp/font-substitution/) für diese separaten Schritte.

## **Ein Thema kopieren oder anwenden**

Die nachfolgenden Workflows lösen verschiedene themenbezogene Probleme.

### **Externes Thema auf Folien anwenden, die von einem Master abhängen**

Verwenden Sie [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/), wenn Sie eine PowerPoint‑Themedatei (`.thmx`) besitzen und jedes von einem bestimmten Master abhängige Folien‑Design neu gestalten möchten. Wählen Sie den Master aus der [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/)‑Sammlung, die [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/) implementiert, und übergeben Sie den Pfad zur Themedatei an die Methode.

Die Methode führt folgende Schritte aus:

1. Erstellt eine neue Master‑Folien‑Instanz basierend auf dem ausgewählten Master.
1. Wendet das externe Thema auf den neuen Master an.
1. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhingen.
1. Gibt das neu erstellte [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/) zurück.

Das folgende Beispiel wendet ein externes Thema auf die Folien an, die vom ersten Master abhängen, und speichert die Präsentation:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);

auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");
Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());

presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

Ein ungültiges, beschädigtes oder nicht unterstütztes Thema kann eine [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) oder eine ihrer formatbezogenen Unterklassen auslösen. Validieren Sie von Benutzern bereitgestellte Pfade, behandeln Sie Zugriffsfehler auf das Dateisystem und speichern Sie die Präsentation erst, nachdem das Thema erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugewiesen. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Themen. Themen‑bewusste Farben, Schriften, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Thema aufgelöst. Direkt zugewiesene Farben, Schriften, Füllungen und andere explizite Formatierungen können unverändert bleiben. Overrides auf Layout‑ und Folien‑Ebene können ebenfalls Vorrang vor Werten haben, die vom neuen Master geerbt wurden.

Das Thema kann Schriften referenzieren, die in der Laufzeitumgebung nicht verfügbar sind. Für konsistentes Rendern und Export installieren Sie die erforderlichen Schriften, stellen sie über [custom font sources](/slides/de/cpp/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/cpp/font-substitution/).

Dies ist ein direkter Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert kein manuelles Erzeugen von Folien‑ oder Layout‑Overrides.

### **Verschiedene externe Themen in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master nicht im Voraus bekannt ist, ermitteln Sie ihn über eine repräsentative Folie mittels [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) und [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_masterslide/). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themen anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, um deren Master zu ermitteln, und wendet jedem Gruppe ein anderes externes Thema an:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());

        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

Der erste Aufruf wirkt nur auf Folien, die vom `firstGroupMaster` abhingen, der zweite Aufruf nur auf Folien, die vom `secondGroupMaster` abhingen. Folien, die zu anderen Mastern gehören, werden nicht neu gestaltet.

### **Quell‑Thema beim Verschieben von Folien beibehalten**

Wenn Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design bewahren wollen, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/), dann klonen Sie die Folie mit [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) und dem geklonten Master. Dadurch werden Master, seine Layouts und das zugehörige Thema zusammen transportiert.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");

auto sourceSlide = source->get_Slide(0);

auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);

target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen muss. Das reine Kopieren von Inhalten auf einen nicht verwandten Ziel‑Master kann themenbasierte Farben, Schriften, Hintergründe und Effekte ändern.

### **Themenwerte auf eine vorhandene Folie anwenden**

Wenn die Ziel‑Folie auf ihrem aktuellen Master und Layout verbleiben soll, initialisieren Sie ein Folien‑Override aus dem Quell‑Thema. Die Methoden [OverrideTheme::InitColorSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) und [OverrideTheme::InitFormatSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) kopieren die drei Haupt‑Themenkomponenten in das Override.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);

auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());

target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

Damit wird das Thema dieser Folie geändert, ohne das von anderen Folien geerbte Thema zu beeinflussen. Um das lokale Override zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/clear/) auf.

### **Ein Themen‑Override auf ein Layout anwenden**

Ein Layout‑Override gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie kein eigenes Override besitzt. Die gleichen Initialisierungsmethoden können über das Layout‑[IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) verwendet werden:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);

auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());

target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Basiskonzept teilen sollen, ein Layout‑Override, wenn eine Layout‑Familie ein anderes Styling benötigt, und ein Folien‑Override nur für wahre Ausnahmefälle. Übermäßige Folien‑Overrides erschweren spätere globale Themenänderungen.

## **Theme‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themas werden in [FormatScheme::get_BackgroundFillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) gespeichert. PowerPoint kann in seiner Benutzeroberfläche mehr Hintergrund‑Optionen präsentieren, als die Anzahl der physisch in dieser Sammlung gespeicherten Fülldefinitionen, weil die UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrund‑Galerie für ein Präsentationsthema](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, untersuchen Sie die gespeicherte Sammlung und das aktuelle [Background::get_StyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` verwendet `0` für keine themenbasierte Füllung; positive Werte sind Referenzen auf Themen‑Hintergrund‑Stile. Das unterscheidet sich vom Indexieren einer C++‑Sammlung mit `idx_get(0)`, wobei `0` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl an Hintergrund‑Füllstilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl von Hintergrund‑Füllungen aus, ordnet dem ersten Master eine themenbasierte Hintergrund‑Referenz zu und speichert die Präsentation:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);

    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

Das sichtbare Ergebnis hängt vom im Master referenzierten Themaintrag und etwaigen Hintergrund‑Overrides auf Layout‑ oder Folien‑Ebene ab. Verwendet eine Folie ihren eigenen Hintergrund, kann das reine Ändern des Master‑Hintergrunds diese Folie unbeeinflusst lassen. Nutzen Sie [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/), wenn Sie den finalen Hintergrund nach Anwendung der Vererbung ermitteln müssen.

{{% alert color="warning" title="Warning" %}}
Behandeln Sie `StyleIndex` nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem das Hard‑Coden einer Stil‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei identisch aussieht; Themen‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Für direkte Hintergrund‑Formatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/cpp/presentation-background/).
{{% /alert %}}

## **Theme‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen für [FormatScheme::get_FillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_linestyles/) und [FormatScheme::get_EffectStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Typische Office‑Themen enthalten häufig drei Haupt‑Stileinträge, die visuell subtil, moderat und intensiv formatiert sind, aber Code sollte jede Sammlung untersuchen, anstatt eine feste Anzahl anzunehmen.

![Subtile, moderate und intensive Themen‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Wenn Sie diese Sammlungen in C++ ansprechen, ist der Index nullbasiert: `idx_get(0)` ist der erste gespeicherte Stil und `idx_get(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Themen‑Stils wirkt sich auf Formen aus, die diesen Themen‑Stil referenzieren; Formen mit direkter Formatierung können unverändert bleiben.

Das folgende Beispiel prüft, ob die erforderlichen Stileinträge vorhanden sind, ändert den ersten Linien‑Stil, den dritten Füll‑Stil, aktiviert einen äußeren Schatten im dritten Effekt‑Stil und speichert das Ergebnis:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

Für Formen, die diese Slots referenzieren, wird der erste Themen‑Linienstil Rot, der dritte Themen‑Füllstil zu Voll‑Waldgrün und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einer Distanz von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Slots jede Form referenziert und ob direkte Formatierung das Thema überschreibt.

![Themen‑Effekt‑Stile nach Änderung von Linie, Füllung und Schatten‑Einstellungen](presentation-design_11.png)

## **Füll‑ und Linienstile eines Themas für eine Form auswählen**

Eine Form kann ihre Füllung und Kontur unabhängig über [IShapeStyle::set_FillStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_fillstyleindex/) bzw. [IShapeStyle::set_LineStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_linestyleindex/) auswählen. Für beide Setter wählt der Index `1` den ersten Eintrag in der jeweiligen Themen‑Sammlung (`idx_get(0)`), und Index `2` wählt den zweiten Eintrag.

Das folgende Beispiel richtet zwei Füll‑Stile (Gold und Himmelblau) und zwei Linien‑Stile (dunkelblau bei 6 pt und dunkelrot bei 12 pt) im Standard‑Thema einer neuen Präsentation ein. Es speichert die Folie in drei Stufen, sodass Sie die Ergebnisse in PowerPoint vergleichen können.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeStyle.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto styles = presentation->get_MasterTheme()->get_FormatScheme();

auto goldFill = styles->get_FillStyles()->idx_get(0);
goldFill->set_FillType(FillType::Solid);
goldFill->get_SolidFillColor()->set_Color(Color::get_Gold());
auto blueFill = styles->get_FillStyles()->idx_get(1);
blueFill->set_FillType(FillType::Solid);
blueFill->get_SolidFillColor()->set_Color(Color::get_SkyBlue());

auto thinLine = styles->get_LineStyles()->idx_get(0);
thinLine->get_FillFormat()->set_FillType(FillType::Solid);
thinLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
thinLine->set_Width(6.0);
auto thickLine = styles->get_LineStyles()->idx_get(1);
thickLine->get_FillFormat()->set_FillType(FillType::Solid);
thickLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkRed());
thickLine->set_Width(12.0);

auto shapes = presentation->get_Slide(0)->get_Shapes();
auto left = shapes->AddAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
auto right = shapes->AddAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
auto leftStyle = left->get_ShapeStyle();
auto rightStyle = right->get_ShapeStyle();
leftStyle->set_FillStyleIndex(1);
rightStyle->set_FillStyleIndex(2);
leftStyle->set_LineStyleIndex(1);
rightStyle->set_LineStyleIndex(1);
presentation->Save(u"01-initial.pptx", SaveFormat::Pptx);

rightStyle->set_LineStyleIndex(2);
presentation->Save(u"02-line-changed.pptx", SaveFormat::Pptx);

goldFill->get_SolidFillColor()->set_Color(Color::get_SeaGreen());
presentation->Save(u"03-theme-changed.pptx", SaveFormat::Pptx);
```

| Initiale Stile | Ändere den rechten Umriss | Erste Themen‑Füllung bearbeiten |
|:---:|:---:|:---:|
| ![Goldene und himmelblaue Rechtecke mit passenden dünnen dunkelblauen Konturen](theme-style-initial.png) | ![Das himmelblaue Rechteck hat jetzt einen dicken dunkelroten Umriss](theme-style-line-changed.png) | ![Das linke Rechteck ist jetzt grün und beide Umrisse bleiben unverändert](theme-style-fill-changed.png) |

Das Auswählen eines anderen Linien‑Stils ändert nur den Umriss des rechten Rechtecks. Das Bearbeiten der ersten Themen‑Füllung aktualisiert jede Form, die sie verwendet. Hier wird nur das linke Rechteck grün.

Auf einer bestehenden Form kann eine lokale Füll‑, Linien‑ oder Linienstärken‑Farbe das entsprechende Themen‑Stil‑Element überschreiben. Wenn das Ändern eines Stil‑Indexes keine sichtbare Wirkung zeigt, prüfen Sie die [direkte Formatierung](/slides/de/cpp/shape-formatting/) der Form.

## **Ermitteln, ob eine effektive Vollfüllung eine Themenfarbe verwendet**

Eine Füllung kann direkt auf einem Objekt gespeichert oder von einem Absatz, Layout, Master, Themen‑Stil oder einer anderen Formatierungsebene geerbt werden. Rufen Sie [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/) auf, um diese Hierarchie in ein unveränderliches [IFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/) aufzulösen. Prüfen Sie zuerst [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Nur wenn sie `FillType::Solid` ist, sollten Sie die Eigenschaften einer Vollfüllung auslesen.

Für eine Vollfüllung liefert [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) den finalen gerenderten RGB‑Wert nach Vererbung, Themen‑Lookup und Farb‑Transformationen. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) gibt das zugehörige logische [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/)‑Slot zurück, z. B. `Text1` oder `Accent6`. Der Wert `SchemeColor::NotDefined` bedeutet, dass die effektive Vollfüllung nicht auf einer Schemafarben basiert. In einem Workflow, bei dem Füllungen entweder Themen‑Farben oder direkte RGB‑Farben sind, identifiziert dieser Wert eine direkte RGB‑Füllung.

Verwenden Sie nicht ausschließlich den lokalen [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_schemecolor/)‑Wert, um eine Füllung zu klassifizieren. Beispielsweise kann ein Textabschnitt keine lokal definierte Schemafarben besitzen, sodass sein lokaler Wert `NotDefined` ist, während seine effektive Füllung eine Themenfarbe erbt und zu `Text1` oder `Accent6` aufgelöst wird. Andererseits gibt `get_SolidFillSchemeColor` an, welches logische Themen‑Slot die effektive Farbe erzeugt hat, sagt jedoch nichts darüber aus, ob dieses Slot vom Objekt, Absatz, Layout, Master oder einer anderen Ebene stammt.

Das folgende Beispiel lädt eine Präsentation, prüft sowohl Form‑Füllungen als auch Text‑Abschnitt‑Füllungen, gibt jeden finalen RGB‑Wert und das zugehörige Schemecolor aus und markiert Vollfüllungen, die nicht auf Themenfarben reagieren:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

Der Zweig `NotDefined` liefert eine Prüfliste von Vollfüllungen, die nicht auf Änderungen in Themen‑Farbslots reagieren. Überprüfen Sie diese Objekte, wenn eine Präsentation einer neuen Marken‑Palette folgen muss. Der gemeldete RGB‑Wert zeigt weiterhin das aktuelle Aussehen, während der Schemecolor‑Wert erklärt, ob dieses Aussehen mit dem Thema verbunden ist.

Effekt‑Objekte sind Schnappschüsse. Nach einer Themen‑Änderung, einem Themen‑Override oder einer anderen geerbten Formatierung rufen Sie `GetEffective` erneut auf und lesen ein neues `IFillFormatEffectiveData`‑Objekt, bevor Sie Farben vergleichen oder berichten.

## **Effektive Themenwerte auslesen**

Roh‑Themen‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich verwendet, nachdem Vererbung und lokale Overrides aufgelöst wurden. Für eine Folie rufen Sie [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) auf. Für einen Hintergrund verwenden Sie [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/), und für eine Füllung [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/).

Das folgende Beispiel liest das effektive Thema, den Hintergrund und die erste Form‑Füllung einer Folie:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/) untersuchen, können Sie einen Master-, Layout‑, Folien‑ oder Form‑Override übersehen, der das finale Aussehen ändert.

## **FAQ**

**Wirkt das Anwenden eines externen Themas auf jede Folie der Präsentation?**

Nein. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) weist nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master benutzen, behalten ihre bestehenden Themen.

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) der Folie und initialisieren Sie deren Override‑Thema. Die Änderung bleibt lokal auf dieser Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Wie übertrage ich ein Thema am sichersten von einer Präsentation in eine andere?**

Wenn Sie eine Folie verschieben und ihr Ausgangs‑Design bewahren wollen, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mittels [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/) und [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/). Dadurch bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) für ein Folien‑ oder Layout‑Thema und die entsprechenden Effective‑Data‑Methoden für Format‑Objekte wie [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) und [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/). Diese APIs geben die aufgelösten Werte nach Anwendung von Vererbung und Overrides zurück.