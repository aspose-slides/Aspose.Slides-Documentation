---
title: Presentatiedia's omzetten naar afbeeldingen in C++
linktitle: Dia naar afbeelding
type: docs
weight: 41
url: /nl/cpp/convert-slide/
keywords:
- dia converteren
- dia exporteren
- dia naar afbeelding
- dia bewaren als afbeelding
- dia naar PNG
- dia naar JPEG
- dia naar bitmap
- dia naar TIFF
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Dia's van PPT, PPTX en ODP omzetten naar afbeeldingen in C++ met Aspose.Slides—snelle, hoogwaardige rendering met duidelijke codevoorbeelden."
---
## **Inleiding**

Aspose.Slides for C++ maakt het eenvoudig om PowerPoint‑ en OpenDocument‑presentatieslides om te zetten naar verschillende afbeeldingsformaten, waaronder BMP, PNG, JPG (JPEG), GIF en andere.

Om een slide naar een afbeelding te converteren, volgt u deze stappen:

1. Definieer de gewenste conversie‑instellingen en selecteer de slides die u wilt exporteren met behulp van:
    - De [ITiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/itiffoptions/) interface, of
    - De [IRenderingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/irenderingoptions/) interface.
2. Genereer de slide‑afbeelding door de [GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/getimage/) methode aan te roepen.

Een [Bitmap](https://reference.aspose.com/slides/nl/cpp/system.drawing/bitmap/) is een object waarmee u kunt werken met afbeeldingen die zijn gedefinieerd door pixelgegevens. U kunt een instantie van deze klasse gebruiken om afbeeldingen op te slaan in een breed scala aan formaten (BMP, JPG, PNG, enz.).

## **Slides omzetten naar Bitmaps en de afbeeldingen opslaan in PNG**

U kunt een slide omzetten naar een bitmap‑object en deze direct in uw applicatie gebruiken. Als alternatief kunt u een slide omzetten naar een bitmap en vervolgens de afbeelding opslaan in JPEG of een ander gewenst formaat.

Deze C++‑code toont hoe u de eerste slide van een presentatie omzet naar een bitmap‑object en vervolgens de afbeelding opslaat in PNG‑formaat:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Converteer de eerste dia in de presentatie naar een bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Sla de afbeelding op in PNG-formaat.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Slides omzetten naar afbeeldingen met aangepaste afmetingen**

U wilt misschien een afbeelding met een bepaalde afmeting verkrijgen. Met behulp van een overload van de [GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/getimage/) kunt u een slide omzetten naar een afbeelding met specifieke dimensies (breedte en hoogte). 

Deze voorbeeldcode toont hoe u dit kunt doen:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Converteer de eerste dia in de presentatie naar een bitmap met de opgegeven grootte.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Sla de afbeelding op in JPEG-formaat.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Slides met notities en opmerkingen omzetten naar afbeeldingen**

Enkele slides kunnen notities en opmerkingen bevatten.

Aspose.Slides biedt twee interfaces—[ITiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/itiffoptions/) en [IRenderingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/irenderingoptions/)—die u in staat stellen de weergave van presentatieslides naar afbeeldingen te regelen. Beide interfaces bevatten de `set_SlidesLayoutOptions`‑methode, waarmee u de weergave van notities en opmerkingen op een slide kunt configureren bij het omzetten naar een afbeelding.

Met de klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notescommentslayoutingoptions/) kunt u uw gewenste positie voor notities en opmerkingen in de resulterende afbeelding aangeven.

Deze C++‑code toont hoe u een slide met notities en opmerkingen omzet:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Laad een presentatiebestand.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Stel de positie van de notities in.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Stel de positie van de opmerkingen in.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Stel de breedte van het opmerkingengebied in.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Stel de kleur voor het opmerkingengebied in.

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

{{% alert title="Note" color="warning" %}} 

In elk slide‑naar‑afbeelding‑conversieproces kan de [set_NotesPosition](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) methode de instelling `BottomFull` (om de positie voor notities op te geven) niet toepassen, omdat de tekst van een notitie te groot kan zijn om binnen de opgegeven afbeeldingsgrootte te passen.

{{% /alert %}} 

## **Slides omzetten naar afbeeldingen met TIFF‑opties**

De [ITiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/itiffoptions/) interface biedt meer controle over de resulterende TIFF‑afbeelding door u parameters zoals grootte, resolutie, kleurenpalet en meer te laten specificeren.

Deze C++‑code toont een conversieproces waarbij TIFF‑opties worden gebruikt om een zwart‑wit afbeelding met een resolutie van 300 DPI en een grootte van 2160 × 2800 te produceren:

```cpp 
// Laad een presentatiebestand.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Haal de eerste dia uit de presentatie.
auto slide = presentation->get_Slide(0);

// Configureer de instellingen van de output TIFF-afbeelding.
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

## **Alle slides omzetten naar afbeeldingen**

Aspose.Slides maakt het mogelijk om alle slides in een presentatie om te zetten naar afbeeldingen, waardoor de hele presentatie effectief wordt omgezet in een reeks afbeeldingen.

Deze voorbeeldcode toont hoe u alle slides in een presentatie kunt omzetten naar afbeeldingen in C++:

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

## **Kleur‑emoji weergave**

{{% alert title="Note" color="warning" %}} 
Om kleur‑emoji’s correct weer te geven bij het omzetten van presentatieslides naar afbeeldingen, moeten de emoji‑lettertypen die in de presentatie worden gebruikt geïnstalleerd en beschikbaar zijn op het systeem dat de conversie uitvoert. Bijvoorbeeld, als de presentatie **Segoe UI Emoji** gebruikt en dit lettertype ontbreekt, kunnen emoji’s monochroom verschijnen in de uitvoer‑afbeeldingen.
{{% /alert %}}

## **Veelgestelde vragen**

**Ondersteunt Aspose.Slides het renderen van slides met animaties?**

Nee, de `GetImage`‑methode slaat alleen een statische afbeelding van de slide op, zonder animaties.

**Kunnen verborgen slides worden geëxporteerd als afbeeldingen?**

Ja, verborgen slides kunnen worden verwerkt net als gewone slides. Zorg er alleen voor dat ze zijn opgenomen in de verwerkingslus.

**Kunnen afbeeldingen worden opgeslagen met schaduwen en effecten?**

Ja, Aspose.Slides ondersteunt het renderen van schaduwen, transparantie en andere grafische effecten bij het opslaan van slides als afbeeldingen.