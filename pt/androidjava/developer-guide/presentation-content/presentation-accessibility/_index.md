---
title: Gerenciar acessibilidade de apresentações no Android
linktitle: Acessibilidade de apresentações
type: docs
weight: 30
url: /pt/androidjava/presentation-accessibility/
keywords:
- acessibilidade de apresentação
- marcar como decorativo
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Descubra como o Aspose.Slides para Android via Java ajuda a automatizar verificações de acessibilidade de apresentações em arquivos PPT, PPTX e ODP — melhore a experiência de leitores de tela e aumente a conformidade."
---
## **Visão geral**

A acessibilidade de apresentações garante que pessoas que utilizam tecnologias assistivas — como leitores de tela, displays em braile ou navegação apenas por teclado — possam entender e navegar seus slides tão efetivamente quanto o público que vê e usa mouse. Boas práticas se concentram em ordem de leitura clara, texto alternativo significativo para elementos visuais informativos, contraste de cores suficiente, tipografia legível, texto de link descritivo e evitar transmitir significado apenas por cor ou posição. Quando a acessibilidade é planejada desde o início, o resultado é uma estrutura mais limpa, visuais mais consistentes e conteúdo que alcança todos os espectadores sem soluções alternativas.

## **Marcar como decorativo**

O marcador 'Marcar como decorativo' sinaliza elementos puramente ornamentais para que leitores de tela os ignorem, reduzindo ruído e mantendo o foco no conteúdo significativo. Aplique‑o em fundos, enfeites e espaçadores — nunca em gráficos, ícones ou imagens que transmitam informações. O Aspose.Slides expõe esse marcador para detecção e validação, permitindo verificações automatizadas de acessibilidade e limpeza.

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