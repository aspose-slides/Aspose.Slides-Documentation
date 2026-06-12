---
title: Získat celé pozadí snímku z prezentace jako obrázek
linktitle: Celé pozadí snímku
type: docs
weight: 95
url: /cs/php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- pozadí snímku
- konečné pozadí
- extrahovat pozadí
- celé pozadí
- pozadí na obrázek
- PPT pozadí
- PPTX pozadí
- ODP pozadí
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Extrahujte kompletní pozadí snímků jako obrázky z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java, zefektivňující vizuální pracovní postupy."
---
## **Přehled**

V prezentacích PowerPoint může být pozadí snímku tvořeno z více prvků, včetně obrázku pozadí snímku, motivu prezentace, barevného schématu a objektů umístěných na hlavním snímku nebo snímku rozvržení.

Tento článek ukazuje, jak pomocí Aspose.Slides extrahovat celé pozadí snímku jako obrázek. Protože neexistuje jediné metoda pro tento úkol, přístup zahrnuje klonování vybraného snímku do dočasné prezentace, odstranění tvarů snímku a následnou konverzi vzniklého pozadí snímku na obrázek.

## **Získání celého pozadí snímku**

Aspose.Slides for PHP via Java neposkytuje jednoduchou metodu pro extrahování celého pozadí snímku prezentace jako obrázku, ale můžete postupovat podle níže uvedených kroků:
1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte velikost snímku z prezentace.
1. Vyberte snímek.
1. Vytvořte dočasnou prezentaci.
1. Nastavte stejnou velikost snímku v dočasné prezentaci.
1. Zklonujte vybraný snímek do dočasné prezentace.
1. Odstraňte tvary ze zklonovaného snímku.
1. Převěďte zklonovaný snímek na obrázek.

Následující ukázkový kód extrahuje celé pozadí snímku prezentace jako obrázek.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```

## **Často kladené otázky**

**Zachovají se složité gradienty, textury nebo výplně obrázky z hlavního snímku v výsledném obrázku pozadí?**

Ano. Aspose.Slides vykresluje gradientové, obrázkové a texturové výplně definované na snímku, rozvržení nebo hlavním snímku. Pokud potřebujete izolovat vzhled od zděděných hlavních snímků, [nastavte vlastní pozadí](/slides/cs/php-java/presentation-background/) na aktuální snímek před exportem.

**Mohu přidat vodoznak do výsledného obrázku pozadí před jeho uložením?**

Ano. Můžete [přidat vodoznak](/slides/cs/php-java/watermark/) jako tvar nebo obrázek na pracovní [kopii snímku](/slides/cs/php-java/clone-slides/) (umístěnou za ostatní obsah) a poté exportovat. To vám umožní vygenerovat obrázek pozadí s vodoznakem zabudovaným do něj.

**Mohu získat pozadí pro konkrétní rozvržení nebo hlavní snímek, aniž by bylo svázáno s existujícím snímkem?**

Ano. Přistupte k požadovanému hlavnímu snímku nebo rozvržení, aplikujte jej na [dočasný snímek](/slides/cs/php-java/clone-slides/) s požadovanou velikostí a exportujte tento snímek, abyste získali pozadí odvozené z tohoto rozvržení nebo hlavního snímku.

**Existují licenční omezení, která ovlivňují export obrázků?**

Funkce vykreslování jsou plně k dispozici s [platnou licencí](/slides/cs/php-java/licensing/). V režimu hodnocení může výstup obsahovat omezení, například vodoznak. Aktivujte licenci jednou na proces před spouštěním dávkových exportů.