---
title: Restringir Edições de Apresentação com Bloqueios de Forma no .NET
linktitle: Restringir Edições de Apresentação
type: docs
weight: 70
url: /pt/net/applying-protection-to-presentation/
keywords:
- evitar edições
- proteger contra edição
- bloquear forma
- bloquear posição
- bloquear seleção
- bloquear redimensionamento
- bloquear agrupamento
- PowerPoint
- PPTX
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como bloquear e desbloquear formas em apresentações PPTX com Aspose.Slides para .NET para restringir seleção, movimentação, redimensionamento e agrupamento."
---
## **Contexto**

Um uso comum do Aspose.Slides for .NET é criar, atualizar e salvar apresentações PowerPoint (PPTX) como parte de um fluxo de trabalho automatizado. Quando os usuários recebem essas apresentações, restringir alterações nas formas pode ajudar a preservar o layout e o conteúdo pretendidos.

Este artigo explica como as formas são organizadas nos slides e como aplicar e remover bloqueios de forma em uma apresentação PPTX. Esses bloqueios permitem que você restrinja operações de edição específicas em formas individuais.

## **Composição de um Slide**

Um slide de apresentação é composto por componentes como autoshapes, tabelas, objetos OLE, formas agrupadas, molduras de imagem, molduras de vídeo, conectores e outros elementos usados para montar uma apresentação. No Aspose.Slides for .NET, cada elemento em um slide é representado por um objeto que implementa a interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) ou herda de uma classe que o faz.

Tipos diferentes de forma expõem opções de bloqueio diferentes. A interface [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) é a interface base para bloqueios de forma. O Aspose.Slides for .NET fornece as seguintes interfaces de bloqueio:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) bloqueia formas automáticas.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) bloqueia formas de conector.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) bloqueia objetos gráficos.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) bloqueia formas de grupo.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) bloqueia molduras de imagem.  

Para aplicar bloqueios em toda uma [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), itere pelos seus slides e defina os bloqueios apropriados em cada forma suportada.

## **Aplicar e Remover Proteção**

Editores de apresentação compatíveis usam bloqueios de forma para restringir operações de edição individuais. Criptografia de arquivos e proteção de escrita em nível de documento são configurações separadas de [presentation protection settings](/slides/pt/net/password-protected-presentation/).

### **Aplicar Proteção a Formas PPTX**

O Aspose.Slides for .NET fornece a interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) para trabalhar com formas em um slide.

O exemplo define [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) e [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) como `true` para autoshapes, com bloqueios equivalentes para formas de grupo, conectores e molduras de imagem. Conectores usam [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) para movimentação; grupos também usam [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) para restringir a agrupação.

O exemplo carrega uma apresentação PPTX existente, verifica as formas na coleção de formas de cada slide e salva uma cópia com essas restrições aplicadas. Formas fora dos quatro tipos tratados permanecem inalteradas. O loop não percorre as formas filhas dentro de um grupo.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Remover Proteção**

Para remover um bloqueio de forma, defina seu valor como `false`. O exemplo a seguir carrega uma apresentação com bloqueios de forma e limpa as restrições de seleção, movimentação e redimensionamento por meio de [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) e [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Ele também limpa [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) e salva uma cópia da apresentação. Outras configurações de bloqueio permanecem inalteradas.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Preservar um Recorte de Imagem**

Coloque uma foto chamada `photo.jpg` no diretório de trabalho. O exemplo recorta 12 % da esquerda e 8 % da direita, depois define [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) na moldura de imagem. Essa flag restringe novos recortes e preserva o recorte existente.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` armazena o bloqueio de recorte como `true`. No PowerPoint, o comando **Crop** fica desativado quando a foto está selecionada.

### **Manter um Diagrama Agrupado**

O exemplo agrupa um retângulo e uma seta, então define [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) no próprio grupo para manter os componentes do diagrama juntos. Outras edições, como mover o grupo ou alterar o preenchimento de um componente, permanecem disponíveis.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` armazena o bloqueio de desagrupamento como `true`. No PowerPoint, o comando **Ungroup** fica desativado quando todo o diagrama está selecionado.

### **Relatar Bloqueios de Formas Existentes**

Para revisar um modelo, abra-o e leia o objeto de bloqueio de cada forma. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) é `true` quando todas as flags naquele objeto estão desativadas e `false` quando ao menos uma está ativada. Um grupo e seus filhos possuem objetos de bloqueio separados, portanto inspecione os filhos mesmo quando o grupo não tem bloqueios.

Este exemplo verifica movimentação para autoshapes, molduras de imagem e grupos, recorte para imagens e desagrupamento para grupos. Ele relata as flags que reconhece e marca tipos de forma que não inspeciona.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

Suponha que o slide 1 de `Sample.pptx` contenha um grupo chamado `Layout` com desagrupamento bloqueado, uma foto chamada `Photo` dentro dele com recorte bloqueado e um retângulo desbloqueado chamado `Free`. O relatório ignora `Free` e imprime estas duas linhas:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

O relatório lê as flags de edição armazenadas no nível da forma sem alterá‑las ou salvar a apresentação. A proteção de escrita em nível de documento é uma configuração separada, e a aplicação de cada flag depende do editor.

### **Conclusão**

O Aspose.Slides for .NET permite que você restrinja operações de edição específicas em formas individuais ou aplique as mesmas restrições em vários slides. Escolha os bloqueios suportados por cada tipo de forma e defina seus valores como `false` quando precisar remover essas restrições.

## **FAQ**

**Posso combinar bloqueios de forma e proteção por senha na mesma apresentação?**

Sim. Bloqueios de forma restringem operações de edição específicas, enquanto [password protection](/slides/pt/net/password-protected-presentation/) pode restringir a abertura ou modificação da apresentação. Você pode usar ambos no mesmo arquivo.

**Posso restringir a edição em slides específicos sem afetar os demais?**

Sim. Aplique bloqueios apenas nas formas dos slides selecionados. Isso não altera as configurações de bloqueio nos outros slides.

**Como posso aplicar bloqueios a formas individuais dentro de um grupo?**

Itere pela coleção [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) do grupo e aplique os bloqueios apropriados a cada forma filha. Repita isso para quaisquer grupos aninhados, seguindo a travessia no exemplo de relatório.