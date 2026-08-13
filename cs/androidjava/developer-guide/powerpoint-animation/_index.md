---
title: Vylepšete PowerPoint prezentace animacemi na Androidu
linktitle: PowerPoint animace
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
- Android
- Java
- Aspose.Slides
description: "Prozkoumejte možnosti Aspose.Slides pro Android prostřednictvím Javy při zpracování animací PowerPointu. Tento obecný přehled zdůrazňuje klíčové funkce."
---
## **Úvod**

Protože prezentace mají něco představit, jejich vizuální vzhled a interaktivní chování jsou při jejich tvorbě vždy zohledňovány.

**PowerPoint animation** hraje důležitou roli při tom, aby byla prezentace poutavá a atraktivní pro diváky. Aspose.Slides for Android via Java nabízí širokou škálu možností, jak přidat animaci do PowerPoint prezentace:

- aplikovat různé typy animačních efektů PowerPointu na tvary, grafy, tabulky, OLE objekty a další prvky prezentace.
- použít několik animačních efektů PowerPointu na jednom tvaru.
- použít časovou osu animace k řízení animačních efektů.
- vytvořit vlastní animaci.

V Aspose.Slides for Android via Java lze na tvary použít různé animační efekty. Protože je každý prvek na snímku, včetně textu, obrázků, OLE objektu, tabulky atd., považován za tvar, můžeme na každém prvku snímku aplikovat animační efekt.

## **Animační efekty**
Aspose.Slides podporuje **více než 150 animačních efektů**, včetně základních efektů jako Bounce, PathFootball, Zoom a specifických efektů jako OLEObjectShow, OLEObjectOpen. Úplný seznam animačních efektů najdete v [**EffectType**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effecttype/)enumeration.

Dále lze tyto animační efekty kombinovat s následujícími:

- [ColorEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SetEffect)

## **Vlastní animace**
Je možné vytvořit vlastní **animace** v Aspose.Slides.  
To lze dosáhnout kombinací několika chování do nové vlastní animace.

[**Behavior**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Behavior) je stavební jednotka jakéhokoli animačního efektu PowerPointu.  
Všechny animační efekty jsou vlastně souborem chování složených do jedné strategie.  
Můžete kombinovat chování do vlastní animace jednou a znovu ji použít v dalších prezentacích.  
Pokud přidáte nové chování do standardního animačního efektu PowerPointu, vytvoříte další vlastní animaci.  
Například můžete přidat opakování chování k animaci, aby se několikrát zopakovala.

[**Animation Point**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Point) je bod, kde by mělo být chování použito.

## **Časová osa animace**
[**Sequence**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Sequence) je kolekce animačních efektů aplikovaných na konkrétní tvar.

[**Timeline**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/AnimationTimeLine) je sada Sekvencí použitých v konkrétním snímku. Jedná se o animační engine, který je k dispozici od PowerPointu 2002. Ve starších verzích PowerPointu bylo obtížné přidávat animační efekty do prezentace, což bylo možné pouze pomocí různých obcházek. Timeline nahrazuje starou třídu AnimationSettings a poskytuje přehlednější objektový model pro animaci v PowerPointu. Jeden snímek může mít pouze jednu časovou osu animace.

## **Interaktivní animace**
[**Trigger**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/EffectTriggerType) umožňuje definovat akce uživatele (např. kliknutí tlačítka), které spustí konkrétní animaci. Triggery byly přidány jen v nejnovější verzi PowerPointu.

## **Animace tvarů**
Aspose.Slides umožňuje aplikovat animaci na tvary, kterými mohou být text, obdélník, čára, rámeček, OLE objekt atd.

{{% alert color="info" %}} 
Více informací [**O animaci tvarů**](/slides/cs/androidjava/shape-animation/).
{{% /alert %}}

## **Animované grafy**
Pro vytvoření animovaných grafů byste měli použít stejné třídy jako pro tvary. Nicméně je možné použít animaci PowerPointu pouze na kategorie grafu nebo řady grafu. Můžete také aplikovat animační efekt na prvek kategorie nebo na prvek řady.

{{% alert color="info" %}} 
Více informací [**O animovaných grafech**](/slides/cs/androidjava/animated-charts/).
{{% /alert %}}

## **Animovaný text**
Kromě animovaného textu je také možné aplikovat animaci na odstavec.

{{% alert color="info" %}} 
Více informací [**O animovaném textu**](/slides/cs/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

### Zachovají se animace při exportu do PDF?

Ne. PDF je statický formát, takže animace a [přechody snímků](/slides/cs/androidjava/slide-transition/) se nepřehrávají. Pokud potřebujete pohyb, exportujte do [HTML5](/slides/cs/androidjava/export-to-html5/), [animovaného GIFu](/slides/cs/androidjava/convert-powerpoint-to-animated-gif/) nebo [videa](/slides/cs/androidjava/convert-powerpoint-to-video/).

### Mohu převést animovanou prezentaci na video a ovládat snímkovou frekvenci a velikost rámce?

Ano. Můžete [vyrenderovat prezentaci jako snímky](/slides/cs/androidjava/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), s výběrem FPS a rozlišení. Animace a přechody snímků jsou během renderování přehrávány.

### Zůstanou animace nedotčeny při práci s ODP (nejen PPTX)?

Formáty PPT, PPTX i ODP jsou podporovány pro [čtení](/slides/cs/androidjava/open-presentation/) a [zápis](/slides/cs/androidjava/save-presentation/), ale rozdíly ve formátu mohou způsobit, že některé efekty vypadají nebo se chovají mírně odlišně. Ověřte kritické případy pomocí reálných vzorků.