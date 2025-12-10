---
title: 新しい HTML エクスポート システム - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /ja/net/web-extensions/
keywords:
- Web 拡張機能
- テンプレート エンジン
- PowerPoint のエクスポート
- OpenDocument のエクスポート
- プレゼンテーションのエクスポート
- スライドのエクスポート
- PPT のエクスポート
- PPTX のエクスポート
- ODP のエクスポート
- PowerPoint から HTML への変換
- OpenDocument から HTML への変換
- プレゼンテーションを HTML に変換
- スライドを HTML に変換
- PPT を HTML に変換
- PPTX を HTML に変換
- ODP を HTML に変換
- .NET
- C#
- Aspose.Slides
description: "テンプレート、CSS、JS を使用してプレゼンテーションを HTML にエクスポート（SVG なし）。シングルページまたはマルチページ出力、リソース管理、PPT、PPTX、ODP のカスタマイズ方法を学びましょう。"
---

## **はじめに**

* 旧バージョンの Aspose.Slides API では、PowerPoint を HTML にエクスポートすると、生成された HTML は SVG マークアップと HTML が組み合わされた形で表現されました。各スライドは SVG コンテナとしてエクスポートされました。  
* 新しい Aspose.Slides バージョンでは、PowerPoint プレゼンテーションを HTML にエクスポートするために WebExtensions システムを使用すると、HTML エクスポート設定をカスタマイズして最適な結果を得ることができます。  

新しい WebExtensions システムを使用すると、SVG なしで CSS クラスと JavaScript アニメーションのセットを用いてプレゼンテーション全体を HTML にエクスポートできます。新しいエクスポートシステムは、エクスポートプロセスを定義する無制限のオプションとメソッドも提供します。  

WebExtensions システムは、以下のケースやイベントでプレゼンテーションから HTML を生成するために使用されます。

* カスタム CSS スタイルやアニメーションを使用する場合、特定の形状タイプのマークアップを上書きする場合。  
* ドキュメント構造を上書きする場合（例: ページ間のカスタムナビゲーションを使用）。  
* .html、.css、.js ファイルをカスタマイズされた階層でフォルダーに保存する場合。例として、セクション名に基づいてスライドをフォルダーにエクスポートします。  
* デフォルトで CSS と JS を別々のフォルダーに保存し、HTML ファイルに追加する場合。画像や埋め込みフォントも別ファイルとして保存されますが、HTML に埋め込む（base64 形式）ことも可能です。リソースの一部をファイルに保存し、残りを base64 で HTML に埋め込むことができます。  

PowerPoint から HTML への例は GitHub の [Aspose.Slides.WebExtensions プロジェクト](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/)で確認できます。このプロジェクトは **Examples\SinglePageApp** と **Examples\MultiPageApp** の 2 部構成です。この記事で使用した他の例も GitHub リポジトリで見つけられます。  

### **テンプレート**

HTML エクスポート機能をさらに拡張するには、ASP.NET Razor テンプレートシステムの使用を推奨します。 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスは、テンプレートのセットと組み合わせて HTML ドキュメントをエクスポート結果として取得できます。

**デモンストレーション**

この例では、プレゼンテーションからテキストを HTML にエクスポートします。まずテンプレートを作成しましょう。
``` html
<!DOCTYPE html>
<body>
    @foreach (Slide slide in Model.Object.Slides)    
    {
        foreach (Shape shape in slide.Shapes)
        {
            if(shape is AutoShape)
            {
                ITextFrame textFrame = ((AutoShape)shape).TextFrame;
                <div class="text">@textFrame.Text</div>
            }
        }
    }
</body>
</html>
```

このテンプレートはディスク上に **shape-template-hello-world.html** という名前で保存され、次のステップで使用されます。

