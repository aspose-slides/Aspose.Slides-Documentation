---
title: HTML5へのエクスポート
type: docs
weight: 40
url: /ja/net/export-to-html5/
keywords:
- PowerPointからHTMLへの変換
- スライドをHTMLに変換
- HTML5
- HTMLエクスポート
- プレゼンテーションのエクスポート
- プレゼンテーションの変換
- スライドの変換
- C#
- Csharp
- Aspose.Slides for .NET
description: "C#または.NETでPowerPointをHTML5にエクスポート"
---

{{% alert title="情報" color="info" %}}

[Aspose.Slides 21.9](/slides/ja/net/aspose-slides-for-net-21-9-release-notes/) では、HTML5エクスポートのサポートを実装しました。ただし、WebExtensionsを使用してPowerPointをHTMLにエクスポートすることを希望される場合は、[この記事](/slides/ja/net/web-extensions/)をご覧ください。 

{{% /alert %}} 

ここでのHTML5へのエクスポートプロセスでは、WebExtensionsや依存関係を使用せずにPowerPointをHTMLに変換できます。この方法では、自分自身のテンプレートを使用して、エクスポートプロセスと生成されるHTML、CSS、JavaScript、アニメーション属性を定義する非常に柔軟なオプションを適用できます。

## **PowerPointをHTML5にエクスポート**

このC#コードは、WebExtensionsや依存関係を使用せずにプレゼンテーションをHTML5にエクスポートする方法を示しています。

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 

この場合、クリーンなHTMLが得られます。 

{{% /alert %}}

この方法で形状のアニメーションやスライドのトランジションの設定を指定することができます。

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

#### **PowerPointをHTMLにエクスポート**

このC#コードは、標準のPowerPointからHTMLへのプロセスを示しています。

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

この場合、プレゼンテーションの内容はSVGを介して次のようにレンダリングされます。

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> スライドの内容はここに入ります </g>
     </svg>
</div>
</body>
```

{{% alert title="注意" color="warning" %}} 

この方法を使用してPowerPointをHTMLにエクスポートすると、SVGレンダリングにより、特定の要素にスタイルを適用したりアニメートしたりすることができなくなります。 

{{% /alert %}}

## **PowerPointをHTML5スライドビューにエクスポート**

**Aspose.Slides**を使用すると、PowerPointプレゼンテーションをHTML5文書に変換し、スライドがスライドビューモードで表示されます。この場合、結果として得られたHTML5ファイルをブラウザで開くと、ウェブページ上でスライドビューのモードでプレゼンテーションが表示されます。 

このC#コードは、PowerPointをHTML5スライドビューにエクスポートするプロセスを示しています。

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## コメント付きのプレゼンテーションをHTML5文書に変換する

PowerPointのコメントは、ユーザーがプレゼンテーションスライドにメモやフィードバックを残すことを許可するツールです。これは特に共同作業プロジェクトで便利で、複数の人がメインコンテンツを変更することなく特定のスライド要素に提案やメモを追加できます。各コメントは著者の名前を表示し、誰がメモを残したかを追跡しやすくします。

以下のPowerPointプレゼンテーションが「sample.pptx」というファイルに保存されているとします。

![プレゼンテーションスライドの2つのコメント](two_comments_pptx.png)

PowerPointプレゼンテーションをHTML5文書に変換する際、出力文書にプレゼンテーションからのコメントを含めるかどうかを簡単に指定できます。これを行うには、[Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/)クラスの`NotesCommentsLayouting`プロパティでコメントの表示パラメータを指定する必要があります。

以下のコード例は、スライドの右側に表示されるコメント付きでプレゼンテーションをHTML5文書に変換します。
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

「output.html」文書は、以下の画像に示されています。

![出力HTML5文書のコメント](two_comments_html5.png)