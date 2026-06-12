---
title: Vylepšete své prezentace pomocí AutoFit v .NET
linktitle: Nastavení Autofit
type: docs
weight: 30
url: /cs/net/manage-autofit-settings/
keywords:
- textové pole
- autofit
- neaplikovat autofit
- přizpůsobit text
- zmenšit text
- zalamovat text
- změnit velikost tvaru
- PowerPoint
- prezentace
- C#
- .NET
- Aspose.Slides
description: "Zjistěte, jak spravovat nastavení AutoFit v Aspose.Slides pro .NET, abyste optimalizovali zobrazení textu ve svých prezentacích PowerPoint a OpenDocument a zlepšili čitelnost obsahu."
---
## **Úvod**

Ve výchozím nastavení, když přidáte textové pole, Microsoft PowerPoint používá nastavení **Resize shape to fit text** pro textové pole – automaticky mění velikost textového pole, aby jeho text vždy do něj pasoval.

![Textové pole v PowerPointu](textbox-in-powerpoint.png)

* Když text v textovém poli se prodlouží nebo zvětší, PowerPoint automaticky zvětší textové pole – zvýší jeho výšku – aby pojmul více textu.
* Když text v textovém poli se zkrátí nebo zmenší, PowerPoint automaticky zmenší textové pole – sníží jeho výšku – aby odstranil nadbytečný prostor.

V PowerPointu jsou toto čtyři důležité parametry nebo možnosti, které řídí chování autofitu pro textové pole:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Možnosti Autofit v PowerPointu](autofit-options-powerpoint.png)

Aspose.Slides pro .NET poskytuje podobné možnosti – vlastnosti ve třídě [TextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat) – které vám umožňují řídit chování autofitu pro textová pole v prezentacích.

## **Změna velikosti tvaru, aby text pasoval**

Pokud chcete, aby text v rámečku vždy pasoval do tohoto rámečku po změnách textu, musíte použít možnost **Resize shape to fit text**. Pro nastavení této volby nastavte vlastnost `AutofitType` ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat) na `Shape`.

![Změna velikosti tvaru, aby text pasoval](alwaysfit-setting-powerpoint.png)

Tento C# kód ukazuje, jak nastavit, aby text vždy pasoval do svého rámečku v prezentaci PowerPoint:

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

Pokud text bude delší nebo větší, textové pole se automaticky zvětší (zvýší se výška), aby se do něj vešel celý text. Pokud se text zkrátí, nastane opačný efekt.

## **Neaplikovat Autofit**

Pokud chcete, aby textové pole nebo tvar zachovalo své rozměry bez ohledu na změny textu, musíte použít možnost **Do not Autofit**. Pro nastavení této volby nastavte vlastnost `AutofitType` ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat) na `None`.

!["Do not Autofit" nastavení v PowerPointu](donotautofit-setting-powerpoint.png)

Tento C# kód ukazuje, jak nastavit, aby textové pole vždy zachovalo své rozměry v prezentaci PowerPoint:

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

Když se text stane příliš dlouhým pro své pole, vylézá mimo něj.

## **Zmenšit text při přetečení**

Pokud se text stane příliš dlouhým pro své pole, můžete pomocí možnosti **Shrink text on overflow** určit, že velikost a rozestupy textu musí být zmenšeny, aby se vešel do pole. Pro nastavení této volby nastavte vlastnost `AutofitType` ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat) na `Normal`.

!["Shrink text on overflow" nastavení v PowerPointu](shrinktextonoverflow-setting-powerpoint.png)

Tento C# kód ukazuje, jak nastavit, aby se text při přetečení zmenšil v prezentaci PowerPoint:

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
Když je použita možnost **Shrink text on overflow**, nastavení se použije pouze tehdy, když se text stane příliš dlouhým pro své pole.
{{% /alert %}}

## **Zalamování textu**

Pokud chcete, aby byl text v tvaru zalomen uvnitř tohoto tvaru, když text přesáhne hranici tvaru (pouze šířka), musíte použít parametr **Wrap text in shape**. Pro nastavení této volby nastavte vlastnost `WrapText` ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat) na `NullableBool.True`.

Tento C# kód ukazuje, jak použít nastavení Wrap Text v prezentaci PowerPoint:

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
Pokud nastavíte vlastnost `WrapText` na `NullableBool.False` pro tvar, když text uvnitř tvaru přesáhne šířku tvaru, text se rozšíří mimo hranice tvaru v jedné řadě.
{{% /alert %}}

## **Často kladené otázky**

**Ovlivňují vnitřní okraje textového rámce AutoFit?**

Ano. Vnitřní okraje (padding) snižují použitelné místo pro text, takže AutoFit zasáhne dříve – zmenší písmo nebo upraví velikost tvaru dříve. Zkontrolujte a upravte okraje před laděním AutoFit.

**Jak AutoFit spolupracuje s ručními a měkkými konci řádků?**

Vynucené konce řádků zůstávají na místě a AutoFit upravuje velikost písma a rozestupy kolem nich. Odstraněním zbytečných koneců řádků se často sníží, jak agresivně AutoFit musí text zmenšovat.

**Mění změna písma motivu nebo spuštění substituce písma výsledky AutoFit?**

Ano. Nahrazení písma fontem s odlišnými metrikami glyfů změní šířku/výšku textu, což může ovlivnit konečnou velikost písma a zalamování řádků. Po jakékoli změně písma nebo jeho substituci znovu zkontrolujte snímky.