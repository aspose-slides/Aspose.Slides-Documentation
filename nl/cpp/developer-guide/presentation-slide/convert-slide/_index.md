---
title: Presentatiedia's converteren naar afbeeldingen in C++
linktitle: Dia naar afbeelding
type: docs
weight: 41
url: /nl/cpp/convert-slide/
keywords:
  - dia converteren
  - dia exporteren
  - dia naar afbeelding
  - dia opslaan als afbeelding
  - dia naar PNG
  - dia naar JPEG
  - dia naar bitmap
  - dia naar TIFF
  - PowerPoint
  - OpenDocument
  - presentatie
  - C++
  - Aspose.Slides
description: "Converteer dia's van PPT, PPTX en ODP naar afbeeldingen in C++ met Aspose.Slides - snelle, hoogwaardige weergave met duidelijke codevoorbeelden."
---
## **Introductie**

Aspose.Slides for C++ stelt je in staat om PowerPoint- en OpenDocument‑presentatiedia's eenvoudig te converteren naar diverse afbeeldingsformaten, waaronder BMP, PNG, JPG (JPEG), GIF en andere.

Om een dia naar een afbeelding te converteren, volg je deze stappen:

1. Definieer de gewenste conversie‑instellingen en selecteer de dia's die je wilt exporteren met behulp van:
    - De [ITiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/itiffoptions/) interface, of
    - De [IRenderingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/irenderingoptions/) interface.
2. Genereer de dia‑afbeelding door de [GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/getimage/) methode aan te roepen.

Een [Bitmap](https://reference.aspose.com/slides/nl/cpp/system.drawing/bitmap/) is een object waarmee je kunt werken met afbeeldingen die zijn gedefinieerd door pixelgegevens. Je kunt een instantie van deze klasse gebruiken om afbeeldingen op te slaan in een breed scala aan formaten (BMP, JPG, PNG, enz.).

## **Dia's converteren naar Bitmaps en de afbeeldingen opslaan in PNG**

Je kunt een dia omzetten naar een bitmap‑object en dit direct in je applicatie gebruiken. Alternatief kun je een dia omzetten naar een bitmap en vervolgens de afbeelding opslaan in JPEG of een ander gewenst formaat.

Deze C++‑code laat zien hoe je de eerste dia van een presentatie omzet naar een bitmap‑object en vervolgens de afbeelding opslaat in PNG‑formaat:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Converteer de eerste dia in de presentatie naar een bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Sla de afbeelding op in het PNG-formaat.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Dia's converteren naar afbeeldingen met aangepaste afmetingen**

Je wilt misschien een afbeelding met een bepaalde grootte verkrijgen. Met een overload van de [GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/getimage/) kun je een dia omzetten naar een afbeelding met specifieke afmetingen (breedte en hoogte).

Deze voorbeeldcode laat zien hoe je dit doet:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Converteer de eerste dia in de presentatie naar een bitmap met de opgegeven grootte.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Sla de afbeelding op in het JPEG-formaat.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Dia's met notities en opmerkingen converteren naar afbeeldingen**

Sommige dia's kunnen notities en opmerkingen bevatten.

Aspose.Slides biedt twee interfaces—[ITiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/itiffoptions/) en [IRenderingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/irenderingoptions/)—die je controle geven over het renderen van presentatiedia's naar afbeeldingen. Beide interfaces bevatten de `set_SlidesLayoutOptions` methode, waarmee je de weergave van notities en opmerkingen op een dia kunt configureren bij het converteren naar een afbeelding.

Met de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notescommentslayoutingoptions/) klasse kun je de gewenste positie voor notities en opmerkingen in de resulterende afbeelding opgeven.

Deze C++‑code laat zien hoe je een dia met notities en opmerkingen converteert:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Laad een presentatie‑bestand.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Stel de positie van de notities in.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Stel de positie van de opmerkingen in.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Stel de breedte van het opmerkingengebied in.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Stel de kleur van het opmerkingengebied in.

// Maak de renderopties aan.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Converteer de eerste dia van de presentatie naar een afbeelding.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Sla de afbeelding op in GIF-formaat.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Opmerking" color="warning" %}} 
In elk dia‑naar‑afbeelding‑conversieproces kan de [set_NotesPosition](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) methode geen `BottomFull` toepassen (om de positie van notities op te geven) omdat de tekst van een notitie te groot kan zijn om binnen de gespecificeerde afbeeldingsgrootte te passen.
{{% /alert %}} 

## **Dia's converteren naar afbeeldingen met TIFF‑opties**

De [ITiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/itiffoptions/) interface biedt meer controle over de resulterende TIFF‑afbeelding door parameters zoals grootte, resolutie, kleurenpalet en meer te specificeren.

Deze C++‑code toont een conversie‑proces waarbij TIFF‑opties worden gebruikt om een zwart‑wit afbeelding te genereren met een resolutie van 300 dpi en een afmeting van 2160 × 2800:

```cpp 
// Laad een presentiebestand.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Haal de eerste dia uit de presentatie.
auto slide = presentation->get_Slide(0);

// Configureer de instellingen van de TIFF-uitvoerafbeelding.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Stel de afbeeldingsgrootte in.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Stel het pixelformaat in (zwart-wit).
tiffOptions->set_DpiX(300);                                         // Stel de horizontale resolutie in.
tiffOptions->set_DpiY(300);                                         // Stel de verticale resolutie in.

// Converteer de dia naar een afbeelding met de opgegeven opties.
auto image = slide->GetImage(tiffOptions);

// Sla de afbeelding op in TIFF-formaat.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Alle dia's converteren naar afbeeldingen**

Aspose.Slides maakt het mogelijk om alle dia's in een presentatie te converteren naar afbeeldingen, waardoor de volledige presentatie wordt omgezet in een reeks afbeeldingen.

Deze voorbeeldcode laat zien hoe je alle dia's in een presentatie converteert naar afbeeldingen in C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Render de presentatie naar afbeeldingen dia voor dia.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Beheer verborgen dia's (render geen verborgen dia's).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Converteer de dia naar een afbeelding.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Sla de afbeelding op in JPEG-formaat.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **FAQ**

**Ondersteunt Aspose.Slides het renderen van dia's met animaties?**

Nee, de `GetImage` methode slaat alleen een statische afbeelding van de dia op, zonder animaties.

**Kunnen verborgen dia's worden geëxporteerd als afbeeldingen?**

Ja, verborgen dia's kunnen worden verwerkt net als normale dia's. Zorg er alleen voor dat ze zijn opgenomen in de verwerkingslus.

**Kunnen afbeeldingen worden opgeslagen met schaduwen en effecten?**

Ja, Aspose.Slides ondersteunt het renderen van schaduwen, transparantie en andere grafische effecte­n bij het opslaan van dia's als afbeeldingen.