このテンプレートでは、プレゼンテーションのシェイプ内のテキストフレームを列挙してテキストを表示します。`WebDocument` を使用して HTML ファイルを生成し、`Presentation` をそのファイルにエクスポートします。  
``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Razor テンプレートエンジンを使用する予定です。ITemplateEngine を実装することで他のテンプレートエンジンも使用できます  
        OutputSaver = new FileOutputSaver() // IOutputSaver インターフェイスを実装することで他の結果保存機能も使用できます
    };
    WebDocument document = new WebDocument(options);

    // ドキュメント "input" を追加 - HTML ドキュメント生成に使用するソースは何か
    document.Input
        .AddTemplate<Presentation>( // テンプレートは Presentation を "model" オブジェクト (Model.Object) として持ちます 
        "index", // テンプレートキー - テンプレートエンジンがオブジェクト (Presentation) とディスクから読み込んだテンプレート ("shape-template-hello-world.html") を一致させるために必要です  
        @"custom-templates\shape-template-hello-world.html"); // 以前作成したテンプレート
                
    // 出力を追加 - エクスポート時に生成される HTML ドキュメントの形
    document.Output.Add(
        "hello-world.html", // 出力ファイルパス
        "index", // このファイルに使用されるテンプレートキー（前のステートメントで設定しました）  
        pres); // 実際の Model.Object インスタンス 
                
    document.Save();
}
```


例えば、エクスポート結果のテキスト色を赤に変更する CSS スタイルを追加したい場合、CSS テンプレートを追加します。  
``` css
.text {
    color: red;
}
```


次に、入力と出力にそれを組み込みます。  
``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions { TemplateEngine = new RazorTemplateEngine(), OutputSaver = new FileOutputSaver() };
    WebDocument document = new WebDocument(options);

    document.Input.AddTemplate<Presentation>("index", @"custom-templates\shape-template-hello-world.html");
    document.Input.AddTemplate<Presentation>("styles", @"custom-templates\styles\shape-template-hello-world.css");
    document.Output.Add("hello-world.html", "index", pres); 
    document.Output.Add("hello-world.css", "styles", pres);
                
    document.Save();
}
```


テンプレートとクラス **text** にスタイル参照を追加します。  
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```


### **デフォルトテンプレート**

WebExtensions はプレゼンテーションを HTML にエクスポートするための基本テンプレートを 2 套提供します。

* **シングルページ**: すべてのプレゼンテーションコンテンツが 1 つの HTML ファイルにエクスポートされ、画像・フォント・スタイルなどのリソースは別ファイルとして出力されます。  
* **マルチページ**: 各スライドが個別の HTML ファイルにエクスポートされます。リソースのエクスポートロジックはシングルページと同様です。  

`PresentationExtensions` クラスはテンプレートを使用したプレゼンテーションのエクスポートプロセスを簡素化します。`PresentationExtensions` クラスは `Presentation` クラス向けの拡張メソッドを多数提供しています。シングルページにエクスポートするには、`Aspose.Slides.WebExtensions` 名前空間をインクルードし、2 つのメソッドを呼び出すだけです。最初のメソッド `ToSinglePageWebDocument` が `WebDocument` インスタンスを作成し、2 番目のメソッドが HTML ドキュメントを保存します。  
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```


`ToSinglePageWebDocument` メソッドは「テンプレート フォルダー」と「エクスポート フォルダー」の 2 つのパラメーターを受け取れます。  

マルチページにエクスポートするには、同じパラメーターで `ToMultiPageWebDocument` メソッドを使用します。  
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```


WebExtensions では、マークアップ生成に使用される各テンプレートがキーにバインドされます。そのキーはテンプレート内で使用できます。例えば `@Include` ディレクティブでは、キーで指定したテンプレートを別のテンプレートに挿入できます。  

テキストのポーションテンプレート使用例は、Aspose.Slides.WebExtensions プロジェクトの [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html) にあります。段落内のポーションを描画するために、Razor Engine の `@foreach` ディレクティブで列挙します。  
``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```


ポーションは独自のテンプレート [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) を持ち、モデルが生成されます。そのモデルは出力の `paragraph.html` テンプレートに追加されます。  
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```


シェイプタイプごとにカスタムテンプレートを使用し、Aspose.Slides.WebExtensions プロジェクトの一般テンプレートセットに追加します。`ToSinglePageWebDocument` と `ToMultiPageWebDocument` メソッドでこれらのテンプレートが結合され、最終結果が生成されます。以下はシングルページとマルチページの両方で使用される共通テンプレートです。

-templates  
+-common  
  ¦ +-scripts: スライド遷移アニメーション用 JavaScript スクリプト  
  ¦ +-styles: 共通 CSS スタイル  
  +-multi-page: マルチページ出力用の index、menu、slide テンプレート  
  +-single-page: シングルページ出力用の index、slide テンプレート  

`PresentationExtensions.AddCommonInputOutput` メソッドで共通部分がすべてのテンプレートにバインドされている様子は [こちら](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs) を参照してください。  

### **デフォルトテンプレートのカスタマイズ**

共通モデルのテンプレート内の任意の要素を修正できます。例えば、テーブルの書式スタイルは変更したいが、シングルページの他のスタイルはそのままにしたい場合などです。  

既定では `Templates\common\table.html` が使用され、テーブルは PowerPoint の外観と同じになります。カスタム CSS スタイルでテーブルの書式を変更してみましょう。  
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```


