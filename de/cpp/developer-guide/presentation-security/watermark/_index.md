---
title: Wasserzeichen zu Präsentationen in C++ hinzufügen
linktitle: Wasserzeichen
type: docs
weight: 40
url: /de/cpp/watermark/
keywords:
- Wasserzeichen
- Textwasserzeichen
- Bildwasserzeichen
- Wasserzeichen hinzufügen
- Wasserzeichen ändern
- Wasserzeichen entfernen
- Wasserzeichen löschen
- Wasserzeichen zu PPT hinzufügen
- Wasserzeichen zu PPTX hinzufügen
- Wasserzeichen zu ODP hinzufügen
- Wasserzeichen aus PPT entfernen
- Wasserzeichen aus PPTX entfernen
- Wasserzeichen aus ODP entfernen
- Wasserzeichen aus PPT löschen
- Wasserzeichen aus PPTX löschen
- Wasserzeichen aus ODP löschen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie Text- und Bildwasserzeichen in PowerPoint- und OpenDocument-Präsentationen in C++, um Entwürfe, vertrauliche Informationen, Urheberrechte und mehr zu kennzeichnen."
---

## **Übersicht**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder auf allen Präsentationsfolien verwendet wird. In der Regel wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Entwurf“-Wasserzeichen), dass vertrauliche Informationen enthalten sind (z. B. ein „Vertraulich“-Wasserzeichen), um zu spezifizieren, zu welchem Unternehmen sie gehört (z. B. ein „Firmenname“-Wasserzeichen), um den Präsentationsautor zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden sollte. Wasserzeichen werden sowohl in PowerPoint‑ als auch in OpenOffice‑Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint‑PPT, PPTX und OpenOffice‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/cpp/), gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und deren Design und Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Textwasserzeichen die [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)-Schnittstelle verwenden und zum Hinzufügen von Bildwasserzeichen die [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/)-Klasse oder das Füllen einer Wasserzeichnungsform mit einem Bild. `PictureFrame` implementiert die [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)-Schnittstelle, sodass Sie alle flexiblen Einstellungen des Formobjekts nutzen können. Da `ITextFrame` keine Form ist und seine Einstellungen eingeschränkt sind, wird es in ein [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)-Objekt eingebettet.

Ein Wasserzeichen kann auf zwei Arten angewendet werden: auf einer einzelnen Folie oder auf allen Präsentationsfolien. Der Folienmaster wird verwendet, um ein Wasserzeichen auf alle Folien anzuwenden — das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu ändern.

Ein Wasserzeichen wird in der Regel als nicht editierbar für andere Benutzer betrachtet. Um zu verhindern, dass das Wasserzeichen (bzw. die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Form‑Sperrfunktion. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn die Wasserzeichen‑Form auf dem Folienmaster gesperrt ist, wird sie auf allen Folien gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es in Zukunft, wenn Sie es löschen möchten, anhand des Namens in den Folienformen finden können.

Das Wasserzeichen kann auf beliebige Weise gestaltet werden; üblich sind jedoch Merkmale wie zentrierte Ausrichtung, Drehung, Position im Vordergrund usw. Wir betrachten, wie diese in den nachfolgenden Beispielen verwendet werden können.

## **Text‑Wasserzeichen**

### **Ein Text‑Wasserzeichen zu einer Folie hinzufügen**

Um ein Text‑Wasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst einer Folie eine Form hinzufügen und dann dieser Form einen Textrahmen zuweisen. Der Textrahmen wird durch die [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)-Schnittstelle repräsentiert. Dieser Typ erbt nicht von [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), das über umfangreiche Eigenschaften zur flexiblen Positionierung des Wasserzeichens verfügt. Daher wird das [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)-Objekt in ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)-Objekt eingebettet. Um Wasserzeichentext zur Form hinzuzufügen, verwenden Sie die [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/)-Methode wie unten gezeigt.
```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```


{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man die TextFrame‑Klasse verwendet](/slides/de/cpp/text-formatting/)
{{% /alert %}}

### **Ein Text‑Wasserzeichen zu einer Präsentation hinzufügen**

Wenn Sie ein Text‑Wasserzeichen der gesamten Präsentation (d. h. allen Folien auf einmal) hinzufügen möchten, fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) hinzu. Der Rest der Logik ist identisch zu dem, was beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie verwendet wird — erstellen Sie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)-Objekt und fügen Sie das Wasserzeichen mit der [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/)-Methode hinzu.
```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```


{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man den Folienmaster verwendet](/slides/de/cpp/slide-master/)
{{% /alert %}}

