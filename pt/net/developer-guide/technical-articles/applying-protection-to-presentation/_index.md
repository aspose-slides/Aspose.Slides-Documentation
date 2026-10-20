---
title: Restringir edições de apresentação com bloqueios de forma no .NET
linktitle: Restringir edições de apresentação
type: docs
weight: 70
url: /pt/net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Aprenda como bloquear e desbloquear formas em apresentações PPTX com Aspose.Slides para .NET para restringir seleção, movimentação, redimensionamento e agrupamento."
---
## **Contexto**

Um uso comum do Aspose.Slides for .NET é criar, atualizar e salvar apresentações PowerPoint (PPTX) como parte de um fluxo de trabalho automatizado. Quando os usuários recebem essas apresentações, restringir alterações nas formas pode ajudar a preservar o layout e o conteúdo pretendidos.

Este artigo explica como as formas são organizadas nos slides e como aplicar e remover bloqueios de forma em uma apresentação PPTX. Esses bloqueios permitem restringir operações de edição específicas em formas individuais.

## **Composição de um Slide**

Um slide de apresentação é composto por componentes como autoshapes, tabelas, objetos OLE, formas agrupadas, quadros de imagem, quadros de vídeo, conectores e outros elementos usados para construir uma apresentação. No Aspose.Slides for .NET, cada elemento em um slide é representado por um objeto que implementa a interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) ou herda de uma classe que a implementa.

Tipos diferentes de formas expõem diferentes opções de bloqueio. A interface [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) é a interface base para bloqueios de formas. O Aspose.Slides for .NET fornece as seguintes interfaces de bloqueio:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) bloqueia autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) bloqueia formas de conector.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) bloqueia objetos gráficos.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) bloqueia formas agrupadas.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) bloqueia quadros de imagem.  

Para aplicar bloqueios em toda uma [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), itere pelos seus slides e defina os bloqueios apropriados em cada forma suportada.

## **Aplicar e Remover Proteção**

Bloqueios de forma restringem operações como selecionar, mover e redimensionar formas. Eles não tornam toda a apresentação não editável.

### **Aplicar Proteção a Formas PPTX**

O Aspose.Slides for .NET fornece a interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) para trabalhar com formas em um slide.

O exemplo define [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/), e [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) como `true` para autoshapes, com bloqueios equivalentes para formas de grupo, conectores e quadros de imagem. Conectores usam [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) para movimento; grupos também usam [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) para restringir o agrupamento.

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

Para remover um bloqueio de forma, defina seu valor como `false`. O exemplo a seguir carrega uma apresentação com bloqueios de forma e limpa as restrições de seleção, movimento e redimensionamento através de [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), e [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Também limpa [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) e salva uma cópia da apresentação. Outras configurações de bloqueio permanecem inalteradas.

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

### **Conclusão**

O Aspose.Slides for .NET permite restringir operações de edição específicas em formas individuais ou aplicar as mesmas restrições em vários slides. Escolha os bloqueios suportados por cada tipo de forma e defina seus valores como `false` quando precisar remover essas restrições.

## **Perguntas Frequentes**

**Posso combinar bloqueios de forma e proteção por senha na mesma apresentação?**

Sim. Bloqueios de forma restringem operações de edição específicas, enquanto [password protection](/slides/pt/net/password-protected-presentation/) pode restringir a abertura ou modificação da apresentação. Você pode usar ambos no mesmo arquivo.

**Posso restringir a edição em slides específicos sem afetar os demais?**

Sim. Aplique bloqueios apenas nas formas dos slides selecionados. Isso não altera as configurações de bloqueio nos demais slides.

**Como posso aplicar bloqueios a formas individuais dentro de um grupo?**

Itere pela coleção [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) do grupo e aplique os bloqueios apropriados a cada forma filha. Repita isso para quaisquer grupos aninhados. Os exemplos acima processam apenas a coleção de formas do slide, portanto não definem bloqueios nos membros individuais do grupo.