---
title: Form-Animation
type: docs
weight: 60
url: /cpp/shape-animation/
keywords: "PowerPoint-Animation, Animations-Effekt, Animation anwenden, PowerPoint-Präsentation, C++, CPP, Aspose.Slides für C++"
description: "PowerPoint-Animation in C++ anwenden"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](/slides/cpp/animated-charts/) angewendet werden können. Sie bringen Präsentationen oder deren Bestandteile zum Leben.

### **Warum Animationen in Präsentationen verwenden?**

Mit Animationen können Sie 

* den Informationsfluss steuern
* wichtige Punkte hervorheben
* das Interesse oder die Teilnahme Ihres Publikums steigern
* Inhalte leichter lesbar, verdaulich oder verarbeitbar machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet zahlreiche Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eintritt**, **Austritt**, **Betonung** und **Bewegungspfade**. 

### **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen zur Verfügung, die Sie benötigen, um mit Animationen im [Aspose.Slides.Animation](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) Namespace zu arbeiten,
* Aspose.Slides bietet über **150 Animationseffekte** unter der [EffectType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) Aufzählung. Diese Effekte sind im Wesentlichen die gleichen (oder äquivalenten) Effekte, die in PowerPoint verwendet werden.

## **Animation auf TextBox anwenden**

Aspose.Slides für C++ ermöglicht es Ihnen, eine Animation auf den Text in einer Form anzuwenden. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über deren Index.
3. Fügen Sie eine `Rechteck` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) hinzu. 
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) hinzu.
5. Holen Sie sich eine Hauptsequenz von Effekten.
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) hinzu. 
7. Setzen Sie die [TextAnimation.BuildType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) Eigenschaft auf den Wert aus der [BuildType Aufzählung](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Schreiben Sie die Präsentation auf die Festplatte als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie den `Fade`-Effekt auf AutoShape anwenden und die Textanimation auf den Wert *Nach 1. Ebene Absätzen* setzen:

```c++
// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Fügt eine neue AutoShape mit Text hinzu
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Erster Absatz \nZweiter Absatz \nDritter Absatz");

// Holen Sie sich die Hauptsequenz der Folie.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Fügt einen Fade-Animationseffekt zur Form hinzu
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animiert den Formtext nach 1. Ebene Absätzen
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Speichern Sie die PPTX-Datei auf der Festplatte
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph) anwenden. Siehe [**Animierter Text**](/slides/cpp/animated-text/).

{{% /alert %}} 

## **Animation auf PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über deren Index.
3. Fügen Sie einen [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) zur Folie hinzu oder erhalten Sie ihn. 
4. Holen Sie sich die Hauptsequenz von Effekten.
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) hinzu.
6. Schreiben Sie die Präsentation auf die Festplatte als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie den `Fly`-Effekt auf einen PictureFrame anwenden:

```c++
// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Laden Sie das Bild, das in die Präsentation Bildsammlung hinzugefügt werden soll
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Fügt dem Folien-Shape-Bild hinzu
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Holen Sie sich die Hauptsequenz der Folie.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Fügt einen Fly von links Animationseffekt zum Bildrahmen hinzu
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Speichern Sie die PPTX-Datei auf der Festplatte
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Animation auf Form anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über deren Index.
3. Fügen Sie eine `Rechteck` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) hinzu. 
4. Fügen Sie eine `Bevel` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).
5. Erstellen Sie eine Effektssequenz auf der Bevel-Form.
6. Erstellen Sie einen benutzerdefinierten `UserPath`.
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.
8. Schreiben Sie die Präsentation auf die Festplatte als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie den `PathFootball` (Fußballpfad) Effekt auf eine Form anwenden:

```c++
	// Der Pfad zum Dokumentverzeichnis.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Lädt die Präsentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Greift auf die Sammlung der Shapes für die ausgewählte Folie zu
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Erstellt den PathFootball-Effekt für eine bestehende Form von Grund auf.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animierte TextBox");

	// Fügt den PathFootBall Animationseffekt hinzu
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Erstellt eine Art "Taste".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Erstellt eine Sequenz von Effekten für diesen Knopf.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Erstellt einen benutzerdefinierten Benutzerpfad. Unser Objekt wird nur nach einem Klick auf den Knopf bewegt.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Fügt Befehle für die Bewegung hinzu, da der erstellte Pfad leer ist.
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
	 
	 //Schreibt die PPTX-Datei auf die Festplatte
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Die auf eine Form angewendeten Animationseffekte abrufen**

Sie könnten entscheiden, alle auf eine bestimmte Form angewendeten Animationseffekte herauszufinden. 

Dieser C++-Code zeigt Ihnen, wie Sie alle auf eine spezifische Form angewendeten Effekte abrufen:

```c++
// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

System::SharedPtr<ISlide> firstSlide = pres->get_Slides()->idx_get(0);

// Holen Sie sich die Hauptsequenz der Folie.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Holen Sie sich die erste Form auf der Folie.
System::SharedPtr<IShape> shape = firstSlide->get_Shapes()->idx_get(0);

