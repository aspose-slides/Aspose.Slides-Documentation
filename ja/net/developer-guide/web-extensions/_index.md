---
title: 新しい HTML エクスポート システム - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /ja/net/web-extensions/
keywords:
- Web拡張機能
- テンプレートエンジン
- PowerPoint のエクスポート
- OpenDocument のエクスポート
- プレゼンテーションのエクスポート
- スライドのエクスポート
- PPT のエクスポート
- PPTX のエクスポート
- ODP のエクスポート
- PowerPoint から HTML への変換
- OpenDocument から HTML への変換
- プレゼンテーションから HTML への変換
- スライドから HTML への変換
- PPT から HTML への変換
- PPTX から HTML への変換
- ODP から HTML への変換
- .NET
- C#
- Aspose.Slides
description: "テンプレート、CSS、JS を使用してプレゼンテーションを HTML にエクスポート（SVG なし）。シングルページまたはマルチページの出力、リソース管理、PPT、PPTX、ODP のカスタマイズ方法を学べます。"
---

## はじめに

* 以前の Aspose.Slides API ビルドでは、PowerPoint を HTML にエクスポートすると、生成された HTML が SVG マークアップと HTML を組み合わせた形で表現されました。各スライドは SVG コンテナとしてエクスポートされました。  
* 新しい Aspose.Slides バージョンでは、WebExtensions システムを使用して PowerPoint プレゼンテーションを HTML にエクスポートする際に、HTML エクスポート設定をカスタマイズして最適な結果を得ることができます。  

新しい WebExtensions システムを使うと、SVG を使用せずに CSS クラスと JavaScript アニメーションのセットでプレゼンテーション全体を HTML にエクスポートできます。新しいエクスポートシステムは、エクスポートプロセスを定義する無制限のオプションとメソッドも提供します。  

WebExtensions システムは、次のようなケースやイベントでプレゼンテーションから HTML を生成するために使用されます。

* カスタム CSS スタイルやアニメーションを使用する場合、特定のシェイプタイプのマークアップを上書きする場合。  
* ドキュメント構造を上書きする場合（例: カスタムナビゲーションを使用したページ間遷移）。  
* .html、.css、.js ファイルをカスタマイズされた階層構造のフォルダーに保存する場合。たとえば、セクション名に基づいたフォルダーにスライドをエクスポートするといったシナリオです。  
* デフォルトで CSS と JS ファイルを別々のフォルダーに保存し、HTML ファイルに追加する場合。画像や埋め込みフォントも別ファイルとして保存されますが、HTML に base64 形式で埋め込むことも可能です。リソースの一部をファイルに保存し、他のリソースは HTML に base64 で埋め込むことができます。  

PowerPoint から HTML へのサンプルは、GitHub の [Aspose.Slides.WebExtensions プロジェクト](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) で確認できます。このプロジェクトは **Examples\\SinglePageApp** と **Examples\\MultiPageApp** の 2 部構成です。この記事で使用した他のサンプルも同リポジトリにあります。  

### **テンプレート**

HTML エクスポート機能をさらに拡張するには、ASP.NET Razor テンプレートシステムの使用を推奨します。`Presentation` クラスのインスタンスは、テンプレートのセットと組み合わせて HTML ドキュメントをエクスポート結果として取得できます。  

**デモンストレーション**

この例では、プレゼンテーションのテキストを HTML にエクスポートします。まずテンプレートを作成します:
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

このテンプレートはディスク上に **shape-template-hello-world.html** として保存され、次のステップで使用されます。  

テンプレートでは、プレゼンテーションのシェイプ内のテキストフレームを走査してテキストを表示します。`WebDocument` を使用して HTML ファイルを生成し、プレゼンテーションをそのファイルにエクスポートします: 
``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Razor テンプレートエンジンを使用します。ITemplateEngine を実装すれば他のテンプレートエンジンも使用可能です
        OutputSaver = new FileOutputSaver() // IOutputSaver インターフェイスを実装すれば他の結果セーバーも使用可能です
    };
    WebDocument document = new WebDocument(options);

    // ドキュメントの「input」追加 - HTML ドキュメント生成に使用するソース
    document.Input
        .AddTemplate<Presentation>( // テンプレートは Presentation を「モデル」オブジェクト (Model.Object) として使用します
        "index", // テンプレートキー - テンプレートエンジンがオブジェクト (Presentation) とディスクから読み込まれたテンプレート ("shape-template-hello-world.html") を紐付けるために必要です
        @"custom-templates\shape-template-hello-world.html"); // 以前作成したテンプレート
                
    // 出力の追加 - エクスポート時にディスク上に生成される HTML ドキュメントの形状
    document.Output.Add(
        "hello-world.html", // 出力ファイルパス
        "index", // このファイルに使用されるテンプレートキー（前のステートメントで設定したもの）
        pres); // 実際の Model.Object インスタンス
                
    document.Save();
}
```


たとえば、エクスポート結果のテキスト色を赤に変更する CSS スタイルを追加したい場合、次の CSS テンプレートを追加します:
``` css
.text {
    color: red;
}
```


続いて入力と出力に組み込みます:
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


テンプレートの **text** クラスにスタイル参照を追加します:
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```


### **デフォルトテンプレート**

WebExtensions は、プレゼンテーションを HTML にエクスポートするための基本テンプレートを 2 組提供します。  
* **シングルページ**: プレゼンテーション全体のコンテンツが 1 つの HTML ファイルにエクスポートされ、画像・フォント・スタイル等のリソースは別ファイルに出力されます。  
* **マルチページ**: 各スライドが個別の HTML ファイルにエクスポートされます。リソースのエクスポートロジックはシングルページと同様です。  

