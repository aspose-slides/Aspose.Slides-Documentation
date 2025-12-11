---
title: Folien einer Präsentation klonen in C++
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
description: "Duplizieren Sie PowerPoint‑Folien schnell mit Aspose.Slides für C++. Nutzen Sie unsere klaren Code‑Beispiele, um die PPT‑Erstellung in Sekunden zu automatisieren und manuelle Arbeit zu vermeiden."
---

## **Folien in einer Präsentation klonen**
Klonen ist der Vorgang, eine exakte Kopie oder ein Duplikat von etwas zu erstellen. Aspose.Slides für C++ ermöglicht es ebenfalls, eine Kopie oder einen Klon einer beliebigen Folie zu erstellen und diesen geklonten Folie in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Vorgang des Folienklonens erzeugt eine neue Folie, die von Entwicklern modifiziert werden kann, ohne die Originalfolie zu ändern. Es gibt mehrere mögliche Wege, eine Folie zu klonen:

- Klonen am Ende innerhalb einer Präsentation.
- Klonen an einer anderen Position innerhalb einer Präsentation.
- Klonen am Ende in einer anderen Präsentation.
- Klonen an einer anderen Position in einer anderen Präsentation.
- Klonen an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides für C++ stellt die (eine Sammlung von [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) Objekten) die von dem [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Objekt angebotene [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) und [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) Methoden die oben genannten Arten des Folienklonens bereit.

## **Eine Folie am Ende einer Präsentation klonen**
Wenn Sie eine Folie klonen und dann innerhalb derselben Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten, nutzen Sie die [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) Methode gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) Klasse, indem Sie auf die Folien‑Sammlung zugreifen, die vom [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Objekt bereitgestellt wird.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) Objekt bereitgestellt wird, und übergeben Sie die zu klonende Folie als Parameter an die [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) Methode.
1. Schreiben Sie die modifizierte Präsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (die an der ersten Position – Index 0 – der Präsentation liegt) an das Ende der Präsentation geklont.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Eine Folie an einer anderen Position innerhalb einer Präsentation klonen**
Wenn Sie eine Folie klonen und dann innerhalb derselben Präsentationsdatei, jedoch an einer anderen Position, verwenden möchten, nutzen Sie die [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) Methode:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Instanziieren Sie die Klasse, indem Sie auf die **Slides**‑Sammlung zugreifen, die vom [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Objekt bereitgestellt wird.
1. Rufen Sie die [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) Objekt bereitgestellt wird, und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) Methode.
1. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir eine Folie (die am Index 0 – Position 1 – der Präsentation liegt) an Index 1 – Position 2 – der Präsentation geklont.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Eine Folie am Ende einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) Klasse, indem Sie auf die **Slides**‑Sammlung zugreifen, die vom Presentation‑Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) Methode.
1. Schreiben Sie die modifizierte Zieldatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Eine Folie an einer anderen Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position verwenden möchten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) Klasse, indem Sie auf die Slides‑Sammlung zugreifen, die vom Presentation‑Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) Methode.
1. Schreiben Sie die modifizierte Zieldatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem Index 0 der Quellpräsentation) an Index 1 (Position 2) der Zielpräsentation geklont.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Eine Folie an einer bestimmten Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie zusammen mit einer Master‑Folien aus einer Präsentation klonen und in einer anderen Präsentation verwenden möchten, müssen Sie zunächst die gewünschte Master‑Folien aus der Quell‑ in die Zielpräsentation klonen. Anschließend verwenden Sie diese Master‑Folien für das Klonen der Folie mit Master. Die **AddClone(ISlide, IMasterSlide)** erwartet die Master‑Folien aus der Zielpräsentation, nicht aus der Quellpräsentation. Um die Folie mit Master zu klonen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse, die die Zielpräsentation enthält, zu der die Folie geklont werden soll.
1. Greifen Sie auf die zu klonende Folie zusammen mit der zugehörigen Master‑Folien zu.
1. Instanziieren Sie die [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/) Klasse, indem Sie auf die Masters‑Sammlung zugreifen, die vom [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) Methode auf, die vom [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/) Objekt bereitgestellt wird, und übergeben Sie die Master‑Folien aus der Quell‑PPTX als Parameter an die [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) Methode.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) Klasse, indem Sie die Referenz auf die Slides‑Sammlung setzen, die vom [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation sowie die Master‑Folien als Parameter an die [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) Methode.
1. Schreiben Sie die modifizierte Zielpräsentation.

Im nachstehenden Beispiel haben wir eine Folie mit Master (die am Index 0 der Quellpräsentation liegt) an das Ende der Zielpräsentation geklont, wobei das Master‑Element aus der Quell‑Folien stammt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Eine Folie am Ende eines angegebenen Abschnitts klonen**
Wenn Sie eine Folie klonen und dann innerhalb derselben Präsentationsdatei, jedoch in einem anderen Abschnitt, verwenden möchten, verwenden Sie die [**AddClone()**](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) Methode, die vom [**ISlideCollection**](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) Interface bereitgestellt wird. Aspose.Slides für C++ ermöglicht es, eine Folie aus dem ersten Abschnitt zu klonen und dann diese geklonte Folie in den zweiten Abschnitt derselben Präsentation einzufügen.

Der folgende Codeausschnitt zeigt, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **FAQ**

**Werden Sprechernotizen und Reviewer‑Kommentare geklont?**

Ja. Die Notizenseite und die Review‑Kommentare sind im Klon enthalten. Wenn Sie diese nicht wünschen, [entfernen Sie sie](/slides/de/cpp/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und deren Datenquellen behandelt?**

Das Diagramm‑Objekt, die Formatierung und eingebettete Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/cpp/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten prüfen.

**Kann ich die Einfügeposition und die Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen gewählten [Abschnitt](/slides/de/cpp/slide-section/) platzieren. Wenn der Zielabschnitt nicht existiert, erstellen Sie ihn zunächst und verschieben dann die Folie hinein.