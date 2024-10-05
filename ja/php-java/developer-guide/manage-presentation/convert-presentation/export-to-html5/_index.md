---
title: HTML5へのエクスポート
type: docs
weight: 40
url: /php-java/export-to-html5/
keywords:
- PowerPointからHTML
- スライドからHTML
- HTML5
- HTMLエクスポート
- プレゼンテーションをエクスポート
- プレゼンテーションを変換
- スライドを変換
- PHP
- Aspose.Slides for PHP via Java
description: "PHPでPowerPointをHTML5にエクスポート"
---

{{% alert title="情報" color="info" %}}

[Aspose.Slides 21.9](/slides/php-java/aspose-slides-for-java-21-9-release-notes/)では、HTML5エクスポートのサポートを実装しました。

{{% /alert %}} 

ここでのHTML5へのエクスポートプロセスでは、Web拡張機能や依存関係なしにPowerPointをHTMLに変換できます。この方法では、独自のテンプレートを使用して、エクスポートプロセスと生成されたHTML、CSS、JavaScript、およびアニメーション属性を定義する非常に柔軟なオプションを適用できます。

## **PowerPointをHTML5にエクスポート**

このPHPコードは、Web拡張機能や依存関係なしにプレゼンテーションをHTML5にエクスポートする方法を示しています：

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

この場合、クリーンなHTMLが得られます。 

{{% /alert %}}

形状のアニメーションとスライドのトランジションの設定をこのように指定することもできます：

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

## **PowerPointをHTMLにエクスポート**

このJavaは、標準のPowerPointからHTMLへのプロセスを示しています：

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

この場合、プレゼンテーションの内容はSVGを通じて次のようにレンダリングされます：

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> スライドの内容はここに入ります </g>
     </svg>
</div>
</body>
```php

```

{{% alert title="注意" color="warning" %}} 

この方法を使用してPowerPointをHTMLにエクスポートする際、SVGレンダリングにより、特定の要素にスタイルを適用したりアニメートしたりすることはできません。 

{{% /alert %}}

## **PowerPointをHTML5スライドビューにエクスポート**

**Aspose.Slides** は、PowerPointプレゼンテーションをスライドビュー形式で表示するHTML5ドキュメントに変換することを可能にします。この場合、生成されたHTML5ファイルをブラウザで開くと、ウェブページ上でスライドビュー形式でプレゼンテーションが表示されます。

このPHPコードは、PowerPointからHTML5スライドビューへのエクスポートプロセスを示しています：

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

## コメント付きプレゼンテーションをHTML5ドキュメントに変換

PowerPointのコメントは、ユーザーがプレゼンテーションスライドにメモやフィードバックを残すためのツールです。これは特に、複数の人が特定のスライド要素に対して提案や意見を追加できるコラボレーションプロジェクトにおいて便利です。各コメントには著者の名前が表示され、誰がその意見を残したのか追跡するのが容易です。

以下のPowerPointプレゼンテーションが「sample.pptx」ファイルに保存されているとしましょう。

![プレゼンテーションスライド上の二つのコメント](two_comments_pptx.png)

PowerPointプレゼンテーションをHTML5ドキュメントに変換する際、出力ドキュメントにプレゼンテーションからコメントを含めるかどうかを簡単に指定できます。これを行うには、`Html5Options`クラスの`getNotesCommentsLayouting`メソッドでコメントの表示パラメータを指定する必要があります。

以下のコード例は、コメントがスライドの右側に表示されるHTML5ドキュメントへのプレゼンテーションの変換を示しています。
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```

「output.html」ドキュメントは以下の画像に示されています。

![出力HTML5ドキュメント内のコメント](two_comments_html5.png)