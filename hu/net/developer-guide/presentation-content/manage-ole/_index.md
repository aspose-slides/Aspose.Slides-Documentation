---
title: OLE objektumok kezelése prezentációkban .NET-ben
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/net/manage-ole/
keywords:
- OLE objektum
- Objektumláncolás és beágyazás
- OLE hozzáadása
- OLE beágyazása
- objektum hozzáadása
- objektum beágyazása
- fájl hozzáadása
- fájl beágyazása
- linkelt objektum
- linkelt fájl
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

{{% alert title="Információ" color="info" %}}
Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásba helyezzék el hivatkozással vagy beágyazással. 
{{% /alert %}} 

Hozzon példaként egy MS Excelben létrehozott diagramot. A diagramot ezután egy PowerPoint diára helyezik. Az Excel diagram OLE objektumnak minősül. 

- Egy OLE objektum megjelenhet ikonként. Ebben az esetben, ha duplán kattint az ikonra, a diagram a társított alkalmazásban (Excel) nyílik meg, vagy felkérik egy alkalmazás kiválasztására az objektum megnyitásához vagy szerkesztéséhez. 
- Egy OLE objektum megjelenítheti a tényleges tartalmát, például egy diagram tartalmát. Ebben az esetben a diagram aktiválódik a PowerPointban, betöltődik a diagram felülete, és módosíthatja a diagram adatait a PowerPointon belül.

[Aspose.Slides for .NET](https://products.aspose.com/slides/hu/net/) lehetővé teszi OLE objektumok beillesztését a diákba OLE objektumkeretekként ([OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe)).

## **OLE objektumkeretek hozzáadása a diákhoz**

Feltételezve, hogy már létrehozott egy diagramot a Microsoft Excelben, és azt OLE objektumkeretként szeretné beágyazni egy diára az Aspose.Slides for .NET segítségével, ezt a következőképpen teheti meg:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Szerezze meg egy dia referenciaját az indexe alapján.
3. Olvassa be az Excel-fájlt byte tömbként.
4. Adja hozzá a [OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe)-et a diához, amely tartalmazza a byte tömböt és egyéb információkat az OLE objektumról.
5. Írja ki a módosított prezentációt PPTX fájlként.

Az alábbi példában egy Excel-fájlból származó diagramot adtunk hozzá egy diára [OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe) formájában az Aspose.Slides for .NET használatával.  
**Megjegyzés**, hogy a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hu/net/aspose.slides.dom.ole/oleembeddeddatainfo/) konstruktor második paraméterként egy beágyazható objektum kiterjesztést vesz át. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy helyesen értelmezze a fájltípust, és a megfelelő alkalmazást válassza az OLE objektum megnyitásához.
```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Készítse elő az OLE objektum adatait.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Adja hozzá az OLE objektumkeretet a diához.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Linkelt OLE objektumkeretek hozzáadása**

Az Aspose.Slides for .NET lehetővé teszi egy [OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe) hozzáadását adat beágyazása nélkül, csak a fájlra mutató hivatkozással.

Ez a C# kód megmutatja, hogyan adhatunk egy [OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe)-et egy linkelt Excel-fájllal egy diára:
```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy OLE objektumkeretet egy linkelt Excel-fájlhoz.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE objektumkeretek elérése**

Ha egy OLE objektum már be van ágyazva egy diára, ezt a módot követve könnyen megtalálhatja vagy elérheti:

1. Töltsön be egy prezentációt, amely tartalmazza a beágyazott OLE objektumot, a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály példányosításával.
2. Szerezze meg a dia referenciaját az indexének használatával.
3. Hozzáférés a [OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe) alakzathoz.
   Példánkban a korábban létrehozott PPTX-et használtuk, amelynek az első dián csak egy alakzata van. Ezután *cast*-oltuk (átcastoltuk) az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleobjectframe)-ként. Ez volt a kívánt OLE objektumkeret, amelyhez hozzáfértünk.
4. Miután hozzáfértünk az OLE objektumkerethez, tetszőleges műveletet végezhet rajta.

Az alábbi példában egy OLE objektumkeret (egy diára beágyazott Excel-diagram objektum) és annak fájladatát érjük el.
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Az első alakzatot OLE objektumkeretként lekérjük.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // A beágyazott fájl adatait lekérjük.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // A beágyazott fájl kiterjesztését lekérjük.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Linkelt OLE objektumkeret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a linkelt OLE objektumkeret tulajdonságainak elérését.

