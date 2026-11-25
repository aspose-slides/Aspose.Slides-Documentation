---
title: Restringir edições de apresentação com bloqueios de forma em C++
linktitle: Restringir edições de apresentação
type: docs
weight: 10
url: /pt/cpp/applying-protection-to-presentation/
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
- C++
- Aspose.Slides
description: "Aprenda como bloquear e desbloquear formas em apresentações PPTX com Aspose.Slides para C++ para restringir seleção, movimentação, redimensionamento e agrupamento."
---
## **Contexto**

Um uso comum do Aspose.Slides for C++ é criar, atualizar e salvar apresentações PowerPoint (PPTX) como parte de um fluxo de trabalho automatizado. Quando os usuários recebem essas apresentações, restringir alterações nas formas pode ajudar a preservar o layout e o conteúdo desejados.

Este artigo explica como as formas são organizadas nos slides e como aplicar e remover bloqueios de forma em uma apresentação PPTX. Esses bloqueios permitem restringir operações de edição específicas em formas individuais.

## **Composição de um Slide**

Um slide de apresentação é composto por componentes como autoshapes, tabelas, objetos OLE, formas agrupadas, quadros de imagem, quadros de vídeo, conectores e outros elementos usados para construir uma apresentação. No Aspose.Slides for C++, cada elemento em um slide é representado por um objeto que implementa a interface [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) ou herda de uma classe que o faz.

Diferentes tipos de forma expõem diferentes opções de bloqueio. A interface [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) é a interface base para bloqueios de forma. O Aspose.Slides for C++ fornece as seguintes interfaces de bloqueio:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) bloqueia autoshapes.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) bloqueia formas de conectores.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) bloqueia objetos gráficos.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) bloqueia formas agrupadas.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) bloqueia quadros de imagem.

Para aplicar bloqueios em uma [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), percorra seus slides e defina os bloqueios apropriados em cada forma suportada.

## **Aplicar e Remover Proteção**

Editores de apresentação compatíveis usam bloqueios de forma para restringir operações de edição individuais. Criptografia de arquivo e proteção contra gravação em nível de documento são configurações separadas de [presentation protection settings](/slides/pt/cpp/password-protected-presentation/).

### **Aplicar Proteção a Formas PPTX**

O Aspose.Slides for C++ fornece a interface [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) para trabalhar com formas em um slide.

O exemplo passa `true` para [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) e [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) para autoshapes, com bloqueios equivalentes para formas agrupadas, conectores e quadros de imagem. Conectores usam [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) para movimento; grupos também usam [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) para restringir o agrupamento.

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

Para remover um bloqueio de forma, defina seu valor como `false`. O exemplo a seguir carrega uma apresentação com bloqueios de forma e limpa as restrições de seleção, movimento e redimensionamento através de [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) e [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Ele também limpa [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) e salva uma cópia da apresentação. Outras configurações de bloqueio permanecem inalteradas.

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

### **Preservar um Recorte de Imagem**

Coloque uma foto chamada `photo.jpg` no diretório de trabalho. O exemplo recorta 12 % da esquerda e 8 % da direita, então chama [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) no bloqueio do quadro de imagem para preservar o recorte e restringir novos recortes.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto photoBytes = File::ReadAllBytes(u"photo.jpg");
auto photo = presentation->get_Images()->AddImage(photoBytes);

auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, photo);
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_CropLeft(12);
pictureFormat->set_CropRight(8);

auto pictureFrameLock = pictureFrame->get_PictureFrameLock();
pictureFrameLock->set_AspectRatioLocked(false);
pictureFrameLock->set_CropLocked(true);

