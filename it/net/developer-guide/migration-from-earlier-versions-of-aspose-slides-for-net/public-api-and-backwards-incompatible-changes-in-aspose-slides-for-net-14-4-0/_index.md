---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per .NET 14.4.0
linktitle: Aspose.Slides per .NET 14.4.0
type: docs
weight: 60
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
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
description: "Revisiona gli aggiornamenti dell'API pubblica e le modifiche incompatibili retroattive in Aspose.Slides per .NET per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
## **API pubbliche e modifiche incompatibili retroattive**
### **Interfacce, classi, metodi e proprietà aggiunti**
#### **Proprietà Aspose.Slides.ILayoutSlide.HasDependingSlides è stata aggiunta**
La proprietà Aspose.Slides.ILayoutSlide.HasDependingSlides restituisce true se esiste almeno una diapositiva che dipende da questa diapositiva layout. Ad esempio:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Metodo Aspose.Slides.ILayoutSlide.Remove()**
Il metodo Aspose.Slides.ILayoutSlide.Remove() consente di rimuovere un layout da una presentazione con il minimo di codice. Ad esempio:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Metodo Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
Il metodo Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) consente di rimuovere un layout dalla collezione. Esempi di codice:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

o

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Il metodo Aspose.Slides.ILayoutSlideCollection.RemoveUnused() consente di rimuovere i layout slide inutilizzati (layout slide la cui proprietà HasDependingSlides è false). Esempi di codice:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

o

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Proprietà Aspose.Slides.IMasterSlide.HasDependingSlides**
La proprietà Aspose.Slides.IMasterSlide.HasDependingSlides restituisce true se esiste almeno una diapositiva che dipende da questa diapositiva master. Ad esempio:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Metodo Aspose.Slides.ISlide.Remove()**
Il metodo Aspose.Slides.ISlide.Remove() consente di rimuovere una diapositiva da una presentazione con il minimo di codice. Ad esempio:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
La proprietà Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat restituisce IFillFormat per il proiettile di un nodo SmartArt se il layout fornisce i proiettili. Può essere usata per impostare l’immagine del proiettile.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Proprietà Aspose.Slides.SmartArt.ISmartArtNode.Level**
La proprietà Aspose.Slides.SmartArt.ISmartArtNode.Level restituisce il livello nidificato per i nodi SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Proprietà Aspose.Slides.SmartArt.ISmartArtNode.Position**
La proprietà Aspose.Slides.SmartArt.ISmartArtNode.Position restituisce la posizione di un nodo tra i suoi fratelli.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Metodo Aspose.Slides.SmartArt.ISmartArtNode.Remove() è stato aggiunto**
Il metodo Aspose.Slides.SmartArt.ISmartArtNode.Remove() consente di rimuovere un nodo da un diagramma.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Interfaccia IGlobalLayoutSlideCollection e classe GlobalLayoutSlideCollection**
L’interfaccia IGlobalLayoutSlideCollection e la classe GlobalLayoutSlideCollection sono state aggiunte allo spazio dei nomi Aspose.Slides.

La classe GlobalLayoutSlideCollection implementa l’interfaccia IGlobalLayoutSlideCollection.

L’interfaccia IGlobalLayoutSlideCollection rappresenta una collezione di tutti i layout slide in una presentazione. La proprietà IPresentation.LayoutSlides è di tipo IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection estende l’interfaccia ILayoutSlideCollection con metodi per aggiungere e clonare layout slide nel contesto dell’unione delle collezioni individuali dei layout slide del master:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Può essere usato per aggiungere una copia di un layout slide specificato alla presentazione. Questo metodo conserva la formattazione di origine (quando si clona un layout tra presentazioni diverse, anche il master del layout può essere clonato. Il registro interno è usato per tracciare i master clonati automaticamente e prevenire la creazione di più cloni dello stesso master slide).
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Usato per aggiungere una copia di un layout slide specificato a una presentazione. Il nuovo layout sarà collegato al master definito nella presentazione di destinazione. Questa opzione è analoga a copiare o incollare con l’opzione **Use Destination Theme** in Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Usato per aggiungere un nuovo layout slide a una presentazione. Tipi di layout supportati: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Il nome del layout può essere generato automaticamente. Un layout aggiunto di tipo SlideLayoutType.Custom non contiene segnaposti né forme. Un analogo di questo metodo è il metodo IMasterLayoutSlideCollection.Add(SlideLayoutType, string) accessibile tramite la proprietà IMasterSlide.LayoutSlides.
#### **Interfaccia IMasterLayoutSlideCollection e classe MasterLayoutSlideCollection**
L’interfaccia IMasterLayoutSlideCollection e la classe MasterLayoutSlideCollection sono state aggiunte allo spazio dei nomi Aspose.Slides. La classe MasterLayoutSlideCollection implementa l’interfaccia IMasterLayoutSlideCollection.

