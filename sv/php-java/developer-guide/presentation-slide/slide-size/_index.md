---
title: Ändra bildstorlek för presentation i PHP
linktitle: Bildstorlek
type: docs
weight: 70
url: /sv/php-java/slide-size/
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
- säkerställ anpassning
- maximera
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du snabbt ändrar storlek på bilder i PPT-, PPTX- och ODP-filer med PHP och Aspose.Slides, optimera presentationer för vilken skärm som helst utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides tillhandahåller omfattande verktyg för att justera bildstorlek och bildförhållande i PowerPoint-presentationer, vilket är kritiskt både för utskrift och skärmvisning.

Populära bildstorlekar och förhållanden:

- **Standard (4:3-förhållande)**: Ideal för äldre skärmar och enheter.
- **Bredbild (16:9-förhållande)**: Rekommenderas för moderna projektorer och skärmar.

Säkerställ konsekvens i hela presentationen genom att en enda bildstorlek och ett bildförhållande gäller för alla bilder. För bästa resultat, ange bilddimensionerna i början av ditt presentationsskapande för att undvika komplikationer.

{{% alert color="info" title="Note" %}}
Som standard använder presentationer som skapas med Aspose.Slides det standardiserade 4:3‑förhållandet.
{{% /alert %}}

Antecknings- och utdelningssidors har separata dimensioner från vanliga bilder. Se [Notes Page Size](/slides/sv/php-java/notes-size/) för att ändra deras storlek och orientering.

## **Ändra bildstorlek i presentationer**

Detta exempel på kod visar hur du ändrar bildstorleken i en presentation med Aspose.Slides:

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange anpassade bildstorlekar i presentationer**

Om de vanliga bildstorlekarna (4:3 och 16:9) inte passar ditt arbete kan du välja en specifik eller unik bildstorlek. Till exempel, om du planerar att skriva ut fullstora bilder från din presentation på en anpassad sidlayout eller om du avser att visa presentationen på vissa skärmtyper, kan du ha nytta av att använda en anpassad storleksinställning för din presentation.

Detta exempel på kod visar hur du använder Aspose.Slides för PHP via Java för att ange en anpassad bildstorlek för en presentation:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// A4-pappersstorlek

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hantera bildinnehåll efter storleksändring**

När du ändrar bildstorleken för en presentation kan bildens innehåll (bilder eller objekt, till exempel) bli förvrängt. Som standard får objekten automatiskt en ny storlek för att passa den nya bildstorleken. När du ändrar en presentations bildstorlek kan du dock specificera en inställning som bestämmer hur Aspose.Slides hanterar innehållet på bilderna.

Beroende på vad du vill uppnå kan du använda någon av dessa inställningar:

- `DoNotScale`

  Om du INTE vill att objekten på bilderna ska skalas, använd denna inställning.

- `EnsureFit`

  Om du vill skalera till en mindre bildstorlek och du behöver att Aspose.Slides minskar objektens storlek så att de alla får plats på bilderna (så att du undviker att förlora innehåll), använd denna inställning.

- `Maximize`

  Om du vill skalera till en större bildstorlek och du behöver att Aspose.Slides förstorar objekten så att de blir proportionella mot den nya bildstorleken, använd denna inställning.

Detta exempel på kod visar hur du använder `Maximize`‑inställningen när du ändrar storleken på en presentations bild:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan jag ange en anpassad bildstorlek med enheter annat än tum (till exempel punkter eller millimeter)?**

Ja. Aspose.Slides använder punkter internt, där 1 punkt motsvarar 1/72 tum. Du kan konvertera vilken enhet som helst (till exempel millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

**Kommer en mycket stor anpassad bildstorlek att påverka prestanda och minnesanvändning vid rendering?**

Ja. Större bilddimensioner (i punkter) kombinerat med högre renderingsskala leder till ökat minnesutnyttjande och längre bearbetningstider. Sikta på en praktisk bildstorlek och justera renderingsskalan endast vid behov för att uppnå önskad utskriftskvalitet.

**Kan jag definiera en icke‑standard bildstorlek och sedan slå ihop bilder från presentationer som har olika storlekar?**

Du kan inte [merge presentations](/slides/sv/php-java/merge-presentation/) när de har olika bildstorlekar – först ändrar du storleken på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesizescaletype/). Efter att storlekarna har anpassats kan du slå ihop bilder samtidigt som formateringen bevaras.

**Kan jag generera miniatyrbilder för enskilda former eller specifika områden på en bild, och kommer de att respektera den nya bildstorleken?**

Ja. Aspose.Slides kan rendera miniatyrbilder för [entire slides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage) såväl som för [selected shapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getImage). De resulterande bilderna återspeglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer konsekvent inramning och geometri.