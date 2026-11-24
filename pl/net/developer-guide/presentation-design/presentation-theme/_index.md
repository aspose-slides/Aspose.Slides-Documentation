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
description: "Główne motywy prezentacji w Aspose.Slides dla .NET, służące do tworzenia, dostosowywania i konwertowania plików PowerPoint z zachowaniem spójnej identyfikacji wizualnej."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych współdzielonych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, więc zmiana motywu może jednocześnie zaktualizować wiele obiektów.

W Aspose.Slides motyw na poziomie prezentacji jest dostępny za pośrednictwem właściwości [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/). Prezentacja może także zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji przy użyciu [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/masterthememanager/overridetheme/), układ może nadpisać swój odziedziczony motyw przy użyciu [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), a pojedynczy slajd może zrobić to samo. W praktyce skuteczny motyw dla slajdu jest rozwiązywany w łańcuchu dziedziczenia: motyw prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Składniki motywu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje pokazują najczęstsze scenariusze pracy z motywem: sprawdzanie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt skutecznych wartości po rozwiązaniu dziedziczenia i nadpisań.

## **Sprawdzenie motywu**

Obiekt [MasterTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/) udostępnia [ColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/fontscheme/) i [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/formatscheme/). Sprawdzanie tych kolekcji przed ich modyfikacją jest szczególnie przydatne, gdy prezentacja pochodzi z zewnętrznego źródła, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje główne właściwości motywu i informuje, ile stylów tła, wypełnień, linii i efektów jest przechowywanych w motywie:

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

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma ten sam skuteczny motyw. Sprawdź master powiązany ze slajdem i użyj przepływu pracy ze skutecznym motywem przedstawionego później w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmiana kolorów motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/), wszystkie obiekty nadal odwołujące się do tego koloru motywu zostaną przeliczane względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie są zmieniane przez aktualizację koloru motywu.

Poniższy przykład typu end‑to‑end tworzy kształt używający `Accent4`, zmienia kolor `Accent4` w motywie na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje skuteczny kolor wypełnienia:

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

Ponieważ prostokąt pozostaje powiązany z `Accent4`, jego widoczny kolor staje się czerwony po zmianie motywu. Jeśli zamienisz kolor schematu na bezpośredni kolor w kształcie, późniejsze zmiany `Accent4` nie będą już wpływać na to wypełnienie.

### **Użyj kolorów z dodatkowej palety**

