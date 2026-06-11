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
descriptions: "Lär dig snabbt hur du ändrar storlek på bilder i PPT-, PPTX- och ODP-filer med .NET och Aspose.Slides, optimera presentationer för vilken skärm som helst utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides för .NET tillhandahåller omfattande verktyg för att justera bildstorlek och bildförhållande i PowerPoint‑presentationer, vilket är kritiskt både för utskrift och visning på skärm. 

Vanliga bildstorlekar och förhållanden:

- **Standard (4:3‑förhållande)**: Perfekt för äldre skärmar och enheter.
- **Bredbild (16:9‑förhållande)**: Rekommenderas för moderna projektorer och skärmar.

Se till att hålla en enhetlig bildstorlek och bildförhållande i hela presentationen, eftersom en enda bildstorlek och förhållande gäller för alla bilder. För bästa resultat ska du ange bildens dimensioner i början av presentationsskapandet för att undvika komplikationer.

{{% alert color="primary" %}} 
Som standard använder presentationer som skapas med Aspose.Slides det vanliga 4:3‑förhållandet.
{{% /alert %}}

## **Hur du ändrar bildstorleken i en presentation**

Detta exempel visar hur du ändrar en presentations bildstorlek med Aspose.Slides i C#:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Ange anpassade bildstorlekar**

Att anpassa bildstorleken efter dina specifika behov, exempelvis för unika papperlayouter eller skärmspecifikationer, kan vara fördelaktigt. Så här anger du en anpassad bildstorlek med Aspose.Slides för .NET:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 pappersstorlek
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Hantera bildinnehåll efter storleksändring**

Efter en storleksändring kan bildens innehåll förvrängas. Du kan styra hur Aspose.Slides hanterar denna förändring:

- **`DoNotScale`**: Behåller objekt i sina ursprungliga storlekar för att undvika skalning.
- **`EnsureFit`**: Skalar objekt så att de passar mindre bilder, vilket förhindrar innehållsförlust.
- **`Maximize`**: Förstorar objekt för att passa större bilder för estetisk konsekvens.

Exempel på att använda `Maximize`‑inställningen för att justera bildstorlek:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

**Kan jag ange en anpassad bildstorlek med andra enheter än tum (t.ex. punkter eller millimeter)?**

Ja. Aspose.Slides använder punkter internt, där 1 punkt motsvarar 1/72 tum. Du kan konvertera vilken enhet som helst (t.ex. millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

**Kommer en mycket stor anpassad bildstorlek att påverka prestanda och minnesanvändning vid rendering?**

Ja. Större bilddimensioner (i punkter) i kombination med högre renderingsskala leder till ökat minnesbruk och längre behandlingstider. Sträva efter en praktisk bildstorlek och justera renderingsskalan endast efter behov för att uppnå önskad utskriftskvalitet.

**Kan jag definiera en icke‑standard bildstorlek och sedan slå samman bilder från presentationer som har olika storlekar?**

Du kan inte [slå samman presentationer](/slides/sv/net/merge-presentation/) när de har olika bildstorlekar — först, ändra storleken på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/net/aspose.slides/slidesizescaletype/). Efter att storlekarna har anpassats kan du slå samman bilder samtidigt som formateringen bevaras.

**Kan jag generera miniatyrer för enskilda former eller specifika områden av en bild, och kommer de att respektera den nya bildstorleken?**

Ja. Aspose.Slides kan rendera miniatyrer för [hela bilder](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/getimage/) såväl som för [utvalda former](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/getimage/). De resulterande bilderna speglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer enhetlig inramning och geometri.