---
title: Prezentáció szövegének formázása .NET-ben
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/net/text-formatting/
keywords:
- szöveg kiemelése
- reguláris kifejezés
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karaktertávolság
- betűtulajdonságok
- betűcsalád
- szöveg forgatás
- forgatási szög
- szövegdoboz
- sorköz
- automatikus illeszkedés tulajdonság
- szövegdoboz rögzítés
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET használatával. Testreszabhatja a betűtípusokat, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet szöveget formázni PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET használatával. Kitér a kiemelésre, háttérszínekre, átlátszóságra, karaktertávolságra, betűtulajdonságokra, forgatásra, bekezdéstávolságra, automatikus illeszkedésre, szöveg rögzítésére, tabulátor beállításokra és nyelvi beállításokra.

Az alábbi példákban egy „sample.pptx” nevű fájlt használunk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **Szöveg kiemelése**

Használja az [ITextFrame.HighlightText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/highlighttext/) metódust, amikor egy szövegrétegen belül egy adott minta alapján kell szöveget kiemelni. A metódus kiemelő színt alkalmaz a megfelelő szövegrészekre, és használható a [TextSearchOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/) segítségével a keresés módjának szabályozására, például csak teljes szavak egyezésére.

Az alábbi kódrészlet minden **"try"** karakter előfordulást kiemeli, majd csak a teljes **"to"** szót emeli ki.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Szerezze meg az első alakzatot az első diáról.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Emelje ki a "try" szót az alakzaton.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Emelje ki a "to" szót az alakzaton.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A kiemelt szöveg](highlighted_text.png)

## **Szöveg kiemelése reguláris kifejezésekkel**

Az [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/highlightregex/) metódus a reguláris kifejezéssel megtalált szöveg egyezéseket emeli ki. .NET-ben ez az API a [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) felületén érhető el.

Az alábbi kódrészlet minden **hét vagy több karaktert** tartalmazó szót kiemeli:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // Emelje ki az összes olyan szót, amely legalább hét karakterből áll.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A reguláris kifejezéssel kiemelt szöveg](highlighted_text_using_regex.png)

## **Szöveg háttérszínének beállítása**

Használja az [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/defaultportionformat/) metódust a bekezdés alapértelmezett kiemelő színének beállításához, vagy az [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformat/highlightcolor/) metódust az egyes szövegrészekhez.

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín a **teljes bekezdés** számára:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Állítsa be a kiemelés színét a teljes bekezdésre.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűtípussal rendelkező szövegrészek** számára:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Állítsa be a kiemelés színét a szövegrészhez.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja az [IParagraphFormat.Alignment](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/alignment/) tulajdonságot a bekezdés igazításának beállításához egy szövegrétegen belül. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

Az alábbi kódrészlet bemutatja, hogyan igazítható a bekezdés **középre**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Állítsa be a bekezdés igazítását középre.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![Az igazított bekezdés](aligned_paragraph.png)

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszósága az [IPortionFormat.FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformat/fillformat/) színének alfa komponensével szabályozható. Az alábbi példákban az `alpha = 50` egy 0–255 skálájú ARGB alfa-csatorna érték, nem átlátszósági százalék.

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság a **teljes bekezdésre**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Állítsa be a szöveg kitöltőszínét átlátszó színre.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság **félkövér betűtípussal rendelkező szövegrészek** számára:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Állítsa be a szövegrész átlátszóságát.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![Az átlátszó szövegrészek](transparent_text_portions.png)

## **Karaktertávolság beállítása a szövegben**

Használja az [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/spacing/) tulajdonságot a karakterek közötti távolság növelésére vagy csökkentésére egy szövegdobozban.

Az alábbi C# kód bemutatja, hogyan növelhető a karaktertávolság a **teljes bekezdésben**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Megjegyzés: Negatív értékek használata a karaktertávolság összenyomásához.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // A karaktertávolság növelése.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A karaktertávolság a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan növelhető a karaktertávolság **félkövér betűtípussal rendelkező szövegrészek** esetén:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Megjegyzés: Negatív értékek használata a karaktertávolság összenyomásához.
            portion.PortionFormat.Spacing = 3;  // A karaktertávolság növelése.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A karaktertávolság a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása adott betűtípusoknál**

Néhány esetben az Aspose.Slides által renderelt szöveg kicsit szorosabbnak tűnhet, mint a PowerPoint-ban megjelenő ugyanaz a szöveg. Ez azért fordulhat elő, mert a PowerPoint egyes betűtípusoknál figyelmen kívül hagyhatja a kerning adatokat, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban a kerning engedélyezve van.

A renderelt kimenet PowerPoint-hoz való közelebb hozása érdekében ilyen esetekben letilthatja a kerninget azoknál a szövegrészeknél, amelyek az érintett betűtípust használják. Állítsa be az [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/kerningminimalsize/) értékét sokkal nagyobbra, mint a tényleges betűméret:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Ez a beállítás megakadályozza a kerning alkalmazását a megfelelő szövegrészekre, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális kimenetéhez igazításában az érintett betűtípusok esetén.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten az [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/defaultportionformat/) segítségével, vagy egyes részekre az [IPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformat/) segítségével.

Az alábbi kód beállítja a betűtípust és a szövegstílust a **teljes bekezdés** számára: betűméretet, félkövér, dőlt, pontozott aláhúzást és a Times New Roman betűtípust alkalmaz minden résznél a bekezdésben.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Állítsa be a bekezdés betűtulajdonságait.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A betűtulajdonságok a bekezdéshez](font_properties_for_paragraph.png)

