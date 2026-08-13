---
title: Aggiungi Filigrane alle Presentazioni in C++
linktitle: Filigrana
type: docs
weight: 40
url: /it/cpp/watermark/
keywords:
- filigrana
- filigrana di testo
- filigrana di immagine
- aggiungi filigrana
- modifica filigrana
- rimuovi filigrana
- elimina filigrana
- aggiungi filigrana a PPT
- aggiungi filigrana a PPTX
- aggiungi filigrana a ODP
- rimuovi filigrana da PPT
- rimuovi filigrana da PPTX
- rimuovi filigrana da ODP
- elimina filigrana da PPT
- elimina filigrana da PPTX
- elimina filigrana da ODP
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci le filigrane di testo e le filigrane di immagine in presentazioni PowerPoint e OpenDocument in C++ per indicare una bozza, informazioni riservate, diritti d'autore e altro."
---
## **Introduzione**

**Una filigrana** in una presentazione è un timbro di testo o immagine usato su una diapositiva o su tutte le diapositive della presentazione. Di solito, una filigrana viene usata per indicare che la presentazione è una bozza (ad es., una filigrana “Bozza”), che contiene informazioni riservate (ad es., una filigrana “Confidenziale”), per specificare a quale azienda appartiene (ad es., una filigrana “Nome Azienda”), per identificare l’autore della presentazione, ecc. Una filigrana aiuta a prevenire violazioni di copyright indicando che la presentazione non deve essere copiata. Le filigrane sono usate sia nei formati di presentazione PowerPoint che OpenOffice. In Aspose.Slides, è possibile aggiungere una filigrana ai formati di file PowerPoint PPT, PPTX e OpenOffice ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/cpp/), esistono vari modi per creare filigrane in documenti PowerPoint o OpenOffice e modificare il loro design e comportamento. L’aspetto comune è che, per aggiungere filigrane di testo, si dovrebbe usare l’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/), e per aggiungere filigrane di immagine, usare la classe [PictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/pictureframe/) o riempire una forma di filigrana con un’immagine. `PictureFrame` implementa l’interfaccia [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/), consentendo di usare tutte le impostazioni flessibili dell’oggetto forma. Poiché `ITextFrame` non è una forma e le sue impostazioni sono limitate, viene avvolto in un oggetto [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/).

Ci sono due modi per applicare una filigrana: a una singola diapositiva o a tutte le diapositive della presentazione. Lo Slide Master viene usato per applicare una filigrana a tutte le diapositive della presentazione — la filigrana viene aggiunta allo Slide Master, completamente progettata lì, e applicata a tutte le diapositive senza influire sul permesso di modificare la filigrana nelle singole diapositive.

Una filigrana è generalmente considerata non modificabile da altri utenti. Per impedire che la filigrana (o più precisamente la forma genitore della filigrana) venga modificata, Aspose.Slides fornisce la funzionalità di blocco delle forme. Una forma specifica può essere bloccata su una diapositiva normale o su uno Slide Master. Quando la forma della filigrana è bloccata sullo Slide Master, sarà bloccata su tutte le diapositive della presentazione.

È possibile impostare un nome per la filigrana così che in futuro, se si desidera eliminarla, si possa trovare nelle forme della diapositiva per nome.

È possibile progettare la filigrana in qualsiasi modo; tuttavia, di solito le filigrane hanno caratteristiche comuni, come allineamento centrale, rotazione, posizione in primo piano, ecc. Considereremo come utilizzare questi aspetti negli esempi seguenti.

## **Filigrana di Testo**

### **Aggiungi una Filigrana di Testo a una Diapositiva**

Per aggiungere una filigrana di testo in PPT, PPTX o ODP, è possibile prima aggiungere una forma alla diapositiva, poi aggiungere un fotogramma di testo a questa forma. Il fotogramma di testo è rappresentato dall’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/). Questo tipo non eredita da [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/), che offre un ampio set di proprietà per posizionare la filigrana in modo flessibile. Pertanto, l’oggetto [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) è avvolto in un oggetto [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/). Per aggiungere il testo della filigrana alla forma, utilizzare il metodo [AddTextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/addtextframe/) come mostrato di seguito.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Vedi anche" %}} 
- [How to Use the TextFrame Class](/slides/it/cpp/text-formatting/)
{{% /alert %}}

### **Aggiungi una Filigrana di Testo a una Presentazione**

