---
title: "Képek kezelése a prezentációkban C++-szal optimalizálva"
linktitle: "Képek kezelése"
type: docs
weight: 10
url: /hu/cpp/image/
keywords:
- "kép hozzáadása"
- "grafika hozzáadása"
- "bitmap hozzáadása"
- "kép cseréje"
- "grafika cseréje"
- "webről"
- "háttér"
- "PNG hozzáadása"
- "JPG hozzáadása"
- "SVG hozzáadása"
- "EMF hozzáadása"
- "WMF hozzáadása"
- "TIFF hozzáadása"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "EMF"
- "SVG"
- "C++"
- "Aspose.Slides"
description: "Egyszerűsítse a képek kezelését a PowerPoint és OpenDocument formátumokban az Aspose.Slides for C++ segítségével, javítva a teljesítményt és automatizálva a munkafolyamatot."
---
## **Bevezetés**

A képek élénkebbé és érdekesebbé teszik a prezentációkat. A Microsoft PowerPointban képeket szúrhat be fájlból, az internetről vagy más helyekről a diákra. Hasonlóképpen az Aspose.Slides lehetővé teszi, hogy képeket adjon hozzá a prezentációk diáihoz különböző eljárásokon keresztül. 

{{% alert title="Tip" color="primary" %}} 

