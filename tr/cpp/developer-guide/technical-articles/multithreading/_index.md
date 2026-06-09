---
title: C++ için Aspose.Slides'de Çoklu İş Parçacığı Kullanımı
linktitle: Çoklu İş Parçacığı
type: docs
weight: 200
url: /tr/cpp/multithreading/
keywords:
- çoklu iş parçacığı
- birden çok iş parçacığı
- paralel çalışma
- slaytları dönüştür
- slaytlardan görsellere
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: C++ için Aspose.Slides çoklu iş parçacığı, PowerPoint ve OpenDocument işleme performansını artırır. Verimli sunum iş akışları için en iyi uygulamaları keşfedin.
---
## **Giriş**

Sunumlarla paralel çalışma (ayrıca ayrıştırma/yükleme/kopyalama dışında) mümkün olmakta ve her şey (çoğu zaman) sorunsuz ilerlese de, kütüphaneyi birden fazla iş parçacığında kullandığınızda hatalı sonuçlar elde etme olasılığı küçüktür.

Çok iş parçacıklı bir ortamda tek bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) örneğini **kullanmamanızı** şiddetle öneririz; çünkü bu, kolayca tespit edilemeyen öngörülemeyen hatalar veya başarısızlıklara yol açabilir.  

Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının örneğini birden fazla iş parçacığında yüklemek, kaydetmek ve/veya kopyalamak **güvenli değildir**. Bu tür işlemler **desteklenmez**. Bu görevleri gerçekleştirmeniz gerekirse, işlemleri birkaç tek iş parçacıklı süreçle paralelleştirmeniz gerekir; ve bu süreçlerin her biri kendi sunum örneğini kullanmalıdır.  

## **Sunum Slaytlarını Paralel Olarak Görsellere Dönüştürme**

Tüm PowerPoint sunum slaytlarını paralel olarak PNG görsellere dönüştürmek istediğimizi varsayalım. Tek bir `Presentation` örneğini birden fazla iş parçacığında kullanmak güvenli olmadığından, slaytları ayrı sunumlara bölüp her birini ayrı bir iş parçacığında paralel olarak görsele dönüştürüyoruz. Aşağıdaki kod örneği bunu nasıl yapacağınızı gösterir.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // i. slaytı ayrı bir sunuma çıkar.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Slaytı ayrı bir görevde görsele dönüştür.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// Tüm görevlerin tamamlanmasını bekle.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **SSS**

**Her iş parçacığında lisans kurulumunu çağırmam gerekiyor mu?**

Hayır. İş parçacıkları başlamadan önce işlem/app domain başına bir kez yapmak yeterlidir. Eğer [license setup](/slides/tr/cpp/licensing/) aynı anda çağrılabilir (örneğin tembel başlatma sırasında) ise, bu çağrıyı eşzamanlayın; çünkü lisans kurulum yöntemi kendisi iş parçacığı güvenli değildir.

**`Presentation` veya `Slide` nesnelerini iş parçacıkları arasında aktarabilir miyim?**

“Canlı” sunum nesnelerini iş parçacıkları arasında geçirmek önerilmez: her iş parçacığı için bağımsız örnekler kullanın veya her iş parçacığı için ayrı sunum/slayt konteynerleri önceden oluşturun. Bu yaklaşım, tek bir sunum örneğini iş parçacıkları arasında paylaşmama önerisine uygundur.

**Her iş parçacığının kendi `Presentation` örneğine sahip olduğu sürece farklı formatlara (PDF, HTML, görseller) dışa aktarmayı paralelleştirmek güvenli mi?**

Evet. Bağımsız örnekler ve ayrı çıkış yolları ile bu tür görevler genellikle doğru bir şekilde paralelleşir; ortak sunum nesneleri ve ortak I/O akışlarından kaçının.

**Çok iş parçacıklı ortamda küresel yazı tipi ayarları (klasörler, ikameler) ile ne yapmalıyım?**

Tüm küresel yazı tipi ayarlarını iş parçacıklarını başlatmadan önce başlatın ve paralel çalışma sırasında değiştirmeyin. Bu, ortak yazı tipi kaynaklarına erişimde yarış durumlarını ortadan kaldırır.