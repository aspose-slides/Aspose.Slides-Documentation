---
title: C++ におけるフォールバック フォント コレクションの構成
linktitle: フォールバック フォント コレクション
type: docs
weight: 20
url: /ja/cpp/create-fallback-fonts-collection/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォント コレクション
- フォントの構成
- フォントの設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "PowerPoint と OpenDocument のプレゼンテーションでテキストの一貫性と鮮明さを保つため、Aspose.Slides for C++ でフォールバック フォント コレクションを設定します。"
---
## **概要**

Aspose.Slides を使用すると、プレゼンテーション用のフォールバック フォント ルールのコレクションを構成できます。各フォールバック ルールは `FontFallBackRule` クラスで表され、`IFontFallBackRulesCollection` インターフェイスを実装する `FontFallBackRulesCollection` に追加できます。

コレクションを作成した後、プレゼンテーションの `FontsManager` の `set_FontFallBackRulesCollection` メソッドを使用して割り当てることができます。`FontsManager` はプレゼンテーション全体のフォントを管理し、各 `Presentation` インスタンスは独自の `FontsManager` を持ちます。

`FontsManager` がフォールバック フォント コレクションで初期化されると、指定されたフォールバック フォントがプレゼンテーションのレンダリング中に適用されます。

## **フォールバック ルールの適用**

[FontFallBackRule](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrule/) クラスのインスタンスは、[IFontFallBackRulesCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontfallbackrulescollection/) インターフェイスを実装する [FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrulescollection/) に編成できます。コレクションからルールを追加または削除することが可能です。

次に、このコレクションは [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) メソッドに渡すことができ、[FontsManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/) クラスで使用されます。FontsManager はプレゼンテーション全体のフォントを制御します。

各 [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) には、FontsManager クラスの独自のインスタンスを返す [get_FontsManager()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_fontsmanager/) メソッドがあります。

以下は、フォールバック フォント ルール コレクションを作成し、特定のプレゼンテーションの FontsManager に割り当てる例です。

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

FontsManager がフォールバック フォント コレクションで初期化されると、フォールバック フォントはプレゼンテーションのレンダリング中に適用されます。

{{% alert color="info" %}} 
フォールバック フォントでプレゼンテーションをレンダリングする方法の詳細はこちら: [フォールバック フォントでプレゼンテーションをレンダリング](/slides/ja/cpp/render-presentation-with-fallback-font/)。 
{{% /alert %}}

## **よくある質問**

### フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされないため、PowerPoint の UI には表示されません。

### SmartArt、WordArt、チャート、テーブル内のテキストにもフォールバックは適用されますか？

はい。これらのオブジェクト内のテキストにも同じグリフ置換機構が使用されます。

### Aspose はライブラリにフォントを同梱していますか？

いいえ。フォントはお客様側で追加・使用していただき、自己責任で管理してください。

### 不足しているフォントの置換/サブスティテューションと、欠損グリフのフォールバックは同時に使用できますか？

はい。これは同じフォント解決パイプラインの独立した段階です。最初にエンジンがフォントの可用性を解決し（[replacement](/slides/ja/cpp/font-replacement/)/[substitution](/slides/ja/cpp/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠損グリフを補完します。