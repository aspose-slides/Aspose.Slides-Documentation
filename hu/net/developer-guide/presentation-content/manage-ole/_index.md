---
title: OLE objektumok kezelése prezentációkban .NET-ben
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/net/manage-ole/
keywords:
- OLE objektum
- Objektum hivatkozás és beágyazás
- OLE hozzáadása
- OLE beágyazása
- objektum hozzáadása
- objektum beágyazása
- fájl hozzáadása
- fájl beágyazása
- hivatkozott objektum
- hivatkozott fájl
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
description: "Optimalizálja az OLE objektumok kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for .NET segítségével. Beágyazza, frissíti és zökkenőmentesen exportálja az OLE tartalmat."
---
## **Bevezetés**

{{% alert title="Info" color="info" %}}
Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásba helyezzük be hivatkozással vagy beágyazással. 

Vegyük például az MS Excelben létrehozott diagramot. A diagramot ezután egy PowerPoint diára helyezzük. Ez az Excel-diagram OLE objektumnak számít. 

- Egy OLE objektum megjelenhet ikonként. Ebben az esetben, ha duplán kattintunk az ikonra, a diagram a kapcsolódó alkalmazásban (Excel) nyílik meg, vagy arra kérik a felhasználót, hogy válasszon alkalmazást az objektum megnyitásához vagy szerkesztéséhez. 
- Egy OLE objektum megjelenítheti a tényleges tartalmát, például egy diagram tartalmát. Ebben az esetben a diagram a PowerPointban aktiválódik, a diagram felület betöltődik, és a PowerPointon belül módosíthatja a diagram adatait. 

[Aspose.Slides for .NET](https://products.aspose.com/slides/hu/net/) lehetővé teszi OLE objektumok beszúrását a diáknak OLE objektumkeretként ([OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe)).{{% /alert %}} 

## **OLE objektumkeretek hozzáadása a diákhoz**

Feltételezve, hogy már létrehozott egy diagramot a Microsoft Excelben, és ezt OLE objektumkeretként szeretné beágyazni egy diára az Aspose.Slides for .NET használatával, ezt a módon teheti meg:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Szerezze meg a dia referenciaját az indexe alapján.  
3. Olvassa be az Excel-fájlt bájt-tömbként.  
4. Adja hozzá a [OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe) keretet a diához, amely tartalmazza a bájt-tömböt és egyéb információkat az OLE objektumról.  
5. Írja ki a módosított prezentációt PPTX fájlként.  

Az alábbi példában egy Excel-fájlból származó diagramot adtunk hozzá a diához [OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe) keretként az Aspose.Slides for .NET használatával. **Megjegyzés**: a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hu/net/aspose.slides.dom.ole/oleembeddeddatainfo/) konstruktor második paraméterként egy beágyazható objektum kiterjesztést vár. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy helyesen értelmezze a fájltípust és kiválassza a megfelelő alkalmazást az OLE objektum megnyitásához.  

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Előkészíti az OLE objektum adatait.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Hozzáadja az OLE objektumkeretet a diához.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Hivatkozott OLE objektumkeretek hozzáadása**

Az Aspose.Slides for .NET lehetővé teszi egy [OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe) hozzáadását adatbeágyazás nélkül, csak a fájlra mutató hivatkozással.  

Ez a C# kód megmutatja, hogyan adhat hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe) hivatkozott Excel-fájllal a diára:  

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Hozzáad egy OLE objektumkeretet egy hivatkozott Excel fájllal.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE objektumkeretek elérése**

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen megtalálhatja vagy elérheti a következő módon:

1. Töltsön be egy prezentációt a beágyazott OLE objektummal úgy, hogy létrehoz egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Szerezze meg a dia referenciaját az indexének használatával.  
3. Érje el a [OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe) alakzatot. A példánkban a korábban létrehozott PPTX-et használtuk, amelyen az első dián csak egy alakzat van. Ezután *cast*-oljuk azt az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleobjectframe) típusra. Ez volt a kívánt OLE objektumkeret, amelyet el akarunk érni.  
4. Miután az OLE objektumkeret elérhető, bármilyen műveletet végrehajthat rajta.  

Az alábbi példában egy OLE objektumkeret (egy beágyazott Excel-diagram objektum) és annak fájladatai kerülnek elérésre.  

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Az első alakzat lekérése OLE objektumkeretként.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // A beágyazott fájl adatainak lekérése.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // A beágyazott fájl kiterjesztésének lekérése.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Hivatkozott OLE objektumkeret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a hivatkozott OLE objektumkeret tulajdonságainak elérését.  

Ez a C# kód megmutatja, hogyan ellenőrizze, hogy egy OLE objektum hivatkozott-e, majd hogyan kapja meg a hivatkozott fájl elérési útját:  

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Az első alakzat lekérése OLE objektumkeretként.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Ellenőrzi, hogy az OLE objektum hivatkozott-e.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Kiírja a hivatkozott fájl teljes útvonalát.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Kiírja a hivatkozott fájl relatív útvonalát, ha létezik.
        // Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE objektum adatainak módosítása**

{{% alert color="info" %}}  
Ebben a szakaszban a lenti kódrészlet a [Aspose.Cells for .NET](/cells/net/) használatát mutatja be.  
{{% /alert %}}  

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen elérheti és módosíthatja az adatát a következő módon:

