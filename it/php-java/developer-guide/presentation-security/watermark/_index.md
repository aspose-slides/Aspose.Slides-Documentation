---
title: Aggiungere filigrane alle presentazioni in PHP
linktitle: Filigrana
type: docs
weight: 40
url: /it/php-java/watermark/
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
- PHP
- Aspose.Slides
description: "Gestisci filigrane di testo e immagine in presentazioni PowerPoint e OpenDocument in PHP per indicare una bozza, informazioni riservate, diritti d'autore e altro."
---
## **Introduzione**

**Una filigrana** in una presentazione è un timbro di testo o immagine utilizzato su una diapositiva o su tutte le diapositive della presentazione. Di solito, una filigrana serve a indicare che la presentazione è una bozza (ad es., una filigrana “Bozza”), che contiene informazioni riservate (ad es., una filigrana “Confidenziale”), a specificare a quale azienda appartiene (ad es., una filigrana “Nome Azienda”), a identificare l’autore della presentazione, ecc. Una filigrana aiuta a prevenire violazioni di copyright indicando che la presentazione non deve essere copiata. Le filigrane sono usate sia nei formati di presentazione PowerPoint che OpenOffice. In Aspose.Slides, è possibile aggiungere una filigrana ai formati di file PowerPoint PPT, PPTX e OpenOffice ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/php-java/), esistono diversi modi per creare filigrane in documenti PowerPoint o OpenOffice e modificare il loro design e comportamento. L’aspetto comune è che, per aggiungere filigrane di testo, è necessario utilizzare la classe [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/), e per aggiungere filigrane di immagine, utilizzare la classe [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) o riempire una forma di filigrana con un’immagine. `PictureFrame` implementa la classe [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/), consentendo di usare tutte le impostazioni flessibili dell’oggetto forma. Poiché `ITextFrame` non è una forma e le sue impostazioni sono limitate, viene avvolto in un oggetto [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/).

Ci sono due modalità di applicazione di una filigrana: a una singola diapositiva o a tutte le diapositive della presentazione. Lo Slide Master è usato per applicare una filigrana a tutte le diapositive — la filigrana viene aggiunta allo Slide Master, progettata completamente lì e applicata a tutte le diapositive senza influire sul permesso di modificare la filigrana su singole diapositive.

Una filigrana è generalmente considerata non modificabile da altri utenti. Per impedire che la filigrana (o più precisamente la forma padre della filigrana) venga modificata, Aspose.Slides fornisce funzionalità di blocco forma. Una specifica forma può essere bloccata su una diapositiva normale o su uno Slide Master. Quando la forma della filigrana è bloccata sullo Slide Master, sarà bloccata su tutte le diapositive della presentazione.

È possibile impostare un nome per la filigrana in modo da poterla trovare in futuro, qualora si desideri eliminarla, cercandola tra le forme della diapositiva per nome.

È possibile progettare la filigrana in qualsiasi modo; tuttavia, di solito le filigrane presentano caratteristiche comuni, come allineamento al centro, rotazione, posizione in primo piano, ecc. Considereremo come utilizzare queste caratteristiche negli esempi seguenti.

## **Filigrana di testo**

### **Aggiungere una filigrana di testo a una diapositiva**

