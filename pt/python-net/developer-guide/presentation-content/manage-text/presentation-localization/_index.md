---
title: Automatizar a localização de apresentações com Python
linktitle: Localização de Apresentações
type: docs
weight: 100
url: /pt/python-net/presentation-localization/
keywords:
- alterar idioma
- verificação ortográfica
- ID de idioma
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Automatize a localização de slides PowerPoint e OpenDocument em Python com Aspose.Slides, usando exemplos de código práticos e dicas para uma implantação global mais rápida."
---
## **Visão geral**

Este artigo explica como definir o `language_id` para texto em uma apresentação usando Aspose.Slides. Ele mostra como abrir uma apresentação, adicionar uma forma com texto, atribuir um identificador de idioma a uma porção de texto e salvar o resultado como um arquivo PPTX.

## **Alterar idioma da apresentação e do texto da forma**
- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Retângulo ao slide.
- Adicione algum texto ao TextFrame.
- Defina o Language Id para o texto.
- Salve a apresentação como um arquivo PPTX.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**O ID de idioma aciona a tradução automática de texto?**

Não. O [language_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/language_id/) em Aspose.Slides armazena o idioma para verificação ortográfica e correção gramatical, mas não traduz nem altera o conteúdo do texto. É um metadado que o PowerPoint entende para revisão.

**O ID de idioma afeta a hifenização e quebras de linha durante a renderização?**

No Aspose.Slides, o [language_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/language_id/) serve para revisão. A qualidade da hifenização e a quebra de linha dependem principalmente da disponibilidade de [proper fonts](/slides/pt/python-net/powerpoint-fonts/) e das configurações de layout/quebra de linha para o sistema de escrita. Para garantir a renderização correta, disponibilize as fontes necessárias, configure as [font substitution rules](/slides/pt/python-net/font-substitution/) e/ou [embed fonts](/slides/pt/python-net/embedded-font/) na apresentação.

**Posso definir idiomas diferentes dentro de um único parágrafo?**

Sim. O [language_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/language_id/) é aplicado ao nível da porção de texto, portanto um único parágrafo pode combinar múltiplos idiomas com configurações de revisão distintas.