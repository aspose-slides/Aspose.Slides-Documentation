---
title: Prezentáció szövegének formázása .NET-ben
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/net/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karakter távolság
- betűtulajdonságok
- betűtípus család
- szöveg forgatás
- forgatási szög
- szövegdoboz
- sortávolság
- automatikus illesztés tulajdonság
- szövegdoboz rögzítés
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET használatával. Testreszabhatja a betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet formázni a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET segítségével. Kitér a háttérszínekre, átlátszóságra, karaktertávolságra, betűtulajdonságokra, forgatásra, bekezdés távolságokra, automatikus illesztés viselkedésére, szöveg rögzítésére, tabulátorokra és nyelvi beállításokra.

Az alábbi példákban a „sample.pptx” nevű fájlt használjuk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Példa szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés egyezések megtalálásához és kiemeléséhez lásd a [Szöveg keresése és cseréje](/slides/hu/net/search-and-replace-text/) oldalt.

## **Szöveg háttérszín beállítása**

Használja a [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/defaultportionformat/) metódust a bekezdés alapértelmezett kiemelési színének beállításához, vagy az [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/highlightcolor/) metódust az egyes szövegrészekhez.

Az alábbi kódrészlet bemutatja, hogyan állítható be a **teljes bekezdés** háttérszíne:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Állítsa be a teljes bekezdés kiemelési színét.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a **félkövér betűkkel rendelkező szövegrészek** háttérszíne:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Állítsa be a szövegrész kiemelési színét.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja a [IParagraphFormat.Alignment](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/alignment/) metódust a bekezdés igazításának beállításához egy szövegdobozon belül. Az érték lehet középre, balra, jobbra, sorkizárt stb.

Az alábbi kódrészlet bemutatja, hogyan igazítható a bekezdés **középre**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

A szöveg átlátszóságát az [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/fillformat/) színének alfa komponensével szabályozhatja. Az alábbi példákban az `alpha = 50` egy ARGB alfa csatorna érték a 0–255 skálán, nem átlátszósági százalék.

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság a **teljes bekezdés** esetén:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság a **félkövér betűkkel rendelkező szövegrészek** esetén:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Karakter távolság beállítása a szövegben**

Használja az [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/spacing/) metódust a karakterek közötti távolság növelésére vagy csökkentésére egy szövegdobozban.

Az alábbi C# kód bemutatja, hogyan növelhető a karakter távolság a **teljes bekezdés** esetén:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Megjegyzés: Negatív értékek használata a karaktertávolság csökkentéséhez.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Karaktertávolság növelése.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A karaktertávolság a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan növelhető a karaktertávolság a **félkövér betűkkel rendelkező szövegrészek** esetén:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Megjegyzés: Negatív értékek használata a karaktertávolság csökkentéséhez.
            portion.PortionFormat.Spacing = 3;  // Karaktertávolság növelése.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A karaktertávolság a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPointban megjelenő szöveg. Ennek oka lehet, hogy a PowerPoint egyes betűtípusoknál figyelmen kívül hagyja a kerning adatokat, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a kerning engedélyezve van a PowerPoint beállításaiban.

Az ilyen esetekben a renderelt kimenet PowerPoint közelítéséhez letilthatja a kerninget a **érintett betűtípust** használó szövegrészeknél. Állítsa be az [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/kerningminimalsize/) értékét a tényleges betűméretnél jelentősen nagyobbra:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

A betűtulajdonságok beállíthatók a bekezdés szintjén a [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/defaultportionformat/) segítségével, vagy egyes részekre az [IPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformat/) segítségével.

Az alábbi kód beállítja a betűt és a szövegstílust a teljes bekezdéshez: betűméret, félkövér, dőlt, pontozott aláhúzás, valamint a Times New Roman betűt minden részhez a bekezdésben.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

![A betűtulajdonságok a bekezdésben](font_properties_for_paragraph.png)

Az alábbi kódrészlet hasonló tulajdonságokat alkalmaz a **félkövér betűkkel rendelkező szövegrészek** esetén:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Állítsa be a betűtulajdonságokat a szövegrészhez.
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

![A betűtulajdonságok a szövegrészekben](font_properties_for_text_portions.png)

## **Szöveg forgatás beállítása**

Használja a [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/textverticaltype/) metódust egy előre definiált szövegorientáció beállításához egy alakzaton belül.

Az alábbi kódrészlet a szöveg orientációt `Vertical270`-re állítja, ami **90 fokkal balra forgatja** a szöveget:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

