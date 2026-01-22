---
title: Android でプレゼンテーションを HTML5 に変換
linktitle: プレゼンテーションから HTML5 へ
type: docs
weight: 40
url: /ja/androidjava/export-to-html5/
keywords:
- PowerPoint から HTML5 へ
- OpenDocument から HTML5 へ
- プレゼンテーションから HTML5 へ
- スライドから HTML5 へ
- PPT から HTML5 へ
- PPTX から HTML5 へ
- ODP から HTML5 へ
- PPT を HTML5 として保存
- PPTX を HTML5 として保存
- ODP を HTML5 として保存
- PPT を HTML5 にエクスポート
- PPTX を HTML5 にエクスポート
- ODP を HTML5 にエクスポート
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides で PowerPoint と OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式設定、アニメーション、インタラクティブ性を保持します。"
---

Aspose.Slides は HTML5 エクスポートをサポートします。ここでの HTML5 エクスポート プロセスにより、Web 拡張機能や外部依存関係なしで PowerPoint を HTML に変換できます。独自のテンプレートを使用することで、エクスポート プロセスと生成される HTML、CSS、JavaScript、およびアニメーション属性を定義する柔軟なオプションを適用できます。 

## **PowerPoint を HTML5 にエクスポート**

この Java コードは、Web 拡張機能や依存関係なしでプレゼンテーションを HTML5 にエクスポートする方法を示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
この場合、クリーンな HTML が得られます。 
{{% /alert %}}

この方法でシェイプ アニメーションやスライド遷移の設定を指定したい場合:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint を HTML にエクスポート**

この Java は標準的な PowerPoint から HTML への変換プロセスを示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```


この場合、プレゼンテーションのコンテンツは以下のように SVG を介してレンダリングされます:
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```


{{% alert title="Note" color="warning" %}} 
この方法で PowerPoint を HTML にエクスポートすると、SVG レンダリングのため、スタイルを適用したり特定の要素をアニメーション化したりできません。 
{{% /alert %}}

## **PowerPoint を HTML5 スライド ビューにエクスポート**

**Aspose.Slides** は、スライドがスライド ビュー モードで表示される HTML5 ドキュメントに PowerPoint プレゼンテーションを変換できます。この場合、生成された HTML5 ファイルをブラウザーで開くと、Web ページ上でスライド ビュー モードのプレゼンテーションが表示されます。

この Java コードは、PowerPoint から HTML5 スライド ビューへのエクスポート プロセスを示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **コメント付き HTML5 ドキュメントへのプレゼンテーション変換**

PowerPoint のコメントは、ユーザーがスライドにメモやフィードバックを残すためのツールです。共同プロジェクトで特に有用で、複数の人がメイン コンテンツを変更せずに特定のスライド要素に対して提案や指摘を追加できます。各コメントには作成者名が表示されるため、誰がコメントしたかが容易に把握できます。

例として、"sample.pptx" ファイルに保存された以下の PowerPoint プレゼンテーションを考えてみましょう。

![プレゼンテーション スライド上の 2 つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際、出力ドキュメントにコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) クラスの `getNotesCommentsLayouting` メソッドでコメントの表示パラメーターを設定します。

以下のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 ドキュメントに変換します。
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```


生成された "output.html" ドキュメントは下の画像に示されています。

![出力された HTML5 ドキュメント内のコメント](two_comments_html5.png)

## **FAQ**

**オブジェクトのアニメーションやスライド遷移の再生を HTML5 で制御できますか？**

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) と [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) を有効または無効にする個別のオプションが用意されています。

**コメントの出力はサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、HTML5 ではコメントを追加でき、[layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) を使用してスライドの右側など任意の位置に配置できます。

**セキュリティや CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、[setting](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) が用意されており、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできます。