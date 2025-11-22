---
title: フォント置き換え - PowerPoint JavaScript API
linktitle: フォント置き換え
type: docs
weight: 60
url: /ja/nodejs-java/font-replacement/
description: PowerPoint の JavaScript API を使用して、明示的な置き換え方法でフォントを置き換える方法を学びます。
---

## **フォントの置き換え**

フォントの使用をやめたい場合は、別のフォントに置き換えることができます。古いフォントのすべてのインスタンスが新しいフォントに置き換えられます。

Aspose.Slides では、次の手順でフォントを置き換えることができます。

1. 対象のプレゼンテーションをロードします。 
2. 置き換えるフォントをロードします。 
3. 新しいフォントをロードします。 
4. フォントを置き換えます。 
5. 変更済みのプレゼンテーションを書き出して PPTX ファイルに保存します。

この JavaScript コードはフォント置き換えを示しています：
```javascript
// プレゼンテーションを読み込む
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // 置き換える元フォントを読み込む
    var sourceFont = new aspose.slides.FontData("Arial");
    // 新しいフォントを読み込む
    var destFont = new aspose.slides.FontData("Times New Roman");
    // フォントを置き換える
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // プレゼンテーションを保存する
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 
特定の条件（たとえばフォントにアクセスできない場合）で何が起きるかを決定するルールを設定するには、[**フォント置換**](/slides/ja/nodejs-java/font-substitution/) を参照してください。 
{{% /alert %}}

## **FAQ**

**「フォント置き換え」「フォント置換」「フォールバックフォント」の違いは何ですか？**

置き換えは、文書全体でフォントファミリーを意図的に別のものに切り替えることです。[置換](/slides/ja/nodejs-java/font-substitution/) は「フォントが利用できない場合は X を使用する」というようなルールです。[フォールバック](/slides/ja/nodejs-java/fallback-font/) は、ベースフォントはインストールされているが必要な文字が含まれていない場合に、個々の欠損グリフに対して外科的に適用されます。

**置き換えはマスタースライド、レイアウト、ノート、コメントにも適用されますか？**

はい。置き換えは元のフォントを使用するすべてのプレゼンテーションオブジェクトに影響し、マスタースライドやノートも含まれます。コメントも文書の一部であり、フォントエンジンによって考慮されます。

**埋め込み OLE オブジェクト（例: Excel）内のフォントは変更されますか？**

いいえ。[OLE コンテンツ](/slides/ja/nodejs-java/manage-ole/) はそれぞれのアプリケーションで管理されています。プレゼンテーション内での置き換えは内部の OLE データの再フォーマットを行わず、画像として表示されるか、外部で編集可能なコンテンツとして扱われることがあります。

**プレゼンテーションの一部（スライドや領域）だけでフォントを置き換えることはできますか？**

対象オブジェクトや範囲単位でフォントを変更すれば、ドキュメント全体に対してグローバルに置き換えるのではなく、特定の部分だけで置き換えることが可能です。レンダリング時の全体的なフォント選択ロジックは変わりません。

**プレゼンテーションで使用されているフォントを事前に確認するにはどうすればよいですか？**

プレゼンテーションの[フォントマネージャー](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) を使用します。これにより、使用中の[フォントファミリー](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/) の一覧や、[置換/「不明」フォント](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) に関する情報が取得でき、置き換えの計画に役立ちます。

**PDF/画像へ変換する際にフォント置き換えは機能しますか？**

はい。エクスポート時に Aspose.Slides は同じ[フォント選択/置換シーケンス](/slides/ja/nodejs-java/font-selection-sequence/) を適用するため、事前に行った置き換えは変換時にも尊重されます。

**ターゲットフォントをシステムにインストールする必要がありますか？それともフォントフォルダーを添付できますか？**

インストールは不要です。ライブラリはユーザーフォルダーから[外部フォントのロード](/slides/ja/nodejs-java/custom-font/) を許可し、[レンダリングおよびエクスポート](/slides/ja/nodejs-java/convert-powerpoint/) 時に使用できます。

**置き換えで文字の代わりに表示される「豆腐」（四角）を解消できますか？**

ターゲットフォントに必要なグリフが実際に含まれている場合に限り解消できます。含まれていない場合は、[フォールバックを構成](/slides/ja/nodejs-java/fallback-font/)して欠損文字をカバーしてください。