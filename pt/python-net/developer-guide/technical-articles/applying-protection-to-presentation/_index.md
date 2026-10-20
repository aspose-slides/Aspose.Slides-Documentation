---
title: Restringir Edições de Apresentação com Bloqueios de Forma em Python
linktitle: Restringir Edições de Apresentação
type: docs
weight: 70
url: /pt/python-net/applying-protection-to-presentation/
keywords:
- impedir edições
- proteger contra edição
- bloquear forma
- bloquear posição
- bloquear seleção
- bloquear redimensionamento
- bloquear agrupamento
- PowerPoint
- PPTX
- apresentação
- Python
- Aspose.Slides
description: "Aprenda como bloquear e desbloquear formas em apresentações PPTX com Aspose.Slides for Python via .NET para restringir seleção, movimentação, redimensionamento e agrupamento."
---
## **Contexto**

Um uso comum do Aspose.Slides for Python via .NET é criar, atualizar e salvar apresentações PowerPoint (PPTX) como parte de um fluxo de trabalho automatizado. Quando os usuários recebem essas apresentações, restringir alterações nas formas pode ajudar a preservar o layout e o conteúdo pretendidos.

Este artigo explica como as formas são organizadas nos slides e como aplicar e remover bloqueios de forma em uma apresentação PPTX. Esses bloqueios permitem restringir operações de edição específicas em formas individuais.

## **Composição de um Slide**

Um slide de apresentação é composto por componentes como autoshapes, tabelas, objetos OLE, formas agrupadas, quadros de imagem, quadros de vídeo, conectores e outros elementos usados para criar uma apresentação. No Aspose.Slides for Python via .NET, cada elemento em um slide é representado por um objeto que herda da classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

Tipos diferentes de forma expõem opções de bloqueio diferentes. A classe [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) é a classe base para bloqueios de forma. O Aspose.Slides for Python via .NET fornece as seguintes classes de bloqueio:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) bloqueia autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) bloqueia formas de conector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) bloqueia objetos gráficos.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) bloqueia formas agrupadas.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) bloqueia quadros de imagem.  

Para aplicar bloqueios em toda a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), itere pelos seus slides e defina os bloqueios apropriados em cada forma suportada.

## **Aplicar e Remover Proteção**

Os bloqueios de forma restringem operações como selecionar, mover e redimensionar formas. Eles não tornam toda a apresentação não editável.

### **Aplicar Proteção a Formas PPTX**

O Aspose.Slides for Python via .NET fornece a classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) para trabalhar com formas em um slide.

O exemplo define [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), e [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) como `True` para autoshapes, com bloqueios equivalentes para formas de grupo, conectores e quadros de imagem. Conectores usam [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) para movimento; grupos também usam [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) para restringir o agrupamento.

O exemplo carrega uma apresentação PPTX existente, verifica as formas na coleção de formas de cada slide e salva uma cópia com essas restrições aplicadas. Formas fora dos quatro tipos tratados permanecem inalteradas. O loop não percorre as formas filhas dentro de um grupo.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Remover Proteção**

Para remover um bloqueio de forma, defina seu valor como `False`. O exemplo a seguir carrega uma apresentação com bloqueios de forma e limpa as restrições de seleção, movimento e redimensionamento através de [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), e [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Ele também limpa [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) e salva uma cópia da apresentação. Outras configurações de bloqueio permanecem inalteradas.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Conclusão**

O Aspose.Slides for Python via .NET permite restringir operações de edição específicas em formas individuais ou aplicar as mesmas restrições em vários slides. Escolha os bloqueios suportados por cada tipo de forma e defina seus valores como `False` quando precisar remover essas restrições.

## **Perguntas Frequentes**

**Posso combinar bloqueios de forma e proteção por senha na mesma apresentação?**

Sim. Os bloqueios de forma restringem operações de edição específicas, enquanto [proteção por senha](/slides/pt/python-net/password-protected-presentation/) pode restringir a abertura ou modificação da apresentação. Você pode usar ambos no mesmo arquivo.

**Posso restringir a edição em slides específicos sem afetar os demais?**

Sim. Aplique bloqueios apenas às formas nos slides selecionados. Isso não altera as configurações de bloqueio nos outros slides.

**Como posso aplicar bloqueios a formas individuais dentro de um grupo?**

Itere pela coleção de [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) do grupo e aplique os bloqueios apropriados a cada forma filha. Repita isso para quaisquer grupos aninhados. Os exemplos acima processam apenas a coleção de formas do slide, portanto não definem bloqueios em membros individuais do grupo.