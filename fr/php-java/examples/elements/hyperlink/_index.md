---
title: Hyperlien
type: docs
weight: 130
url: /fr/php-java/examples/elements/hyperlink/
keywords:
- hyperlien
- ajouter hyperlien
- accéder hyperlien
- supprimer hyperlien
- mettre à jour hyperlien
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Ajouter, modifier et supprimer des hyperliens en PHP avec Aspose.Slides : texte de lien, formes, diapositives, URL et e‑mail ; définir les cibles et les actions pour PPT, PPTX et ODP."
---
Démontre comment ajouter, accéder, supprimer et mettre à jour des hyperliens sur des formes en utilisant **Aspose.Slides for PHP via Java**.

## **Ajouter un hyperlien**

Créez une forme rectangulaire avec un hyperlien pointant vers un site Web externe.

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accéder à un hyperlien**

Lisez les informations d'hyperlien à partir de la portion de texte d'une forme.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // En supposant que la première forme contient le lien hypertexte.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Supprimer un hyperlien**

Supprimez l'hyperlien du texte d'une forme.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // En supposant que la première forme contient le lien hypertexte.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

```

## **Mettre à jour un hyperlien**

Modifiez la cible d'un hyperlien existant. Utilisez `HyperlinkManager` pour modifier le texte contenant déjà un hyperlien, ce qui imite la façon dont PowerPoint met à jour les hyperliens de manière sécurisée.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // En supposant que la première forme contient le lien hypertexte.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // Modifier un hyperlien dans le texte existant doit être fait via
        // HyperlinkManager plutôt que de définir la propriété directement.
        // Ceci imite la façon dont PowerPoint met à jour les hyperliens en toute sécurité.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```