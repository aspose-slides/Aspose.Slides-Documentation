---
title: Verwalten von Folienübergängen in Präsentationen mit C++
linktitle: Folienübergang
type: docs
weight: 80
url: /de/cpp/slide-transition/
keywords:
- Folienübergang
- Folienübergang hinzufügen
- Folienübergang anwenden
- erweiterter Folienübergang
- Morph‑Übergang
- Übergangstyp
- Übergangseffekt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Folienübergänge anwenden, automatisches Voranschreiten der Folien konfigurieren und Morph sowie andere Übergangseffekte mit Aspose.Slides für C++ anpassen."
---
## **Übersicht**

Folienübergänge bestimmen, wie Folien während einer Bildschirmpräsentation erscheinen. Mit Aspose.Slides for C++ können Sie für jede Folie einen Übergangseffekt auswählen, den Fortschritt per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen für einen Effekt anpassen. Dieser Artikel verwendet C++‑Beispiele, um Übergänge anzuwenden, exakte Übergangsdauern festzulegen, Folienzeiten zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen außerdem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse und greifen über [get_SlideShowTransition](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) auf die Übergangseinstellungen einer Folie zu. Rufen Sie [set_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_type/) mit einem Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/transitiontype/) auf und speichern Sie anschließend die Präsentation.

Im folgenden Beispiel wird ein Circle‑Übergang auf die erste Folie und ein Comb‑Übergang auf die zweite Folie angewendet. Verwenden Sie eine Datei `input.pptx` mit mindestens zwei Folien.

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

## **Erweiterten Folienübergang hinzufügen**

Sie können konfigurieren, wie lange eine Folie auf dem Bildschirm bleibt und ob ein Mausklick die Präsentation voranbringt. Die folgenden Methoden steuern dieses Verhalten:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) ermöglicht das Voranschreiten durch Mausklick.
- [set_AdvanceAfter](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_advanceafter/) aktiviert das automatische Voranschreiten.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) legt die Verzögerung vor dem automatischen Voranschreiten in Millisekunden fest.

Aktivieren Sie sowohl Klick‑ als auch Zeit‑Fortschritt, damit der Betrachter entweder mit einem Klick weitergehen oder auf den Timer warten kann. Um nur den Timer zu verwenden, rufen Sie [set_AdvanceOnClick](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) mit `false` auf. Die Verzögerung steuert, wann die Präsentation fortschreitet; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert das automatische Voranschreiten nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls voranbringen. Verwenden Sie eine Datei `input.pptx` mit mindestens drei Folien.

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

Um zu prüfen, ob das zeitgesteuerte Voranschreiten aktiviert ist, rufen Sie [get_AdvanceAfter](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/get_advanceafter/) auf. Eine gespeicherte Verzögerung allein zeigt nicht an, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, meldet jeden aktivierten Timer und deaktiviert das automatische Voranschreiten für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien wird der Mausklick wieder aktiviert und die aktualisierten Einstellungen werden gespeichert.

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

Verwenden Sie [set_Duration](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_duration/), um die exakte Länge eines Übergangseffekts in Millisekunden festzulegen. Die Methode [get_SlideShowTransition](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) der Folie gibt diese Einstellungen über [ISlideShowTransition](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/) frei:

| Methode | Zweck |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_duration/) | Legt die Dauer des eigentlichen Übergangseffekts in Millisekunden fest. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Legt die Verzögerung fest, bevor die Folie automatisch voranschreitet, in Millisekunden. Rufen Sie [set_AdvanceAfter](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_advanceafter/) mit `true` auf, um diesen Timer zu aktivieren. |
| [set_Speed](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_speed/) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium oder Fast. Sie wird verwendet, wenn keine exakte Dauer angegeben wird. |

[set_Duration](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_duration/) steuert nur den Übergangseffekt; sie bestimmt nicht, wie lange die Folie sichtbar bleibt. Konfigurieren Sie die Verzögerung für das automatische Voranschreiten separat. Wenn keine explizite Dauer gesetzt ist, ermittelt Aspose.Slides die Effektdauer aus dem Übergangstyp und dem von [get_Speed](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/get_speed/) zurückgegebenen Wert.

### **Die gleiche Dauer auf jede Folie anwenden**

Für ein gleichmäßiges Tempo wenden Sie denselben Effekt und dieselbe exakte Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/transitiontype/) und gibt jedem Übergang eine Dauer von 750 Millisekunden. Es aktiviert das automatische Voranschreiten nach 5000 Millisekunden und deaktiviert das Voranschreiten per Mausklick, dann wird das Ergebnis als PPTX gespeichert.

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

    // Konfigurieren Sie das automatische Voranschreiten unabhängig von der Dauer des Effekts.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Verschiedene Dauern für einzelne Folien festlegen**

Unterschiedliche Folien können unterschiedliche Effektdauern verwenden. Zum Beispiel kann für eine Titelfolie ein kurzer Übergang und für eine Abschnittseinleitung ein längerer Übergang verwendet werden. Dieses Beispiel setzt 500 Millisekunden für die erste Folie und 1200 Millisekunden für die zweite. Verwenden Sie eine Datei `input.pptx` mit mindestens zwei Folien.

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

