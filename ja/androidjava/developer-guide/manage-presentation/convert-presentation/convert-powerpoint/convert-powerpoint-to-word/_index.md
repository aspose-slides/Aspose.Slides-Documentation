---
title: Android で PowerPoint プレゼンテーションを Word 文書に変換
linktitle: PowerPoint を Word に変換
type: docs
weight: 110
url: /ja/androidjava/convert-powerpoint-to-word/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を Word に変換
- プレゼンテーションを Word に変換
- スライドを Word に変換
- PPT を Word に変換
- PPTX を Word に変換
- PowerPoint を DOCX に変換
- プレゼンテーションを DOCX に変換
- スライドを DOCX に変換
- PPT を DOCX に変換
- PPTX を DOCX に変換
- PowerPoint を DOC に変換
- プレゼンテーションを DOC に変換
- スライドを DOC に変換
- PPT を DOC に変換
- PPTX を DOC に変換
- PPT を DOCX として保存
- PPTX を DOCX として保存
- PPT を DOCX にエクスポート
- PPTX を DOCX にエクスポート
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides を使用して、Java で PowerPoint の PPT および PPTX スライドを編集可能な Word 文書に変換し、レイアウト、画像、書式設定を正確に保持します。"
---

プレゼンテーション（PPT または PPTX）からテキスト コンテンツや情報を新しい方法で活用したい場合、プレゼンテーションを Word（DOC または DOCX）に変換すると便利です。

* Microsoft PowerPoint と比較して、Microsoft Word アプリはコンテンツに関するツールや機能がより充実しています。
* Word の編集機能に加えて、コラボレーション、印刷、共有機能も強化されています。

{{% alert color="primary" %}}

テキスト コンテンツをスライドから活用するメリットを確認するには、[**スライドから Word へのオンライン変換ツール**](https://products.aspose.app/slides/conversion/ppt-to-word) をお試しください。

{{% /alert %}}

## **Aspose.Slides と Aspose.Words**

PowerPoint ファイル（PPTX または PPT）を Word（DOCX または DOCX）に変換するには、[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) と [Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/) の両方が必要です。

単体 API としての [Aspose.Slides](https://products.aspose.app/slides) for java は、プレゼンテーションからテキストを抽出する機能を提供します。

[Aspose.Words](https://docs.aspose.com/words/androidjava/) は、Microsoft Word を使用せずにドキュメントの生成、変更、変換、レンダリング、印刷などを行える高度な文書処理 API です。

## **PowerPoint を Word に変換する**

1. [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/java) と [Aspose.Words for Java](https://downloads.aspose.com/words/java) ライブラリをダウンロードします。
2. *aspose-slides-x.x-jdk16.jar* と *aspose-words-x.x-jdk16.jar* を CLASSPATH に追加します。
3. 以下のコード スニペットを使用して PowerPoint を Word に変換します:
```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // スライド画像をバイト配列ストリームとして生成します
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // スライドのテキストを挿入します
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```


## **FAQ**

**PowerPoint と OpenDocument のプレゼンテーションを Word 文書に変換するために必要なコンポーネントは何ですか？**

プロジェクトに [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/androidjava/) と [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) の該当パッケージを追加するだけで済みます。両方のライブラリは単体 API として動作し、Microsoft Office のインストールは不要です。

**すべての PowerPoint と OpenDocument プレゼンテーション形式がサポートされていますか？**

Aspose.Slides は [すべてのプレゼンテーション形式をサポート](/slides/ja/androidjava/supported-file-formats/) しており、PPT、PPTX、ODP などの一般的なファイルタイプに対応しています。これにより、さまざまなバージョンの Microsoft PowerPoint で作成されたプレゼンテーションを扱うことができます。