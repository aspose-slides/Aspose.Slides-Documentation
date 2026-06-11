---
title: Ulepsz swoje prezentacje przy użyciu AutoFit w C++
linktitle: Ustawienia Autofit
type: docs
weight: 30
url: /pl/cpp/manage-autofit-settings/
keywords:
- pole tekstowe
- autofit
- nie używaj autofitu
- dopasuj tekst
- zmniejsz tekst
- zawijaj tekst
- zmień rozmiar kształtu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak zarządzać ustawieniami AutoFit w Aspose.Slides dla C++, aby zoptymalizować wyświetlanie tekstu w prezentacjach PowerPoint i OpenDocument oraz poprawić czytelność treści."
---
## **Wprowadzenie**

Domyślnie, gdy dodajesz pole tekstowe, Microsoft PowerPoint używa ustawienia **Resize shape to fix text** dla tego pola tekstowego — automatycznie zmienia rozmiar pola tekstowego, aby jego tekst zawsze w nim pasował. 

![Pole tekstowe w PowerPoint](textbox-in-powerpoint.png)

* Gdy tekst w polu tekstowym staje się dłuższy lub większy, PowerPoint automatycznie powiększa pole tekstowe — zwiększa jego wysokość — aby pomieścić więcej tekstu. 
* Gdy tekst w polu tekstowym staje się krótszy lub mniejszy, PowerPoint automatycznie zmniejsza pole tekstowe — zmniejsza jego wysokość — aby usunąć nadmiarowe miejsce. 

W programie PowerPoint są to 4 ważne parametry lub opcje kontrolujące zachowanie autofit dla pola tekstowego: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![Opcje autofit w PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for C++ udostępnia podobne opcje — niektóre metody w klasie [TextFrameFormat](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.text_frame_format) — które pozwalają kontrolować zachowanie autofit dla pól tekstowych w prezentacjach. 

## **Zmiana rozmiaru kształtu, aby dopasować tekst**

Jeśli chcesz, aby tekst w ramce zawsze pasował do tej ramki po wprowadzeniu zmian w tekście, musisz użyć opcji **Resize shape to fix text**. Aby określić to ustawienie, ustaw właściwość [AutofitType](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.text_frame_format)) na `Shape`. 

![Ustawienie alwaysfit w PowerPoint](alwaysfit-setting-powerpoint.png)

Ten kod C++ pokazuje, jak określić, że tekst musi zawsze pasować do swojej ramki w prezentacji PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Jeśli tekst stanie się dłuższy lub większy, pole tekstowe zostanie automatycznie zmienione (zwiększenie wysokości), aby cały tekst w nim zmieścił się. Jeśli tekst stanie się krótszy, nastąpi odwrotny efekt. 

## **Nie używaj Autofit**

Jeśli chcesz, aby pole tekstowe lub kształt zachowały swoje wymiary niezależnie od zmian wprowadzonych w zawartym tekście, musisz użyć opcji **Do not Autofit**. Aby określić to ustawienie, ustaw właściwość [AutofitType](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.text_frame_format)) na `None`. 

![Ustawienie donotautofit w PowerPoint](donotautofit-setting-powerpoint.png)

Ten kod C++ pokazuje, jak określić, że pole tekstowe musi zawsze zachować swoje wymiary w prezentacji PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Gdy tekst stanie się zbyt długi dla swojej ramki, wycieka poza nią. 

## **Zmniejsz tekst przy przepełnieniu**

Jeśli tekst stanie się zbyt długi dla swojej ramki, dzięki opcji **Shrink text on overflow** możesz określić, że rozmiar i odległości tekstu mają zostać zmniejszone, aby dopasować go do ramki. Aby ustawić tę opcję, ustaw właściwość [AutofitType](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.text_frame_format)) na `Normal`. 

![Ustawienie shrinktextonoverflow w PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Ten kod C++ pokazuje, jak określić, że tekst ma być zmniejszany przy przepełnieniu w prezentacji PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Info" color="info" %}}
Gdy użyta jest opcja **Shrink text on overflow**, ustawienie jest stosowane tylko wtedy, gdy tekst stanie się zbyt długi dla ramki. 
{{% /alert %}}

## **Zawijanie tekstu**

Jeśli chcesz, aby tekst w kształcie był zawijany wewnątrz tego kształtu, gdy tekst wykracza poza krawędź kształtu (tylko szerokość), musisz użyć parametru **Wrap text in shape**. Aby określić to ustawienie, należy ustawić właściwość [WrapText](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.text_frame_format)) na `true`. 

Ten kod C++ pokazuje, jak używać ustawienia Wrap Text w prezentacji PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Jeśli ustawisz właściwość `WrapText` na `False` dla kształtu, gdy tekst wewnątrz kształtu stanie się dłuższy niż szerokość kształtu, tekst zostanie wyświetlony poza granicami kształtu w jednej linii. 
{{% /alert %}}

## **FAQ**

**Czy wewnętrzne marginesy ramki tekstu wpływają na AutoFit?**

Tak. Padding (wewnętrzne marginesy) zmniejsza dostępny obszar dla tekstu, więc AutoFit zadziała wcześniej — zmniejszy czcionkę lub rozmiar kształtu szybciej. Sprawdź i dostosuj marginesy przed dostosowywaniem AutoFit.

**Jak AutoFit współdziała z ręcznymi i miękkimi podziałami wierszy?**

Wymuszone podziały pozostają na miejscu, a AutoFit dostosowuje rozmiar czcionki i odstępy wokół nich. Usuwanie niepotrzebnych podziałów często zmniejsza agresywność, z jaką AutoFit musi zmniejszyć tekst.

**Czy zmiana czcionki motywu lub wywołanie podstawienia czcionki wpływa na wyniki AutoFit?**

Tak. Podstawienie czcionki o innych metrykach glifów zmienia szerokość/wysokość tekstu, co może zmienić ostateczny rozmiar czcionki i zawijanie linii. Po każdej zmianie czcionki lub podstawieniu, należy ponownie sprawdzić slajdy.