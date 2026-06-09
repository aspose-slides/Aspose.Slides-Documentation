---
title: Comparar Slides de Apresentação em .NET
linktitle: Comparar Slides
type: docs
weight: 50
url: /pt/net/compare-slides/
keywords:
- comparar slides
- comparação de slides
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Compare apresentações PowerPoint e OpenDocument programaticamente com Aspose.Slides para .NET. Identifique diferenças de slides no código rapidamente."
---
## **Visão geral**

Aspose.Slides permite comparar slides, slides de layout e slides mestres usando o método `Equals` fornecido pela interface `IBaseSlide` e pela classe `BaseSlide`. Esse método retorna `true` quando os slides comparados são idênticos em sua estrutura e conteúdo estático.

## **Comparar dois slides**

O método Equals foi adicionado à interface [IBaseSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide) e à classe [BaseSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/baseslide). Ele retorna true para os slides/layout e slides/mestre que são idênticos em sua estrutura e conteúdo estático.

Dois slides são iguais se todas as formas, estilos, textos, animações e outras configurações forem iguais, etc. A comparação não leva em conta valores de identificadores únicos, por exemplo SlideId, e conteúdo dinâmico, por exemplo o valor da data atual em um placeholder de data.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **FAQ**

**O fato de um slide estar oculto afeta a comparação dos próprios slides?**

[Hidden status](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/hidden/) é uma propriedade ao nível da apresentação/reprodução, não de conteúdo visual. A igualdade de dois slides específicos é determinada pela sua estrutura e conteúdo estático; o simples fato de um slide estar oculto não torna os slides diferentes.

**Os hiperlinks e seus parâmetros são levados em conta?**

Sim. Links são parte do conteúdo estático de um slide. Se a URL ou a ação do hiperlink diferir, isso geralmente é tratado como uma diferença no conteúdo estático.

**Se um gráfico referir a um arquivo Excel externo, o conteúdo desse arquivo será levado em conta?**

Não. A comparação é realizada com base nos próprios slides. Fontes de dados externas geralmente não são lidas no momento da comparação; somente o que está presente na estrutura e estado estático do slide é considerado.