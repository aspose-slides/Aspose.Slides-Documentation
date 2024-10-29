---
title: 新しいHTMLエクスポートシステム - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /ja/net/web-extensions/
keywords: "PowerPointをHTMLにエクスポート, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでのPowerPoint HTMLエクスポート"
---


## はじめに

* 古いAspose.Slides APIビルドでは、PowerPointをHTMLにエクスポートすると、結果として得られたHTMLはHTMLと組み合わされたSVGマークアップとして表現されました。各スライドはSVGコンテナとしてエクスポートされました。
* 新しいAspose.Slidesバージョンでは、WebExtensionsシステムを使用してPowerPointプレゼンテーションをHTMLにエクスポートすると、最適な結果を提供するためにHTMLエクスポート設定をカスタマイズできます。

新しいWebExtensionsシステムを使用すると、CSSクラスとJavaScriptアニメーションのセットを用いて、プレゼンテーション全体をHTMLにエクスポートできます（SVGなし）。新しいエクスポートシステムは、エクスポートプロセスを定義する無限のオプションとメソッドを提供します。

新しいWebExtensionsシステムは、次のケースやイベントでプレゼンテーションからHTMLを生成するために使用されます：

* カスタムCSSスタイルやアニメーションを使用する際；特定のタイプの図形のマークアップを上書きする。
* 文書の構造を上書きする際、例えば、ページ間のカスタムナビゲーションを使用する。
* .html、.css、.jsファイルをカスタマイズされた階層でフォルダーに保存する際、異なるフォルダーに特定のファイルタイプを含む。例えば、セクション名に基づいてスライドをフォルダーにエクスポートする。
* デフォルトでCSSとJSファイルを別々のフォルダーに保存し、その後HTMLファイルに追加する際。画像や埋め込まれたフォントも別々のファイルに保存されます。ただし、これらはHTMLファイルに埋め込むこともできます（base64形式）。リソースの一部をファイルに保存し、他のリソースをHTMLにbase64形式で埋め込むことができます。

PowerPointからHTMLへの例は、[Aspose.Slides.WebExtensionsプロジェクト](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/)のGitHubで確認できます。このプロジェクトは、**Examples\SinglePageApp**と**Examples\MultiPageApp**の2つの部分で構成されています。この記事で使用される他の例もGitHubリポで見つけることができます。

### **テンプレート**

HTMLエクスポートの機能をさらに拡張するために、ASP.NET Razorテンプレートシステムの使用をお勧めします。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスは、一連のテンプレートとともに使用して、エクスポート結果としてHTML文書を取得できます。

**デモンストレーション**

この例では、プレゼンテーションからHTMLにテキストをエクスポートします。まず、テンプレートを作成しましょう：

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
このテンプレートは「shape-template-hello-world.html」としてディスクに保存され、次のステップで使用されます。