presentation->Save(u"PictureLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`PictureLocked.pptx` armazena o bloqueio de recorte como `true`. No PowerPoint, o comando **Crop** fica desabilitado quando a foto está selecionada.

### **Manter um Diagrama Agrupado**

O exemplo agrupa um retângulo e uma seta, então chama [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) no bloqueio do grupo para manter os componentes do diagrama juntos. Outras edições, como mover o grupo ou alterar o preenchimento de um componente, permanecem disponíveis.

```cpp
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto groupShape = shapes->AddGroupShape();
auto groupShapes = groupShape->get_Shapes();
groupShapes->AddAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
groupShapes->AddAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
groupShape->get_GroupShapeLock()->set_UngroupingLocked(true);

presentation->Save(u"DiagramLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`DiagramLocked.pptx` armazena o bloqueio de desagrupamento como `true`. No PowerPoint, o comando **Ungroup** fica desabilitado quando todo o diagrama está selecionado.

### **Relatar Bloqueios de Forma Existentes**

Para analisar um modelo, abra-o e leia o objeto de bloqueio de cada forma. [get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) retorna `true` quando todas as flags nesse objeto estão desativadas e `false` quando ao menos uma está ativada. Um grupo e seus filhos possuem objetos de bloqueio separados, portanto inspecione os filhos mesmo quando o grupo não tem bloqueios.

Este exemplo verifica movimento para autoshapes, quadros de imagem e grupos, recorte para imagens e desagrupamento para grupos. Ele relata as flags reconhecidas e marca tipos de forma que não são inspecionados.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/list.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <functional>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

std::function<void(SharedPtr<IShapeCollection>, int, String)> inspect;
inspect = [&inspect](SharedPtr<IShapeCollection> shapes, int slideNumber, String prefix)
{
    for (auto&& shape : IterateOver(shapes))
    {
        auto path = prefix + shape->get_Name();
        auto label = String::Format(u"Slide {0} | {1} | {2}", slideNumber, path, shape->GetType().get_Name());
        auto flags = MakeObject<List<String>>();
        auto group = AsCast<IGroupShape>(shape);

        if (group)
        {
            auto locks = group->get_GroupShapeLock();
            if (locks->get_UngroupingLocked()) flags->Add(u"UngroupingLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto picture = AsCast<IPictureFrame>(shape))
        {
            auto locks = picture->get_PictureFrameLock();
            if (locks->get_CropLocked()) flags->Add(u"CropLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto autoShape = AsCast<IAutoShape>(shape))
        {
            if (autoShape->get_AutoShapeLock()->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else
        {
            Console::WriteLine(label + u" | Uninspected");
            continue;
        }

        if (!shape->get_ShapeLock()->get_NoLocks())
        {
            auto restrictions = flags->get_Count() ? String::Join(u", ", flags->ToArray()) : String(u"Active flag not identified");
            Console::WriteLine(label + u" | " + restrictions);
        }

        if (group)
            inspect(group->get_Shapes(), slideNumber, path + u"/");
    }
};

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    inspect(slide->get_Shapes(), slide->get_SlideNumber(), u"");
}
presentation->Dispose();
```

Suponha que o slide 1 de `Sample.pptx` contenha um grupo chamado `Layout` com desagrupamento bloqueado, uma imagem chamada `Photo` dentro dele com recorte bloqueado e um retângulo desbloqueado chamado `Free`. O relatório ignora `Free` e imprime estas duas linhas:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

O relatório lê as flags de edição armazenadas no nível da forma sem alterá‑las ou salvar a apresentação. A proteção contra gravação em nível de documento é uma configuração separada, e a aplicação de cada flag depende do editor.

### **Conclusão**

O Aspose.Slides for C++ permite restringir operações de edição específicas em formas individuais ou aplicar as mesmas restrições em vários slides. Escolha os bloqueios suportados por cada tipo de forma e defina seus valores como `false` quando precisar remover essas restrições.

## **FAQ**

**Posso combinar bloqueios de forma e proteção por senha na mesma apresentação?**

Sim. Os bloqueios de forma restringem operações de edição específicas, enquanto a [password protection](/slides/pt/cpp/password-protected-presentation/) pode restringir a abertura ou modificação da apresentação. Você pode usar ambos no mesmo arquivo.

**Posso restringir a edição em slides específicos sem afetar os demais?**

Sim. Aplique bloqueios apenas às formas nos slides selecionados. Isso não altera as configurações de bloqueio nos demais slides.

**Como posso aplicar bloqueios a formas individuais dentro de um grupo?**

Percorra a coleção retornada pelo método [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) do grupo e aplique os bloqueios apropriados a cada forma filha. Repita isso para quaisquer grupos aninhados, seguindo a travessia mostrada no exemplo de relatório.