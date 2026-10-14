---
title: Converter slides PowerPoint para PNG em C++
linktitle: PowerPoint para PNG
type: docs
weight: 30
url: /pt/cpp/convert-powerpoint-to-png/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para PNG
- apresentação para PNG
- slide para PNG
- PPT para PNG
- PPTX para PNG
- salvar PPT como PNG
- salvar PPTX como PNG
- exportar PPT para PNG
- exportar PPTX para PNG
- C++
- Aspose.Slides
description: "Converta apresentações PowerPoint em imagens PNG de alta qualidade rapidamente com Aspose.Slides para C++, garantindo resultados precisos e automatizados."
---
## **Visão geral**

Este artigo explica como converter slides de apresentação em imagens PNG usando Aspose.Slides para C++. Você pode carregar apresentações em formatos como PPT, PPTX e ODP, renderizar cada slide e salvá‑lo como uma imagem PNG separada.

Os exemplos abaixo demonstram a renderização na escala padrão, o aumento da escala, a especificação das dimensões de saída em pixels e a escolha de um estilo de renderização de gradiente.

## **Converter PowerPoint em PNG**

Carregue uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) e acesse seus slides através do acessador [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/). O exemplo renderiza cada slide com [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) sem parâmetros para criar uma miniatura. Em seguida, chama [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) com [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) para salvar cada slide renderizado como uma imagem PNG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
A sobrecarga sem parâmetros de [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) renderiza com uma escala de 0,2. Por exemplo, um slide que mede 720 × 540 pontos produz uma miniatura de 144 × 108 pixels. Para controlar as dimensões de saída, use as sobrecargas com fatores de escala ou um tamanho de imagem explícito mostrado abaixo.
{{% /alert %}}

## **Converter PowerPoint em PNG com Dimensões Personalizadas**

Passe fatores de escala horizontal e vertical para [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) para controlar as dimensões renderizadas. Neste exemplo, ambos os fatores são 2, portanto um slide que mede 720 × 540 pontos produz uma imagem de 1440 × 1080 pixels. Fatores de escala iguais preservam a proporção do slide. Cada imagem é salva no formato PNG com [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Converter PowerPoint em PNG com Tamanho Personalizado**

Para especificar as dimensões de saída em pixels, passe um tamanho para [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) em vez de fatores de escala. Este exemplo renderiza cada slide em 960 × 720 pixels e salva o resultado com [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Escolha dimensões que correspondam à proporção do slide para evitar distorção da imagem.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Escolher um Estilo de Renderização de Gradiente**

Suponha que um slide contenha preenchimentos degradê, mas as transições no PNG exportado pareçam mais claras ou diferentes do que você vê no PowerPoint. Você pode usar o método [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) de [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) para escolher como os gradientes são renderizados.

Faça o download de [gradient-styles.pptx](gradient-styles.pptx) e coloque‑o no diretório de trabalho da aplicação. Seu primeiro slide contém dois gradientes lineares: ciano para laranja na parte superior e azul para amarelo na parte inferior. Cada gradiente tem duas paradas, em 0% e 100%.

O exemplo a seguir carrega esta apresentação e renderiza o mesmo primeiro slide em ambos os modos com [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

As imagens abaixo mostram a saída do mesmo slide, com ambos os gradientes em cada imagem:

| Default | PowerPointUI |
| --- | --- |
| ![Gradientes de ciano para laranja e azul para amarelo renderizados com Default](gradient-Default.png) | ![Os mesmos gradientes renderizados com PowerPointUI](gradient-PowerPointUI.png) |

Neste exemplo, `Default` produz cores intermediárias mais claras, enquanto `PowerPointUI` produz cores intermediárias mais escuras. A diferença depende das cores e das paradas no gradiente.

Escolha `Default` quando a saída padrão do Aspose.Slides atender às suas necessidades. Experimente `PowerPointUI` quando sua prioridade for corresponder à aparência no PowerPoint. Compare ambas as saídas com o resultado desejado; nenhum modo é universalmente preferível.

## **Perguntas frequentes**

**Como posso exportar uma forma específica, como um gráfico ou imagem, em vez de todo o slide?**

O Aspose.Slides oferece suporte a [gerar miniaturas para formas individuais](/slides/pt/cpp/shape-thumbnails/), permitindo renderizar uma forma como uma imagem PNG.

**A conversão paralela é suportada em um servidor?**

Sim. Use uma instância de apresentação separada para cada thread ou processo; [não compartilhe uma única instância entre threads](/slides/pt/cpp/multithreading/).

**Quais são as limitações da avaliação ao exportar para PNG?**

O modo de avaliação adiciona uma marca d’água às imagens de saída e aplica [outras restrições](/slides/pt/cpp/licensing/) até que uma licença seja aplicada.