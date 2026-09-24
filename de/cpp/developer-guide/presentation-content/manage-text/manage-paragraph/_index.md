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
- Absatz-Einzug
- Hängender Einzug
- Absatz-Aufzählungszeichen
- Nummerierte Liste
- Aufzählungsliste
- Absatzeigenschaften
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
description: "Erfahren Sie, wie Sie mit Aspose.Slides für C++ Absätze, Portionen, Aufzählungszeichen, nummerierte Listen, Einzüge, HTML-Inhalte und Absatzbilder erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für C++ stellt Text als Hierarchie von Textfeldern, Absätzen und Portionen dar:

* [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) stellt den Textbehälter in einer Form dar und bietet Zugriff auf die Absatzsammlung.
* [IParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/) repräsentiert einen Absatz in einem Textfeld und bietet Zugriff auf seine Portionen und absatzbezogene Formatierung.
* [IPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/) stellt einen Textlauf innerhalb eines Absatzes dar. Jede Portion kann eigenen Text und Zeichenformatierung besitzen.

Ein Absatz kann daher Text mit verschiedenen Schriften, Farben, Größen und anderer Formatierung enthalten, indem mehrere Portionen verwendet werden.

## **Absätze erstellen und formatieren**

### **Absätze mit mehreren Portionen erstellen**

Die folgenden Schritte erstellen ein Textfeld mit drei Absätzen, die jeweils drei Portionen enthalten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie ein rechteckiges [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) der Form zu.
5. Verwenden Sie den Standardabsatz und fügen Sie dem Textfeld zwei weitere [IParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/)‑Objekte hinzu.
6. Fügen Sie genügend [IPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/)‑Objekte hinzu, sodass jeder Absatz drei Portionen enthält. Der Standardabsatz enthält bereits eine leere Portion.
7. Setzen Sie den Text jeder Portion.
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

## **Aufzählungs‑ und nummerierte Listen erstellen**

### **Eine Aufzählungs‑ oder nummerierte Liste erstellen**

Aufzählungszeichen und Nummerierung erleichtern das Durchsehen verwandter Elemente. In Aspose.Slides werden Listeneinstellungen über [IBulletFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/) definiert.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der ausgewählten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) der Form zu.
5. Entfernen Sie den Standardabsatz aus dem Textfeld.
6. Erstellen Sie ein [Paragraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/paragraph/) für ein Symbol‑Aufzählungszeichen.
7. Setzen Sie [IBulletFormat::set_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_type/) auf [BulletType::Symbol](https://reference.aspose.com/slides/de/cpp/aspose.slides/bullettype/) und geben Sie das Aufzählungszeichenzeichen an.
8. Setzen Sie den Absatztext, Einzug, Aufzählungsfarbe und Aufzählungsgröße.
9. Fügen Sie den Absatz dem Textfeld hinzu.
10. Erstellen Sie einen zweiten Absatz und setzen Sie [IBulletFormat::set_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_type/) auf [BulletType::Numbered](https://reference.aspose.com/slides/de/cpp/aspose.slides/bullettype/).
11. Konfigurieren Sie den Stil des nummerierten Aufzählungszeichens und fügen Sie den Absatz dem Textfeld hinzu.
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

### **Bildaufzählungszeichen verwenden**

Bildaufzählungszeichen ermöglichen die Verwendung eines benutzerdefinierten Bildes anstelle eines Symbols oder einer Zahl.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu und greifen Sie auf dessen [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) zu.
4. Entfernen Sie den Standardabsatz aus dem Textfeld.
5. Laden Sie das Aufzählungsbild und fügen Sie es der Bildsammlung der Präsentation als [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) hinzu.
6. Erstellen Sie ein [Paragraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/paragraph/) und setzen Sie dessen Text.
7. Setzen Sie [IBulletFormat::set_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_type/) auf [BulletType::Picture](https://reference.aspose.com/slides/de/cpp/aspose.slides/bullettype/).
8. Weisen Sie das Bild über [ISlidesPicture::set_Image](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidespicture/set_image/) zu und setzen Sie die Aufzählungsgröße.
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

Setzen Sie [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_depth/), um Absätze auf verschiedenen Ebenen einer Liste zu platzieren. Die oberste Ebene hat eine Tiefe von `0`.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) und greifen Sie auf eine Folie zu.
2. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu und löschen Sie den Standardabsatz aus dessen Textfeld.
3. Erstellen Sie vier Absätze und konfigurieren Sie deren Aufzählungssymbole.
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

### **Nummerierte Listeneinträge mit benutzerdefinierten Werten beginnen**

Verwenden Sie [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/), um die für einen nummerierten Absatz angezeigte Anfangszahl festzulegen.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) und fügen Sie einer Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
2. Löschen Sie den Standardabsatz aus dem Textfeld der Form.
3. Erstellen Sie drei nummerierte Absätze.
4. Setzen Sie [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) für die jeweiligen Absätze auf `2`, `3` bzw. `7`.
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

### **Einrückung der ersten Zeile festlegen**

Verwenden Sie [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_indent/), um die Einrückung der ersten Zeile eines Absatzes zu steuern. Diese Methode verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die restlichen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_marginleft/), wenn Sie den gesamten Absatz verschieben müssen. Verwenden Sie [IParagraphFormat::set_Indent], wenn Sie nur die erste Zeile verschieben müssen.