`PresentationExtensions.ToSinglePageWebDocument` を呼び出しながら、入力テンプレートと出力ファイルの同一構造を作成できます。そのために `ExportCustomTableStyles_AddCommonStructure` メソッドを追加します。このメソッドは標準のテーブルテンプレートとメイン index ページを追加しません（カスタムテーブルスタイルへの参照を含めるように置き換えられます）。  
``` csharp
private static void ExportCustomTableStyles_AddCommonStructure(
    Presentation pres, 
    WebDocument document,
    string templatesPath, 
    string outputPath, 
    bool embedImages)
{
    AddCommonStylesTemplates(document, templatesPath);
            
    document.Input.AddTemplate<Slide>("slide", Path.Combine(templatesPath, "slide.html"));
    document.Input.AddTemplate<AutoShape>("autoshape", Path.Combine(templatesPath, "autoshape.html"));
    document.Input.AddTemplate<TextFrame>("textframe", Path.Combine(templatesPath, "textframe.html"));
    document.Input.AddTemplate<Paragraph>("paragraph", Path.Combine(templatesPath, "paragraph.html"));
    document.Input.AddTemplate<Paragraph>("bullet", Path.Combine(templatesPath, "bullet.html"));
    document.Input.AddTemplate<Portion>("portion", Path.Combine(templatesPath, "portion.html"));
    document.Input.AddTemplate<VideoFrame>("videoframe", Path.Combine(templatesPath, "videoframe.html"));
    document.Input.AddTemplate<PictureFrame>("pictureframe", Path.Combine(templatesPath, "pictureframe.html")); ;
    document.Input.AddTemplate<Shape>("shape", Path.Combine(templatesPath, "shape.html"));

    AddSinglePageCommonOutput(pres, document, outputPath);
            
    AddResourcesOutput(pres, document, embedImages);
            
    AddScriptsOutput(document, templatesPath);
}
```


代わりにカスタムテンプレートを追加します。  
```csharp
using (Presentation pres = new Presentation("table.pptx"))
{
    const string templatesPath = "templates\\single-page";
    const string outputPath = "custom-table-styles";
                
    var options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        EmbedImages = false
    };

    // グローバルドキュメントの値を設定
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // 共通構造を追加（テーブルテンプレートを除く）
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // カスタムテーブルテンプレートを追加
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // カスタムテーブルスタイルを追加
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // カスタムインデックスを追加 - 標準の "index.html" のコピーで、"table-custom-style.css" への参照が含まれています
    document.Input.AddTemplate<Presentation>("index", @"custom-templates\index-table-custom-style.html");
                
    document.Save();
}
```

``` html
@model TemplateContext<Table>

@{
	Table contextObject = Model.Object;
	
	var origin = Model.Local.Get<Point>("origin");
	var positionStyle = string.Format("left: {0}px; top: {1}px; width: {2}px; height: {3}px;",
										(int)contextObject.X + origin.X,
										(int)contextObject.Y + origin.Y,
										(int)contextObject.Width,
										(int)contextObject.Height);
}

	<table class="table custom-table" style="@positionStyle">
	@for (int i = 0; i < contextObject.Rows.Count; i++)
	{
		var rowHeight = string.Format("height: {0}px", contextObject.Rows[i].Height);
		<tr style="@rowHeight">
		@for (int j = 0; j < contextObject.Columns.Count; j++)
		{
			var cell = contextObject[j, i];
			if (cell.FirstRowIndex ==  i && cell.FirstColumnIndex == j)
			{
				var spans = cell.IsMergedCell ? string.Format("rowspan=\"{0}\" colspan=\"{1}\"", cell.RowSpan, cell.ColSpan) : "";
				<td width="@cell.Width px" @Raw(spans)>
					@{
						for(int k = 0; k < cell.TextFrame.Paragraphs.Count; k++)
						{
							var para = (Paragraph)cell.TextFrame.Paragraphs[k];
						
							var subModel = Model.SubModel(para);
							double[] margins = new double[] { cell.MarginLeft, cell.MarginTop, cell.MarginRight, cell.MarginBottom };
							subModel.Local.Put("margins", margins);
							subModel.Local.Put("parent", cell.TextFrame);
							subModel.Local.Put("parentContainerSize", new SizeF((float)cell.Width, (float)cell.Height));
                            subModel.Local.Put("tableContent", true);
							
							@Include("paragraph", subModel)
						}
					}
				</td>
			}
		}
		</tr>
	}
</table>
```