1. Töltsön be egy prezentációt a beágyazott OLE objektummal úgy, hogy létrehoz egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Szerezze meg a dia referenciaját az indexe alapján.  
3. Érje el a [OLEObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe) alakzatot. A példánkban a korábban létrehozott PPTX-et használtuk, amelyen az első dián egy alakzat van. Ezután *cast*-oljuk azt az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleobjectframe) típusra. Ez volt a kívánt OLE objektumkeret, amelyet el akarunk érni.  
4. Miután az OLE objektumkeret elérhető, bármilyen műveletet végrehajthat rajta.  
5. Hozzon létre egy `Workbook` objektumot, és érje el az OLE adatokat.  
6. Érje el a kívánt `Worksheet`‑t, és módosítsa az adatokat.  
7. Mentse a frissített `Workbook`‑ot egy stream‑be.  
8. Cserélje le az OLE objektum adatát a streamből.  

Az alábbi példában egy OLE objektumkeret (egy beágyazott Excel-diagram) kerül elérésre, és a fájladatai módosulnak a diagram adatainak frissítéséhez.  

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Az első alakzat lekérése OLE objektumkeretként.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Az OLE objektum adatainak beolvasása Workbook objektumként.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // A workbook adatainak módosítása.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Az OLE keret objektum adatainak módosítása.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Más fájltípusok beágyazása a diába**

Az Excel-diagramok mellett az Aspose.Slides for .NET lehetővé teszi más típusú fájlok beágyazását a diákba. Például HTML-, PDF- és ZIP-fájlokat helyezhet el objektumként. Amikor a felhasználó duplán kattint a beillesztett objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót felszólítják, hogy válasszon egy megfelelő programot a megnyitáshoz.  

Ez a C# kód megmutatja, hogyan ágyazzon be HTML-t és ZIP-et egy diára:  

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

## **Beágyazott objektumok fájltípusának beállítása**

Prezentációk kezelésekor előfordulhat, hogy régi OLE objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE objektumot egy támogatottal. Az Aspose.Slides for .NET lehetővé teszi a beágyazott objektum fájltípusának beállítását, így frissítheti az OLE keret adatát vagy kiterjesztését.  

Ez a C# kód megmutatja, hogyan állíthatja be egy beágyazott OLE objektum fájltípusát `zip`‑re:  

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

    // A fájltípus módosítása ZIP-re.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ikonképek és címek beállítása beágyazott objektumokhoz**

Egy OLE objektum beágyazása után automatikusan hozzáadódik egy előnézet, amely egy ikonképből áll. Ez az előnézet látható a felhasználók számára, mielőtt hozzáférnének vagy megnyitnák az OLE objektumot. Ha egyedi képet és szöveget szeretne használni az előnézet elemeiként, beállíthatja az ikonképet és a címet az Aspose.Slides for .NET segítségével.  

Ez a C# kód megmutatja, hogyan állíthatja be az ikonképet és a címet egy beágyazott objektumhoz:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Képet ad hozzá a prezentáció erőforrásaihoz.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Beállít egy címet és a képet az OLE előnézethez.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Az OLE objektumkeret átméretezésének és áthelyezésének megakadályozása**

Miután egy hivatkozott OLE objektumot hozzáadott egy prezentációs diához, a PowerPointban megnyitva egy üzenetet láthat, amely a linkek frissítését kéri. Az "Update Links" gombra kattintva a OLE objektumkeret mérete és pozíciója megváltozhat, mivel a PowerPoint frissíti a hivatkozott OLE objektum adatait és újratölti az objektum előnézetét. Annak megakadályozására, hogy a PowerPoint felkérje az objektum adatainak frissítését, állítsa a `UpdateAutomatic` tulajdonságot a [IOleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleobjectframe/) interfészben `false` értékre:  

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Tartsa meg az OLE objektumkeret méretét és pozícióját, amikor a PowerPoint frissíti a hivatkozást.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Beágyazott fájlok kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, amely tartalmazza a kinyerni kívánt OLE objektumokat.  
2. Iteráljon végig a prezentáció összes alakzataján, és érje el a [OLEObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe) alakzatokat.  
3. Érje el a beágyazott fájlok adatait az OLE objektumkeretekből, és írja őket lemezre.  

Ez a C# kód megmutatja, hogyan nyerhet ki egy diára beágyazott fájlokat OLE objektumként:  

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

### **Megjelenik-e az OLE tartalom a diák PDF/képek exportálásakor?**

A dián látható elem kerül renderelésre – az ikon/helyettesítő kép (előnézet). Az „élő” OLE tartalmat nem hajtja végre a renderelés során. Szükség esetén állítson be saját előnézeti képet, hogy a várt megjelenés a PDF‑ben is biztosított legyen.

### **Hogyan zárolhatok egy OLE objektumot a dián, hogy a felhasználók ne mozgathassák/szerkeszthessék a PowerPointban?**

Zárolja az alakzatot: az Aspose.Slides [alakzatszintű zárolásokat](/slides/hu/net/applying-protection-to-presentation/) biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és a mozgatást.

### **Miért „ugrik” vagy változik mérete a hivatkozott Excel objektumnak a prezentáció megnyitásakor?**

A PowerPoint frissítheti a hivatkozott OLE előnézetét. A stabil megjelenés érdekében kövesse a [Worksheet átméretezés megoldását](/slides/hu/net/working-solution-for-worksheet-resizing/) – vagy illessze a keretet a tartományhoz, vagy méretezze a tartományt egy rögzített keretre, és állítson be megfelelő helyettesítő képet.

### **Megmaradnak-e a hivatkozott OLE objektumok relatív útvonalai a PPTX formátumban?**

A PPTX formátumban a „relatív útvonal” információ nem érhető el – csak a teljes útvonal. A relatív útvonalak a régebbi PPT formátumban léteznek. A hordozhatóság érdekében inkább megbízható abszolút útvonalakat vagy elérhető URI‑kat, illetve beágyazást használjon.