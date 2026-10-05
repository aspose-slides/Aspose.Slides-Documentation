---
title: ".NET でプレゼンテーションを HTML5 に変換"
linktitle: "プレゼンテーションから HTML5 へ"
type: docs
weight: 40
url: /ja/net/export-to-html5/
keywords:
- "PowerPoint を HTML5 に変換"
- "OpenDocument を HTML5 に変換"
- "プレゼンテーションを HTML5 に変換"
- "スライドを HTML5 に変換"
- "PPT を HTML5 に変換"
- "PPTX を HTML5 に変換"
- "ODP を HTML5 に変換"
- "PPT を HTML5 として保存"
- "PPTX を HTML5 として保存"
- "ODP を HTML5 として保存"
- "PPT を HTML5 にエクスポート"
- "PPTX を HTML5 にエクスポート"
- "ODP を HTML5 にエクスポート"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式設定、アニメーション、インタラクティブ性を保持します。"
---
## **概要**

本記事では、Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションを HTML5 に変換する方法を説明します。基本的なエクスポート、図形アニメーションとスライド遷移の制御、コメントのレイアウトについて解説します。また、HTML5 の出力と標準 HTML エクスポートの SVG ベース出力を比較します。

## **PowerPoint を HTML5 にエクスポート**

次のサンプルは、作業ディレクトリからプレゼンテーションを読み込み、HTML5 形式で保存します。デフォルトのエクスポート設定を使用しています。次の例では、アニメーションの再生を明示的に制御する方法を示します。入力パスはご自身のプレゼンテーションのパスに置き換えてください。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
HTML ドキュメントに加えて、エクスポートはスライドのスタイリング、アニメーション、エフェクト、ナビゲーション用の CSS および JavaScript ファイルを出力します。出力先を移動または公開する際は、これらのファイルを HTML ドキュメントと一緒に保持してください。生成されたページは、jQuery と Anime.js をパブリック CDN から読み込みます。これらが無いと、スライドのナビゲーションやアニメーションは動作しません。
{{% /alert %}}

シェイプアニメーションやスライド遷移を再生しないでエクスポートするには、[AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) と [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) を [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) で `false` に設定します。これらの設定は独立しているため、片方だけを有効にし、もう片方を無効にすることができます。以下の例では、生成されたページで両方のアニメーションを無効にした状態でプレゼンテーションをエクスポートしています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **PowerPoint を HTML にエクスポート**

標準の HTML エクスポートは別のレンダリング手法を使用します。スライドの内容は HTML ページ内の SVG として表現されます。次のサンプルは、このレンダリング手法を用いてプレゼンテーションを HTML ドキュメントに変換します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

以下の簡易マークアップは、生成されたページの構造を示しています。SVG 要素にはレンダリングされたスライド内容が含まれ、プレースホルダーのテキストはその内容を表すものであり、実際のエクスポート出力ではありません。

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
SVG ベースのエクスポートは、PowerPoint の図形を個別の HTML 要素として公開しません。この記事で示したシェイプアニメーションやスライド遷移のオプションが必要な場合は、HTML5 エクスポートを使用してください。
{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

HTML5 エクスポートは、ブラウザーでプレゼンテーションスライドを表示・ナビゲートするためのページを生成します。この例では、[AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) と [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) の両方を有効にし、エクスポートされたスライドビューが元のプレゼンテーションのエフェクトを再生できるようにしています。

シェイプアニメーションとスライド遷移がすでに含まれているプレゼンテーションを使用すると、これらの設定効果を確認できます。設定を有効にしても、アニメーションが設定されていないスライドには新しいエフェクトは追加されません。エクスポート後、サポートファイルが利用可能な状態でブラウザーで生成された HTML5 ドキュメントを開いてください。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **プレゼンテーションをコメント付き HTML5 ドキュメントに変換**

HTML5 出力に既存のスライドコメントを含めることができ、読者はスライド内容とともにフィードバックを見ることができます。このセクションのサンプルは、下図のようにコメントが含まれていることを前提としています。コメントをエクスポートしますが、新しいコメントは作成しません。

![プレゼンテーションスライド上の 2 つのコメント](two_comments_pptx.png)

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) オブジェクトを [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) の [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) プロパティに割り当てます。[CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) を列挙型 [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) の `Right` に設定し、各スライドの右側にコメントを配置します。

以下の例は、このコメントレイアウトを使用してプレゼンテーションを HTML5 にエクスポートします。コメントがないプレゼンテーションでは、表示するコメントテキストはありません。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

下図は、スライドの横にコメントが表示されたエクスポート済み HTML5 ドキュメントを示しています。

![出力された HTML5 ドキュメント内のコメント](two_comments_html5.png)

## **エクスポート時に JavaScript ハイパーリンクを除外**

`hyperlinks.pptx` に `javascript:alert('Hello')` ターゲットのリンクテキストと、通常の `https://example.com/` リンクが含まれているとします。エクスポート時に JavaScript ハイパーリンクを除外するには、[SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) を `true` に設定します。デフォルトは `false` であり、オプションを有効にしない限りこれらのリンクはフィルタリングされません。

次の例は、作業ディレクトリからプレゼンテーションを読み込み、[Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) を使用してエクスポートします。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

エクスポートされたファイルは JavaScript ハイパーリンクを除外しつつ、リンクテキストと通常の HTTPS リンクは保持します。元のプレゼンテーションは変更されません。

このオプションは JavaScript ハイパーリンクのみをフィルタリングし、すべてのスクリプトやその他のアクティブコンテンツを削除するわけでも、CSP 適合性を保証するわけでもありません。たとえば、HTML5 出力にはスライドのナビゲーションとアニメーション用のスクリプトが依然として含まれます。

## **FAQ**

**HTML5 でオブジェクトのアニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 エクスポートは [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) と [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) を個別に有効化または無効化できるオプションを提供します。

**コメントはサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、既存のコメントを HTML5 出力に含めることができ、[layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) を使用してスライドの右側など任意の位置に配置できます。

**セキュリティや CSP の観点から JavaScript を呼び出すリンクを除外できますか？**

はい、[SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) 設定により、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできます。デフォルトは `false` です。詳細とフィルタの対象範囲については、[Exclude JavaScript Hyperlinks During Export](/slides/ja/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) を参照してください。この設定は、ナビゲーションとアニメーション用に HTML5 ビューアが使用する JavaScript を削除するものではありません。