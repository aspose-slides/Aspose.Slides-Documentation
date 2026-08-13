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
- Themafarbe
- zusätzliche Palette
- Themen-Schriftart
- Themenstil
- Themaeffekt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Master‑Präsentationsthemen in Aspose.Slides für C++ erstellen, anpassen und PowerPoint‑Dateien mit konsistenter Markenführung konvertieren."
---
## **Einleitung**

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz von visuellen Elementen und deren Eigenschaften.

In PowerPoint besteht ein Thema aus Farben, [Schriftarten](/slides/de/cpp/powerpoint-fonts/), [Hintergrundstilen](/slides/de/cpp/presentation-background/) und Effekten.

![theme-constituents](theme-constituents.png)

## **Themafarbe ändern**

Ein PowerPoint‑Thema verwendet einen bestimmten Satz von Farben für verschiedene Elemente einer Folie. Wenn Ihnen die Farben nicht gefallen, ändern Sie sie, indem Sie neue Farben für das Thema anwenden. Damit Sie eine neue Themafarbe auswählen können, stellt Aspose.Slides Werte aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) bereit.

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Sie können den effektiven Wert der resultierenden Farbe auf diese Weise ermitteln:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto fillEffective = shape->get_FillFormat()->GetEffective();

Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Farbe [A=255, R=128, G=100, B=162])
```

Um den Farbwechsel weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ursprünglichen Operation) zu. Anschließend ändern wir die Farbe im Thema:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();

auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);

otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Themafarbe aus einer zusätzlichen Palette festlegen**

Wenn Sie Luminanz‑Transformationen auf die Hauptthemafarbe (1) anwenden, entstehen Farben aus der zusätzlichen Palette (2). Diese Themafarben können Sie dann setzen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1**- Hauptthemafarben  
**2**- Farben aus der zusätzlichen Palette.

Dieser C++‑Code demonstriert eine Operation, bei der Farben aus der zusätzlichen Palette aus der Hauptthemafarbe gewonnen und anschließend in Formen verwendet werden:

```c++
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

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Akzent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Akzent 4, Heller 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Akzent 4, Heller 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Akzent 4, Heller 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Akzent 4, Dunkler 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Akzent 4, Dunkler 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **`SchemeColor` zu `IColorScheme`‑Farben zuordnen**

Wenn Sie mit [SchemeColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/schemecolor/) arbeiten, werden Sie feststellen, dass es die folgenden Themenfarbwerte enthält: `Background1`, `Background2`, `Text1` und `Text2`.

Allerdings gibt `Presentation::get_MasterTheme()::get_ColorScheme()` [IColorScheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/icolorscheme/) zurück, das die entsprechenden Farben wie folgt bereitstellt: `Dark1`, `Dark2`, `Light1` und `Light2`.

Dieser Unterschied besteht nur in der Benennung. Diese Werte beziehen sich auf dieselben Themfarbe‑Slots und die Zuordnung ist festgelegt:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Es gibt keine dynamische Konvertierung zwischen `Text`/`Background` und `Dark`/`Light`. Sie sind lediglich alternative Bezeichnungen für dieselben Themfarben.

Dieser Unterschied in der Benennung stammt aus der Terminologie von Microsoft Office. Ältere Office‑Versionen verwendeten `Dark 1`, `Light 1`, `Dark 2` und `Light 2`, während neuere UI‑Versionen dieselben Slots als `Text 1`, `Background 1`, `Text 2` und `Background 2` anzeigen.

## **Thema‑Schriftart ändern**

Damit Sie Schriftarten für Themen und andere Zwecke auswählen können, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen, die in PowerPoint verwendet werden):

* **+mn-lt** – Körper‑Schriftart Lateinisch (Minor Latin Font)
* **+mj-lt** – Überschriften‑Schriftart Lateinisch (Major Latin Font)
* **+mn-ea** – Körper‑Schriftart Ostasiatisch (Minor East Asian Font)
* **+mj-ea** – Körper‑Schriftart Ostasiatisch (Major East Asian Font)

Dieser C++‑Code zeigt, wie Sie die lateinische Schriftart einem Theme‑Element zuweisen:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Dieser C++‑Code zeigt, wie Sie die Schriftart des Präsentationsthemas ändern:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Die Schriftart in allen Textfeldern wird aktualisiert.

{{% alert color="info" title="TIP" %}} 
Vielleicht möchten Sie sich [PowerPoint-Schriftarten](/slides/de/cpp/powerpoint-fonts/) ansehen.
{{% /alert %}}

## **Hintergrundstil des Themas ändern**

Standardmäßig stellt die PowerPoint‑App 12 vordefinierte Hintergründe bereit, aber nur 3 dieser 12 Hintergründe werden in einer typischen Präsentation gespeichert.

![todo:image_alt_text](presentation-design_8.png)

Beispielsweise können Sie nach dem Speichern einer Präsentation in der PowerPoint‑App diesen C++‑Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation zu ermitteln:

```c++
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Theme;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
Verwenden Sie die Eigenschaft [BackgroundFillStyles](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) der Klasse [FormatScheme](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.theme.i_format_scheme/), können Sie den Hintergrundstil in einem PowerPoint‑Theme hinzufügen oder darauf zugreifen. 
{{% /alert %}}

Dieser C++‑Code zeigt, wie Sie den Hintergrund für eine Präsentation festlegen:

```c++
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Index‑Leitfaden**: 0 steht für keine Füllung. Der Index beginnt bei 1.

{{% alert color="info" title="TIP" %}} 
Vielleicht möchten Sie sich [PowerPoint‑Hintergrund](/slides/de/cpp/presentation-background/) ansehen.
{{% /alert %}}

## **Thema‑Effekt ändern**

Ein PowerPoint‑Thema enthält normalerweise 3 Werte für jedes Stil-Array. Diese Arrays werden zu den 3 Effekten kombiniert: subtil, moderat und intensiv. Beispielsweise ist dies das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Mit den 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) aus der Klasse [FormatScheme](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.theme.i_format_scheme/) können Sie die Elemente eines Themas ändern (noch flexibler als die Optionen in PowerPoint).

```c++
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
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
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");

pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

Die resultierenden Änderungen bei Füllfarbe, Fülltyp, Schatteneffekt usw.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### Kann ich ein Thema auf eine einzelne Folie anwenden, ohne die Masterfolie zu ändern?

Ja. Aspose.Slides unterstützt Themen‑Überschreibungen auf Folienebene, sodass Sie ein lokales Thema nur auf diese Folie anwenden können, während das Master‑Thema unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/slidethememanager/)).

### Was ist der sicherste Weg, ein Thema von einer Präsentation zur anderen zu übertragen?

[Klonen Sie Folien](/slides/de/cpp/clone-slides/) zusammen mit deren Master in die Zielpräsentation. Dadurch werden der ursprüngliche Master, die Layouts und das zugehörige Thema erhalten, sodass das Aussehen konsistent bleibt.

### Wie kann ich die „effektiven“ Werte nach allen Vererbungen und Überschreibungen sehen?

Verwenden Sie die ["effektiven" Ansichten](/slides/de/cpp/shape-effective-properties/) der API für Thema/Farbe/Schriftart/Effekt. Diese geben die aufgelösten, endgültigen Eigenschaften zurück, nachdem der Master sowie alle lokalen Überschreibungen angewendet wurden.