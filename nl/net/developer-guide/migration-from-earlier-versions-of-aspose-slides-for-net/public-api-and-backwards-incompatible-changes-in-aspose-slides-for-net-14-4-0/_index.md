---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 14.4.0
linktitle: Aspose.Slides voor .NET 14.4.0
type: docs
weight: 60
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de updates van de openbare API en de brekende wijzigingen in Aspose.Slides voor .NET om uw PowerPoint PPT, PPTX en ODP presentatie oplossingen soepel te migreren."
---
## **Openbare API en achterwaarts incompatibele wijzigingen**
### **Toegevoegde interfaces, klassen, methoden en eigenschappen**
#### **Eigenschap Aspose.Slides.ILayoutSlide.HasDependingSlides is toegevoegd**
De eigenschap Aspose.Slides.ILayoutSlide.HasDependingSlides geeft true terug als er ten minste één dia bestaat die afhankelijk is van deze layout‑dia. Bijvoorbeeld:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Methode Aspose.Slides.ILayoutSlide.Remove()**
De methode Aspose.Slides.ILayoutSlide.Remove() stelt u in staat een layout uit een presentatie te verwijderen met minimale code. Bijvoorbeeld:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Methode Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
De methode Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) stelt u in staat een layout uit de collectie te verwijderen. Code‑voorbeelden:

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
#### **Methode Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
De methode Aspose.Slides.ILayoutSlideCollection.RemoveUnused() stelt u in staat ongebruikte layout‑dia’s te verwijderen (layout‑dia’s waarvan HasDependingSlides false is). Code‑voorbeelden:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

or

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Eigenschap Aspose.Slides.IMasterSlide.HasDependingSlides**
De eigenschap Aspose.Slides.IMasterSlide.HasDependingSlides geeft true terug als er ten minste één dia bestaat die afhankelijk is van deze master‑dia. Bijvoorbeeld:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Methode Aspose.Slides.ISlide.Remove()**
De methode Aspose.Slides.ISlide.Remove() stelt u in staat een dia uit een presentatie te verwijderen met minimale code. Bijvoorbeeld:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Eigenschap Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
De eigenschap Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat retourneert een IFillFormat voor een bullet van een SmartArt‑knooppunt als de lay‑out bullets levert. Het kan worden gebruikt om de bullet‑afbeelding in te stellen.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Eigenschap Aspose.Slides.SmartArt.ISmartArtNode.Level**
De eigenschap Aspose.Slides.SmartArt.ISmartArtNode.Level retourneert het geneste niveau voor SmartArt‑knooppunten.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Eigenschap Aspose.Slides.SmartArt.ISmartArtNode.Position**
De eigenschap Aspose.Slides.SmartArt.ISmartArtNode.Position retourneert de positie van een knooppunt ten opzichte van zijn broers en zussen.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Methode Aspose.Slides.SmartArt.ISmartArtNode.Remove() is toegevoegd**
De methode Aspose.Slides.SmartArt.ISmartArtNode.Remove() stelt u in staat een knooppunt uit een diagram te verwijderen.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Interface IGlobalLayoutSlideCollection en klasse GlobalLayoutSlideCollection**
De IGlobalLayoutSlideCollection‑interface en de GlobalLayoutSlideCollection‑klasse zijn toegevoegd aan de Aspose.Slides‑namespace.

De GlobalLayoutSlideCollection‑klasse implementeert de IGlobalLayoutSlideCollection‑interface.

