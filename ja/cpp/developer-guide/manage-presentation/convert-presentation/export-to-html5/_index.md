---
title: C++ でプレゼンテーションを HTML5 に変換
linktitle: プレゼンテーションを HTML5 に
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
description: "Aspose.Slides for C++ を使用して、PowerPoint と OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式設定、アニメーション、インタラクティブ性を保持します。"
---

{{% alert title="Info" color="info" %}}

[Aspose.Slides 21.9](/slides/ja/cpp/aspose-slides-for-cpp-21-9-release-notes/) では、HTML5 エクスポートのサポートを実装しました。

{{% /alert %}} 

この HTML5 エクスポートプロセスにより、PowerPoint を HTML に変換できます。独自のテンプレートを使用することで、エクスポートプロセスや生成される HTML、CSS、JavaScript、アニメーション属性を定義する非常に柔軟なオプションを適用できます。 

## **PowerPoint を HTML5 にエクスポート**

この C++ コードは、プレゼンテーションを HTML5 にエクスポートする方法を示します。
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```


{{% alert color="primary" %}} 

この場合、クリーンな HTML が得られます。 

{{% /alert %}}

このように、形状アニメーションやスライド遷移の設定を指定したい場合があります。
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
using namespace Aspense::Slides;
using namespace Aspense::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```


この場合、プレゼンテーションの内容は SVG を使用して以下のようにレンダリングされます。
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

この方法で PowerPoint を HTML にエクスポートすると、SVG のレンダリングのため、特定の要素にスタイルを適用したりアニメーションを付けたりすることはできません。 

{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

**Aspose.Slides** は、PowerPoint プレゼンテーションを HTML5 ドキュメントに変換でき、スライドがスライドビュー形式で表示されます。この場合、生成された HTML5 ファイルをブラウザーで開くと、ウェブページ上でスライドビュー モードのプレゼンテーションが表示されます。 

この C++ コードは、PowerPoint を HTML5 スライドビューにエクスポートするプロセスを示しています:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **コメント付きでプレゼンテーションを HTML5 ドキュメントに変換**

PowerPoint のコメントは、ユーザーがスライドにメモやフィードバックを残すためのツールです。共同プロジェクトで特に有用で、複数のメンバーがメインコンテンツを変更せずに特定のスライド要素に提案や指摘を追加できます。各コメントには作者の名前が表示され、誰がコメントしたかを簡単に追跡できます。

たとえば、"sample.pptx" ファイルに保存された次の PowerPoint プレゼンテーションがあるとします。

![プレゼンテーションスライド上の2つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際、出力ドキュメントにコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) クラスの `get_NotesCommentsLayouting` メソッドでコメントの表示パラメータを指定する必要があります。

以下のコード例は、スライドの右側にコメントを表示した HTML5 ドキュメントにプレゼンテーションを変換します。
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

**HTML5 でオブジェクト アニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) と [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) を有効化または無効化する個別のオプションが提供されています。

**コメントの出力はサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、HTML5 ではコメントを追加でき、ノートとコメントのレイアウト設定を使用して（例としてスライドの右側など）配置できます。

**セキュリティや CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできる [setting](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) があり、厳格なセキュリティポリシーに準拠するのに役立ちます。