---
title: Comparar slides de apresentação em Python
linktitle: Comparar slides
type: docs
weight: 50
url: /pt/python-java/compare-slides/
keywords:
- comparar slides
- comparação de slides
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Compare apresentações PowerPoint e OpenDocument programaticamente com Aspose.Slides para Python via Java. Identifique diferenças de slides no código rapidamente."
---
## **Visão geral**

Aspose.Slides permite comparar slides, slides de layout e slides mestre usando o método [equals](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#equals) fornecido pela classe [BaseSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/) . Este método retorna `True` quando os slides comparados são idênticos em sua estrutura e conteúdo estático.

## **Comparar dois slides**

O método [equals](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#equals) na classe [BaseSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/) retorna `True` para slides, slides de layout e slides mestre que são idênticos em estrutura e conteúdo estático.

Dois slides são iguais se todas as suas formas, estilos, texto, animações e outras configurações forem iguais. A comparação não leva em conta valores de identificadores exclusivos, como IDs de slide, ou conteúdo dinâmico, como a data atual em um marcador de posição de data.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **FAQ**

**O fato de um slide estar oculto afeta a comparação dos próprios slides?**

O status [Hidden](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getHidden) é uma propriedade de nível de apresentação/reprodução, não de conteúdo visual. A igualdade de dois slides específicos é determinada por sua estrutura e conteúdo estático; o simples fato de um slide estar oculto não torna os slides diferentes.

**Links e seus parâmetros são considerados?**

Sim. Links fazem parte do conteúdo estático de um slide. Se a URL ou a ação do hiperlink diferirem, isso geralmente é tratado como uma diferença no conteúdo estático.

**Se um gráfico referir-se a um arquivo Excel externo, o conteúdo desse arquivo será considerado?**

Não. A comparação é feita com base nos próprios slides. Fontes de dados externas geralmente não são lidas no momento da comparação; somente o que está presente na estrutura e no estado estático do slide é considerado.