---
title: Spravovat OLE objekty v prezentacích v .NET
linktitle: Spravovat OLE
type: docs
weight: 40
url: /cs/net/manage-ole/
keywords:
  - OLE objekt
  - Objektové propojení a vkládání
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
description: "Optimalizujte správu OLE objektů v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Vkládejte, aktualizujte a exportujte OLE obsah hladce."
---
## **Úvod**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) je technologie Microsoftu, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace prostřednictvím propojení nebo vložení. 
{{% /alert %}} 

Zvažte graf vytvořený v MS Excel. Tento graf je poté umístěn do snímku PowerPointu. Tento Excel graf je považován za OLE objekt. 

- OLE objekt může být zobrazen jako ikona. V tom případě, když na ikonu dvakrát kliknete, otevře se graf v jeho přidružené aplikaci (Excel), nebo budete vyzváni vybrat aplikaci pro otevření či úpravu objektu. 
- OLE objekt může zobrazovat svůj skutečný obsah, například obsah grafu. V tomto případě je graf aktivován v PowerPointu, načte se rozhraní grafu a můžete v PowerPointu upravovat data grafu.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) vám umožňuje vložit OLE objekty do snímků jako OLE rámce objektů ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Přidání OLE rámců objektů do snímků**

Předpokládáme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE rámec objektu pomocí Aspose.Slides for .NET, můžete to provést takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přečtěte soubor Excel jako pole bajtů.
4. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) do snímku s polem bajtů a dalším informacemi o OLE objektu.
5. Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali graf ze souboru Excel do snímku jako [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) pomocí Aspose.Slides for .NET.  
**Poznámka**: konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) přijímá jako druhý parametr rozšíření vkládaného objektu. Toto rozšíření umožňuje PowerPointu správně interpretovat typ souboru a vybrat správnou aplikaci pro otevření tohoto OLE objektu.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Připravte data pro OLE objekt.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Přidejte rámec OLE objektu do snímku.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Přidání propojených OLE rámců objektů**

Aspose.Slides for .NET vám umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) bez vložení dat, pouze s odkazem na soubor.

Tento C# kód vám ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) s odkázaným souborem Excel do snímku:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Přidejte rámec OLE objektu s propojeným souborem Excel.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Přístup k OLE rámcům objektů**

Pokud je OLE objekt již vložen do snímku, můžete jej snadno najít nebo přistupovat k němu tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přistupte k tvaru [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). 
   V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jen jeden tvar. Pak jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). To byl požadovaný OLE rámec objektu, ke kterému jsme přistupovali.
4. Jakmile je OLE rámec objektu přístupný, můžete na něm provádět libovolnou operaci.

V níže uvedeném příkladu je přístup k OLE rámci objektu (objekt Excel grafu vložený do snímku) a jeho souborovým datům.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Získat první tvar jako OLE rámec objektu.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Získat vložená data souboru.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Získat příponu vloženého souboru.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Přístup k vlastnostem propojeného OLE rámce objektu**

Aspose.Slides vám umožňuje přistupovat k vlastnostem propojených OLE rámců objektů.

Tento C# kód vám ukazuje, jak zkontrolovat, zda je OLE objekt propojen, a poté získat cestu k propojenému souboru:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Získat první tvar jako rámec OLE objektu.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Zkontrolovat, zda je OLE objekt propojen.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Vytisknout úplnou cestu k propojenému souboru.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Vytisknout relativní cestu k propojenému souboru, pokud existuje.
        // Pouze prezentace PPT mohou obsahovat relativní cestu.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Změna dat OLE objektu**

