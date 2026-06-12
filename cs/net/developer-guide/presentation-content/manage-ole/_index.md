---
title: Správa OLE objektů v prezentacích v .NET
linktitle: Správa OLE
type: docs
weight: 40
url: /cs/net/manage-ole/
keywords:
- OLE objekt
- Objektové propojování a vkládání
- přidat OLE
- vložit OLE
- přidat objekt
- vložit objekt
- přidat soubor
- vložit soubor
- propojený objekt
- propojený soubor
- změnit OLE
- OLE ikona
- OLE název
- extrahovat OLE
- extrahovat objekt
- extrahovat soubor
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Optimalizujte správu OLE objektů v PowerPointu a souborech OpenDocument pomocí Aspose.Slides pro .NET. Vkládejte, aktualizujte a exportujte OLE obsah bez problémů."
---
## **Úvod**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) je technologie společnosti Microsoft, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí propojení nebo vložení. 

{{% /alert %}} 

Uvažujme o grafu vytvořeném v MS Excel. Tento graf je poté umístěn do snímku PowerPointu. Tento Excel graf se považuje za OLE objekt. 

- OLE objekt se může zobrazovat jako ikona. V takovém případě, když ikonu dvojkliknete, otevře se graf v přidružené aplikaci (Excel), nebo budete vyzváni k výběru aplikace pro otevření nebo úpravu objektu. 
- OLE objekt může zobrazovat svůj skutečný obsah, například obsah grafu. V tomto případě je graf aktivován v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.

[Aspose.Slides for .NET](https://products.aspose.com/slides/cs/net/) umožňuje vkládat OLE objekty do snímků jako rámy OLE objektů ([OleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe)).

## **Přidání OLE objektových rámců do snímků**

Předpokládejme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako rámeček OLE objektu pomocí Aspose.Slides for .NET, můžete to provést následujícím způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Načtěte soubor Excel jako pole bajtů.
4. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe) do snímku, který obsahuje pole bajtů a další informace o OLE objektu.
5. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali graf ze souboru Excel do snímku jako [OleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe) pomocí Aspose.Slides for .NET. **Poznámka** že konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cs/net/aspose.slides.dom.ole/oleembeddeddatainfo/) přijímá rozšíření vkládatelného objektu jako druhý parametr. Toto rozšíření umožňuje PowerPointu správně interpretovat typ souboru a vybrat správnou aplikaci pro otevření tohoto OLE objektu.

```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Připravte data pro OLE objekt.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Přidejte OLE objektový rámec do snímku.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Přidání propojených OLE objektových rámců**

Aspose.Slides for .NET umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe) bez vkládání dat, ale pouze s odkazem na soubor.

Tento kód v C# ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe) s propojeným souborem Excel do snímku:

```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Přidejte OLE objektový rámec s odkazem na soubor Excel.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Přístup k OLE objektovým rámcům**

Pokud je OLE objekt již vložen do snímku, můžete jej snadno najít nebo získat tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Získejte přístup k tvaru [OleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe). V našem příkladu jsme použili dříve vytvořený PPTX, který má na první snímku pouze jeden tvar. Poté jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleobjectframe). Toto byl požadovaný rám OLE objektu, ke kterému jsme chtěli získat přístup.
4. Jakmile získáte přístup k rámci OLE objektu, můžete na něm provádět libovolné operace.

V níže uvedeném příkladu je přístup k OLE objektovému rámci (grafu Excel vloženému do snímku) a jeho souborovým datům.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Získejte první tvar jako OLE objektový rámec.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Získejte data vloženého souboru.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Získejte příponu vloženého souboru.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Přístup k vlastnostem propojeného OLE objektového rámce**

Aspose.Slides umožňuje přístup k vlastnostem propojených OLE objektových rámců.

Tento kód v C# ukazuje, jak zkontrolovat, zda je OLE objekt propojen, a poté získat cestu k propojenému souboru:

