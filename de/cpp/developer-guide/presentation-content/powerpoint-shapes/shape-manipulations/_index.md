---
title: Formenmanipulationen
type: docs
weight: 40
url: /de/cpp/shape-manipulations/
---

## **Form in Folie finden**
Dieses Thema beschreibt eine einfache Technik, die es Entwicklern erleichtert, eine bestimmte Form auf einer Folie zu finden, ohne ihre interne ID zu verwenden. Es ist wichtig zu wissen, dass PowerPoint-Präsentationsdateien keine Möglichkeit bieten, Formen auf einer Folie zu identifizieren, außer durch eine interne einzigartige ID. Es scheint für Entwickler schwierig zu sein, eine Form mithilfe ihrer internen einzigartigen ID zu finden. Alle Formen, die zu den Folien hinzugefügt werden, haben einen alternativen Text. Wir empfehlen Entwicklern, alternativen Text zu verwenden, um eine bestimmte Form zu finden. Sie können MS PowerPoint verwenden, um den alternativen Text für Objekte festzulegen, die Sie in Zukunft ändern möchten.

Nachdem der alternative Text für eine gewünschte Form festgelegt wurde, können Sie diese Präsentation mit Aspose.Slides für C++ öffnen und durch alle auf einer Folie hinzugefügten Formen iterieren. Bei jeder Iteration können Sie den alternativen Text der Form überprüfen, und die Form mit dem übereinstimmenden alternativen Text wäre die von Ihnen benötigte Form. Um diese Technik besser zu demonstrieren, haben wir eine Methode, [FindShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f), erstellt, die den Trick vollbringt, um eine bestimmte Form in einer Folie zu finden und dann einfach diese Form zurückzugeben.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}


## **Form klonen**
Um eine Form in eine Folie mit Aspose.Slides für C++ zu klonen:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die Formsammlung der Quellfolie zu.
1. Fügen Sie eine neue Folie zur Präsentation hinzu.
1. Klonen Sie Formen aus der Formsammlung der Quellfolie in die neue Folie.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Das folgende Beispiel fügt eine Gruppierung von Formen zu einer Folie hinzu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}


## **Form entfernen**
Aspose.Slides für C++ ermöglicht es Entwicklern, jede Form zu entfernen. Um die Form von einer Folie zu entfernen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Finden Sie die Form mit spezifischem AlternativeText.
1. Entfernen Sie die Form.
1. Speichern Sie die Datei auf der Festplatte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}


## **Form ausblenden**
Aspose.Slides für C++ ermöglicht es Entwicklern, jede Form auszublenden. Um die Form von einer Folie auszublenden, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Finden Sie die Form mit spezifischem AlternativeText.
1. Blenden Sie die Form aus.
1. Speichern Sie die Datei auf der Festplatte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}



## **Formenreihenfolge ändern**
Aspose.Slides für C++ ermöglicht es Entwicklern, die Reihenfolge der Formen zu ändern. Die Neuanordnung der Formen gibt an, welche Form im Vordergrund oder welche Form im Hintergrund ist. Um die Form von einer Folie neu anzuordnen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine Form hinzu.
1. Fügen Sie Text in den Textrahmen der Form ein.
1. Fügen Sie eine weitere Form mit denselben Koordinaten hinzu.
1. Ordnen Sie die Formen neu.
1. Speichern Sie die Datei auf der Festplatte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}


## **Interop Shape ID abrufen**
Aspose.Slides für C++ ermöglicht es Entwicklern, einen einzigartigen Formbezeichner im Folienkontext im Gegensatz zur UniqueId-Eigenschaft zu erhalten, die es ermöglicht, einen einzigartigen Bezeichner im Präsentationskontext zu erhalten. Die Eigenschaft OfficeInteropShapeId wurde den IShape-Schnittstellen und der Shape-Klasse hinzugefügt. Der von der OfficeInteropShapeId-Eigenschaft zurückgegebene Wert entspricht dem Wert der ID des Microsoft.Office.Interop.PowerPoint.Shape-Objekts. Nachfolgend ist ein Beispielcode angegeben.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}


## **AlternativeText-Eigenschaft festlegen**
Aspose.Slides für C++ ermöglicht es Entwicklern, den AlternateText jeder Form festzulegen. Um den AlternateText einer Form festzulegen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine beliebige Form zur Folie hinzu.
1. Arbeiten Sie mit der neu hinzugefügten Form.
1. Durchlaufen Sie die Formen, um eine Form zu finden.
1. Legen Sie den AlternativeText fest.
1. Speichern Sie die Datei auf der Festplatte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}


## **Zugriff auf Layout-Formate für Formen**
Aspose.Slides für C++ ermöglicht es Entwicklern, auf Layout-Formate für eine Form zuzugreifen. Dieser Artikel zeigt, wie Sie auf die Eigenschaften **FillFormat** und **LineFormat** für eine Form zugreifen können.

Nachfolgend ist ein Beispielcode angegeben.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Form als SVG rendern**
Jetzt unterstützt Aspose.Slides für C++ das Rendern einer Form als SVG. Die Methode WriteAsSvg (und ihre Überladungen) wurde zur Shape-Klasse und zur IShape-Schnittstelle hinzugefügt. Diese Methode ermöglicht das Speichern des Inhalts der Form als SVG-Datei. Der folgende Codeausschnitt zeigt, wie man die Form einer Folie in eine SVG-Datei exportiert.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Formen-Ausrichtung**
Aspose.Slides ermöglicht das Ausrichten von Formen entweder relativ zu den Folienrändern oder relativ zueinander. Zu diesem Zweck wurde eine überladene [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) Methode hinzugefügt. Die Enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) definiert mögliche Ausrichtungsoptionen.

**Beispiel 1**

Der nachstehende Quellcode richtet die Formen mit den Indizes 1, 2 und 4 entlang der oberen Kante der Folie aus.

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

Das folgende Beispiel zeigt, wie man die gesamte Sammlung von Formen relativ zur untersten Form in der Sammlung ausrichtet.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```