De IGlobalLayoutSlideCollection‑interface vertegenwoordigt een verzameling van alle layout‑dia’s in een presentatie. De IPresentation.LayoutSlides‑eigenschap is van het type IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection breidt de ILayoutSlideCollection‑interface uit met methoden voor het toevoegen en klonen van layout‑dia’s in de context van het samenvoegen van de individuele collecties van master‑layout‑dia’s:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Kan worden gebruikt om een kopie van een opgegeven layout‑dia toe te voegen aan de presentatie. Deze methode behoudt de bronopmaak (bij het klonen van een layout tussen verschillende presentaties kan de master van de layout ook worden gekloond. Het interne register wordt gebruikt om automatisch gekloonde masters bij te houden om te voorkomen dat meerdere klonen van dezelfde master‑dia worden aangemaakt.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Wordt gebruikt om een kopie van een opgegeven layout‑dia toe te voegen aan een presentatie. De nieuwe layout wordt gekoppeld aan de gedefinieerde master in de bestemmingspresentatie. Deze optie is analoog aan kopiëren of plakken met de **Use Destination Theme**‑optie in Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Wordt gebruikt om een nieuwe layout‑dia toe te voegen aan een presentatie. Ondersteunde layout‑typen: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. De layout‑naam kan automatisch gegenereerd worden. Een toegevoegde layout van het type SlideLayoutType.Custom bevat geen placeholders en geen shapes. Een analoog van deze methode is de IMasterLayoutSlideCollection.Add(SlideLayoutType, string)‑methode, benaderd via de IMasterSlide.LayoutSlides‑eigenschap.
#### **Interface IMasterLayoutSlideCollection en klasse MasterLayoutSlideCollection**
De IMasterLayoutSlideCollection‑interface en de MasterLayoutSlideCollection‑klasse zijn toegevoegd aan de Aspose.Slides‑namespace. De MasterLayoutSlideCollection‑klasse implementeert de IMasterLayoutSlideCollection‑interface.

De IMasterLayoutSlideCollection‑interface vertegenwoordigt een verzameling van alle layout‑dia’s van een gedefinieerde master‑dia. Ze breidt de ILayoutSlideCollection‑interface uit met methoden voor het toevoegen, invoegen, verwijderen of klonen van layout‑dia’s in de context van de individuele collecties van een master‑layout‑dia’s:

``` csharp

 // Methodehandtekening:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Codevoorbeeld dat een kopie van sourceLayout koppelt aan destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

De methode kan worden gebruikt om een kopie van een opgegeven layout‑dia toe te voegen aan het einde van de collectie. De nieuwe layout wordt gekoppeld aan de ouder‑master‑dia voor deze layout‑dia‑collectie. Dit is dus analoog aan kopiëren of plakken met de **Use Destination Theme**‑optie in PowerPoint. Een analoog van deze methode is de methode IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) benaderd via de IPresentation.LayoutSlides‑eigenschap.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Wordt gebruikt om een kopie van een opgegeven layout‑dia in te voegen op een specifieke positie in de collectie. Nieuwe layout wordt gekoppeld aan de ouder‑master‑dia voor deze layout‑dia‑collectie. Dit is dus analoog aan kopiëren en plakken met de **Use Destination Theme**‑optie in PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Wordt gebruikt om een nieuwe layout‑dia toe te voegen of in te voegen. Ondersteunde layout‑typen: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. De layout‑naam kan automatisch gegenereerd worden. Een toegevoegde layout van het type SlideLayoutType.Custom bevat geen placeholders en geen shapes. Een analoog van deze methode is de IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string)‑methode, benaderd via de IPresentation.LayoutSlides‑eigenschap.
- void RemoveAt(int index); – Wordt gebruikt om de layout op de opgegeven index uit de collectie te verwijderen.
- void Reorder(int index, ILayoutSlide layoutSlide); – Wordt gebruikt om een layout‑dia binnen de collectie naar de opgegeven positie te verplaatsen.
### **Gewijzigde methoden en eigenschappen**
#### **Handtekening van de Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) methode**
De handtekening van de ISlideCollection‑methode:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

is nu verouderd en vervangen door de handtekening

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

De parameter allowCloneMissingLayout geeft aan wat er moet gebeuren als er geen passende layout bestaat in de destMaster voor de nieuwe (gekloonde) dia. De passende layout is de layout met hetzelfde type of dezelfde naam als de layout van de bron‑dia. Als er geen passende layout bestaat in de opgegeven master, wordt de layout van de bron‑dia gekloond (als allowCloneMissingLayout true is) of wordt een PptxEditException gegooid (als allowCloneMissingLayout false is).

Een aanroep van de verouderde methode zoals

AddClone(sourceSlide, destMaster);

veronderstelt dat allowCloneMissingLayout gelijk is aan false (dat wil zeggen, een PptxEditException wordt gegooid als er geen passende layout is). Een functioneel identieke aanroep met de nieuwe handtekening ziet er zo uit:
AddClone(sourceSlide, destMaster, false);

Als u wilt dat ontbrekende layouts automatisch worden gekloond in plaats van een PptxEditException te werpen, geef dan de parameter allowCloneMissingLayout de waarde true.

Hetzelfde geldt voor de ISlideCollection‑methode:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

is ook verouderd en vervangen door de handtekening

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Type van de Aspose.Slides.IMasterSlide.LayoutSlides eigenschap**
Het type van de Aspose.Slides.IMasterSlide.LayoutSlides‑eigenschap is gewijzigd van ILayoutSlideCollection naar de nieuwe IMasterLayoutSlideCollection‑interface. De IMasterLayoutSlideCollection‑interface is een afstammeling van de ILayoutSlideCollection, dus bestaande code behoeft geen aanpassingen.
#### **Type van de Aspose.Slides.IPresentation.LayoutSlides eigenschap is gewijzigd**
Het type van de Aspose.Slides.IPresentation.LayoutSlides‑eigenschap is gewijzigd van ILayoutSlideCollection naar de nieuwe IGlobalLayoutSlideCollection‑interface. De IGlobalLayoutSlideCollection‑interface is een afstammeling van de ILayoutSlideCollection, dus bestaande code behoeft geen aanpassingen.