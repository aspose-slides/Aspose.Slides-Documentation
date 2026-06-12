---
title: Optimaliseer Beeldbeheer in Presentaties met C++
linktitle: Beheer Afbeeldingen
type: docs
weight: 10
url: /nl/cpp/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- bitmap toevoegen
- afbeelding vervangen
- foto vervangen
- van internet
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- EMF toevoegen
- WMF toevoegen
- TIFF toevoegen
- PowerPoint
- OpenDocument
- presentatie
- EMF
- SVG
- C++
- Aspose.Slides
description: "Versnel het beheer van afbeeldingen in PowerPoint en OpenDocument met Aspose.Slides voor C++, optimaliseer de prestaties en automatiseer uw workflow."
---
## **Inleiding**

Afbeeldingen maken presentaties boeiender en interessanter. In Microsoft PowerPoint kunt u afbeeldingen invoegen vanaf een bestand, internet of andere locaties op dia's. Evenzo stelt Aspose.Slides u in staat afbeeldingen toe te voegen aan dia's in uw presentaties via verschillende procedures. 

{{% alert title="Tip" color="primary" %}} 
Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die mensen in staat stellen snel presentaties te maken vanuit afbeeldingen. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Als u een afbeelding wilt toevoegen als een frame‑object—vooral wanneer u van plan bent standaard opmaakopties te gebruiken om de grootte te wijzigen, effecten toe te voegen, enzovoort—zie [Beeldframe](/slides/nl/cpp/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
U kunt in‑ en uitvoerbewerkingen met afbeeldingen en PowerPoint‑presentaties manipuleren om een afbeelding van het ene formaat naar het andere te converteren. Zie de volgende pagina’s: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/cpp/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/cpp/conversion/jpg-to-png/); converteer [PNG naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/cpp/conversion/png-to-svg/); converteer [SVG naar PNG](https://products.aspose.com/slides/nl/cpp/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides ondersteunt bewerkingen met afbeeldingen in deze populaire formaten: JPEG, PNG, GIF en andere. 

## **Afbeeldingen lokaal toevoegen aan dia's**

U kunt één of meerdere afbeeldingen van uw computer aan een dia in een presentatie toevoegen. Deze voorbeeldcode in C++ laat zien hoe u een afbeelding aan een dia toevoegt:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Afbeeldingen van het web toevoegen aan dia's**

Als de afbeelding die u aan een dia wilt toevoegen niet op uw computer beschikbaar is, kunt u de afbeelding rechtstreeks van het internet toevoegen. 

Deze voorbeeldcode laat zien hoe u een afbeelding van het internet aan een dia toevoegt in C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Afbeeldingen toevoegen aan dia‑master**

Een dia‑master is de bovenliggende dia die informatie (thema, lay‑out, enz.) over alle onderliggende dia's opslaat en beheert. Dus wanneer u een afbeelding aan een dia‑master toevoegt, verschijnt die afbeelding op elke dia die onder die master valt. 

Deze C++‑voorbeeldcode laat zien hoe u een afbeelding aan een dia‑master toevoegt:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Afbeeldingen gebruiken als dia‑achtergrond**

U kunt ervoor kiezen een afbeelding als achtergrond voor een specifieke dia of meerdere dia's te gebruiken. In dat geval moet u *[Instellen van afbeeldingen als achtergrond voor dia's](https://docs.aspose.com/slides/nl/cpp/presentation-background/#setting-images-as-background-for-slides)* bekijken.

## **SVG toevoegen aan presentaties**

U kunt elke afbeelding toevoegen of invoegen in een presentatie met behulp van de methode [AddPictureFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) die behoort tot de interface [IShapeCollection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_shape_collection).

Om een afbeeldingsobject op basis van een SVG‑afbeelding te maken, kunt u dit op deze manier doen:

1. Maak een SvgImage‑object om het in de ImageShapeCollection in te voegen
2. Maak een PPImage‑object van ISvgImage
3. Maak een PictureFrame‑object met behulp van de IPPImage‑interface

Deze voorbeeldcode laat zien hoe u de bovenstaande stappen implementeert om een SVG‑afbeelding aan een presentatie toe te voegen:
``` cpp 
// Het pad naar de documentenmap
System::String dataDir = u"D:\\Documents\\";

// Bron SVG-bestandsnaam
System::String svgFileName = dataDir + u"sample.svg";

// Uitvoerbestand voor presentatie
System::String outPptxPath = dataDir + u"presentation.pptx";

// Nieuwe presentatie maken
auto p = System::MakeObject<Presentation>();

// SVG-bestandsinhoud lezen
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImage-object maken
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// PPImage-object maken
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Maak een nieuw PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Presentatie opslaan in PPTX-formaat
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **SVG converteren naar een set vormen**

De conversie van SVG naar een set vormen in Aspose.Slides is vergelijkbaar met de functionaliteit van PowerPoint voor het werken met SVG‑afbeeldingen:

![PowerPoint Popup Menu](img_01_01.png)

Deze functionaliteit wordt geleverd door één van de overloads van de methode [AddGroupShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) van de interface [IShapeCollection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_shape_collection) die een [ISvgImage](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_svg_image)‑object als eerste argument neemt.

Deze voorbeeldcode laat zien hoe u de beschreven methode gebruikt om een SVG‑bestand te converteren naar een set vormen:
``` cpp 
// Het pad naar de documentenmap
System::String dataDir = u"D:\\Documents\\";

// Bron SVG-bestandsnaam
System::String svgFileName = dataDir + u"sample.svg";

// Uitvoerbestandsnaam voor presentatie
System::String outPptxPath = dataDir + u"presentation.pptx";

// Nieuwe presentatie maken
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// SVG-bestandsinhoud lezen
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImage-object maken
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Diaformaat ophalen
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Converteer SVG-afbeelding naar een groep vormen door deze te schalen naar diaformaat
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Presentatie opslaan in PPTX-formaat
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Afbeeldingen als EMF aan dia's toevoegen**

Aspose.Slides voor C++ stelt u in staat EMF‑afbeeldingen te genereren uit Excel‑bladen en de afbeeldingen als EMF aan dia's toe te voegen met Aspose.Cells. 

Deze voorbeeldcode laat zien hoe u de beschreven taak uitvoert:
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

## **Afbeeldingen vervangen in de afbeeldingcollectie**

Aspose.Slides stelt u in staat afbeeldingen die zijn opgeslagen in de afbeeldingcollectie van een presentatie (inclusief die gebruikt door dia‑vormen) te vervangen. Deze sectie toont verschillende benaderingen om afbeeldingen in de collectie bij te werken. De API biedt eenvoudige methoden om een afbeelding te vervangen met ruwe byte‑data, een [IImage]‑instantie of een andere afbeelding die al in de collectie bestaat.

1. Laad het presentatie‑bestand dat afbeeldingen bevat met de klasse [Presentation].
2. Laad een nieuwe afbeelding vanuit een bestand in een byte‑array.
3. Vervang de doelafbeelding door de nieuwe afbeelding met behulp van de byte‑array.
4. In de tweede benadering laadt u de afbeelding in een [IImage]‑object en vervangt u de doelafbeelding door dat object.
5. In de derde benadering vervangt u de doelafbeelding door een afbeelding die al bestaat in de afbeeldingcollectie van de presentatie.
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```cpp
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// De eerste manier.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// De tweede manier.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// De derde manier.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Sla de presentatie op in een bestand.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Met de GRATIS Aspose [Text to GIF] converter kunt u eenvoudig teksten animeren, GIF‑bestanden van teksten maken, enz.
{{% /alert %}}

## **FAQ**

**Blijft de oorspronkelijke beeldresolutie intact na invoegen?**

Ja. De oorspronkelijke pixels worden behouden, maar het uiteindelijke uiterlijk hangt af van hoe de [picture] op de dia wordt geschaald en van eventuele compressie bij het opslaan.

**Wat is de beste manier om hetzelfde logo in tientallen dia's tegelijk te vervangen?**

Plaats het logo op de master‑dia of een lay‑out en vervang het in de afbeeldingcollectie van de presentatie—wijzigingen worden doorgevoerd naar alle elementen die die bron gebruiken.

**Kan een ingevoegde SVG worden omgezet in bewerkbare vormen?**

Ja. U kunt een SVG converteren naar een groep vormen, waarna individuele onderdelen bewerkbaar worden met standaard vorm‑eigenschappen.

**Hoe kan ik een afbeelding in één keer als achtergrond voor meerdere dia's instellen?**

Wijs de afbeelding toe als achtergrond op de master‑dia of de desbetreffende lay‑out—alle dia's die die master/lay‑out gebruiken, nemen de achtergrond over.

**Hoe voorkom ik dat de presentatie enorm in omvang groeit door veel afbeeldingen?**

Herbruik één enkele afbeeldingsbron in plaats van duplicaten, kies een redelijke resolutie, pas compressie toe bij het opslaan en houd herhaalde grafieken op de master waar gepast.