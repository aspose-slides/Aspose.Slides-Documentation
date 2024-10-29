---
title: スライドレイアウト
type: docs
weight: 60
url: /ja/androidjava/slide-layout/
keyword: "スライドサイズを設定、スライドオプションを設定、スライドサイズを指定、フッターの可視性、子フッター、コンテンツスケーリング、ページサイズ、Java、Aspose.Slides"
description: "JavaでPowerPointスライドサイズとオプションを設定"
---

スライドレイアウトには、スライド上に表示されるすべてのコンテンツのプレースホルダーボックスと書式情報が含まれています。レイアウトは、利用可能なコンテンツプレースホルダーとそれらが配置される場所を決定します。

スライドレイアウトを使用すると、プレゼンテーションを迅速に作成および設計できます（シンプルでも複雑でも）。これらは、PowerPointプレゼンテーションで使用される最も一般的なスライドレイアウトのいくつかです：

* **タイトルスライドレイアウト**。このレイアウトには、2つのテキストプレースホルダーが含まれています。1つのプレースホルダーはタイトル用で、もう1つはサブタイトル用です。
* **タイトルとコンテンツレイアウト**。このレイアウトには、上部にタイトル用の比較的小さなプレースホルダーと、コアコンテンツ（チャート、段落、箇条書き、番号付きリスト、画像など）用の大きなプレースホルダーが含まれています。
* **空白レイアウト**。このレイアウトにはプレースホルダーがないため、ゼロから要素を作成することができます。

スライドマスターは、スライドレイアウトに関する情報を保存する最上位の階層スライドであるため、マスタースライドを使用してスライドレイアウトにアクセスし、変更を加えることができます。レイアウトスライドは、タイプまたは名前でアクセスできます。同様に、すべてのスライドには一意のIDがあり、これを使用してアクセスできます。

また、プレゼンテーション内の特定のスライドレイアウトに直接変更を加えることも可能です。

* スライドレイアウト（マスタースライドのものも含む）を操作するために、Aspose.Slidesは、[getLayoutSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--)や[getMasters()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--)などのプロパティを、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスの下で提供しています。
* 関連するタスクを実行するために、Aspose.Slidesは[MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/)、[MasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterlayoutslidecollection/)、[SlideSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/)、[BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslideheaderfootermanager/)など、他にも多くのタイプを提供しています。

{{% alert title="情報" color="info" %}}

