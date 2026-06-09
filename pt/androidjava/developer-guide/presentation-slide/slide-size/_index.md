---
title: Alterar o Tamanho do Slide da Apresentação no Android
linktitle: Tamanho do Slide
type: docs
weight: 70
url: /pt/androidjava/slide-size/
keywords:
- tamanho do slide
- proporção
- padrão
- tela larga
- 4:3
- 16:9
- definir tamanho do slide
- alterar tamanho do slide
- tamanho de slide personalizado
- tamanho de slide especial
- tamanho de slide único
- slide em tamanho real
- tipo de tela
- não dimensionar
- assegurar ajuste
- maximizar
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
descriptions: "Redimensione rapidamente slides em arquivos PPT, PPTX e ODP com Java e Aspose.Slides para Android, otimize apresentações para qualquer tela sem perder qualidade."
---
## **Introdução**

Aspose.Slides fornece ferramentas abrangentes para ajustar o tamanho do slide e a proporção da imagem em apresentações do PowerPoint, críticas tanto para impressão quanto para exibição em tela.

Tamanhos de Slide e Proporções Populares:

- **Padrão (Proporção 4:3)**: Ideal para telas e dispositivos mais antigos.
- **Tela Larga (Proporção 16:9)**: Recomendado para projetores e monitores modernos.

Garanta consistência em toda a apresentação, pois um único tamanho de slide e proporção são aplicados a todos os slides. Para obter resultados ideais, defina as dimensões dos slides no início do processo de criação da apresentação para evitar complicações.

{{% alert color="primary" %}} 
Por padrão, apresentações criadas com Aspose.Slides utilizam a proporção padrão 4:3.
{{% /alert %}}

## **Alterar o Tamanho do Slide em Apresentações**

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

## **Especificar Tamanhos de Slide Personalizados em Apresentações**

Se os tamanhos de slide comuns (4:3 e 16:9) não forem adequados ao seu trabalho, você pode optar por usar um tamanho de slide específico ou único. Por exemplo, se planeja imprimir slides em tamanho real a partir da sua apresentação em um layout de página customizado ou se pretende exibir a apresentação em determinados tipos de tela, provavelmente se beneficiará ao usar uma configuração de tamanho personalizada para a sua apresentação.

Este código de exemplo mostra como usar Aspose.Slides para Android via Java para especificar um tamanho de slide personalizado para uma apresentação em Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // tamanho de papel A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Manipular o Conteúdo do Slide Após Redimensionamento**

Depois de alterar o tamanho do slide de uma apresentação, o conteúdo dos slides (imagens ou objetos, por exemplo) pode ficar distorcido. Por padrão, os objetos são redimensionados automaticamente para se ajustarem ao novo tamanho do slide. Contudo, ao alterar o tamanho do slide de uma apresentação, você pode especificar uma configuração que determina como o Aspose.Slides lida com o conteúdo dos slides.

Dependendo do que você pretende fazer ou alcançar, pode usar qualquer uma dessas configurações:

- `DoNotScale`

  Se NÃO quiser que os objetos nos slides sejam redimensionados, use esta configuração.

- `EnsureFit`

  Se quiser redimensionar para um slide menor e precisar que o Aspose.Slides reduza os objetos dos slides para garantir que todos caibam nos slides (evitando perda de conteúdo), use esta configuração.

- `Maximize`

  Se quiser redimensionar para um slide maior e precisar que o Aspose.Slides amplie os objetos dos slides para torná‑los proporcionais ao novo tamanho, use esta configuração.

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

Sim. O Aspose.Slides usa pontos internamente, onde 1 ponto equivale a 1/72 de polegada. Você pode converter qualquer unidade (como milímetros ou centímetros) para pontos e usar os valores convertidos para definir a largura e a altura do slide.

**Um tamanho de slide personalizado muito grande afetará o desempenho e o uso de memória durante a renderização?**

Sim. Dimensões de slide maiores (em pontos) combinadas com escala de renderização mais alta levam a maior consumo de memória e tempos de processamento mais longos. Procure um tamanho de slide prático e ajuste a escala de renderização somente quando necessário para alcançar a qualidade de saída desejada.

**Posso definir um tamanho de slide não padrão e depois mesclar slides de apresentações que têm tamanhos diferentes?**

Você não pode [merge presentations](/slides/pt/androidjava/merge-presentation/) enquanto elas têm tamanhos de slide diferentes — primeiro, redimensione uma apresentação para corresponder à outra. Ao mudar o tamanho do slide, você pode escolher como o conteúdo existente será tratado via a opção [SlideSizeScaleType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidesizescaletype/). Após alinhar os tamanhos, é possível mesclar slides preservando a formatação.

**Posso gerar miniaturas para formas individuais ou regiões específicas de um slide, e elas respeitarão o novo tamanho do slide?**

Sim. O Aspose.Slides pode renderizar miniaturas para [entire slides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) assim como para [selected shapes](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). As imagens resultantes refletem o tamanho atual do slide e a proporção, garantindo enquadramento e geometria consistentes.