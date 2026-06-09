---
title: Converter Slides PowerPoint para PNG em C++
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

Este artigo explica como converter apresentações do PowerPoint em imagens PNG usando Aspose.Slides. Ele mostra como carregar arquivos de apresentação em formatos como PPT, PPTX e ODP, renderizar os slides como imagens e salvar os resultados no formato PNG.

O artigo também demonstra como personalizar as imagens PNG geradas definindo valores de escala ou especificando a largura e altura desejadas.

## **Converter PowerPoint para PNG**

Siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
2. Obtenha o objeto de slide da coleção [Presentation::get_Slides()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) sob a interface [ISlide](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_slide).
3. Use o método [ISlide::GetImage()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/getimage) para obter a miniatura de cada slide.
4. Use o método [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) para salvar a miniatura do slide no formato PNG.

Este código C++ mostra como converter uma apresentação PowerPoint em PNG:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **Converter PowerPoint para PNG com dimensões personalizadas**

Se você deseja obter arquivos PNG em uma certa escala, pode definir os valores para `desiredX` e `desiredY`, que determinam as dimensões da miniatura resultante.

Este código em C++ demonstra a operação descrita:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **Converter PowerPoint para PNG com tamanho personalizado**

Se você deseja obter arquivos PNG com um tamanho específico, pode passar os argumentos `width` e `height` desejados para `ImageSize`.

Este código mostra como converter um PowerPoint para PNG especificando o tamanho das imagens:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

## **FAQ**

**Como exportar apenas uma forma específica (por exemplo, gráfico ou imagem) em vez de todo o slide?**

Aspose.Slides oferece suporte à [generating thumbnails for individual shapes](/slides/pt/cpp/create-shape-thumbnails/); você pode renderizar uma forma para uma imagem PNG.

**A conversão paralela é suportada em um servidor?**

Sim, mas [don’t share](/slides/pt/cpp/multithreading/) uma única instância de apresentação entre threads. Use uma instância separada por thread ou processo.

**Quais são as limitações da versão de avaliação ao exportar para PNG?**

O modo de avaliação adiciona uma marca d'água às imagens de saída e impõe [other restrictions](/slides/pt/cpp/licensing/) até que uma licença seja aplicada.