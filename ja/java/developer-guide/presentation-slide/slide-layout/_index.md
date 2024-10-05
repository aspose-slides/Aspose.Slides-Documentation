---
title: スライドレイアウト
type: docs
weight: 60
url: /java/slide-layout/
keyword: "スライドサイズの設定、スライドオプションの設定、スライドサイズの指定、フッターの表示、子フッター、コンテンツスケーリング、ページサイズ、Java、Aspose.Slides"
description: "JavaでPowerPointスライドサイズとオプションを設定する"
---

スライドレイアウトには、スライドに表示されるすべてのコンテンツのためのプレースホルダーのボックスとフォーマット情報が含まれています。レイアウトは、使用可能なコンテンツのプレースホルダーとその配置場所を決定します。

スライドレイアウトを使用することで、プレゼンテーションを迅速に作成および設計できます（シンプルなものから複雑なものまで）。以下は、PowerPointプレゼンテーションで使用される最も一般的なスライドレイアウトのいくつかです：

* **タイトルスライドレイアウト**。このレイアウトは、タイトル用のプレースホルダーとサブタイトル用のプレースホルダーの2つで構成されています。
* **タイトルとコンテンツレイアウト**。このレイアウトには、タイトル用に比較的小さなプレースホルダーが上部にあり、核心コンテンツ（チャート、段落、箇条書きリスト、番号付きリスト、画像など）用の大きなプレースホルダーがあります。
* **空白レイアウト**。このレイアウトにはプレースホルダーがなく、ゼロから要素を作成できます。

スライドマスターは、スライドレイアウトに関する情報を保存する最上位の階層スライドであるため、マスタースライドを使用してスライドレイアウトにアクセスし、それらを変更できます。レイアウトスライドには、タイプまたは名前でアクセスできます。同様に、すべてのスライドには一意のIDがあり、これを使用してアクセスできます。

また、プレゼンテーション内の特定のスライドレイアウトに直接変更を加えることもできます。

