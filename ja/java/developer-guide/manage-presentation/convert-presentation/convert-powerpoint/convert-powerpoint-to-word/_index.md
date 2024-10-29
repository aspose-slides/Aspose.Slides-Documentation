---
title: PowerPointをWordに変換
type: docs
weight: 110
url: /ja/java/convert-powerpoint-to-word/
keywords: "PowerPointを変換, PPT, PPTX, プレゼンテーション, Word, DOCX, DOC, PPTXをDOCXに, PPTをDOCに, PPTXをDOCに, PPTをDOCXに, Java, java, Aspose.Slides"
description: "JavaでPowerPointプレゼンテーションをWordに変換"
---

プレゼンテーション（PPTまたはPPTX）から新しい方法でテキストコンテンツや情報を使用する予定がある場合、プレゼンテーションをWord（DOCまたはDOCX）に変換することが役立ちます。

* Microsoft PowerPointと比較して、Microsoft Wordアプリはコンテンツ用のツールや機能が豊富です。
* Wordの編集機能に加えて、コラボレーション、印刷、共有機能を強化することもできます。

{{% alert color="primary" %}} 

スライドのテキストコンテンツを利用することで得られるものを確認するために、私たちの[**プレゼンテーションをWordにオンライン変換するツール**](https://products.aspose.app/slides/conversion/ppt-to-word)を試してみることをお勧めします。

{{% /alert %}} 

## **Aspose.SlidesとAspose.Words**

PowerPointファイル（PPTXまたはPPT）をWord（DOCXまたはDOCX）に変換するには、[Aspose.Slides for Java](https://products.aspose.com/slides/java/)と[Aspose.Words for Java](https://products.aspose.com/words/java/)の両方が必要です。

スタンドアロンAPIとして、[Aspose.Slides](https://products.aspose.app/slides) for Javaは、プレゼンテーションからテキストを抽出することを可能にする機能を提供します。

[Aspose.Words](https://docs.aspose.com/words/java/)は、高度な文書処理APIであり、アプリケーションがMicrosoft Wordを利用せずに、ファイルの生成、変更、変換、レンダリング、印刷、および他の文書作業を行うことを可能にします。

## **PowerPointをWordに変換**

1. [Aspose.Slides for Java](https://downloads.aspose.com/slides/java)と[Aspose.Words for Java](https://downloads.aspose.com/words/java)ライブラリをダウンロードします。
2. *aspose-slides-x.x-jdk16.jar*と*aspose-words-x.x-jdk16.jar*をCLASSPATHに追加します。
3. このコードスニペットを使用してPowerPointをWordに変換します：

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