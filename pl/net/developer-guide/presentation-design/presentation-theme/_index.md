---
title: Zarządzaj motywami prezentacji w .NET
linktitle: Motyw prezentacji
type: docs
weight: 10
url: /pl/net/presentation-theme/
keywords:
- Motyw PowerPoint
- Motyw prezentacji
- Motyw slajdu
- Ustaw motyw
- Zmień motyw
- Zarządzaj motywem
- Zewnętrzny motyw
- THMX
- Kolor motywu
- Dodatkowa paleta
- Czcionka motywu
- Styl motywu
- Efekt motywu
- PowerPoint
- OpenDocument
- Prezentacja
- .NET
- C#
- Aspose.Slides
description: "Główne motywy prezentacji w Aspose.Slides dla .NET, umożliwiające tworzenie, dostosowywanie i konwertowanie plików PowerPoint z zachowaniem spójnej identyfikacji wizualnej."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych wspólnych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, dzięki czemu zmiana motywu może jednocześnie zaktualizować wiele obiektów.

W Aspose.Slides motyw na poziomie prezentacji jest dostępny poprzez właściwość [Presentation.MasterTheme](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/mastertheme/). Prezentacja może również zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji za pomocą [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/masterthememanager/overridetheme/), układ może nadpisać odziedziczony motyw za pomocą [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), a pojedynczy slajd może zrobić to samo. W praktyce skuteczny motyw slajdu jest określany poprzez łańcuch dziedziczenia: motyw prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Składniki motywu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje przedstawiają najczęstsze scenariusze pracy z motywem: przeglądanie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt skutecznych wartości po rozwiązaniu dziedziczenia i nadpisań.

## **Sprawdź motyw**

Obiekt [MasterTheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/mastertheme/) udostępnia [ColorScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/mastertheme/fontscheme/) oraz [FormatScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/mastertheme/formatscheme/). Przeglądanie tych kolekcji przed ich modyfikacją jest szczególnie przydatne, gdy prezentacja pochodzi ze zewnętrznego źródła, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje główne właściwości motywu i podaje, ile stylów tła, wypełnienia, linii i efektów jest przechowywanych w motywie:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma taki sam skuteczny motyw. Sprawdź master powiązany ze slajdem i użyj workflowu skutecznego motywu przedstawionego później w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmień kolory motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/pl/net/aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w [IColorScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/icolorscheme/) motywu, wszystkie obiekty, które nadal odwołują się do tego koloru motywu, zostaną rozpisane względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie zostaną zmienione po aktualizacji koloru motywu.

Poniższy przykład end‑to‑end tworzy kształt używający `Accent4`, zmienia kolor `Accent4` motywu na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje skuteczny kolor wypełnienia:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

Ponieważ prostokąt pozostaje powiązany z `Accent4`, po zmianie motywu jego widoczny kolor staje się czerwony. Jeśli zamienisz kolor schematu na bezpośredni kolor na kształcie, późniejsze zmiany `Accent4` nie będą już wpływać na to wypełnienie.

### **Użyj kolorów z dodatkowej palety**

