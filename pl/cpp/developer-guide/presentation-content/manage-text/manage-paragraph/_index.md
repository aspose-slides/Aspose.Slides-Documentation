---
title: Zarządzanie akapitami tekstu PowerPoint w C++
linktitle: Zarządzaj akapitem
type: docs
weight: 40
url: /pl/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
  - dodaj tekst
  - dodaj akapit
  - zarządzaj tekstem
  - zarządzaj akapitem
  - zarządzaj wypunktowaniem
  - wcięcie akapitu
  - wcięcie wiszące
  - punktowanie akapitu
  - lista numerowana
  - lista wypunktowana
  - właściwości akapitu
  - importuj HTML
  - tekst do HTML
  - akapit do HTML
  - akapit do obrazu
  - tekst do obrazu
  - eksportuj akapit
  - PowerPoint
  - prezentacja
  - C++
  - Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować akapity, fragmenty, wypunktowania, listy numerowane, wcięcia, treść HTML oraz obrazy akapitów przy użyciu Aspose.Slides dla C++."
---
## **Przegląd**

Aspose.Slides for C++ reprezentuje tekst jako hierarchię ramek tekstowych, akapitów i fragmentów:

* [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) reprezentuje kontener tekstowy w kształcie i zapewnia dostęp do jego kolekcji akapitów.
* [IParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraph/) reprezentuje pojedynczy akapit w ramce tekstowej i zapewnia dostęp do jego fragmentów oraz formatowania na poziomie akapitu.
* [IPortion](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/) reprezentuje fragment tekstu w akapicie. Każdy fragment może mieć własny tekst i formatowanie na poziomie znaków.

Akapit może więc zawierać tekst o różnych czcionkach, kolorach, rozmiarach i innych formatowaniach, używając wielu fragmentów.

## **Tworzenie i formatowanie akapitów**

### **Tworzenie akapitów z wieloma fragmentami**

Poniższe kroki tworzą ramkę tekstową z trzema akapitami, z których każdy zawiera trzy fragmenty:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj odniesienie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj prostokątny [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) kształtu.
5. Użyj domyślnego akapitu i dodaj dwa kolejne obiekty [IParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraph/) do ramki tekstowej.
6. Dodaj wystarczającą liczbę obiektów [IPortion](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/) dla każdego akapitu, aby zawierały po trzy fragmenty. Domyślny akapit już zawiera jeden pusty fragment.
7. Ustaw tekst każdego fragmentu.
8. Zastosuj formatowanie na poziomie znaków za pomocą [IPortion::get_PortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/get_portionformat/).
9. Zapisz zmodyfikowaną prezentację.

Ten przykład w C++ implementuje te kroki:

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

## **Tworzenie list punktowanych i numerowanych**

### **Tworzenie listy punktowanej lub numerowanej**

