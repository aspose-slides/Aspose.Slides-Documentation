---
title: Fejlessze előadásait az AutoFit használatával .NET-ben
linktitle: Autofit beállítások
type: docs
weight: 30
url: /hu/net/manage-autofit-settings/
keywords:
- szövegmező
- autofit
- ne alkalmazzon autofit-et
- szöveg illesztése
- szöveg zsugorítása
- szöveg tördelése
- alakzat átméretezése
- PowerPoint
- prezentáció
- C#
- .NET
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti az AutoFit beállításait az Aspose.Slides for .NET-ben, hogy optimalizálja a szöveg megjelenítését PowerPoint és OpenDocument prezentációiban, és javítsa a tartalom olvashatóságát."
---
## **Bevezetés**

Alapértelmezés szerint, amikor szövegmezőt adsz hozzá, a Microsoft PowerPoint a **Resize shape to fit text** beállítást használja a szövegmezőhöz – automatikusan átméretezi a szövegmezőt, hogy a benne lévő szöveg mindig elférjen benne.

![Szövegmező a PowerPointban](textbox-in-powerpoint.png)

* Ha a szövegmező szövege hosszabbá vagy nagyobbra nő, a PowerPoint automatikusan megnöveli a szövegmezőt – magasságát növelve – hogy több szöveget tudjon tartalmazni.
* Ha a szövegmező szövege rövidebbé vagy kisebbé válik, a PowerPoint automatikusan csökkenti a szövegmezőt – magasságát csökkentve – hogy eltávolítsa a felesleges helyet.

A PowerPointban ezek azok a négy fontos paraméter vagy beállítás, amelyek szabályozzák a szövegmező auto‑fit viselkedését:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Auto‑fit beállítások a PowerPointban](autofit-options-powerpoint.png)

Az Aspose.Slides for .NET hasonló lehetőségeket kínál – a [TextFrameFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat) osztály tulajdonságai – amelyek lehetővé teszik az auto‑fit viselkedés szabályozását a prezentációk szövegmezőiben.

## **Alakzat átméretezése a szöveghez**

Ha azt szeretnéd, hogy a doboz szövege mindig elférjen a dobozban a változtatások után, a **Resize shape to fit text** beállítást kell használnod. Ennek a beállításnak a megadásához állítsd be a `AutofitType` tulajdonságot a [TextFrameFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat) osztályból `Shape` értékre.

![Alakzat átméretezése a szöveghez](alwaysfit-setting-powerpoint.png)

Ez a C# kód bemutatja, hogyan adhatod meg, hogy a szövegnek mindig el kell férnie a dobozában egy PowerPoint prezentációban:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

Ha a szöveg hosszabbá vagy nagyobbá válik, a szövegmező automatikusan átméreteződik (magassága növekszik), hogy minden szöveg elférjen benne. Ha a szöveg rövidebbé válik, a fordított történik.

## **Ne alkalmazzon AutoFit-et**

Ha azt szeretnéd, hogy egy szövegmező vagy alakzat megtartsa méreteit a benne lévő szöveg változásai ellenére, a **Do not Autofit** beállítást kell használnod. Ennek a beállításnak a megadásához állítsd be a `AutofitType` tulajdonságot a [TextFrameFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat) osztályból `None` értékre.

!["Do not Autofit" beállítás a PowerPointban](donotautofit-setting-powerpoint.png)

Ez a C# kód bemutatja, hogyan adhatod meg, hogy egy szövegmező mindig megtartsa méreteit egy PowerPoint prezentációban:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

Ha a szöveg túl hosszú lesz a dobozhoz képest, kilóg.

## **Szöveg zsugorítása túlcsorduláskor**

Ha a szöveg túl hosszú lesz a dobozhoz képest, a **Shrink text on overflow** beállítással megadhatod, hogy a szöveg méretét és távolságát csökkenteni kell, hogy elférjen a dobozban. Ennek a beállításnak a megadásához állítsd be a `AutofitType` tulajdonságot a [TextFrameFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat) osztályból `Normal` értékre.

!["Shrink text on overflow" beállítás a PowerPointban](shrinktextonoverflow-setting-powerpoint.png)

Ez a C# kód bemutatja, hogyan adhatod meg, hogy a szöveg legyen zsugorítva túlcsorduláskor egy PowerPoint prezentációban:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}
A **Shrink text on overflow** beállítás használatakor a beállítás csak akkor lép életbe, amikor a szöveg túl hosszúra nő a dobozhoz képest.
{{% /alert %}}

## **Szöveg tördelése**

Ha azt szeretnéd, hogy a szöveg egy alakzatban a saját határain belül legyen tördelve, amikor a szöveg túllépi az alakzat szélességét, a **Wrap text in shape** paramétert kell használnod. Ennek a beállításnak a megadásához a `WrapText` tulajdonságot a [TextFrameFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat) osztályból `NullableBool.True` értékre kell állítanod.

Ez a C# kód bemutatja, hogyan használhatod a Szöveg tördelése beállítást egy PowerPoint prezentációban:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}} 
Ha egy alakzatra a `WrapText` tulajdonságot `NullableBool.False`‑ra állítod, akkor amikor a belső szöveg hosszabbá válik az alakzat szélességénél, a szöveg egyetlen sorban túlnyúlik az alakzat határain.
{{% /alert %}}

## **FAQ**

**A szövegkeret belső margói befolyásolják az AutoFitet?**

Igen. A kitöltés (belső margók) csökkenti a szövegnek rendelkezésre álló területet, így az AutoFit hamarabb beavatkozik – a betűméretet vagy az alakzat méretét korábban csökkentve. Ellenőrizd és állítsd be a margókat, mielőtt finomhangolnád az AutoFitet.

**Hogyan működik az AutoFit a kézi és puha sortörésekkel?**

A kényszerített sortörések megmaradnak, és az AutoFit a körülöttük lévő betűméretet és távolságot igazítja. A felesleges sortörések eltávolítása gyakran csökkenti, hogy milyen agresszíven kell az AutoFitnek zsugorítania a szöveget.

**A téma betűtípusának módosítása vagy a betűtípuscsere indítása befolyásolja az AutoFit eredményét?**

Igen. Ha más metrikájú betűtípusra cseréled a betűket, a szöveg szélessége/magassága megváltozik, ami befolyásolhatja a végső betűméretet és a sorok tördelését. Bármilyen betűtípusváltoztatás vagy -csere után ellenőrizd újra a diák tartalmát.