```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Získejte první tvar jako OLE objektový rámec.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Zkontrolujte, zda je OLE objekt propojen.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Vytiskněte úplnou cestu k propojenému souboru.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Vytiskněte relativní cestu k propojenému souboru, pokud existuje.
        // Pouze prezentace PPT mohou obsahovat relativní cestu.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Změna dat OLE objektu**

{{% alert color="primary" %}} 

V této sekci níže uvedený příklad kódu používá [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Pokud je OLE objekt již vložen do snímku, můžete jej snadno získat a upravit jeho data tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Získejte přístup k tvaru [OLEObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe). V našem příkladu jsme použili dříve vytvořený PPTX, který má na první snímku jeden tvar. Poté jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleobjectframe). Toto byl požadovaný rám OLE objektu, ke kterému jsme chtěli získat přístup.
4. Jakmile získáte přístup k rámci OLE objektu, můžete na něm provádět libovolné operace.
5. Vytvořte objekt `Workbook` a získejte přístup k OLE datům.
6. Získejte požadovaný `Worksheet` a upravte data.
7. Uložte aktualizovaný `Workbook` do proudu.
8. Změňte data OLE objektu z proudu.

V níže uvedeném příkladu je přístup k OLE objektovému rámci (grafu Excel vloženému do snímku) a jeho souborová data jsou upravena pro aktualizaci dat grafu.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Získejte první tvar jako OLE objektový rámec.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Přečtěte data OLE objektu jako objekt Workbook.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Modifikujte data sešitu.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Změňte data objektu OLE rámce.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Vkládání dalších typů souborů do snímků**

Kromě grafů Excel umožňuje Aspose.Slides for .NET vložit do snímků i jiné typy souborů. Například můžete vložit soubory HTML, PDF a ZIP jako objekty. Když uživatel dvojklikne na vložený objekt, automaticky se otevře v příslušném programu nebo je uživatel vyzván, aby vybral vhodný program pro jeho otevření.

Tento kód v C# ukazuje, jak vložit HTML a ZIP do snímku:

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

## **Nastavení typů souborů pro vložené objekty**

Při práci s prezentacemi může být potřeba nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for .NET umožňuje nastavit typ souboru pro vložený objekt, což umožňuje aktualizovat data OLE rámce nebo jeho příponu.

Tento kód v C# ukazuje, jak nastavit typ souboru pro vložený OLE objekt na `zip`:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Změňte typ souboru na ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Nastavení obrázků ikon a názvů pro vložené objekty**

Po vložení OLE objektu se automaticky přidá náhled skládající se z obrázku ikony. Tento náhled uživatelé vidí před přístupem nebo otevřením OLE objektu. Pokud chcete použít konkrétní obrázek a text jako prvky v náhledu, můžete nastavit obrázek ikony a název pomocí Aspose.Slides for .NET.

Tento kód v C# ukazuje, jak nastavit obrázek ikony a název pro vložený objekt: 

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Přidejte obrázek do zdrojů prezentace.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Nastavte název a obrázek pro náhled OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Zabránit změně velikosti a posunu OLE objektového rámce**

Po přidání propojeného OLE objektu do snímku prezentace, když otevřete prezentaci v PowerPointu, můžete vidět zprávu, která vás žádá o aktualizaci odkazů. Kliknutí na tlačítko „Update Links“ může změnit velikost a polohu rámce OLE objektu, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnovuje náhled objektu. Chcete‑li zabránit PowerPointu v dotazu na aktualizaci dat objektu, nastavte vlastnost `UpdateAutomatic` rozhraní [IOleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleobjectframe/) na `false`:

```cs
oleFrame.UpdateAutomatic = false;
```

## **Extrahování vložených souborů**

Aspose.Slides for .NET umožňuje extrahovat soubory vložené do snímků jako OLE objekty tímto způsobem:
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), která obsahuje OLE objekty, které chcete extrahovat.
2. Projděte všechny tvary v prezentaci a získejte přístup k tvarům [OLEObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe).
3. Získejte data vložených souborů z OLE objektových rámců a zapište je na disk.

Tento kód v C# ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

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

## **FAQ**

**Bude při exportu snímků do PDF/obrázků vykreslen obsah OLE?**

To, co je na snímku viditelné, se vykreslí – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah se během vykreslování nespouští. V případě potřeby nastavte vlastní náhledový obrázek, aby výstupní PDF vypadal podle očekávání.

**Jak mohu uzamknout OLE objekt na snímku, aby jej uživatelé v PowerPointu nemohli přesouvat/upravovat?**

Uzamkněte tvar: Aspose.Slides poskytuje [zámky na úrovni tvaru](/slides/cs/net/applying-protection-to-presentation/). Nejedná se o šifrování, ale účinně zabraňuje nechtěným úpravám a přesunům.

**Proč se propojený Excel objekt „přeskakuje“ nebo mění velikost, když otevřu prezentaci?**

PowerPoint může obnovit náhled propojeného OLE. Pro stabilní vzhled dodržujte osvědčené postupy z [Working Solution for Worksheet Resizing](/slides/cs/net/working-solution-for-worksheet-resizing/) – buď přizpůsobte rám rozsahu, nebo škálujte rozsah na pevný rám a nastavte vhodný náhradní obrázek.

**Zůstanou relativní cesty k propojeným OLE objektům zachovány ve formátu PPTX?**

Ve formátu PPTX informace o „relativní cestě“ nejsou k dispozici – pouze úplná cesta. Relativní cesty jsou dostupné ve starším formátu PPT. Pro přenositelnost upřednostňujte spolehlivé absolutní cesty/přístupné URI nebo vkládání.