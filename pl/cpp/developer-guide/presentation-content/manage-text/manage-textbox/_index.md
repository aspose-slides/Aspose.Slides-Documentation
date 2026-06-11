---
title: Manage Text Boxes in Presentations Using C++
linktitle: Manage Text Box
type: docs
weight: 20
url: /pl/cpp/manage-textbox/
keywords:
- pole tekstowe
- ramka tekstowa
- dodawanie tekstu
- aktualizacja tekstu
- tworzenie pola tekstowego
- sprawdzanie pola tekstowego
- dodawanie kolumny tekstu
- dodawanie hiperłącza
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ umożliwia łatwe tworzenie, edytowanie i klonowanie pól tekstowych w plikach PowerPoint i OpenDocument, zwiększając możliwości automatyzacji prezentacji."
---
## **Wprowadzenie**

Teksty na slajdach zazwyczaj istnieją w polach tekstowych lub kształtach. Dlatego, aby dodać tekst do slajdu, musisz dodać pole tekstowe i następnie umieścić w nim tekst. Aspose.Slides for C++ udostępnia interfejs [IAutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape), który pozwala dodać kształt zawierający tekst.

{{% alert title="Info" color="info" %}}
Aspose.Slides udostępnia również interfejs [IShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_shape), który pozwala dodawać kształty do slajdów. Jednak nie wszystkie kształty dodane poprzez interfejs `IShape` mogą zawierać tekst. Natomiast kształty dodane poprzez interfejs [IAutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape) mogą zawierać tekst. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Dlatego, pracując z kształtem, do którego chcesz dodać tekst, możesz chcieć sprawdzić i potwierdzić, że został rzutowany przy użyciu interfejsu `IAutoShape`. Dopiero wtedy będziesz mógł pracować z [TextFrame](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.text_frame), które jest właściwością w `IAutoShape`. Zobacz sekcję [Update Text](https://docs.aspose.com/slides/pl/cpp/manage-textbox/#update-text) na tej stronie. 
{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

Aby utworzyć pole tekstowe na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).  
2. Uzyskaj referencję do pierwszego slajdu w nowo utworzonej prezentacji.  
3. Dodaj obiekt [IAutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape) z [ShapeType](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) ustawionym na `Rectangle` w określonej pozycji na slajdzie i uzyskaj referencję do nowo dodanego obiektu `IAutoShape`.  
4. Dodaj właściwość `TextFrame` do obiektu `IAutoShape`, która będzie zawierać tekst. W poniższym przykładzie dodaliśmy tekst: *Aspose TextBox*  
5. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`.  

Ten kod C++ — implementacja powyższych kroków — pokazuje, jak dodać tekst do slajdu:

```cpp
// Tworzy instancję Presentation
auto pres = System::MakeObject<Presentation>();

// Pobiera pierwszy slajd w prezentacji
auto sld = pres->get_Slides()->idx_get(0);

// Dodaje AutoShape z typem ustawionym na Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Dodaje TextFrame do Rectangle
ashp->AddTextFrame(u" ");

// Uzyskuje dostęp do ramki tekstowej
auto txtFrame = ashp->get_TextFrame();

// Tworzy obiekt Paragraph dla ramki tekstowej
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Tworzy obiekt Portion dla akapitu
auto portion = para->get_Portions()->idx_get(0);

// Ustawia tekst
portion->set_Text(u"Aspose TextBox");

// Zapisuje prezentację na dysk
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Sprawdzenie, czy kształt jest polem tekstowym**

Aspose.Slides udostępnia metodę [get_IsTextBox](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/get_istextbox/) z interfejsu [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/), umożliwiającą badanie kształtów i identyfikację pól tekstowych.

![Text box and shape](istextbox.png)

Ten kod C++ pokazuje, jak sprawdzić, czy kształt został utworzony jako pole tekstowe:

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Zauważ, że jeśli po prostu dodasz autokształt metodą `AddAutoShape` z interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/), metoda `get_IsTextBox` tego autokształtu zwróci `false`. Jednak po dodaniu tekstu do autokształtu metodą `AddTextFrame` lub metodą `set_Text`, metoda `get_IsTextBox` zwróci `true`.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() zwraca false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() zwraca true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() zwraca false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() zwraca true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() zwraca false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() zwraca false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() zwraca false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() zwraca false
```

## **Dodawanie kolumn do pola tekstowego**

Aspose.Slides udostępnia metody [set_ColumnCount](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) i [set_ColumnSpacing](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (z interfejsu [ITextFrameFormat](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_text_frame_format) oraz klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_text_frame_format)), które pozwalają dodać kolumny do pól tekstowych. Możesz określić liczbę kolumn w polu tekstowym oraz ustawić odstęp w punktach między kolumnami.

Ten kod w C++ demonstruje opisaną operację:

```cpp
auto presentation = System::MakeObject<Presentation>();
// Pobiera pierwszy slajd w prezentacji
auto slide = presentation->get_Slides()->idx_get(0);

