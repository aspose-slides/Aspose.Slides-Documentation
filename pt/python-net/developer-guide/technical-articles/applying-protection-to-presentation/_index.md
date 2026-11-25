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
description: "Aprenda como bloquear e desbloquear formas em apresentações PPTX com Aspose.Slides para Python via .NET para restringir seleção, movimentação, redimensionamento e agrupamento."
---
## **Contexto**

Um uso comum do Aspose.Slides para Python via .NET é criar, atualizar e salvar apresentações PowerPoint (PPTX) como parte de um fluxo de trabalho automatizado. Quando os usuários recebem essas apresentações, restringir alterações nas formas pode ajudar a preservar o layout e o conteúdo pretendidos.

Este artigo explica como as formas são organizadas nos slides e como aplicar e remover bloqueios de forma em uma apresentação PPTX. Esses bloqueios permitem restringir operações específicas de edição em formas individuais.

## **Composição de um Slide**

Um slide de apresentação é composto por componentes como formas automáticas, tabelas, objetos OLE, formas agrupadas, quadros de imagem, quadros de vídeo, conectores e outros elementos usados para montar uma apresentação. No Aspose.Slides para Python via .NET, cada elemento em um slide é representado por um objeto que herda da classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Tipos diferentes de forma expõem opções diferentes de bloqueio. A classe [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) é a classe base para bloqueios de forma. O Aspose.Slides para Python via .NET fornece as seguintes classes de bloqueio:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) bloqueia formas automáticas.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) bloqueia formas de conector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) bloqueia objetos gráficos.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) bloqueia formas agrupadas.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) bloqueia quadros de imagem.  

Para aplicar bloqueios em uma [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), itere pelos seus slides e defina os bloqueios apropriados em cada forma suportada.

## **Aplicar e Remover Proteção**

Editores de apresentação compatíveis usam bloqueios de forma para restringir operações individuais de edição. Criptografia de arquivo e proteção contra gravação ao nível do documento são configurações separadas de [configurações de proteção de apresentação](/slides/pt/python-net/password-protected-presentation/).

### **Aplicar Proteção às Formas PPTX**

O Aspose.Slides para Python via .NET fornece a classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) para trabalhar com formas em um slide.

O exemplo define [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) e [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) como `True` para formas automáticas, com bloqueios equivalentes para formas agrupadas, conectores e quadros de imagem. Conectores usam [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) para movimentação; grupos também usam [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) para restringir o agrupamento.

O exemplo carrega uma apresentação PPTX existente, verifica as formas na coleção de formas de cada slide e salva uma cópia com essas restrições aplicadas. Formas fora dos quatro tipos tratados permanecem inalteradas. O laço não percorre as formas filhas dentro de um grupo.

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

Para remover um bloqueio de forma, defina seu valor como `False`. O exemplo a seguir carrega uma apresentação com bloqueios de forma e limpa as restrições de seleção, movimentação e redimensionamento através de [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) e [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Ele também limpa [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) e salva uma cópia da apresentação. Outras configurações de bloqueio permanecem inalteradas.

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

### **Preservar um Recorte de Imagem**

Coloque uma foto chamada `photo.jpg` no diretório de trabalho. O exemplo recorta 12 % da esquerda e 8 % da direita, então define [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) no quadro de imagem. Essa flag restringe novos recortes e preserva o recorte existente.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` armazena o bloqueio de recorte como `True`. No PowerPoint, o comando **Crop** fica desativado quando a foto está selecionada.

### **Manter um Diagrama Agrupado**

O exemplo agrupa um retângulo e uma seta, então define [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) no próprio grupo para manter os componentes do diagrama juntos. Outras edições, como mover o grupo ou alterar o preenchimento de um componente, permanecem disponíveis.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` armazena o bloqueio de desagrupamento como `True`. No PowerPoint, o comando **Ungroup** fica desativado quando todo o diagrama está selecionado.

### **Relatar Bloqueios de Forma Existentes**

Para analisar um modelo, abra-o e leia o objeto de bloqueio de cada forma. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) é `True` quando todas as flags naquele objeto estão desativadas e `False` quando ao menos uma está ativada. Um grupo e seus filhos possuem objetos de bloqueio separados, portanto inspecione os filhos mesmo quando o grupo não possui bloqueios.

Este exemplo verifica movimentação para formas automáticas, quadros de imagem e grupos, recorte para imagens e desagrupamento para grupos. Ele relata as flags reconhecidas e marca tipos de forma que não são inspecionados.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

Suponha que o slide 1 de `Sample.pptx` contenha um grupo chamado `Layout` com desagrupamento bloqueado, uma imagem chamada `Photo` dentro dele com recorte bloqueado e um retângulo desbloqueado chamado `Free`. O relatório ignora `Free` e imprime estas duas linhas:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

O relatório lê as flags de edição armazenadas ao nível da forma sem alterá‑las ou salvar a apresentação. A proteção contra gravação ao nível do documento é uma configuração separada, e a aplicação de cada flag depende do editor.

### **Conclusão**

O Aspose.Slides para Python via .NET permite restringir operações específicas de edição em formas individuais ou aplicar as mesmas restrições em vários slides. Escolha os bloqueios suportados por cada tipo de forma e defina seus valores como `False` quando precisar remover essas restrições.

## **FAQ**

**Posso combinar bloqueios de forma e proteção por senha na mesma apresentação?**

Sim. Bloqueios de forma restringem operações específicas de edição, enquanto a [proteção por senha](/slides/pt/python-net/password-protected-presentation/) pode restringir a abertura ou modificação da apresentação. Você pode usar ambos no mesmo arquivo.

**Posso restringir a edição em slides específicos sem afetar os demais?**

Sim. Aplique bloqueios apenas nas formas dos slides selecionados. Isso não altera as configurações de bloqueio nos outros slides.

**Como aplicar bloqueios a formas individuais dentro de um grupo?**

Itere pela coleção de [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) do grupo e aplique os bloqueios apropriados a cada forma filha. Repita isso para quaisquer grupos aninhados, seguindo o percurso mostrado no exemplo de relatório.