---
title: Gestisci i frame immagine nelle presentazioni usando C++
linktitle: Frame immagine
type: docs
weight: 10
url: /it/cpp/picture-frame/
keywords:
- frame immagine
- aggiungi frame immagine
- crea frame immagine
- aggiungi immagine
- crea immagine
- estrai immagine
- immagine raster
- immagine vettoriale
- ritaglia immagine
- area ritagliata
- proprietà StretchOff
- formattazione del frame immagine
- proprietà del frame immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- trasparenza immagine
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Aggiungi frame immagine a presentazioni PowerPoint e OpenDocument con Aspose.Slides per C++. Semplifica il tuo flusso di lavoro e migliora il design delle diapositive."
---
## **Introduzione**

Un frame immagine è una forma che contiene un'immagine—è come un'immagine in una cornice.  

Puoi aggiungere un'immagine a una diapositiva tramite un frame immagine. In questo modo, puoi formattare l'immagine formattando il frame immagine.

{{% alert title="Suggerimento" color="primary" %}} 
Aspose fornisce convertitori gratuiti—[JPEG to PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare presentazioni rapidamente a partire dalle immagini. 
{{% /alert %}} 

## **Creare un frame immagine**

1. Crea un'istanza della [Presentation class](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
2. Ottieni un riferimento a una diapositiva tramite il suo indice. 
3. Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_p_p_image) aggiungendo un'immagine alla [IImagescollection](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_image_collection) associata all'oggetto presentazione che verrà utilizzato per riempire la forma.
4. Specifica la larghezza e l'altezza dell'immagine.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.picture_frame) basato sulla larghezza e altezza dell'immagine tramite il metodo `AddPictureFrame` esposto dall'oggetto forma associato alla diapositiva di riferimento.
6. Aggiungi un frame immagine (contenente l'immagine) alla diapositiva.
7. Scrivi la presentazione modificata come file PPTX.

Questo codice C++ mostra come creare un frame immagine:

```c++
// Il percorso della directory dei documenti.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Carica la presentazione desiderata.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede alla prima diapositiva.
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Carica l'immagine che verrà aggiunta alla collezione di immagini della presentazione.
// Ottiene l'immagine.
auto image = Images::FromFile(filePath);

// Aggiunge un'immagine alla collezione di immagini della presentazione.
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Aggiunge un frame immagine alla diapositiva.
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Imposta la larghezza e l'altezza della scala relativa.
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Applica alcune formattazioni al PictureFrame.
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//Scrive il file PPTX su disco.
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
I frame immagine consentono di creare rapidamente diapositive di presentazione basate su immagini. Quando combini il frame immagine con le opzioni di salvataggio di Aspose.Slides, puoi manipolare le operazioni di input/output per convertire le immagini da un formato all'altro. Potresti voler consultare queste pagine: converti [image to JPG](https://products.aspose.com/slides/it/cpp/conversion/image-to-jpg/); converti [JPG to image](https://products.aspose.com/slides/it/cpp/conversion/jpg-to-image/); converti [JPG to PNG](https://products.aspose.com/slides/it/cpp/conversion/jpg-to-png/), converti [PNG to JPG](https://products.aspose.com/slides/it/cpp/conversion/png-to-jpg/); converti [PNG to SVG](https://products.aspose.com/slides/it/cpp/conversion/png-to-svg/), converti [SVG to PNG](https://products.aspose.com/slides/it/cpp/conversion/svg-to-png/).
{{% /alert %}}

## **Creare un frame immagine con scala relativa**

Modificando la scala relativa di un'immagine, è possibile creare un frame immagine più complesso. 

1. Crea un'istanza della [Presentation class](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
2. Ottieni un riferimento a una diapositiva tramite il suo indice. 
3. Aggiungi un'immagine alla collezione di immagini della presentazione.
4. Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_p_p_image) aggiungendo un'immagine alla [IImagescollection](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_image_collection) associata all'oggetto presentazione che verrà utilizzato per riempire la forma.
5. Specifica la larghezza e l'altezza relative dell'immagine nel frame immagine.
6. Scrivi la presentazione modificata come file PPTX.

Questo codice C++ mostra come creare un frame immagine con scala relativa:

```c++
// Il percorso della directory dei documenti.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Carica la presentazione desiderata.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede alla prima diapositiva.
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Carica l'immagine da aggiungere alla collezione di immagini della presentazione
// Ottiene l'immagine
auto image = Images::FromFile(filePath);

// Aggiunge un'immagine alla collezione di immagini della presentazione
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Aggiunge un frame immagine alla diapositiva
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Imposta la larghezza e l'altezza della scala relativa
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Scrive il file PPTX su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Estrarre immagini raster dai frame immagine**

Puoi estrarre immagini raster dagli oggetti [PictureFrame](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.picture_frame) e salvarle in PNG, JPG e altri formati. L'esempio di codice seguente dimostra come estrarre un'immagine dal documento "sample.pptx" e salvarla in formato PNG.

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **Estrarre immagini SVG dai frame immagine**

Quando una presentazione contiene grafica SVG inserita all'interno di forme [PictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/pictureframe/) , Aspose.Slides per C++ consente di recuperare le immagini vettoriali originali con piena fedeltà. Percorrendo la collezione di forme della diapositiva, è possibile identificare ogni [PictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/pictureframe/), verificare se l'oggetto [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) sottostante contiene contenuto SVG, e quindi salvare quell'immagine su disco o in uno stream nel suo formato SVG nativo.

Il seguente esempio di codice dimostra come estrarre un'immagine SVG da un frame immagine:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **Ottenere la trasparenza di un'immagine**

Aspose.Slides consente di ottenere l'effetto di trasparenza applicato a un'immagine. Questo codice C++ dimostra l'operazione:

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="primary" %}} 
Tutti gli effetti applicati alle immagini sono disponibili in [Aspose::Slides::Effects](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/).
{{% /alert %}}

