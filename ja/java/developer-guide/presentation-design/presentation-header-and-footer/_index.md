---
title: プレゼンテーションのヘッダーとフッター
type: docs
weight: 140
url: /ja/java/presentation-header-and-footer/
keywords: "JavaのPowerPointヘッダーとフッター"
description: "JavaのPowerPointヘッダーとフッター"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ja/java/) は、実際にスライドマスターレベルで維持されているスライドのヘッダーとフッターのテキストを操作するためのサポートを提供します。

{{% /alert %}} 

[Aspose.Slides for Java](/slides/ja/java/) は、プレゼンテーションスライド内のヘッダーとフッターを管理する機能を提供します。これらは実際にはプレゼンテーションマスターレベルで管理されています。

## **プレゼンテーションのヘッダーとフッターを管理する**
特定のスライドのノートは、以下の例のように削除できます：

```java
// プレゼンテーションをロード
Presentation pres = new Presentation("headerTest.pptx");
try {
    // フッターの設定
    pres.getHeaderFooterManager().setAllFootersText("私のフッターテキスト");
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
                ((IAutoShape)shape).getTextFrame().setText("こんにちは、新しいヘッダー");
            }
        }
    }
}
```

## **配布用スライドとノートスライドのヘッダーとフッターを管理する**
Aspose.Slides for Javaは、配布用スライドとノートスライドのヘッダーとフッターをサポートしています。以下の手順に従ってください：

- ビデオを含む[プレゼンテーション](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)をロードします。
- ノートマスターとすべてのノートスライドのヘッダーとフッターの設定を変更します。
- マスターノートスライドとすべての子フッタープレースホルダーを表示します。
- マスターノートスライドとすべての子日付および時刻プレースホルダーを表示します。
- 最初のノートスライドだけのヘッダーとフッターの設定を変更します。
- ノートスライドのヘッダープレースホルダーを表示します。
- ノートスライドのヘッダープレースホルダーにテキストを設定します。
- ノートスライドの日時プレースホルダーにテキストを設定します。
- 修正されたプレゼンテーションファイルを書き込みます。

以下の例にコードスニペットが提供されています。

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // ノートマスターとすべてのノートスライドのヘッダーとフッターの設定を変更
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // マスターノートスライドとすべての子フッタープレースホルダーを表示
        headerFooterManager.setFooterAndChildFootersVisibility(true); // マスターノートスライドとすべての子ヘッダープレースホルダーを表示
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // マスターノートスライドとすべての子スライド番号プレースホルダーを表示
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // マスターノートスライドとすべての子日付および時刻プレースホルダーを表示

        headerFooterManager.setHeaderAndChildHeadersText("ヘッターテキスト"); // マスターノートスライドとすべての子ヘッダープレースホルダーにテキストを設定
        headerFooterManager.setFooterAndChildFootersText("フッターテキスト"); // マスターノートスライドとすべての子フッタープレースホルダーにテキストを設定
        headerFooterManager.setDateTimeAndChildDateTimesText("日付と時刻のテキスト"); // マスターノートスライドとすべての子日付および時刻プレースホルダーにテキストを設定
    }

    // 最初のノートスライドだけのヘッダーとフッター設定を変更
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // このノートスライドのヘッダープレースホルダーを表示

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // このノートスライドのフッタープレースホルダーを表示

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // このノートスライドのスライド番号プレースホルダーを表示

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // このノートスライドの日付時刻プレースホルダーを表示

        headerFooterManager.setHeaderText("新しいヘッダーテキスト"); // ノートスライドのヘッダープレースホルダーにテキストを設定
        headerFooterManager.setFooterText("新しいフッターテキスト"); // ノートスライドのフッタープレースホルダーにテキストを設定
        headerFooterManager.setDateTimeText("新しい日付と時刻のテキスト"); // ノートスライドの日付時刻プレースホルダーにテキストを設定
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```