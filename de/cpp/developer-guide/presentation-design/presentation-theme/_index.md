---
title: Verwalten von Präsentationsdesigns in C++
linktitle: Präsentationsdesign
type: docs
weight: 10
url: /de/cpp/presentation-theme/
keywords:
- PowerPoint-Design
- Präsentationsdesign
- Folien-Design
- Design festlegen
- Design ändern
- Design verwalten
- externes Design
- THMX
- Designfarbe
- zusätzliche Palette
- Designschrift
- Designstil
- Designeffekt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Master-Präsentationsdesigns in Aspose.Slides für C++, um PowerPoint-Dateien mit einheitlicher Markenidentität zu erstellen, anzupassen und zu konvertieren."
---
## **Einführung**

Ein Präsentations‑Design definiert einen koordinierten Satz von Farben, Schriften, Hintergrundstilen, Füllungen, Linien und Effekten. Themenbewusste Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass eine Design‑Änderung viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das Präsentations‑Design über [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_mastertheme/). Eine Präsentation kann auch Design‑Überschreibungen auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentations‑Design über [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) überschreiben, während ein Layout oder eine einzelne Folie [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) verwenden kann. In der Praxis wird das wirksame Design einer Folie über diese Vererbungskette bestimmt: Präsentations‑Design, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Design‑Komponenten: Farben, Schriften, Hintergrundstile und Effekte](theme-constituents.png)

Die folgenden Abschnitte zeigen die gängigsten Design‑Arbeitsabläufe: ein Design inspizieren, Farben und Schriften ändern, ein Design kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Auflösung von Vererbung und Überschreibungen auslesen.

## **Design untersuchen**

Das Objekt [MasterTheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/) stellt die Methoden des Designs [get_ColorScheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), und [get_FormatScheme()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) bereit. Das Untersuchen dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da Anzahl und Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Designs aus und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Design gespeichert sind:

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

Verwendet eine Datei mehrere Master, darfst du nicht annehmen, dass jede Folie dasselbe wirksame Design hat. Prüfe den dem Folien zugeordneten Master und verwende den später in diesem Artikel gezeigten Wirksam‑Design‑Arbeitsablauf, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Design‑Farben ändern**

Themenbewusste Füllungen, Linien und Texte können auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/schemecolor/) verweisen. Wenn du den entsprechenden Eintrag in der [IColorScheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/icolorscheme/) des Designs änderst, werden alle Objekte, die noch auf diese Design‑Farbe verweisen, gegenüber dem neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch eine Design‑Farb‑Aktualisierung nicht geändert.

