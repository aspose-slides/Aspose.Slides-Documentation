---
title: Gerenciar acessibilidade de apresentações em C++
linktitle: Acessibilidade de apresentações
type: docs
weight: 30
url: /pt/cpp/presentation-accessibility/
keywords:
- acessibilidade de apresentação
- marcar como decorativo
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Descubra como o Aspose.Slides para C++ ajuda a automatizar verificações de acessibilidade de apresentações em arquivos PPT, PPTX e ODP—melhore a experiência de leitores de tela e aumente a conformidade."
---
## **Visão geral**

A acessibilidade de apresentações garante que pessoas que utilizam tecnologias assistivas—como leitores de tela, displays Braille ou navegação apenas por teclado—possam entender e navegar pelos seus slides tão eficazmente quanto o público que vê e usa o mouse. As boas práticas focam em ordem de leitura clara, texto alternativo significativo para imagens informativas, contraste de cores adequado, tipografia legível, texto de link descritivo e evitar transmitir significado apenas por cor ou posição. Quando a acessibilidade é planejada desde o início, o resultado é uma estrutura mais limpa, recursos visuais mais consistentes e conteúdo que alcança todos os espectadores sem soluções alternativas.

## **Marcar como decorativo**

Marcar como decorativo sinaliza que os recursos puramente ornamentais devem ser ignorados pelos leitores de tela, reduzindo ruído e mantendo o foco no conteúdo significativo. Aplique isso a fundos, enfeites e espaçadores—nunca a gráficos, ícones ou imagens que transmitam informação. Aspose.Slides expõe essa bandeira para detecção e validação, permitindo verificações automatizadas de acessibilidade e limpeza.

![Marcar como decorativo](mark_as_decorative.png)

O exemplo de código a seguir mostra como determinar se uma forma está marcada como decorativa.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```