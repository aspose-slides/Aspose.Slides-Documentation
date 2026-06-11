---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 14.4.0
linktitle: Aspose.Slides dla .NET 14.4.0
type: docs
weight: 60
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- migracja
- kod starszy
- nowoczesny kod
- stare podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API oraz zmiany niekompatybilne wstecz w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
## **Publiczne API i zmiany niekompatybilne wstecz**
### **Dodane interfejsy, klasy, metody i właściwości**
#### **Dodano właściwość Aspose.Slides.ILayoutSlide.HasDependingSlides**
Właściwość Aspose.Slides.ILayoutSlide.HasDependingSlides zwraca true, jeśli istnieje co najmniej jeden slajd zależny od tego slajdu układu. Na przykład:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Metoda Aspose.Slides.ILayoutSlide.Remove()**
Metoda Aspose.Slides.ILayoutSlide.Remove() umożliwia usunięcie układu z prezentacji przy minimalnej liczbie kodu. Na przykład:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Metoda Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
Metoda Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) umożliwia usunięcie układu z kolekcji. Przykłady kodu:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

lub

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Metoda Aspose.Slides.ILayoutSlideCollection.RemoveUnused() umożliwia usunięcie nieużywanych slajdów układu (slajdów układu, których HasDependingSlides jest false). Przykłady kodu:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

lub

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Właściwość Aspose.Slides.IMasterSlide.HasDependingSlides**
Właściwość Aspose.Slides.IMasterSlide.HasDependingSlides zwraca true, jeśli istnieje co najmniej jeden slajd zależny od tego slajdu master. Na przykład:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Metoda Aspose.Slides.ISlide.Remove()**
Metoda Aspose.Slides.ISlide.Remove() umożliwia usunięcie slajdu z prezentacji przy minimalnej liczbie kodu. Na przykład:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Właściwość Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat zwraca IFillFormat dla wypunktowania węzła SmartArt, jeśli układ zapewnia wypunktowania. Można jej użyć do ustawienia obrazu wypunktowania.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level Property**
Właściwość Aspose.Slides.SmartArt.ISmartArtNode.Level zwraca poziom zagnieżdżenia dla węzłów SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position Property**
Właściwość Aspose.Slides.SmartArt.ISmartArtNode.Position zwraca pozycję węzła wśród jego rodzeństwa.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Dodano metodę Aspose.Slides.SmartArt.ISmartArtNode.Remove()**
Metoda Aspose.Slides.SmartArt.ISmartArtNode.Remove() umożliwia usunięcie węzła z diagramu.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Interfejs IGlobalLayoutSlideCollection i klasa GlobalLayoutSlideCollection**
Interfejs IGlobalLayoutSlideCollection oraz klasa GlobalLayoutSlideCollection zostały dodane do przestrzeni nazw Aspose.Slides.

Klasa GlobalLayoutSlideCollection implementuje interfejs IGlobalLayoutSlideCollection.

Interfejs IGlobalLayoutSlideCollection reprezentuje kolekcję wszystkich slajdów układu w prezentacji. Właściwość IPresentation.LayoutSlides jest typu IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection rozszerza interfejs ILayoutSlideCollection o metody umożliwiające dodawanie i klonowanie slajdów układu w kontekście łączenia poszczególnych kolekcji układów mastera:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Może być użyta do dodania kopii określonego slajdu układu do prezentacji. Metoda zachowuje formatowanie źródła (przy klonowaniu układu między różnymi prezentacjami, można również sklonować master układu. Wewnętrzny rejestr służy do śledzenia automatycznie sklonowanych masterów, aby zapobiec tworzeniu wielu kopii tego samego slajdu master).

- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Służy do dodania kopii określonego slajdu układu do prezentacji. Nowy układ zostanie powiązany z określonym masterem w prezentacji docelowej. Opcja ta jest analogiczna do kopiowania lub wklejania z użyciem opcji **Use Destination Theme** w Microsoft PowerPoint.

- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Służy do dodania nowego slajdu układu do prezentacji. Obsługiwane typy układów: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Nazwa układu może być generowana automatycznie. Dodany układ typu SlideLayoutType.Custom nie zawiera placeholderów ani kształtów. Analogiczna metoda to IMasterLayoutSlideCollection.Add(SlideLayoutType, string) dostępna przez właściwość IMasterSlide.LayoutSlides.

