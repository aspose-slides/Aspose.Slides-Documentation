---
title: Hantera OLE‑objekt i presentationer i .NET
linktitle: Hantera OLE
type: docs
weight: 40
url: /sv/net/manage-ole/
keywords:
- OLE‑objekt
- Objektlänkning & Inbäddning
- lägg till OLE
- bädda in OLE
- lägg till objekt
- bädda in objekt
- lägg till fil
- bädda in fil
- länkat objekt
- länkat fil
- ändra OLE
- OLE‑ikon
- OLE‑titel
- extrahera OLE
- extrahera objekt
- extrahera fil
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Optimera hanteringen av OLE‑objekt i PowerPoint‑ och OpenDocument‑filer med Aspose.Slides för .NET. Bädda in, uppdatera och exportera OLE‑innehåll sömlöst."
---
## **Introduktion**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) är en Microsoft‑teknik som gör att data och objekt som skapats i en applikation kan placeras i en annan applikation genom länkning eller inbäddning. 

{{% /alert %}} 

Föreställ dig ett diagram som skapats i MS Excel. Diagrammet placeras sedan i en PowerPoint‑bild. Det Excel‑diagrammet betraktas som ett OLE‑objekt. 

- Ett OLE‑objekt kan visas som en ikon. I så fall, när du dubbelklickar på ikonen, öppnas diagrammet i dess tillhörande program (Excel), eller du blir ombedd att välja ett program för att öppna eller redigera objektet. 
- Ett OLE‑objekt kan visa sitt faktiska innehåll, till exempel innehållet i ett diagram. I så fall aktiveras diagrammet i PowerPoint, diagramgränssnittet laddas och du kan ändra diagrammets data i PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/sv/net/) låter dig infoga OLE‑objekt i bilder som OLE‑objektramar ([OleObjectFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/oleobjectframe)).

## **Lägg till OLE‑objektramar till bilder**

