---
title: Python（Java経由）でプレゼンテーションのフォント置き換えを効率化
linktitle: フォント置き換え
type: docs
weight: 60
url: /ja/python-java/font-replacement/
keywords:
- フォント
- フォント置き換え
- フォント置き換え
- フォント変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python（Java経由）用の Aspose.Slides でフォントをシームレスに置き換え、PowerPoint および OpenDocument プレゼンテーションのタイポグラフィを一貫させます。"
---
## **概要**

Aspose.Slides を使用すると、プレゼンテーション全体であるフォントを別のフォントに置き換えることができます。フォントが置き換えられると、元のフォントのすべてのインスタンスが新しいフォントに変更されます。

フォントの置き換えを実行するには、プレゼンテーションを読み込み、元のフォントと置き換えるフォントを定義し、フォント置き換えメソッドを呼び出して、変更されたプレゼンテーションを PPTX ファイルとして保存します。この方法は、プレゼンテーション全体で意図的にフォントファミリを別のものに切り替えたい場合に便利です。

## **フォントの置き換え**

フォントの使用をやめたいと思ったら、そのフォントを別のフォントに置き換えることができます。古いフォントのすべてのインスタンスが新しいフォントに置き換えられます。

Aspose.Slides では、フォントを次の手順で置き換えることができます。

1. 対象のプレゼンテーションをロードします。 
2. 置き換えるフォントをロードします。 
3. 新しいフォントをロードします。 
4. フォントを置き換えます。 
5. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

この Python コードはフォント置き換えを示しています:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# プレゼンテーションを読み込む。
presentation = Presentation("Fonts.pptx")
try:
    # 置き換える元のフォントを読み込む。
    source_font = FontData("Arial")

    # 新しいフォントを読み込む。
    destination_font = FontData("Times New Roman")

    # フォントを置き換える。
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # プレゼンテーションを保存する。
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}} 
特定の条件（たとえばフォントにアクセスできない場合）で何が起こるかを決定するルールを設定するには、[Font Substitution](/slides/ja/python-java/font-substitution/) を参照してください。 
{{% /alert %}}

## **よくある質問**

**「フォント置き換え」「フォント代替」「フォールバックフォント」は何が違いますか？**

置き換えは、文書全体でフォントファミリを意図的に別のものに切り替えることです。[代替](/slides/ja/python-java/font-substitution/) は「フォントが利用できない場合は X を使用する」というルールです。[フォールバック](/slides/ja/python-java/fallback-font/) は、ベースフォントがインストールされているが必要な文字が含まれていない場合に、個々の欠損グリフに対して適用されます。

**置き換えはマスタースライド、レイアウト、ノート、コメントにも適用されますか？**

はい。置き換えは元のフォントを使用しているすべてのプレゼンテーションオブジェクトに影響し、マスタースライドやノートも含まれます。コメントも文書の一部であり、フォントエンジンが考慮します。

**埋め込み OLE オブジェクト（例: Excel）内のフォントは変更されますか？**

いいえ。[OLE コンテンツ](/slides/ja/python-java/manage-ole/) はそれぞれのアプリケーションで管理されます。プレゼンテーション内での置き換えは内部 OLE データの書式を変更せず、画像として表示されるか外部で編集可能なコンテンツとして扱われます。

**プレゼンテーションの一部（スライドや領域）だけでフォントを置き換えることはできますか？**

対象オブジェクト・範囲レベルでフォントを変更すれば、文書全体に対するグローバル置き換えではなく、限定的な置き換えが可能です。レンダリング時の全体的なフォント選択ロジックは変わりません。

**事前にプレゼンテーションで使用されているフォントを把握するにはどうすればよいですか？**

プレゼンテーションの[フォントマネージャー]（https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/）を使用します。これにより、[使用中のファミリ]（https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getFonts）と[代替／「不明」フォント]（https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getSubstitutions）の一覧と情報が取得でき、置き換え計画に役立ちます。

**PDF／画像への変換時にもフォント置き換えは機能しますか？**

はい。エクスポート時に Aspose.Slides は同じ[フォント選択／代替シーケンス](/slides/ja/python-java/font-selection-sequence/) を適用するため、事前に行った置き換えは変換時にも尊重されます。

**対象フォントをシステムにインストールする必要がありますか、それともフォントフォルダーを添付できますか？**

インストールは不要です。ライブラリは[外部フォントの読み込み](/slides/ja/python-java/custom-font/) をサポートしており、ユーザーフォルダーからフォントを読み込んで[レンダリングおよびエクスポート](/slides/ja/python-java/convert-powerpoint/) に使用できます。

**置き換えで「豆腐」文字（四角）を解消できますか？**

置き換えるフォントが実際に必要なグリフを含んでいる場合のみ解消できます。含まれていない場合は、[フォールバックの設定](/slides/ja/python-java/fallback-font/) を行って欠損文字をカバーしてください。