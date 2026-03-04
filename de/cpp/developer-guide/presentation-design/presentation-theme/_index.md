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
- Theme festlegen
- Theme ändern
- Theme verwalten
- Theme-Farbe
- zusätzliche Palette
- Theme-Schriftart
- Theme-Stil
- Theme-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für C++ zum Erstellen, Anpassen und Konvertieren von PowerPoint-Dateien mit einheitlichem Branding."
---
Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften.

In PowerPoint umfasst ein Thema Farben, [fonts](/slides/de/cpp/powerpoint-fonts/), [background styles](/slides/de/cpp/presentation-background/) und Effekte.

![theme-constituents](theme-constituents.png)

## **Theme-Farbe ändern**

Ein PowerPoint-Thema verwendet einen bestimmten Satz von Farben für verschiedene Elemente einer Folie. Wenn Ihnen die Farben nicht gefallen, ändern Sie sie, indem Sie neue Farben für das Thema anwenden. Um Ihnen die Auswahl einer neuen Theme‑Farbe zu ermöglichen, stellt Aspose.Slides Werte aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) bereit.

Dieser C++‑Code zeigt, wie Sie die Akzentfarbe für ein Thema ändern:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Sie können den effektiven Wert der resultierenden Farbe auf diese Weise bestimmen:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Farbe [A=255, R=128, G=100, B=162])
```

Um die Farbänderungsoperation weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ersten Operation) zu. Dann ändern wir die Farbe im Thema:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Theme‑Farbe aus einer zusätzlichen Palette festlegen**

Wenn Sie Luminanz‑Transformationen auf die Haupt‑Theme‑Farbe (1) anwenden, entstehen Farben aus der zusätzlichen Palette (2). Sie können diese Theme‑Farben dann setzen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1**- Haupt‑Theme‑Farben  
**2**- Farben aus der zusätzlichen Palette.

Dieser C++‑Code demonstriert einen Vorgang, bei dem Farben der zusätzlichen Palette aus der Haupt‑Theme‑Farbe gewonnen und anschließend in Formen verwendet werden:

```c++
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

### **Zuordnung von `SchemeColor` zu `IColorScheme`‑Farben**

Wenn Sie mit [SchemeColor](https://reference.aspose.com/slides/de/cpp/aspose.slides.schemecolor/) arbeiten, werden Sie feststellen, dass es die folgenden Theme‑Farbwerte enthält: `Background1`, `Background2`, `Text1` und `Text2`.

Aber `Presentation::get_MasterTheme()::get_ColorScheme()` gibt [IColorScheme](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/icolorscheme/) zurück, das die entsprechenden Farben wie folgt bereitstellt: `Dark1`, `Dark2`, `Light1` und `Light2`.

Dieser Unterschied besteht nur in der Benennung. Diese Werte beziehen sich auf dieselben Theme‑Farbschlitze und die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Es gibt keine dynamische Umwandlung zwischen `Text`/`Background` und `Dark`/`Light`. Es handelt sich lediglich um alternative Bezeichnungen für dieselben Theme‑Farben.

Diese Benennungsunterschiede stammen von der Microsoft‑Office‑Terminologie. Ältere Office‑Versionen nutzten `Dark 1`, `Light 1`, `Dark 2` und `Light 2`, während neuere UI‑Versionen dieselben Schlitze als `Text 1`, `Background 1`, `Text 2` und `Background 2` anzeigen.

## **Theme‑Schriftart ändern**

Um Ihnen die Auswahl von Schriftarten für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen in PowerPoint):

* **+mn‑lt** – Body‑Schriftart Latin (Minor Latin Font)
* **+mj‑lt** – Heading‑Schriftart Latin (Major Latin Font)
* **+mn‑ea** – Body‑Schriftart Ostasiatisch (Minor East Asian Font)
* **+mj‑ea** – Body‑Schriftart Ostasiatisch (Major East Asian Font)

Dieser C++‑Code zeigt, wie Sie die Latin‑Schriftart einem Theme‑Element zuweisen:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Dieser C++‑Code zeigt, wie Sie die Präsentations‑Theme‑Schriftart ändern:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Die Schriftart in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIP" %}} 
Vielleicht möchten Sie sich die [PowerPoint fonts](/slides/de/cpp/powerpoint-fonts/) ansehen. 
{{% /alert %}}

## **Theme‑Hintergrundstil ändern**

Standardmäßig stellt die PowerPoint‑App 12 vordefinierte Hintergründe bereit, aber nur 3 dieser 12 Hintergründe werden in einer typischen Präsentation gespeichert.

![todo:image_alt_text](presentation-design_8.png)

Zum Beispiel können Sie nach dem Speichern einer Präsentation in der PowerPoint‑App diesen C++‑Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation zu ermitteln:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
Mit der Eigenschaft [BackgroundFillStyles](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) der Klasse [FormatScheme](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.theme.i_format_scheme/) können Sie den Hintergrundstil in einem PowerPoint‑Theme hinzufügen oder darauf zugreifen. 
{{% /alert %}}

Dieser C++‑Code zeigt, wie Sie den Hintergrund für eine Präsentation festlegen:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Index‑Leitfaden**: 0 wird für keine Füllung verwendet. Der Index beginnt bei 1.

{{% alert color="primary" title="TIP" %}} 
Vielleicht möchten Sie sich den [PowerPoint Background](/slides/de/cpp/presentation-background/) ansehen. 
{{% /alert %}}

## **Theme‑Effekt ändern**

Ein PowerPoint‑Theme enthält normalerweise 3 Werte für jedes Stil‑Array. Diese Arrays werden zu den 3 Effekten subtil, moderat und intensiv kombiniert. Zum Beispiel ist dies das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Durch die Verwendung von 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) der Klasse [FormatScheme](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.theme.i_format_scheme/) können Sie die Elemente in einem Theme ändern (noch flexibler als die Optionen in PowerPoint).

```c++
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

**Kann ich ein Theme auf eine einzelne Folie anwenden, ohne den Master zu ändern?**  
Ja. Aspose.Slides unterstützt Theme‑Überschreibungen auf Folienebene, sodass Sie ein lokales Theme nur auf diese Folie anwenden können, während das Master‑Theme unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/de/cpp/aspose.slides.theme/slidethememanager/)).

**Was ist der sicherste Weg, ein Theme von einer Präsentation in eine andere zu übertragen?**  
[Clone slides](/slides/de/cpp/clone-slides/) gemeinsam mit ihrem Master in die Zielpräsentation übernehmen. Dadurch bleiben das ursprüngliche Master‑Layout, die Layouts und das zugehörige Theme erhalten, sodass das Erscheinungsbild konsistent bleibt.

**Wie kann ich die „effektiven“ Werte nach allen Vererbungen und Überschreibungen sehen?**  
Verwenden Sie die ["effektiven" Ansichten](/slides/de/cpp/shape-effective-properties/) der API für Theme/Farbe/Schriftart/Effekt. Diese geben die aufgelösten, endgültigen Eigenschaften zurück, nachdem der Master sowie etwaige lokale Überschreibungen angewendet wurden.