---
title: Ändra presentationens bildstorlek i .NET
linktitle: Bildstorlek
type: docs
weight: 70
url: /sv/net/slide-size/
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
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du snabbt ändrar storlek på bilder i PPT, PPTX och ODP-filer med .NET och Aspose.Slides, optimera presentationer för vilken skärm som helst utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides för .NET erbjuder omfattande verktyg för att justera bildstorlek och bildförhållande i PowerPoint‑presentationer, vilket är avgörande både för utskrift och bildskärmvisning.

Populära bildstorlekar och förhållanden:

- **Standard (4:3‑förhållande)**: Idealiskt för äldre skärmar och enheter.
- **Bredbild (16:9‑förhållande)**: Rekommenderas för moderna projektorer och skärmar.

Säkerställ konsistens i hela din presentation eftersom en enda bildstorlek och ett bildförhållande gäller för alla bilder. För bästa resultat, ange bildmåtten i början av ditt presentationsskapande för att undvika komplikationer.

{{% alert color="info" %}} 
Som standard använder presentationer som skapas med Aspose.Slides det vanliga 4:3‑förhållandet.
{{% /alert %}}

Antecknings- och utdelningssidor har separata mått jämfört med vanliga bilder. Se [Notes Page Size](/slides/sv/net/notes-size/) för att ändra deras storlek och orientering.

## **Hur du ändrar bildstorleken i en presentation**

Detta exempel visar hur du ändrar en presentations bildstorlek med Aspose.Slides i C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Ange anpassade bildstorlekar**

Att anpassa bildstorleken efter dina specifika behov, till exempel för unika papperslayouter eller skärm‑specifikationer, kan vara fördelaktigt. Så här anger du en anpassad bildstorlek med Aspose.Slides för .NET:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-pappersstorlek
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Hantera bildinnehåll efter storleksändring**

Efter storleksändring kan bildinnehållet bli förvrängt. Du kan styra hur Aspose.Slides hanterar denna ändring:

- **`DoNotScale`**: Behåll objekt i sina ursprungliga storlekar för att undvika skalning.
- **`EnsureFit`**: Skala objekt så att de passar på mindre bilder, vilket förhindrar förlust av innehåll.
- **`Maximize`**: Förstora objekt så att de passar på större bilder för estetisk konsistens.

Exempel på hur du använder `Maximize`‑inställningen för att justera bildstorlek:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **Vanliga frågor**

### Kan jag ange en anpassad bildstorlek med enheter annat än tum (till exempel punkter eller millimeter)?

Ja. Aspose.Slides använder punkter internt, där 1 punkt motsvarar 1/72 tum. Du kan konvertera vilken enhet som helst (till exempel millimeter eller centimeter) till punkter och använda de konverterade värdena för att ange bildbredd och -höjd.

### Kommer en mycket stor anpassad bildstorlek att påverka prestanda och minnesanvändning vid rendering?

Ja. Större bilddimensioner (i punkter) i kombination med högre renderingsskala leder till ökad minnesförbrukning och längre bearbetningstider. Sikta på en praktisk bildstorlek och justera renderingsskalan endast vid behov för att uppnå önskad utskriftskvalitet.

### Kan jag definiera en icke‑standard bildstorlek och sedan slå ihop bilder från presentationer som har olika storlekar?

Du kan inte [merge presentations](/slides/sv/net/merge-presentation/) när de har olika bildstorlekar – först, ändra storleken på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/net/aspose.slides/slidesizescaletype/). Efter att storlekarna är anpassade kan du slå ihop bilder samtidigt som formateringen bevaras.

### Kan jag generera miniatyrer för enskilda former eller specifika områden i en bild, och kommer de att följa den nya bildstorleken?

Ja. Aspose.Slides kan rendera miniatyrer för [entire slides](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/getimage/) såväl som för [selected shapes](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/getimage/). Resultatbilderna speglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer enhetlig inramning och geometri.