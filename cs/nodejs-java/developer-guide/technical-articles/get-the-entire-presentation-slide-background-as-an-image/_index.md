---
title: Získat celé pozadí snímku z prezentace jako obrázek
linktitle: Celé pozadí snímku
type: docs
weight: 95
url: /cs/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Extrahujte úplná pozadí snímků jako obrázky z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js přes Java, zjednodušující vizuální workflow."
---
## **Přehled**

V prezentacích PowerPoint může pozadí snímku být vytvořeno z několika prvků, včetně obrázku pozadí snímku, motivu prezentace, barevného schématu a objektů umístěných na hlavním snímku nebo rozložení snímku.

Tento článek ukazuje, jak pomocí Aspose.Slides extrahovat celé pozadí snímku jako obrázek. Protože neexistuje jediné metoda pro tento úkol, postup zahrnuje klonování vybraného snímku do dočasné prezentace, odstranění tvarů snímku a následnou konverzi vzniklého pozadí snímku na obrázek.

## **Získání celého pozadí snímku**

Aspose.Slides pro Node.js přes Java neposkytuje jednoduchou metodu pro extrakci celého pozadí snímku prezentace jako obrázku, ale můžete postupovat podle níže uvedených kroků:
1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte velikost snímku z prezentace.
1. Vyberte snímek.
1. Vytvořte dočasnou prezentaci.
1. Nastavte stejnou velikost snímku v dočasné prezentaci.
1. Naklonujte vybraný snímek do dočasné prezentace.
1. Odstraňte tvary z naklonovaného snímku.
1. Převěďte naklonovaný snímek na obrázek.

Následující ukázkový kód extrahuje celé pozadí snímku prezentace jako obrázek.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```

## **FAQ**

**Budou složité přechody, textury nebo výplně obrázky z hlavního snímku zachovány v výsledném obrázku pozadí?**

Ano. Aspose.Slides vykresluje gradientní, obrázkové a texturové výplně definované na snímku, rozložení nebo hlavním snímku. Pokud potřebujete oddělit vzhled od zděděných hlav, [nastavte vlastní pozadí](/slides/cs/nodejs-java/presentation-background/) na aktuálním snímku před exportem.

**Mohu přidat vodoznak do výsledného obrázku pozadí před jeho uložením?**

Ano. Můžete [přidat vodoznak](/slides/cs/nodejs-java/watermark/) jako tvar nebo obrázek na pracovní [kopii snímku](/slides/cs/nodejs-java/clone-slides/) (umístěnou za ostatním obsahem) a poté exportovat. To vám umožní vytvořit obrázek pozadí s vodoznakem vloženým.

**Mohu získat pozadí pro konkrétní rozložení či hlavní snímek, aniž by bylo svázáno s existujícím snímkem?**

Ano. Přistupte k požadovanému hlavnímu snímku nebo rozložení, aplikujte jej na [dočasný snímek](/slides/cs/nodejs-java/clone-slides/) s potřebnou velikostí a exportujte tento snímek, abyste získali pozadí odvozené od tohoto rozložení či hlavního snímku.

**Existují licenční omezení, která ovlivňují export obrázků?**

Funkce renderování jsou plně k dispozici s [platnou licencí](/slides/cs/nodejs-java/licensing/). V režimu hodnocení může výstup obsahovat omezení, například vodoznak. Aktivujte licenci jednou na proces před prováděním hromadných exportů.