---
title: Java でプレゼンテーションを HTML5 に変換
linktitle: プレゼンテーション to HTML5
type: docs
weight: 40
url: /ja/java/export-to-html5/
keywords:
- PowerPoint を HTML5 に変換
- OpenDocument を HTML5 に変換
- プレゼンテーション を HTML5 に変換
- スライド を HTML5 に変換
- PPT を HTML5 に変換
- PPTX を HTML5 に変換
- ODP を HTML5 に変換
- PPT を HTML5 として保存
- PPTX を HTML5 として保存
- ODP を HTML5 として保存
- PPT を HTML5 にエクスポート
- PPTX を HTML5 にエクスポート
- ODP を HTML5 にエクスポート
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument プレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションを HTML5 に変換する方法を説明します。Web 拡張機能や追加の依存関係なしで基本的な HTML5 エクスポートを行う方法と、シェイプ アニメーションやスライド トランジションを制御するオプションについて説明します。また、標準的な PowerPoint から HTML へのエクスポート プロセス、スライド ビュー モードで HTML5 出力を生成する方法、エクスポートされたドキュメントにコメントを含める方法も示します。

## **PowerPoint を HTML5 にエクスポート**

この Java コードは、Web 拡張機能や依存関係なしでプレゼンテーションを HTML5 にエクスポートする方法を示しています。

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
この場合、クリーンな HTML が取得できます。 
{{% /alert %}}

次のようにシェイプ アニメーションとスライド トランジションの設定を指定することもできます。

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

この Java は標準的な PowerPoint から HTML へのプロセスを示します。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

この場合、プレゼンテーションの内容は次のような SVG 形式でレンダリングされます。

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
この方法で PowerPoint を HTML にエクスポートすると、SVG のレンダリングにより特定の要素にスタイルを適用したりアニメーションさせたりすることができません。 
{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

**Aspose.Slides** を使用すると、スライドがスライド ビュー モードで表示される HTML5 ドキュメントに PowerPoint プレゼンテーションを変換できます。この場合、生成された HTML5 ファイルをブラウザーで開くと、Web ページ上でスライド ビュー モードのプレゼンテーションが表示されます。

この Java コードは PowerPoint から HTML5 スライドビューへのエクスポート プロセスを示しています。

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

## **コメント付きで PowerPoint を HTML5 ドキュメントに変換**

PowerPoint のコメントは、プレゼンテーション スライドにメモやフィードバックを残すためのツールです。共同作業プロジェクトで特に有用で、複数のユーザーがメイン コンテンツを変更せずに特定のスライド要素に対して提案や指摘を追加できます。各コメントには作成者の名前が表示されるため、誰がコメントしたかを簡単に追跡できます。

たとえば、次のような PowerPoint プレゼンテーションを「sample.pptx」ファイルに保存しているとします。

![プレゼンテーション スライド上の 2 つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際に、出力ドキュメントにプレゼンテーションからのコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/ja/java/com.aspose.slides/html5options/) クラスの `setSlidesLayoutOptions` メソッドにコメントの表示パラメータを渡します。

次のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 ドキュメントに変換します。
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

以下の画像は「output.html」ドキュメントの例です。

![出力された HTML5 ドキュメント内のコメント](two_comments_html5.png)

## **FAQ**

### HTML5 でオブジェクト アニメーションやスライド トランジションの再生を制御できますか？

はい、HTML5 では[シェイプ アニメーション](https://reference.aspose.com/slides/ja/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-)と[スライド トランジション](https://reference.aspose.com/slides/ja/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)を有効または無効にする個別のオプションが提供されています。

### コメントの出力はサポートされていますか？また、スライドに対してどこに配置できますか？

はい、HTML5 にコメントを追加でき、[レイアウト設定](https://reference.aspose.com/slides/ja/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)を使用してスライドの右側など任意の位置に配置できます。

### セキュリティや CSP の理由で JavaScript を呼び出すリンクをスキップできますか？

はい、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップする[設定](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-)があります。これにより、厳格なセキュリティ ポリシーへの準拠が容易になります。