---
title: PowerPoint-Textabsätze in C++ verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- Text hinzufügen
- Absatz hinzufügen
- Text verwalten
- Absatz verwalten
- Aufzählungszeichen verwalten
- Absatz Einzug
- hängender Einzug
- Absatz Aufzählungszeichen
- nummerierte Liste
- Aufzählungsliste
- Absatz Eigenschaften
- HTML importieren
- Text zu HTML
- Absatz zu HTML
- Absatz zu Bild
- Text zu Bild
- Absatz exportieren
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für C++ Absätze, Teile, Aufzählungszeichen, nummerierte Listen, Einzüge, HTML‑Inhalte und Absatz‑Bilder erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für C++ stellt Text als Hierarchie von Textfeldern, Absätzen und Teilen dar:

* [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) stellt den Textbehälter in einer Form dar und liefert Zugriff auf die zugehörige Absatzsammlung.
* [IParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/) stellt einen Absatz in einem Textfeld dar und liefert Zugriff auf seine Teile und die Absatz‑Formatierung.
* [IPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/) stellt einen Textlauf innerhalb eines Absatzes dar. Jeder Teil kann eigenen Text und Zeichenformatierung besitzen.

Ein Absatz kann daher Text mit unterschiedlichen Schriften, Farben, Größen und anderer Formatierung enthalten, indem mehrere Teile verwendet werden.

## **Absätze erstellen und formatieren**

### **Absätze mit mehreren Teilen erstellen**

Die folgenden Schritte erstellen ein Textfeld mit drei Absätzen, wobei jeder Absatz drei Teile enthält:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die betreffende Folie zu.
3. Fügen Sie der Folie ein rechteckiges [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) der Form zu.
5. Verwenden Sie den Standardabsatz und fügen Sie dem Textfeld zwei weitere [IParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/)‑Objekte hinzu.
6. Fügen Sie genügend [IPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/)‑Objekte hinzu, damit jeder Absatz drei Teile enthält. Der Standardabsatz enthält bereits einen leeren Teil.
7. Setzen Sie den Text jedes Teils.
8. Wenden Sie Zeichenformatierung über [IPortion::get_PortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/get_portionformat/) an.
9. Speichern Sie die geänderte Präsentation.

Dieses C++‑Beispiel implementiert die Schritte:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Aufgezählte und nummerierte Listen erstellen**

### **Eine Aufzählungs‑ oder Nummernliste erstellen**

Aufzählungszeichen und Nummerierung erleichtern das Scannen verwandter Elemente. In Aspose.Slides werden Listeneinstellungen über [IBulletFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/) definiert.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die betreffende Folie zu.
3. Fügen Sie der ausgewählten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) der Form zu.
5. Entfernen Sie den Standardabsatz aus dem Textfeld.
6. Erstellen Sie ein [Paragraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/paragraph/) für ein Symbol‑Aufzählungszeichen.
7. Setzen Sie [IBulletFormat::set_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_type/) auf [BulletType::Symbol](https://reference.aspose.com/slides/de/cpp/aspose.slides/bullettype/) und geben Sie das Aufzählungszeichen‑Symbol an.
8. Legen Sie den Absatztext, Einzug, Aufzählungszeichen‑Farbe und Aufzählungszeichen‑Größe fest.
9. Fügen Sie den Absatz dem Textfeld hinzu.
10. Erstellen Sie einen zweiten Absatz und setzen Sie [IBulletFormat::set_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_type/) auf [BulletType::Numbered](https://reference.aspose.com/slides/de/cpp/aspose.slides/bullettype/).
11. Konfigurieren Sie den nummerierten Aufzählungsstil und fügen Sie den Absatz dem Textfeld hinzu.
12. Speichern Sie die Präsentation.

Dieses C++‑Beispiel erstellt ein Symbol‑Aufzählungszeichen und ein nummeriertes Aufzählungszeichen:

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Bild‑Aufzählungszeichen verwenden**

Bild‑Aufzählungszeichen ermöglichen die Verwendung eines eigenen Bildes anstelle eines Symbols oder einer Zahl.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die betreffende Folie zu.
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu und greifen Sie auf dessen [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) zu.
4. Entfernen Sie den Standardabsatz aus dem Textfeld.
5. Laden Sie das Aufzählungs‑Bild und fügen Sie es der Bildsammlung der Präsentation als [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) hinzu.
6. Erstellen Sie ein [Paragraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/paragraph/) und setzen Sie dessen Text.
7. Setzen Sie [IBulletFormat::set_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_type/) auf [BulletType::Picture](https://reference.aspose.com/slides/de/cpp/aspose.slides/bullettype/).
8. Weisen Sie das Bild über [ISlidesPicture::set_Image](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidespicture/set_image/) zu und setzen Sie die Aufzählungs‑Höhe.
9. Fügen Sie den Absatz dem Textfeld hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieses C++‑Beispiel erstellt ein Bild‑Aufzählungszeichen:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **Eine mehrstufige Liste erstellen**

Setzen Sie [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_depth/), um Absätze auf unterschiedlichen Ebenen einer Liste zu platzieren. Die oberste Ebene hat eine Tiefe von `0`.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) und greifen Sie auf eine Folie zu.
2. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu und entfernen Sie den Standardabsatz aus dessen Textfeld.
3. Erstellen Sie vier Absätze und konfigurieren Sie deren Aufzählungs‑Symbole.
4. Setzen Sie deren [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_depth/)‑Werte auf `0`, `1`, `2` und `3`.
5. Fügen Sie die Absätze dem Textfeld hinzu und speichern Sie die Präsentation.

Dieses C++‑Beispiel erstellt eine vierstufige Aufzählungsliste:

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Nummerierte Listenelemente mit benutzerdefinierten Startwerten beginnen**

Verwenden Sie [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/), um die Anfangszahl für einen nummerierten Absatz festzulegen.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) und fügen Sie einer Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
2. Entfernen Sie den Standardabsatz aus dem Textfeld der Form.
3. Erstellen Sie drei nummerierte Absätze.
4. Setzen Sie [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) auf `2`, `3` bzw. `7` für die jeweiligen Absätze.
5. Fügen Sie die Absätze dem Textfeld hinzu und speichern Sie die Präsentation.

Dieses C++‑Beispiel weist jedem Absatz einen benutzerdefinierten Startwert zu:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Absatzlayout und End‑Eigenschaften steuern**

### **Erstzeileneinzug festlegen**

Verwenden Sie [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_indent/), um den Erstzeileneinzug eines Absatzes zu steuern. Diese Methode verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_marginleft/), wenn Sie den gesamten Absatz verschieben wollen. Verwenden Sie [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_indent/), wenn Sie nur die erste Zeile verschieben möchten.

