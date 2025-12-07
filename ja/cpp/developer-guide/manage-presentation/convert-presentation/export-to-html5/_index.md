---
title: C++でプレゼンテーションをHTML5に変換
linktitle: プレゼンテーションをHTML5に変換
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
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---

{{% alert title="Info" color="info" %}}

[Aspose.Slides 21.9](/slides/ja/cpp/aspose-slides-for-cpp-21-9-release-notes/)で、HTML5 エクスポートのサポートを実装しました。

{{% /alert %}} 

ここでの HTML5 エクスポート プロセスは、PowerPoint を HTML に変換することを可能にします。独自のテンプレートを使用して、エクスポート プロセスと生成される HTML、CSS、JavaScript、アニメーション属性を定義する非常に柔軟なオプションを適用できます。

## **PowerPoint を HTML5 にエクスポートする**

この C++ コードは、プレゼンテーションを HTML5 にエクスポートする方法を示しています。
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```


{{% alert color="primary" %}} 

この場合、クリーンな HTML が取得できます。 

{{% /alert %}}

このように、シェイプ アニメーションとスライド トランジションの設定を指定することもできます:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```


## **PowerPoint を HTML にエクスポートする**

この C++ は、標準的な PowerPoint から HTML へのプロセスを示しています:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```


この場合、プレゼンテーションの内容は次のような形式で SVG を介してレンダリングされます:
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

この方法で PowerPoint を HTML にエクスポートすると、SVG レンダリングのため、特定の要素にスタイルを適用したりアニメーション化したりすることはできません。 

{{% /alert %}}

## **PowerPoint を HTML5 スライド ビューにエクスポートする**

**Aspose.Slides** は、スライドがスライド ビュー モードで表示される HTML5 ドキュメントに PowerPoint プレゼンテーションを変換できます。この場合、ブラウザーで生成された HTML5 ファイルを開くと、Web ページ上でスライド ビュー モードのプレゼンテーションが表示されます。

この C++ コードは、PowerPoint から HTML5 スライド ビューへのエクスポート プロセスを示しています:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **コメント付き HTML5 ドキュメントにプレゼンテーションを変換する**

PowerPoint のコメントは、プレゼンテーション スライドにメモやフィードバックを残すためのツールです。特に共同プロジェクトで有用で、複数のユーザーがメイン コンテンツを変更せずに特定のスライド要素に対して提案や指摘を追加できます。各コメントは作者名を表示するため、誰がコメントしたかを簡単に追跡できます。

たとえば、"sample.pptx" ファイルに保存された次の PowerPoint プレゼンテーションがあるとします。

![Two comments on the presentation slide](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際、出力ドキュメントにプレゼンテーションからのコメントを含めるかどうかを簡単に指定できます。これを行うには、[Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) クラスの `get_NotesCommentsLayouting` メソッドでコメントの表示パラメーターを指定します。

以下のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 ドキュメントに変換します。
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


下の画像に「output.html」ドキュメントが示されています。

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**HTML5 でオブジェクト アニメーションやスライド トランジションの再生を制御できますか？**

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) と [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) を有効化または無効化する個別のオプションが提供されています。

**コメントの出力はサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、HTML5 でコメントを追加でき、ノートとコメントのレイアウト設定により（例: スライドの右側）配置できます。

**セキュリティや CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできる [setting](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) が用意されています。これにより厳格なセキュリティ ポリシーに準拠できます。