---
title: ActiveX
type: docs
weight: 200
url: /fr/php-java/examples/elements/activex/
keywords:
- ActiveX
- contrôle ActiveX
- ajouter ActiveX
- accéder à ActiveX
- supprimer ActiveX
- propriétés ActiveX
- exemples de code
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez comment trouver, modifier et supprimer des contrôles ActiveX en PHP avec Aspose.Slides, y compris les mises à jour de propriétés pour les présentations PowerPoint."
---
Démontre comment ajouter, accéder, supprimer et configurer des contrôles ActiveX dans une présentation en utilisant **Aspose.Slides for PHP via Java**.

## **Ajouter un contrôle ActiveX**

Insérer un nouveau contrôle ActiveX.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Ajouter un nouveau contrôle ActiveX.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // Libérer la présentation.
        $presentation->dispose();
    }
}
```

## **Accéder à un contrôle ActiveX**

Lire les informations du premier contrôle ActiveX sur la diapositive.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accéder au premier contrôle ActiveX.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // Libérer la présentation.
        $presentation->dispose();
    }
}
```

## **Supprimer un contrôle ActiveX**

Supprimer un contrôle ActiveX existant de la diapositive.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Supprimer le premier contrôle ActiveX.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // Libérer la présentation.
        $presentation->dispose();
    }
}
```

## **Définir les propriétés ActiveX**

Configurer plusieurs propriétés ActiveX.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supposant que le premier contrôle est celui que nous avons ajouté.
        $control = $slide->getControls()->get_Item(0);

        // Configurer les propriétés.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // Libérer la présentation.
        $presentation->dispose();
    }
}
```