---
title: HTML5 にエクスポート
type: docs
weight: 40
url: /ja/net/export-to-html5/
keywords:
- PowerPoint を HTML に変換
- スライドを HTML に変換
- HTML5
- HTML エクスポート
- プレゼンテーションをエクスポート
- プレゼンテーションを変換
- スライドを変換
- C#
- C#
- Aspose.Slides for .NET
description: "C# または .NET で PowerPoint を HTML5 にエクスポート"
---

{{% alert title="情報" color="info" %}}

[Aspose.Slides 21.9](/slides/ja/net/aspose-slides-for-net-21-9-release-notes/) では HTML5 エクスポートのサポートを実装しました。ただし、WebExtensions を使用して PowerPoint を HTML にエクスポートしたい場合は、代わりに [この記事](/slides/ja/net/web-extensions/)をご参照ください。

{{% /alert %}}

ここでの HTML5 エクスポートプロセスは、WebExtensions や外部依存関係なしで PowerPoint を HTML に変換できます。独自のテンプレートを使用することで、エクスポートプロセスと生成される HTML、CSS、JavaScript、アニメーション属性を柔軟に定義するオプションを適用できます。

## **PowerPoint を HTML5 にエクスポート**

以下の C# コードは、WebExtensions や依存関係なしでプレゼンテーションを HTML5 にエクスポートする方法を示しています：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 

この場合、クリーンな HTML が取得できます。

{{% /alert %}}

このようにして、図形アニメーションやスライド遷移の設定を指定することもできます：
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


## **PowerPoint を HTML にエクスポート**

以下の C# は標準的な PowerPoint → HTML のプロセスを示しています：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```


この場合、プレゼンテーション内容は次のような SVG 形式で描画されます：
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```


{{% alert title="注意" color="warning" %}} 

この方法で PowerPoint を HTML にエクスポートすると、SVG 描画のため、特定の要素にスタイルを適用したりアニメーションさせたりすることはできません。

{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

**Aspose.Slides** を使用すると、スライドがスライドビュー モードで表示される HTML5 ドキュメントに PowerPoint プレゼンテーションを変換できます。この場合、生成された HTML5 ファイルをブラウザで開くと、Web ページ上でスライドビュー モードのプレゼンテーションが表示されます。

以下の C# コードは、PowerPoint を HTML5 スライドビューにエクスポートするプロセスを示しています：
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


## **コメント付き HTML5 ドキュメントへのプレゼンテーション変換**

PowerPoint のコメントは、スライド上の特定要素に対してメモやフィードバックを残すためのツールです。特に共同作業プロジェクトで有用で、複数のユーザーがメインコンテンツを変更せずに意見を追加できます。各コメントは作成者名を表示するため、誰がコメントしたかが容易に把握できます。

たとえば、"sample.pptx" ファイルに保存された次の PowerPoint プレゼンテーションがあるとします。

![プレゼンテーションスライドの 2 つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際に、コメントを出力ドキュメントに含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) クラスの `NotesCommentsLayouting` プロパティでコメントの表示パラメータを指定します。

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


以下の画像は、生成された "output.html" ドキュメントです。

![出力された HTML5 ドキュメント内のコメント](two_comments_html5.png)

## **FAQ**

**HTML5 でオブジェクトのアニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) と [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) を個別に有効化または無効化するオプションが用意されています。

**コメントの出力はサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、HTML5 でコメントを追加でき、[layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) を使用してスライドの右側など任意の位置に配置できます。

**セキュリティまたは CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、[setting](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) により、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできます。これにより、厳格なセキュリティポリシーへの準拠が容易になります。