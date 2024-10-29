---
title: デフォルトフォント - PowerPoint Java API
linktitle: デフォルトフォント
type: docs
weight: 30
url: /ja/java/default-font/
description: PowerPoint Java APIを使用すると、プレゼンテーションをPDF、XPS、またはサムネイルとしてレンダリングするためのデフォルトフォントを設定できます。この記事では、デフォルトフォントとして使用するためのDefaultRegular FontとDefaultAsian Fontの定義方法を示します。
---


## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**
Aspose.Slidesでは、プレゼンテーションをPDF、XPS、またはサムネイルとしてレンダリングするためのデフォルトフォントを設定できます。この記事では、デフォルトフォントとして使用するためのDefaultRegular FontとDefaultAsian Fontの定義方法を示します。Aspose.Slides for Java APIを使用して外部ディレクトリからフォントをロードする手順は以下の通りです。

1. [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions)のインスタンスを作成します。
1. [DefaultRegularFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-)を希望するフォントに設定します。以下の例では、Wingdingsを使用しています。
1. [DefaultAsianFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-)を希望するフォントに設定します。以下のサンプルでもWingdingsを使用しています。
1. Presentationを使用してプレゼンテーションをロードし、ロードオプションを設定します。
1. スライドのサムネイル、PDF、XPSを生成して結果を確認します。

上記の実装は以下の通りです。

```java
// デフォルトのレギュラーおよびアジアンフォントを定義するためにロードオプションを使用します
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// プレゼンテーションをロードします
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // スライドのサムネイルを生成します
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // ディスクに画像を保存します。
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // PDFを生成します
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // XPSを生成します
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```