---
title: Verwalten von Präsentationsformen in C++
linktitle: Formmanipulation
type: docs
weight: 40
url: /de/cpp/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form duplizieren
- Form entfernen
- Form ausblenden
- Reihenfolge von Formen ändern
- Interop-Form-ID erhalten
- AlternativeText einer Form
- Layoutformate einer Form
- Form als SVG
- Form nach SVG
- Form ausrichten
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in Aspose.Slides für C++ erstellen, bearbeiten und optimieren und leistungsstarke PowerPoint-Präsentationen bereitstellen."
---

## **Eine Form auf einer Folie finden**
Dieses Thema beschreibt eine einfache Technik, mit der Entwickler eine bestimmte Form auf einer Folie leichter finden können, ohne deren interne Id zu verwenden. Es ist wichtig zu wissen, dass PowerPoint‑Präsentationsdateien keine Möglichkeit besitzen, Formen auf einer Folie zu identifizieren, außer über eine interne eindeutige Id. Für Entwickler ist es oft schwierig, eine Form über ihre interne eindeutige Id zu finden. Allen Formen, die zu Folien hinzugefügt werden, ist ein Alternativtext zugewiesen. Wir empfehlen Entwicklern, den Alternativtext zur Suche einer bestimmten Form zu nutzen. Sie können in MS PowerPoint den Alternativtext für Objekte festlegen, die Sie künftig ändern möchten.

Nachdem Sie den Alternativtext einer gewünschten Form festgelegt haben, können Sie die Präsentation mit Aspose.Slides für C++ öffnen und alle Formen einer Folie durchlaufen. Bei jeder Iteration prüfen Sie den Alternativtext der Form; die Form mit dem passenden Alternativtext ist die gesuchte Form. Um diese Technik anschaulicher zu demonstrieren, haben wir die Methode [FindShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) erstellt, die das Auffinden einer bestimmten Form in einer Folie übernimmt und die Form zurückgibt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **Eine Form duplizieren**
Um eine Form mit Aspose.Slides für C++ auf einer Folie zu duplizieren:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Greifen Sie auf die Formsammlung der Quellfolie zu.
4. Fügen Sie der Präsentation eine neue Folie hinzu.
5. Duplizieren Sie Formen aus der Formsammlung der Quellfolie in die neue Folie.
6. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das folgende Beispiel fügt einer Folie ein Gruppenelement hinzu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **Eine Form entfernen**
Aspose.Slides für C++ ermöglicht es Entwicklern, jede Form zu entfernen. So entfernen Sie eine Form von einer Folie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Greifen Sie auf die erste Folie zu.
3. Suchen Sie die Form mit dem gewünschten AlternativeText.
4. Entfernen Sie die Form.
5. Speichern Sie die Datei auf dem Datenträger.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **Eine Form ausblenden**
Aspose.Slides für C++ ermöglicht es Entwicklern, jede Form auszublenden. So blenden Sie eine Form auf einer Folie aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Greifen Sie auf die erste Folie zu.
3. Suchen Sie die Form mit dem gewünschten AlternativeText.
4. Blenden Sie die Form aus.
5. Speichern Sie die Datei auf dem Datenträger.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **Reihenfolge von Formen ändern**
Aspose.Slides für C++ ermöglicht es Entwicklern, die Reihenfolge von Formen zu ändern. Durch das Neuordnen wird festgelegt, welche Form im Vordergrund bzw. im Hintergrund liegt. So ändern Sie die Reihenfolge von Formen auf einer Folie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine Form hinzu.
4. Fügen Sie Text im TextFrame der Form ein.
5. Fügen Sie eine weitere Form mit denselben Koordinaten hinzu.
6. Ordnen Sie die Formen neu.
7. Speichern Sie die Datei auf dem Datenträger.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **Interop‑Form‑ID erhalten**
Aspose.Slides für C++ ermöglicht es Entwicklern, eine eindeutige Form‑ID im Folien‑Umfang zu erhalten, im Gegensatz zur Property UniqueId, die eine eindeutige ID im Präsentations‑Umfang liefert. Die Property OfficeInteropShapeId wurde den Schnittstellen IShape und der Klasse Shape hinzugefügt. Der von OfficeInteropShapeId zurückgegebene Wert entspricht dem Id‑Wert des Microsoft.Office.Interop.PowerPoint.Shape‑Objekts. Unten finden Sie ein Beispiel.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **AlternativeText‑Eigenschaft setzen**
Aspose.Slides für C++ ermöglicht es Entwicklern, den AlternateText einer Form zu setzen. So setzen Sie den AlternateText einer Form:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine beliebige Form zur Folie hinzu.
4. Arbeiten Sie mit der neu hinzugefügten Form.
5. Durchlaufen Sie die Formen, um die gewünschte Form zu finden.
6. Setzen Sie den AlternativeText.
7. Speichern Sie die Datei auf dem Datenträger.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **Layout‑Formate für eine Form abrufen**
Aspose.Slides für C++ ermöglicht es Entwicklern, Layout‑Formate einer Form abzurufen. Dieser Artikel zeigt, wie Sie die Eigenschaften **FillFormat** und **LineFormat** einer Form verwenden können.

