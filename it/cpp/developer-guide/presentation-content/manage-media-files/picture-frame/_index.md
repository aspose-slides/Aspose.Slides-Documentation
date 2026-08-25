---
title: Gestire i fotogrammi immagine nelle presentazioni usando C++
linktitle: Fotogramma
type: docs
weight: 10
url: /it/cpp/picture-frame/
keywords:
- fotogramma immagine
- aggiungi fotogramma immagine
- crea fotogramma immagine
- immagine incorporata
- immagine collegata
- estrai immagine
- immagine raster
- immagine SVG
- ritaglia immagine
- elimina aree ritagliate
- comprimi immagine
- StretchOffset
- formattazione fotogramma immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Crea, formatta, collega, ritaglia, estrae e comprime i fotogrammi immagine nelle presentazioni con Aspose.Slides per C++."
---
## **Panoramica**

Un fotogramma immagine è una forma di diapositiva che visualizza un'immagine. In Aspose.Slides, la risorsa immagine e la forma che la visualizza sono oggetti separati: una [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) possiede le risorse immagine incorporate tramite la sua [image collection](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_images/), mentre un [IPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframe/) controlla la posizione, le dimensioni, la formattazione delle linee, la rotazione, il ritaglio, gli effetti immagine e altre impostazioni a livello di fotogramma.

Questa separazione è utile quando la stessa immagine viene mostrata più di una volta. Aggiungi l'immagine alla presentazione una sola volta, conserva il [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) restituito e utilizza quella risorsa immagine quando crei i fotogrammi immagine.

I fotogrammi immagine possono contenere immagini raster come PNG o JPEG e immagini vettoriali SVG. Possono anche fare riferimento a immagini collegate invece di memorizzare i byte dell'immagine nella presentazione. La scelta influisce sulla portabilità, sulla dimensione del file, sull'estrazione e sul comportamento di esportazione, perciò è utile decidere come l'immagine debba essere archiviata prima di applicare formattazioni o ottimizzazioni.

## **Aggiungere e Formattare un'Immagine Incorporata**

Per un'immagine incorporata, aggiungi i dati immagine alla presentazione e crea un fotogramma immagine con [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/shapecollection/addpictureframe/). L'immagine diventa parte del pacchetto della presentazione, così la presentazione rimane autonoma quando viene spostata su un altro computer.

L'esempio seguente aggiunge un'immagine JPEG, crea un fotogramma alle dimensioni native dell'immagine e applica la formattazione della linea e la rotazione:

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il fotogramma immagine controlla la geometria visualizzata; modificare le dimensioni del fotogramma non cambia le dimensioni in pixel originali memorizzate nella risorsa immagine incorporata. Questa distinzione diventa importante quando si ritaglia o si comprime un'immagine in seguito.

## **Usare la Scala Relativa**

[IPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframe/) espone la scalatura relativa di larghezza e altezza per il fotogramma. Un valore di `1.0` corrisponde al 100 % della dimensione originale dell'immagine. La scala relativa è utile quando un flusso di lavoro deve preservare una relazione con le dimensioni dell'immagine sorgente anziché calcolare manualmente le dimensioni finali.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La scala relativa modifica le impostazioni di scala del fotogramma; non ricampiona né comprime l'immagine incorporata.

## **Immagini Incorporate e Collegate**

Un'immagine incorporata memorizza i dati immagine all'interno della presentazione ed è quindi la scelta più sicura per la portabilità e il rendering prevedibile. Un'immagine collegata memorizza un percorso esterno attraverso il percorso di collegamento di [ISlidesPicture](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidespicture/) anziché incorporare i dati immagine nello stesso modo.

Le immagini collegate possono ridurre la quantità di dati immagine memorizzati nel PPTX, ma introducono una dipendenza esterna. Il file collegato deve rimanere accessibile all'applicazione che apre o rende la presentazione. Se il percorso cambia, il file viene spostato o la risorsa non è più disponibile, l'immagine collegata potrebbe non essere visualizzata come previsto. Per presentazioni che devono essere inviate via e‑mail, archiviate o renderizzate in ambienti isolati, le immagini incorporate sono solitamente più affidabili.

### **Aggiungere un'Immagine Collegata**

L'esempio seguente crea un fotogramma immagine e lo punta a un file immagine locale. Gestisce solo il collegamento di immagini; il collegamento di video è un flusso di lavoro multimediale separato e non è mescolato intenzionalmente in questo esempio.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Usa i collegamenti quando la gestione di file esterni è intenzionale. Non usarli semplicemente come sostituto della compressione: un PPTX piccolo con dipendenze immagine rotte è solitamente meno utile di una presentazione più grande e autonoma.

## **Estrarre Immagini da Fotogrammi Immagine**

