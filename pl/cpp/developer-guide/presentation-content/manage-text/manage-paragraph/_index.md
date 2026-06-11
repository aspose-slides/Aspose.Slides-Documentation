---
title: Zarządzaj akapitami tekstu PowerPoint w C++
linktitle: Zarządzaj akapitem
type: docs
weight: 40
url: /pl/cpp/manage-paragraph/
keywords:
- dodaj tekst
- dodaj akapit
- zarządzaj tekstem
- zarządzaj akapitem
- zarządzaj wypunktowaniem
- wcięcie akapitu
- wcięcie wiszące
- wypunktowanie akapitu
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
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Mistrzowskie formatowanie akapitu z Aspose.Slides dla C++ — optymalizuj wyrównanie, odstępy i styl w prezentacjach PPT, PPTX i ODP w C++."
---
## **Wprowadzenie**

Aspose.Slides zapewnia wszystkie interfejsy i klasy potrzebne do pracy z tekstami, akapitami i fragmentami PowerPoint w C++.

* Aspose.Slides udostępnia interfejs [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) umożliwiający dodawanie obiektów reprezentujących akapit. Obiekt `ITextFame` może mieć jeden lub wiele akapitów (każdy akapit tworzony jest poprzez znak powrotu).
* Aspose.Slides udostępnia interfejs [IParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraph/) umożliwiający dodawanie obiektów reprezentujących fragmenty. Obiekt `IParagraph` może mieć jeden lub wiele fragmentów (kolekcja obiektów iPortions).
* Aspose.Slides udostępnia interfejs [IPortion](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/) umożliwiający dodawanie obiektów reprezentujących teksty i ich właściwości formatowania. 

Obiekt `IParagraph` jest w stanie obsługiwać teksty o różnych właściwościach formatowania poprzez leżące pod nim obiekty `IPortion`.

## **Dodaj wiele akapitów zawierających wiele fragmentów**

