---
title: Comparar Slides de Apresentação em Java
linktitle: Comparar Slides
type: docs
weight: 50
url: /pt/java/compare-slides/
keywords:
- comparar slides
- comparação de slides
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Compare apresentações PowerPoint e OpenDocument programaticamente com Aspose.Slides para Java. Identifique diferenças de slides no código rapidamente."
---
## **Visão Geral**

O Aspose.Slides permite comparar slides, slides de layout e slides mestre usando o método `equals` fornecido pela interface `IBaseSlide` e pela classe `BaseSlide`. Esse método retorna `true` quando os slides comparados são idênticos em sua estrutura e conteúdo estático.

## **Comparar Dois Slides**
O método Equals foi adicionado à interface [IBaseSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IBaseSlide) e à classe [BaseSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/BaseSlide). Ele retorna true para os slides de layout e slides mestre que são idênticos em sua estrutura e conteúdo estático.  

Dois slides são iguais se todas as formas, estilos, textos, animações e outras configurações, etc., forem iguais. A comparação não leva em conta valores de identificadores únicos, por exemplo SlideId, e conteúdo dinâmico, por exemplo o valor da data atual em Placeholder de Data.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **Perguntas Frequentes**

**O fato de um slide estar oculto afeta a comparação dos próprios slides?**

[Hidden status](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slide/#getHidden--) é uma propriedade de nível de apresentação/reprodução, não de conteúdo visual. A igualdade de dois slides específicos é determinada por sua estrutura e conteúdo estático; o simples fato de um slide estar oculto não faz com que os slides sejam diferentes.

**Os hiperlinks e seus parâmetros são levados em conta?**

Sim. Os links fazem parte do conteúdo estático de um slide. Se a URL ou a ação do hiperlink diferir, isso geralmente é tratado como uma diferença no conteúdo estático.

**Se um gráfico referir-se a um arquivo Excel externo, o conteúdo desse arquivo será levado em conta?**

Não. A comparação é feita com base nos próprios slides. Fontes de dados externas geralmente não são lidas no momento da comparação; somente o que está presente na estrutura e estado estático do slide é considerado.