Prima di estrarre un'immagine da una presentazione esistente, verifica che una forma sia effettivamente un [IPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframe/) e che contenga un'immagine incorporata. I fotogrammi immagine collegati potrebbero non contenere i byte dell'immagine estraibili nello stesso modo.

### **Estrarre un'Immagine Raster**

L'API immagine moderna utilizza direttamente [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/). L'esempio seguente trova la prima immagine raster incorporata in una diapositiva e la salva come PNG:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

Il salvataggio tramite [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) converte l'immagine estratta nel formato di output richiesto. Se ti servono i byte codificati memorizzati nella presentazione invece di un file raster convertito, usa i dati binari della risorsa immagine.

### **Estrarre un'Immagine SVG**

Per un'immagine SVG, il [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) espone un oggetto [ISvgImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/isvgimage/). Questo consente di recuperare direttamente i dati SVG invece di rasterizzare prima l'immagine.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

Mantenere il contenuto SVG come SVG preserva la sorgente vettoriale all'interno della presentazione. Le esportazioni raster come PNG o JPEG rendono necessariamente quel contenuto vettoriale in pixel. L'esportazione diapositive in PDF o SVG è anch'essa un'operazione di rendering, pertanto la grafica esportata non deve essere trattata come una copia byte‑a‑byte dell'SVG incorporato originale; utilizza i dati [ISvgImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/isvgimage/) incorporati quando è richiesto il vettoriale originale.

## **Ritagliare un'Immagine**

Il ritaglio cambia quale parte di un'immagine è visibile all'interno del fotogramma. I valori di ritaglio su [IPictureFillFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/) sono percentuali delle dimensioni dell'immagine sorgente. Il ritaglio non elimina inizialmente i pixel nascosti dall'immagine incorporata; cambia solo la regione visibile.

L'esempio seguente trova in modo sicuro un fotogramma immagine e applica i valori di ritaglio:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Poiché i dati immagine nascosti sono ancora presenti, il ritaglio può essere modificato in un secondo momento senza perdere i pixel originali. Se la dimensione del file è più importante della reversibilità, le regioni ritagliate possono essere rimosse fisicamente come descritto nella sezione successiva.

## **Rimuovere i Dati Immagine Ritagliati**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) rimuove i dati immagine al di fuori del rettangolo di ritaglio corrente e restituisce la risorsa immagine risultante. Questo può ridurre la dimensione del file, ma è un'ottimizzazione distruttiva: dopo il salvataggio della presentazione i pixel rimossi non sono più disponibili per un'operazione di "uncrop" successiva.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

Il metodo può aggiungere una nuova risorsa immagine alla presentazione. Se l'immagine originale è anche usata da altri fotogrammi, quei fotogrammi hanno comunque bisogno della risorsa esistente, quindi l'eliminazione delle aree ritagliate non riduce necessariamente il numero totale di immagini. Il ritaglio di contenuti WMF o EMF con questo metodo rasterizza il risultato ritagliato in PNG.

## **Comprimere Immagini Raster**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/compressimage/) riduce la risoluzione dell'immagine raster rispetto alle dimensioni con cui l'immagine è visualizzata. Può anche rimuovere le regioni ritagliate nella stessa operazione. Il metodo restituisce `true` quando l'immagine è stata ridimensionata o ritagliata e `false` quando non è stato necessario alcun cambiamento.

Usa un valore predefinito di [PicturesCompression](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/picturescompression/) quando una risoluzione target standard è sufficiente:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

È possibile passare un valore DPI positivo personalizzato al posto del valore enum quando è richiesto un target specifico.

La compressione è destinata alle immagini raster. Il contenuto SVG e metafile non è ridotto da questo flusso di lavoro di compressione raster. Ricorda inoltre che risoluzioni più basse e regioni ritagliate eliminate non possono essere recuperate dalla presentazione ottimizzata. Scegli una risoluzione target basata sulla dimensione massima alla quale l'immagine sarà effettivamente visualizzata o esportata, anziché applicare globalmente il DPI più basso.

## **Gestire gli Effetti di Trasformazione dell'Immagine**

Per un flusso di lavoro completo che copra luminosità, contrasto, trasformazioni colore, sfocatura, effetti alfa, catene ordinate, ispezione, rimozione e verifica round‑trip, vedi [Image Transform Effects](/slides/it/cpp/image-transform-effects/).

## **Bloccare la Geometria del Fotogramma Immagine**

Le impostazioni di [IPictureFrameLock](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframelock/) controllano quali operazioni di modifica sono disabilitate per un fotogramma immagine. Ad esempio, il [aspect-ratio lock](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) preserva le proporzioni della forma durante il ridimensionamento.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il blocco si applica alla forma del fotogramma immagine. Non obbliga l'immagine sorgente a essere ricampionata o permanentemente modificata per adottare lo stesso rapporto d'aspetto.

