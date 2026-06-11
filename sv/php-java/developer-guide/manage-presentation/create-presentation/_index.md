---
title: Skapa presentationer i PHP
linktitle: Skapa presentation
type: docs
weight: 10
url: /sv/php-java/create-presentation/
keywords:
- skapa presentation
- ny presentation
- skapa PPT
- ny PPT
- skapa PPTX
- ny PPTX
- skapa ODP
- ny ODP
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Skapa presentationer med Aspose.Slides för PHP via Java — skapa PPT-, PPTX- och ODP-filer och spara dem programmatiskt för pålitliga resultat."
---
## **Översikt**

Den här artikeln visar hur du skapar en presentation i Aspose.Slides, lägger till enkelt innehåll på en bild och sparar resultatet som en fil. Den demonstrerar också hur du skapar och sparar en ny presentation, öppnar en befintlig presentation i ett stödd format och sparar den till ett annat format. Dessutom innehåller artikeln en kort FAQ med vanliga frågor om format, mallar, bildstorlekar, enheter, minnesanvändning, trådar, licensiering, digitala signaturer och VBA‑stöd.

## **Skapa en presentation**

För att lägga till en enkel rak linje på en vald bild i presentationen, följ stegen nedan:

1. Skapa en instans av Presentation‑klassen.  
1. Hämta referensen till en bild genom att använda dess Index.  
1. Lägg till en AutoShape av typ Linje med hjälp av addAutoShape‑metoden som tillhandahålls av Shapes‑objektet.  
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en linje på den första bilden i presentationen.

```php
  # Instansiera ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation();
  try {
    # Hämta den första bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Lägg till en autoshape av typen linje
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Vilka format kan jag spara en ny presentation i?**

Du kan spara till [PPTX, PPT och ODP](/slides/sv/php-java/save-presentation/), och exportera till [PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/sv/php-java/convert-powerpoint-to-xps/), [HTML](/slides/sv/php-java/convert-powerpoint-to-html/), [SVG](/slides/sv/php-java/convert-powerpoint-to-png/) och [bilder](/slides/sv/php-java/convert-powerpoint-to-png/), bland annat.

**Kan jag börja från en mall (POTX/POTM) och spara som en vanlig PPTX?**

Ja. Läs in mallen och spara till önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/php-java/supported-file-formats/).

**Hur styr jag bildstorlek/bildförhållande när jag skapar en presentation?**

Ställ in [bildstorlek](/slides/sv/php-java/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller egna dimensioner) och välj hur innehållet ska skalas.

**I vilka enheter mäts storlekar och koordinater?**

I punkter: 1 tum motsvarar 72 enheter.

**Hur hanterar jag mycket stora presentationer (med många mediafiler) för att minska minnesanvändningen?**

Använd [BLOB‑hanteringsstrategier](/slides/sv/php-java/manage-blob/), begränsa minneslagring genom att utnyttja temporära filer och föredra filbaserade arbetsflöden framför enbart minnesströmmar.

**Kan jag skapa/spara presentationer parallellt?**

Du kan inte arbeta på samma [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/php-java/multithreading/). Kör separata, isolerade instanser per tråd eller process.

**Hur tar jag bort provversionens vattenstämpel och begränsningar?**

[Applicera en licens](/slides/sv/php-java/licensing/) en gång per process. Licens‑XML‑filen får inte ändras, och licensinställningen bör synkroniseras om flera trådar är inblandade.

**Kan jag digitalt signera den PPTX jag skapar?**

Ja. [Digitala signaturer](/slides/sv/php-java/digital-signature-in-powerpoint/) (tillläggning och verifiering) stöds för presentationer.

**Stöds makron (VBA) i skapade presentationer?**

Ja. Du kan [skapa/redigera VBA‑projekt](/slides/sv/php-java/presentation-via-vba/) och spara makro‑aktiverade filer såsom PPTM/PPSM.