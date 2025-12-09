---
title: Python でプレゼンテーションのフォント置換を設定
linktitle: フォント置換
type: docs
weight: 70
url: /ja/python-net/font-substitution/
keywords:
- フォント
- 代替フォント
- フォント置換
- フォントの置換
- フォント置換
- 置換規則
- 置換規則
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "PowerPoint および OpenDocument のプレゼンテーションを他のファイル形式に変換する際、.NET を介した Python 用 Aspose.Slides で最適なフォント置換を有効にします。"
---

## **置換規則の設定**

Aspose.Slides では、フォントに対する規則を設定でき、特定の条件（例: フォントにアクセスできない場合）で何をすべきかを決定します。

1. 対象のプレゼンテーションを読み込みます。
2. 置換対象となるフォントを読み込みます。
3. 新しいフォントを読み込みます。
4. 置換の規則を追加します。
5. その規則をプレゼンテーションのフォント置換規則コレクションに追加します。
6. スライド画像を生成して効果を確認します。

この Python コードはフォント置換プロセスを示しています:
```python
import aspose.slides as slides

# プレゼンテーションを読み込みます
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 置換される元のフォントを読み込みます
    sourceFont = slides.FontData("SomeRareFont")

    # 新しいフォントを読み込みます
    destFont = slides.FontData("Arial")

    # フォント置換の規則を追加します
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # 規則をフォント置換規則コレクションに追加します
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # フォント規則コレクションを規則リストに追加します
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial フォントは、SomeRareFont が利用できない場合に代わりに使用されます
    with presentation.slides[0].get_image(1, 1) as bmp:
        # JPEG 形式で画像をディスクに保存します
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```


{{%  alert title="NOTE"  color="warning"   %}} 
フォント置換に関する詳細は[**Font Replacement**](/slides/ja/python-net/font-replacement/)をご覧ください。 
{{% /alert %}}

## **FAQ**

**フォント置換とフォント置換（サブスティテューション）の違いは何ですか？**

[Replacement](/slides/ja/python-net/font-replacement/) は、プレゼンテーション全体であるフォントを別のフォントに強制的に上書きするものです。サブスティテューションは、特定の条件（例: 元のフォントが利用できない場合）でトリガーされ、指定された代替フォントが使用される規則です。

**置換規則は正確にいつ適用されますか？**

規則は標準の[font selection](/slides/ja/python-net/font-selection-sequence/) シーケンスに参加し、読み込み、レンダリング、変換の際に評価されます。選択されたフォントが利用できない場合、置換またはサブスティテューションが適用されます。

**置換もサブスティテューションも設定されておらず、システムにフォントが存在しない場合の既定の動作は？**

ライブラリは PowerPoint と同様に、最も近い利用可能なシステムフォントを自動的に選択しようとします。

**実行時にカスタム外部フォントを追加してサブスティテューションを回避できますか？**

はい。実行時に[add external fonts](/slides/ja/python-net/custom-font/) を追加すれば、ライブラリはそれらを選択とレンダリングの対象に含め、以降の変換でも使用できます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。Aspose は有料・無料を問わずフォントを配布していません。フォントはご自身の判断と責任で追加・使用してください。

**Windows、Linux、macOS でサブスティテューションの動作に違いはありますか？**

あります。フォントの検出は OS のフォントディレクトリから開始されます。デフォルトで利用可能なフォントセットや検索パスはプラットフォームごとに異なり、利用可能性とサブスティテューションの必要性に影響します。

**バッチ変換時に予期せぬサブスティテューションを最小限に抑えるための環境設定は？**

マシンまたはコンテナ間でフォントセットを同期し、出力ドキュメントに必要な[add the external fonts](/slides/ja/python-net/custom-font/) を追加し、可能な限りプレゼンテーションに[embed fonts](/slides/ja/python-net/embedded-font/) を埋め込んで、レンダリング時にフォントが利用できるようにします。