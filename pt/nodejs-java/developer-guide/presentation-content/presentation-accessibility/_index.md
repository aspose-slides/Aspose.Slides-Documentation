---
title: Gerenciar acessibilidade de apresentações em JavaScript
linktitle: Acessibilidade de apresentações
type: docs
weight: 30
url: /pt/nodejs-java/presentation-accessibility/
keywords:
- acessibilidade de apresentação
- marcar como decorativo
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatize verificações de acessibilidade de apresentações em arquivos PPT, PPTX e ODP com Aspose.Slides para Node.js—melhore a experiência de leitores de tela e aumente a conformidade."
---
## **Visão geral**

A acessibilidade de apresentações garante que pessoas que utilizam tecnologias assistivas — como leitores de tela, displays braille ou navegação apenas por teclado — possam entender e navegar pelos seus slides com a mesma eficácia que o público que vê e usa mouse. As boas práticas concentram‑se na ordem de leitura clara, texto alternativo significativo para recursos visuais informativos, contraste de cores suficiente, tipografia legível, texto de link descritivo e evitar transmitir significado apenas por cor ou posição. Quando a acessibilidade é planejada desde o início, o resultado é uma estrutura mais limpa, recursos visuais mais consistentes e conteúdo que alcança todos os espectadores sem soluções alternativas.

## **Marcar como decorativo**

Marcar como decorativo sinaliza recursos puramente ornamentais para que os leitores de tela os ignorem, reduzindo ruído e mantendo o foco no conteúdo significativo. Aplique‑a a fundos, enfeites e espaçadores — nunca a gráficos, ícones ou imagens que transmitem informações. O Aspose.Slides expõe essa sinalização para detecção e validação, permitindo verificações automáticas de acessibilidade e limpeza.

![Marcar como decorativo](mark_as_decorative.png)

O exemplo de código a seguir mostra como determinar se uma forma está marcada como decorativa.

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Is shape decorative:", shape.isDecorative());
} finally {
    presentation.dispose();
}
```