---
title: Android で PowerPoint プレゼンテーションを Word 文書に変換
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
- プレゼンテーションから Word へ
- スライドから Word へ
- PPT から Word へ
- PPTX から Word へ
- PowerPoint から DOCX へ
- プレゼンテーションから DOCX へ
- スライドから DOCX へ
- PPT から DOCX へ
- PPTX から DOCX へ
- PowerPoint から DOC へ
- プレゼンテーションから DOC へ
- スライドから DOC へ
- PPT から DOC へ
- PPTX から DOC へ
- PPT を DOCX として保存
- PPTX を DOCX として保存
- PPT を DOCX にエクスポート
- PPTX を DOCX にエクスポート
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用し、正確なレイアウト、画像、書式を保持したまま、Java で PowerPoint の PPT および PPTX スライドを編集可能な Word 文書に変換します。"
---

プレゼンテーション（PPT または PPTX）のテキストコンテンツや情報を新しい形で利用する場合、プレゼンテーションを Word（DOC または DOCX）に変換すると便利です。

* Microsoft PowerPoint と比較して、Microsoft Word アプリはコンテンツ向けのツールや機能が豊富です。  
* Word の編集機能に加えて、コラボレーション、印刷、共有機能も強化されています。

{{% alert color="primary" %}}  
スライドのテキストコンテンツを活用するメリットを確認するには、[**プレゼンテーションからWordへのオンラインコンバーター**](https://products.aspose.app/slides/conversion/ppt-to-word) をお試しください。  
{{% /alert %}}

## **Aspose.Slides と Aspose.Words**

PowerPoint ファイル（PPTX または PPT）を Word（DOCX または DOC）に変換するには、[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) と [Aspose.Words for Android via Java](https://products.aspose.com/words/androidjava/) の両方が必要です。

単体 API としての [Aspose.Slides](https://products.aspose.app/slides) for java は、プレゼンテーションからテキストを抽出する機能を提供します。

[Aspose.Words](https://docs.aspose.com/words/androidjava/) は、高度なドキュメント処理 API で、Microsoft Word を使用せずに、アプリケーションがファイルの生成、変更、変換、レンダリング、印刷、およびその他のドキュメント操作を行えるようにします。

## **PowerPoint を Word に変換**

1. [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/java) と [Aspose.Words for Java](https://downloads.aspose.com/words/java) ライブラリをダウンロードします。  
2. *aspose-slides-x.x-jdk16.jar* と *aspose-words-x.x-jdk16.jar* を CLASSPATH に追加します。  
3. 以下のコードスニペットを使用して PowerPoint を Word に変換します：  
```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // スライド画像をバイト配列ストリームとして生成
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // スライドのテキストを挿入
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

**PowerPoint および OpenDocument プレゼンテーションを Word ドキュメントに変換するためにインストールが必要なコンポーネントは何ですか？**

[Aspose.Slides for Android via Java](https://releases.aspose.com/slides/androidjava/) と [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) の各パッケージをプロジェクトに追加するだけで済みます。両方のライブラリは単体 API として機能し、Microsoft Office のインストールは不要です。

**すべての PowerPoint および OpenDocument プレゼンテーション形式がサポートされていますか？**

Aspose.Slides は [すべてのプレゼンテーション形式をサポート](/slides/ja/androidjava/supported-file-formats/) しており、PPT、PPTX、ODP などの一般的なファイルタイプを含みます。これにより、さまざまなバージョンの Microsoft PowerPoint で作成されたプレゼンテーションを扱うことができます。