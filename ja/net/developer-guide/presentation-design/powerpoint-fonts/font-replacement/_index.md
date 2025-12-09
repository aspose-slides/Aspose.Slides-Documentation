---
title: .NET でプレゼンテーションのフォント置換を効率化
linktitle: フォント置換
type: docs
weight: 60
url: /ja/net/font-replacement/
keywords:
- フォント
- フォント置換
- フォント置換
- フォント変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でフォントをシームレスに置換し、PowerPoint および OpenDocument プレゼンテーションのタイポグラフィを一貫させます。"
---

## **フォントの置換**

フォントの使用をやめたくなった場合、別のフォントに置き換えることができます。古いフォントのすべてのインスタンスが新しいフォントに置き換えられます。

Aspose.Slides では、次の手順でフォントを置換できます:

1. 対象のプレゼンテーションを読み込む。  
2. 置換対象のフォントを読み込む。  
3. 新しいフォントを読み込む。  
4. フォントを置換する。  
5. 変更したプレゼンテーションを PPTX ファイルとして書き出す。

この C# コードはフォント置換を示しています:
```c#
// プレゼンテーションをロードします
Presentation presentation = new Presentation("Fonts.pptx");

// 置換される元フォントをロードします
IFontData sourceFont = new FontData("Arial");

// 新しいフォントをロードします
IFontData destFont = new FontData("Times New Roman");

// フォントを置き換えます
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// プレゼンテーションを保存します
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```


{{% alert title="Note" color="warning" %}} 
特定の条件下での挙動（たとえばフォントにアクセスできない場合）を決定するルールを設定するには、[**Font Substitution**](/slides/ja/net/font-substitution/) を参照してください。 
{{% /alert %}}

## **FAQ**

**「フォント置換」「font substitution」「fallback fonts」の違いは何ですか？**

置換は、文書全体でフォントファミリを意図的に別のものに切り替えることです。[Substitution](/slides/ja/net/font-substitution/) は「フォントが利用できない場合は X を使用する」というようなルールです。[Fallback](/slides/ja/net/fallback-font/) は、ベースフォントがインストールされているが必要な文字が含まれていない場合に、個々の欠損グリフに対して外科的に適用されます。

**置換はマスタースライド、レイアウト、ノート、コメントにも適用されますか？**

はい。置換はオリジナルフォントを使用しているすべてのプレゼンテーションオブジェクトに影響し、マスタースライドやノートも含まれます。コメントも文書の一部であり、フォントエンジンによって考慮されます。

**埋め込み OLE オブジェクト（例: Excel）内のフォントは変更されますか？**

いいえ。[OLE content](/slides/ja/net/manage-ole/) はそれぞれのアプリケーションで管理されます。プレゼンテーションでの置換は内部の OLE データの再フォーマットを行わず、画像として表示されたり、外部で編集可能なコンテンツとして扱われることがあります。

**プレゼンテーションの一部（スライドや領域）だけでフォントを置換できますか？**

対象オブジェクトや範囲レベルでフォントを変更すれば、グローバルに文書全体へ置換を適用するのではなく、部分的な置換が可能です。レンダリング時の全体的なフォント選択ロジックは変わりません。

**プレゼンテーションで使用されているフォントを事前に把握するにはどうすればよいですか？**

プレゼンテーションの [font manager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/) を使用します。使用中のフォントファミリの一覧は [families in use](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) で取得でき、[substitutions/"unknown" fonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) に関する情報も得られるため、置換計画の立案に役立ちます。

**PDF/画像に変換する際にフォント置換は機能しますか？**

はい。エクスポート時に Aspose.Slides は同じ [font selection/substitution sequence](/slides/ja/net/font-selection-sequence/) を適用するため、事前に実施した置換は変換時に反映されます。

**対象フォントをシステムにインストールする必要がありますか、それともフォントフォルダーを添付できますか？**

インストールは不要です。ライブラリはユーザーフォルダーから [loading external fonts](/slides/ja/net/custom-font/) を読み込むことをサポートしており、[rendering and export](/slides/ja/net/convert-powerpoint/) 時に使用できます。

**置換で文字が「豆腐」(四角)になる問題は解消されますか？**

対象フォントに必要なグリフが実際に含まれている場合のみ解消します。含まれていない場合は、欠損文字をカバーするために [configure fallback](/slides/ja/net/fallback-font/) を設定してください。