---
title: Alterar o tamanho do slide da apresentação em Java
linktitle: Tamanho do Slide
type: docs
weight: 70
url: /pt/java/slide-size/
keywords:
- tamanho do slide
- proporção
- padrão
- tela ampla
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
- assegurar ajuste
- maximizar
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Aprenda como redimensionar rapidamente slides em arquivos PPT, PPTX e ODP com Java e Aspose.Slides, otimize apresentações para qualquer tela sem perder qualidade."
---
## **Introdução**

Aspose.Slides fornece ferramentas abrangentes para ajustar o tamanho do slide e a proporção em apresentações do PowerPoint, essenciais tanto para impressão quanto para exibição em tela. 

Tamanhos de slide populares e proporções:

- **Padrão (Proporção 4:3)**: Ideal para telas e dispositivos mais antigos.
- **Tela ampla (Proporção 16:9)**: Recomendado para projetores e telas modernas.

Garanta consistência em toda a sua apresentação, pois um único tamanho de slide e proporção se aplicam a todos os slides. Para obter resultados ideais, defina as dimensões dos slides no início do processo de criação da apresentação para evitar complicações.

{{% alert color="primary" %}} 
Por padrão, as apresentações criadas com Aspose.Slides usam a proporção padrão 4:3.
{{% /alert %}}

## **Alterar o tamanho do slide em apresentações**

Este código de exemplo mostra como alterar o tamanho do slide em uma apresentação em Java usando Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Especificar tamanhos de slide personalizados em apresentações**

Se você considerar os tamanhos de slide comuns (4:3 e 16:9) inadequados para o seu trabalho, pode decidir usar um tamanho de slide específico ou único. Por exemplo, se planeja imprimir slides em tamanho real da sua apresentação em um layout de página personalizado ou se pretende exibir sua apresentação em determinados tipos de tela, provavelmente se beneficiará de usar uma configuração de tamanho personalizado para sua apresentação. 

Este código de exemplo mostra como usar Aspose.Slides para Java para especificar um tamanho de slide personalizado para uma apresentação em Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // tamanho de papel A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Manipular o conteúdo do slide após redimensionamento**

Após alterar o tamanho do slide de uma apresentação, o conteúdo dos slides (imagens ou objetos, por exemplo) pode ficar distorcido. Por padrão, os objetos são redimensionados automaticamente para se ajustarem ao novo tamanho do slide. No entanto, ao mudar o tamanho do slide de uma apresentação, você pode especificar uma configuração que determina como o Aspose.Slides trata o conteúdo dos slides.

Dependendo do que você pretende fazer ou alcançar, pode usar qualquer uma dessas configurações:

- `DoNotScale`

  Se você NÃO deseja que os objetos nos slides sejam redimensionados, use esta configuração.

- `EnsureFit`

  Se você deseja redimensionar para um tamanho de slide menor e precisa que o Aspose.Slides reduza os objetos dos slides para garantir que todos caibam nos slides (assim, evita perda de conteúdo), use esta configuração. 

- `Maximize`

  Se você deseja redimensionar para um tamanho de slide maior e precisa que o Aspose.Slides aumente os objetos dos slides para torná-los proporcionais ao novo tamanho do slide, use esta configuração. 

Este código de exemplo mostra como usar a configuração `Maximize` ao alterar o tamanho do slide de uma apresentação:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso definir um tamanho de slide personalizado usando unidades diferentes de polegadas (por exemplo, pontos ou milímetros)?**

Sim. Aspose.Slides usa pontos internamente, onde 1 ponto equivale a 1/72 de polegada. Você pode converter qualquer unidade (como milímetros ou centímetros) para pontos e usar os valores convertidos para definir a largura e a altura do slide.

**Um tamanho de slide personalizado muito grande afetará o desempenho e o uso de memória durante a renderização?**

Sim. Dimensões maiores de slide (em pontos) combinadas com escala de renderização mais alta levam ao aumento do consumo de memória e a tempos de processamento mais longos. Procure um tamanho de slide prático e ajuste a escala de renderização apenas quando necessário para obter a qualidade de saída desejada.

**Posso definir um tamanho de slide não padrão e depois mesclar slides de apresentações que tenham tamanhos diferentes?**

Você não pode [mesclar apresentações](/slides/pt/java/merge-presentation/) enquanto elas têm tamanhos de slide diferentes — primeiro, redimensione uma apresentação para corresponder à outra. Ao alterar o tamanho do slide, você pode escolher como o conteúdo existente será tratado via a opção [SlideSizeScaleType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slidesizescaletype/). Após alinhar os tamanhos, você pode mesclar os slides preservando a formatação.

**Posso gerar miniaturas para formas individuais ou regiões específicas de um slide, e elas respeitarão o novo tamanho do slide?**

Sim. Aspose.Slides pode renderizar miniaturas para [slides inteiros](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) assim como para [formas selecionadas](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#getImage-int-float-float-). As imagens resultantes refletem o tamanho e a proporção atuais do slide, garantindo enquadramento e geometria consistentes.