### **Transparenz der Wasserzeichen‑Form festlegen**

Standardmäßig ist die Rechteckform mit Füll‑ und Linienstilen versehen. Die folgenden Code‑Zeilen machen die Form transparent.
```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```


### **Schriftart für ein Text‑Wasserzeichen festlegen**

Sie können die Schriftart des Text‑Wasserzeichens wie unten gezeigt ändern.
```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```


### **Farbe des Wasserzeichen‑Texts festlegen**

Um die Farbe des Wasserzeichen‑Texts festzulegen, verwenden Sie diesen Code:
```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```


### **Text‑Wasserzeichen zentrieren**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren; dafür können Sie Folgendes tun:
```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```


Das Bild unten zeigt das Endergebnis.

![The text watermark](text_watermark.png)

## **Bild‑Wasserzeichen**

### **Ein Bild‑Wasserzeichen zu einer Präsentation hinzufügen**

Um ein Bild‑Wasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes ausführen:
```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```


## **Ein Wasserzeichen vor dem Bearbeiten sperren**

Wenn es notwendig ist, ein Wasserzeichen vor der Bearbeitung zu schützen, verwenden Sie die [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/)-Methode auf der Form. Mit dieser Eigenschaft können Sie die Form davor schützen, ausgewählt, in der Größe geändert, verschoben, mit anderen Elementen gruppiert, ihr Text vor der Bearbeitung gesperrt usw. zu werden:
```cpp
// Sperre die Wasserzeichenform vor Änderungen
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```


## **Ein Wasserzeichen in den Vordergrund bringen**

In Aspose.Slides kann die Z‑Reihenfolge von Formen über die [IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/)-Methode festgelegt werden. Dazu rufen Sie diese Methode aus der Liste der Präsentationsfolien auf und übergeben die Referenz der Form sowie deren Reihenfolgenummer. Auf diese Weise kann eine Form in den Vordergrund oder in den Hintergrund der Folie verschoben werden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor den restlichen Inhalten der Präsentation platzieren müssen:
```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```


## **Drehung des Wasserzeichens festlegen**

Hier ein Code‑Beispiel, wie Sie die Drehung des Wasserzeichens so anpassen, dass es diagonal über die Folie positioniert wird:
```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```


## **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht das Festlegen eines Formnamens. Durch die Verwendung des Formnamens können Sie die Form später zum Ändern oder Löschen finden. Um den Namen der Wasserzeichen‑Form festzulegen, weisen Sie ihn der [IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/)-Methode zu:
```cpp
watermarkShape->set_Name(u"watermark");
```


## **Ein Wasserzeichen entfernen**

Um die Wasserzeichen‑Form zu entfernen, verwenden Sie die [IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/)-Methode, um sie in den Folienformen zu finden. Anschließend übergeben Sie die Wasserzeichen‑Form an die [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/)-Methode:
```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```


## **Ein Live‑Beispiel**

Sie können die **Aspose.Slides free**‑Online‑Tools [Add Watermark](https://products.aspose.app/slides/watermark) und [Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark) testen.

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**Was ist ein Wasserzeichen und warum sollte ich es verwenden?**

Ein Wasserzeichen ist ein Text‑ oder Bildüberlagerung, die auf Folien angewendet wird, um geistiges Eigentum zu schützen, die Markenbekanntheit zu erhöhen oder die unbefugte Nutzung von Präsentationen zu verhindern.

**Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?**

Ja, Aspose.Slides ermöglicht das programmgesteuerte Hinzufügen eines Wasserzeichens zu jeder Folie einer Präsentation. Sie können durch alle Folien iterieren und die Wasserzeichen‑Einstellungen einzeln anwenden.

**Wie kann ich die Transparenz des Wasserzeichens anpassen?**

Sie können die Transparenz des Wasserzeichens ändern, indem Sie die Füll‑Einstellungen ([FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_fillformat/)) der Form anpassen. So bleibt das Wasserzeichen dezent und lenkt nicht vom Folieninhalt ab.

**Welche Bildformate werden für Wasserzeichen unterstützt?**

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und weitere.

**Kann ich die Schriftart und den Stil eines Text‑Wasserzeichens anpassen?**

Ja, Sie können jede Schriftart, Größe und jeden Stil wählen, um das Design Ihrer Präsentation und die Marken­konsistenz zu gewährleisten.

**Wie ändere ich die Position oder Ausrichtung eines Wasserzeichens?**

Sie können die Position und Ausrichtung des Wasserzeichens programmgesteuert ändern, indem Sie die Koordinaten, Größe und Drehungs‑Eigenschaften der Form anpassen.