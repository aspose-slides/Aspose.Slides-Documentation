---
title: C++ のシェイプレックでプレゼンテーションの編集を制限する
linktitle: プレゼンテーションの編集を制限
type: docs
weight: 10
url: /ja/cpp/applying-protection-to-presentation/
keywords:
- 編集防止
- 編集から保護
- シェイプレック
- 位置ロック
- 選択ロック
- サイズ変更ロック
- グループ化ロック
- PowerPoint
- PPTX
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PPTX プレゼンテーションのシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **背景**

Aspose.Slides for C++ の一般的な使用方法は、PowerPoint (PPTX) プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際に、図形の変更を制限することで意図したレイアウトと内容を保持するのに役立ちます。

この記事では、スライド上で図形がどのように構成されているか、そして PPTX プレゼンテーションで図形ロックを適用および解除する方法について説明します。これらのロックにより、個々の図形に対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化された図形、画像フレーム、ビデオフレーム、コネクタ、その他プレゼンテーションの作成に使用される要素で構成されています。Aspose.Slides for C++ では、スライド上の各要素は[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) インターフェイスを実装するオブジェクト、またはそのクラスから派生したオブジェクトで表されます。

形状の種類に応じて異なるロックオプションが提供されます。[IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) インターフェイスは図形ロックの基本インターフェイスです。Aspose.Slides for C++ は以下のロックインターフェイスを提供します：

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) はオートシェイプをロックします。
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) はコネクタ形状をロックします。
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) はグラフィックオブジェクトをロックします。
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) はグループ形状をロックします。
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) は画像フレームをロックします。

ロックを[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 全体に適用するには、スライドを列挙し、各サポートされている図形に適切なロックを設定します。

## **保護の適用と削除**

図形ロックは、図形の選択、移動、サイズ変更などの操作を制限します。ただし、プレゼンテーション全体を編集できなくするわけではありません。

### **PPTX 図形への保護の適用**

Aspose.Slides for C++ は、スライド上の図形を操作するための[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) インターフェイスを提供します。

この例では、オートシェイプに対して `true` を[set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/)、[set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/)、[set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) に渡し、グループ形状、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動のために[set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) を使用し、グループはグループ化を制限するために[set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) も使用します。

この例では、既存の PPTX プレゼンテーションを読み込み、各スライドの shape collection 内の図形をチェックし、これらの制限が適用されたコピーを保存します。取り扱われている 4 種類以外の図形は変更されません。ループはグループ内の子図形を走査しません。

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

### **保護の削除**

図形ロックを削除するには、その値を `false` に設定します。以下の例では、ロックされた図形を持つプレゼンテーションを読み込み、[IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/)、[IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) を通じて選択、移動、サイズ変更の制限を解除します。また、[IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) もクリアし、プレゼンテーションのコピーを保存します。他のロック設定は変更されません。

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

### **結論**

Aspose.Slides for C++ を使用すると、個々の図形に対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。各図形タイプでサポートされているロックを選択し、制限を解除する必要がある場合は値を `false` に設定してください。

## **よくある質問**

**同じプレゼンテーションで図形ロックとパスワード保護を組み合わせることはできますか？**

はい。図形ロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/cpp/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同じファイルで使用できます。

**特定のスライドだけ編集を制限し、他のスライドには影響させないことはできますか？**

はい。選択したスライドの図形にのみロックを適用すれば、他のスライドのロック設定は変更されません。

**グループ内の個々の図形にロックを適用するにはどうすればよいですか？**

グループの[get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) メソッドが返すコレクションを走査し、各子図形に適切なロックを適用します。入れ子になったグループがある場合は同様に繰り返します。上記の例はスライドの shape collection のみを処理しているため、個々のグループメンバーにはロックを設定していません。