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
description: "Skapa presentationer i .NET med Aspose.Slides—generera PPT-, PPTX- och ODP-filer, dra nytta av OpenDocument-stöd och spara dem programatiskt för pålitliga resultat."
---
## **Översikt**

Den här artikeln visar hur du skapar en presentation i Aspose.Slides, lägger till en textruta på dess första bild och sparar resultatet som en fil. Den visar också hur du skapar och sparar en tom presentation samt hur du öppnar en befintlig presentation i ett stödt format och sparar den i ett annat format. En kort FAQ i slutet täcker vanliga frågor om format, mallar, bildstorlek, enheter, minnesanvändning, trådar, licensiering, digitala signaturer och VBA-stöd.

Innan du börjar, lägg till Aspose.Slides i ditt projekt från NuGet. Se [Installation](/slides/sv/net/installation/) för paketet att använda på Windows, Linux och macOS.

## **Skapa en PowerPoint-presentation**

För att skapa en presentation och placera en textruta på dess första bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/). En ny presentation innehåller redan en tom bild.
2. Hämta den bilden från samlingen [Slides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/slides/sv/) med dess index, 0.
3. Lägg till en rektangel med metoden [AddAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addautoshape/) och ange dess [text](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/text/).
4. Spara presentationen som en PPTX-fil med metoden [Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Rektangelns övre vänstra hörn är 50 punkter från vänsterkanten och 50 punkter från övre kanten på bilden, och rektangeln är 400 punkter bred och 100 punkter hög. Den sparade filen innehåller en bild med den rektangeln och dess text. Utan licens lägger Aspose.Slides även till ett utvärderingsvattenstämpel på varje bild den sparar; se [Licensing](/slides/sv/net/licensing/).

## **Skapa och spara en presentation**

<a name="csharp-create-save-presentation"></a>

För att skapa en tom presentation och spara den, skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) och spara den i vilket format som helst från uppräkningen [SaveFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/). Resultatet är en presentation med en tom bild.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Öppna och spara en presentation**

<a name="csharp-open-save-presentation"></a>

För att konvertera en presentation från ett format till ett annat, öppna den genom att skicka dess sökväg till konstruktorn [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/presentation/), spara den sedan i målformatet. Aspose.Slides upptäcker inmatningsformatet, t.ex. PPT, PPTX eller ODP, från själva filen.

Exemplet nedan förväntar sig en OpenDocument-presentation med namnet *Sample.odp* i arbetskatalogen och sparar den som PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### Vilka format kan jag spara en ny presentation till?

Du kan spara till [PPTX, PPT och ODP](/slides/sv/net/save-presentation/), och exportera till [PDF](/slides/sv/net/convert-powerpoint-to-pdf/), [XPS](/slides/sv/net/convert-powerpoint-to-xps/), [HTML](/slides/sv/net/convert-powerpoint-to-html/), [SVG](/slides/sv/net/render-a-slide-as-an-svg-image/) och [bilder](/slides/sv/net/convert-powerpoint-to-png/), bland annat.

### Kan jag börja från en mall (POTX/POTM) och spara som en vanlig PPTX?

Ja. Läs in mallen och spara i önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/net/supported-file-formats/).

### Hur kontrollerar jag bildstorlek/bildförhållande när jag skapar en presentation?

Ställ in [bildstorleken](/slides/sv/net/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller egna mått) och välj hur innehållet ska skalas.

### I vilka enheter mäts storlekar och koordinater?

I punkter: 1 tum motsvarar 72 enheter.

### Hur hanterar jag mycket stora presentationer (med många mediafiler) för att minska minnesanvändning?

Använd [BLOB-hanteringsstrategier](/slides/sv/net/manage-blob/), begränsa lagring i minnet genom att utnyttja temporära filer och föredra filbaserade arbetsflöden framför rena minnesströmmar.

### Kan jag skapa/spara presentationer parallellt?

Du kan inte arbeta på samma [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/net/multithreading/). Kör separata, isolerade instanser per tråd eller process.

### Hur tar jag bort provvattenstämpeln och begränsningarna?

[Applicera en licens](/slides/sv/net/licensing/) en gång per process. Licens‑XML‑filen får inte modifieras, och licensinställningen bör synkroniseras om flera trådar är inblandade.

### Kan jag digitalt signera PPTX‑filen jag skapar?

Ja. [Digitala signaturer](/slides/sv/net/digital-signature-in-powerpoint/) (tillägg och verifiering) stöds för presentationer.

### Stöds makron (VBA) i skapade presentationer?

Ja. Du kan [skapa/redigera VBA‑projekt](/slides/sv/net/presentation-via-vba/) och spara makro‑aktiverade filer såsom PPTM/PPSM.