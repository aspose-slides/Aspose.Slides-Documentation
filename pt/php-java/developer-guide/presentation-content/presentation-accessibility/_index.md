---
title: Gerenciar acessibilidade de apresentações em PHP
linktitle: Acessibilidade de Apresentação
type: docs
weight: 30
url: /pt/php-java/presentation-accessibility/
keywords:
- acessibilidade de apresentação
- marcar como decorativo
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Descubra como o Aspose.Slides ajuda a automatizar verificações de acessibilidade em apresentações nos arquivos PPT, PPTX e ODP — melhore a experiência de leitores de tela e aumente a conformidade."
---
## **Visão geral**

A acessibilidade em apresentações garante que pessoas que utilizam tecnologias assistivas — como leitores de tela, displays braille ou navegação apenas por teclado — possam entender e navegar pelos seus slides tão efetivamente quanto o público que enxerga e usa mouse. Boas práticas concentram‑se em ordem de leitura clara, texto alternativo significativo para elementos visuais informativos, contraste de cores suficiente, tipografia legível, texto descritivo em links e evitar transmitir significado apenas por cor ou posição. Quando a acessibilidade é planejada desde o início, o resultado é uma estrutura mais limpa, visuais mais consistentes e conteúdo que alcança todos os espectadores sem soluções alternativas.

## **Marcar como decorativo**

O marcador “marcar como decorativo” indica visualmente ornamentais puros, fazendo com que leitores de tela os ignorem, reduzindo ruído e mantendo o foco no conteúdo significativo. Aplique‑o em fundos, enfeites e espaçadores — nunca em gráficos, ícones ou imagens que transmitam informação. Aspose.Slides expõe esse marcador para detecção e validação, permitindo verificações automatizadas de acessibilidade e limpeza.

![Marcar como decorativo](mark_as_decorative.png)

O exemplo de código a seguir mostra como determinar se uma forma está marcada como decorativa.

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Is shape decorative: " . ($shape->isDecorative() ? "true" : "false") . "\n";
} finally {
    $presentation->dispose();
}
```