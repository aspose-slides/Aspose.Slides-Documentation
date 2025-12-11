---
title: Android でプレゼンテーションを HTML5 に変換する
linktitle: プレゼンテーションを HTML5 に変換
type: docs
weight: 40
url: /ja/androidjava/export-to-html5/
keywords:
- PowerPoint を HTML5 に変換
- OpenDocument を HTML5 に変換
- プレゼンテーションを HTML5 に変換
- スライドを HTML5 に変換
- PPT を HTML5 に変換
- PPTX を HTML5 に変換
- ODP を HTML5 に変換
- PPT を HTML5 として保存
- PPTX を HTML5 として保存
- ODP を HTML5 として保存
- PPT を HTML5 にエクスポート
- PPTX を HTML5 にエクスポート
- ODP を HTML5 にエクスポート
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides を使用し、Java 経由で PowerPoint および OpenDocument プレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---

{{% alert title="Info" color="info" %}}
[Aspose.Slides 21.9](/slides/ja/androidjava/aspose-slides-for-java-21-9-release-notes/) では、HTML5 エクスポートのサポートを実装しました。
{{% /alert %}} 

ここでの HTML5 エクスポート プロセスにより、Web 拡張機能や依存関係なしで PowerPoint を HTML に変換できます。この方法では、独自のテンプレートを使用して、エクスポート プロセスと生成される HTML、CSS、JavaScript、アニメーション属性を定義する非常に柔軟なオプションを適用できます。 

## **PowerPoint を HTML5 にエクスポート**

この Java コードは、Web 拡張機能や依存関係なしでプレゼンテーションを HTML5 にエクスポートする方法を示しています：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
この場合、クリーンな HTML が取得できます。 
{{% /alert %}}

このように、シェイプ アニメーションとスライド遷移の設定を指定したくなる場合があります：
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

この Java は、標準的な PowerPoint から HTML へのプロセスを示しています：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```


この場合、プレゼンテーションのコンテンツは SVG を介して次のような形でレンダリングされます：
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
この方法で PowerPoint を HTML にエクスポートすると、SVG によるレンダリングのため、特定の要素にスタイルを適用したりアニメーションを付けたりすることができません。 
{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

**Aspose.Slides** は、PowerPoint プレゼンテーションを HTML5 ドキュメントに変換でき、スライドがスライドビュー モードで表示されます。この場合、生成された HTML5 ファイルをブラウザで開くと、ウェブページ上でスライドビュー モードのプレゼンテーションが表示されます。 

この Java コードは、PowerPoint を HTML5 スライドビューにエクスポートするプロセスを示しています：
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


## **プレゼンテーションをコメント付き HTML5 ドキュメントに変換**

PowerPoint のコメントは、ユーザーがプレゼンテーション スライドにメモやフィードバックを残すためのツールです。特に共同プロジェクトで有用で、複数のユーザーがメインコンテンツを変更せずに特定のスライド要素に提案やコメントを追加できます。各コメントには作成者の名前が表示され、誰がコメントしたかを簡単に追跡できます。

例えば、"sample.pptx" ファイルに保存された以下の PowerPoint プレゼンテーションがあるとします。

![プレゼンテーション スライドの 2 つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際、出力ドキュメントにプレゼンテーションのコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) クラスの `getNotesCommentsLayouting` メソッドでコメントの表示パラメータを指定する必要があります。

次のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 ドキュメントに変換します。
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```


以下の画像に「output.html」ドキュメントが示されています。

![出力された HTML5 ドキュメントのコメント](two_comments_html5.png)

## **FAQ**

**HTML5 でオブジェクト アニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 では、[shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) と [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) を有効化または無効化するための個別のオプションが提供されています。

**コメントの出力はサポートされますか？また、スライドに対してどこに配置できますか？**

はい、HTML5 でコメントを追加でき、ノートとコメントの [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) を使用して（例としてスライドの右側など）配置することができます。

**セキュリティや CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできる [setting](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) があり、厳格なセキュリティ ポリシーに準拠するのに役立ちます。