Az Aspose ingyenes konvertereket biztosít – [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) –, amelyek lehetővé teszik, hogy a felhasználók gyorsan prezentációkat hozzanak létre képekből. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Ha képet szeretne keretobjektumként hozzáadni – különösen, ha a képre szabványos formázási lehetőségeket kíván alkalmazni a méret módosításához, effektusok hozzáadásához stb. – tekintse meg a [Képkocka](/slides/hu/cpp/picture-frame/) oldalát. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Képek és PowerPoint prezentációk közötti be- és kimeneti műveleteket kezelhet, hogy egy képet egy formátumból a másikba konvertáljon. Lásd ezeket az oldalakat: konvertálás [kép JPG‑re](https://products.aspose.com/slides/hu/cpp/conversion/image-to-jpg/); konvertálás [JPG képre](https://products.aspose.com/slides/hu/cpp/conversion/jpg-to-image/); konvertálás [JPG‑ról PNG‑ra](https://products.aspose.com/slides/hu/cpp/conversion/jpg-to-png/), konvertálás [PNG‑ról JPG‑ra](https://products.aspose.com/slides/hu/cpp/conversion/png-to-jpg/); konvertálás [PNG‑ról SVG‑ra](https://products.aspose.com/slides/hu/cpp/conversion/png-to-svg/), konvertálás [SVG‑ról PNG‑ra](https://products.aspose.com/slides/hu/cpp/conversion/svg-to-png/).

{{% /alert %}}

Az Aspose.Slides támogatja a képekkel végzett műveleteket a következő népszerű formátumokban: JPEG, PNG, GIF és egyebek. 

## **Képek helyi tárolásból való hozzáadása a diákhoz**

A számítógépén tárolt egy vagy több képet hozzáadhatja a prezentáció egy diájához. Az alábbi C++ példakód megmutatja, hogyan lehet képet adni egy diához:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Képek hozzáadása a webről a diákhoz**

Ha a kívánt kép nincs a számítógépén, közvetlenül a webről adhatja hozzá a diához. 

Ez a példakód megmutatja, hogyan adhat hozzá egy képet a webről egy diához C++‑ban:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Képek hozzáadása dia mesterekhez**

A dia mester a legfelső dia, amely tárolja és vezérli az összes alatta lévő dia információit (téma, elrendezés stb.). Így, amikor egy képet ad hozzá egy dia mesterhez, az a kép minden alatta lévő dián megjelenik. 

Ez a C++ példakód megmutatja, hogyan adhat hozzá egy képet egy dia mesterhez:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Képek hozzáadása diák háttérként**

Előfordulhat, hogy egy képet szeretne háttérként használni egy adott dián vagy több dián. Ebben az esetben tekintse meg a *[Képek beállítása diák háttereként](https://docs.aspose.com/slides/hu/cpp/presentation-background/#setting-images-as-background-for-slides)* oldalt.

## **SVG hozzáadása prezentációkhoz**
Bármilyen képet hozzáadhat vagy beilleszthet egy prezentációba az [AddPictureFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) metódussal, amely az [IShapeCollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_shape_collection) interfészhez tartozik.

Az SVG képen alapuló képobjektus létrehozásához a következő módon járhat el:

1. Hozzon létre egy **SvgImage** objektumot, hogy beillessze az **ImageShapeCollection**‑be.
2. Hozzon létre egy **PPImage** objektumot az **ISvgImage**‑ből.
3. Hozzon létre egy **PictureFrame** objektumot az **IPPImage** interfész használatával.

Ez a példakód megmutatja, hogyan valósítható meg a fenti lépések egy SVG kép prezentációba való hozzáadásához:
``` cpp 
// A dokumentumok könyvtárának útvonala
System::String dataDir = u"D:\\Documents\\";

// A forrás SVG fájl neve
System::String svgFileName = dataDir + u"sample.svg";

// A kimeneti prezentáció fájl neve
System::String outPptxPath = dataDir + u"presentation.pptx";

// Új prezentáció létrehozása
auto p = System::MakeObject<Presentation>();

// SVG fájl tartalmának beolvasása
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImage objektum létrehozása
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// PPImage objektum létrehozása
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Új PictureFrame létrehozása 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Prezentáció mentése PPTX formátumban
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **SVG konvertálása alakzatkészletre**
Az Aspose.Slides SVG‑ről alakzatkészletre történő konvertálása hasonló a PowerPoint SVG‑képekkel való munkára szolgáló funkciójához:


![PowerPoint Popup Menu](img_01_01.png)

A funkciót a [AddGroupShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) metódus egyik túlterhelése biztosítja az [IShapeCollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_shape_collection) interfészen, amely első argumentumként egy **ISvgImage** objektumot vár.

Ez a példakód megmutatja, hogyan használja a leírt metódust egy SVG fájl alakzatkészletté konvertálásához:

``` cpp 
// A dokumentumok könyvtárának útvonala
System::String dataDir = u"D:\\Documents\\";

// A forrás SVG fájl neve
System::String svgFileName = dataDir + u"sample.svg";

// A kimeneti prezentáció fájl neve
System::String outPptxPath = dataDir + u"presentation.pptx";

// Új prezentáció létrehozása
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// SVG fájl tartalmának beolvasása
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImage objektum létrehozása
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Dia méretének lekérése
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// SVG képet alakzatcsoporttá konvertálása, a dia méretére skálázva
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Prezentáció mentése PPTX formátumban
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Képek hozzáadása EMF‑ként a diákhoz**
Az Aspose.Slides for C++ lehetővé teszi, hogy Excel‑lapokból EMF képeket generáljon, majd ezeket az EMF képeket az Aspose.Cells segítségével a diákba illessze. 

Ez a példakód megmutatja, hogyan hajtható végre a leírt feladat:

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

## **Képek cseréje a képgyűjteményben**

Az Aspose.Slides lehetővé teszi a prezentáció képgyűjteményében (beleértve a dia alakzatok által használt képeket is) tárolt képek cseréjét. Ez a szakasz több megközelítést mutat be a gyűjteményben lévő képek frissítésére. Az API egyszerű módszereket kínál a kép cseréjére nyers bájtadatok, egy [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) példány vagy egy már a gyűjteményben létező másik kép használatával.

Kövesse az alábbi lépéseket:

1. Töltse be a képeket tartalmazó prezentációs fájlt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztállyal.
2. Töltsön be egy új képet fájlból egy bájt tömbbe.
3. Cserélje le a célképet az új képre a bájt tömb használatával.
4. A második megközelítésben töltse be a képet egy [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) objektumba, majd cserélje le a célképet ezzel az objektummal.
5. A harmadik megközelítésben cserélje le a célképet egy olyan képpel, amely már létezik a prezentáció képgyűjteményében.
6. Írja a módosított prezentációt PPTX fájlként.

```cpp
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Az első mód.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// A második mód.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// A harmadik mód.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Mentse a prezentációt egy fájlba.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Az Aspose INGYENES [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konverterével könnyedén animálhat szövegeket, GIF‑eket készíthet szövegekből stb. 

{{% /alert %}}

## **GYIK**

**Megmarad az eredeti kép felbontása a beszúrás után?**

Igen. A forráspixelek megmaradnak, de a végső megjelenés attól függ, hogy a [kép](/slides/hu/cpp/picture-frame/) hogyan van méretezve a dián, és milyen tömörítést alkalmaznak mentéskor.

**Mi a legjobb módja annak, hogy egyszerre több tucat dián cseréljük le ugyanazt a logót?**

Helyezze a logót a mesterdiára vagy egy elrendezésre, és cserélje le a prezentáció képgyűjteményében – a frissítés minden olyan elemre kiterjed, amely azt a forrást használja.

**Átalakítható‑e egy beillesztett SVG szerkeszthető alakzatokká?**

Igen. Az SVG‑t konvertálhatja alakzatcsoporttá, majd az egyes részek szerkeszthetők lesznek a szokásos alakzattulajdonságokkal.

**Hogyan állíthatom be egy képet háttérként több diára egyszerre?**

[Állítsa be a képet háttérnek](/slides/hu/cpp/presentation-background/) a mesterdián vagy a megfelelő elrendezésen – a master/​layout‑ot használó diák öröklik a hátteret.

**Hogyan kerülhetem el, hogy a prezentáció sok kép miatt „fellő” a méretét?**

Használjon egyetlen képforrást a másolatok helyett, válasszon megfelelő felbontást, alkalmazzon tömörítést mentéskor, és ismétlődő grafikákat tegyen a mesterre, ahol indokolt.