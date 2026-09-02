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
- karakterköz
- betűtulajdonságok
- betűtípuscsalád
- szöveg forgatása
- forgatási szög
- szövegdoboz
- sortávolság
- automatikus illesztés tulajdonság
- szövegdoboz rögzítése
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

Ez a cikk bemutatja, hogyan lehet szöveget formázni PowerPoint és OpenDocument bemutatókban az Aspose.Slides for .NET használatával. Tárgyalja a háttérszíneket, átlátszóságot, karakterek közti távolságot, betűtulajdonságokat, forgatást, bekezdés távolságot, autofit viselkedést, szöveg rögzítését, tabulátorpozíciókat és nyelvi beállításokat.

Az alábbi példákban a "sample.pptx" nevű fájlt használjuk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

A szöveg keresése és cseréje gyakorlati módjairól lásd a [Szöveg keresése és cseréje](/slides/hu/net/search-and-replace-text/).

## **Szöveg háttérszín beállítása**

Használja az [IParagraphFormat.DefaultPortionFormat]... a bekezdés alapértelmezett kiemelési színének beállításához, vagy használja az [IBasePortionFormat.HighlightColor]... egyedi szövegrészekhez.

Az alábbi kódrészlet bemutatja, hogyan lehet beállítani a háttérszínt a **teljes bekezdés** számára: 

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Állítsa be a kiemelés színét a teljes bekezdéshez.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan lehet beállítani a háttérszínt **félkövér betűtípussal rendelkező szövegrészek** számára:

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

Használja az [IParagraphFormat.Alignment]... a bekezdésigazítás beállításához egy szövegdobozon belül. Az érték lehet középre igazított, balra igazított, jobbra igazított, sorkizárt stb.

Az alábbi kódrészlet bemutatja, hogyan lehet a bekezdést **középre** igazítani:

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

A szöveg átlátszóságát az [IBasePortionFormat.FillFormat]... által hozzárendelt szín alfa komponense szabályozza. Az alábbi példákban az `alpha = 50` egy ARGB alfa-csatorna érték a 0–255 skálán, nem átlátszósági százalék.

Az alábbi kódrészlet bemutatja, hogyan lehet átlátszóságot alkalmazni a **teljes bekezdés**re:

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

Az alábbi kódrészlet bemutatja, hogyan lehet átlátszóságot alkalmazni **félkövér betűtípussal rendelkező szövegrészek** esetén:

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

## **Karakterköz beállítása szövegnél**

Használja az [IBasePortionFormat.Spacing]... a karakterek közti távolság növeléséhez vagy szűkítéséhez egy szövegdobozban.

Az alábbi C# kód bemutatja, hogyan lehet növelni a karakterközt a **teljes bekezdés**ben:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Megjegyzés: Negatív értékekkel lehet összenyomni a karakterközt.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Kiterjeszti a karakterközt.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan lehet növelni a karakterközt **félkövér betűtípussal rendelkező szövegrészek** esetén:

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
            // Megjegyzés: Negatív értékekkel lehet összenyomni a karakterközt.
            portion.PortionFormat.Spacing = 3;  // Kiterjeszti a karakterközt.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Körírás letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorúbb lehet, mint a PowerPointban megjelenő ugyanaz a szöveg. Ez akkor fordulhat elő, ha a PowerPoint figyelmen kívül hagyja a körírásadatokat bizonyos betűtípusoknál, még akkor is, ha a betűtípusban érvényes körírási információk vannak, és a körírás be van kapcsolva a PowerPoint beállításaiban.

Az ilyen esetekben, hogy a renderelt kimenet közelebb legyen a PowerPoint-hoz, letilthatja a körírást azoknál a szövegrészeknél, amelyek az érintett betűtípust használják. Állítsa be az [IBasePortionFormat.KerningMinimalSize]... értékét jóval nagyobbra, mint a tényleges betűméret:

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

Ez a beállítás megakadályozza a körírás alkalmazását a megfelelő szövegrészekre, és segíthet az Aspose.Slides renderelését a PowerPoint vizuális kimenetéhez igazítani az ilyen PowerPoint-specifikus viselkedés által érintett betűtípusok esetén.

## **Szöveg betűtulajdonságok kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten az [IParagraphFormat.DefaultPortionFormat]... vagy egyedi részeknél az [IPortionFormat]... segítségével.

Az alábbi kód beállítja a betűtípust és a szövegstílust a teljes bekezdésre: alkalmazza a betűméretet, félkövér, dőlt, pontozott aláhúzást, és a Times New Roman betűtípust a bekezdés minden részére.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Állítsa be a betűtulajdonságokat a bekezdéshez.
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

![A betűtulajdonságok a szövegrészekhez](font_properties_for_text_portions.png)

## **Szöveg forgatása**

Használja az [ITextFrameFormat.TextVerticalType]... egy előre meghatározott szövegorientáció beállításához egy alakzaton belül.

