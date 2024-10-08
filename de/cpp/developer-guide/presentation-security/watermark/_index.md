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
description: "Fügen Sie Text- und Bildwasserzeichen in C++ zu PowerPoint-Präsentationen hinzu"
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text- oder Bildstempel, der auf einer Folie oder auf allen Folien der Präsentation verwendet wird. In der Regel wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein "Entwurf"-Wasserzeichen), dass sie vertrauliche Informationen enthält (z. B. ein "Vertraulich"-Wasserzeichen), um anzugeben, welchem Unternehmen sie gehört (z. B. ein "Unternehmensname"-Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden darf. Wasserzeichen werden sowohl im PowerPoint- als auch im OpenOffice-Präsentationsformat verwendet. In Aspose.Slides können Sie ein Wasserzeichen in den PowerPoint PPT-, PPTX- und OpenOffice ODP-Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint- oder OpenOffice-Dokumenten zu erstellen und deren Design und Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie für das Hinzufügen von Textwasserzeichen das [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) Interface verwenden sollten und für das Hinzufügen von Bildwasserzeichen die [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) Klasse oder eine Wasserzeichengestalt mit einem Bild füllen. `PictureFrame` implementiert das [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) Interface, was es Ihnen ermöglicht, alle flexiblen Einstellungen des Formobjekts zu verwenden. Da `ITextFrame` keine Form ist und seine Einstellungen begrenzt sind, wird es in ein [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) Objekt eingewickelt.

Es gibt zwei Möglichkeiten, wie ein Wasserzeichen angewendet werden kann: auf eine einzelne Folie oder auf alle Präsentationsfolien. Der Folienmaster wird verwendet, um ein Wasserzeichen auf allen Präsentationsfolien anzuwenden — das Wasserzeichen wird zum Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne das Recht zur Modifizierung des Wasserzeichens auf einzelnen Folien zu beeinträchtigen.

Ein Wasserzeichen wird in der Regel als nicht bearbeitbar für andere Benutzer betrachtet. Um zu verhindern, dass das Wasserzeichen (oder besser gesagt, die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Funktion zur Formverriegelung. Eine spezifische Form kann auf einer normalen Folie oder auf einem Folienmaster verriegelt werden. Wenn die Wasserzeichengestalt auf dem Folienmaster verriegelt ist, wird sie auf allen Präsentationsfolien verriegelt.

Sie können dem Wasserzeichen einen Namen geben, damit Sie es in Zukunft, falls Sie es löschen möchten, in den Formen der Folie nach dem Namen finden können.

Sie können das Wasserzeichen auf beliebige Weise gestalten; es gibt jedoch normalerweise gemeinsame Merkmale in Wasserzeichen, wie z. B. zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Wir werden im Folgenden betrachten, wie man diese in den Beispielen nutzt.

## **Textwasserzeichen**

### **Fügen Sie ein Textwasserzeichen zu einer Folie hinzu**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zuerst eine Form zur Folie hinzufügen und dann einen Textrahmen zu dieser Form hinzufügen. Der Textrahmen wird durch das [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) Interface dargestellt. Dieser Typ erbt nicht von [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), das eine breite Palette von Eigenschaften zur flexiblen Positionierung des Wasserzeichens hat. Daher wird das [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) Objekt in ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) Objekt eingewickelt. Um dem Formobjekt Wasserzeichentext hinzuzufügen, verwenden Sie die Methode [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) wie unten gezeigt.

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

### **Fügen Sie ein Textwasserzeichen zur gesamten Präsentation hinzu**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation (d. h. alle Folien auf einmal) hinzufügen möchten, fügen Sie es zum [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) hinzu. Der Rest der Logik ist derselbe wie beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie — erstellen Sie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) Objekt und fügen Sie dann das Wasserzeichen mit der Methode [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) hinzu.

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

### **Setzen Sie die Transparenz der Wasserzeichengestalt**

Standardmäßig ist die rechteckige Form mit Füll- und Liniefarben gestaltet. Die folgenden Codezeilen machen die Form transparent.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Setzen Sie die Schriftart für ein Textwasserzeichen**

Sie können die Schriftart des Textwasserzeichens wie unten gezeigt ändern.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Setzen Sie die Textfarbe des Wasserzeichens**

Um die Farbe des Wasserzeichentextes zu setzen, verwenden Sie diesen Code:

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

## **Ein Wasserzeichen vor Änderungen sperren**

Wenn es notwendig ist, zu verhindern, dass ein Wasserzeichen bearbeitet wird, verwenden Sie die Methode [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/) auf der Form. Mit dieser Eigenschaft können Sie die Form vor dem Auswählen, Ändern der Größe, erneuten Positionieren, Gruppieren mit anderen Elementen, dem Sperren des Textes vor Änderungen und vieles mehr schützen:

```cpp
// Sperren Sie die Wasserzeichengestalt vor Änderungen
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Ein Wasserzeichen nach vorne bringen**

In Aspose.Slides kann die Z-Reihenfolge von Formen über die Methode [IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/) festgelegt werden. Dazu müssen Sie diese Methode aus der Folienliste der Präsentation aufrufen und die Formreferenz sowie ihre Reihenfolgenummer in die Methode übergeben. So ist es möglich, eine Form nach vorne zu bringen oder sie zurück auf die Folie zu senden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor der Präsentation platzieren müssen:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Setzen Sie die Wasserzeichenrotation**

Hier ist ein Codebeispiel, wie Sie die Rotation des Wasserzeichens anpassen können, sodass es diagonal über die Folie positioniert ist:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Setzen Sie einen Namen für ein Wasserzeichen**

Aspose.Slides ermöglicht es Ihnen, den Namen einer Form festzulegen. Indem Sie den Formnamen verwenden, können Sie in Zukunft darauf zugreifen, um ihn zu ändern oder zu löschen. Um den Namen der Wasserzeichengestalt festzulegen, weisen Sie ihn der Methode [IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/) zu:

```cpp
watermarkShape->set_Name(u"wasserzeichen");
```

## **Entfernen Sie ein Wasserzeichen**

Um die Wasserzeichengestalt zu entfernen, verwenden Sie die Methode [IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/) um sie in den Folienformen zu finden. Übergeben Sie dann die Wasserzeichengestalt an die Methode [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/):

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