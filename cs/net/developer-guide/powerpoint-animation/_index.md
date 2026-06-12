---
title: Vylepšete prezentace PowerPoint pomocí animací v .NET
linktitle: Animace PowerPoint
type: docs
weight: 150
url: /cs/net/powerpoint-animation/
keywords:
- přidat animaci
- aktualizovat animaci
- změnit animaci
- odstranit animaci
- spravovat animaci
- ovládat animaci
- efekt animace
- animace PowerPoint
- časová osa animace
- interaktivní animace
- vlastní animace
- animace tvaru
- animovaný graf
- animovaný text
- animovaný tvar
- animovaný OLE objekt
- animovaný obrázek
- animovaná tabulka
- prezentace PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte možnosti Aspose.Slides pro .NET při práci s animacemi PowerPoint. Tento obecný přehled zdůrazňuje klíčové funkce a nabízí poznatky pro vylepšení vašich prezentací."
---
## **Úvod**

Protože prezentace mají sloužit k představení něčeho, jejich vizuální vzhled a interaktivní chování jsou při tvorbě vždy zohledněny.

**PowerPoint animation** hraje důležitou roli při zpříjemnění prezentace a zaujetí diváků. Aspose.Slides for .NET poskytuje širokou škálu možností, jak přidat animace do prezentací PowerPoint:

- Použijte různé typy efektů animace PowerPointu na tvary, grafy, tabulky, OLE objekty a další prvky prezentace.
- Použijte více efektů animace PowerPointu na jeden tvar.
- Využijte časovou osu animace k řízení efektů animace.
- Vytvořte vlastní animace.

V Aspose.Slides pro .NET lze na tvary aplikovat různé efekty animace. Jelikož je každý prvek na snímku, včetně textu, obrázků, OLE objektů a tabulek, považován za tvar, lze efekty animace použít na libovolný prvek snímku.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/) namespace poskytuje třídy pro práci s animacemi PowerPointu.

## **Efekty animace**

Aspose.Slides podporuje **150+ animačních efektů**, včetně základních efektů jako Bounce, PathFootball a Zoom, stejně jako specifických efektů jako OLEObjectShow a OLEObjectOpen. Kompletní seznam efektů animace najdete v výčtu [EffectType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effecttype).

Navíc mohou být tyto efekty animace použity v kombinaci s následujícími:

- [ColorEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/seteffect)

## **Vlastní animace**

Je možné v Aspose.Slides vytvořit vlastní **vlastní animace**. To lze dosáhnout kombinací několika chování do nové vlastní animace.

[Behaviour](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/behavior) je stavebním blokem jakéhokoli efektu animace PowerPointu. Všechny efekty animace jsou v podstatě souborem chování složených do jedné strategie. Můžete kombinovat chování do vlastní animace jednou a znovu ji použít v dalších prezentacích. Pokud přidáte nové chování ke standardnímu efektu animace PowerPointu, stane se další vlastní animací. Například můžete přidat opakující se chování k animaci, aby se několikrát opakovala.

[Animation Point](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/point) je bod, ve kterém má být chování aplikováno.

## **Časová osa animace**

[Sequence](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/sequence) je kolekce efektů animace aplikovaných na konkrétní tvar.

[Timeline](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/animationtimeline) je sada sekvencí použitých v konkrétním snímku. Jedná se o animační engine zavedený v PowerPointu 2002. Ve starších verzích PowerPointu bylo přidávání efektů animace do prezentací obtížné a mohlo být provedeno jen různými obcházkovými metodami. Časová osa nahrazuje starou třídu AnimationSettings a poskytuje přehlednější objektový model pro animace PowerPointu. Snímek může mít pouze jednu časovou osu animace.

## **Interaktivní animace**

[Trigger](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effecttriggertype) vám umožňuje definovat uživatelské akce (např. kliknutí na tlačítko), které spustí konkrétní animaci. Spouštěče byly zavedeny v nejnovější verzi PowerPointu.

## **Animace tvarů**

Aspose.Slides vám umožňuje aplikovat animace na tvary, které mohou zahrnovat text, obdélníky, čáry, rámečky, OLE objekty a další.

{{% alert color="primary" %}} 
Přečtěte si více [**O animaci tvarů**](/slides/cs/net/shape-animation/).
{{% /alert %}}

## **Animované grafy**

Pro vytvoření animovaných grafů byste měli použít stejné třídy jako pro tvary. Nicméně animace PowerPointu lze aplikovat pouze na kategorie grafu nebo řady grafu. Můžete také aplikovat efekty animace na prvek kategorie nebo na prvek řady.

{{% alert color="primary" %}} 
Přečtěte si více [**O animovaných grafech**](/slides/cs/net/animated-charts/).
{{% /alert %}}

## **Animovaný text**

Kromě animovaného textu je také možné aplikovat animaci na odstavec.

{{% alert color="primary" %}} 
Přečtěte si více [**O animovaném textu**](/slides/cs/net/animated-text/).
{{% /alert %}}

## **Často kladené otázky**

**Zůstanou animace zachovány při exportu do PDF?**

Ne. PDF je statický formát, takže animace a [přechody snímků](/slides/cs/net/slide-transition/) se nepřehrávají. Pokud potřebujete pohyb, exportujte místo toho do [HTML5](/slides/cs/net/export-to-html5/), [animovaného GIFu](/slides/cs/net/convert-powerpoint-to-animated-gif/) nebo [videa](/slides/cs/net/convert-powerpoint-to-video/).

**Mohu převést animovanou prezentaci na video a řídit počet snímků za sekundu a velikost snímku?**

Ano. Můžete [vykreslit prezentaci po jednotlivých snímcích](/slides/cs/net/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), přičemž zvolíte FPS a rozlišení. Během vykreslování se přehrávají animace a přechody snímků.

**Zůstanou animace neporušené při práci s ODP (nejen PPTX)?**

Formáty PPT, PPTX a ODP jsou podporovány pro [čtení](/slides/cs/net/open-presentation/) a [zápis](/slides/cs/net/save-presentation/), ale rozdíly ve formátu mohou způsobit, že některé efekty vypadají nebo se chovají mírně odlišně. Ověřte kritické případy pomocí reálných vzorků.