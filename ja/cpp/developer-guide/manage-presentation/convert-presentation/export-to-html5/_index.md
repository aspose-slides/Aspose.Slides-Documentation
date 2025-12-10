---
title: C++でプレゼンテーションをHTML5に変換
linktitle: HTML5へのプレゼンテーション
type: docs
weight: 40
url: /ja/cpp/export-to-html5/
keywords:
- PowerPointをHTML5に変換
- OpenDocumentをHTML5に変換
- プレゼンテーションをHTML5に変換
- スライドをHTML5に変換
- PPTをHTML5に変換
- PPTXをHTML5に変換
- ODPをHTML5に変換
- PPTをHTML5として保存
- PPTXをHTML5として保存
- ODPをHTML5として保存
- PPTをHTML5にエクスポート
- PPTXをHTML5にエクスポート
- ODPをHTML5にエクスポート
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint と OpenDocument のプレゼンテーションをレスポンシブなHTML5にエクスポートします。書式設定、アニメーション、インタラクティブ性を保持します。"
---

{{% alert title="Info" color="info" %}}
[Aspose.Slides 21.9](/slides/ja/cpp/aspose-slides-for-cpp-21-9-release-notes/)で、HTML5 エクスポートのサポートを実装しました。
{{% /alert %}} 

ここでの HTML5 エクスポート プロセスにより、PowerPoint を HTML に変換できます。独自のテンプレートを使用することで、エクスポート プロセスと生成される HTML、CSS、JavaScript、アニメーション属性を定義する非常に柔軟なオプションを適用できます。 

## **PowerPoint を HTML5 にエクスポート**

この C++ コードは、プレゼンテーションを HTML5 にエクスポートする方法を示しています。
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```


{{% alert color="primary" %}} 
この場合、クリーンな HTML が得られます。 
{{% /alert %}}

このように、シェイプ アニメーションやスライド遷移の設定を指定することもできます。
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```


## **PowerPoint を HTML にエクスポート**

この C++ は、標準的な PowerPoint から HTML への変換プロセスを示しています。
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```


この場合、プレゼンテーションの内容は SVG を通じて以下のような形でレンダリングされます。
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
この方法で PowerPoint を HTML にエクスポートすると、SVG レンダリングのため、スタイルを適用したり特定の要素をアニメーション化したりすることができなくなります。 
{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

**Aspose.Slides** を使用すると、PowerPoint プレゼンテーションを HTML5 ドキュメントに変換でき、スライドはスライド ビュー モードで表示されます。この場合、生成された HTML5 ファイルをブラウザーで開くと、Web ページ上でスライド ビュー モードのプレゼンテーションが表示されます。 

この C++ コードは、PowerPoint を HTML5 スライドビューにエクスポートするプロセスを示しています。
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **コメント付き HTML5 ドキュメントへのプレゼンテーション変換**

PowerPoint のコメントは、スライド上の特定の要素に対してユーザーがメモやフィードバックを残すためのツールです。特に共同プロジェクトで有用で、複数のメンバーがメイン コンテンツを変更せずに提案や指摘を追加できます。各コメントには作成者の名前が表示され、誰がコメントしたかが容易に追跡できます。

例として、"sample.pptx" ファイルに保存された PowerPoint プレゼンテーションがあるとします。

![プレゼンテーション スライド上の 2 つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換するとき、出力ドキュメントにコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) クラスの `get_NotesCommentsLayouting` メソッドでコメントの表示パラメータを指定する必要があります。

以下のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 ドキュメントに変換します。
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


下の画像は "output.html" ドキュメントの例です。

![出力された HTML5 ドキュメント内のコメント](two_comments_html5.png)

## **FAQ**

**HTML5 でオブジェクト アニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) と [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) を個別に有効化または無効化するオプションが提供されています。

**コメントの出力はサポートされていますか？また、スライドに対してどの位置に配置できますか？**

はい、HTML5 でコメントを追加でき、ノートとコメントのレイアウト設定で（例としてスライドの右側など）配置することが可能です。

**セキュリティや CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、[setting](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) があり、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできます。これにより、厳格なセキュリティ ポリシーに準拠できます。