---
title: MacroVBA
type: docs
weight: 150
url: /pt/php-java/examples/elements/vba-macro/
keywords:
- macro vba
- adicionar macro vba
- acessar macro vba
- remover macro vba
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Trabalhe com macros VBA em PHP usando Aspose.Slides: adicione ou edite projetos e módulos, assine ou remova macros e salve apresentações em PPT, PPTX e ODP."
---
Ilustra como adicionar, acessar e remover macros VBA usando **Aspose.Slides for PHP via Java**.

## **Adicionar uma Macro VBA**

Crie uma apresentação com um projeto VBA e um módulo de macro simples.

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

## **Acessar uma Macro VBA**

Recupere o primeiro módulo do projeto VBA.

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

## **Remover uma Macro VBA**

Exclua um módulo do projeto VBA.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Assumindo que há pelo menos um módulo no projeto VBA.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```