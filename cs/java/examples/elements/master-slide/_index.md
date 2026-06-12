---
title: "Hlavní snímek"
type: docs
weight: 30
url: /cs/java/examples/elements/master-slide/
keywords:
- "příklad kódu"
- "master snímek"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Java"
- "Aspose.Slides"
description: "Prozkoumejte příklady master snímků Aspose.Slides pro Java: vytvářejte, upravujte a stylizujte mastery, zástupné symboly a motivy v PPT, PPTX a ODP s přehledným Java kódem."
---
Master slides tvoří nejvyšší úroveň hierarchie dědičnosti snímků v PowerPointu. **master slide** definuje společné designové prvky, jako jsou pozadí, loga a formátování textu. **Layout slides** dědí z master slides a **normal slides** dědí z layout slides.

Tento článek ukazuje, jak vytvářet, upravovat a spravovat master slides pomocí Aspose.Slides pro Java.

## **Přidat master slide**

Tento příklad ukazuje, jak vytvořit nový master slide klonováním výchozího. Poté přidá banner s názvem společnosti ke všem snímkům prostřednictvím dědičnosti rozvržení.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Zkopírujte výchozí master slide.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Přidejte banner s názvem společnosti na vrchol master slide.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Přiřaďte nový master slide k layout slide.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Přiřaďte layout slide k prvnímu snímku v prezentaci.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Poznámka 1:** Master slides poskytují způsob, jak aplikovat jednotné brandování nebo sdílené designové prvky napříč všemi snímky. Jakékoli změny provedené v masteru se automaticky projeví na závislých layoutových a normálních snímcích.
> 
> 💡 **Poznámka 2:** Všechny tvary nebo formátování přidané do master slide jsou zděděny layout slides a následně všemi normal slides používajícími tyto rozvržení.  
> Obrázek níže ilustruje, jak je textové pole přidané na master slide automaticky vykresleno na finálním snímku.

![Příklad dědičnosti master](master-slide-banner.png)

## **Přístup k master slide**

K master slides můžete přistupovat pomocí kolekce masterů prezentace. Zde je návod, jak je načíst a s nimi pracovat:

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

## **Odstranit master slide**

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Odstraňte master slide podle indexu.
        presentation.getMasters().removeAt(0);

        // Odstraňte master slide podle reference.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit nepoužívané master slides**

Některé prezentace obsahují master slides, které nejsou používány. Odstranění těchto snímků může pomoci snížit velikost souboru.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Odstraňte všechny nepoužívané master slide (i ty označené jako Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```