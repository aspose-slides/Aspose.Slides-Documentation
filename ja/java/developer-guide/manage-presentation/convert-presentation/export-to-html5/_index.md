---
title: HTML5へのエクスポート
type: docs
weight: 40
url: /ja/java/export-to-html5/
keywords:
- PowerPointからHTML
- スライドからHTML
- HTML5
- HTMLエクスポート
- プレゼンテーションのエクスポート
- プレゼンテーションの変換
- スライドの変換
- Java
- Aspose.Slides for Java
description: "JavaでPowerPointをHTML5にエクスポート"
---

{{% alert title="情報" color="info" %}}

[Aspose.Slides 21.9](/slides/ja/java/aspose-slides-for-java-21-9-release-notes/) では、HTML5エクスポートのサポートを実装しました。

{{% /alert %}} 

ここでのHTML5へのエクスポートプロセスでは、ウェブ拡張または依存関係なしにPowerPointをHTMLに変換できます。この方法により、自分のテンプレートを使用して、エクスポートプロセスと結果として得られるHTML、CSS、JavaScript、およびアニメーション属性を定義する非常に柔軟なオプションを適用できます。 

## **PowerPointをHTML5にエクスポート**

このJavaコードは、ウェブ拡張や依存関係なしにプレゼンテーションをHTML5にエクスポートする方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

この場合、クリーンなHTMLを得ることができます。 

{{% /alert %}}

この方法で形状アニメーションやスライド遷移の設定を指定することもできます：

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

## **PowerPointをHTMLにエクスポート**

このJavaは、標準的なPowerPointからHTMLへのプロセスを示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

この場合、プレゼンテーション内容は次のようにSVGを介してレンダリングされます：

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> スライド内容がここに入ります </g>
     </svg>
</div>
</body>
```

{{% alert title="注意" color="warning" %}} 

この方法を使用してPowerPointをHTMLにエクスポートすると、SVGレンダリングのために特定の要素にスタイルを適用したりアニメーションを追加したりすることができません。 

{{% /alert %}}

## **PowerPointをHTML5スライドビューにエクスポート**

**Aspose.Slides** は、PowerPointプレゼンテーションをHTML5文書に変換し、スライドがスライドビュー形式で表示されるようにします。この場合、生成されたHTML5ファイルをブラウザで開くと、ウェブページ上でスライドビュー形式でプレゼンテーションが表示されます。 

このJavaコードは、PowerPointからHTML5スライドビューへのエクスポートプロセスを示しています：

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

## コメント付きのプレゼンテーションをHTML5文書に変換

PowerPointのコメントは、ユーザーがプレゼンテーションスライドにメモやフィードバックを残すためのツールです。これは特に複数の人が特定のスライド要素に対して提案や意見を追加できる共同プロジェクトに役立ち、メインコンテンツを変更することなく使用されます。各コメントには、著者の名前が表示され、誰が発言したかを簡単に追跡できます。

例えば、次のPowerPointプレゼンテーションが "sample.pptx" ファイルに保存されているとしましょう。

![スライドに対する2つのコメント](two_comments_pptx.png)

PowerPointプレゼンテーションをHTML5文書に変換する際、出力文書にプレゼンテーションのコメントを含めるかどうかを簡単に指定できます。これを行うには、[Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) クラスの `getNotesCommentsLayouting` メソッドでコメントの表示パラメーターを指定する必要があります。

次のコード例は、スライドの右にコメントが表示されたHTML5文書にプレゼンテーションを変換します。
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

"output.html" ドキュメントは以下の画像のように表示されます。

![出力HTML5文書におけるコメント](two_comments_html5.png)