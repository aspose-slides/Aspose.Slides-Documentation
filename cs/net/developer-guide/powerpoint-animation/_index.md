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
- odebrat animaci
- spravovat animaci
- ovládat animaci
- efekt animace
- animace PowerPoint
- časová osa animace
- interaktivní animace
- vlastní animace
- animace tvarů
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
description: "Prozkoumejte možnosti Aspose.Slides pro .NET při práci s animacemi PowerPoint. Tento obecný přehled zdůrazňuje klíčové funkce a poskytuje postřehy pro vylepšení vašich prezentací."
---
## **Úvod**

Vzhledem k tomu, že prezentace mají sloužit k předvedení něčeho, jejich vizuální vzhled a interaktivní chování jsou při tvorbě vždy zohledňovány.

**PowerPoint animace** hraje důležitou roli při tom, aby byla prezentace pro diváky atraktivní a poutavá. Aspose.Slides pro .NET poskytuje širokou škálu možností, jak přidávat animace do prezentací PowerPoint:

- Použít různé typy animací PowerPointu na tvary, grafy, tabulky, OLE objekty a další prvky prezentace.
- Použít více animací PowerPointu na jeden tvar.
- Využít časovou osu animací k řízení animačních efektů.
- Vytvořit vlastní animace.

V Aspose.Slides pro .NET lze na tvary použít různé animační efekty. Protože každý prvek na snímku, včetně textu, obrázků, OLE objektů a tabulek, je považován za tvar, lze animační efekty použít na libovolný prvek snímku.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/) namespace poskytuje třídy pro práci s animacemi PowerPointu.

## **Efekty animací**

Aspose.Slides podporuje **150+ animačních efektů**, včetně základních efektů jako Bounce, PathFootball a Zoom, stejně jako specifických efektů jako OLEObjectShow a OLEObjectOpen. Kompletní seznam animačních efektů najdete v enumeraci [EffectType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effecttype).

Navíc lze tyto animační efekty kombinovat s následujícími:

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

[Behaviour](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/behavior) je stavební blok každého animačního efektu PowerPointu. Všechny animační efekty jsou v podstatě sadou chování složených do jedné strategie. Chování můžete spojit do vlastní animace jednou a znovu ji použít v dalších prezentacích. Pokud přidáte nové chování k standardnímu animačnímu efektu PowerPointu, stane se další vlastní animací. Například můžete k animaci přidat opakující se chování, aby se animace několikrát opakovala.

[Animation Point](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/point) je bod, ve kterém by mělo být chování použito.

## **Časová osa animace**

[Sequence](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/sequence) je kolekce animačních efektů aplikovaných na konkrétní tvar.

[Timeline](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/animationtimeline) je sada sekvencí používaných v konkrétním snímku. Jedná se o animační engine zavedený v PowerPointu 2002. Ve starších verzích PowerPointu bylo přidávání animačních efektů do prezentací obtížné a lze jej dosáhnout jen různými obcházeními. Časová osa nahrazuje starou třídu AnimationSettings a poskytuje přehlednější objektový model pro animace PowerPointu. Snímek může mít pouze jednu časovou osu animace.

## **Interaktivní animace**

[Trigger](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effecttriggertype) vám umožňuje definovat uživatelské akce (např. kliknutí na tlačítko), které spustí konkrétní animaci. Spouštěče byly zavedeny v nejnovější verzi PowerPointu.

## **Animace tvarů**

Aspose.Slides vám umožňuje aplikovat animace na tvary, které mohou zahrnovat text, obdélníky, čáry, rámečky, OLE objekty a další.

{{% alert color="info" %}} 
Přečtěte si více [**O animaci tvarů**](/slides/cs/net/shape-animation/).
{{% /alert %}}

## **Animované grafy**

Pro vytvoření animovaných grafů byste měli použít stejné třídy jako pro tvary. Nicméně animace PowerPointu lze aplikovat pouze na kategorie grafu nebo řady grafu. Můžete také aplikovat animační efekty na prvek kategorie nebo prvek řady.

{{% alert color="info" %}} 
Přečtěte si více [**O animovaných grafech**](/slides/cs/net/animated-charts/).
{{% /alert %}}

## **Animovaný text**

Kromě animovaného textu je také možné aplikovat animaci na odstavec.

{{% alert color="info" %}} 
Přečtěte si více [**O animovaném textu**](/slides/cs/net/animated-text/).
{{% /alert %}}

## **Často kladené otázky**

### Budou animace zachovány při exportu do PDF?

Ne. PDF je statický formát, takže animace a [přechody snímků](/slides/cs/net/slide-transition/) se nepřehrávají. Pokud potřebujete pohyb, exportujte do [HTML5](/slides/cs/net/export-to-html5/), [animovaného GIFu](/slides/cs/net/convert-powerpoint-to-animated-gif/), nebo [videa](/slides/cs/net/convert-powerpoint-to-video/).

### Mohu převést animovanou prezentaci na video a kontrolovat snímkovou frekvenci a velikost snímku?

Ano. Můžete [renderovat prezentaci jako snímky](/slides/cs/net/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), přičemž vyberete FPS a rozlišení. Animace a přechody snímků jsou během renderování přehrávány.

### Zůstanou animace zachovány při práci s ODP (nejen PPTX)?

PPT, PPTX a ODP jsou podporovány pro [čtení](/slides/cs/net/open-presentation/) a [zápis](/slides/cs/net/save-presentation/), ale rozdíly ve formátech znamenají, že některé efekty mohou vypadat nebo se chovat mírně odlišně. Ověřte kritické případy pomocí reálných vzorků.