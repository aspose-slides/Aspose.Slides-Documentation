---
title: C++ を使用したプレゼンテーションでのフォント置換の構成
linktitle: フォント置換
type: docs
weight: 70
url: /ja/cpp/font-substitution/
keywords:
- フォント
- 代替フォント
- フォント置換
- フォントの置換
- フォント置き換え
- 置換ルール
- 置換規則
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "PowerPoint および OpenDocument のプレゼンテーションを他のファイル形式に変換する際に、C++ 用 Aspose.Slides で最適なフォント置換を有効にします。"
---
## **概要**

フォント置換により、Aspose.Slides はレンダリングまたは変換時に元のプレゼンテーションのフォントが利用できない場合、別のフォントを使用できます。 `IFontsManager` インターフェイスの `GetSubstitutions` メソッドを使用すると、どのフォントが置換されたかを確認できます。

Aspose.Slides はフォント置換ルールの定義も可能です。たとえば、アクセスできないフォントを別の利用可能なフォントに置き換えるよう指定し、そのルールをプレゼンテーションのフォントマネージャーを通じて適用できます。

## **フォント置換ルールの設定**

Aspose.Slides では、特定の条件下（たとえばフォントにアクセスできない場合）に何を行うかを決定するフォントのルールを次のように設定できます。

1. 対象のプレゼンテーションをロードします。
2. 置換対象のフォントをロードします。
3. 新しいフォントをロードします。
4. 置換のルールを追加します。
5. そのルールをプレゼンテーションのフォント置換ルールコレクションに追加します。
6. スライド画像を生成して効果を確認します。

この C++ コードはフォント置換プロセスを示しています：

```c++
// ドキュメント ディレクトリへのパスです。
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// プレゼンテーションを読み込みます
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 置換されるフォントと新しいフォントを定義します
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// フォント置換のためのルールを追加します
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// ルールをフォント置換ルールコレクションに追加します
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// フォントルールコレクションをルールリストに追加します
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


 // PPTX をディスクに保存します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
この項目を確認したい場合は[**フォント置換**](/slides/ja/cpp/font-replacement/)をご覧ください。 
{{% /alert %}}

## **数式フォントの制限**

フォント置換ルールは、レンダリングおよび変換時に使用される標準のフォント選択プロセスに参加します。これは、Aspose.Slides が設定されたルールに従って利用できないフォントを別の利用可能なフォントに置き換えることができる、通常のテキストシナリオに適しています。

しかし、Office の数式には重要な制限があります。数式が **Cambria Math** で作成されている場合、Aspose.Slides は数式レイアウトを正しく計算・描画するために元の **Cambria Math** フォントを依然として必要とすることがあります。そのため、**Cambria Math** を **STIX Two Math** などの別の数式フォントに置換することは、数式の描画ではサポートされず、**Cambria Math** が必要であることを示す例外が発生する可能性があります。

このようなプレゼンテーションを正常に変換するには、実行時に **Cambria Math** が Aspose.Slides で利用可能であることを確認してください。フォントを OS にインストールするか、[外部フォント](/slides/ja/cpp/custom-font/)として提供し、レンダリングおよび変換時の通常のフォント選択プロセスに参加させることができます。

この制限は数式の描画に特化したものです。上記の標準フォント置換ルールは、元のフォントが利用できない通常のプレゼンテーションテキストには引き続き適用されます。

## **FAQ**

**フォント置換とフォント置換（置換）の違いは何ですか？**

[置換](/slides/ja/cpp/font-replacement/) はプレゼンテーション全体であるフォントを別のフォントに強制的に上書きすることです。置換は特定の条件（たとえば元のフォントが利用できない場合）でトリガーされ、指定された代替フォントが使用されます。

**置換ルールは正確にはいつ適用されますか？**

これらのルールはロード、レンダリング、変換時に評価される標準の[フォント選択](/slides/ja/cpp/font-selection-sequence/)シーケンスに参加します。選択されたフォントが利用できない場合に置換または置換が適用されます。

**置換も置換規則も設定されておらず、システムにフォントが存在しない場合の既定の動作は？**

ライブラリは PowerPoint の動作に似て、最も近い利用可能なシステムフォントを選択しようとします。

**実行時にカスタム外部フォントを添付して置換を回避できますか？**

はい。実行時に[外部フォントを追加](/slides/ja/cpp/custom-font/)すれば、ライブラリはそれらを選択とレンダリングの対象に含め、以降の変換でも使用できます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。Aspose は有料または無料のフォントを配布しません。フォントはご自身の判断と責任で追加・使用してください。

**Windows、Linux、macOS で置換の動作に違いがありますか？**

あります。フォントの検出は OS のフォントディレクトリから開始されます。デフォルトで利用可能なフォントセットや検索パスはプラットフォームごとに異なるため、利用可能性と置換の必要性に影響します。

**バッチ変換時に予期しない置換を最小限に抑えるための環境準備は？**

マシンやコンテナ間でフォントセットを同期し、出力ドキュメントに必要な[外部フォント](/slides/ja/cpp/custom-font/)を[追加]し、可能であればプレゼンテーションに[フォントを埋め込む](/slides/ja/cpp/embedded-font/)ことで、レンダリング時に選択可能なフォントを確保します。