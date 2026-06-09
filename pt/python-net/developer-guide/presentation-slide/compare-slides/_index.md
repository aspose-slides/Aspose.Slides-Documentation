---
title: Comparar slides de apresentação em Python
linktitle: Comparar slides
type: docs
weight: 50
url: /pt/python-net/compare-slides/
keywords:
- comparar slides
- comparação de slides
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Compare apresentações PowerPoint e OpenDocument programaticamente com Aspose.Slides para Python via .NET. Identifique diferenças de slides no código rapidamente."
---
## **Visão geral**

Aspose.Slides permite comparar slides, slides de layout e slides mestre usando o método `equals` fornecido pela classe `BaseSlide`. Esse método devolve `True` quando os slides comparados são idênticos em sua estrutura e conteúdo estático.

## **Comparar dois slides**
O método `equals` foi adicionado à classe [BaseSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslide/). Ele devolve true para os slides de layout e slides mestre que são idênticos por sua estrutura e conteúdo estático.

Dois slides são iguais se todas as formas, estilos, textos, animações e outras configurações, etc., forem iguais. A comparação não leva em conta valores de identificadores únicos, por exemplo SlideId, e conteúdo dinâmico, como o valor da data atual em um Placeholder de Data.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i].equals(p2.masters[j]):
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```


## **Perguntas frequentes**

**Faz diferença o fato de um slide estar oculto na comparação dos próprios slides?**

O [status oculto](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/hidden/) é uma propriedade ao nível da apresentação/reprodução, não conteúdo visual. A igualdade de dois slides específicos é determinada por sua estrutura e conteúdo estático; o simples fato de um slide estar oculto não torna os slides diferentes.

**Links e seus parâmetros são levados em conta?**

Sim. Links fazem parte do conteúdo estático de um slide. Se a URL ou a ação do hyperlink for diferente, isso geralmente é tratado como uma diferença no conteúdo estático.

**Se um gráfico referir um arquivo Excel externo, o conteúdo desse arquivo será considerado?**

Não. A comparação é feita com base nos próprios slides. Fontes de dados externas geralmente não são lidas no momento da comparação; apenas o que está presente na estrutura e no estado estático do slide é considerado.