---
title: Rozvrhový snímek
type: docs
weight: 20
url: /cs/nodejs-java/examples/elements/layout-slide/
keywords:
- ukázka kódu
- rozvrhový snímek
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte rozvrhové snímky v Aspose.Slides pro Node.js: vybírejte, aplikujte a přizpůsobujte rozvrhy snímků, zástupné prvky a hlavní snímky s příklady pro prezentace PPT, PPTX a ODP."
---
Tento článek demonstruje, jak pracovat s **Layout Slides** v Aspose.Slides pro Node.js přes Java. Rozvrhový snímek definuje design a formátování zděděné normálními snímky. Můžete přidávat, přistupovat, klonovat a odstraňovat rozvrhové snímky a také vyčistit nepoužívané, aby se snížila velikost prezentace.

## **Přidat rozvrhový snímek**

Můžete vytvořit vlastní rozvrhový snímek pro definování opakovaně použitelného formátování.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Vytvořte rozvrhový snímek s prázdným typem rozvrhu a vlastním názvem.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Poznámka 1:** Rozvrhové snímky fungují jako šablony pro jednotlivé snímky. Můžete definovat společné prvky jednou a znovu je použít v mnoha snímcích.

> 💡 **Poznámka 2:** Když přidáte tvary nebo text do rozvrhového snímku, všechny snímky založené na tomto rozvrhu automaticky zobrazí tento sdílený obsah.
> Níže uvedený snímek ukazuje dva snímky, z nichž každý dědí textové pole ze stejného rozvrhového snímku.

![Snímky dědící obsah rozvrhu](layout-slide-result.png)

## **Přístup k rozvrhovému snímku**

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Přístup k rozvrhovému snímku podle indexu.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Přístup k rozvrhovému snímku podle typu.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit rozvrhový snímek**

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Získejte rozvrhový snímek podle typu a odstraňte jej.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit nepoužívané rozvrhové snímky**

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Automaticky odstraní všechny rozvrhové snímky, na které neodkazuje žádný snímek.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Klonovat rozvrhový snímek**

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Získejte existující rozvrhový snímek podle typu.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Klonujte rozvrhový snímek na konec kolekce rozvrhových snímků.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Souhrn:** Rozvrhové snímky jsou výkonné nástroje pro správu konzistentního formátování napříč snímky. Aspose.Slides umožňuje plnou kontrolu nad vytvářením, správou a optimalizací rozvrhových snímků.