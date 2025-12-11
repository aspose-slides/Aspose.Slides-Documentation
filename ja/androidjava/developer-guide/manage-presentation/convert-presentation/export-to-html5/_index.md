---
title: Android でプレゼンテーションを HTML5 に変換
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
description: "Java を介して Android 用 Aspose.Slides で PowerPoint と OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式設定、アニメーション、インタラクティブ性を保持します。"
---

{{% alert title="Info" color="info" %}}
Aspose.Slides 21.9 のリリースノートで、HTML5 エクスポートのサポートを実装しました。
{{% /alert %}}

ここでの HTML5 エクスポートプロセスにより、Web 拡張機能や依存関係なしで PowerPoint を HTML に変換できます。この方法では、独自のテンプレートを使用して、エクスポートプロセスと生成される HTML、CSS、JavaScript、アニメーション属性を定義する非常に柔軟なオプションを適用できます。 

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

このようにして、シェイプ アニメーションとスライド遷移の設定を指定したくなるかもしれません：
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


この場合、プレゼンテーションのコンテンツは SVG を使用して以下のようにレンダリングされます：
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
この方法で PowerPoint を HTML にエクスポートすると、SVG でのレンダリングのため、特定の要素にスタイルを適用したりアニメーションさせたりすることができません。 
{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

**Aspose.Slides** は、スライドがスライドビュー モードで表示される HTML5 ドキュメントに PowerPoint プレゼンテーションを変換できます。この場合、生成された HTML5 ファイルをブラウザーで開くと、Web ページ上でスライドビュー モードのプレゼンテーションが表示されます。 

この Java コードは、PowerPoint から HTML5 スライドビューへのエクスポートプロセスを実演しています：
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


## **コメント付きでプレゼンテーションを HTML5 ドキュメントに変換**

PowerPoint のコメントは、ユーザーがプレゼンテーション スライドにメモやフィードバックを残すためのツールです。特に共同プロジェクトで有用で、複数のユーザーが主要なコンテンツを変更せずに特定のスライド要素に提案やコメントを追加できます。各コメントは作成者の名前を表示するため、誰がコメントしたかを簡単に追跡できます。 

たとえば、以下の PowerPoint プレゼンテーションが "sample.pptx" ファイルに保存されているとします。

![プレゼンテーション スライド上の 2 つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際、出力ドキュメントにコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) クラスの `getNotesCommentsLayouting` メソッドでコメントの表示パラメータを指定する必要があります。

次のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 ドキュメントに変換します。
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```


「output.html」ドキュメントが下の画像に示されています。

![出力された HTML5 ドキュメントのコメント](two_comments_html5.png)

## **よくある質問**

**HTML5 でオブジェクト アニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 では、[shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) と [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) を有効または無効にする個別のオプションが提供されています。 

**コメントの出力はサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、HTML5 でコメントを追加でき、ノートやコメントの [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) を使用して（例としてスライドの右側など）配置できます。 

**セキュリティや CSP の理由で、JavaScript を呼び出すリンクをスキップできますか？**

はい、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできる [setting](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) があり、厳格なセキュリティ ポリシーに準拠するのに役立ちます。