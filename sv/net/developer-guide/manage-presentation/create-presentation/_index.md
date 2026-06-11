---
title: Skapa presentationer i .NET
linktitle: Skapa presentation
type: docs
weight: 10
url: /sv/net/create-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Skapa presentationer i .NET med Aspose.Slides—generera PPT-, PPTX- och ODP-filer, dra nytta av OpenDocument-stöd och spara dem programmatiskt för pålitliga resultat."
---
## **Översikt**

Denna artikel visar hur du skapar en presentation i Aspose.Slides, lägger till enkelt innehåll på en bild och sparar resultatet som en fil. Den demonstrerar också hur du skapar och sparar en ny presentation, öppnar en befintlig presentation i ett stödformat och sparar den till ett annat format. Dessutom innehåller artikeln en kort FAQ med vanliga frågor om format, mallar, bildstorlek, enheter, minnesanvändning, trådar, licensiering, digitala signaturer och VBA‑stöd.

## **Skapa en PowerPoint-presentation**
För att lägga till en enkel rak linje på en vald bild i presentationen, följ stegen nedan:

1. Skapa en instans av Presentation-klassen.  
1. Hämta referensen till en bild genom att använda dess Index.  
1. Lägg till en AutoShape av typ Line med metoden AddAutoShape som exponeras av Shapes‑objektet.  
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en linje på den första bilden i presentationen.

```c#
 // Instansiera ett Presentation-objekt som representerar en presentationsfil
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoshape av typ linje
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## **Skapa och spara en presentation**

<a name="csharp-create-save-presentation"><strong>Steg: Skapa och spara presentation i C#</strong></a>

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑klassen.  
2. Spara _Presentation_ till valfritt format som stöds av [SaveFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/)

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Öppna och spara en presentation**

<a name="csharp-open-save-presentation"><strong>Steg: Öppna och spara presentation i C#</strong></a>

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑klassen med valfritt format, t.ex. PPT, PPTX, ODP osv.  
2. Spara _Presentation_ till valfritt format som stöds av [SaveFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/)

```c#
// Ladda någon stödfil i Presentation, t.ex. ppt, pptx, odp osv.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Vanliga frågor**

**Vilka format kan jag spara en ny presentation till?**

Du kan spara till [PPTX, PPT, and ODP](/slides/sv/net/save-presentation/), och exportera till [PDF](/slides/sv/net/convert-powerpoint-to-pdf/), [XPS](/slides/sv/net/convert-powerpoint-to-xps/), [HTML](/slides/sv/net/convert-powerpoint-to-html/), [SVG](/slides/sv/net/convert-powerpoint-to-png/), och [bilder](/slides/sv/net/convert-powerpoint-to-png/), bland annat.

**Kan jag börja från en mall (POTX/POTM) och spara som en vanlig PPTX?**

Ja. Läs in mallen och spara till önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/net/supported-file-formats/).

**Hur styr jag bildstorlek/formatförhållande när jag skapar en presentation?**

Ställ in [bildstorlek](/slides/sv/net/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller egna dimensioner) och välj hur innehållet ska skalas.

**I vilka enheter mäts storlekar och koordinater?**

I punkter: 1 tum motsvarar 72 enheter.

**Hur hanterar jag mycket stora presentationer (med många mediefiler) för att minska minnesanvändningen?**

Använd [BLOB management strategies](/slides/sv/net/manage-blob/), begränsa minneslagring genom att utnyttja temporära filer och föredra filbaserade arbetsflöden framför rena minnesströmmar.

**Kan jag skapa/spara presentationer parallellt?**

Du kan inte arbeta på samma [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/net/multithreading/). Kör separata, isolerade instanser per tråd eller process.

**Hur tar jag bort provversionens vattenstämpel och begränsningar?**

[Applicera en licens](/slides/sv/net/licensing/) en gång per process. Licens‑XML‑filen får inte ändras, och licensinställningen bör synkroniseras om flera trådar är inblandade.

**Kan jag digitalt signera PPTX‑filen jag skapar?**

Ja. [Digital signatures](/slides/sv/net/digital-signature-in-powerpoint/) (lägg till och verifiera) stöds för presentationer.

**Stöds makron (VBA) i skapade presentationer?**

Ja. Du kan [create/edit VBA projects](/slides/sv/net/presentation-via-vba/) och spara makro‑aktiverade filer såsom PPTM/PPSM.