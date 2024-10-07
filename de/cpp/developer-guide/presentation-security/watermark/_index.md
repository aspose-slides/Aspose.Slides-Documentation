---
title: Wasserzeichen
type: docs
weight: 40
url: /cpp/watermark/
keywords:
- wasserzeichen
- wasserzeichen hinzufügen
- textwasserzeichen
- bildwasserzeichen
- PowerPoint
- präsentation
- C++
- Aspose.Slides für C++
description: "Fügen Sie Text- und Bildwasserzeichen zu PowerPoint-Präsentationen in C++ hinzu"
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text- oder Bildstempel, der auf einer Folie oder auf allen Folien der Präsentation verwendet wird. In der Regel wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein "Entwurf"-Wasserzeichen), dass sie vertrauliche Informationen enthält (z. B. ein "Vertraulich"-Wasserzeichen), um anzugeben, welcher Firma sie gehört (z. B. ein "Firmenname"-Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden sollte. Wasserzeichen werden sowohl in PowerPoint- als auch in OpenOffice-Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint PPT, PPTX und OpenOffice ODP-Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint- oder OpenOffice-Dokumenten zu erstellen und deren Design und Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Textwasserzeichen das [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) Interface verwenden sollten, und um Bildwasserzeichen hinzuzufügen, verwenden Sie die [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) Klasse oder füllen Sie eine Wasserzeichengeometrie mit einem Bild. `PictureFrame` implementiert das [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) Interface, sodass Sie alle flexiblen Einstellungen des Formenobjekts nutzen können. Da `ITextFrame` keine Form ist und seine Einstellungen begrenzt sind, wird es in einem [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) Objekt verpackt.

Es gibt zwei Möglichkeiten, wie ein Wasserzeichen angewendet werden kann: auf eine einzelne Folie oder auf alle Präsentationsfolien. Der Folienmaster wird verwendet, um ein Wasserzeichen auf alle Präsentationsfolien anzuwenden — das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne das Recht zur Bearbeitung des Wasserzeichens auf einzelnen Folien zu beeinträchtigen.

Ein Wasserzeichen wird normalerweise als nicht bearbeitbar für andere Benutzer betrachtet. Um zu verhindern, dass das Wasserzeichen (oder besser gesagt die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Funktion zum Sperren von Formen. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn die Wasserzeichenform auf dem Folienmaster gesperrt ist, wird sie auf allen Präsentationsfolien gesperrt.

Sie können ein Wasserzeichen benennen, sodass Sie es in Zukunft, falls Sie es löschen möchten, anhand des Namens in den Formen der Folie finden können.

Sie können das Wasserzeichen auf beliebige Weise gestalten; jedoch gibt es normalerweise allgemeine Merkmale in Wasserzeichen, wie z. B. zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Wir werden im Folgenden betrachten, wie man diese in den Beispielen verwendet.

## **Textwasserzeichen**

### **Fügen Sie ein Textwasserzeichen zu einer Folie hinzu**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst eine Form zur Folie hinzufügen und dann ein Textfeld zu dieser Form hinzufügen. Das Textfeld wird durch das [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) Interface dargestellt. Dieser Typ erbt nicht von [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), das über eine breite Palette von Eigenschaften zur flexiblen Positionierung des Wasserzeichens verfügt. Daher wird das [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) Objekt in ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) Objekt verpackt. Um den Wasserzeichentext zur Form hinzuzufügen, verwenden Sie die [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) Methode, wie unten gezeigt.

```cpp
auto watermarkText = u"VERTRAULICH";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man die TextFrame-Klasse verwendet](/slides/cpp/text-formatting/)
{{% /alert %}}

### **Fügen Sie ein Textwasserzeichen zu einer Präsentation hinzu**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation (d. h. zu allen Folien auf einmal) hinzufügen möchten, fügen Sie es zum [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) hinzu. Der Rest der Logik bleibt gleich wie beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie — erstellen Sie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) Objekt und fügen Sie dann das Wasserzeichen mit der [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) Methode hinzu.

```cpp
auto watermarkText = u"VERTRAULICH";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man den Folienmaster verwendet](/slides/cpp/slide-master/)
{{% /alert %}}

### **Setzen Sie die Transparenz der Wasserzeichenform**

Standardmäßig wird die Rechtecksform mit Füll- und Linienfarben gestaltet. Die folgenden Codezeilen machen die Form transparent.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Setzen Sie die Schriftart für ein Textwasserzeichen**

Sie können die Schriftart des Textwasserzeichens wie folgt ändern.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Setzen Sie die Textfarbe des Wasserzeichens**

Um die Farbe des Wasserzeichentextes festzulegen, verwenden Sie diesen Code:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Zentrieren Sie ein Textwasserzeichen**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren, und dafür können Sie Folgendes tun:

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

![Das Textwasserzeichen](text_watermark.png)

## **Bildwasserzeichen**

### **Fügen Sie ein Bildwasserzeichen zu einer Präsentation hinzu**

Um ein Bildwasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes tun:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Sperren Sie ein Wasserzeichen gegen Bearbeitung**

Wenn es notwendig ist, ein Wasserzeichen vor Bearbeitungen zu schützen, verwenden Sie die [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/) Methode auf der Form. Mit dieser Eigenschaft können Sie die Form vor der Auswahl, Größenänderung, Neupositionierung, Gruppierung mit anderen Elementen schützen, ihren Text vor der Bearbeitung sperren und vieles mehr:

```cpp
// Die Wasserzeichenform gegen Modifizierungen sperren
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Bringen Sie ein Wasserzeichen nach vorne**

In Aspose.Slides kann die Z-Reihenfolge von Formen über die [IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/) Methode festgelegt werden. Dazu müssen Sie diese Methode aus der Liste der Folien der Präsentation aufrufen und den Verweis auf die Form sowie ihre Reihenfolge in die Methode übergeben. Auf diese Weise ist es möglich, eine Form nach vorne zu bringen oder sie in den Hintergrund der Folie zu senden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor der Präsentation platzieren müssen:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Setzen Sie die Wasserzeichenrotation**

Hier ist ein Beispielcode, wie Sie die Rotation des Wasserzeichens anpassen können, sodass es diagonal über die Folie positioniert ist:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht es Ihnen, den Namen einer Form festzulegen. Mit dem Namen der Form können Sie in Zukunft darauf zugreifen, um sie zu modifizieren oder zu löschen. Um den Namen der Wasserzeichenform festzulegen, weisen Sie ihn der [IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/) Methode zu:

```cpp
watermarkShape->set_Name(u"wasserzeichen");
```

## **Entfernen Sie ein Wasserzeichen**

Um die Wasserzeichenform zu entfernen, verwenden Sie die [IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/) Methode, um sie in den Formen der Folie zu finden. Übergeben Sie dann die Wasserzeichenform an die [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) Methode:

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"wasserzeichen", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **Ein Live-Beispiel**

Sie möchten vielleicht die **Aspose.Slides kostenlose** [Wasserzeichen hinzufügen](https://products.aspose.app/slides/watermark) und [Wasserzeichen entfernen](https://products.aspose.app/slides/watermark/remove-watermark) Online-Tools ausprobieren.

![Online-Tools zum Hinzufügen und Entfernen von Wasserzeichen](online_tools.png)