---
title: Správa OLE objektů v prezentacích v .NET
linktitle: Správa OLE
type: docs
weight: 40
url: /cs/net/manage-ole/
keywords:
- OLE objekt
- Propojení a vložení objektů
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
description: "Optimalizujte správu OLE objektů v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Vkládejte, aktualizujte a exportujte OLE obsah bez problémů."
---
## **Úvod**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) je technologie společnosti Microsoft, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí propojení nebo vložení. 

{{% /alert %}} 

Chtějte si představit graf vytvořený v MS Excel. Tento graf je poté umístěn na snímek PowerPointu. Tento Excel graf je považován za OLE objekt. 

- OLE objekt se může zobrazit jako ikona. V tomto případě, když na ikonu dvojkliknete, graf se otevře v přidružené aplikaci (Excel), nebo budete vyzváni k výběru aplikace pro otevření nebo úpravu objektu. 
- OLE objekt může zobrazovat svůj skutečný obsah, například obsah grafu. V tomto případě je graf aktivován v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.

[Aspose.Slides for .NET](https://products.aspose.com/slides/cs/net/) umožňuje vkládat OLE objekty do snímků jako OLE rámy objektů ([OleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe)).

## **Přidání OLE objektových rámců do snímků**

Předpokládejme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE objektový rámec pomocí Aspose.Slides for .NET, můžete to provést následujícím způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation). 
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Přečtěte soubor Excel jako pole bytů. 
4. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe) do snímku, který obsahuje pole bytů a další informace o OLE objektu. 
5. Uložte upravenou prezentaci jako soubor PPTX. 

V níže uvedeném příkladu jsme přidali graf ze souboru Excel do snímku jako [OleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe) pomocí Aspose.Slides for .NET.  **Poznámka**: konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cs/net/aspose.slides.dom.ole/oleembeddeddatainfo/) přijímá rozšíření vložitelného objektu jako druhý parametr. Toto rozšíření umožňuje PowerPointu správně interpretovat typ souboru a zvolit správnou aplikaci pro otevření tohoto OLE objektu.

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

    // Přidejte OLE objektový rámec na snímek.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Přidání propojených OLE objektových rámců**

Aspose.Slides for .NET umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe) bez vložení dat, ale pouze s odkazem na soubor.

Tento C# kód ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe) s propojeným souborem Excel na snímek:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Přidejte OLE objektový rámec s propojeným souborem Excel.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Přístup k OLE objektovým rámcům**

Pokud je OLE objekt již vložen do snímku, můžete jej snadno najít nebo získat takto:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation). 
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Získejte přístup k tvaru [OleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe). V našem příkladu jsme použili dříve vytvořený PPTX, který má na první snímku pouze jeden tvar. Poté jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleobjectframe). To byl požadovaný OLE objektový rámec, ke kterému se máme přistupovat. 
4. Jakmile získáte přístup k OLE objektovému rámci, můžete s ním provádět libovolné operace. 

V níže uvedeném příkladu je přístup k OLE objektovému rámci (objekt grafu Excel vložený do snímku) a k jeho datům souboru.

```csharp 
using Aspose.Slides;

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

Tento C# kód ukazuje, jak zkontrolovat, zda je OLE objekt propojen, a poté získat cestu k propojenému souboru:

```csharp
using Aspose.Slides;

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

{{% alert color="info" %}} 

V této sekci níže uvedený příklad kódu používá [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Pokud je OLE objekt již vložen do snímku, můžete k tomuto objektu snadno získat přístup a upravit jeho data následujícím způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation). 
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Získejte přístup k [OLEObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe) tvaru. V našem příkladu jsme použili dříve vytvořený PPTX, který má na první snímku jeden tvar. Poté jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleobjectframe). To byl požadovaný OLE objektový rámec, ke kterému se máme přistupovat. 
4. Jakmile získáte přístup k OLE objektovému rámci, můžete s ním provádět libovolné operace. 
5. Vytvořte objekt `Workbook` a získejte přístup k OLE datům. 
6. Získejte požadovaný `Worksheet` a upravte data. 
7. Uložte aktualizovaný `Workbook` do proudu. 
8. Změňte data OLE objektu ze streamu. 

