---
title: JavaScript でプレゼンテーションを HTML5 に変換
linktitle: プレゼンテーションを HTML5 に変換
type: docs
weight: 40
url: /ja/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、PowerPoint と OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式設定、アニメーション、インタラクティブ性を保持します。"
---

Aspose.Slides は HTML5 エクスポートをサポートしています。この HTML5 エクスポートプロセスを使用すると、Web 拡張機能や依存関係なしで PowerPoint を HTML に変換できます。独自のテンプレートを使用して、エクスポートプロセスと生成される HTML、CSS、JavaScript、アニメーション属性を定義する非常に柔軟なオプションを適用できます。

## **PowerPoint を HTML5 にエクスポート**

この JavaScript コードは、Web 拡張機能や依存関係なしでプレゼンテーションを HTML5 にエクスポートする方法を示しています:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
この場合、クリーンな HTML が得られます。 
{{% /alert %}}

シェイプ アニメーションやスライド トランジションの設定をこのように指定したい場合:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint を HTML にエクスポート**

この JavaScript は標準的な PowerPoint → HTML プロセスを示しています:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


この場合、プレゼンテーションのコンテンツは以下のような形で SVG を通じてレンダリングされます:
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
この方法で PowerPoint を HTML にエクスポートすると、SVG レンダリングのため、特定の要素にスタイルを適用したりアニメーションを付けたりすることができなくなります。 
{{% /alert %}}

## **PowerPoint を HTML5 スライド ビューにエクスポート**

**Aspose.Slides** を使用すると、スライドがスライド ビュー モードで表示される HTML5 ドキュメントに PowerPoint プレゼンテーションを変換できます。この場合、生成された HTML5 ファイルをブラウザーで開くと、Web ページ上でスライド ビュー モードのプレゼンテーションが表示されます。

この JavaScript コードは、PowerPoint → HTML5 スライド ビュー エクスポートプロセスを示しています:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **コメント付き HTML5 ドキュメントへのプレゼンテーション変換**

PowerPoint のコメントは、スライド上の特定の要素に対してノートやフィードバックを残すためのツールです。特に共同プロジェクトで有用で、複数のユーザーがメイン コンテンツを変更せずにコメントや提案を追加できます。各コメントには作成者の名前が表示されるため、誰がコメントしたかを簡単に追跡できます。

たとえば、"sample.pptx" ファイルに保存された以下の PowerPoint プレゼンテーションがあるとします。

![プレゼンテーションスライドの 2 つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換するとき、出力ドキュメントにコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) クラスの `notes_comments_layouting` プロパティでコメントの表示パラメータを指定します。

以下のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 ドキュメントに変換します。
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```


"output.html" ドキュメントは以下の画像に示されています。

![出力された HTML5 ドキュメントのコメント](two_comments_html5.png)

## **FAQ**

**HTML5 でオブジェクト アニメーションやスライド トランジションの再生を制御できますか？**

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) と [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/) を個別に有効または無効にするオプションが用意されています。

**コメントの出力はサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、HTML5 でコメントを追加でき、[layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) を使用してスライドの右側など任意の位置に配置できます。

**セキュリティまたは CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできる [setting](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) が用意されています。これにより、厳格なセキュリティ ポリシーに準拠できます。