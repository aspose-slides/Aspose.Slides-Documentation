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
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument プレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---

{{% alert title="Info" color="info" %}}

[Aspose.Slides 21.9](/slides/ja/net/aspose-slides-for-net-21-9-release-notes/) では HTML5 エクスポートのサポートを実装しました。ただし、WebExtensions を使用して PowerPoint を HTML にエクスポートしたい場合は、代わりに [この記事](/slides/ja/net/web-extensions/) を参照してください。

{{% /alert %}} 

ここでの HTML5 エクスポートプロセスにより、WebExtensions や依存関係なしで PowerPoint を HTML に変換できます。この方法では、独自のテンプレートを使用して、エクスポートプロセスと生成される HTML、CSS、JavaScript、アニメーション属性を定義する非常に柔軟なオプションを適用できます。 

## **PowerPoint を HTML5 にエクスポート**

この C# コードは、WebExtensions および依存関係なしでプレゼンテーションを HTML5 にエクスポートする方法を示します:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 

この場合、クリーンな HTML が得られます。 

{{% /alert %}}

このようにして、シェイプ アニメーションやスライド遷移の設定を指定したい場合があります:
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

この C# は、標準的な PowerPoint から HTML へのプロセスを示しています:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```


この場合、プレゼンテーションの内容は SVG を介して次のような形でレンダリングされます:
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

この方法で PowerPoint を HTML にエクスポートすると、SVG 渲染のため、特定の要素にスタイルを適用したりアニメーションを付けたりすることができません。 

{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

**Aspose.Slides** を使用すると、PowerPoint プレゼンテーションをスライドがスライドビュー モードで表示される HTML5 ドキュメントに変換できます。この場合、生成された HTML5 ファイルをブラウザで開くと、ウェブページ上でスライドビュー モードのプレゼンテーションが表示されます。 

この C# コードは、PowerPoint を HTML5 スライドビューにエクスポートするプロセスを示しています:
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


## **コメント付きでプレゼンテーションを HTML5 ドキュメントに変換**

PowerPoint のコメントは、ユーザーがプレゼンテーション スライドにメモやフィードバックを残すためのツールです。特に共同プロジェクトでは、複数のユーザーがメインコンテンツを変更せずに特定のスライド要素に提案やコメントを追加できるため便利です。各コメントには作成者の名前が表示され、誰がコメントしたかを簡単に追跡できます。

例えば、次の PowerPoint プレゼンテーションが "sample.pptx" ファイルに保存されているとします。

![プレゼンテーション スライド上の 2 つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際、出力ドキュメントにコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) クラスの `NotesCommentsLayouting` プロパティでコメントの表示パラメータを指定する必要があります。

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


"output.html" ドキュメントは以下の画像に示されています。

![出力された HTML5 ドキュメントのコメント](two_comments_html5.png)

## **よくある質問**

**HTML5 でオブジェクト アニメーションとスライド遷移の再生を制御できますか？**

はい、HTML5 では [シェイプ アニメーション](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) と [スライド遷移](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) を有効または無効にする個別のオプションが用意されています。

**コメントの出力はサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、HTML5 ではコメントを追加でき、[レイアウト設定](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) を使用して（例としてスライドの右側に）配置できます。

**セキュリティや CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできる [設定](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) があり、厳格なセキュリティポリシーに対応するのに役立ちます。