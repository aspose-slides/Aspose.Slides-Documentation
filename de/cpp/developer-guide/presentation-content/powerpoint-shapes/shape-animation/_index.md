---
title: Shape-Animationen in Präsentationen mit C++ anwenden
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
- Effektton
- Animation anwenden
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Shape-Animationen in PowerPoint-Präsentationen mit Aspose.Slides für C++ erstellen und anpassen. Heben Sie sich ab!"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](/slides/de/cpp/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben. 

## **Warum Animationen in Präsentationen verwenden?**

* den Informationsfluss steuern
* wichtige Punkte hervorheben
* das Interesse oder die Beteiligung Ihres Publikums erhöhen
* Inhalte leichter lesbar, nachvollziehbar oder verarbeitbar machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet zahlreiche Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungspfade**. 

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) zu arbeiten,  
* Aspose.Slides bietet über **150 Animationseffekte** im [EffectType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) Aufzählungstyp. Diese Effekte sind im Wesentlichen dieselben (oder äquivalenten) Effekte, die in PowerPoint verwendet werden. 

## **Animation auf ein Textfeld anwenden**

Aspose.Slides für C++ ermöglicht es Ihnen, eine Animation auf den Text in einer Form anzuwenden. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) Klasse.  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) hinzu.  
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) hinzu.  
5. Rufen Sie die Hauptsequenz der Effekte ab.  
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) hinzu.  
7. Setzen Sie die Eigenschaft [TextAnimation.BuildType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) auf den Wert aus der [BuildType Enumeration](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).  
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Dieser C++-Code zeigt, wie Sie den `Fade`-Effekt auf AutoShape anwenden und die Textanimation auf den *By 1st Level Paragraphs*-Wert setzen:
```c++
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Fügt eine neue AutoShape mit Text hinzu
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Ruft die Hauptsequenz der Folie ab.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Fügt dem Shape den Fade-Animationseffekt hinzu
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animiert den Shape-Text nach Absätzen der ersten Ebene
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Speichert die PPTX-Datei auf dem Datenträger
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert color="primary"  %}} 

Zusätzlich zur Anwendung von Animationen auf Text können Sie Animationen auch auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph) anwenden. Siehe **Animierter Text**[/slides/cpp/animated-text/].
{{% /alert %}} 

## **Animation auf ein PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) Klasse.  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Fügen Sie ein [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) hinzu oder rufen Sie es ab.  
4. Rufen Sie die Hauptsequenz der Effekte ab.  
5. Fügen Sie einen Animationseffekt zum [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) hinzu.  
6. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Dieser C++-Code zeigt, wie Sie den `Fly`-Effekt auf einen Bildrahmen anwenden:
```c++
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Bild laden, das zur Bildsammlung der Präsentation hinzugefügt wird
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Fügt der Folie einen Bildrahmen hinzu
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Ruft die Hauptsequenz der Folie ab.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Fügt dem Bildrahmen den Fly-from-Left-Animationseffekt hinzu
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Speichert die PPTX-Datei auf dem Datenträger
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Animation auf eine Form anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) Klasse.  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) hinzu.  
4. Fügen Sie ein `Bevel` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).  
5. Erstellen Sie eine Sequenz von Effekten für die Bevel-Form.  
6. Erstellen Sie einen benutzerdefinierten `UserPath`.  
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.  
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Dieser C++-Code zeigt, wie Sie den `PathFootball` (Pfad-Football)-Effekt auf eine Form anwenden:
```c++
	// Der Pfad zum Dokumentverzeichnis.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Lädt die Präsentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Greift auf die Formen‑Sammlung der ausgewählten Folie zu
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Erstellt den PathFootball‑Effekt für die vorhandene Form von Grund auf.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Fügt den PathFootBall‑Animationseffekt hinzu
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Erstellt eine Art "button".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Erstellt eine Sequenz von Effekten für diese Schaltfläche.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Erstellt einen benutzerdefinierten Pfad. Unser Objekt wird nur bewegt, nachdem die Schaltfläche geklickt wurde.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Fügt Befehle zum Bewegen hinzu, da der erstellte Pfad leer ist.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	//SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
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


## **Die auf eine Form angewendeten Animationseffekte abrufen**

Die folgenden Beispiele zeigen, wie Sie die Methode `GetEffectsByShape` aus dem [ISequence](https://reference.aspose.com/slides/cpp/aspose.slides.animation/isequence/) Interface verwenden, um alle auf eine Form angewendeten Animationseffekte zu erhalten.

**Beispiel 1: Animationseffekte abrufen, die auf eine Form einer normalen Folie angewendet wurden**

Zuvor haben Sie gelernt, wie man Animationseffekte zu Formen in PowerPoint-Präsentationen hinzufügt. Der folgende Beispielcode zeigt, wie Sie die Effekte abrufen, die auf die erste Form der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendet wurden.
```c++
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Ermittelt die Hauptanimationssequenz der Folie.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Ermittelt die erste Form auf der ersten Folie.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Ermittelt die auf die Form angewendeten Animationseffekte.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```


**Beispiel 2: Alle Animationseffekte abrufen, einschließlich der von Platzhaltern geerbten**

Wenn eine Form auf einer normalen Folie Platzhalter hat, die sich auf der Layout‑Folie und/oder Master‑Folie befinden, und diesen Platzhaltern Animationseffekte zugewiesen wurden, dann werden alle Effekte der Form während der Bildschirmanzeige abgespielt, einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint-Präsentationsdatei `sample.pptx` mit einer Folie, die nur eine Fußzeilen‑Form mit dem Text „Made with Aspose.Slides“ enthält und der **Random Bars**‑Effekt auf die Form angewendet wurde.

![Folienform-Animationseffekt](slide-shape-animation.png)

Angenommen, der **Split**‑Effekt ist auf den Fußzeilen‑Platzhalter der **Layout**‑Folientyp angewendet.

![Layout‑Form‑Animationseffekt](layout-shape-animation.png)

Und schließlich ist der **Fly In**‑Effekt auf den Fußzeilen‑Platzhalter der **Master**‑Folientyp angewendet.

![Master‑Form‑Animationseffekt](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie Sie die Methode `GetBasePlaceholder` aus dem [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) Interface verwenden, um die Form‑Platzhalter zuzugreifen und die auf die Fußzeilen‑Form angewendeten Animationseffekte zu erhalten, einschließlich der von Platzhaltern auf Layout‑ und Master‑Folien geerbten.
```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```

```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Get animation effects of the shape on the normal slide.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
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
Type: 47, subtype: 2              // Flug, Unten
Type: 134, subtype: 45            // Split, VertikalEin
Type: 126, subtype: 22            // ZufälligeBalken, Horizontal
```


## **Timing‑Eigenschaften von Animationseffekten ändern**

Aspose.Slides für C++ ermöglicht das Ändern der Timing‑Eigenschaften eines Animationseffekts.

Dies ist das Animations‑Timing‑Paneel in Microsoft PowerPoint:

![Animations‑Timing‑Beispiel](shape-animation.png)

Dies sind die Entsprechungen zwischen PowerPoint‑Timing und den Eigenschaften von [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- Die Dropdown‑Liste **Start** in PowerPoint‑Timing entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3).  
- Die Dropdown‑Liste **Duration** in PowerPoint‑Timing entspricht der Eigenschaft [Effect.Timing.Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). Die Dauer eines Effekts (in Sekunden) ist die Gesamtzeit, die der Effekt für einen Durchlauf benötigt.  
- Die Dropdown‑Liste **Delay** in PowerPoint‑Timing entspricht der Eigenschaft [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b).  

So ändern Sie die Eigenschaften des Effect‑Timings:

1. [Anwenden](#apply-animation-to-shape) oder holen Sie den Animationseffekt.  
2. Setzen Sie neue Werte für die benötigten [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) Eigenschaften.  
3. Speichern Sie die geänderte PPTX‑Datei.  

Dieser C++‑Code demonstriert die Vorgehensweise:
```c++
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Ermittelt die Hauptsequenz der Folie.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Ermittelt den ersten Effekt der Hauptsequenz.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Ändert den TriggerType des Effekts, sodass er bei Klick startet
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Ändert die Dauer des Effekts
effect->get_Timing()->set_Duration(3.f);

