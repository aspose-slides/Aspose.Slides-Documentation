---
title: Python için Aspose.Slides'te Çoklu İş Parçacığı
linktitle: Çoklu İş Parçacığı
type: docs
weight: 200
url: /tr/python-net/multithreading/
keywords:
- çoklu iş parçacığı
- birden fazla iş parçacığı
- paralel çalışma
- slaytları dönüştür
- slaytları görüntülere
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET çoklu iş parçacığı, PowerPoint ve OpenDocument işleme hızını artırır. Verimli sunum iş akışları için en iyi uygulamaları keşfedin."
---
## **Giriş**

Sunumlarla paralel çalışma (parsing/yükleme/kopyalama dışında) mümkün olduğu ve çoğu zaman her şey sorunsuz gittiği halde, kütüphaneyi birden fazla iş parçacığında kullandığınızda hatalı sonuçlar almanız olasılığı vardır.

Çok iş parçacıklı bir ortamda tek bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği **kullanmamalısınız**, çünkü bu, kolayca tespit edilemeyen öngörülemeyen hatalar veya başarısızlıklara yol açabilir.  

Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini birden fazla iş parçacığında yüklemek, kaydetmek ve/veya kopyalamak **güvenli **değil**. Bu tür işlemler **desteklenmez**. Böyle görevleri yerine getirmeniz gerekiyorsa, işlemleri birkaç tek iş parçacıklı süreç kullanarak paralel hâle getirmelisiniz ve bu süreçlerin her biri kendi sunum örneğini kullanmalıdır. 

## **Sunum Slaytlarını Paralel Olarak Görsellere Dönüştür**

Diyelim ki bir PowerPoint sunumundaki tüm slaytları paralel olarak PNG görsellere dönüştürmek istiyoruz. Tek bir `Presentation` örneğini birden fazla iş parçacığında kullanmak güvenli olmadığından, sunum slaytlarını ayrı ayrı sunumlara ayırıyor ve slaytları paralel olarak görsellere dönüştürüyoruz; her bir sunumu ayrı bir iş parçacığında kullanıyoruz. Aşağıdaki kod örneği bunun nasıl yapılacağını gösterir.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # i. slaytı ayrı bir sunuma aktar.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Slaytı bir görsele dönüştür.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Tüm görevlerin tamamlanmasını bekle.
for task in conversion_tasks:
    task.result()

del presentation
```

## **SSS**

**Her iş parçacığında lisans ayarını çağırmam gerekir mi?**

Hayır. İş parçacıkları başlamadan önce işlem/app domain başına bir kez yapmak yeterlidir. Eğer [license setup](/slides/tr/python-net/licensing/) eşzamanlı olarak çağrılabilir (örneğin, tembel başlatma sırasında), bu çağrıyı senkronize edin çünkü lisans ayarı yöntemi kendisi iş parçacığı güvenli değildir.

**`Presentation` veya `Slide` nesnelerini iş parçacıkları arasında aktarabilir miyim?**

"Canlı" sunum nesnelerini iş parçacıkları arasında geçirmek önerilmez: her iş parçacığı için bağımsız örnekler kullanın veya her iş parçacığı için ayrı sunum/slide kapsayıcıları önceden oluşturun. Bu yaklaşım, tek bir sunum örneğini iş parçacıkları arasında paylaşmamaya yönelik genel öneriyi takip eder.

**Her iş parçacığının kendi `Presentation` örneğine sahip olduğu koşulda farklı formatlara (PDF, HTML, görseller) dışa aktarmayı paralelleştirmek güvenli mi?**

Evet. Bağımsız örnekler ve ayrı çıktı yolları ile bu görevler genellikle doğru şekilde paralelleşir; ortak sunum nesnelerinden ve ortak I/O akışlarından kaçının.

**Çok iş parçacıklı ortamda genel font ayarları (klasörler, ikameler) ile ne yapmalıyım?**

Tüm genel font ayarlarını iş parçacıklarını başlatmadan önce başlatın ve paralel çalışma sırasında değiştirmeyin. Bu, paylaşılan font kaynaklarına erişimde yarış koşullarını ortadan kaldırır.