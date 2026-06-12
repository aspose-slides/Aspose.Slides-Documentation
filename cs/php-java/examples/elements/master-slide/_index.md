---
title: Hlavní snímek
type: docs
weight: 30
url: /cs/php-java/examples/elements/master-slide/
keywords:
- hlavní snímek
- přidat hlavní snímek
- přístup k hlavnímu snímku
- odstranit hlavní snímek
- nepoužitý hlavní snímek
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte hlavní snímky v PHP pomocí Aspose.Slides: vytvářejte, upravujte, klonujte a formátujte motivy, pozadí, zástupné symboly pro sjednocení snímků v PowerPoint a OpenDocument."
---
Master slides tvoří nejvyšší úroveň hierarchie dědičnosti snímků v PowerPointu. **master slide** definuje společné designové prvky, jako jsou pozadí, loga a formátování textu. **Layout slides** dědí z master slide a **normal slides** dědí z layout slides.

Tento článek ukazuje, jak vytvářet, upravovat a spravovat master slide pomocí Aspose.Slides pro PHP přes Java.

## **Přidat master slide**

Tento příklad ukazuje, jak vytvořit nový master slide klonováním výchozího.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Zkopírujte výchozí hlavní snímek.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** Master slide poskytují způsob, jak použít konzistentní brandování nebo společné designové prvky napříč všemi snímky. Jakékoli změny provedené v master slide se automaticky projeví v závislých layout a normal slidech.

> 💡 **Tip 2:** Jakékoli tvary nebo formátování přidané do master slide jsou zděděny layout slide a následně všemi normal slide, které tyto rozložení používají.  
> Obrázek níže ilustruje, jak je textové pole přidané do master slide automaticky vykresleno na konečném snímku.

![Příklad dědičnosti master slide](master-slide-banner.png)

## **Přístup k master slide**

K master slide můžete přistupovat pomocí metody `Presentation::getMasters`. Zde je návod, jak je načíst a pracovat s nimi:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Přístup k prvnímu hlavnímu snímku.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Odstranit master slide**

Master slide lze odstranit buď podle indexu, nebo podle reference.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Odstranit podle indexu.
        $presentation->getMasters()->removeAt(0);

        // Nebo odstranit podle odkazu.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Odstranit nepoužívané master slide**

Některé prezentace obsahují master slide, které nejsou používány. Odstranění těchto snímků může pomoci snížit velikost souboru.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Odstranit všechny nepoužívané hlavní snímky (i ty označené jako Preserve).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Tip:** Použijte `removeUnused(true)`, abyste vyčistili nepoužívané master slide a minimalizovali velikost prezentace.