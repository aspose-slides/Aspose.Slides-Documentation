---
title: デフォルトフォント - PowerPoint Java API
linktitle: デフォルトフォント
type: docs
weight: 30
url: /androidjava/default-font/
description: PowerPoint Java APIを使用すると、プレゼンテーションをPDF、XPS、またはサムネイルとしてレンダリングするためのデフォルトフォントを設定できます。この記事では、デフォルトフォントとして使用するためのDefaultRegular FontとDefaultAsian Fontの定義方法を説明します。
---


## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**
Aspose.Slidesを使用すると、プレゼンテーションをPDF、XPS、またはサムネイルとしてレンダリングするためのデフォルトフォントを設定できます。この記事では、デフォルトフォントとして使用するためのDefaultRegular FontとDefaultAsian Fontの定義方法を説明します。以下の手順に従って、Aspose.Slides for Androidを使用してJava API経由で外部ディレクトリからフォントを読み込んでください：

1. [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions)のインスタンスを作成します。
1. [DefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-)を希望のフォントに設定します。次の例では、Wingdingsを使用しました。
1. [DefaultAsianFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-)を希望のフォントに設定します。次のサンプルでもWingdingsを使用しました。
1. プレゼンテーションをPresentationを使用して読み込み、ロードオプションを設定します。
1. さて、スライドのサムネイル、PDF、およびXPSを生成して結果を確認します。

上記の実装は以下の通りです。

```java
// デフォルトのレギュラーおよびアジアンフォントを定義するためにロードオプションを使用します
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// プレゼンテーションを読み込む
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // スライドのサムネイルを生成する
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // ディスクに画像を保存する。
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // PDFを生成する
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // XPSを生成する
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```