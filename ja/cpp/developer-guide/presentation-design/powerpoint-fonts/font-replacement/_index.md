---
title: プレゼンテーションでの С++ を使用したフォント置換を効率化
linktitle: フォント置換
type: docs
weight: 60
url: /ja/cpp/font-replacement/
keywords:
- フォント
- フォント置換
- フォント置換
- フォント変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ でフォントをシームレスに置換し、PowerPoint および OpenDocument のプレゼンテーションで一貫したタイポグラフィを保証します。"
---

## **フォントの置換**

フォントの使用をやめたい場合は、別のフォントに置き換えることができます。古いフォントのすべてのインスタンスが新しいフォントに置き換わります。 

Aspose.Slides では、次の手順でフォントを置換できます：

1. 対象のプレゼンテーションを読み込みます。 
2. 置換対象のフォントを読み込みます。 
3. 新しいフォントを読み込みます。 
4. フォントを置換します。 
5. 変更されたプレゼンテーションを書き出して PPTX ファイルにします。

この C++ コードはフォント置換を示しています:
``` cpp
// プレゼンテーションを読み込む
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// 置換対象となる元フォントを読み込む
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// 新しいフォントを読み込む
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// フォントを置換する
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// プレゼンテーションを保存する
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 

特定の条件（たとえばフォントにアクセスできない場合）での動作を決定するルールを設定するには、[**フォント置換**](/slides/ja/cpp/font-substitution/) を参照してください。 

{{% /alert %}}

## **よくある質問**

**「フォント置換」「フォントサブスティテューション」「フォールバックフォント」の違いは何ですか？**

置換は、ドキュメント全体でフォントファミリを意図的に別のものに切り替えることです。[サブスティテューション](/slides/ja/cpp/font-substitution/) は「フォントが利用できない場合は X を使用する」というようなルールです。[フォールバック](/slides/ja/cpp/fallback-font/) は、ベースフォントがインストールされているが必要な文字が含まれていない場合に、個々の欠損グリフに対してのみ適用されます。

**置換はマスタースライド、レイアウト、ノート、コメントにも適用されますか？**

はい。置換は元のフォントを使用しているすべてのプレゼンテーションオブジェクトに影響し、マスタースライドやノートも含まれます。コメントもドキュメントの一部であり、フォントエンジンで考慮されます。

**埋め込み OLE オブジェクト（例: Excel）内のフォントは変更されますか？**

いいえ。[OLE コンテンツ](/slides/ja/cpp/manage-ole/) はそれぞれのアプリケーションによって管理されます。プレゼンテーション内での置換は内部 OLE データの形式を変えません。表示は画像として、または外部で編集可能なコンテンツとして行われる場合があります。

**プレゼンテーションの一部（スライドや領域）だけでフォントを置換できますか？**

対象オブジェクトや範囲レベルでフォントを変更すれば、特定のスライドや領域だけで置換することが可能です。ただし、ドキュメント全体に対してグローバルに置換を適用するのとは異なります。レンダリング時の全体的なフォント選択ロジックは同じままです。

**プレゼンテーションが使用しているフォントを事前にすべて把握するにはどうすればよいですか？**

プレゼンテーションの[フォントマネージャー](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) を使用します。使用中の[フォントファミリの一覧](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getfonts/) と、[置換または「不明」フォントに関する情報](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getsubstitutions/) を取得でき、置換の計画に役立ちます。

**PDF や画像への変換時にフォント置換は機能しますか？**

はい。エクスポート時に Aspose.Slides は同じ[フォント選択/置換シーケンス](/slides/ja/cpp/font-selection-sequence/) を適用するため、事前に行った置換は変換時に反映されます。

**対象フォントをシステムにインストールする必要がありますか、それともフォントフォルダーを添付できますか？**

インストールは不要です。ライブラリはユーザーフォルダーから[外部フォントの読み込み](/slides/ja/cpp/custom-font/) をサポートしており、[レンダリングおよびエクスポート](/slides/ja/cpp/convert-powerpoint/) 時に使用できます。

**置換により文字の代わりに表示される「豆腐」(四角) が解消しますか？**

対象フォントに必要なグリフが実際に含まれている場合に限り、置換で解決します。含まれていない場合は、[フォールバックの設定](/slides/ja/cpp/fallback-font/) を行い、欠損文字をカバーしてください。