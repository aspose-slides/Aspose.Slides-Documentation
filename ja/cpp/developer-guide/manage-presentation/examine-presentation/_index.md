---
title: "C++ でプレゼンテーション情報を取得および更新"
linktitle: "プレゼンテーション情報"
type: docs
weight: 30
url: /ja/cpp/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- プロパティの取得
- プロパティの読み取り
- プロパティの変更
- プロパティの修正
- プロパティの更新
- PPTX の検査
- PPT の検査
- ODP の検査
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ を使用して PowerPoint および OpenDocument のプレゼンテーション内のスライド、構造、メタデータを調査し、迅速な洞察とより賢いコンテンツ監査を実現します。"
---
## **概要**

この記事では、Aspose.Slides でプレゼンテーション情報を検査する方法を示します。ファイル全体を読み込まずにプレゼンテーションの現在の形式を判別し、ドキュメントプロパティを読み取り、必要に応じてそれらのプロパティを更新する方法を説明します。

例は[PresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentationinfo/)と[DocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/documentproperties/)APIを使用し、プレゼンテーションのメタデータを操作する典型的な操作を示しています。

## **プレゼンテーション形式の確認**

プレゼンテーションを操作する前に、現在の形式（PPT、PPTX、ODP など）を確認したい場合があります。

プレゼンテーションを読み込まずに形式を確認できます。この C++ コードを参照してください：

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **プレゼンテーション プロパティの取得**

この C++ コードは、プレゼンテーションのプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています：

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// 省略
```

## **プレゼンテーション プロパティの更新**

Aspose.Slides は、プレゼンテーションプロパティを変更できる[PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentationinfo/updatedocumentproperties/)メソッドを提供します。

以下のようなドキュメントプロパティを持つ PowerPoint プレゼンテーションがあるとします。

![PowerPoint プレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示しています：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

ドキュメントプロパティを変更した結果は以下のとおりです。

![PowerPoint プレゼンテーションの変更後のドキュメントプロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションおよびそのセキュリティ属性に関する詳細情報を取得するには、以下のリンクが役立ちます：

- [プレゼンテーションのパスワード保護](/slides/ja/cpp/password-protected-presentation/)
- [プレゼンテーションの書き込み保護](/slides/ja/cpp/write-protected-presentation/)

## **FAQ**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかをどう確認できますか？**

プレゼンテーションレベルで[embedded-font information](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/getembeddedfonts/)を取得し、[fonts actually used across content](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/getfonts/) の集合と比較することで、レンダリングに不可欠なフォントを特定できます。

**ファイルに非表示スライドがあるか、その数をすばやく確認する方法は？**

[slide collection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slidecollection/) を反復処理し、各スライドの[visibility flag](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slide/get_hidden/) を調べます。

**カスタムスライドサイズや方向が使用されているか、デフォルトと異なるかを検出できますか？**

現在の[slide size and orientation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_slidesize/) を標準プリセットと比較します。これにより、印刷やエクスポート時の挙動を予測できます。

**チャートが外部データソースを参照しているかをすばやく確認する方法はありますか？**

すべての[charts](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/chart/) を走査し、[data source](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) を確認して、データが内部かリンクベースか、壊れたリンクがあるかを把握します。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価するには？**

各スライドでオブジェクト数を集計し、大きな画像、透明度、影、アニメーション、マルチメディアなどをチェックして、概算の複雑度スコアを付け、パフォーマンス上のボトルネックを特定します。