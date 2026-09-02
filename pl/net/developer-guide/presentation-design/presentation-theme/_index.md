---
title: Zarządzanie motywami prezentacji w .NET
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
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Główne motywy prezentacji w Aspose.Slides dla .NET umożliwiają tworzenie, dostosowywanie i konwertowanie plików PowerPoint z jednolitą identyfikacją wizualną."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych współdzielonych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, dzięki czemu zmiana motywu może zaktualizować wiele obiektów jednocześnie.

W Aspose.Slides temat na poziomie prezentacji jest dostępny poprzez właściwość [Presentation.MasterTheme](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/mastertheme/). Prezentacja może także zawierać nadpisania motywu na niższych poziomach. Master może nadpisać temat prezentacji za pomocą [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/masterthememanager/overridetheme/), układ może nadpisać odziedziczony temat za pomocą [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), a pojedynczy slajd może zrobić to samo. W praktyce skuteczny temat dla slajdu jest rozwiązywany poprzez następujący łańcuch dziedziczenia: temat prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Składniki tematu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje przedstawiają najczęstsze scenariusze pracy z motywem: sprawdzanie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt skutecznych wartości po rozwiązaniu dziedziczenia i nadpisań.

## **Sprawdzanie tematu**

Obiekt [MasterTheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/mastertheme/) udostępnia [ColorScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/mastertheme/fontscheme/) i [FormatScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/mastertheme/formatscheme/). Sprawdzanie tych kolekcji przed ich modyfikacją jest szczególnie przydatne, gdy prezentacja pochodzi z zewnętrznego źródła, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje podstawowe właściwości tematu i raportuje, ile stylów tła, wypełnień, linii i efektów jest przechowywanych w temacie:

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

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma ten sam skuteczny temat. Sprawdź master powiązany ze slajdem i użyj workflowu skutecznego tematu przedstawionego później w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmienianie kolorów tematu**

Wypełnienia, linie i tekst świadome tematu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/pl/net/aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w [IColorScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/icolorscheme/) tematu, wszystkie obiekty, które nadal odwołują się do tego koloru tematu, zostaną rozwiążone względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie zostaną zmienione przez aktualizację koloru tematu.

Poniższy kompletny przykład tworzy kształt używający `Accent4`, zmienia kolor tematu `Accent4` na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje skuteczny kolor wypełnienia:

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

Ponieważ prostokąt pozostaje powiązany z `Accent4`, jego widoczny kolor staje się czerwony po zmianie tematu. Jeśli zamienisz kolor schematu na bezpośredni kolor w kształcie, późniejsze zmiany `Accent4` nie będą już wpływać na to wypełnienie.

### **Użycie kolorów z dodatkowej palety**

