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
description: "Główne motywy prezentacji w Aspose.Slides dla .NET służą do tworzenia, dostosowywania i konwertowania plików PowerPoint z spójną identyfikacją wizualną."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych współdzielonych definicji zamiast przechowywać każdą własność wizualną jako stałą wartość, dzięki czemu zmiana motywu może jednocześnie zaktualizować wiele obiektów.

W Aspose.Slides motyw na poziomie prezentacji jest dostępny poprzez właściwość [Presentation.MasterTheme](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/mastertheme/). Prezentacja może także zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji przy użyciu [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/masterthememanager/overridetheme/), układ może nadpisać odziedziczony motyw przy użyciu [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), a pojedynczy slajd może zrobić to samo. W praktyce efektywny motyw dla slajdu jest rozwiązywany poprzez ten łańcuch dziedziczenia: motyw prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Komponenty motywu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje pokazują najczęstsze przepływy pracy z motywem: przeglądanie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt efektownych wartości po rozwiązaniu dziedziczenia i nadpisań.

## **Sprawdzenie motywu**

Obiekt [MasterTheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/mastertheme/) udostępnia [ColorScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/mastertheme/fontscheme/) i [FormatScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/mastertheme/formatscheme/). Przeglądanie tych kolekcji przed ich zmianą jest szczególnie przydatne, gdy prezentacja pochodzi ze źródła zewnętrznego, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje główne właściwości motywu i zgłasza, ile stylów tła, wypełnień, linii i efektów jest przechowywanych w motywie:

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

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma ten sam efektywny motyw. Przejrzyj master powiązany ze slajdem i użyj przepływu pracy efektywnego motywu przedstawionego później w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmiana kolorów motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/pl/net/aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w [IColorScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/icolorscheme/) motywu, wszystkie obiekty, które nadal odwołują się do tego koloru motywu, zostaną rozwiązywane względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie są zmieniane przez aktualizację koloru motywu.

Poniższy przykład end-to-end tworzy kształt używający `Accent4`, zmienia kolor `Accent4` w motywie na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje efektywny kolor wypełnienia:

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

Ponieważ prostokąt pozostaje połączony z `Accent4`, jego widoczny kolor staje się czerwony po zmianie motywu. Jeśli zastąpisz kolor schematu bezpośrednim kolorem w kształcie, późniejsze zmiany `Accent4` nie będą już wpływać na to wypełnienie.

### **Używanie kolorów z dodatkowej palety**