Használja a [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/rotationangle/) metódust egy egyéni forgatási szög beállításához egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) számára.

Az alábbi kódrészlet a szövegdobozt 3 fokkal óramutató járásával megegyező irányba forgatja az alakzaton belül:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![Az egyéni szövegfordítás](custom_text_rotation.png)

## **Bekezdés sortávolságának beállítása**

Az Aspose.Slides a [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/spacebefore/) és [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/spacewithin/) segítségével szabályozza a bekezdés távolságait. Ezeket a tulajdonságokat a következőképpen használják:

* Pozitív értékkel a sortávolság a sormagasság százalékában adható meg.
* Negatív értékkel a sortávolság pontban adható meg.

Az alábbi kódrészlet bemutatja, hogyan adható meg a sortávolság a bekezdésen belül:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A sortávolság a bekezdésen belül](line_spacing.png)

## **Automatikus illesztés típusának beállítása szövegdobozokhoz**

Az [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/autofittype/) meghatározza, hogyan viselkedik a szöveg, ha meghaladja a tárolója határait. Ezzel szabályozható, hogy a szöveg zsugorodik, túlfut vagy automatikusan átméretezi az alakzatot.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

A sorok számolásához automatikus sortördelés után és a szöveg vagy alakzat szélességének változásának megtekintéséhez lásd a [Renderelt sorok számlálása](/slides/hu/net/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg túlfut-e a tárolójából.

## **Szövegdobozok rögzítésének beállítása**

Az [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/anchoringtype/) meghatározza, hogyan helyezkedik el függőlegesen a szöveg egy alakzaton belül, például a tetején, közepén vagy alján.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Szöveg tabulációjának beállítása**

Használja az [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/defaulttabsize/) és az [IParagraphFormat.Tabs](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/tabs/) metódusokat a bekezdés tabulátorainak konfigurálásához.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Javítási nyelv beállítása**

Az Aspose.Slides biztosítja az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/languageid/) lehetőségét, amely lehetővé teszi a javítási nyelv beállítását egy szövegrészhez. A javítási nyelv határozza meg, melyik nyelvet használja a helyesírás- és nyelvtan-ellenőrzés a PowerPointban.

Az alábbi kódrészlet bemutatja, hogyan állítható be a javítási nyelv egy szövegrészhez:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

    // Állítsa be a javítási nyelv azonosítóját.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/defaulttextlanguage/) metódust az alapértelmezett nyelv meghatározásához a betöltés vagy létrehozás során létrehozott szövegekhez.

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Új téglalap alakzat hozzáadása szöveggel.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Ellenőrizze az első rész nyelvét.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás alkalmazásához a prezentáció szintjén használja az [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/defaulttextstyle/) metódust.

Az alábbi kódrészlet bemutatja, hogyan állítható be egy alapértelmezett félkövér betű, 14 pt mérettel az összes dián lévő szöveghez egy új prezentációban.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // Lekéri a legfelső szintű bekezdésformátumot.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Szöveg kinyerése a nagybetűs hatással**

A PowerPointban a **All Caps** betűhatás alkalmazása azt eredményezi, hogy a szöveg nagybetűvel jelenik meg a dián, még ha eredetileg kisbetűvel lett beíró. Amikor ilyen szövegrészt kér le az Aspose.Slides, a könyvtár pontosan úgy adja vissza a szöveget, ahogy be lett gépelve. A megjelenített szöveghez való illesztéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/net/aspose.slides/textcaptype/) értékét, és nagybetűssé alakítsa a visszaadott karakterláncot, ha az érték `All`.

Tegyük fel, hogy a sample2.pptx fájl első diáján a következő szövegdoboz található.

![A nagybetűs hatás](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan nyerhető ki a szöveg a **All Caps** hatás alkalmazásával:

```cs
using Aspose.Slides;

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

**Hogyan módosítható a szöveg egy táblázatban a dián?**

A szöveg táblázatban történő módosításához használja a [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) interfészt. Iteráljon a cellákon, és frissítse mindegyik cellát a [ICell.TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/icell/textframe/) és a bekezdés formázását az [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/paragraphformat/) segítségével.

**Hogyan alkalmazhatók színátmenetek a szövegre egy PowerPoint diában?**

A színátmenetes szöveghez használja az [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/fillformat/) metódust. Állítsa be az [IFillFormat.FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/ifillformat/filltype/) értékét a [FillType.Gradient](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) opcióra, és konfigurálja a színátmenet állomásait, irányát és átlátszóságát.