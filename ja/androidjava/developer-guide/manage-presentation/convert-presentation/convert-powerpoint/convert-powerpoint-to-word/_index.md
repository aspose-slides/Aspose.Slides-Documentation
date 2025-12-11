---
title: Android で PowerPoint プレゼンテーションを Word ドキュメントに変換
linktitle: PowerPoint から Word へ
type: docs
weight: 110
url: /ja/androidjava/convert-powerpoint-to-word/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint から Word へ
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
description: "Aspose.Slides for Android を使用し、正確なレイアウト、画像、書式を保持したまま、Java で PowerPoint の PPT および PPTX スライドを編集可能な Word ドキュメントに変換します。"
---

プレゼンテーション（PPT または PPTX）からテキストコンテンツや情報を新しい方法で使用する予定がある場合、プレゼンテーションを Word（DOC または DOCX）に変換すると便利です。 

* Microsoft PowerPoint と比較すると、Microsoft Word アプリはコンテンツ向けのツールや機能がより充実しています。 
* Word の編集機能に加えて、強化された共同作業、印刷、共有機能も利用できます。 

{{% alert color="primary" %}} 
スライドのテキストコンテンツを活用して得られるメリットを確認するために、[**Presentation to Word Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) をぜひお試しください。 
{{% /alert %}} 

## **Aspose.Slides と Aspose.Words**

PowerPoint ファイル（PPTX または PPT）を Word（DOCX または DOCX）に変換するには、[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) と [Aspose.Words for Android via Java](https://products.aspose.com/words/androidjava/) の両方が必要です。

スタンドアロン API として、Java 用の [Aspose.Slides](https://products.aspose.app/slides) はプレゼンテーションからテキストを抽出する機能を提供します。 

[Aspose.Words](https://docs.aspose.com/words/androidjava/) は、Microsoft Word を使用せずに、アプリケーションがドキュメントを生成、変更、変換、レンダリング、印刷し、その他の処理を行うことができる高度な文書処理 API です。

## **PowerPoint を Word に変換**

1. [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/java) と [Aspose.Words for Java](https://downloads.aspose.com/words/java) ライブラリをダウンロードします。
2. *aspose-slides-x.x-jdk16.jar* と *aspose-words-x.x-jdk16.jar* を CLASSPATH に追加します。
3. 次のコードスニペットを使用して PowerPoint を Word に変換します:
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

**PowerPoint および OpenDocument プレゼンテーションを Word 文書に変換するために必要なコンポーネントは何ですか？**

プロジェクトに、[Aspose.Slides for Android via Java](https://releases.aspose.com/slides/androidjava/) と [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) の各パッケージを追加するだけで構いません。両方のライブラリはスタンドアロン API として動作し、Microsoft Office をインストールする必要はありません。

**すべての PowerPoint および OpenDocument プレゼンテーション形式はサポートされていますか？**

Aspose.Slides は、PPT、PPTX、ODP、その他の一般的なファイルタイプを含む [すべてのプレゼンテーション形式をサポート](/slides/ja/androidjava/supported-file-formats/) しています。これにより、さまざまなバージョンの Microsoft PowerPoint で作成されたプレゼンテーションを扱うことができます。