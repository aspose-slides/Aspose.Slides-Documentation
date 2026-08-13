---
title: Ändra presentationsbildens storlek i .NET
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
description: "Lär dig snabbt hur du ändrar storlek på bilder i PPT-, PPTX- och ODP-filer med .NET och Aspose.Slides, optimera presentationer för vilken skärm som helst utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides för .NET tillhandahåller omfattande verktyg för att justera bildens storlek och bildförhållande i PowerPoint-presentationer, vilket är avgörande både för utskrift och skärmvisning. 

Vanliga bildstorlekar och förhållanden:

- **Standard (4:3 bildförhållande)**: Idealisk för äldre skärmar och enheter.
- **Bredbild (16:9 bildförhållande)**: Rekommenderas för moderna projektorer och skärmar.

Säkerställ konsistens i hela din presentation eftersom en enda bildstorlek och ett bildförhållande gäller för alla bilder. För bästa resultat, ange bildens dimensioner i början av presentationsskapandet för att undvika komplikationer.

{{% alert color="info" %}} 
Som standard använder presentationer som skapats med Aspose.Slides det vanliga 4:3‑förhållandet.
{{% /alert %}}

## **Hur du ändrar bildstorlek i en presentation**

Det här exempel visar hur man ändrar bildstorleken i en presentation med Aspose.Slides i C#:

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

Att anpassa bildstorleken efter dina specifika behov, exempelvis för unika papperslayouter eller skärm‑specifikationer, kan vara fördelaktigt. Så här ställer du in en anpassad bildstorlek med Aspose.Slides för .NET:

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

Efter en storleksändring kan bildens innehåll bli förvrängt. Du kan styra hur Aspose.Slides hanterar denna förändring:

- **`DoNotScale`**: Behåll objekt i originalstorlek för att undvika skalning.
- **`EnsureFit`**: Skala objekt så att de passar mindre bilder, vilket förhindrar förlust av innehåll.
- **`Maximize`**: Förstora objekt så att de passar större bilder för estetisk konsistens.

Exempel på hur du använder inställningen `Maximize` för att justera bildstorleken:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **Vanliga frågor**

### Kan jag ange en anpassad bildstorlek med andra enheter än tum (till exempel punkt eller millimeter)?

Ja. Aspose.Slides använder punkter internt, där 1 punkt motsvarar 1/72 tum. Du kan konvertera vilken enhet som helst (t.ex. millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

### Påverkar en mycket stor anpassad bildstorlek prestanda och minnesanvändning under renderingen?

Ja. Större bilddimensioner (i punkter) i kombination med högre renderingsskala leder till ökad minnesförbrukning och längre bearbetningstider. Sträva efter en praktisk bildstorlek och justera renderingsskalan endast vid behov för att uppnå önskad utdata­kvalitet.

### Kan jag definiera en icke‑standard bildstorlek och sedan slå ihop bilder från presentationer som har olika storlekar?

Du kan inte [merge presentations](/slides/sv/net/merge-presentation/) när de har olika bildstorlekar — först, ändra storleken på en presentation så att den matchar den andra. När du ändrar bildstorlek kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/net/aspose.slides/slidesizescaletype/). Efter att storlekarna har anpassats kan du slå ihop bilder samtidigt som formateringen bevaras.

### Kan jag generera miniatyrer för enskilda former eller specifika områden på en bild, och kommer de att respektera den nya bildstorleken?

Ja. Aspose.Slides kan rendera miniatyrer för [entire slides](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/getimage/) såväl som för [selected shapes](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/getimage/). De resulterande bilderna speglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer enhetlig inramning och geometri.