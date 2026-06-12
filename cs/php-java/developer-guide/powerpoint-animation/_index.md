---
title: Vylepšete prezentace PowerPoint pomocí animací v PHP
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
- ovládat animaci
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
description: "Prozkoumejte možnosti Aspose.Slides for PHP via Java při práci s animacemi v PowerPointu. Klíčové funkce a poznatky pro vylepšení vašich prezentací."
---
## **Úvod**

Protože prezentace slouží k představení něčeho, jejich vizuální vzhled a interaktivní chování jsou při jejich vytváření vždy brány v úvahu.

**PowerPoint animace** hraje důležitou roli při tom, aby byla prezentace poutavá a atraktivní pro diváky. Aspose.Slides for PHP via Java nabízí širokou škálu možností, jak přidat animaci do PowerPoint prezentace:

- aplikovat různé typy efektů PowerPoint animace na tvary, grafy, tabulky, OLE objekty a další prvky prezentace.
- použít více efektů PowerPoint animace na jeden tvar.
- použít časovou osu animace k řízení efektů animace.
- vytvořit vlastní animaci.

V Aspose.Slides for PHP via Java lze na tvary použít různé efekty animace. Jelikož je každý prvek na snímku, včetně textu, obrázků, OLE objektu, tabulky atd., považován za tvar, lze tak aplikovat efekt animace na každý prvek snímku.

## **Efekty animace**
Aspose.Slides podporuje **více než 150 efektů animace**, včetně základních efektů jako Bounce, PathFootball, zoom a specifických efektů jako OLEObjectShow, OLEObjectOpen. Kompletní seznam efektů animace najdete v enumeraci [**EffectType**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effecttype/).

Navíc lze tyto efekty animace kombinovat s:

- [ColorEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SetEffect)

## **Vlastní animace**
Je možné vytvořit vlastní **vlastní animace** v Aspose.Slides.  
Toho lze dosáhnout, pokud spojíte několik chování do nové vlastní animace.

[**Behavior**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Behavior) je stavební jednotka jakéhokoli efektu PowerPoint animace. Všechny efekty animace jsou ve skutečnosti souborem chování složených do jedné strategie. Chování můžete spojit do vlastní animace jednou a znovu ji použít v dalších prezentacích. Pokud přidáte nové chování do standardního efektu PowerPoint animace, vznikne další vlastní animace. Například můžete přidat opakování chování do animace, aby se několikrát opakovala.

[**Animation Point**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Point) je bod, kde by mělo být použito chování.

## **Časová osa animace**
[**Sequence**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Sequence) je kolekce efektů animace aplikovaná na konkrétní tvar.

[**Timeline**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/AnimationTimeLine) je sada sekvencí používaných v konkrétním snímku. Jedná se o animační engine, který je součástí od PowerPoint 2002. Ve starších verzích PowerPointu bylo obtížné přidávat efekty animace do prezentace, což bylo možné pouze pomocí různých obcházek. Timeline nahrazuje starou třídu AnimationSettings a poskytuje přehlednější objektový model pro PowerPoint animaci. Jeden snímek může mít pouze jednu časovou osu animace.

## **Interaktivní animace**
[**Trigger**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/EffectTriggerType) umožňuje definovat uživatelské akce (např. kliknutí na tlačítko), které spustí určitou animaci. Spouštěče (triggery) byly přidány pouze v nejnovější verzi PowerPointu.

## **Animace tvaru**
Aspose.Slides umožňuje aplikovat animaci na tvary, kterými mohou být text, obdélník, čára, rámeček, OLE objekt atd.

{{% alert color="primary" %}} 
Přečtěte si více [**O animaci tvarů**](/slides/cs/php-java/shape-animation/).
{{% /alert %}}

## **Animované grafy**
Pro vytvoření animovaných grafů byste měli použít stejné třídy jako pro tvary. Je však možné použít PowerPoint animaci pouze na kategorie grafu nebo řady grafu. Můžete také aplikovat efekt animace na prvek kategorie nebo řady.

{{% alert color="primary" %}} 
Přečtěte si více [**O animovaných grafech**](/slides/cs/php-java/animated-charts/).
{{% /alert %}}

## **Animovaný text**
Kromě animovaného textu je také možné aplikovat animaci na odstavec.

{{% alert color="primary" %}} 
Přečtěte si více [**O animovaném textu**](/slides/cs/php-java/animated-text/).
{{% /alert %}}

## **Často kladené otázky**

**Zůstanou animace zachovány při exportu do PDF?**

Ne. PDF je statický formát, takže animace a [přechody snímků](/slides/cs/php-java/slide-transition/) se nepřehrávají. Pokud potřebujete pohyb, exportujte místo toho do [HTML5](/slides/cs/php-java/export-to-html5/), [animovaného GIF](/slides/cs/php-java/convert-powerpoint-to-animated-gif/) nebo [videa](/slides/cs/php-java/convert-powerpoint-to-video/).

**Mohu převést animovanou prezentaci na video a řídit snímkovou frekvenci a velikost snímku?**

Ano. Můžete [vykreslit prezentaci po snímcích](/slides/cs/php-java/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), přičemž si zvolíte FPS a rozlišení. Animace a přechody snímků jsou během vykreslování přehrávány.

**Zůstanou animace zachovány při práci s ODP (nejen PPTX)?**

Formáty PPT, PPTX a ODP jsou podporovány pro [čtení](/slides/cs/php-java/open-presentation/) a [zápis](/slides/cs/php-java/save-presentation/), ale rozdíly ve formátu mohou způsobit, že některé efekty budou vypadat nebo fungovat mírně odlišně. Ověřte kritické případy pomocí skutečných vzorků.