// Ändert die Triggerverzögerungszeit des Effekts
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Speichert die PPTX-Datei auf dem Datenträger
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Sound für Animationseffekte**

Aspose.Slides stellt diese Eigenschaften bereit, um mit Sounds in Animationseffekten zu arbeiten: 

- [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/)  
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Sound zu einem Animationseffekt hinzufügen**

Dieser C++‑Code zeigt, wie Sie einen Sound zu einem Animationseffekt hinzufügen und diesen stoppen, wenn der nächste Effekt beginnt:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Fügt Audio zur Audiosammlung der Präsentation hinzu
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ermittelt die Hauptsequenz der Folie.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Ermittelt den ersten Effekt der Hauptsequenz
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Überprüft, ob der Effekt keinen Sound hat
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Fügt dem ersten Effekt einen Sound hinzu
    firstEffect->set_Sound(effectSound);
}

// Ermittelt die erste interaktive Sequenz der Folie.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Setzt das Flag "Stop previous sound" für den Effekt
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```


### **Sound aus einem Animationseffekt extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Rufen Sie die Hauptsequenz der Effekte ab.  
4. Extrahieren Sie das in jeden Animationseffekt eingebettete [set_Sound()]().  

Dieser C++‑Code zeigt, wie Sie den in einen Animationseffekt eingebetteten Sound extrahieren:
```c++
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Ruft die Hauptsequenz der Folie ab.
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