Te kroki pokazują, jak dodać ramkę tekstową zawierającą 3 akapity, a każdy akapit zawierający 3 fragmenty:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj prostokątny [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
4. Pobierz ITextFrame powiązany z [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/).
5. Utwórz dwa obiekty [IParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraph/) i dodaj je do kolekcji `IParagraphs` w [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/).
6. Utwórz trzy obiekty [IPortion](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/) dla każdego nowego `IParagraph` (dwa obiekty Portion dla domyślnego akapitu) i dodaj każdy obiekt `IPortion` do kolekcji IPortion każdego `IParagraph`.
7. Ustaw tekst dla każdego fragmentu.
8. Zastosuj wybrane właściwości formatowania do każdego fragmentu przy użyciu właściwości formatowania udostępnionych przez obiekt `IPortion`.
9. Zapisz zmodyfikowaną prezentację.

Ten kod C++ jest implementacją kroków dodawania akapitów zawierających fragmenty: 

```c++
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Wczytaj żądaną prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Uzyskaj dostęp do pierwszego slajdu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Dodaj AutoShape typu Prostokąt
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Dodaj TextFrame do prostokąta
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Uzyskanie pierwszego akapitu
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Dodawanie drugiego akapitu
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Dodawanie trzeciego akapitu
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// Zapisz PPTX na dysku
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Zarządzaj wypunktowaniem akapitów**

Listy wypunktowane pomagają szybko i efektywnie organizować oraz prezentować informacje. Akapity z wypunktowaniem są zawsze łatwiejsze do czytania i zrozumienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [autoshape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do wybranego slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) autoshape. 
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/paragraph/).
7. Ustaw `Type` wypunktowania dla akapitu na `Symbol` i określ znak wypunktowania.
8. Ustaw `Text` akapitu.
9. Ustaw `Indent` akapitu dla wypunktowania.
10. Ustaw kolor wypunktowania.
11. Ustaw wysokość wypunktowania.
12. Dodaj nowy akapit do kolekcji akapitów `TextFrame`.
13. Dodaj drugi akapit i powtórz proces opisany w krokach 7‑13.
14. Zapisz prezentację.

Ten kod C++ pokazuje, jak dodać wypunktowanie akapitu:

```c++
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Wczytaj żądaną prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Uzyskaj dostęp do pierwszego slajdu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Dodaj AutoShape typu Prostokąt
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Dodaj TextFrame do prostokąta
ashp->AddTextFrame(u"");

// Uzyskanie ramki tekstowej
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Utwórz obiekt Paragraph dla ramki tekstowej
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//Ustawianie tekstu
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Ustawianie wcięcia wypunktowania
paragraph->get_ParagraphFormat()->set_Indent (25);

// Ustawianie koloru wypunktowania
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// set IsBulletHardColor na true, aby użyć własnego koloru wypunktowania
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Ustawianie wysokości wypunktowania
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Dodawanie Paragraph do ramki tekstowej
txtFrame->get_Paragraphs()->Add(paragraph);

// Tworzenie drugiego akapitu
// Utwórz obiekt Paragraph dla ramki tekstowej
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//Ustawianie tekstu
paragraph2->set_Text(u"This is numbered bullet");

// Ustawianie typu i stylu wypunktowania akapitu
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Ustawianie wcięcia wypunktowania
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Ustawianie koloru wypunktowania
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// set IsBulletHardColor na true, aby użyć własnego koloru wypunktowania
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Ustawianie wysokości wypunktowania
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Dodawanie Paragraph do ramki tekstowej
txtFrame->get_Paragraphs()->Add(paragraph2);


// Zapisz PPTX na dysku
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Zarządzaj wypunktowaniem obrazkowym**

Listy wypunktowane pomagają szybko i efektywnie organizować oraz prezentować informacje. Akapity z obrazkami są łatwe do odczytania i zrozumienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [autoshape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) autoshape. 
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/paragraph/).
7. Wczytaj obraz przy użyciu [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/).
8. Ustaw typ wypunktowania na [Picture](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) i określ obraz.
9. Ustaw `Text` akapitu.
10. Ustaw `Indent` akapitu dla wypunktowania.
11. Ustaw kolor wypunktowania.
12. Ustaw wysokość wypunktowania.
13. Dodaj nowy akapit do kolekcji akapitów `TextFrame`.
14. Dodaj drugi akapit i powtórz proces opisany w poprzednich krokach.
15. Zapisz zmodyfikowaną prezentację.

Ten kod C++ pokazuje, jak dodać i zarządzać wypunktowaniem obrazkowym:

```c++
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Uzyskuje dostęp do pierwszego slajdu
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Tworzy obraz dla wypunktowania
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Dodaje i uzyskuje dostęp do Autoshape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Uzyskuje dostęp do ramki tekstowej autoshape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Usuwa domyślny akapit
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Tworzy nowy akapit
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Ustawia styl i obraz wypunktowania akapitu
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Ustawia wysokość wypunktowania
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Dodaje akapit do ramki tekstowej
paragraphs->Add(paragraph);

// Zapisuje prezentację jako plik PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Zapisuje prezentację jako plik PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```


## **Zarządzaj wypunktowaniem wielopoziomowym**

Listy wypunktowane pomagają szybko i efektywnie organizować oraz prezentować informacje. Wypunktowanie wielopoziomowe jest łatwe do odczytania i zrozumienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [autoshape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) w nowym slajdzie.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) autoshape. 
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/paragraph/) i ustaw głębokość na 0.
7. Utwórz drugą instancję akapitu przy użyciu klasy `Paragraph` i ustaw głębokość na 1.
8. Utwórz trzecią instancję akapitu przy użyciu klasy `Paragraph` i ustaw głębokość na 2.
9. Utwórz czwartą instancję akapitu przy użyciu klasy `Paragraph` i ustaw głębokość na 3.
10. Dodaj nowe akapity do kolekcji akapitów `TextFrame`.
11. Zapisz zmodyfikowaną prezentację.