PowerPoint tworzy jaśniejsze i ciemniejsze warianty z koloru motywu, stosując transformacje kolorów. Aspose.Slides udostępnia te transformacje poprzez [ColorTransformOperation](https://reference.aspose.com/slides/pl/net/aspose.slides/colortransformoperation/).

![Główne kolory motywu oraz jaśniejsze i ciemniejsze kolory wygenerowane z dodatkowej palety](additional-palette-colors.png)

**1** – Główne kolory motywu.  
**2** – Jaśniejsze i ciemniejsze warianty wygenerowane z głównych kolorów motywu.

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

Te warianty pozostają oparte na kolorze motywu. Jeśli `Accent4` zmieni się później, przekształcone kolory są przeliczane na nową wartość `Accent4`.

### **Mapowanie wartości `SchemeColor` na sloty `IColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/pl/net/aspose.slides/schemecolor/) używa `Text1`, `Background1`, `Text2` i `Background2`, podczas gdy [IColorScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/icolorscheme/) udostępnia te same sloty motywu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych slotów motywu; nie są to wartości dynamicznie konwertowane z jednej formy na inną.

## **Zmiana czcionek w motywie**

Schemat czcionek motywu zawiera zestaw głównej czcionki dla nagłówków i zestaw czcionki pobocznej dla tekstu głównego. Właściwości [FontScheme.Major](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/fontscheme/major/) i [FontScheme.Minor](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/fontscheme/minor/) udostępniają te zestawy.

Identyfikatory czcionek motywu zgodne z PowerPoint mogą być używane w formatowaniu tekstu:

* `+mn-lt` – czcionka ciała Latin (Minor Latin Font)
* `+mj-lt` – czcionka nagłówka Latin (Major Latin Font)
* `+mn-ea` – czcionka ciała East Asian (Minor East Asian Font)
* `+mj-ea` – czcionka nagłówka East Asian (Major East Asian Font)

Poniższy przykład tworzy jeden nagłówek używający głównej czcionki Latin z motywu oraz jedną linię ciała używającą pobocznej czcionki Latin z motywu. Następnie zmienia czcionki motywu i zapisuje wynik:

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

Nagłówek używa głównej czcionki, a tekst ciała używa czcionki pobocznej. Tekst, który ma wyraźnie określoną nazwę czcionki zamiast identyfikatora motywu, nie przełączy się automatycznie po zmianie schematu czcionek motywu.

Zbiory głównych i pobocznych czcionek mogą także zawierać mapowania czcionek dla poszczególnych systemów pisma, takich jak cyrylica, arabski, japoński, gruziński i thaana. Aby przeglądać, dodawać, zamieniać lub usuwać te mapowania, zobacz [Script-Specific Theme Fonts](/slides/pl/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Aby uzyskać więcej informacji o czcionkach w prezentacjach, zobacz [PowerPoint Fonts](/slides/pl/net/powerpoint-fonts/).
{{% /alert %}}

## **Kopiowanie lub zastosowanie motywu**

Istnieją dwa typowe przepływy pracy, które rozwiązują różne problemy.

### **Zachowanie motywu źródłowego przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego oryginalny projekt, sklonuj master źródłowy do docelowej prezentacji przy użyciu [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection/addclone/), a następnie sklonuj slajd przy użyciu [ISlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/) i sklonowanego mastera. To przenosi master, jego układy i powiązany motyw razem.

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

Jest to preferowany przepływ pracy, gdy slajd źródłowy musi wyglądać tak samo w miejscu docelowym. Samo klonowanie zawartości na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane przez motyw.

### **Zastosowanie wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd musi pozostać na obecnym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu z motywu źródłowego. Metody [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/overridetheme/initfontschemefrom/) i [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/overridetheme/initformatschemefrom/) kopiują trzy główne komponenty motywu do nadpisania.

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

### **Zastosowanie nadpisania motywu do układu**

Nadpisanie na poziomie układu ma zastosowanie do slajdów używających tego układu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacji można używać przez [LayoutSlideThemeManager](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/layoutslidethememanager/):

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

Używaj motywu na poziomie mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić tę samą podstawową projekcję, nadpisania układu, gdy jedna rodzina układów potrzebuje innego stylu, oraz nadpisania slajdu tylko dla prawdziwych wyjątków. Nadmierne nadpisania na poziomie slajdu utrudniają przewidywanie późniejszych globalnych zmian motywu.

## **Aktualizacja stylów tła motywu**

Wypełnienia tła motywu są przechowywane w [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint może prezentować więcej opcji tła w interfejsie niż liczba definicji wypełnień fizycznie przechowywanych w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odniesieniami stylów.

![Galeria stylów tła PowerPoint dla motywu prezentacji](presentation-design_8.png)

Przed użyciem stylu tła, przejrzyj przechowywaną kolekcję i bieżący [Background.StyleIndex](https://reference.aspose.com/slides/pl/net/aspose.slides/background/styleindex/). `StyleIndex` używa `0` dla braku wypełnienia tematycznego; wartości dodatnie są odniesieniami do stylów tła motywu. To różni się od indeksowania kolekcji .NET bezpośrednio, gdzie `[0]` oznacza pierwszy przechowywany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnień tła.

Poniższy przykład zgłasza dostępny licznik wypełnień tła, przypisuje odniesienie do tematycznego tła pierwszemu masterowi i zapisuje prezentację:

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

Widoczny wynik zależy od wpisu motywu odwołanego przez master oraz od wszelkich nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana tylko tła mastera może nie zmieni tego slajdu. Użyj [Background.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/background/geteffective/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Warning" %}}
Nie traktuj `StyleIndex` jako indeks kolekcji zerowego. Unikaj również twardego kodowania numeru stylu z jednego pliku i zakładania, że ma on ten sam wygląd w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Aby uzyskać informacje o bezpośrednim formatowaniu tła i dziedziczeniu tła, zobacz [Presentation Background](/slides/pl/net/presentation-background/).
{{% /alert %}}

## **Aktualizacja efektów motywu**

Schemat formatu motywu zawiera oddzielne kolekcje [FillStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/linestyles/), i [EffectStyles](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/formatscheme/effectstyles/). Typowe motywy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien przeglądać każdą kolekcję zamiast zakładać stałą liczbę.

![Subtelne, umiarkowane i intensywne efekty motywu zastosowane do tego samego kształtu](presentation-design_10.png)

Gdy uzyskujesz dostęp do tych kolekcji w C#, indeks kolekcji jest zerowy: `[0]` to pierwszy przechowywany styl, a `[2]` to trzeci. Indeksy odniesień stylu kształtu to odrębna koncepcja, udostępniana przez [IShapeStyle](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapestyle/). Modyfikowanie stylu motywu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

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

Dla kształtów, które odwołują się do tych slotów, pierwszy styl linii motywu staje się czerwony, trzeci styl wypełnienia motywu staje się jednolitym zielonym lasem, a trzeci styl efektu zyskuje zewnętrzny cień o odległości 10 punktów. Dokładny wynik wizualny nadal zależy od tego, które sloty stylu każdy kształt odwołuje oraz czy bezpośrednie formatowanie nadpisuje motyw.

## **Odczyt efektywnych wartości motywu**

Surowe obiekty motywu informują, co jest zdefiniowane na danym poziomie. Efektywne wartości informują, co slajd lub kształt faktycznie używa po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Dla tła użyj [Background.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/background/geteffective/), a dla wypełnienia [FillFormat.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/geteffective/).

Poniższy przykład odczytuje efektywny motyw, tło i pierwsze wypełnienie kształtu ze slajdu:

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

Używaj efektywnych danych do diagnostyki renderowania, walidacji i porównań. Jeśli przeglądasz tylko [Presentation.MasterTheme](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/mastertheme/), możesz przeoczyć nadpisanie mastera, układu, slajdu lub kształtu, które zmienia końcowy wygląd.

## **FAQ**

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/slidethememanager/) slajdu i zainicjuj jego nadpisanie motywu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal dziedziczą swoje istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Podczas przenoszenia slajdu i zachowania jego wyglądu źródłowego, sklonuj master źródłowy do miejsca docelowego i sklonuj slajd z tym masterem przy użyciu [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection/addclone/) i [ISlideCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/). To utrzymuje master, układy i motyw razem.

**Jak mogę zobaczyć efektywne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) dla motywu slajdu lub układu oraz odpowiednich metod danych efektywnych dla obiektów formatów, takich jak [Background.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/background/geteffective/) i [FillFormat.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/geteffective/). Te API zwracają rozwiązywane wartości po zastosowaniu dziedziczenia i nadpisań.