Ez a C# kód megmutatja, hogyan ellenőrizheti, hogy egy OLE objektum linkelt-e, majd hogyan szerezheti meg a linkelt fájl elérési útját:
```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Az első alakzatot OLE objektumkeretként lekérjük.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Ellenőrizzük, hogy az OLE objektum linkelt-e.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Kiírjuk a linkelt fájl teljes útvonalát.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Kiírjuk a linkelt fájl relatív útvonalát, ha létezik.
        // Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE objektum adatainak módosítása**

{{% alert color="primary" %}} 
Ebbe a szakaszba az alábbi kódpélda a [Aspose.Cells for .NET](/cells/net/) használatát mutatja. 
{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy diára, könnyen hozzáférhet az objektumhoz és módosíthatja annak adatait a következő módon:

1. Töltsön be egy prezentációt, amely tartalmazza a beágyazott OLE objektumot, a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály példányosításával.
2. Szerezze meg a dia referenciaját az indexe alapján.
3. Hozzáférés az [OLEObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe) alakzathoz.
   Példánkban a korábban létrehozott PPTX-et használtuk, amelynek az első dián egy alakzata van. Ezután *cast*-oltuk az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleobjectframe)-ként. Ez volt a kívánt OLE objektumkeret, amelyhez hozzáfértünk.
4. Miután hozzáfértünk az OLE objektumkerethez, tetszőleges műveletet végezhet rajta.
5. Hozzon létre egy `Workbook` objektumot, és férjen hozzá az OLE adatokhoz.
6. Hozzáférés a kívánt `Worksheet`-hez, és módosítsa az adatokat.
7. Mentse az frissített `Workbook`-ot egy stream-be.
8. Módosítsa az OLE objektum adatait a streamből.

Az alábbi példában egy OLE objektumkeretet (egy diára beágyazott Excel-diagram objektumot) érünk el, és a fájl adatait módosítjuk a diagram adatok frissítéséhez.
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Az első alakzatot OLE objektumkeretként lekérjük.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Az OLE objektum adatait Workbook objektumként olvassuk.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // A munkafüzet adatait módosítjuk.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Az OLE keret objektum adatait módosítjuk.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Más fájltípusok beágyazása a diákba**

Az Excel diagramok mellett az Aspose.Slides for .NET lehetővé teszi más típusú fájlok beágyazását a diákba. Például HTML, PDF és ZIP fájlokat is beilleszthet objektumként. Amikor a felhasználó duplán kattint a beillesztett objektumra, az automatikusan megnyílik a megfelelő programban, vagy felkérik a megfelelő program kiválasztására a megnyitáshoz.

Ez a C# kód megmutatja, hogyan ágyazhat be HTML- és ZIP-fájlokat egy diára:
```c#
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

Prezentációk kezelése során előfordulhat, hogy régi OLE objektumokat kell cserélni újakra, vagy egy nem támogatott OLE objektumot egy támogatottra. Az Aspose.Slides for .NET lehetővé teszi a beágyazott objektum fájltípusának beállítását, így frissítheti az OLE keret adatait vagy annak kiterjesztését.

Ez a C# kód megmutatja, hogyan állítható be a beágyazott OLE objektum fájltípusa `zip`-re:
```c#
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

Egy OLE objektum beágyazása után automatikusan hozzáadódik egy előnézet, amely egy ikonképből áll. Ez az előnézet az, amit a felhasználók látnak az OLE objektum elérése vagy megnyitása előtt. Ha egy adott képet és szöveget szeretne használni az előnézet elemeiként, az ikonképet és a címet az Aspose.Slides for .NET segítségével állíthatja be.

Ez a C# kód megmutatja, hogyan állítható be az ikonkép és a cím egy beágyazott objektumhoz: 
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Képet adunk a prezentáció erőforrásaihoz.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Beállítunk egy címet és képet az OLE előnézethez.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Az OLE objektumkeret átméretezésének és áthelyezésének megakadályozása**

Miután egy linkelt OLE objektumot hozzáad egy prezentációs diához, a PowerPointban történő megnyitáskor megjelenhet egy üzenet, amely a hivatkozások frissítését kérdezi. A „Update Links” (Hivatkozások frissítése) gombra kattintás megváltoztathatja az OLE objektumkeret méretét és pozícióját, mivel a PowerPoint frissíti a linkelt OLE objektum adatait és frissíti az objektum előnézetét. Az OLE objektum adatainak frissítésére vonatkozó PowerPoint‑i felszólítás elkerüléséhez állítsa az [IOleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleobjectframe/) interfész `UpdateAutomatic` tulajdonságát `false`-ra:
```cs
oleFrame.UpdateAutomatic = false;
```

## **Beágyazott fájlok kinyerése**

Az Aspose.Slides for .NET lehetővé teszi a diákba beágyazott fájlok OLE objektumokként történő kinyerését a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, amely tartalmazza a kinyerni kívánt OLE objektumokat.
2. Járjon végig a prezentáció összes alakzatán, és érje el az [OLEObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe) alakzatokat.
3. Szerezze meg a beágyazott fájlok adatait az OLE objektumkeretekből, és írja őket lemezre.

Ez a C# kód megmutatja, hogyan lehet kinyerni egy diára beágyazott fájlokat OLE objektumokként:
```c#
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

## **GYIK**

**Megjelenik-e az OLE tartalom a diák PDF/képek formátumba exportálásakor?**

A dián látható elem jelenik meg – az ikon/helyettesítő kép (előnézet). A „valódi” OLE tartalom nem kerül végrehajtásra a renderelés során. Szükség esetén állítson be saját előnézeti képet a várt megjelenés biztosításához az exportált PDF-ben.

**Hogyan zárolhatok egy OLE objektumot a dián, hogy a felhasználók ne mozdíthassák/szerkeszthessék a PowerPointban?**

Zárolja az alakzatot: az Aspose.Slides [alakzatszintű zárolásokat](/slides/hu/net/applying-protection-to-presentation/) biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és áthelyezést.

**Miért „ugrik” vagy változik mérete a linkelt Excel objektum, amikor megnyitom a prezentációt?**

A PowerPoint frissítheti a linkelt OLE előnézetét. Stabil megjelenés érdekében kövesse a [Worksheet Resizing munkamegoldás](/slides/hu/net/working-solution-for-worksheet-resizing/) gyakorlatait – vagy illessze a keretet a tartományhoz, vagy méretezze a tartományt egy rögzített keretre, és állítson be megfelelő helyettesítő képet.

**Megmaradnak-e a linkelt OLE objektumok relatív útvonalai a PPTX formátumban?**

A PPTX formátumban a „relatív útvonal” információ nem áll rendelkezésre – csak a teljes útvonal. Relatív útvonalak a régebbi PPT formátumban találhatók. A hordozhatóság érdekében részesítse előnyben a megbízható abszolút útvonalakat/könnyen elérhető URI-kat vagy a beágyazást.