PowerPoint generuje jaśniejsze i ciemniejsze warianty koloru tematu, stosując transformacje kolorów. Aspose.Slides udostępnia te transformacje za pośrednictwem [ColorTransformOperation](https://reference.aspose.com/slides/pl/net/aspose.slides/colortransformoperation/).

![Główne kolory tematu oraz jaśniejsze i ciemniejsze kolory wygenerowane z dodatkowej palety](additional-palette-colors.png)

**1** – Główne kolory tematu.  
**2** – Jaśniejsze i ciemniejsze warianty wygenerowane z głównych kolorów tematu.

Poniższy przykład tworzy sześć prostokątów opartych na `Accent4`, stosuje transformacje luminancji do pięciu z nich i zapisuje wynik:

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

Te warianty pozostają oparte na kolorze tematu. Jeśli `Accent4` zostanie później zmieniony, przekształcone kolory zostaną ponownie obliczone na podstawie nowej wartości `Accent4`.

### **Mapowanie wartości `SchemeColor` na pozycje `IColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/pl/net/aspose.slides/schemecolor/) używa `Text1`, `Background1`, `Text2` i `Background2`, podczas gdy [IColorScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/icolorscheme/) udostępnia te same pozycje tematu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych pozycji tematu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmienianie czcionek tematu**

Schemat czcionek tematu zawiera główny zestaw czcionek dla nagłówków oraz dodatkowy zestaw czcionek dla tekstu podstawowego. Właściwości [FontScheme.Major](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/fontscheme/major/) i [FontScheme.Minor](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/fontscheme/minor/) udostępniają te zestawy.

Identyfikatory czcionek kompatybilne z PowerPoint można używać w formatowaniu tekstu:

* `+mn-lt` – Czcionka podstawowa łacińska (Minor Latin Font)
* `+mj-lt` – Czcionka nagłówka łacińska (Major Latin Font)
* `+mn-ea` – Czcionka podstawowa wschodnioazjatycka (Minor East Asian Font)
* `+mj-ea` – Czcionka nagłówka wschodnioazjatycka (Major East Asian Font)

Poniższy przykład tworzy jeden nagłówek używający głównej łacińskiej czcionki tematu oraz jedną linię tekstu używającą dodatkowej łacińskiej czcionki tematu. Następnie zmienia czcionki tematu i zapisuje wynik:

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

Nagłówek podąża za czcionką główną, a tekst podstawowy za czcionką dodatkową. Tekst, który ma explicite nazwę czcionki zamiast identyfikatora tematu, nie przełączy się automatycznie po zmianie schematu czcionek tematu.

Zbiory czcionek głównych i dodatkowych mogą również zawierać mapowania czcionek dla poszczególnych systemów pisma, takich jak cyrylica, arabski, japoński, gruziński i thaana. Aby sprawdzić, dodać, zamienić lub usunąć te mapowania, zobacz [Czcionki tematu specyficzne dla skryptu](/slides/pl/net/script-specific-font-mappings/).

{{% alert color="info" title="Wskazówka" %}}
Aby uzyskać więcej informacji o czcionkach w prezentacji, zobacz [Czcionki PowerPoint](/slides/pl/net/powerpoint-fonts/).
{{% /alert %}}

## **Kopiowanie lub zastosowanie tematu**

Poniższe scenariusze rozwiązują różne problemy związane z tematem.

### **Zastosowanie zewnętrznego tematu do slajdów zależnych od mastera**

Użyj [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) gdy masz plik tematu PowerPoint (`.thmx`) i chcesz zmienić styl każdego slajdu zależnego od określonego mastera. Wybierz master z kolekcji [Presentation.Masters](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/masters/), która implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection/), i przekaż ścieżkę do pliku tematu metodzie.

Metoda wykonuje następujące operacje:

1. Tworzy nowy slajd master na podstawie wybranego mastera.  
2. Zastosowuje zewnętrzny temat do nowego mastera.  
3. Przypisuje nowy master wszystkim slajdom, które wcześniej zależały od wybranego mastera.  
4. Zwraca nowo utworzony [IMasterSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/).

Poniższy przykład stosuje zewnętrzny temat do slajdów zależnych od pierwszego mastera, zapisuje prezentację i otwiera wynik ponownie:

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

Nieprawidłowy, uszkodzony lub nieobsługiwany temat może spowodować [PptxException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxexception/) lub jedną z jego podklas związanych z formatem. Waliduj ścieżki podawane przez użytkowników, obsługuj błędy dostępu do systemu plików i zapisuj prezentację dopiero po pomyślnym zastosowaniu tematu.

Tylko slajdy zależne od wybranego mastera są ponownie przypisane. Slajdy powiązane z innymi masterami zachowują istniejące mastery i tematy. Kolory, czcionki, wypełnienia, linie, tła i efekty świadome tematu są rozwiązywane względem zewnętrznego tematu. Bezpośrednio przypisane kolory, czcionki, wypełnienia i inne explicite formatowanie mogą pozostać niezmienione. Nadpisania na poziomie układu i slajdu mogą również mieć pierwszeństwo przed wartościami odziedziczonymi z nowego mastera.

