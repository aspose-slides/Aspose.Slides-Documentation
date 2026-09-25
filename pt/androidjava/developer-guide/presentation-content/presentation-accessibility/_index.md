---
title: Gerenciar Acessibilidade de Apresentação no Android
linktitle: Acessibilidade de Apresentação
type: docs
weight: 30
url: /pt/androidjava/presentation-accessibility/
keywords:
- acessibilidade de apresentação
- texto alternativo
- título de texto alternativo
- descrição de texto alternativo
- marcar como decorativo
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Descubra como o Aspose.Slides para Android via Java ajuda a automatizar verificações de acessibilidade de apresentações em arquivos PPT, PPTX e ODP — melhore a experiência de leitores de tela e aumente a conformidade."
---
## **Introdução**

Texto alternativo ajuda pessoas que utilizam tecnologias assistivas a entender o significado de imagens, gráficos e outras formas informativas. Este artigo explica como ler e atualizar títulos e descrições de texto alternativo com Aspose.Slides para Android via Java, distinguir descrições de acessibilidade dos nomes de forma usados no código e verificar se uma forma está marcada como decorativa.

Esses recursos suportam a acessibilidade de apresentações, mas não a garantem. A ordem de leitura, o contraste de cores, a legibilidade do texto e outros requisitos de acessibilidade também precisam ser revisados.

## **Gerenciar Títulos e Descrições de Texto Alternativo**

Use texto alternativo para explicar o significado de imagens, gráficos e outras formas informativas para pessoas que não podem vê‑las. Os métodos e conteúdos a seguir servem a propósitos diferentes:

| Método ou conteúdo | Propósito |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Um título curto para a descrição alternativa. |
| [getAlternativeText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | Uma descrição significativa do conteúdo ou propósito da forma no contexto do slide. |
| [getName](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getName--) | O nome da forma, que o código pode usar para encontrar uma forma específica na apresentação. |
| Texto visível | Conteúdo exibido no slide, como o texto de uma forma ou o título e os rótulos de um gráfico. Atualizar o texto alternativo não altera esse conteúdo. |

Quando uma apresentação é reutilizada como modelo, o código pode encontrar uma forma pelo nome retornado por [getName](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getName--) antes de atualizá‑la. Esse nome tem um propósito diferente do texto alternativo, que explica o que o visual comunica ao leitor. Pesquisar pelo nome permite que os autores melhorem ou traduam descrições sem alterar como o código encontra a forma. Os nomes podem ser editados e não são garantidos como únicos, portanto verifique se o nome corresponde à forma desejada; veja [Identify and Find Shapes](/slides/pt/androidjava/shape-manipulations/#identify-and-find-shapes).

O exemplo a seguir requer `input.pptx` com uma imagem de uma entrada de escritório como a primeira forma no primeiro slide. A imagem não deve ser marcada como decorativa. O exemplo lê e imprime o título e a descrição atuais do texto alternativo, atualiza ambos os valores e salva a apresentação como `output.pptx`. Adapte a redação à imagem real e às informações que ela transmite.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Adicionar apenas texto alternativo não garante a acessibilidade da apresentação nem a conformidade com os padrões de acessibilidade. Revise as descrições quanto à precisão e relevância, e também verifique a ordem de leitura, o contraste de cores, a legibilidade do texto e outros requisitos de acessibilidade. Visuais informativos não devem ser marcados como decorativos; a próxima seção mostra como verificar [isDecorative](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#isDecorative--).

## **Marcar como Decorativo**

O marcador marcar como decorativo identifica visualizações puramente ornamentais para que leitores de tela as ignorem, reduzindo ruído e mantendo o foco no conteúdo significativo. Aplique‑o a fundos, ornamentos e espaçadores — nunca a gráficos, ícones ou imagens que transmitam informações. Aspose.Slides expõe esse marcador para detecção e validação, permitindo verificações automatizadas de acessibilidade e limpeza.

![Mark as Decorative](mark_as_decorative.png)

O exemplo de código a seguir mostra como determinar se uma forma está marcada como decorativa.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **Perguntas Frequentes**

**O que devo colocar no título e na descrição do texto alternativo?**

Use um título curto para identificar o assunto e uma descrição para explicar as informações que o visual transmite no contexto do slide. Para um gráfico, descreva a tendência ou comparação relevante em vez de simplesmente dizer “gráfico”.

**Devo usar texto alternativo para localizar formas em um modelo?**

Prefira encontrar a forma pelo nome retornado por [getName](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getName--) e verificar se é a forma esperada. O texto alternativo pode ser editado ou traduzido, o que pode quebrar o código que busca uma descrição exata; veja [Identify and Find Shapes](/slides/pt/androidjava/shape-manipulations/).

**Quando uma forma deve ser marcada como decorativa?**

Use o marcador decorativo para visualizações que não adicionam informação, como ornamentos ornamentais. Imagens e gráficos que comunicam significado precisam de uma descrição apropriada.

**Adicionar texto alternativo torna uma apresentação totalmente acessível?**

Não. Texto alternativo aborda apenas parte da acessibilidade. Também revise a ordem de leitura, o contraste de cores, a legibilidade do texto e outros requisitos aplicáveis; definir apenas essas propriedades não estabelece conformidade.