---
title: Alterar o Tamanho do Slide da Apresentação em PHP
linktitle: Tamanho do Slide
type: docs
weight: 70
url: /pt/php-java/slide-size/
keywords:
- tamanho do slide
- proporção de aspecto
- padrão
- tela widescreen
- 4:3
- 16:9
- definir tamanho do slide
- alterar tamanho do slide
- tamanho de slide personalizado
- tamanho de slide especial
- tamanho de slide único
- slide em tamanho completo
- tipo de tela
- não escalar
- garantir ajuste
- maximizar
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a redimensionar rapidamente slides em arquivos PPT, PPTX e ODP com PHP e Aspose.Slides, otimize apresentações para qualquer tela sem perder qualidade."
---
## **Introdução**

Aspose.Slides oferece ferramentas abrangentes para ajustar o tamanho do slide e a proporção de aspecto em apresentações do PowerPoint, essencial tanto para impressão quanto para exibição em tela.

Tamanhos e proporções de slide populares:

- **Padrão (Proporção 4:3)**: Ideal para telas e dispositivos mais antigos.
- **Tela widescreen (Proporção 16:9)**: Recomendado para projetores e monitores modernos.

Garanta consistência em toda a apresentação, pois um único tamanho de slide e proporção de aspecto se aplicam a todos os slides. Para obter resultados ideais, defina as dimensões dos slides no início do processo de criação da apresentação para evitar complicações.

{{% alert color="info" title="Note" %}}
Por padrão, as apresentações criadas com Aspose.Slides usam a proporção padrão 4:3.
{{% /alert %}}

Páginas de notas e de material de apoio têm dimensões separadas dos slides regulares. Consulte [Notes Page Size](/slides/pt/php-java/notes-size/) para alterar seu tamanho e orientação.

## **Alterar o tamanho do slide em apresentações**

Este exemplo de código mostra como alterar o tamanho do slide em uma apresentação usando Aspose.Slides:

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Especificar tamanhos de slide personalizados em apresentações**

Se os tamanhos de slide comuns (4:3 e 16:9) não forem adequados ao seu trabalho, você pode optar por usar um tamanho de slide específico ou único. Por exemplo, se planeja imprimir slides em tamanho real a partir da sua apresentação em um layout de página personalizado ou se pretende exibir a apresentação em determinados tipos de tela, provavelmente se beneficiará ao usar uma configuração de tamanho personalizada.

Este exemplo de código demonstra como usar Aspose.Slides for PHP via Java para especificar um tamanho de slide personalizado para uma apresentação:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// tamanho de papel A4

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Manipular o conteúdo do slide após redimensionamento**

Depois de alterar o tamanho do slide de uma apresentação, o conteúdo dos slides (imagens ou objetos, por exemplo) pode ficar distorcido. Por padrão, os objetos são redimensionados automaticamente para se ajustarem ao novo tamanho do slide. No entanto, ao mudar o tamanho do slide de uma apresentação, você pode especificar uma configuração que determina como o Aspose.Slides lida com o conteúdo nos slides.

Dependendo do que você pretende fazer ou alcançar, pode usar qualquer uma dessas configurações:

- `DoNotScale`

  Se NÃO quiser que os objetos nos slides sejam redimensionados, use esta configuração.

- `EnsureFit`

  Se deseja reduzir para um tamanho de slide menor e precisa que o Aspose.Slides diminua os objetos dos slides para garantir que todos caibam nos slides (evitando perda de conteúdo), use esta configuração.

- `Maximize`

  Se deseja ampliar para um tamanho de slide maior e precisa que o Aspose.Slides aumente os objetos dos slides para que fiquem proporcionais ao novo tamanho, use esta configuração.

Este exemplo de código mostra como usar a configuração `Maximize` ao alterar o tamanho do slide de uma apresentação:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso definir um tamanho de slide personalizado usando unidades diferentes de polegadas (por exemplo, pontos ou milímetros)?**

Sim. O Aspose.Slides usa pontos internamente, onde 1 ponto equivale a 1/72 de polegada. Você pode converter qualquer unidade (como milímetros ou centímetros) para pontos e usar os valores convertidos para definir a largura e a altura do slide.

**Um tamanho de slide personalizado muito grande afeta o desempenho e o uso de memória durante a renderização?**

Sim. Dimensões de slide maiores (em pontos) combinadas com uma escala de renderização mais alta aumentam o consumo de memória e prolongam o tempo de processamento. Procure um tamanho de slide prático e ajuste a escala de renderização somente quando necessário para alcançar a qualidade de saída desejada.

**Posso definir um tamanho de slide não padrão e depois mesclar slides de apresentações que têm tamanhos diferentes?**

Não é possível [merge presentations](/slides/pt/php-java/merge-presentation/) enquanto elas possuem tamanhos de slide diferentes — primeiro, redimensione uma apresentação para coincidir com a outra. Ao mudar o tamanho do slide, você pode escolher como o conteúdo existente será tratado via a opção [SlideSizeScaleType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesizescaletype/). Depois de alinhar os tamanhos, você pode mesclar os slides preservando a formatação.

**Posso gerar miniaturas para formas individuais ou regiões específicas de um slide, e elas respeitarão o novo tamanho do slide?**

Sim. O Aspose.Slides pode gerar miniaturas para [entire slides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#getImage) assim como para [selected shapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getImage). As imagens resultantes refletem o tamanho e a proporção de aspecto atuais do slide, garantindo enquadramento e geometria consistentes.