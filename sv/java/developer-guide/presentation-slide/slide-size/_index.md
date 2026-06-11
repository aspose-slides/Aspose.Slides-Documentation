---
title: Ändra bildstorlek på presentationen i Java
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
- fullstora bild
- skärmtyp
- skala inte
- säkerställ passning
- maximera
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
descriptions: "Lär dig hur du snabbt ändrar storlek på bilder i PPT-, PPTX- och ODP-filer med Java och Aspose.Slides, optimera presentationer för alla skärmar utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides tillhandahåller omfattande verktyg för att justera bildstorlek och bildförhållande i PowerPoint-presentationer, vilket är kritiskt både för utskrift och visning på skärm. 

Vanliga bildstorlekar och förhållanden:

- **Standard (4:3 Bildförhållande)**: Idealisk för äldre skärmar och enheter.
- **Bredbild (16:9 Bildförhållande)**: Rekommenderas för moderna projektorer och skärmar.

Säkerställ konsekvens i hela presentationen eftersom en enhetlig bildstorlek och bildförhållande gäller för alla bilder. För bästa resultat, ange bildens dimensioner i början av presentationsskapandet för att undvika komplikationer.

{{% alert color="primary" %}} 
Som standard använder presentationer som skapas med Aspose.Slides det standardiserade 4:3‑bildförhållandet.
{{% /alert %}}

## **Ändra bildstorlek i presentationer**

Detta exempel visar hur du ändrar bildstorleken i en presentation i Java med Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange anpassade bildstorlekar i presentationer**

Om du tycker att de vanliga bildstorlekarna (4:3 och 16:9) är olämpliga för ditt arbete, kan du välja att använda en specifik eller unik bildstorlek. Till exempel, om du planerar att skriva ut bilder i full storlek från din presentation på en anpassad sidlayout eller om du avser att visa din presentation på vissa skärmtyper, kan du dra nytta av att använda en anpassad storleksinställning för din presentation. 

Detta exempel visar hur du använder Aspose.Slides för Java för att ange en anpassad bildstorlek för en presentation i Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-pappersstorlek
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hantera bildinnehåll efter storleksändring**

När du ändrar bildstorleken för en presentation kan bildens innehåll (t.ex. bilder eller objekt) bli förvrängt. Som standard anpassas objekten automatiskt för att passa den nya bildstorleken. Däremot, vid förändring av en presentations bildstorlek, kan du ange en inställning som bestämmer hur Aspose.Slides hanterar innehållet på bilderna.

Beroende på vad du vill göra eller uppnå kan du använda någon av dessa inställningar:

- `DoNotScale`

  Om du INTE vill att objekten på bilderna skalas om, använd denna inställning.

- `EnsureFit`

  Om du vill skala till en mindre bildstorlek och behöver att Aspose.Slides minskar bildens objekt för att säkerställa att de alla får plats på bilderna (så undviker du förlorat innehåll), använd denna inställning. 

- `Maximize`

  Om du vill skala till en större bildstorlek och behöver att Aspose.Slides förstorar bildens objekt så att de blir proportionella mot den nya bildstorleken, använd denna inställning. 

Detta exempel visar hur du använder `Maximize`‑inställningen när du ändrar en presentations bildstorlek:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan jag ange en anpassad bildstorlek med andra enheter än tum (t.ex. punkter eller millimeter)?**

Ja. Aspose.Slides använder punkter internt, där 1 punkt motsvarar 1/72 tum. Du kan konvertera vilken enhet som helst (t.ex. millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

**Kommer en mycket stor anpassad bildstorlek att påverka prestanda och minnesanvändning vid rendering?**

Ja. Större bilddimensioner (i punkter) i kombination med högre renderingsskala leder till ökad minnesförbrukning och längre bearbetningstider. Sikta på en praktisk bildstorlek och justera renderingsskalan endast vid behov för att uppnå önskad utskriftskvalitet.

**Kan jag definiera en icke‑standard bildstorlek och sedan sammanfoga bilder från presentationer som har olika storlekar?**

Du kan inte [sammanfoga presentationer](/slides/sv/java/merge-presentation/) när de har olika bildstorlekar – först, ändra storleken på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidesizescaletype/). Efter att ha justerat storlekarna kan du sammanfoga bilder samtidigt som formateringen bevaras.

**Kan jag generera miniatyrbilder för enskilda former eller specifika områden på en bild, och kommer de att respektera den nya bildstorleken?**

Ja. Aspose.Slides kan rendera miniatyrer för [hela bilder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) samt för [valda former](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getImage-int-float-float-). De resulterande bilderna speglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer en enhetlig inramning och geometri.