Ten kod C++ pokazuje, jak dodać i zarządzać wypunktowaniem wielopoziomowym:

```c++
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Uzyskuje dostęp do pierwszego slajdu
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Dodaje i uzyskuje dostęp do Autoshape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Uzyskuje dostęp do ramki tekstowej utworzonego autoshape
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Czyści domyślny akapit
text->get_Paragraphs()->Clear();

// Dodaje pierwszy akapit
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Ustawia poziom wypunktowania
para1Format->set_Depth(0);

// Dodaje drugi akapit
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Ustawia poziom wypunktowania
para2Format->set_Depth(1);

// Dodaje trzeci akapit
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Ustawia poziom wypunktowania
para3Format->set_Depth(2);

// Dodaje czwarty akapit
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Ustawia poziom wypunktowania
para4Format->set_Depth(3);

// Dodaje akapity do kolekcji
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Zapisuje prezentację jako plik PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```


## **Zarządzaj akapitem z niestandardową listą numerowaną**

Interfejs [IBulletFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibulletformat/) udostępnia właściwość [NumberedBulletStartWith](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) i inne, które pozwalają zarządzać akapitami z własnym numerowaniem lub formatowaniem. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu zawierającego akapit.
3. Dodaj [autoshape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) autoshape. 
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/paragraph/) i ustaw [NumberedBulletStartWith](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) na 2.
7. Utwórz drugą instancję akapitu przy użyciu klasy `Paragraph` i ustaw `NumberedBulletStartWith` na 3.
8. Utwórz trzecią instancję akapitu przy użyciu klasy `Paragraph` i ustaw `NumberedBulletStartWith` na 7.
9. Dodaj nowe akapity do kolekcji akapitów `TextFrame`.
10. Zapisz zmodyfikowaną prezentację.

Ten kod C++ pokazuje, jak dodać i zarządzać akapitami z własnym numerowaniem lub formatowaniem:

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accesses the text frame of created autoshape
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Removes the default existing paragraph
textFrame->get_Paragraphs()->RemoveAt(0);

// First list
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```

## **Ustaw wcięcie pierwszej linii akapitu**

Użyj metody [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_indent/) aby kontrolować wcięcie pierwszej linii akapitu. Metoda ta przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Dodatnia wartość przesuwa pierwszą linię w prawo, podczas gdy pozostałe linie pozostają wyrównane do treści akapitu.

Użyj [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_marginleft/) gdy potrzebujesz przesunąć cały akapit. Użyj [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_indent/) gdy chcesz przesunąć tylko pierwszą linię.

Poniższy przykład tworzy kilka akapitów i stosuje różne wartości `Indent`, aby pokazać, jak wcięcie pierwszej linii wpływa na układ akapitu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj odwołanie do docelowego slajdu.
3. Dodaj prostokątny [AutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/autoshape/) do slajdu.
4. Dodaj pusty [TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textframe/) do kształtu i usuń domyślny akapit.
5. Utwórz kilka akapitów i ustaw różne wartości [Indent](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_indent/) dla nich.
6. Dodaj akapity do ramki tekstowej.
7. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak ustawić wcięcie akapitu:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Ustaw wcięcie wiszące akapitu**

Wcięcie wiszące to układ akapitu, w którym pierwsza linia zaczyna się po lewej stronie pozostałych linii. W Aspose.Slides tworzysz ten efekt za pomocą metody [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_indent/). Ustaw wcięcie na wartość ujemną, aby przesunąć pierwszą linię w lewo względem treści akapitu.

W praktyce [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_marginleft/) określa lewą pozycję treści akapitu, a [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_indent/) określa pozycję pierwszej linii względem tego marginesu. Aby stworzyć wcięcie wiszące, ustaw dodatnią wartość `MarginLeft` i ujemną wartość `Indent`.

To formatowanie jest przydatne w bibliografiach, odniesieniach, hasłach słownika i innych akapitach, w których zawijane linie muszą być wyrównane pod treścią akapitu, a nie pod pierwszym znakiem pierwszej linii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj odwołanie do docelowego slajdu.
3. Dodaj prostokątny [AutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/autoshape/) do slajdu.
4. Dodaj pusty [TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textframe/) do kształtu i usuń domyślny akapit.
5. Utwórz akapity i ustaw dodatnią wartość [MarginLeft](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_marginleft/) dla każdego akapitu.
6. Ustaw ujemną wartość [Indent](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_indent/) aby uzyskać efekt wcięcia wiszącego.
7. Dodaj akapity do ramki tekstowej.
8. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak ustawić wcięcie wiszące akapitu:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Zarządzaj właściwościami końcowymi akapitu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu zawierającego akapit według jego pozycji.
1. Dodaj prostokątny [autoshape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
1. Dodaj [TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) z dwoma akapitami do prostokąta.
1. Ustaw `FontHeight` i typ czcionki dla akapitów.
1. Ustaw właściwości końcowe dla akapitów.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C++ pokazuje, jak ustawić właściwości końcowe akapitów w PowerPoint: 

```c++
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Wczytaj żądaną prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Uzyskaj dostęp do pierwszego slajdu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Dodaj AutoShape typu Prostokąt
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Dodaj TextFrame do prostokąta
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Dodawanie pierwszego akapitu
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Dodawanie drugiego akapitu
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Zapisz PPTX na dysku
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Importuj tekst HTML do akapitów**

