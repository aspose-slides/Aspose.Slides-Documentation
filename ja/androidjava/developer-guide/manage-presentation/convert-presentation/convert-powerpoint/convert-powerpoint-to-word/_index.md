---
title: PowerPointをWordに変換
type: docs
weight: 110
url: /ja/androidjava/convert-powerpoint-to-word/
keywords: "PowerPoint 変換, PPT, PPTX, プレゼンテーション, Word, DOCX, DOC, PPTXをDOCXに, PPTをDOCに, PPTXをDOCに, PPTをDOCXに, Java, java, Aspose.Slides"
description: "JavaでPowerPointプレゼンテーションをWordに変換"
---

プレゼンテーション（PPTまたはPPTX）のテキストコンテンツや情報を新しい方法で使用する予定がある場合、プレゼンテーションをWord（DOCまたはDOCX）に変換することで利益を得ることができます。

* Microsoft PowerPointと比較して、Microsoft Wordアプリはコンテンツのためのツールや機能が充実しています。 
* Wordの編集機能に加えて、強化されたコラボレーション、印刷、共有機能を利用できる場合があります。

{{% alert color="primary" %}} 

スライドからのテキストコンテンツを扱うことで得られるものを確認するために、私たちの[**プレゼンテーションをWordオンラインコンバータ**](https://products.aspose.app/slides/conversion/ppt-to-word)を試してみることをお勧めします。 

{{% /alert %}} 

## **Aspose.SlidesとAspose.Words**

PowerPointファイル（PPTXまたはPPT）をWord（DOCXまたはDOC）に変換するには、[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/)と[Aspose.Words for Java](https://products.aspose.com/words/java/)の両方が必要です。

スタンドアロンAPIである[Aspose.Slides](https://products.aspose.app/slides) for Javaは、プレゼンテーションからテキストを抽出する機能を提供します。

[Aspose.Words](https://docs.aspose.com/words/java/)は、アプリケーションがMicrosoft Wordを利用せずにファイルを生成、修正、変換、レンダリング、印刷し、その他のドキュメントに関するタスクを実行できる高度な文書処理APIです。

## **PowerPointをWordに変換**

1. [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/java)と[Aspose.Words for Java](https://downloads.aspose.com/words/java)ライブラリをダウンロードします。
2. *aspose-slides-x.x-jdk16.jar*と*aspose-words-x.x-jdk16.jar*をCLASSPATHに追加します。
3. 以下のコードスニペットを使用してPowerPointをWordに変換します：

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