特にマスタースライドを操作する詳細については、[スライドマスター](https://docs.aspose.com/slides/androidjava/slide-master/)の記事を参照してください。

{{% /alert %}}

## **プレゼンテーションにスライドレイアウトを追加**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. [MasterSlideコレクション](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/)にアクセスします。
1. 既存のレイアウトスライドを確認して、必要なレイアウトスライドがレイアウトスライドコレクションにすでに存在することを確認します。そうでない場合は、必要なレイアウトスライドを追加します。
1. 新しいレイアウトスライドに基づいて空のスライドを追加します。
1. プレゼンテーションを保存します。

このJavaコードは、PowerPointプレゼンテーションにスライドレイアウトを追加する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成
Presentation pres = new Presentation("AccessSlides.pptx");
try {
    // レイアウトスライドタイプを経由
    IMasterLayoutSlideCollection layoutSlides = pres.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;

    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // プレゼンテーションに特定のレイアウトタイプが含まれていない状況。
        // プレゼンテーションファイルには空白とカスタムレイアウトタイプのみが含まれています。
        // ただし、カスタムタイプのレイアウトスライドは異なるスライド名を持ち、
        // 例えば「タイトル」、「タイトルとコンテンツ」など。この名前を使用してレイアウトスライドを選択することも可能です。
        // 一連のプレースホルダーシェイプタイプを使用することもできます。たとえば、
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

## **未使用のレイアウトスライドを削除**

Aspose.Slidesは、不要で未使用のレイアウトスライドを削除するために、[removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)メソッドを、[Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)クラスから提供しています。このJavaコードは、PowerPointプレゼンテーションからレイアウトスライドを削除する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **スライドレイアウトのサイズとタイプを設定**

特定のレイアウトスライドのサイズとタイプを設定できるように、Aspose.Slidesは、[getType()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getType--)および[getSize()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getSize--)プロパティを、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスから提供しています。このJavaは操作を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトを生成
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

## **スライド内のフッターの可視性を設定**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通してスライドの参照を取得します。
1. スライドフッタープレースホルダーを可視に設定します。
1. 日時プレースホルダーを可視に設定します。
1. プレゼンテーションを保存します。

このJavaコードは、スライドのフッターの可視性を設定する方法を示しています（および関連するタスクを実行）：

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.getSlides().get_Item(0).getHeaderFooterManager();
    if (!headerFooterManager.isFooterVisible()) // メソッドisFooterVisibleは、スライドフッタープレースホルダーが欠落していることを示します
    {
        headerFooterManager.setFooterVisibility(true); // メソッドsetFooterVisibilityは、スライドフッタープレースホルダーを可視に設定します
    }
    if (!headerFooterManager.isSlideNumberVisible()) // メソッドisSlideNumberVisibleは、スライドページ番号プレースホルダーが欠落していることを示します
    {
        headerFooterManager.setSlideNumberVisibility(true); // メソッドsetSlideNumberVisibilityは、スライドページ番号プレースホルダーを可視に設定します
    }
    if (!headerFooterManager.isDateTimeVisible()) // メソッドisDateTimeVisibleは、スライド日時プレースホルダーが欠落していることを示します
    {
        headerFooterManager.setDateTimeVisibility(true); // メソッドsetDateTimeVisibilityは、スライド日時プレースホルダーを可視に設定します
    }
    headerFooterManager.setFooterText("フッターのテキスト"); // メソッドsetFooterTextは、スライドフッタープレースホルダーのテキストを設定します。
    headerFooterManager.setDateTimeText("日付と時間のテキスト"); // メソッドsetDateTimeTextは、スライド日時プレースホルダーのテキストを設定します。
} finally {
    presentation.dispose();
}
```

## **スライド内の子フッターの可視性を設定**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通してマスタースライドの参照を取得します。
1. マスタースライドとすべての子フッタープレースホルダーを可視に設定します。
1. マスタースライドとすべての子フッタープレースホルダーにテキストを設定します。
1. マスタースライドとすべての子日時プレースホルダーにテキストを設定します。
1. プレゼンテーションを保存します。

このJavaコードは、操作を示しています：

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true); // メソッドsetFooterAndChildFootersVisibilityは、マスタースライドとすべての子フッタープレースホルダーを可視に設定します
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // メソッドsetSlideNumberAndChildSlideNumbersVisibilityは、マスタースライドとすべての子ページ番号プレースホルダーを可視に設定します
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // メソッドsetDateTimeAndChildDateTimesVisibilityは、マスタースライドとすべての子日時プレースホルダーを可視に設定します

    headerFooterManager.setFooterAndChildFootersText("フッターのテキスト"); // メソッドsetFooterAndChildFootersTextは、マスタースライドとすべての子フッタープレースホルダーのテキストを設定します
    headerFooterManager.setDateTimeAndChildDateTimesText("日付と時間のテキスト"); // メソッドsetDateTimeAndChildDateTimesTextは、マスタースライドとすべての子日時プレースホルダーのテキストを設定します
} finally {
    presentation.dispose();
}
```

## **コンテンツスケーリングに関するスライドサイズを設定**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成し、サイズを設定するスライドを含むプレゼンテーションをロードします。
1. 新しいプレゼンテーションを生成するために別の[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通して（最初のプレゼンテーションから）スライドの参照を取得します。
1. スライドフッタープレースホルダーを可視に設定します。
1. 日時プレースホルダーを可視に設定します。
1. プレゼンテーションを保存します。

このJavaコードは、操作を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトを生成
Presentation presentation = new Presentation("demo.pptx");
try {
    // 生成されたプレゼンテーションのスライドサイズをソースのものに設定
    presentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit); // メソッドSetSizeは、コンテンツに合わせるためにスライドサイズを設定します
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // メソッドSetSizeは、コンテンツの最大サイズにスライドサイズを設定します

    // プレゼンテーションをディスクに保存
    presentation.save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **PDF生成時のページサイズを設定**

特定のプレゼンテーション（ポスターなど）は、しばしばPDFドキュメントに変換されます。PowerPointをPDFに変換して、最適な印刷およびアクセシビリティオプションにアクセスしたい場合は、スライドをPDF文書（例えばA4）に適したサイズに設定する必要があります。

Aspose.Slidesは、スライドに対する好みの設定を指定できるように、[SlideSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/)クラスを提供しています。このJavaコードは、プレゼンテーション内のスライドの特定の用紙サイズを設定するために、`SlideSize`クラスから[getType()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getType--)プロパティを使用する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトを生成
Presentation presentation = new Presentation();
try {
    // SlideSize.Typeプロパティを設定  
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);
    
    // PDFオプション用のさまざまなプロパティを設定
    PdfOptions opts = new  PdfOptions();
    opts.setSufficientResolution(600);
    
    // プレゼンテーションをディスクに保存
    presentation.save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
} finally {
    presentation.dispose();
}
```