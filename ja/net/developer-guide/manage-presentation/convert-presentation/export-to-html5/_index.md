---
title: プレゼンテーションを .NET で HTML5 に変換
linktitle: プレゼンテーションを HTML5 に変換
type: docs
weight: 40
url: /ja/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument プレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---

{{% alert title="Info" color="info" %}}

[Aspose.Slides 21.9](/slides/ja/net/aspose-slides-for-net-21-9-release-notes/)では、HTML5 エクスポートのサポートを実装しました。ただし、WebExtensions を使用して PowerPoint を HTML にエクスポートしたい場合は、代わりに[この記事](/slides/ja/net/web-extensions/)をご覧ください。

{{% /alert %}}

ここでの HTML5 エクスポートプロセスは、WebExtensions や外部依存関係なしで PowerPoint を HTML に変換できます。この方法では、独自のテンプレートを使用して、エクスポートプロセスと生成される HTML、CSS、JavaScript、アニメーション属性を柔軟に定義できます。

## **Export PowerPoint to HTML5**

この C# コードは、WebExtensions や依存関係なしでプレゼンテーションを HTML5 にエクスポートする方法を示しています:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 

この場合、クリーンな HTML が得られます。

{{% /alert %}}

このようにして、図形アニメーションやスライド遷移の設定を指定できます:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```


## **Export PowerPoint to HTML**

この C# は標準的な PowerPoint から HTML への変換プロセスを示しています:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```


この場合、プレゼンテーションのコンテンツは次のような形式の SVG を通じてレンダリングされます:
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

この方法で PowerPoint を HTML にエクスポートすると、SVG レンダリングのため、スタイルの適用や特定要素のアニメーションを行うことはできません。

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** を使用すると、スライドがスライドビュー モードで表示される HTML5 ドキュメントに PowerPoint プレゼンテーションを変換できます。この場合、ブラウザーで生成された HTML5 ファイルを開くと、Web ページ上でスライドビュー モードのプレゼンテーションが表示されます。

この C# コードは、PowerPoint から HTML5 スライドビューへのエクスポートプロセスを示しています:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```


## **Convert a Presentation to an HTML5 Document with Comments**

PowerPoint のコメントは、ユーザーがスライドにメモやフィードバックを残すためのツールです。共同プロジェクトで特に有用で、複数のメンバーがメインコンテンツを変更せずに特定のスライド要素に対して提案や指摘を追加できます。各コメントには作成者の名前が表示されるため、誰がコメントしたかがすぐに分かります。

例として、"sample.pptx" ファイルに保存された以下の PowerPoint プレゼンテーションを考えてみましょう。

![Two comments on the presentation slide](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際、出力ドキュメントにプレゼンテーションからのコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) クラスの `NotesCommentsLayouting` プロパティでコメントの表示パラメータを設定します。

以下のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 ドキュメントに変換します。
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```


下の画像は、生成された "output.html" ドキュメントです。

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**HTML5 でオブジェクトのアニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) と [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) を個別に有効化または無効化するオプションが用意されています。

**コメントの出力はサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、コメントは HTML5 で追加でき、[layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) を使用してスライドの右側など任意の位置に配置できます。

**セキュリティや CSP の観点から JavaScript を呼び出すリンクを除外できますか？**

はい、[setting](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) があり、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできます。これにより、厳格なセキュリティ ポリシーに準拠できます。