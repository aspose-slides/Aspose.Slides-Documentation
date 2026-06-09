---
title: Gerenciar Acessibilidade de Apresentação em .NET
linktitle: Acessibilidade de Apresentação
type: docs
weight: 30
url: /pt/net/presentation-accessibility/
keywords:
- acessibilidade de apresentação
- marcar como decorativo
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Automatize verificações de acessibilidade em apresentações nos arquivos PPT, PPTX e ODP com Aspose.Slides para .NET — melhore a experiência do leitor de tela e aumente a conformidade."
---
## **Introdução**

A acessibilidade em apresentações garante que pessoas que utilizam tecnologias assistivas — como leitores de tela, displays em braile ou navegação apenas por teclado — possam entender e navegar seus slides tão efetivamente quanto o público que vê e usa o mouse. As boas práticas se concentram em ordem de leitura clara, texto alternativo significativo para elementos visuais informativos, contraste de cores suficiente, tipografia legível, texto de link descritivo e em evitar transmitir significado apenas por cor ou posição. Quando a acessibilidade é planejada desde o início, o resultado é uma estrutura mais limpa, elementos visuais mais consistentes e um conteúdo que alcança todos os espectadores sem soluções alternativas.

## **Marcar como Decorativo**

Marcar como decorativo sinaliza elementos puramente ornamentais para que os leitores de tela os ignorem, reduzindo ruído e mantendo o foco no conteúdo significativo. Aplique isso a fundos, adornos e separadores — nunca a gráficos, ícones ou imagens que transmitam informações. Aspose.Slides expõe essa sinalização para detecção e validação, permitindo verificações automatizadas de acessibilidade e limpeza.

![Marcar como Decorativo](mark_as_decorative.png)

O exemplo de código a seguir mostra como determinar se uma forma está marcada como decorativa.

```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```