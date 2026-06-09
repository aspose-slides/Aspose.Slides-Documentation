---
title: Gerenciar Acessibilidade de Apresentação em Python
linktitle: Acessibilidade de Apresentação
type: docs
weight: 30
url: /pt/python-net/presentation-accessibility/
keywords:
- acessibilidade de apresentação
- marcar como decorativo
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Descubra como Aspose.Slides para Python ajuda a automatizar verificações de acessibilidade de apresentações em arquivos PPT, PPTX e ODP - melhore a experiência de leitores de tela e aumente a conformidade."
---
## **Introdução**

A acessibilidade de apresentações garante que pessoas que utilizam tecnologias assistivas— como leitores de tela, displays braille ou navegação apenas por teclado—possam entender e navegar pelos seus slides tão efetivamente quanto o público que enxerga e usa o mouse. Boas práticas se concentram em uma ordem de leitura clara, texto alternativo significativo para elementos visuais informativos, contraste de cores suficiente, tipografia legível, texto de link descritivo e evitar transmitir significado apenas por cor ou posição. Quando a acessibilidade é planejada desde o início, o resultado é uma estrutura mais limpa, elementos visuais mais consistentes e conteúdo que alcança todos os espectadores sem soluções alternativas.

## **Marcar como Decorativo**

Marcar como decorativo sinaliza elementos visuais puramente ornamentais para que os leitores de tela os ignorem, reduzindo ruído e mantendo o foco no conteúdo significativo. Aplique‑o a fundos, ornamentos e espaçadores— nunca a gráficos, ícones ou imagens que transmitam informações. Aspose.Slides expõe essa sinalização para detecção e validação, permitindo verificações automatizadas de acessibilidade e limpeza.

![Marcar como Decorativo](mark_as_decorative.png)

O exemplo de código a seguir demonstra como determinar se uma forma está marcada como decorativa.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    print(f"Is shape decorative: {shape.is_decorative}")
```