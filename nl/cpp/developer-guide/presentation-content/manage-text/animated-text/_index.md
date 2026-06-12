---
title: Animeer PowerPoint-tekst in C++
linktitle: Geanimeerde tekst
type: docs
weight: 60
url: /nl/cpp/animated-text/
keywords:
- geanimeerde tekst
- tekstanimatie
- geanimeerde alinea
- alinea-animatie
- animatie-effect
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Maak dynamische geanimeerde tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor C++, met gemakkelijk te volgen, geoptimaliseerde C++ codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u met geanimeerde tekst in Aspose.Slides kunt werken door animatie-effecten toe te passen op individuele alinea's en de al reeds toegekende effecten aan alinea's in een tekstvak op te halen. Het richt zich op de API‑methoden die worden gebruikt om animatie op alinea‑niveau toe te voegen en bestaande animatie‑effecten van alinea's in een presentatie te inspecteren.

## **Animatie‑effecten toevoegen aan alinea's**

We hebben de [**AddEffect()**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) methode toegevoegd aan de [**Sequence**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.sequence) en [**ISequence**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.i_sequence) klassen. Deze methode stelt u in staat om animatie‑effecten toe te voegen aan een enkele alinea. Deze voorbeeldcode laat zien hoe u een animatie‑effect aan een enkele alinea kunt toevoegen:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// selecteer alinea om effect toe te voegen
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// voeg Fly-animatieeffect toe aan geselecteerde alinea
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## **Animatie‑effecten ophalen voor alinea's**

U kunt er bijvoorbeeld voor kiezen om de aan een alinea toegevoegde animatie‑effecten te achterhalen; in een scenario wilt u de animatie‑effecten in een alinea ophalen omdat u die wilt toepassen op een andere alinea of vorm.

Aspose.Slides for C++ stelt u in staat om alle animatie‑effecten op te halen die zijn toegepast op alinea's die zich in een tekstvak (vorm) bevinden. Deze voorbeeldcode laat zien hoe u de animatie‑effecten in een alinea kunt ophalen:

``` cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```

## **Veelgestelde vragen**

**Hoe verschillen tekstanimaties van dia‑overgangen, en kunnen ze gecombineerd worden?**

Tekstanimaties bepalen hoe een object zich in de loop van de tijd op een dia gedraagt, terwijl [overgangen](/slides/nl/cpp/slide-transition/) bepalen hoe dia's veranderen. Ze zijn onafhankelijk en kunnen samen worden gebruikt; de afspeelvolgorde wordt bepaald door de animatietijdlijn en de overgangsinstellingen.

**Worden tekstanimaties behouden bij exporteren naar PDF of afbeeldingen?**

Nee. PDF‑bestanden en raster‑afbeeldingen zijn statisch, dus u ziet slechts één staat van de dia zonder beweging. Om beweging te behouden, exporteer naar [video](/slides/nl/cpp/convert-powerpoint-to-video/) of [HTML](/slides/nl/cpp/export-to-html5/).

**Werken tekstanimaties in lay‑outs en de dia‑master?**

Effecten die op lay‑out‑/master‑objecten worden toegepast, worden geërfd door dia's, maar hun timing en interactie met dia‑niveau animaties hangen af van de uiteindelijke volgorde op de dia.