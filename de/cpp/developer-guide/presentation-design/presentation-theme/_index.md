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
- Themenfarbe
- Zusätzliche Palette
- Themen-Schriftart
- Themenstil
- Themaeffekt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für C++, um PowerPoint-Dateien mit einheitlicher Markenidentität zu erstellen, anzupassen und zu konvertieren."
---
## **Einführung**

Ein Präsentationsthema definiert ein abgestimmtes Set aus Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Themen‑aware Objekte beziehen sich auf diese gemeinsam genutzten Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass eine Themenänderung viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das thema‑bezogene Design auf Präsentationsebene über [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_mastertheme/) verfügbar. Eine Präsentation kann außerdem Themen‑Overrides auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) überschreiben, während ein Layout oder eine einzelne Folie [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) verwenden kann. In der Praxis wird das effektive Thema einer Folie über diese Vererbungskette aufgelöst: Präsentationsthema, Master‑Override, Layout‑Override und Folien‑Override.

![Themenkomponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gebräuchlichsten Workflows für Themen: ein Thema untersuchen, Farben und Schriftarten ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Auflösung von Vererbung und Overrides lesen.

## **Thema untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/)‑Objekt stellt die Methoden [get_ColorScheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) und [get_FormatScheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) des Themas bereit. Das Durchsehen dieser Sammlungen, bevor Änderungen vorgenommen werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, weil die Anzahl und der Inhalt der Stileinträge variieren können.

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

Verwendet eine Datei mehrere Master, darf nicht davon ausgegangen werden, dass jede Folie das gleiche effektive Thema hat. Untersuchen Sie den Master, der der Folie zugeordnet ist, und verwenden Sie den später im Artikel gezeigten Workflow für effektive Themen, wenn Layout‑ oder Folien‑Overrides vorhanden sein können.

## **Themafarben ändern**

Themen‑aware Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag in der [IColorScheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/icolorscheme/)-Sammlung des Themas ändern, werden alle Objekte, die weiterhin auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch eine Themenfarb‑Aktualisierung nicht geändert.

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

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Themenänderung rot. Ersetzen Sie die Schema‑Farbe durch eine direkte Farbe im Shape, wirken spätere Änderungen an `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Themenfarbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über [ColorTransformOperation](https://reference.aspose.com/slides/de/cpp/aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und aus der zusätzlichen Palette erzeugte hellere und dunklere Farben](additional-palette-colors.png)

**1** – Hauptthemenfarben.  
**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt wurden.

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

### **`SchemeColor`‑Werte den `IColorScheme`‑Slots zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während [IColorScheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/icolorscheme/) dieselben Themenslots als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenslots; es handelt sich nicht um Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Thema‑Schriftarten ändern**

Ein Themen‑Schriftartenschema enthält ein Haupt‑Schriftset für Überschriften und ein Neben‑Schriftset für Fließtext. Die Methoden [FontScheme::get_Major()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/fontscheme/get_major/) und [FontScheme::get_Minor()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/fontscheme/get_minor/) stellen diese Sets bereit.

PowerPoint‑kompatible Themen‑Schriftarten‑Bezeichner können in der Textformatierung verwendet werden:

* `+mn‑lt` – Fließtext‑Schrift Latin (Minor Latin Font)
* `+mj‑lt` – Überschrift‑Schrift Latin (Major Latin Font)
* `+mn‑ea` – Fließtext‑Schrift East Asian (Minor East Asian Font)
* `+mj‑ea` – Überschrift‑Schrift East Asian (Major East Asian Font)

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

Die Überschrift verwendet die Haupt‑Latin‑Schrift des Themas, die Fließzeile verwendet die Neben‑Latin‑Schrift. Text, dem ein expliziter Schriftname anstelle eines Themen‑Bezeichners zugewiesen ist, wechselt nicht automatisch, wenn das Themen‑Schriftartenschema geändert wird.

Die Haupt‑ und Neben‑Schriftartensammlungen können zudem Schriftzuordnungen für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Weitere Informationen zu Präsentationsschriftarten finden Sie unter [PowerPoint Fonts](/slides/de/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Es gibt zwei gängige Workflows, die unterschiedliche Probleme lösen.

### **Quell‑Thema beim Verschieben von Folien erhalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und dabei das ursprüngliche Design bewahren, klonen Sie den Quell‑Master in die Zielpräsentation mit [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/addclone/), und klonen Sie anschließend die Folie mit [ISlideCollection::AddClone()](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) sowie den geklonten Master. Dadurch werden Master, Layouts und das zugehörige Thema zusammen übertragen.

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

Dies ist der empfohlene Workflow, wenn die Quell‑Folie im Ziel genau gleich aussehen soll. Das reine Kopieren von Inhalten auf einen nicht zugehörigen Ziel‑Master kann themen­getriebene Farben, Schriftarten, Hintergründe und Effekte verändern.

### **Themenwerte auf eine vorhandene Folie anwenden**

Muss die Ziel‑Folie auf ihrem aktuellen Master und Layout verbleiben, initialisieren Sie ein Folien‑Override aus dem Quell‑Thema. Die Methoden [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) und [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) kopieren die drei Hauptkomponenten des Themas in das Override.

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

Damit wird das Thema dieser Folie geändert, ohne das von anderen Folien geerbte Thema zu beeinflussen. Um das lokale Override zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme::Clear()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/clear/) auf.

### **Ein Themen‑Override auf ein Layout anwenden**

Ein Layout‑Override gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie kein eigenes Override besitzt. Die gleichen Initialisierungsmethoden können über das Layout‑[IOverrideThemeManager](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ioverridethememanager/) aufgerufen werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Basisdesign teilen sollen, ein Layout‑Override, wenn eine Layout‑Familie ein anderes Styling benötigt, und ein Folien‑Override nur für echte Ausnahmen. Übermäßige Folien‑Overrides erschweren die Vorhersagbarkeit späterer globaler Themenänderungen.

## **Hintergrundstile des Themas aktualisieren**

Die Hintergrund‑Füllungen des Themas werden in [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) gespeichert. PowerPoint kann in seiner Benutzeroberfläche mehr Hintergrundoptionen anbieten, als tatsächlich in dieser Sammlung definiert sind, weil die UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrundstil‑Galerie für ein Präsentationsthema](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, prüfen Sie die gespeicherte Sammlung und den aktuellen Wert von [Background::get_StyleIndex()](https://reference.aspose.com/slides/de/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` verwendet `0` für keine themenbezogene Füllung; positive Werte sind Referenzen auf Themen‑Hintergrundstile. Das unterscheidet sich vom direkten Indexieren einer C++‑Sammlung mit `idx_get(0)`, wobei `0` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl von Hintergrund‑Füllstilen enthält.

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

Das Ergebnis, das Sie sehen, hängt vom Themen‑Eintrag ab, auf den der Master verweist, sowie von etwaigen Hintergrund‑Overrides auf Layout‑ oder Folienebene. Verwendet eine Folie einen eigenen Hintergrund, wird eine reine Änderung des Master‑Hintergrunds diese Folie möglicherweise nicht beeinflussen. Nutzen Sie [Background::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/background/geteffective/), wenn Sie den finalen Hintergrund nach Anwendung der Vererbung kennen müssen.

{{% alert color="warning" title="Warning" %}}
Betrachten Sie `StyleIndex` nicht als nullbasierten Sammlungsindex. Vermeiden Sie zudem das Hard‑Coden einer Stil‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei gleich aussieht; Themenstil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/cpp/presentation-background/).
{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen für [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_linestyles/) und [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Typische Office‑Themen enthalten häufig drei Haupteinträge, die visuell subtil, moderat bzw. intensiv formatiert sind, aber Ihr Code sollte jede Sammlung inspizieren, anstatt von einer festen Anzahl auszugehen.

![Subtile, moderate und intensive Themen‑Effekte, die auf dasselbe Shape angewendet werden](presentation-design_10.png)

Greifen Sie in C++ auf diese Sammlungen zu, ist der Sammlungs‑Index nullbasiert: `idx_get(0)` liefert den ersten gespeicherten Stil, `idx_get(2)` den dritten. Die Indexe, die ein Shape zur Stilreferenz verwendet, sind ein separates Konzept und werden über [IShapeStyle](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapestyle/) bereitgestellt. Das Ändern eines Themen‑Stils wirkt sich auf alle Shapes aus, die diesen Stil referenzieren; Shapes mit direkter Formatierung bleiben unverändert.

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

Für Shapes, die diese Slots referenzieren, wird der erste Themen‑Linienstil rot, der dritte Themen‑Füllstil zuurchigendes Waldgrün und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Slots jedes Shape referenziert und ob direkte Formatierung das Thema überschreibt.

![Themen‑Effekt‑Stile nach Änderung von Linie, Füllung und Schatteneinstellungen](presentation-design_11.png)

## **Effektive Themenwerte lesen**

Roh‑Themenobjekte zeigen an, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder ein Shape tatsächlich verwendet, nachdem Vererbung und lokale Overrides aufgelöst wurden. Für eine Folie rufen Sie [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) auf. Für einen Hintergrund verwenden Sie [Background::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/background/geteffective/), und für eine Füllung [FillFormat::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/geteffective/).

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

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_mastertheme/) inspizieren, können Sie einen Master‑, Layout‑, Folien‑ oder Shape‑Override übersehen, der das endgültige Erscheinungsbild verändert.

## **FAQ**

**Kann ich ein Thema nur auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den Folien‑[IOverrideThemeManager](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ioverridethememanager/) und initialisieren Sie dessen Override‑Thema. Die Änderung bleibt lokal für diese Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Was ist der sicherste Weg, ein Thema von einer Präsentation zur anderen zu übertragen?**

Beim Verschieben einer Folie und dem Erhalt ihres Quell‑Designs klonen Sie den Quell‑Master in das Ziel und klonen die Folie mit diesem Master mittels [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/addclone/) und [ISlideCollection::AddClone()](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/). Dadurch bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) für ein Folien‑ oder Layout‑Thema und die entsprechenden effektiven‑Daten‑Methoden für Formatobjekte wie [Background::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/background/geteffective/) und [FillFormat::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/geteffective/). Diese APIs liefern die aufgelösten Werte nach Anwendung von Vererbung und Overrides.