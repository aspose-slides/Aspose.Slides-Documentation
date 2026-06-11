---
title: Optimera bildhantering i presentationer med C++
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/cpp/image/
keywords:
- lägga till bild
- lägga till bild
- lägga till bitmap
- ersätta bild
- ersätta bild
- från webben
- bakgrund
- lägga till PNG
- lägga till JPG
- lägga till SVG
- lägga till EMF
- lägga till WMF
- lägga till TIFF
- PowerPoint
- OpenDocument
- presentation
- EMF
- SVG
- C++
- Aspose.Slides
description: "Strömlinjeforma bildhantering i PowerPoint och OpenDocument med Aspose.Slides för C++, optimera prestanda och automatisera ditt arbetsflöde."
---
## **Introduktion**

Bilder gör presentationer mer engagerande och intressanta. I Microsoft PowerPoint kan du infoga bilder från en fil, internet eller andra platser på bilder. På samma sätt låter Aspose.Slides dig lägga till bilder på bilder i dina presentationer genom olika metoder. 

{{% alert title="Tip" color="primary" %}} 
Aspose erbjuder gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som gör det möjligt för användare att snabbt skapa presentationer från bilder. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Om du vill lägga till en bild som ett ramobjekt—särskilt om du planerar att använda standardformateringsalternativ för att ändra dess storlek, lägga till effekter osv—se [Picture Frame](/slides/sv/cpp/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Du kan manipulera in-/utdataoperationer som involverar bilder och PowerPoint-presentationer för att konvertera en bild från ett format till ett annat. Se dessa sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/cpp/conversion/image-to-jpg/); konvertera [JPG till bild](https://products.aspose.com/slides/sv/cpp/conversion/jpg-to-image/); konvertera [JPG till PNG](https://products.aspose.com/slides/sv/cpp/conversion/jpg-to-png/), konvertera [PNG till JPG](https://products.aspose.com/slides/sv/cpp/conversion/png-to-jpg/); konvertera [PNG till SVG](https://products.aspose.com/slides/sv/cpp/conversion/png-to-svg/), konvertera [SVG till PNG](https://products.aspose.com/slides/sv/cpp/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides stöder operationer med bilder i dessa populära format: JPEG, PNG, GIF och andra. 

## **Lägg till bilder lagrade lokalt på bilder**

Du kan lägga till en eller flera bilder från din dator på en bild i en presentation. Den här exempelkoden i C++ visar hur du lägger till en bild på en bild:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Lägg till bilder från webben på bilder**

Om bilden du vill lägga till på en bild inte finns på din dator kan du lägga till bilden direkt från webben.

Den här exempelkoden visar hur du lägger till en bild från webben på en bild i C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Lägg till bilder på bildmaster**

En bildmaster är den översta bilden som lagrar och styr information (tema, layout osv.) om alla bilder under den. Således, när du lägger till en bild på en bildmaster, visas den bilden på varje bild under den bildmastern. 

Den här C++-exempelkoden visar hur du lägger till en bild på en bildmaster:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Lägg till bilder som bildbakgrunder**

Du kan välja att använda en bild som bakgrund för en specifik bild eller flera bilder. I så fall måste du se *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/sv/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Lägg till SVG i presentationer**
Du kan lägga till eller infoga vilken bild som helst i en presentation genom att använda metoden [AddPictureFrame](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) som tillhör gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_shape_collection).

För att skapa ett bildobjekt baserat på en SVG-bild kan du göra så här:

1. Skapa SvgImage-objekt för att infoga det i ImageShapeCollection
2. Skapa PPImage-objekt från ISvgImage
3. Skapa PictureFrame-objekt med IPPImage-gränssnittet