Aspose.Slides zapewnia rozszerzone wsparcie dla importowania tekstu HTML do akapitów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [autoshape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) do slajdu.
4. Dodaj i uzyskaj dostęp do `autoshape` [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) 
5. Usuń domyślny akapit w `ITextFrame`.
6. Odczytaj źródłowy plik HTML w obiekcie TextReader.
7. Utwórz pierwszą instancję akapitu przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/paragraph/).
8. Dodaj zawartość pliku HTML odczytanego przez TextReader do [ParagraphCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/paragraphcollection/) ramki tekstowej.
9. Zapisz zmodyfikowaną prezentację.

Ten kod C++ jest implementacją kroków importowania tekstów HTML do akapitów: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Wczytaj żądaną prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Uzyskaj dostęp do pierwszego slajdu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Dodaj AutoShape typu Prostokąt
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
//Resetowanie domyślnego koloru wypełnienia
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Dodaj TextFrame do prostokąta
ashp->AddTextFrame(u" ");

// Uzyskiwanie dostępu do ramki tekstowej
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//GetParagraphs collection
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Clearing all paragraphs in added text frame
ParaCollection->Clear();

// Loading the HTML file using stream reader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Adding text from HTML stream reader in text frame
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Create the Paragraph object for text frame
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Create Portion object for paragraph
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//Get portion format
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Set the Font for the Portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Set Bold property of the Font
pf->set_FontBold(NullableBool::True);

// Set Italic property of the Font
pf->set_FontItalic(NullableBool::True);

// Set Underline property of the Font
pf->set_FontUnderline(TextUnderlineType::Single);

// Set the Height of the Font
pf->set_FontHeight(25);

// Set the color of the Font
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Eksportuj tekst akapitu do HTML**

Aspose.Slides zapewnia rozszerzone wsparcie dla eksportowania tekstów (zawartych w akapitach) do HTML.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) i wczytaj żądaną prezentację.
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do kształtu zawierającego tekst, który ma zostać wyeksportowany do HTML.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) kształtu.
5. Utwórz instancję `StreamWriter` i dodaj nowy plik HTML.
6. Podaj indeks początkowy do StreamWriter i wyeksportuj wybrane akapity.

Ten kod C++ pokazuje, jak wyeksportować teksty akapitów PowerPoint do HTML: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Wczytaj żądaną prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Uzyskaj dostęp do domyślnego pierwszego slajdu prezentacji
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Żądany indeks
int index = 0;