Das folgende End‑to‑End‑Beispiel erstellt eine Form, die `Accent4` verwendet, ändert die `Accent4`‑Farbe des Designs zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die wirksame Füllfarbe aus:

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

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Design‑Änderung rot. Wenn du die Schemafarbe durch eine direkte Farbe auf der Form ersetzt, wirken spätere Änderungen von `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Design‑Farbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über [ColorTransformOperation](https://reference.aspose.com/slides/de/cpp/aspose.slides/colortransformoperation/) bereit.

![Hauptdesign‑Farben und daraus generierte hellere und dunklere Farben der zusätzlichen Palette](additional-palette-colors.png)

**1** - Hauptdesign‑Farben.  
**2** - Hellere und dunklere Varianten, die aus den Hauptdesign‑Farben erzeugt wurden.

Das folgende Beispiel erstellt sechs Rechtecke basierend auf `Accent4`, wendet auf fünf von ihnen Luminanz‑Transformationen an und speichert das Ergebnis:

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

Diese Varianten bleiben auf der Design‑Farbe basierend. Ändert sich `Accent4` später, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `IColorScheme`‑Plätzen zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während [IColorScheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/icolorscheme/) dieselben Design‑Plätze als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Design‑Plätze; sie sind keine Werte, die dynamisch von einer Form in eine andere konvertiert werden.

## **Design‑Schriften ändern**

Ein Design‑Schriftenschema enthält ein Hauptschriftset für Überschriften und ein Nebenschriftset für Fließtext. Die Methoden [FontScheme::get_Major()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/fontscheme/get_major/) und [FontScheme::get_Minor()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/fontscheme/get_minor/) geben diese Sets zurück.

PowerPoint‑kompatible Design‑Schriftidentifikatoren können in der Textformatierung verwendet werden:

* `+mn-lt` - Körper‑Schrift Latin (Minor Latin Font)
* `+mj-lt` - Überschrifts‑Schrift Latin (Major Latin Font)
* `+mn-ea` - Körper‑Schrift Ostasiatisch (Minor East Asian Font)
* `+mj-ea` - Überschrifts‑Schrift Ostasiatisch (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Design‑Schrift verwendet, und eine Textzeile, die die Neben‑Latin‑Design‑Schrift verwendet. Anschließend werden die Design‑Schriften geändert und das Ergebnis gespeichert:

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

Die Überschrift verwendet die Hauptschrift und der Fließtext die Nebenschrift. Text, der einen expliziten Schriftnamen anstelle eines Design‑Identifikators hat, wechselt nicht automatisch, wenn das Design‑Schriftenschema geändert wird.

Die Haupt‑ und Nebenschrift‑Sammlungen können außerdem Schriftzuordnungen für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Für weitere Informationen zu Präsentationsschriften siehe [PowerPoint Fonts](/slides/de/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Ein Design kopieren oder anwenden**

Die nachfolgenden Arbeitsabläufe lösen verschiedene Design‑bezogene Probleme.

### **Ein externes Design auf von einem Master abhängende Folien anwenden**

Verwende [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) , wenn du eine PowerPoint‑Design‑Datei (`.thmx`) hast und jede Folie, die von einem bestimmten Master abhängt, neu gestalten möchtest. Wähle den Master aus der Sammlung [Presentation::get_Masters](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_masters/) aus, die [IMasterSlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/) implementiert, und übergebe den Pfad zur Design‑Datei an die Methode.

Die Methode führt die folgenden Vorgänge aus:

1. Erstellt eine neue Master‑Folie basierend auf dem ausgewählten Master.  
2. Wendet das externe Design auf den neuen Master an.  
3. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhingen.  
4. Gibt das neu erstellte [IMasterSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/) zurück.

Das folgende Beispiel wendet ein externes Design auf die Folien an, die vom ersten Master abhängen, und speichert die Präsentation:

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

Ein ungültiges, beschädigtes oder nicht unterstütztes Design kann eine [PptxException](https://reference.aspose.com/slides/de/cpp/aspose.slides/pptxexception/) oder eine ihrer formatbezogenen Unterklassen auslösen. Validiere von Benutzern bereitgestellte Pfade, behandel Zugriffsfehler auf das Dateisystem und speichere die Präsentation erst, nachdem das Design erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugewiesen. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Designs bei. Themenbewusste Farben, Schriften, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Design aufgelöst. Direkt zugewiesene Farben, Schriften, Füllungen und andere explizite Formatierungen können unverändert bleiben. Layout‑ und Folien‑Überschreibungen können ebenfalls Vorrang vor aus dem neuen Master geerbten Werten haben.

Das Design kann Schriften referenzieren, die in der Laufzeitumgebung nicht verfügbar sind. Für konsistente Darstellung und Export installiere die benötigten Schriften, stelle sie über [custom font sources](/slides/de/cpp/custom-font/) bereit oder konfiguriere [font substitution](/slides/de/cpp/font-substitution/).

Dies ist ein direkter Master‑Ebene‑Arbeitsablauf: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert keine manuelle Erstellung von Folien‑ oder Layout‑Design‑Überschreibungen.

### **Verschiedene externe Designs in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master nicht im Voraus bekannt ist, erhalte ihn von einer repräsentativen Folie über [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/get_layoutslide/) und [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/get_masterslide/). Speichere die ursprünglichen Master‑Referenzen, bevor du Designs anwendest, da jeder Aufruf einen weiteren Master in der Präsentation erstellt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, um deren Master zu ermitteln, und wendet jedem Gruppe ein unterschiedliches externes Design an:

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

Der erste Aufruf wirkt nur auf Folien, die von `firstGroupMaster` abhingen, und der zweite Aufruf wirkt nur auf Folien, die von `secondGroupMaster` abhingen. Folien, die zu einem anderen Master gehören, werden nicht neu gestaltet.

### **Ein Quell‑Design beim Verschieben von Folien beibehalten**

Wenn du eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design beibehalten möchtest, klone den Quell‑Master in die Zielpräsentation mit [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/addclone/), klone anschließend die Folie mit [ISlideCollection::AddClone()](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) und dem geklonten Master. Dadurch werden der Master, seine Layouts und das zugehörige Design gemeinsam übertragen.

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

Dies ist der bevorzugte Arbeitsablauf, wenn die Quell‑Folie im Ziel identisch aussehen muss. Das bloße Klonen von Inhalten auf einen nicht zum Quell‑Master gehörenden Ziel‑Master kann themengesteuerte Farben, Schriften, Hintergründe und Effekte ändern.

### **Design‑Werte auf eine vorhandene Folie anwenden**

Wenn die Ziel‑Folie auf ihrem aktuellen Master und Layout verbleiben muss, initialisiere eine Folien‑Überschreibung aus dem Quell‑Design. Die Methoden [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) und [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) kopieren die drei Hauptkomponenten des Designs in die Überschreibung.

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

Dies ändert das von dieser Folie verwendete Design, ohne das von anderen Folien geerbte Design zu ändern. Um die lokale Überschreibung zu entfernen und zu den geerbten Werten zurückzukehren, rufe [OverrideTheme::Clear()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/overridetheme/clear/) auf.

### **Eine Design‑Überschreibung auf ein Layout anwenden**

Eine Layout‑Überschreibung gilt für Folien, die dieses Layout verwenden, es sei denn, eine bestimmte Folie hat ihre eigene Überschreibung. Die gleichen Initialisierungsmethoden können über den [IOverrideThemeManager](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ioverridethememanager/) des Layouts verwendet werden:

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

Verwende ein Master‑ oder Präsentations‑Design, wenn viele Layouts und Folien das gleiche Basis‑Design teilen sollen, eine Layout‑Überschreibung, wenn eine Layout‑Familie ein anderes Styling benötigt, und eine Folien‑Überschreibung nur für echte Ausnahmen. Übermäßige Folien‑Überschreibungen erschweren die Vorhersage späterer globaler Design‑Änderungen.

## **Design‑Hintergrundstile aktualisieren**

Die Hintergrundfüllungen des Designs werden in [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) gespeichert. PowerPoint kann in seiner Benutzeroberfläche mehr Hintergrundoptionen anzeigen als die tatsächlich in dieser Sammlung gespeicherten Fülldefinitionen, da die UI Design‑Füllungen mit Design‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrundstilgalerie für ein Präsentationsdesign](presentation-design_8.png)

Bevor ein Hintergrundstil verwendet wird, prüfe die gespeicherte Sammlung und den aktuellen [Background::get_StyleIndex()](https://reference.aspose.com/slides/de/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` verwendet `0` für keine themenbasierte Füllung; positive Werte sind Referenzen zu Design‑Hintergrundstilen. Das unterscheidet sich vom direkten Indexieren einer C++‑Sammlung mit `idx_get(0)`, bei dem `0` das erste gespeicherte Element bedeutet. Gehe nicht davon aus, dass jede Präsentation die gleiche Anzahl von Hintergrundfüllungen enthält.

