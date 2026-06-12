---
title: Vylepšete PowerPoint prezentace animacemi na Androidu
linktitle: Animace PowerPoint
type: docs
weight: 150
url: /cs/androidjava/powerpoint-animation/
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
- Android
- Java
- Aspose.Slides
description: "Prozkoumejte možnosti Aspose.Slides pro Android via Java při práci s animacemi PowerPoint. Tento obecný přehled zdůrazňuje klíčové funkce."
---
## **Úvod**

Protože prezentace mají sloužit k předvedení něčeho, jejich vizuální vzhled a interaktivní chování jsou při jejich vytváření vždy zohledňovány.

**PowerPoint animation** hraje důležitou roli, aby byla prezentace poutavá a atraktivní pro diváky. Aspose.Slides for Android via Java nabízí širokou škálu možností, jak přidat animaci do PowerPoint prezentace:

- aplikovat různé typy efektů animace PowerPointu na tvary, grafy, tabulky, OLE objekty a další prvky prezentace.
- použít více efektů animace PowerPointu na jeden tvar.
- použít časovou osu animace k řízení efektů animace.
- vytvořit vlastní animaci.

V Aspose.Slides for Android via Java lze na tvary použít různé animační efekty. Protože každý prvek na snímku včetně textu, obrázků, OLE objektu, tabulky atd. je považován za tvar, můžeme aplikovat animační efekt na každý prvek snímku.

## **Animační efekty**
Aspose.Slides podporuje **150+ animačních efektů**, včetně základních animačních efektů jako Bounce, PathFootball, Zoom a specifických animačních efektů jako OLEObjectShow, OLEObjectOpen. Kompletní seznam animačních efektů najdete v enumeraci [**EffectType**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effecttype/).

Navíc lze tyto animační efekty kombinovat s nimi:
- [ColorEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SetEffect)

## **Vlastní animace**
Je možné vytvořit vlastní **vlastní animace** v Aspose.Slides. To lze dosáhnout kombinací několika chování do nové vlastní animace.

[**Behavior**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Behavior) je stavební jednotka jakéhokoli animačního efektu PowerPointu. Všechny animační efekty jsou ve skutečnosti sadou chování složených do jedné strategie. Chování můžete sloučit do vlastní animace jednou a znovu ji použít v dalších prezentacích. Pokud přidáte nové chování do standardního animačního efektu PowerPointu, vznikne další vlastní animace. Například můžete přidat opakování chování do animace, aby se několikrát opakovala.

[**Animation Point**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Point) je bod, kde by mělo být aplikováno chování.

## **Časová osa animace**
[**Sequence**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Sequence) je sbírka animačních efektů, aplikovaných na konkrétní tvar.

[**Timeline**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/AnimationTimeLine) je sada sekvencí používaných v konkrétním snímku. Je to animační engine představovaný od PowerPointu 2002. Ve starších verzích PowerPointu bylo obtížné přidávat animační efekty do prezentace, což bylo možné jen pomocí různých workaroundů. Timeline nahrazuje starou třídu AnimationSettings a poskytuje přehlednější objektový model pro animaci v PowerPointu. Jeden snímek může mít pouze jednu časovou osu animace.

## **Interaktivní animace**
[**Trigger**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/EffectTriggerType) umožňuje definovat uživatelské akce (např. kliknutí na tlačítko), které spustí konkrétní animaci. Spouštěče byly přidány pouze do nejnovější verze PowerPointu.

## **Animace tvarů**
Aspose.Slides umožňuje aplikovat animaci na tvary, kterými mohou být text, obdélník, čára, rámeček, OLE objekt atd.

{{% alert color="primary" %}} 
Přečtěte si více [**O animaci tvarů**](/slides/cs/androidjava/shape-animation/).
{{% /alert %}}

## **Animované grafy**
Pro vytvoření animovaných grafů byste měli použít stejné třídy jako pro tvary. Nicméně je možné použít animaci PowerPointu pouze na kategorie grafu nebo série grafu. Můžete také aplikovat animační efekt na prvek kategorie nebo prvek série.

{{% alert color="primary" %}} 
Přečtěte si více [**O animovaných grafech**](/slides/cs/androidjava/animated-charts/).
{{% /alert %}}

## **Animovaný text**
Kromě animovaného textu je také možné aplikovat animaci na odstavec.

{{% alert color="primary" %}} 
Přečtěte si více [**O animovaném textu**](/slides/cs/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Zůstanou animace zachovány při exportu do PDF?**

Ne. PDF je statický formát, takže animace a [přechody snímků](/slides/cs/androidjava/slide-transition/) se nepřehrávají. Pokud potřebujete pohyb, exportujte místo toho do [HTML5](/slides/cs/androidjava/export-to-html5/), [animovaný GIF](/slides/cs/androidjava/convert-powerpoint-to-animated-gif/) nebo [video](/slides/cs/androidjava/convert-powerpoint-to-video/).

**Mohu převést animovanou prezentaci na video a ovládat snímkovou frekvenci a velikost rámců?**

Ano. Můžete [renderovat prezentaci do snímků](/slides/cs/androidjava/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), přičemž zvolíte FPS a rozlišení. Během renderování jsou přehrávány animace a přechody snímků.

**Zůstanou animace neporušené při práci s ODP (nejen PPTX)?**

PPT, PPTX a ODP jsou podporovány pro [čtení](/slides/cs/androidjava/open-presentation/) a [zápis](/slides/cs/androidjava/save-presentation/), ale rozdíly ve formátu znamenají, že některé efekty mohou vypadat nebo se chovat mírně odlišně. Ověřte kritické případy pomocí reálných vzorků.