// Uzyskiwanie dostępu do dodanego kształtu
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Wyodrębnianie pierwszego akapitu jako HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Zapis danych akapitów do HTML poprzez podanie indeksu początkowego akapitu i liczby akapitów do skopiowania
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **Zapisz akapit jako obraz**

W tej sekcji przedstawimy dwa przykłady demonstrujące, jak zapisać akapit tekstowy, reprezentowany przez interfejs [IParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraph/), jako obraz. Oba przykłady obejmują uzyskanie obrazu kształtu zawierającego akapit przy użyciu metod `GetImage` z interfejsu [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/), obliczenie granic akapitu w obrębie kształtu oraz wyeksportowanie go jako obrazu bitmapowego. Podejścia te pozwalają wyodrębnić konkretne fragmenty tekstu z prezentacji PowerPoint i zapisać je jako oddzielne obrazy, co może być przydatne w różnych scenariuszach.

Załóżmy, że mamy plik prezentacji o nazwie sample.pptx z jednym slajdem, gdzie pierwszy kształt jest polem tekstowym zawierającym trzy akapity.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Przykład 1**

W tym przykładzie uzyskujemy drugi akapit jako obraz. W tym celu wyodrębniamy obraz kształtu z pierwszego slajdu prezentacji, a następnie obliczamy granice drugiego akapitu w ramce tekstowej kształtu. Akapit jest następnie rysowany na nowym obrazie bitmapowym, który zapisywany jest w formacie PNG. Metoda ta jest szczególnie przydatna, gdy trzeba zapisać konkretny akapit jako oddzielny obraz, zachowując dokładne wymiary i formatowanie tekstu.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

Wynik:

![The paragraph image](paragraph_to_image_output.png)

**Przykład 2**

W tym przykładzie rozszerzamy poprzednie podejście o czynniki skalowania obrazu akapitu. Kształt jest wyodrębniany z prezentacji i zapisywany jako obraz ze współczynnikiem skali `2`. Umożliwia to uzyskanie obrazu o wyższej rozdzielczości przy eksportowaniu akapitu. Granice akapitu są następnie obliczane z uwzględnieniem skali. Skalowanie może być szczególnie użyteczne, gdy potrzebny jest bardziej szczegółowy obraz, np. do zastosowań w materiałach drukowanych wysokiej jakości.

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Zapisz kształt w pamięci jako bitmapę z skalowaniem.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Utwórz bitmapę kształtu z pamięci.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Oblicz granice drugiego akapitu.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Oblicz rozmiar obrazu wyjściowego (minimalny rozmiar - 1x1 piksel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Przygotuj bitmapę dla akapitu.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Przerysuj akapit z bitmapy kształtu na bitmapę akapitu.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **FAQ**

**Czy mogę całkowicie wyłączyć zawijanie linii wewnątrz ramki tekstowej?**

Tak. Użyj metody zawijania ramki tekstowej ([set_WrapText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textframeformat/set_wraptext/)), aby wyłączyć zawijanie, dzięki czemu linie nie będą łamane przy krawędziach ramki.

**Jak uzyskać dokładne granice akapitu na slajdzie?**

Możesz pobrać prostokąt ograniczający akapit (a nawet pojedynczy fragment), aby poznać jego precyzyjne położenie i rozmiar na slajdzie.

**Gdzie kontrolowane jest wyrównanie akapitu (lewo/prawo/środek/wyjustowanie)?**

[Alignment](https://reference.aspose.com/slides/pl/cpp/aspose.slides/paragraphformat/set_alignment/) jest ustawieniem na poziomie akapitu w [ParagraphFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/paragraphformat/); ma zastosowanie do całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

**Czy mogę ustawić język sprawdzania pisowni tylko dla części akapitu (np. jednego słowa)?**

Tak. Język jest ustawiany na poziomie fragmentu przy użyciu ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseportionformat/set_languageid/)), więc w jednym akapicie mogą współistnieć różne języki.