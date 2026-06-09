---
title: Gerenciar Espaços Reservados de Apresentação no Android
linktitle: Gerenciar Espaços Reservados
type: docs
weight: 10
url: /pt/androidjava/manage-placeholder/
keywords:
- espaço reservado
- espaço reservado de texto
- espaço reservado de imagem
- espaço reservado de gráfico
- texto de sugestão
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Gerencie espaços reservados no Aspose.Slides para Android via Java com facilidade: substitua texto, personalize sugestões e defina a transparência de imagens em PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite que você gerencie espaços reservados de apresentação programaticamente. Este artigo explica como encontrar espaços reservados em slides e mudar seu texto, definir texto de sugestão personalizado para layouts de espaço reservado e ajustar a transparência de uma imagem usada como plano de fundo de um espaço reservado. Também inclui um breve FAQ que esclarece a diferença entre espaços reservados base e formas locais, explica como as alterações de espaço reservado podem ser aplicadas por meio de layouts ou mestres, e aponta para a gestão de espaços reservados de cabeçalho e rodapé.

## **Alterar texto em um espaço reservado**
Usando [Aspose.Slides para Android via Java](/slides/pt/androidjava/), você pode encontrar e modificar espaços reservados em slides de apresentações. Aspose.Slides permite que você faça alterações no texto de um espaço reservado.

**Pré‑requisito**: Você precisa de uma apresentação que contenha um espaço reservado. Você pode criar essa apresentação no aplicativo padrão Microsoft PowerPoint.

Assim você usa Aspose.Slides para substituir o texto no espaço reservado naquela apresentação:

1. Instancie a classe [`Presentation`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) e passe a apresentação como argumento.
2. Obtenha uma referência ao slide por seu índice.
3. Percorra as formas para encontrar o espaço reservado.
4. Converta a forma do espaço reservado para um [`AutoShape`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/AutoShape) e altere o texto usando o [`TextFrame`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/TextFrame) associado ao [`AutoShape`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/AutoShape).
5. Salve a apresentação modificada.

Este código Java mostra como alterar o texto em um espaço reservado:

```java
// Instancia a classe Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Acessa o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Itera pelas formas para encontrar o espaço reservado
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Altera o texto em cada espaço reservado
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Salva a apresentação no disco
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir texto de sugestão em um espaço reservado**
Layouts padrão e pré‑construídos contêm textos de sugestão de espaço reservado, como ***Clique para adicionar um título*** ou ***Clique para adicionar um subtítulo***. Usando Aspose.Slides, você pode inserir seus próprios textos de sugestão nos layouts de espaço reservado.

Este código Java mostra como definir o texto de sugestão em um espaço reservado:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Itera pelas formas do slide
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

## **Definir transparência da imagem do espaço reservado**

Aspose.Slides permite definir a transparência da imagem de fundo em um espaço reservado de texto. Ajustando a transparência da imagem em tal quadro, você pode fazer o texto ou a imagem se destacar (dependendo das cores do texto e da imagem).

Este código Java mostra como definir a transparência para o fundo de uma imagem (dentro de uma forma):

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

**O que é um espaço reservado base e como ele difere de uma forma local em um slide?**

Um espaço reservado base é a forma original em um layout ou mestre que a forma do slide herda — tipo, posição e parte da formatação vêm dele. Uma forma local é independente; se não houver um espaço reservado base, a herança não se aplica.

**Como posso atualizar todos os títulos ou legendas em uma apresentação sem iterar sobre cada slide?**

Edite o espaço reservado correspondente no layout ou no mestre. Slides baseados nesses layouts/nesse mestre herdarão automaticamente a alteração.

**Como controlo os espaços reservados padrão de cabeçalho/rodapé — data e hora, número do slide e texto do rodapé?**

Use os gerenciadores HeaderFooter no escopo apropriado (slides normais, layouts, mestre, anotações/folhetos) para ativar ou desativar esses espaços reservados e definir seu conteúdo.