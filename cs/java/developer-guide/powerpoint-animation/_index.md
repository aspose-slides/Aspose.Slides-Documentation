---
title: Vylepšete prezentace PowerPoint pomocí animací v jazyce Java
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
- řídit animaci
- efekt animace
- animace PowerPoint
- časová osa animace
- interaktivní animace
- vlastní animace
- animace tvaru
- animovaný diagram
- animovaný text
- animovaný tvar
- animovaný OLE objekt
- animovaný obrázek
- animovaná tabulka
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Prozkoumejte možnosti Aspose.Slides pro Java při práci s animacemi PowerPoint. Tento obecný přehled zdůrazňuje klíčové funkce a poskytuje poznatky pro vylepšení vašich prezentací."
---
## **Úvod**

Protože prezentace mají představovat něco, jejich vizuální vzhled a interaktivní chování jsou při tvorbě vždy brány v úvahu.

**PowerPoint animation** hraje důležitou roli při tom, aby byla prezentace poutavá a zajímavá pro diváky. Aspose.Slides poskytuje širokou škálu možností, jak přidat animace do PowerPoint prezentací:

- Použít různé typy animačních efektů PowerPoint na tvary, grafy, tabulky, OLE objekty a další prvky prezentace.
- Použít více animačních efektů PowerPoint na jeden tvar.
- Využít časovou osu animace k řízení animačních efektů.
- Vytvořit vlastní animace.

V Aspose.Slides lze na tvary aplikovat různé animační efekty. Protože každý prvek na snímku, včetně textu, obrázků, OLE objektů a tabulek, je považován za tvar, lze animační efekty použít na jakýkoli prvek snímku.

## **Animační efekty**
Aspose.Slides podporuje **150+ animačních efektů**, včetně základních animačních efektů, jako jsou Bounce, PathFootball, Zoom efekt a specifických animačních efektů, jako OLEObjectShow, OLEObjectOpen. Úplný seznam animačních efektů najdete v [**EffectType**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effecttype/) výčtu.

Kromě toho lze tyto animační efekty použít v kombinaci s následujícími:

- [ColorEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SetEffect)

## **Vlastní animace**
Je možné vytvořit vlastní **vlastní animace** v Aspose.Slides.  
Toto lze dosáhnout, pokud spojíte několik chování dohromady do nové vlastní animace.

[**Behavior**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Behavior) je stavební jednotka libovolného animačního efektu PowerPoint. Všechny animační efekty jsou ve skutečnosti množinou chování složených do jedné strategie. Můžete spojit chování do vlastní animace jednou a opakovaně ji použít v dalších prezentacích. Pokud do standardního animačního efektu PowerPoint přidáte nové chování – vznikne další vlastní animace. Například můžete přidat chování opakování k animaci, aby se opakovala několikrát.

[**Animation Point**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Point) je bod, kde by mělo být chování aplikováno.

## **Časová osa animace**
[**Sequence**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Sequence) je kolekce animačních efektů aplikovaných na konkrétní tvar.

[**Timeline**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/AnimationTimeLine) je sada sekvencí používaných v konkrétním snímku. Jedná se o animační engine, který existuje od PowerPointu 2002. Ve starších verzích PowerPointu bylo obtížné přidávat animační efekty do prezentace, což bylo možné pouze různými obcházeními. Časová osa nahrazuje starou třídu AnimationSettings a poskytuje jasnější objektový model pro animační efekty PowerPoint. Jeden snímek může mít **pouze jednu** časovou osu animace.

## **Interaktivní animace**
[**Trigger**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/EffectTriggerType) umožňuje definovat uživatelské akce (např. kliknutí na tlačítko), které spustí konkrétní animaci. Spouštěče byly přidány až v nejnovější verzi PowerPointu.

## **Animace tvarů**
Aspose.Slides umožňuje aplikovat animaci na tvary, kterými mohou být text, obdélník, čára, rámeček, OLE objekt atd.

{{% alert color="primary" %}} 
Přečtěte si více [**O animaci tvarů**](/slides/cs/java/shape-animation/).
{{% /alert %}}

## **Animované diagramy**
Pro vytvoření animovaných diagramů byste měli použít stejné třídy jako pro tvary. Nicméně je možné použít PowerPoint animaci pouze na kategorie diagramu nebo na řady diagramu. Můžete také aplikovat animační efekt na prvek kategorie nebo na prvek řady.

{{% alert color="primary" %}} 
Přečtěte si více [**O animovaných diagramech**](/slides/cs/java/animated-charts/).
{{% /alert %}}

## **Animovaný text**
Kromě animovaného textu je také možné aplikovat animaci na odstavec.

{{% alert color="primary" %}} 
Přečtěte si více [**O animovaném textu**](/slides/cs/java/animated-text/).
{{% /alert %}}

## **Často kladené otázky**

**Zůstanou animace zachovány při exportu do PDF?**

Ne. PDF je statický formát, takže animace a [přechody mezi snímky](/slides/cs/java/slide-transition/) se nepřehrávají. Pokud potřebujete pohyb, exportujte do [HTML5](/slides/cs/java/export-to-html5/), [animovaného GIFu](/slides/cs/java/convert-powerpoint-to-animated-gif/) nebo [videa](/slides/cs/java/convert-powerpoint-to-video/) místo toho.

**Mohu převést animovanou prezentaci na video a řídit snímkovou frekvenci i velikost snímku?**

Ano. Můžete [vyrenderovat prezentaci jako snímky](/slides/cs/java/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), přičemž si můžete zvolit FPS a rozlišení. Během renderování se přehrávají animace i přechody mezi snímky.

**Zůstanou animace zachovány při práci s ODP (nejen PPTX)?**

PPT, PPTX a ODP jsou podporovány pro [čtení](/slides/cs/java/open-presentation/) i [zápis](/slides/cs/java/save-presentation/), ale rozdíly ve formátech znamenají, že některé efekty se mohou mírně lišit v vzhledu nebo chování. Kritické případy ověřte pomocí reálných ukázek.