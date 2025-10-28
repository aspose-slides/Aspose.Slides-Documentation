---
title: Python を使用したプレゼンテーションのフォント置換の効率化
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
description: ".NET 経由の Aspose.Slides Python でフォントをシームレスに置換し、PowerPoint および OpenDocument プレゼンテーションのタイポグラフィを一貫させます。"
---

## **フォントの置換**

フォントの使用をやめる場合は、別のフォントに置換できます。古いフォントのすべてのインスタンスが新しいフォントに置き換えられます。

Aspose.Slides では、次の手順でフォントを置換できます。

1. 対象のプレゼンテーションを読み込む。  
2. 置換対象のフォントを読み込む。  
3. 新しいフォントを読み込む。  
4. フォントを置換する。  
5. 変更後のプレゼンテーションを PPTX ファイルとして保存する。

この Python コードはフォント置換を示しています。

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Loads a presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Loads the source font that will be replaced
    sourceFont = slides.FontData("Arial")

    # Loads the new font
    destFont = slides.FontData("Times New Roman")

    # Replaces the fonts
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Saves the presentation
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注" color="warning" %}} 
特定の条件下での動作を決定するルール（たとえばフォントにアクセスできない場合）を設定するには、[**フォントの代替**](/slides/ja/python-net/font-substitution/) を参照してください。 
{{% /alert %}}

## **よくある質問**

**「フォント置換」「フォント代替」「フォールバックフォント」の違いは何ですか？**

置換は文書全体でフォントファミリを意図的に別のものに切り替えることです。[代替](/slides/ja/python-net/font-substitution/) は「フォントが利用できない場合は X を使用する」といったルールです。[フォールバック](/slides/ja/python-net/fallback-font/) は、ベースフォントはインストールされているが必要な文字が含まれていない個々の欠落グリフに対して外科的に適用されます。

**置換はマスタースライド、レイアウト、ノート、コメントにも適用されますか？**

はい。置換は元のフォントを使用しているすべてのプレゼンテーションオブジェクトに影響し、マスタースライドやノートも含まれます。コメントも文書の一部であり、フォントエンジンの対象となります。

**埋め込み OLE オブジェクト（たとえば Excel）内のフォントは変更されますか？**

いいえ。[OLE コンテンツ](/slides/ja/python-net/manage-ole/) はそれぞれのアプリケーションで管理されます。プレゼンテーション内での置換は内部の OLE データを再フォーマットしません。表示は画像として、または外部で編集可能なコンテンツとして扱われる場合があります。

**プレゼンテーションの一部（スライドや領域）だけでフォントを置換できますか？**

対象オブジェクトや範囲レベルでフォントを変更すれば、ドキュメント全体に対するグローバル置換ではなく、限定的な置換が可能です。レンダリング時の全体的なフォント選択ロジックは変わりません。

**プレゼンテーションが使用しているフォントを事前にすべて把握するにはどうすればよいですか？**

プレゼンテーションの[フォントマネージャ]（https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/）を使用します。使用中の[フォントファミリ一覧]（https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/）や[代替/「不明」フォント情報]（https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/）が取得でき、置換計画に役立ちます。

**PDF/画像に変換する際にフォント置換は機能しますか？**

はい。エクスポート時に Aspose.Slides は同じ[フォント選択・代替シーケンス](/slides/ja/python-net/font-selection-sequence/) を適用するため、事前に行った置換は変換時に尊重されます。

**対象フォントをシステムにインストールする必要がありますか？フォントフォルダーを添付できますか？**

インストールは必須ではありません。ライブラリは[外部フォントの読み込み](/slides/ja/python-net/custom-font/) をサポートしており、ユーザーフォルダーからフォントを読み込んで[レンダリングおよびエクスポート](/slides/ja/python-net/convert-powerpoint/) に使用できます。

**置換で「豆腐」文字（四角形）が解消されますか？**

対象フォントに必要なグリフが実際に含まれている場合にのみ解消されます。含まれていない場合は、[フォールバックの設定](/slides/ja/python-net/fallback-font/) を行い、欠損文字をカバーしてください。