PowerPoint tworzy jaśniejsze i ciemniejsze warianty z koloru motywu, stosując transformacje kolorów. Aspose.Slides udostępnia te transformacje poprzez [ColorTransformOperation](https://reference.aspose.com/slides/pl/net/aspose.slides/colortransformoperation/).

![Główne kolory motywu oraz jaśniejsze i ciemniejsze kolory wygenerowane z dodatkowej palety](additional-palette-colors.png)

**1** – Główne kolory motywu.  
**2** – Jaśniejsze i ciemniejsze warianty utworzone z głównych kolorów motywu.

Poniższy przykład tworzy sześć prostokątów opartych na `Accent4`, pięciu z nich stosuje transformacje luminancji i zapisuje wynik:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

Te warianty pozostają oparte na kolorze motywu. Jeśli później `Accent4` zostanie zmieniony, przekształcone kolory zostaną przeliczone na podstawie nowej wartości `Accent4`.

### **Mapuj wartości `SchemeColor` na sloty `IColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/pl/net/aspose.slides/schemecolor/) używa `Text1`, `Background1`, `Text2` i `Background2`, podczas gdy [IColorScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/icolorscheme/) udostępnia te same sloty motywu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych slotów motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmień czcionki motywu**

Schemat czcionek motywu zawiera zestaw głównych czcionek dla nagłówków oraz zestaw podrzędnych czcionek dla treści. Właściwości [FontScheme.Major](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/fontscheme/major/) i [FontScheme.Minor](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/fontscheme/minor/) udostępniają te zestawy.

Identyfikatory czcionek zgodne z PowerPoint mogą być używane w formatowaniu tekstu:

* `+mn-lt` – Czcionka ciała tekstu łacińska (Minor Latin Font)
* `+mj-lt` – Czcionka nagłówka łacińska (Major Latin Font)
* `+mn-ea` – Czcionka ciała tekstu wschodnio‑azjatycka (Minor East Asian Font)
* `+mj-ea` – Czcionka nagłówka wschodnio‑azjatycka (Major East Asian Font)

Poniższy przykład tworzy jeden nagłówek używający głównej łacińskiej czcionki motywu oraz jedną linię tekstu ciała używającą podrzędnej łacińskiej czcionki motywu. Następnie zmienia czcionki motywu i zapisuje wynik:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

Nagłówek podąża za czcionką główną, a tekst ciała za czcionką podrzędną. Tekst z wyraźnie określoną nazwą czcionki zamiast identyfikatora motywu nie zmieni się automatycznie po zmianie schematu czcionek motywu.

Zbiory czcionek głównych i podrzędnych mogą również zawierać mapowania czcionek dla poszczególnych systemów pisma, takich jak cyrylica, arabski, japoński, gruziński i thaana. Aby przeglądać, dodawać, zastępować lub usuwać te mapowania, zobacz [Script‑Specific Theme Fonts](/slides/pl/net/script-specific-font-mappings/).

{{% alert color="info" title="Porada" %}}
Aby uzyskać więcej informacji o czcionkach w prezentacjach, zobacz [Czcionki PowerPoint](/slides/pl/net/powerpoint-fonts/).
{{% /alert %}}

## **Kopiuj lub zastosuj motyw**

Poniższe workflowy rozwiązują różne problemy związane z motywami.

### **Zastosuj zewnętrzny motyw do zależnych slajdów mastera**

Użyj [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) gdy masz plik motywu PowerPoint (`.thmx`) i chcesz zmienić wygląd wszystkich slajdów zależnych od określonego mastera. Wybierz master z kolekcji [Presentation.Masters](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/masters/), która implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection/), i przekaż ścieżkę do pliku tematu metodzie.

Metoda wykonuje następujące operacje:

1. Tworzy nowy slajd master na podstawie wybranego mastera.  
1. Zastosowuje zewnętrzny motyw do nowego mastera.  
1. Przypisuje nowego mastera do wszystkich slajdów, które wcześniej zależały od wybranego mastera.  
1. Zwraca nowo utworzony [IMasterSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/).

Poniższy przykład stosuje zewnętrzny motyw do slajdów zależnych od pierwszego mastera, zapisuje prezentację i ponownie otwiera wynik:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

Nieprawidłowy, uszkodzony lub nieobsługiwany motyw może spowodować [PptxException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxexception/) lub jedną z jego podklas związanych z formatem. Waliduj ścieżki podawane przez użytkowników, obsługuj błędy dostępu do systemu plików i zapisuj prezentację dopiero po pomyślnym zastosowaniu motywu.

Tylko slajdy zależne od wybranego mastera są ponownie przypisane. Slajdy powiązane z innymi masterami zachowują swoje istniejące mastery i motywy. Kolory, czcionki, wypełnienia, linie, tła i efekty świadome motywu są rozpisane względem zewnętrznego motywu. Bezpośrednio przypisane kolory, czcionki, wypełnienia i inne formatowanie mogą pozostać niezmienione. Nadpisania na poziomie układu i slajdu mogą również mieć pierwszeństwo przed wartościami odziedziczonymi z nowego mastera.

