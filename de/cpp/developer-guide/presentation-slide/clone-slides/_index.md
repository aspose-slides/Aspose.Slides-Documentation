---
title: Präsentationsfolien in C++ klonen
linktitle: Folien klonen
type: docs
weight: 40
url: /de/cpp/clone-slides/
keywords:
- Folien klonen
- Folien kopieren
- Folien speichern
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Duplizieren Sie PowerPoint-Folien schnell mit Aspose.Slides für C++. Befolgen Sie unsere klaren Codebeispiele, um die Erstellung von PPTs in Sekunden zu automatisieren und manuelle Arbeit zu vermeiden."
---
## **Einführung**

Cloning ist der Vorgang, eine exakte Kopie oder Replik eines Objekts zu erstellen. Aspose.Slides for C++ ermöglicht es ebenfalls, eine Kopie oder einen Klon einer beliebigen Folie zu erstellen und diesen geklonten Folie in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Vorgang des Folienklonens erzeugt eine neue Folie, die von Entwicklern bearbeitet werden kann, ohne die Originalfolie zu ändern. Es gibt mehrere mögliche Methoden, eine Folie zu klonen:

- Klon am Ende innerhalb einer Präsentation.
- Klon an einer anderen Position innerhalb einer Präsentation.
- Klon am Ende in einer anderen Präsentation.
- Klon an einer anderen Position in einer anderen Präsentation.
- Klon an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides for C++ (eine Sammlung von [ISlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/) Objekten), die vom [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Objekt bereitgestellt wird, stehen die Methoden [AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) und [InsertClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/insertclone/) zur Verfügung, um die oben genannten Arten des Folienklonens auszuführen.

## **Klone eine Folie am Ende einer Präsentation**
Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten, verwenden Sie die [AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) Methode gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/) Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Objekt bereitgestellte Slides‑Sammlung verweisen.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/) Objekt bereitgestellt wird, und übergeben Sie die zu klonende Folie als Parameter an die [AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) Methode.
1. Schreiben Sie die geänderte Präsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (die sich an der ersten Position – Index 0 – der Präsentation befindet) an das Ende der Präsentation geklont.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Klone eine Folie an eine andere Position innerhalb einer Präsentation**
Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei, jedoch an einer anderen Position verwenden möchten, verwenden Sie die [InsertClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/insertclone/) Methode:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse.
1. Instanziieren Sie die Klasse, indem Sie auf die **Slides**‑Sammlung verweisen, die vom [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Objekt bereitgestellt wird.
1. Rufen Sie die [InsertClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/insertclone/) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/) Objekt bereitgestellt wird, und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die [InsertClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/insertclone/) Methode.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir eine Folie (die sich am Index 0 – Position 1 – der Präsentation befindet) zu Index 1 – Position 2 – der Präsentation geklont.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Klone eine Folie am Ende einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und sie in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse, die die Präsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/) Klasse, indem Sie auf die **Slides**‑Sammlung verweisen, die vom Presentation‑Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die [AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) Methode.
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (vom ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klone eine Folie an eine andere Position in einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und sie in einer anderen Präsentationsdatei an einer bestimmten Position verwenden möchten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse, die die Präsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/) Klasse, indem Sie auf die Slides‑Sammlung verweisen, die vom Presentation‑Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [InsertClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/insertclone/) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die [InsertClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/insertclone/) Methode.
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (vom Index 0 der Quellpräsentation) zu Index 1 (Position 2) der Zielpräsentation geklont.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klone eine Folie an einer bestimmten Position in einer anderen Präsentation**
Wenn Sie eine Folie mit Masterfolie aus einer Präsentation klonen und in einer anderen Präsentation verwenden möchten, müssen Sie zunächst die gewünschte Masterfolie aus der Quellpräsentation in die Zielpräsentation klonen. Anschließend verwenden Sie diese Masterfolie für das Klonen der Folie mit Master. Die **AddClone(ISlide, IMasterSlide)**‑Methode erwartet die Masterfolie der Zielpräsentation und nicht die der Quellpräsentation. Gehen Sie wie folgt vor, um die Folie mit Master zu klonen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse, die die Zielpräsentation enthält, zu der die Folie geklont werden soll.
1. Greifen Sie auf die zu klonende Folie zusammen mit der Masterfolie zu.
1. Instanziieren Sie die [IMasterSlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/) Klasse, indem Sie auf die Masters‑Sammlung verweisen, die vom [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) Methode auf, die vom [IMasterSlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/) Objekt bereitgestellt wird, und übergeben Sie den Master aus der Quell‑PPTX als Parameter an die [AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) Methode.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/) Klasse, indem Sie die Referenz auf die Slides‑Sammlung setzen, die vom [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation sowie die Masterfolie als Parameter an die [AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) Methode.
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie mit Master (die sich am Index 0 der Quellpräsentation befindet) an das Ende der Zielpräsentation geklont, wobei der Master aus der Quellfolie verwendet wurde.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Klone eine Folie am Ende eines angegebenen Abschnitts**
Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei, jedoch in einem anderen Abschnitt verwenden möchten, verwenden Sie die [**AddClone()**](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) Methode, die von der [**ISlideCollection**](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/) Schnittstelle bereitgestellt wird. Aspose.Slides for C++ ermöglicht es, eine Folie aus dem ersten Abschnitt zu klonen und diese geklonte Folie in den zweiten Abschnitt derselben Präsentation einzufügen.

Der folgende Codeausschnitt zeigt, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Stellen Sie die Übereinstimmung der Foliengröße sicher**

Beim Klonen von Folien in eine andere Präsentation muss die Zielpräsentation dieselbe Foliengröße wie die Quellpräsentation besitzen. Wenn die Foliengrößen abweichen, skaliert Aspose.Slides die geklonten Formen nicht automatisch – ihre ursprünglichen Koordinaten und Abmessungen bleiben erhalten, was dazu führen kann, dass Inhalte fehlerhaft ausgerichtet sind oder über die Folienränder hinausgehen.

Sie können die Foliengröße der Zielpräsentation vor dem Klonen von Master und Folie an die Quelle anpassen:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

Tun Sie dies, bevor Sie den Master und die Folie klonen.

## **FAQ**

**Werden Sprecher‑Notizen und Prüferkommentare geklont?**

Ja. Die Notizenseite und Prüferkommentare werden in den Klon übernommen. Wenn Sie sie nicht wünschen, [entfernen Sie sie](/slides/de/cpp/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und deren Datenquellen behandelt?**

Das Diagrammobjekt, die Formatierung und die eingebetteten Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑einbetten Arbeitsmappe), bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/cpp/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien prüfen Sie die Datenverfügbarkeit und das Aktualisierungsverhalten.

**Kann ich die Einfügeposition und Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen gewählten [Abschnitt](/slides/de/cpp/slide-section/) verschieben. Existiert der Zielabschnitt nicht, erstellen Sie ihn zuerst und verschieben dann die Folie dorthin.