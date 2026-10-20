---
title: Restringir Edições de Apresentação com Bloqueios de Forma em C++
linktitle: Restringir Edições de Apresentação
type: docs
weight: 10
url: /pt/cpp/applying-protection-to-presentation/
keywords:
- prevenir edições
- proteger contra edição
- bloquear forma
- bloquear posição
- bloquear seleção
- bloquear redimensionamento
- bloquear agrupamento
- PowerPoint
- PPTX
- apresentação
- C++
- Aspose.Slides
description: "Aprenda como bloquear e desbloquear formas em apresentações PPTX com Aspose.Slides para C++ para restringir seleção, movimentação, redimensionamento e agrupamento."
---
## **Contexto**

Um uso comum do Aspose.Slides para C++ é criar, atualizar e salvar apresentações PowerPoint (PPTX) como parte de um fluxo de trabalho automatizado. Quando os usuários recebem essas apresentações, restringir alterações em formas pode ajudar a preservar o layout e o conteúdo pretendidos.

Este artigo explica como as formas são organizadas nos slides e como aplicar e remover bloqueios de forma em uma apresentação PPTX. Esses bloqueios permitem restringir operações específicas de edição em formas individuais.

## **Composição de um Slide**

Um slide de apresentação é composto por componentes como autoshapes, tabelas, objetos OLE, formas agrupadas, frames de imagem, frames de vídeo, conectores e outros elementos usados para construir uma apresentação. No Aspose.Slides para C++, cada elemento em um slide é representado por um objeto que implementa a interface [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) ou herda de uma classe que o faz.

Tipos diferentes de forma expõem opções de bloqueio diferentes. A interface [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) é a interface base para bloqueios de forma. O Aspose.Slides para C++ fornece as seguintes interfaces de bloqueio:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) bloqueia autoshapes.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) bloqueia formas de conector.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) bloqueia objetos gráficos.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) bloqueia formas agrupadas.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) bloqueia frames de imagem.

Para aplicar bloqueios em uma [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), itere pelos seus slides e defina os bloqueios apropriados em cada forma suportada.

## **Aplicar e Remover Proteção**

Os bloqueios de forma restringem operações como selecionar, mover e redimensionar formas. Eles não tornam toda a apresentação não editável.

### **Aplicar Proteção a Formas PPTX**

O Aspose.Slides para C++ fornece a interface [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) para trabalhar com formas em um slide.

O exemplo passa `true` para [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) e [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) para autoshapes, com bloqueios equivalentes para formas agrupadas, conectores e frames de imagem. Conectores usam [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) para movimento; grupos também usam [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) para restringir agrupamento.

O exemplo carrega uma apresentação PPTX existente, verifica as formas na coleção de formas de cada slide e salva uma cópia com essas restrições aplicadas. Formas fora dos quatro tipos tratados permanecem inalteradas. O loop não percorre as formas filhas dentro de um grupo.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(true);
            autoShapeLock->set_SelectLocked(true);
            autoShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(true);
            groupShapeLock->set_PositionLocked(true);
            groupShapeLock->set_SelectLocked(true);
            groupShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(true);
            connectorShapeLock->set_SelectLocked(true);
            connectorShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(true);
            pictureFrameLock->set_SelectLocked(true);
            pictureFrameLock->set_SizeLocked(true);
        }
    }
}

presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Remover Proteção**

Para remover um bloqueio de forma, defina seu valor como `false`. O exemplo a seguir carrega uma apresentação com bloqueios de forma e limpa as restrições de seleção, movimento e redimensionamento através de [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) e [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Também limpa [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) e salva uma cópia da apresentação. Outras configurações de bloqueio permanecem inalteradas.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(false);
            autoShapeLock->set_SelectLocked(false);
            autoShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(false);
            groupShapeLock->set_PositionLocked(false);
            groupShapeLock->set_SelectLocked(false);
            groupShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(false);
            connectorShapeLock->set_SelectLocked(false);
            connectorShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(false);
            pictureFrameLock->set_SelectLocked(false);
            pictureFrameLock->set_SizeLocked(false);
        }
    }
}

presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Conclusão**

O Aspose.Slides para C++ permite restringir operações específicas de edição em formas individuais ou aplicar as mesmas restrições em vários slides. Escolha os bloqueios suportados por cada tipo de forma e defina seus valores como `false` quando precisar remover essas restrições.

## **FAQ**

**Posso combinar bloqueios de forma e proteção por senha na mesma apresentação?**

Sim. Bloqueios de forma restringem operações específicas de edição, enquanto a [proteção por senha](/slides/pt/cpp/password-protected-presentation/) pode restringir a abertura ou modificação da apresentação. Você pode usar ambos no mesmo arquivo.

**Posso restringir a edição em slides específicos sem afetar os demais?**

Sim. Aplique bloqueios apenas às formas nos slides selecionados. Isso não altera as configurações de bloqueio nos outros slides.

**Como aplicar bloqueios a formas individuais dentro de um grupo?**

Itere pela coleção retornada pelo método [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) do grupo e aplique os bloqueios apropriados a cada forma filha. Repita isso para grupos aninhados. Os exemplos acima processam apenas a coleção de formas do slide, portanto não definem bloqueios em membros individuais de um grupo.