Az alábbi kódrészlet a szövegorientációt az alakzatban `Vertical270`-re állítja, amely **90 fokkal óramutató járásával ellentétesen** forgatja a szöveget:

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

Használja az [ITextFrameFormat.RotationAngle]... egy egyéni forgatási szög beállításához egy [ITextFrame]... esetén.

Az alábbi kódrészlet 3 fokkal óramutató járásával megegyező irányban forgatja a szövegdobozt az alakzatban: 

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

![Az egyéni szövegforgatás](custom_text_rotation.png)

## **Bekezdés sortávolság beállítása**

Az Aspose.Slides biztosítja az [IParagraphFormat.SpaceAfter]..., az [IParagraphFormat.SpaceBefore]... és az [IParagraphFormat.SpaceWithin]... tulajdonságokat a bekezdés távolságának szabályozásához. Ezeket a tulajdonságokat a következőképpen használják:

* Pozitív értéket használjon a sortávolság a sormagasság százalékában való megadásához.
* Negatív értéket használjon a sortávolság pontokban való megadásához.

Az alábbi kódrészlet bemutatja, hogyan lehet megadni a sortávolságot a bekezdésen belül:

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

![A sortávolság a bekezdésben](line_spacing.png)

## **Automatikus illesztés típusának beállítása szövegdobozokhoz**

Az [ITextFrameFormat.AutofitType]... meghatározza, hogy a szöveg hogyan viselkedik, ha meghaladja a tároló határait. Ennek segítségével szabályozható, hogy a szöveg zsugorodjon, kifolyjon, vagy a forma mérete automatikusan változzon.

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

## **Szövegdoboz rögzítésének beállítása**

Az [ITextFrameFormat.AnchoringType]... meghatározza, hogy a szöveget hogyan helyezi el függőlegesen egy alakzatban, például felül, középen vagy alul.

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

## **Szöveg tabuláció beállítása**

Használja az [IParagraphFormat.DefaultTabSize]... és az [IParagraphFormat.Tabs]... a bekezdés tabulátorpozícióinak beállításához.

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

![A bekezdés tabulátorjai](paragraph_tabs.png)

## **Helyesírási nyelv beállítása**

Az Aspose.Slides biztosítja a [IBasePortionFormat.LanguageId]... lehetőséget, amely lehetővé teszi a helyesírási nyelv beállítását egy szövegrészhez. A helyesírási nyelv határozza meg a PowerPointban a helyesírás- és nyelvtan-ellenőrzéshez használt nyelvet.

Az alábbi kódrészlet bemutatja, hogyan lehet beállítani a helyesírási nyelvet egy szövegrészhez:

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

    // Állítsa be a helyesírási nyelv azonosítóját.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.DefaultTextLanguage]... a prezentáció betöltése vagy létrehozása során létrehozott szöveg alapértelmezett nyelvének meghatározásához.

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Új téglalap alakzat szöveggel.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Ellenőrizze az első rész nyelvét.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás prezentáció szintű alkalmazásához használja az [IPresentation.DefaultTextStyle]... .

Az alábbi kódrészlet bemutatja, hogyan lehet beállítani egy alapértelmezett félkövér betűtípust 14 pt mérettel minden szöveghez a diákon egy új prezentációban.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // A felső szintű bekezdésformátum lekérése.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Szöveg kinyerése nagybetűs hatással**

PowerPointban az **All Caps** betűhatás alkalmazása a szöveget nagybetűvel jeleníti meg a dián, még akkor is, ha eredetileg kisbetűvel írták. Amikor az Aspose.Slides-szel egy ilyen szövegrészt lekér, a könyvtár a szöveget pontosan úgy adja vissza, ahogy be lett gépelve. A megjelenített szöveghez való illesztéshez ellenőrizze a [TextCapType]... értékét, és konvertálja a visszakapott karakterláncot nagybetűssé, ha az érték `All`.

Tegyük fel, hogy a sample2.pptx fájl első diáján a következő szövegdoboz van.

![A nagybetűs hatás](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan lehet kinyerni a szöveget, amikor a **All Caps** hatás alkalmazva van:

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

**Hogyan lehet módosítani a szöveget egy táblában egy dián?**

A szöveg módosításához egy táblában egy dián használja az [ITable]... iteráljon a cellákon, és frissítse minden cellát az [ICell.TextFrame]... és a bekezdésformázást az [IParagraph.ParagraphFormat]... segítségével.

**Hogyan lehet színátmenetes színt alkalmazni szövegre egy PowerPoint dián?**

A színátmenet alkalmazásához szövegre használja a [IBasePortionFormat.FillFormat]... Állítsa be az [IFillFormat.FillType]... értékét [FillType.Gradient]... és konfigurálja a színátmenet állomásait, irányát és átlátszóságát.