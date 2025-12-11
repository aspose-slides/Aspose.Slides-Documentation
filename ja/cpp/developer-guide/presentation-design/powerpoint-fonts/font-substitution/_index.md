---
title: "С++ を使用したプレゼンテーションでのフォント置換の設定"
linktitle: "フォント置換"
type: docs
weight: 70
url: /ja/cpp/font-substitution/
keywords:
- "フォント"
- "置換フォント"
- "フォント置換"
- "フォント置換"
- "フォント置換"
- "置換ルール"
- "置換ルール"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "С++"
- "Aspose.Slides"
description: "PowerPoint および OpenDocument のプレゼンテーションを他のファイル形式に変換する際、С++ 用 Aspose.Slides で最適なフォント置換を有効にします。"
---

## **フォント置換ルールの設定**

Aspose.Slides は、フォントに対するルールを設定でき、特定の条件（例: フォントにアクセスできない場合）で何をすべきかを次のように決められます：

1. 関連するプレゼンテーションを読み込む。
2. 置換対象のフォントを読み込む。
3. 新しいフォントを読み込む。
4. 置換用のルールを追加する。
5. そのルールをプレゼンテーションのフォント置換ルールコレクションに追加する。
6. スライド画像を生成して効果を確認する。

この C++ コードはフォント置換プロセスを示しています：
```c++
// ドキュメント ディレクトリへのパス。
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// プレゼンテーションを読み込む
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 置換対象のフォントと新しいフォントを定義する
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// フォント置換のためのルールを追加する
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// フォント置換ルールコレクションにルールを追加する
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// ルールリストにフォントルールコレクションを追加する
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// PPTX をディスクに保存する
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert title="NOTE"  color="warning"   %}} 
以下をご覧ください。[**フォント置換**](/slides/ja/cpp/font-replacement/)。 
{{% /alert %}}

## **よくある質問**

**フォント置換とフォント代替の違いは何ですか？**

[Replacement](/slides/ja/cpp/font-replacement/) は、プレゼンテーション全体であるフォントを別のフォントに強制的に置き換えるものです。代替は、特定の条件（例: 元のフォントが利用できない場合）でトリガーされ、指定されたフォールバックフォントが使用されるルールです。

**代替ルールは正確にいつ適用されますか？**

これらのルールは、読み込み、レンダリング、変換時に評価される標準的な[フォント選択](/slides/ja/cpp/font-selection-sequence/) シーケンスに組み込まれます。選択されたフォントが利用できない場合、置換または代替が適用されます。

**置換も代替も設定されておらず、システムにフォントが存在しない場合のデフォルト動作は何ですか？**

ライブラリは、PowerPoint と同様に、利用可能なシステムフォントの中で最も近いものを選択しようとします。

**代替を防ぐために、実行時にカスタム外部フォントを添付できますか？**

はい。実行時に[外部フォントを追加](/slides/ja/cpp/custom-font/) することで、ライブラリはそれらを選択やレンダリング、さらには以降の変換時にも考慮します。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。Aspose は有料・無料を問わずフォントを配布していません。フォントはご自身の判断と責任で追加・使用してください。

**Windows、Linux、macOS での代替動作に違いはありますか？**

はい。フォントの検出は OS のフォントディレクトリから開始されます。デフォルトで利用可能なフォントのセットや検索パスはプラットフォームごとに異なり、利用可能性や代替の必要性に影響します。

**バッチ変換時の予期しない代替を最小限に抑えるために、環境はどのように整えるべきですか？**

マシンやコンテナ間でフォントセットを同期し、出力ドキュメントに必要な[外部フォントを追加](/slides/ja/cpp/custom-font/)し、可能であればプレゼンテーションに[フォントを埋め込む](/slides/ja/cpp/embedded-font/)ことで、レンダリング時に選択したフォントが利用できるようにします。