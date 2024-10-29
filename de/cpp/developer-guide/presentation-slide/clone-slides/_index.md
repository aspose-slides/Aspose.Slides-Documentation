---
title: Folien klonen
type: docs
weight: 40
url: /de/cpp/clone-slides/
---


## **Folien in Präsentation klonen**
Klonen ist der Prozess, eine exakte Kopie oder Nachbildung von etwas zu erstellen. Aspose.Slides für C++ ermöglicht es zudem, eine Kopie oder einen Klon einer beliebigen Folie zu erstellen und diese geklonte Folie dann in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Prozess des Folienklonens erstellt eine neue Folie, die von Entwicklern modifiziert werden kann, ohne die Originalfolie zu ändern. Es gibt mehrere mögliche Wege, eine Folie zu klonen:

- Am Ende innerhalb einer Präsentation klonen.
- An einer anderen Position innerhalb der Präsentation klonen.
- Am Ende in einer anderen Präsentation klonen.
- An einer anderen Position in einer anderen Präsentation klonen.
- An einer bestimmten Position in einer anderen Präsentation klonen.

In Aspose.Slides für C++ bietet eine Sammlung von [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) Objekten, die vom [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt bereitgestellt werden, die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) und [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) Methoden, um die oben beschriebenen Arten des Folienklonens durchzuführen.

## **Am Ende innerhalb der Präsentation klonen**
Wenn Sie eine Folie klonen und dann am Ende der bestehenden Folien in derselben Präsentationsdatei verwenden möchten, verwenden Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) Methode gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Klasse, indem Sie auf die von der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt bereitgestellte Folienkollektion verweisen.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Objekt bereitgestellt wird, und übergeben Sie die zu klonende Folie als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) Methode.
1. Schreiben Sie die modifizierte Präsentationsdatei.

Im folgenden Beispiel haben wir eine Folie (die an erster Stelle – Index Null – der Präsentation liegt) ans Ende der Präsentation geklont.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}


## **An anderer Position in der Präsentation klonen**
Wenn Sie eine Folie klonen und dann in derselben Präsentationsdatei, aber an einer anderen Position verwenden möchten, verwenden Sie die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) Methode:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Instanziieren Sie die Klasse, indem Sie auf die **Slides** Kollektion verweisen, die vom [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt bereitgestellt wird.
1. Rufen Sie die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Objekt bereitgestellt wird, und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) Methode.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Folie (die am Index Null – Position 1 – der Präsentation liegt) an Index 1 – Position 2 – der Präsentation geklont.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Folie am Ende in einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der bestehenden Folien verwenden müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Präsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Klasse, indem Sie auf die **Slides** Kollektion verweisen, die vom Presentation Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) Methode.
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im folgenden Beispiel haben wir eine Folie (aus dem ersten Index der Quellpräsentation) ans Ende der Zielpräsentation geklont.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Folie an einer anderen Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position verwenden müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Präsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Klasse, indem Sie auf die von der Presentation Objekt der Zielpräsentation bereitgestellte Folienkollektion verweisen.
1. Rufen Sie die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) Methode.
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im folgenden Beispiel haben wir eine Folie (aus dem Index Null der Quellpräsentation) an Index 1 (Position 2) der Zielpräsentation geklont.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}
## **Folie an spezifischer Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie mit Masterfolie aus einer Präsentation klonen und in einer anderen Präsentation verwenden müssen, müssen Sie zunächst die gewünschte Masterfolie aus der Quellpräsentation in die Zielpräsentation klonen. Dann müssen Sie diese Masterfolie für das Klonen der Folie mit Masterfolie verwenden. Die **AddClone(ISlide, IMasterSlide)** erwartet die Masterfolie aus der Zielpräsentation anstelle der Quellpräsentation. Um die Folie mit Master zu klonen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Zielpräsentation enthält, in die die Folie geklont werden soll.
1. Greifen Sie auf die Folie zu, die geklont werden soll, zusammen mit der Masterfolie.
1. Instanziieren Sie die [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection) Klasse, indem Sie auf die von der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt der Zielpräsentation bereitgestellte Masters-Kollektion verweisen.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) Methode auf, die vom [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection) Objekt bereitgestellt wird, und übergeben Sie die Masterfolie aus dem Quelldateiformat, die geklont werden soll, als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) Methode.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Klasse, indem Sie die Referenz auf die von der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt der Zielpräsentation bereitgestellte Folienkollektion setzen.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation, die geklont werden soll, sowie die Masterfolie als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) Methode.
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im folgenden Beispiel haben wir eine Folie mit Master (die am Index Null der Quellpräsentation liegt) ans Ende der Zielpräsentation geklont, wobei die Masterfolie von der Quellfolie stammt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}
## **Folie in festgelegten Abschnitt klonen**
Wenn Sie eine Folie klonen und dann in derselben Präsentationsdatei, aber an einem anderen Abschnitt verwenden möchten, verwenden Sie die [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a46981dac8b18355531a04a70c70c444b) Methode, die von der [**ISlideCollection** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection)Schnittstelle bereitgestellt wird. Aspose.Slides für C++ ermöglicht es, eine Folie aus dem ersten Abschnitt zu klonen und diese geklonte Folie dann in den zweiten Abschnitt derselben Präsentation einzufügen.

Der folgende Codeausschnitt zeigt Ihnen, wie Sie eine Folie klonen und die geklonte Folie in einen festgelegten Abschnitt einfügen.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}