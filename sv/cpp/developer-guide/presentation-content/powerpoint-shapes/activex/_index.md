---
title: Hantera ActiveX‑kontroller i presentationer med C++
linktitle: ActiveX
type: docs
weight: 80
url: /sv/cpp/activex/
keywords:
- ActiveX
- ActiveX‑kontroll
- hantera ActiveX
- lägga till ActiveX
- modifiera ActiveX
- mediaspelare
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur Aspose.Slides för C++ utnyttjar ActiveX för att automatisera och förbättra PowerPoint-presentationer, vilket ger utvecklare kraftfull kontroll över bilder."
---
## **Introduktion**

ActiveX control används i presentationer. Aspose.Slides för C++ låter dig hantera ActiveX‑kontroller, men att hantera dem är lite knepigare och annorlunda än vanliga presentationsformer. Från Aspose.Slides för C++ 18.1 stöder komponenten hantering av ActiveX‑kontroller. För närvarande kan du komma åt redan tillagda ActiveX‑kontroller i din presentation och ändra eller ta bort dem genom att använda deras olika egenskaper. Kom ihåg att ActiveX‑kontroller inte är former och inte är en del av presentationens IShapeCollection utan den separata IControlCollection. Den här artikeln visar hur du arbetar med dem.

## **Ändra en ActiveX‑kontroll**
För att hantera en enkel ActiveX‑kontroll som en textruta och en enkel kommandoknapp på en bild:

1. Skapa en instans av Presentation‑klassen och läs in presentationen som innehåller ActiveX‑kontroller.
2. Hämta en bildreferens med dess index.
3. Kom åt ActiveX‑kontrollerna på bilden genom att använda IControlCollection.
4. Kom åt TextBox1‑ActiveX‑kontrollen med ControlEx‑objektet.
5. Ändra de olika egenskaperna för TextBox1‑ActiveX‑kontrollen, inklusive text, teckensnitt, teckenhöjd och ramposition.
6. Kom åt den andra åtkomstkontrollen som heter CommandButton1.
7. Ändra knappens rubrik, teckensnitt och position.
8. Flytta positionen för ActiveX‑kontrollernas ramar.
9. Skriv den modifierade presentationen till en PPTX‑fil.

Kodsnutten nedan uppdaterar ActiveX‑kontrollerna på presentationsbilderna som visas nedan.

``` cpp
// Åtkomst till presentationen med ActiveX‑kontroller
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Åtkomst till den första bilden i presentationen
auto slide = presentation->get_Slides()->idx_get(0);

// ändrar TextBox‑text
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // ändrar ersättningsbild. PowerPoint kommer att ersätta denna bild under ActiveX‑aktivering, så ibland är det OK att låta bilden förbli oförändrad.
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

// ändrar knappens rubrik
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // ändrar ersättning
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

// Flyttar ActiveX‑ramar 100 punkter ned
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Spara presentationen med redigerade ActiveX‑kontroller
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Nu tar vi bort kontroller
slide->get_Controls()->Clear();

// Sparar presentationen med rensade ActiveX‑kontroller
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Lägg till en Media Player ActiveX‑kontroll**
ActiveX‑kontroller används i presentationer. Aspose.Slides för C++ låter dig lägga till och hantera ActiveX‑kontroller, men att hantera dem är lite knepigare och annorlunda än vanliga presentationsformer. Från Aspose.Slides för C++ 18.1 har stöd för att lägga till Media Player‑ActiveX‑kontroller lagts till i Aspose.Slides. Kom ihåg att ActiveX‑kontroller inte är former och inte är en del av presentationens IShapeCollection utan den separata IControlExCollection. Den här artikeln visar hur du arbetar med dem. För att hantera en Media Player‑ActiveX‑kontroll, följ dessa steg:

1. Skapa en instans av Presentation‑klassen och läs in exempelpresentationen som innehåller Media Player‑ActiveX‑kontroller.
2. Skapa en instans av mål‑Presentation‑klassen och generera en tom presentationsinstans.
3. Klona bilden med Media Player‑ActiveX‑kontrollen i mallpresentationen till mål‑Presentation.
4. Kom åt den klonade bilden i mål‑Presentation.
5. Kom åt ActiveX‑kontrollerna på bilden genom att använda IControlCollection.
6. Kom åt Media Player‑ActiveX‑kontrollen och ange videons sökväg genom att använda dess egenskaper.
7. Spara presentationen till en PPTX‑fil.

``` cpp
// Instansiera Presentation-klassen som representerar PPTX-filen
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Skapa en tom presentationsinstans
auto newPresentation = System::MakeObject<Presentation>();

// Ta bort standardbilden
newPresentation->get_Slides()->RemoveAt(0);

// Klona bild med Media Player ActiveX-kontroll
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Kom åt Media Player ActiveX-kontrollen och ange videons sökväg
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Spara presentationen
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Bevarar Aspose.Slides ActiveX‑kontroller när den läser och sparar om de inte kan köras i C++‑runtime‑miljön?**

Ja. Aspose.Slides behandlar dem som en del av presentationen och kan läsa/ändra deras egenskaper och ramar; att köra kontrollerna själva krävs inte för att bevara dem.

**Hur skiljer sig ActiveX‑kontroller från OLE‑objekt i en presentation?**

ActiveX‑kontroller är interaktiva hanterade kontroller (knappar, textrutor, media player), medan [OLE](/slides/sv/cpp/manage-ole/) avser inbäddade programobjekt (till exempel ett Excel‑ kalkylblad). De lagras och hanteras annorlunda och har olika egenskapsmodeller.

**Fungerar ActiveX‑händelser och VBA‑makron om filen har modifierats av Aspose.Slides?**

Aspose.Slides bevarar den befintliga markupen och metadata; dock körs händelser och makron endast i PowerPoint på Windows när säkerheten tillåter det. Biblioteket kör inte VBA.