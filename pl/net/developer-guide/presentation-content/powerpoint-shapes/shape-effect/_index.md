---
title: Zastosowanie efektów kształtów w prezentacjach w .NET
linktitle: Efekt kształtu
type: docs
weight: 30
url: /pl/net/shape-effect/
keywords:
- efekt kształtu
- efekt cienia
- efekt odbicia
- efekt poświaty
- efekt miękkich krawędzi
- format efektu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przekształć pliki PPT i PPTX za pomocą zaawansowanych efektów kształtów przy użyciu Aspose.Slides dla .NET — twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wprowadzenie**

Podczas gdy efekty w PowerPoint mogą być używane do wyróżnienia kształtu, różnią się od [wypełnień](/slides/pl/net/shape-formatting/#gradient-fill) lub obrysów. Korzystając z efektów PowerPoint, możesz tworzyć przekonujące odbicia na kształcie, rozpraszać poświatę kształtu itp.

![Efekt kształtu](shape-effect.png)

PowerPoint udostępnia sześć efektów, które można zastosować do kształtów. Możesz zastosować jeden lub więcej efektów do kształtu.

Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu PowerPoint posiada opcje pod **Preset**. Opcje Preset to zasadniczo znana, dobrze wyglądająca kombinacja dwóch lub więcej efektów. Dzięki temu, wybierając preset, nie będziesz musiał tracić czasu na testowanie lub łączenie różnych efektów w poszukiwaniu ładnej kombinacji.

Aspose.Slides udostępnia właściwości i metody w klasie [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/), które pozwalają zastosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosuj efekt cienia**

Aspose.Slides for .NET obsługuje zewnętrzne i wewnętrzne cienie dla kształtów. Możesz dostosować ich kolor, kierunek, odległość i promień rozmycia, aby pasowały do projektu Twojej prezentacji.

### **Zastosuj zewnętrzny cień**

Użyj zewnętrznego cienia, aby karta lub panel wyróżniały się na tle slajdu. Cień rozciąga się poza krawędzie kształtu, tworząc wrażenie, że kształt jest uniesiony nad slajdem. Dostosuj jego kolor, kierunek, odległość i promień rozmycia, aby pasowały do oświetlenia i stylu szablonu.

Ten kod C# pokazuje, jak zastosować [efekt zewnętrznego cienia](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) do prostokąta:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![Efekt cienia](shadow_effect.png)

### **Zastosuj wewnętrzny cień**

Podczas odtwarzania wizualnego stylu szablonu użyj wewnętrznego cienia, aby nadać karcie lub panelowi wklęsły wygląd. Zewnętrzny cień rozciąga się poza kształt i sprawia, że wygląda na podniesiony, podczas gdy wewnętrzny cień przyciemnia wnętrze jego krawędzi.

Wywołaj [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), a następnie skonfiguruj [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Większe wartości dają łagodniejsze krawędzie.

Ten przykład C# tworzy jasno niebieską kartę z ciemnoszarym wewnętrznym cieniem i zapisuje ją jako plik PPTX:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![Niebieski prostokąt z wewnętrznym cieniem](inner_shadow_effect.png)

Aby usunąć wewnętrzny cień, wywołaj [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) na formacie efektu kształtu.

## **Zastosuj efekt odbicia**

Aby zastosować efekt odbicia w Aspose.Slides for .NET, możesz dodać lustrzane odbicie do kształtów, regulując takie parametry jak odległość, przejrzystość i rozmiar. Ten efekt podnosi estetykę prezentacji, nadając kształtom bardziej wyrafinowany i dopracowany wygląd. Jest łatwy do wdrożenia przy użyciu prostego kodu, co umożliwia szybkie zastosowanie go w wielu elementach dla spójnego projektu.

Ten kod C# pokazuje, jak zastosować [efekt odbicia](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) do kształtu:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![Efekt odbicia](reflection_effect.png)

## **Zastosuj efekt poświaty**

Aby zastosować efekt poświaty do kształtu w Aspose.Slides for .NET, możesz dodać miękką, świetlistą aurę wokół kształtów, regulując właściwości takie jak kolor i rozmiar. Ten efekt pomaga wyróżnić kształty i dodaje atrakcyjny, przyciągający wzrok element wizualny do Twojej prezentacji. Jest łatwy do wdrożenia przy minimalnym kodzie, podnosząc ogólny wygląd slajdów.

Ten kod C# pokazuje, jak zastosować [efekt poświaty](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) do kształtu:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Efekt poświaty](glow_effect.png)

## **Zastosuj efekt miękkich krawędzi**

Aby zastosować efekt miękkich krawędzi w Aspose.Slides for .NET, możesz stworzyć płynne, rozmyte przejście wokół krawędzi kształtu. Ten efekt dodaje subtelny i wyrafinowany wygląd, idealny dla projektów wymagających delikatnego, łagodniejszego wyglądu. Możesz łatwo regulować parametry, takie jak promień, aby uzyskać pożądany efekt w różnych kształtach w prezentacji.

Ten kod C# pokazuje, jak zastosować [miękkie krawędzie](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) do kształtu:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Efekt miękkich krawędzi](soft_edges_effect.png)

## **Zastosuj efekt rozmycia**

Użyj rozmycia kształtu, aby zmiękczyć wypełnienie i obrys kształtu, jednocześnie zachowując możliwość edycji kształtu. Wywołaj [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) na formacie efektu kształtu. Promień jest mierzony w punktach (1/72 cala): użyj wartości nieujemnej, przy czym większe wartości dają silniejsze rozmycie. Promień równy zero pozostawia wygląd niezmieniony.

Ustawienie [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) kontroluje widoczne granice efektu. Przy `false` rozmycie jest przycięte do pierwotnych malowanych granic, włącznie z obrysem. Przy `true` rozmycie może wykraczać poza te granice. Żadne z ustawień nie zmienia położenia ani wymiarów kształtu.

Porównanie poniżej używa tych samych wypełnień, obrysów i wymiarów kształtu w całym przykładzie. Górny wiersz używa `grow = false`; dolny wiersz używa `grow = true`.

![Oryginalny prostokąt porównany z promieniami rozmycia 5 i 15 punktów, przy wyłączonym i włączonym Grow](shape_blur_comparison.png)

Ten przykład C# tworzy pomarańczowy prostokąt z ciemnoniebieskim obrysem, stosuje rozmycie o promieniu 5 punktów, a następnie aktualizuje je do rozmycia 15‑punktowego, wywołując ponownie [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/). Zapisuje oba rozmyte stany, potem wywołuje [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) i zapisuje kształt bez rozmycia.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

Rozmycie kształtu wpływa jednocześnie na wypełnienie i obrys. Efekt miękkich krawędzi rozmywa krawędzie kształtu, podczas gdy rozmycie cienia zmiękcza tylko cień. Efekty transformacji obrazu działają na zawartość obrazu; ten przykład stosuje rozmycie bezpośrednio do formatu efektu kształtu, nie przekształcając kształtu w obraz.

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Do jakich kształtów mogę zastosować efekty?**

Efekty można stosować do różnych kształtów, w tym autokształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę zastosować efekty do grupowanych kształtów?**

Tak, możesz zastosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.