このテンプレートでは、プレゼンテーションの図形内のテキストフレームを繰り返してテキストを表示しています。WebDocumentを使用してHTMLファイルを生成し、その後プレゼンテーションをファイルにエクスポートしましょう：

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Razorテンプレートエンジンを使用する意図があります。他のテンプレートエンジンはITemplateEngineを実装することで使用できます  
        OutputSaver = new FileOutputSaver() // 他の結果セーバーはIOutputSaverインターフェースを実装することで使用できます
    };
    WebDocument document = new WebDocument(options);

    // ドキュメント「入力」を追加します - HTMLドキュメントを生成するために使用されるソース
    document.Input
        .AddTemplate<Presentation>( // テンプレートはPresentationを「モデル」オブジェクト（Model.Object）として持ちます 
        "index", // テンプレートキー - テンプレートエンジンがオブジェクト（Presentation）をディスクから読み込んだテンプレートにマッチさせるために必要  
        @"custom-templates\shape-template-hello-world.html"); // 以前に作成したテンプレート
                
    // 出力を追加します - 結果のHTMLドキュメントがディスクにエクスポートされるときの見た目
    document.Output.Add(
        "hello-world.html", // 出力ファイルパス
        "index", // このファイルに使用されるテンプレートキー（前のステートメントで設定しました）  
        pres); // 実際のModel.Objectインスタンス 
                
    document.Save();
}
```

例えば、エクスポート結果にCSSスタイルを追加してテキストの色を赤に変更したいとします。CSSテンプレートを追加しましょう：

``` css
.text {
    color: red;
}
```

次に、これを入力と出力に追加します：

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

スタイルへの参照をテンプレートとクラス「text」に追加しましょう：
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **デフォルトテンプレート**

WebExtensionsは、プレゼンテーションをHTMLにエクスポートするための基本テンプレートを2セット提供します：
* シングルページ：すべてのプレゼンテーションコンテンツが1つのHTMLファイルにエクスポートされます。すべての他のリソース（画像、フォント、スタイルなど）は別々のファイルにエクスポートされます。
* マルチページ：各プレゼンテーションスライドが個別のHTMLファイルにエクスポートされます。リソースをエクスポートするためのデフォルトのロジックは、シングルページと同じです。 

`PresentationExtensions`クラスは、テンプレートを使用してプレゼンテーションエクスポートプロセスを簡素化するために使用できます。`PresentationExtensions`クラスは、Presentationクラスの拡張メソッドのセットを含みます。プレゼンテーションをシングルページにエクスポートするには、Aspose.Slides.WebExtensions名前空間を含め、2つのメソッドを呼び出すだけです。最初のメソッド、`ToSinglePageWebDocument`は、`WebDocument`インスタンスを作成します。2番目のメソッドはHTMLドキュメントを保存します： 

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

ToSinglePageWebDocumentメソッドは、テンプレートフォルダーとエクスポートフォルダーの2つのパラメータを取ることができます。

プレゼンテーションをマルチページにエクスポートするには、同じパラメータでToMultiPageWebDocumentメソッドを使用します：

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

WebExtensionsでは、マークアップ生成に使用される各テンプレートはキーにバインドされています。そのキーはテンプレート内で使用できます。例えば、@Includeディレクティブで、特定のテンプレートを別のテンプレートにキーで挿入できます。

テキスト部分テンプレートを段落テンプレート内で使用する手順を、例を通じて示すことができます。使用例はAspose.Slides.WebExtensionsプロジェクトで見つけることができます：[Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html)。段落内の部分を描画するために、Razorエンジンの@foreachディレクティブを使用してそれらを繰り返します：

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

Portionには独自のテンプレート[portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html)があり、そのためのモデルが生成されます。そのモデルは出力段落.htmlテンプレートに追加されます：
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

各図形タイプにはカスタムテンプレートを使用し、それをAspose.Slides.WebExtensionsプロジェクトの一般的なセットに追加します。テンプレートはToSinglePageWebDocumentおよびToMultiPageWebDocumentメソッド内で結合され、最終結果を提供します。これらはシングルページとマルチページの両方で使用される一般的なテンプレートです：

-templates
+-common
  ¦ +-scripts: スライド遷移アニメーションのためのJavaScriptスクリプトなど。
  ¦ +-styles: 共通のCSSスタイル。
  +-multi-page: マルチページ出力用のインデックス、メニュー、スライドテンプレート。
  +-single-page: シングルページ出力用のインデックス、スライドテンプレート。

`PresentationExtensions.AddCommonInputOutput`メソッド[こちら](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs)で、すべてのテンプレートに共通の部分がどのようにバインドされているかを確認できます。

### **デフォルトテンプレートのカスタマイズ**

共通モデルのテンプレート内の任意の要素を変更することができます。例えば、表の書式スタイルを変更することを決定したが、シングルページの他のすべてのスタイルを変更しないようにすることができます。

デフォルトでは、Templates\common\table.htmlが使用され、表はPowerPointの表と同じ外観を持ちます。カスタムCSSスタイルを使用して表の書式を変更しましょう：
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

`PresentationExtensions.ToSinglePageWebDocument`メソッドを呼び出す際に、同一の入力テンプレートと出力ファイルの構造を作成することができます。そのために、`ExportCustomTableStyles_AddCommonStructure`メソッドを追加しましょう。このメソッドと`ToSinglePageWebDocument`メソッドの違いは、標準の表およびメインインデックスページのテンプレートを追加する必要がないことです（カスタム表スタイルへの参照を含むように置き換えられます）：

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

代わりにカスタムテンプレートを追加しましょう：

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

    // グローバルドキュメント値を設定します
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // 共通構造を追加します（表テンプレートを除く）
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // カスタム表テンプレートを追加します
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // カスタム表スタイルを追加します
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // カスタムインデックスを追加します - それは単に標準の「index.html」のコピーですが、「table-custom-style.css」の参照を含みます
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

**注意**：カスタム表テンプレートは、標準の表と同じ「table」キーで追加されました。したがって、特定のデフォルトテンプレートを再作成せずに置き換えることができます。デフォルトの構造から同じキーを持つテンプレートを使用することもできます。例えば、表テンプレート内で標準の段落テンプレートを使用することができます。また、キーで置き換えることもできます。
index.htmlを使用してカスタムテーブルCSSスタイルへの参照を含めることもできます： 

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

## **プロジェクトをゼロから作成する：アニメーションスライド遷移**

WebExtensionsを使用すると、アニメーションスライド遷移を持つプレゼンテーションをエクスポートできます。`WebDocumentOptions`の`AnimateTransitions`プロパティを`true`に設定するだけです：

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... 他のオプション
    AnimateTransitions = true
};
```

アニメーション付きページ遷移のHTMLビューワーを作成するために、Aspose.SlidesとAspose.Slides.WebExtensionsを使用する新しいプロジェクトを作成しましょう。ここでは、Aspose.SlidesのPDFインポート機能を使用する必要があります。

PdfToPresentationToHtmlプロジェクトを作成し、Aspose.Slides.WebExtensions NuGetパッケージを追加します（Aspose.Slidesパッケージも依存関係として追加されます）：
![NuGetパッケージ](screen.png)

PDF文書をインポートし、それをアニメーションさせてHTMLプレゼンテーションにエクスポートすることから始めます：

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

次に、アニメーションスライド遷移を設定できます（各スライドはインポートされたPDFページです）。サンプルPDFドキュメントでは9つのスライドを使用しました。各スライドに遷移を追加します（HTMLを表示している間のデモ）：

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

最後に、`WebDocument`を使用してHTMLにエクスポートし、`AnimateTransitions`プロパティを`true`に設定します：

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

完全なソースコード例：
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

これで、PDFドキュメントから生成されたアニメーションページ遷移付きのHTMLを作成するために必要なすべての手順が完了しました。

* [サンプルHTMLファイルをダウンロード](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples)。
* [サンプルプロジェクトをダウンロード](/slides/ja/net/web-extensions/sample.zip)。