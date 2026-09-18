---
title: Vylepšete PowerPoint prezentace pomocí animací v PHP
linktitle: PowerPoint animace
type: docs
weight: 150
url: /cs/php-java/powerpoint-animation/
keywords:
- přidat animaci
- aktualizovat animaci
- změnit animaci
- odstranit animaci
- spravovat animaci
- řídit animaci
- efekt animace
- PowerPoint animace
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
- PHP
- Aspose.Slides
description: "Prozkoumejte možnosti Aspose.Slides pro PHP prostřednictvím Java při práci s PowerPoint animacemi. Klíčové funkce a poznatky k vylepšení vašich prezentací."
---
## **Úvod**

Protože prezentace mají něco předvést, jejich vizuální vzhled a interaktivní chování jsou při tvorbě vždy brány v úvahu.

**PowerPoint animace** hraje důležitou roli při tom, aby byla prezentace poutavá a zajímavá pro diváky. Aspose.Slides for PHP via Java nabízí širokou škálu možností, jak do PowerPointových prezentací přidat animace:

- Použijte různé typy PowerPoint animací na tvary, grafy, tabulky, OLE objekty a další prvky prezentace.
- Použijte více PowerPoint animací na jeden tvar.
- Využijte časovou osu animací k řízení animačních efektů.
- Vytvořte vlastní animace.

V Aspose.Slides for PHP via Java lze na tvary aplikovat různé animační efekty. Protože každý prvek na snímku, včetně textu, obrázků, OLE objektů a tabulek, je považován za tvar, lze animační efekty použít na libovolný prvek snímku.

## **Efekty animace**
Aspose.Slides podporuje **více než 150 animačních efektů**, včetně základních efektů jako Bounce, PathFootball a Zoom a specifických efektů jako OLEObjectShow a OLEObjectOpen. Úplný seznam najdete ve třídě [EffectType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effecttype/).

Tyto animační efekty lze dále kombinovat s následujícími chováními:

- [ColorEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SetEffect)

## **Vlastní animace**

Kompletní příklady v PHP, které vytvářejí, zkoumají a upravují chování a editovatelné pohybové cesty, najdete v [Custom Animation](/slides/cs/php-java/custom-animation/).

V Aspose.Slides můžete vytvořit své **vlastní animace**. Toho lze dosáhnout kombinací několika chování do nové vlastní animace.

[Behavior](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behavior/) je stavební blok PowerPoint animačního efektu. Kombinujte chování pro přizpůsobení efektu nebo přidejte chování pro rozšíření předdefinovaného efektu. Opakování se konfiguruje pomocí časování místo samostatného opakovacího chování.

[Animation Point](https://reference.aspose.com/slides/cs/php-java/aspose.slides/point/) je místo, kde by mělo být chování použito.

## **Časová osa animace**
[Sequence](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sequence/) je kolekce animačních efektů, které mohou cílit na různé tvary.

[Timeline](https://reference.aspose.com/slides/cs/php-java/aspose.slides/animationtimeline/) je sada sekvencí používaných v konkrétním snímku. Je to animační engine zavedený v PowerPoint 2002. Ve starších verzích PowerPointu bylo přidávání animačních efektů do prezentací obtížné a mohlo být dosaženo jen různými obcházeními. Časová osa poskytuje přehlednější objektový model pro PowerPoint animace. Jeden snímek může mít pouze jednu časovou osu animace.

## **Interaktivní animace**
[Trigger](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effecttriggertype/) umožňuje definovat uživatelské akce, například kliknutí na tlačítko, které spustí konkrétní animaci.

## **Animace tvaru**
Aspose.Slides umožňuje aplikovat animace na tvary, mezi které patří text, obdélníky, čáry, rámy, OLE objekty a další.

{{% alert color="info" title="Poznámka" %}}
Přečtěte si více [**O animaci tvaru**](/slides/cs/php-java/shape-animation/).
{{% /alert %}}

## **Animované grafy**
Pro vytvoření animovaných grafů byste měli použít stejné třídy jako pro tvary. Nicméně PowerPoint animace lze aplikovat jen na kategorie grafu nebo na řady grafu. Můžete také aplikovat animační efekty na prvek kategorie nebo na prvek řady.

{{% alert color="info" title="Poznámka" %}}
Přečtěte si více [**O animovaných grafech**](/slides/cs/php-java/animated-charts/).
{{% /alert %}}

## **Animovaný text**
Kromě animace textu můžete aplikovat animaci i na odstavec.

{{% alert color="info" title="Poznámka" %}}
Přečtěte si více [**O animovaném textu**](/slides/cs/php-java/animated-text/).
{{% /alert %}}

## **Často kladené otázky**

**Zůstanou animace zachovány při exportu do PDF?**

Ne. PDF je statický formát, takže animace a [přechody snímků](/slides/cs/php-java/slide-transition/) se nepřehrají. Pokud potřebujete pohyb, exportujte do [HTML5](/slides/cs/php-java/export-to-html5/), [animovaného GIFu](/slides/cs/php-java/convert-powerpoint-to-animated-gif/) nebo [videa](/slides/cs/php-java/convert-powerpoint-to-video/) místo toho.

**Mohu převést animovanou prezentaci na video a ovládat snímkovou frekvenci a velikost snímku?**

Ano. Můžete [vyrenderovat prezentaci jako snímky](/slides/cs/php-java/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), přičemž si zvolíte FPS a rozlišení. Během renderování se přehrávají animace i přechody snímků.

**Zůstanou animace neporušené při práci s ODP (nejen PPTX)?**

PPT, PPTX a ODP jsou podporovány pro [čtení](/slides/cs/php-java/open-presentation/) i [zápis](/slides/cs/php-java/save-presentation/), avšak to nezaručuje zachování animací. Vlastní animační data mohou být ztracena při konverzi do ODP. Viz [Custom Animation](/slides/cs/php-java/custom-animation/) pro příklady a návod, jak zkontrolovat kompatibilitu formátu.