---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 14.4.0
linktitle: Aspose.Slides pro .NET 14.4.0
type: docs
weight: 60
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte aktualizace veřejného API a nekompatibilní změny v Aspose.Slides pro .NET, abyste hladce migrovali vaše řešení prezentací PowerPoint PPT, PPTX a ODP."
---
## **Veřejné API a zpětně nekompatibilní změny**
### **Přidané rozhraní, třídy, metody a vlastnosti**
#### **Vlastnost Aspose.Slides.ILayoutSlide.HasDependingSlides byla přidána**
Vlastnost Aspose.Slides.ILayoutSlide.HasDependingSlides vrací true, pokud existuje alespoň jeden snímek, který závisí na tomto rozložení snímku. Například:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Metoda Aspose.Slides.ILayoutSlide.Remove()**
Metoda Aspose.Slides.ILayoutSlide.Remove() umožňuje odstranit rozložení z prezentace s minimem kódu. Například:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Metoda Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
Metoda Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) umožňuje odstranit rozložení ze sbírky. Příklady kódu:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

nebo

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Metoda Aspose.Slides.ILayoutSlideCollection.RemoveUnused() umožňuje odstranit nepoužívaná rozložení snímků (rozložení snímků, jejichž HasDependingSlides je false). Příklady kódu:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

nebo

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Vlastnost Aspose.Slides.IMasterSlide.HasDependingSlides**
Vlastnost Aspose.Slides.IMasterSlide.HasDependingSlides vrací true, pokud existuje alespoň jeden snímek, který závisí na tomto hlavním snímku. Například:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Metoda Aspose.Slides.ISlide.Remove()**
Metoda Aspose.Slides.ISlide.Remove() umožňuje odstranit snímek z prezentace s minimem kódu. Například:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Vlastnost Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat vrací IFillFormat pro odrážku uzlu SmartArt, pokud rozložení poskytuje odrážky. Lze ji použít k nastavení obrázku odrážky.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Vlastnost Aspose.Slides.SmartArt.ISmartArtNode.Level**
Vlastnost Aspose.Slides.SmartArt.ISmartArtNode.Level vrací úroveň vnoření pro uzly SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Vlastnost Aspose.Slides.SmartArt.ISmartArtNode.Position**
Vlastnost Aspose.Slides.SmartArt.ISmartArtNode.Position vrací pozici uzlu mezi jeho sourozenci.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Metoda Aspose.Slides.SmartArt.ISmartArtNode.Remove() byla přidána**
Metoda Aspose.Slides.SmartArt.ISmartArtNode.Remove() umožňuje odebrat uzel z diagramu.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Rozhraní IGlobalLayoutSlideCollection a třída GlobalLayoutSlideCollection**
Rozhraní IGlobalLayoutSlideCollection a třída GlobalLayoutSlideCollection byly přidány do jmenného prostoru Aspose.Slides.

Třída GlobalLayoutSlideCollection implementuje rozhraní IGlobalLayoutSlideCollection.