Az alábbi kódrészlet hasonló tulajdonságokat alkalmaz **félkövér betűtípussal rendelkező szövegrészek** esetén:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Állítsa be a szövegrész betűtulajdonságait.
            portion.PortionFormat.FontHeight = 13;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
            portion.PortionFormat.LatinFont = new FontData("Times New Roman");
        }
    }

    presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A betűtulajdonságok a szövegrészekhez](font_properties_for_text_portions.png)

## **Szöveg forgatásának beállítása**

Használja az [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/textverticaltype/) metódust egy előre definiált szövegorientáció beállításához egy alakzatban.

Az alábbi kódrészlet a szöveg orientációt `Vertical270`-re állítja az alakzatban, ami a szöveget **90 fokkal óramutató járásával ellentétesen** forgat:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A szöveg forgatása](text_rotation.png)

## **Egyéni forgatás beállítása szövegdobozokhoz**

Használja az [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/rotationangle/) metódust egy egyéni forgatási szög beállításához egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) esetén.

Az alábbi kódrészlet a szövegdobozt 3 fokkal az óramutató járásával megegyező irányban forgatja az alakzatban:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![Az egyéni szöveg forgatás](custom_text_rotation.png)

## **Bekezdés sorok közti távolság beállítása**

Az Aspose.Slides biztosítja az [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/spacebefore/) és [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/spacewithin/) tulajdonságokat a bekezdés távolságának szabályozásához. Ezeket a következőképpen használják:

* Pozitív érték használata a sorköz meghatározásához a sor magasságának százalékában.  
* Negatív érték használata a sorköz meghatározásához pontokban.  

Az alábbi kódrészlet bemutatja, hogyan adható meg a sorköz a bekezdésen belül:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A sorköz a bekezdésen belül](line_spacing.png)

## **Automatikus illeszkedés típusának beállítása szövegdobozokhoz**

Az [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/autofittype/) meghatározza, hogyan viselkedik a szöveg, ha meghaladja a tároló határait. Használja annak szabályozására, hogy a szöveg zsugorodjon, túlcsorduljon vagy a forma automatikusan átméreteződjön.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Szövegdobozok rögzítésének beállítása**

Az [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/anchoringtype/) meghatározza, hogyan helyezkedik el a szöveg függőlegesen egy alakzatban, például a tetején, közepén vagy alján.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Szöveg tabulációjának beállítása**

Használja az [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/defaulttabsize/) és az [IParagraphFormat.Tabs](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/tabs/) tulajdonságokat a tabulátorok beállításához egy bekezdésben.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A bekezdés tabulátorai](paragraph_tabs.png)

## **Ellenőrző nyelv beállítása**

Az Aspose.Slides biztosítja az [IPortionFormat.LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformat/languageid/) tulajdonságot, amely lehetővé teszi a szövegrész ellenőrző nyelvének beállítását. Az ellenőrző nyelv határozza meg a helyesírás- és nyelvtani ellenőrzéshez használt nyelvet a PowerPointban.

Az alábbi kódrészlet bemutatja, hogyan állítható be egy szövegrész ellenőrző nyelve:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // Állítsa be a helyesírási nyelv azonosítóját.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/defaulttextlanguage/) beállítást a prezentáció betöltése vagy létrehozása során létrehozott szöveg alapértelmezett nyelvének meghatározásához.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Adjunk hozzá egy új téglalap alakzatot szöveggel.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Ellenőrizze az első szövegrész nyelvét.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás alkalmazásához a prezentáció szintjén, használja az [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/defaulttextstyle/) elemet.

Az alábbi kódrészlet bemutatja, hogyan állítható be egy alapértelmezett félkövér betűtípus 14 pt mérettel az összes dián lévő szöveghez egy új prezentációban.

```cs
using (var presentation = new Presentation())
{
    // Szerezze meg a felső szintű bekezdésformátumot.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Szöveg kinyerése a Nagybetűs hatással**

A PowerPointban az **All Caps** betűhatás alkalmazása a szöveget nagybetűs megjelenésűvé teszi a dián, még akkor is, ha eredetileg kisbetűkkel lett beírt. Amikor az Aspose.Slides-szel egy ilyen szövegrészt lekér, a könyvtár a szöveget pontosan úgy adja vissza, ahogy be lett írva. A megjelenő szöveghez igazodva ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/net/aspose.slides/textcaptype/) értékét, és konvertálja a visszakapott karakterláncot nagybetűsre, ha az érték `All`.

Tegyük fel, hogy a sample2.pptx fájl első diáján a következő szövegdoboz van.

![A Nagybetűs hatás](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan nyerhető ki a szöveg a **All Caps** hatással:

```cs
using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

Kimenet:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **GYIK**

**Hogyan módosítható a szöveg egy dián található táblázatban?**

A dián található táblázat szövegének módosításához használja a [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) elemet. Iteráljon a cellákon, és frissítse minden cellát a [ICell.TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/icell/textframe/) és a bekezdés formázást az [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/paragraphformat/) segítségével.

**Hogyan alkalmazhatók színátmenetek a szövegre egy PowerPoint dián?**

A szövegre színátmenet alkalmazásához használja az [IPortionFormat.FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformat/fillformat/) elemet. Állítsa a [IFillFormat.FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/ifillformat/filltype/) értékét a [FillType.Gradient](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) típusra, és konfigurálja a színátmenet állomásait, irányát és átlátszóságát.