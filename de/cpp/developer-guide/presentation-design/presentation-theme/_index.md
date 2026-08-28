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
- Externes Thema
- THMX
- Themenfarbe
- Zusätzliche Palette
- Themen-Schriftart
- Themenstil
- Themeneffekt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für C++, um PowerPoint-Dateien mit einheitlichem Branding zu erstellen, anzupassen und zu konvertieren."
---
## **Einführung**

Ein Präsentationsthema definiert ein koordiniertes Set aus Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Themen‑aware Objekte verweisen auf diese geteilten Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Themenwechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das präsentationsweite Thema über [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_mastertheme/) verfügbar. Eine Präsentation kann außerdem Themen‑Overrides auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) überschreiben, während ein Layout oder eine einzelne Folie [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) verwenden kann. In der Praxis wird das effektive Thema einer Folie über diese Vererbungskette bestimmt: Präsentationsthema, Master‑Override, Layout‑Override und Folien‑Override.

![Theme-Komponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gebräuchlichsten Themen‑Workflows: ein Thema inspizieren, Farben und Schriftarten ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Vererbung und Overrides auslesen.

## **Ein Thema inspizieren**

Das [MasterTheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/)‑Objekt stellt die Methoden [get_ColorScheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) und [get_FormatScheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) des Themas bereit. Das Inspizieren dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stileinträge variieren können.

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

Verwenden Sie bei Dateien mit mehreren Mastern nicht die Annahme, dass jede Folie dasselbe effektive Thema hat. Inspizieren Sie den Master, der zur Folie gehört, und nutzen Sie den später in diesem Artikel gezeigten effektiven‑Themen‑Workflow, wenn Layout‑ oder Folien‑Overrides vorhanden sein können.

## **Themenfarben ändern**

Themen‑aware Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag in der [IColorScheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/icolorscheme/) des Themas ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Update der Themenfarbe nicht geändert.

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

Da das Rechteck mit `Accent4` verknüpft bleibt, wird seine sichtbare Farbe nach der Themenänderung Rot. Wenn Sie die Schema‑Farbe durch eine direkte Farbe auf der Form ersetzen, wirken spätere Änderungen an `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint erzeugt hellere und dunklere Varianten einer Themenfarbe, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über [ColorTransformOperation](https://reference.aspose.com/slides/de/cpp/aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und hellere sowie dunklere Farben, die aus der zusätzlichen Palette erzeugt wurden](additional-palette-colors.png)

**1** – Hauptthemenfarben.  
**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt wurden.

Das folgende Beispiel erstellt sechs Rechtecke auf Basis von `Accent4`, wendet Luminanz‑Transformationen auf fünf davon an und speichert das Ergebnis:

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

Diese Varianten bleiben an der Themenfarbe ausgerichtet. Ändert sich `Accent4` später, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `IColorScheme`‑Plätzen zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während [IColorScheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/icolorscheme/) dieselben Themenslots als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenslots; sie sind keine Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Themen‑Schriftarten ändern**

Ein Themen‑Schriftartenschema enthält einen Hauptschriftatz für Überschriften und einen Nebenschriftatz für Fließtext. Die Methoden [FontScheme::get_Major()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/fontscheme/get_major/) und [FontScheme::get_Minor()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/fontscheme/get_minor/) geben diese Sätze zurück.

PowerPoint‑kompatible Theme‑Schriftart‑Kennungen können in der Textformatierung verwendet werden:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Themen‑Schriftart verwendet, und eine Textzeile, die die Neben‑Latin‑Themen‑Schriftart verwendet. Anschließend werden die Themen‑Schriftarten geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Hauptschriftart und der Fließtext folgt der Nebenschriftart. Text, der einen expliziten Schriftartnamen anstelle einer Themen‑Kennung enthält, wechselt nicht automatisch, wenn das Themen‑Schriftartenschema geändert wird.

Die Haupt‑ und Nebenschriftart‑Sammlungen können zudem Schriftzuordnungen für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Inspizieren, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Weitere Informationen zu Präsentations‑Schriftarten finden Sie unter [PowerPoint Fonts](/slides/de/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Die nachfolgenden Workflows lösen unterschiedliche themenbezogene Probleme.

### **Ein externes Thema auf master‑abhängige Folien anwenden**

Verwenden Sie [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/), wenn Sie eine PowerPoint‑Themen‑Datei (`.thmx`) besitzen und jede Folie neu stylen möchten, die von einem bestimmten Master abhängt. Wählen Sie den Master aus der [Presentation::get_Masters](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_masters/)‑Sammlung, die [IMasterSlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/) implementiert, und übergeben Sie den Pfad zur Themen‑Datei an die Methode.

Die Methode führt folgende Schritte aus:

1. Erstellt eine neue Master‑Folie basierend auf dem ausgewählten Master.  
1. Wendet das externe Thema auf den neuen Master an.  
1. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhingen.  
1. Gibt das neu erstellte [IMasterSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/) zurück.

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

Ein ungültiges, beschädigtes oder nicht unterstütztes Thema kann eine [PptxException](https://reference.aspose.com/slides/de/cpp/aspose.slides/pptxexception/) oder eine ihrer formatbezogenen Unterklassen auslösen. Validieren Sie vom Benutzer bereitgestellte Pfade, behandeln Sie Dateisystem‑Zugriffsfehler und speichern Sie die Präsentation erst, nachdem das Thema erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugeordnet. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Themen. Themen‑aware Farben, Schriftarten, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Thema aufgelöst. Direkt zugewiesene Farben, Schriftarten, Füllungen und andere explizite Formatierungen können unverändert bleiben. Layout‑ und Folien‑Overrides können zudem Vorrang vor den vom neuen Master geerbten Werten haben.

Das Thema kann Schriftarten referenzieren, die in der Laufzeitumgebung nicht verfügbar sind. Für ein konsistentes Rendering und Exportieren installieren Sie die erforderlichen Schriftarten, stellen Sie sie über [custom font sources](/slides/de/cpp/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/cpp/font-substitution/).

Dies ist ein direkter Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert nicht das manuelle Erstellen von Folien‑ oder Layout‑Overrides.

### **Unterschiedliche externe Themen in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master im Voraus nicht bekannt ist, ermitteln Sie ihn über eine repräsentative Folie mittels [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/get_layoutslide/) und [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/get_masterslide/). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themen anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, um deren Master zu finden, und wendet jedem Gruppensatz ein unterschiedliches externes Thema zu:

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

Der erste Aufruf betrifft nur Folien, die von `firstGroupMaster` abhingen, der zweite Aufruf betrifft nur Folien, die von `secondGroupMaster` abhingen. Folien, die anderen Mastern zugeordnet sind, werden nicht neu gestylt.

### **Ein Quell‑Thema beim Verschieben von Folien beibehalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und dabei das ursprüngliche Design erhalten, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/addclone/), dann klonen Sie die Folie mit [ISlideCollection::AddClone()](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) und dem geklonten Master. Dadurch werden Master, seine Layouts und das zugehörige Thema zusammen übertragen.

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

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel identisch aussehen muss. Das bloße Klonen von Inhalten auf einen fremden Ziel‑Master kann zu Änderungen von themenabhängigen Farben, Schriftarten, Hintergründen und Effekten führen.

### **Themenwerte auf einer bestehenden Folie anwenden**

Möchten Sie, dass die Ziel‑Folie auf ihrem aktuellen Master und Layout bleibt, initialisieren Sie einen Folien‑Level‑Override aus dem Quell‑Thema. Die Methoden [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) und [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) kopieren die drei Haupt‑Themen‑Komponenten in den Override.

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

Damit wird das von dieser Folie genutzte Thema geändert, ohne das von anderen Folien geerbte Thema zu beeinflussen. Um den lokalen Override zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme::Clear()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/clear/) auf.

### **Ein Themen‑Override auf ein Layout anwenden**

Ein Layout‑Level‑Override gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht einen eigenen Override besitzt. Die gleichen Initialisierungsmethoden können über das Layout‑Objekt [IOverrideThemeManager](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ioverridethememanager/) verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe BasDesign teilen sollen, ein Layout‑Override, wenn eine Layout‑Familie ein anderes Styling benötigt, und ein Folien‑Override nur für echte Ausnahmen. Übermäßige Folien‑Overrides erschweren spätere globale Themenänderungen.

## **Themen‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themas werden über [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) gespeichert. PowerPoint kann im UI mehr Hintergrund‑Optionen anbieten, als die tatsächlich in dieser Sammlung gespeicherten Fülldefinitionen vorhanden sind, weil das UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrund‑Stilgalerie für ein Präsentationsthema](presentation-design_8.png)

Bevor Sie einen Hintergrund‑Stil verwenden, inspizieren Sie die gespeicherte Sammlung und den aktuellen [Background::get_StyleIndex()](https://reference.aspose.com/slides/de/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` verwendet `0` für keine thematisierte Füllung; positive Werte sind Referenzen zu Theme‑Hintergrund‑Stilen. Das unterscheidet sich vom Indexieren einer C++‑Sammlung mit `idx_get(0)`, bei dem `0` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation die gleiche Anzahl von Hintergrund‑Füllstilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl von Hintergrund‑Füllungen aus, weist dem ersten Master eine thematisierte Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom vom Master referenzierten Thema‑Eintrag und etwaigen Hintergrund‑Overrides auf Layout‑ oder Folien‑Ebene ab. Verwendet eine Folie ihren eigenen Hintergrund, ändert das reine Ändern des Master‑Hintergrunds möglicherweise diese Folie nicht. Nutzen Sie [Background::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/background/geteffective/), wenn Sie den endgültigen Hintergrund nach angewandter Vererbung benötigen.

{{% alert color="warning" title="Warning" %}}
Betrachten Sie `StyleIndex` nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem das Hard‑Coden einer Stil‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei gleich aussieht; Themen‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/cpp/presentation-background/).
{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_linestyles/) und [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Typische Office‑Themen enthalten oft drei Haupteinträge, die visuell subtil, moderat und intensiv formatiert sind, aber der Code sollte jede Sammlung inspizieren, anstatt von einer festen Anzahl auszugehen.

![Subtile, moderate und intensive Themeneffekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Greift man in C++ auf diese Sammlungen zu, ist der Index nullbasiert: `idx_get(0)` liefert den ersten gespeicherten Stil, `idx_get(2)` den dritten. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Themen‑Stils beeinflusst Formen, die diesen Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stil‑Einträge existieren, ändert den ersten Linien‑Stil, den dritten Füll‑Stil, aktiviert einen äußeren Schatten im dritten Effekt‑Stil und speichert das Ergebnis:

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

Für Formen, die diese Slots referenzieren, wird der erste Themen‑Linien‑Stil Rot, der dritte Themen‑Füll‑Stil zu einem satten Waldgrün und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Slots jede Form referenziert und ob direkte Formatierung den Themenstil überschreibt.

![Thema‑Effekt‑Stile nach Änderung von Linie, Füllung und Schatteneinstellungen](presentation-design_11.png)

## **Ermitteln, ob eine effektive Voll‑Füllung eine Themenfarbe verwendet**

Eine Füllung kann direkt auf einem Objekt gespeichert sein oder von einem Absatz, Layout, Master, Themen‑Stil oder einer anderen Formatierungsebene geerbt werden. Rufen Sie [IFillFormat::GetEffective](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifillformat/geteffective/) auf, um diese Hierarchie in ein unveränderliches [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifillformateffectivedata/) zu überführen. Prüfen Sie zuerst [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Nur wenn dieser `FillType::Solid` ist, sollten Sie die Eigenschaften der Voll‑Füllung auslesen.

Für eine Voll‑Füllung liefert [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) den finalen gerenderten RGB‑Wert nach Vererbung, Themen‑Lookup und Farb‑Transformationen. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) liefert den zugehörigen logischen [SchemeColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/schemecolor/)-Slot, etwa `Text1` oder `Accent6`. Der Wert `SchemeColor::NotDefined` bedeutet, dass die effektive Voll‑Füllung nicht auf einer Schema‑Farbe basiert. In einem Workflow, in dem Füllungen entweder Themen‑Farben oder direkte RGB‑Farben sind, identifiziert dieser Wert eine direkte RGB‑Füllung.

Verwenden Sie nicht allein den lokalen Wert [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/icolorformat/get_schemecolor/) zur Klassifizierung einer Füllung. Beispielsweise kann ein Textabschnitt keine lokal definierte Schema‑Farbe besitzen, sodass sein lokaler Wert `NotDefined` ist, während seine effektive Füllung eine Themen‑Farbe erbt und zu `Text1` oder `Accent6` aufgelöst wird. Umgekehrt sagt Ihnen `get_SolidFillSchemeColor`, welcher logische Themen‑Slot die effektive Farbe erzeugt hat, aber nicht, ob dieser Slot vom Objekt, Absatz, Layout, Master oder einer anderen Ebene stammt.

Das folgende Beispiel lädt eine Präsentation, prüft sowohl Form‑Füllungen als auch Text‑Abschnitt‑Füllungen, gibt jeden finalen RGB‑Wert und die zugehörige Schema‑Farbe aus und kennzeichnet Voll‑Füllungen, die nicht den Themen‑Farbänderungen folgen:

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

Der `NotDefined`‑Zweig liefert eine Prüfliste von Voll‑Füllungen, die nicht auf Themen‑Farben reagieren. Überprüfen Sie diese Objekte, wenn eine Präsentation einer neuen Marken‑Palette folgen muss. Der ausgegebene RGB‑Wert zeigt weiterhin das aktuelle Aussehen, während der Schema‑Wert erklärt, ob dieses Aussehen mit dem Thema verknüpft ist.

Effektive Format‑Objekte sind Momentaufnahmen. Nachdem Sie das Präsentations‑Thema, einen Themen‑Override oder irgendeine geerbte Formatierung geändert haben, rufen Sie `GetEffective` erneut auf und lesen ein neues `IFillFormatEffectiveData`‑Objekt, bevor Sie Farben vergleichen oder berichten.

## **Effektive Themen‑Werte auslesen**

Roh‑Themen‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich verwendet, nachdem Vererbung und lokale Overrides aufgelöst wurden. Für eine Folie rufen Sie [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) auf. Für einen Hintergrund verwenden Sie [Background::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/background/geteffective/), und für eine Füllung [FillFormat::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/geteffective/).

Das folgende Beispiel liest das effektive Thema, den Hintergrund und die erste Form‑Füllung einer Folie aus:

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

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_mastertheme/) inspizieren, können Sie Master‑, Layout‑, Folien‑ oder Form‑Overrides übersehen, die das endgültige Aussehen ändern.

## **FAQ**

**Wirkt das Anwenden eines externen Themas auf jede Folie der Präsentation?**

Nein. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) weist nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master verwenden, behalten ihre bestehenden Themen.

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [IOverrideThemeManager](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ioverridethememanager/) der Folie und initialisieren Sie dessen Override‑Thema. Die Änderung bleibt lokal für diese Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Was ist der sicherste Weg, ein Thema von einer Präsentation in eine andere zu übertragen?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Aussehen erhalten möchten, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master über [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/addclone/) und [ISlideCollection::AddClone()](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/). Dadurch bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) für eine Folien‑ oder Layout‑Thema und die entsprechenden Effective‑Data‑Methoden für Formatobjekte wie [Background::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/background/geteffective/) und [FillFormat::GetEffective()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/geteffective/). Diese APIs liefern die aufgelösten Werte nach angewandter Vererbung und Overrides.