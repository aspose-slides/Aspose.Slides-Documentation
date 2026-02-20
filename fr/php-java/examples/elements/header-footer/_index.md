---
title: En-tête et pied de page
type: docs
weight: 220
url: /fr/php-java/examples/elements/header-footer/
keywords:
- en-tête et pied de page
- ajouter en-tête et pied de page
- mettre à jour en-tête et pied de page
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Contrôlez les en-têtes et pieds de page en PHP avec Aspose.Slides: ajoutez ou modifiez la date/heure, les numéros de diapositive et le texte du pied de page, affichez ou masquez les espaces réservés dans les formats PPT, PPTX et ODP."
---
Montre comment ajouter des pieds de page et mettre à jour les espaces réservés de date et d’heure en utilisant **Aspose.Slides for PHP via Java**.

## **Ajouter un pied de page**

Ajoutez du texte dans la zone de pied de page d’une diapositive et rendez-le visible.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Mettre à jour la date et l’heure**

Modifiez l’espace réservé de date et d’heure sur une diapositive.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```