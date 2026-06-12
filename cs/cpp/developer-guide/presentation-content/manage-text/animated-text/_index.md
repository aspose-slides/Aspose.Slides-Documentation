---
title: "Animovat text v PowerPointu v C++"
linktitle: "Animovaný text"
type: docs
weight: 60
url: /cs/cpp/animated-text/
keywords:
- animovaný text
- animace textu
- animovaný odstavec
- animace odstavce
- efekt animace
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Vytvořte dynamický animovaný text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro C++, s jednoduchými, optimalizovanými příklady kódu v C++."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s animovaným textem v Aspose.Slides pomocí aplikace animačních efektů na jednotlivé odstavce a získávání efektů, které jsou již přiřazeny odstavcům v textovém rámečku. Zaměřuje se na metody API používané k přidání animace na úrovni odstavce a ke kontrole existujících animačních efektů odstavců v prezentaci.

## **Přidání animačních efektů k odstavcům**

Přidali jsme metodu [**AddEffect()**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) do tříd [**Sequence**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.sequence) a [**ISequence**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.i_sequence). Tato metoda vám umožní přidat animační efekty k jednomu odstavci. Tento ukázkový kód vám ukazuje, jak přidat animační efekt k jednomu odstavci:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// vybrat odstavec pro přidání efektu
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// přidat efekt animace Fly do vybraného odstavce
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## **Získání animačních efektů pro odstavce**

Můžete se rozhodnout zjistit animační efekty přidané k odstavci, například v jednom scénáři chcete získat animační efekty v odstavci, protože plánujete tyto efekty použít u jiného odstavce nebo tvaru.

Aspose.Slides pro C++ vám umožňuje získat všechny animační efekty aplikované na odstavce obsažené v textovém rámečku (tvaru). Tento ukázkový kód vám ukazuje, jak získat animační efekty v odstavci:

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

## **Často kladené otázky**

**Jak se animace textu liší od přechodů snímků a lze je kombinovat?**

Animace textu řídí chování objektu v čase na snímku, zatímco [přechody](/slides/cs/cpp/slide-transition/) řídí, jak se snímky mění. Jsou nezávislé a lze je použít společně; pořadí přehrávání je určeno časovou osou animace a nastavením přechodů.

**Zůstávají animace textu zachovány při exportu do PDF nebo obrázků?**

Ne. PDF a rastrové obrázky jsou statické, takže uvidíte jediný stav snímku bez pohybu. Pro zachování pohybu použijte export do [videa](/slides/cs/cpp/convert-powerpoint-to-video/) nebo [HTML](/slides/cs/cpp/export-to-html5/).

**Fungují animace textu v rozložení a hlavním snímku?**

Efekty aplikované na objekty rozvržení/master jsou zděděny snímky, ale jejich načasování a interakce s animacemi na úrovni snímku závisí na konečné sekvenci na snímku.