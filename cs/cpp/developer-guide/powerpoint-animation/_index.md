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
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak přidávat a ovládat pokročilé animační efekty v Aspose.Slides pro C++ pro tvorbu dynamických PowerPoint a OpenDocument prezentací."
---
## **Introduction**

Protože prezentace mají představovat něco, jejich vizuální vzhled a interaktivní chování jsou při jejich tvorbě vždy brány v úvahu.

Animace v PowerPointu hraje důležitou roli, aby byla prezentace poutavá a atraktivní pro diváky. Aspose.Slides pro C++ nabízí širokou škálu možností, jak přidat animaci do PowerPoint prezentace:

- aplikovat různé typy animačních efektů PowerPointu na tvary, grafy, tabulky, OLE objekty a další prvky prezentace.
- použít více animačních efektů PowerPointu na jeden tvar.
- použít časovou osu animace k řízení animačních efektů.
- vytvořit vlastní animaci.

V Aspose.Slides pro C++ lze na tvary aplikovat různé animační efekty. Jelikož je každý prvek na snímku, včetně textu, obrázků, OLE objektu, tabulky atd., považován za tvar, lze animaci použít na každý prvek snímku.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.animation) **namespace** poskytuje třídy pro práci s animacemi PowerPointu.

## **Efekty animace**

Aspose.Slides podporuje **více než 150 animačních efektů**, včetně základních efektů jako Bounce, PathFootball, Zoom a specifických efektů jako OLEObjectShow, OLEObjectOpen. Úplný seznam animačních efektů najdete v enumeraci [**EffectType**](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) enumerace.

- [ColorEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.set_effect)

## **Vlastní animace**

Je možné vytvořit vlastní **vlastní animace** v Aspose.Slides. To lze dosáhnout sloučením několika chování do nové vlastní animace.

[**Behavior**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.behavior) je stavební jednotka jakéhokoli animačního efektu PowerPointu. Všechny animační efekty jsou ve skutečnosti sadou chování složených do jedné strategie. Můžete sloučit chování do vlastní animace jednou a znovu ji použít v dalších prezentacích. Pokud přidáte nové chování do standardního animačního efektu PowerPointu, vytvoří se další vlastní animace. Například můžete přidat opakování chování k animaci, aby se několikrát opakovala.

[**Animation Point**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.point) je bod, kde má být chování aplikováno.

## **Časová osa animace**

[**Sequence**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.sequence) je kolekce animačních efektů aplikovaných na konkrétní tvar.

[**AnimationTimeLine**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.animation_time_line) je sada Sekvencí používaných v konkrétním snímku. Jedná se o animační engine, který je součástí PowerPointu od verze 2002. Ve starších verzích PowerPointu bylo obtížné přidávat animační efekty do prezentace, což bylo možné jen pomocí různých obcházek. Časová osa nahradila starou třídu AnimationSettings a poskytuje přehlednější objektový model pro animace v PowerPointu. Jeden snímek může mít pouze jednu časovou osu animace.

## **Interaktivní animace**

[**EffectTriggerType**](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) umožňuje definovat uživatelské akce (např. kliknutí na tlačítko), které spustí konkrétní animaci. Spouštěče byly přidány až v nejnovější verzi PowerPointu.

## **Animace tvarů**

Aspose.Slides umožňuje aplikovat animaci na tvary, kterými mohou být například text, obdélník, čára, rámec, OLE objekt atd.

{{% alert color="primary" %}} 
Přečtěte si více [**O animaci tvarů**](/slides/cs/cpp/shape-animation/).
{{% /alert %}}

## **Animované grafy**

Pro vytvoření animovaných grafů byste měli použít stejné třídy jako pro tvary. Přesto je možné použít animaci PowerPointu pouze na kategorie grafu nebo řady grafu. Můžete také aplikovat animační efekt na prvek kategorie nebo prvek řady.

{{% alert color="primary" %}} 
Přečtěte si více [**O animovaných grafech**](/slides/cs/cpp/animated-charts/).
{{% /alert %}}

## **Animovaný text**

Kromě animovaného textu je také možné aplikovat animaci na odstavec.

{{% alert color="primary" %}} 
Přečtěte si více [**O animovaném textu**](/slides/cs/cpp/animated-text/).
{{% /alert %}}

## **Často kladené otázky**

**Budou animace zachovány při exportu do PDF?**

Ne. PDF je statický formát, takže animace a [přechody snímků](/slides/cs/cpp/slide-transition/) se nepřehrají. Pokud potřebujete pohyb, exportujte místo toho do [HTML5](/slides/cs/cpp/export-to-html5/), [animovaného GIFu](/slides/cs/cpp/convert-powerpoint-to-animated-gif/) nebo [videa](/slides/cs/cpp/convert-powerpoint-to-video/).

**Mohu převést animovanou prezentaci na video a řídit snímkovou frekvenci a velikost snímku?**

Ano. Můžete [vykreslit prezentaci jako snímky](/slides/cs/cpp/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), přičemž si zvolíte FPS a rozlišení. Během vykreslování se přehrávají animace i přechody snímků.

**Zůstanou animace zachovány při práci s ODP (a ne jen PPTX)?**

Formáty PPT, PPTX i ODP jsou podporovány pro [čtení](/slides/cs/cpp/open-presentation/) a [zápis](/slides/cs/cpp/save-presentation/), avšak rozdíly ve formátu mohou způsobit, že některé efekty budou vypadat či fungovat mírně odlišně. Ověřte kritické případy pomocí reálných vzorků.