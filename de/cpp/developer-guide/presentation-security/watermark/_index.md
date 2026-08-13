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
description: "Verwalten Sie Text- und Bildwasserzeichen in PowerPoint- und OpenDocument-Präsentationen in C++, um einen Entwurf, vertrauliche Informationen, Urheberrechte und mehr anzuzeigen."
---
## **Einleitung**

**Ein Wasserzeichen** in einer Präsentation ist ein Text- oder Bildstempel, der auf einer Folie oder in allen Folien einer Präsentation verwendet wird. Üblicherweise wird ein Wasserzeichen genutzt, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Draft“-Wasserzeichen), dass sie vertrauliche Informationen enthält (z. B. ein „Confidential“-Wasserzeichen), um anzugeben, zu welchem Unternehmen sie gehört (z. B. ein „Company Name“-Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden darf. Wasserzeichen werden sowohl in PowerPoint‑ als auch in OpenOffice‑Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint‑PPT, PPTX und OpenOffice‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/de/cpp/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und deren Design sowie Verhalten zu ändern. Der gemeinsame Aspekt ist, dass zum Hinzufügen von Textwasserzeichen das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/)-Interface verwendet werden sollte und zum Hinzufügen von Bildwasserzeichen die [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/)-Klasse oder das Füllen einer Wasserzeichen‑Form mit einem Bild. `PictureFrame` implementiert das [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/)-Interface, sodass Sie alle flexiblen Einstellungen des Form‑Objekts nutzen können. Da `ITextFrame` keine Form ist und seine Einstellungen begrenzt sind, wird es in ein [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/)-Objekt eingebettet.

Ein Wasserzeichen kann auf zwei Arten angewendet werden: auf eine einzelne Folie oder auf alle Folien der Präsentation. Der Folienmaster wird verwendet, um ein Wasserzeichen auf alle Folien anzuwenden — das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu ändern.

