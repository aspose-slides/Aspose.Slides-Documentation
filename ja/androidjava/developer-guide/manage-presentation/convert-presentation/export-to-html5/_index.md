---
title: HTML5 にエクスポート
type: docs
weight: 40
url: /ja/androidjava/export-to-html5/
keywords:
- PowerPoint to HTML
- スライドを HTML に
- HTML5
- HTML エクスポート
- プレゼンテーションをエクスポート
- プレゼンテーションを変換
- スライドを変換
- Java
- Aspose.Slides for Android via Java
description: "Java で PowerPoint を HTML5 にエクスポート"
---

{{% alert title="情報" color="info" %}}

[Aspose.Slides 21.9](/slides/ja/androidjava/aspose-slides-for-java-21-9-release-notes/) では、HTML5 エクスポートのサポートを実装しました。

{{% /alert %}} 

ここでの HTML5 へのエクスポートプロセスでは、Web 拡張機能や依存関係なしで PowerPoint を HTML に変換できます。この方法では、自分自身のテンプレートを使用し、エクスポートプロセスと結果として生成される HTML、CSS、JavaScript、アニメーション属性を定義する柔軟なオプションを適用できます。

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

この場合、クリーンな HTML が得られます。

{{% /alert %}}

図形アニメーションやスライドトランジションの設定を次のように指定することもできます：

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

この Java コードは、標準の PowerPoint から HTML へのプロセスを示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

この場合、プレゼンテーションの内容は次のように SVG を通じてレンダリングされます：

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> スライドの内容がここに入ります </g>
     </svg>
</div>
</body>
```

{{% alert title="注意" color="warning" %}} 

この方法を使用して PowerPoint を HTML にエクスポートする場合、SVG レンダリングのため、特定の要素にスタイルを適用したりアニメーションを施したりすることはできません。

{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

**Aspose.Slides** は、PowerPoint プレゼンテーションを HTML5 ドキュメントに変換し、スライドがスライドビューモードで表示されるようにします。この場合、結果の HTML5 ファイルをブラウザで開くと、ウェブページ上でスライドビューモードのプレゼンテーションが表示されます。

この Java コードは、PowerPoint から HTML5 スライドビューへのエクスポートプロセスを示しています：

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

## コメント付きのプレゼンテーションを HTML5 ドキュメントに変換

PowerPoint のコメントは、ユーザーがプレゼンテーションスライドにメモやフィードバックを残せるツールです。特に、複数の人が特定のスライド要素に自分の提案や意見を加え、主なコンテンツを変更することなく共同作業を行うプロジェクトでは非常に便利です。各コメントには著者の名前が表示されるため、誰がコメントを残したかを簡単に追跡できます。

「sample.pptx」ファイルに保存された次の PowerPoint プレゼンテーションを考えてみましょう。

![プレゼンテーションスライドに対する2つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際に、出力ドキュメントにプレゼンテーションのコメントを含めるかどうかを簡単に指定できます。これを行うには、[Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) クラスの `getNotesCommentsLayouting` メソッドでコメントの表示パラメータを指定する必要があります。

次のコード例は、スライドの右側にコメントを表示する HTML5 ドキュメントへのプレゼンテーションの変換を示しています。
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

「output.html」ドキュメントは、以下の画像に示されています。

![出力 HTML5 ドキュメントのコメント](two_comments_html5.png)