---
title: C++ のシェイプロックでプレゼンテーションの編集を制限する
linktitle: プレゼンテーションの編集を制限
type: docs
weight: 10
url: /ja/cpp/applying-protection-to-presentation/
keywords:
- 編集防止
- 編集から保護
- シェイプをロック
- 位置をロック
- 選択をロック
- サイズ変更をロック
- グループ化をロック
- PowerPoint
- PPTX
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PPTX プレゼンテーションのシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **背景**

Aspose.Slides for C++ の一般的な使用例は、PowerPoint (PPTX) プレゼンテーションを自動化ワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際に、シェイプへの変更を制限することで、意図したレイアウトとコンテンツを保護できます。

この記事では、スライド上でシェイプがどのように構成されているか、そして PPTX プレゼンテーションでシェイプ ロックを適用および削除する方法を説明します。これらのロックにより、個々のシェイプに対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化シェイプ、画像フレーム、ビデオフレーム、コネクタ、およびプレゼンテーションの作成に使用されるその他の要素で構成されます。Aspose.Slides for C++ では、スライド上の各要素は [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) インターフェイスを実装するオブジェクト、あるいはそのクラスから継承したオブジェクトで表されます。

シェイプの種類に応じて異なるロックオプションが提供されます。[IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) インターフェイスはシェイプ ロックの基本インターフェイスです。Aspose.Slides for C++ は以下のロックインターフェイスを提供します：

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) はオートシェイプをロックします。
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) はコネクタシェイプをロックします。
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) はグラフィカルオブジェクトをロックします。
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) はグループシェイプをロックします。
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) は画像フレームをロックします。

ロックを [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 全体に適用するには、スライドを順に走査し、サポートされている各シェイプに適切なロックを設定します。

## **保護の適用と解除**

互換性のあるプレゼンテーションエディタはシェイプ ロックを使用して個別の編集操作を制限します。ファイル暗号化およびドキュメントレベルの書き込み保護は、別個の [プレゼンテーション保護設定](/slides/ja/cpp/password-protected-presentation/) です。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for C++ はスライド上のシェイプを操作するための [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) インターフェイスを提供します。

この例では、オートシェイプに対して `true` を [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/)、[set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) および [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) に渡し、グループシェイプ、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動に [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) を使用し、グループはグループ化を制限するために [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) を使用します。

この例では既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプコレクション内のシェイプをチェックし、これらの制約が適用されたコピーを保存します。対象の4つのタイプ以外のシェイプは変更されません。ループはグループ内部の子シェイプを走査しません。

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

### **保護の解除**

シェイプ ロックを解除するには、その値を `false` に設定します。以下の例では、シェイプ ロックが設定されたプレゼンテーションを読み込み、[IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/)、および [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) を使用して選択、移動、サイズ変更の制限をクリアします。また、[IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) をクリアし、プレゼンテーションのコピーを保存します。他のロック設定は変更されません。

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

### **画像の切り抜きの保持**

作業ディレクトリに `photo.jpg` という名前の写真を配置します。この例では左側から12%、右側から8% を切り抜き、画像フレームロックの [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) を呼び出して切り抜きを保持し、以降の切り抜きを制限します。

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

`PictureLocked.pptx` は切り抜きロックを `true` として保存します。PowerPoint では、写真が選択されているとき **Crop** コマンドが無効化されます。

### **図表をグループ化したままにする**

この例では矩形と矢印をグループ化し、グループのロックに対して [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) を呼び出して図表の構成要素を一緒に保持します。グループの移動や構成要素の塗りの変更など、他の編集は引き続き可能です。

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

`DiagramLocked.pptx` はグループ解除ロックを `true` として保存します。PowerPoint では、図全体が選択されているとき **Ungroup** コマンドが無効化されます。

### **既存シェイプロックの報告**

テンプレートを確認するには、開いて各シェイプのロックオブジェクトを読み取ります。[get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) はそのオブジェクト上のすべてのフラグが無効な場合に `true` を、少なくとも1つが有効な場合に `false` を返します。グループとその子は別々のロックオブジェクトを持つため、グループにロックがなくても子を検査してください。

この例では、オートシェイプ、画像フレーム、グループの移動、画像の切り抜き、グループの解除をチェックします。認識したフラグを報告し、検査しないシェイプタイプはマークします。

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

`Sample.pptx` のスライド 1 に、グループ解除がロックされた `Layout` という名前のグループがあり、その中に切り抜きがロックされた `Photo` という画像があり、ロックされていない矩形 `Free` があるとします。レポートは `Free` をスキップし、次の2行を出力します：

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

このレポートは、保存されたシェイプレベルの編集フラグを読み取りますが、変更したりプレゼンテーションを保存したりはしません。ドキュメントレベルの書き込み保護は別個の設定であり、各フラグの適用はエディタに依存します。

### **結論**

Aspose.Slides for C++ を使用すると、個々のシェイプに対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。シェイプタイプごとにサポートされているロックを選択し、制限を解除する必要がある場合は値を `false` に設定してください。

## **FAQ**

**プレゼンテーションでシェイプロックとパスワード保護を併用できますか？**

はい。シェイプロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/cpp/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同一ファイルで使用できます。

**特定のスライドだけの編集を制限し、他のスライドに影響を与えませんか？**

はい。選択したスライドのシェイプにのみロックを適用します。これにより、他のスライドのロック設定は変更されません。

**グループ内の個別シェイプにロックを適用するにはどうすればよいですか？**

グループの [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) メソッドが返すコレクションを走査し、各子シェイプに適切なロックを適用します。入れ子になったグループがある場合は、レポート例の走査方法に従って同様に処理してください。