`PresentationExtensions` クラスを使用すると、テンプレートを利用したプレゼンテーションのエクスポートが簡素化されます。`PresentationExtensions` には `Presentation` クラス向けの拡張メソッドが多数用意されています。シングルページにエクスポートするには、`Aspose.Slides.WebExtensions` 名前空間をインクルードし、2 つのメソッドを呼び出します。最初の `ToSinglePageWebDocument` が `WebDocument` インスタンスを作成し、次のメソッドで HTML を保存します: 
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```


`ToSinglePageWebDocument` メソッドは、テンプレートフォルダーとエクスポートフォルダーの 2 つのパラメーターを受け取ります。  

マルチページにエクスポートする場合は、同じパラメーターで `ToMultiPageWebDocument` メソッドを使用します:
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```


WebExtensions では、マークアップ生成に使用される各テンプレートがキーにバインドされています。キーはテンプレート内で参照可能です。たとえば `@Include` ディレクティブで、キーを指定して別テンプレートを挿入できます。  

テキスト部分テンプレートを段落テンプレート内で使用する例を示します。サンプルは Aspose.Slides.WebExtensions プロジェクトの **Templates\\common\\paragraph.html** にあります: [Templates\\common\\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html)。段落内の部分を描画するために、Razor Engine の `@foreach` ディレクティブで走査します:
``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```


各部分には独自のテンプレート **portion.html** があり、モデルが生成されて **paragraph.html** の出力に追加されます:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```


シェイプタイプごとにカスタムテンプレートを使用し、これらは Aspose.Slides.WebExtensions プロジェクトの共通テンプレートセットに追加されます。`ToSinglePageWebDocument` と `ToMultiPageWebDocument` で結合され、最終結果が生成されます。以下はシングルページ・マルチページ共通で使用されるテンプレート構成です。

-templates
+-common
  ¦ +-scripts: スライド遷移アニメーション用の JavaScript スクリプト。
  ¦ +-styles: 共通 CSS スタイル。
  +-multi-page: マルチページ出力用の index、menu、slide テンプレート。
  +-single-page: シングルページ出力用の index、slide テンプレート。

`PresentationExtensions.AddCommonInputOutput` メソッドで共通部分がすべてのテンプレートにバインドされる仕組みは [こちら](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs) で確認できます。  

### **デフォルトテンプレートのカスタマイズ**

共通モデルのテンプレートの任意の要素を変更できます。たとえば、テーブルの書式スタイルは変更したいが、シングルページの他のスタイルはそのままにしたい場合です。  

デフォルトでは **Templates\\common\\table.html** が使用され、テーブルは PowerPoint の外観と同じになります。ここでカスタム CSS スタイルでテーブル書式を変更します:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```


`PresentationExtensions.ToSinglePageWebDocument` メソッドを呼び出す際に、同じ入力テンプレート構造と出力ファイル構造を生成しつつ、`ExportCustomTableStyles_AddCommonStructure` メソッドを追加します。このメソッドは標準のテーブルテンプレートとメインインデックスページを追加しません（カスタムテーブルスタイルへの参照を含める形で置き換えられます）:
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


代わりにカスタムテンプレートを追加します:
``` csharp
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

    // グローバルドキュメント値を設定
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // 共通構造を追加（テーブルテンプレートを除く）
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // カスタムテーブルテンプレートを追加
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // カスタムテーブルスタイルを追加
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // カスタムインデックスを追加 - 標準の "index.html" のコピーですが、"table-custom-style.css" への参照が含まれます
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


**注意**: カスタムテーブルテンプレートは標準テーブルと同じ “table” キーで追加されました。そのため、既定のテンプレートを上書きして置き換えることが可能です。既定構造のテンプレートも同じキーで使用できます。たとえば、テーブルテンプレート内で標準の段落テンプレートを使用したり、キーで置き換えたりできます。`index.html` にカスタムテーブル CSS スタイルへの参照を組み込むことも可能です: 
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


## **プロジェクトの作成: アニメーション付きスライド遷移**

WebExtensions では、スライド遷移にアニメーションを付与したプレゼンテーションをエクスポートできます。`WebDocumentOptions` の `AnimateTransitions` プロパティを `true` に設定するだけです:
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... 他のオプション
    AnimateTransitions = true
};
```


ここでは、Aspose.Slides と Aspose.Slides.WebExtensions を使用して、PDF から滑らかなページ遷移付き HTML ビューアを作成する新規プロジェクトを作ります。PDF のインポート機能を利用します。

PdfToPresentationToHtml プロジェクトを作成し、Aspose.Slides.WebExtensions NuGet パッケージ（依存関係として Aspose.Slides も追加）を導入します:
![NuGet Package](screen.png)

まず PDF ドキュメントをインポートします。インポートされたページはアニメーション付きで HTML プレゼンテーションにエクスポートされます:
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```


次に、スライド遷移（各スライドはインポートされた PDF ページ）を設定します。サンプル PDF には 9 ページあり、各ページに遷移を追加します（HTML 表示時のデモ）:
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


最後に、`AnimateTransitions` プロパティを `true` にした `WebDocument` で HTML にエクスポートします:
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


完全なサンプルコード:
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


これで PDF から生成されたアニメーション付きページ遷移の HTML が完成です。  

* [サンプル HTML ファイルをダウンロード](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples)  
* [サンプルプロジェクトをダウンロード](/slides/ja/net/web-extensions/sample.zip)