---
title: Java で PowerPoint プレゼンテーションを HTML に変換
linktitle: PowerPoint を HTML に変換
type: docs
weight: 30
url: /ja/java/convert-powerpoint-to-html/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を HTML に変換
- プレゼンテーションを HTML に変換
- スライドを HTML に変換
- PPT を HTML に変換
- PPTX を HTML に変換
- PowerPoint を HTML として保存
- プレゼンテーションを HTML として保存
- スライドを HTML として保存
- PPT を HTML として保存
- PPTX を HTML として保存
- PPT を HTML にエクスポート
- PPTX を HTML にエクスポート
- Java
- Aspose.Slides
description: "Java で PowerPoint プレゼンテーションを HTML に変換します。Aspose.Slides を使用して PPT および PPTX ファイル、選択したスライド、ノート、フォント、画像、SVG、およびメディアをエクスポートできます。"
---
## **概要**

Aspose.Slides for Java は Microsoft PowerPoint を使用せずに PowerPoint プレゼンテーションを HTML として保存できます。基本的な変換は、単一の [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) の読み込みと、[SaveFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) を使用した `save` 呼び出しです。エクスポートされたレイアウト、フォント、画像、ノート、コメント、SVG 出力、またはリンクされたリソースを制御する必要がある場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/htmloptions/) を使用します。

このガイドは実践的な HTML エクスポートシナリオに焦点を当てます：

- プレゼンテーション全体または選択したスライドをエクスポートします。
- 固定レイアウト、レスポンシブ、または SVG ベースの HTML を生成します。
- スピーカーノートとコメントを含めます。
- 画像品質と切り取られた画像データを制御します。
- フォントを埋め込むか、フォントファイルを別々に保存します。
- 外部リソースおよびメディアファイルの書き込みと参照方法を選択します。

デフォルトでは、HTML エクスポートはほとんどのリソースが埋め込まれた単一の自己完結型 HTML ドキュメントを生成します。これは 1 ファイルで共有するのに便利ですが、出力サイズが大きくなる可能性があります。Web 公開の場合は、外部リソースの使用、画像 DPI を下げ、ターゲット環境で確実に利用できないフォントのみを埋め込むことを検討してください。

## **プレゼンテーションをHTMLに変換**

プレゼンテーションを HTML にエクスポートするには、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) で読み込み、[SaveFormat.Html](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) で保存します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

この例は 1 つの HTML ファイルを書き込みます。`finally` ブロックでプレゼンテーションオブジェクトが破棄され、エクスポート後にファイルハンドルとレンダリングリソースが解放されます。

## **HtmlOptions の使用**

[HtmlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/htmloptions/) は HTML エクスポートの主要な構成クラスです。一般的な設定は次のとおりです。

- `SlidesLayoutOptions`: ノート、コメント、配布資料などのレイアウト情報を追加します。
- `HtmlFormatter`: HTML ドキュメント構造を変更したり、フォーマッティングをコントローラに委譲したりします。
- `SlideImageFormat`: スライドの表現方法を変更します