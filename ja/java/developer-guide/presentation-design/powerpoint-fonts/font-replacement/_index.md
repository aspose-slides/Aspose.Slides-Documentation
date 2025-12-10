---
title: Javaを使用したプレゼンテーションのフォント置換を効率化
linktitle: フォント置換
type: docs
weight: 60
url: /ja/java/font-replacement/
keywords:
- フォント
- フォント置換
- フォント置換
- フォント変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でフォントをシームレスに置換し、PowerPoint および OpenDocument プレゼンテーションのタイポグラフィを一貫させます。"
---

## **フォントの置換**

フォントの使用をやめたい場合、別のフォントに置き換えることができます。古いフォントのすべてのインスタンスが新しいフォントに置き換えられます。

Aspose.Slides では、次の手順でフォントを置換できます：

1. 対象のプレゼンテーションを読み込みます。  
2. 置換対象のフォントを読み込みます。  
3. 新しいフォントを読み込みます。  
4. フォントを置換します。  
5. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードはフォント置換を示しています：
```java
// プレゼンテーションを読み込みます
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 置換対象となる元フォントを読み込みます
    IFontData sourceFont = new FontData("Arial");
    
    // 新しいフォントを読み込みます
    IFontData destFont = new FontData("Times New Roman");
    
    // フォントを置換します
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // プレゼンテーションを保存します
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

特定の条件（例: フォントにアクセスできない場合）で何が起こるかを決定するルールを設定するには、[**Font Substitution**](/slides/ja/java/font-substitution/) を参照してください。 

{{% /alert %}}

## **FAQ**

**「フォントの置換」「フォントの代替」「フォールバックフォント」の違いは何ですか？**

置換は、文書全体であるフォントファミリーから別のフォントファミリーへ意図的に切り替えることです。[Substitution](/slides/ja/java/font-substitution/) は「フォントが利用できない場合は X を使用する」といったルールです。[Fallback](/slides/ja/java/fallback-font/) は、ベースフォントはインストールされているものの必要な文字が含まれていない個々の欠損グリフに対して個別に適用されます。

**置換はマスタースライド、レイアウト、ノート、コメントにも適用されますか？**

はい。置換は元のフォントを使用しているすべてのプレゼンテーションオブジェクトに影響し、マスタースライドやノートも含まれます。コメントも文書の一部であり、フォントエンジンで考慮されます。

**埋め込み OLE オブジェクト（例: Excel）内のフォントは変更されますか？**

いいえ。[OLE content](/slides/ja/java/manage-ole/) はそれぞれのアプリケーションで管理されています。プレゼンテーション内での置換は内部の OLE データを再フォーマットせず、画像として表示されたり外部で編集可能なコンテンツとして扱われることがあります。

**プレゼンテーションの一部（スライドや領域）だけでフォントを置換できますか？**

対象となるオブジェクトや範囲のレベルでフォントを変更すれば、特定のスライドや領域だけで置換することが可能です。ドキュメント全体に対してグローバルに置換を適用するのではありません。レンダリング時のフォント選択ロジック全体は変わりません。

**プレゼンテーションが使用しているフォントを事前に把握するにはどうすればよいですか？**

プレゼンテーションの [font manager](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/) を使用します。これにより、使用中の [families in use](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getFonts--) のリストや、[substitutions/"unknown" fonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getSubstitutions--) に関する情報が取得でき、置換計画に役立ちます。

**PDF/画像への変換時にもフォント置換は機能しますか？**

はい。エクスポート時に Aspose.Slides は同じ [font selection/substitution sequence](/slides/ja/java/font-selection-sequence/) を適用するため、事前に行った置換は変換時にも反映されます。

**対象フォントをシステムにインストールする必要がありますか？それともフォントフォルダーを添付できますか？**

インストールは不要です。ライブラリはユーザーフォルダーからの [loading external fonts](/slides/ja/java/custom-font/) をサポートしており、[rendering and export](/slides/ja/java/convert-powerpoint/) 時に使用できます。

**置換で文字の代わりに「豆腐」（四角）が表示される問題は解決しますか？**

対象フォントに必要なグリフが実際に含まれている場合に限り解決します。含まれていない場合は、欠損文字を補うために [configure fallback](/slides/ja/java/fallback-font/) を設定してください。