Aspose.Slides für C++ ermöglicht das Ändern der Nach‑Animation‑Eigenschaft eines Animationseffekts.

![Nach‑Animation‑Beispiel](shape-after-animation.png)

Die Dropdown‑Liste **After animation** in PowerPoint‑Effekt entspricht diesen Eigenschaften:

- Die Eigenschaft [set_AfterAnimationType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) beschreibt den Nach‑Animation‑Typ:
  * PowerPoint **More Colors** entspricht dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/);  
  * PowerPoint **Don't Dim** entspricht dem Typ [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) (Standard‑Nach‑Animation‑Typ);  
  * PowerPoint **Hide After Animation** entspricht dem Typ [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/);  
  * PowerPoint **Hide on Next Mouse Click** entspricht dem Typ [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/);  

- Die Eigenschaft [set_AfterAnimationColor()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) definiert ein Nach‑Animation‑Farbformat. Diese Eigenschaft arbeitet zusammen mit dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/). Wenn Sie den Typ zu einem anderen ändern, wird die Nach‑Animationsfarbe zurückgesetzt.

Dieser C++‑Code zeigt, wie Sie einen Nach‑Animation‑Effekt ändern:
```c++
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ermittelt den ersten Effekt der Hauptsequenz
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Ändert den Nachanimationstyp auf Farbe
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Setzt die Dim‑Farbe der Nachanimation
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```


## **Text animieren**

Aspose.Slides stellt diese Eigenschaften bereit, um mit dem *Animate text*‑Block eines Animationseffekts zu arbeiten:

- [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) beschreibt den Typ der Textanimation des Effekts. Der Text einer Form kann animiert werden:
  - Alle gleichzeitig ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) Typ)  
  - Wortweise ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) Typ)  
  - Buchstabenweise ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) Typ)  
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) legt eine Verzögerung zwischen den animierten Textteilen (Wörter oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effekt‑Dauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.  

So können Sie die Eigenschaften der Effect‑Animate‑Text‑Funktion ändern:

1. [Anwenden](#apply-animation-to-shape) oder holen Sie den Animationseffekt.  
2. Setzen Sie die Eigenschaft [set_BuildType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) auf den Wert [BuildType.AsOneObject](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/), um den *By Paragraphs*‑Animationsmodus zu deaktivieren.  
3. Setzen Sie neue Werte für die Eigenschaften [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) und [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).  
4. Speichern Sie die geänderte PPTX‑Datei.  

Dieser C++‑Code demonstriert die Vorgehensweise:
```c++
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ermittelt den ersten Effekt der Hauptsequenz
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Ändert den Textanimations‑Typ des Effekts zu "Als ein Objekt"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Ändert den Animations‑Text‑Typ des Effekts zu "Wortweise"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Setzt die Verzögerung zwischen Wörtern auf 20% der Effektdauer
firstEffect->set_DelayBetweenTextParts(20.0f);

// Schreibt die PPTX‑Datei auf die Festplatte
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?**

[Export to HTML5](/slides/de/cpp/export-to-html5/) und aktivieren Sie die [Optionen](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) für [shape](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) und [transition](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) Animationen. Reines HTML spielt Folienanimationen nicht ab, HTML5 hingegen schon.

**Wie beeinflusst das Ändern der Z‑Reihenfolge (Ebenenreihenfolge) von Formen die Animation?**

Animationen und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erschienen‑/Verschwindens, während die [z-order](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_zorderposition/) bestimmt, was was überdeckt. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das generelle Verhalten von PowerPoint; das Aspose.Slides‑Modell für Effekte und Formen folgt derselben Logik.)

**Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**

Im Allgemeinen werden [Animationen unterstützt](/slides/de/cpp/convert-powerpoint-to-video/), aber seltene Fälle oder spezifische Effekte können anders gerendert werden. Es wird empfohlen, die von Ihnen genutzten Effekte und die Bibliotheksversion zu testen.