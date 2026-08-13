---
title: Vylepšete prezentace PowerPoint pomocí animací v Javě
linktitle: Animace PowerPoint
type: docs
weight: 150
url: /cs/java/powerpoint-animation/
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
- Java
- Aspose.Slides
description: "Prozkoumejte možnosti Aspose.Slides pro Java při práci s animacemi PowerPointu. Tento obecný přehled zdůrazňuje klíčové funkce a nabízí postřehy pro vylepšení vašich prezentací."
---
## **Úvod**

Protože prezentace mají sloužit k představení něčeho, jejich vizuální vzhled a interaktivní chování jsou při tvorbě vždy zohledňovány.

**Animace PowerPoint** hraje důležitou roli při tom, aby byla prezentace poutavá a zajímavá pro diváky. Aspose.Slides poskytuje širokou škálu možností, jak do prezentací PowerPoint přidat animace:

- Použít různé typy efektů animace PowerPoint na tvary, grafy, tabulky, OLE objekty a další prvky prezentace.
- Použít více efektů animace PowerPoint na jednom tvaru.
- Využít časovou osu animace k řízení efektů animace.
- Vytvářet vlastní animace.

## **Efekty animace**
Aspose.Slides podporuje **více než 150 animací**, včetně základních efektů jako Bounce, PathFootball, Zoom a specifických efektů jako OLEObjectShow, OLEObjectOpen. Kompletní seznam efektů najdete v enumeraci [**EffectType**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effecttype/).

Navíc lze tyto efekty animace použít v kombinaci s nimi:

- [ColorEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SetEffect)

## **Vlastní animace**
Je možné vytvořit vlastní **vlastní animace** v Aspose.Slides. To lze dosáhnout kombinací několika chování do nové vlastní animace.

[**Behavior**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Behavior) je stavební jednotka jakéhokoli efektu animace PowerPoint. Všechny efekty animace jsou ve skutečnosti sadou chování složených do jedné strategie. Můžete kombinovat chování do vlastní animace jednou a znovu ji použít v dalších prezentacích. Pokud přidáte nové chování do standardního efektu animace PowerPoint, vznikne další vlastní animace. Například můžete k animaci přidat chování opakování, aby se animace několikrát zopakovala.

[**Animation Point**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Point) je bod, kde by mělo být chování aplikováno.

## **Časová osa animace**
[**Sequence**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Sequence) je kolekce efektů animace aplikovaná na konkrétní tvar.

[**Timeline**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/AnimationTimeLine) je sada sekvencí používaných na konkrétním snímku. Jedná se o animační engine, který je součástí od PowerPoint 2002. Ve starších verzích PowerPointu bylo obtížné přidávat efekty animace do prezentace, což bylo možné jen pomocí různých obcházek. Timeline nahrazuje starou třídu AnimationSettings a poskytuje přehlednější objektový model pro animaci PowerPoint. Jeden snímek může mít pouze jednu časovou osu animace.

## **Interaktivní animace**
[**Trigger**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/EffectTriggerType) umožňuje definovat uživatelské akce (např. kliknutí na tlačítko), které spustí konkrétní animaci. Spouštěče byly přidány pouze v nejnovější verzi PowerPoint.

## **Animace tvarů**
Aspose.Slides umožňuje aplikovat animaci na tvary, kterými mohou být text, obdélník, čára, rám, OLE objekt atd.

{{% alert color="info" %}} 
Více informací [**O animaci tvarů**](/slides/cs/java/shape-animation/).
{{% /alert %}}

## **Animované grafy**
Pro vytvoření animovaných grafů byste měli použít stejné třídy jako u tvarů. Je však možné použít animaci PowerPoint pouze na kategorie grafu nebo řady grafu. Můžete také aplikovat efekt animace na prvek kategorie nebo prvek řady.

{{% alert color="info" %}} 
Více informací [**O animovaných grafech**](/slides/cs/java/animated-charts/).
{{% /alert %}}

## **Animovaný text**
Kromě animovaného textu je také možné aplikovat animaci na odstavec.

{{% alert color="info" %}} 
Více informací [**O animovaném textu**](/slides/cs/java/animated-text/).
{{% /alert %}}

## **Často kladené otázky**

### Zůstanou animace zachovány při exportu do PDF?

Ne. PDF je statický format, takže animace a [přechody snímků](/slides/cs/java/slide-transition/) se nepřehrají. Pokud potřebujete pohyb, exportujte místo toho do [HTML5](/slides/cs/java/export-to-html5/), [animovaného GIF](/slides/cs/java/convert-powerpoint-to-animated-gif/) nebo [videa](/slides/cs/java/convert-powerpoint-to-video/).

### Mohu převést animovanou prezentaci na video a ovládat snímkovou frekvenci a velikost snímku?

Ano. Můžete [vygenerovat prezentaci jako snímky](/slides/cs/java/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), přičemž zvolíte FPS a rozlišení. Animace a přechody snímků jsou během generování přehrávány.

### Zůstanou animace zachovány při práci s ODP (nejen s PPTX)?

Formáty PPT, PPTX i ODP jsou podporovány pro [čtení](/slides/cs/java/open-presentation/) a [zápis](/slides/cs/java/save-presentation/), ale rozdíly ve formátu mohou způsobit, že některé efekty vypadají nebo se chovají mírně odlišně. Kritické případy ověřte pomocí skutečných vzorků.