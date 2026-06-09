---
title: Hyperlink
type: docs
weight: 130
url: /pt/php-java/examples/elements/hyperlink/
keywords:
- hyperlink
- adicionar hyperlink
- acessar hyperlink
- remover hyperlink
- atualizar hyperlink
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Adicionar, editar e remover hyperlinks em PHP com Aspose.Slides: texto de link, formas, slides, URLs e email; definir destinos e ações para PPT, PPTX e ODP."
---
Demonstrar a adição, o acesso, a remoção e a atualização de hyperlinks em formas usando **Aspose.Slides for PHP via Java**.

## **Adicionar um Hyperlink**

Crie uma forma retangular com um hyperlink que aponta para um site externo.

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

## **Acessar um Hyperlink**

Leia as informações do hyperlink a partir da parte de texto de uma forma.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumindo que a primeira forma contém o hyperlink.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover um Hyperlink**

Remova o hyperlink do texto de uma forma.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumindo que a primeira forma contém o hyperlink.
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

## **Atualizar um Hyperlink**

Altere o destino de um hyperlink existente. Use `HyperlinkManager` para modificar o texto que já contém um hyperlink, simulando como o PowerPoint atualiza hyperlinks de forma segura.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumindo que a primeira forma contém o hyperlink.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // Alterar um hyperlink dentro do texto existente deve ser feito via
        // HyperlinkManager ao invés de definir a propriedade diretamente.
        // Isso imita como o PowerPoint atualiza hyperlinks de forma segura.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```