Rozhraní IGlobalLayoutSlideCollection představuje sbírku všech rozložení snímků v prezentaci. Vlastnost IPresentation.LayoutSlides je typu IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection rozšiřuje rozhraní ILayoutSlideCollection o metody pro přidávání a klonování rozložení snímků v kontextu sjednocení jednotlivých sbírek rozložení snímků hlavního snímku:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Lze použít k přidání kopie určeného rozložení snímku do prezentace. Tato metoda zachovává formátování zdroje (při klonování rozložení mezi různými prezentacemi může být klonován také hlavní snímek rozložení. Interní registr se používá k automatickému sledování klonovaných hlavních snímků a zabraňuje vytvoření více kopií stejného hlavního snímku.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Použito k přidání kopie určeného rozložení snímku do prezentace. Nové rozložení bude propojeno s definovaným hlavním snímkem v cílové prezentaci. Tato volba je ekvivalentní kopírování nebo vložení s možností **Use Destination Theme** v Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Použito k přidání nového rozložení snímku do prezentace. Podporované typy rozložení: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Název rozložení může být generován automaticky. Přidané rozložení typu SlideLayoutType.Custom neobsahuje žádné zástupné symboly ani tvary. Analogie této metody je metoda IMasterLayoutSlideCollection.Add(SlideLayoutType, string) přístupná přes vlastnost IMasterSlide.LayoutSlides.
#### **Rozhraní IMasterLayoutSlideCollection a třída MasterLayoutSlideCollection**
Rozhraní IMasterLayoutSlideCollection a třída MasterLayoutSlideCollection byly přidány do jmenného prostoru Aspose.Slides. Třída MasterLayoutSlideCollection implementuje rozhraní IMasterLayoutSlideCollection.

Rozhraní IMasterLayoutSlideCollection představuje sbírku všech rozložení snímků definovaného hlavního snímku. Rozšiřuje rozhraní ILayoutSlideCollection o metody pro přidávání, vkládání, odstraňování nebo klonování rozložení snímků v kontextu jednotlivých sbírek rozložení hlavního snímku:

``` csharp

 // Podpis metody:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Ukázkový kód, který připojuje kopii sourceLayout k destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Metodu lze použít k přidání kopie určeného rozložení snímku na konec sbírky. Nové rozložení bude propojeno s rodičovským hlavním snímkem pro tuto sbírku rozložení. Jedná se o ekvivalent kopírování nebo vložení s možností **Use Destination Theme** v PowerPointu. Analogií této metody je metoda IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) přístupná přes vlastnost IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Použito k vložení kopie určeného rozložení snímku na určenou pozici sbírky. Nové rozložení bude propojeno s rodičovským hlavním snímkem pro tuto sbírku rozložení. Jedná se o ekvivalent kopírování a vložení s možností **Use Destination Theme** v PowerPointu.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Použito k přidání nebo vložení nového rozložení snímku. Podporované typy rozložení: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Název rozložení může být generován automaticky. Přidané rozložení typu SlideLayoutType.Custom neobsahuje žádné zástupné symboly ani tvary. Analogií této metody je metoda IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) přístupná přes vlastnost IPresentation.LayoutSlides.
- void RemoveAt(int index); – Použito k odstranění rozložení na zadaném indexu sbírky.
- void Reorder(int index, ILayoutSlide layoutSlide); – Použito k přesunutí rozložení snímku ve sbírce na zadanou pozici.
### **Změněné metody a vlastnosti**
#### **Signatura metody Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
Signatura metody ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

je nyní zastaralá a byla nahrazena signaturou

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

Parametr allowCloneMissingLayout určuje, co provést, pokud v destMaster neexistuje vhodné rozložení pro nový (klonovaný) snímek. Vhodné rozložení je rozložení se stejným typem nebo názvem jako rozložení zdrojového snímku. Pokud v určeném hlavním snímku není vhodné rozložení, rozložení zdrojového snímku bude klonováno (pokud je allowCloneMissingLayout true) nebo bude vyhozena výjimka PptxEditException (pokud je allowCloneMissingLayout false).

Volání zastaralé metody jako

AddClone(sourceSlide, destMaster);

předpokládá, že allowCloneMissingLayout je false (tzn. bude vyhozena PptxEditException, pokud neexistuje vhodné rozložení). Funkčně ekvivalentní volání s novou signaturou vypadá takto:
AddClone(sourceSlide, destMaster, false);

Pokud chcete, aby chybějící rozložení byla automaticky klonována místo vyhození PptxEditException, předávejte parametr allowCloneMissingLayout jako true.

Totéž se vztahuje na metodu ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

je také zastaralá a byla nahrazena signaturou

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Typ vlastnosti Aspose.Slides.IMasterSlide.LayoutSlides**
Typ vlastnosti Aspose.Slides.IMasterSlide.LayoutSlides byl změněn z ILayoutSlideCollection na nové rozhraní IMasterLayoutSlideCollection. Rozhraní IMasterLayoutSlideCollection je potomkem ILayoutSlideCollection, takže stávající kód nevyžaduje úpravy.
#### **Typ vlastnosti Aspose.Slides.IPresentation.LayoutSlides byl změněn**
Typ vlastnosti Aspose.Slides.IPresentation.LayoutSlides byl změněn z ILayoutSlideCollection na nové rozhraní IGlobalLayoutSlideCollection. Rozhraní IGlobalLayoutSlideCollection je potomkem ILayoutSlideCollection, takže stávající kód nevyžaduje úpravy.