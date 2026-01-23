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
description: "Java経由でPHP用Aspose.Slidesを使用し、PowerPointおよびOpenDocumentプレゼンテーションをレスポンシブなHTML5にエクスポートします。書式設定、アニメーション、インタラクティブ性を保持します。"
---

Aspose.Slides は HTML5 エクスポートをサポートします。ここでの HTML5 へのエクスポート プロセスにより、Web 拡張機能や依存関係なしで PowerPoint を HTML に変換できます。独自のテンプレートを使用すれば、エクスポート プロセスと生成される HTML、CSS、JavaScript、アニメーション属性を定義する柔軟なオプションを適用できます。

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
この場合、クリーンな HTML が得られます。 
{{% /alert %}}

シェイプ アニメーションとスライド トランジションの設定をこのように指定できます:
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

この Java は標準的な PowerPoint から HTML へのエクスポート プロセスを示しています:
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


この場合、プレゼンテーション コンテンツは SVG を通じて次のような形でレンダリングされます:
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


{{% alert title="Note" color="warning" %}} 
この方法で PowerPoint を HTML にエクスポートすると、SVG レンダリングのため、特定の要素にスタイルを適用したりアニメーション化したりできません。 
{{% /alert %}}

## **PowerPoint を HTML5 スライド ビューにエクスポート**

**Aspose.Slides** は、スライドがスライド ビュー モードで表示される HTML5 ドキュメントに PowerPoint プレゼンテーションを変換できます。この場合、生成された HTML5 ファイルをブラウザーで開くと、Web ページ上でスライド ビュー モードのプレゼンテーションが表示されます。

この PHP コードは、PowerPoint から HTML5 スライド ビューへのエクスポート プロセスを示しています:
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


## **コメント付き HTML5 ドキュメントにプレゼンテーションを変換**

PowerPoint のコメントは、ユーザーがスライドにメモやフィードバックを残すためのツールです。複数のメンバーが特定のスライド要素に対して提案や指摘を追加でき、メイン コンテンツを変更せずに共同作業が可能です。各コメントは作者名を表示するため、誰が指摘したかが容易に追跡できます。

たとえば、次の PowerPoint プレゼンテーションが「sample.pptx」というファイルに保存されているとします。

![Two comments on the presentation slide](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際、出力ドキュメントにプレゼンテーションからのコメントを含めるかどうかを簡単に指定できます。そのためには、`Html5Options` クラスの `getNotesCommentsLayouting` メソッドでコメントの表示パラメータを指定する必要があります。

次のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 ドキュメントに変換します。
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```


「output.html」ドキュメントは下の画像に示されています。

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**HTML5 でオブジェクト アニメーションやスライド トランジションの再生を制御できますか？**

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) と [slide transitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/) を個別に有効化または無効化するオプションが用意されています。

**コメントの出力はサポートされていますか？スライドに対してどの位置に配置できますか？**

はい、HTML5 でコメントを追加でき、ノートやコメント用の [layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) によりスライドの右側など任意の位置に配置可能です。

**セキュリティや CSP の観点で JavaScript を呼び出すリンクを除外できますか？**

はい、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップする [setting](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) があり、厳格なセキュリティ ポリシーに準拠できます。