Das folgende Beispiel gibt die Anzahl verfügbarer Hintergrundfüllungen aus, weist dem ersten Master eine themenbasierte Hintergrundreferenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom vom Master referenzierten Design‑Eintrag und von etwaigen Hintergrund‑Überschreibungen auf Layout‑ oder Folienebene ab. Verwendet eine Folie ihren eigenen Hintergrund, kann das Ändern des Master‑Hintergrunds diese Folie nicht beeinflussen. Verwende [Background::GetEffective](), wenn du den endgültigen Hintergrund nach angewandter Vererbung ermitteln musst.

{{% alert color="warning" title="Warning" %}}
Betrachte `StyleIndex` nicht als nullbasierten Sammlungsindex. Vermeide außerdem, eine Stil‑Nummer aus einer Datei fest zu codieren und anzunehmen, dass sie in einer anderen Datei gleich aussieht; Design‑Stildefinitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/cpp/presentation-background/).
{{% /alert %}}

## **Design‑Effekte aktualisieren**

Ein Design‑Format‑Schema enthält separate Sammlungen [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_linestyles/), und [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Typische Office‑Designs enthalten häufig drei Hauptstileinträge, die visuell subtilen, moderaten und intensiven Formatierungen entsprechen, aber Code sollte jede Sammlung prüfen, anstatt eine feste Anzahl anzunehmen.

![Subtile, moderate und intensive Design‑Effekte, die auf dieselbe Form angewendet wurden](presentation-design_10.png)

Wenn du in C++ auf diese Sammlungen zugreifst, ist der Sammlungs‑Index nullbasiert: `idx_get(0)` ist der erste gespeicherte Stil und `idx_get(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Design‑Stils wirkt sich auf Formen aus, die diesen Design‑Stil referenzieren; Formen mit direkter Formatierung können unverändert bleiben.

Das folgende Beispiel prüft, ob die erforderlichen Stileinträge vorhanden sind, ändert den ersten Linienstil, ändert den dritten Füllstil, aktiviert einen äußeren Schatten im dritten Effektstil und speichert das Ergebnis:

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

Für Formen, die diese Plätze referenzieren, wird der erste Design‑Linienstil rot, der dritte Design‑Füllstil wird zu einem deckenden Waldgrün und der dritte Effektstil erhält einen äußeren Schatten mit einer Distanz von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Plätze jede Form referenziert und ob direkte Formatierung das Design überschreibt.

![Design‑Effektstile nach Änderungen von Linie, Füllung und Schatteneinstellungen](presentation-design_11.png)

## **Wirksame Design‑Werte auslesen**

Roh‑Design‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Wirksame Werte zeigen, was eine Folie oder Form tatsächlich nach Auflösung von Vererbung und lokalen Überschreibungen verwendet. Für eine Folie rufe [IThemeable::CreateThemeEffective]()(https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) auf. Für einen Hintergrund verwende [Background::GetEffective]()(https://reference.aspose.com/slides/de/cpp/aspose.slides/background/geteffective/), und für eine Füllung [FillFormat::GetEffective]()(https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/geteffective/).

Das folgende Beispiel liest das wirksame Design, den Hintergrund und die erste Form‑Füllung einer Folie aus:

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

Verwende wirksame Daten für Render‑Diagnosen, Validierung und Vergleiche. Wenn du nur [Presentation::get_MasterTheme]()(https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_mastertheme/) prüfst, kannst du einen Master‑, Layout‑, Folien‑ oder Form‑Überschreibung übersehen, die das endgültige Erscheinungsbild ändert.

## **FAQ**

**Wirkt das Anwenden eines externen Designs auf jede Folie in der Präsentation?**

Nein. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) weist nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master verwenden, behalten ihre bestehenden Designs bei.

**Kann ich ein Design auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwende den [IOverrideThemeManager](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ioverridethememanager/) der Folie und initialisiere ihr Überschreibungs‑Design. Die Änderung bleibt auf diese Folie lokal; andere Folien erben weiterhin ihre bestehenden Designs.

**Was ist der sicherste Weg, ein Design von einer Präsentation in eine andere zu übertragen?**

Wenn du eine Folie verschiebst und ihr ursprüngliches Erscheinungsbild beibehältst, klone den Quell‑Master in das Ziel und klone die Folie mit diesem Master mithilfe von [IMasterSlideCollection::AddClone()]()(https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/addclone/) und [ISlideCollection::AddClone()]()(https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) . Dadurch bleiben Master, Layouts und Design zusammen.

**Wie kann ich die wirksamen Werte nach Vererbung und Überschreibungen einsehen?**

Verwende [IThemeable::CreateThemeEffective]()(https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) für ein Folien‑ oder Layout‑Design und die entsprechenden Wirksam‑Daten‑Methoden für Formatobjekte wie [Background::GetEffective]()(https://reference.aspose.com/slides/de/cpp/aspose.slides/background/geteffective/) und [FillFormat::GetEffective]()(https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/geteffective/). Diese APIs geben die aufgelösten Werte zurück, nachdem Vererbung und Überschreibungen angewendet wurden.