Motyw może odwoływać się do czcionek, które nie są dostępne w środowisku uruchomieniowym. Aby zapewnić spójne renderowanie i eksport, zainstaluj wymagane czcionki, udostępnij je poprzez [custom font sources](/slides/pl/net/custom-font/), lub skonfiguruj [font substitution](/slides/pl/net/font-substitution/).

Jest to bezpośredni workflow na poziomie mastera: metoda przyjmuje ścieżkę do pliku `.thmx` i nie wymaga ręcznego tworzenia nadpisań motywu na poziomie slajdu lub układu.

### **Zastosuj różne zewnętrzne motywy w prezentacji z wieloma masterami**

Gdy nie wiadomo, który master będzie potrzebny, pobierz go z reprezentatywnego slajdu za pomocą [ISlide.LayoutSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/layoutslide/) i [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/masterslide/). Przechowaj oryginalne referencje masterów przed zastosowaniem jakichkolwiek motywów, ponieważ każde wywołanie tworzy kolejny master w prezentacji.

Poniższy przykład używa slajdów z dwóch sekcji, aby odnaleźć ich mastery i stosuje inny zewnętrzny motyw do każdej grupy:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

Pierwsze wywołanie wpływa tylko na slajdy zależne od `firstGroupMaster`, a drugie wywołanie tylko na slajdy zależne od `secondGroupMaster`. Slajdy powiązane z innymi masterami nie zostaną przetworzone.

### **Zachowaj motyw źródłowy przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego pierwotny projekt, sklonuj master źródłowy do docelowej prezentacji przy użyciu [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection/addclone/), a następnie sklonuj slajd przy użyciu [ISlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/) i sklonowanego mastera. To przenosi master, jego układy oraz powiązany motyw razem.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

Jest to zalecany workflow, gdy slajd źródłowy musi wyglądać identycznie w miejscu docelowym. Proste klonowanie treści na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane motywem.

### **Zastosuj wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd musi pozostać na bieżącym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu na podstawie motywu źródłowego. Metody [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/overridetheme/initfontschemefrom/) i [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/overridetheme/initformatschemefrom/) kopiują trzy główne komponenty motywu do nadpisania.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

To zmienia motyw używany przez ten slajd bez zmiany motywu dziedziczonego przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości dziedziczonych, wywołaj [OverrideTheme.Clear](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/overridetheme/clear/).

### **Zastosuj nadpisanie motywu do układu**

Nadpisanie na poziomie układu dotyczy slajdów wykorzystujących dany układ, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacji można używać przez [LayoutSlideThemeManager](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/layoutslidethememanager/) układu:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

Użyj motywu na poziomie mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić tę samą bazową koncepcję, nadpisanie układu, gdy rodzina układów wymaga odmiennego stylu, oraz nadpisanie slajdu tylko dla prawdziwych wyjątków. Nadmierne nadpisania na poziomie slajdu utrudniają późniejsze globalne zmiany motywu.

## **Zaktualizuj style tła motywu**