Temat może odwoływać się do czcionek niedostępnych w środowisku uruchomieniowym. Dla spójnego renderowania i eksportu zainstaluj wymagane czcionki, udostępnij je przez [niestandardowe źródła czcionek](/slides/pl/net/custom-font/), lub skonfiguruj [zastępowanie czcionek](/slides/pl/net/font-substitution/).

Jest to bezpośredni workflow na poziomie mastera: metoda przyjmuje ścieżkę do pliku `.thmx` i nie wymaga ręcznego tworzenia nadpisań tematu na poziomie slajdu lub układu.

### **Zastosowanie różnych zewnętrznych tematów w prezentacji wielomastrowej**

Gdy odpowiedni master nie jest znany z góry, pobierz go z reprezentatywnego slajdu za pomocą [ISlide.LayoutSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/layoutslide/) i [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/ilayoutslide/masterslide/). Przechowaj oryginalne referencje masterów przed zastosowaniem jakichkolwiek tematów, ponieważ każde wywołanie tworzy kolejny master w prezentacji.

Poniższy przykład używa slajdów z dwóch sekcji, aby zlokalizować ich mastery i zastosować inny zewnętrzny temat do każdej grupy:

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

Pierwsze wywołanie wpływa tylko na slajdy zależne od `firstGroupMaster`, a drugie wywołanie wpływa tylko na slajdy zależne od `secondGroupMaster`. Slajdy należące do innych masterów nie są przekształcane.

### **Zachowanie tematu źródłowego przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego pierwotny projekt, sklonuj źródłowy master do docelowej prezentacji przy użyciu [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection/addclone/), a następnie sklonuj slajd przy użyciu [ISlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/) i sklonowanego mastera. To przenosi master, jego układy i powiązany temat razem.

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

Jest to preferowany workflow, gdy źródłowy slajd musi wyglądać identycznie w miejscu docelowym. Proste klonowanie treści na niepowiązanym masterze docelowym może zmienić kolory, czcionki, tła i efekty sterowane tematem.

### **Zastosowanie wartości tematu do istniejącego slajdu**

Jeśli docelowy slajd ma pozostać na bieżącym masterze i układzie, zainicjalizuj nadpisanie na poziomie slajdu z tematu źródłowego. Metody [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/overridetheme/initfontschemefrom/) i [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/overridetheme/initformatschemefrom/) kopiują trzy główne komponenty tematu do nadpisania.

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

To zmienia temat używany przez ten slajd bez zmiany tematu dziedziczonego przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości dziedziczonych, wywołaj [OverrideTheme.Clear](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/overridetheme/clear/).

### **Zastosowanie nadpisania tematu do układu**

Nadpisanie na poziomie układu dotyczy slajdów używających tego układu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacji mogą być użyte poprzez [LayoutSlideThemeManager](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/layoutslidethememanager/) układu:

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

Użyj tematu na poziomie mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić tę samą bazową konstrukcję, nadpisania układu, gdy rodzina układów wymaga innego stylu, oraz nadpisania slajdu wyłącznie w przypadku rzeczywistych wyjątków. Nadmierne nadpisania na poziomie slajdu utrudniają późniejsze globalne zmiany tematu.

## **Aktualizacja stylów tła tematu**

