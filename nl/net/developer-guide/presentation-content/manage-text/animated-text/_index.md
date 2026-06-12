---
title: Animeer PowerPoint-tekst in .NET
linktitle: Geanimeerde tekst
type: docs
weight: 60
url: /nl/net/animated-text/
keywords:
- geanimeerde tekst
- tekstanimatie
- geanimeerde alinea
- alinea-animatie
- animatie-effect
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak dynamische geanimeerde tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor .NET, met gemakkelijk te volgen, geoptimaliseerde C#-codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u werkt met geanimeerde tekst in Aspose.Slides door animatie‑effecten toe te passen op individuele alinea's en de al toegekende effecten op alinea's in een tekstraster op te halen. Het richt zich op de API‑methoden die worden gebruikt om animatie op alinea‑niveau toe te voegen en bestaande animatie‑effecten van alinea's in een presentatie te inspecteren.

## **Animatie‑effecten toevoegen aan alinea's**

We hebben de [**AddEffect()**](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/sequence/methods/addeffect/index) methode toegevoegd aan de [**Sequence**](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/sequence) en [**ISequence**](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/isequence) klassen. Deze methode stelt u in staat om animatie‑effecten toe te voegen aan één enkele alinea. Deze voorbeeldcode laat zien hoe u een animatie‑effect aan één alinea toevoegt:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // selecteer de alinea om een effect toe te voegen
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // voeg Fly‑animatie‑effect toe aan de geselecteerde alinea
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **Animatie‑effecten ophalen voor alinea's**

U kunt ervoor kiezen om de animatie‑effecten die aan een alinea zijn toegevoegd te achterhalen – bijvoorbeeld in een scenario waarin u de animatie‑effecten van een alinea wilt ophalen omdat u die effecten op een andere alinea of vorm wilt toepassen.

Aspose.Slides for .NET stelt u in staat om alle animatie‑effecten op te halen die zijn toegepast op alinea's die zich in een tekstraster (shape) bevinden. Deze voorbeeldcode laat zien hoe u de animatie‑effecten in een alinea kunt ophalen:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```

## **FAQ**

**Hoe verschillen tekstananimaties van dia‑overgangen, en kunnen ze gecombineerd worden?**

Tekstananimaties bepalen het gedrag van objecten in de tijd op een dia, terwijl [overgangen](/slides/nl/net/slide-transition/) regelen hoe dia's veranderen. Ze zijn onafhankelijk en kunnen samen worden gebruikt; de afspeelvolgorde wordt bepaald door de animatietijdlijn en de overgangsinstellingen.

**Worden tekstananimaties behouden bij het exporteren naar PDF of afbeeldingen?**

Nee. PDF‑bestanden en raster‑afbeeldingen zijn statisch, dus u ziet slechts één staat van de dia zonder beweging. Om beweging te behouden, exporteer naar [video](/slides/nl/net/convert-powerpoint-to-video/) of [HTML](/slides/nl/net/export-to-html5/).

**Werken tekstananimaties in lay‑out‑ en de dia‑master?**

Effecten die op lay‑out‑/master‑objecten worden toegepast, worden doorgegeven aan dia's, maar hun timing en interactie met dia‑niveau animaties hangen af van de uiteindelijke volgorde op de dia.