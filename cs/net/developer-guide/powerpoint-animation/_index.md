---
title: Vylepšete PowerPoint prezentace pomocí animací v .NET
linktitle: Animace PowerPoint
type: docs
weight: 150
url: /cs/net/powerpoint-animation/
keywords:
- přidat animaci
- aktualizovat animaci
- změnit animaci
- odstranit animaci
- spravovat animaci
- řídit animaci
- animační efekt
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
- PowerPoint prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte možnosti Aspose.Slides pro .NET při práci s animacemi v PowerPointu. Tento obecný přehled zdůrazňuje klíčové funkce a poskytuje poznatky pro vylepšení vašich prezentací."
---
## **Úvod**

Protože prezentace mají sloužit k předvedení něčeho, jejich vizuální vzhled a interaktivní chování jsou při tvorbě vždy zohledňovány.

**PowerPoint animation** hraje důležitou roli při tom, aby prezentace byla poutavá a zajímavá pro diváky. Aspose.Slides for .NET poskytuje širokou škálu možností, jak do PowerPoint prezentací přidat animace:

- Použít různé typy animačních efektů PowerPoint na objekty, grafy, tabulky, OLE objekty a další prvky prezentace.
- Použít několik animačních efektů PowerPoint na jeden objekt.
- Využít časovou osu animace k řízení animačních efektů.
- Vytvořit vlastní animace.

V Aspose.Slides for .NET lze na objekty aplikovat různé animační efekty. Protože je každý prvek na snímku, včetně textu, obrázků, OLE objektů a tabulek, považován za objekt, lze animační efekty použít na libovolný prvek snímku.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/) namespace poskytuje třídy pro práci s animacemi PowerPoint.

## **Efekty animace**

Aspose.Slides podporuje **150+ animačních efektů**, včetně základních efektů jako Bounce, PathFootball a Zoom, a také specifických efektů jako OLEObjectShow a OLEObjectOpen. Kompletní seznam animačních efektů najdete v enumeraci [EffectType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effecttype).

Tyto animační efekty lze také kombinovat s následujícími:

- [ColorEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/seteffect)

## **Vlastní animace**

Pro kompletní příklady v C#, které vytvářejí, kontrolují a upravují chování a editovatelné dráhy pohybu, viz [Custom Animation](/slides/cs/net/custom-animation/).

V Aspose.Slides je možné vytvořit vlastní **custom animations**. Toho lze dosáhnout kombinací několika chování do nové vlastní animace.

[Behavior](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/behavior) je stavební blok animačního efektu PowerPoint. Kombinujte chování pro přizpůsobení efektu nebo přidejte chování pro rozšíření předdefinovaného efektu. Opakování je konfigurováno pomocí časových nastavení, nikoli samostatným chováním opakování.

[Animation Point](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/point) je bod, ve kterém by mělo být chování aplikováno.

## **Časová osa animace**

[Sequence](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/sequence) je kolekce animačních efektů, které mohou cílit na různé objekty.

[Timeline](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/animationtimeline) je sada sekvencí použitých na konkrétním snímku. Jedná se o animační engine zavedený v PowerPoint 2002. Ve starších verzích PowerPointu bylo přidávání animačních efektů do prezentací obtížné a dosahovalo se jen různých obcházek. Časová osa nahrazuje starou třídu AnimationSettings a poskytuje přehlednější objektový model pro animace PowerPoint. Snímek může mít pouze jednu časovou osu animace.

## **Interaktivní animace**

[Trigger](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effecttriggertype) vám umožňuje definovat uživatelské akce (např. kliknutí na tlačítko), které spustí konkrétní animaci. Triggery byly zavedeny v nejnovější verzi PowerPoint.

## **Animace tvarů**

Aspose.Slides umožňuje aplikovat animace na objekty, což může zahrnovat text, obdélníky, čáry, rámečky, OLE objekty a další.

{{% alert color="info" title="Note" %}}
Read more [**O animaci tvarů**](/slides/cs/net/shape-animation/).
{{% /alert %}}

## **Animované grafy**

Pro vytvoření animovaných grafů byste měli použít stejné třídy jako pro objekty. Nicméně animace PowerPoint mohou být aplikovány jen na kategorie grafu nebo série grafu. Můžete také aplikovat animační efekty na prvek kategorie nebo prvek série.

{{% alert color="info" title="Note" %}}
Read more [**O animovaných grafech**](/slides/cs/net/animated-charts/).
{{% /alert %}}

## **Animovaný text**

Kromě animování textu můžete animovat i odstavec.

{{% alert color="info" title="Note" %}}
Read more [**O animovaném textu**](/slides/cs/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Zůstanou animace zachovány při exportu do PDF?**

Ne. PDF je statický formát, takže animace a [slide transitions](/slides/cs/net/slide-transition/) se nepřehrají. Pokud potřebujete pohyb, exportujte místo toho do [HTML5](/slides/cs/net/export-to-html5/), [animated GIF](/slides/cs/net/convert-powerpoint-to-animated-gif/) nebo [video](/slides/cs/net/convert-powerpoint-to-video/).

**Mohu převést animovanou prezentaci na video a ovládat počet snímků za sekundu a velikost snímku?**

Ano. Můžete [render the presentation as frames](/slides/cs/net/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), přičemž si zvolíte FPS a rozlišení. Animace a přechody snímků jsou při renderování přehrávány.

**Zůstanou animace nedotčeny při práci s ODP (nejen PPTX)?**

PPT, PPTX i ODP jsou podporovány pro [reading](/slides/cs/net/open-presentation/) i [writing](/slides/cs/net/save-presentation/), ale neznamená to, že se animace zachovají. Data vlastních animací mohou být při konverzi do ODP ztracena. Viz [Custom Animation](/slides/cs/net/custom-animation/) pro ověřený příklad a omezení formátů.