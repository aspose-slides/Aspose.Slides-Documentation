---
title: "Hlavní snímek"
type: docs
weight: 30
url: /cs/androidjava/examples/elements/master-slide/
keywords:
- "příklad kódu"
- "hlavní snímek"
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Prozkoumejte příklady hlavních snímků Aspose.Slides pro Android: vytvářejte, upravujte a stylizujte hlavní snímky, zástupné prvky a motivy v PPT, PPTX a ODP pomocí přehledného Java kódu."
---
Hlavní snímky tvoří nejvyšší úroveň hierarchie dědičnosti snímků v PowerPointu. **Hlavní snímek** definuje společné návrhové prvky, jako jsou pozadí, loga a formátování textu. **Rozložení snímků** dědí z hlavních snímků a **normální snímky** dědí z rozložení snímků.

Tento článek ukazuje, jak pomocí Aspose.Slides pro Android přes Java vytvářet, upravovat a spravovat hlavní snímky.

## **Přidat hlavní snímek**

Tento příklad ukazuje, jak vytvořit nový hlavní snímek klonováním výchozího. Poté přidá banner s názvem společnosti ke všem snímkům prostřednictvím dědičnosti rozložení.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Zkopírujte výchozí hlavní snímek.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Přidejte banner s názvem společnosti na vrchol hlavního snímku.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Přiřaďte nový hlavní snímek k rozložení snímku.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Přiřaďte rozložení snímku k prvnímu snímku v prezentaci.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Poznámka 1:** Hlavní snímky poskytují způsob, jak aplikovat jednotné značení nebo sdílené návrhové prvky na všechny snímky. Jakékoli změny provedené v hlavním snímku se automaticky projeví na závislých rozložení a normálních snímcích.

> 💡 **Poznámka 2:** Veškeré tvary nebo formátování přidané do hlavního snímku jsou děděny rozloženími a následně všemi normálními snímky, které tato rozložení používají.  
> Obrázek níže ilustruje, jak textové pole přidané na hlavní snímek je automaticky vykresleno na finálním snímku.

![Příklad dědičnosti hlavního snímku](master-slide-banner.png)

## **Přístup k hlavnímu snímku**

K hlavním snímkům můžete přistupovat pomocí kolekce hlavních snímků prezentace. Zde je návod, jak je načíst a s nimi pracovat:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Změňte typ pozadí.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Odebrat hlavní snímek**

Hlavní snímky lze odebrat buď podle indexu, nebo podle reference.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Odeberte hlavní snímek podle indexu.
        presentation.getMasters().removeAt(0);

        // Odeberte hlavní snímek podle reference.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Odebrat nepoužité hlavní snímky**

Některé prezentace obsahují hlavní snímky, které nejsou používány. Odebrání těchto snímků může pomoci snížit velikost souboru.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Odstraňte všechny nepoužité hlavní snímky (i ty označené jako Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```