---
title: Animar texto do PowerPoint em Java
linktitle: Texto animado
type: docs
weight: 60
url: /pt/java/animated-text/
keywords:
- texto animado
- animação de texto
- parágrafo animado
- animação de parágrafo
- efeito de animação
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Crie texto animado dinâmico em apresentações PowerPoint e OpenDocument usando Aspose.Slides for Java, com exemplos de código Java fáceis de seguir e otimizados."
---
## **Visão geral**

Este artigo explica como trabalhar com texto animado no Aspose.Slides aplicando efeitos de animação a parágrafos individuais e recuperando os efeitos já atribuídos aos parágrafos em um quadro de texto. Ele se concentra nos métodos da API usados para adicionar animação ao nível de parágrafo e inspecionar os efeitos de animação de parágrafo existentes em uma apresentação.

## **Adicionar efeitos de animação aos parágrafos**

Adicionamos o método [**addEffect()**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) às classes [**Sequence**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Sequence) e [**ISequence**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISequence). Esse método permite adicionar efeitos de animação a um único parágrafo. Este código de exemplo mostra como adicionar um efeito de animação a um único parágrafo:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // selecionar parágrafo para adicionar efeito
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // adicionar efeito de animação Fly ao parágrafo selecionado
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Obter efeitos de animação dos parágrafos**

Você pode decidir descobrir os efeitos de animação adicionados a um parágrafo — por exemplo, em um cenário, você deseja obter os efeitos de animação em um parágrafo porque planeja aplicar esses efeitos a outro parágrafo ou forma.

O Aspose.Slides for Java permite obter todos os efeitos de animação aplicados aos parágrafos contidos em um quadro de texto (forma). Este código de exemplo mostra como obter os efeitos de animação em um parágrafo:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **FAQ**

**Como as animações de texto diferem das transições de slide e podem ser combinadas?**

As animações de texto controlam o comportamento do objeto ao longo do tempo em um slide, enquanto [transitions](/slides/pt/java/slide-transition/) controlam como os slides mudam. Elas são independentes e podem ser usadas juntas; a ordem de reprodução é governada pela linha do tempo da animação e pelas configurações de transição.

**As animações de texto são preservadas ao exportar para PDF ou imagens?**

Não. PDFs e imagens raster são estáticos, portanto você verá um único estado do slide sem movimento. Para manter o movimento, use a exportação para [video](/slides/pt/java/convert-powerpoint-to-video/) ou [HTML](/slides/pt/java/export-to-html5/).

**As animações de texto funcionam em layouts e no mestre de slides?**

Os efeitos aplicados a objetos de layout/mestre são herdados pelos slides, mas sua temporização e interação com animações ao nível do slide dependem da sequência final no slide.