---
title: Vylepšete PowerPoint prezentace pomocí animací v C++
linktitle: Animace PowerPoint
type: docs
weight: 150
url: /cs/cpp/powerpoint-animation/
keywords:
- přidat animaci
- aktualizovat animaci
- změnit animaci
- odebrat animaci
- spravovat animaci
- řídit animaci
- animační efekt
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
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se přidávat a řídit pokročilé animační efekty v Aspose.Slides pro C++, abyste vytvořili dynamické prezentace PowerPoint a OpenDocument."
---
## **Úvod**

Protože prezentace slouží k představení něčeho, jejich vizuální vzhled a interaktivní chování jsou při tvorbě vždy zohledňovány.

**Animace PowerPoint** hraje důležitou roli při tom, aby byla prezentace poutavá a zajímavá pro diváky. Aspose.Slides poskytuje širokou škálu možností, jak do PowerPoint prezentací přidat animace:

- Použít různé typy animací PowerPoint na tvary, grafy, tabulky, OLE objekty a další prvky prezentace.
- Použít více animací PowerPoint na jeden tvar.
- Využít časovou osu animace k řízení efektů animací.
- Vytvářet vlastní animace.

V Aspose.Slides lze na tvary použít různé animační efekty. Protože každý prvek na snímku, včetně textu, obrázků, OLE objektů a tabulek, je považován za tvar, lze animační efekty aplikovat na jakýkoli prvek na snímku.

Namespace [Aspose::Slides::Animation](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/) poskytuje třídy pro práci s animacemi PowerPoint.

## **Animační efekty**

Aspose.Slides podporuje **150+ animačních efektů**, včetně základních efektů jako Bounce, PathFootball a Zoom a specifických efektů jako OLEObjectShow a OLEObjectOpen. Kompletní výpis najdete v enumeraci [EffectType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effecttype/).

Dále lze tyto animační efekty kombinovat s následujícími chováními:

- [ColorEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/seteffect/)

## **Vlastní animace**

Kompletní C++ příklady, které vytvářejí, inspektují a upravují chování a editovatelné pohybové cesty, naleznete v [Custom Animation](/slides/cs/cpp/custom-animation/).

Je možné vytvořit vlastní **vlastní animace** v Aspose.Slides. Toho lze dosáhnout kombinací několika chování do nové vlastní animace.

[Behavior](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/behavior/) je stavební blok animačního efektu PowerPoint. Kombinujte chování pro úpravu efektu nebo přidejte chování k rozšíření předdefinovaného efektu. Opakování se nastavuje pomocí časových nastavení, nikoli pomocí samostatného opakovacího chování.

[Animation Point](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/point/) je bod, ve kterém by mělo být chování aplikováno.

## **Časová osa animace**
[Sequence](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/sequence/) je kolekce animačních efektů, které mohou cílit na různé tvary.

[IAnimationTimeLine](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ianimationtimeline/) je sada sekvencí používaných v konkrétním snímku. Jedná se o animační engine zavedený v PowerPointu 2002. Ve starších verzích PowerPointu bylo přidávání animačních efektů do prezentací obtížné a mohlo být dosaženo pouze různými obskurními řešeními. Časová osa poskytuje přehlednější objektový model pro animace PowerPoint. Snímek může mít pouze jednu časovou osu animace.

## **Interaktivní animace**
[Trigger](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effecttriggertype/) umožňuje definovat uživatelské akce, jako je kliknutí na tlačítko, které spustí konkrétní animaci.

## **Animace tvarů**
Aspose.Slides vám umožňuje aplikovat animace na tvary, které mohou zahrnovat text, obdélníky, čáry, rámy, OLE objekty a další.

{{% alert color="info" title="Note" %}}
Přečtěte si více [**O animaci tvarů**](/slides/cs/cpp/shape-animation/).
{{% /alert %}}

## **Animované grafy**
Pro vytvoření animovaných grafů byste měli použít stejné třídy jako pro tvary. Nicméně animace PowerPoint lze aplikovat pouze na kategorie grafu nebo sérii grafu. Můžete také aplikovat animační efekty na prvek kategorie nebo prvek série.

{{% alert color="info" title="Note" %}}
Přečtěte si více [**O animovaných grafech**](/slides/cs/cpp/animated-charts/).
{{% /alert %}}

## **Animovaný text**
Kromě animování textu můžete animaci aplikovat i na odstavec.

{{% alert color="info" title="Note" %}}
Přečtěte si více [**O animovaném textu**](/slides/cs/cpp/animated-text/).
{{% /alert %}}

## **Často kladené otázky**

**Zůstanou animace zachovány při exportu do PDF?**

Není. PDF je statický formát, takže animace a [přechody snímků](/slides/cs/cpp/slide-transition/) se nepřehrávají. Pokud potřebujete pohyb, exportujte místo toho do [HTML5](/slides/cs/cpp/export-to-html5/), [animated GIF](/slides/cs/cpp/convert-powerpoint-to-animated-gif/) nebo [video](/slides/cs/cpp/convert-powerpoint-to-video/).

**Mohu převést animovanou prezentaci na video a ovládat snímkovou frekvenci a velikost snímku?**

Ano. Můžete [vyrenderovat prezentaci jako snímky](/slides/cs/cpp/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), přičemž si zvolíte FPS a rozlišení. Během renderování se přehrávají animace a přechody snímků.

**Zůstanou animace zachovány při práci s ODP (nejen PPTX)?**

PPT, PPTX a ODP jsou podporovány pro [čtení](/slides/cs/cpp/open-presentation/) a [zápis](/slides/cs/cpp/save-presentation/), ale to neznamená, že animace budou zachovány. Data vlastní animace se mohou při konverzi do ODP ztratit. Viz [Custom Animation](/slides/cs/cpp/custom-animation/) pro příklady a návod, jak zkontrolovat kompatibilitu formátu.