#### **Interfejs IMasterLayoutSlideCollection i klasa MasterLayoutSlideCollection**
Interfejs IMasterLayoutSlideCollection oraz klasa MasterLayoutSlideCollection zostały dodane do przestrzeni nazw Aspose.Slides. Klasa MasterLayoutSlideCollection implementuje interfejs IMasterLayoutSlideCollection.

Interfejs IMasterLayoutSlideCollection reprezentuje kolekcję wszystkich slajdów układu określonego slajdu master. Rozszerza interfejs ILayoutSlideCollection o metody umożliwiające dodawanie, wstawianie, usuwanie lub klonowanie slajdów układu w kontekście poszczególnych kolekcji układów mastera:

``` csharp

 // Sygnatura metody:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Przykład kodu, który dołącza kopię sourceLayout do destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

Metoda może być użyta do dodania kopii określonego slajdu układu na koniec kolekcji. Nowy układ zostanie powiązany z nadrzędnym slajdem master tej kolekcji slajdów układu. Jest to analogiczne do kopiowania lub wklejania z użyciem opcji **Use Destination Theme** w PowerPoint. Analogia tej metody to IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) dostępna przez właściwość IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Służy do wstawienia kopii określonego slajdu układu na wskazaną pozycję w kolekcji. Nowy układ zostanie powiązany z nadrzędnym slajdem master tej kolekcji slajdów układu. Jest to analogiczne do kopiowania i wklejania z użyciem opcji **Use Destination Theme** w PowerPoint.

- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);

- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Służy do dodania lub wstawienia nowego slajdu układu. Obsługiwane typy układów: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Nazwa układu może być generowana automatycznie. Dodany układ typu SlideLayoutType.Custom nie zawiera placeholderów ani kształtów. Analogiczna metoda to IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) dostępna przez właściwość IPresentation.LayoutSlides.

- void RemoveAt(int index); – Służy do usunięcia układu o wskazanym indeksie w kolekcji.

- void Reorder(int index, ILayoutSlide layoutSlide); – Służy do przeniesienia slajdu układu w kolekcji na wskazaną pozycję.

### **Zmienione metody i właściwości**
#### **Sygnatura metody Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
Sygnatura metody ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);
jest obecnie przestarzała i została zastąpiona sygnaturą

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

Parametr **allowCloneMissingLayout** określa, co zrobić, gdy w destMaster nie ma odpowiedniego układu dla nowego (sklonowanego) slajdu. Odpowiedni układ to układ o tym samym typie lub nazwie co układ slajdu źródłowego. Jeśli w określonym masterze nie ma takiego układu, układ slajdu źródłowego zostanie sklonowany (gdy **allowCloneMissingLayout** jest true) lub zostanie zgłoszony **PptxEditException** (gdy **allowCloneMissingLayout** jest false).

Wywołanie przestarzałej metody, np.:

AddClone(sourceSlide, destMaster);

zakłada, że **allowCloneMissingLayout** ma wartość false (czyli zostanie zgłoszony **PptxEditException**, jeśli nie ma odpowiedniego układu). Identyczna funkcjonalnie metoda używająca nowej sygnatury wygląda tak:

AddClone(sourceSlide, destMaster, false);

Jeśli chcesz, aby brakujące układy były automatycznie klonowane zamiast zgłaszania **PptxEditException**, przekaż parametr **allowCloneMissingLayout** jako true.

To samo dotyczy metody ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

która również jest przestarzała i została zastąpiona sygnaturą

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);

#### **Typ właściwości Aspose.Slides.IMasterSlide.LayoutSlides**
Typ właściwości Aspose.Slides.IMasterSlide.LayoutSlides został zmieniony z ILayoutSlideCollection na nowy interfejs **IMasterLayoutSlideCollection**. Interfejs IMasterLayoutSlideCollection jest potomkiem ILayoutSlideCollection, więc istniejący kod nie wymaga adaptacji.

#### **Typ właściwości Aspose.Slides.IPresentation.LayoutSlides został zmieniony**
Typ właściwości Aspose.Slides.IPresentation.LayoutSlides został zmieniony z ILayoutSlideCollection na nowy interfejs **IGlobalLayoutSlideCollection**. Interfejs IGlobalLayoutSlideCollection jest potomkiem ILayoutSlideCollection, więc istniejący kod nie wymaga adaptacji.