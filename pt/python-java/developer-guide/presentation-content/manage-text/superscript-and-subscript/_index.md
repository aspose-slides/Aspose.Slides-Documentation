---
title: Gerenciar sobrescrito e subscrito em apresentações usando Python via Java
linktitle: Sobrescrito e Subscrito
type: docs
weight: 80
url: /pt/python-java/superscript-and-subscript/
keywords:
- sobrescrito
- subscrito
- adicionar sobrescrito
- adicionar subscrito
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Domine sobrescrito e subscrito no Aspose.Slides para Python via Java e eleve suas apresentações com formatação de texto profissional para máximo impacto."
---
## **Visão geral**

Aspose.Slides oferece recursos para integrar texto em sobrescrito e subscrito em suas apresentações PowerPoint (PPT, PPTX) e OpenDocument (ODP). Seja para destacar fórmulas químicas, equações matemáticas ou anotar conteúdo com notas de rodapé, essas opções de formatação especial ajudam a manter clareza e precisão. Neste artigo, você aprenderá como aplicar estilos de sobrescrito e subscrito de forma contínua e garantir resultados profissionais em cada slide.

## **Gerenciar texto em sobrescrito e subscrito**

Você pode adicionar texto em sobrescrito e subscrito a qualquer parte de um parágrafo. Para aplicar essa formatação em um frame de texto Aspose.Slides, use o método [setEscapement](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/#setEscapement) da classe [PortionFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/).

O valor de escapamento varia de -100% (subscrito) a 100% (sobrescrito). Por exemplo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
- Obtenha um slide pelo seu índice.
- Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) do tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#Rectangle) ao slide.
- Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) associado ao [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/).
- Limpe os parágrafos existentes.
- Crie um parágrafo para conter texto em sobrescrito e adicione-o à [coleção de parágrafos](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/#getParagraphs) do frame de texto.
- Crie uma porção.
- Use [setEscapement](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/#setEscapement) para definir um valor de 0 a 100 para sobrescrito (0 significa sem sobrescrito).
- Defina o texto da [Portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/) e adicione-o à coleção de porções do parágrafo.
- Crie um parágrafo para conter texto em subscrito e adicione-o à [coleção de parágrafos](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/#getParagraphs) do frame de texto.
- Crie uma porção.
- Use [setEscapement](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/#setEscapement) para definir um valor de -100 a 0 para subscrito (0 significa sem subscrito).
- Defina o texto da [Portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/) e adicione-o à coleção de porções do parágrafo.
- Salve a apresentação como um arquivo PPTX.

O exemplo a seguir implementa essas etapas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Criar uma apresentação.
presentation = Presentation()
try:
    # Obter o slide.
    slide = presentation.getSlides().get_Item(0)

    # Criar uma caixa de texto.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Criar um parágrafo para texto em sobrescrito.
    superscript_paragraph = Paragraph()

    # Criar uma porção com texto normal.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Criar uma porção com texto em sobrescrito.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Criar um parágrafo para texto em subscrito.
    subscript_paragraph = Paragraph()

    # Criar uma porção com texto normal.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Criar uma porção com texto em subscrito.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Adicionar os parágrafos à caixa de texto.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**A formatação de sobrescrito e subscrito será preservada ao exportar para PDF ou outros formatos?**

Sim, Aspose.Slides mantém corretamente a formatação de sobrescrito e subscrito ao exportar apresentações para PDF, PPT/PPTX, imagens e outros formatos suportados. A formatação especializada permanece intacta em todos os arquivos de saída.

**É possível combinar sobrescrito e subscrito com outros estilos de formatação, como negrito ou itálico?**

Sim, Aspose.Slides permite misturar vários estilos de texto dentro de uma única porção. Você pode ativar negrito, itálico, sublinhado e, simultaneamente, aplicar sobrescrito ou subscrito configurando as propriedades correspondentes em [PortionFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/).

**A formatação de sobrescrito e subscrito funciona para texto dentro de tabelas, gráficos ou SmartArt?**

Sim, Aspose.Slides oferece suporte à formatação na maioria dos objetos, incluindo elementos de tabelas e gráficos. Ao trabalhar com SmartArt, é necessário acessar os elementos apropriados (como [SmartArtNode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnode/)) e seus contêineres de texto, e então configurar as propriedades de [PortionFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/) de maneira similar.