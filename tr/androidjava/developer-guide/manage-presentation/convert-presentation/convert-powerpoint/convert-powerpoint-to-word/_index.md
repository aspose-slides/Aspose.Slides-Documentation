---
title: Android'de PowerPoint Sunumlarını Word Belgelerine Dönüştürme
linktitle: PowerPoint'ten Word'e
type: docs
weight: 110
url: /tr/androidjava/convert-powerpoint-to-word/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten Word'e
- sunumu Word'e
- slaytı Word'e
- PPT'den Word'e
- PPTX'ten Word'e
- PowerPoint'ten DOCX'e
- sunumu DOCX'e
- slaytı DOCX'e
- PPT'den DOCX'e
- PPTX'ten DOCX'e
- PowerPoint'ten DOC'a
- sunumu DOC'a
- slaytı DOC'a
- PPT'den DOC'a
- PPTX'ten DOC'a
- PPT'yi DOCX olarak kaydet
- PPTX'i DOCX olarak kaydet
- PPT'yi DOCX'e dışa aktar
- PPTX'i DOCX'e dışa aktar
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak Java'da PowerPoint PPT ve PPTX slaytlarını düzenlenebilir Word belgelerine dönüştürün; kesin düzen, görüntüler ve biçimlendirme korunur."
---
## **Genel Bakış**

Bu makale, geliştiricilere Aspose.Slides ve Aspose.Words kullanarak PowerPoint ve OpenDocument sunumlarını Word belgelerine dönüştürme konusunda bir çözüm sunar. Adım adım kılavuz, dönüşüm sürecinin her aşamasında size rehberlik eder.

## **Aspose.Slides ve Aspose.Words**

PowerPoint dosyasını (PPTX veya PPT) Word (DOCX veya DOCX) formatına dönüştürmek için hem [Aspose.Slides for Android via Java](https://products.aspose.com/slides/tr/androidjava/) hem de [Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/) gereklidir.

Bağımsız bir API olarak, java için [Aspose.Slides](https://products.aspose.app/slides) sunumlardan metin çıkarmanıza olanak tanıyan işlevler sunar.

[Aspose.Words](https://docs.aspose.com/words/androidjava/) belge işleme konusunda gelişmiş bir API olup, uygulamaların dosyaları oluşturmasını, düzenlemesini, dönüştürmesini, render etmesini, yazdırmasını ve Microsoft Word kullanmadan belgelerle diğer görevleri gerçekleştirmesini sağlar.

## **PowerPoint'i Word'e Dönüştürme**

1. [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/tr/java) ve [Aspose.Words for Java](https://downloads.aspose.com/words/java) kitaplıklarını indirin.  
2. *aspose-slides-x.x-jdk16.jar* ve *aspose-words-x.x-jdk16.jar* dosyalarını CLASSPATH'inize ekleyin.  
3. PowerPoint'i Word'e dönüştürmek için bu kod parçacığını kullanın:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // slayt görselini bayt dizisi akışı olarak oluşturur
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // slayt metinlerini ekler
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

Projenize yalnızca ilgili paketleri [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/tr/androidjava/) ve [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) eklemeniz yeterlidir. Her iki kütüphane de bağımsız API'ler olarak çalışır ve Microsoft Office'in yüklü olması gerekmez.

**Tüm PowerPoint ve OpenDocument sunum formatları destekleniyor mu?**

Aspose.Slides [tüm sunum formatlarını destekler](/slides/tr/androidjava/supported-file-formats/), PPT, PPTX, ODP ve diğer yaygın dosya türleri dahil. Bu, çeşitli Microsoft PowerPoint sürümlerinde oluşturulmuş sunumlarla çalışabileceğiniz anlamına gelir.