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
- Erweiterter Folienübergang
- Morph-Übergang
- Übergangstyp
- Übergangseffekt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folienübergänge in Aspose.Slides für C++ anpassen können, mit einer Schritt-für-Schritt-Anleitung für PowerPoint- und OpenDocument-Präsentationen."
---

## **Folienübergang hinzufügen**
Um das Verständnis zu erleichtern, haben wir die Verwendung von Aspose.Slides für C++ zur Verwaltung einfacher Folienübergänge demonstriert. Entwickler können nicht nur verschiedene Folienübergangseffekte auf die Folien anwenden, sondern auch das Verhalten dieser Übergangseffekte anpassen. Um einen einfachen Folienübergangseffekt zu erstellen, folgen Sie den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)-Klasse.  
2. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides für C++ angebotenen Übergangseffekte über das TransitionType‑Enum verwenden.  
3. Schreiben Sie die geänderte Präsentationsdatei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Erweiterten Folienübergang hinzufügen**
Im obigen Abschnitt haben wir nur einen einfachen Übergangseffekt auf die Folie angewendet. Jetzt, um diesen einfachen Übergangseffekt noch besser und kontrollierter zu machen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)-Klasse.  
2. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides für C++ angebotenen Übergangseffekte verwenden.  
3. Sie können den Übergang auch auf Vorwärts bei Klick, nach einem bestimmten Zeitraum oder beides einstellen.  
4. Wenn der Folienübergang auf Vorwärts bei Klick eingestellt ist, wird der Übergang nur weitergehen, wenn jemand die Maus klickt. Darüber hinaus wird der Übergang automatisch weitergehen, wenn die Eigenschaft Advance After Time festgelegt ist und die angegebene Zeit verstrichen ist.  
5. Schreiben Sie die geänderte Präsentation in eine Präsentationsdatei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Morph‑Übergang**
Aspose.Slides für C++ unterstützt jetzt den Morph‑Übergang. Sie stellen den neuen Morph‑Übergang vor, der in PowerPoint 2019 eingeführt wurde. Der Morph‑Übergang ermöglicht es, eine sanfte Bewegung von einer Folie zur nächsten zu animieren. Dieser Artikel beschreibt das Konzept und die Verwendung des Morph‑Übergangs. Um den Morph‑Übergang effektiv zu nutzen, benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Weg ist, die Folie zu duplizieren und das Objekt auf der zweiten Folie an eine andere Stelle zu verschieben.

Der folgende Codeausschnitt zeigt, wie Sie eine Kopie der Folie mit etwas Text zur Präsentation hinzufügen und den Übergang des Typs Morph für die zweite Folie festlegen.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Morph‑Übergangstypen**
Ein neues Enum Aspose.Slides.SlideShow.TransitionMorphType wurde hinzugefügt. Es repräsentiert verschiedene Arten von Morph‑Folienübergängen.

Das TransitionMorphType‑Enum verfügt über drei Mitglieder:

- ByObject: Der Morph‑Übergang wird unter Berücksichtigung von Formen als unteilbare Objekte durchgeführt.  
- ByWord: Der Morph‑Übergang wird, wo möglich, mit Textübertragung Wort für Wort durchgeführt.  
- ByChar: Der Morph‑Übergang wird, wo möglich, mit Textübertragung Zeichen für Zeichen durchgeführt.  

Der folgende Codeausschnitt zeigt, wie Sie den Morph‑Übergang für eine Folie festlegen und den Morph‑Typ ändern:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Übergangseffekte festlegen**
Aspose.Slides für C++ unterstützt das Festlegen von Übergangseffekten wie von Schwarz, von links, von rechts usw. Um den Übergangseffekt festzulegen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Presentation‑Klasse.  
- Holen Sie sich eine Referenz der Folie.  
- Legen Sie den Übergangseffekt fest.  
- Schreiben Sie die Präsentation als PPTX‑Datei.  

Im nachstehenden Beispiel haben wir die Übergangseffekte festgelegt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Stellen Sie die [speed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) des Übergangs mit der Einstellung [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) ein (z. B. slow/medium/fast).

**Kann ich einem Übergang Audio hinzufügen und es wiederholen lassen?**

Ja. Sie können einen Ton für den Übergang einbetten und das Verhalten über Einstellungen wie Sound‑Modus und Wiederholung steuern (z. B. [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), zusätzlich Metadaten wie [set_SoundIsBuiltIn](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) und [set_SoundName](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)).

**Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Konfigurieren Sie den gewünschten Übergangstyp in den Übergangseinstellungen jeder Folie; Übergänge werden pro Folie gespeichert, sodass das Anwenden desselben Typs auf alle Folien ein konsistentes Ergebnis liefert.

**Wie kann ich überprüfen, welcher Übergang derzeit für eine Folie eingestellt ist?**

Prüfen Sie die [transition settings](https://reference.aspose.com/slides/cpp/aspose.slides.baseslide/get_slideshowtransition/) der Folie und lesen Sie deren [transition type](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/get_type/); dieser Wert gibt genau an, welcher Effekt angewendet wurde.