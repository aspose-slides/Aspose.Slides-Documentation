---
title: Impedir edições de apresentação com bloqueios de forma em .NET
linktitle: Impedir edições de apresentação
type: docs
weight: 70
url: /pt/net/applying-protection-to-presentation/
keywords:
- impedir edições
- proteger contra edição
- bloquear forma
- bloquear posição
- bloquear seleção
- bloquear tamanho
- bloquear agrupamento
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra como o Aspose.Slides for .NET bloqueia ou desbloqueia formas em arquivos PPT, PPTX e ODP, protegendo apresentações enquanto permite edições controladas."
---
## **Contexto**

Um uso comum do Aspose.Slides é criar, atualizar e salvar apresentações Microsoft PowerPoint (PPTX) como parte de um fluxo de trabalho automatizado. Usuários de aplicações que empregam Aspose.Slides dessa forma têm acesso às apresentações geradas, portanto protegê‑las contra edição é uma preocupação frequente. É importante que apresentações geradas automaticamente mantenham sua formatação e conteúdo originais.

Este artigo explica como apresentações e slides são estruturados e como o Aspose.Slides for .NET pode aplicar proteção a uma apresentação e removê‑la posteriormente. Ele fornece aos desenvolvedores um meio de controlar como as apresentações geradas por suas aplicações são usadas.

## **Composição de um Slide**

Um slide de apresentação é composto por componentes como autoshapes, tabelas, objetos OLE, formas agrupadas, molduras de imagem, molduras de vídeo, conectores e outros elementos usados para construir uma apresentação. No Aspose.Slides for .NET, cada elemento em um slide é representado por um objeto que implementa a interface [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/) ou herda de uma classe que o faz.

A estrutura do PPTX é complexa, de modo que, ao contrário do PPT, onde um bloqueio genérico pode ser usado para todos os tipos de formas, diferentes tipos de forma requerem bloqueios diferentes. A interface [IBaseShapeLock](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseshapelock/) é a classe de bloqueio genérica para PPTX. Os seguintes tipos de bloqueios são suportados no Aspose.Slides for .NET para PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshapelock/) bloqueia autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/pt/net/aspose.slides/iconnectorlock/) bloqueia formas de conector.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/pt/net/aspose.slides/igraphicalobjectlock/) bloqueia objetos gráficos.  
- [IGroupShapeLock](https://reference.aspose.com/slides/pt/net/aspose.slides/igroupshapelock/) bloqueia formas agrupadas.  
- [IPictureFrameLock](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframelock/) bloqueia molduras de imagem.  

Qualquer ação realizada em todos os objetos de forma em um objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) é aplicada a toda a apresentação.

## **Aplicar e Remover Proteção**

Aplicar proteção garante que uma apresentação não possa ser editada. É uma técnica útil para proteger o conteúdo da apresentação.

### **Aplicar Proteção a Formas PPTX**

O Aspose.Slides for .NET fornece a interface [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/) para trabalhar com formas em um slide.

Conforme mencionado anteriormente, cada classe de forma possui uma classe de bloqueio associada para proteção. Este artigo foca nos bloqueios NoSelect, NoMove e NoResize. Esses bloqueios garantem que as formas não possam ser selecionadas (por cliques do mouse ou outros métodos de seleção) e que não possam ser movidas ou redimensionadas.

O exemplo de código a seguir aplica proteção a todos os tipos de forma em uma apresentação.

```cs
// Instancie a classe Presentation que representa um arquivo PPTX.
using Presentation presentation = new Presentation("Sample.pptx");

// Percorrendo todos os slides da apresentação.
foreach (ISlide slide in presentation.Slides)
{
    // Percorrendo todas as formas no slide.
    foreach (IShape shape in slide.Shapes)
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

// Salvando o arquivo da apresentação.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Remover Proteção**

Para desbloquear uma forma, defina o valor do bloqueio aplicado como `false`. O exemplo de código a seguir mostra como desbloquear formas em uma apresentação protegida.

```cs
// Instancie a classe Presentation que representa um arquivo PPTX.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Percorrendo todos os slides da apresentação.
foreach (ISlide slide in presentation.Slides)
{
    // Percorrendo todas as formas no slide.
    foreach (IShape shape in slide.Shapes)
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

// Salvando o arquivo da apresentação.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Conclusão**

O Aspose.Slides oferece várias opções para proteger formas em uma apresentação. Você pode bloquear uma forma individual ou iterar por todas as formas em uma apresentação e bloquear cada uma para proteger efetivamente todo o arquivo. É possível remover a proteção definindo o valor do bloqueio como `false`.

## **Perguntas frequentes**

**Posso combinar bloqueios de forma e proteção por senha na mesma apresentação?**

Sim. Os bloqueios limitam a edição de objetos dentro do arquivo, enquanto a [proteção por senha](/slides/pt/net/password-protected-presentation/) controla o acesso à abertura e/ou gravação de alterações. Esses mecanismos se complementam e funcionam em conjunto.

**Posso restringir a edição em slides específicos sem afetar os demais?**

Sim. Aplique bloqueios às formas nos slides selecionados; os demais slides permanecerão editáveis.

**Os bloqueios de forma se aplicam a objetos agrupados e conectores?**

Sim. Tipos de bloqueio dedicados são suportados para grupos, conectores, objetos gráficos e outros tipos de forma.