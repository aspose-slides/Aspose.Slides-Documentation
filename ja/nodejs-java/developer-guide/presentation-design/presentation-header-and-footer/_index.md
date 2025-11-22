---
title: プレゼンテーションのヘッダーとフッター
type: docs
weight: 140
url: /ja/nodejs-java/presentation-header-and-footer/
keywords: "PowerPoint のヘッダーとフッター（JavaScript）"
description: "PowerPoint のヘッダーとフッター（JavaScript）"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ja/nodejs-java/) は、スライドのヘッダーとフッターテキストを操作するサポートを提供します。このテキストは実際にスライドマスターレベルで管理されています。

{{% /alert %}} 

[Aspose.Slides for Node.js via Java](/slides/ja/nodejs-java/) は、プレゼンテーションスライド内のヘッダーとフッターを管理する機能を提供します。これらは実際にプレゼンテーションマスターレベルで管理されています。

## **プレゼンテーションでのヘッダーとフッターの管理**
特定のスライドのノートは、以下の例のように削除できます。
```javascript
// プレゼンテーションを読み込む
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // フッターを設定
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // ヘッダーにアクセスして更新
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // プレゼンテーションを保存
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```


## **配布資料とノートスライドでのヘッダーとフッターの管理**
Aspose.Slides for Node.js via Java は、配布資料およびノートスライドでヘッダーとフッターをサポートしています。以下の手順に従ってください。

- ビデオを含む [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) を読み込みます。
- ノートマスターとすべてのノートスライドのヘッダーとフッター設定を変更します。
- マスターノートスライドとすべての子フッタープレースホルダーを表示に設定します。
- マスターノートスライドとすべての子日付と時刻プレースホルダーを表示に設定します。
- 最初のノートスライドだけのヘッダーとフッター設定を変更します。
- ノートスライドのヘッダープレースホルダーを表示に設定します。
- ノートスライドのヘッダープレースホルダーにテキストを設定します。
- ノートスライドの日付/時刻プレースホルダーにテキストを設定します。
- 変更されたプレゼンテーションファイルを書き出します。

以下の例にコードスニペットが提供されています。
```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // ノートマスターとすべてのノートスライドのヘッダーとフッター設定を変更
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// マスターノートスライドとすべての子フッタープレースホルダーを表示にする
        headerFooterManager.setFooterAndChildFootersVisibility(true);// マスターノートスライドとすべての子ヘッダープレースホルダーを表示にする
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// マスターノートスライドとすべての子スライド番号プレースホルダーを表示にする
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// マスターノートスライドとすべての子日付と時刻プレースホルダーを表示にする
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// マスターノートスライドとすべての子ヘッダープレースホルダーにテキストを設定
        headerFooterManager.setFooterAndChildFootersText("Footer text");// マスターノートスライドとすべての子フッタープレースホルダーにテキストを設定
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// マスターノートスライドとすべての子日付と時刻プレースホルダーにテキストを設定
    }
    // 最初のノートスライドのみのヘッダーとフッター設定を変更
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// このノートスライドのヘッダープレースホルダーを表示にする
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// このノートスライドのフッタープレースホルダーを表示にする
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// このノートスライドのスライド番号プレースホルダーを表示にする
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// このノートスライドの日付と時刻プレースホルダーを表示にする
        headerFooterManager.setHeaderText("New header text");// ノートスライドのヘッダープレースホルダーにテキストを設定
        headerFooterManager.setFooterText("New footer text");// ノートスライドのフッタープレースホルダーにテキストを設定
        headerFooterManager.setDateTimeText("New date and time text");// ノートスライドの日付と時刻プレースホルダーにテキストを設定
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**通常のスライドに「ヘッダー」を追加できますか？**

PowerPoint では、ヘッダーはノートと配布資料にのみ存在し、通常のスライドではフッター、日付/時刻、スライド番号のみがサポートされます。Aspose.Slides でも同じ制限があり、ヘッダーはノート/配布資料にのみ使用でき、スライド上ではフッター、日付/時刻、スライド番号が使用可能です。

**レイアウトにフッター領域が含まれていない場合、表示を「オン」にできますか？**

はい。ヘッダー/フッターマネージャーで可視性を確認し、必要に応じて有効にしてください。これらの API 指標やメソッドは、プレースホルダーが欠落しているか非表示の場合に対応できるよう設計されています。

**スライド番号を 1 以外の値から開始するにはどうすればよいですか？**

プレゼンテーションの [最初のスライド番号](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) を設定します。これ以降、すべての番号付けが再計算されます。例えば、0 や 10 から開始し、タイトルスライドの番号を非表示にすることができます。

**PDF/画像/HTML にエクスポートする際、ヘッダー/フッターはどうなりますか？**

ヘッダーとフッターはプレゼンテーションの通常のテキスト要素としてレンダリングされます。つまり、スライドやノートページで要素が表示されていれば、出力形式でも他のコンテンツと同様に表示されます。