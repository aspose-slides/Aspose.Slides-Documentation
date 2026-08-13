---
title: Ottimizza la gestione delle immagini nelle presentazioni usando C++
linktitle: Gestisci immagini
type: docs
weight: 10
url: /it/cpp/image/
keywords:
- aggiungi immagine
- aggiungi foto
- aggiungi bitmap
- sostituisci immagine
- sostituisci foto
- dal web
- sfondo
- aggiungi PNG
- aggiungi JPG
- aggiungi SVG
- risorse SVG esterne
- risolutore SVG
- immagini SVG collegate
- font SVG
- aggiungi EMF
- aggiungi WMF
- aggiungi TIFF
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Snellisci la gestione delle immagini in PowerPoint e OpenDocument con Aspose.Slides per C++, ottimizzando le prestazioni e automatizzando il tuo flusso di lavoro."
---
## **Introduzione**

Le immagini rendono le presentazioni più coinvolgenti e visivamente attraenti. In Microsoft PowerPoint, è possibile inserire immagini nelle diapositive da file, Internet o altre fonti. Analogamente, Aspose.Slides consente di aggiungere immagini alle diapositive di una presentazione in diversi modi. 

{{% alert title="Tip" color="info" %}} 
Aspose fornisce convertitori gratuiti—[JPEG to PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare rapidamente presentazioni a partire da immagini. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Se desideri aggiungere un'immagine come cornice fotografica—soprattutto se prevedi di ridimensionarla, applicare effetti o utilizzare altre opzioni di formattazione standard—vedi [Picture Frame](/slides/it/cpp/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Puoi convertire le immagini da un formato all'altro. Consulta le seguenti pagine: converti [image to JPG](https://products.aspose.com/slides/it/cpp/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/it/cpp/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/it/cpp/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/it/cpp/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/it/cpp/conversion/png-to-svg/), e [SVG to PNG](https://products.aspose.com/slides/it/cpp/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides supporta immagini nei formati più diffusi, come JPEG, PNG, BMP, GIF e altri. 

## **Aggiungere immagini archiviate localmente alle diapositive**

È possibile aggiungere una o più immagini memorizzate sul proprio computer a una diapositiva della presentazione. Il seguente codice di esempio in C++ mostra come aggiungere un'immagine a una diapositiva:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Aggiungere immagini dal web alle diapositive**

Se l'immagine che desideri aggiungere a una diapositiva non è memorizzata sul tuo computer, puoi aggiungerla direttamente dal web. 

Il seguente codice di esempio in C++ mostra come aggiungere un'immagine dal web a una diapositiva:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Aggiungere immagini ai master delle diapositive**

Un master delle diapositive memorizza e controlla informazioni come il tema e il layout per le diapositive che lo utilizzano. Quando aggiungi un'immagine a un master delle diapositive, l'immagine appare su ogni diapositiva basata su quel master. 

Il seguente codice di esempio in C++ mostra come aggiungere un'immagine a un master delle diapositive:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Aggiungere immagini come sfondi delle diapositive**

Puoi utilizzare un'immagine come sfondo per una o più diapositive. Per i dettagli, vedi *[Setting Images as Backgrounds for Slides](/slides/it/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Aggiungere SVG alle presentazioni**

Il contenuto SVG può essere aggiunto a una presentazione utilizzando la classe [SvgImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/svgimage/). L'oggetto [ISvgImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/isvgimage/) risultante può quindi essere aggiunto alla raccolta di immagini della presentazione e utilizzato per creare una cornice fotografica.

Il seguente esempio C++ importa una stringa SVG autonoma. Tutte le immagini, gli stili e le altre risorse utilizzate da questo SVG sono incorporati direttamente nel contenuto SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Importare contenuto SVG con risorse esterne**

I file SVG esportati da strumenti di design, editor di diagrammi, sistemi di icone e pipeline web possono fare riferimento a risorse memorizzate al di fuori del documento SVG. Ad esempio, un SVG può contenere un collegamento a un'immagine come `images/photo.png`, un valore CSS `url(...)` o un URL di un font.

Per importare tale contenuto SVG, crea un’implementazione di [IExternalResourceResolver](https://reference.aspose.com/slides/it/cpp/aspose.slides.import/iexternalresourceresolver/) e passala, insieme a un URI di base, al costruttore appropriato di `SvgImage`. L'URI di base identifica la posizione del documento SVG ed è usato per risolvere i collegamenti relativi.

L'interfaccia [ISvgImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/isvgimage/) fornisce l'accesso alle informazioni sul SVG importato:

- `get_SvgContent()` restituisce il markup SVG come stringa.  
- `get_SvgData()` restituisce il contenuto SVG come array di byte.  
- `get_BaseUri()` restituisce l'URI di base usato per i collegamenti relativi.  
- `get_ExternalResourceResolver()` restituisce il resolver assegnato all'immagine SVG.  

### **Implementare un Resolver di Risorse Esterne**

Il resolver ha due metodi:

- [ResolveUri](https://reference.aspose.com/slides/it/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) combina l'URI di base e un collegamento a una risorsa relativa e restituisce un URI assoluto. Restituisci una stringa null quando il collegamento non può essere risolto o non è consentito.  
- [GetEntity](https://reference.aspose.com/slides/it/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) restituisce uno stream leggibile per un URI di risorsa assoluto. Restituisci `nullptr` quando la risorsa è mancante, bloccata o non disponibile. Uno stream di fallback può anche essere restituito quando opportuno.  

Il resolver seguente carica le risorse collegate solo da una directory locale consentita. Le risorse di rete e i percorsi al di fuori della directory autorizzata sono bloccati. Un'immagine di fallback opzionale viene restituita per i collegamenti immagine non risolti.

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // Questo resolver consente intenzionalmente solo file locali.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // Usa un fallback solo per risorse immagine. Restituire uno stream di immagine
        // per un font o un foglio di stile mancante non sarebbe valido.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **Risolvi le risorse collegate durante l'importazione SVG**

Supponiamo che `assets/diagram.svg` contenga un riferimento relativo come:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Il seguente esempio C++ passa l'URI del file SVG come URI di base e fornisce un resolver personalizzato. Il resolver converte il collegamento immagine relativo in un URI assoluto e restituisce uno stream contenente la risorsa collegata mentre Aspose.Slides elabora l'SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// L'URI di base rappresenta la posizione del documento SVG.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage espone il contenuto sorgente, i dati binari, l'URI di base e il resolver.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La classe `SvgImage` fornisce anche overload che accettano dati SVG come array di byte o stream, insieme a un resolver di risorse esterne e a un URI di base.

{{% alert title="Important" color="warning" %}}
Il resolver di risorse rende disponibili le risorse esterne mentre Aspose.Slides elabora e renderizza l'SVG. Non modifica il markup SVG originale né incorpora automaticamente le risorse risolte al suo interno.

Quando un `ISvgImage` viene aggiunto alla raccolta di immagini della presentazione, il file PPTX può contenere sia la rappresentazione SVG originale sia un'immagine raster di fallback. Una risorsa collegata può apparire nell'immagine di fallback generata mentre un collegamento relativo come `images/photo.png` rimane invariato nello SVG memorizzato. Un'applicazione che renderizza la rappresentazione SVG nativa può quindi omettere il contenuto collegato quando la risorsa esterna originale non è disponibile.
{{% /alert %}}

### **Creare un'immagine SVG portabile**

Per creare un'immagine SVG che non dipenda da file esterni, rendi l'SVG autonomo prima di creare il `SvgImage`. Ad esempio, sostituisci gli URL delle immagini collegate con URI `data:` che contengono i dati dell'immagine:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Dopo che tutte le risorse necessarie sono state incorporate nel contenuto SVG, crea il `SvgImage`, aggiungilo alla raccolta di immagini della presentazione e inseriscilo in una cornice fotografica come mostrato nell'esempio precedente.

### **Gestire risorse mancanti o bloccate**

Restituisci una stringa null da `ResolveUri` quando un URI di risorsa è non valido, proibito o non può essere risolto. Restituisci `nullptr` da `GetEntity` quando la risorsa non può essere letta. Aspose.Slides continua a elaborare l'SVG senza quella risorsa quando possibile.

È possibile restituire uno stream di fallback per una risorsa mancante, ma il suo contenuto deve essere compatibile con il tipo di risorsa richiesto. Ad esempio, restituisci uno stream immagine solo per un'immagine mancante, non per un font o un foglio di stile.

{{% alert title="Security" color="warning" %}}
Non risolvere percorsi di file arbitrari o URL di rete non limitati da file SVG non attendibili. Limita gli schemi, le directory e gli host consentiti. Per le risorse di rete, applica anche timeout di connessione, limiti di dimensione della risposta e convalida del contenuto.
{{% /alert %}}

## **Convertire SVG in un insieme di forme**
Aspose.Slides può convertire un SVG in un insieme di forme, in modo simile alla funzionalità corrispondente in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Questa funzionalità è fornita da un overload del metodo [AddGroupShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/) dell'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/) che accetta un oggetto [ISvgImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/isvgimage/) come primo argomento.

Il seguente codice di esempio in C++ mostra come utilizzare questo metodo per convertire un file SVG in un insieme di forme:

```cpp
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// Nome file SVG di origine
auto svgFileName = System::String(u"sample.svg");

// Nome file di output della presentazione
auto outPptxPath = System::String(u"presentation.pptx");

// Crea una nuova presentazione
auto presentation = System::MakeObject<Presentation>();

// Leggi il contenuto del file SVG
auto svgContent = File::ReadAllText(svgFileName);

// Crea un oggetto SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Ottieni la dimensione della diapositiva
auto slideSize = presentation->get_SlideSize()->get_Size();

// Converti l'immagine SVG in un gruppo di forme e scala alla dimensione della diapositiva
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Salva la presentazione in formato PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Aggiungere immagini come EMF alle diapositive**
Aspose.Slides per C++ consente di generare immagini EMF da fogli di lavoro Excel con Aspose.Cells e aggiungerle alle diapositive della presentazione. 

Il seguente codice di esempio in C++ mostra come fare:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells per C++ deve essere avviato prima di utilizzare qualsiasi suo tipo.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Esegui il rendering del foglio di lavoro come EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells restituisce la pagina renderizzata come buffer, che Aspose.Slides aggiunge come immagine.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **Sostituire immagini nella raccolta di immagini**

Aspose.Slides consente di sostituire le immagini memorizzate nella raccolta di immagini di una presentazione, incluse le immagini utilizzate dalle forme delle diapositive. Questa sezione descrive diversi modi per aggiornare le immagini nella raccolta. È possibile sostituire un'immagine usando dati grezzi in byte, un'istanza [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) o un'altra immagine già presente nella raccolta.

Segui i passaggi seguenti:

1. Carica il file di presentazione che contiene le immagini usando la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).  
2. Carica una nuova immagine da un file in un array di byte.  
3. Sostituisci l'immagine target con la nuova immagine usando l'array di byte.  
4. Nel secondo approccio, carica l'immagine in un oggetto [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) e sostituisci l'immagine target con quell'oggetto.  
5. Nel terzo approccio, sostituisci l'immagine target con un'immagine già presente nella raccolta di immagini della presentazione.  
6. Scrivi la presentazione modificata come file PPTX.  

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

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
Con il convertitore gratuito [Text to GIF](https://products.aspose.app/slides/it/text-to-gif) di Aspose, puoi facilmente animare il testo e creare GIF dal testo. 
{{% /alert %}}

## **FAQ**

**La risoluzione originale dell'immagine rimane intatta dopo l'inserimento?**

Sì. I pixel originali sono preservati, ma l'aspetto finale dipende da come il [picture](/slides/it/cpp/picture-frame/) viene scalato nella diapositiva e da eventuali compressioni applicate al salvataggio.

**Qual è il modo migliore per sostituire lo stesso logo su decine di diapositive contemporaneamente?**

Posiziona il logo sul master della diapositiva o su un layout e sostituiscilo nella raccolta di immagini della presentazione—gli aggiornamenti si propagheranno a tutti gli elementi che utilizzano quella risorsa.

**Un SVG inserito può essere convertito in forme modificabili?**

Sì. È possibile convertire un SVG in un gruppo di forme, dopo di che le singole parti diventano modificabili con le proprietà standard delle forme.

**Come posso impostare un'immagine come sfondo per più diapositive contemporaneamente?**

[Assegna l'immagine come sfondo](/slides/it/cpp/presentation-background/) sul master della diapositiva o sul layout pertinente—tutte le diapositive che utilizzano quel master/layout erediteranno lo sfondo.

**Come evito che una presentazione diventi troppo grande a causa di molte immagini?**

Riutilizza una singola risorsa immagine anziché duplicati, scegli risoluzioni ragionevoli, applica compressione al salvataggio e mantieni le grafiche ripetute sul master dove opportuno.