---
title: HTML5へのエクスポート
type: docs
weight: 40
url: /ja/cpp/export-to-html5/
keywords:
- PowerPointをHTMLに
- スライドをHTMLに
- HTML5
- HTMLエクスポート
- プレゼンテーションをエクスポート
- プレゼンテーションを変換
- スライドを変換
- C++
- Aspose.Slides for C++
description: "C++でPowerPointをHTML5にエクスポート" 
---

{{% alert title="情報" color="info" %}}

[Aspose.Slides 21.9](/slides/ja/cpp/aspose-slides-for-cpp-21-9-release-notes/)では、HTML5エクスポートのサポートを実装しました。

{{% /alert %}} 

ここでのHTML5へのエクスポートプロセスにより、PowerPointをHTMLに変換できます。この方法を使えば、自分自身のテンプレートを使用して、エクスポートプロセスと結果として得られるHTML、CSS、JavaScript、およびアニメーション属性を定義する非常に柔軟なオプションを適用できます。

## **PowerPointをHTML5にエクスポート**

このC++のコードは、プレゼンテーションをHTML5にエクスポートする方法を示しています。

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 

この場合、きれいなHTMLが得られます。 

{{% /alert %}}

形状アニメーションやスライドトランジションの設定をこのように指定したい場合があります：

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **PowerPointをHTMLにエクスポート**

このC++は、標準的なPowerPointからHTMLへのプロセスを示します：

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

この場合、プレゼンテーションの内容は、次のような形式でSVGを通じてレンダリングされます：

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> スライドの内容がここに入ります </g>
     </svg>
</div>
</body>
```

{{% alert title="注記" color="warning" %}} 

この方法を使用してPowerPointをHTMLにエクスポートする場合、SVGレンダリングのため、特定の要素にスタイルを適用したりアニメーションを適用したりすることはできません。 

{{% /alert %}}

## **HTML5スライドビューへのPowerPointエクスポート**

**Aspose.Slides**は、PowerPointプレゼンテーションをHTML5ドキュメントに変換することを可能にし、その中でスライドがスライドビューモードで表示されます。この場合、生成されたHTML5ファイルをブラウザで開くと、ウェブページ上でスライドビューモードのプレゼンテーションが表示されます。

このC++のコードは、PowerPointからHTML5スライドビューへのエクスポートプロセスを示しています：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## コメント付きのプレゼンテーションをHTML5ドキュメントに変換

PowerPointのコメントは、ユーザーがプレゼンテーションスライドにメモやフィードバックを残すためのツールです。これらは特に共同プロジェクトにおいて便利で、複数の人がメインコンテンツを変更することなく、特定のスライド要素に提案や意見を追加できます。各コメントには著者の名前が表示され、誰がコメントを残したかを追跡するのが簡単です。

以下の「sample.pptx」ファイルに保存されたPowerPointプレゼンテーションがあるとします。

![プレゼンテーションスライドの2つのコメント](two_comments_pptx.png)

PowerPointプレゼンテーションをHTML5ドキュメントに変換するとき、出力ドキュメントにプレゼンテーションからコメントを含めるかどうかを簡単に指定できます。これを行うには、[Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/)クラスの`get_NotesCommentsLayouting`メソッドでコメントの表示パラメータを指定する必要があります。

以下のコード例は、スライドの右にコメントが表示されるHTML5ドキュメントにプレゼンテーションを変換します。
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

「output.html」ドキュメントは、以下の画像に示されています。

![出力HTML5ドキュメントのコメント](two_comments_html5.png)