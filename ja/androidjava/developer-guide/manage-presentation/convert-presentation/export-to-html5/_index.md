---
title: Android でプレゼンテーションを HTML5 に変換
linktitle: プレゼンテーションから HTML5 へ
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
description: "Java を使用して Android 向け Aspose.Slides で PowerPoint および OpenDocument プレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションを HTML5 に変換する方法を説明します。Web 拡張機能や追加の依存関係なしで基本的な HTML5 エクスポートを行う方法と、シェイプ アニメーションやスライド遷移を制御するオプションについてカバーしています。また、標準的な PowerPoint から HTML へのエクスポート手順を示し、スライド ビュー モードで HTML5 出力を生成する方法、およびレイアウトを設定してエクスポートされたドキュメントにコメントを含める方法もデモしています。

## **PowerPoint を HTML5 にエクスポート**

この Java コードは、Web 拡張機能や依存関係なしでプレゼンテーションを HTML5 にエクスポートする方法を示します。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
この場合、クリーンな HTML が得られます。 
{{% /alert %}}

このようにシェイプ アニメーションとスライド遷移の設定を指定することもできます。

```java
import com.aspose.slides.*;

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

この Java は、標準的な PowerPoint から HTML へのプロセスを示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

この場合、プレゼンテーションの内容は SVG を介して次のような形でレンダリングされます。

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
この方法で PowerPoint を HTML にエクスポートすると、SVG レンダリングのため、特定の要素にスタイルを適用したりアニメーションを付けたりすることはできません。 
{{% /alert %}}

## **PowerPoint を HTML5 スライド ビューにエクスポート**

**Aspose.Slides** を使用すると、PowerPoint プレゼンテーションをスライド ビュー モードで表示される HTML5 ドキュメントに変換できます。この場合、生成された HTML5 ファイルをブラウザで開くと、ウェブページ上でスライド ビュー モードのプレゼンテーションが表示されます。

この Java コードは、PowerPoint から HTML5 スライド ビューへのエクスポート手順を示しています。

```java
import com.aspose.slides.*;

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

PowerPoint のコメントは、ユーザーがスライドにメモやフィードバックを残すためのツールです。特に共同作業プロジェクトで有用で、複数のメンバーがメイン コンテンツを変更せずに特定のスライド要素に提案や指摘を追加できます。各コメントには作成者の名前が表示され、誰がコメントしたかを簡単に追跡できます。

たとえば、"sample.pptx" ファイルに保存された以下の PowerPoint プレゼンテーションがあるとします。

![プレゼンテーション スライド上の 2 つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際、出力ドキュメントにコメントを含めるかどうかを簡単に指定できます。そのためには、コメントの表示パラメーターを [Html5Options](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/html5options/) クラスの `setSlidesLayoutOptions` メソッドに渡す必要があります。

以下のコード例は、スライドの右側にコメントを表示した HTML5 ドキュメントにプレゼンテーションを変換します。
```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

下の画像は "output.html" ドキュメントを示しています。

![出力された HTML5 ドキュメントのコメント](two_comments_html5.png)

## **よくある質問**

### HTML5 でオブジェクト アニメーションやスライド遷移の再生を制御できますか？

はい、HTML5 では [シェイプ アニメーション](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) および [スライド遷移](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) を有効化または無効化する個別のオプションが提供されています。

### コメントの出力はサポートされており、スライドに対してどこに配置できますか？

はい、HTML5 でコメントを追加でき、ノートとコメント用の [layout settings](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) を使用して（例としてスライドの右側など）配置することができます。

### セキュリティや CSP の理由で JavaScript を呼び出すリンクをスキップできますか？

はい、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできる [設定](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) があり、厳格なセキュリティ ポリシーに準拠するのに役立ちます。