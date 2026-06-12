---
title: Hlavní snímek
type: docs
weight: 30
url: /cs/nodejs-java/examples/elements/master-slide/
keywords:
- ukázka kódu
- hlavní snímek
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Prozkoumejte příklady hlavních snímků Aspose.Slides pro Node.js: vytvářejte, upravujte a stylizujte hlavní snímky, zástupné prvky a motivy v PPT, PPTX a ODP pomocí přehledného kódu."
---
Master snímky tvoří nejvyšší úroveň hierarchie dědičnosti snímků v PowerPointu. **Hlavní snímek** definuje společné designové prvky, jako jsou pozadí, loga a formátování textu. **Rozvržení snímků** dědí z hlavních snímků a **normální snímky** dědí z rozvržení snímků.

Tento článek ukazuje, jak vytvářet, upravovat a spravovat hlavní snímky pomocí Aspose.Slides pro Node.js prostřednictvím Javy.

## **Přidat hlavní snímek**

Tento příklad ukazuje, jak vytvořit nový hlavní snímek klonováním výchozího. Poté přidá banner s názvem společnosti ke všem snímkům prostřednictvím dědičnosti rozvržení.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Klonujte výchozí hlavní snímek.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // Přidejte banner s názvem společnosti na vrchol hlavního snímku.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // Přiřaďte nový hlavní snímek k rozvržení snímku.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Přiřaďte rozvržení snímku k prvnímu snímku v prezentaci.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Poznámka 1:** Hlavní snímky poskytují možnost aplikovat konzistentní branding nebo sdílené designové prvky na všechny snímky. Jakékoli změny provedené v hlavním snímku se automaticky projeví na závislých rozvrženích a normálních snímcích.  
> 
> 💡 **Poznámka 2:** Jakékoli tvary nebo formátování přidané do hlavního snímku jsou zděděny rozvrženími snímků a následně všemi normálními snímky používajícími tato rozvržení.  
> The image below illustrates how a text box added on a master slide is automatically rendered on the final slide.

![Příklad dědičnosti hlavního snímku](master-slide-banner.png)

## **Přístup k hlavnímu snímku**

K hlavním snímkům můžete přistupovat pomocí kolekce hlavních snímků prezentace. Zde je návod, jak je načíst a s nimi pracovat:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Změňte typ pozadí.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit hlavní snímek**

Hlavní snímky lze odstranit buď podle indexu, nebo podle reference.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Odstraňte hlavní snímek podle indexu.
        presentation.getMasters().removeAt(0);

        // Odstraňte hlavní snímek podle reference.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit nepoužité hlavní snímky**

Některé prezentace obsahují hlavní snímky, které nejsou používány. Odstranění těchto snímků může pomoci snížit velikost souboru.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Odstraňte všechny nepoužívané hlavní snímky (i ty označené jako Preserve).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```