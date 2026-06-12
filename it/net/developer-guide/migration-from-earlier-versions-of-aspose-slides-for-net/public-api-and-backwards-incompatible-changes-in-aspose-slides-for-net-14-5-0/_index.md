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
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per .NET per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [added](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/), eventuali nuove [restrictions](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) e altri [changes](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) introdotti con l’API Aspose.Slides per .NET 14.5.0.

{{% /alert %}} 
## **Public API and Backwards Incompatible Changes**
### **Added Interfaces, Classes, Properties and Methods**
#### **Added the Aspose.Slides.IPresentationInfo Interface and PresentationInfo Class**
Rappresenta le informazioni sulla presentazione.

- La proprietà Boolean IsEncrypted restituisce True se una presentazione è crittografata, altrimenti restituisce False.
- La proprietà LoadFormat restituisce il tipo di una presentazione.
#### **Added the Aspose.Slides.IShape.IsGrouped Property**
La proprietà Aspose.Slides.IShape.IsGrouped determina se una forma è raggruppata.
#### **Added the Aspose.Slides.IShape.ParentGroup Property**
La proprietà Aspose.Slides.IShape.ParentGroup restituisce l’oggetto GroupShape genitore se una forma è raggruppata. Altrimenti restituisce null.
#### **Added the Aspose.Slides.IShapeCollection.AddGroupShape() Method**
Il metodo Aspose.Slides.IShapeCollection.AddGroupShape() crea un nuovo GroupShape e lo aggiunge alla fine della collezione.
La dimensione e la posizione del frame del GroupShape saranno adattate al contenuto quando viene aggiunta una nuova forma.
#### **Added the Aspose.Slides.IShapeCollection.Clear() Method**
Il metodo Aspose.Slides.IShapeCollection.Clear() rimuove tutte le forme dalla collezione.
#### **Added the Aspose.Slides.IShapeCollection.InsertGroupShape(int) Method**
Il metodo Aspose.Slides.IShapeCollection.InsertGroupShape(int) crea un nuovo GroupShape e lo inserisce nella collezione nella posizione indice specificata.
La dimensione e la posizione del frame del GroupShape saranno adattate al contenuto quando viene aggiunta una nuova forma.
#### **Added the IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) Methods**
Questi metodi consentono di ottenere informazioni su un file o stream di presentazione senza caricare completamente la presentazione.
#### **Added the IPresentationFactory PresentationFactory.Instance Property**
Questa proprietà permette agli sviluppatori di utilizzare le funzionalità della factory senza istanziare un oggetto.
### **Restrictions**
#### **Restrictions to IShape.Frame**
Sono state aggiunte restrizioni per l’uso di valori non definiti per IShape.Frame. Un codice che tenta di assegnare un frame non definito a IShape.Frame non ha senso nella maggior parte dei casi (in particolare quando il GroupShape padre è annidato più volte in altri {{GroupShape}}). Ad esempio:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

o

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Questo tipo di codice può portare a situazioni poco chiare. Perciò sono state aggiunte restrizioni per l’uso di valori non definiti per IShape.Frame. I valori di x, y, width, height, flipH, flipV e rotationAngle devono essere definiti (e non impostati a float.NaN o NullableBool.NotDefined). Il codice di esempio sopra ora genera un’eccezione ArgumentException.
Ciò si applica a questi casi d’uso:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Non può essere indefinito

IShapeCollection shapes = ...;

// I parametri x, y, width, height non possono essere float.NaN:

{

    shapes.AddAudioFrameCD(...);

    shapes.AddAudioFrameEmbedded(...);

    shapes.AddAudioFrameLinked(...);

    shapes.AddAutoShape(...);

    shapes.AddChart(...);

    shapes.AddConnector(...);

    shapes.AddOleObjectFrame(...);

    shapes.AddPictureFrame(...);

    shapes.AddSmartArt(...);

    shapes.AddTable(...);

    shapes.AddVideoFrame(...);

    shapes.InsertAudioFrameEmbedded(...);

    shapes.InsertAudioFrameLinked(...);

    shapes.InsertAutoShape(...);

    shapes.InsertChart(...);

    shapes.InsertConnector(...);

    shapes.InsertOleObjectFrame(...);

    shapes.InsertPictureFrame(...);

    shapes.InsertTable(...);

    shapes.InsertVideoFrame(...);

}


``` 

Ma le proprietà del frame IShape.RawFrame possono essere non definite. Questo ha senso quando una forma è collegata a un segnaposto. In tal caso i valori di frame non definiti della forma vengono sovrascritti dal segnaposto padre. Se non esiste un segnaposto padre, la forma utilizza valori predefiniti quando valuta il frame efficace basato su IShape.RawFrame. I valori predefiniti sono 0 e NullableBool.False per x, y, width, height, flipH, flipV e rotationAngle. Per esempio:

``` csharp

 IShape shape = ...; // shape è collegata al segnaposto

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// ora shape eredita i valori x, y, height, flipH, flipV dal placeholder e sovrascrive width=100 e rotationAngle=0.

``` 
### **Changed Properties**
#### **Changed the Aspose.Slides.IShapeCollection.Parent Property Name and Type**
- Il tipo della proprietà Aspose.Slides.IShapeCollection.Parent è stato modificato da ISlideComponent alla nuova interfaccia IGroupShape. L’interfaccia IGroupShape discende da ISlideComponent, quindi il codice esistente non richiede adattamenti.
- Il nome della proprietà Aspose.Slides.IShapeCollection.Parent è stato cambiato da Parent a ParentGroup.
#### **Changed the Aspose.Slides.IShapeFrame.FlipH, .FlipV Properties Types**
- Il tipo della proprietà Aspose.Slides.IShapeFrame.FlipH è stato modificato da bool a NullableBool.
- La proprietà IShape.Frame restituisce un’istanza efficace di IShapeFrame (tutte le sue proprietà hanno valori efficaci definiti).
- La proprietà IShape.RawFrame restituisce un’istanza di IShapeFrame in cui ciascuna proprietà può avere un valore non definito (in particolare FlipH o FlipV possono avere valore NullableBool.NotDefined).