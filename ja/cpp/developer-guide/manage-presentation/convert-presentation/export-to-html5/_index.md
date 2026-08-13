---
title: C++ でプレゼンテーションを HTML5 に変換
linktitle: HTML5 へのプレゼンテーション
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
description: "Aspose.Slides for C++ を使用して、PowerPoint と OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式設定、アニメーション、インタラクティブ性を保持します。"
---
## **Overview**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションを HTML5 に変換する方法を説明します。Web 拡張や追加の依存関係なしで基本的な HTML5 エクスポートを行う方法や、シェイプ アニメーションやスライド トランジションを制御するオプションについてカバーします。また、標準的な PowerPoint から HTML へのエクスポート手順を示し、スライド ビュー モードで HTML5 出力を生成する方法、レイアウトを設定してエクスポートされたドキュメントにコメントを含める方法も解説します。

## **Export PowerPoint to HTML5**

この C++ コードは、プレゼンテーションを HTML5 にエクスポートする方法を示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
この場合、クリーンな HTML が得られます。 
{{% /alert %}}

このようにシェイプ アニメーションとスライド トランジションの設定を指定することもできます。

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Export PowerPoint to HTML**

この C++ は、標準的な PowerPoint から HTML へのエクスポート手順を示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

この場合、プレゼンテーションの内容は SVG を使用して以下のように描画されます。

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
この方法で PowerPoint を HTML にエクスポートすると、SVG による描画のため、特定の要素にスタイルを適用したりアニメーションさせたりすることはできません。 
{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** を使用すると、PowerPoint プレゼンテーションをスライド ビュー モードで表示される HTML5 ドキュメントに変換できます。この場合、生成された HTML5 ファイルをブラウザーで開くと、ウェブページ上でスライド ビュー モードのプレゼンテーションが表示されます。

この C++ コードは、PowerPoint から HTML5 スライド ビューへのエクスポートプロセスを示しています。

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Convert a Presentation to an HTML5 Document with Comments**

PowerPoint のコメントは、ユーザーがスライドにメモやフィードバックを残すための機能です。複数のユーザーがメインのコンテンツを変更せずにスライド要素に対して提案やコメントを追加できるため、共同作業プロジェクトで特に有用です。各コメントには作成者の名前が表示されるため、誰がコメントしたかを簡単に追跡できます。

例として、"sample.pptx" ファイルに保存されている以下の PowerPoint プレゼンテーションがあるとします。

![プレゼンテーションスライド上の 2 つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際、出力ドキュメントにプレゼンテーションのコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/html5options/) クラスの `get_NotesCommentsLayouting` メソッドでコメントの表示パラメータを設定する必要があります。

次のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 ドキュメントに変換します。
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

以下の画像に「output.html」ドキュメントの例が示されています。

![出力された HTML5 ドキュメント内のコメント](two_comments_html5.png)

## **FAQ**

### Can I control whether object animations and slide transitions will play in HTML5?

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/html5options/set_animateshapes/) と [slide transitions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/html5options/set_animatetransitions/) を有効または無効にする個別のオプションが提供されています。

### Is the output of comments supported, and where can they be placed relative to the slide?

はい、HTML5 にコメントを追加でき、ノートとコメントのレイアウト設定を通じて（例としてスライドの右側など）配置することが可能です。

### Can I skip links that invoke JavaScript for security or CSP reasons?

はい、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできる [setting](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) が用意されています。これにより厳格なセキュリティ ポリシーに準拠できます。