---
title: Cabeçalho e Rodapé
type: docs
weight: 220
url: /pt/nodejs-java/examples/elements/header-footer/
keywords:
- exemplo de código
- cabeçalho
- rodapé
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Controle cabeçalhos e rodapés de slides com Aspose.Slides para Node.js: adicione datas, números de slide e texto personalizado em PPT, PPTX e ODP com exemplos em JavaScript."
---
Este artigo demonstra como adicionar rodapés e atualizar marcadores de data e hora usando **Aspose.Slides for Node.js via Java**.

## **Adicionar Rodapé**

Adicione texto à área de rodapé de um slide e torne‑o visível.

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Atualizar Data e Hora**

Modifique o marcador de data e hora em um slide.

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```