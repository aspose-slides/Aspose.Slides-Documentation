---
title: Aggiungere filigrane alle presentazioni in C++
linktitle: Filigrana
type: docs
weight: 40
url: /it/cpp/watermark/
keywords:
- filigrana
- filigrana di testo
- filigrana immagine
- aggiungere filigrana
- modificare filigrana
- rimuovere filigrana
- eliminare filigrana
- aggiungere filigrana a PPT
- aggiungere filigrana a PPTX
- aggiungere filigrana a ODP
- rimuovere filigrana da PPT
- rimuovere filigrana da PPTX
- rimuovere filigrana da ODP
- eliminare filigrana da PPT
- eliminare filigrana da PPTX
- eliminare filigrana da ODP
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci filigrane di testo e di immagine nelle presentazioni PowerPoint e OpenDocument in C++ per indicare una bozza, informazioni confidenziali, copyright e altro."
---
## **Introduzione**

**Una filigrana** in una presentazione è un timbro di testo o immagine usato su una diapositiva o su tutte le diapositive della presentazione. Di solito, una filigrana serve a indicare che la presentazione è una bozza (ad es. una filigrana “Bozza”), che contiene informazioni riservate (ad es. una filigrana “Confidenziale”), a specificare a quale azienda appartiene (ad es. una filigrana “Nome Azienda”), a identificare l’autore della presentazione, ecc. Una filigrana aiuta a prevenire violazioni di copyright indicando che la presentazione non deve essere copiata. Le filigrane sono utilizzate sia nei formati di presentazione PowerPoint che OpenOffice. In Aspose.Slides, è possibile aggiungere una filigrana ai formati di file PowerPoint PPT, PPTX e OpenOffice ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/cpp/), esistono vari modi per creare filigrane in documenti PowerPoint o OpenOffice e modificarne il design e il comportamento. L’aspetto comune è che per aggiungere filigrane di testo si deve usare l’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/), mentre per aggiungere filigrane immagine si utilizza la classe [PictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/pictureframe/) o si riempie una forma di filigrana con un’immagine. `PictureFrame` implementa l’interfaccia [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/), consentendo di utilizzare tutte le impostazioni flessibili dell’oggetto forma. Poiché `ITextFrame` non è una forma e le sue impostazioni sono limitate, viene avvolto in un oggetto [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/).

Ci sono due modalità di applicazione di una filigrana: a una singola diapositiva o a tutte le diapositive della presentazione. Lo Slide Master viene usato per applicare una filigrana a tutte le diapositive — la filigrana viene aggiunta allo Slide Master, completamente progettata lì, e applicata a tutte le diapositive senza influire sull’autorizzazione a modificare la filigrana nelle diapositive individuali.

Una filigrana è generalmente considerata non modificabile da altri utenti. Per impedire che la filigrana (o piuttosto la forma padre della filigrana) venga modificata, Aspose.Slides fornisce la funzionalità di blocco delle forme. Una forma specifica può essere bloccata su una diapositiva normale o su uno Slide Master. Quando la forma della filigrana è bloccata sullo Slide Master, sarà bloccata su tutte le diapositive della presentazione.

È possibile impostare un nome per la filigrana in modo da poterla trovare in futuro, se si desidera eliminarla, cercandola nelle forme della diapositiva per nome.

È possibile progettare la filigrana in qualsiasi modo; tuttavia, generalmente le filigrane condividono caratteristiche comuni, come l’allineamento centrale, la rotazione, la posizione in primo piano, ecc. Vedremo come usare queste funzioni negli esempi seguenti.

## **Filigrana di Testo**

### **Aggiungere una Filigrana di Testo a una Diapositiva**

Per aggiungere una filigrana di testo in PPT, PPTX o ODP, è possibile prima aggiungere una forma alla diapositiva, quindi aggiungere un frame di testo a questa forma. Il frame di testo è rappresentato dall’interfaccia [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/). Questo tipo non eredita da [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/), che offre un ampio set di proprietà per posizionare la filigrana in modo flessibile. Pertanto, l’oggetto [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) viene avvolto in un oggetto [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/). Per aggiungere il testo della filigrana alla forma, utilizzare il metodo [AddTextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/addtextframe/) come mostrato di seguito.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Vedi anche" %}} 
- [Come utilizzare la classe TextFrame](/slides/it/cpp/text-formatting/)
{{% /alert %}}

### **Aggiungere una Filigrana di Testo a una Presentazione**

