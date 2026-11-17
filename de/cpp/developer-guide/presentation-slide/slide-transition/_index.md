---
title: Folienübergänge in Präsentationen mit C++ verwalten
linktitle: Folienübergang
type: docs
weight: 80
url: /de/cpp/slide-transition/
keywords:
- Folienübergang
- Folienübergang hinzufügen
- Folienübergang anwenden
- Erweiterter Folienübergang
- Morph‑Übergang
- Übergangstyp
- Übergangseffekt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Folienübergänge anwenden, die automatische Folienweitergabe konfigurieren und Morph‑ sowie andere Übergangseffekte mit Aspose.Slides für C++ anpassen."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Bildschirmpräsentation angezeigt werden. Mit Aspose.Slides für C++ können Sie für jede Folie einen Übergangseffekt auswählen, den Fortschritt per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen anpassen. Dieser Artikel verwendet C++‑Beispiele, um Übergänge anzuwenden, genaue Übergangsdauern festzulegen, die Folienzeit zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erzeugen. Die Beispiele zeigen außerdem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse und greifen über [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) auf die Übergangseinstellungen einer Folie zu. Rufen Sie [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) mit einem Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) auf und speichern Sie anschließend die Präsentation.

Das folgende Beispiel wendet einen Circle‑Übergang auf die erste Folie und einen Comb‑Übergang auf die zweite an. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Wheel‑Übergang**

Die Methode [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) von [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) steuert die Anzahl der radialen Sektoren, die die Ziel‑Folie sichtbar machen. Rufen Sie [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) mit Wheel aus [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) auf, bevor Sie [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) als [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) abrufen.

Dieses Beispiel erstellt zwei identische Folienpaare: eine schwarze Folie, gefolgt von einer Folie mit einem goldenen Rechteck. Die Ziel‑Folien verwenden Spoke‑Zahlen von 1 bzw. 8, mit derselben Geschwindigkeit, die über [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) festgelegt wird, und einer expliziten Dauer von 8.000 Millisekunden, die über [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) gesetzt wird, um den Unterschied leicht zu erkennen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/IWheelTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <cstdint>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();
auto slideWidth = presentation->get_SlideSize()->get_Size().get_Width();
auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();

auto blackSlide = presentation->get_Slide(0);
blackSlide->get_Shapes()->Clear();
blackSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
blackSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
blackSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

auto destinationSlide = presentation->get_Slides()->AddClone(blackSlide);
auto rectangle = destinationSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, slideWidth, slideHeight);
rectangle->get_FillFormat()->set_FillType(FillType::Solid);
rectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gold());
rectangle->get_TextFrame()->set_Text(u"Wheel transition");

presentation->get_Slides()->AddClone(blackSlide);
presentation->get_Slides()->AddClone(destinationSlide);

const uint32_t spokeCounts[] = { 1, 8 };
for (auto i = 0; i < 2; i++)
{
    auto transition = presentation->get_Slide(i * 2 + 1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Wheel);
    auto wheelTransition = ExplicitCast<IWheelTransition>(transition->get_Value());
    wheelTransition->set_Spokes(spokeCounts[i]);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(8000);
}

presentation->Save(u"wheel-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Öffnen Sie die Ausgabedatei in PowerPoint und starten Sie die Bildschirmpräsentation. Wechseln Sie von Folie 1 zu Folie 2 und anschließend von Folie 3 zu Folie 4. In der PowerPoint‑Wiedergabe zeigt die überprüfte Spoke‑Anzahl von 1 die Folie mit einem einzigen, im Uhrzeigersinn verlaufenden Durchlauf; die überprüfte Anzahl von 8 zeigt sie durch acht radiale Sektoren gleichzeitig. Der Zielinhalt und die Übergangszeit sind identisch, sodass sich nur die Anzahl der Enthüllungssektoren unterscheidet.

## **Erweiterten Folienübergang hinzufügen**

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) ermöglicht es dem Betrachter, durch Klicken der Maus weiterzugehen.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) aktiviert die automatische Weitergabe.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) legt die Verzögerung vor der automatischen Weitergabe in Millisekunden fest.

