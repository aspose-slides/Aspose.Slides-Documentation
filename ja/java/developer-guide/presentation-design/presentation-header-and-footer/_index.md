---
title: Java でプレゼンテーションのヘッダーとフッターを管理する
linktitle: ヘッダーとフッター
type: docs
weight: 140
url: /ja/java/presentation-header-and-footer/
keywords:
- ヘッダー
- ヘッダーテキスト
- フッター
- フッターテキスト
- ヘッダー設定
- フッター設定
- 配布資料
- ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java 用 Aspose.Slides を使用して、PowerPoint および OpenDocument プレゼンテーションにヘッダーとフッターを追加およびカスタマイズし、プロフェッショナルな外観にします。"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ja/java/) は、スライドのヘッダーとフッターのテキストを操作するサポートを提供します。これらはスライドマスターレベルで管理されています。

{{% /alert %}} 

[Aspose.Slides for Java](/slides/ja/java/) は、プレゼンテーションスライド内のヘッダーとフッターを管理する機能を提供します。これらは実際にはプレゼンテーションマスターレベルで管理されています。

## **プレゼンテーション内のヘッダーとフッターの管理**
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
// ヘッダー/フッターのテキストを設定するメソッド
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


## **ハンドアウトとノートスライドのヘッダーとフッターの管理**
Aspose.Slides for Java は、ハンドアウトとノートスライドでヘッダーとフッターをサポートしています。以下の手順に従ってください：

- ビデオを含む [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) をロードします。
- ノートマスターとすべてのノートスライドのヘッダーとフッター設定を変更します。
- マスターノートスライドとすべての子フッタープレースホルダーを表示に設定します。
- マスターノートスライドとすべての子日付と時刻のプレースホルダーを表示に設定します。
- 最初のノートスライドのみのヘッダーとフッター設定を変更します。
- ノートスライドのヘッダープレースホルダーを表示に設定します。
- ノートスライドのヘッダープレースホルダーにテキストを設定します。
- ノートスライドの日付時刻プレースホルダーにテキストを設定します。
- 変更されたプレゼンテーションファイルを書き出します。

以下の例にコードスニペットが提供されています。
```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // ノートマスタとすべてのノートスライドのヘッダーとフッター設定を変更
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // マスターノートスライドとすべての子フッタープレースホルダーを表示にします
        headerFooterManager.setFooterAndChildFootersVisibility(true); // マスターノートスライドとすべての子ヘッダープレースホルダーを表示にします
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // マスターノートスライドとすべての子スライド番号プレースホルダーを表示にします
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // マスターノートスライドとすべての子日付および時刻プレースホルダーを表示にします

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // マスターノートスライドとすべての子ヘッダープレースホルダーにテキストを設定
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // マスターノートスライドとすべての子フッタープレースホルダーにテキストを設定
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // マスターノートスライドとすべての子日付および時刻プレースホルダーにテキストを設定
    }

    // 最初のノートスライドのみのヘッダーとフッター設定を変更
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // このノートスライドのヘッダープレースホルダーを表示にします

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // このノートスライドのフッタープレースホルダーを表示にします

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // このノートスライドのスライド番号プレースホルダーを表示にします

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // このノートスライドの日付時刻プレースホルダーを表示にします

        headerFooterManager.setHeaderText("New header text"); // ノートスライドのヘッダープレースホルダーにテキストを設定
        headerFooterManager.setFooterText("New footer text"); // ノートスライドのフッタープレースホルダーにテキストを設定
        headerFooterManager.setDateTimeText("New date and time text"); // ノートスライドの日付時刻プレースホルダーにテキストを設定
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**通常のスライドに「ヘッダー」を追加できますか？**

PowerPoint では、ヘッダーはノートとハンドアウトにのみ存在し、通常のスライドではサポートされている要素はフッター、日付/時刻、スライド番号です。Aspose.Slides でも同様の制限があり、ヘッダーはノート/ハンドアウトにのみ使用でき、スライド上ではフッター、日付時刻、スライド番号がサポートされています。

**レイアウトにフッター領域が含まれていない場合、表示を「オン」にできますか？**

はい。ヘッダー/フッターマネージャーで表示状態を確認し、必要に応じて有効化します。これらの API 指標とメソッドは、プレースホルダーが存在しない、または非表示の場合に対応するよう設計されています。

**スライド番号を 1 以外の値から開始するにはどうすればよいですか？**

プレゼンテーションの [first slide number](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) を設定します。これにより、すべての番号が再計算されます。たとえば、0 や 10 から開始でき、タイトルスライドの番号を非表示にすることも可能です。

**PDF/画像/HTML にエクスポートする際、ヘッダー/フッターはどうなりますか？**

ヘッダーとフッターはプレゼンテーションの通常のテキスト要素としてレンダリングされます。つまり、スライドやノートページで要素が表示されている場合、出力形式でも他のコンテンツと同様に表示されます。