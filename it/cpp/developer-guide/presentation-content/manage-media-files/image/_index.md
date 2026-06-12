---
title: Ottimizzare la gestione delle immagini nelle presentazioni usando C++
linktitle: Gestire le immagini
type: docs
weight: 10
url: /it/cpp/image/
keywords:
- aggiungere immagine
- aggiungere foto
- aggiungere bitmap
- sostituire immagine
- sostituire foto
- dal web
- sfondo
- aggiungere PNG
- aggiungere JPG
- aggiungere SVG
- aggiungere EMF
- aggiungere WMF
- aggiungere TIFF
- PowerPoint
- OpenDocument
- presentazione
- EMF
- SVG
- C++
- Aspose.Slides
description: "Ottimizza la gestione delle immagini in PowerPoint e OpenDocument con Aspose.Slides per C++, migliorando le prestazioni e automatizzando il tuo flusso di lavoro."
---
## **Introduzione**

Le immagini rendono le presentazioni più coinvolgenti e interessanti. In Microsoft PowerPoint, è possibile inserire immagini da un file, da Internet o da altre posizioni nelle diapositive. Analogamente, Aspose.Slides consente di aggiungere immagini alle diapositive delle proprie presentazioni tramite diverse procedure. 

{{% alert title="Tip" color="primary" %}} 

