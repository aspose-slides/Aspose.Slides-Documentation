---
title: Slide de Layout
type: docs
weight: 20
url: /pt/php-java/examples/elements/layout-slide/
keywords:
- slide de layout
- adicionar slide de layout
- acessar slide de layout
- remover slide de layout
- slide de layout não usado
- clonar slide de layout
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Use PHP para gerenciar slides de layout com Aspose.Slides: criar, aplicar, clonar, renomear e personalizar marcadores de posição e temas em apresentações para PPT, PPTX e ODP."
---
Este artigo demonstra como trabalhar com **Layout Slides** no Aspose.Slides for PHP via Java. Um slide de layout define o design e a formatação herdados pelos slides normais. Você pode adicionar, acessar, clonar e remover slides de layout, além de limpar os não utilizados para reduzir o tamanho da apresentação.

## **Adicionar um Slide de Layout**

Você pode criar um slide de layout personalizado para definir formatação reutilizável. Por exemplo, pode adicionar uma caixa de texto que aparece em todos os slides que usam este layout.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // Crie um slide de layout com um tipo de layout em branco e um nome personalizado.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Dica 1:** Slides de layout funcionam como modelos para slides individuais. Você pode definir elementos comuns uma vez e reutilizá‑los em muitos slides.

> 💡 **Dica 2:** Quando você adiciona formas ou texto a um slide de layout, todos os slides baseados nesse layout exibirão esse conteúdo compartilhado automaticamente.  
> A captura de tela abaixo mostra dois slides, cada um herdando uma caixa de texto do mesmo slide de layout.

![Slides herdando conteúdo de layout](layout-slide-result.png)

## **Acessar um Slide de Layout**

Slides de layout podem ser acessados por índice ou por tipo de layout (por exemplo, `Blank`, `Title`, `SectionHeader`, etc.).

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Acesse por índice.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // Acesse por tipo de layout.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover um Slide de Layout**

Você pode remover um slide de layout específico se ele não for mais necessário.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Obtenha um slide de layout por tipo e remova-o.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover Slides de Layout Não Utilizados**

Para reduzir o tamanho da apresentação, você pode querer remover slides de layout que não são usados por nenhum slide normal.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Remove automaticamente todos os slides de layout que não são referenciados por nenhum slide.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Clonar um Slide de Layout**

Você pode duplicar um slide de layout usando o método `addClone`.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Obtenha um slide de layout existente por tipo.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Clone o slide de layout para o final da coleção de slides de layout.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Resumo:** Slides de layout são ferramentas poderosas para gerenciar formatação consistente em slides. Aspose.Slides permite controle total sobre a criação, gerenciamento e otimização de slides de layout.