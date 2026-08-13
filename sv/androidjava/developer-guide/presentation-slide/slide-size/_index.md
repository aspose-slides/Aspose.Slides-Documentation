---
title: Ändra bildstorlek för presentation på Android
linktitle: Bildstorlek
type: docs
weight: 70
url: /sv/androidjava/slide-size/
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
- Android
- Java
- Aspose.Slides
description: "Snabbt ändra storlek på bilder i PPT-, PPTX- och ODP-filer med Java och Aspose.Slides för Android, optimera presentationer för vilken skärm som helst utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides tillhandahåller omfattande verktyg för att justera bildstorlek och bildförhållande i PowerPoint‑presentationer, vilket är avgörande för både utskrift och visning på skärm.

Populära bildstorlekar och förhållanden:

- **Standard (4:3 Bildförhållande)**: Idealiskt för äldre skärmar och enheter.
- **Bredbild (16:9 Bildförhållande)**: Rekommenderas för moderna projektorer och skärmar.

Säkerställ konsekvens i hela presentationen då en enskild bildstorlek och bildförhållande gäller för alla bilder. För bästa resultat, ställ in bildens dimensioner i början av skapandeprocessen för presentationen för att undvika komplikationer.

{{% alert color="info" %}} 
Som standard använder presentationer som skapats med Aspose.Slides det vanliga 4:3 bildförhållandet.
{{% /alert %}}

## **Ändra bildstorlek i presentationer**

Den här exempelkoden visar hur du ändrar bildstorleken i en presentation i Java med Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange anpassade bildstorlekar i presentationer**

Om du finner de vanliga bildstorlekarna (4:3 och 16:9) olämpliga för ditt arbete kan du välja att använda en specifik eller unik bildstorlek. Till exempel, om du planerar att skriva ut helstora bilder från din presentation på en anpassad sidlayout eller om du avser att visa presentationen på vissa skärmtyper, kan du ha nytta av att använda en anpassad storleksinställning för din presentation.

Den här exempelkoden visar hur du använder Aspose.Slides för Android via Java för att ange en anpassad bildstorlek för en presentation i Java:

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

När du ändrar bildstorleken för en presentation kan bildens innehåll (t.ex. bilder eller objekt) bli förvrängt. Som standard skalas objekt automatiskt om för att passa den nya bildstorleken. När du ändrar en presentations bildstorlek kan du dock ange en inställning som bestämmer hur Aspose.Slides hanterar innehållet på bilderna.

Beroende på vad du vill göra eller uppnå kan du använda någon av dessa inställningar:

- `DoNotScale`

  Om du INTE vill att objekten på bilderna ska skalas om, använd den här inställningen.

- `EnsureFit`

  Om du vill skala till en mindre bildstorlek och du behöver att Aspose.Slides minskar bildens objekt för att säkerställa att de alla får plats på bilderna (så undviker du att förlora innehåll), använd den här inställningen.

- `Maximize`

  Om du vill skala till en större bildstorlek och du behöver att Aspose.Slides förstorar bildens objekt så att de blir proportionella mot den nya bildstorleken, använd den här inställningen.

Den här exempelkoden visar hur du använder `Maximize`‑inställningen när du ändrar storleken på en presentations bild:

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

### Kan jag ange en anpassad bildstorlek med andra enheter än tum (t.ex. punkter eller millimeter)?

Ja. Aspose.Slides använder punkter internt, där 1 punkt motsvarar 1/72 tum. Du kan konvertera vilken enhet som helst (såsom millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

### Påverkar en mycket stor anpassad bildstorlek prestanda och minnesanvändning vid rendering?

Ja. Större bilddimensioner (i punkter) kombinerat med högre renderingsskala leder till ökad minnesförbrukning och längre behandlingstider. Sikta på en praktisk bildstorlek och justera renderingsskalan endast när det behövs för att uppnå önskad utdata­kvalitet.

### Kan jag definiera en icke‑standard bildstorlek och sedan sammanfoga bilder från presentationer som har olika storlekar?

Du kan inte [sammanfoga presentationer](/slides/sv/androidjava/merge-presentation/) när de har olika bildstorlekar — först, ändra storlek på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidesizescaletype/). Efter att storlekarna har anpassats kan du sammanfoga bilder samtidigt som formateringen bevaras.

### Kan jag generera miniatyrer för enskilda former eller specifika områden av en bild, och kommer de att respekt­era den nya bildstorleken?

Ja. Aspose.Slides kan rendera miniatyrer för [hela bilder](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) samt för [valda former](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). De resulterande bilderna speglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer enhetlig inramning och geometri.