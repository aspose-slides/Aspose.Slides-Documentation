---
title: Získání celého pozadí snímku z prezentace jako obrázku
linktitle: Celé pozadí snímku
type: docs
weight: 95
url: /cs/java/get-the-entire-presentation-slide-background-as-an-image/
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
- Java
- Aspose.Slides
description: "Extrahujte úplná pozadí snímků jako obrázky z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Java, zjednodušující vizuální pracovní postupy."
---
## **Přehled**

V PowerPoint prezentacích může být pozadí snímku tvořeno z několika prvků, včetně obrázku pozadí snímku, motivu prezentace, schématu barev a objektů umístěných na hlavním nebo rozložení snímku.

Tento článek ukazuje, jak pomocí Aspose.Slides pro .NET extrahovat celé pozadí snímku jako obrázek. Protože neexistuje jediná metoda pro tento úkol, postup zahrnuje klonování vybraného snímku do dočasné prezentace, odstranění tvarů ze snímku a následný převod vzniklého pozadí snímku na obrázek.

## **Získání celého pozadí snímku**

Aspose.Slides pro Java neposkytuje jednoduchou metodu pro extrahování celého pozadí snímku prezentace jako obrázku, ale můžete postupovat podle níže uvedených kroků:
1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte velikost snímku z prezentace.
1. Vyberte snímek.
1. Vytvořte dočasnou prezentaci.
1. Nastavte stejnou velikost snímku v dočasné prezentaci.
1. Naklonujte vybraný snímek do dočasné prezentace.
1. Odstraňte tvary z naklonovaného snímku.
1. Převod naklonovaného snímku na obrázek.

Následující ukázkový kód extrahuje celé pozadí snímku prezentace jako obrázek.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **FAQ**

**Zachovají se v výsledném obrázku pozadí složité přechody, textury nebo výplně obrázky z hlavního snímku?**

Ano. Aspose.Slides vykresluje přechodové, obrázkové a texturové výplně definované na snímku, rozložení nebo hlavním snímku. Pokud potřebujete oddělit vzhled od zděděných hlavních snímků, [nastavte vlastní pozadí](/slides/cs/java/presentation-background/) na aktuální snímek před exportem.

**Mohu přidat vodoznak do výsledného obrázku pozadí před jeho uložením?**

Ano. Můžete [přidat vodoznak](/slides/cs/java/watermark/) jako tvar nebo obrázek na pracovní [kopii snímku](/slides/cs/java/clone-slides/) (umístěnou za ostatní obsah) a poté exportovat. To vám umožní vytvořit obrázek pozadí s vodoznakem zabudovaným.

**Mohu získat pozadí pro konkrétní rozložení nebo hlavní snímek, aniž bych jej spojoval s existujícím snímkem?**

Ano. Přistupte k požadovanému hlavnímu snímku nebo rozložení, aplikujte jej na [dočasný snímek](/slides/cs/java/clone-slides/) s požadovanou velikostí a exportujte tento snímek, abyste získali pozadí odvozené od daného rozložení nebo hlavního snímku.

**Existují licenční omezení, která ovlivňují export obrázků?**

Funkce vykreslování jsou plně dostupné s [platnou licencí](/slides/cs/java/licensing/). V režimu hodnocení může výstup obsahovat omezení, například vodoznak. Aktivujte licenci jednou na proces před spuštěním hromadných exportů.