## **Regolare i Valori StretchOffset**

Quando la modalità di riempimento immagine è stretch, i valori stretch‑offset su [IPictureFillFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/) definiscono il rettangolo di riempimento relativo al bounding box del fotogramma immagine. Percentuali positive creano un inset rispetto al bordo, mentre percentuali negative creano un outset.

Questo è diverso dal ritaglio. I valori di ritaglio selezionano quale parte dell'immagine sorgente è visibile; gli offset di stretch modificano il rettangolo nel quale il riempimento immagine visibile viene allungato.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Usa gli stretch‑offset per il posizionamento del riempimento. Usa le proprietà di ritaglio quando l'obiettivo è nascondere i bordi dell'immagine sorgente.

## **Considerazioni su Archiviazione, Dimensione del File e Esportazione**

I principali compromessi sono più facili da gestire quando l'archiviazione delle immagini e la formattazione dei fotogrammi sono trattati separatamente:

- **Immagini incorporate** rendono la presentazione autonoma e sono le più affidabili per la condivisione e il rendering server‑side, ma le immagini raster di grandi dimensioni aumentano la dimensione del PPTX e l'uso di memoria.
- **Immagini collegate** possono mantenere il pacchetto più piccolo, ma la presentazione dipende dalla disponibilità continuata dei file esterni nei percorsi o nelle posizioni memorizzate.
- **Ritaglio** è inizialmente non distruttivo. I pixel nascosti rimangono incorporati finché le aree ritagliate non vengono eliminate esplicitamente o rimosse durante la compressione.
- **Compressone** può ridurre notevolmente la dimensione del file per immagini raster sovradimensionate, ma sacrifica la risoluzione originale. Deve essere applicata dopo aver determinato la dimensione effettiva sull slide.
- **Immagini SVG** dovrebbero rimanere come SVG quando è importante preservare il vettoriale. Estrai direttamente l'SVG incorporato quando ti serve la risorsa vettoriale stessa. Le esportazioni slide raster convertono sempre la slide renderizzata in pixel.
- **Immagini ripetute** dovrebbero riutilizzare una risorsa [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) esistente quando possibile, anziché caricare ripetutamente lo stesso file nel flusso di lavoro della presentazione.

Per presentazioni di grandi dimensioni, l'ottimizzazione delle immagini è solitamente più efficace quando eseguita in modo selettivo: mantieni loghi e diagrammi come contenuto vettoriale, comprimi le fotografie in base alla loro reale dimensione di visualizzazione, rimuovi i pixel ritagliati solo quando non è necessario un successivo editing, ed evita i collegamenti esterni a meno che la gestione delle dipendenze non faccia parte del design di distribuzione.

## **FAQ**

**Qual è la differenza tra un fotogramma immagine e una risorsa immagine?**

Un [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) rappresenta una risorsa immagine associata alla presentazione. Un [IPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframe/) è una forma su una diapositiva che visualizza un'immagine e memorizza la geometria e la formattazione a livello di fotogramma, come dimensioni, rotazione, valori di ritaglio, effetti e blocchi.

**Devo incorporare o collegare le immagini?**

Incorpora le immagini quando la presentazione deve essere portabile, archiviata o renderizzata senza accesso a risorse esterne. Collega le immagini solo quando è intenzionale mantenere i file immagine fuori dal PPTX e le posizioni esterne possono essere gestite in modo affidabile.

**Il ritaglio riduce la dimensione del file PPTX?**

Non da solo. Le impostazioni di ritaglio normali nascondono parti dell'immagine sorgente ma mantengono i pixel sottostanti. Usa [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) o la compressione immagine con rimozione delle aree ritagliate quando quei pixel possono essere scartati definitivamente.

**Posso ripristinare la qualità dell'immagine dopo la compressione?**

No. La compressione può ridurre la risoluzione raster memorizzata e la rimozione delle regioni ritagliate elimina i dati immagine. Conserva l'immagine sorgente originale al di fuori della presentazione se in seguito potrebbe essere necessario un editing ad alta risoluzione.

**Come devono essere gestite le immagini SVG?**

Mantieni il contenuto SVG come SVG quando è importante la fedeltà vettoriale. L'[ISvgImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/isvgimage/) incorporato può essere estratto direttamente. Il rendering di una slide in formato raster (PNG, JPEG) rasterizza l'SVG come parte dell'immagine della slide.

**Come evitare cast non sicuri durante la lettura di slide esistenti?**

Controlla il tipo di forma prima di utilizzare i membri specifici del fotogramma immagine. Verifica la forma con [IPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframe/) prima di effettuare un cast a runtime e assegna il risultato del cast a una variabile locale prima di accedere ai membri specifici del fotogramma.