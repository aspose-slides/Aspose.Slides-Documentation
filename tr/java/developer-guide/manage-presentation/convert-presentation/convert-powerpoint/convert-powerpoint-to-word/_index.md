---
title: Java'da PowerPoint Sunumlarını Word Belgelerine Dönüştürme
linktitle: PowerPoint'ten Word'e
type: docs
weight: 110
url: /tr/java/convert-powerpoint-to-word/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten Word'e
- sunumdan Word'e
- slayttan Word'e
- PPT'den Word'e
- PPTX'den Word'e
- PowerPoint'ten DOCX'e
- sunumdan DOCX'e
- slayttan DOCX'e
- PPT'den DOCX'e
- PPTX'den DOCX'e
- PowerPoint'ten DOC'a
- sunumdan DOC'a
- slayttan DOC'a
- PPT'den DOC'a
- PPTX'den DOC'a
- PPT'yi DOCX olarak kaydet
- PPTX'i DOCX olarak kaydet
- PPT'yi DOCX'e dışa aktar
- PPTX'i DOCX'e dışa aktar
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak, PowerPoint PPT ve PPTX slaytlarını Java'da düzenlenebilir Word belgelerine, kesin düzen, görseller ve biçimlendirme korunarak dönüştürün."
---
## **Genel Bakış**

Bu makale, geliştiricilere Aspose.Slides ve Aspose.Words kullanarak PowerPoint ve OpenDocument sunumlarını Word belgelerine dönüştürme çözümü sunar. Adım adım rehber, dönüşüm sürecinin her aşamasında size yol gösterir.

## **PowerPoint'i Word'e Dönüştür**

Aşağıdaki talimatları izleyerek bir PowerPoint veya OpenDocument sunumunu Word belgesine dönüştürün:

1. İndir [Aspose.Slides for Java](https://downloads.aspose.com/slides/tr/java) ve [Aspose.Words for Java](https://downloads.aspose.com/words/java) kütüphanelerini.
2. *aspose-slides-x.x-jdk16.jar* ve *aspose-words-x.x-jdk16.jar* dosyalarını CLASSPATH'ınıza ekleyin.
3. PowerPoint'i Word'e dönüştürmek için bu kod parçacığını kullanın:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // slayt görüntüsünü bayt dizisi akışı olarak oluşturur
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // slaytın metinlerini ekler
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

## **SSS**

**PowerPoint ve OpenDocument sunumlarını Word belgelerine dönüştürmek için hangi bileşenlerin kurulması gerekir?**

Projenize yalnızca [Aspose.Slides for Java](https://releases.aspose.com/slides/tr/java/) ve [Aspose.Words for Java](https://releases.aspose.com/words/java/) paketlerini eklemeniz yeterlidir. Her iki kütüphane de bağımsız API'lar olarak çalışır ve Microsoft Office'in kurulmasına gerek yoktur.

**Tüm PowerPoint ve OpenDocument sunum formatları destekleniyor mu?**

Aspose.Slides [tüm sunum formatlarını destekler](/slides/tr/java/supported-file-formats/), PPT, PPTX, ODP ve diğer yaygın dosya türleri dahil. Bu, Microsoft PowerPoint'in farklı sürümlerinde oluşturulmuş sunumlarla çalışabilmenizi sağlar.