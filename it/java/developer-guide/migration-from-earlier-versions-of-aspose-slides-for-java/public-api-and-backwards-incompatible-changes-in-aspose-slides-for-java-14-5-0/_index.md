---
title: API Pubblica e Modifiche Incompatibili Retroattive in Aspose.Slides per Java 14.5.0
linktitle: Aspose.Slides per Java 14.5.0
type: docs
weight: 40
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche breaking in Aspose.Slides per Java per migrare senza problemi le soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutte le [aggiunte](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) classi, metodi, proprietà e così via, eventuali nuove [restrizioni](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) e altre [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) introdotte con l'API Aspose.Slides per Java 14.5.0.

{{% /alert %}} 
## **API Pubblica e Modifiche Incompatibili Retroattive**
### **Classi e Metodi Aggiunti**
#### **Aggiunta l'interfaccia Aspose.Slides.IPresentationInfo e le classi PresentationInfo**
Rappresenta le informazioni sulla presentazione.

Metodo Boolean isEncrypted() restituisce True se una presentazione è crittografata, altrimenti restituisce False.

Metodo LoadFormat getLoadFormat() restituisce il tipo di presentazione.
#### **Aggiunto il metodo Aspose.Slides.IShape.isGrouped()**
Il metodo Aspose.Slides.IShape.isGrouped() determina se la forma è raggruppata.
#### **Aggiunto il metodo Aspose.Slides.IShape.getParentGroup()**
Il metodo Aspose.Slides.IShape.getParentGroup() restituisce l'oggetto GroupShape padre se la forma è raggruppata. Altrimenti restituisce null.
#### **Aggiunto il metodo Aspose.Slides.IShapeCollection.addGroupShape()**
Il metodo Aspose.Slides.IShapeCollection.addGroupShape() crea un nuovo GroupShape e lo aggiunge alla fine della collezione.

La dimensione e la posizione del frame del GroupShape saranno adattate al contenuto quando una nuova forma verrà aggiunta al GroupShape.
#### **Aggiunto il metodo Aspose.Slides.IShapeCollection.clear()**
Il metodo Aspose.Slides.IShapeCollection.clear() rimuove tutte le forme dalla collezione.
#### **Aggiunto il metodo Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Il metodo Aspose.Slides.IShapeCollection.insertGroupShape(int) crea un nuovo GroupShape e lo inserisce nella collezione all'indice specificato.
La dimensione e la posizione del frame del GroupShape saranno adattate al contenuto quando una nuova forma verrà aggiunta al GroupShape.
#### **Aggiunti i metodi IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream)**
Questi metodi consentono agli sviluppatori di ottenere informazioni su un file/stream di presentazione senza caricare l'intera presentazione.
#### **Aggiunto il metodo IPresentationFactory PresentationFactory.getInstance()**
Consente di utilizzare le funzionalità della factory senza istanziare un oggetto.
### **Restrizioni**
#### **Sono state aggiunte restrizioni per l'uso di valori indefiniti per IShape.getFrame()**
Il codice che tenta di assegnare un frame indefinito a IShape.setFrame(IShapeFrame) non ha senso nei casi generali (in particolare quando il GroupShape padre è nidificato più volte in altri {{GroupShape}}). Ad esempio:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // Genera un'ArgumentException: i valori del frame devono essere definiti.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

o

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Genera un'ArgumentException: i valori x, y, larghezza e altezza devono essere definiti.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

Tale codice può portare a situazioni poco chiare. Pertanto sono state aggiunte restrizioni per l'uso di valori indefiniti per IShape.Frame. I valori di x, y, width, height, flipH, flipV e rotationAngle devono essere definiti (non Float.NaN o NullableBool.NotDefined). Il codice di esempio sopra ora genera un'eccezione ArgumentException.
Questo vale per i seguenti casi d'uso:

``` java
// Il frame passato a IShape.setFrame(IShapeFrame) non può contenere valori indefiniti.

// I parametri x, y, larghezza e altezza dei seguenti metodi IShapeCollection
// non possono nemmeno essere Float.NaN:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

Ma il frame restituito da IShape.getRawFrame() può essere indefinito. Questo ha senso quando una forma è collegata a un placeholder. In tal caso i valori indefiniti del frame della forma vengono sovrascritti dal placeholder padre. Se non esiste un placeholder padre per quella forma, vengono usati i valori predefiniti quando si valuta il frame effettivo basato sul suo IShape.getRawFrame(). I valori predefiniti sono 0 e NullableBool.False per x, y, width, height, flipH, flipV e rotationAngle. Ad esempio:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // La forma è collegata a un segnaposto.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Ora la forma eredita i valori x, y, altezza, flipH e flipV dal segnaposto
    // e sovrascrive larghezza = 100 e rotationAngle = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Proprietà Modificate**
#### **Modificato il tipo e il nome del metodo Aspose.Slides.IShapeCollection.getParent()**
Il tipo della proprietà Aspose.Slides.IShapeCollection.Parent è stato cambiato da ISlideComponent alla nuova interfaccia IGroupShape. L'interfaccia IGroupShape discende da ISlideComponent, quindi il codice esistente non richiede alcuna modifica.

Il nome del metodo Aspose.Slides.IShapeCollection.getParent() è stato cambiato da getParent a getParentGroup().
#### **Modificato il tipo dei metodi Aspose.Slides.IShapeFrame.getFlipH() e .getFlipV()**
Il tipo del metodo Aspose.Slides.IShapeFrame.getFlipH() è stato cambiato da bool a NullableBool.

Il metodo IShape.getFrame() restituisce l'istanza effettiva di IShapeFrame (tutte le cui proprietà hanno valori effettivi definiti).

Il metodo IShape.getRawFrame() restituisce un'istanza di IShapeFrame in cui ciascuna proprietà può avere valore indefinito (in particolare FlipH o FlipV possono avere valore NullableBool.NotDefined).