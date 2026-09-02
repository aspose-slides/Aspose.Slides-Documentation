---
title: "Ottimizza la gestione delle immagini nelle presentazioni con C++"
linktitle: "Gestisci immagini"
type: docs
weight: 10
url: /it/cpp/image/
keywords:
- aggiungi immagine
- aggiungi immagine
- sostituisci immagine
- raccolta immagini
- riquadro immagine
- immagine collegata
- sfondo
- aggiungi PNG
- aggiungi JPG
- aggiungi SVG
- SVG in forme
- risorse SVG esterne
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri come aggiungere, riutilizzare, collegare, sostituire e gestire immagini raster e SVG in presentazioni PowerPoint e OpenDocument con Aspose.Slides per C++."
---
## **Introduzione**

Aspose.Slides per C++ offre diversi modi per lavorare con le immagini, e ciascuno serve a uno scopo diverso. È possibile memorizzare un'immagine in una presentazione, visualizzarla in un riquadro immagine, usarla come sfondo diapositive, collegarla a un'immagine esterna, sostituire una risorsa immagine condivisa o convertire il contenuto SVG in forme modificabili.

Questo articolo si concentra sulle risorse immagine e su come vengono utilizzate all'interno di una presentazione. Per ritaglio, trasparenza, effetti, allungamento e altre formattazioni applicate a un singolo riquadro immagine, vedere [Picture Frame](/slides/it/cpp/picture-frame/).

## **Comprendere il modello immagine**

I seguenti concetti API sono strettamente correlati ma non intercambiabili:

- La [presentation image collection](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimagecollection/) memorizza le risorse immagine utilizzate dalla presentazione. Usa [IImageCollection::AddImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimagecollection/addimage/) per aggiungere dati immagine e ottenere una risorsa [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/).
- Un [picture frame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframe/) è una forma che visualizza un'immagine su una diapositiva, layout o master. Usa [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addpictureframe/) per posizionare una risorsa immagine su una diapositiva.
- Uno sfondo diapositiva utilizza un'immagine come parte del riempimento della diapositiva anziché come forma. Perciò non si comporta come un picture frame.
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/replaceimage/) sostituisce una risorsa immagine. Se diversi elementi della presentazione utilizzano quella risorsa, tutti useranno la sostituzione.
- La conversione di un SVG in forme crea forme di diapositiva modificabili. Dopo la conversione, il contenuto non è più gestito come una singola risorsa immagine.

Un flusso di lavoro tipico è quindi: aggiungere i dati immagine alla collection, ricevere un [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/), e quindi utilizzare quella risorsa in uno o più picture frame o riempimenti.

## **Aggiungere un'immagine incorporata**

Per inserire un'immagine locale, leggi il file, aggiungi i suoi dati alla collection e crea un picture frame che utilizza la risorsa [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) restituita.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

L'immagine aggiunta in questo modo è incorporata nella presentazione, quindi il file risultante non dipende dalla disponibilità del file immagine originale.

### **Aggiungere un'immagine dal Web**

Quando un'immagine è disponibile tramite HTTP o HTTPS, scarica i suoi byte, aggiungili alla presentation image collection e usa la risorsa immagine restituita nello stesso modo di un'immagine locale.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Convalida URL remote, dimensioni della risposta e tipologie di contenuto quando la fonte non è attendibile. nelle applicazioni che già utilizzano un altro client HTTP, è possibile scaricare l'immagine con quel client e passare i byte o lo stream risultante a [IImageCollection::AddImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimagecollection/addimage/).

## **Riutilizzare le immagini tra le diapositive**

Se la stessa immagine è necessaria più di una volta, aggiungila alla presentazione una sola volta e riutilizza il [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) restituito quando crei ulteriori picture frame. Questo evita di caricare ripetutamente gli stessi dati di origine e rende esplicita la relazione tra la risorsa immagine condivisa e i suoi utilizzi.

Per grafica che dovrebbe apparire automaticamente su molte diapositive, come un logo aziendale, considera di posizionare il picture frame su un [slide master](/slides/it/cpp/slide-master/) o layout anziché aggiungere una forma equivalente a ogni diapositiva.