Beim Erstellen eines [animated GIF](/slides/de/cpp/convert-powerpoint-to-animated-gif/), einer [HTML5-Präsentation](/slides/de/cpp/export-to-html5/) oder eines [Videos](/slides/de/cpp/convert-powerpoint-to-video/) sollten Sie die exakten Übergangszeiten vor dem Export festlegen, um das gewünschte Tempo zu treffen. Verwenden Sie beispielsweise einen 600-milliseconden Fade zwischen Szenen und passen Sie die Voranschreitverzögerung jeder Folie separat an, um Zeit für die Erzählung oder den Inhalt zu ermöglichen.

Für GIF und Video koordinieren Sie die Bildrate des Outputs mit der Effektdauer: 600 Millisekunden entsprechen 18 Bildern bei 30 Bildern pro Sekunde. In HTML5 aktivieren Sie animierte Übergänge in den Export‑Einstellungen. Prüfen Sie die vom gewählten Exportformat unterstützten Effekte und Zeitoptionen und prüfen Sie die Ausgabe, um die Synchronisation zu bestätigen.

### **Eine vorhandene Übergangsdauer auslesen**

Rufen Sie [get_Duration](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/get_duration/) auf, bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Ein Wert von `-1` bedeutet, dass keine explizite Dauer gesetzt ist; ein nicht negativer Wert gibt die gespeicherte Dauer in Millisekunden an. Dieser nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides verwendet den Übergangstyp und den von [get_Speed](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/get_speed/) zurückgegebenen Wert, um diese Dauer zu bestimmen. Das Festlegen eines Übergangstyps kann eine Dauer initialisieren, daher sollten Sie zuerst die ursprünglichen Einstellungen prüfen.

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

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erzeugen, duplizieren Sie eine Folie, verschieben oder skalieren ein Objekt auf der Kopie und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhalten die zugehörigen Objekte eine Animation zwischen ihrem ursprünglichen und modifizierten Zustand.

Das folgende Beispiel erstellt eine Folie mit einem Textrechteck, dupliziert die Folie und ändert die Position und Größe des Rechtecks auf der Kopie. Anschließend wählt es Morph aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/transitiontype/) für die zweite Folie. Öffnen Sie die gespeicherte Datei in einem Präsentationsviewer, der Morph unterstützt, um den Effekt während einer Bildschirmpräsentation zu sehen.

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

Die Aufzählung [TransitionMorphType](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/transitionmorphtype/) bestimmt, wie Morph Inhalte abgleicht und animiert:

- [ByObject](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/transitionmorphtype/) behandelt jede Form als ganzes Objekt.
- [ByWord](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/transitionmorphtype/) animiert Text, indem nach Möglichkeit Wörter abgeglichen werden.
- [ByChar](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/transitionmorphtype/) animiert Text, indem nach Möglichkeit Zeichen abgeglichen werden.

Rufen Sie [set_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_type/) mit Morph auf, bevor Sie [get_Value](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/get_value/) aufrufen. Der zurückgegebene Wert liefert die Schnittstelle [IMorphTransition](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/imorphtransition/), deren Methode [set_MorphType](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) den Abgleichmodus auswählt.

Dieses Beispiel öffnet die im vorherigen Abschnitt erstellte Präsentation und konfiguriert die zweite Folie so, dass sie eine wortbasierte Morph‑Animation verwendet.

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

Einige Übergänge bieten zusätzliche Optionen, etwa Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom gewählten Übergangstyp ab. Setzen Sie zuerst den Typ und verwenden Sie anschließend die geeignete Schnittstelle, die von [get_Value](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/get_value/) zurückgegeben wird.

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Es ruft [set_FromBlack](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) mit `true` über [IOptionalBlackTransition](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/ioptionalblacktransition/) auf, sodass der Übergang von einem schwarzen Bildschirm startet.

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

Ja. Verwenden Sie bevorzugt [set_Duration](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_duration/), wenn Sie eine exakte Effektdauer in Millisekunden benötigen. Nutzen Sie [set_Speed](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_speed/), wenn eine vordefinierte Kategorie von [TransitionSpeed](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/transitionspeed/) – Slow, Medium oder Fast – ausreicht und keine explizite Dauer gesetzt ist. Diese Einstellungen steuern den Übergangseffekt unabhängig von der Verzögerung des automatischen Voranschreitens.

**Kann ich einer Folie Audio hinzufügen und es wiederholen lassen?**

Ja. Weisen Sie eingebettetes Audio mit [set_Sound](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_sound/) zu, rufen Sie [set_SoundMode](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_soundmode/) mit **StartSound** aus der Aufzählung [TransitionSoundMode](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/transitionsoundmode/) auf und aktivieren Sie das Looping mit [set_SoundLoop](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_soundloop/). Das Audio wird wiederholt, bis das nächste Sound‑Ereignis in der Präsentation eintritt.

**Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Durchlaufen Sie die Sammlung, die von der Methode [get_Slides](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_slides/) der Präsentation zurückgegeben wird, und rufen Sie für jede Folie [set_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/set_type/) mit demselben Wert auf. Setzen Sie Timing‑ und Effektoptionen im selben Durchlauf, um das Verhalten über alle Folien hinweg konsistent zu halten.

**Wie kann ich prüfen, welcher Übergang aktuell für eine Folie eingestellt ist?**

Rufen Sie [get_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideshowtransition/get_type/) auf dem Übergang auf, der von [get_SlideShowTransition](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) der Folie zurückgegeben wird. Sie erhalten einen Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/cpp/aspose.slides.slideshow/transitiontype/); None bedeutet, dass kein Übergangseffekt angewendet wurde.