Punkty i numeracja ułatwiają przeglądanie powiązanych elementów. W Aspose.Slides ustawienia listy są definiowane za pomocą [IBulletFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibulletformat/).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj odniesienie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do wybranego slajdu.
4. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/).
5. Usuń domyślny akapit z ramki tekstowej.
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/paragraph/) dla symbolu punktu.
7. Ustaw [IBulletFormat::set_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibulletformat/set_type/) na [BulletType::Symbol](https://reference.aspose.com/slides/pl/cpp/aspose.slides/bullettype/) i określ znak punktu.
8. Ustaw tekst akapitu, wcięcie, kolor punktu i wysokość punktu.
9. Dodaj akapit do ramki tekstowej.
10. Utwórz drugi akapit i ustaw [IBulletFormat::set_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibulletformat/set_type/) na [BulletType::Numbered](https://reference.aspose.com/slides/pl/cpp/aspose.slides/bullettype/).
11. Skonfiguruj styl numerowanego punktu i dodaj akapit do ramki tekstowej.
12. Zapisz prezentację.

Ten przykład w C++ tworzy symbolowy punkt oraz punkt numerowany:

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

### **Używanie punktów graficznych**

Punkty graficzne pozwalają używać własnego obrazu zamiast symbolu lub numeru.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj odniesienie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) i uzyskaj dostęp do jego [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/).
4. Usuń domyślny akapit z ramki tekstowej.
5. Wczytaj obraz punktu i dodaj go do kolekcji obrazów prezentacji jako [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/).
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/paragraph/) i ustaw jego tekst.
7. Ustaw [IBulletFormat::set_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibulletformat/set_type/) na [BulletType::Picture](https://reference.aspose.com/slides/pl/cpp/aspose.slides/bullettype/).
8. Przypisz obraz za pomocą [ISlidesPicture::set_Image](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidespicture/set_image/) i ustaw wysokość punktu.
9. Dodaj akapit do ramki tekstowej.
10. Zapisz zmodyfikowaną prezentację.

Ten przykład w C++ tworzy punkt graficzny:

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

### **Tworzenie listy wielopoziomowej**

Ustaw [IParagraphFormat::set_Depth], aby umieścić akapity na różnych poziomach listy. Najwyższy poziom ma głębokość `0`.

1. Utwórz [Presentation] i uzyskaj dostęp do slajdu.
2. Dodaj [IAutoShape] i wyczyść domyślny akapit z jego ramki tekstowej.
3. Utwórz cztery akapity i skonfiguruj ich symbole punktów.
4. Ustaw ich wartości [IParagraphFormat::set_Depth] na `0`, `1`, `2` i `3`.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

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

### **Rozpoczęcie elementów listy numerowanej od niestandardowych wartości**

Użyj [IBulletFormat::set_NumberedBulletStartWith], aby ustawić początkowy numer wyświetlany dla numerowanego akapitu.

1. Utwórz [Presentation] i dodaj [IAutoShape] do slajdu.
2. Wyczyść domyślny akapit z ramki tekstowej kształtu.
3. Utwórz trzy numerowane akapity.
4. Ustaw [IBulletFormat::set_NumberedBulletStartWith] na `2`, `3` i `7` dla odpowiednich akapitów.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

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

## **Kontrola układu akapitu i właściwości końcowych**

### **Ustawienie wcięcia pierwszej linii**

Użyj [IParagraphFormat::set_Indent], aby kontrolować wcięcie pierwszej linii akapitu. Ta metoda przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Dodatnia wartość przesuwa pierwszą linię w prawo, podczas gdy pozostałe linie pozostają wyrównane do treści akapitu.

Użyj [IParagraphFormat::set_MarginLeft], gdy potrzebujesz przesunąć cały akapit. Użyj [IParagraphFormat::set_Indent], gdy potrzebujesz przesunąć tylko pierwszą linię.

Poniższy przykład tworzy kilka akapitów i stosuje różne wartości [IParagraphFormat::set_Indent], aby pokazać, jak wcięcie pierwszej linii wpływa na układ akapitu.

1. Utwórz instancję klasy [Presentation].
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątny [IAutoShape] do slajdu.
4. Uzyskaj dostęp do [ITextFrame] kształtu i usuń domyślny akapit.
5. Utwórz kilka akapitów i ustaw dla nich różne wartości [IParagraphFormat::set_Indent].
6. Dodaj akapity do ramki tekstowej.
7. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak ustawić wcięcie akapitu:

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

Wynik:

![Wcięcie pierwszej linii akapitów](first_line_indent.png)

### **Ustawienie wcięcia wiszącego**

Wcięcie wiszące to układ akapitu, w którym pierwsza linia zaczyna się po lewej stronie pozostałych linii. W Aspose.Slides tworzy się ten efekt za pomocą [IParagraphFormat::set_Indent]. Ustaw wcięcie na wartość ujemną, aby przesunąć pierwszą linię w lewo względem treści akapitu.

W praktyce [IParagraphFormat::set_MarginLeft] określa lewą pozycję ciała akapitu, a [IParagraphFormat::set_Indent] pozycję pierwszej linii względem tego marginesu. Aby utworzyć wcięcie wiszące, ustaw dodatnią wartość margin-left i ujemną wartość indent.

To formatowanie jest przydatne w bibliografiach, odnośnikach, hasłach słownika i innych akapitach, w których zawijane linie muszą być wyrównane pod ciałem akapitu, a nie pod pierwszym znakiem pierwszej linii.

1. Utwórz instancję klasy [Presentation].
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątny [IAutoShape] do slajdu.
4. Uzyskaj dostęp do [ITextFrame] kształtu i usuń domyślny akapit.
5. Utwórz akapity i ustaw dodatnią wartość [IParagraphFormat::set_MarginLeft] dla każdego akapitu.
6. Ustaw ujemną wartość [IParagraphFormat::set_Indent], aby uzyskać efekt wcięcia wiszącego.
7. Dodaj akapity do ramki tekstowej.
8. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak ustawić wcięcie wiszące dla akapitu:

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

Wynik:

![Wcięcie wiszące akapitów](hanging_indent.png)

### **Ustawienie właściwości końcowego fragmentu akapitu**

[IParagraph::set_EndParagraphPortionFormat] kontroluje formatowanie znaku końcowego akapitu. Poniższy przykład przypisuje rozmiar czcionki i czcionkę łacińską do znaku końcowego drugiego akapitu:

1. Wczytaj [Presentation] i uzyskaj dostęp do slajdu.
2. Dodaj [IAutoShape] i wyczyść jego domyślny akapit.
3. Utwórz dwa akapity i dodaj do nich fragmenty tekstu.
4. Utwórz [PortionFormat] dla znaku końcowego drugiego akapitu.
5. Ustaw [IBasePortionFormat::set_FontHeight] i [IBasePortionFormat::set_LatinFont].
6. Przypisz format za pomocą [IParagraph::set_EndParagraphPortionFormat] i zapisz prezentację.

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

## **Liczenie renderowanych linii**

Użyj [IParagraph::GetLinesCount], aby policzyć linie zajmowane przez akapit po ułożeniu tekstu, włączając automatyczne zawijanie. Jest to przydatne przy sprawdzaniu długości tekstu i układu w szablonach prezentacji.

Akapit jest jednym elementem w [ITextFrame::get_Paragraphs] i może zajmować kilka renderowanych linii. Jawny podział linii w akapicie wymusza nową linię bez tworzenia kolejnego akapitu. Automatyczne zawijanie tworzy linie w oparciu o dostępną szerokość, nie wstawiając jawnych znaków podziału linii do tekstu. Dlatego liczenie akapitów lub znaków podziału linii nie daje liczby renderowanych linii.

Poniższy przykład tworzy kształt tekstowy, liczy jego linie, zwęża kształt, a następnie zastępuje tekst krótszym ciągiem. Zawijanie jest włączone, a automatyczne dopasowanie wyłączone, tak aby szerokość kształtu kontrolowała zawijanie bez automatycznego zmniejszania tekstu lub zmiany rozmiaru kształtu. Wymiary kształtu są podane w punktach. Na końcu przykład dodaje kolejny akapit i sumuje liczbę linii w całej ramce tekstowej.

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

Przy tym tekście i tych wymiarach, zwężanie kształtu zwiększa liczbę linii, podczas gdy zastąpienie tekstu krótkim ciągiem ją zmniejsza. Dokładne liczby mogą się różnić w zależności od dostępności czcionek i ich zastępowania, rozmiaru czcionki, marginesów, wcięć, zawijania i ustawień automatycznego dopasowania. Używaj czcionek i ustawień układu przeznaczonych dla docelowego środowiska przy sprawdzaniu szablonu.

Jedynie liczba linii nie określa, czy tekst wykracza poza kontener. Ważna jest również dostępna wysokość, wysokość linii, odstępy między akapitami i liniami oraz zachowanie automatycznego dopasowania; nawet pojedyncza linia może przekroczyć dostępną szerokość, gdy zawijanie jest wyłączone.

## **Import i eksport treści akapitów**

### **Importowanie tekstu HTML do akapitów**

Użyj [IParagraphCollection::AddFromHtml], aby przekształcić znacznik HTML w akapity i fragmenty w ramce tekstowej.

1. Utwórz instancję klasy [Presentation].
2. Uzyskaj dostęp do slajdu i dodaj [IAutoShape].
3. Uzyskaj dostęp do [ITextFrame] kształtu i wyczyść jego domyślny akapit.
4. Odczytaj plik źródłowy HTML.
5. Przekaż ciąg HTML do [IParagraphCollection::AddFromHtml].
6. Zapisz zmodyfikowaną prezentację.

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

### **Eksportowanie tekstu akapitu do HTML**

Użyj [IParagraphCollection::ExportToHtml], aby wyeksportować wybrany zakres akapitów jako HTML.

1. Utwórz instancję klasy [Presentation] i wczytaj żądaną prezentację.
2. Uzyskaj dostęp do slajdu i znajdź [IAutoShape] zawierający tekst.
3. Uzyskaj dostęp do [ITextFrame] kształtu.
4. Wywołaj [IParagraphCollection::ExportToHtml] z indeksem początkowego akapitu i liczbą akapitów do eksportu.
5. Zapisz zwrócony ciąg HTML do pliku.

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

### **Renderowanie akapitu jako obrazu**

[IParagraph::GetImage] renderuje pojedynczy akapit bezpośrednio i zwraca [IImage]. Zapisz wynik do pliku lub strumienia za pomocą [IImage::Save]. Nie musisz renderować zawierającego kształtu ani ręcznie przycinać bitmapy.

[IParagraph::GetImage] może zwrócić `nullptr`, jeśli akapit nie zostanie znaleziony w kolekcji nadrzędnej, nie ma prawidłowych granic renderowania lub nie może zostać wyrenderowany. Sprawdź wynik przed zapisem i zwolnij zwrócony obraz po użyciu.

#### **Renderowanie akapitu w domyślnej skali**

Załóżmy, że mamy plik prezentacji o nazwie sample.pptx z jednym slajdem, na którym pierwszy kształt jest polem tekstowym zawierającym trzy akapity.

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

Poniższy przykład renderuje drugi akapit w zwykłym polu tekstowym w domyślnej skali i zapisuje zwrócony obraz w formacie PNG.

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

Wynik:

![Obraz akapitu](paragraph_to_image_output.png)

#### **Renderowanie akapitu w komórce tabeli ze skalowaniem**

Użyj przeciążenia [IParagraph::GetImage], które przyjmuje parametry `float scaleX` i `float scaleY`, aby ustawić poziome i pionowe współczynniki skali. Poniższy przykład tworzy tabelę, renderuje akapit w jej pierwszej komórce przy dwukrotnej szerokości i wysokości względem domyślnych i zapisuje wynik jako obraz PNG.

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

Współczynnik skali `1` utrzymuje daną oś w domyślnym rozmiarze pikseli. Na przykład `2` dla obu współczynników tworzy obraz, którego szerokość i wysokość są w przybliżeniu dwukrotnie większe niż domyślne wymiary, co skutkuje czterokrotną liczbą pikseli. Większe współczynniki zazwyczaj dają ostrzejszy tekst przy powiększeniu lub wyjściu o wysokiej rozdzielczości, ale zwiększają zużycie pamięci i rozmiar pliku. Współczynniki poniżej `1` tworzą mniejsze obrazy z mniejszą szczegółowością. Używaj równych współczynników, aby zachować proporcje akapitu; różne współczynniki poziome i pionowe rozciągają wynik niezależnie.

Renderowanie całego kształtu za pomocą [IShape::GetImage] jest przydatne, gdy wynik musi zawierać wypełnienie, obramowanie lub inny kontekst wizualny kształtu. Aby uzyskać obraz tylko akapitu, użyj [IParagraph::GetImage].

## **FAQ**

**Czy mogę całkowicie wyłączyć zawijanie linii wewnątrz ramki tekstowej?**

Tak. Użyj [ITextFrameFormat::set_WrapText], aby wyłączyć zawijanie, tak aby linie nie łamały się na krawędziach ramki tekstowej.

**Jak mogę uzyskać dokładne granice konkretnego akapitu na slajdzie?**

Użyj [IParagraph::GetRect], aby pobrać prostokąt ograniczający akapit. [IPortion::GetRect] zapewnia granice pojedynczego fragmentu.

**Gdzie kontrolowane jest wyrównanie akapitu (lewe, prawe, wyśrodkowane lub wyjustowane)?**

[IParagraphFormat::set_Alignment] jest ustawieniem na poziomie akapitu i ma zastosowanie do całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

**Czy mogę ustawić język korekty dla części akapitu?**

Tak. Użyj [IBasePortionFormat::set_LanguageId] dla poszczególnych fragmentów, aby jeden akapit mógł zawierać tekst w wielu językach.