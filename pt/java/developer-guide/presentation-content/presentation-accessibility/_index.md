---
title: Gerenciar Acessibilidade de Apresentação em Java
linktitle: Acessibilidade de Apresentação
type: docs
weight: 30
url: /pt/java/presentation-accessibility/
keywords:
- acessibilidade de apresentação
- marcar como decorativo
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Descubra como o Aspose.Slides para Java ajuda a automatizar verificações de acessibilidade de apresentações em arquivos PPT, PPTX e ODP—melhore a experiência de leitores de tela e aumente a conformidade."
---
## **Introdução**

A acessibilidade em apresentações garante que pessoas que utilizam tecnologias assistivas—como leitores de tela, displays braille ou navegação apenas por teclado—possam compreender e navegar pelos seus slides tão efetivamente quanto o público que vê e usa mouse. As boas práticas concentram‑se na ordem de leitura clara, texto alternativo significativo para elementos visuais informativos, contraste de cores suficiente, tipografia legível, texto de link descritivo e evitar transmitir significado apenas por cor ou posição. Quando a acessibilidade é planejada desde o início, o resultado é uma estrutura mais limpa, elementos visuais mais consistentes e conteúdo que alcança todos os espectadores sem soluções alternativas.

## **Marcar como decorativo**

O sinalizador marcar como decorativo indica que os elementos visuais são puramente ornamentais, fazendo com que leitores de tela os ignorem, reduzindo ruído e mantendo o foco no conteúdo significativo. Aplique‑lo a fundos, enfeites e espaçadores—nunca a gráficos, ícones ou imagens que transmitam informações. Aspose.Slides expõe esse sinalizador para detecção e validação, permitindo verificações automáticas de acessibilidade e limpeza.

![Marcar como decorativo](mark_as_decorative.png)

O exemplo de código a seguir mostra como determinar se uma forma está marcada como decorativa.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```