---
title: Publikus API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 14.4.0-ban
linktitle: Aspose.Slides for .NET 14.4.0
type: docs
weight: 60
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Nézze át a publikus API frissítéseket és a töréspontokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
## **Publikus API és visszafelé nem kompatibilis változások**
### **Új interfészek, osztályok, metódusok és tulajdonságok**
#### **Az Aspose.Slides.ILayoutSlide.HasDependingSlides tulajdonság hozzá lett adva**
Az Aspose.Slides.ILayoutSlide.HasDependingSlides tulajdonság true értéket ad vissza, ha létezik legalább egy dia, amely függ ettől az elrendezési diától. Például:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlide.Remove() metódus**
Az Aspose.Slides.ILayoutSlide.Remove() metódus lehetővé teszi egy elrendezés eltávolítását a prezentációból minimális kóddal. Például:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) metódus**
Az Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) metódus lehetővé teszi egy elrendezés eltávolítását a gyűjteményből. Kódpéldák:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

vagy

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Az Aspose.Slides.ILayoutSlideCollection.RemoveUnused() metódus lehetővé teszi a nem használt elrendezési diák (azok a diák, melyeknek a HasDependingSlides értéke false) eltávolítását. Kódpéldák:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

vagy

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlides tulajdonság**
Az Aspose.Slides.IMasterSlide.HasDependingSlides tulajdonság true értéket ad vissza, ha létezik legalább egy dia, amely függ ettől a mester diától. Például:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Aspose.Slides.ISlide.Remove() metódus**
Az Aspose.Slides.ISlide.Remove() metódus lehetővé teszi egy dia eltávolítását a prezentációból minimális kóddal. Például:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Az Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat tulajdonság IFillFormat objektumot ad egy SmartArt csomópont jelölőhöz, ha az elrendezés támogatja a jelölőket. A jelölő képének beállítására használható.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level tulajdonság**
Az Aspose.Slides.SmartArt.ISmartArtNode.Level tulajdonság a SmartArt csomópontok beágyazott szintjét adja vissza.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position tulajdonság**
Az Aspose.Slides.SmartArt.ISmartArtNode.Position tulajdonság egy csomópont pozícióját adja vissza a testvérei közül.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Remove() metódus hozzáadva**
Az Aspose.Slides.SmartArt.ISmartArtNode.Remove() metódus lehetővé teszi egy csomópont eltávolítását egy diagramból.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection interfész és GlobalLayoutSlideCollection osztály**
Az IGlobalLayoutSlideCollection interfész és a GlobalLayoutSlideCollection osztály hozzá lett adva az Aspose.Slides névtérhez.

A GlobalLayoutSlideCollection osztály megvalósítja az IGlobalLayoutSlideCollection interfészt.

