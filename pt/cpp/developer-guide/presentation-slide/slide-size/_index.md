---
title: Alterar o Tamanho do Slide da Apresentação em C++
linktitle: Tamanho do Slide
type: docs
weight: 70
url: /pt/cpp/slide-size/
keywords:
- tamanho do slide
- proporção de aspecto
- padrão
- tela larga
- 4:3
- 16:9
- definir tamanho do slide
- alterar tamanho do slide
- tamanho de slide personalizado
- tamanho de slide especial
- tamanho de slide exclusivo
- slide em tamanho completo
- tipo de tela
- não escalar
- garantir ajuste
- maximizar
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aprenda como redimensionar rapidamente slides em arquivos PPT, PPTX e ODP com C++ e Aspose.Slides, otimize apresentações para qualquer tela sem perder qualidade."
---
## **Introdução**

Aspose.Slides fornece ferramentas abrangentes para ajustar o tamanho do slide e a proporção de aspecto em apresentações do PowerPoint, essencial tanto para impressão quanto para exibição em tela.

Tamanhos de slide populares e proporções:

- **Padrão (Proporção 4:3)**: Ideal para telas e dispositivos mais antigos.
- **Tela larga (Proporção 16:9)**: Recomendado para projetores e monitores modernos.

Garanta consistência em toda a sua apresentação, pois um único tamanho de slide e proporção de aspecto se aplicam a todos os slides. Para resultados ideais, defina as dimensões dos slides no início do processo de criação da apresentação para evitar complicações.

{{% alert color="primary" %}} 
Por padrão, as apresentações criadas com Aspose.Slides usam a proporção padrão 4:3.
{{% /alert %}}

## **Alterar o tamanho do slide em apresentações**

Este código de exemplo mostra como alterar o tamanho do slide em uma apresentação em C++ usando Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Especificar tamanhos de slide personalizados em apresentações**

Se os tamanhos de slide comuns (4:3 e 16:9) não forem adequados para o seu trabalho, você pode decidir usar um tamanho de slide específico ou exclusivo. Por exemplo, se planeja imprimir slides em tamanho real a partir da sua apresentação em um layout de página personalizado ou se pretende exibir sua apresentação em certos tipos de tela, provavelmente se beneficiará ao usar uma configuração de tamanho personalizada para a sua apresentação.

Este código de exemplo mostra como usar Aspose.Slides para C++ para especificar um tamanho de slide personalizado para uma apresentação em C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Tamanho de papel A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Manipular o conteúdo do slide após redimensionamento**

Após alterar o tamanho do slide de uma apresentação, o conteúdo dos slides (imagens ou objetos, por exemplo) pode ficar distorcido. Por padrão, os objetos são redimensionados automaticamente para se ajustarem ao novo tamanho do slide. No entanto, ao mudar o tamanho do slide de uma apresentação, você pode especificar uma configuração que determina como Aspose.Slides lida com o conteúdo nos slides.

Dependendo do que você pretende fazer ou alcançar, pode usar qualquer uma dessas configurações:

- `DoNotScale`

  Se NÃO desejar que os objetos nos slides sejam redimensionados, use esta configuração.

- `EnsureFit`

  Se desejar redimensionar para um tamanho de slide menor e precisar que Aspose.Slides reduza os objetos dos slides para garantir que todos caibam nos slides (dessa forma, você evita a perda de conteúdo), use esta configuração.

- `Maximize`

  Se quiser redimensionar para um tamanho de slide maior e precisar que Aspose.Slides aumente os objetos dos slides para torná‑los proporcionais ao novo tamanho do slide, use esta configuração.

Este código de exemplo mostra como usar a configuração `Maximize` ao mudar o tamanho do slide de uma apresentação:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **Perguntas frequentes**

**Posso definir um tamanho de slide personalizado usando unidades diferentes de polegadas (por exemplo, pontos ou milímetros)?**

Sim. Aspose.Slides usa pontos internamente, onde 1 ponto equivale a 1/72 de polegada. Você pode converter qualquer unidade (como milímetros ou centímetros) para pontos e usar os valores convertidos para definir a largura e a altura do slide.

**Um tamanho de slide personalizado muito grande afetará o desempenho e o uso de memória durante a renderização?**

Sim. Dimensões de slide maiores (em pontos) combinadas com escala de renderização mais alta resultam em maior consumo de memória e tempos de processamento mais longos. Procure um tamanho de slide prático e ajuste a escala de renderização apenas conforme necessário para alcançar a qualidade de saída desejada.

**Posso definir um tamanho de slide não padrão e, em seguida, mesclar slides de apresentações que têm tamanhos diferentes?**

Você não pode [mesclar apresentações](/slides/pt/cpp/merge-presentation/) enquanto elas têm tamanhos de slide diferentes — primeiro, redimensione uma apresentação para corresponder à outra. Ao alterar o tamanho do slide, você pode escolher como o conteúdo existente é tratado via a opção [SlideSizeScaleType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slidesizescaletype/). Após alinhar os tamanhos, você pode mesclar os slides mantendo a formatação.

**Posso gerar miniaturas para formas individuais ou regiões específicas de um slide, e elas respeitarão o novo tamanho do slide?**

Sim. Aspose.Slides pode renderizar miniaturas para [slides inteiros](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slide/getimage/) bem como para [formas selecionadas](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/getimage/). As imagens resultantes refletem o tamanho e a proporção de aspecto atuais do slide, garantindo enquadramento e geometria consistentes.