Das untenstehende Beispiel erstellt mehrere Absätze und wendet unterschiedliche [IParagraphFormat::set_Indent]-Werte an, um zu zeigen, wie die Einrückung der ersten Zeile das Absatzlayout beeinflusst.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Greifen Sie auf die Ziel‑folie zu.
3. Fügen Sie der Folie ein rechteckiges [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) der Form zu und entfernen Sie den Standardabsatz.
5. Erstellen Sie mehrere Absätze und setzen Sie unterschiedliche [IParagraphFormat::set_Indent]-Werte dafür.
6. Fügen Sie die Absätze dem Textfeld hinzu.
7. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie man eine Absatz‑Einrückung festlegt:

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **Hängende Einrückung festlegen**

Eine hängende Einrückung ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit [IParagraphFormat::set_Indent]. Setzen Sie die Einrückung auf einen negativen Wert, um die erste Zeile relativ zum Absatzkörper nach links zu verschieben.

In der Praxis definiert [IParagraphFormat::set_MarginLeft] die linke Position des Absatzkörpers und [IParagraphFormat::set_Indent] die Position der ersten Zeile relativ zu diesem Rand. Um eine hängende Einrückung zu erzeugen, setzen Sie einen positiven Margin‑Left‑Wert und einen negativen Einrückungswert.

Diese Formatierung ist nützlich für Bibliografien, Verweise, Glossareinträge und andere Absätze, bei denen umgebrochene Zeilen unter dem Absatzkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein müssen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Greifen Sie auf die Ziel‑folie zu.
3. Fügen Sie der Folie ein rechteckiges [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) der Form zu und entfernen Sie den Standardabsatz.
5. Erstellen Sie Absätze und setzen Sie für jeden Absatz einen positiven [IParagraphFormat::set_MarginLeft]-Wert.
6. Setzen Sie einen negativen [IParagraphFormat::set_Indent]-Wert, um den Effekt der hängenden Einrückung zu erzeugen.
7. Fügen Sie die Absätze dem Textfeld hinzu.
8. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie man für einen Absatz eine hängende Einrückung festlegt:

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **End‑Absatz‑Lauf‑Eigenschaften festlegen**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) steuert die Formatierung des Absatzendzeichens. Das folgende Beispiel weist dem Endzeichen des zweiten Absatzes eine Schriftgröße und eine lateinische Schrift zu:

1. Laden Sie eine [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) und greifen Sie auf eine Folie zu.
2. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu und entfernen Sie dessen Standardabsatz.
3. Erstellen Sie zwei Absätze und fügen Sie Textportionen hinzu.
4. Erstellen Sie ein [PortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/portionformat/) für das Endzeichen des zweiten Absatzes.
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

## **Gerenderte Zeilen zählen**

