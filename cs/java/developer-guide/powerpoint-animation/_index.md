---
title: Vylepšete PowerPoint prezentace animacemi v Java
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
description: "Prozkoumejte možnosti Aspose.Slides pro Java při práci s animacemi PowerPointu. Tento obecný přehled zdůrazňuje hlavní funkce a poskytuje postřehy pro vylepšení vašich prezentací."
---
## **Úvod**

Protože prezentace slouží k představení něčeho, jejich vizuální vzhled a interaktivní chování jsou při tvorbě vždy zohledňovány.

**PowerPoint animace** hraje důležitou roli při tom, aby byla prezentace poutavá a zajímavá pro diváky. Aspose.Slides poskytuje širokou škálu možností, jak přidat animace do PowerPoint prezentací:

- Použít různé typy efektů animace PowerPointu na tvary, grafy, tabulky, OLE objekty a další prvky prezentace.
- Použít více efektů animace PowerPointu na jeden tvar.
- Využít časovou osu animace k řízení efektů animace.
- Vytvořit vlastní animace.

V Aspose.Slides lze na tvary aplikovat různé animační efekty. Protože každý prvek na snímku, včetně textu, obrázků, OLE objektů a tabulek, je považován za tvar, lze efekty animace aplikovat na jakýkoli prvek na snímku.

## **Efekty animace**
Aspose.Slides podporuje **více než 150 animačních efektů**, včetně základních efektů jako Bounce, PathFootball a Zoom a specifických efektů jako OLEObjectShow a OLEObjectOpen. Kompletní seznam najdete ve třídě [EffectType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effecttype/).

Navíc lze tyto animační efekty kombinovat s následujícími chováními:

- [ColorEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SetEffect)

## **Vlastní animace**

Pro úplné příklady v jazyce Java, které vytvářejí, kontrolují a upravují chování a editovatelné pohybové cesty, viz [Vlastní animace](/slides/cs/java/custom-animation/).

Je možné v Aspose.Slides vytvořit vlastní **vlastní animace**. To lze dosáhnout kombinací několika chování do nové vlastní animace.

[Behavior](https://reference.aspose.com/slides/cs/java/com.aspose.slides/behavior/) je stavební blok efeku animace PowerPointu. Kombinujte chování pro přizpůsobení efektu nebo přidejte chování pro rozšíření předdefinovaného efektu. Opakování je konfigurováno pomocí časových nastavení, nikoli samostatným chováním opakování.

[Animation Point](https://reference.aspose.com/slides/cs/java/com.aspose.slides/point/) je bod, ve kterém by mělo být chování použito.

## **Časová osa animace**
[Sequence](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sequence/) je kolekce animačních efektů, které mohou cílit na různé tvary.

[Timeline](https://reference.aspose.com/slides/cs/java/com.aspose.slides/animationtimeline/) je soubor sekvencí používaných na konkrétním snímku. Jedná se o animační engine zavedený v PowerPointu 2002. Ve starších verzích PowerPointu bylo přidávání animačních efektů do prezentací obtížné a bylo možné jej dosáhnout jen různými obcházeními. Časová osa poskytuje přehlednější objektový model pro animace PowerPointu. Snímek může mít jen jednu časovou osu animace.

## **Interaktivní animace**
[Trigger](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effecttriggertype/) vám umožňuje definovat akce uživatele, například kliknutí na tlačítko, které spustí konkrétní animaci.

## **Animace tvaru**
Aspose.Slides vám umožňuje aplikovat animace na tvary, které mohou zahrnovat text, obdélníky, čáry, rámečky, OLE objekty a další.

{{% alert color="info" title="Note" %}}
Přečtěte si více [**O animaci tvaru**](/slides/cs/java/shape-animation/).
{{% /alert %}}

## **Animované grafy**
Pro vytvoření animovaných grafů byste měli použít stejné třídy jako pro tvary. Nicméně animace v PowerPointu lze aplikovat pouze na kategorie grafu nebo řady grafu. Můžete také aplikovat animační efekty na prvek kategorie nebo prvek řady.

{{% alert color="info" title="Note" %}}
Přečtěte si více [**O animovaných grafech**](/slides/cs/java/animated-charts/).
{{% /alert %}}

## **Animovaný text**
Kromě animování textu můžete aplikovat animaci i na odstavec.

{{% alert color="info" title="Note" %}}
Přečtěte si více [**O animovaném textu**](/slides/cs/java/animated-text/).
{{% /alert %}}

## **FAQ**

**Zůstanou animace zachovány při exportu do PDF?**

Ne. PDF je statický formát, takže animace a [přechody snímků](/slides/cs/java/slide-transition/) se nepřehrávají. Pokud potřebujete pohyb, exportujte místo toho do [HTML5](/slides/cs/java/export-to-html5/), [animovaného GIFu](/slides/cs/java/convert-powerpoint-to-animated-gif/) nebo [videa](/slides/cs/java/convert-powerpoint-to-video/).

**Mohu převést animovanou prezentaci na video a řídit snímkovou frekvenci a velikost snímku?**

Ano. Můžete [vykreslit prezentaci po jednotlivých snímcích](/slides/cs/java/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), přičemž zvolíte FPS a rozlišení. Animace a přechody snímků jsou během vykreslování přehrávány.

**Zůstanou animace zachovány při práci s ODP (nejen PPTX)?**

Formáty PPT, PPTX a ODP jsou podporovány pro [čtení](/slides/cs/java/open-presentation/) a [zápis](/slides/cs/java/save-presentation/), avšak to nezaručuje zachování animací. Data vlastních animací mohou být při konverzi do ODP ztracena. Viz [Vlastní animace](/slides/cs/java/custom-animation/) pro příklady a pokyny k ověření kompatibility formátu.