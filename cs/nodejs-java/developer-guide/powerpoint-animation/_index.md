---
title: Vylepšete prezentace PowerPoint pomocí animací v JavaScriptu
linktitle: Animace PowerPoint
type: docs
weight: 150
url: /cs/nodejs-java/powerpoint-animation/
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
- animovaný objekt OLE
- animovaný obrázek
- animovaná tabulka
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Použijte Aspose.Slides pro Node.js via Java k manipulaci s animacemi PowerPoint. Tento přehled zdůrazňuje klíčové funkce a nabízí poznatky pro vylepšení vašich prezentací."
---
## **Úvod**

Protože prezentace mají sloužit k představení něčeho, jejich vizuální vzhled a interaktivní chování jsou při jejich tvorbě vždy zvažovány.

**Animace PowerPointu** hraje důležitou roli, aby byla prezentace poutavá a atraktivní pro diváky. Aspose.Slides for Node.js via Java nabízí širokou škálu možností, jak přidat animaci do prezentace PowerPoint:

- použít různé typy efektů animace PowerPointu na tvary, grafy, tabulky, objekty OLE a další prvky prezentace.
- použít více efektů animace PowerPointu na jeden tvar.
- použít časovou osu animace ke kontrole efektů animace.
- vytvořit vlastní animaci.

V Aspose.Slides for Node.js via Java lze na tvary použít různé efekty animací. Protože každý prvek na snímku, včetně textu, obrázků, objektu OLE, tabulky atd., je považován za tvar, můžeme na každý prvek snímku aplikovat efekt animace.

## **Efekty animace**
Aspose.Slides podporuje **150+ efektů animace**, včetně základních efektů animace jako Bounce, PathFootball, efekt Zoom a specifických efektů animace jako OLEObjectShow, OLEObjectOpen. Úplný seznam efektů animace najdete v [**EffectType**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effecttype/) enumeraci.

Navíc lze tyto efekty animace kombinovat s:
- [ColorEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SetEffect)

## **Vlastní animace**
Je možné vytvořit vlastní **vlastní animace** v Aspose.Slides. To lze dosáhnout kombinací několika chování do nové vlastní animace.

[**Behavior**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Behavior) je stavební jednotka každého efektu animace PowerPointu. Všechny efekty animace jsou ve skutečnosti souborem chování složených do jedné strategie. Můžete kombinovat chování do vlastní animace jednou a znovu ji použít v jiných prezentacích. Pokud do standardního efektu animace PowerPointu přidáte nové chování, vznikne další vlastní animace. Například můžete přidat chování opakování k animaci, aby se opakovala několikrát.

[**Animation Point**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Point) je bod, kde by mělo být chování aplikováno.

## **Časová osa animace**
[**Sequence**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Sequence) je kolekce efektů animace, aplikovaná na konkrétní tvar.

[**Timeline**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AnimationTimeLine) je sada sekvencí používaných v konkrétním snímku. Jedná se o animační engine, který existuje od PowerPointu 2002. Ve starších verzích PowerPointu bylo obtížné přidávat efekty animace do prezentace, což bylo možné pouze různými obcházeními. Timeline nahrazuje starou třídu AnimationSettings a poskytuje jasnější objektový model pro animaci PowerPointu. Jeden snímek může mít pouze jednu časovou osu animace.

## **Interaktivní animace**
[**Trigger**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/EffectTriggerType) umožňuje definovat uživatelské akce (např. kliknutí tlačítka), které spustí určitou animaci. Spouštěče byly přidány pouze v nejnovější verzi PowerPointu.

## **Animace tvarů**
Aspose.Slides umožňuje použít animaci na tvary, kterými mohou být text, obdélník, čára, rámec, objekt OLE atd.

{{% alert color="primary" %}} 
Přečtěte si více [**O animaci tvarů**](/slides/cs/nodejs-java/shape-animation/).
{{% /alert %}}

## **Animované grafy**
Pro vytvoření animovaných grafů byste měli použít stejné třídy jako pro tvary. Nicméně je možné použít animaci PowerPointu pouze na kategorie grafu nebo sérii grafu. Můžete také aplikovat efekt animace na prvek kategorie nebo prvek série.

{{% alert color="primary" %}} 
Přečtěte si více [**O animovaných grafech**](/slides/cs/nodejs-java/animated-charts/).
{{% /alert %}}

## **Animovaný text**
Kromě animovaného textu je také možné aplikovat animaci na odstavec.

{{% alert color="primary" %}} 
Přečtěte si více [**O animovaném textu**](/slides/cs/nodejs-java/animated-text/).
{{% /alert %}}

## **Často kladené otázky**

**Zůstanou animace zachovány při exportu do PDF?**

Ne. PDF je statický formát, takže animace a [přechody snímků](/slides/cs/nodejs-java/slide-transition/) se nepřehrávají. Pokud potřebujete pohyb, exportujte místo toho do [HTML5](/slides/cs/nodejs-java/export-to-html5/), [animovaného GIFu](/slides/cs/nodejs-java/convert-powerpoint-to-animated-gif/) nebo [videa](/slides/cs/nodejs-java/convert-powerpoint-to-video/).

**Mohu převést animovanou prezentaci na video a ovládat snímkovou frekvenci a velikost snímku?**

Ano. Můžete [vykreslit prezentaci jako snímky](/slides/cs/nodejs-java/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), přičemž zvolíte FPS a rozlišení. Animace a přechody snímků jsou během vykreslování přehrávány.

**Zůstanou animace zachovány při práci s ODP (nejen PPTX)?**

Formáty PPT, PPTX a ODP jsou podporovány pro [čtení](/slides/cs/nodejs-java/open-presentation/) a [zápis](/slides/cs/nodejs-java/save-presentation/), ale rozdíly ve formátech mohou způsobit, že některé efekty vypadají nebo se chovají mírně odlišně. Ověřte kritické případy pomocí reálných ukázek.