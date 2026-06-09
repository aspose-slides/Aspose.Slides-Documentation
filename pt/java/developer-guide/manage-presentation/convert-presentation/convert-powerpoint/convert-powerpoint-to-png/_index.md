---
title: Converter Slides do PowerPoint para PNG em Java
linktitle: PowerPoint para PNG
type: docs
weight: 30
url: /pt/java/convert-powerpoint-to-png/
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
- Java
- Aspose.Slides
description: "Converta apresentações do PowerPoint em imagens PNG de alta qualidade rapidamente com Aspose.Slides para Java, garantindo resultados precisos e automatizados."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint em imagens PNG usando Aspose.Slides. Ele mostra como carregar arquivos de apresentação em formatos como PPT, PPTX e ODP, renderizar slides como imagens e salvar os resultados no formato PNG.

O artigo também demonstra como personalizar as imagens PNG geradas definindo valores de escala ou especificando a largura e a altura desejadas.

## **Converter PowerPoint para PNG**

Siga estas etapas:

1. Instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
2. Obter o objeto slide da coleção [Presentation.getSlides()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation#getSlides--) sob a interface [ISlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISlide).
3. Usar o método [ISlide.getImage()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISlide) para obter a miniatura de cada slide.
4. Usar o método [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) para salvar a miniatura do slide no formato PNG.

Este código Java mostra como converter uma apresentação PowerPoint para PNG:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Converter PowerPoint para PNG com Dimensões Personalizadas**

Se quiser obter arquivos PNG em uma certa escala, você pode definir os valores para `desiredX` e `desiredY`, que determinam as dimensões da miniatura resultante.

Este código em Java demonstra a operação descrita:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Converter PowerPoint para PNG com Tamanho Personalizado**

Se quiser obter arquivos PNG em um tamanho específico, pode passar os argumentos `width` e `height` desejados para `ImageSize`.

Este código mostra como converter um PowerPoint para PNG especificando o tamanho das imagens:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Como exportar apenas uma forma específica (por exemplo, gráfico ou imagem) em vez de todo o slide?**

Aspose.Slides suporta [gerar miniaturas para formas individuais](/slides/pt/java/create-shape-thumbnails/); você pode renderizar uma forma em uma imagem PNG.

**A conversão paralela é suportada em um servidor?**

Sim, mas [não compartilhe](/slides/pt/java/multithreading/) uma única instância de apresentação entre threads. Use uma instância separada por thread ou processo.

**Quais são as limitações da versão de avaliação ao exportar para PNG?**

O modo de avaliação adiciona uma marca d’água às imagens de saída e impõe [outras restrições](/slides/pt/java/licensing/) até que uma licença seja aplicada.