// Holen Sie sich alle Animationseffekte, die auf der Form angewendet wurden.
System::ArrayPtr<System::SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    System::Console::WriteLine(System::String(u"Die Form ") + shape->get_Name() + u" hat " + shapeEffects->get_Length() + u" Animationseffekte.");
}
```

## **Ändern der zeitlichen Eigenschaften von Animationseffekten**

Aspose.Slides für C++ ermöglicht es Ihnen, die Zeitwerte eines Animationseffekts zu ändern.

Dies ist das animierte Timing-Fenster in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Dies sind die Entsprechungen zwischen PowerPoint Timing und [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) Eigenschaften:

- PowerPoint Timing **Start** Dropdown-Liste entspricht der [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) Eigenschaft. 
- PowerPoint Timing **Dauer** entspricht der [Effect.Timing.Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) Eigenschaft. Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die benötigt wird, um einen Zyklus der Animation abzuschließen. 
- PowerPoint Timing **Verzögerung** entspricht der [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) Eigenschaft. 

So ändern Sie die Effekt Timing-Eigenschaften:

1. [Wenden Sie an](#apply-animation-to-shape) oder abrufen Sie den Animationseffekt.
2. Setzen Sie neue Werte für die [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) Eigenschaften, die Sie benötigen. 
3. Speichern Sie die modifizierte PPTX-Datei.

Dieser C++-Code demonstriert die Operation:

```c++
// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Holen Sie sich die Hauptsequenz der Folie.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Holen Sie sich den ersten Effekt der Hauptsequenz.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Ändert den TriggerType des Effekts, sodass er bei Klick startet
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Ändert die Dauer des Effekts
effect->get_Timing()->set_Duration(3.f);

// Ändert die TriggerDelayTime des Effekts
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Speichert die PPTX-Datei auf der Festplatte
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Animationseffekt-Sound**

Aspose.Slides bietet diese Eigenschaften, um Ihnen die Arbeit mit Sounds in Animationseffekten zu ermöglichen: 

- [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Animationseffekt-Sound hinzufügen**

Dieser C++-Code zeigt Ihnen, wie Sie einen Sound zu einem Animationseffekt hinzufügen und diesen anhalten, wenn der nächste Effekt beginnt:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Fügt Audio zur Präsentations-Audiokolllektion hinzu
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Holen Sie sich die Hauptsequenz der Folie.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Holen Sie sich den ersten Effekt der Hauptsequenz
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Prüft den Effekt auf "Kein Sound"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Fügt Sound für den ersten Effekt hinzu
    firstEffect->set_Sound(effectSound);
}

// Holen Sie sich die erste interaktive Sequenz der Folie.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Setzt das Flag "Vorherigen Sound stoppen" für den Effekt
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Animationseffekt-Sound extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über deren Index. 
3. Holen Sie sich die Hauptsequenz der Effekte. 
4. Extrahieren Sie das [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) , das in jeden Animationseffekt eingebettet ist. 

Dieser C++-Code zeigt Ihnen, wie Sie den in einem Animationseffekt eingebetteten Sound extrahieren:

```c++
// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Holen Sie sich die Hauptsequenz der Folie.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Nach Animation**

Aspose.Slides für C++ ermöglicht es Ihnen, die Nach-Animations-Eigenschaft eines Animationseffekts zu ändern.

Dies ist das Fenster für die Animationseffekte und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Die PowerPoint Effekt **Nach der Animation** Dropdown-Liste entspricht diesen Eigenschaften: 

- [set_AfterAnimationType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) Eigenschaft, die den Nach-Animationstyp beschreibt :
  * PowerPoint **Weitere Farben** entspricht dem [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) Typ;
  * PowerPoint **Nicht dimmen** Listenelement entspricht dem [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) Typ (Standard-Nach-Animationstyp);
  * PowerPoint **Nach der Animation ausblenden** Element entspricht dem [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) Typ;
  * PowerPoint **Nach dem nächsten Mausklick ausblenden** Listenelement entspricht dem [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) Typ;
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) Eigenschaft, die ein Nach-Animationsfarbformat definiert. Diese Eigenschaft funktioniert in Verbindung mit dem [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) Typ. Wenn Sie den Typ auf einen anderen ändern, wird die Nachanimationsfarbe gelöscht.

Dieser C++-Code zeigt Ihnen, wie Sie einen Nachanimationseffekt ändern:

```c++
// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Holen Sie sich den ersten Effekt der Hauptsequenz
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Ändert den Nachanimations-Typ zu Farbe
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Setzt die Nachanimations-Dimmfarbe
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Text animieren**

Aspose.Slides bietet diese Eigenschaften, um Ihnen die Arbeit mit dem *Text animieren*-Block eines Animationseffekts zu ermöglichen:

- [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) die einen animierten Texttyp des Effekts beschreibt. Der Text der Form kann animiert werden:
  - Alles auf einmal ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) Typ)
  - Nach Wort ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) Typ)
  - Nach Buchstabe ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) Typ)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) legt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effekt-Dauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.

So ändern Sie die Effekt-Animationstext-Eigenschaften:

1. [Wenden Sie an](#apply-animation-to-shape) oder abrufen Sie den Animationseffekt.
2. Setzen Sie die [set_BuildType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) Eigenschaft auf den Wert [BuildType.AsOneObject](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/) um den *Nach Absätzen* Animationsmodus auszuschalten.
3. Setzen Sie neue Werte für die [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) und die [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) Eigenschaften.
4. Speichern Sie die modifizierte PPTX-Datei.

Dieser C++-Code demonstriert die Operation:

```c++
// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Holen Sie sich den ersten Effekt der Hauptsequenz
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Ändert den Effekt Textanimations-Typ auf "Als ein Objekt"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Ändert den Effekt Animierten Texttyp auf "Nach Wort"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Setzt die Verzögerung zwischen Wörtern auf 20 % der Effekt-Dauer
firstEffect->set_DelayBetweenTextParts(20.0f);

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```