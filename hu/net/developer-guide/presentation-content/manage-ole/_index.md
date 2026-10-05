---
title: OLE objektumok kezelése prezentációkban .NET-ben
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/net/manage-ole/
keywords:
- OLE objektum
- Objektumösszekapcsolás és beágyazás
- OLE hozzáadása
- OLE beágyazása
- objektum hozzáadása
- objektum beágyazása
- fájl hozzáadása
- fájl beágyazása
- kapcsolt objektum
- kapcsolt fájl
- OLE módosítása
- OLE ikon
- OLE cím
- OLE kinyerése
- objektum kinyerése
- fájl kinyerése
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Optimalizálja az OLE objektumok kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for .NET segítségével. Ágyazza be, frissítse és exportálja az OLE tartalmat zökkenőmentesen."
---
## **Bevezetés**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásba helyezzük el hivatkozás vagy beágyazás segítségével. 

A diagramot ezután egy PowerPoint diára helyezik. Ez az Excel diagram OLE objektumnak számít. 

- Egy OLE objektum ikonként jelenhet meg. Ebben az esetben, ha duplán kattint az ikonra, a diagram a hozzá tartozó alkalmazásban (Excel) nyílik meg, vagy felkérik, hogy válasszon egy alkalmazást az objektum megnyitásához vagy szerkesztéséhez. 
- Egy OLE objektum megjelenítheti tényleges tartalmát, például egy diagram tartalmát. Ebben az esetben a diagram aktiválódik a PowerPointban, a diagram felület betöltődik, és a PowerPointon belül módosíthatja a diagram adatait. 

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) lehetővé teszi OLE objektumok beszúrását a diákra OLE objektumkeretekként ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).
{{% /alert %}} 

## **OLE Objektumkeretek Hozzáadása a Diákhoz**

Tételezzük fel, hogy már létrehozott egy diagramot a Microsoft Excelben, és Aspose.Slides for .NET segítségével OLE objektumkeretként szeretné beágyazni egy diára, ezt a módon teheti meg:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Olvassa be az Excel fájlt bájt tömbként.  
4. Adja hozzá a [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) elemet a diához, amely tartalmazza a bájt tömböt és egyéb információkat az OLE objektumról.  
5. Írja ki a módosított prezentációt PPTX fájlként.  

Az alábbi példában egy Excel fájlból származó diagramot adtunk hozzá egy diához [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) formájában az Aspose.Slides for .NET használatával.  
**Megjegyzés** hogy a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) konstruktor második paraméterként egy beágyazható objektum kiterjesztést vár. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy helyesen értelmezze a fájltípust és a megfelelő alkalmazást válassza az OLE objektum megnyitásához.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Készítse elő az OLE objektum adatait.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Adjon hozzá egy OLE objektumkeretet a diához.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Kapcsolt OLE Objektumkeretek Hozzáadása**

Aspose.Slides for .NET lehetővé teszi egy [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) hozzáadását anélkül, hogy adatot ágyazna be, csak a fájlra mutató hivatkozással.

Ez a C# kód megmutatja, hogyan adhatunk hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) elemet egy kapcsolt Excel fájllal egy diához:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy OLE objektumkeretet egy kapcsolt Excel fájllal.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE Objektumkeretek Elérése**

Ha egy OLE objektum már be van ágyazva egy diára, ezt a módot könnyen megtalálhatja vagy elérheti:

1. Töltsön be egy prezentációt a beágyazott OLE objektummal úgy, hogy létrehoz egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexének használatával.  
3. Érje el a [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) alakzatot. A példánkban a korábban létrehozott PPTX-et használtuk, amelynek az első dián csak egy alakzata van. Ezután *cast*‑oltuk azt az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) típusúvá. Ez volt a kívánt OLE objektumkeret, amelyet el kell érni.  
4. Miután elérte az OLE objektumkeretet, bármilyen műveletet végrehajthat rajta.  

Az alábbi példában egy OLE objektumkeret (egy beágyazott Excel diagram objektum) és annak fájladatait érjük el.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Szerezze meg az első alakzatot OLE objektumkeretként.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Szerezze meg a beágyazott fájl adatokat.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Szerezze meg a beágyazott fájl kiterjesztését.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Kapcsolt OLE Objektumkeret Tulajdonságainak Elérése**

Aspose.Slides lehetővé teszi a kapcsolt OLE objektumkeret tulajdonságainak elérését.

Ez a C# kód megmutatja, hogyan ellenőrizheti, hogy egy OLE objektum kapcsolt-e, és hogyan szerezheti meg a kapcsolt fájl útvonalát:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Szerezze meg az első alakzatot OLE objektumkeretként.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Ellenőrizze, hogy az OLE objektum kapcsolt-e.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Írja ki a kapcsolt fájl teljes útvonalát.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Írja ki a kapcsolt fájl relatív útvonalát, ha van.
        // Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE Objektum Adatainak Módosítása**

