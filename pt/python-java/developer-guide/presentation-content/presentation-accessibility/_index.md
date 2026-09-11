---
title: Gerenciar Acessibilidade de Apresentações em Python via Java
linktitle: Acessibilidade de Apresentação
type: docs
weight: 30
url: /pt/python-java/presentation-accessibility/
keywords:
- acessibilidade de apresentação
- marcar como decorativo
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Descubra como o Aspose.Slides for Python via Java ajuda a automatizar verificações de acessibilidade de apresentações em arquivos PPT, PPTX e ODP — melhore a experiência de leitores de tela e aumente a conformidade."
---
## **Introdução**

A acessibilidade de apresentações garante que pessoas que utilizam tecnologias assistivas — como leitores de tela, displays em braile ou navegação apenas por teclado — possam entender e navegar pelos seus slides tão efetivamente quanto o público que enxerga e usa mouse. Boas práticas concentram-se em uma ordem de leitura clara, texto alternativo significativo para elementos visuais informativos, contraste de cores suficiente, tipografia legível, texto de link descritivo e na evitação de transmitir significado apenas por cor ou posição. Quando a acessibilidade é planejada desde o início, o resultado é uma estrutura mais limpa, elementos visuais mais consistentes e conteúdo que alcança todos os espectadores sem soluções alternativas.

## **Marcar como Decorativo**

A marcação como decorativo sinaliza elementos visuais puramente ornamentais para que leitores de tela os ignorem, reduzindo ruído e mantendo o foco no conteúdo significativo. Aplique-a em fundos, ornamentos e espaçadores — nunca em gráficos, ícones ou imagens que transmitem informações. O Aspose.Slides expõe essa marcação para detecção e validação, permitindo verificações automatizadas de acessibilidade e limpeza.

![Marcar como Decorativo](mark_as_decorative.png)

O exemplo de código a seguir mostra como determinar se uma forma está marcada como decorativa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```