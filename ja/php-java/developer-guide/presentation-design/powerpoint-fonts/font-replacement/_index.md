---
title: PHP を使用したプレゼンテーションのフォント置換を効率化
linktitle: フォント置換
type: docs
weight: 60
url: /ja/php-java/font-replacement/
keywords:
- フォント
- フォント置換
- フォント置換
- フォント変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides のフォントをシームレスに置換し、PowerPoint および OpenDocument プレゼンテーションで一貫したタイポグラフィを実現します。"
---

## **フォントの置換**

フォントの使用をやめたい場合は、別のフォントに置き換えることができます。古いフォントのすべてのインスタンスが新しいフォントに置き換えられます。

Aspose.Slides では、フォントを次の手順で置き換えることができます:

1. 対象のプレゼンテーションを読み込みます。  
2. 置き換えるフォントを読み込みます。  
3. 新しいフォントを読み込みます。  
4. フォントを置換します。  
5. 変更されたプレゼンテーションを書き出してPPTXファイルにします。

このPHPコードはフォント置換を示しています:
```php
  # プレゼンテーションを読み込みます
  $pres = new Presentation("Fonts.pptx");
  try {
    # 置き換える元フォントを読み込みます
    $sourceFont = new FontData("Arial");
    # 新しいフォントを読み込みます
    $destFont = new FontData("Times New Roman");
    # フォントを置換します
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # プレゼンテーションを保存します
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Note" color="warning" %}} 
フォントにアクセスできない場合など、特定の条件下で何が起こるかを決めるルールを設定するには、[**フォント置換**](/slides/ja/php-java/font-substitution/)をご覧ください。 
{{% /alert %}}

## **FAQ**

**「font replacement」「font substitution」「fallback fonts」の違いは何ですか？**

置換は文書全体で特定のフォントファミリーから別のフォントファミリーへ意図的に切り替えることです。[Substitution](/slides/ja/php-java/font-substitution/) は「フォントが利用できない場合はXを使用する」というようなルールです。[Fallback](/slides/ja/php-java/fallback-font/) は、ベースフォントがインストールされているものの必要な文字が含まれていない場合に、個々の欠損グリフに対して外科的に適用されます。

**置換はマスタースライド、レイアウト、ノート、コメントにも適用されますか？**

はい。置換は元のフォントを使用しているすべてのプレゼンテーションオブジェクトに影響し、マスタースライドやノートも含まれます。コメントも文書の一部であり、フォントエンジンによって考慮されます。

**埋め込みOLEオブジェクト（例: Excel）内のフォントは変更されますか？**

いいえ。[OLE content](/slides/ja/php-java/manage-ole/) はそれぞれのアプリケーションで管理されています。プレゼンテーション内での置換は内部のOLEデータを再フォーマットせず、画像として表示されたり外部で編集可能なコンテンツとして扱われることがあります。

**プレゼンテーションの一部（スライドや領域）だけでフォントを置換できますか？**

対象オブジェクト/範囲レベルでフォントを変更すれば、ドキュメント全体に対してグローバル置換を適用せずに、目的のスライドや領域だけで置換が可能です。レンダリング時の全体的なフォント選択ロジックは変わりません。

**プレゼンテーションが使用しているフォントを事前にすべて把握するにはどうすればよいですか？**

プレゼンテーションの[font manager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/)を使用します。これにより、使用中の[フォントファミリーの一覧](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getfonts/)や、[置換/「不明」フォントの情報](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/)が取得でき、置換計画に役立ちます。

**PDF/画像に変換するときにフォント置換は機能しますか？**

はい。エクスポート時、Aspose.Slides は同じ[フォント選択/置換シーケンス](/slides/ja/php-java/font-selection-sequence/)を適用するため、事前に行った置換は変換時にも反映されます。

**対象フォントをシステムにインストールする必要がありますか？フォントフォルダーを添付できますか？**

インストールは不要です。ライブラリはユーザーフォルダーから[外部フォントの読み込み](/slides/ja/php-java/custom-font/)をサポートしており、[レンダリングやエクスポート](/slides/ja/php-java/convert-powerpoint/)時に使用できます。

**置換で文字が四角（tofu）になる問題は解決しますか？**

対象フォントに必要なグリフが実際に含まれている場合に限り解決します。含まれていない場合は、欠損文字をカバーするために[フォールバックを設定](/slides/ja/php-java/fallback-font/)してください。