**注意** カスタムテーブルテンプレートは標準テーブルと同じ “table” キーで追加されました。そのため、既定テンプレートを上書きして再記述せずに置き換えることができます。同じキーを持つデフォルト構造のテンプレートも利用可能です。例えば、テーブルテンプレート内で標準の段落テンプレートを使用したり、キーで置き換えたりできます。  
`index.html` にカスタムテーブル CSS スタイルへの参照を組み込むことも可能です。  
``` html
<!DOCTYPE html>    
    
<html     
    xmlns="http://www.w3.org/1999/xhtml"    
    xmlns:svg="http://www.w3.org/2000/svg"    
    xmlns:xlink="http://www.w3.org/1999/xlink">    
<head>    
     ...
    <link rel="stylesheet" type="text/css" href="table-custom-style.css" />
    ...
</head>    
<body>    
    ...
</body>
</html>
```


## **スクラッチからプロジェクトを作成: アニメーションスライド遷移**

WebExtensions を使用すれば、スライド遷移にアニメーションを付与したプレゼンテーションをエクスポートできます。`WebDocumentOptions` の `AnimateTransitions` プロパティを `true` に設定するだけです。  
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... その他のオプション
    AnimateTransitions = true
};
```


Aspose.Slides と Aspose.Slides.WebExtensions を利用し、PDF 用の HTML ビューアを滑らかなアニメーションページ遷移付きで作成する新規プロジェクトを作成しましょう。ここでは Aspose.Slides の PDF インポート機能を使用します。  

PdfToPresentationToHtml プロジェクトを作成し、Aspose.Slides.WebExtensions NuGet パッケージを追加します（Aspose.Slides パッケージも依存関係として自動で追加されます）。  
![NuGet Package](screen.png)

まず PDF ドキュメントをインポートします。この PDF はアニメーション化され、HTML プレゼンテーションとしてエクスポートされます。  
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```


次に、アニメーションスライド遷移を設定します（各スライドはインポートした PDF ページに対応）。サンプル PDF では 9 枚のスライドが使用されています。各スライドに遷移効果を追加してみましょう（HTML を表示しながらのデモ）。  
``` csharp
pres.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
pres.Slides[1].SlideShowTransition.Type = TransitionType.RandomBar;
pres.Slides[2].SlideShowTransition.Type = TransitionType.Cover;
pres.Slides[3].SlideShowTransition.Type = TransitionType.Dissolve;
pres.Slides[4].SlideShowTransition.Type = TransitionType.Switch;
pres.Slides[5].SlideShowTransition.Type = TransitionType.Pan;
pres.Slides[6].SlideShowTransition.Type = TransitionType.Ferris;
pres.Slides[7].SlideShowTransition.Type = TransitionType.Pull;
pres.Slides[8].SlideShowTransition.Type = TransitionType.Plus;
```


最後に、`AnimateTransitions` プロパティを `true` に設定した `WebDocument` を使って HTML にエクスポートします。  
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    TemplateEngine = new RazorTemplateEngine(),
    OutputSaver = new FileOutputSaver(),
    AnimateTransitions = true
};

WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "animated-pdf");
document.Save();
```


完全なソースコード例:  
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
    pres.Slides[1].SlideShowTransition.Type = TransitionType.RandomBar;
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Cover;
    pres.Slides[3].SlideShowTransition.Type = TransitionType.Dissolve;
    pres.Slides[4].SlideShowTransition.Type = TransitionType.Switch;
    pres.Slides[5].SlideShowTransition.Type = TransitionType.Pan;
    pres.Slides[6].SlideShowTransition.Type = TransitionType.Ferris;
    pres.Slides[7].SlideShowTransition.Type = TransitionType.Pull;
    pres.Slides[8].SlideShowTransition.Type = TransitionType.Plus;

    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        AnimateTransitions = true
    };

    WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "animated-pdf");
    document.Save();
}
```


以上で、PDF ドキュメントから生成されたアニメーションページ遷移付き HTML を作成する手順は完了です。  

* [サンプル HTML ファイルをダウンロード](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples)  
* [サンプルプロジェクトをダウンロード](/slides/ja/net/web-extensions/sample.zip)