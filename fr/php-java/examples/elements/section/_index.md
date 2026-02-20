---
title: Section
type: docs
weight: 90
url: /fr/php-java/examples/elements/section/
keywords:
- section
- section de diapositive
- ajouter une section
- accéder à une section
- supprimer une section
- renommer une section
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Gérez les sections de diapositives en PHP avec Aspose.Slides : créez, renommez, réorganisez facilement, déplacez les diapositives entre les sections et contrôlez la visibilité pour PPT, PPTX et ODP."
---
Exemples de gestion des sections de présentation — ajouter, accéder, supprimer et renommer programmatiquement en utilisant **Aspose.Slides for PHP via Java**.

## **Ajouter une section**

Créer une section qui commence à une diapositive spécifique.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Spécifiez la diapositive qui marque le début de la section.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accéder à une section**

Lire les informations de la section d’une présentation.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Accéder à une section par indice.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Supprimer une section**

Supprimer une section précédemment ajoutée.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Supprimer la section.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Renommer une section**

Modifier le nom d’une section existante.

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```