Antag att du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objektram med Aspose.Slides for .NET, så kan du göra så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Hämta en bilds referens via dess index.
3. Läs Excel‑filen som en byte‑array.
4. Lägg till [OleObjectFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/oleobjectframe) på bilden med byte‑arrayen och annan information om OLE‑objektet.
5. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplen nedan lade vi till ett diagram från en Excel‑fil i en bild som ett [OleObjectFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/oleobjectframe) med Aspose.Slides for .NET.  
**Obs!** att konstruktören för [OleEmbeddedDataInfo](https://reference.aspose.com/slides/sv/net/aspose.slides.dom.ole/oleembeddeddatainfo/) tar en inbäddningsbar objekt‑extension som andra parameter. Denna extension gör att PowerPoint korrekt tolkar filtypen och väljer rätt program för att öppna OLE‑objektet.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Förbered data för OLE-objektet.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Lägg till OLE-objektramen på bilden.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Lägg till länkade OLE‑objektramar**

Aspose.Slides for .NET låter dig lägga till ett [OleObjectFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/oleobjectframe) utan att bädda in data, utan bara med en länk till filen.

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Lägg till en OLE-objektram med en länkad Excel-fil.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Åtkomst till OLE‑objektramar**

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt hitta eller komma åt det på följande sätt:

1. Ladda en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Hämta bildens referens med hjälp av dess index.
3. Kom åt formen [OleObjectFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/oleobjectframe). I vårt exempel använde vi den tidigare skapade PPTX‑filen som har endast en form på den första bilden. Vi *castar* sedan det objektet till ett [IOleObjectFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ioleobjectframe). Detta var den önskade OLE‑objektramen som skulle nås.
4. När OLE‑objektramen har nåtts kan du utföra valfri operation på den.

I exemplen nedan nås en OLE‑objektram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Hämta den första formen som en OLE-objektram.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Hämta den inbäddade filens data.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Hämta filändelsen för den inbäddade filen.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Åtkomst till egenskaper för länkade OLE‑objektramar**

Aspose.Slides låter dig komma åt egenskaper för länkade OLE‑objektramar.

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Hämta den första formen som en OLE-objektram.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Kontrollera om OLE-objektet är länkat.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Skriv ut den fullständiga sökvägen till den länkade filen.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Skriv ut den relativa sökvägen till den länkade filen om den finns.
        // Endast PPT-presentationer kan innehålla den relativa sökvägen.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Ändra OLE‑objektdata**

{{% alert color="info" %}} 

I den här sektionen använder kodexemplet nedan [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt nå det och ändra dess data på följande sätt:

1. Ladda en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Hämta bildens referens via dess index. 
3. Kom åt formen [OLEObjectFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/oleobjectframe). I vårt exempel använde vi den tidigare skapade PPTX‑filen som har en form på den första bilden. Vi *castar* sedan objektet till ett [IOleObjectFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ioleobjectframe). Detta var den önskade OLE‑objektramen som skulle nås.
4. När OLE‑objektramen har nåtts kan du utföra valfri operation på den.
5. Skapa ett `Workbook`‑objekt och hämta OLE‑data.
6. Hämta önskat `Worksheet` och ändra data.
7. Spara den uppdaterade `Workbook` i en ström.
8. Ändra OLE‑objektdatan från strömmen.

I exemplen nedan nås en OLE‑objektram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata modifieras för att uppdatera diagrammets data.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Hämta den första formen som en OLE-objektram.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Läs OLE-objektets data som ett Workbook-objekt.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Modifiera arbetsbokens data.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Ändra OLE-ramens objektdatat.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Bädda in andra filtyper i bilder**

Förutom Excel‑diagram låter Aspose.Slides for .NET dig bädda in andra filtyper i bilder. Till exempel kan du infoga HTML‑, PDF‑ och ZIP‑filer som objekt. När en användare dubbelklickar på det infogade objektet öppnas det automatiskt i det relevanta programmet, eller så får användaren en uppmaning att välja ett lämpligt program för att öppna det.

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ange filtyper för inbäddade objekt**

När du arbetar med presentationer kan du behöva ersätta gamla OLE‑objekt med nya eller ersätta ett ej‑stött OLE‑objekt med ett stödt. Aspose.Slides for .NET låter dig ange filtypen för ett inbäddat objekt, vilket gör att du kan uppdatera OLE‑ramens data eller dess extension.

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Ändra filtypen till ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ange ikonbilder och titlar för inbäddade objekt**

Efter att ha bäddat in ett OLE‑objekt läggs automatiskt en förhandsgranskning bestående av en ikonbild till. Denna förhandsgranskning är vad användare ser innan de öppnar eller får åtkomst till OLE‑objektet. Om du vill använda en specifik bild och text som element i förhandsgranskningen kan du ange ikonbilden och titeln med Aspose.Slides for .NET.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Lägg till en bild i presentationens resurser.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Ange en titel och bilden för OLE‑förhandsgranskningen.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Förhindra att en OLE‑objektram ändras i storlek och position**

Efter att du har lagt till ett länkat OLE‑objekt i en presentationsbild, kan du när du öppnar presentationen i PowerPoint få ett meddelande som ber dig uppdatera länkarna. Att klicka på knappen "Uppdatera länkar" kan ändra storlek och position på OLE‑objektramen eftersom PowerPoint uppdaterar data från det länkade OLE‑objektet och uppdaterar förhandsgranskningen. För att förhindra att PowerPoint uppmanar att uppdatera objektets data, sätt egenskapen `UpdateAutomatic` på [IOleObjectFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ioleobjectframe/)‑gränssnittet till `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Behåll OLE-objektramens storlek och position när PowerPoint uppdaterar länken.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Extrahera inbäddade filer**

Aspose.Slides for .NET låter dig extrahera filer som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) som innehåller de OLE‑objekt du vill extrahera.
2. Loopa igenom alla former i presentationen och kom åt formerna [OLEObjectFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/oleobjectframe).
3. Hämta data från inbäddade filer i OLE‑objektramarna och skriv den till disk.

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **FAQ**

### Renderas OLE‑innehållet när bilder exporteras till PDF/bilder?

Det som syns på bilden renderas – ikonen/substitut‑bilden (förhandsgranskningen). Det ”levande” OLE‑innehållet körs inte under rendering. Vid behov, ange en egen förhandsgranskningsbild för att säkerställa önskat utseende i den exporterade PDF‑filen.

### Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?

Lås formen: Aspose.Slides tillhandahåller [form‑nivå lås](/slides/sv/net/applying-protection-to-presentation/). Detta är ingen kryptering, men det förhindrar i praktiken oavsiktliga redigeringar och flyttningar.

### Varför “hoppar” ett länkat Excel‑objekt eller ändrar storlek när jag öppnar presentationen?

PowerPoint kan uppdatera förhandsgranskningen av det länkade OLE‑objektet. För ett stabilt utseende, följ [Working Solution for Worksheet Resizing](/slides/sv/net/working-solution-for-worksheet-resizing/)-praktiken – antingen anpassa ramen till intervallet, eller skala intervallet till en fast ram och ange en lämplig ersättningsbild.

### Kommer relativa sökvägar för länkade OLE‑objekt att bevaras i PPTX‑formatet?

I PPTX är information om “relativ sökväg” inte tillgänglig – endast den fullständiga sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet, föredra pålitliga absoluta sökvägar/tillgängliga URI:er eller inbäddning.