Wypełnienia tła motywu są przechowywane w [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint może prezentować więcej opcji tła w interfejsie niż liczba definicji w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odwołaniami stylów.

![Galeria stylów tła PowerPoint dla motywu prezentacji](presentation-design_8.png)

Przed użyciem stylu tła, sprawdź przechowywaną kolekcję oraz aktualny [Background.StyleIndex](https://reference.aspose.com/slides/pl/net/aspose.slides/background/styleindex/). `StyleIndex` używa `0` dla braku wypełnienia motywowego; wartości dodatnie to odwołania do stylów tła motywu. To różni się od indeksowania kolekcji .NET, gdzie `[0]` oznacza pierwszy przechowywany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnień tła.

Poniższy przykład podaje liczbę dostępnych wypełnień tła, przypisuje odwołanie do motywu tła pierwszemu masterowi i zapisuje prezentację:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

Widoczny rezultat zależy od wpisu motywu, na który wskazuje master, oraz od ewentualnych nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana jedynie tła mastera może nie wpłynąć na ten slajd. Użyj [Background.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/background/geteffective/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Ostrzeżenie" %}}
Nie traktuj `StyleIndex` jako indeksu zerowego w kolekcji. Unikaj także twardego kodowania numeru stylu z jednego pliku i zakładania, że będzie miał taki sam wygląd w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Porada" %}}
Aby sformatować tło bezpośrednio i zrozumieć dziedziczenie tła, zobacz [Presentation Background](/slides/pl/net/presentation-background/).
{{% /alert %}}

## **Zaktualizuj efekty motywu**

Schemat formatu motywu zawiera oddzielne kolekcje [FillStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/linestyles/) i [EffectStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/effectstyles/). Typowe motywy Office często zawierają trzy główne wpisy stylów odpowiadające wizualnie subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien sprawdzać każdą kolekcję zamiast zakładać stałą liczbę.

![Delikatne, umiarkowane i intensywne efekty motywu zastosowane do tego samego kształtu](presentation-design_10.png)

W C# indeksowanie tych kolekcji jest zerowe: `[0]` to pierwszy przechowywany styl, a `[2]` to trzeci. Indeksy odwołań stylów w kształcie to osobna koncepcja, udostępniana przez [IShapeStyle](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapestyle/). Modyfikacja stylu motywu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

Poniższy przykład sprawdza, czy wymagane wpisy stylów istnieją, zmienia pierwszy styl linii, trzeci styl wypełnienia, włącza zewnętrzny cień w trzecim stylu efektu i zapisuje wynik:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

Dla kształtów odwołujących się do tych slotów, pierwszy styl linii motywu staje się czerwony, trzeci styl wypełnienia motywu staje się jednolitym zielonym lasem, a trzeci styl efektu uzyskuje zewnętrzny cień o odległości 10 punktów. Dokładny wygląd nadal zależy od tego, które sloty stylów każdy kształt referuje i czy bezpośrednie formatowanie nadpisuje motyw.

![Style efektów motywu po zmianie linii, wypełnienia i ustawień cienia](presentation-design_11.png)

## **Odczytaj skuteczne wartości motywu**

Surowe obiekty motywu mówią, co jest zdefiniowane na danym poziomie. Skuteczne wartości mówią, co slajd lub kształt faktycznie używa po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Dla tła użyj [Background.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/background/geteffective/), a dla wypełnienia [FillFormat.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/geteffective/).

Poniższy przykład odczytuje skuteczny motyw, tło i wypełnienie pierwszego kształtu ze slajdu:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

Używaj danych skutecznych do diagnostyki renderowania, walidacji i porównań. Jeśli przeglądasz wyłącznie [Presentation.MasterTheme](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/mastertheme/), możesz przeoczyć nadpisanie mastera, układu, slajdu lub kształtu, które zmienia ostateczny wygląd.

## **FAQ**

**Czy zastosowanie zewnętrznego motywu wpływa na każdy slajd w prezentacji?**

Nie. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) przypisuje tylko slajdy zależne od wybranego mastera. Slajdy używające innych masterów zachowują istniejące motywy.

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/slidethememanager/) slajdu i zainicjuj jego nadpisanie motywu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal dziedziczą swoje istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Podczas przenoszenia slajdu i zachowania jego pierwotnego wyglądu, sklonuj master źródłowy do docelowej prezentacji przy użyciu [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection/addclone/) oraz sklonuj slajd z tym masterem przy użyciu [ISlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/). To zachowuje master, układy i motyw razem.

**Jak mogę zobaczyć skuteczne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) dla slajdu lub układu oraz odpowiednich metod danych skutecznych dla obiektów formatu, takich jak [Background.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/background/geteffective/) i [FillFormat.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/geteffective/). Te API zwracają wartości po rozwiązaniu dziedziczenia i nadpisań.