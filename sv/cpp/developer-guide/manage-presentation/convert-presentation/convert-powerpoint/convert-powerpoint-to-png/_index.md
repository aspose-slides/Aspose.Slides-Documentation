---
title: Konvertera PowerPoint‑bilder till PNG i C++
linktitle: PowerPoint till PNG
type: docs
weight: 30
url: /sv/cpp/convert-powerpoint-to-png/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till PNG
- presentation till PNG
- bild till PNG
- PPT till PNG
- PPTX till PNG
- spara PPT som PNG
- spara PPTX som PNG
- exportera PPT till PNG
- exportera PPTX till PNG
- C++
- Aspose.Slides
description: "Konvertera PowerPoint‑presentationer till högkvalitativa PNG‑bilder snabbt med Aspose.Slides för C++, vilket säkerställer precisa, automatiserade resultat."
---
## **Översikt**

Denna artikel förklarar hur du konverterar PowerPoint‑presentationer till PNG‑bilder med Aspose.Slides. Den visar hur du laddar presentationsfiler i format som PPT, PPTX och ODP, renderar bilder som bilder och sparar resultaten i PNG‑format.

Artikeln visar även hur du anpassar de genererade PNG‑bilderna genom att ange skalvärden eller specificera önskad bredd och höjd.

## **Konvertera PowerPoint till PNG**

Gå igenom dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
2. Hämta bildobjektet från samlingen [Presentation::get_Slides()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) under gränssnittet [ISlide](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_slide).
3. Använd metoden [ISlide::GetImage()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/getimage) för att hämta miniatyrbilden för varje bild.
4. Använd metoden [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) för att spara bildens miniatyr i PNG‑format.

Denna C++‑kod visar hur du konverterar en PowerPoint‑presentation till PNG:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **Konvertera PowerPoint till PNG med anpassade dimensioner**

Om du vill få PNG‑filer med en viss skala kan du ange värdena för `desiredX` och `desiredY`, vilka bestämmer dimensionerna på den resulterande miniatyrbilden.

Denna kod i C++ demonstrerar den beskrivna operationen:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **Konvertera PowerPoint till PNG med anpassad storlek**

Om du vill få PNG‑filer med en viss storlek kan du skicka dina önskade `width`‑ och `height`‑argument för `ImageSize`.

Denna kod visar hur du konverterar en PowerPoint till PNG medan du specificerar storleken på bilderna:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

## **Vanliga frågor**

**Hur kan jag exportera endast en specifik form (t.ex. diagram eller bild) istället för hela bilden?**

Aspose.Slides stöder [generering av miniatyrbilder för enskilda former](/slides/sv/cpp/create-shape-thumbnails/); du kan rendera en form till en PNG‑bild.

**Stöds parallell konvertering på en server?**

Ja, men [dela inte](/slides/sv/cpp/multithreading/) en enskild presentationsinstans mellan trådar. Använd en separat instans per tråd eller process.

**Vilka är begränsningarna i provversionen vid export till PNG?**

Utvärderingsläget lägger till ett vattenmärke på utskriftsbilder och upprätthåller [andra begränsningar](/slides/sv/cpp/licensing/) tills en licens har tillämpats.