Verwenden Sie [IParagraph::GetLinesCount](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/getlinescount/), um die nach der Textanordnung von einem Absatz belegten Zeilen zu zählen, einschließlich automatischem Umbruch. Dies ist nützlich, wenn Sie die Textlänge und das Layout in Präsentationsvorlagen prüfen.

Ein Absatz ist ein Element in [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_paragraphs/ ) und kann mehrere gerenderte Zeilen beanspruchen. Ein expliziter Zeilenumbruch innerhalb eines Absatzes erzwingt eine neue Zeile, ohne einen weiteren Absatz zu erzeugen. Automatischer Umbruch erzeugt Zeilen basierend auf der verfügbaren Breite, ohne explizite Zeilenumbrüche in den Text einzufügen. Das Zählen von Absätzen oder Zeilenumbruch‑Zeichen liefert daher nicht die Anzahl der gerenderten Zeilen.

Das folgende Beispiel erstellt ein Textobjekt, zählt seine Zeilen, verengt die Form und ersetzt anschließend den Text durch eine kürzere Zeichenkette. Der Umbruch ist aktiviert und die automatische Anpassung deaktiviert, sodass die Formbreite den Umbruch steuert, ohne den Text automatisch zu verkleinern oder die Form zu skalieren. Die Formabmessungen sind in Punkten angegeben. Abschließend fügt das Beispiel einen weiteren Absatz hinzu und summiert die Zeilenzahlen über das Textfeld.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
paragraph->set_Text(u"This text demonstrates how automatic wrapping changes the number of rendered lines.");
Console::WriteLine(u"Original width: {0}", paragraph->GetLinesCount());

shape->set_Width(150);
Console::WriteLine(u"Narrower shape: {0}", paragraph->GetLinesCount());