Az IGlobalLayoutSlideCollection interfész a prezentáció összes elrendezési diájának gyűjteményét reprezentálja. Az IPresentation.LayoutSlides tulajdonság típusa IGlobalLayoutSlideCollection. Az IGlobalLayoutSlideCollection kiterjeszti az ILayoutSlideCollection interfészt olyan metódusokkal, amelyek lehetővé teszik elrendezési diák hozzáadását és klónozását a különálló mester elrendezési gyűjtemények egyesítése kontextusában:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Egy megadott elrendezési dia másolatának hozzáadására használható a prezentációhoz. A metódus megtartja a forrás formázását (ha egy elrendezést különböző prezentációk között klónozunk, a dia mesterét is klónozhatja. A belső nyilvántartás automatikusan klónozott mestereket követ, hogy megakadályozza ugyanannak a mester diának a többszöri klónozását.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Egy megadott elrendezési dia másolatának hozzáadására használható egy prezentációhoz. Az új elrendezés a célprezentációban meghatározott mesterhez lesz kapcsolva. Ez a lehetőség analóg a másolás vagy beillesztés **Use Destination Theme** opciójával a Microsoft PowerPoint‑ban.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Új elrendezési dia hozzáadására használható a prezentációhoz. Támogatott elrendezéstípusok: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. A layout neve automatikusan generálható. A SlideLayoutType.Custom típusú elrendezés nem tartalmaz helyőrzőket és alakzatokat. Ennek a metódusnak az analógiája az IMasterLayoutSlideCollection.Add(SlideLayoutType, string) metódus, amely az IMasterSlide.LayoutSlides tulajdonságon keresztül érhető el.
#### **IMasterLayoutSlideCollection interfész és MasterLayoutSlideCollection osztály**
Az IMasterLayoutSlideCollection interfész és a MasterLayoutSlideCollection osztály hozzá lett adva az Aspose.Slides névtérhez. A MasterLayoutSlideCollection osztály megvalósítja az IMasterLayoutSlideCollection interfészt.

Az IMasterLayoutSlideCollection interfész egy meghatározott mester diához tartozó összes elrendezési dia gyűjteményét reprezentálja. Kiterjeszti az ILayoutSlideCollection interfészt olyan metódusokkal, amelyek lehetővé teszik elrendezési diák hozzáadását, beszúrását, eltávolítását vagy klónozását egy mester elrendezési diáinak egyedi gyűjteményei kontextusában:

``` csharp

 // Metódus aláírása:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Kódpélda, amely a sourceLayout másolatát a destMasterSlide-hez csatolja:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);
``` 

A metódus használható egy megadott elrendezési dia másolatának a gyűjtemény végéhez való hozzáadására. Az új elrendezés a szülő mester diához lesz kapcsolva ebben a gyűjteményben. Ez analóg a **Use Destination Theme** opcióval történő másolással vagy beillesztéssel a PowerPoint‑ban. Az IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) metódus analógiája az IPresentation.LayoutSlides tulajdonságon keresztül elérhető.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Egy megadott elrendezési dia másolatának a gyűjtemény adott pozíciójába való beszúrására használható. Az új elrendezés a szülő mester diához lesz kapcsolva. Analóg a **Use Destination Theme** opcióval történő másolással vagy beillesztéssel a PowerPoint‑ban.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Új elrendezési dia hozzáadására vagy beszúrására használható. Támogatott elrendezéstípusok: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. A layout neve automatikusan generálható. A SlideLayoutType.Custom típusú elrendezés nem tartalmaz helyőrzőket és alakzatokat. Analóg ennek a metódusnak az IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) metódus, amely az IPresentation.LayoutSlides tulajdonságon keresztül érhető el.
- void RemoveAt(int index); – A megadott indexű elrendezés eltávolítására szolgál a gyűjteményből.
- void Reorder(int index, ILayoutSlide layoutSlide); – Egy elrendezési dia áthelyezésére a gyűjteményben a megadott pozícióra.
### **Módosított metódusok és tulajdonságok**
#### **Az Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) metódus aláírása**
Az ISlideCollection metódus aláírása:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

elavulttá vált, és helyette az alábbi aláírás használható:

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

Az allowCloneMissingLayout paraméter azt határozza meg, mi történjen, ha a célmesterben nincs megfelelő elrendezés az új (klónozott) diának. A megfelelő elrendezés azonos típusú vagy nevű elrendezés, mint a forrás dia elrendezése. Ha a megadott mesterben nincs megfelelő elrendezés, akkor a forrás dia elrendezése klónozásra kerül (ha az allowCloneMissingLayout true), vagy PptxEditException keletkezik (ha false).

Az elavult metódus meghívása, például:
AddClone(sourceSlide, destMaster);
feltételezi, hogy az allowCloneMissingLayout false (azaz PptxEditException keletkezik, ha nincs megfelelő elrendezés). A funkcionálisan ekvivalens új hívás így néz ki:
AddClone(sourceSlide, destMaster, false);

Ha azt szeretné, hogy a hiányzó elrendezések automatikusan klónozódjanak a PptxEditException helyett, akkor az allowCloneMissingLayout paramétert true‑ra kell állítani.

Ugyanez vonatkozik a következő ISlideCollection metódusra is:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);
ez is elavult, és helyette az alábbi aláírás használható:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Az Aspose.Slides.IMasterSlide.LayoutSlides tulajdonság típusa**
Az Aspose.Slides.IMasterSlide.LayoutSlides tulajdonság típusa ILayoutSlideCollection-ről új IMasterLayoutSlideCollection interfészre változott. Az IMasterLayoutSlideCollection interfész az ILayoutSlideCollection leszármazottja, ezért a meglévő kódnak nem szükséges módosulnia.
#### **Az Aspose.Slides.IPresentation.LayoutSlides tulajdonság típusa megváltozott**
Az Aspose.Slides.IPresentation.LayoutSlides tulajdonság típusa ILayoutSlideCollection-ről új IGlobalLayoutSlideCollection interfészre változott. Az IGlobalLayoutSlideCollection interfész az ILayoutSlideCollection leszármazottja, ezért a meglévő kódnak nem szükséges módosulnia.