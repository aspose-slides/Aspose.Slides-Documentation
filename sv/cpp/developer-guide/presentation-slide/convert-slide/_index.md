---
title: Konvertera presentationsbilder till bilder i C++
linktitle: Bild till bild
type: docs
weight: 41
url: /sv/cpp/convert-slide/
keywords:
- konvertera bild
- exportera bild
- bild till bild
- spara bild som bild
- bild till PNG
- bild till JPEG
- bild till bitmap
- bild till TIFF
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Konvertera bilder från PPT, PPTX och ODP till bildfiler i C++ med Aspose.Slides—snabb, högkvalitativ rendering med tydliga kodexempel."
---
## **Introduktion**

Aspose.Slides for C++ gör det enkelt att konvertera PowerPoint‑ och OpenDocument‑presentationer till olika bildformat, inklusive BMP, PNG, JPG (JPEG), GIF och andra.

För att konvertera en bild till en bildfil, följ dessa steg:

1. Definera önskade konverteringsinställningar och välj de bilder du vill exportera genom att använda:
    - Gränssnittet [ITiffOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/itiffoptions/), eller
    - Gränssnittet [IRenderingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/irenderingoptions/).
2. Generera bildfilen genom att anropa metoden [GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/getimage/).

En [Bitmap](https://reference.aspose.com/slides/sv/cpp/system.drawing/bitmap/) är ett objekt som låter dig arbeta med bilder definierade av pixeldata. Du kan använda en instans av denna klass för att spara bilder i ett brett sortiment av format (BMP, JPG, PNG osv.).

## **Konvertera bilder till bitmapar och spara dem i PNG**

Du kan konvertera en bild till ett bitmap‑objekt och använda det direkt i din applikation. Alternativt kan du konvertera en bild till en bitmap och sedan spara den i JPEG eller något annat önskat format.

Denna C++‑kod visar hur man konverterar den första bilden i en presentation till ett bitmap‑objekt och sedan sparar bilden i PNG‑format:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide in the presentation to a bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Save the image in the PNG format.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Konvertera bilder till bildfiler med anpassade storlekar**

Du kan behöva en bild av en viss storlek. Genom att använda en överlagring av [GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/getimage/) kan du konvertera en bild till en bildfil med specifika dimensioner (bredd och höjd).

Denna exempelkod visar hur man gör detta:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Konvertera den första bilden i presentationen till en bitmap med angiven storlek.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Spara bilden i JPEG-format.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Konvertera bilder med anteckningar och kommentarer till bildfiler**

Vissa bilder kan innehålla anteckningar och kommentarer.

Aspose.Slides tillhandahåller två gränssnitt—[ITiffOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/itiffoptions/) och [IRenderingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/irenderingoptions/)—som låter dig styra rendering av presentationsbilder till bildfiler. Båda gränssnitten innehåller metoden `set_SlidesLayoutOptions`, som gör det möjligt att konfigurera rendering av anteckningar och kommentarer på en bild när den konverteras till en bildfil.

Med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/notescommentslayoutingoptions/) kan du ange din föredragna position för anteckningar och kommentarer i den resulterande bilden.

Denna C++‑kod visar hur du konverterar en bild med anteckningar och kommentarer:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Läs in en presentationsfil.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Ange positionen för noterna.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Ange positionen för kommentarerna.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Ange bredden på kommentarsområdet.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Ange färgen för kommentarsområdet.

// Skapa renderingsalternativen.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Konvertera den första bilden i presentationen till en bild.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Spara bilden i GIF-format.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

I vilken som helst bild‑till‑bildfil‑konverteringsprocess kan metoden [set_NotesPosition](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) inte tillämpa `BottomFull` (för att ange positionen för anteckningar) eftersom en antecknings text kan vara för stor för att få plats i den angivna bildstorleken.

{{% /alert %}} 

## **Konvertera bilder till bildfiler med TIFF‑alternativ**

Gränssnittet [ITiffOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/itiffoptions/) ger större kontroll över den resulterande TIFF‑bilden genom att låta dig specificera parametrar såsom storlek, upplösning, färgpalett och mer.

Denna C++‑kod demonstrerar en konverteringsprocess där TIFF‑alternativ används för att skapa en svart‑vit bild med 300 DPI upplösning och en storlek på 2160 × 2800:

```cpp 
// Läs in en presentationsfil.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Hämta den första bilden från presentationen.
auto slide = presentation->get_Slide(0);

// Konfigurera inställningarna för den utgående TIFF-bilden.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Ange bildstorleken.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Ange pixelformatet (svartvitt).
tiffOptions->set_DpiX(300);                                         // Ange horisontell upplösning.
tiffOptions->set_DpiY(300);                                         // Ange vertikal upplösning.

// Konvertera bilden till en bild med de angivna alternativen.
auto image = slide->GetImage(tiffOptions);

// Spara bilden i TIFF-format.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Konvertera alla bilder till bildfiler**

Aspose.Slides låter dig konvertera alla bilder i en presentation till bildfiler, vilket effektivt omvandlar hela presentationen till en serie bilder.

Denna exempelkod visar hur du konverterar alla bilder i en presentation till bildfiler i C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Rendera presentationen till bilder bild för bild.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Kontrollera dolda bilder (rendera inte dolda bilder).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Konvertera bilden till en bild.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Spara bilden i JPEG-format.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **FAQ**

**Stöder Aspose.Slides rendering av bilder med animationer?**

Nej, metoden `GetImage` sparar endast en statisk bild av bilden, utan animationer.

**Kan dolda bilder exporteras som bildfiler?**

Ja, dolda bilder kan behandlas precis som vanliga. Se bara till att de inkluderas i bearbetningsloopen.

**Kan bilder sparas med skuggor och effekter?**

Ja, Aspose.Slides stöder rendering av skuggor, transparens och andra grafikeffekter när bilder sparas som bildfiler.