{{% alert color="info" title="Note" %}}
V této sekci níže uvedený příklad kódu používá [Aspose.Cells for .NET](https://docs.aspose.com/cells/net/).
{{% /alert %}}

Pokud je OLE objekt již vložen do snímku, můžete jej snadno přistupovat a upravit jeho data tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přistupte k tvaru [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
   V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jeden tvar. Pak jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). To byl požadovaný OLE rámec objektu, ke kterému jsme přistupovali.
4. Jakmile je OLE rámec objektu přístupný, můžete na něm provádět libovolnou operaci.
5. Vytvořte objekt `Workbook` a přistupte k OLE datům.
6. Přistupte k požadovanému `Worksheet` a upravte data.
7. Uložte aktualizovaný `Workbook` do proudu.
8. Změňte data OLE objektu ze proudu.

V níže uvedeném příkladu je přístup k OLE rámci objektu (objekt Excel grafu vložený do snímku) a jeho souborová data jsou upravena k aktualizaci dat grafu.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Získat první tvar jako rámec OLE objektu.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Načíst data OLE objektu jako objekt Workbook.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Upravit data sešitu.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Změnit data objektu OLE rámce.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Vkládání dalších typů souborů do snímků**

Kromě Excel grafů vám Aspose.Slides for .NET umožňuje vložit do snímků i jiné typy souborů. Například můžete vložit soubory HTML, PDF a ZIP jako objekty. Když uživatel dvakrát klikne na vložený objekt, automaticky se otevře ve příslušném programu, nebo je uživatel vyzván vybrat vhodný program pro jeho otevření.

Tento C# kód vám ukazuje, jak vložit HTML a ZIP do snímku:

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

## **Nastavení typů souborů pro vložené objekty**

Při práci s prezentacemi může být potřeba nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for .NET vám umožňuje nastavit typ souboru pro vložený objekt, což vám umožní aktualizovat data OLE rámce nebo jeho rozšíření.

Tento C# kód vám ukazuje, jak nastavit typ souboru pro vložený OLE objekt na `zip`:

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

    // Změnit typ souboru na ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Nastavení obrázků ikon a názvů pro vložené objekty**

Po vložení OLE objektu se automaticky přidá náhled skládající se z obrázku ikony. Tento náhled je to, co uživatelé vidí před přístupem nebo otevřením OLE objektu. Pokud chcete použít konkrétní obrázek a text jako prvky v náhledu, můžete nastavit obrázek ikony a název pomocí Aspose.Slides for .NET.

Tento C# kód vám ukazuje, jak nastavit obrázek ikony a název pro vložený objekt: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Přidat obrázek do zdrojů prezentace.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Nastavit název a obrázek pro náhled OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Zabránit změně velikosti a přemístění OLE rámce objektu**

Po přidání propojeného OLE objektu do snímku prezentace a otevření prezentace v PowerPointu se může zobrazit zpráva s výzvou k aktualizaci odkazů. Kliknutím na tlačítko „Update Links“ může dojít ke změně velikosti a polohy OLE rámce objektu, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnoví náhled objektu. Chcete‑li zabránit výzvě PowerPointu k aktualizaci dat objektu, nastavte vlastnost `UpdateAutomatic` rozhraní [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) na `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Zachovat velikost a pozici rámce OLE objektu, když PowerPoint aktualizuje odkaz.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Extrahovat vložené soubory**

Aspose.Slides for .NET vám umožňuje extrahovat soubory vložené do snímků jako OLE objekty tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) obsahující OLE objekty, které chcete extrahovat.
2. Projděte všechny tvary v prezentaci a přistupujte k tvarům [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
3. Přistupte k datům vložených souborů z OLE rámců objektů a zapište je na disk.

Tento C# kód vám ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

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

## **Často kladené otázky**

**Bude obsah OLE vykreslen při exportu snímků do PDF/obrázků?**

Na snímku se vykresluje to, co je viditelné — ikona/náhradní obrázek (náhled). „Živý“ OLE obsah se během vykreslování nespouští. V případě potřeby nastavte vlastní obrázek náhledu, aby byl v exportovaném PDF očekávaný vzhled.  
Chcete‑li také zachovat vložený soubor jako přílohu PDF, nastavte [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) na `true`. Tato volba je ve výchozím nastavení zakázána. Pro příklad a instrukce ke kontrole přílohy viz [Preserve Embedded OLE Files as PDF Attachments](/slides/cs/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Jak mohu zamknout OLE objekt na snímku, aby jej uživatelé nemohli přesouvat/upravovat v PowerPointu?**

Uzamkněte tvar: Aspose.Slides poskytuje [shape-level locks](/slides/cs/net/applying-protection-to-presentation/). Nejedná se o šifrování, ale účinně zabraňuje neúmyslným úpravám a přesunu.

**Proč se propojený Excel objekt „přeskakuje“ nebo mění velikost, když otevřu prezentaci?**

PowerPoint může obnovit náhled propojeného OLE. Pro stabilní vzhled dodržujte postupy z [Working Solution for Worksheet Resizing](/slides/cs/net/working-solution-for-worksheet-resizing/) — buď přizpůsobte rámec rozsahu, nebo škálujte rozsah na pevný rámec a nastavte vhodný náhradní obrázek.

**Zůstanou relativní cesty pro propojené OLE objekty zachovány ve formátu PPTX?**

V PPTX nejsou informace o „relativní cestě“ k dispozici — existuje pouze úplná cesta. Relativní cesty se nacházejí ve starším formátu PPT. Pro přenositelnost raději používejte spolehlivé absolutní cesty/přístupné URI nebo vkládání.