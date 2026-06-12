---
title: Beheer ActiveX-besturingselementen in presentaties met C++
linktitle: ActiveX
type: docs
weight: 80
url: /nl/cpp/activex/
keywords:
- ActiveX
- ActiveX-besturingselement
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaspeler
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe Aspose.Slides for C++ ActiveX benut om PowerPoint-presentaties te automatiseren en te verbeteren, waardoor ontwikkelaars krachtige controle over dia's krijgen."
---
## **Introductie**

ActiveX‑besturingselementen worden gebruikt in presentaties. Aspose.Slides for C++ stelt u in staat om ActiveX‑besturingselementen te beheren, maar het beheren daarvan is iets ingewikkelder en verschilt van normale presentatie‑vormen. Vanaf Aspose.Slides for C++ 18.1 ondersteunt het component het beheren van ActiveX‑besturingselementen. Momenteel kunt u reeds toegevoegde ActiveX‑besturingselementen in uw presentatie benaderen en deze wijzigen of verwijderen via hun verschillende eigenschappen. Onthoud dat ActiveX‑besturingselementen geen vormen zijn en geen deel uitmaken van de IShapeCollection van de presentatie, maar van de aparte IControlCollection. Dit artikel laat zien hoe u ermee kunt werken.

## **Een ActiveX‑besturingselement wijzigen**
Om een eenvoudig ActiveX‑besturingselement, zoals een tekstvak en een eenvoudige opdrachtknop, op een dia te beheren:

1. Maak een instantie van de Presentation‑klasse en laad de presentatie waarin ActiveX‑besturingselementen staan.
1. Verkrijg een referentie naar de dia op basis van de index.
1. Toegang krijgen tot de ActiveX‑besturingselementen op de dia via de IControlCollection.
1. Toegang krijgen tot het ActiveX‑besturingselement TextBox1 met behulp van het ControlEx‑object.
1. Wijzig de verschillende eigenschappen van het ActiveX‑besturingselement TextBox1, waaronder tekst, lettertype, lettergrootte en positie van het frame.
1. Toegang krijgen tot het tweede besturingselement genaamd CommandButton1.
1. Wijzig de knopbijschrift, het lettertype en de positie.
1. Verplaats de positie van de frames van de ActiveX‑besturingselementen.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Het codefragment hieronder werkt de ActiveX‑besturingselementen op de presentatiedia's bij, zoals weergegeven hieronder.

``` cpp
// Toegang tot de presentatie met ActiveX-besturingselementen
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Toegang tot de eerste dia in de presentatie
auto slide = presentation->get_Slides()->idx_get(0);

// tekst van TextBox wijzigen
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // vervangend beeld wijzigen. PowerPoint zal deze afbeelding vervangen tijdens ActiveX-activatie, dus soms is het OK om de afbeelding ongewijzigd te laten.
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

// bijschrift van knop wijzigen
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // vervangende afbeelding wijzigen
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

// ActiveX-frames 100 punten omlaag verplaatsen
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Opslaan van de presentatie met bewerkte ActiveX-besturingselementen
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Besturingselementen nu verwijderen
slide->get_Controls()->Clear();

// Opslaan van de presentatie met verwijderde ActiveX-besturingselementen
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Een Media Player ActiveX‑besturingselement toevoegen**
ActiveX‑besturingselementen worden gebruikt in presentaties. Aspose.Slides for C++ stelt u in staat om ActiveX‑besturingselementen toe te voegen en te beheren, maar het beheren daarvan is iets ingewikkelder en verschilt van gewone presentatie‑vormen. Vanaf Aspose.Slides for C++ 18.1 is er ondersteuning toegevoegd voor het toevoegen van Media Player ActiveX‑besturingselementen in Aspose.Slides. Onthoud dat ActiveX‑besturingselementen geen vormen zijn en geen deel uitmaken van de IShapeCollection van de presentatie, maar van de afzonderlijke IControlExCollection. Dit artikel laat zien hoe u ermee kunt werken. Om een Media Player ActiveX‑besturingselement te beheren, volgt u de onderstaande stappen:

1. Maak een instantie van de Presentation‑klasse en laad de voorbeeldpresentatie waarin Media Player ActiveX‑besturingselementen staan.
1. Maak een instantie van de doel‑Presentation‑klasse en genereer een lege presentatie‑instantie.
1. Kloon de dia met Media Player ActiveX‑besturingselement uit de sjabloonpresentatie naar de doel‑Presentation.
1. Verkrijg toegang tot de gekloonde dia in de doel‑Presentation.
1. Verkrijg toegang tot de ActiveX‑besturingselementen op de dia via de IControlCollection.
1. Verkrijg toegang tot het Media Player ActiveX‑besturingselement en stel het videopad in via zijn eigenschappen.
1. Sla de presentatie op als een PPTX‑bestand.

``` cpp
// Instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Maak een lege presentatie-instantie
auto newPresentation = System::MakeObject<Presentation>();

// Verwijder standaarddia
newPresentation->get_Slides()->RemoveAt(0);

// Kloon dia met Media Player ActiveX-besturingselement
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Verkrijg toegang tot het Media Player ActiveX-besturingselement en stel het videopad in
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Sla de presentatie op
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Behoudt Aspose.Slides ActiveX‑besturingselementen bij het lezen en opnieuw opslaan wanneer ze niet uitgevoerd kunnen worden in de C++‑runtime?**

Ja. Aspose.Slides beschouwt ze als onderdeel van de presentatie en kan hun eigenschappen en frames lezen/wijzigen; het uitvoeren van de besturingselementen zelf is niet nodig om ze te behouden.

**Hoe verschillen ActiveX‑besturingselementen van OLE‑objecten in een presentatie?**

ActiveX‑besturingselementen zijn interactieve beheerde elementen (knoppen, tekstvakken, media‑speler), terwijl [OLE](/slides/nl/cpp/manage-ole/) verwijst naar ingebedde toepassingsobjecten (bijvoorbeeld een Excel‑werkblad). Ze worden anders opgeslagen en behandeld en hebben verschillende eigenschapsmodellen.

**Werken ActiveX‑gebeurtenissen en VBA‑macro's als het bestand is aangepast door Aspose.Slides?**

Aspose.Slides behoudt de bestaande markup en metadata; echter, gebeurtenissen en macro's worden alleen uitgevoerd in PowerPoint op Windows wanneer de beveiliging dit toestaat. De bibliotheek voert geen VBA uit.