Ein Wasserzeichen gilt normalerweise als für andere Benutzer nicht editierbar. Um zu verhindern, dass das Wasserzeichen (bzw. die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Form‑Sperr‑Funktionalität. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn die Wasserzeichen‑Form auf dem Folienmaster gesperrt ist, wird sie auf allen Folien der Präsentation gesperrt sein.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es in Zukunft, falls Sie es löschen möchten, anhand des Namens in den Folienformen finden können.

Sie können das Wasserzeichen nach Belieben gestalten; üblicherweise gibt es jedoch gemeinsame Merkmale von Wasserzeichen, wie zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Wir werden im Folgenden sehen, wie diese in den Beispielen verwendet werden.

## **Textwasserzeichen**

### **Ein Textwasserzeichen zu einer Folie hinzufügen**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst eine Form zur Folie hinzufügen und dann dieser Form einen Textframe hinzufügen. Der Textframe wird durch das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/)-Interface repräsentiert. Dieser Typ erbt nicht von [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/), das über einen breiten Satz von Eigenschaften für die flexible Positionierung des Wasserzeichens verfügt. Daher wird das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/)-Objekt in ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/)-Objekt eingebettet. Um dem Text des Wasserzeichens zur Form hinzuzufügen, verwenden Sie die Methode [AddTextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/addtextframe/) wie unten gezeigt.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Siehe auch" %}} 
- [Wie man die TextFrame-Klasse verwendet](/slides/de/cpp/text-formatting/)
{{% /alert %}}

### **Ein Textwasserzeichen zu einer Präsentation hinzufügen**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation (d. h. allen Folien gleichzeitig) hinzufügen möchten, fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/masterslide/) hinzu. Der Rest der Logik ist derselbe wie beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie — erstellen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/)-Objekt und fügen Sie das Wasserzeichen mit der Methode [AddTextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/addtextframe/) hinzu.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Siehe auch" %}} 
- [Wie man den Folienmaster verwendet](/slides/de/cpp/slide-master/)
{{% /alert %}}

### **Transparenz der Wasserzeichen‑Form festlegen**

Standardmäßig ist die Rechteckform mit Füll‑ und Linienfarben formatiert. Die folgenden Codezeilen machen die Form transparent.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Schriftart für ein Textwasserzeichen festlegen**

Sie können die Schriftart des Textwasserzeichens wie unten gezeigt ändern.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Farbe des Wasserzeichentextes festlegen**

Um die Farbe des Wasserzeichentextes festzulegen, verwenden Sie diesen Code:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Textwasserzeichen zentrieren**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren; dafür können Sie Folgendes tun:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

![Das Textwasserzeichen](text_watermark.png)

## **Bildwasserzeichen**

### **Ein Bildwasserzeichen zu einer Präsentation hinzufügen**

Um ein Bildwasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes tun:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Ein Wasserzeichen vor Bearbeitung schützen**

Falls es erforderlich ist, ein Wasserzeichen vor Bearbeitung zu schützen, verwenden Sie die Methode [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/get_autoshapelock/) auf der Form. Mit dieser Eigenschaft können Sie die Form davor schützen, ausgewählt, in der Größe geändert, verschoben, mit anderen Elementen gruppiert, ihr Text vor Bearbeitung gesperrt und vieles mehr zu werden:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// Sperre die Wasserzeichenform vor Änderungen
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **Ein Wasserzeichen in den Vordergrund bringen**

In Aspose.Slides kann die Z‑Reihenfolge von Formen über die Methode [IShapeCollection::Reorder](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/reorder/) festgelegt werden. Dazu müssen Sie diese Methode aus der Liste der Präsentationsfolien aufrufen und die Formreferenz sowie deren Ordnungszahl an die Methode übergeben. Auf diese Weise kann eine Form in den Vordergrund oder in den Hintergrund der Folie gebracht werden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor den Inhalt der Präsentation platzieren müssen:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Wasserzeichen‑Drehung festlegen**

Hier ein Codebeispiel, wie die Drehung des Wasserzeichens angepasst wird, sodass es diagonal über die Folie positioniert ist:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht das Festlegen eines Namens für eine Form. Durch die Verwendung des Formnamens können Sie künftig darauf zugreifen, um sie zu ändern oder zu löschen. Um den Namen der Wasserzeichen‑Form festzulegen, weisen Sie ihn der Methode [IAutoShape::set_Name](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/set_name/) zu:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **Ein Wasserzeichen entfernen**

Um die Wasserzeichen‑Form zu entfernen, verwenden Sie die Methode [IAutoShape::get_Name](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_name/), um sie in den Folienformen zu finden. Anschließend übergeben Sie die Wasserzeichen‑Form an die Methode [IShapeCollection::Remove](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/remove/):

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **Ein Live‑Beispiel**

Vielleicht möchten Sie die **kostenlosen Aspose.Slides**‑Online‑Tools [Wasserzeichen hinzufügen](https://products.aspose.app/slides/de/watermark) und [Wasserzeichen entfernen](https://products.aspose.app/slides/de/watermark/remove-watermark) ausprobieren.

![Online‑Tools zum Hinzufügen und Entfernen von Wasserzeichen](online_tools.png)

## **FAQ**

### Was ist ein Wasserzeichen und warum sollte ich es verwenden?

Ein Wasserzeichen ist ein Text‑ oder Bild‑Overlay, das auf Folien angewendet wird und dabei hilft, geistiges Eigentum zu schützen, die Markenbekanntheit zu steigern oder die unbefugte Nutzung von Präsentationen zu verhindern.

### Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?

Ja, Aspose.Slides ermöglicht es, programmatisch ein Wasserzeichen zu jeder Folie einer Präsentation hinzuzufügen. Sie können durch alle Folien iterieren und die Wasserzeicheneinstellungen einzeln anwenden.

### Wie kann ich die Transparenz des Wasserzeichens anpassen?

Sie können die Transparenz des Wasserzeichens anpassen, indem Sie die Füll‑Einstellungen ([FillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/get_fillformat/)) der Form ändern. Dadurch wird das Wasserzeichen dezent und lenkt nicht vom Folieninhalt ab.

### Welche Bildformate werden für Wasserzeichen unterstützt?

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und weitere.

### Kann ich die Schriftart und den Stil eines Textwasserzeichens anpassen?

Ja, Sie können beliebige Schriftart, Größe und Stil wählen, um sie an das Design Ihrer Präsentation anzupassen und die Marken‑konsistenz zu wahren.

### Wie ändere ich die Position oder Orientierung eines Wasserzeichens?

Sie können die Position und Orientierung des Wasserzeichens programmatisch anpassen, indem Sie die Koordinaten, Größe und Drehungseigenschaften der Form ändern.