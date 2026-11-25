---
title: Restringir edições de apresentações com bloqueios de forma em Python
linktitle: Restringir edições de apresentação
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
description: "Aprenda a bloquear e desbloquear formas em apresentações PPTX com Aspose.Slides for Python via Java para restringir seleção, movimentação, redimensionamento e agrupamento."
---
## **Visão geral**

Um uso comum do Aspose.Slides for Python via Java é criar, atualizar e salvar apresentações PowerPoint (PPTX) como parte de um fluxo de trabalho automatizado. Quando os usuários recebem essas apresentações, restringir alterações nas formas pode ajudar a preservar o layout e o conteúdo pretendidos.

Este artigo explica como as formas são organizadas nos slides e como aplicar e remover bloqueios de forma em uma apresentação PPTX. Esses bloqueios permitem que você restrinja operações de edição específicas em formas individuais.

## **Composição de um slide**

Um slide de apresentação é composto por componentes como autoshapes, tabelas, objetos OLE, formas agrupadas, quadros de imagem, quadros de vídeo, conectores e outros elementos usados para montar uma apresentação. No Aspose.Slides for Python via Java, cada elemento em um slide é representado por um objeto que herda da classe [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/).

Tipos diferentes de forma expõem opções de bloqueio diferentes. A classe [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) é a classe base para bloqueios de forma. O Aspose.Slides for Python via Java fornece as seguintes classes de bloqueio:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) bloqueia autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) bloqueia formas de conector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) bloqueia objetos gráficos.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) bloqueia formas agrupadas.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) bloqueia quadros de imagem.  

Para aplicar bloqueios em uma [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), percorra seus slides e defina os bloqueios apropriados em cada forma suportada.

## **Aplicar e remover proteção**

Editores de apresentação compatíveis usam bloqueios de forma para restringir operações de edição individuais. Criptografia de arquivo e proteção de gravação em nível de documento são configurações de [proteção de apresentação](/slides/pt/python-java/password-protected-presentation/) distintas.

### **Aplicar proteção a formas PPTX**

O Aspose.Slides for Python via Java fornece a classe [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) para trabalhar com formas em um slide.

O exemplo chama [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) e [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) com `True` para autoshapes, com bloqueios equivalentes para formas agrupadas, conectores e quadros de imagem. Conectores utilizam [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) para movimentação; grupos também utilizam [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) para restringir o agrupamento.

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

### **Remover proteção**

Para remover um bloqueio de forma, defina seu valor como `False`. O exemplo a seguir carrega uma apresentação com bloqueios de forma e limpa as restrições de seleção, movimentação e redimensionamento por meio de [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) e [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Ele também remove a restrição de agrupamento passando `False` para [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) e salva uma cópia da apresentação. Outras configurações de bloqueio permanecem inalteradas.

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

### **Preservar o recorte de uma imagem**

Coloque uma foto chamada `photo.jpg` no diretório de trabalho. O exemplo recorta 12 % da esquerda e 8 % da direita, depois chama [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) com `True` para preservar o recorte.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Em `PictureLocked.pptx`, o PowerPoint desabilita o comando **Crop** ao selecionar a foto.

### **Manter um diagrama agrupado**

O exemplo agrupa um retângulo e uma seta, depois chama [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) com `True` para manter as duas formas juntas. Ainda é possível mover o grupo ou alterar o preenchimento de um componente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Em `DiagramLocked.pptx`, o PowerPoint desabilita o comando **Ungroup** ao selecionar todo o diagrama.

### **Relatar bloqueios de forma existentes**

Para revisar um modelo, abra‑o e leia o objeto de bloqueio de cada forma. O método [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) retorna `True` quando todas as flags desse objeto estão desativadas e `False` quando ao menos uma está ativada. Um grupo e seus filhos têm objetos de bloqueio separados, portanto inspecione os filhos mesmo quando o grupo não possui bloqueios.

Este exemplo verifica movimentação para autoshapes, quadros de imagem e grupos. Também verifica recorte para imagens e desagrupamento para grupos. O relatório lista as flags ativadas reconhecidas e marca tipos de forma que não são inspecionados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

Suponha que o slide 1 de `Sample.pptx` contenha um grupo chamado `Layout` com desagrupamento bloqueado, uma imagem chamada `Photo` dentro dele com recorte bloqueado e um retângulo desbloqueado chamado `Free`. O relatório ignora `Free` e imprime estas duas linhas:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

O relatório lê as flags de edição armazenadas em nível de forma sem alterá‑las ou salvar a apresentação. A proteção de gravação em nível de documento é uma configuração separada, e a aplicação de cada flag depende do editor.

### **Conclusão**

O Aspose.Slides for Python via Java permite que você restrinja operações de edição específicas em formas individuais ou aplique as mesmas restrições em vários slides. Escolha os bloqueios suportados por cada tipo de forma e defina seus valores como `False` quando precisar remover essas restrições.

## **FAQ**

**Posso combinar bloqueios de forma e proteção por senha na mesma apresentação?**

Sim. Bloqueios de forma restringem operações específicas de edição, enquanto a [proteção por senha](/slides/pt/python-java/password-protected-presentation/) pode restringir a abertura ou modificação da apresentação. Você pode usar ambos no mesmo arquivo.

**Posso restringir a edição em slides específicos sem afetar os demais?**

Sim. Aplique bloqueios somente às formas nos slides selecionados. Isso não altera as configurações de bloqueio nos outros slides.

**Como posso aplicar bloqueios a formas individuais dentro de um grupo?**

Percorra a coleção retornada pelo método [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) do grupo e aplique os bloqueios apropriados a cada forma filha. Repita isso para quaisquer grupos aninhados, seguindo a mesma lógica apresentada no exemplo de relatório.