// Dodaje AutoShape z typem ustawionym na Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Dodaje TextFrame do prostokąta
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Pobiera format tekstu z TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Określa liczbę kolumn w TextFrame
format->set_ColumnCount(3);

// Określa odstęp między kolumnami
format->set_ColumnSpacing(10);

// Zapisuje prezentację
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Dodawanie kolumn do ramki tekstowej**

Aspose.Slides for C++ udostępnia metodę [set_ColumnCount](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (z interfejsu [ITextFrameFormat](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_text_frame_format)), która pozwala dodać kolumny w ramkach tekstowych. Dzięki tej metodzie możesz określić preferowaną liczbę kolumn w ramce tekstowej.

Ten kod C++ pokazuje, jak dodać kolumnę wewnątrz ramki tekstowej:

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Aktualizacja tekstu**

Aspose.Slides pozwala zmienić lub zaktualizować tekst zawarty w polu tekstowym lub wszystkie teksty w prezentacji.

Ten kod C++ demonstruje operację, w której wszystkie teksty w prezentacji są aktualizowane lub zmieniane:

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    //Modyfikuje tekst
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Modyfikuje formatowanie
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Zapisuje zmodyfikowaną prezentację
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Dodanie pola tekstowego z hiperłączem**

Możesz wstawić link wewnątrz pola tekstowego. Po kliknięciu pola tekstowego użytkownicy są kierowani do otwarcia linku.

Aby dodać pole tekstowe zawierające link, wykonaj następujące kroki:

1. Utwórz instancję klasy `Presentation`.  
2. Uzyskaj referencję do pierwszego slajdu w nowo utworzonej prezentacji.  
3. Dodaj obiekt `AutoShape` z `ShapeType` ustawionym na `Rectangle` w określonej pozycji na slajdzie i uzyskaj referencję do nowo dodanego obiektu AutoShape.  
4. Dodaj `TextFrame` do obiektu `AutoShape`, który zawiera *Aspose TextBox* jako domyślny tekst.  
5. Zainstaluj klasę `IHyperlinkManager`.  
6. Przypisz obiekt `IHyperlinkManager` do metody [set_HyperlinkClick](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) powiązanej z wybraną częścią `TextFrame`.  
7. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`.  

Ten kod C++ — implementacja powyższych kroków — pokazuje, jak dodać pole tekstowe z hiperłączem do slajdu:

```cpp
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
auto presentation = System::MakeObject<Presentation>();

// Pobiera pierwszy slajd w prezentacji
auto slide = presentation->get_Slides()->idx_get(0);

// Dodaje obiekt AutoShape z typem ustawionym na Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Rzutuje kształt na AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Uzyskuje dostęp do własności ITextFrame powiązanej z AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Dodaje tekst do ramki
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Ustawia hiperłącze dla tekstu części
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Zapisuje prezentację PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a symbolem zastępczym tekstu podczas pracy z master slajdami?**

[placeholder](/slides/pl/cpp/manage-placeholder/) dziedziczy styl/pozycję z [master](https://reference.aspose.com/slides/pl/cpp/aspose.slides/masterslide/) i może być nadpisany na [layouts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/layoutslide/), podczas gdy zwykłe pole tekstowe jest niezależnym obiektem na konkretnym slajdzie i nie zmienia się przy przełączaniu układów.

**Jak mogę wykonać masową zamianę tekstu w całej prezentacji bez modyfikacji tekstu wewnątrz wykresów, tabel i SmartArt?**

Ogranicz iterację do autokształtów, które mają ramki tekstowe, i wyklucz osadzone obiekty ([charts](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/pl/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/smartart/)) poprzez przeglądanie ich kolekcji osobno lub pomijanie tych typów obiektów.