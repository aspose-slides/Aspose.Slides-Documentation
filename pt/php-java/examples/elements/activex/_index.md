---
title: ActiveX
type: docs
weight: 200
url: /pt/php-java/examples/elements/activex/
keywords:
- ActiveX
- controle ActiveX
- adicionar ActiveX
- acessar ActiveX
- remover ActiveX
- propriedades ActiveX
- exemplos de código
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como localizar, editar e remover controles ActiveX em PHP com Aspose.Slides, incluindo atualizações de propriedades para apresentações PowerPoint."
---
Demonstra como adicionar, acessar, remover e configurar controles ActiveX em uma apresentação usando **Aspose.Slides for PHP via Java**.

## **Adicionar um Controle ActiveX**

Inserir um novo controle ActiveX.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Adicionar um novo controle ActiveX.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // Liberar a apresentação.
        $presentation->dispose();
    }
}
```

## **Acessar um Controle ActiveX**

Ler informações do primeiro controle ActiveX no slide.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acessar o primeiro controle ActiveX.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // Liberar a apresentação.
        $presentation->dispose();
    }
}
```

## **Remover um Controle ActiveX**

Excluir um controle ActiveX existente do slide.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Remover o primeiro controle ActiveX.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // Liberar a apresentação.
        $presentation->dispose();
    }
}
```

## **Definir Propriedades do ActiveX**

Configurar várias propriedades do ActiveX.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumindo que o primeiro controle é o que adicionamos.
        $control = $slide->getControls()->get_Item(0);

        // Configurar propriedades.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // Liberar a apresentação.
        $presentation->dispose();
    }
}
```