Aktivieren Sie sowohl die Klick‑ als auch die zeitgesteuerte Weitergabe, damit der Betrachter entweder per Klick weitergehen oder auf den Timer warten kann. Um nur den Timer zu verwenden, rufen Sie [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) mit `false` auf. Die Verzögerung bestimmt, wann die Präsentation weitergeht; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert die automatische Weitergabe nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls weiterleiten. Verwenden Sie eine `input.pptx`‑Datei mit mindestens drei Folien.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

Um zu prüfen, ob die zeitgesteuerte Weitergabe aktiviert ist, rufen Sie [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/) auf. Ein gespeicherter Verzögerungswert allein zeigt nicht an, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, gibt jeden aktivierten Timer aus und deaktiviert die automatische Weitergabe für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien werden Mausklicks aktiviert und die aktualisierten Einstellungen gespeichert.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Übergangszeit präzise steuern**

Verwenden Sie [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/), um die genaue Länge eines Übergangseffekts in Millisekunden festzulegen. Die [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/)-Methode der Folie stellt diese Einstellungen über [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/) bereit:

| Method | Zweck |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | Legt die Dauer des eigentlichen Übergangseffekts in Millisekunden fest. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Legt die Verzögerung fest, bevor die Folie automatisch weitergeht, in Millisekunden. Rufen Sie [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) mit `true` auf, um diesen Timer zu aktivieren. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium oder Fast. Sie wird verwendet, wenn keine exakte Dauer angegeben ist. |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) steuert nur den Übergangseffekt; sie bestimmt nicht, wie lange die Folie sichtbar bleibt. Konfigurieren Sie die Verzögerung für die automatische Weitergabe separat. Wenn keine explizite Dauer gesetzt ist, ermittelt Aspose.Slides die Effektdauer aus dem Übergangstyp und dem von [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) zurückgegebenen Wert.

<!-- visual-explanation:slide-transition:start -->
[![Separate Balken zeigen die 750‑ms‑Übergangsdauer und die 5.000‑ms‑Einstellung für die automatische Weitergabe.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Das gemeinsame Beispiel weist jeder Folie einen 750‑ms‑Fade‑Übergang zu und aktiviert separat die automatische Weitergabe nach 5.000 ms. Die Übergangsdauer steuert den Effekt; die Weitergabe bestimmt, wann die Folie verlassen wird. Diese Balken sind schematische Einstellungen, kein gemessener kombinierter Zeitverlauf.*
<!-- visual-explanation:slide-transition:end -->

### **Für jede Folie dieselbe Dauer anwenden**

Für ein gleichmäßiges Timing wenden Sie denselben Effekt und dieselbe exakte Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/), und gibt jedem Übergang eine Dauer von 750 Millisekunden. Es aktiviert separat die automatische Weitergabe nach 5.000 Millisekunden und deaktiviert die Weitergabe per Mausklick, dann speichert es das Ergebnis als PPTX.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // Automatische Weitergabe unabhängig von der Effektdauer konfigurieren.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Unterschiedliche Dauern für einzelne Folien festlegen**

Verschiedene Folien können unterschiedliche Effektdauern verwenden. Zum Beispiel einen kurzen Übergang für eine Titelfolie und einen längeren Übergang für eine Abschnittseinleitung. Dieses Beispiel setzt 500 Millisekunden für die erste Folie und 1.200 Millisekunden für die zweite. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **Übergänge mit animierter Ausgabe koordinieren**

Beim Erstellen eines [animierten GIF](/slides/de/cpp/convert-powerpoint-to-animated-gif/), einer [HTML5‑Präsentation](/slides/de/cpp/export-to-html5/) oder eines [Videos](/slides/de/cpp/convert-powerpoint-to-video/) sollten Sie vor dem Export exakte Übergangsdauern festlegen, um das gewünschte Tempo zu erreichen. Verwenden Sie beispielsweise ein 600‑Millisekunden‑Fade zwischen Szenen und passen Sie die Verzögerung für die Weitergabe jeder Folie separat an, um Zeit für deren Erzählung oder Inhalt zu lassen.

Für GIF und Video koordinieren Sie die Ausgabebildrate mit der Effektdauer: 600 Millisekunden entsprechen 18 Frames bei 30 Frames pro Sekunde. In HTML5 aktivieren Sie animierte Übergänge in den Exporteinstellungen. Prüfen Sie die vom gewählten Exportformat unterstützten Effekte und Timing‑Optionen und zeigen Sie eine Vorschau des Outputs, um die Synchronisation zu bestätigen.

### **Vorhandene Übergangsdauer auslesen**

Rufen Sie [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) auf, bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Ein Wert von `-1` bedeutet, dass keine explizite Dauer festgelegt ist; ein nichtnegativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides verwendet den Übergangstyp und den von [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) zurückgegebenen Wert, um diese Dauer zu bestimmen. Das Festlegen eines Übergangstyps kann eine Dauer initialisieren, daher sollten Sie zuerst die ursprünglichen Einstellungen prüfen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Morph‑Übergang**

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erzeugen, klonen Sie eine Folie, verschieben oder skalieren ein Objekt auf dem Klon und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhält der Übergang die entsprechenden Objekte, die zwischen ihrem ursprünglichen und modifizierten Zustand animiert werden.

Das folgende Beispiel erstellt eine Folie mit einem Text‑Rechteck, klont die Folie und ändert Position und Größe des Rechtecks im Klon. Anschließend wählt es Morph aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) für die zweite Folie. Öffnen Sie die gespeicherte Datei in einem Präsentationsviewer, der Morph unterstützt, um den Effekt während einer Bildschirmpräsentation zu sehen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Morph‑Übergangstypen**

