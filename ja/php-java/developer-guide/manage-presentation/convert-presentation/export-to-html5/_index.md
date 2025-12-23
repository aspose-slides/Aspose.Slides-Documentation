---
title: PHPでプレゼンテーションをHTML5に変換
linktitle: プレゼンテーションをHTML5へ
type: docs
weight: 40
url: /ja/php-java/export-to-html5/
keywords:
- PowerPointをHTML5に変換
- OpenDocumentをHTML5に変換
- プレゼンテーションをHTML5に変換
- スライドをHTML5に変換
- PPTをHTML5に変換
- PPTXをHTML5に変換
- ODPをHTML5に変換
- PPTをHTML5として保存
- PPTXをHTML5として保存
- ODPをHTML5として保存
- PPTをHTML5にエクスポート
- PPTXをHTML5にエクスポート
- ODPをHTML5にエクスポート
- PHP
- Aspose.Slides
description: "Java経由でPHP用Aspose.Slidesを使用し、PowerPointおよびOpenDocumentのプレゼンテーションをレスポンシブなHTML5にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---

{{% alert title="情報" color="info" %}}

[Aspose.Slides 21.9](/slides/ja/php-java/aspose-slides-for-java-21-9-release-notes/)で、HTML5 エクスポートのサポートを実装しました。

{{% /alert %}} 

この HTML5 エクスポートプロセスにより、Web 拡張機能や依存関係なしで PowerPoint を HTML に変換できます。独自のテンプレートを使用して、エクスポートプロセスや生成される HTML、CSS、JavaScript、アニメーション属性を定義する非常に柔軟なオプションを適用できます。

## **PowerPoint を HTML5 にエクスポート**

この PHP コードは、Web 拡張機能や依存関係なしでプレゼンテーションを HTML5 にエクスポートする方法を示しています:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

この場合、クリーンな HTML が取得できます。

{{% /alert %}}

この方法で形状アニメーションやスライド遷移の設定を指定できます:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **PowerPoint を HTML にエクスポート**

この Java は、標準的な PowerPoint から HTML への変換プロセスを示しています:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


この場合、プレゼンテーションの内容は SVG を介して次のように描画されます:
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```php

```


{{% alert title="注意" color="warning" %}} 

この方法で PowerPoint を HTML にエクスポートすると、SVG 描画のため、スタイルの適用や特定要素のアニメーションはできません。

{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

**Aspose.Slides** を使用すると、PowerPoint プレゼンテーションを HTML5 ドキュメントに変換でき、スライドはスライドビュー モードで表示されます。この場合、生成された HTML5 ファイルをブラウザーで開くと、Web ページ上でスライドビュー モードのプレゼンテーションが表示されます。

この PHP コードは、PowerPoint を HTML5 スライドビューにエクスポートするプロセスを示しています:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **コメント付き HTML5 ドキュメントへのプレゼンテーション変換**

PowerPoint のコメントは、ユーザーがスライドにメモやフィードバックを残すためのツールです。共同作業プロジェクトで特に有用で、複数のユーザーがメインコンテンツを変更せずに特定のスライド要素に提案やコメントを追加できます。各コメントには作成者名が表示され、誰がコメントしたかを簡単に追跡できます。

例えば、"sample.pptx" ファイルに保存された PowerPoint プレゼンテーションがあるとします。

![プレゼンテーション スライド上の 2 つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際に、出力ドキュメントにコメントを含めるかどうかを簡単に指定できます。そのためには、`Html5Options` クラスの `getNotesCommentsLayouting` メソッドでコメントの表示パラメーターを指定します。

以下のコード例は、スライドの右側にコメントを表示した HTML5 ドキュメントにプレゼンテーションを変換します。
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```


下の画像に「output.html」ドキュメントが示されています。

![出力された HTML5 ドキュメント内のコメント](two_comments_html5.png)

## **FAQ**

**オブジェクト アニメーションやスライド遷移を HTML5 で再生させるかどうか制御できますか？**

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) と [slide transitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/) を有効または無効にする個別のオプションが提供されています。

**コメントの出力はサポートされており、スライドに対してどの位置に配置できますか？**

はい、HTML5 でコメントを追加でき、ノートやコメントの [layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) を使用して（例：スライドの右側）配置できます。

**セキュリティや CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできる [setting](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) があり、厳格なセキュリティポリシーに対応できます。