## **Ottenere luminosità e contrasto di un'immagine**

Aspose.Slides consente di ottenere l'effetto di luminosità e contrasto applicato a un'immagine. L'interfaccia [ILuminance](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iluminance/) rappresenta questo effetto di trasformazione dell'immagine.

Questo codice C++ dimostra come ottenere le impostazioni di luminosità e contrasto da un frame immagine:

```c++
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **Formattazione del frame immagine**

Aspose.Slides offre molte opzioni di formattazione che possono essere applicate a un frame immagine. Utilizzando queste opzioni, è possibile modificare un frame immagine per soddisfare requisiti specifici.

1. Crea un'istanza della [Presentation class](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
2. Ottieni un riferimento a una diapositiva tramite il suo indice. 
3. Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_p_p_image) aggiungendo un'immagine alla [IImagescollection](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_image_collection) associata all'oggetto presentazione che verrà utilizzato per riempire la forma.
4. Specifica la larghezza e l'altezza dell'immagine.
5. Crea un `PictureFrame` basato sulla larghezza e altezza dell'immagine tramite il metodo [AddPictureFrame](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) esposto dall'oggetto [IShapes](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_shape_collection) associato alla diapositiva di riferimento.
6. Aggiungi il frame immagine (contenente l'immagine) alla diapositiva.
7. Imposta il colore della linea del frame immagine.
8. Imposta lo spessore della linea del frame immagine.
9. Ruota il frame immagine assegnandogli un valore positivo o negativo.
   * Un valore positivo ruota l'immagine in senso orario. 
   * Un valore negativo ruota l'immagine in senso anti-orario.
10. Aggiungi il frame immagine (contenente l'immagine) alla diapositiva.
11. Scrivi la presentazione modificata come file PPTX.

Questo codice C++ dimostra il processo di formattazione del frame immagine:

```c++
// Il percorso della directory dei documenti.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Carica la presentazione desiderata.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede alla prima diapositiva.
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Carica l'immagine da aggiungere alla collezione di immagini della presentazione
// Ottiene l'immagine
auto image = Images::FromFile(filePath);