Se si desidera aggiungere una filigrana di testo all’intera presentazione (cioè a tutte le diapositive contemporaneamente), aggiungerla al [MasterSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/masterslide/). Il resto della logica è identico a quello per l’aggiunta di una filigrana a una singola diapositiva — creare un oggetto [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) e quindi aggiungere la filigrana usando il metodo [AddTextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Vedi anche" %}} 
- [Come utilizzare lo Slide Master](/slides/it/cpp/slide-master/)
{{% /alert %}}

### **Impostare la Trasparenza della Forma della Filigrana**

Per impostazione predefinita, la forma rettangolare è stilizzata con colori di riempimento e bordo. Le righe di codice seguenti rendono la forma trasparente.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Impostare il Font per una Filigrana di Testo**

È possibile modificare il font della filigrana di testo come mostrato di seguito.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Impostare il Colore del Testo della Filigrana**

Per impostare il colore del testo della filigrana, utilizzare questo codice:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Centrare una Filigrana di Testo**

È possibile centrare la filigrana su una diapositiva; per farlo, eseguire le seguenti operazioni:

```cpp
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

![La filigrana di testo](text_watermark.png)

## **Filigrana Immagine**

### **Aggiungere una Filigrana Immagine a una Presentazione**

Per aggiungere una filigrana immagine a una diapositiva della presentazione, è possibile eseguire quanto segue:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Bloccare una Filigrana dalla Modifica**

Se è necessario impedire la modifica di una filigrana, utilizzare il metodo [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/get_autoshapelock/) sulla forma. Con questa proprietà è possibile proteggere la forma da selezione, ridimensionamento, spostamento, raggruppamento con altri elementi, bloccare il suo testo dalla modifica e molto altro:

```cpp
// Blocca la forma della filigrana dalla modifica
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Portare una Filigrana in Primo Piano**

In Aspose.Slides, l’ordine Z delle forme può essere impostato tramite il metodo [IShapeCollection::Reorder](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/reorder/). Per farlo, è necessario chiamare questo metodo dall’elenco delle diapositive della presentazione e passare il riferimento della forma e il suo numero di ordine al metodo. In questo modo è possibile portare una forma in primo piano o spostarla sullo sfondo della diapositiva. Questa funzionalità è particolarmente utile se si deve posizionare una filigrana davanti alla presentazione:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Impostare la Rotazione della Filigrana**

Ecco un esempio di codice su come regolare la rotazione della filigrana in modo che sia posizionata diagonalmente sulla diapositiva:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Impostare un Nome per una Filigrana**

Aspose.Slides consente di impostare il nome di una forma. Utilizzando il nome della forma, è possibile accedervi in futuro per modificarla o eliminarla. Per impostare il nome della forma della filigrana, assegnarlo al metodo [IAutoShape::set_Name](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/set_name/):

```cpp
watermarkShape->set_Name(u"watermark");
```

## **Rimuovere una Filigrana**

Per rimuovere la forma della filigrana, utilizzare il metodo [IAutoShape::get_Name](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_name/) per trovarla tra le forme della diapositiva. Quindi, passare la forma della filigrana al metodo [IShapeCollection::Remove](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/remove/):

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **Esempio Live**

Potresti voler provare gli strumenti online **Aspose.Slides free** [Aggiungi Filigrana](https://products.aspose.app/slides/it/watermark) e [Rimuovi Filigrana](https://products.aspose.app/slides/it/watermark/remove-watermark).

![Strumenti online per aggiungere e rimuovere le filigrane](online_tools.png)

## **Domande Frequenti**

**Che cos'è una filigrana e perché dovrei usarla?**

Una filigrana è una sovrapposizione di testo o immagine applicata alle diapositive che aiuta a proteggere la proprietà intellettuale, a migliorare il riconoscimento del marchio o a impedire l’uso non autorizzato delle presentazioni.

**Posso aggiungere una filigrana a tutte le diapositive di una presentazione?**

Sì, Aspose.Slides consente di aggiungere programmaticamente una filigrana a ogni diapositiva di una presentazione. È possibile iterare tutte le diapositive e applicare le impostazioni della filigrana individualmente.

**Come posso regolare la trasparenza della filigrana?**

È possibile regolare la trasparenza della filigrana modificando le impostazioni di riempimento ([FillFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/get_fillformat/)) della forma. Questo garantisce che la filigrana sia discreta e non distragga dal contenuto della diapositiva.

**Quali formati immagine sono supportati per le filigrane?**

Aspose.Slides supporta vari formati immagine come PNG, JPEG, GIF, BMP, SVG e altri.

**Posso personalizzare il font e lo stile di una filigrana di testo?**

Sì, è possibile scegliere qualsiasi font, dimensione e stile per adattare il design della presentazione e mantenere la coerenza del marchio.

**Come modifico la posizione o l'orientamento di una filigrana?**

È possibile regolare la posizione e l'orientamento della filigrana programmaticamente modificando le coordinate, le dimensioni e le proprietà di rotazione della forma.