Das nachstehende Beispiel erstellt mehrere Absätze und wendet unterschiedliche [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_indent/)‑Werte an, um zu zeigen, wie sich der Erstzeileneinzug auf das Layout auswirkt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) der Form zu und entfernen Sie den Standardabsatz.
5. Erstellen Sie mehrere Absätze und setzen Sie für jeden unterschiedliche [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_indent/)‑Werte.
6. Fügen Sie die Absätze dem Textfeld hinzu.
7. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie ein Absatz‑Einzug gesetzt wird:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Der Erstzeileneinzug der Absätze](first_line_indent.png)

### **Hängenden Einzug festlegen**

Ein hängender Einzug ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_indent/). Setzen Sie den Einzug auf einen negativen Wert, um die erste Zeile nach links zu verschieben.

In der Praxis definiert [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_marginleft/) die linke Position des Absatzkörpers, und [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_indent/) definiert die Position der ersten Zeile relativ zu diesem Rand. Für einen hängenden Einzug setzen Sie einen positiven margin‑left‑Wert und einen negativen Einzug‑Wert.

Diese Formatierung ist nützlich für Bibliographien, Verweise, Glossareinträge und andere Absätze, bei denen umgebrochene Zeilen unter dem Absatzkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet werden sollen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) der Form zu und entfernen Sie den Standardabsatz.
5. Erstellen Sie Absätze und setzen Sie für jeden einen positiven [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_marginleft/)‑Wert.
6. Setzen Sie einen negativen [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_indent/)‑Wert, um den hängenden Einzug zu erzeugen.
7. Fügen Sie die Absätze dem Textfeld hinzu.
8. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie ein hängender Einzug für einen Absatz gesetzt wird:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Der hängende Einzug der Absätze](hanging_indent.png)

### **End‑Absatz‑Lauf‑Eigenschaften festlegen**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) steuert die Formatierung des Absatz‑Endzeichens. Das folgende Beispiel weist dem Endzeichen des zweiten Absatzes eine Schriftgröße und eine lateinische Schriftart zu:

1. Laden Sie eine [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) und greifen Sie auf eine Folie zu.
2. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu und entfernen Sie dessen Standardabsatz.
3. Erstellen Sie zwei Absätze und fügen Sie ihnen Text‑Teile hinzu.
4. Erzeugen Sie ein [PortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/portionformat/) für das Endzeichen des zweiten Absatzes.
5. Setzen Sie [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseportionformat/set_fontheight/) und [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseportionformat/set_latinfont/).
6. Weisen Sie das Format mit [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) zu und speichern Sie die Präsentation.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Absatzinhalt importieren und exportieren**

### **HTML‑Text in Absätze importieren**

Verwenden Sie [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphcollection/addfromhtml/), um HTML‑Markup in Absätze und Teile eines Textfelds zu konvertieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Greifen Sie auf eine Folie zu und fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
3. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) der Form zu und entfernen Sie den Standardabsatz.
4. Lesen Sie die Quell‑HTML‑Datei.
5. übergeben Sie die HTML‑Zeichenkette an [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphcollection/addfromhtml/).
6. Speichern Sie die geänderte Präsentation.

