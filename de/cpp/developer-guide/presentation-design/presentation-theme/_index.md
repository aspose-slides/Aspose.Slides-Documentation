---
title: Verwalten von Präsentationsthemen in C++
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
- Themenfarbe
- Zusätzliche Palette
- Themenschriftart
- Themenstil
- Themaeffekt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Master‑Präsentationsthemen in Aspose.Slides für C++, um PowerPoint‑Dateien mit konsistenter Markenführung zu erstellen, anzupassen und zu konvertieren."
---
## **Einleitung**

Ein Präsentationsthema definiert ein koordiniertes Set aus Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Themenbewusste Objekte verweisen auf diese gemeinsam genutzten Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass eine Themenänderung viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das Themen‑Level der Präsentation über [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_mastertheme/) verfügbar. Eine Präsentation kann außerdem Themen‑Überschreibungen auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) überschreiben, während ein Layout oder eine einzelne Folie [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) verwenden kann. In der Praxis wird das effektive Thema einer Folie über diese Vererbungskette aufgelöst: Präsentationsthema, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Themen‑Komponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die folgenden Abschnitte zeigen die gängigsten Arbeitsabläufe für Themen: ein Thema inspizieren, Farben und Schriftarten ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Vererbung und Überschreibungen lesen.

## **Ein Thema inspizieren**

Das [MasterTheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/)‑Objekt stellt die Methoden [get_ColorScheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) und [get_FormatScheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) des Themas zur Verfügung. Das Durchsuchen dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, weil Anzahl und Inhalt der Stileinträge variieren können.

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

Verwendet eine Datei mehrere Master, darf nicht angenommen werden, dass jede Folie das gleiche effektive Thema hat. Inspiziere den mit der Folie verknüpften Master und nutze den später im Artikel gezeigten Arbeitsablauf für effektive Themen, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Themen‑Farben ändern**

Themenbewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/schemecolor/) beziehen. Wenn du den entsprechenden Eintrag in der [IColorScheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/icolorscheme/)-Sammlung des Themas änderst, werden alle Objekte, die noch auf diese Themenfarbe verweisen, mit dem neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch eine Themenfarb‑Aktualisierung nicht geändert.

Das folgende End‑zu‑Ende‑Beispiel erstellt eine Form, die `Accent4` verwendet, ändert die `Accent4`‑Farbe des Themas zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die effektive Füllfarbe aus:

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

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Themenänderung Rot. Wenn du die Schema‑Farbe durch eine direkte Farbe auf der Form ersetzt, wirken spätere Änderungen an `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint erzeugt aus einer Themenfarbe hellere und dunklere Varianten mittels Farbtransformationen. Aspose.Slides stellt diese Transformationen über [ColorTransformOperation](https://reference.aspose.com/slides/de/cpp/aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und hellere sowie dunklere Farben, die aus der zusätzlichen Palette generiert wurden](additional-palette-colors.png)

**1** – Hauptthemenfarben.  
**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt wurden.

Das folgende Beispiel erstellt sechs Rechtecke, die auf `Accent4` basieren, wendet auf fünf von ihnen Luminanz‑Transformationen an und speichert das Ergebnis:

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

Diese Varianten bleiben an der Themenfarbe ausgerichtet. Wenn `Accent4` später geändert wird, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `IColorScheme`‑Plätzen zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während [IColorScheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/icolorscheme/) dieselben Themenplätze als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenplätze; sie sind keine Werte, die dynamisch von einer Form zur anderen konvertiert werden.

## **Themen‑Schriftarten ändern**

Ein Themen‑Schriftartenschema enthält einen Hauptschriftartensatz für Überschriften und einen Nebenschriftartensatz für Fließtext. Die Methoden [FontScheme::get_Major()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/fontscheme/get_major/) und [FontScheme::get_Minor()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/fontscheme/get_minor/) geben diese Sätze zurück.

PowerPoint‑kompatible Themen‑Schriftartkennungen können in der Textformatierung verwendet werden:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Schriftart des Themas verwendet, und eine Textzeile, die die Neben‑Latin‑Schriftart nutzt. Anschließend werden die Themen‑Schriftarten geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Hauptschriftart und der Fließtext der Neben­schriftart. Text, dem ein expliziter Schriftartname anstelle einer Themen‑Kennung zugewiesen wurde, wechselt nicht automatisch, wenn das Themen‑Schriftartenschema geändert wird.

{{% alert color="info" title="Hinweis" %}}
Weitere Informationen zu Präsentations‑Schriftarten finden Sie unter [PowerPoint Fonts](/slides/de/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Es gibt zwei gängige Arbeitsabläufe, die unterschiedliche Probleme lösen.

### **Quell‑Thema beim Verschieben von Folien beibehalten**

Wenn Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design behalten möchten, klonen Sie den Quell‑Master in die Zielpräsentation mit [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/addclone/), und klonen Sie anschließend die Folie mit [ISlideCollection::AddClone()](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) und dem geklonten Master. Dadurch werden Master, Layouts und das zugehörige Thema gemeinsam übertragen.

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

Dies ist der bevorzugte Arbeitsablauf, wenn die Quell‑Folie im Ziel exakt gleich aussehen soll. Das reine Klonen von Inhalten auf einen nicht zugehörigen Ziel‑Master kann themen‑abhängige Farben, Schriftarten, Hintergründe und Effekte ändern.

### **Themen‑Werte auf eine vorhandene Folie anwenden**

Muss die Ziel‑Folie auf ihrem aktuellen Master und Layout bleiben, initialisieren Sie eine Folien‑Überschreibung aus dem Quell‑Thema. Die Methoden [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) und [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) kopieren die drei Hauptkomponenten des Themas in die Überschreibung.

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

Damit wird das von dieser Folie genutzte Thema geändert, ohne das von anderen Folien geerbte Thema zu beeinflussen. Um die lokale Überschreibung zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme::Clear()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/clear/) auf.

### **Eine Themen‑Überschreibung auf ein Layout anwenden**

Eine Layout‑Überschreibung gilt für alle Folien, die dieses Layout verwenden, es sei denn, eine bestimmte Folie hat ihre eigene Überschreibung. Die gleichen Initialisierungsmethoden können über das [IOverrideThemeManager](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ioverridethememanager/) des Layouts verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Grunddesign teilen sollen, eine Layout‑Überschreibung, wenn eine Layout‑Familie ein anderes Styling benötigt, und eine Folien‑Überschreibung nur für echte Ausnahmen. Übermäßige Folien‑Überschreibungen erschweren die Vorhersagbarkeit späterer globaler Themenänderungen.

## **Themen‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themas werden in [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) gespeichert. PowerPoint kann in seiner Benutzeroberfläche mehr Hintergrund‑Optionen anzeigen, als in dieser Sammlung physisch definiert sind, weil die UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrundstil‑Galerie für ein Präsentationsthema](presentation-design_8.png)

Bevor ein Hintergrundstil verwendet wird, prüfen Sie die gespeicherte Sammlung und den aktuellen Wert von [Background::get_StyleIndex()](https://reference.aspose.com/slides/de/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` verwendet `0` für keine themenbasierte Füllung; positive Werte verweisen auf Themen‑Hintergrund‑Stil‑Referenzen. Das unterscheidet sich vom Indexieren einer C++‑Sammlung mit `idx_get(0)`, wo `0` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl von Hintergrund‑Füllstilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl von Hintergrund‑Füllungen aus, weist dem ersten Master eine themenbasierte Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom vom Master referenzierten Themaintrag sowie von etwaigen Hintergrund‑Überschreibungen auf Layout‑ oder Folien‑Ebene ab. Wenn eine Folie einen eigenen Hintergrund verwendet, ändert das reine Ändern des Master‑Hintergrunds diese Folie nicht. Verwenden Sie [Background::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/background/geteffective/), wenn Sie den endgültigen Hintergrund nach angewandter Vererbung ermitteln müssen.

