---
title: Ändra presentationens bildstorlek i C++
linktitle: Bildstorlek
type: docs
weight: 70
url: /sv/cpp/slide-size/
keywords:
- bildstorlek
- bildförhållande
- standard
- bredbild
- 4:3
- 16:9
- ange bildstorlek
- ändra bildstorlek
- anpassad bildstorlek
- speciell bildstorlek
- unik bildstorlek
- fullstor bild
- skärmtyp
- skala inte
- säkerställ passning
- maximera
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du snabbt ändrar storlek på bilder i PPT-, PPTX- och ODP-filer med C++ och Aspose.Slides, optimera presentationer för vilken skärm som helst utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides tillhandahåller omfattande verktyg för att justera bildstorlek och bildförhållande i PowerPoint-presentationer, vilket är kritiskt både för utskrift och visning på skärm. 

Vanliga bildstorlekar och förhållanden:

- **Standard (4:3 bildförhållande)**: Ideal för äldre skärmar och enheter.
- **Bredbild (16:9 bildförhållande)**: Rekommenderas för moderna projektorer och skärmar.

Säkerställ konsistens i hela din presentation eftersom en enskild bildstorlek och bildförhållande gäller för alla bilder. För bästa resultat, ange bilddimensionerna i början av skapandeprocessen för presentationen för att undvika komplikationer.

{{% alert color="primary" %}} 
Som standard använder presentationer som skapas med Aspose.Slides det standardiserade 4:3‑bildförhållandet.
{{% /alert %}}

## **Ändra bildstorlek i presentationer**

Det här exempelprogrammet visar hur du ändrar bildstorleken i en presentation i C++ med Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Ange anpassade bildstorlekar i presentationer**

Om du anser att de vanliga bildstorlekarna (4:3 och 16:9) är olämpliga för ditt arbete, kan du välja att använda en specifik eller unik bildstorlek. Till exempel, om du planerar att skriva ut bilder i full storlek från din presentation på en anpassad sidlayout eller om du avser att visa presentationen på vissa skärmtyper, kan du ha nytta av att använda en anpassad storleksinställning för presentationen. 

Det här exempelprogrammet visar hur du använder Aspose.Slides för C++ för att ange en anpassad bildstorlek för en presentation i C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 pappersstorlek
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Hantera bildinnehåll efter storleksändring**

När du ändrar bildstorleken för en presentation kan bildens innehåll (t.ex. bilder eller objekt) bli förvrängt. Som standard blir objekten automatiskt omdimensionerade för att passa den nya bildstorleken. När du ändrar en presentations bildstorlek kan du dock ange en inställning som bestämmer hur Aspose.Slides hanterar innehållet på bilderna.

Beroende på vad du avser att göra eller uppnå kan du använda någon av dessa inställningar:

- `DoNotScale`

  Om du INTE vill att objekten på bilderna ska omdimensioneras, använd den här inställningen.

- `EnsureFit`

  Om du vill skala till en mindre bildstorlek och du behöver att Aspose.Slides minskar bildens objekt för att säkerställa att de alla får plats på bilderna (så undviker du att förlora innehåll), använd den här inställningen. 

- `Maximize`

  Om du vill skala till en större bildstorlek och du behöver att Aspose.Slides förstorar bildens objekt så att de blir proportionella mot den nya bildstorleken, använd den här inställningen. 

Det här exempelprogrammet visar hur du använder `Maximize`-inställningen när du ändrar storleken på en presentations bild:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **Vanliga frågor**

**Kan jag ange en anpassad bildstorlek med enheter annat än tum (till exempel punkter eller millimeter)?**

Ja. Aspose.Slides använder punkter internt, där 1 punkt motsvarar 1/72 tum. Du kan konvertera vilken enhet som helst (t.ex. millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

**Kommer en väldigt stor anpassad bildstorlek att påverka prestanda och minnesanvändning under rendering?**

Ja. Större bilddimensioner (i punkter) kombinerat med högre renderingsskala leder till ökat minnesförbrukning och längre bearbetningstid. Sträva efter en praktisk bildstorlek och justera renderingsskalan endast när det behövs för att uppnå önskad utdata kvalitet.

**Kan jag definiera en icke‑standard bildstorlek och sedan sammanslå bilder från presentationer som har olika storlekar?**

Du kan inte [merge presentations](/slides/sv/cpp/merge-presentation/) när de har olika bildstorlekar – först, ändra storleken på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidesizescaletype/). Efter att storlekarna har justerats kan du sammanslå bilder samtidigt som formateringen bevaras.

**Kan jag generera miniatyrbilder för enskilda former eller specifika områden på en bild, och kommer de att respektera den nya bildstorleken?**

Ja. Aspose.Slides kan rendera miniatyrbilder för [entire slides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slide/getimage/) såväl som för [selected shapes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/getimage/). De resulterande bilderna återspeglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer enhetlig inramning och geometri.