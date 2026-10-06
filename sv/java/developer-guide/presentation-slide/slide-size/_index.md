---
title: Ändra bildstorlek i presentationen i Java
linktitle: Bildstorlek
type: docs
weight: 70
url: /sv/java/slide-size/
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
- Java
- Aspose.Slides
description: "Lär dig snabbt hur du ändrar storlek på bilder i PPT-, PPTX- och ODP-filer med Java och Aspose.Slides, optimera presentationer för alla skärmar utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides tillhandahåller omfattande verktyg för att justera bildstorlek och bildförhållande i PowerPoint-presentationer, vilket är kritiskt både för utskrift och visning på skärm. 

Vanliga bildstorlekar och förhållanden:

- **Standard (4:3‑förhållande)**: Ideal för äldre skärmar och enheter.
- **Bredbild (16:9‑förhållande)**: Rekommenderas för moderna projektorer och skärmar.

Säkerställ konsistens i hela din presentation eftersom en enskild bildstorlek och bildförhållande gäller för alla bilder. För optimala resultat, ange bildmåtten i början av presentationsskapandet för att undvika komplikationer.

{{% alert color="info" title="Note" %}}
Som standard använder presentationer som skapats med Aspose.Slides standardförhållandet 4:3.
{{% /alert %}}

Noter och utdelningssidor har separata mått från vanliga bilder. Se [Storlek på notsidan](/slides/sv/java/notes-size/) för att ändra deras storlek och orientering.

## **Ändra bildstorlek i presentationer**

Detta exempel visar hur du ändrar bildstorlek i en presentation i Java med Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange anpassade bildstorlekar i presentationer**

Om du finner de vanliga bildstorlekarna (4:3 och 16:9) olämpliga för ditt arbete, kan du bestämma dig för att använda en specifik eller unik bildstorlek. Till exempel, om du planerar att skriva ut fullstora bilder från din presentation på en anpassad sidlayout eller om du avser att visa din presentation på vissa skärmtyper, kan du ha nytta av att använda en anpassad storleksinställning för din presentation. 

Detta exempel visar hur du använder Aspose.Slides för Java för att ange en anpassad bildstorlek för en presentation i Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-pappersstorlek
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hantera bildinnehåll efter storleksändring**

Efter att du har ändrat bildstorleken för en presentation kan bildens innehåll (bilder eller objekt, till exempel) bli förvrängt. Som standard anpassas objekten automatiskt för att passa den nya bildstorleken. När du ändrar en presentations bildstorlek kan du dock ange en inställning som bestämmer hur Aspose.Slides hanterar innehållet på bilderna.

Beroende på vad du avser att göra eller uppnå kan du använda någon av dessa inställningar:

- `DoNotScale`

  Om du INTE vill att objekten på bilderna ska skalas om, använd denna inställning.

- `EnsureFit`

  Om du vill skala till en mindre bildstorlek och du behöver att Aspose.Slides skalar ner bildens objekt för att säkerställa att de alla får plats på bilderna (så undviker du att förlora innehåll), använd denna inställning. 

- `Maximize`

  Om du vill skala till en större bildstorlek och du behöver att Aspose.Slides förstorar bildens objekt så att de blir proportionella mot den nya bildstorleken, använd denna inställning. 

Detta exempel visar hur du använder `Maximize`-inställningen när du ändrar storleken på en presentations bild:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Kan jag ange en anpassad bildstorlek med enheter förutom tum (till exempel punkter eller millimeter)?**

Ja. Aspose.Slides använder punkter internt, där 1 punkt motsvarar 1/72 tum. Du kan konvertera vilken enhet som helst (till exempel millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

**Kommer en mycket stor anpassad bildstorlek att påverka prestanda och minnesanvändning under rendering?**

Ja. Större bildmått (i punkter) i kombination med högre renderingsskala leder till ökat minnesbruk och längre behandlingstider. Sträva efter en praktisk bildstorlek och justera renderingsskalan endast vid behov för att uppnå önskad utskriftskvalitet.

**Kan jag definiera en icke‑standard bildstorlek och sedan slå ihop bilder från presentationer som har olika storlekar?**

Du kan inte [slå ihop presentationer](/slides/sv/java/merge-presentation/) medan de har olika bildstorlekar – först, ändra storleken på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidesizescaletype/). Efter att storlekarna har matchats kan du slå ihop bilder samtidigt som formateringen bevaras.

**Kan jag generera miniatyrer för enskilda former eller specifika områden på en bild, och kommer de att följa den nya bildstorleken?**

Ja. Aspose.Slides kan rendera miniatyrer för [hela bilder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) såväl som för [valda former](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getImage-int-float-float-). De resulterande bilderna återspeglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer enhetlig inramning och geometri.