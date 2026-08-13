---
title: Formanimationen in Präsentationen mit C++ anwenden
linktitle: Formanimation
type: docs
weight: 60
url: /de/cpp/shape-animation/
keywords:
- Form
- Animation
- Effekt
- animierte Form
- animierter Text
- Animation hinzufügen
- Animation abrufen
- Animation extrahieren
- Effekt hinzufügen
- Effekt abrufen
- Effekt extrahieren
- Effektsound
- Animation anwenden
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie, wie Sie Formanimationen in PowerPoint-Präsentationen mit Aspose.Slides für C++ erstellen und anpassen. Heben Sie sich ab!"
---
## **Einführung**

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](/slides/de/cpp/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben. 

## **Warum Animationen in Präsentationen verwenden?**

Durch den Einsatz von Animationen können Sie  

* den Informationsfluss steuern  
* wichtige Punkte hervorheben  
* das Interesse oder die Beteiligung des Publikums steigern  
* den Inhalt leichter lesbar, verständlich oder verarbeitbar machen  
* die Aufmerksamkeit der Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken  

PowerPoint bietet viele Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungspfad**. 

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/de/cpp/namespace/aspose.slides.animation) zu arbeiten,  
* Aspose.Slides bietet über **150 Animationseffekte** in der Aufzählung [EffectType](https://reference.aspose.com/slides/de/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Diese Effekte sind im Wesentlichen dieselben (oder gleichwertigen) Effekte, die in PowerPoint verwendet werden. 

## **Animation auf ein Textfeld anwenden**

Aspose.Slides für C++ ermöglicht es Ihnen, Animationen auf den Text in einer Form anzuwenden. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation/).  
2. Holen Sie sich den Verweis auf eine Folie über ihren Index.  
3. Fügen Sie eine `rectangle`-[IAutoShape](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_auto_shape) hinzu.  
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) hinzu.  
5. Holen Sie die Hauptsequenz der Effekte.  
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_auto_shape) hinzu.  
7. Setzen Sie die Eigenschaft [TextAnimation.BuildType](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) auf den Wert aus der [BuildType Enumeration](https://reference.aspose.com/slides/de/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).  
8. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.  

Dieser C++‑Code zeigt, wie Sie den `Fade`‑Effekt auf AutoShape anwenden und die Textanimation auf den Wert *By 1st Level Paragraphs* setzen:

```c++
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Fügt eine neue AutoShape mit Text hinzu
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Ruft die Hauptsequenz der Folie ab.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Fügt der Form den Fade-Animationseffekt hinzu
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animiert den Text der Form nach Absätzen der ersten Ebene
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Speichert die PPTX-Datei auf der Festplatte
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_paragraph) anwenden. Siehe [**Animierter Text**](/slides/de/cpp/animated-text/).

{{% /alert %}} 

## **Animation auf ein PictureFrame anwenden**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation/).  
2. Holen Sie den Verweis auf eine Folie über ihren Index.  
3. Fügen Sie ein [PictureFrame](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_picture_frame) zur Folie hinzu oder holen Sie es.  
4. Holen Sie die Hauptsequenz der Effekte.  
5. Fügen Sie einen Animationseffekt zum [PictureFrame](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_picture_frame) hinzu.  
6. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.  

Dieser C++‑Code zeigt, wie Sie den `Fly`‑Effekt auf einen Bildrahmen anwenden:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Bild laden, das zur Bildsammlung der Präsentation hinzugefügt werden soll
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Fügt der Folie einen Bildrahmen hinzu
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Ruft die Hauptsequenz der Folie ab.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Fügt dem Bildrahmen den Fly from Left-Animationseffekt hinzu
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Speichert die PPTX-Datei auf der Festplatte
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Animation auf eine Form anwenden**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation/).  
2. Holen Sie den Verweis auf eine Folie über ihren Index.  
3. Fügen Sie eine `rectangle`-[IAutoShape](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_auto_shape) hinzu.  
4. Fügen Sie eine `Bevel`-[IAutoShape](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_auto_shape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).  
5. Erstellen Sie eine Sequenz von Effekten auf der Abschrägungsform.  
6. Erstellen Sie einen benutzerdefinierten `UserPath`.  
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.  
8. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.  

Dieser C++‑Code zeigt, wie Sie den `PathFootball`‑Effekt (Pfad‑Football) auf eine Form anwenden:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionEffect.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

	// Der Pfad zum Dokumentverzeichnis.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Lädt die Präsentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Greift auf die Formsammlung der ausgewählten Folie zu
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Erstellt den PathFootball-Effekt für die vorhandene Form von Grund auf.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Fügt den PathFootball-Animationseffekt hinzu
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Erstellt eine Art „Button“.
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Erstellt eine Sequenz von Effekten für diesen Button.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Erstellt einen benutzerdefinierten Pfad. Unser Objekt wird erst bewegt, nachdem der Button geklickt wurde.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Fügt Befehle zum Bewegen hinzu, da der erstellte Pfad leer ist.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 // Schreibt die PPTX-Datei auf die Festplatte
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Animationseffekte, die einer Form zugewiesen wurden, abrufen**

Die folgenden Beispiele zeigen, wie Sie die Methode `GetEffectsByShape` aus der Schnittstelle [ISequence](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/isequence/) verwenden, um alle auf eine Form angewendeten Animationseffekte zu erhalten.

**Beispiel 1: Animationseffekte, die einer Form auf einer normalen Folie zugewiesen wurden, abrufen**

Zuvor haben Sie gelernt, wie man Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzufügt. Der folgende Beispielcode zeigt, wie Sie die Effekte der ersten Form auf der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` abrufen.

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Ruft die Hauptanimationssequenz der Folie ab.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Ruft die erste Form auf der ersten Folie ab.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Ruft die auf die Form angewendeten Animationseffekte ab.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Beispiel 2: Alle Animationseffekte abrufen, einschließlich der von Platzhaltern geerbten**

Wenn eine Form auf einer normalen Folie Platzhalter hat, die sich auf der Layout‑Folie und/oder der Master‑Folie befinden, und diesen Platzhaltern Animationseffekte hinzugefügt wurden, dann werden alle Effekte der Form während der Bildschirmpräsentation abgespielt, einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint‑Präsentationsdatei `sample.pptx` mit einer Folie, die nur eine Fußzeilenform mit dem Text "Made with Aspose.Slides" enthält und der Effekt **Random Bars** auf die Form angewendet wurde.

![Folien‑Form‑Animationseffekt](slide-shape-animation.png)

Angenommen, der Effekt **Split** ist auch auf den Fußzeilen‑Platzhalter der **Layout**‑Folie angewendet.

![Layout‑Form‑Animationseffekt](layout-shape-animation.png)

Und schließlich ist der Effekt **Fly In** auf den Fußzeilen‑Platzhalter der **Master**‑Folie angewendet.

![Master‑Form‑Animationseffekt](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie Sie die Methode `GetBasePlaceholder` aus der Schnittstelle [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/) verwenden, um auf die Form‑Platzhalter zuzugreifen und die Animationseffekte der Fußzeilenform zu erhalten, einschließlich der von den Platzhaltern auf Layout‑ und Master‑Folien geerbten.

```cpp
#include <DOM/Animation/IEffect.h>
#include <system/array.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};
```
```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Animationseffekte der Form auf der normalen Folie abrufen.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Animationseffekte des Platzhalters auf der Layout-Folie abrufen.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Animationseffekte des Platzhalters auf der Master-Folie abrufen.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Ausgabe:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Fly, Unten
Type: 134, subtype: 45            // Split, VerticalIn
Type: 126, subtype: 22            // RandomBars, Horizontal
```

## **Timing‑Eigenschaften von Animationseffekten ändern**

Aspose.Slides für C++ ermöglicht es Ihnen, die Timing‑Eigenschaften eines Animationseffekts zu ändern.

Dies ist das Animations‑Timing‑Fenster in Microsoft PowerPoint:

![Beispiel1_Bild](shape-animation.png)

Dies sind die Entsprechungen zwischen PowerPoint Timing und den Eigenschaften von [Effect.Timing](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- Die Dropdown‑Liste **Start** in PowerPoint Timing entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3).  
- PowerPoint Timing **Duration** entspricht der Eigenschaft [Effect.Timing.Duration](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation für einen Durchlauf benötigt.  
- PowerPoint Timing **Delay** entspricht der Eigenschaft [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b).  

So ändern Sie die Timing‑Eigenschaften des Effekts:

1. Wenden Sie die Animation an oder holen Sie den Animationseffekt.  
2. Setzen Sie neue Werte für die benötigten [Effect.Timing](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c)-Eigenschaften.  
3. Speichern Sie die geänderte PPTX‑Datei.  

Dieser C++‑Code demonstriert den Vorgang:

```c++
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Ruft die Hauptsequenz der Folie ab.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Ruft den ersten Effekt der Hauptsequenz ab.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Ändert den TriggerTyp des Effekts, sodass er bei Klick startet
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Ändert die Dauer des Effekts
effect->get_Timing()->set_Duration(3.f);

// Ändert die Triggerverzögerungszeit des Effekts
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Speichert die PPTX-Datei auf der Festplatte
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ton für Animationseffekt**

Aspose.Slides stellt diese Eigenschaften zur Verfügung, um mit Sounds in Animationseffekten zu arbeiten: 

- [set_Sound()](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/effect/set_sound/)  
- [set_StopPreviousSound()](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Einen Sound zu einem Animationseffekt hinzufügen**

Dieser C++‑Code zeigt, wie man einem Animationseffekt einen Sound hinzufügt und ihn stoppt, wenn der nächste Effekt beginnt:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System::IO;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Fügt Audio zur Audiosammlung der Präsentation hinzu
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ruft die Hauptsequenz der Folie ab.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Ruft den ersten Effekt der Hauptsequenz ab
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Überprüft, ob der Effekt keinen Sound hat
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Fügt dem ersten Effekt einen Sound hinzu
    firstEffect->set_Sound(effectSound);
}

// Ruft die erste interaktive Sequenz der Folie ab.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Setzt das Flag "Stop previous sound" für den Effekt
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Sound aus einem Animationseffekt extrahieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).  
2. Holen Sie den Folienverweis über den Index.  
3. Holen Sie die Hauptsequenz der Effekte.  
4. Extrahieren Sie das in [set_Sound()] eingebettete Sound‑Signal jedes Animationseffekts.  

Dieser C++‑Code zeigt, wie man den in einem Animationseffekt eingebetteten Sound extrahiert:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Nach der Animation**

Aspose.Slides für C++ ermöglicht es Ihnen, die **After animation**‑Eigenschaft eines Animationseffekts zu ändern.

Dies ist das Fenster für Animationseffekte und das erweiterte Menü in Microsoft PowerPoint:

![Beispiel1_Bild](shape-after-animation.png)

Die Dropdown‑Liste **After animation** in PowerPoint entspricht diesen Eigenschaften: 

- [set_AfterAnimationType()](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) – Eigenschaft, die den Typ der Nachanimation beschreibt:  
  * PowerPoint **More Colors** entspricht dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/afteranimationtype/);  
  * PowerPoint **Don't Dim** entspricht dem Typ [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/afteranimationtype/) (Standard‑Nachanimationstyp);  
  * PowerPoint **Hide After Animation** entspricht dem Typ [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/afteranimationtype/);  
  * PowerPoint **Hide on Next Mouse Click** entspricht dem Typ [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/afteranimationtype/);  
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) – Eigenschaft, die ein Farbschema für die Nachanimation definiert. Diese Eigenschaft funktioniert zusammen mit dem Typ [AfterAnimationType.Color]. Wenn Sie den Typ ändern, wird die Nachanimationsfarbe zurückgesetzt.  

Dieser C++‑Code zeigt, wie man einen Nachanimations‑Effekt ändert:

```c++
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IColorFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ruft den ersten Effekt der Hauptsequenz ab
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Ändert den Nachanimations-Typ zu Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Setzt die Nachanimations-Dimmfarbe
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Text animieren**

Aspose.Slides stellt diese Eigenschaften zur Verfügung, um mit dem *Animate text*‑Block eines Animationseffekts zu arbeiten: 

- [set_AnimateTextType()](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) – beschreibt den Textanimations‑Typ des Effekts. Der Text einer Form kann animiert werden:  
  * Alles auf einmal ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/animatetexttype/)‑Typ)  
  * Wortweise ([AnimateTextType.ByWord](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/animatetexttype/)‑Typ)  
  * Buchstabenweise ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/animatetexttype/)‑Typ)  
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) – legt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effekt‑Dauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.  

