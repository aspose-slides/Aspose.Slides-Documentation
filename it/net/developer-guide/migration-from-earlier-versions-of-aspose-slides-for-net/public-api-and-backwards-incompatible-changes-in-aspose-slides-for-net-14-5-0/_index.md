---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per .NET 14.5.0
linktitle: Aspose.Slides per .NET 14.5.0
type: docs
weight: 70
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per .NET per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunte](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/), eventuali nuove [restrizioni](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) e altre [modifiche](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) introdotte con l'API Aspose.Slides per .NET 14.5.0.

{{% /alert %}} 
## **API pubbliche e modifiche incompatibili retroattive**
### **Interfacce, classi, proprietà e metodi aggiunti**
#### **Aggiunta l'interfaccia Aspose.Slides.IPresentationInfo e la classe PresentationInfo**
Rappresenta le informazioni sulla presentazione.

- La proprietà Boolean IsEncrypted restituisce True se una presentazione è crittografata, altrimenti restituisce False.
- La proprietà LoadFormat restituisce il tipo di una presentazione.
#### **Aggiunta la proprietà Aspose.Slides.IShape.IsGrouped**
La proprietà Aspose.Slides.IShape.IsGrouped determina se una forma è raggruppata.
#### **Aggiunta la proprietà Aspose.Slides.IShape.ParentGroup**
La proprietà Aspose.Slides.IShape.ParentGroup restituisce l'oggetto GroupShape genitore se una forma è raggruppata. Altrimenti restituisce null.
#### **Aggiunto il metodo Aspose.Slides.IShapeCollection.AddGroupShape()**
Il metodo Aspose.Slides.IShapeCollection.AddGroupShape() crea un nuovo GroupShape e lo aggiunge alla fine della collezione.
Le dimensioni e la posizione del frame del GroupShape saranno adattate al contenuto quando viene aggiunta una nuova forma.
#### **Aggiunto il metodo Aspose.Slides.IShapeCollection.Clear()**
Il metodo Aspose.Slides.IShapeCollection.Clear() rimuove tutte le forme dalla collezione.
#### **Aggiunto il metodo Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Il metodo Aspose.Slides.IShapeCollection.InsertGroupShape(int) crea un nuovo GroupShape e lo inserisce nella collezione nella posizione di indice specificata.
Le dimensioni e la posizione del frame del GroupShape saranno adattate al contenuto quando viene aggiunta una nuova forma.
#### **Aggiunti i metodi IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Questi metodi consentono di ottenere informazioni su un file o un flusso di presentazione senza caricare completamente la presentazione.
#### **Aggiunta la proprietà IPresentationFactory PresentationFactory.Instance**
Questa proprietà consente agli sviluppatori di utilizzare la funzionalità di fabbrica senza istanziare.
### **Restrizioni**
#### **Restrizioni su IShape.Frame**
È stata aggiunta delle restrizioni per l'uso di valori non definiti per IShape.Frame. Il codice che tenta di assegnare un frame non definito a IShape.Frame non ha senso nella maggior parte dei casi (in particolare quando il GroupShape genitore è nidificato più volte in altri {{GroupShape}}). Ad esempio:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// Lancia ArgumentException: i valori del frame devono essere definiti.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

or

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Lancia ArgumentException: x, y, larghezza e altezza devono essere definiti.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Tale codice può portare a situazioni poco chiare. Pertanto sono state aggiunte delle restrizioni per l'uso di valori non definiti per IShape.Frame. I valori di x, y, width, height, flipH, flipV e rotationAngle devono essere definiti (e non impostati a float.NaN o NullableBool.NotDefined). Il codice di esempio sopra ora genera un'eccezione ArgumentException.
Ciò si applica a questi casi d'uso:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// I parametri x, y, larghezza e altezza non possono essere float.NaN, e flipH, flipV
// non possono essere NullableBool.NotDefined:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// La stessa restrizione si applica a tutti i metodi che creano una forma:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

Ma le proprietà del frame IShape.RawFrame possono essere non definite. Questo ha senso quando una forma è collegata a un segnaposto. In tal caso i valori non definiti del frame della forma vengono sovrascritti dal segnaposto genitore. Se non esiste un segnaposto genitore, la forma utilizza i valori predefiniti quando valuta il frame efficace basato sul suo IShape.RawFrame. I valori predefiniti sono 0 e NullableBool.False per x, y, width, height, flipH, flipV e rotationAngle. Per esempio:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // La forma è collegata a un segnaposto
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // ora la forma eredita i valori x, y, altezza, flipH, flipV dal segnaposto e sovrascrive larghezza=100 e rotationAngle=0.
}
``` 
### **Proprietà modificate**
#### **Modificato il nome e il tipo della proprietà Aspose.Slides.IShapeCollection.Parent**
- Il tipo della proprietà Aspose.Slides.IShapeCollection.Parent è stato cambiato da ISlideComponent alla nuova interfaccia IGroupShape. L'interfaccia IGroupShape discende da ISlideComponent, quindi il codice esistente non richiede adattamenti.
- Il nome della proprietà Aspose.Slides.IShapeCollection.Parent è stato modificato da Parent a ParentGroup.
#### **Modificati i tipi delle proprietà Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- Il tipo della proprietà Aspose.Slides.IShapeFrame.FlipH è stato cambiato da bool a NullableBool.
- La proprietà IShape.Frame restituisce un'istanza efficace di IShapeFrame (tutte le cui proprietà hanno valori efficaci definiti).
- La proprietà IShape.RawFrame restituisce un'istanza di IShapeFrame la cui ogni proprietà può avere un valore non definito (in particolare FlipH o FlipV possono avere il valore NullableBool.NotDefined).