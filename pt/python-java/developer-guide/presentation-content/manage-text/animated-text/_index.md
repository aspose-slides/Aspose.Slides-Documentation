---
title: Animar texto do PowerPoint em Python via Java
linktitle: Texto animado
type: docs
weight: 60
url: /pt/python-java/animated-text/
keywords:
- texto animado
- animação de texto
- parágrafo animado
- animação de parágrafo
- efeito de animação
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Crie texto animado dinâmico em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via Java, com exemplos de código Python fáceis de seguir e otimizados."
---
## **Visão geral**

Este artigo explica como trabalhar com texto animado no Aspose.Slides aplicando efeitos de animação a parágrafos individuais e recuperando os efeitos já atribuídos a parágrafos em uma moldura de texto. Ele se concentra nos métodos da API usados para adicionar animação ao nível de parágrafo e inspecionar efeitos de animação de parágrafo existentes em uma apresentação.

## **Adicionar efeitos de animação a parágrafos**

O método [addEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sequence/#addEffect) da classe [Sequence](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sequence/) permite adicionar efeitos de animação a um único parágrafo. Este código de exemplo mostra como adicionar um efeito de animação a um único parágrafo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Selecione o parágrafo para adicionar um efeito.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Adicione um efeito de animação Fly ao parágrafo selecionado.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obter efeitos de animação de parágrafos**

Você pode querer recuperar os efeitos de animação aplicados a um parágrafo — por exemplo, para aplicar esses efeitos a outro parágrafo ou forma.

Aspose.Slides for Python via Java permite obter todos os efeitos de animação aplicados a parágrafos contidos em uma moldura de texto (forma). Este código de exemplo mostra como obter os efeitos de animação aplicados a um parágrafo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **FAQ**

**Como as animações de texto diferem das transições de slide e podem ser combinadas?**

As animações de texto controlam o comportamento de objetos ao longo do tempo em um slide, enquanto [transitions](/slides/pt/python-java/slide-transition/) controlam como os slides mudam. Elas são independentes e podem ser usadas juntas; a ordem de reprodução é governada pela linha do tempo da animação e pelas configurações de transição.

**As animações de texto são preservadas ao exportar para PDF ou imagens?**

Não. PDFs e imagens raster são estáticos, portanto você verá um único estado do slide sem movimento. Para manter o movimento, use exportação para [video](/slides/pt/python-java/convert-powerpoint-to-video/) ou [HTML](/slides/pt/python-java/export-to-html5/).

**As animações de texto funcionam em layouts e no mestre de slides?**

Os efeitos aplicados a objetos de layout/mestre são herdados pelos slides, mas seu tempo e interação com animações a nível de slide dependem da sequência final no slide.