Die Aufzählung [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) steuert, wie Morph Inhalte zuordnet und animiert:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) behandelt jede Form als ein gesamtes Objekt.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) animiert Text, indem nach Möglichkeit Wörter abgeglichen werden.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) animiert Text, indem nach Möglichkeit Zeichen abgeglichen werden.

Rufen Sie [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) mit Morph auf, bevor Sie [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) aufrufen. Der zurückgegebene Wert liefert dann die Schnittstelle [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/), deren Methode [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) den Abgleichmodus auswählt.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Übergangseffekte festlegen**

Einige Übergänge bieten zusätzliche Optionen, z. B. Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom gewählten Übergangstyp ab. Legen Sie zuerst den Typ fest und verwenden Sie anschließend die passende Schnittstelle, die von [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) zurückgegeben wird.

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Es ruft [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) mit `true` über [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) auf, sodass der Übergang von einem schwarzen Bildschirm startet.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Verwenden Sie bevorzugt [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/), wenn Sie eine genaue Effektdauer in Millisekunden benötigen. Nutzen Sie [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/), wenn eine vordefinierte Kategorie aus [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) – Slow, Medium oder Fast – ausreicht und keine explizite Dauer festgelegt ist. Diese Einstellungen steuern den Übergangseffekt unabhängig von der Verzögerung der automatischen Weitergabe.

**Kann ich einem Übergang Audio hinzufügen und es wiederholen lassen?**

Ja. Weisen Sie eingebettetes Audio mit [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/) zu, rufen Sie [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) mit StartSound aus der Aufzählung [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) auf und aktivieren Sie das Schleifen mit [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/). Das Audio wiederholt sich, bis das nächste Tonelement in der Bildschirmpräsentation erreicht wird.

**Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Iterieren Sie über die von der Präsentation über die Methode [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) zurückgegebene Sammlung und rufen Sie für den Übergang jeder Folie [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) mit demselben Wert auf. Setzen Sie sämtliche Timing‑ und Effektoptionen im selben Durchlauf, um das Verhalten über alle Folien hinweg konsistent zu halten.

**Wie kann ich prüfen, welcher Übergang aktuell für eine Folie eingestellt ist?**

Rufen Sie [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) auf dem von der Folie über die Methode [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) zurückgegebenen Übergang auf. Sie liefert einen Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/); None bedeutet, dass kein Übergangseffekt angewendet wurde.