## **Usare un'immagine come sfondo diapositiva**

Un'immagine di sfondo è assegnata al riempimento della diapositiva; non è aggiunta come forma picture-frame. È utile quando l'immagine deve coprire lo sfondo della diapositiva e non deve essere manipolata come un normale oggetto diapositiva.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Per opzioni di sfondo aggiuntive, inclusi sfondi master e layout, vedere [Presentation Background](/slides/it/cpp/presentation-background/).

## **Immagini incorporate e immagini collegate**

Le immagini incorporate e le immagini collegate hanno diverse compromissioni di portabilità e dimensione del file:

- **Immagine incorporata:** i dati dell'immagine sono memorizzati all'interno della presentazione. La presentazione è autonoma, ma la dimensione del file include i dati dell'immagine.
- **Immagine collegata:** la presentazione memorizza un percorso o URL a un'immagine esterna. Questo può ridurre la dimensione della presentazione, ma la risorsa esterna deve rimanere accessibile quando la presentazione è aperta o renderizzata.

Un'immagine collegata può essere creata assegnando il percorso o l'URL esterno tramite [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidespicture/set_linkpathlong/) anziché incorporare i dati dell'immagine.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Utilizza immagini collegate solo quando l'ambiente di distribuzione può accedere in modo affidabile alla risorsa esterna. Per presentazioni che devono funzionare offline o essere spostate tra sistemi, le immagini incorporate sono generalmente più sicure.

## **Lavorare con immagini SVG**

SVG è un formato vettoriale, quindi può essere utile per icone, diagrammi e altre grafiche che devono scalare senza la stessa perdita di dettaglio delle immagini raster. Aspose.Slides supporta SVG sia come risorsa immagine sia come fonte per forme di diapositiva modificabili.

### **Aggiungere un SVG come immagine**

Crea un [SvgImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/svgimage/), aggiungilo alla collection e posiziona la risorsa immagine risultante in un picture frame.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **File SVG con risorse esterne**

Un SVG può fare riferimento a immagini, fogli di stile o font esterni. Per questi casi, [SvgImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/svgimage/) fornisce costruttori che accettano un [IExternalResourceResolver](https://reference.aspose.com/slides/it/cpp/aspose.slides.import/iexternalresourceresolver/) e un URI di base. Il resolver può mappare un URI relativo a un URI assoluto consentito e restituire uno stream per la risorsa richiesta.

Il resolver rende disponibili le risorse esterne mentre Aspose.Slides elabora il SVG, ma non riscrive il SVG in un documento autonomo. Se il SVG deve rimanere portabile, incorpora le risorse richieste direttamente nel SVG, ad esempio usando URI `data:` per immagini collegate.

Quando i file SVG provengono da fonti non attendibili, limita gli schemi, le posizioni dei file e gli host a cui il resolver può accedere. I resolver di rete dovrebbero inoltre applicare timeout, limiti di dimensione della risposta e convalida del contenuto.

### **Convertire SVG in forme modificabili**

Aspose.Slides può convertire un SVG in un gruppo di forme di diapositiva modificabili, simile al comando corrispondente di PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Usa la sovraccarico [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addgroupshape/) che accetta un [ISvgImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/isvgimage/) per eseguire la conversione.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Utilizza la conversione SVG-in-forme quando gli elementi vettoriali individuali devono essere modificati come forme PowerPoint. Se il SVG deve solo essere visualizzato, mantenerlo come immagine è più semplice e evita di creare molte forme separate.

## **Sostituire una risorsa immagine esistente**

Usa [IPPImage::ReplaceImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/replaceimage/) quando desideri sostituire una risorsa immagine esistente. È particolarmente utile per grafiche condivise come loghi.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Se più picture frame, sfondi, master o layout usano la stessa risorsa immagine, la sostituzione di quella risorsa aggiorna tutti quegli utilizzi. Se deve cambiare solo un picture frame, assegna un'immagine diversa a quel frame anziché sostituire la risorsa condivisa.

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/replaceimage/) fornisce anche sovraccarichi che accettano un [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) o un altro [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/).

## **Linee guida pratiche per la gestione delle immagini**

