---
title: フォント置き換え - PowerPoint C# API
linktitle: フォント置き換え
type: docs
weight: 60
url: /ja/net/font-replacement/
keywords: "フォント, フォント置き換え, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: C# の PowerPoint API を使用すると、プレゼンテーション内でフォントを別のフォントに明示的に置き換えることができます。
---

## **フォントの置き換え**

フォントの使用をやめることにした場合、別のフォントに置き換えることができます。古いフォントのすべてのインスタンスが新しいフォントに置き換えられます。

Aspose.Slides では、次の手順でフォントを置き換えることができます：

1. 対象のプレゼンテーションをロードします。  
2. 置き換えるフォントをロードします。  
3. 新しいフォントをロードします。  
4. フォントを置き換えます。  
5. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

この C# コードはフォント置き換えを示しています：
```c#
// プレゼンテーションをロードします
Presentation presentation = new Presentation("Fonts.pptx");

// 置き換える元フォントをロードします
IFontData sourceFont = new FontData("Arial");

// 新しいフォントをロードします
IFontData destFont = new FontData("Times New Roman");

// フォントを置き換えます
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// プレゼンテーションを保存します
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```


{{% alert title="Note" color="warning" %}} 
特定の条件（たとえばフォントにアクセスできない場合）で何が起こるかを決定するルールを設定するには、[**フォント置換**](/slides/ja/net/font-substitution/)をご覧ください。 
{{% /alert %}}

## **FAQ**

**「フォント置き換え」「フォント置換」「フォールバックフォント」の違いは何ですか？**

置き換えは、文書全体でフォントファミリーを意図的に別のものに切り替えることです。[置換](/slides/ja/net/font-substitution/)は「フォントが利用できない場合は X を使用する」といったルールです。[フォールバック](/slides/ja/net/fallback-font/)は、ベースフォントがインストールされているものの必要な文字が含まれていない場合に、個々の欠落した文字に対して外科的に適用されます。

**置き換えはマスタースライド、レイアウト、ノート、コメントにも適用されますか？**

はい。置き換えは元のフォントを使用しているすべてのプレゼンテーションオブジェクトに影響し、マスタースライドやノートも含まれます。コメントも文書の一部であり、フォントエンジンが考慮します。

**埋め込み OLE オブジェクト（例: Excel）内のフォントは変更されますか？**

いいえ。[OLE コンテンツ](/slides/ja/net/manage-ole/)はそれぞれのアプリケーションで管理されます。プレゼンテーション内での置き換えは内部の OLE データを再フォーマットしません。画像として表示されるか、外部で編集可能なコンテンツとして扱われることがあります。

**プレゼンテーションの一部（スライドや領域）だけでフォントを置き換えることはできますか？**

対象となるオブジェクトや範囲単位でフォントを変更すれば、ドキュメント全体に対してグローバルに置き換えるのではなく、部分的な置き換えが可能です。レンダリング時の全体的なフォント選択ロジックは変わりません。

**プレゼンテーションが使用しているフォントを事前に確認するにはどうすればよいですか？**

プレゼンテーションの[フォントマネージャー](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/)を使用します。これにより、使用中の[フォントファミリー](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/)の一覧や、[置換/「不明」フォント](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/)に関する情報が取得でき、置き換えの計画に役立ちます。

**PDF/画像への変換時にフォント置き換えは機能しますか？**

はい。エクスポート時に Aspose.Slides は同じ[フォント選択/置換シーケンス](/slides/ja/net/font-selection-sequence/)を適用するため、事前に行った置き換えは変換時に尊重されます。

**対象フォントをシステムにインストールする必要がありますか、それともフォントフォルダーを添付できますか？**

インストールは不要です。ライブラリは、ユーザーフォルダーから[外部フォントのロード](/slides/ja/net/custom-font/)をサポートしており、[レンダリングおよびエクスポート](/slides/ja/net/convert-powerpoint/)時に使用できます。

**置き換えで「豆腐」(四角) が文字の代わりに表示される問題は解消されますか？**

対象フォントに必要なグリフが実際に含まれている場合に限り、置き換えで解消できます。含まれていない場合は、欠落文字を補うために[フォールバックを設定](/slides/ja/net/fallback-font/)してください。