Se si desidera aggiungere una filigrana di testo all’intera presentazione (cioè a tutte le diapositive contemporaneamente), aggiungerla allo [MasterSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/masterslide/). Il resto della logica è identico a quello per aggiungere una filigrana a una singola diapositiva — creare un oggetto [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) e quindi aggiungere la filigrana usando il metodo [AddTextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Vedi anche" %}} 
- [How to Use the Slide Master](/slides/it/cpp/slide-master/)
{{% /alert %}}

### **Imposta la Trasparenza della Forma della Filigrana**

Per impostazione predefinita, la forma rettangolare è stilizzata con colori di riempimento e contorno. Le seguenti righe di codice rendono la forma trasparente.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Imposta il Font per una Filigrana di Testo**

È possibile cambiare il font della filigrana di testo come mostrato di seguito.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Imposta il Colore del Testo della Filigrana**

Per impostare il colore del testo della filigrana, utilizzare questo codice:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Centra una Filigrana di Testo**

È possibile centrare la filigrana su una diapositiva; per farlo, eseguire quanto segue:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

L’immagine seguente mostra il risultato finale.

![The text watermark](text_watermark.png)

## **Filigrana di Immagine**

### **Aggiungi una Filigrana di Immagine a una Presentazione**

Per aggiungere una filigrana di immagine a una diapositiva della presentazione, è possibile eseguire quanto segue:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Blocca una Filigrana dalla Modifica**

Se è necessario impedire la modifica di una filigrana, utilizzare il metodo [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/get_autoshapelock/) sulla forma. Con questa proprietà, è possibile proteggere la forma da selezione, ridimensionamento, riposizionamento, raggruppamento con altri elementi, bloccare il suo testo dalla modifica e molto altro:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// Blocca la forma della filigrana dalla modifica
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **Porta una Filigrana in Primo Piano**

In Aspose.Slides, l’ordine Z delle forme può essere impostato tramite il metodo [IShapeCollection::Reorder](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/reorder/). Per farlo, è necessario chiamare questo metodo dall’elenco delle diapositive della presentazione e passare il riferimento della forma e il suo numero d’ordine al metodo. In questo modo è possibile portare una forma in primo piano o inviarla sullo sfondo della diapositiva. Questa funzione è particolarmente utile se occorre posizionare una filigrana davanti alla presentazione:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Imposta la Rotazione della Filigrana**

Ecco un esempio di codice su come regolare la rotazione della filigrana in modo che sia posizionata diagonalmente sulla diapositiva:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Imposta un Nome per una Filigrana**

Aspose.Slides consente di impostare il nome di una forma. Utilizzando il nome della forma, è possibile accedervi in futuro per modificarla o eliminarla. Per impostare il nome della forma della filigrana, assegnarlo al metodo [IAutoShape::set_Name](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/set_name/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **Rimuovi una Filigrana**

Per rimuovere la forma della filigrana, utilizzare il metodo [IAutoShape::get_Name](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_name/) per trovarla nelle forme della diapositiva. Quindi, passare la forma della filigrana al metodo [IShapeCollection::Remove](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/remove/):

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **Esempio Live**

Potresti voler provare gli strumenti online **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/it/watermark) e [Remove Watermark](https://products.aspose.app/slides/it/watermark/remove-watermark).

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

### Cos'è una filigrana e perché dovrei usarla?

Una filigrana è una sovrapposizione di testo o immagine applicata alle diapositive che aiuta a proteggere la proprietà intellettuale, migliorare il riconoscimento del marchio o impedire l’uso non autorizzato delle presentazioni.

### Posso aggiungere una filigrana a tutte le diapositive di una presentazione?

Sì, Aspose.Slides consente di aggiungere programmaticamente una filigrana a ogni diapositiva di una presentazione. È possibile iterare su tutte le diapositive e applicare le impostazioni della filigrana singolarmente.

### Come posso regolare la trasparenza della filigrana?

È possibile regolare la trasparenza della filigrana modificando le impostazioni di riempimento ([FillFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/get_fillformat/)) della forma. Questo garantisce che la filigrana sia discreta e non distragga dal contenuto della diapositiva.

### Quali formati immagine sono supportati per le filigrane?

Aspose.Slides supporta vari formati immagine come PNG, JPEG, GIF, BMP, SVG e altri.

### Posso personalizzare il font e lo stile di una filigrana di testo?

Sì, è possibile scegliere qualsiasi font, dimensione e stile per adattarsi al design della presentazione e mantenere la coerenza del marchio.

### Come cambio la posizione o l’orientamento di una filigrana?

È possibile modificare la posizione e l’orientamento della filigrana programmaticamente modificando le coordinate, la dimensione e le proprietà di rotazione della forma.