* スライドレイアウトで作業できるように（マスタースライド内のものも含む）、Aspose.Slidesは[ getLayoutSlides() ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--)と[getMasters()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--)のプロパティを[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスの下で提供します。
* 関連タスクを実行するために、Aspose.Slidesは[MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/)、[MasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/masterlayoutslidecollection/)、[SlideSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/)、[BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/baseslideheaderfootermanager/)などの多くのタイプを提供します。

{{% alert title="情報" color="info" %}}

マスタースライドでの作業に関する詳細は、[スライドマスター](https://docs.aspose.com/slides/java/slide-master/)の記事を参照してください。

{{% /alert %}}

## **プレゼンテーションにスライドレイアウトを追加する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. [MasterSlideコレクション](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/)にアクセスします。
1. 既存のレイアウトスライドを確認し、必要なレイアウトスライドがレイアウトスライドコレクションにすでに存在することを確認します。存在しない場合は、追加したいレイアウトスライドを追加します。
1. 新しいレイアウトスライドに基づいて空のスライドを追加します。
1. プレゼンテーションを保存します。

このJavaコードは、PowerPointプレゼンテーションにスライドレイアウトを追加する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation("AccessSlides.pptx");
try {
    // レイアウトスライドタイプを通過
    IMasterLayoutSlideCollection layoutSlides = pres.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;

    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // プレゼンテーションに一部のレイアウトタイプが含まれない状況。
        // プレゼンテーションファイルには空白とカスタムレイアウトタイプのみが含まれています。
        // ただし、カスタムタイプのレイアウトスライドは異なるスライド名を持っています、
        // 例えば「タイトル」、「タイトルとコンテンツ」など。そして、これらを用いてレイアウトスライドを選択することが可能です。
        // プレースホルダーシェイプタイプのセットを使用することもできます。例えば、
        // タイトルスライドはタイトルプレースホルダータイプのみを持つべきです。
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName() == "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }
        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName() == "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }
            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // 追加したレイアウトスライドで空のスライドを追加
    pres.getSlides().insertEmptySlide(0, layoutSlide);

    // プレゼンテーションをディスクに保存
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **未使用のレイアウトスライドを削除する**

Aspose.Slidesは、不要で未使用のレイアウトスライドを削除できるようにするために、[removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)メソッドを[Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)クラスから提供します。このJavaコードは、PowerPointプレゼンテーションからレイアウトスライドを削除する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **スライドレイアウトのサイズとタイプを設定する**

特定のレイアウトスライドのサイズとタイプを設定できるように、Aspose.Slidesは[ getType() ](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getType--)および[getSize()](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getSize--)プロパティを[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスから提供します。このJavaコードは、その操作を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation presentation = new Presentation("demo.pptx");
try {
    Presentation auxPresentation = new Presentation();
    try {
        // 生成されたプレゼンテーションのスライドサイズをソースのものに設定
        auxPresentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit);
        //getType());
        auxPresentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);
        
        // 必要なスライドをクローン
        auxPresentation.getSlides().addClone(presentation.getSlides().get_Item(0));
        auxPresentation.getSlides().removeAt(0);
        
        // プレゼンテーションをディスクに保存
        auxPresentation.save("size.pptx", SaveFormat.Pptx);
    } finally {
        auxPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **スライド内のフッターの表示を設定する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. スライドフッタープレースホルダーを表示するよう設定します。
1. 日時プレースホルダーを表示するよう設定します。
1. プレゼンテーションを保存します。

このJavaコードは、スライドフッターの可視性を設定する方法を示しています（および関連するタスクを実行）：

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.getSlides().get_Item(0).getHeaderFooterManager();
    if (!headerFooterManager.isFooterVisible()) // メソッドisFooterVisibleはスライドフッタープレースホルダーが欠落していることを示すために使用されます
    {
        headerFooterManager.setFooterVisibility(true); // メソッドsetFooterVisibilityはスライドフッタープレースホルダーを表示するために使用されます
    }
    if (!headerFooterManager.isSlideNumberVisible()) // メソッドisSlideNumberVisibleはスライドページ番号プレースホルダーが欠落していることを示すために使用されます
    {
        headerFooterManager.setSlideNumberVisibility(true); // メソッドsetSlideNumberVisibilityはスライドページ番号プレースホルダーを表示するために使用されます
    }
    if (!headerFooterManager.isDateTimeVisible()) // メソッドisDateTimeVisibleはスライド日時プレースホルダーが欠落していることを示すために使用されます
    {
        headerFooterManager.setDateTimeVisibility(true); // メソッドSetFooterVisibilityはスライド日時プレースホルダーを表示するために使用されます
    }
    headerFooterManager.setFooterText("フッターのテキスト"); // メソッドSetFooterTextはスライドフッタープレースホルダーのテキストを設定するために使用されます。
    headerFooterManager.setDateTimeText("日時のテキスト"); // メソッドSetDateTimeTextはスライド日時プレースホルダーのテキストを設定するために使用されます。
} finally {
    presentation.dispose();
}
```

## **スライド内の子フッターの表示を設定する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてマスタースライドの参照を取得します。
1. マスタースライドとすべての子フッタープレースホルダーを表示するよう設定します。
1. マスタースライドおよびすべての子フッタープレースホルダーのテキストを設定します。
1. マスタースライドおよびすべての子日時プレースホルダーのテキストを設定します。
1. プレゼンテーションを保存します。

このJavaコードは、その操作を示しています：

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true); // メソッドsetFooterAndChildFootersVisibilityはマスタースライドとすべての子フッタープレースホルダーを表示するために使用されます
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // メソッドsetSlideNumberAndChildSlideNumbersVisibilityはマスタースライドとすべての子ページ番号プレースホルダーを表示するために使用されます
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // メソッドsetDateTimeAndChildDateTimesVisibilityはマスタースライドとすべての子日時プレースホルダーを表示するために使用されます

    headerFooterManager.setFooterAndChildFootersText("フッターのテキスト"); // メソッドsetFooterAndChildFootersTextはマスタースライドとすべての子フッタープレースホルダーのテキストを設定するために使用されます
    headerFooterManager.setDateTimeAndChildDateTimesText("日時のテキスト"); // メソッドsetDateTimeAndChildDateTimesTextはマスタースライドとすべての子日時プレースホルダーのテキストを設定するために使用されます
} finally {
    presentation.dispose();
}
```

## **コンテンツスケーリングに応じたスライドサイズを設定する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成し、サイズを設定したいスライドを含むプレゼンテーションをロードします。
1. 新しいプレゼンテーションを生成するために別の[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. スライドの参照を（最初のプレゼンテーションから）インデックスを通じて取得します。
1. スライドフッタープレースホルダーを表示するよう設定します。
1. 日時プレースホルダーを表示するよう設定します。
1. プレゼンテーションを保存します。

このJavaコードは、その操作を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation presentation = new Presentation("demo.pptx");
try {
    // 生成されたプレゼンテーションのスライドサイズをソースのものに設定
    presentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit); // メソッドSetSizeはコンテンツに合わせてスライドサイズを設定するために使用されます
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // メソッドSetSizeはコンテンツの最大サイズでスライドサイズを設定するために使用されます

    // プレゼンテーションをディスクに保存
    presentation.save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **PDFを生成する際のページサイズを設定する**

特定のプレゼンテーション（ポスターなど）は、PDFドキュメントに変換されることがよくあります。PowerPointをPDFに変換して、最高の印刷およびアクセスオプションを利用したい場合は、スライドをPDF文書に適したサイズ（例：A4）に設定する必要があります。

Aspose.Slidesは、スライドの好ましい設定を指定できるように[SlideSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/)クラスを提供します。このJavaコードは、プレゼンテーション内のスライドの特定の用紙サイズを設定するために[getType()](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getType--)プロパティを使用する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化 
Presentation presentation = new Presentation();
try {
    // SlideSize.Typeプロパティを設定
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);
    
    // PDFオプションのさまざまなプロパティを設定
    PdfOptions opts = new  PdfOptions();
    opts.setSufficientResolution(600);
    
    // プレゼンテーションをディスクに保存
    presentation.save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
} finally {
    presentation.dispose();
}
```