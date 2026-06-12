---
title: Animovat text PowerPointu v .NET
linktitle: Animovaný text
type: docs
weight: 60
url: /cs/net/animated-text/
keywords:
- animovaný text
- animace textu
- animovaný odstavec
- animace odstavce
- efekt animace
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvořte dynamický animovaný text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET, s snadno sledovatelnými a optimalizovanými ukázkami kódu v C#."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s animovaným textem v Aspose.Slides pomocí aplikace animačních efektů na jednotlivé odstavce a získávání efektů již přiřazených odstavcům v textovém rámečku. Soustředí se na API metody používané k přidání animace na úrovni odstavce a prozkoumání existujících animačních efektů odstavců v prezentaci.

## **Přidání animačních efektů k odstavcům**

Přidali jsme metodu [**AddEffect()**](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/sequence/methods/addeffect/index) do tříd [**Sequence**](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/sequence) a [**ISequence**](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/isequence). Tato metoda vám umožňuje přidat animační efekty k jednomu odstavci. Tento ukázkový kód ukazuje, jak přidat animační efekt k jednomu odstavci:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // vyberte odstavec pro přidání efektu
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // přidejte animační efekt Fly do vybraného odstavce
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **Získání animačních efektů pro odstavce**

Můžete se rozhodnout zjistit animační efekty přidané k odstavci – například v jednom scénáři chcete získat animační efekty v odstavci, protože je plánujete použít u jiného odstavce nebo tvaru. Aspose.Slides pro .NET vám umožňuje získat všechny animační efekty aplikované na odstavce obsažené v textovém rámečku (tvaru). Tento ukázkový kód ukazuje, jak získat animační efekty v odstavci:

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

## **Často kladené otázky**

**Jak se liší animace textu od přechodů mezi snímky a lze je kombinovat?**

Animace textu řídí chování objektu v čase na snímku, zatímco [transitions](/slides/cs/net/slide-transition/) řídí, jak se snímky mění. Jsou nezávislé a lze je použít společně; pořadí přehrávání určuje časová osa animací a nastavení přechodu.

**Zůstávají animace textu zachovány při exportu do PDF nebo obrázků?**

Ne. PDF a rastrové obrázky jsou statické, takže uvidíte jediný stav snímku bez pohybu. Pro zachování pohybu použijte export do [video](/slides/cs/net/convert-powerpoint-to-video/) nebo [HTML](/slides/cs/net/export-to-html5/).

**Fungují animace textu v rozvrženích a v hlavním snímku (master)?**

Efekty aplikované na objekty rozvržení/master jsou děděny snímky, ale jejich časování a interakce s animacemi na úrovni snímku závisí na konečné sekvenci na snímku.