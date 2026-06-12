---
title: API pubblica e modifiche incompatibili retroattive in Aspose.Slides per Java 14.5.0
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
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche breaking in Aspose.Slides per Java per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Questa pagina elenca tutte le [aggiunte](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) classi, metodi, proprietà e così via, eventuali nuove [restrizioni](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) e altre [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) introdotte con l'Aspose.Slides for Java 14.5.0 API.

{{% /alert %}} 
## **API pubblica e modifiche incompatibili retroattive**
### **Classi e Metodi Aggiunti**
#### **Aggiunta l'interfaccia Aspose.Slides.IPresentationInfo e le classi PresentationInfo**
Rappresenta informazioni sulla presentazione.

Metodo Boolean isEncrypted() restituisce True se una presentazione è crittata, altrimenti restituisce False.

Metodo LoadFormat getLoadFormat() restituisce il tipo di presentazione.
#### **Aggiunto il metodo Aspose.Slides.IShape.isGrouped()**
Il metodo Aspose.Slides.IShape.isGrouped() determina se la forma è raggruppata.
#### **Aggiunto il metodo Aspose.Slides.IShape.getParentGroup()**
Il metodo Aspose.Slides.IShape.getParentGroup() restituisce l'oggetto GroupShape genitore se la forma è raggruppata. Altrimenti restituisce null.
#### **Aggiunto il metodo Aspose.Slides.IShapeCollection.addGroupShape()**
Il metodo Aspose.Slides.IShapeCollection.addGroupShape() crea un nuovo GroupShape e lo aggiunge alla fine della raccolta.

La dimensione e la posizione del frame del GroupShape saranno adattate al contenuto quando una nuova forma verrà aggiunta al GroupShape.
#### **Aggiunto il metodo Aspose.Slides.IShapeCollection.clear()**
Il metodo Aspose.Slides.IShapeCollection.clear() rimuove tutte le forme dalla raccolta.
#### **Aggiunto il metodo Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Il metodo Aspose.Slides.IShapeCollection.insertGroupShape(int) crea un nuovo GroupShape e lo inserisce nella raccolta all'indice specificato.
GroupShape frame size and position will be fitted to content when new shape will be added into the GroupShape.
#### **Aggiunti i metodi IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
Questi metodi consentono agli sviluppatori di ottenere informazioni su un file/stream di presentazione senza caricare l'intera presentazione.
#### **Aggiunto il metodo IPresentationFactory PresentationFactory.getInstance()**
Consente di utilizzare la funzionalità della factory senza istanziare.
### **Restrizioni**
#### **Sono state aggiunte restrizioni per l'uso di valori non definiti per IShape.getFrame()**
Il codice che tenta di assegnare un frame non definito a IShape.setFrame(IShapeFrame) non ha senso nei casi generali (in particolare quando il GroupShape genitore è annidato più volte in altri {{GroupShape}}). Per esempio:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

or

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Questo tipo di codice può portare a situazioni ambigue. Pertanto sono state aggiunte restrizioni per l'uso di valori non definiti per IShape.Frame. I valori di x, y, width, height, flipH, flipV e rotationAngle devono essere definiti (non Float.NaN o NullableBool.NotDefined). Il codice di esempio sopra ora genera un'eccezione ArgumentException.
Ciò si applica a questi casi d'uso:

``` java

 IShape shape = ...;

shape.setFrame(...); // non può essere indefinito

IShapeCollection shapes = ...;

// i parametri x, y, width, height non possono essere Float.NaN:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}
```

Ma il frame IShape.getRawFrame() può essere non definito. Questo ha senso quando una forma è collegata a un segnaposto. In tal caso i valori non definiti del frame della forma vengono sovrascritti dal segnaposto genitore. Se non esiste un segnaposto genitore per quella forma, vengono utilizzati i valori predefiniti quando si valuta il frame effettivo basato sul suo IShape.getRawFrame(). I valori predefiniti sono 0 e NullableBool.False per x, y, width, height, flipH, flipV e rotationAngle. Per esempio:

``` java

 IShape shape = ...; // la forma è collegata a un segnaposto

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// ora la forma eredita i valori x, y, height, flipH, flipV dal segnaposto e sovrascrive width=100 e rotationAngle=0.
```
### **Proprietà Modificate**
#### **Modificati il tipo e il nome del metodo Aspose.Slides.IShapeCollection.getParent()**
Il tipo della proprietà Aspose.Slides.IShapeCollection.Parent è stato modificato da ISlideComponent alla nuova interfaccia IGroupShape. L'interfaccia IGroupShape è discendente di ISlideComponent, quindi il codice esistente non richiede alcuna adattamento.

Il nome del metodo Aspose.Slides.IShapeCollection.getParent() è stato modificato da getParent a getParentGroup().
#### **Modifica il tipo dei metodi Aspose.Slides.IShapeFrame.getFlipH() e .getFlipV()**
Il tipo del metodo Aspose.Slides.IShapeFrame.getFlipH() è stato modificato da bool a NullableBool.

Il metodo IShape.getFrame() restituisce l'istanza effettiva di IShapeFrame (tutte le sue proprietà hanno valori effettivi definiti).

Il metodo IShape.getRawFrame() restituisce un'istanza di IShapeFrame la cui ogni proprietà può avere un valore non definito (in particolare FlipH o FlipV possono avere valore NullableBool.NotDefined).