V níže uvedeném příkladu je přístup k OLE objektovému rámci (objekt grafu Excel vložený do snímku) a data souboru jsou upravena tak, aby se aktualizovala data grafu.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Získejte první tvar jako OLE objektový rámec.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Načtěte data OLE objektu jako objekt Workbook.
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

Kromě grafů Excel umožňuje Aspose.Slides for .NET vkládat do snímků i další typy souborů. Například můžete vložit soubory HTML, PDF a ZIP jako objekty. Když uživatel dvojklikne na vložený objekt, automaticky se otevře v příslušném programu, nebo je uživatel vyzván k výběru vhodného programu pro otevření.

Tento C# kód ukazuje, jak vložit HTML a ZIP do snímku:

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

Při práci s prezentacemi může být nutné nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for .NET umožňuje nastavit typ souboru pro vložený objekt, což vám umožní aktualizovat data OLE rámce nebo jeho příponu.

Tento C# kód ukazuje, jak nastavit typ souboru pro vložený OLE objekt na `zip`:

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

    // Změňte typ souboru na ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Nastavení ikony a titulku pro vložené objekty**

Po vložení OLE objektu se automaticky přidá náhled sestávající z ikony. Tento náhled je to, co uživatelé vidí před přístupem nebo otevřením OLE objektu. Pokud chcete použít konkrétní obrázek a text jako prvky v náhledu, můžete pomocí Aspose.Slides for .NET nastavit ikonu a titulek.

Tento C# kód ukazuje, jak nastavit ikonu a titulek pro vložený objekt: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Přidejte obrázek do zdrojů prezentace.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Nastavte titulek a obrázek pro náhled OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Zabránění změně velikosti a pozicování OLE objektového rámce**

Po přidání propojeného OLE objektu do snímku prezentace, když otevřete prezentaci v PowerPointu, můžete vidět zprávu s výzvou k aktualizaci odkazů. Kliknutím na tlačítko „Update Links“ se může změnit velikost a pozice OLE objektového rámce, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnoví náhled objektu. Chcete‑li zabránit PowerPointu v dotazování na aktualizaci dat objektu, nastavte vlastnost `UpdateAutomatic` rozhraní [IOleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleobjectframe/) na `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Udržte velikost a polohu OLE objektového rámce, když PowerPoint aktualizuje odkaz.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Extrahování vložených souborů**

Aspose.Slides for .NET vám umožňuje extrahovat soubory vložené do snímků jako OLE objekty následujícím způsobem:
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), která obsahuje OLE objekty, které chcete extrahovat. 
2. Projděte všechny tvary v prezentaci a získejte přístup k tvarům [OLEObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe). 
3. Získejte data vložených souborů z OLE objektových rámců a zapište je na disk. 

Tento C# kód ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

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

### Bude obsah OLE renderován při exportu snímků do PDF/obrázků?

Co je na snímku viditelné, je renderováno – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah není během renderování vykonán. V případě potřeby nastavte vlastní obrázek náhledu, aby exportovaný PDF vypadal podle očekávání.

### Jak mohu zamknout OLE objekt na snímku, aby jej uživatelé nemohli v PowerPointu přesouvat/upravovat?

Zamkněte tvar: Aspose.Slides poskytuje [zámky na úrovni tvarů](/slides/cs/net/applying-protection-to-presentation/). Není to šifrování, ale účinně zabraňuje neúmyslným úpravám a přesunu.

### Proč se propojený Excel objekt při otevření prezentace „přesouvá“ nebo mění velikost?

PowerPoint může při otevření prezentace obnovit náhled propojeného OLE. Pro stabilní vzhled postupujte podle praktik [Working Solution for Worksheet Resizing](/slides/cs/net/working-solution-for-worksheet-resizing/) – buď přizpůsobte rámec oblastí, nebo škálujte oblast na pevný rámec a nastavte vhodný náhradní obrázek.

### Zůstanou relativní cesty pro propojené OLE objekty zachovány ve formátu PPTX?

V PPTX není informace o „relativní cestě“ k dispozici – pouze plná cesta. Relativní cesty jsou obsaženy ve starším formátu PPT. Pro přenositelnost upřednostněte spolehlivé absolutní cesty/přístupné URI nebo vložení.