{{% alert color="warning" title="Warnung" %}}
Behandeln Sie `StyleIndex` nicht als nullbasierten Sammlungsindex. Vermeiden Sie außerdem das harte Kodieren einer Stil‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei das gleiche Aussehen hat; Themen‑Stil‑Definitionen sind präsentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Hinweis" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/cpp/presentation-background/).
{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen für [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_linestyles/) und [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Typische Office‑Themen enthalten oft drei Haupteinträge, die visuell subtilen, moderaten und intensiven Formatierungen entsprechen, aber der Code sollte jede Sammlung prüfen, anstatt von einer festen Anzahl auszugehen.

![Subtile, moderate und intensive Themen‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Wenn Sie in C++ auf diese Sammlungen zugreifen, ist der Index nullbasiert: `idx_get(0)` ist der erste gespeicherte Stil und `idx_get(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form bilden ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Themen‑Stils wirkt sich auf Formen aus, die diesen Stil referenzieren; Formen mit direkter Formatierung können unverändert bleiben.

Das folgende Beispiel prüft, ob die erforderlichen Stileinträge existieren, ändert den ersten Linienstil, den dritten Füllstil, aktiviert einen äußeren Schatten im dritten Effektstil und speichert das Ergebnis:

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

Für Formen, die diese Plätze referenzieren, wird der erste Themen‑Linienstil rot, der dritte Themen‑Füllstil zu einem satten Waldgrün und der dritte Effektstil erhält einen äußeren Schatten mit einer Distanz von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Plätze jede Form referenziert und ob direkte Formatierung die Themenwerte überschreibt.

![Themen‑Effektstile nach Änderung von Linie, Füllung und Schatteneinstellungen](presentation-design_11.png)

## **Effektive Themen‑Werte lesen**

Roh‑Themen‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich verwendet, nachdem Vererbung und lokale Überschreibungen aufgelöst wurden. Für eine Folie rufen Sie [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) auf. Für einen Hintergrund verwenden Sie [Background::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/background/geteffective/), und für eine Füllung [FillFormat::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/geteffective/).

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

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_mastertheme/) inspizieren, können Sie eine Master‑, Layout‑, Folien‑ oder Form‑Überschreibung übersehen, die das endgültige Erscheinungsbild ändert.

## **FAQ**

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie das [IOverrideThemeManager](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ioverridethememanager/) der Folie und initialisieren Sie dessen Überschreibungsthema. Die Änderung bleibt lokal auf dieser Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Was ist der sicherste Weg, ein Thema von einer Präsentation in eine andere zu übernehmen?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Aussehen bewahren wollen, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mittels [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/addclone/) und [ISlideCollection::AddClone()](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/). Dadurch bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Überschreibungen sehen?**

Verwenden Sie [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) für das Folien‑ oder Layout‑Thema und die entsprechenden effektiven‑Daten‑Methoden für Format‑Objekte wie [Background::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/background/geteffective/) und [FillFormat::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/geteffective/). Diese APIs liefern die aufgelösten Werte nach Anwendung von Vererbung und Überschreibungen.