Dieses C++‑Beispiel importiert HTML in ein Textfeld:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Absatz‑Text nach HTML exportieren**

Verwenden Sie [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphcollection/exporttohtml/), um einen ausgewählten Absatz‑Bereich als HTML zu exportieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) und laden Sie die gewünschte Präsentation.
2. Greifen Sie auf die Folie zu und suchen Sie das [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/), das den Text enthält.
3. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) der Form zu.
4. Rufen Sie [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphcollection/exporttohtml/) mit dem Start‑Absatz‑Index und der Anzahl der zu exportierenden Absätze auf.
5. Schreiben Sie die zurückgegebene HTML‑Zeichenkette in eine Datei.

Dieses C++‑Beispiel exportiert alle Absätze aus der ersten Textform:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **Einen Absatz als Bild rendern**

[IParagraph::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/getimage/) rendert einen einzelnen Absatz direkt und gibt ein [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/) zurück. Speichern Sie das Ergebnis mit [IImage::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/save/) in einer Datei oder einem Stream. Sie müssen nicht die umgebende Form rendern oder ein Bitmap manuell zuschneiden.

[IParagraph::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/getimage/) kann `nullptr` zurückgeben, wenn der Absatz in seiner übergeordneten Sammlung nicht gefunden wird, keine gültigen Render‑Bounds hat oder nicht gerendert werden kann. Prüfen Sie das Ergebnis, bevor Sie es speichern, und geben Sie das zurückgegebene Bild nach der Verwendung frei.

#### **Absatz mit Standard‑Skalierung rendern**

Angenommen, wir haben eine Präsentationsdatei namens sample.pptx mit einer Folie, wobei die erste Form ein Textfeld mit drei Absätzen ist.

![Das Textfeld mit drei Absätzen](paragraph_to_image_input.png)

Das folgende Beispiel rendert den zweiten Absatz in einer normalen Textform mit Standard‑Skalierung und speichert das zurückgegebene Bild im PNG‑Format.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

Das Ergebnis:

![Das Absatz‑Bild](paragraph_to_image_output.png)

#### **Absatz in einer Tabellenzelle mit Skalierung rendern**

Verwenden Sie die Überladung von [IParagraph::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/getimage/), die die Parameter `float scaleX` und `float scaleY` akzeptiert, um die horizontalen und vertikalen Skalierungsfaktoren festzulegen. Das folgende Beispiel erstellt eine Tabelle, rendert den Absatz in deren erster Zelle mit dem doppelten Standard‑Breiten‑ und Höhenwert und speichert das Ergebnis als PNG‑Bild.

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

Ein Skalierungsfaktor von `1` behält die Standard‑Pixelgröße der jeweiligen Achse bei. Beispielsweise erzeugt `2` für beide Faktoren ein Bild, dessen Breite und Höhe etwa doppelt so groß sind wie die Standard‑Dimensionen, was zu viermal so vielen Pixeln führt. Größere Faktoren erzeugen im Allgemeinen schärferen Text für Zoom‑ oder hochauflösende Ausgaben, erhöhen jedoch Speicher‑ und Dateigröße. Faktoren unter `1` erzeugen kleinere Bilder mit weniger Details. Verwenden Sie gleiche Faktoren, um das Seitenverhältnis des Absatzes beizubehalten; unterschiedliche horizontale und vertikale Faktoren strecken die Ausgabe unabhängig voneinander.

Das Rendern einer gesamten Form mit [IShape::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/getimage/) bleibt sinnvoll, wenn das Ergebnis die Füllung, den Rand oder andere visuelle Kontexte der Form enthalten soll. Für ein reines Absatz‑Bild verwenden Sie [IParagraph::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Kann ich das Zeilen‑Umbrechen innerhalb eines Textfeldes komplett deaktivieren?**

Ja. Verwenden Sie [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/set_wraptext/), um das Umbrechen zu deaktivieren, sodass Zeilen nicht an den Rändern des Textfeldes umbrechen.

**Wie erhalte ich die genauen on‑slide‑Bounds eines bestimmten Absatzes?**

Verwenden Sie [IParagraph::GetRect](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/getrect/), um das Begrenzungs‑Rechteck des Absatzes zu erhalten. [IPortion::GetRect](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/getrect/) liefert die Bounds eines einzelnen Teils.

**Wo wird die Absatz‑Ausrichtung (links, rechts, zentriert oder Blocksatz) gesteuert?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_alignment/) ist eine Absatz‑Ebene‑Einstellung und gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Teile.

**Kann ich die Korrektursprache für einen Teil eines Absatzes festlegen?**

Ja. Verwenden Sie [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseportionformat/set_languageid/) für einzelne Teile, sodass ein Absatz Text in mehreren Sprachen enthalten kann.