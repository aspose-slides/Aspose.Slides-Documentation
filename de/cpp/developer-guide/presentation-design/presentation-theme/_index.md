---
title: Präsentationsthema
type: docs
weight: 10
url: /cpp/presentation-theme/
keywords: "Thema, PowerPoint-Thema, PowerPoint-Präsentation, CPP, C++, Aspose.Slides für C++"
description: "PowerPoint-Präsentationsthema in C++"
---

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften aus. 

In PowerPoint umfasst ein Thema Farben, [Schriften](/slides/cpp/powerpoint-fonts/), [Hintergrundstile](/slides/cpp/presentation-background/) und Effekte. 

![theme-constituents](theme-constituents.png)

## **Themenfarbe ändern**

Ein PowerPoint-Thema verwendet einen bestimmten Farbensatz für verschiedene Elemente auf einer Folie. Wenn Ihnen die Farben nicht gefallen, können Sie sie ändern, indem Sie neue Farben für das Thema anwenden. Um Ihnen die Auswahl einer neuen Themenfarbe zu ermöglichen, stellt Aspose.Slides Werte unter der [SchemeColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) Enumeration zur Verfügung.

Dieser C++-Code zeigt Ihnen, wie Sie die Akzentfarbe für ein Thema ändern:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

So können Sie den effektiven Wert der resultierenden Farbe bestimmen:

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

### **Themenfarbe aus zusätzlicher Palette festlegen**

Wenn Sie Luminanztransformationen auf die Hauptthemenfarbe(1) anwenden, werden Farben aus der zusätzlichen Palette(2) gebildet. Sie können dann diese Themenfarben festlegen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1** - Hauptthemenfarben

**2** - Farben aus der zusätzlichen Palette.

Dieser C++-Code demonstriert eine Operation, bei der zusätzliche Palettenfarben aus der Hauptthemenfarbe abgerufen und dann in Formen verwendet werden:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Akzent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Akzent 4, heller 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Akzent 4, heller 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Akzent 4, heller 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Akzent 4, dunkler 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Akzent 4, dunkler 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

## **Themenfont ändern**

Um Ihnen die Auswahl von Schriften für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen in PowerPoint):

* **+mn-lt** - Textschrift Latein (Sekundärlateinschrift)
* **+mj-lt** - Überschrift Schrift Latein (Primärlateinschrift)
* **+mn-ea** - Textschrift Ostasiatisch (Sekundärostasiatische Schrift)
* **+mj-ea** - Überschrift Schrift Ostasiatisch (Primär-Ostasiatische Schrift)

Dieser C++-Code zeigt Ihnen, wie Sie die lateinische Schrift einem themenbezogenen Element zuweisen:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Thema Textformat");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Dieser C++-Code zeigt Ihnen, wie Sie die Schriftart des Präsentationsthemas ändern:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Die Schriftart in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIPP" %}} 

Sie möchten möglicherweise die [PowerPoint-Schriften](/slides/cpp/powerpoint-fonts/) sehen.

{{% /alert %}}

## **Themenhintergrundstil ändern**

Standardmäßig bietet die PowerPoint-Anwendung 12 vordefinierte Hintergründe an, aber nur 3 von diesen 12 Hintergründen werden in einer typischen Präsentation gespeichert. 

![todo:image_alt_text](presentation-design_8.png)

Nachdem Sie beispielsweise eine Präsentation in der PowerPoint-App gespeichert haben, können Sie diesen C++-Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation herauszufinden:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Anzahl der Hintergrundfüllstile für das Thema beträgt {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 

Mit der [BackgroundFillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) Eigenschaft der [FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/) Klasse können Sie den Hintergrundstil in einem PowerPoint-Thema hinzufügen oder darauf zugreifen. 

{{% /alert %}}

Dieser C++-Code zeigt Ihnen, wie Sie den Hintergrund für eine Präsentation festlegen:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Index-Leitfaden**: 0 wird für keinen Füllstil verwendet. Der Index beginnt bei 1.

{{% alert color="primary" title="TIPP" %}} 

Sie möchten möglicherweise den [PowerPoint-Hintergrund](/slides/cpp/presentation-background/) sehen.

{{% /alert %}}

## **Themenwirkung ändern**

Ein PowerPoint-Thema enthält normalerweise 3 Werte für jedes Stilarray. Diese Arrays werden in diese 3 Effekte kombiniert: subtil, moderat und intensiv. Beispielhaft ist dies das Ergebnis, wenn die Effekte auf ein bestimmtes Element angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Mit 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) der [FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/) Klasse können Sie die Elemente in einem Thema (sogar flexibler als die Optionen in PowerPoint) ändern.

Dieser C++-Code zeigt Ihnen, wie Sie eine Themenwirkung ändern, indem Sie Teile von Elementen ändern:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

Die resultierenden Änderungen in der Füllfarbe, dem Fülltyp, dem Schatteneffekt usw.:

![todo:image_alt_text](presentation-design_11.png)