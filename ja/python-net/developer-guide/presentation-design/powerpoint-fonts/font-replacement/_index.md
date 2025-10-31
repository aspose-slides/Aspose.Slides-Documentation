---
title: Python を使用したプレゼンテーションのフォント置換を効率化
linktitle: フォント置換
type: docs
weight: 60
url: /ja/python-net/font-replacement/
keywords:
- フォント
- フォント置換
- フォント置換
- フォント変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides Python (.NET) でフォントをシームレスに置換し、PowerPoint および OpenDocument のプレゼンテーションで一貫したタイポグラフィを実現します。"
---

## **フォントの置換**

フォントの使用をやめたくなった場合、別のフォントに置換できます。元のフォントのすべてのインスタンスが新しいフォントに置き換えられます。  

Aspose.Slides は次の手順でフォントを置換できます。

1. 対象のプレゼンテーションを読み込みます。  
2. 置換対象のフォントを読み込みます。  
3. 新しいフォントを読み込みます。  
4. フォントを置換します。  
5. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この Python コードはフォント置換の例です。

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# プレゼンテーションを読み込みます
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 置換対象となるソースフォントを読み込みます
    sourceFont = slides.FontData("Arial")

    # 新しいフォントを読み込みます
    destFont = slides.FontData("Times New Roman")

    # フォントを置換します
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # プレゼンテーションを保存します
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}} 
特定の状況（例: フォントにアクセスできない場合）での動作を決定するルールを設定するには、[**フォント置換**](/slides/ja/python-net/font-substitution/) を参照してください。 
{{% /alert %}}

## **よくある質問**

**「フォント置換」「フォント代替」「フォールバックフォント」の違いは何ですか？**

置換は文書全体でフォントファミリを意図的に別のものに切り替えることです。[代替](/slides/ja/python-net/font-substitution/) は「フォントが利用できない場合は X を使用する」などのルールです。[フォールバック](/slides/ja/python-net/fallback-font/) は、基本フォントはインストールされているものの必要な文字が欠けている場合に、個別の欠損グリフに対して適用されます。

**置換はマスタースライド、レイアウト、ノート、コメントにも適用されますか？**

はい。置換は元のフォントを使用しているすべてのプレゼンテーションオブジェクトに影響し、マスタースライドやノートも含まれます。コメントも文書の一部であり、フォントエンジンが考慮します。

**埋め込み OLE オブジェクト（例: Excel）内のフォントは変更されますか？**

いいえ。[OLE コンテンツ](/slides/ja/python-net/manage-ole/) はそれぞれのアプリケーションで管理されます。プレゼンテーションでの置換は内部の OLE データを再フォーマットしません; 画像として表示されるか、外部で編集可能なコンテンツとして表示されます。

**プレゼンテーションの一部（スライドや領域）だけでフォントを置換できますか？**

対象スライドや領域単位でフォントを変更すれば、部分的な置換が可能です。文書全体に対してグローバルに置換するのではなく、必要なオブジェクト/範囲レベルでフォントを変更します。レンダリング時の全体的なフォント選択ロジックは変わりません。

**プレゼンテーションが使用しているすべてのフォントを事前に確認するには？**

プレゼンテーションの[フォントマネージャー](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) を使用します: 使用中の[フォントファミリ]（https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/）のリストと、[代替/「不明」フォント]（https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/）に関する情報が取得でき、置換計画に役立ちます。

**PDF/画像への変換時にフォント置換は機能しますか？**

はい。エクスポート時、Aspose.Slides は同じ[フォント選択/代替シーケンス](/slides/ja/python-net/font-selection-sequence/) を適用するため、事前に行った置換は変換時に尊重されます。

**システムに対象フォントをインストールする必要がありますか、あるいはフォントフォルダーを添付できますか？**

インストールは不要です: ライブラリは[外部フォントの読み込み](/slides/ja/python-net/custom-font/) をサポートし、ユーザーフォルダーからのフォントを[レンダリングとエクスポート](/slides/ja/python-net/convert-powerpoint/) 時に使用できます。

**置換で「豆腐」(四角) の文字化けは解消されますか？**

対象フォントに必要なグリフが実際に含まれている場合にのみ置換で解決します。含まれていない場合は、[フォールバック](/slides/ja/python-net/fallback-font/) を設定して不足文字をカバーしてください。