So können Sie die Eigenschaften *Effect Animate text* ändern:

1. Wenden Sie die Animation an oder holen Sie den Effekt.  
2. Setzen Sie die Eigenschaft [set_BuildType()](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itextanimation/set_buildtype/) auf den Wert [BuildType.AsOneObject](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/buildtype/), um den *By Paragraphs*‑Animationsmodus zu deaktivieren.  
3. Setzen Sie neue Werte für die Eigenschaften [set_AnimateTextType()](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) und [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) fest.  
4. Speichern Sie die geänderte PPTX‑Datei.  

Dieser C++‑Code demonstriert den Vorgang:

```c++
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ruft den ersten Effekt der Hauptsequenz ab
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Ändert den Textanimationstyp des Effekts zu "Als ein Objekt"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Ändert den Animations‑Texttyp des Effekts zu "Nach Wort"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Setzt die Verzögerung zwischen Wörtern auf 20% der Effektdauer
firstEffect->set_DelayBetweenTextParts(20.0f);

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

### Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?

[Export to HTML5](/slides/de/cpp/export-to-html5/) und aktivieren Sie die [Optionen](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/html5options/), die für die Animationen von [shape](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/html5options/set_animateshapes/) und [transition](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/html5options/set_animatetransitions/) verantwortlich sind. Reines HTML spielt Folienanimationen nicht ab, HTML5 jedoch.

### Wie wirkt sich das Ändern der Z‑Reihenfolge (Layer‑Reihenfolge) von Formen auf Animationen aus?

Animationen und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ von Erscheinen/Verschwinden, während die [z-order](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/get_zorderposition/) bestimmt, was was überlappt. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das generelle Verhalten von PowerPoint; das Modell von Aspose.Slides für Effekte und Formen folgt derselben Logik.)

### Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?

Im Allgemeinen werden [Animationen unterstützt](/slides/de/cpp/convert-powerpoint-to-video/), jedoch können seltene Fälle oder bestimmte Effekte anders wiedergegeben werden. Es wird empfohlen, die von Ihnen verwendeten Effekte und die Bibliotheksversion zu testen.