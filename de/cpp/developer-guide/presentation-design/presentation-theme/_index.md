---
title: Präsentationsthemen verwalten in C++
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
- zusätzliche Palette
- Themen‑Schrift
- Themen‑Stil
- Themen‑Effekt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Präsentationsthemen in Aspose.Slides für C++ verwalten, um PowerPoint‑Dateien mit konsistenter Markenbildung zu erstellen, anzupassen und zu konvertieren."
---

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften.

In PowerPoint besteht ein Thema aus Farben, [fonts](/slides/de/cpp/powerpoint-fonts/), [background styles](/slides/de/cpp/presentation-background/), und Effekten.

![theme-constituents](theme-constituents.png)

## **Theme-Farbe ändern**

Ein PowerPoint-Thema verwendet einen festen Satz von Farben für verschiedene Elemente einer Folie. Wenn Ihnen die Farben nicht gefallen, ändern Sie sie, indem Sie neue Farben für das Thema anwenden. Um Ihnen die Auswahl einer neuen Theme-Farbe zu ermöglichen, stellt Aspose.Slides Werte der Aufzählung [SchemeColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) bereit.

Dieser C++‑Code zeigt, wie die Akzentfarbe eines Themas geändert wird:
```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```


Sie können den effektiven Wert der resultierenden Farbe so bestimmen:
```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Farbe [A=255, R=128, G=100, B=162])
```


Um die Farbänderung weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ersten Operation) zu. Anschließend ändern wir die Farbe im Thema:
```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```


Die neue Farbe wird automatisch auf beiden Elementen angewendet.

### **Theme-Farbe aus einer zusätzlichen Palette setzen**

Wenn Sie Luminanz‑Transformationen auf die Haupt‑Theme‑Farbe (1) anwenden, entstehen Farben aus der zusätzlichen Palette (2). Diese Theme‑Farben können Sie dann setzen und auslesen.

![additional-palette-colors](additional-palette-colors.png)

**1**‑ Haupt‑Theme‑Farben  

**2**‑ Farben aus der zusätzlichen Palette.

Dieser C++‑Code demonstriert, wie Farben der zusätzlichen Palette aus der Haupt‑Theme‑Farbe gewonnen und anschließend in Formen verwendet werden:
```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, Lighter 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, Lighter 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, Lighter 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, Darker 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, Darker 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```


## **Theme‑Schrift ändern**

Um Ihnen die Auswahl von Schriften für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen in PowerPoint):

* **+mn-lt** – Body Font Latin (Minor Latin Font)
* **+mj-lt** – Heading Font Latin (Major Latin Font)
* **+mn-ea** – Body Font East Asian (Minor East Asian Font)
* **+mj-ea** – Body Font East Asian (Major East Asian Font)

Dieser C++‑Code zeigt, wie die lateinische Schrift einem Theme‑Element zugewiesen wird:
```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```


Dieser C++‑Code zeigt, wie die Präsentations‑Theme‑Schrift geändert wird:
{{c3c369c2-3c50-4dff-879a-0d3233a8da554}}

Die Schrift in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIP" %}} 

Vielleicht möchten Sie auch [PowerPoint fonts](/slides/de/cpp/powerpoint-fonts/) ansehen.

{{% /alert %}}

## **Theme‑Hintergrundstil ändern**

Standardmäßig stellt die PowerPoint‑App 12 vordefinierte Hintergründe bereit, von denen jedoch in einer typischen Präsentation nur 3 dieser 12 Hintergründe gespeichert werden.

![todo:image_alt_text](presentation-design_8.png)

Beispielsweise können Sie nach dem Speichern einer Präsentation in der PowerPoint‑App folgenden C++‑Code ausführen, um die Anzahl vordefinierter Hintergründe in der Präsentation zu ermitteln:
```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```


{{% alert color="warning" %}} 

Mit der Eigenschaft [BackgroundFillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) aus der Klasse [FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/) können Sie den Hintergrundstil in einem PowerPoint‑Theme hinzufügen oder darauf zugreifen. 

{{% /alert %}}

Dieser C++‑Code zeigt, wie der Hintergrund für eine Präsentation festgelegt wird:
```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```


**Index‑Leitfaden**: 0 steht für keine Füllung. Der Index beginnt bei 1.

{{% alert color="primary" title="TIP" %}} 

Vielleicht möchten Sie auch [PowerPoint Background](/slides/de/cpp/presentation-background/) ansehen.

{{% /alert %}}

## **Theme‑Effekt ändern**

Ein PowerPoint‑Theme enthält normalerweise 3 Werte für jedes Stil‑Array. Diese Arrays werden zu den 3 Effekten *subtle*, *moderate* und *intense* kombiniert. Beispiel: Das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Mit den 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) aus der Klasse [FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/) können Sie die Elemente eines Themas ändern (noch flexibler als die Optionen in PowerPoint).

Dieser C++‑Code zeigt, wie ein Theme‑Effekt geändert wird, indem Teile von Elementen angepasst werden:
```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```


Die daraus resultierenden Änderungen von Füllfarbe, Fülltyp, Schatteneffekt usw.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kann ich ein Theme auf eine einzelne Folie anwenden, ohne das Master‑Theme zu ändern?**

Ja. Aspose.Slides unterstützt Theme‑Überschreibungen auf Folienebene, sodass Sie ein lokales Theme nur für diese Folie anwenden können, während das Master‑Theme unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/slidethememanager/)).

**Wie übertrage ich ein Theme am sichersten von einer Präsentation zur anderen?**

[Clone slides](/slides/de/cpp/clone-slides/) zusammen mit deren Master in die Zielpräsentation einbinden. Dadurch bleiben der ursprüngliche Master, die Layouts und das zugehörige Theme erhalten, sodass das Aussehen konsistent bleibt.

**Wie kann ich die „effektiven“ Werte nach allen Vererbungen und Überschreibungen sehen?**

Verwenden Sie die API‑„["effective" views](/slides/de/cpp/shape-effective-properties/)“ für Theme/Farbe/Schrift/Effekt. Diese geben die aufgelösten, endgültigen Eigenschaften nach Anwendung des Masters sowie aller lokalen Überschreibungen zurück.