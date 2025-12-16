---
title: Android でのプレゼンテーションにおけるフォント置換の効率化
linktitle: フォント置換
type: docs
weight: 60
url: /ja/androidjava/font-replacement/
keywords:
- フォント
- フォント置換
- フォント置換
- フォント変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides のフォントをシームレスに置換し、PowerPoint および OpenDocument のプレゼンテーションで一貫したタイポグラフィを実現します。"
---

## **フォントの置換**

フォントの使用をやめたい場合は、別のフォントに置き換えることができます。古いフォントのすべてのインスタンスが新しいフォントに置き換えられます。

Aspose.Slides では、次の手順でフォントを置換できます：

1. 対象のプレゼンテーションを読み込みます。  
2. 置換対象のフォントを読み込みます。  
3. 新しいフォントを読み込みます。  
4. フォントを置換します。  
5. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードはフォント置換を示しています：
```java
// プレゼンテーションを読み込む
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 置換対象の元フォントを読み込む
    IFontData sourceFont = new FontData("Arial");
    
    // 新しいフォントを読み込む
    IFontData destFont = new FontData("Times New Roman");
    
    // フォントを置換する
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // プレゼンテーションを保存する
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Note" color="warning" %}} 
フォントにアクセスできない等、特定の条件下での挙動を決めるルールを設定するには、[**フォント代替**](/slides/ja/androidjava/font-substitution/)をご参照ください。 
{{% /alert %}}

## **よくある質問**

**「フォント置換」「フォント代替」「フォールバックフォント」は何が違うのですか？**  

置換は、ドキュメント全体でフォントファミリーを意図的に別のものに切り替えることです。[代替](/slides/ja/androidjava/font-substitution/) は「フォントが利用できない場合は X を使用する」といったルールです。[フォールバック](/slides/ja/androidjava/fallback-font/) は、ベースフォントがインストールされているが必要な文字が含まれていない場合に、個々の欠損グリフに対して外科的に適用されます。  

**置換はマスタースライド、レイアウト、ノート、コメントにも適用されますか？**  

はい。置換は元のフォントを使用しているすべてのプレゼンテーションオブジェクトに影響し、マスタースライドやノートも含まれます。コメントも文書の一部であり、フォントエンジンによって考慮されます。  

**埋め込み OLE オブジェクト（例：Excel）内のフォントは変更されますか？**  

いいえ。[OLE コンテンツ](/slides/ja/androidjava/manage-ole/) はそれぞれのアプリケーションで管理されます。プレゼンテーション内での置換は内部 OLE データの形式を変更せず、画像として表示されるか、外部で編集可能なコンテンツとして扱われます。  

**プレゼンテーションの一部（スライドや領域）だけでフォントを置換できますか？**  

対象となるオブジェクトや範囲のレベルでフォントを変更すれば、部分的な置換が可能です。全文書に対してグローバルに置換するのではなく、必要なスライドや領域だけに適用できます。レンダリング時の全体的なフォント選択ロジックは変わりません。  

**プレゼンテーションで使用されているフォントを事前に把握するにはどうすればよいですか？**  

プレゼンテーションの[フォントマネージャー](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/) を使用します。これにより[使用中のファミリー](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getFonts--) と[代替/「不明」フォント](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--) の情報が取得でき、置換計画を立てやすくなります。  

**PDF/画像への変換時にフォント置換は機能しますか？**  

はい。エクスポート時に Aspose.Slides は同じ[フォント選択/代替シーケンス](/slides/ja/androidjava/font-selection-sequence/) を適用するため、事前に行った置換は変換時にも尊重されます。  

**ターゲットフォントをシステムにインストールする必要がありますか、あるいはフォントフォルダーを添付できますか？**  

インストールは不要です。ライブラリはユーザーフォルダーから[外部フォントの読み込み](/slides/ja/androidjava/custom-font/) をサポートしており、[レンダリングとエクスポート](/slides/ja/androidjava/convert-powerpoint/) 時に使用できます。  

**置換で「豆腐」(四角) の文字化けは解消されますか？**  

対象フォントに必要なグリフが実際に含まれている場合にのみ有効です。含まれていない場合は、[フォールバックの設定](/slides/ja/androidjava/fallback-font/) を行って欠損文字をカバーしてください。