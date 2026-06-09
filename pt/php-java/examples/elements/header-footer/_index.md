---
title: CabeçalhoRodapé
type: docs
weight: 220
url: /pt/php-java/examples/elements/header-footer/
keywords:
- cabeçalho rodapé
- adicionar cabeçalho rodapé
- atualizar cabeçalho rodapé
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Controle de cabeçalhos e rodapés em PHP com Aspose.Slides: adicione ou edite data/hora, números de slide e texto do rodapé, mostre ou oculte marcadores nos formatos PPT, PPTX e ODP."
---
Mostra como adicionar rodapés e atualizar marcadores de data e hora usando **Aspose.Slides for PHP via Java**.

## **Adicionar um Rodapé**

Adicione texto à área de rodapé de um slide e torne‑o visível.

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

## **Atualizar Data e Hora**

Modifique o marcador de data e hora em um slide.

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