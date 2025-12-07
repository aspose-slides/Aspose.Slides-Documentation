---
title: C++ でプレゼンテーションを HTML5 に変換
linktitle: プレゼンテーションを HTML5 に
type: docs
weight: 40
url: /ja/cpp/export-to-html5/
keywords:
- PowerPoint を HTML5 に
- OpenDocument を HTML5 に
- プレゼンテーションを HTML5 に
- スライドを HTML5 に
- PPT を HTML5 に
- PPTX を HTML5 に
- ODP を HTML5 に
- PPT を HTML5 として保存
- PPTX を HTML5 として保存
- ODP を HTML5 として保存
- PPT を HTML5 にエクスポート
- PPTX を HTML5 にエクスポート
- ODP を HTML5 にエクスポート
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式設定、アニメーション、インタラクティブ性を保持します。"
---

{{% alert title="Info" color="info" %}}

[Aspose.Slides 21.9](/slides/ja/cpp/aspose-slides-for-cpp-21-9-release-notes/)で、HTML5 エクスポートのサポートを実装しました。

{{% /alert %}} 

ここでの HTML5 エクスポートプロセスは、PowerPoint を HTML に変換することを可能にします。この方法で独自のテンプレートを使用し、エクスポートプロセスと生成される HTML、CSS、JavaScript、アニメーション属性を定義する非常に柔軟なオプションを適用できます。 

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

このように、シェイプ アニメーションとスライド トランジションの設定を指定したい場合があります。
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

この C++ は、標準的な PowerPoint から HTML へのプロセスを示しています。
```cpp
using namespace Aspose::Slides;
using namespace Aspise::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```


この場合、プレゼンテーションの内容は SVG を通じて以下のようにレンダリングされます。
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

この方法で PowerPoint を HTML にエクスポートすると、SVG レンダリングのため、特定の要素にスタイルを適用したりアニメーションを付けたりできません。 

{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

**Aspose.Slides** は、PowerPoint プレゼンテーションをスライドがスライドビュー モードで表示される HTML5 ドキュメントに変換できます。この場合、生成された HTML5 ファイルをブラウザーで開くと、Web ページ上でスライドビュー モードのプレゼンテーションが表示されます。 

この C++ コードは、PowerPoint を HTML5 スライドビュー エクスポートするプロセスを示しています：
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **コメント付きの HTML5 ドキュメントにプレゼンテーションを変換**

PowerPoint のコメントは、ユーザーがプレゼンテーションスライドにメモやフィードバックを残すためのツールです。特に共同作業プロジェクトで有用で、複数のユーザーがメインコンテンツを変更せずに特定のスライド要素に対して提案や所見を追加できます。各コメントは作成者の名前を表示し、誰がコメントしたかを簡単に追跡できます。

例として、"sample.pptx" ファイルに保存された次の PowerPoint プレゼンテーションがあるとします。

![プレゼンテーションスライド上の2つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際、出力ドキュメントにプレゼンテーションのコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) クラスの `get_NotesCommentsLayouting` メソッドでコメントの表示パラメータを指定する必要があります。

以下のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 ドキュメントに変換します。
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


"output.html" ドキュメントは以下の画像に示されています。

![出力された HTML5 ドキュメント内のコメント](two_comments_html5.png)

## **FAQ**

**HTML5 でオブジェクト アニメーションやスライド トランジションの再生を制御できますか？**

はい、HTML5 では[shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) と [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) を有効または無効にする個別のオプションが提供されています。

**コメントの出力はサポートされていますか？スライドに対してどこに配置できますか？**

はい、HTML5 ではコメントを追加でき、ノートとコメントのレイアウト設定を使用して（例としてスライドの右側に）配置できます。

**セキュリティや CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできる[設定](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) があり、厳格なセキュリティポリシーに従うのに役立ちます。