---
title: PowerPoint-dia's converteren naar PNG in C++
linktitle: PowerPoint naar PNG
type: docs
weight: 30
url: /nl/cpp/convert-powerpoint-to-png/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar PNG
- presentatie naar PNG
- dia naar PNG
- PPT naar PNG
- PPTX naar PNG
- PPT opslaan als PNG
- PPTX opslaan als PNG
- PPT exporteren naar PNG
- PPTX exporteren naar PNG
- C++
- Aspose.Slides
description: "Converteer PowerPoint-presentaties snel naar hoogwaardige PNG-afbeeldingen met Aspose.Slides voor C++, waardoor nauwkeurige, geautomatiseerde resultaten gegarandeerd worden."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt omzetten naar PNG‑afbeeldingen met Aspose.Slides. Het laat zien hoe u presentaties kunt laden in formaten zoals PPT, PPTX en ODP, dia’s kunt renderen als afbeeldingen en de resultaten kunt opslaan in PNG‑formaat.

Het artikel laat ook zien hoe u de gegenereerde PNG‑afbeeldingen kunt aanpassen door schaalwaarden in te stellen of de gewenste breedte en hoogte op te geven.

## **PowerPoint naar PNG converteren**

Doorloop de volgende stappen:

1. Instantieer de [Presentatie](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse.  
2. Haalt het dia‑object op uit de Presentation::get_Slides()-collectie via de [ISlide](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_slide)‑interface.  
3. Gebruik de [ISlide::GetImage()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/getimage)‑methode om de thumbnail voor elke dia op te halen.  
4. Gebruik de [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method)‑methode om de dia‑thumbnail op te slaan in PNG‑formaat.  

Deze C++‑code laat zien hoe u een PowerPoint‑presentatie naar PNG kunt omzetten:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **PowerPoint naar PNG converteren met aangepaste afmetingen**

Als u PNG‑bestanden wilt verkrijgen met een bepaalde schaal, kunt u de waarden voor `desiredX` en `desiredY` instellen, die de afmetingen van de resulterende thumbnail bepalen.  

Deze C++‑code demonstreert de beschreven handeling:

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

## **PowerPoint naar PNG converteren met aangepaste grootte**

Als u PNG‑bestanden wilt verkrijgen met een bepaalde grootte, kunt u uw gewenste `width`‑ en `height`‑argumenten doorgeven voor `ImageSize`.  

Deze code laat zien hoe u een PowerPoint naar PNG kunt omzetten terwijl u de grootte van de afbeeldingen opgeeft: 

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

## **FAQ**

**Hoe kan ik alleen een specifieke vorm (bijv. grafiek of afbeelding) exporteren in plaats van de hele dia?**

Aspose.Slides ondersteunt het [miniaturen voor individuele vormen genereren](/slides/nl/cpp/create-shape-thumbnails/); u kunt een vorm renderen naar een PNG‑afbeelding.

**Wordt parallelle conversie ondersteund op een server?**

Ja, maar [deel niet](/slides/nl/cpp/multithreading/) een enkele presentatie‑instantie over meerdere threads. Gebruik een aparte instantie per thread of proces.

**Wat zijn de beperkingen van de proefversie bij het exporteren naar PNG?**

De evaluatiemodus voegt een watermerk toe aan de uitvoerafbeeldingen en handhaaft [andere beperkingen](/slides/nl/cpp/licensing/) totdat een licentie is toegepast.