Unten finden Sie den Beispielcode.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Eine Form als SVG rendern**
Jetzt unterstützt Aspose.Slides für C++ das Rendern einer Form als SVG. Die Methode WriteAsSvg (und ihre Überladung) wurde der Klasse Shape und der Schnittstelle IShape hinzugefügt. Mit dieser Methode können Sie den Inhalt einer Form als SVG‑Datei speichern. Der nachfolgende Code‑Auszug zeigt, wie Sie die Form einer Folie in eine SVG‑Datei exportieren.
``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```


## **Formen ausrichten**
Aspose.Slides ermöglicht das Ausrichten von Formen entweder relativ zu den Folienrändern oder relativ zueinander. Zu diesem Zweck wurde eine überladene Methode [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) bereitgestellt. Die Aufzählung [ShapesAlignmentType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) definiert die möglichen Ausrichtungsoptionen.

**Beispiel 1**

Der nachstehende Quellcode richtet die Formen mit den Indizes 1, 2 und 4 am oberen Rand der Folie aus.  
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```


**Beispiel 2**

Im folgenden Beispiel wird gezeigt, wie die gesamte Formsammlung relativ zur untersten Form der Sammlung ausgerichtet wird.  
``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```


## **Spiegelungs‑Eigenschaften**

In Aspose.Slides bietet die Klasse [ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/) die Kontrolle über horizontales und vertikales Spiegeln von Formen über die Eigenschaften `flipH` und `flipV`. Beide Eigenschaften sind vom Typ [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) und können True für ein Spiegeln, False für kein Spiegeln oder NotDefined für das Standardverhalten annehmen. Diese Werte sind über das [Frame](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_frame/) einer Form zugreifbar.

Um die Spiegel‑Einstellungen zu ändern, wird eine neue [ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/)‑Instanz mit der aktuellen Position und Größe der Form, den gewünschten Werten für `flipH` und `flipV` sowie dem Drehwinkel erstellt. Durch Zuweisung dieser Instanz an das [Frame](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_frame/) der Form und anschließendem Speichern der Präsentation werden die Spiegel‑Transformationen angewendet und in die Ausgabedatei übernommen.

Angenommen, wir haben eine Datei sample.pptx, in der die erste Folie eine einzelne Form mit den Standard‑Spiegel‑Einstellungen enthält, wie unten gezeigt.

![Die zu spiegelnde Form](shape_to_be_flipped.png)

Der folgende Code‑Auszug liest die aktuellen Spiegel‑Eigenschaften der Form aus und spiegelt sie sowohl horizontal als auch vertikal.
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Ruft die horizontale Flip-Eigenschaft der Form ab.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Ruft die vertikale Flip-Eigenschaft der Form ab.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Horizontal spiegeln.
auto flipV = NullableBool::True; // Horizontal spiegeln.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Das Ergebnis:

![Die gespiegelte Form](flipped_shape.png)

## **FAQ**

**Kann ich Formen (Vereinigung/Überschneidung/Subtraktion) auf einer Folie wie in einem Desktop‑Editor kombinieren?**

Eine eingebaute Boolesche‑Operation‑API gibt es nicht. Sie können das Ergebnis annähern, indem Sie die gewünschte Kontur selbst erzeugen – z. B. die resultierende Geometrie über [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) berechnen und eine neue Form mit diesem Umriss erstellen, optional die Originals entfernen.

**Wie kann ich die Stapelreihenfolge (Z‑Order) steuern, sodass eine Form immer „oben“ bleibt?**

Ändern Sie die Einfüge‑/Verschiebe‑Reihenfolge innerhalb der [shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/)‑Sammlung der Folie. Für vorhersehbare Ergebnisse sollten Sie den Z‑Order nach allen anderen Änderungen an der Folie finalisieren.

**Kann ich eine Form „sperren“, damit Benutzer sie in PowerPoint nicht bearbeiten können?**

Ja. Setzen Sie die [Form‑Schutz‑Flags](/slides/de/cpp/applying-protection-to-presentation/) (z. B. Auswahl, Bewegung, Größenänderung, Textbearbeitung sperren). Bei Bedarf können Sie entsprechende Beschränkungen auf dem Master‑ oder Layout‑Folientyp festlegen. Beachten Sie, dass dies ein UI‑Schutz ist und keine Sicherheitsfunktion; für stärkeren Schutz kombinieren Sie ihn mit Dateischutzeinstellungen wie Lese‑Only‑Empfehlungen oder Passwörtern (/slides/de/cpp/password-protected-presentation/).