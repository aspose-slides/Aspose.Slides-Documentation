---
title: Förbättra dina presentationer med AutoFit i .NET
linktitle: Autofit-inställningar
type: docs
weight: 30
url: /sv/net/manage-autofit-settings/
keywords:
- textruta
- autofit
- inaktivera autofit
- anpassa text
- krymp text
- radbryt text
- ändra storlek på form
- PowerPoint
- presentation
- C#
- .NET
- Aspose.Slides
description: "Lär dig hur du hanterar AutoFit-inställningar i Aspose.Slides för .NET för att optimera textvisning i dina PowerPoint- och OpenDocument-presentationer och förbättra innehållsläsbarheten."
---
## **Introduktion**

Som standard, när du lägger till en textruta, använder Microsoft PowerPoint inställningen **Ändra storlek på form för att passa text** för textrutan – den ändrar automatiskt storleken på textrutan så att texten alltid får plats i den.

![En textruta i PowerPoint](textbox-in-powerpoint.png)

* När texten i textrutan blir längre eller större förstorar PowerPoint automatiskt textrutan – höjden ökas – för att rymma mer text.
* När texten i textrutan blir kortare eller mindre minskar PowerPoint automatiskt textrutan – höjden minskas – för att ta bort överflödig plats.

I PowerPoint finns fyra viktiga parametrar eller alternativ som styr autofit‑beteendet för en textruta:

* **Inaktivera Autofit**
* **Krymp text vid överspill**
* **Ändra storlek på form för att passa text**
* **Radbryt text i form**

![Autofit‑alternativ i PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET erbjuder liknande alternativ – egenskaper under klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat) – som låter dig styra autofit‑beteendet för textrutor i presentationer.

## **Ändra storlek på form för att passa text**

Om du vill att texten i en ruta alltid ska få plats i den efter att texten ändrats, måste du använda alternativet **Ändra storlek på form för att passa text**. För att specificera denna inställning, sätt `AutofitType`‑egenskapen från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat) till `Shape`.

![Ändra storlek på form för att passa text](alwaysfit-setting-powerpoint.png)

Denna C#‑kod visar hur du anger att text alltid ska få plats i sin ruta i en PowerPoint‑presentation:

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

Om texten blir längre eller större kommer textrutan automatiskt att ändras i storlek (höjden ökas) så att all text får plats. Om texten blir kortare sker motsatsen.

## **Inaktivera Autofit**

Om du vill att en textruta eller form ska behålla sina mått oavsett vilka ändringar som görs i texten, måste du använda alternativet **Inaktivera Autofit**. För att specificera denna inställning, sätt `AutofitType`‑egenskapen från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat) till `None`.

!["Do not Autofit"-inställning i PowerPoint](donotautofit-setting-powerpoint.png)

Denna C#‑kod visar hur du anger att en textruta alltid ska behålla sina mått i en PowerPoint‑presentation:

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

När texten blir för lång för sin ruta, flyter den över kanten.

## **Krymp text vid överspill**

Om texten blir för lång för sin ruta kan du med alternativet **Krymp text vid överspill** ange att textens storlek och avstånd ska minskas så att den får plats i rutan. För att specificera denna inställning, sätt `AutofitType`‑egenskapen från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat) till `Normal`.

!["Shrink text on overflow"-inställning i PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Denna C#‑kod visar hur du anger att text ska krympas vid överspill i en PowerPoint‑presentation:

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
När alternativet **Krymp text vid överspill** används tillämpas inställningen endast när texten blir för lång för sin ruta.
{{% /alert %}}

## **Radbryt text**

Om du vill att texten i en form ska radbrytas inom formen när texten går utanför formens kant (endast bredd), måste du använda parametern **Radbryt text i form**. För att specificera denna inställning, sätt `WrapText`‑egenskapen från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat) till `NullableBool.True`.

Denna C#‑kod visar hur du använder radbrytningsinställningen i en PowerPoint‑presentation:

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
Om du sätter `WrapText`‑egenskapen till `NullableBool.False` för en form, kommer texten som blir längre än formens bredd att fortsätta på en enda rad utanför formens kanter.
{{% /alert %}}

## **Vanliga frågor**

**Påverkar textrutans interna marginaler AutoFit?**

Ja. Padding (interna marginaler) minskar det användbara området för text, så AutoFit triggas tidigare – fonten krympes eller formen ändras i storlek tidigare. Kontrollera och justera marginalerna innan du finjusterar AutoFit.

**Hur samverkar AutoFit med manuella och mjuka radbrytningar?**

Tvingade radbrytningar behålls, och AutoFit anpassar teckenstorlek och avstånd runt dem. Att ta bort onödiga radbrytningar minskar ofta hur aggressivt AutoFit behöver krympa texten.

**Påverkar byte av temafont eller font‑substitution resultatet av AutoFit?**

Ja. Bytet till en font med andra glyf‑mått förändrar textens bredd/höjd, vilket kan ändra den slutliga teckenstorleken och radbrytningen. Efter varje font‑ändring eller -substitution bör du kontrollera bilderna igen.