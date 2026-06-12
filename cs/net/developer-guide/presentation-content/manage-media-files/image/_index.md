---
title: "Optimalizace správy obrázků v prezentacích v .NET"
linktitle: "Správa obrázků"
type: docs
weight: 10
url: /cs/net/image/
keywords:
- přidat obrázek
- přidat fotografii
- přidat bitmapu
- nahradit obrázek
- nahradit fotografii
- z webu
- pozadí
- přidat PNG
- přidat JPG
- přidat SVG
- přidat EMF
- přidat WMF
- přidat TIFF
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjednodušte správu obrázků v PowerPointu a OpenDocument pomocí Aspose.Slides pro .NET, optimalizujte výkon a automatizujte svůj pracovní postup."
---
## **Úvod**

Obrázky činí prezentace poutavějšími a zajímavějšími. V aplikaci Microsoft PowerPoint můžete do snímků vkládat obrázky ze souboru, z internetu nebo z jiných míst. Podobně Aspose.Slides umožňuje přidávat obrázky do snímků vašich prezentací různými postupy.

{{% alert  title="Tip" color="primary" %}} 

Aspose poskytuje bezplatné převodníky—[JPEG na PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG na PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt)—které umožňují rychle vytvářet prezentace z obrázků. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Pokud chcete přidat obrázek jako objekt rámce—zejména pokud plánujete použít standardní možnosti formátování k úpravě velikosti, přidání efektů a podobně—podívejte se na [Rámec obrázku](https://docs.aspose.com/slides/cs/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Poznámka" color="warning" %}}

Můžete manipulovat s operacemi vstupu/výstupu zahrnujícími obrázky a prezentace PowerPointu a převádět obrázek z jednoho formátu do druhého. Viz tyto stránky: převod [obrázku na JPG](https://products.aspose.com/slides/cs/net/conversion/image-to-jpg/); převod [JPG na obrázek](https://products.aspose.com/slides/cs/net/conversion/jpg-to-image/); převod [JPG na PNG](https://products.aspose.com/slides/cs/net/conversion/jpg-to-png/), převod [PNG na JPG](https://products.aspose.com/slides/cs/net/conversion/png-to-jpg/); převod [PNG na SVG](https://products.aspose.com/slides/cs/net/conversion/png-to-svg/), převod [SVG na PNG](https://products.aspose.com/slides/cs/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides podporuje operace s obrázky v těchto populárních formátech: JPEG, PNG, BMP, GIF a další. 

## **Přidání obrázků uložených lokálně do snímků**

Můžete přidat jeden nebo více obrázků z vašeho počítače na snímek v prezentaci. Tento ukázkový kód v C# ukazuje, jak přidat obrázek na snímek:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Přidání obrázků z webu do snímků**

Pokud obrázek, který chcete na snímek přidat, není k dispozici na vašem počítači, můžete jej přidat přímo z webu.

Tento ukázkový kód ukazuje, jak v C# přidat obrázek z webu na snímek:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Přidání obrázků do hlavních snímků**

Hlavní snímek (slide master) je nejvyšší snímek, který ukládá a řídí informace (téma, rozvržení atd.) o všech snímcích pod ním. Proto když přidáte obrázek do hlavního snímku, tento obrázek se objeví na každém snímku pod tímto hlavním snímkem.

Tento ukázkový kód v C# ukazuje, jak přidat obrázek do hlavního snímku:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Přidání obrázků jako pozadí snímků**

Můžete se rozhodnout použít obrázek jako pozadí pro konkrétní snímek nebo několik snímků. V takovém případě si musíte prohlédnout *[Nastavení obrázků jako pozadí snímků](https://docs.aspose.com/slides/cs/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Přidání SVG do prezentací**

Můžete přidat nebo vložit jakýkoli obrázek do prezentace pomocí metody [AddPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/methods/addpictureframe), která patří k rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection).

Pro vytvoření objektu obrázku založeného na SVG můžete postupovat takto:

1. Vytvořte objekt SvgImage, který vložíte do ImageShapeCollection  
2. Vytvořte objekt PPImage z ISvgImage  
3. Vytvořte objekt PictureFrame pomocí rozhraní IPPImage  

Tento ukázkový kód ukazuje, jak implementovat výše uvedené kroky pro přidání SVG obrázku do prezentace:
``` csharp 
// Cesta k adresáři dokumentů
string dataDir = @"D:\Documents\";

// Název zdrojového SVG souboru
string svgFileName = dataDir + "sample.svg";

// Název výstupního souboru prezentace
string outPptxPath = dataDir + "presentation.pptx";

// Vytvořit novou prezentaci
using (var p = new Presentation())
{
    // Načíst obsah SVG souboru
    string svgContent = File.ReadAllText(svgFileName);

    // Vytvořit objekt SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Vytvořit objekt PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Vytvoří nový PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Uložit prezentaci ve formátu PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Převod SVG na sadu tvarů**

Převod SVG na sadu tvarů v Aspose.Slides je podobný funkci PowerPointu používané pro práci s SVG obrázky:

![PowerPoint Popup Menu](img_01_01.png)

Funkčnost je poskytována jednou z přetížení metody [AddGroupShape](https://reference.aspose.com/slides/cs/net/aspose.slides.ishapecollection/addgroupshape/methods/1) rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection), která přijímá objekt [ISvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage) jako první argument.

Tento ukázkový kód ukazuje, jak použít popsanou metodu pro převod SVG souboru na sadu tvarů:

``` csharp 
// Cesta k adresáři dokumentů
string dataDir = @"D:\Documents\";

// Název zdrojového SVG souboru
string svgFileName = dataDir + "sample.svg";

// Název výstupního souboru prezentace
string outPptxPath = dataDir + "presentation.pptx";

// Vytvořit novou prezentaci
using (IPresentation presentation = new Presentation())
{
    // Načíst obsah SVG souboru
    string svgContent = File.ReadAllText(svgFileName);

    // Vytvořit objekt SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Získat velikost snímku
    SizeF slideSize = presentation.SlideSize.Size;

    // Převést SVG obrázek na skupinu tvarů a přizpůsobit velikosti snímku
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Uložit prezentaci ve formátu PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Přidání obrázků jako EMF do snímků**

Aspose.Slides pro .NET umožňuje generovat EMF obrázky z excelových listů a přidávat tyto obrázky jako EMF do snímků pomocí Aspose.Cells.  

Tento ukázkový kód ukazuje, jak provést popsaný úkol:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Uložit sešit do proudu
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Nahrazení obrázků ve sbírce obrázků**

Aspose.Slides umožňuje nahradit obrázky uložené v kolekci obrázků prezentace (včetně těch, které používají tvary snímků). Tato sekce ukazuje několik přístupů k aktualizaci obrázků v kolekci. API poskytuje přímé metody pro nahrazení obrázku pomocí surových bajtových dat, instance [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) nebo jiného obrázku, který již v kolekci existuje.

Postupujte podle následujících kroků:

1. Načtěte soubor prezentace, který obsahuje obrázky, pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).  
2. Načtěte nový obrázek ze souboru do pole bajtů.  
3. Nahraďte cílový obrázek novým obrázkem pomocí pole bajtů.  
4. Ve druhém přístupu načtěte obrázek do objektu [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) a nahraďte cílový obrázek tímto objektem.  
5. Ve třetím přístupu nahraďte cílový obrázek obrázkem, který již v kolekci obrázků prezentace existuje.  
6. Uložte upravenou prezentaci jako soubor PPTX.

```cs
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using Presentation presentation = new Presentation("sample.pptx");

// První způsob.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Druhý způsob.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Třetí způsob.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Uložit prezentaci do souboru.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

Pomocí Aspose FREE [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) převodníku můžete snadno animovat texty, vytvářet GIFy z textu atd. 

{{% /alert %}}

## **FAQ**

**Zůstane původní rozlišení obrázku po vložení zachováno?**

Ano. Původní pixely jsou zachovány, ale konečný vzhled závisí na tom, jak je [obrázek](/slides/cs/net/picture-frame/) na snímku škálován a jaká komprese je použita při uložení.

**Jaký je nejlepší způsob, jak najednou nahradit stejné logo na desítkách snímků?**

Umístěte logo na hlavní snímek nebo rozvržení a nahraďte ho v kolekci obrázků prezentace — změna se projeví ve všech prvcích, které tento zdroj používají.

**Lze vložený SVG převést na editovatelné tvary?**

Ano. SVG můžete převést na skupinu tvarů, po čemž se jednotlivé části stanou editovatelnými pomocí standardních vlastností tvarů.

**Jak mohu nastavit obrázek jako pozadí pro více snímků najednou?**

[Assign the image as the background](/slides/cs/net/presentation-background/) na hlavním snímku nebo příslušném rozvržení — všechny snímky využívající daný hlavní snímek/rozvržení zdědí toto pozadí.

**Jak zabránit tomu, aby se prezentace „nafoukla“ kvůli mnoha obrázkům?**

Opakovaně používejte jeden zdroj obrázku místo duplicit, zvolte rozumná rozlišení, použijte kompresi při uložení a opakovanou grafiku umístěte tam, kde to dává smysl, na hlavní snímek.