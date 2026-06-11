---
title: Ändra bildstorlek i presentation med PHP
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
- säker passning
- maximera
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
descriptions: "Lär dig hur du snabbt ändrar storlek på bilder i PPT-, PPTX- och ODP-filer med PHP och Aspose.Slides, optimera presentationer för vilken skärm som helst utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides tillhandahåller omfattande verktyg för att justera bildstorlek och bildförhållande i PowerPoint‑presentationer, vilket är kritiskt både för utskrift och visning på skärm. 

Populära bildstorlekar och förhållanden:

- **Standard (4:3 Aspect Ratio)**: Ideal för äldre skärmar och enheter.
- **Widescreen (16:9 Aspect Ratio)**: Rekommenderas för moderna projektorer och skärmar.

Säkerställ konsekvens i hela din presentation genom att en enda bildstorlek och ett bildförhållande gäller för alla bilder. För bästa resultat, ange bildens dimensioner i början av presentationsskapandet för att undvika komplikationer.

{{% alert color="primary" %}} 
Som standard använder presentationer som skapats med Aspose.Slides det vanliga 4:3‑bildförhållandet.
{{% /alert %}}

## **Ändra bildstorlek i presentationer**

Den här exempel­koden visar hur du ändrar bildstorleken i en presentation med Aspose.Slides:

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

Om du finner de vanliga bildstorlekarna (4:3 och 16:9) olämpliga för ditt arbete kan du bestämma dig för att använda en specifik eller unik bildstorlek. Till exempel, om du planerar att skriva ut full‑storleksbilder från din presentation på en anpassad sidlayout eller om du avser att visa presentationen på vissa skärmtyper, kan du ha nytta av att använda en anpassad storleksinställning för din presentation. 

Den här exempel­koden visar hur du använder Aspose.Slides för PHP via Java för att ange en anpassad bildstorlek för en presentation:

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

Efter att du har ändrat bildstorleken för en presentation kan bildens innehåll (bilder eller objekt, till exempel) bli förvrängt. Som standard skalas objekten automatiskt om så att de passar den nya bildstorleken. När du ändrar en presentations bildstorlek kan du dock ange en inställning som bestämmer hur Aspose.Slides hanterar innehållet på bilderna.

Beroende på vad du avser att göra eller uppnå kan du använda någon av dessa inställningar:

- `DoNotScale`

  Om du INTE vill att objekten på bilderna ska skalas om, använd den här inställningen.

- `EnsureFit`

  Om du vill skala till en mindre bildstorlek och behöver att Aspose.Slides skalär ner bildens objekt så att de alla får plats på bilderna (så undviker du förlorat innehåll), använd den här inställningen. 

- `Maximize`

  Om du vill skala till en större bildstorlek och behöver att Aspose.Slides förstorar bildens objekt så att de blir proportionella mot den nya bildstorleken, använd den här inställningen. 

Den här exempel­koden visar hur du använder `Maximize`‑inställningen när du ändrar storleken på en presentations bild:

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

**Kan jag ange en anpassad bildstorlek med andra enheter än tum (till exempel punkter eller millimeter)?**

Ja. Aspose.Slides använder punkter internt, där 1 punkt är lika med 1/72 tum. Du kan konvertera vilken enhet som helst (till exempel millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

**Kommer en mycket stor anpassad bildstorlek att påverka prestanda och minnesanvändning under rendering?**

Ja. Större bilddimensioner (i punkter) kombinerat med högre renderingsskala leder till ökat minnesbruk och längre bearbetningstid. Sträva efter en praktisk bildstorlek och justera renderingsskalan endast vid behov för att uppnå önskad utdata‑kvalitet.

**Kan jag definiera en icke‑standard bildstorlek och sedan slå ihop bilder från presentationer som har olika storlekar?**

Du kan inte [slå ihop presentationer](/slides/sv/php-java/merge-presentation/) medan de har olika bildstorlekar – först, ändra storleken på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesizescaletype/). Efter att storlekarna har justerats kan du slå ihop bilder samtidigt som formateringen bevaras.

**Kan jag generera miniatyrer för enskilda former eller specifika områden på en bild, och kommer de att följa den nya bildstorleken?**

Ja. Aspose.Slides kan rendera miniatyrer för [hela bilder](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage) såväl som för [valda former](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getImage). De resulterande bilderna speglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer enhetlig inramning och geometri.