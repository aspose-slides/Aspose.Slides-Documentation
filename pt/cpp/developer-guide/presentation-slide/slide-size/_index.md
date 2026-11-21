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
description: "Aprenda a redimensionar rapidamente slides em arquivos PPT, PPTX e ODP com C++ e Aspose.Slides, otimize apresentações para qualquer tela sem perder qualidade."
---
## **Introdução**

Aspose.Slides fornece ferramentas abrangentes para ajustar o tamanho do slide e a proporção da tela em apresentações do PowerPoint, essencial tanto para impressão quanto para exibição em tela. 

Tamanhos de Slide Populares e Proporções:

- **Padrão (Proporção 4:3)**: Ideal para telas e dispositivos mais antigos.
- **Tela Larga (Proporção 16:9)**: Recomendado para projetores e monitores modernos.

Garanta consistência em toda a sua apresentação, pois um único tamanho de slide e proporção são aplicados a todos os slides. Para resultados ideais, defina as dimensões do slide no início do processo de criação da apresentação para evitar complicações.

{{% alert color="info" %}} 
Por padrão, as apresentações criadas com Aspose.Slides utilizam a proporção padrão 4:3.
{{% /alert %}}

As páginas de notas e de folhetos têm dimensões separadas dos slides regulares. Consulte [Tamanho da Página de Notas](/slides/pt/cpp/notes-size/) para alterar seu tamanho e orientação.

## **Alterar o Tamanho do Slide em Apresentações**

Este código de exemplo mostra como alterar o tamanho do slide em uma apresentação em C++ usando Aspose.Slides:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Especificar Tamanhos de Slide Personalizados em Apresentações**

Se os tamanhos de slide comuns (4:3 e 16:9) não forem adequados ao seu trabalho, você pode optar por usar um tamanho de slide específico ou exclusivo. Por exemplo, se planeja imprimir slides em tamanho real a partir de sua apresentação em um layout de página personalizado ou se pretende exibir sua apresentação em determinados tipos de tela, provavelmente se beneficiará ao usar uma configuração de tamanho personalizado para sua apresentação. 

Este código de exemplo mostra como usar Aspose.Slides para C++ para especificar um tamanho de slide personalizado para uma apresentação em C++:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// tamanho de papel A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Manipular o Conteúdo do Slide Após Redimensionamento**

Depois de alterar o tamanho do slide de uma apresentação, o conteúdo dos slides (imagens ou objetos, por exemplo) pode ficar distorcido. Por padrão, os objetos são redimensionados automaticamente para se ajustarem ao novo tamanho do slide. No entanto, ao mudar o tamanho do slide de uma apresentação, você pode especificar uma configuração que determina como o Aspose.Slides lida com o conteúdo dos slides.

Dependendo do que você pretende fazer ou alcançar, você pode usar qualquer uma dessas configurações:

- `DoNotScale`

  Se NÃO deseja que os objetos nos slides sejam redimensionados, use esta configuração.

- `EnsureFit`

  Se deseja reduzir para um tamanho de slide menor e precisa que o Aspose.Slides reduza os objetos dos slides para garantir que todos caibam nos slides (assim, você evita perder conteúdo), use esta configuração. 

- `Maximize`

  Se deseja ampliar para um tamanho de slide maior e precisa que o Aspose.Slides aumente os objetos dos slides para torná-los proporcionais ao novo tamanho do slide, use esta configuração. 

Este código de exemplo mostra como usar a configuração `Maximize` ao alterar o tamanho do slide de uma apresentação:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **Perguntas Frequentes**

### Posso definir um tamanho de slide personalizado usando unidades diferentes de polegadas (por exemplo, pontos ou milímetros)?

Sim. Aspose.Slides usa pontos internamente, onde 1 ponto equivale a 1/72 de polegada. Você pode converter qualquer unidade (como milímetros ou centímetros) para pontos e usar os valores convertidos para definir a largura e altura do slide.

### Um tamanho de slide personalizado muito grande afetará o desempenho e o uso de memória durante a renderização?

Sim. Dimensões de slide maiores (em pontos) combinadas com escala de renderização mais alta levam a maior consumo de memória e tempos de processamento mais longos. Busque um tamanho de slide prático e ajuste a escala de renderização apenas conforme necessário para atingir a qualidade de saída desejada.

### Posso definir um tamanho de slide não padrão e então mesclar slides de apresentações que têm tamanhos diferentes?

Você não pode [mesclar apresentações](/slides/pt/cpp/merge-presentation/) enquanto elas têm tamanhos de slide diferentes — primeiro, redimensione uma apresentação para corresponder à outra. Ao mudar o tamanho do slide, você pode escolher como o conteúdo existente será tratado via a opção [SlideSizeScaleType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slidesizescaletype/). Após alinhar os tamanhos, você pode mesclar slides preservando a formatação.

### Posso gerar miniaturas para formas individuais ou regiões específicas de um slide, e elas respeitarão o novo tamanho do slide?

Sim. Aspose.Slides pode renderizar miniaturas para [slides inteiros](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slide/getimage/) assim como para [formas selecionadas](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/getimage/). As imagens resultantes refletem o tamanho atual do slide e a proporção da tela, garantindo enquadramento e geometria consistentes.