paragraph->set_Text(u"Short text.");
Console::WriteLine(u"Shorter text: {0}", paragraph->GetLinesCount());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Another paragraph.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto totalLineCount = 0;
for (auto currentParagraph : textFrame->get_Paragraphs())
{
    totalLineCount += currentParagraph->GetLinesCount();
}
Console::WriteLine(u"Total lines in the text frame: {0}", totalLineCount);
presentation->Dispose();
```

Bei diesem Text und diesen Abmessungen erhöht das Verengen der Form die Zeilenzahl, während das Ersetzen des Textes durch die kurze Zeichenkette sie verringert. Die genauen Zählungen können je nach Schriftverfügbarkeit und -ersatz, Schriftgröße, Rändern, Einrückungen, Umbruch und Autofit‑Einstellungen variieren. Verwenden Sie die für die Zielumgebung vorgesehenen Schriften und Layout‑Einstellungen, wenn Sie eine Vorlage prüfen.

Die reine Zeilenzahl bestimmt nicht, ob der Text seinen Container überschreitet. Auch die verfügbare Höhe, Zeilenhöhen, Absatz‑ und Zeilenabstände sowie das Verhalten von Autofit sind wichtig; bereits eine einzelne Zeile kann die verfügbare Breite überschreiten, wenn der Umbruch deaktiviert ist.

## **Absatzinhalt importieren und exportieren**

### **HTML‑Text in Absätze importieren**

Verwenden Sie [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphcollection/addfromhtml/), um HTML‑Markup in Absätze und Portionen in einem Textfeld zu konvertieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Greifen Sie auf eine Folie zu und fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
3. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) der Form zu und löschen Sie den Standardabsatz.
4. Laden Sie die Quell‑HTML‑Datei.
5. Geben Sie die HTML‑Zeichenkette an [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphcollection/addfromhtml/) weiter.
6. Speichern Sie die geänderte Präsentation.

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

### **Absatztext nach HTML exportieren**

Verwenden Sie [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphcollection/exporttohtml/), um einen ausgewählten Bereich von Absätzen als HTML zu exportieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) und laden Sie die gewünschte Präsentation.
2. Greifen Sie auf die Folie zu und finden Sie das [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/), das den Text enthält.
3. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) der Form zu.
4. Rufen Sie [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphcollection/exporttohtml/) mit dem Start‑Absatz‑Index und der Anzahl der zu exportierenden Absätze auf.
5. Schreiben Sie die zurückgegebene HTML‑Zeichenkette in eine Datei.

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

[IParagraph::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/getimage/) rendert einen einzelnen Absatz direkt und gibt ein [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/) zurück. Speichern Sie das Ergebnis mit [IImage::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/save/) in einer Datei oder einem Stream. Sie müssen die enthaltende Form nicht rendern oder ein Bitmap manuell zuschneiden.

[IParagraph::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/getimage/) kann `nullptr` zurückgeben, wenn der Absatz nicht in seiner übergeordneten Sammlung gefunden wird, keine gültigen Render‑Grenzen hat oder nicht gerendert werden kann. Überprüfen Sie das Ergebnis, bevor Sie es speichern, und geben Sie das zurückgegebene Bild nach der Verwendung frei.

#### **Absatz mit Standardskala rendern**

Angenommen, wir haben eine Präsentationsdatei namens sample.pptx mit einer Folie, bei der das erste Objekt ein Textfeld mit drei Absätzen ist.

![The text box with three paragraphs](paragraph_to_image_input.png)

Das folgende Beispiel rendert den zweiten Absatz in einem normalen Textfeld bei der Standardskala und speichert das zurückgegebene Bild im PNG‑Format.

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

![The paragraph image](paragraph_to_image_output.png)

#### **Absatz in einer Tabellenzelle mit Skalierung rendern**

Verwenden Sie die Überladung von [IParagraph::GetImage], die `float scaleX` und `float scaleY` Parameter akzeptiert, um die horizontalen und vertikalen Skalierungsfaktoren festzulegen. Das folgende Beispiel erstellt eine Tabelle, rendert den Absatz in ihrer ersten Zelle mit dem doppelten Standard‑Breite‑ und Höhenwert und speichert das Ergebnis als PNG‑Bild.

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

Ein Skalierungsfaktor von `1` lässt diese Achse bei ihrer Standard‑Pixel‑Größe. Beispielsweise erzeugt `2` für beide Faktoren ein Bild, dessen Breite und Höhe etwa das Doppelte der Standardabmessungen betragen, was zu viermal so vielen Pixeln führt. Größere Faktoren erzeugen im Allgemeinen schärferen Text für Vergrößerungen oder hochauflösende Ausgaben, erhöhen jedoch auch den Speicherverbrauch und die Dateigröße. Faktoren unter `1` erzeugen kleinere Bilder mit weniger Details. Verwenden Sie gleiche Faktoren, um das Seitenverhältnis des Absatzes beizubehalten; unterschiedliche horizontale und vertikale Faktoren dehnen die Ausgabe unabhängig voneinander.

Das Rendern einer gesamten Form mit [IShape::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/getimage/) bleibt nützlich, wenn die Ausgabe die Füllung, den Rand oder einen anderen visuellen Kontext der Form enthalten muss. Für ein Bild, das nur den Absatz enthält, verwenden Sie [IParagraph::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Kann ich das Zeilenumbruch in einem Textfeld komplett deaktivieren?**

Ja. Verwenden Sie [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/set_wraptext/), um den Umbruch zu deaktivieren, sodass Zeilen nicht an den Rändern des Textfeldes umgebrochen werden.

**Wie kann ich die genauen Folien‑Grenzen eines bestimmten Absatzes erhalten?**

Verwenden Sie [IParagraph::GetRect](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/getrect/), um das umgebende Rechteck des Absatzes abzurufen. [IPortion::GetRect](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/getrect/) liefert die Grenzen einer einzelnen Portion.

**Wo wird die Absatzausrichtung (links, rechts, zentriert oder Blocksatz) gesteuert?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_alignment/) ist eine Absatz‑Ebene‑Einstellung und gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

**Kann ich die Rechtschreib‑Sprache für einen Teil eines Absatzes festlegen?**

Ja. Verwenden Sie [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseportionformat/set_languageid/) für einzelne Portionen, sodass ein Absatz Text in mehreren Sprachen enthalten kann.