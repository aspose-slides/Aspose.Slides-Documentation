---
title: プレゼンテーションを C++ で HTML5 に変換
linktitle: HTML5 へのプレゼンテーション
type: docs
weight: 40
url: /ja/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint および OpenDocument プレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---

{{% alert title="情報" color="info" %}}

[Aspose.Slides 21.9](/slides/ja/cpp/aspose-slides-for-cpp-21-9-release-notes/) で HTML5 エクスポートのサポートを実装しました。

{{% /alert %}} 

ここでの HTML5 エクスポートプロセスにより、PowerPoint を HTML に変換できます。独自のテンプレートを使用して、エクスポートプロセスと生成される HTML、CSS、JavaScript、アニメーション属性を定義する非常に柔軟なオプションを適用できます。

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

シェイプのアニメーションやスライド遷移の設定をこのように指定することもできます：
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

この C++ は標準的な PowerPoint から HTML へのプロセスを示しています：
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```


この場合、プレゼンテーションのコンテンツは次のような形式で SVG を介してレンダリングされます：
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

この方法で PowerPoint を HTML にエクスポートすると、SVG レンダリングのため、特定の要素にスタイルを適用したりアニメーションを付けたりすることはできません。

{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

**Aspose.Slides** は、スライドがスライド ビュー モードで表示される HTML5 ドキュメントに PowerPoint プレゼンテーションを変換できるようにします。この場合、生成された HTML5 ファイルをブラウザーで開くと、Web ページ上でスライド ビュー モードのプレゼンテーションが表示されます。

この C++ コードは、PowerPoint から HTML5 スライド ビューへのエクスポートプロセスを示しています：
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **コメント付き HTML5 ドキュメントへのプレゼンテーション変換**

PowerPoint のコメントは、プレゼンテーション スライドにメモやフィードバックを残すためのツールです。特に共同プロジェクトで役立ち、複数のユーザーがメイン コンテンツを変更せずに特定のスライド要素に提案やコメントを追加できます。各コメントには作者名が表示され、誰がコメントしたかが一目で分かります。

次のような PowerPoint プレゼンテーションが「sample.pptx」ファイルに保存されているとします。

![プレゼンテーションスライドの2つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際に、出力ドキュメントにプレゼンテーションのコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) クラスの `get_NotesCommentsLayouting` メソッドでコメントの表示パラメータを指定します。

次のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 ドキュメントに変換します。
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


以下の画像に「output.html」ドキュメントが示されています。

![出力された HTML5 ドキュメント内のコメント](two_comments_html5.png)

## **FAQ**

**HTML5 でオブジェクト アニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export.html5options/set_animateshapes/) と [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export.html5options/set_animatetransitions/) を有効または無効にする個別のオプションが提供されています。

**コメントの出力はサポートされており、スライドに対してどこに配置できますか？**

はい、HTML5 でコメントを追加でき、ノートとコメントのレイアウト設定を使用して（例: スライドの右側）配置できます。

**セキュリティや CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、[setting](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) があり、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできます。これにより、厳格なセキュリティ ポリシーに準拠できます。