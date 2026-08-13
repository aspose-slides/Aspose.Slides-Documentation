---
title: Vylepšete prezentace PowerPoint pomocí animací v C++
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
- řídit animaci
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
description: "Naučte se, jak přidávat a řídit pokročilé animační efekty v Aspose.Slides pro C++, abyste vytvořili dynamické prezentace PowerPoint a OpenDocument."
---
## **Úvod**

Protože prezentace mají sloužit k představení něčeho, jejich vizuální vzhled a interaktivní chování jsou při jejich tvorbě vždy zvažovány.

**PowerPoint animace** hraje důležitou roli při tom, aby byla prezentace poutavá a atraktivní pro diváky. Aspose.Slides for C++ nabízí širokou škálu možností, jak přidat animaci do PowerPoint prezentace:

- aplikovat různé typy efektů PowerPoint animací na tvary, grafy, tabulky, OLE objekty a další prvky prezentace.
- použít více efektů PowerPoint animací na jeden tvar.
- použít časovou osu animace k řízení efektů animace.
- vytvořit vlastní animaci.

V Aspose.Slides for C++ lze na tvary použít různé animační efekty. Protože každý prvek na snímku, včetně textu, obrázků, OLE objektu, tabulky atd., je považován za tvar, můžeme aplikovat animační efekt na každý prvek snímku.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.animation) **namespace** poskytuje třídy pro práci s PowerPoint animacemi.
## **Animační efekty**
Aspose.Slides podporuje **150+ animačních efektů**, včetně základních efektů jako Bounce, PathFootball, Zoom a specifických efektů jako OLEObjectShow, OLEObjectOpen. Kompletní seznam animačních efektů najdete v enumeraci [**EffectType**](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

Kromě toho lze tyto animační efekty používat v kombinaci:

- [ColorEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.set_effect)

## **Vlastní animace**
Je možné vytvořit vlastní **animace** v Aspose.Slides.  
To lze dosáhnout kombinací několika chování do nové vlastní animace.

[**Behavior**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.behavior) je stavební jednotka každého PowerPoint animačního efektu. Všechny animační efekty jsou ve skutečnosti souborem chování složených do jedné strategie. Můžete kombinovat chování do vlastní animace jednou a znovu ji použít v dalších prezentacích. Pokud přidáte nové chování do standardního PowerPoint animačního efektu, vznikne další vlastní animace. Například můžete přidat opakování chování do animace, aby se několikrát opakovala.

[**Animation Point**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.point) je bod, kde by mělo být chování aplikováno.

## **Časová osa animace**
[**Sequence**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.sequence) je sbírka animačních efektů aplikovaných na konkrétní tvar.

[**AnimationTimeLine**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.animation_time_line) je sada sekvencí používaných na konkrétním snímku. Jedná se o animační engine, který je k dispozici od PowerPoint 2002. Ve starších verzích PowerPointu bylo obtížné přidávat animační efekty do prezentace, což bylo možné jen pomocí různých obcházek. Časová osa nahrazuje starou třídu AnimationSettings a poskytuje přehlednější objektový model pro PowerPoint animace. Jeden snímek může mít pouze jednu časovou osu animace.

## **Interaktivní animace**
[**EffectTriggerType**](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) umožňuje definovat uživatelské akce (např. kliknutí tlačítka), které spustí určitý animační efekt. Spouštěče byly přidány pouze v nejnovější verzi PowerPointu.

## **Animace tvarů**
Aspose.Slides umožňuje aplikovat animaci na tvary, kterými mohou být text, obdélník, čára, rám, OLE objekt atd.

{{% alert color="info" %}} 
Přečtěte si více [**O animaci tvarů**](/slides/cs/cpp/shape-animation/).
{{% /alert %}}

## **Animované grafy**
Pro vytvoření animovaných grafů byste měli použít stejné třídy jako pro tvary. Nicméně je možné použít PowerPoint animaci pouze na kategorie grafu nebo řady grafu. Můžete také aplikovat animační efekt na prvek kategorie nebo prvek řady.

{{% alert color="info" %}} 
Přečtěte si více [**O animovaných grafech**](/slides/cs/cpp/animated-charts/).
{{% /alert %}}

## **Animovaný text**
Kromě animovaného textu je také možné aplikovat animaci na odstavec.

{{% alert color="info" %}} 
Přečtěte si více [**O animovaném textu**](/slides/cs/cpp/animated-text/).
{{% /alert %}}

## **Často kladené otázky**

### Zůstanou animace zachovány při exportu do PDF?

Ne. PDF je statický formát, takže animace a [přechody snímků](/slides/cs/cpp/slide-transition/) se nepřehrávají. Pokud potřebujete pohyb, exportujte místo toho do [HTML5](/slides/cs/cpp/export-to-html5/), [animovaného GIFu](/slides/cs/cpp/convert-powerpoint-to-animated-gif/) nebo [videa](/slides/cs/cpp/convert-powerpoint-to-video/).

### Mohu převést animovanou prezentaci na video a ovládat počet snímků za sekundu a velikost snímku?

Ano. Můžete [vyrenderovat prezentaci jako snímky](/slides/cs/cpp/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), přičemž zvolíte FPS a rozlišení. Animace a přechody snímků jsou během renderování přehrávány.

### Zůstanou animace zachovány při práci s ODP (nejen PPTX)?

Formáty PPT, PPTX a ODP jsou podporovány pro [čtení](/slides/cs/cpp/open-presentation/) i [zápis](/slides/cs/cpp/save-presentation/), ale rozdíly ve formátech mohou způsobit, že některé efekty vypadají nebo se chovají mírně odlišně. Ověřte kritické případy pomocí skutečných vzorků.