Aspose fornisce convertitori gratuiti—[JPEG to PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare presentazioni rapidamente a partire dalle immagini. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Se desideri aggiungere un'immagine come oggetto cornice—soprattutto se prevedi di utilizzare le opzioni di formattazione standard per modificarne le dimensioni, aggiungere effetti, ecc.—vedi [Picture Frame](/slides/it/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

È possibile manipolare le operazioni di input/output che coinvolgono immagini e presentazioni PowerPoint per convertire un'immagine da un formato all'altro. Consulta queste pagine: converti [image to JPG](https://products.aspose.com/slides/it/cpp/conversion/image-to-jpg/); converti [JPG to image](https://products.aspose.com/slides/it/cpp/conversion/jpg-to-image/); converti [JPG to PNG](https://products.aspose.com/slides/it/cpp/conversion/jpg-to-png/), converti [PNG to JPG](https://products.aspose.com/slides/it/cpp/conversion/png-to-jpg/); converti [PNG to SVG](https://products.aspose.com/slides/it/cpp/conversion/png-to-svg/), converti [SVG to PNG](https://products.aspose.com/slides/it/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides supporta operazioni con immagini in questi formati popolari: JPEG, PNG, GIF e altri. 

## **Aggiungere Immagini Memorizzate Localmente alle Diapositive**

È possibile aggiungere una o più immagini presenti sul proprio computer a una diapositiva di una presentazione. Questo esempio di codice in C++ mostra come aggiungere un'immagine a una diapositiva:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Aggiungere Immagini dal Web alle Diapositive**

Se l'immagine che desideri aggiungere a una diapositiva non è disponibile sul tuo computer, è possibile aggiungere l'immagine direttamente dal web. 

Questo esempio di codice mostra come aggiungere un'immagine dal web a una diapositiva in C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Aggiungere Immagini ai Master delle Diapositive**

Un master della diapositiva è la diapositiva principale che memorizza e controlla le informazioni (tema, layout, ecc.) di tutte le diapositive sottostanti. Pertanto, quando aggiungi un'immagine a un master della diapositiva, tale immagine appare su ogni diapositiva sotto quel master. 

Questo esempio di codice C++ mostra come aggiungere un'immagine a un master della diapositiva:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Aggiungere Immagini come Sfondo delle Diapositive**

Potresti decidere di utilizzare un'immagine come sfondo per una diapositiva specifica o per più diapositive. In tal caso, devi consultare *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/it/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Aggiungere SVG alle Presentazioni**
È possibile aggiungere o inserire qualsiasi immagine in una presentazione utilizzando il metodo [AddPictureFrame](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) appartenente all'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_shape_collection).

Per creare un oggetto immagine basato su un'immagine SVG, è possibile procedere in questo modo:

1. Crea un oggetto SvgImage da inserire in ImageShapeCollection
2. Crea un oggetto PPImage da ISvgImage
3. Crea un oggetto PictureFrame utilizzando l'interfaccia IPPImage

Questo esempio di codice mostra come implementare i passaggi precedenti per aggiungere un'immagine SVG in una presentazione:
``` cpp 
// Il percorso della directory dei documenti
System::String dataDir = u"D:\\Documents\\";

// Nome file SVG di origine
System::String svgFileName = dataDir + u"sample.svg";

// Nome file della presentazione di output
System::String outPptxPath = dataDir + u"presentation.pptx";

// Crea una nuova presentazione
auto p = System::MakeObject<Presentation>();

// Leggi il contenuto del file SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Crea oggetto SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Crea oggetto PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Crea un nuovo PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Salva la presentazione in formato PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **Convertire SVG in un Set di Forme**
La conversione di SVG in un set di forme di Aspose.Slides è simile alla funzionalità di PowerPoint utilizzata per lavorare con immagini SVG:

![PowerPoint Popup Menu](img_01_01.png)

La funzionalità è fornita da una delle sovraccariche del metodo [AddGroupShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) dell'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_shape_collection) che accetta un oggetto [ISvgImage](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_svg_image) come primo argomento.

Questo esempio di codice mostra come utilizzare il metodo descritto per convertire un file SVG in un set di forme:

``` cpp 
// Il percorso della directory dei documenti
System::String dataDir = u"D:\\Documents\\";

// Nome file SVG di origine
System::String svgFileName = dataDir + u"sample.svg";

// Nome file della presentazione di output
System::String outPptxPath = dataDir + u"presentation.pptx";

// Crea una nuova presentazione
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// Leggi il contenuto del file SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Crea oggetto SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Ottieni dimensione della diapositiva
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Converti l'immagine SVG in un gruppo di forme scalandola alla dimensione della diapositiva
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Salva la presentazione in formato PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Aggiungere Immagini come EMF alle Diapositive**
Aspose.Slides per C++ consente di generare immagini EMF da fogli Excel e aggiungere le immagini come EMF nelle diapositive con Aspose.Cells. 

Questo esempio di codice mostra come eseguire l'operazione descritta:

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

// Salva la cartella di lavoro nello stream
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

## **Sostituire Immagini nella Raccolta di Immagini**

Aspose.Slides consente di sostituire le immagini memorizzate nella raccolta di immagini di una presentazione (comprese quelle utilizzate dalle forme delle diapositive). Questa sezione mostra diversi approcci per aggiornare le immagini nella raccolta. L'API fornisce metodi semplici per sostituire un'immagine utilizzando dati byte grezzi, un'istanza [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/), o un'altra immagine già presente nella raccolta.

1. Carica il file di presentazione che contiene le immagini utilizzando la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Carica una nuova immagine da un file in un array di byte.
3. Sostituisci l'immagine di destinazione con la nuova immagine utilizzando l'array di byte.
4. Nel secondo approccio, carica l'immagine in un oggetto [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) e sostituisci l'immagine di destinazione con quell'oggetto.
5. Nel terzo approccio, sostituisci l'immagine di destinazione con un'immagine già presente nella raccolta di immagini della presentazione.
6. Scrivi la presentazione modificata come file PPTX.

```cpp
// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Il primo modo.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Il secondo modo.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Il terzo modo.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Salva la presentazione su un file.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Utilizzando il convertitore GRATUITO Aspose [Text to GIF](https://products.aspose.app/slides/it/text-to-gif), è possibile animare facilmente testi, creare GIF da testi, ecc. 

{{% /alert %}}

## **FAQ**

**La risoluzione originale dell'immagine rimane intatta dopo l'inserimento?**

Sì. I pixel originali vengono conservati, ma l'aspetto finale dipende da come l[**picture**](/slides/it/cpp/picture-frame/) viene scalato nella diapositiva e da eventuali compressioni applicate al salvataggio.

**Qual è il modo migliore per sostituire lo stesso logo in decine di diapositive contemporaneamente?**

Posiziona il logo sul master della diapositiva o su un layout e sostituirlo nella raccolta di immagini della presentazione: gli aggiornamenti si propagheranno a tutti gli elementi che utilizzano quella risorsa.

**Un SVG inserito può essere convertito in forme modificabili?**

Sì. È possibile convertire un SVG in un gruppo di forme, dopo di che le singole parti diventano modificabili con le proprietà standard delle forme.

**Come posso impostare un'immagine come sfondo per più diapositive contemporaneamente?**

[Assegna l'immagine come sfondo](/slides/it/cpp/presentation-background/) sul master della diapositiva o sul layout pertinente: tutte le diapositive che utilizzano quel master/layout erediteranno lo sfondo.

**Come evito che la presentazione aumenti di dimensione a causa di molte immagini?**

Riutilizza una singola risorsa immagine invece di duplicati, scegli risoluzioni ragionevoli, applica la compressione al salvataggio e mantieni le grafiche ripetute sul master, dove opportuno.