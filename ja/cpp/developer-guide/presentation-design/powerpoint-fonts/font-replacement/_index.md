---
title: C++ を使用したプレゼンテーションのフォント置換を効率化
linktitle: フォント置換
type: docs
weight: 60
url: /ja/cpp/font-replacement/
keywords:
- フォント
- フォントの置換
- フォント置換
- フォント変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument プレゼンテーションでタイポグラフィを一貫させるためにフォントをシームレスに置換します。"
---
## **概要**

Aspose.Slides を使用すると、プレゼンテーション全体でフォントを別のフォントに置き換えることができます。フォントが置き換えられると、元のフォントのすべてのインスタンスが新しいフォントに変更されます。

フォント置換を実行するには、プレゼンテーションをロードし、元のフォントと置換フォントを定義し、フォント置換メソッドを呼び出して、変更されたプレゼンテーションを PPTX ファイルとして保存します。この方法は、プレゼンテーション全体でフォントファミリを意図的に切り替えたい場合に便利です。

## **フォントの置換**

フォントの使用をやめたい場合は、別のフォントに置き換えることができます。古いフォントのすべてのインスタンスが新しいフォントに置き換えられます。

Aspose.Slides では、次の手順でフォントを置換できます：

1. 対象のプレゼンテーションをロードします。  
2. 置換対象のフォントをロードします。  
3. 新しいフォントをロードします。  
4. フォントを置換します。  
5. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

この C++ コードはフォント置換を示しています：

```cpp
// プレゼンテーションを読み込みます
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// 置換される元フォントを読み込みます
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// 新しいフォントを読み込みます
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// フォントを置換します
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// プレゼンテーションを保存します
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
特定の条件下（たとえばフォントにアクセスできない場合）での動作を決定するルールを設定するには、[**Font Substitution**](/slides/ja/cpp/font-substitution/)をご覧ください。 
{{% /alert %}}

## **FAQ**

**「フォント置換」「フォント代替」「フォールバックフォント」の違いは何ですか？**  
置換は、文書全体であるフォントファミリから別のフォントファミリへ意図的に切り替えることです。[Substitution](/slides/ja/cpp/font-substitution/) は「フォントが利用できない場合は X を使用する」といったルールです。[Fallback](/slides/ja/cpp/fallback-font/) は、ベースフォントがインストールされているが必要な文字が含まれていない場合に、個々の欠損グリフに対して外科的に適用されます。

**置換はマスタースライド、レイアウト、ノート、コメントにも適用されますか？**  
はい。置換は元のフォントを使用しているすべてのプレゼンテーションオブジェクトに影響し、マスタースライドやノートも含まれます。コメントもドキュメントの一部であり、フォントエンジンによって考慮されます。

**埋め込み OLE オブジェクト（例: Excel）内のフォントは変更されますか？**  
いいえ。[OLE content](/slides/ja/cpp/manage-ole/) はそれぞれのアプリケーションで制御されます。プレゼンテーション側での置換は内部の OLE データを再フォーマットせず、画像として表示されたり外部で編集可能なコンテンツとして扱われる場合があります。

**プレゼンテーションの一部（スライドや領域）だけでフォントを置換できますか？**  
対象オブジェクトや範囲レベルでフォントを変更すれば、ドキュメント全体に対してグローバルに置換するのではなく、プレゼンテーションの一部だけで置換することが可能です。レンダリング時の全体的なフォント選択ロジックは変わりません。

**プレゼンテーションが使用しているフォントを事前に確認するにはどうすればよいですか？**  
プレゼンテーションの[フォントマネージャ](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/)を使用します。使用中の[ファミリ](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/getfonts/) の一覧や、[代替/不明フォント](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/getsubstitutions/) に関する情報が取得でき、置換の計画に役立ちます。

**PDF/画像への変換時にフォント置換は機能しますか？**  
はい。エクスポート時に Aspose.Slides は同じ[font selection/substitution sequence](/slides/ja/cpp/font-selection-sequence/)を適用するため、事前に実施した置換は変換時に尊重されます。

**対象フォントをシステムにインストールする必要がありますか、それともフォントフォルダーを添付できますか？**  
インストールは不要です。ライブラリはユーザーフォルダーから[外部フォントのロード](/slides/ja/cpp/custom-font/) を可能にし、[レンダリングおよびエクスポート](/slides/ja/cpp/convert-powerpoint/) 時に使用できます。

**置換で文字の代わりに表示される「豆腐」（四角）を解消できますか？**  
対象フォントに必要なグリフが実際に含まれている場合にのみ解消します。含まれていない場合は、[fallback の設定](/slides/ja/cpp/fallback-font/) を行い、欠損文字をカバーしてください。