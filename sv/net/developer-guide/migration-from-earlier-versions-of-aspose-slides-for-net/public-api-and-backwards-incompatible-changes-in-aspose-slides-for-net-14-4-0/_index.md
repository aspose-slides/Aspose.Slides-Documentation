---
title: Offentlig API och bakåt inkompatibla ändringar i Aspose.Slides för .NET 14.4.0
linktitle: Aspose.Slides för .NET 14.4.0
type: docs
weight: 60
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- migrering
- äldre kod
- modern kod
- äldre tillvägagångssätt
- modernt tillvägagångssätt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande ändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT, PPTX och ODP presentationslösningar."
---
## **Public API and Backwards Incompatible Changes**
### **Added Interfaces, Classes, Methods and Properties**
#### **Aspose.Slides.ILayoutSlide.HasDependingSlides Property Has Been Added**
Egenskapen Aspose.Slides.ILayoutSlide.HasDependingSlides returnerar true om det finns minst en bild som är beroende av denna layoutbild. Till exempel:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlide.Remove() Method**
Metoden Aspose.Slides.ILayoutSlide.Remove() låter dig ta bort en layout från en presentation med minimal kod. Till exempel:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) Method**
Metoden Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) låter dig ta bort en layout från samlingen. Kodexempel:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

or

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Metoden Aspose.Slides.ILayoutSlideCollection.RemoveUnused() låter dig ta bort oanvända layoutbilder (layoutbilder där HasDependingSlides är false). Kodexempel:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

or

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlides Property**
Egenskapen Aspose.Slides.IMasterSlide.HasDependingSlides returnerar true om det finns minst en bild som är beroende av denna masternivåbild. Till exempel:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Aspose.Slides.ISlide.Remove() Method**
Metoden Aspose.Slides.ISlide.Remove() låter dig ta bort en bild från en presentation med minimal kod. Till exempel:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Egenskapen Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat returnerar IFillFormat för en SmartArt‑nodpunkt om layouten tillhandahåller punkter. Den kan användas för att ange punktbilden.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level Property**
Egenskapen Aspose.Slides.SmartArt.ISmartArtNode.Level returnerar nästlad nivå för SmartArt‑noder.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position Property**
Egenskapen Aspose.Slides.SmartArt.ISmartArtNode.Position returnerar nodens position bland dess syskon.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Remove() Method Has Been Added**
Metoden Aspose.Slides.SmartArt.ISmartArtNode.Remove() möjliggör borttagning av en nod från ett diagram.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection Interface and GlobalLayoutSlideCollection Class**
Gränssnittet IGlobalLayoutSlideCollection och klassen GlobalLayoutSlideCollection har lagts till i Aspose.Slides‑namnutrymmet.

Klassen GlobalLayoutSlideCollection implementerar gränssnittet IGlobalLayoutSlideCollection.