Wypełnienia tła tematu są przechowywane w [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint może prezentować w interfejsie więcej opcji tła niż liczba definicji wypełnień fizycznie zapisanych w tej kolekcji, ponieważ UI może łączyć wypełnienia tematu z kolorami tematu i innymi odniesieniami stylów.

![Galeria stylów tła PowerPoint dla tematu prezentacji](presentation-design_8.png)

Przed użyciem stylu tła sprawdź przechowywaną kolekcję i bieżącą wartość [Background.StyleIndex](https://reference.aspose.com/slides/pl/net/aspose.slides/background/styleindex/). `StyleIndex` używa `0` dla braku tematycznego wypełnienia; dodatnie wartości są odwołaniami do stylu tła tematu. To różni się od indeksowania kolekcji .NET bezpośrednio, gdzie `[0]` oznacza pierwszy zapisany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnień tła.

Poniższy przykład raportuje dostępny licznik wypełnień tła, przypisuje odwołanie tematycznego tła do pierwszego mastera i zapisuje prezentację:

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

Widoczny rezultat zależy od wpisu tematu, na który wskazuje master, oraz od wszelkich nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana samego tła mastera może nie wpłynąć na ten slajd. Użyj [Background.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/background/geteffective/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Ostrzeżenie" %}}
Nie traktuj `StyleIndex` jako indeks kolekcji zaczynający się od zera. Unikaj także twardego kodowania numeru stylu z jednego pliku i zakładania, że będzie miał taki sam wygląd w innym pliku; definicje stylów tematu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Wskazówka" %}}
Aby sformatować tło bezpośrednio i zarządzać dziedziczeniem tła, zobacz [Tło prezentacji](/slides/pl/net/presentation-background/).
{{% /alert %}}

## **Aktualizacja efektów tematu**

Schemat formatu tematu zawiera oddzielne kolekcje [FillStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/linestyles/) i [EffectStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/effectstyles/). Typowe tematy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien sprawdzać każdą kolekcję zamiast zakładać stałą liczbę wpisów.

![Subtelne, umiarkowane i intensywne efekty tematu zastosowane do tego samego kształtu](presentation-design_10.png)

Kiedy uzyskujesz dostęp do tych kolekcji w C#, indeks kolekcji jest zerowy: `[0]` to pierwszy zapisany styl, a `[2]` to trzeci. Indeksy referencji stylu kształtu to odrębna koncepcja, udostępniona przez [IShapeStyle](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapestyle/). Modyfikowanie stylu tematu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

Poniższy przykład sprawdza, czy wymagane wpisy stylów istnieją, zmienia pierwszy styl linii, zmienia trzeci styl wypełnienia, włącza zewnętrzny cień w trzecim stylu efektu i zapisuje wynik:

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

Dla kształtów, które odwołują się do tych slotów, pierwszy linowy styl tematu staje się czerwony, trzeci wypełnieniowy styl tematu staje się jednolitym zielonym lasem, a trzeci styl efektu zyskuje zewnętrzny cień o odległości 10 punktów. Dokładny efekt wizualny nadal zależy od tego, które sloty stylu odwołuje każdy kształt i czy bezpośrednie formatowanie nie nadpisuje tematu.

![Style efektów tematu po zmianie ustawień linii, wypełnienia i cienia](presentation-design_11.png)

## **Określenie, czy skuteczne wypełnienie jednolite używa koloru tematu**

Wypełnienie może być zapisane bezpośrednio na obiekcie lub dziedziczone z akapitu, układu, mastera, stylu tematu lub innego poziomu formatowania. Wywołaj [IFillFormat.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/ifillformat/geteffective/), aby rozwiązać tę hierarchię w niezmienny [IFillFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ifillformateffectivedata/). Najpierw sprawdź [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/ifillformateffectivedata/filltype/). Tylko gdy jest `FillType.Solid`, odczytaj właściwości wypełnienia jednolitego.

Dla wypełnienia jednolitego, [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/pl/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) zwraca ostateczną wartość RGB po dziedziczeniu, wyszukiwaniu w temacie i zastosowaniu transformacji kolorów. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/pl/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) zwraca odpowiadające logiczne miejsce [SchemeColor](https://reference.aspose.com/slides/pl/net/aspose.slides/schemecolor/), takie jak `Text1` lub `Accent6`. Wartość `SchemeColor.NotDefined` oznacza, że skuteczne wypełnienie jednolite nie opiera się na kolorze schematu. W workflowie, w którym wypełnienia są albo kolorami tematu, albo bezpośrednimi kolorami RGB, ta wartość identyfikuje wypełnienie RGB.

Nie używaj wyłącznie lokalnej wartości [IColorFormat.SchemeColor](https://reference.aspose.com/slides/pl/net/aspose.slides/icolorformat/schemecolor/) do klasyfikacji wypełnienia. Na przykład fragment tekstu może nie mieć lokalnie zdefiniowanego koloru schematu, więc jego lokalna wartość to `NotDefined`, podczas gdy jego skuteczne wypełnienie dziedziczy kolor tematu i rozwiązuje się do `Text1` lub `Accent6`. Natomiast `SolidFillSchemeColor` mówi, który logiczny slot tematu wygenerował skuteczny kolor, ale nie informuje, czy ten slot pochodzi z obiektu, akapitu, układu, mastera czy innego poziomu hierarchii formatowania.

Poniższy przykład ładuje prezentację, audytuje zarówno wypełnienia kształtów, jak i wypełnienia fragmentów tekstu, wypisuje każdą końcową wartość RGB i powiązany kolor schematu oraz oznacza wypełnienia jednolite, które nie będą śledzić zmian koloru tematu:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

Gałąź `NotDefined` dostarcza listę audytową wypełnień jednolitych, które nie będą reagować na zmiany w slotach kolorów tematu. Przejrzyj te obiekty, gdy prezentacja musi podążać za nową paletą marki. Zgłoszona wartość RGB wciąż pokazuje aktualny wygląd, podczas gdy wartość schematu wyjaśnia, czy ten wygląd jest powiązany z tematem.

Obiekty formatu skutecznego są migawkami. Po zmianie tematu prezentacji, nadpisania tematu lub dowolnego formatowania dziedziczonego, wywołaj ponownie `GetEffective` i odczytaj nowy obiekt `IFillFormatEffectiveData` przed porównaniem lub raportowaniem kolorów.

## **Odczyt skutecznych wartości tematu**

Surowe obiekty tematu mówią, co jest zdefiniowane na danym poziomie. Skuteczne wartości mówią, co slajd lub kształt faktycznie używa po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Dla tła użyj [Background.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/background/geteffective/), a dla wypełnienia [FillFormat.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/geteffective/).

Poniższy przykład odczytuje skuteczny temat, tło i pierwsze wypełnienie kształtu ze slajdu:

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

Używaj danych skutecznych do diagnostyki renderowania, walidacji i porównań. Jeśli sprawdzisz tylko [Presentation.MasterTheme](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/mastertheme/), możesz przeoczyć nadpisanie mastera, układu, slajdu lub kształtu, które zmienia ostateczny wygląd.

## **FAQ**

**Czy zastosowanie zewnętrznego tematu wpływa na każdy slajd w prezentacji?**

Nie. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) przypisuje tylko te slajdy, które zależą od wybranego mastera. Slajdy korzystające z innych masterów zachowują istniejące tematy.

**Czy mogę zastosować temat do pojedynczego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/slidethememanager/) slajdu i zainicjalizuj jego nadpisanie tematu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal dziedziczą swoje istniejące tematy.

**Jaki jest najbezpieczniejszy sposób przeniesienia tematu z jednej prezentacji do drugiej?**

Podczas przenoszenia slajdu i zachowywania jego pierwotnego wyglądu, sklonuj źródłowy master do docelowej prezentacji i sklonuj slajd z tym masterem przy użyciu [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection/addclone/) oraz [ISlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/). To utrzymuje master, układy i temat razem.

**Jak mogę zobaczyć skuteczne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) dla tematu slajdu lub układu oraz odpowiednich metod zwracających dane skuteczne dla obiektów formatu, takich jak [Background.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/background/geteffective/) i [FillFormat.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/geteffective/). Te API zwracają rozpoznane wartości po zastosowaniu dziedziczenia i nadpisań.