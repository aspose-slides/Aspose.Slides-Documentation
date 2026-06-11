---
title: "Zarządzanie kontrolkami ActiveX w prezentacjach przy użyciu C++"
linktitle: "ActiveX"
type: docs
weight: 80
url: /pl/cpp/activex/
keywords:
- ActiveX
- kontrolka ActiveX
- zarządzanie ActiveX
- dodawanie ActiveX
- modyfikowanie ActiveX
- odtwarzacz multimedialny
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides dla C++ wykorzystuje ActiveX do automatyzacji i ulepszania prezentacji PowerPoint, zapewniając programistom potężną kontrolę nad slajdami."
---
## **Wprowadzenie**

Kontrolki ActiveX są używane w prezentacjach. Aspose.Slides dla C++ umożliwia zarządzanie kontrolkami ActiveX, ale ich obsługa jest nieco trudniejsza i inna niż w przypadku zwykłych kształtów prezentacji. Od wersji Aspose.Slides dla C++ 18.1 komponent obsługuje zarządzanie kontrolkami ActiveX. Obecnie możesz uzyskać dostęp do już dodanej kontrolki ActiveX w swojej prezentacji oraz modyfikować ją lub usuwać, korzystając z różnych jej właściwości. Pamiętaj, że kontrolki ActiveX nie są kształtami i nie należą do IShapeCollection prezentacji, lecz do osobnego IControlCollection. Ten artykuł pokazuje, jak z nimi pracować.

## **Modyfikacja kontrolki ActiveX**
Aby zarządzać prostą kontrolką ActiveX, taką jak pole tekstowe i prosty przycisk polecenia na slajdzie:

1. Utwórz instancję klasy Presentation i wczytaj prezentację zawierającą kontrolki ActiveX.
2. Uzyskaj referencję do slajdu na podstawie jego indeksu.
3. Uzyskaj dostęp do kontrolek ActiveX na slajdzie, odwołując się do IControlCollection.
4. Uzyskaj dostęp do kontrolki ActiveX TextBox1 przy użyciu obiektu ControlEx.
5. Zmień różne właściwości kontrolki ActiveX TextBox1, w tym tekst, czcionkę, wysokość czcionki oraz położenie ramki.
6. Uzyskaj dostęp do drugiej kontrolki o nazwie CommandButton1.
7. Zmień podpis przycisku, czcionkę i położenie.
8. Przesuń położenie ramek kontrolek ActiveX.
9. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Poniższy fragment kodu aktualizuje kontrolki ActiveX na slajdach prezentacji, jak pokazano poniżej.

``` cpp
// Uzyskiwanie dostępu do prezentacji z kontrolkami ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Uzyskiwanie dostępu do pierwszego slajdu w prezentacji
auto slide = presentation->get_Slides()->idx_get(0);

// zmiana tekstu TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // zmiana obrazu zastępczego. PowerPoint zamieni ten obraz podczas aktywacji ActiveX, więc czasami można pozostawić obraz niezmieniony.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// zmiana podpisu przycisku
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // zmiana obrazu zastępczego
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Przesuwanie ramek ActiveX o 100 punktów w dół
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Zapisanie prezentacji z edytowanymi kontrolkami ActiveX
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Teraz usuwanie kontrolek
slide->get_Controls()->Clear();

// Zapisywanie prezentacji z usuniętymi kontrolkami ActiveX
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Dodanie kontrolki ActiveX Media Player**
Kontrolki ActiveX są używane w prezentacjach. Aspose.Slides dla C++ umożliwia dodawanie i zarządzanie kontrolkami ActiveX, ale ich obsługa jest nieco trudniejsza i różni się od zwykłych kształtów prezentacji. Od wersji Aspose.Slides dla C++ 18.1 w Aspose.Slides dodano obsługę dodawania kontrolki ActiveX Media Player. Pamiętaj, że kontrolki ActiveX nie są kształtami i nie należą do IShapeCollection prezentacji, lecz do osobnego IControlExCollection. Ten artykuł pokazuje, jak z nimi pracować. Aby zarządzać kontrolką ActiveX Media Player, wykonaj następujące kroki:

1. Utwórz instancję klasy Presentation i wczytaj przykładową prezentację zawierającą kontrolki ActiveX Media Player.
2. Utwórz instancję docelowej klasy Presentation i utwórz pustą prezentację.
3. Sklonuj slajd z kontrolką ActiveX Media Player w szablonie prezentacji do docelowej prezentacji.
4. Uzyskaj dostęp do sklonowanego slajdu w docelowej prezentacji.
5. Uzyskaj dostęp do kontrolek ActiveX na slajdzie, odwołując się do IControlCollection.
6. Uzyskaj dostęp do kontrolki ActiveX Media Player i ustaw ścieżkę wideo, korzystając z jej właściwości.
7. Zapisz prezentację do pliku PPTX.

``` cpp
// Utwórz instancję klasy Presentation reprezentującej plik PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Utwórz pustą instancję prezentacji
auto newPresentation = System::MakeObject<Presentation>();

// Usuń domyślny slajd
newPresentation->get_Slides()->RemoveAt(0);

// Sklonuj slajd z kontrolką ActiveX Media Player
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Uzyskaj dostęp do kontrolki ActiveX Media Player i ustaw ścieżkę do wideo
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Zapisz prezentację
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Czy Aspose.Slides zachowuje kontrolki ActiveX przy odczycie i ponownym zapisie, jeśli nie mogą być wykonywane w środowisku uruchomieniowym C++?**

Tak. Aspose.Slides traktuje je jako część prezentacji i może odczytywać/modyfikować ich właściwości oraz ramki; nie jest wymagane wykonywanie samych kontrolek, aby je zachować.

**Czym różnią się kontrolki ActiveX od obiektów OLE w prezentacji?**

Kontrolki ActiveX są interaktywnymi kontrolkami zarządzanymi (przyciski, pola tekstowe, odtwarzacz multimedialny), podczas gdy [OLE](/slides/pl/cpp/manage-ole/) odnosi się do osadzonych obiektów aplikacji (np. arkusza Excel). Są przechowywane i obsługiwane inaczej oraz mają inny model właściwości.

**Czy zdarzenia ActiveX i makra VBA działają, jeśli plik został zmodyfikowany przez Aspose.Slides?**

Aspose.Slides zachowuje istniejący znacznik i metadane; jednak zdarzenia i makra uruchamiają się wyłącznie w programie PowerPoint na systemie Windows, gdy zabezpieczenia na to pozwalają. Biblioteka nie wykonuje kodu VBA.