Gränssnittet IGlobalLayoutSlideCollection representerar en samling av alla layoutbilder i en presentation. IPresentation.LayoutSlides‑egenskapen är av typen IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection utökar gränssnittet ILayoutSlideCollection med metoder för att lägga till och klona layoutbilder i samband med förening av de individuella samlingarna av masternas layoutbilder:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Kan användas för att lägga till en kopia av en specificerad layoutbild i presentationen. Denna metod behåller källformatet (vid kloning av en layout mellan olika presentationer kan layoutens master också klonas. Det interna registret används för att spåra automatiskt klonade mastrar för att förhindra att flera kopior av samma masternivåbild skapas.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Används för att lägga till en kopia av en specificerad layoutbild i en presentation. Den nya layouten kommer att länkas till den definierade mastern i målpresentationen. Detta alternativ motsvarar att kopiera eller klistra in med alternativet **Use Destination Theme** i Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Används för att lägga till en ny layoutbild i en presentation. Stödda layouttyper: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Layoutnamnet kan genereras automatiskt. En tillagd layout av typen SlideLayoutType.Custom innehåller inga platshållare och inga former. En motsvarighet till denna metod är IMasterLayoutSlideCollection.Add(SlideLayoutType, string) som nås via IMasterSlide.LayoutSlides‑egenskapen.

#### **Interface IMasterLayoutSlideCollection and Class MasterLayoutSlideCollection**
Gränssnittet IMasterLayoutSlideCollection och klassen MasterLayoutSlideCollection har lagts till i Aspose.Slides‑namnutrymmet. Klassen MasterLayoutSlideCollection implementerar gränssnittet IMasterLayoutSlideCollection.

Gränssnittet IMasterLayoutSlideCollection representerar en samling av alla layoutbilder för en definierad masternivåbild. Det utökar gränssnittet ILayoutSlideCollection med metoder för att lägga till, infoga, ta bort eller klona layoutbilder i samband med de individuella samlingarna av en masters layoutbilder:

``` csharp

 // Metodsignatur:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Kodexempel som fäster en kopia av sourceLayout till destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Metoden kan användas för att lägga till en kopia av en specificerad layoutbild i slutet av samlingen. Den nya layouten kommer att länkas till den överordnade mastern för den här layoutbildssamlingen. Så detta motsvarar att kopiera eller klistra in med alternativet **Use Destination Theme** i PowerPoint. En motsvarighet till denna metod är metoden IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) som nås via IPresentation.LayoutSlides‑egenskapen.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Används för att infoga en kopia av en specificerad layoutbild på en angiven position i samlingen. Den nya layouten kommer att länkas till den överordnade mastern för den här layoutbildssamlingen. Så detta motsvarar att kopiera och klistra in med alternativet **Use Destination Theme** i PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Används för att lägga till eller infoga en ny layoutbild. Stödda layouttyper: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Layoutnamnet kan genereras automatiskt. En tillagd layout av typen SlideLayoutType.Custom innehåller inga platshållare och inga former. En motsvarighet till denna metod är IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) som nås via IPresentation.LayoutSlides‑egenskapen.
- void RemoveAt(int index); – Används för att ta bort layouten på det angivna indexet i samlingen.
- void Reorder(int index, ILayoutSlide layoutSlide); – Används för att flytta en layoutbild inom samlingen till den angivna positionen.

### **Changed Methods and Properties**
#### **Signature of the Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) Method**
Signaturen för metoden ISlideCollection:

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

är nu föråldrad och har ersatts med signaturen

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

Parametern allowCloneMissingLayout specificerar vad som ska göras om det inte finns någon lämplig layout i destMaster för den nya (klonade) bilden. Den lämpliga layouten är den layout som har samma typ eller namn som källbildens layout. Om det inte finns någon lämplig layout i den angivna mastern, kommer layouten från källbilden att klonas (om allowCloneMissingLayout är true) eller en PptxEditException kastas (om allowCloneMissingLayout är false).

Ett anrop av den föråldrade metoden såsom

AddClone(sourceSlide, destMaster);

antar att allowCloneMissingLayout är false (dvs. PptxEditException kastas om det inte finns någon lämplig layout). Ett funktionsmässigt identiskt anrop som använder den nya signaturen ser ut så här:

AddClone(sourceSlide, destMaster, false);

Om du vill att saknade layouter automatiskt ska klonas i stället för att kasta PptxEditException, skicka då parametern allowCloneMissingLayout som true.

Samma gäller för ISlideCollection‑metoden:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

är också föråldrad nu och har ersatts med signaturen

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Type of the Aspose.Slides.IMasterSlide.LayoutSlides Property**
Typen för egenskapen Aspose.Slides.IMasterSlide.LayoutSlides har ändrats från ILayoutSlideCollection till det nya gränssnittet IMasterLayoutSlideCollection. IMasterLayoutSlideCollection är en avledning av ILayoutSlideCollection så befintlig kod kräver inga anpassningar.
#### **Type of the Aspose.Slides.IPresentation.LayoutSlides Property Has Been Changed**
Typen för egenskapen Aspose.Slides.IPresentation.LayoutSlides har ändrats från ILayoutSlideCollection till det nya gränssnittet IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection är en avledning av ILayoutSlideCollection så befintlig kod kräver inga anpassningar.