// Aggiunge un'immagine alla collezione di immagini della presentazione
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Aggiunge un frame immagine alla diapositiva
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Imposta la larghezza e l'altezza della scala relativa
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Scrive il file PPTX su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Suggerimento" color="primary" %}}
Aspose ha recentemente sviluppato un [free Collage Maker](https://products.aspose.app/slides/it/collage). Se devi mai [unire JPG/JPEG](https://products.aspose.app/slides/it/collage/jpg) o immagini PNG, [creare griglie da foto](https://products.aspose.app/slides/it/collage/photo-grid), puoi utilizzare questo servizio. 
{{% /alert %}}

## **Aggiungere un'immagine come collegamento**

Per evitare presentazioni di grandi dimensioni, è possibile aggiungere immagini (o video) tramite collegamenti invece di incorporare i file direttamente nelle presentazioni. Questo codice C++ mostra come aggiungere un'immagine e un video in un segnaposto:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ritagliare immagini**

Questo codice C++ mostra come ritagliare un'immagine esistente su una diapositiva: 

```CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Crea un nuovo oggetto immagine
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Aggiunge un PictureFrame a una diapositiva
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Ritaglia l'immagine (valori percentuali)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Salva il risultato
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Eliminare le aree ritagliate di un'immagine**

Se desideri eliminare le aree ritagliate di un'immagine contenuta in un frame, puoi utilizzare il metodo [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Questo metodo restituisce l'immagine ritagliata o l'immagine originale se il ritaglio non è necessario.

Questo codice C++ dimostra l'operazione: 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Gets the PictureFrame from the first slide
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Deletes cropped areas of the PictureFrame image and returns the cropped image
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Saves the result
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTA" color="warning" %}} 
Il metodo [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) aggiunge l'immagine ritagliata alla collezione di immagini della presentazione. Se l'immagine è utilizzata solo nel [PictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/pictureframe/) elaborato, questa impostazione può ridurre la dimensione della presentazione. Altrimenti, il numero di immagini nella presentazione risultante aumenterà.

Questo metodo converte i metafile WMF/EMF in immagini raster PNG durante l'operazione di ritaglio. 
{{% /alert %}}

## **Comprimere immagini**

Puoi comprimere un'immagine in una presentazione utilizzando il metodo [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/compressimage/). Questo metodo comprime un'immagine riducendone le dimensioni in base alla dimensione della forma e alla risoluzione specificata, con l'opzione di eliminare le aree ritagliate.

Regola la dimensione e la risoluzione dell'immagine in modo simile alla funzionalità **Picture Format -> Compress Pictures -> Resolution** di PowerPoint.

I seguenti esempi C++ mostrano come comprimere un'immagine in una presentazione specificando una risoluzione target e, facoltativamente, rimuovendo le aree ritagliate:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Comprimi l'immagine con una risoluzione target di 150 DPI (risoluzione Web) e rimuovi le aree ritagliate.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Verifica il risultato della compressione.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Oppure utilizzando direttamente un valore DPI personalizzato:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Comprime l'immagine a 150 DPI (risoluzione web), rimuovendo le aree ritagliate.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTA" color="warning" %}} 
Il metodo converte l'immagine a una risoluzione inferiore in base alla dimensione della forma e al DPI fornito. Le regioni ritagliate possono anche essere eliminate per ottimizzare le dimensioni del file.
Se l'immagine è un metafile (WMF/EMF) o SVG, la compressione non verrà applicata. Inoltre, la qualità JPEG è preservata o leggermente ridotta in base alla risoluzione, analogamente a come PowerPoint gestisce JPEG ad alta risoluzione.
{{% /alert %}}

## **Bloccare rapporto d'aspetto**

Se vuoi che una forma contenente un'immagine mantenga il suo rapporto d'aspetto anche dopo aver modificato le dimensioni dell'immagine, puoi usare il metodo [set_AspectRatioLocked()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) per impostare l'impostazione *Lock Aspect Ratio*. 

Questo codice C++ mostra come bloccare il rapporto d'aspetto di una forma:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// imposta la forma per mantenere il rapporto d'aspetto durante il ridimensionamento
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTA" color="warning" %}} 
Questa impostazione *Lock Aspect Ratio* preserva solo il rapporto d'aspetto della forma e non l'immagine contenuta.
{{% /alert %}}

## **Utilizzare la proprietà StretchOff**

Utilizzando le proprietà [StretchOffsetLeft](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) e [StretchOffsetBottom](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) dell'interfaccia [IPictureFillFormat](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_picture_fill_format) e della classe [PictureFillFormat](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.picture_fill_format), puoi specificare un rettangolo di riempimento. 

Quando viene specificata l'estensione di un'immagine, un rettangolo sorgente viene scalato per adattarsi al rettangolo di riempimento specificato. Ogni bordo del rettangolo di riempimento è definito da un offset percentuale rispetto al bordo corrispondente della bounding box della forma. Una percentuale positiva indica un rientro. Una percentuale negativa indica un'estensione.

1. Crea un'istanza della [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) class.
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un rettangolo `AutoShape`. 
4. Crea un'immagine.
5. Imposta il tipo di riempimento della forma.
6. Imposta la modalità di riempimento immagine della forma.
7. Aggiungi un'immagine impostata per riempire la forma.
8. Specifica gli offset dell'immagine rispetto al bordo corrispondente della bounding box della forma
9. Scrivi la presentazione modificata come file PPTX.

Questo codice C++ dimostra un processo in cui viene utilizzata la proprietà StretchOff:

```cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Imposta l'immagine stirata da ogni lato nel corpo della forma
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Come posso scoprire quali formati immagine sono supportati per PictureFrame?**

Aspose.Slides supporta sia immagini raster (PNG, JPEG, BMP, GIF, ecc.) sia immagini vettoriali (ad esempio SVG) tramite l'oggetto immagine assegnato a un [PictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/pictureframe/). L'elenco dei formati supportati si sovrappone generalmente alle capacità del motore di conversione diapositive e immagini.

**Come influenzerà l'aggiunta di decine di immagini grandi le dimensioni e le prestazioni del PPTX?**

Incorporare immagini grandi aumenta le dimensioni del file e l'utilizzo della memoria; collegare le immagini aiuta a mantenere ridotte le dimensioni della presentazione ma richiede che i file esterni rimangano accessibili. Aspose.Slides fornisce la possibilità di aggiungere immagini via collegamento per ridurre le dimensioni del file.

**Come posso bloccare un oggetto immagine per evitare spostamenti o ridimensionamenti accidentali?**

Utilizza i [blocchi forma](https://reference.aspose.com/slides/it/cpp/aspose.slides/pictureframe/get_pictureframelock/) per un [PictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/pictureframe/) (ad esempio, disabilita lo spostamento o il ridimensionamento). Il meccanismo di blocco è descritto per le forme in un articolo separato sulla [protezione](/slides/it/cpp/applying-protection-to-presentation/) ed è supportato per vari tipi di forma, inclusi i [PictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/pictureframe/).

**La fedeltà vettoriale SVG viene preservata quando si esporta una presentazione in PDF/immagini?**

Aspose.Slides consente di estrarre un SVG da un [PictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/pictureframe/) come vettore originale. Quando si esporta in PDF (/slides/it/cpp/convert-powerpoint-to-pdf/) o in formati raster (/slides/it/cpp/convert-powerpoint-to-png/), il risultato può essere rasterizzato a seconda delle impostazioni di esportazione; il fatto che l'SVG originale sia memorizzato come vettore è confermato dal comportamento di estrazione.