### **Controllare la dimensione della presentazione**

Immagini raster di grandi dimensioni possono rendere una presentazione inutilmente grande. Usa immagini sorgente con dimensioni appropriate per la loro visualizzazione prevista, riutilizza le risorse immagine condivise quando possibile e evita di incorporare copie ripetute della stessa grafica ad alta risoluzione.

Per immagini raster già inserite in picture frame, [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/compressimage/) può ridurre i dati immagine in base alla risoluzione e alle impostazioni di ritaglio selezionate. Si tratta di una elaborazione picture-frame piuttosto che di gestione della collection, quindi vedere [Picture Frame](/slides/it/cpp/picture-frame/) per operazioni di formattazione correlate.

### **Scegliere tra contenuto incorporato e collegato**

L'incorporamento rende la presentazione portabile perché tutti i dati immagine necessari viaggiano con il file. Il collegamento può ridurre la dimensione del file, ma introduce una dipendenza esterna. Usa i collegamenti solo quando tale dipendenza è accettabile e stabile.

### **Riutilizzare il branding condiviso**

Per loghi, filigrane o grafiche decorative ricorrenti, utilizza una sola risorsa immagine e riusala. Se la grafica appartiene al design della presentazione piuttosto che al contenuto della diapositiva, posizionala su un master o layout affinché venga ereditata dalle diapositive appropriate.

### **Mantenere le risorse SVG portabili**

Un SVG autonomo è più facile da spostare e renderizzare in modo coerente rispetto a un SVG che dipende da file o risorse di rete esterne. Quando possibile, incorpora le risorse necessarie prima di importare il SVG. Converti SVG in forme solo quando gli elementi vettoriali individuali devono essere modificati.

### **Usare l'API immagine di Aspose.Slides**

Per i flussi di lavoro immagine in C++, usa le API Aspose.Slides [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) e [Images](https://reference.aspose.com/slides/it/cpp/aspose.slides/images/) quando hai bisogno di un oggetto immagine, e usa [IImageCollection::AddImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimagecollection/addimage/) quando devi registrare i dati immagine come risorsa della presentazione. I sovraccarichi della collection supportano anche array di byte e stream, utili quando i dati immagine provengono da file, client di rete, database o altre librerie.

Generare contenuti EMF da fogli di calcolo o da un altro prodotto è un flusso di integrazione separato e fuori dall'ambito di questo articolo. Se un file WMF o EMF esistente deve solo essere inserito in una presentazione, passa i suoi dati a un appropriato sovraccarico [IImageCollection::AddImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimagecollection/addimage/) senza aggiungere una dipendenza da un secondo prodotto al flusso di gestione delle immagini.

## **FAQ**

**Qual è la differenza tra la collection di immagini e un picture frame?**

"La collection di immagini memorizza risorse immagine riutilizzabili. Un picture frame è una forma della diapositiva che visualizza una di quelle risorse e fornisce formattazioni specifiche per le immagini, come ritaglio ed effetti."

**Qual è il modo migliore per sostituire lo stesso logo ovunque?**

"Se il logo è già condiviso come una risorsa immagine, sostituisci quella risorsa con [IPPImage::ReplaceImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/replaceimage/). Per un branding a livello di presentazione, posizionare il logo su un master o layout può anche ridurre il contenuto duplicato delle diapositive."

**Perché un'immagine collegata scompare su un altro computer?**

"Un'immagine collegata dipende dal suo file o URL esterno. Se quella risorsa non è raggiungibile dall'altro computer, l'immagine collegata potrebbe non essere disponibile. Incorporala quando la presentazione deve essere autonoma."

**È possibile modificare un SVG inserito come forme PowerPoint?**

"Sì. Converti l'SVG con [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addgroupshape/); il gruppo risultante contiene forme di diapositiva modificabili anziché un'unica immagine SVG."

**Come posso mantenere le presentazioni con molte immagini più piccole?**

"Riutilizza le risorse immagine condivise, evita fonti raster inutilmente grandi, comprimi le immagini raster appropriate quando opportuno, mantieni il branding ripetuto su master o layout, e usa immagini collegate solo quando una dipendenza esterna è accettabile."