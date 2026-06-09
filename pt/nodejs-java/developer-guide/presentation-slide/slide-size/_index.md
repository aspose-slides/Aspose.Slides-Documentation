---
title: Alterar o Tamanho do Slide da Apresentação em JavaScript
linktitle: Tamanho do Slide
type: docs
weight: 70
url: /pt/nodejs-java/slide-size/
keywords:
- tamanho do slide
- proporção da tela
- padrão
- tela larga
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
- Node.js
- JavaScript
- Aspose.Slides
descriptions: "Aprenda a redimensionar rapidamente slides em arquivos PPT, PPTX e ODP com Node.js e Aspose.Slides, otimize apresentações para qualquer tela sem perder qualidade."
---
## **Introdução**

Aspose.Slides fornece ferramentas abrangentes para ajustar o tamanho do slide e a proporção da tela em apresentações do PowerPoint, essencial tanto para impressão quanto para exibição em tela.

Tamanhos de Slide Populares e Proporções:

- **Padrão (Proporção 4:3)**: Ideal para telas e dispositivos mais antigos.
- **Tela larga (Proporção 16:9)**: Recomendado para projetores e monitores modernos.

Garanta consistência em toda a sua apresentação, pois um único tamanho de slide e proporção se aplicam a todos os slides. Para resultados ideais, defina as dimensões do slide no início do processo de criação da apresentação para evitar complicações.

{{% alert color="primary" %}} 
Por padrão, apresentações criadas com Aspose.Slides usam a proporção padrão 4:3.
{{% /alert %}}

## **Alterando o Tamanho do Slide em Apresentações**

Este código de exemplo mostra como alterar o tamanho do slide em uma apresentação em JavaScript usando Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Especificando Tamanhos de Slide Personalizados em Apresentações**

Se os tamanhos de slide comuns (4:3 e 16:9) não forem adequados para o seu trabalho, você pode decidir usar um tamanho de slide específico ou único. Por exemplo, se planeja imprimir slides em tamanho real da sua apresentação em um layout de página personalizado ou se pretende exibir sua apresentação em determinados tipos de tela, provavelmente se beneficiará ao usar uma configuração de tamanho personalizado para sua apresentação.

Este código de exemplo mostra como usar Aspose.Slides para Node.js via Java para especificar um tamanho de slide personalizado para uma apresentação em JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// tamanho de papel A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lidando com Problemas ao Alterar o Tamanho dos Slides em Apresentações**

Depois de alterar o tamanho do slide de uma apresentação, o conteúdo dos slides (imagens ou objetos, por exemplo) pode ficar distorcido. Por padrão, os objetos são redimensionados automaticamente para se ajustarem ao novo tamanho do slide. No entanto, ao alterar o tamanho do slide de uma apresentação, você pode especificar uma configuração que determina como o Aspose.Slides lida com o conteúdo dos slides.

Dependendo do que você pretende fazer ou alcançar, pode usar qualquer uma dessas configurações:

- `DoNotScale`

  Se você NÃO deseja que os objetos nos slides sejam redimensionados, use esta configuração.

- `EnsureFit`

  Se você deseja redimensionar para um tamanho de slide menor e precisa que o Aspose.Slides diminua os objetos dos slides para garantir que todos caibam nos slides (assim, você evita perder conteúdo), use esta configuração.

- `Maximize`

  Se você deseja redimensionar para um tamanho de slide maior e precisa que o Aspose.Slides aumente os objetos dos slides para que fiquem proporcionais ao novo tamanho do slide, use esta configuração.

Este código de exemplo mostra como usar a configuração `Maximize` ao alterar o tamanho do slide de uma apresentação:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso definir um tamanho de slide personalizado usando unidades diferentes de polegadas (por exemplo, pontos ou milímetros)?**

Sim. Aspose.Slides usa pontos internamente, onde 1 ponto equivale a 1/72 de polegada. Você pode converter qualquer unidade (como milímetros ou centímetros) para pontos e usar os valores convertidos para definir a largura e a altura do slide.

**Um tamanho de slide personalizado muito grande afetará o desempenho e o uso de memória durante a renderização?**

Sim. Dimensões de slide maiores (em pontos) combinadas com uma escala de renderização maior levam a um aumento no consumo de memória e tempos de processamento mais longos. Procure um tamanho de slide prático e ajuste a escala de renderização apenas quando necessário para alcançar a qualidade de saída desejada.

**Posso definir um tamanho de slide não padrão e, em seguida, mesclar slides de apresentações que têm tamanhos diferentes?**

Você não pode [mesclar apresentações](/slides/pt/nodejs-java/merge-presentation/) enquanto elas têm tamanhos de slide diferentes — primeiro, redimensione uma apresentação para combinar com a outra. Ao mudar o tamanho do slide, você pode escolher como o conteúdo existente será tratado via a opção [SlideSizeScaleType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidesizescaletype/). Após alinhar os tamanhos, você pode mesclar slides preservando a formatação.

**Posso gerar miniaturas para formas individuais ou regiões específicas de um slide, e elas respeitarão o novo tamanho do slide?**

Sim. Aspose.Slides pode renderizar miniaturas para [slides inteiros](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#getImage) assim como para [formas selecionadas](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getImage). As imagens resultantes refletem o tamanho e a proporção atuais do slide, garantindo enquadramento e geometria consistentes.