L’interfaccia IMasterLayoutSlideCollection rappresenta una collezione di tutti i layout slide di un master slide definito. Estende l’interfaccia ILayoutSlideCollection con metodi per aggiungere, inserire, rimuovere o clonare layout slide nel contesto delle collezioni individuali dei layout slide di un master:

``` csharp

 // Firma del metodo:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Esempio di codice che collega la copia di sourceLayout al destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Il metodo può essere usato per aggiungere una copia di un layout slide specificato alla fine della collezione. Il nuovo layout sarà collegato al master slide padre per questa collezione di layout slide. È quindi analogo a copiare o incollare con l’opzione **Use Destination Theme** in PowerPoint. Un analogo di questo metodo è il metodo IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) accessibile tramite la proprietà IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Usato per inserire una copia di un layout slide specificato nella posizione indicata della collezione. Il nuovo layout sarà collegato al master slide padre per questa collezione di layout slide. È quindi analogo a copiare e incollare con l’opzione **Use Destination Theme** in PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Usato per aggiungere o inserire un nuovo layout slide. Tipi di layout supportati: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Il nome del layout può essere generato automaticamente. Un layout aggiunto di tipo SlideLayoutType.Custom non contiene segnaposti né forme. Un analogo di questo metodo è il metodo IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) accessibile tramite la proprietà IPresentation.LayoutSlides.
- void RemoveAt(int index); – Usato per rimuovere il layout all’indice specificato della collezione.
- void Reorder(int index, ILayoutSlide layoutSlide); – Usato per spostare il layout slide nella collezione alla posizione specificata.
### **Metodi e proprietà modificati**
#### **Firma del metodo Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
La firma del metodo ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

è ora obsoleta e viene sostituita dalla firma

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

Il parametro allowCloneMissingLayout specifica cosa fare se non esiste un layout appropriato nel destMaster per la nuova diapositiva (clonata). Il layout appropriato è quello con lo stesso tipo o nome del layout della diapositiva di origine. Se non esiste un layout appropriato nel master specificato, il layout della diapositiva di origine sarà clonato (se allowCloneMissingLayout è true) oppure verrà sollevata una PptxEditException (se allowCloneMissingLayout è false).

Una chiamata al metodo obsoleto come

AddClone(sourceSlide, destMaster);

presume che allowCloneMissingLayout sia false (cioè verrà lanciata PptxEditException se non c’è un layout appropriato). Una chiamata funzionalmente identica che usa la nuova firma è:

AddClone(sourceSlide, destMaster, false);

Se si desidera che i layout mancanti vengano clonati automaticamente anziché generare PptxEditException, passare il parametro allowCloneMissingLayout come true.

Vale lo stesso per il metodo ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

che è anch’esso ora obsoleto e viene sostituito dalla firma

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Tipo della proprietà Aspose.Slides.IMasterSlide.LayoutSlides**
Il tipo della proprietà Aspose.Slides.IMasterSlide.LayoutSlides è stato cambiato da ILayoutSlideCollection alla nuova interfaccia IMasterLayoutSlideCollection. L’interfaccia IMasterLayoutSlideCollection discende da ILayoutSlideCollection, quindi il codice esistente non richiede adattamenti.
#### **Tipo della proprietà Aspose.Slides.IPresentation.LayoutSlides è stato cambiato**
Il tipo della proprietà Aspose.Slides.IPresentation.LayoutSlides è stato cambiato da ILayoutSlideCollection alla nuova interfaccia IGlobalLayoutSlideCollection. L’interfaccia IGlobalLayoutSlideCollection discende da ILayoutSlideCollection, quindi il codice esistente non richiede adattamenti.