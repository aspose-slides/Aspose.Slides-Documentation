---
title: Získání celého pozadí snímku z prezentace jako obrázku
linktitle: Celé pozadí snímku
type: docs
weight: 95
url: /cs/androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- pozadí snímku
- finální pozadí
- extrahovat pozadí
- celé pozadí
- pozadí na obrázek
- PPT pozadí
- PPTX pozadí
- ODP pozadí
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Extrahujte kompletní pozadí snímků jako obrázky z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Android přes Java, zjednodušením vizuálních pracovních postupů."
---
## **Přehled**

V prezentacích PowerPoint může pozadí snímku být tvořeno z několika prvků, včetně obrázku pozadí snímku, motivu prezentace, barevného schématu a objektů umístěných na hlavním snímku nebo snímku rozvržení.

Tento článek ukazuje, jak pomocí Aspose.Slides pro .NET extrahovat celé pozadí snímku jako obrázek. Protože pro tento úkol neexistuje jediná metoda, postup zahrnuje klonování vybraného snímku do dočasné prezentace, odstranění tvarů snímku a následnou konverzi výsledného pozadí snímku na obrázek.

## **Získání celého pozadí snímku**

Aspose.Slides pro Android přes Java neposkytuje jednoduchou metodu pro extrahování celého pozadí snímku prezentace jako obrázku, ale můžete postupovat podle níže uvedených kroků:
1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte velikost snímku z prezentace.
1. Vyberte snímek.
1. Vytvořte dočasnou prezentaci.
1. Nastavte stejnou velikost snímku v dočasné prezentaci.
1. Klonujte vybraný snímek do dočasné prezentace.
1. Odstraňte tvary z klonovaného snímku.
1. Převeďte klonovaný snímek na obrázek.

Následující ukázkový kód extrahuje celé pozadí snímku prezentace jako obrázek.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **Často kladené otázky**

**Zůstanou složité gradienty, textury nebo výplně obrázky z hlavního snímku zachovány v výsledném obrázku pozadí?**

Ano. Aspose.Slides vykresluje gradientové, obrázkové a texturové výplně definované na snímku, rozvržení nebo hlavním snímku. Pokud potřebujete oddělit vzhled od zděděných hlavních snímků, [nastavte vlastní pozadí](/slides/cs/androidjava/presentation-background/) na aktuálním snímku před exportem.

**Mohu přidat vodoznak do výsledného obrázku pozadí před jeho uložením?**

Ano. Můžete [přidat vodoznak](/slides/cs/androidjava/watermark/) jako tvar nebo obrázek do pracovní [kopie snímku](/slides/cs/androidjava/clone-slides/) (umístěné za ostatní obsah) a poté exportovat. To vám umožní vytvořit obrázek pozadí s vodoznakem zakomponovaným.

**Mohu získat pozadí pro konkrétní rozvržení nebo hlavní snímek, aniž bych ho vázal na existující snímek?**

Ano. Přistupte k požadovanému hlavnímu snímku nebo rozvržení, aplikujte jej na [dočasný snímek](/slides/cs/androidjava/clone-slides/) s požadovanou velikostí a exportujte tento snímek, abyste získali pozadí odvozené od daného rozvržení nebo hlavního snímku.

**Existují omezení licencování, která ovlivňují export obrázků?**

Funkce vykreslování jsou plně k dispozici s [platnou licencí](/slides/cs/androidjava/licensing/). V režimu hodnocení může výstup obsahovat omezení, například vodoznak. Aktivujte licenci jednou na proces před spuštěním hromadných exportů.