{{% alert color="info" title="Note" %}}
Ebbe a szakaszba a lenti kódpélda a [Aspose.Cells for .NET](https://docs.aspose.com/cells/net/) használatát mutatja.
{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy diára, ezt a módot könnyen elérheti és módosíthatja az adatait:

1. Töltsön be egy prezentációt a beágyazott OLE objektummal úgy, hogy létrehoz egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Érje el a [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) alakzatot. A példánkban a korábban létrehozott PPTX-et használtuk, amelynek az első dián egy alakzata van. Ezután *cast*‑oltuk azt az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) típusúvá. Ez volt a kívánt OLE objektumkeret, amelyet el kell érni.  
4. Miután elérte az OLE objektumkeretet, bármilyen műveletet végrehajthat rajta.  
5. Hozzon létre egy `Workbook` objektumot, és érje el az OLE adatokat.  
6. Érje el a kívánt `Worksheet`‑ot, és módosítsa az adatokat.  
7. Mentse az frissített `Workbook`‑ot egy streambe.  
8. Módosítsa az OLE objektum adatait a streamből.  

Az alábbi példában egy OLE objektumkeret (egy beágyazott Excel diagram) elérhető, és a fájl adatait módosítják a diagram adatainak frissítéséhez.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Szerezze meg az első alakzatot OLE objektumkeretként.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Olvassa be az OLE objektum adatokat Workbook objektumként.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Módosítsa a workbook adatait.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Módosítsa az OLE keret objektum adatait.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Más Fájl Típusok Beágyazása a Diákba**

Az Excel diagramok mellett az Aspose.Slides for .NET lehetővé teszi más típusú fájlok beágyazását a diákba. Például HTML, PDF és ZIP fájlokat helyezhet be objektumként. Amikor a felhasználó duplán kattint a beillesztett objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót felkérik, hogy válasszon egy megfelelő programot a megnyitáshoz.

Ez a C# kód megmutatja, hogyan ágyazzunk be HTML-t és ZIP-et egy diára:

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

## **Beágyazott Objektumok Fájltípusának Beállítása**

Prezentációk kezelése közben előfordulhat, hogy régi OLE objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE objektumot támogatottal. Az Aspose.Slides for .NET lehetővé teszi a beágyazott objektum fájltípusának beállítását, így frissítheti az OLE keret adatait vagy annak kiterjesztését.

Ez a C# kód megmutatja, hogyan állítsa be egy beágyazott OLE objektum fájltípusát `zip`‑re:

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

    // A fájl típusának módosítása ZIP-re.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ikon Képek és Címek Beállítása a Beágyazott Objektumokhoz**

OLE objektum beágyazása után automatikusan hozzáadódik egy előnézet, amely egy ikon képből áll. Ez az előnézet az, amit a felhasználók látnak, mielőtt elérnék vagy megnyitnák az OLE objektumot. Ha egy konkrét képet és szöveget szeretne használni az előnézet elemeiként, beállíthatja az ikon képet és a címet az Aspose.Slides for .NET használatával.

Ez a C# kód megmutatja, hogyan állítsa be az ikon képet és a címet egy beágyazott objektumhoz: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Kép hozzáadása a prezentáció erőforrásaihoz.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Cím és kép beállítása az OLE előnézethez.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Az OLE Objektumkeret Méretezésének és Áthelyezésének Megakadályozása**

Miután egy kapcsolt OLE objektumot hozzáad egy prezentációs diához, a PowerPointban történő megnyitáskor megjelenhet egy üzenet, amely a hivatkozások frissítését kéri. Az "Update Links" gombra kattintás megváltoztathatja az OLE objektumkeret méretét és pozícióját, mivel a PowerPoint frissíti a kapcsolt OLE objektum adatait, és frissíti az objektum előnézetét. A PowerPoint felkéréseinek elkerülése érdekében, állítsa a `UpdateAutomatic` tulajdonságot a [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) interfészben `false` értékre:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Tartsa meg az OLE objektumkeret méretét és helyzetét, amikor a PowerPoint frissíti a hivatkozást.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Beágyazott Fájlok Kinyerése**

Az Aspose.Slides for .NET lehetővé teszi a diákba beágyazott fájlok OLE objektumként történő kinyerését a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) osztályból, amely tartalmazza a kinyerni kívánt OLE objektumokat.  
2. Iteráljon végig a prezentáció összes alakzatán, és érje el a [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) alakzatokat.  
3. Érje el a beágyazott fájlok adatait az OLE objektumkeretekből, és írja őket lemezre.  

Ez a C# kód megmutatja, hogyan nyerhet ki fájlokat, amelyek OLE objektumként vannak beágyazva egy diában:

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

**Megjelenik-e az OLE tartalom a diák PDF/képek exportálásakor?**

A dián látható tartalom kerül renderelésre – az ikon/helyettesítő kép (előnézet). Az „élő” OLE tartalom nem kerül végrehajtásra a renderelés során. Szükség esetén állítson be saját előnézeti képet, hogy a várt megjelenést biztosítsa az exportált PDF‑ben.

Az beágyazott fájl PDF mellékletként való megtartásához állítsa a [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) értékét `true`‑ra. Ez az opció alapértelmezés szerint le van tiltva. Egy példáért és az ellenőrzés módjáért lásd a [Preserve Embedded OLE Files as PDF Attachments](/slides/hu/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) oldalt.

**Hogyan zárolhatok egy OLE objektumot a dián, hogy a felhasználók ne tudják mozgatni/szerkeszteni a PowerPointban?**

Zárja le az alakzatot: az Aspose.Slides [alakzat-szintű zárolásokat](/slides/hu/net/applying-protection-to-presentation/) kínál. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és mozgatást.

**Miért „ugrik” vagy változik mérete egy kapcsolt Excel objektumnak, amikor megnyitom a prezentációt?**

A PowerPoint frissítheti a kapcsolt OLE előnézetét. A stabil megjelenés érdekében kövesse a [Working Solution for Worksheet Resizing](/slides/hu/net/working-solution-for-worksheet-resizing/) gyakorlatait – vagy illessze a keretet a tartományhoz, vagy méretezze a tartományt egy fix keretre, és állítson be megfelelő helyettesítő képet.

**Megmaradnak-e a relatív útvonalak a kapcsolt OLE objektumokhoz a PPTX formátumban?**

PPTX‑ben a „relatív útvonal” információ nem érhető el – csak a teljes útvonal. A relatív útvonalak a régebbi PPT formátumban találhatók. A hordozhatóság érdekében részesítsen előnyben megbízható abszolút útvonalakat/elérhető URI‑kat vagy a beágyazást.