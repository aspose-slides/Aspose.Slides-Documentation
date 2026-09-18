---
title: Vylepšete prezentace PowerPoint pomocí animací na Androidu
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
- Android
- Java
- Aspose.Slides
description: "Prozkoumejte možnosti Aspose.Slides pro Android pomocí Javy při zpracování animací PowerPoint. Tento obecný přehled zdůrazňuje klíčové funkce."
---
## **Úvod**

Protože prezentace mají představovat něco, jejich vizuální vzhled a interaktivní chování jsou při tvorbě vždy zohledňovány.

**PowerPoint animation** hraje důležitou roli při tom, aby byla prezentace pro diváky poutavá a zajímavá. Aspose.Slides poskytuje širokou škálu možností, jak přidat animace do prezentací PowerPoint:

- Použít různé typy efektů animace PowerPoint na tvary, grafy, tabulky, OLE objekty a další prvky prezentace.
- Použít několik efektů animace PowerPoint na jeden tvar.
- Využít časovou osu animace k řízení efektů animace.
- Vytvářet vlastní animace.

## **Efekty animace**
Aspose.Slides podporuje **více než 150 efektů animace**, včetně základních efektů jako Bounce, PathFootball a Zoom a specifických efektů jako OLEObjectShow a OLEObjectOpen. Úplný seznam najdete ve třídě [EffectType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effecttype/).

Navíc lze tyto efekty animace použít v kombinaci s následujícími chováními:

- [ColorEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SetEffect)

## **Vlastní animace**
Úplné ukázky v Javě, které vytvářejí, zkoumají a upravují chování a editovatelné pohybové cesty, najdete na [Custom Animation](/slides/cs/java/custom-animation/).

Je možné vytvořit vlastní **vlastní animace** v Aspose.Slides. To lze dosáhnout kombinací několika chování do nové vlastní animace.

[Behavior](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/behavior/) je stavební blok efektu animace PowerPoint. Kombinujte chování pro úpravu efektu nebo přidejte chování pro rozšíření předdefinovaného efektu. Opakování se konfiguruje pomocí nastavení časování namísto samostatného opakovacího chování.

[Animation Point](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/point/) je bod, ve kterém by mělo být aplikováno chování.

## **Časová osa animace**
[Sequence](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sequence/) je sbírka efektů animace, které mohou cílit na různé tvary.

[Timeline](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/animationtimeline/) je sada sekvencí používaných v konkrétním snímku. Jedná se o animační engine zavedený v PowerPoint 2002. Ve starších verzích PowerPointu bylo přidávání efektů animace do prezentací obtížné a šlo jej realizovat jen pomocí různých obcházek. Časová osa poskytuje přehlednější objektový model pro animace PowerPointu. Snímek může mít pouze jednu časovou osu animace.

## **Interaktivní animace**
[Trigger](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effecttriggertype/) umožňuje definovat uživatelské akce, například kliknutí na tlačítko, které spustí konkrétní animaci.

## **Animace tvaru**
Aspose.Slides vám umožňuje aplikovat animace na tvary, které mohou zahrnovat text, obdélníky, čáry, rámy, OLE objekty a další.

{{% alert color="info" title="Note" %}}
Přečtěte si více [**O animaci tvaru**](/slides/cs/androidjava/shape-animation/).
{{% /alert %}}

## **Animované grafy**
Pro vytvoření animovaných grafů byste měli použít stejné třídy jako pro tvary. Animace PowerPoint však lze aplikovat pouze na kategorie grafu nebo řady grafu. Můžete také použít efekty animace na prvek kategorie nebo prvek řady.

{{% alert color="info" title="Note" %}}
Přečtěte si více [**O animovaných grafech**](/slides/cs/androidjava/animated-charts/).
{{% /alert %}}

## **Animovaný text**
Kromě animace textu můžete animaci aplikovat i na odstavec.

{{% alert color="info" title="Note" %}}
Přečtěte si více [**O animovaném textu**](/slides/cs/androidjava/animated-text/).
{{% /alert %}}

## **Často kladené otázky**

**Zůstanou animace zachovány při exportu do PDF?**

Ne. PDF je statický formát, takže animace a [slide transitions](/slides/cs/androidjava/slide-transition/) se nepřehrávají. Pokud potřebujete pohyb, místo toho exportujte do [HTML5](/slides/cs/androidjava/export-to-html5/), [animated GIF](/slides/cs/androidjava/convert-powerpoint-to-animated-gif/) nebo [video](/slides/cs/androidjava/convert-powerpoint-to-video/).

**Mohu převést animovanou prezentaci na video a kontrolovat snímkovou frekvenci a velikost snímků?**

Ano. Můžete [render the presentation as frames](/slides/cs/androidjava/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), přičemž si vyberete FPS a rozlišení. Během renderování jsou přehrávány animace a přechody mezi snímky.

**Zůstanou animace zachovány při práci s ODP (nejen PPTX)?**

Formáty PPT, PPTX a ODP jsou podporovány pro [reading](/slides/cs/androidjava/open-presentation/) a [writing](/slides/cs/androidjava/save-presentation/), avšak to nezaručuje zachování animací. Při převodu na ODP mohou být ztracena data vlastních animací. Viz [Custom Animation for Java](/slides/cs/java/custom-animation/) pro příklady a návody, jak ověřit kompatibilitu formátu.