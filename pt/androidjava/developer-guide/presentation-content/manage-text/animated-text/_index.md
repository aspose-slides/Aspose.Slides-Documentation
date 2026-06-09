---
title: Animar Texto do PowerPoint no Android
linktitle: Texto Animado
type: docs
weight: 60
url: /pt/androidjava/animated-text/
keywords:
- texto animado
- animação de texto
- parágrafo animado
- animação de parágrafo
- efeito de animação
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Crie texto animado dinâmico em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Android, com exemplos de código Java fáceis de seguir e otimizados."
---
## **Visão Geral**

Este artigo explica como trabalhar com texto animado no Aspose.Slides aplicando efeitos de animação a parágrafos individuais e obtendo os efeitos já atribuídos aos parágrafos em uma moldura de texto. Ele se concentra nos métodos de API usados para adicionar animação ao nível de parágrafo e inspecionar os efeitos de animação de parágrafo existentes em uma apresentação.

## **Adicionar Efeitos de Animação a Parágrafos**

Adicionamos o método [**addEffect()**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) às classes [**Sequence**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Sequence) e [**ISequence**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISequence). Esse método permite adicionar efeitos de animação a um único parágrafo. O código de exemplo abaixo mostra como adicionar um efeito de animação a um único parágrafo:

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

## **Obter Efeitos de Animação de Parágrafos**

Pode ser necessário descobrir quais efeitos de animação foram adicionados a um parágrafo — por exemplo, em um cenário você deseja obter os efeitos de animação de um parágrafo porque planeja aplicar esses efeitos a outro parágrafo ou forma.

O Aspose.Slides for Android via Java permite obter todos os efeitos de animação aplicados aos parágrafos contidos em uma moldura de texto (forma). O código de exemplo abaixo mostra como obter os efeitos de animação em um parágrafo:

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

**Como as animações de texto diferem das transições de slides e podem ser combinadas?**

As animações de texto controlam o comportamento do objeto ao longo do tempo em um slide, enquanto [transições](/slides/pt/androidjava/slide-transition/) controlam como os slides mudam. Elas são independentes e podem ser usadas juntas; a ordem de reprodução é governada pela linha do tempo da animação e pelas configurações de transição.

**Os efeitos de animação de texto são preservados ao exportar para PDF ou imagens?**

Não. PDF e imagens rasterizadas são estáticos, portanto você verá um único estado do slide sem movimento. Para manter a movimentação, use exportação em [vídeo](/slides/pt/androidjava/convert-powerpoint-to-video/) ou [HTML](/slides/pt/androidjava/export-to-html5/).

**As animações de texto funcionam em layouts e no slide mestre?**

Os efeitos aplicados a objetos de layout/mestre são herdados pelos slides, mas seu timing e interação com animações ao nível do slide dependem da sequência final no slide.