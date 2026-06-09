---
title: Python'da PowerPoint Sunumlarını Word Belgelerine Dönüştürme
linktitle: PowerPoint'ten Word'e
type: docs
weight: 110
url: /tr/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint'ten DOCX'e
- OpenDocument'ten DOCX'e
- sunumdan DOCX'e
- slayttan DOCX'e
- PPT'den DOCX'e
- PPTX'den DOCX'e
- ODP'den DOCX'e
- PowerPoint'ten DOC'a
- OpenDocument'ten DOC'a
- sunumdan DOC'a
- slayttan DOC'a
- PPT'den DOC'a
- PPTX'den DOC'a
- ODP'den DOC'a
- PowerPoint'ten Word'e
- OpenDocument'ten Word'e
- sunumdan Word'e
- slayttan Word'e
- PPT'den Word'e
- PPTX'den Word'e
- ODP'den Word'e
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- ODP dönüştür
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarını Word belgelerine zahmetsizce nasıl dönüştüreceğinizi öğrenin. Örnek Python kodu içeren adım adım rehberimiz, belge iş akışlarını basitleştirmek isteyen geliştiriciler için çözüm sunar."
---
## **Genel Bakış**

Bu makale, geliştiricilere Aspose.Slides for Python via .NET ve Aspose.Words for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarını Word belgelerine dönüştürme konusunda bir çözüm sunar. Adım adım rehber, dönüştürme sürecinin her aşamasında size yol gösterir.

## **Bir Sunumu Word Belgesine Dönüştürme**

PowerPoint veya OpenDocument sunumunu bir Word belgesine dönüştürmek için aşağıdaki talimatları izleyin:

1. Sunum dosyasını yüklemek için [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Word belgesi oluşturmak için [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) ve [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) sınıflarının bir örneğini oluşturun.  
3. [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) özelliğini kullanarak Word belgesinin sayfa boyutunu sunumun sayfa boyutuna eşitleyin.  
4. [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) özelliğini kullanarak Word belgesinde kenar boşluklarını ayarlayın.  
5. [Presentation.slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/slides/tr/) özelliğini kullanarak tüm sunum slaytlarını dolaşın.  
    - [Slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/) sınıfının `get_image` yöntemini kullanarak bir slayt resmi oluşturun ve bunu bir bellek akışına kaydedin.  
    - [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) sınıfının `insert_image` yöntemini kullanarak slayt resmini Word belgesine ekleyin.  
6. Word belgesini bir dosyaya kaydedin.

Diyelim ki "sample.pptx" adlı bir sunumumuz var ve şu şekilde görünüyor:

![PowerPoint presentation](PowerPoint.png)

Aşağıdaki Python kod örneği, PowerPoint sunumunu bir Word belgesine nasıl dönüştüreceğinizi gösterir:

```py
import aspose.slides as slides
import aspose.words as words

# Sunum dosyasını yükle.
with slides.Presentation("sample.pptx") as presentation:

    # Document ve DocumentBuilder nesnelerini oluştur.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Word belgesindeki sayfa boyutunu ayarla.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Word belgesindeki kenar boşluklarını ayarla.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # Tüm sunum slaytlarını dolaş.
    for slide in presentation.slides:

        # Bir slayt resmi oluştur ve bir bellek akışına kaydet.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # Slayt resmini Word belgesine ekle.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Word belgesini bir dosyaya kaydet.
    document.save("output.docx")
```

Sonuç:

![Word document](Word.png)

{{% alert color="primary" %}} 

PowerPoint ve OpenDocument sunumlarını Word belgelerine dönüştürerek neler kazanabileceğinizi görmek için [**Online PPT to Word Converter**](https://products.aspose.app/slides/tr/conversion/ppt-to-word) aracını deneyin. 

{{% /alert %}}

## **SSS**

**PowerPoint ve OpenDocument sunumlarını Word belgelerine dönüştürmek için hangi bileşenlerin kurulması gerekir?**

Python projenize yalnızca [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) ve [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) paketlerini eklemeniz yeterlidir. Her iki paket de bağımsız API'ler olarak çalışır ve Microsoft Office'in kurulu olmasına gerek yoktur.

**Tüm PowerPoint ve OpenDocument sunum formatları destekleniyor mu?**

Aspose.Slides for Python .NET [tüm sunum formatlarını destekler](/slides/tr/python-net/supported-file-formats/), PPT, PPTX, ODP ve diğer yaygın dosya türleri dahil. Bu, Microsoft PowerPoint'in farklı sürümlerinde oluşturulmuş sunumlarla çalışabilmenizi sağlar.