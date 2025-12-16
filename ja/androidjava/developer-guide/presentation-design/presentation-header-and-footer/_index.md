---
title: Android でプレゼンテーションのヘッダーとフッターを管理する
linktitle: ヘッダー & フッター
type: docs
weight: 140
url: /ja/androidjava/presentation-header-and-footer/
keywords:
- ヘッダー
- ヘッダーテキスト
- フッター
- フッターテキスト
- ヘッダー設定
- フッター設定
- ハンドアウト
- ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument プレゼンテーションにヘッダーとフッターを追加・カスタマイズし、プロフェッショナルな外観を実現します。"
---

{{% alert color="primary" %}} 
[Aspose.Slides](/slides/ja/androidjava/) は、スライドのヘッダーおよびフッターのテキストを、スライド マスター レベルで実際に管理できるサポートを提供します。
{{% /alert %}} 
[Aspose.Slides for Android via Java](/slides/ja/androidjava/) は、プレゼンテーション スライド内のヘッダーとフッターを管理する機能を提供します。これらは実際にプレゼンテーション マスター レベルで管理されます。

## **プレゼンテーションでヘッダーとフッターを管理する**
特定のスライドのノートは、以下の例のように削除できます。
```java
// プレゼンテーションをロード
Presentation pres = new Presentation("headerTest.pptx");
try {
    // フッターを設定
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // ヘッダーにアクセスして更新
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // プレゼンテーションを保存
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
// ヘッダー/フッターテキストを設定するメソッド
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```


## **配布資料およびノート スライドでヘッダーとフッターを管理する**
Aspose.Slides for Android via Java は、配布資料およびノート スライドでヘッダーとフッターをサポートしています。以下の手順に従ってください：

- ビデオを含む [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) をロードします。
- ノート マスターおよびすべてのノート スライドのヘッダーとフッター設定を変更します。
- マスター ノート スライドとすべての子フッター プレースホルダーを表示に設定します。
- マスター ノート スライドとすべての子日付と時刻 プレースホルダーを表示に設定します。
- 最初のノート スライドのみのヘッダーとフッター設定を変更します。
- ノート スライドのヘッダー プレースホルダーを表示に設定します。
- ノート スライドのヘッダー プレースホルダーにテキストを設定します。
- ノート スライドの日付-時刻 プレースホルダーにテキストを設定します。
- 変更されたプレゼンテーション ファイルを書き出します。

以下の例でコード スニペットが提供されています。
```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // ノート マスターとすべてのノート スライドのヘッダーとフッター設定を変更する
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // マスターノートスライドとすべての子フッタープレースホルダーを表示にする
        headerFooterManager.setFooterAndChildFootersVisibility(true); // マスターノートスライドとすべての子ヘッダープレースホルダーを表示にする
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // マスターノートスライドとすべての子スライド番号プレースホルダーを表示にする
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // マスターノートスライドとすべての子日付と時刻プレースホルダーを表示にする

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // マスターノートスライドとすべての子ヘッダープレースホルダーにテキストを設定する
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // マスターノートスライドとすべての子フッタープレースホルダーにテキストを設定する
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // マスターノートスライドとすべての子日付と時刻プレースホルダーにテキストを設定する
    }

    // 最初のノートスライドのみのヘッダーとフッター設定を変更する
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // このノートスライドのヘッダープレースホルダーを表示にする

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // このノートスライドのフッタープレースホルダーを表示にする

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // このノートスライドのスライド番号プレースホルダーを表示にする

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // このノートスライドの日付時刻プレースホルダーを表示にする

        headerFooterManager.setHeaderText("New header text"); // ノートスライドのヘッダープレースホルダーにテキストを設定する
        headerFooterManager.setFooterText("New footer text"); // ノートスライドのフッタープレースホルダーにテキストを設定する
        headerFooterManager.setDateTimeText("New date and time text"); // ノートスライドの日付時刻プレースホルダーにテキストを設定する
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**通常のスライドに「ヘッダー」を追加できますか？**

PowerPoint では、ヘッダーはノートと配布資料にのみ存在し、通常のスライドではフッター、日付/時刻、スライド番号のみがサポートされています。Aspose.Slides でも同じ制限が適用され、ヘッダーはノート/配布資料にのみ、スライド上ではフッター、DateTime、SlideNumber が利用可能です。

**レイアウトにフッター領域が含まれていない場合、表示を「オン」にできますか？**

はい。ヘッダー/フッター マネージャーで表示状態を確認し、必要に応じて有効にします。これらの API 指標とメソッドは、プレースホルダーが存在しない、または非表示の場合に対応するよう設計されています。

**スライド番号を 1 以外の値から開始するにはどうすればよいですか？**

プレゼンテーションの [first slide number](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) を設定します。その後、すべての番号付けが再計算されます。たとえば、0 や 10 から開始し、タイトル スライドの番号を非表示にすることができます。

**PDF/画像/HTML にエクスポートするとき、ヘッダー/フッターはどうなりますか？**

ヘッダーとフッターはプレゼンテーションの通常のテキスト要素としてレンダリングされます。つまり、スライドやノートページで要素が表示されている場合、出力形式でも他のコンテンツと同様に表示されます。