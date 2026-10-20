---
title: Restringir Edições de Apresentação com Bloqueios de Forma em Python
linktitle: Restringir Edições de Apresentação
type: docs
weight: 60
url: /pt/python-java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Saiba como bloquear e desbloquear formas em apresentações PPTX com Aspose.Slides for Python via Java para restringir seleção, movimentação, redimensionamento e agrupamento."
---
## **Contexto**

Um uso comum do Aspose.Slides for Python via Java é criar, atualizar e salvar apresentações PowerPoint (PPTX) como parte de um fluxo de trabalho automatizado. Quando os usuários recebem essas apresentações, restringir alterações nas formas pode ajudar a preservar o layout e o conteúdo pretendidos.

Este artigo explica como as formas são organizadas nos slides e como aplicar e remover bloqueios de forma em uma apresentação PPTX. Esses bloqueios permitem restringir operações de edição específicas em formas individuais.

## **Composição de um Slide**

Um slide de apresentação é composto por componentes como autoshapes, tabelas, objetos OLE, formas agrupadas, quadros de imagem, quadros de vídeo, conectores e outros elementos usados para construir uma apresentação. No Aspose.Slides for Python via Java, cada elemento em um slide é representado por um objeto que herda da classe [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/).

Tipos diferentes de forma expõem opções de bloqueio diferentes. A classe [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) é a classe base para bloqueios de forma. Aspose.Slides for Python via Java fornece as seguintes classes de bloqueio:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) bloqueia autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) bloqueia formas de conector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) bloqueia objetos gráficos.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) bloqueia formas de grupo.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) bloqueia quadros de imagem.  

Para aplicar bloqueios em uma [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), percorra seus slides e defina os bloqueios apropriados em cada forma suportada.

## **Aplicar e Remover Proteção**

Bloqueios de forma restringem operações como selecionar, mover e redimensionar formas. Eles não tornam toda a apresentação não editável.

### **Aplicar Proteção a Formas PPTX**

Aspose.Slides for Python via Java fornece a classe [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) para trabalhar com formas em um slide.

O exemplo chama [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) e [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) com `True` para autoshapes, com bloqueios equivalentes para formas de grupo, conectores e quadros de imagem. Conectores usam [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) para movimento; grupos também usam [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) para restringir agrupamento.

O exemplo carrega uma apresentação PPTX existente, verifica as formas na coleção de formas de cada slide e salva uma cópia com essas restrições aplicadas. Formas fora dos quatro tipos tratados permanecem inalteradas. O loop não percorre as formas filhas dentro de um grupo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Remover Proteção**

Para remover um bloqueio de forma, defina seu valor como `False`. O exemplo a seguir carrega uma apresentação com bloqueios de forma e limpa as restrições de seleção, movimentação e redimensionamento através de [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) e [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Ele também remove a restrição de agrupamento passando `False` para [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) e salva uma cópia da apresentação. Outras configurações de bloqueio permanecem inalteradas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Conclusão**

Aspose.Slides for Python via Java permite restringir operações de edição específicas em formas individuais ou aplicar as mesmas restrições em vários slides. Escolha os bloqueios suportados por cada tipo de forma e defina seus valores como `False` quando precisar remover essas restrições.

## **FAQ**

**Posso combinar bloqueios de formas e proteção por senha na mesma apresentação?**

Sim. Bloqueios de forma restringem operações de edição específicas, enquanto [proteção por senha](/slides/pt/python-java/password-protected-presentation/) pode restringir a abertura ou a modificação da apresentação. Você pode usar ambos no mesmo arquivo.

**Posso restringir a edição em slides específicos sem afetar os demais?**

Sim. Aplique bloqueios apenas às formas nos slides selecionados. Isso não altera as configurações de bloqueio nos outros slides.

**Como posso aplicar bloqueios a formas individuais dentro de um grupo?**

Percorra a coleção retornada pelo método [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) do grupo e aplique os bloqueios apropriados a cada forma filha. Repita isso para grupos aninhados. Os exemplos acima processam apenas a coleção de formas do slide, portanto não definem bloqueios em membros individuais de grupos.