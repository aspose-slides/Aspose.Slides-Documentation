---
title: "Pythonでプレゼンテーションのフォント置換を設定する"
linktitle: "フォント置換"
type: docs
weight: 70
url: /ja/python-net/font-substitution/
keywords:
- フォント
- 代替フォント
- フォント置換
- フォント置換
- フォント置換
- 置換ルール
- 置換規則
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "PowerPointやOpenDocumentプレゼンテーションを他のファイル形式に変換する際、Aspose.Slides for Python via .NETで最適なフォント置換を有効にします。"
---

## **置換ルールの設定**

Aspose.Slides では、特定の条件（例: フォントにアクセスできない場合）で実行すべき処理を決定するフォント用ルールを設定できます。

1. 対象のプレゼンテーションを読み込みます。
2. 置換対象のフォントを読み込みます。
3. 新しいフォントを読み込みます。
4. 置換のルールを追加します。
5. プレゼンテーションのフォント置換ルールコレクションにルールを追加します。
6. スライドの画像を生成し、効果を確認します。

この Python コードはフォント置換プロセスを示しています：

```python
import aspose.slides as slides

# プレゼンテーションを読み込みます
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 置換対象となる元フォントを読み込みます
    sourceFont = slides.FontData("SomeRareFont")

    # 新しいフォントを読み込みます
    destFont = slides.FontData("Arial")

    # フォント置換のルールを追加します
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # ルールをフォント置換ルールコレクションに追加します
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # フォントルールコレクションをルールリストに設定します
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial フォントは SomeRareFont がアクセス不可の場合に置き換えて使用されます
    with presentation.slides[0].get_image(1, 1) as bmp:
        # JPEG 形式で画像をディスクに保存します
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{% alert title="注意" color="warning" %}} 

次のページをご覧になるとよいでしょう [**フォント置換**](/slides/ja/python-net/font-replacement/)。 

{{% /alert %}}

## **よくある質問**

**フォント置換とフォント置換（サブスティテューション）の違いは何ですか？**

[置換](/slides/ja/python-net/font-replacement/) は、プレゼンテーション全体であるフォントを別のフォントに強制的に置き換えることです。置換（サブスティテューション）は、特定の条件（例: 元のフォントが利用できない場合）で発動するルールで、指定した代替フォントが使用されます。

**置換ルールは正確にいつ適用されますか？**

これらのルールは、読み込み、レンダリング、変換時に評価される標準的な [フォント選択](/slides/ja/python-net/font-selection-sequence/) シーケンスに組み込まれます。選択されたフォントが利用できない場合、置換またはサブスティテューションが適用されます。

**置換もサブスティテューションも設定されておらず、システムにフォントが存在しない場合のデフォルト動作は何ですか？**

ライブラリは、PowerPoint と同様に、利用可能なシステムフォントの中で最も近いものを自動的に選択しようとします。

**ランタイムでカスタム外部フォントを添付して置換を回避できますか？**

はい。ランタイム時に [外部フォントを追加](/slides/ja/python-net/custom-font/) すれば、ライブラリはそれらをフォント選択やレンダリング時に考慮し、以降の変換でも使用できます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。Aspose は有料・無料を問わずフォントを配布していません。フォントはご自身で追加・使用する必要があり、自己の裁量と責任で管理してください。

**Windows、Linux、macOS でのサブスティテューションの動作に違いはありますか？**

あります。フォントの検出は OS のフォントディレクトリから開始されます。プラットフォームごとにデフォルトで利用可能なフォントや検索パスが異なるため、利用可能性やサブスティテューションの必要性に影響します。

**バッチ変換時に予期しないサブスティテューションを最小化するための環境準備はどうすべきですか？**

マシンやコンテナ間でフォントセットを統一し、出力ドキュメントに必要な [外部フォントを追加](/slides/ja/python-net/custom-font/)し、可能であればプレゼンテーションに [フォントを埋め込む](/slides/ja/python-net/embedded-font/)ことで、レンダリング時に必要なフォントが確実に利用できるようにします。