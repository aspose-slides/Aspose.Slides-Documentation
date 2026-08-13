---
title: .NET でプレゼンテーションを HTML5 に変換
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
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションを HTML5 に変換する方法を説明します。基本的な HTML5 エクスポートに加えて、図形アニメーションやスライド遷移を制御するオプションについても説明します。また、標準的な PowerPoint から HTML へのエクスポート手順、スライド表示モードで HTML5 を生成する方法、コメントのレイアウトを設定してエクスポートドキュメントに含める方法も示します。

## **PowerPoint を HTML5 にエクスポート**

この C# コードは、プレゼンテーションを HTML5 にエクスポートする方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 

HTML ドキュメントに加えて、エクスポートは参照されるサポートファイル `pres.css`、`master.css`、`animation.js`、`effects.js`、`navigation.js` も書き込みます。生成されたページは、パブリック CDN から jQuery と Anime.js を読み込みます。これらが無いと、スライドのナビゲーションやアニメーションが動作しません。 

{{% /alert %}}

以下のように、図形アニメーションとスライド遷移の設定を指定できます。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

この C# は、標準的な PowerPoint から HTML へのエクスポート手順を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

この場合、プレゼンテーションの内容は SVG を介して次のように描画されます。

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

この方法で PowerPoint を HTML にエクスポートすると、SVG 描画のため、特定の要素にスタイルを適用したりアニメーションを付加したりすることはできません。 

{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

**Aspose.Slides** を使用すると、PowerPoint プレゼンテーションを HTML5 ドキュメントに変換し、スライドをスライドビュー モードで表示できます。この場合、生成された HTML5 ファイルをブラウザーで開くと、Web ページ上でスライドビュー モードのプレゼンテーションが表示されます。 

この C# コードは、PowerPoint を HTML5 スライドビューにエクスポートする手順を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **コメント付きでプレゼンテーションを HTML5 ドキュメントに変換**

PowerPoint のコメントは、スライド上のノートやフィードバックを残すためのツールです。共同作業プロジェクトで特に有用で、複数のユーザーがメインコンテンツを変更せずに特定のスライド要素に対して提案や指摘を追加できます。各コメントは作者名を表示するため、誰がコメントしたかが容易に把握できます。

例えば、`sample.pptx` ファイルに保存された以下の PowerPoint プレゼンテーションがあるとします。

![Two comments on the presentation slide](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際に、出力ドキュメントにプレゼンテーションのコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/ja/net/aspose.slides.export/html5options/) クラスの `NotesCommentsLayouting` プロパティでコメントの表示パラメーターを設定します。

以下のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 ドキュメントに変換します。
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

下の画像は、`output.html` ドキュメントの表示例です。

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

### オブジェクトのアニメーションやスライド遷移を HTML5 で再生させるか制御できますか？

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/ja/net/aspose.slides.export/html5options/animateshapes/) と [slide transitions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/html5options/animatetransitions/) を有効化または無効化する個別のオプションが用意されています。

### コメントの出力はサポートされていますか？スライドに対してどの位置に配置できますか？

はい、HTML5 でコメントを追加でき、[layout settings](https://reference.aspose.com/slides/ja/net/aspose.slides.export/html5options/notescommentslayouting/) によってスライドの右側など任意の位置に配置できます。

### セキュリティや CSP の観点から、JavaScript を呼び出すリンクを除外できますか？

はい、保存時に JavaScript 呼び出しを含むハイパーリンクを除外する [setting](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) があり、厳格なセキュリティポリシーに対応できます。