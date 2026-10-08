---
title: C++ プレゼンテーションでのフォント置換の設定
linktitle: フォント置換
type: docs
weight: 70
url: /ja/cpp/font-substitution/
keywords:
- フォント
- 置換フォント
- フォント置換
- フォントの置換
- フォントの置き換え
- 置換ルール
- 置換ルール
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションをレンダリングまたは変換する際に、C++ 用 Aspose.Slides でフォント置換ルールを設定し、置換されたフォントを確認します。"
---
## **概要**

フォント置換を使用すると、プレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに、利用可能なフォントを Aspose.Slides が使用できるようになります。置換はレンダリングされた出力にのみ影響し、プレゼンテーション コンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、Aspose.Slides がレンダリング中に行う置換を確認できます。これにより、インストールされているフォントが異なる環境間でも出力を一貫させることができます。

フォントは利用可能だが専用の太字書体がない場合は、[Handle Fonts Without a Dedicated Bold Typeface](/slides/ja/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) を参照してください。そのセクションでは、PDF エクスポート時に影響を受けたテキストをビットマップ化する方法と、テキスト選択、検索、拡大縮小への影響について説明しています。

## **フォント置換の取得**

プレゼンテーションがレンダリングされるときに置換されるフォントを判断するには、[IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) メソッドを使用します。このメソッドは、元のフォント名と置換後のフォント名を示す[FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

次の C++ の例は、プレゼンテーションのすべてのフォント置換を一覧表示します。

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **選択スライドのフォント置換の取得**

`System::ArrayPtr<int32_t> slides` 引数を使用した [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) のオーバーロードを使用すると、特定のスライドのレンダリングに必要な置換のみを確認できます。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合、大規模なプレゼンテーションを段階的にチェックする場合、利用できないフォントに依存するスライドを特定する場合、サーバーやコンテナ用に最小限のフォントパッケージを用意する場合、または関係のないスライドを処理せずにレンダリングの差異を診断する場合に便利です。

`slides` 配列は 1 から始まるスライド インデックスを含みます。`1` は最初のスライドを表します。一方、[Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) メソッドは 0 ベースのインデックスを使用するため、同じスライドは `presentation->get_Slide(0)` でアクセスします。配列を作成する際はこの違いに注意し、オフバイワンエラーを防いでください。

オーバーロードは [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) メソッド経由で呼び出します。これにより、選択したスライドのレンダリング中に決定された置換のみが返されます。各結果は元のフォント名と置換後のフォント名を含む[FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) オブジェクトです。結果は現在のフォント環境、設定されたフォールバック ルール、[IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/) に保存された置換ルール、および[externally loaded fonts](/slides/ja/cpp/custom-font/) を反映します。

同じ置換が複数の選択スライドで必要になることがあります。フォント インベントリやプリフライト レポートを作成する際は結果を重複排除してください。次の例は、返されたすべての置換を報告し、ユニークなフォント マッピングのソート済みリストを作成します。

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

[IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) インターフェイスは両方のオーバーロードを提供します。レンダリング操作の対象範囲に応じて選択してください。

| オーバーロード | 使用するシーン |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | プレゼンテーション全体の置換が必要な場合。 |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | 選択範囲、増分チェック、または部分エクスポートの置換が必要な場合。 |

## **フォント置換ルールの設定**

元のフォントが利用できない場合に Aspose.Slides が使用すべきフォントを指定するには、次の手順を実行します。

1. プレゼンテーションを読み込みます。
2. 元フォントと置換フォントのフォント定義を作成します。
3. [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/) 条件を使用して [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) を作成します。
4. ルールを [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/) に追加します。
5. [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/) メソッドを使用してコレクションを割り当てます。
6. プレゼンテーションをレンダリングまたは変換します。

以下の C++ の例は、`SomeRareFont` が利用できない場合に `Arial` を置換フォントとして使用し、結果を確認するために最初のスライドをレンダリングします。置換フォントは Aspose.Slides で利用可能である必要があります。

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
プレゼンテーション全体で使用されるフォントを無条件に変更するには、[Font Replacement](/slides/ja/cpp/font-replacement/) を参照してください。
{{% /alert %}}

## **数式フォントの制限**

フォント置換ルールは、レンダリングおよび変換中に使用される標準的なフォント選択プロセスの一部です。ルールで指定された利用可能なフォントに置換できる場合、通常のテキストに対して機能します。

Office Math の数式は追加の要件があります。数式が **Cambria Math** を使用している場合、Aspose.Slides はレイアウトの計算とレンダリングにその正確なフォントが必要になることがあります。**STIX Two Math** のような別の数式フォントに置換するルールは、**Cambria Math** の代替にはなりません。そのため、レンダリング時に依然として **Cambria Math** が必要であると報告されることがあります。

このようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が使用できるようにしてください。オペレーティングシステムにインストールするか、[external font](/slides/ja/cpp/custom-font/) としてロードします。

この制限は数式レイアウトに適用されます。上記の置換ルールは通常のプレゼンテーションテキストには引き続き適用されます。

## **FAQ**

**フォント置換（Font Replacement）とフォント置換（Font Substitution）の違いは何ですか？**

[Font replacement](/slides/ja/cpp/font-replacement/) は、プレゼンテーション全体でフォントを別のフォントに意図的に変更します。**Font substitution** は、元のフォントが利用できないなど、設定された条件が満たされたときに、レンダリングされた出力用のフォントを選択します。

**置換ルールはいつ適用されますか？**

ルールは、レンダリングおよび変換中の [font selection sequence](/slides/ja/cpp/font-selection-sequence/) に参加します。`WhenInaccessible` を使用した場合、ソースフォントにアクセスできないときにのみルールが使用されます。

**フォントが欠落し、置換ルールが設定されていない場合はどうなりますか？**

Aspose.Slides はフォント選択プロセスに従って、最も近い利用可能なフォントを選択します。結果は実行環境で利用できるフォントに依存します。

**外部フォントをロードして置換を回避できますか？**

はい。[外部フォントをロード](/slides/ja/cpp/custom-font/) で Aspose.Slides がレンダリングと変換時に使用できるようにできます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントはご自身で用意し、ライセンスを遵守する必要があります。

**置換結果は Windows、Linux、macOS 間で異なる可能性がありますか？**

はい。インストールされているフォントやフォント検索パスは OS によって異なるため、あるマシンで利用できるフォントが別のマシンでは置換が必要になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**

すべてのマシンやコンテナで同じフォント ファイルとバージョンを使用し、[必要な外部フォントをロード](/slides/ja/cpp/custom-font/) し、ライセンスが許可する場合は[フォントを埋め込む](/slides/ja/cpp/embedded-font/)ことが推奨されます。また、エクスポート前に [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) を呼び出して、予期しない置換を特定することもできます。