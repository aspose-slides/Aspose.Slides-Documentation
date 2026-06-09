---
title: Slide Mestre
type: docs
weight: 30
url: /pt/php-java/examples/elements/master-slide/
keywords:
- slide mestre
- adicionar slide mestre
- acessar slide mestre
- remover slide mestre
- slide mestre não utilizado
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie slides mestres em PHP com Aspose.Slides: crie, edite, clone e formate temas, fundos, marcadores de posição para unificar slides no PowerPoint e OpenDocument."
---
Slides mestre formam o nível superior da hierarquia de herança de slides no PowerPoint. Um **slide mestre** define elementos de design comuns, como fundos, logotipos e formatação de texto. **Slides de layout** herdam dos slides mestre, e **slides normais** herdam dos slides de layout.

Este artigo demonstra como criar, modificar e gerenciar slides mestre usando Aspose.Slides for PHP via Java.

## **Adicionar um Slide Mestre**

Este exemplo mostra como criar um novo slide mestre clonando o padrão.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Clone o slide mestre padrão.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** Slides mestre fornecem uma maneira de aplicar branding consistente ou elementos de design compartilhados em todos os slides. Qualquer alteração feita no mestre será refletida automaticamente nos slides de layout e normais dependentes.

> 💡 **Tip 2:** Quaisquer formas ou formatações adicionadas a um slide mestre são herdadas pelos slides de layout e, por sua vez, por todos os slides normais que utilizam esses layouts.  
> A imagem abaixo ilustra como uma caixa de texto adicionada em um slide mestre é renderizada automaticamente no slide final.

![Exemplo de Herança de Mestre](master-slide-banner.png)

## **Acessar um Slide Mestre**

Você pode acessar slides mestre usando o método `Presentation::getMasters`. Veja como recuperá‑los e trabalhar com eles:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Acesse o primeiro slide mestre.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover um Slide Mestre**

Slides mestre podem ser removidos por índice ou por referência.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Remova por índice.
        $presentation->getMasters()->removeAt(0);

        // Ou remova por referência.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover Slides Mestres Não Utilizados**

Algumas apresentações contêm slides mestre que não estão em uso. Remover esses slides pode ajudar a reduzir o tamanho do arquivo.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Remova todos os slides mestres não utilizados (mesmo aqueles marcados como Preserve).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Tip:** Use `removeUnused(true)` para limpar slides mestre não utilizados e minimizar o tamanho da apresentação.