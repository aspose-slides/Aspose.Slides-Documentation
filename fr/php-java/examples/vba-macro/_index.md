---
title: MacroVBA
type: docs
weight: 150
url: /fr/php-java/examples/elements/vba-macro/
keywords:
- macro vba
- ajouter macro vba
- accéder macro vba
- supprimer macro vba
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Travaillez avec les macros VBA en PHP à l’aide d’Aspose.Slides : ajoutez ou modifiez des projets et des modules, signez ou supprimez des macros, et enregistrez des présentations au format PPT, PPTX et ODP."
---
Illustre comment ajouter, accéder et supprimer des macros VBA à l’aide de **Aspose.Slides for PHP via Java**.

## **Ajouter une macro VBA**

Créez une présentation avec un projet VBA et un module de macro simple.

```php
function addVbaMacro() {
    $presentation = new Presentation();
    try {
        $presentation->setVbaProject(new VbaProject());

        $module = $presentation->getVbaProject()->getModules()->addEmptyModule("Module");
        $module->setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        $presentation->save("vba_macro.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accéder à une macro VBA**

Récupérez le premier module du projet VBA.

```php
function accessVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        $firstModule = $presentation->getVbaProject()->getModules()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Supprimer une macro VBA**

Supprimez un module du projet VBA.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Supposant qu'il y ait au moins un module dans le projet VBA.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```