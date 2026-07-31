---
title: Ändra bildstorlek för presentationen i PHP
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
- säkerställ passning
- maximera
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lär dig snabbt hur du ändrar storlek på bilder i PPT-, PPTX- och ODP-filer med PHP och Aspose.Slides, optimera presentationer för vilken skärm som helst utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides tillhandahåller omfattande verktyg för att justera bildstorlek och bildförhållande i PowerPoint‑presentationer, vilket är viktigt både för utskrift och visning på skärm. 

Populära bildstorlekar och förhållanden:

- **Standard (4:3 bildförhållande)**: Idealiskt för äldre skärmar och enheter.
- **Bredbild (16:9 bildförhållande)**: Rekommenderas för moderna projektorer och skärmar.

Säkerställ konsekvens i hela presentationen då en enda bildstorlek och bildförhållande gäller för alla bilder. För optimala resultat, ange bildens dimensioner i början av presentationsskapandet för att undvika komplikationer.

{{% alert color="primary" %}} 
Som standard använder presentationer som skapats med Aspose.Slides det vanliga 4:3‑förhållandet.
{{% /alert %}}

## **Ändra bildstorlek i presentationer**

Den här exempelkoden visar hur du ändrar bildstorleken i en presentation med Aspose.Slides:

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

Om de vanliga bildstorlekarna (4:3 och 16:9) inte passar ditt arbete kan du behöva använda en specifik eller unik bildstorlek. Till exempel, om du planerar att skriva ut fullstora bilder från din presentation på en anpassad sidlayout eller om du avser att visa din presentation på vissa skärmtyper, kan du ha nytta av att använda en anpassad storleksinställning för din presentation. 

Den här exempelkoden visar hur du använder Aspose.Slides för PHP via Java för att ange en anpassad bildstorlek för en presentation :

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

Efter att du har ändrat bildstorleken för en presentation kan bildens innehåll (t.ex. bilder eller objekt) bli förvrängt. Som standard blir objekten automatiskt anpassade för att passa den nya bildstorleken. När du ändrar en presentations bildstorlek kan du dock ange en inställning som bestämmer hur Aspose.Slides hanterar innehållet på bilderna.

Beroende på vad du avser att göra eller uppnå kan du använda någon av dessa inställningar:

- `DoNotScale`

  Om du INTE vill att objekten på bilderna ska skalas om, använd denna inställning.

- `EnsureFit`

  Om du vill skala till en mindre bildstorlek och behöver att Aspose.Slides skalar ner bildobjekten så att de alla får plats på bilderna (så undviker du förlust av innehåll), använd denna inställning.

- `Maximize`

  Om du vill skala till en större bildstorlek och behöver att Aspose.Slides förstorar bildobjekten så att de blir proportionella mot den nya bildstorleken, använd denna inställning.

Den här exempelkoden visar hur du använder `Maximize`‑inställningen när du ändrar storleken på en presentations bild:

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

**Kan jag ange en anpassad bildstorlek med andra enheter än tum (t.ex. punkter eller millimeter)?**

Ja. Aspose.Slides använder punkter internt, där 1 punkt motsvarar 1/72 tum. Du kan konvertera vilken enhet som helst (t.ex. millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

**Kommer en mycket stor anpassad bildstorlek att påverka prestanda och minnesanvändning under rendering?**

Ja. Större bilddimensioner (i punkter) i kombination med högre renderingsskala leder till ökat minnesförbrukning och längre behandlingstider. Sikta på en praktisk bildstorlek och justera renderingsskalan endast vid behov för att uppnå önskad utskriftskvalitet.

**Kan jag definiera en icke‑standard bildstorlek och sedan slå ihop bilder från presentationer som har olika storlekar?**

Du kan inte [slå ihop presentationer](/slides/sv/php-java/merge-presentation/) när de har olika bildstorlekar – först ändra storleken på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesizescaletype/). Efter att storlekarna har anpassats kan du slå ihop bilder samtidigt som formateringen bevaras.

**Kan jag skapa miniatyrer för enskilda former eller specifika områden på en bild, och kommer de att respektera den nya bildstorleken?**

Ja. Aspose.Slides kan rendera miniatyrer för [hela bilder](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage) samt för [valda former](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getImage). De resulterande bilderna speglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer konsekvent inramning och geometri.