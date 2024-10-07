---
title: Folienübergang
type: docs
weight: 80
url: /cpp/slide-transition/
keywords: "PowerPoint Folienübergang, Morphübergang"
description: "PowerPoint Folienübergang, PowerPoint Morphübergang mit Aspose.Slides."
---


## **Folienübergang hinzufügen**
Um es einfacher zu verstehen, haben wir die Verwendung von Aspose.Slides für C++ zur Verwaltung einfacher Folienübergänge demonstriert. Entwickler können nicht nur verschiedene Folienübergangseffekte auf die Folien anwenden, sondern auch das Verhalten dieser Übergangseffekte anpassen. Um einen einfachen Folienübergangseffekt zu erstellen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie aus einem der von Aspose.Slides für C++ angebotenen Übergangseffekte über das TransitionType-Enum an.
1. Schreiben Sie die modifizierte Präsentationsdatei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Erweiterten Folienübergang hinzufügen**
Im obigen Abschnitt haben wir nur einen einfachen Übergangseffekt auf die Folie angewendet. Um diesen einfachen Übergangseffekt noch besser und kontrollierter zu gestalten, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie aus einem der von Aspose.Slides für C++ angebotenen Übergangseffekte an.
1. Sie können den Übergang auch so einstellen, dass er bei einem Klick, nach einem bestimmten Zeitraum oder beidem erfolgt.
1. Wenn der Folienübergang aktiviert ist, um bei einem Klick voranzugehen, wird der Übergang nur voranschreiten, wenn jemand mit der Maus klickt. Zudem wird, wenn die Eigenschaft Advance After Time gesetzt ist, der Übergang automatisch voranschreiten, nachdem die festgelegte Advance-Zeit vergangen ist.
1. Schreiben Sie die modifizierte Präsentation als Präsentationsdatei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}


## **Morphübergang**
Aspose.Slides für C++ unterstützt jetzt den Morphübergang. Dieser stellt einen neuen Morphübergang dar, der in PowerPoint 2019 eingeführt wurde. Der Morphübergang ermöglicht es Ihnen, eine sanfte Bewegung von einer Folie zur nächsten zu animieren. Dieser Artikel beschreibt das Konzept und wie man den Morphübergang verwendet. Um den Morphübergang effektiv zu nutzen, benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Weg ist, die Folie zu duplizieren und dann das Objekt auf der zweiten Folie an einen anderen Ort zu verschieben.

Der folgende Codeausschnitt zeigt Ihnen, wie Sie einen Klon der Folie mit etwas Text zur Präsentation hinzufügen und einen Übergang vom Typ Morph auf die zweite Folie anwenden.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Morphübergangstyp**
Das neue Aspose.Slides.SlideShow.TransitionMorphType-Enum wurde hinzugefügt. Es stellt verschiedene Typen von Morph-Folienübergängen dar.

Das TransitionMorphType-Enum hat drei Mitglieder:

- ByObject: Der Morphübergang wird unter Berücksichtigung von Formen als unteilbare Objekte durchgeführt.
- ByWord: Der Morphübergang wird durchgeführt, wobei Text, wo möglich, wortweise übertragen wird.
- ByChar: Der Morphübergang wird durchgeführt, wobei Text, wo möglich, zeichenweise übertragen wird.

Der folgende Codeausschnitt zeigt Ihnen, wie Sie einen Morphübergang auf die Folie anwenden und den Morphtyp ändern:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}


## **Übergangseffekte festlegen**
Aspose.Slides für C++ unterstützt das Festlegen von Übergangseffekten wie z. B. von schwarz, von links, von rechts usw. Um den Übetragseffekt festzulegen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der Presentation-Klasse.
- Holen Sie sich das Referenz der Folie.
- Stellen Sie den Übergangseffekt ein.
- Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir die Übergangseffekte festgelegt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}