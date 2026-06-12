---
title: Optimalizace správy obrázků v prezentacích pomocí C++
linktitle: Správa obrázků
type: docs
weight: 10
url: /cs/cpp/image/
keywords:
- přidat obrázek
- přidat obrázek
- přidat bitmapu
- nahradit obrázek
- nahradit obrázek
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
- EMF
- SVG
- C++
- Aspose.Slides
description: "Zefektivněte správu obrázků v PowerPoint a OpenDocument pomocí Aspose.Slides pro C++, optimalizujte výkon a automatizujte svůj pracovní postup."
---
## **Úvod**

Obrázky činí prezentace poutavějšími a zajímavějšími. V Microsoft PowerPoint můžete do snímků vložit obrázky ze souboru, z internetu nebo z jiných umístění. Podobně Aspose.Slides umožňuje přidávat obrázky do snímků ve vašich prezentacích různými postupy. 

{{% alert title="Tip" color="primary" %}} 
Aspose poskytuje zdarma konvertory —[JPEG do PowerPointu](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPointu](https://products.aspose.app/slides/cs/import/png-to-ppt) —které umožňují rychle vytvářet prezentace z obrázků. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Pokud chcete přidat obrázek jako rámový objekt — zejména pokud plánujete použít standardní možnosti formátování k změně velikosti, přidání efektů atd. — podívejte se na [Rám obrázku](/slides/cs/cpp/picture-frame/). 
{{% /alert %}} 

{{% alert title="Poznámka" color="warning" %}}
Můžete manipulovat s operacemi vstupu/výstupu zahrnujícími obrázky a prezentace PowerPointu pro převod obrázku z jednoho formátu do druhého. Viz tyto stránky: převést [obrázek na JPG](https://products.aspose.com/slides/cs/cpp/conversion/image-to-jpg/); převést [JPG na obrázek](https://products.aspose.com/slides/cs/cpp/conversion/jpg-to-image/); převést [JPG na PNG](https://products.aspose.com/slides/cs/cpp/conversion/jpg-to-png/), převést [PNG na JPG](https://products.aspose.com/slides/cs/cpp/conversion/png-to-jpg/); převést [PNG na SVG](https://products.aspose.com/slides/cs/cpp/conversion/png-to-svg/), převést [SVG na PNG](https://products.aspose.com/slides/cs/cpp/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides podporuje operace s obrázky v těchto populárních formátech: JPEG, PNG, GIF a další. 

## **Přidání obrázků uložených lokálně do snímků**

Můžete přidat jeden nebo několik obrázků z vašeho počítače do snímku v prezentaci. Tento vzorový kód v C++ vám ukazuje, jak přidat obrázek do snímku:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Přidání obrázků z webu do snímků**

Pokud obrázek, který chcete přidat do snímku, není k dispozici ve vašem počítači, můžete jej přidat přímo z webu. 

Tento vzorový kód vám ukazuje, jak přidat obrázek z webu do snímku v C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Přidání obrázků do hlavních snímků (Slide Masters)**

Hlavní snímek (slide master) je nejvyšší snímek, který ukládá a řídí informace (motiv, rozvržení atd.) o všech snímcích pod ním. Proto když přidáte obrázek do hlavního snímku, tento obrázek se objeví na každém snímku pod tímto hlavním snímkem. 

Tento vzorový kód v C++ vám ukazuje, jak přidat obrázek do hlavního snímku:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Přidání obrázků jako pozadí snímku**

Můžete se rozhodnout použít obrázek jako pozadí pro konkrétní snímek nebo několik snímků. V takovém případě se podívejte na *[Nastavení obrázků jako pozadí snímků](https://docs.aspose.com/slides/cs/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Přidání SVG do prezentací**

Můžete přidat nebo vložit libovolný obrázek do prezentace pomocí metody [AddPictureFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9), která patří k rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_shape_collection). 

Pro vytvoření objektu obrázku založeného na SVG můžete postupovat následovně:

1. Vytvořte objekt SvgImage pro vložení do ImageShapeCollection
2. Vytvořte objekt PPImage z ISvgImage
3. Vytvořte objekt PictureFrame pomocí rozhraní IPPImage

Tento vzorový kód vám ukazuje, jak realizovat výše uvedené kroky pro přidání SVG obrázku do prezentace:
``` cpp 
// Cesta k adresáři dokumentů
System::String dataDir = u"D:\\Documents\\";

// Název zdrojového SVG souboru
System::String svgFileName = dataDir + u"sample.svg";

// Název výstupního souboru prezentace
System::String outPptxPath = dataDir + u"presentation.pptx";

// Vytvořit novou prezentaci
auto p = System::MakeObject<Presentation>();

// Načíst obsah SVG souboru
System::String svgContent = File::ReadAllText(svgFileName);

// Vytvořit objekt SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Vytvořit objekt PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Vytvoří nový PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Uložit prezentaci ve formátu PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **Převod SVG na sadu tvarů**

Konverze SVG na sadu tvarů v Aspose.Slides je podobná funkci PowerPointu používané pro práci s SVG obrázky:

![PowerPoint Popup Menu](img_01_01.png)

Funkčnost je poskytována jedním z přetížení metody [AddGroupShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_shape_collection), které jako první argument přijímá objekt [ISvgImage](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_svg_image). 

Tento vzorový kód vám ukazuje, jak použít popsanou metodu k převodu SVG souboru na sadu tvarů:
``` cpp 
// Cesta k adresáři dokumentů
System::String dataDir = u"D:\\Documents\\";

// Název zdrojového SVG souboru
System::String svgFileName = dataDir + u"sample.svg";

// Název výstupního souboru prezentace
System::String outPptxPath = dataDir + u"presentation.pptx";

// Vytvořit novou prezentaci
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// Načíst obsah SVG souboru
System::String svgContent = File::ReadAllText(svgFileName);

// Vytvořit objekt SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Získat velikost snímku
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Převést SVG obrázek na skupinu tvarů a přizpůsobit ji velikosti snímku
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Uložit prezentaci ve formátu PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Přidání obrázků jako EMF do snímků**

Aspose.Slides pro C++ vám umožňuje generovat EMF obrázky z tabulek Excel a přidávat tyto obrázky jako EMF do snímků pomocí Aspose.Cells. 

Tento vzorový kód vám ukazuje, jak provést popsaný úkol:
``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// Save the workbook to stream
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```

## **Nahrazení obrázků v kolekci obrázků**

Aspose.Slides vám umožňuje nahradit obrázky uložené v kolekci obrázků prezentace (včetně těch používaných tvary snímků). Tato sekce ukazuje několik přístupů k aktualizaci obrázků v kolekci. API poskytuje jednoduché metody pro nahrazení obrázku pomocí surových bajtových dat, instance [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) nebo jiného obrázku, který již v kolekci existuje.

Postupujte podle následujících kroků:
1. Načtěte soubor prezentace, který obsahuje obrázky, pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Načtěte nový obrázek ze souboru do pole bajtů.
3. Nahraďte cílový obrázek novým obrázkem pomocí pole bajtů.
4. Ve druhém přístupu načtěte obrázek do objektu [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) a nahraďte cílový obrázek tímto objektem.
5. Ve třetím přístupu nahraďte cílový obrázek obrázkem, který již v kolekci obrázků prezentace existuje.
6. Uložte upravenou prezentaci jako soubor PPTX.
```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// První způsob.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Druhý způsob.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Třetí způsob.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Uložte prezentaci do souboru.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Pomocí bezplatného konvertoru Aspose FREE [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) můžete snadno animovat texty, vytvářet GIFy z textů atd. 
{{% /alert %}}

## **FAQ**

**Zůstane původní rozlišení obrázku po vložení nezměněno?**  
Ano. Původní pixely jsou zachovány, ale konečný vzhled závisí na tom, jak je [obrázek](/slides/cs/cpp/picture-frame/) na snímku škálován a na případné kompresi při uložení.

**Jaký je nejlepší způsob, jak najednou nahradit stejné logo na desítkách snímků?**  
Umístěte logo na hlavní snímek nebo rozvržení a nahraďte jej v kolekci obrázků prezentace — aktualizace se projeví ve všech prvcích, které tento zdroj používají.

**Lze vložený SVG převést na editovatelné tvary?**  
Ano. SVG můžete převést na skupinu tvarů, po čemž jednotlivé části budou upravitelné pomocí standardních vlastností tvarů.

**Jak nastavit obrázek jako pozadí pro více snímků najednou?**  
[Přiřaďte obrázek jako pozadí](/slides/cs/cpp/presentation-background/) na hlavním snímku nebo příslušném rozvržení — všechny snímky používající tento hlavní snímek/rozvržení zdědí pozadí.

**Jak zabránit tomu, aby se prezentace „nafouklá“ kvůli mnoha obrázkům?**  
Opakovaně používejte jediný zdroj obrázku místo duplicit, zvolte rozumné rozlišení, aplikujte kompresi při ukládání a opakované grafiky umisťujte na hlavní snímek tam, kde to dává smysl.