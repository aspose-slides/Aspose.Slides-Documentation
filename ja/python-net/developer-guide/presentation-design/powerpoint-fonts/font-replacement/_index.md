---
title: Python を使用したプレゼンテーションのフォント置換を効率化
linktitle: フォント置換
type: docs
weight: 60
url: /ja/python-net/font-replacement/
keywords:
- フォント
- フォントの置き換え
- フォント置換
- フォント変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides Python を .NET 経由でシームレスにフォント置換し、PowerPoint および OpenDocument プレゼンテーションで一貫したタイポグラフィを確保します。"
---

## **フォントの置き換え**

フォントの使用をやめたくなった場合、別のフォントに置き換えることができます。古いフォントのすべてのインスタンスは新しいフォントに置き換えられます。

Aspose.Slidesでは、次の手順でフォントを置き換えることができます。

1. 対象のプレゼンテーションをロードします。  
2. 置き換えるフォントをロードします。  
3. 新しいフォントをロードします。  
4. フォントを置き換えます。  
5. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この Python コードはフォント置き換えを示します:
```py
import aspose.pydrawing as draw
import aspose.slides as slides

# プレゼンテーションを読み込む
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 置き換える元フォントを読み込む
    sourceFont = slides.FontData("Arial")

    # 新しいフォントを読み込む
    destFont = slides.FontData("Times New Roman")

    # フォントを置き換える
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # プレゼンテーションを保存する
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Note" color="warning" %}} 

特定の条件下（例: フォントにアクセスできない場合）で何が起こるかを決定するルールを設定するには、[**フォント置換**](/slides/ja/python-net/font-substitution/) を参照してください。 

{{% /alert %}}

## **よくある質問**

**「フォント置き換え」「フォント置換」「フォールバックフォント」の違いは何ですか？**

置き換えは、文書全体でフォントファミリを意図的に別のものに変更することです。[置換](/slides/ja/python-net/font-substitution/) は「フォントが利用できない場合は X を使用する」というルールです。[フォールバック](/slides/ja/python-net/fallback-font/) は、ベースフォントがインストールされているが必要な文字を含まない場合に、個々の欠損グリフに対して外科的に適用されます。

**置き換えはマスタースライド、レイアウト、ノート、コメントにも適用されますか？**

はい。置き換えは元のフォントを使用しているすべてのプレゼンテーションオブジェクトに影響し、マスタースライドやノートを含みます。コメントも文書の一部であり、フォントエンジンによって考慮されます。

**埋め込み OLE オブジェクト（例: Excel）内のフォントは変更されますか？**

いいえ。[OLE コンテンツ](/slides/ja/python-net/manage-ole/) はそれぞれのアプリケーションで管理されています。プレゼンテーション内での置き換えは内部の OLE データを再フォーマットしません。画像として表示されるか、外部で編集可能なコンテンツとして扱われる場合があります。

**プレゼンテーションの一部（スライドや領域）だけでフォントを置き換えることはできますか？**

対象オブジェクト/範囲レベルでフォントを変更すれば、特定のスライドや領域だけに置き換えることが可能です。全体に対してグローバルな置き換えを行うのではなく、必要な部分だけを変更します。レンダリング時のフォント選択ロジック全体は変わりません。

**プレゼンテーションが使用しているフォントを事前にすべて把握するにはどうすればよいですか？**

プレゼンテーションの [フォントマネージャ](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) を使用します。使用中の [フォントファミリ](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) の一覧や、[置換/「不明」フォント](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) に関する情報を取得でき、置き換え計画に役立ちます。

**PDF/画像に変換する際にフォント置き換えは機能しますか？**

はい。エクスポート時に Aspose.Slides は同じ [フォント選択/置換シーケンス](/slides/ja/python-net/font-selection-sequence/) を適用するため、事前に行った置き換えは変換時に反映されます。

**ターゲットフォントをシステムにインストールする必要がありますか？またはフォントフォルダーを添付できますか？**

インストールは不要です。ライブラリはユーザーフォルダーから [外部フォントの読み込み](/slides/ja/python-net/custom-font/) をサポートし、[レンダリングおよびエクスポート](/slides/ja/python-net/convert-powerpoint/) 時に使用できます。

**置き換えは「豆腐」（四角）の代わりに文字を正しく表示させますか？**

対象フォントが実際に必要なグリフを含んでいる場合のみ効果があります。含まれていない場合は、欠損文字をカバーするために [フォールバックの設定](/slides/ja/python-net/fallback-font/) を行ってください。