PowerPoint wyprowadza jaśniejsze i ciemniejsze warianty z koloru motywu, stosując przekształcenia kolorów. Aspose.Slides udostępnia te przekształcenia przez [ColorTransformOperation](https://reference.aspose.com/slides/net/aspose.slides/colortransformoperation/).

![Główne kolory motywu oraz jaśniejsze i ciemniejsze kolory wygenerowane z dodatkowej palety](additional-palette-colors.png)

**1** – Główne kolory motywu.

**2** – Jaśniejsze i ciemniejsze warianty wyprodukowane z głównych kolorów motywu.

Poniższy przykład tworzy sześć prostokątów opartych na `Accent4`, stosuje przekształcenia luminancji do pięciu z nich i zapisuje wynik:

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

Warianty te nadal bazują na kolorze motywu. Jeśli `Accent4` zmieni się później, przekształcone kolory zostaną przeliczone z nowej wartości `Accent4`.

### **Mapowanie wartości `SchemeColor` do slotów `IColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) używa `Text1`, `Background1`, `Text2` i `Background2`, podczas gdy [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) udostępnia te same sloty motywu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych slotów motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmiana czcionek motywu**

Schemat czcionek motywu zawiera główny zestaw czcionek dla nagłówków oraz poboczny zestaw czcionek dla tekstu podstawowego. Właściwości [FontScheme.Major](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/major/) i [FontScheme.Minor](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/minor/) udostępniają te zestawy.

Identyfikatory czcionek kompatybilnych z PowerPoint mogą być używane w formatowaniu tekstu:

* `+mn‑lt` – Czcionka tekstu podstawowego Latin (Minor Latin Font)
* `+mj‑lt` – Czcionka nagłówka Latin (Major Latin Font)
* `+mn‑ea` – Czcionka tekstu podstawowego East Asian (Minor East Asian Font)
* `+mj‑ea` – Czcionka nagłówka East Asian (Major East Asian Font)
* `+mn‑cs` – Czcionka tekstu podstawowego Complex Script (Minor Complex Script Font)
* `+mj‑cs` – Czcionka nagłówka Complex Script (Major Complex Script Font)

Poniższy przykład tworzy jeden nagłówek używający głównej czcionki Latin motywu oraz jedną linię tekstu podstawowego używającą pobocznej czcionki Latin. Następnie zmienia czcionki motywu i zapisuje wynik:

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

Nagłówek podąża za główną czcionką, a tekst podstawowy za poboczną czcionką. Tekst, który ma jawnie określoną nazwę czcionki zamiast identyfikatora motywu, nie zostanie automatycznie zmieniony, gdy schemat czcionek motywu się zmieni.

Główne i poboczne kolekcje czcionek mogą także zawierać mapowania czcionek dla poszczególnych systemów pisma, takich jak cyrylica, arabski, japoński, gruziński i thaana. Aby sprawdzić, dodać, zastąpić lub usunąć te mapowania, zobacz [Theme Fonts specyficzne dla skryptu](/slides/pl/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Więcej informacji o czcionkach w prezentacjach znajdziesz w [Czcionkach PowerPoint](/slides/pl/net/powerpoint-fonts/).
{{% /alert %}}

### **Rozwiązywanie odwołań do czcionek motywu**

Podczas sprawdzania tekstu [IFontData.FontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/fontname/) może zawierać odwołanie do motywu, takie jak `+mn‑lt`, zamiast nazwy rodziny czcionki. Wywołaj [IFontData.GetFontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/getfontname/) z odpowiednim [IThemeEffectiveData](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeeffectivedata/), aby rozwiązać to odwołanie. Prefiksy `+mj` i `+mn` wybierają odpowiednio główny i poboczny zestaw czcionek; przyrostki `-lt`, `-ea` i `-cs` wybierają ich czcionki Latin, East Asian i Complex Script.

Uzyskaj skuteczny motyw poprzez [IThemeable.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeable/createthemeeffective/) na obiekcie, którego motyw ma zastosowanie do sprawdzanego tekstu. Dla zwykłego tekstu na slajdzie użyj `slide.CreateThemeEffective()`, aby kontekst obejmował odziedziczony motyw slajdu i lokalne nadpisania. Podczas sprawdzania układu lub samego mastera użyj jego własnego skutecznego motywu. Nie zakładaj, że motyw pierwszego mastera dotyczy każdego slajdu.

Poniższy przykład tworzy fragment tekstu, który jawnie odwołuje się do pobocznej czcionki Latin. Inicjalizuje schemat czcionek slajdu poprzez [IOverrideTheme.InitFontSchemeFromInherited](https://reference.aspose.com/slides/net/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) i ustawia rodziny czcionek głównej i pobocznej Latin na `Arial` i `Calibri`, co sprawia, że wynik jest odtwarzalny bez pliku wejściowego.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var theme = slide.ThemeManager.OverrideTheme;
theme.InitFontSchemeFromInherited();
theme.FontScheme.Major.LatinFont = new FontData("Arial");
theme.FontScheme.Minor.LatinFont = new FontData("Calibri");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Text using the minor theme font";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LatinFont = new FontData("+mn-lt");

var font = portion.PortionFormat.LatinFont;
var effectiveTheme = slide.CreateThemeEffective();
Console.WriteLine($"{font.FontName} -> {font.GetFontName(effectiveTheme)}");

var explicitFont = new FontData("Verdana");
Console.WriteLine($"{explicitFont.FontName} -> {explicitFont.GetFontName(effectiveTheme)}");
```

Wynik to `+mn‑lt -> Calibri` po którym następuje `Verdana -> Verdana`. Przechowywane odwołanie pozostaje niezmienione, podczas gdy jawna nazwa rodziny jest zwracana bez zmian. Gdyby fragment używał `+mj‑lt`, zostałby rozwiązany do `Arial` w tym motywie.

Rozwiązywanie odwołania do motywu identyfikuje rodzinę czcionki określoną przez motyw. Nie sprawdza dostępności czcionki ani nie określa, który plik czcionki zostanie ostatecznie użyty po podstawieniu lub fallbacku podczas renderowania. Zobacz [Sekwencję wyboru czcionki](/slides/pl/net/font-selection-sequence/) oraz [Podstawianie czcionek](/slides/pl/net/font-substitution/) w odniesieniu do tych odrębnych kroków.

## **Kopiowanie lub zastosowanie motywu**

Poniższe przepływy rozwiązują różne problemy związane z motywami.

### **Zastosuj zewnętrzny motyw do slajdów zależnych od mastera**

Użyj [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/), gdy masz plik motywu PowerPoint (`.thmx`) i chcesz ponownie wystylizować każdy slajd zależny od konkretnego mastera. Wybierz master z kolekcji [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/), która implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/), i przekaż ścieżkę do pliku motywu metodzie.

Metoda wykonuje następujące operacje:

1. Tworzy nowy slajd master na podstawie wybranego mastera.
2. Zastosowuje zewnętrzny motyw do nowego mastera.
3. Przypisuje nowego mastera wszystkim slajdom, które wcześniej zależały od wybranego mastera.
4. Zwraca nowo utworzony [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/).

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

Nieprawidłowy, uszkodzony lub nieobsługiwany motyw może spowodować wyrzucenie [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) lub jednej z jego podklas związanych z formatem. Waliduj ścieżki podane przez użytkowników, obsługuj błędy dostępu do systemu plików i zapisuj prezentację dopiero po pomyślnym zastosowaniu motywu.

Tylko slajdy zależne od wybranego mastera są ponownie przypisywane. Slajdy powiązane z innymi masterami zachowują swoje dotychczasowe mastery i motywy. Kolory, czcionki, wypełnienia, linie, tła i efekty świadome motywu są rozwiązywane względem zewnętrznego motywu. Bezpośrednio przypisane kolory, czcionki, wypełnienia i inne jawne formatowanie mogą pozostać niezmienione. Nadpisania na poziomie układu i slajdu mogą również mieć pierwszeństwo przed wartościami odziedziczonymi z nowego mastera.

Motyw może odwoływać się do czcionek, które nie są dostępne w środowisku uruchomieniowym. Dla spójnego renderowania i eksportu zainstaluj wymagane czcionki, udostępnij je za pomocą [niestandardowych źródeł czcionek](/slides/pl/net/custom-font/), lub skonfiguruj [podstawianie czcionek](/slides/pl/net/font-substitution/).

To jest bezpośredni przepływ na poziomie mastera: metoda przyjmuje ścieżkę do pliku `.thmx` i nie wymaga ręcznego tworzenia nadpisań motywu na poziomie slajdu lub układu.

### **Zastosuj różne zewnętrzne motywy w prezentacji wielomastrowej**

Gdy odpowiedni master nie jest znany z góry, pobierz go z reprezentatywnego slajdu przy użyciu [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) i [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/masterslide/). Przechowaj oryginalne odniesienia do masterów przed zastosowaniem jakichkolwiek motywów, ponieważ każde wywołanie tworzy kolejny master w prezentacji.

Poniższy przykład używa slajdów z dwóch sekcji, aby zlokalizować ich mastery i stosuje inny zewnętrzny motyw do każdej grupy:

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

Pierwsze wywołanie wpływa tylko na slajdy zależne od `firstGroupMaster`, a drugie wywołanie wpływa tylko na slajdy zależne od `secondGroupMaster`. Slajdy należące do innych masterów nie są ponownie stylizowane.

### **Zachowaj źródłowy motyw przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego oryginalny projekt, sklonuj źródłowy master do docelowej prezentacji przy użyciu [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/), a następnie sklonuj slajd przy użyciu [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) i sklonowanego mastera. Dzięki temu master, jego układy i powiązany motyw zostaną przeniesione razem.

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

Jest to preferowany przepływ, gdy źródłowy slajd musi wyglądać tak samo w miejscu docelowym. Proste klonowanie treści na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane przez motyw.

### **Zastosuj wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd musi pozostać na bieżącym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu na podstawie źródłowego motywu. Metody [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initfontschemefrom/) i [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initformatschemefrom/) kopiują trzy główne komponenty motywu do nadpisania.

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

Ta zmiana wpływa na motyw używany przez ten slajd, nie zmieniając motywu dziedziczonego przez pozostałe slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości odziedziczonych, wywołaj [OverrideTheme.Clear](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/clear/).

### **Zastosuj nadpisanie motywu do układu**

Nadpisanie na poziomie układu ma zastosowanie do slajdów używających tego układu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacyjne mogą być użyte poprzez [LayoutSlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/layoutslidethememanager/):

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

Używaj motywu na poziomie mastera lub prezentacji, gdy wiele układów i slajdów powinno współdzielić ten sam podstawowy projekt, nadpisania układu, gdy jedna rodzina układów wymaga innego stylu, oraz nadpisania slajdu tylko dla rzeczywistych wyjątków. Nadmierne nadpisania na poziomie slajdu utrudniają późniejsze globalne zmiany motywu.

## **Aktualizacja stylów tła motywu**

Wypełnienia tła motywu są przechowywane w [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint może w interfejsie prezentować więcej opcji tła niż liczba definicji wypełnień fizycznie zapisanych w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odwołaniami do stylów.

![Galeria stylów tła w PowerPoint dla motywu prezentacji](presentation-design_8.png)

Przed użyciem stylu tła sprawdź przechowywaną kolekcję i bieżącą [Background.StyleIndex](https://reference.aspose.com/slides/net/aspose.slides/background/styleindex/). `StyleIndex` używa `0` dla braku stylowanego wypełnienia; dodatnie wartości są odwołaniami do stylów tła motywu. To różni się od indeksowania kolekcji .NET, gdzie `[0]` oznacza pierwszy zapisany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnień tła.

Poniższy przykład raportuje liczbę dostępnych wypełnień tła, przypisuje odwołanie do stylowanego tła motywu pierwszemu masterowi i zapisuje prezentację:

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

Widoczny rezultat zależy od wpisu motywu odwoływanego przez master oraz od ewentualnych nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana samego tła mastera może nie wpłynąć na ten slajd. Użyj [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/), gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Warning" %}}
Nie traktuj `StyleIndex` jako indeks kolekcji zerowy. Unikaj także twardego kodowania numeru stylu z jednego pliku i zakładania, że będzie miał ten sam wygląd w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Dla bezpośredniego formatowania tła i dziedziczenia tła zobacz [Tło prezentacji](/slides/pl/net/presentation-background/).
{{% /alert %}}

## **Aktualizacja efektów motywu**

Schemat formatu motywu zawiera oddzielne kolekcje [FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles/) i [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles/). Typowe motywy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien sprawdzać każdą kolekcję zamiast zakładać stałą liczbę.

![Subtelne, umiarkowane i intensywne efekty motywu zastosowane do tego samego kształtu](presentation-design_10.png)

Kiedy uzyskujesz dostęp do tych kolekcji w C#, indeks kolekcji jest zerowy: `[0]` to pierwszy zapisany styl, a `[2]` to trzeci. Indeksy odwołań stylu w kształcie to odrębny koncept, udostępniany przez [IShapeStyle](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/). Modyfikacja stylu motywu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

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

Dla kształtów odwołujących się do tych slotów, pierwszy styl linii motywu staje się czerwony, trzeci styl wypełnienia motywu staje się jednolitą zielenią lasu, a trzeci styl efektu zyskuje zewnętrzny cień z odległością 10 punktów. Ostateczny wygląd nadal zależy od tego, które sloty stylu każdy kształt odwołuje oraz czy bezpośrednie formatowanie nadpisuje motyw.

![Style efektów motywu po zmianie linii, wypełnienia i ustawień cienia](presentation-design_11.png)

## **Wybór stylów wypełnienia i linii motywu dla kształtu**

Kształt może wybierać wypełnienie i obrys niezależnie za pomocą [FillStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/fillstyleindex/) oraz [LineStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/linestyleindex/). Dla obu właściwości indeks `1` wybiera pierwszy wpis w odpowiedniej kolekcji motywu (`FillStyles[0]` lub `LineStyles[0]`), a indeks `2` wybiera drugi wpis.

Poniższy przykład tworzy dwa style wypełnienia (złoty i niebieski nieba) oraz dwa style linii (ciemny niebieski 6 pt i ciemny czerwony 12 pt) w domyślnym motywie nowej prezentacji. Zapisuje slajd w trzech etapach, aby można było porównać wyniki w PowerPoint.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var styles = presentation.MasterTheme.FormatScheme;

var goldFill = styles.FillStyles[0];
goldFill.FillType = FillType.Solid;
goldFill.SolidFillColor.Color = Color.Gold;
var blueFill = styles.FillStyles[1];
blueFill.FillType = FillType.Solid;
blueFill.SolidFillColor.Color = Color.SkyBlue;

var thinLine = styles.LineStyles[0];
thinLine.FillFormat.FillType = FillType.Solid;
thinLine.FillFormat.SolidFillColor.Color = Color.DarkBlue;
thinLine.Width = 6;
var thickLine = styles.LineStyles[1];
thickLine.FillFormat.FillType = FillType.Solid;
thickLine.FillFormat.SolidFillColor.Color = Color.DarkRed;
thickLine.Width = 12;

var shapes = presentation.Slides[0].Shapes;
var left = shapes.AddAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
var right = shapes.AddAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
left.ShapeStyle.FillStyleIndex = 1;
right.ShapeStyle.FillStyleIndex = 2;
left.ShapeStyle.LineStyleIndex = 1;
right.ShapeStyle.LineStyleIndex = 1;
presentation.Save("01-initial.pptx", SaveFormat.Pptx);

right.ShapeStyle.LineStyleIndex = 2;
presentation.Save("02-line-changed.pptx", SaveFormat.Pptx);

goldFill.SolidFillColor.Color = Color.SeaGreen;
presentation.Save("03-theme-changed.pptx", SaveFormat.Pptx);
```

| Style początkowe | Zmiana prawego obrysu | Edycja pierwszego wypełnienia motywu |
|:---:|:---:|:---:|
| ![Złote i niebieskie niebo prostokąty z dopasowanymi cienkimi ciemno‑niebieskimi obrysami](theme-style-initial.png) | ![Prostokąt niebieski nieba ma teraz grubą ciemno‑czerwoną obwódkę](theme-style-line-changed.png) | ![Lewy prostokąt jest teraz zielony, a oba obrysy pozostają niezmienione](theme-style-fill-changed.png) |

Wybór innego stylu linii zmienia tylko obrys prawego prostokąta. Edycja pierwszego wypełnienia motywu aktualizuje każdy kształt, który go używa. W tym przypadku tylko lewy prostokąt staje się zielony.

Na istniejącym kształcie lokalny kolor wypełnienia, kolor linii lub grubość linii mogą nadpisać tę część stylu motywu. Jeśli zmiana indeksu stylu nie daje widocznego efektu, sprawdź [bezpośrednie formatowanie](/slides/pl/net/shape-formatting/).

## **Określenie, czy skuteczne wypełnienie stałe używa koloru motywu**

Wypełnienie może być zapisane bezpośrednio na obiekcie lub odziedziczone z akapitu, układu, mastera, stylu motywu lub innego poziomu formatowania. Wywołaj [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), aby rozwiązać tę hierarchię w niezmienny [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/). Najpierw sprawdź [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/). Tylko gdy jest `FillType.Solid`, powinieneś odczytać właściwości wypełnienia stałego.

Dla wypełnienia stałego, [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) zwraca ostateczną wartość RGB po zastosowaniu dziedziczenia, wyszukiwania w motywie i przekształceń kolorów. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) zwraca odpowiadający logiczny slot [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/), np. `Text1` lub `Accent6`. Wartość `SchemeColor.NotDefined` oznacza, że skuteczne wypełnienie stałe nie opiera się na kolorze schematu. W przepływie, w którym wypełnienia są albo kolorami motywu, albo bezpośrednimi kolorami RGB, ta wartość identyfikuje wypełnienie RGB.

Nie używaj samej lokalnej wartości [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) do klasyfikacji wypełnienia. Na przykład fragment tekstu może nie mieć lokalnie zdefiniowanego koloru schematu, więc jego lokalna wartość to `NotDefined`, podczas gdy jego skuteczne wypełnienie dziedziczy kolor motywu i rozwiązuje się do `Text1` lub `Accent6`. Natomiast `SolidFillSchemeColor` mówi, który logiczny slot motywu wygenerował skuteczny kolor, ale nie informuje, czy ten slot pochodzi z obiektu, akapitu, układu, mastera czy innego poziomu hierarchii formatowania.

Poniższy przykład ładuje prezentację, audytuje zarówno wypełnienia kształtów, jak i wypełnienia fragmentów tekstu, wypisuje każdy ostateczny RGB i powiązany kolor schematu oraz oznacza wypełnienia stałe, które nie będą śledzić zmian kolorów motywu:

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

Gałąź `NotDefined` dostarcza listę wypełnień stałych, które nie będą reagować na zmiany w slotach kolorów motywu. Przejrzyj te obiekty, gdy prezentacja musi podążać za nową paletą marki. Zgłoszona wartość RGB nadal pokazuje aktualny wygląd, a wartość schematu wyjaśnia, czy ten wygląd jest połączony z motywem.

Obiekty skutecznego formatu są migawkami. Po zmianie motywu prezentacji, nadpisaniu motywu lub jakiegokolwiek formatowania dziedziczonego, wywołaj ponownie `GetEffective` i odczytaj nowy obiekt `IFillFormatEffectiveData` przed porównaniem lub raportowaniem kolorów.

## **Odczyt skutecznych wartości motywu**

Surowe obiekty motywu mówią, co jest zdefiniowane na danym poziomie. Skuteczne wartości mówią, co slajd lub kształt rzeczywiście używa po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Dla tła użyj [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/), a dla wypełnienia [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/).

Poniższy przykład odczytuje skuteczny motyw, tło i pierwsze wypełnienie kształtu ze slajdu:

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

Używaj danych skutecznych do diagnostyki renderowania, walidacji i porównań. Jeśli sprawdzasz tylko [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/), możesz przeoczyć nadpisanie mastera, układu, slajdu lub kształtu, które zmienia ostateczny wygląd.

## **FAQ**

**Czy zastosowanie zewnętrznego motywu wpływa na każdy slajd w prezentacji?**

Nie. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) przepisuje tylko slajdy zależne od wybranego mastera. Slajdy używające innych masterów zachowują dotychczasowe motywy.

**Czy mogę zastosować motyw do jednego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) slajdu i zainicjalizuj jego nadpisanie motywu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal będą dziedziczyć swoje dotychczasowe motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Podczas przenoszenia slajdu i zachowywania jego pierwotnego wyglądu, sklonuj źródłowy master do docelowej prezentacji oraz sklonuj slajd z tym masterem przy użyciu [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) i [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/). To zachowuje master, układy i motyw razem.

**Jak mogę zobaczyć skuteczne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) dla slajdu lub układu oraz odpowiednich metod zwracających dane skuteczne dla obiektów formatowania, takich jak [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) i [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/). Te API zwracają rozwiązywane wartości po zastosowaniu dziedziczenia i nadpisań.