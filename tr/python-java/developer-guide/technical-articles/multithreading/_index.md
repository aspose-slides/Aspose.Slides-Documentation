---
title: Aspose.Slides for Python via Java'da Çok İş Parçacığı Kullanımı
linktitle: Çok İş Parçacığı
type: docs
weight: 310
url: /tr/python-java/multithreading/
keywords:
- çok iş parçacığı
- birden fazla iş parçacığı
- paralel çalışma
- slaytları dönüştür
- slaytlardan görsellere
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da çok iş parçacığı, PowerPoint ve OpenDocument işlemlerini hızlandırır. Verimli sunum iş akışları için en iyi uygulamaları keşfedin."
---
## **Giriş**

Sunumlarla paralel çalışma (ayrıştırma, yükleme ve klonlamayı hariç tutarak) mümkündür ve genellikle iyi çalışır, ancak kütüphaneyi birden çok iş parçacığında kullandığınızda yanlış sonuçların ortaya çıkma ihtimali vardır.

Çok iş parçacıklı bir ortamda tek bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğini **kullanmayınız** öneririz, çünkü bu, öngörülemeyen hatalar veya kolay tespit edilemeyen başarısızlıklara neden olabilir.

Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğini birden fazla iş parçacığında yüklemek, kaydetmek ve/veya klonlamak **güvenli değildir**. Bu tür işlemler **desteklenmez**. Bu görevleri gerçekleştirmeniz gerekiyorsa, işlemleri birkaç tek iş parçacıklı süreç kullanarak paralelleştirmeniz gerekir ve bu süreçlerin her biri kendi sunum örneğini kullanmalıdır.

## **Sunum Slaytlarını Paralel Olarak Görsellere Dönüştürme**

PowerPoint sunumundaki tüm slaytları paralel olarak PNG görsellere dönüştürmek istediğimizi varsayalım. Tek bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğini birden fazla iş parçacığında kullanmak güvenli olmadığından, sunum slaytlarını ayrı sunumlara bölüp, her sunumu ayrı bir iş parçacığında kullanarak slaytları paralel olarak görsellere dönüştürüyoruz. Aşağıdaki kod örneği bunu nasıl yapacağınızı gösterir.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Slaytı ayrı bir sunuma çıkar.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Slaytı ayrı bir görevde görsele dönüştür.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Tüm görevlerin tamamlanmasını bekle.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **SSS**

**Her iş parçacığında lisans kurulumu yapmam gerekir mi?**

Hayır. İş parçacıkları başlamadan önce süreç başına bir kez yapılması yeterlidir. Eğer [license setup](/slides/tr/python-java/licensing/) eşzamanlı olarak çağrılabilir (örneğin tembel başlatma sırasında) ise, bu çağrıyı senkronize edin çünkü lisans kurulum metodu kendisi iş parçacığı güvenli değildir.

**[Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) veya [Slide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/) nesnelerini iş parçacıkları arasında aktarabilir miyim?**

“Canlı” sunum nesnelerini iş parçacıkları arasında geçirmek önerilmez: her iş parçacığı için bağımsız örnekler kullanın veya her iş parçacığı için önceden ayrı sunumlar veya slayt konteynerleri oluşturun. Bu yaklaşım, tek bir sunum örneğinin iş parçacıkları arasında paylaşılmaması yönündeki genel tavsiyeyi takip eder.

**Her iş parçacığının kendi [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğine sahip olması koşuluyla farklı formatlara (PDF, HTML, görseller) dışa aktarmayı paralelleştirmek güvenli mi?**

Evet. Bağımsız örnekler ve ayrı çıktı yolları ile bu görevler genellikle doğru şekilde paralelleşir; ortak sunum nesneleri ve ortak I/O akışlarından kaçının.

**Çok iş parçacıklı ortamda global font ayarları (klasörler, ikameler) ile ne yapmalıyım?**

Tüm global [font settings](/slides/tr/python-java/powerpoint-fonts/) öğelerini iş parçacıklarını başlatmadan önce başlatın ve paralel çalışma sırasında değiştirmeyin. Bu, paylaşılan font kaynaklarına erişimde yarış durumlarını ortadan kaldırır.