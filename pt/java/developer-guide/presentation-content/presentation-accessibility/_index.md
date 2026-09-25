---
title: Gerenciar Acessibilidade de Apresentações em Java
linktitle: Acessibilidade de Apresentação
type: docs
weight: 30
url: /pt/java/presentation-accessibility/
keywords:
- acessibilidade de apresentação
- texto alternativo
- título de texto alternativo
- descrição de texto alternativo
- marcar como decorativo
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Descubra como o Aspose.Slides for Java ajuda a automatizar verificações de acessibilidade de apresentações em arquivos PPT, PPTX e ODP — melhore a experiência do leitor de tela e aumente a conformidade."
---
## **Introdução**

Texto alternativo ajuda pessoas que utilizam tecnologias assistivas a entender o significado de imagens, gráficos e outras formas informativas. Este artigo explica como ler e atualizar títulos e descrições de texto alternativo com Aspose.Slides for Java, distinguir descrições de acessibilidade dos nomes de formas usados no código e verificar se uma forma está marcada como decorativa.

Esses recursos suportam a acessibilidade de apresentações, mas não a garantem. A ordem de leitura, o contraste de cores, a legibilidade do texto e outros requisitos de acessibilidade também precisam ser revisados.

## **Gerenciar Títulos e Descrições de Texto Alternativo**

Use texto alternativo para explicar o significado de imagens, gráficos e outras formas informativas para pessoas que não podem vê-los. Os métodos e conteúdos a seguir atendem a diferentes propósitos:

| Método ou conteúdo | Propósito |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Um título curto para a descrição alternativa. |
| [getAlternativeText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#getAlternativeText--) | Uma descrição significativa do conteúdo ou propósito da forma no contexto do slide. |
| [getName](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#getName--) | O nome da forma, que o código pode usar para encontrar uma forma específica na apresentação. |
| Texto visível | Conteúdo exibido no slide, como o texto de uma forma ou o título e rótulos de um gráfico. Atualizar o texto alternativo não altera esse conteúdo. |

Quando uma apresentação é reutilizada como modelo, o código pode encontrar uma forma pelo nome retornado por [getName](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#getName--) antes de atualizá‑la. Esse nome tem um propósito diferente do texto alternativo, que explica o que o visual comunica ao leitor. Buscar pelo nome permite que os autores melhorem ou traduzam descrições sem mudar como o código localiza a forma. Os nomes podem ser editados e não são garantidos como únicos, portanto verifique se o nome corresponde à forma pretendida; veja [Identificar e Encontrar Formas](/slides/pt/java/shape-manipulations/#identify-and-find-shapes).

O exemplo a seguir requer `input.pptx` com uma imagem da entrada de um escritório como a primeira forma no primeiro slide. A imagem não deve estar marcada como decorativa. O exemplo lê e imprime o título e a descrição atuais do texto alternativo, atualiza ambos os valores e salva a apresentação como `output.pptx`. Adapte a redação à imagem real e às informações que ela transmite.

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

Adicionar texto alternativo isoladamente não garante a acessibilidade da apresentação nem a conformidade com normas de acessibilidade. Revise as descrições quanto à precisão e relevância e também verifique a ordem de leitura, o contraste de cores, a legibilidade do texto e outros requisitos de acessibilidade. Visuais informativos não devem ser marcados como decorativos; a próxima seção mostra como verificar [isDecorative](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#isDecorative--).

## **Marcar como Decorativo**

Marcar como decorativo sinaliza visuais puramente ornamentais para que leitores de tela os ignorem, reduzindo ruído e mantendo o foco no conteúdo significativo. Aplique isso a fundos, enfeites e espaçadores—nunca a gráficos, ícones ou imagens que transmitam informações. Aspose.Slides expõe essa sinalização para detecção e validação, permitindo verificações automatizadas de acessibilidade e limpeza.

![Marcar como Decorativo](mark_as_decorative.png)

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

Use um título curto para identificar o assunto e uma descrição para explicar as informações que o visual transmite no contexto do slide. Para um gráfico, descreva a tendência ou comparação relevante, em vez de apenas dizer “gráfico”.

**Devo usar texto alternativo para localizar formas em um modelo?**

Prefira localizar a forma pelo nome retornado por [getName](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#getName--) e verificar se é a forma esperada. O texto alternativo pode ser editado ou traduzido, o que pode quebrar código que procura uma descrição exata; veja [Identificar e Encontrar Formas](/slides/pt/java/shape-manipulations/).

**Quando uma forma deve ser marcada como decorativa?**

Use a sinalização decorativa para visuais que não adicionam informação, como enfeites ornamentais. Imagens e gráficos que comunicam significado precisam de uma descrição apropriada em vez disso.

**Adicionar texto alternativo torna uma apresentação totalmente acessível?**

Não. Texto alternativo aborda apenas parte da acessibilidade. Também revise a ordem de leitura, o contraste de cores, a legibilidade do texto e outros requisitos aplicáveis; definir essas propriedades sozinho não estabelece conformidade.