Den här exempelkoden visar hur du implementerar stegen ovan för att lägga till en SVG-bild i en presentation:
``` cpp 
// Sökvägen till dokumentkatalogen
System::String dataDir = u"D:\\Documents\\";

// Källfilnamn för SVG
System::String svgFileName = dataDir + u"sample.svg";

// Utdatafilnamn för presentationen
System::String outPptxPath = dataDir + u"presentation.pptx";

// Skapa ny presentation
auto p = System::MakeObject<Presentation>();

// Läs SVG-filens innehåll
System::String svgContent = File::ReadAllText(svgFileName);

// Skapa SvgImage-objekt
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Skapa PPImage-objekt
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Skapar en ny PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Spara presentation i PPTX-format
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **Konvertera SVG till en mängd former**
Aspose.Slides konvertering av SVG till en mängd former är liknande PowerPoint-funktionen som används för att arbeta med SVG-bilder:

![PowerPoint Popup Menu](img_01_01.png)

Funktionen tillhandahålls av en av overloads av metoden [AddGroupShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) i gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_shape_collection) som tar ett [ISvgImage](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_svg_image)-objekt som första argument.

Den här exempelkoden visar hur du använder den beskrivna metoden för att konvertera en SVG-fil till en mängd former:

``` cpp 
// Sökvägen till dokumentkatalogen
System::String dataDir = u"D:\\Documents\\";

// Källfilnamn för SVG
System::String svgFileName = dataDir + u"sample.svg";

// Utdatafilnamn för presentationen
System::String outPptxPath = dataDir + u"presentation.pptx";

// Skapa ny presentation
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// Läs SVG-filens innehåll
System::String svgContent = File::ReadAllText(svgFileName);

// Skapa SvgImage-objekt
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Hämta bildstorlek
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Konvertera SVG-bild till en grupp av former och skala den till bildens storlek
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Spara presentation i PPTX-format
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Lägg till bilder som EMF på bilder**
Aspose.Slides för C++ låter dig skapa EMF-bilder från Excel-ark och lägga till bilderna som EMF på bilder med Aspose.Cells. 

Den här exempelkoden visar hur du utför den beskrivna uppgiften:

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

## **Byt ut bilder i bildsamlingen**

Aspose.Slides låter dig ersätta bilder som lagras i en presentations bildsamling (inklusive de som används av bildformer). Detta avsnitt visar flera tillvägagångssätt för att uppdatera bilder i samlingen. API:et erbjuder enkla metoder för att ersätta en bild med rå byte‑data, en [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/)-instans eller en annan bild som redan finns i samlingen.

Följ stegen nedan:

1. Ladda presentationsfilen som innehåller bilder med klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Läs in en ny bild från en fil till en byte‑array.
3. Ersätt mål‑bilden med den nya bilden med hjälp av byte‑arrayen.
4. I det andra tillvägagångssättet läses bilden in i ett [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/)-objekt och mål‑bilden ersätts med det objektet.
5. I det tredje tillvägagångssättet ersätts mål‑bilden med en bild som redan finns i presentationens bildsamling.
6. Spara den modifierade presentationen som en PPTX‑fil.

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Det första sättet.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Det andra sättet.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Det tredje sättet.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Spara presentationen till en fil.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Genom att använda Aspose GRATIS [Text to GIF](https://products.aspose.app/slides/sv/text-to-gif)-konverteraren kan du enkelt animera texter, skapa GIF‑filer från texter osv. 
{{% /alert %}}

## **FAQ**

**Behåller den ursprungliga bildupplösningen sin integritet efter infogning?**

Ja. Källpixlarna bevaras, men det slutgiltiga utseendet beror på hur [picture](/slides/sv/cpp/picture-frame/) skalas på bilden och eventuell kompression som tillämpas vid sparande.

**Vad är det bästa sättet att ersätta samma logotyp på dussintals bilder på en gång?**

Placera logotypen på mastern eller en layout och ersätt den i presentationens bildsamling — uppdateringar sprids till alla element som använder den resursen.

**Kan en infogad SVG konverteras till redigerbara former?**

Ja. Du kan konvertera en SVG till en grupp av former, varpå enskilda delar blir redigerbara med standardformsegenskaper.

**Hur kan jag ställa in en bild som bakgrund för flera bilder på en gång?**

[Assign the image as the background](/slides/sv/cpp/presentation-background/) på master‑bilden eller den relevanta layouten — alla bilder som använder den masteren/layouten kommer att ärva bakgrunden.

**Hur förhindrar jag att presentationen växer kraftigt i storlek på grund av många bilder?**

Återanvänd en enda bildresurs istället för dubletter, välj rimliga upplösningar, tillämpa kompression vid sparande och behåll återkommande grafik på master‑sidan där det är lämpligt.