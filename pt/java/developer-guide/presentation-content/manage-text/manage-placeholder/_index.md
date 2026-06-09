---
title: Gerenciar Marcadores de Posição em Java
linktitle: Gerenciar Marcadores
type: docs
weight: 10
url: /pt/java/manage-placeholder/
keywords:
- marcador de posição
- marcador de posição de texto
- marcador de posição de imagem
- marcador de posição de gráfico
- texto de prompt
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Gerencie marcadores de posição no Aspose.Slides para Java de forma simples: substitua texto, personalize prompts e defina transparência de imagem no PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite que você gerencie marcadores de posição de apresentações programaticamente. Este artigo explica como encontrar marcadores de posição nos slides e mudar seu texto, definir texto de prompt personalizado para layouts de marcadores de posição e ajustar a transparência de uma imagem usada como plano de fundo de marcador de posição. Também inclui um breve FAQ que esclarece a diferença entre marcadores de posição base e formas locais, explica como as alterações de marcador de posição podem ser aplicadas através de layouts ou mestres, e aponta para o gerenciamento de marcadores de posição de cabeçalho e rodapé.

## **Alterar texto em um marcador de posição**
Usando [Aspose.Slides for Java](/slides/pt/java/), você pode encontrar e modificar marcadores de posição nos slides de apresentações. Aspose.Slides permite que você faça alterações no texto de um marcador de posição.

**Pré-requisito**: Você precisa de uma apresentação que contenha um marcador de posição. Você pode criar essa apresentação no aplicativo padrão Microsoft PowerPoint.

Esta é a forma de usar Aspose.Slides para substituir o texto no marcador de posição naquela apresentação:

1. Instancie a classe [`Presentation`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) e passe a apresentação como argumento.  
2. Obtenha uma referência ao slide através de seu índice.  
3. Itere pelas formas para encontrar o marcador de posição.  
4. Converta a forma de marcador de posição para um [`AutoShape`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/AutoShape) e altere o texto usando o [`TextFrame`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/TextFrame) associado ao [`AutoShape`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/AutoShape).  
5. Salve a apresentação modificada.

Este código Java mostra como alterar o texto em um marcador de posição:

```java
// Instancia uma classe Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Acessa o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Itera pelas formas para encontrar o marcador de posição
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Altera o texto em cada marcador de posição
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Salva a apresentação no disco
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir texto de prompt em um marcador de posição**
Layouts padrão e pré-construídos contêm textos de prompt de marcador de posição como ***Clique para adicionar um título*** ou ***Clique para adicionar um subtítulo***. Usando Aspose.Slides, você pode inserir seus textos de prompt preferidos em layouts de marcador de posição.

Este código Java mostra como definir o texto de prompt em um marcador de posição:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Itera pelo slide
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint exibe "Clique para adicionar título" 
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Adiciona subtítulo
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir transparência da imagem do marcador de posição**

Aspose.Slides permite definir a transparência da imagem de fundo em um marcador de posição de texto. Ao ajustar a transparência da imagem em tal quadro, você pode fazer o texto ou a imagem se destacar (dependendo das cores do texto e da imagem).

Este código Java mostra como definir a transparência para um fundo de imagem (dentro de uma forma):

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**O que é um marcador de posição base e como ele difere de uma forma local em um slide?**

Um marcador de posição base é a forma original em um layout ou mestre que a forma do slide herda—tipo, posição e parte da formatação vêm dele. Uma forma local é independente; se não houver um marcador de posição base, a herança não se aplica.

**Como atualizar todos os títulos ou legendas em toda a apresentação sem iterar por cada slide?**

Edite o marcador de posição correspondente no layout ou no mestre. Slides baseados nesses layouts ou naquele mestre herdarão a alteração automaticamente.

**Como controlo os marcadores de posição padrão de cabeçalho/rodapé—data & hora, número do slide e texto do rodapé?**

Use os gerenciadores HeaderFooter no escopo apropriado (slides normais, layouts, mestre, anotações/distribuições) para ativar ou desativar esses marcadores de posição e definir seu conteúdo.