Per aggiungere una filigrana di testo in PPT, PPTX o ODP, è possibile prima aggiungere una forma alla diapositiva, poi aggiungere un frame di testo a questa forma. Il frame di testo è rappresentato dalla classe [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/). Questo tipo non eredita da [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/), che dispone di un ampio set di proprietà per posizionare la filigrana in modo flessibile. Pertanto, l’oggetto [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) è avvolto in un oggetto [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/). Per aggiungere il testo della filigrana alla forma, utilizzare il metodo [addTextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/#addTextFrame) come mostrato di seguito.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Vedi anche" %}} 
- [Come usare la classe TextFrame](/slides/it/php-java/text-formatting/)
{{% /alert %}}

### **Aggiungere una filigrana di testo a una presentazione**

Se si desidera aggiungere una filigrana di testo a tutta la presentazione (cioè a tutte le diapositive contemporaneamente), aggiungerla allo [MasterSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/). Il resto della logica è lo stesso di quando si aggiunge una filigrana a una singola diapositiva — creare un oggetto [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) e quindi aggiungere la filigrana usando il metodo [addTextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/#addTextFrame).

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Vedi anche" %}} 
- [Come usare lo Slide Master](/slides/it/php-java/slide-master/)
{{% /alert %}}

### **Impostare la trasparenza della forma della filigrana**

Per impostazione predefinita, la forma rettangolare è stilizzata con colori di riempimento e linea. Le seguenti righe di codice rendono la forma trasparente.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Impostare il carattere per una filigrana di testo**

È possibile cambiare il carattere della filigrana di testo come mostrato di seguito.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Impostare il colore del testo della filigrana**

Per impostare il colore del testo della filigrana, utilizzare questo codice:

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **Centrare una filigrana di testo**

È possibile centrare la filigrana su una diapositiva; per farlo, eseguire quanto segue:

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

L’immagine seguente mostra il risultato finale.

![La filigrana di testo](text_watermark.png)

## **Filigrana di immagine**

### **Aggiungere una filigrana di immagine a una presentazione**

Per aggiungere una filigrana di immagine a una diapositiva della presentazione, è possibile procedere come indicato di seguito:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **Bloccare una filigrana dalla modifica**

Se è necessario impedire che una filigrana venga modificata, utilizzare il metodo [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/#getAutoShapeLock) sulla forma. Con questa proprietà è possibile proteggere la forma da selezione, ridimensionamento, riposizionamento, raggruppamento con altri elementi, bloccare il suo testo dalla modifica e molto altro:

```php
// Blocca la forma della filigrana dalla modifica
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **Portare una filigrana in primo piano**

In Aspose.Slides, l’ordine Z delle forme può essere impostato tramite il metodo [ShapeCollection.reorder](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#reorder). Per farlo, è necessario chiamare questo metodo dall’elenco delle diapositive della presentazione e passare il riferimento della forma e il suo numero di ordine al metodo. In questo modo è possibile portare una forma in primo piano o inviarla sullo sfondo della diapositiva. Questa funzionalità è particolarmente utile se si deve posizionare una filigrana davanti alla presentazione:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **Impostare la rotazione della filigrana**

Ecco un esempio di codice su come regolare la rotazione della filigrana affinché sia posizionata diagonalmente sulla diapositiva:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **Impostare un nome per una filigrana**

Aspose.Slides consente di impostare il nome di una forma. Utilizzando il nome della forma, è possibile accedervi in futuro per modificarla o eliminarla. Per impostare il nome della forma della filigrana, assegnarlo al metodo [AutoShape.setName](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#setName):

```php
$watermarkShape->setName("watermark");
```

### **Rimuovere una filigrana**

Per rimuovere la forma della filigrana, utilizzare il metodo [AutoShape.getName](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getName) per trovarla tra le forme della diapositiva. Poi, passare la forma della filigrana al metodo [ShapeCollection.remove](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#remove):

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **FAQ**

**Cos'è una filigrana e perché dovrei usarla?**

Una filigrana è una sovrapposizione di testo o immagine applicata alle diapositive che aiuta a proteggere la proprietà intellettuale, a rafforzare il riconoscimento del brand o a prevenire l'uso non autorizzato delle presentazioni.

**Posso aggiungere una filigrana a tutte le diapositive di una presentazione?**

Sì, Aspose.Slides consente di aggiungere programmaticamente una filigrana a ogni diapositiva di una presentazione. È possibile iterare tutte le diapositive e applicare le impostazioni della filigrana individualmente.

**Come posso regolare la trasparenza della filigrana?**

È possibile regolare la trasparenza della filigrana modificando le impostazioni di riempimento ([getFillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getfillformat/)) della forma. In questo modo la filigrana risulta discreta e non distrae dal contenuto della diapositiva.

**Quali formati immagine sono supportati per le filigrane?**

Aspose.Slides supporta vari formati immagine come PNG, JPEG, GIF, BMP, SVG e altri.

**Posso personalizzare il carattere e lo stile di una filigrana di testo?**

Sì, è possibile scegliere qualsiasi carattere, dimensione e stile per adattare il design della presentazione e mantenere la coerenza del brand.

**Come modifico la posizione o l'orientamento di una filigrana?**

È possibile regolare programmaticamente la posizione e l'orientamento della filigrana modificando le coordinate, le dimensioni e le proprietà di rotazione della forma.