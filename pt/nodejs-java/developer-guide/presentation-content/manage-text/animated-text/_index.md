---
title: Animar texto do PowerPoint em JavaScript
linktitle: Texto animado
type: docs
weight: 60
url: /pt/nodejs-java/animated-text/
keywords:
- texto animado
- animação de texto
- parágrafo animado
- animação de parágrafo
- efeito de animação
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Crie texto animado dinâmico em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Node.js, com exemplos de código fáceis de seguir e otimizados."
---
## **Visão Geral**

Este artigo explica como trabalhar com texto animado no Aspose.Slides aplicando efeitos de animação a parágrafos individuais e recuperando os efeitos já atribuídos aos parágrafos em um quadro de texto. Ele se concentra nos métodos de API usados para adicionar animação ao nível de parágrafo e inspecionar os efeitos de animação de parágrafo existentes em uma apresentação.

## **Adicionando Efeitos de Animação a Parágrafos**

Adicionamos o método [**addEffect()**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) às classes [**Sequence**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Sequence) e [**Sequence**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Sequence). Esse método permite adicionar efeitos de animação a um único parágrafo. Este código de exemplo mostra como adicionar um efeito de animação a um único parágrafo:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // selecionar parágrafo para adicionar efeito
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // adicionar efeito de animação Fly ao parágrafo selecionado
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Obtendo os Efeitos de Animação em Parágrafos**

Você pode decidir descobrir os efeitos de animação adicionados a um parágrafo — por exemplo, em um cenário, você deseja obter os efeitos de animação em um parágrafo porque planeja aplicar esses efeitos a outro parágrafo ou forma.

O Aspose.Slides for Node.js via Java permite obter todos os efeitos de animação aplicados aos parágrafos contidos em um quadro de texto (forma). Este código de exemplo mostra como obter os efeitos de animação em um parágrafo:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```

## **Perguntas Frequentes**

**Como as animações de texto diferem das transições de slide e podem ser combinadas?**

As animações de texto controlam o comportamento do objeto ao longo do tempo em um slide, enquanto [transitions](/slides/pt/nodejs-java/slide-transition/) controlam como os slides mudam. Elas são independentes e podem ser usadas juntas; a ordem de reprodução é determinada pela linha do tempo da animação e pelas configurações de transição.

**As animações de texto são preservadas ao exportar para PDF ou imagens?**

Não. PDFs e imagens raster são estáticos, portanto você verá um único estado do slide sem movimento. Para manter o movimento, use a exportação para [video](/slides/pt/nodejs-java/convert-powerpoint-to-video/) ou [HTML](/slides/pt/nodejs-java/export-to-html5/).

**As animações de texto funcionam em layouts e no mestre de slides?**

Os efeitos aplicados a objetos de layout/mestre são herdados pelos slides, mas seu cronograma e interação com animações ao nível do slide dependem da sequência final no slide.