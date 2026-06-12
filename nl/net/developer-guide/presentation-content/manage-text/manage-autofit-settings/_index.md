---
title: Verbeter uw presentaties met AutoFit in .NET
linktitle: Autofit‑instellingen
type: docs
weight: 30
url: /nl/net/manage-autofit-settings/
keywords:
- tekstvak
- autofit
- niet autofit
- tekst passen
- tekst verkleinen
- tekst omslaan
- vormgrootte aanpassen
- PowerPoint
- presentatie
- C#
- .NET
- Aspose.Slides
description: "Leer hoe u AutoFit‑instellingen in Aspose.Slides voor .NET kunt beheren om de weergave van tekst in uw PowerPoint‑ en OpenDocument‑presentaties te optimaliseren en de leesbaarheid van de inhoud te verbeteren."
---
## **Inleiding**

Standaard, wanneer je een tekstvak toevoegt, gebruikt Microsoft PowerPoint de **Resize shape to fit text**-instelling voor het tekstvak — hij past de grootte van het tekstvak automatisch aan zodat de tekst er altijd in past.

![Een tekstvak in PowerPoint](textbox-in-powerpoint.png)

* Wanneer de tekst in het tekstvak langer of groter wordt, vergroot PowerPoint automatisch het tekstvak — de hoogte wordt vergroot — zodat het meer tekst kan bevatten.
* Wanneer de tekst in het tekstvak korter of kleiner wordt, verkleint PowerPoint automatisch het tekstvak — de hoogte wordt verkleind — om overtollige ruimte te verwijderen.

In PowerPoint zijn dit de vier belangrijke parameters of opties die het autofit‑gedrag voor een tekstvak bepalen:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Autofit-opties in PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET biedt vergelijkbare opties — eigenschappen onder de [TextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat)-klasse — waarmee je het autofit‑gedrag voor tekstvakken in presentaties kunt beheren.

## **Vormgrootte aanpassen aan tekst**

Als je wilt dat de tekst in een vak altijd in dat vak past nadat de tekst is aangepast, moet je de **Resize shape to fit text**-optie gebruiken. Om deze instelling te specificeren, stel je de `AutofitType`‑eigenschap van de [TextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat)-klasse in op `Shape`.

![Vormgrootte aanpassen aan tekst](alwaysfit-setting-powerpoint.png)

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

Als de tekst langer of groter wordt, wordt het tekstvak automatisch vergroot (de hoogte wordt verhoogd) zodat alle tekst erin past. Als de tekst korter wordt, gebeurt het tegenovergestelde.

## **Niet Autofit**

Als je wilt dat een tekstvak of vorm zijn afmetingen behoudt, ongeacht de wijzigingen in de tekst die het bevat, moet je de **Do not Autofit**-optie gebruiken. Om deze instelling te specificeren, stel je de `AutofitType`‑eigenschap van de [TextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat)-klasse in op `None`.

![Instelling "Do not Autofit" in PowerPoint](donotautofit-setting-powerpoint.png)

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

Wanneer de tekst te lang wordt voor het vak, loopt deze er buiten.

## **Shrink Text on Overflow**

Als de tekst te lang wordt voor het vak, kun je via de **Shrink text on overflow**-optie opgeven dat de grootte en de spatiëring van de tekst moeten worden verminderd zodat deze in het vak past. Om deze instelling te specificeren, stel je de `AutofitType`‑eigenschap van de [TextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat)-klasse in op `Normal`.

![Instelling "Shrink text on overflow" in PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

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
Wanneer de **Shrink text on overflow**-optie wordt gebruikt, wordt de instelling alleen toegepast wanneer de tekst te lang wordt voor het vak.
{{% /alert %}}

## **Wrap Text**

Als je wilt dat de tekst in een vorm wordt omslagen binnen die vorm wanneer de tekst de vormranden (alleen de breedte) overschrijdt, moet je de **Wrap text in shape**-parameter gebruiken. Om deze instelling te specificeren, moet je de `WrapText`‑eigenschap van de [TextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat)-klasse instellen op `NullableBool.True`.

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
Als je de `WrapText`‑eigenschap instelt op `NullableBool.False` voor een vorm, wordt de tekst, wanneer die langer wordt dan de breedte van de vorm, over een enkele regel buiten de vormranden voortgezet.
{{% /alert %}}

## **Veelgestelde vragen**

**Hebben de interne marges van het tekstkader invloed op AutoFit?**

Ja. Opvulling (interne marges) verkleint het bruikbare gebied voor tekst, waardoor AutoFit eerder ingrijpt — het lettertype wordt eerder verkleind of de vorm eerder aangepast. Controleer en pas de marges aan voordat je AutoFit afstemt.

**Hoe werkt AutoFit samen met handmatige en zachte regeleinden?**

Geforceerde regeleinden blijven behouden, en AutoFit past de lettergrootte en spatiëring eromheen aan. Het verwijderen van overbodige regeleinden vermindert vaak hoe agressief AutoFit de tekst moet verkleinen.

**Heeft het wijzigen van het thematische lettertype of het activeren van lettertypevervanging invloed op AutoFit-resultaten?**

Ja. Het vervangen door een lettertype met andere glyph‑metingen verandert de tekstbreedte/-hoogte, wat de uiteindelijke lettergrootte en regelomslag kan beïnvloeden. Na elke wijziging of vervanging van een lettertype, controleer je de dia's opnieuw.