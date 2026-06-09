---
title: Aspose.Slides for PHP via Java'da Çok İş Parçacığı
linktitle: Çok İş Parçacığı
type: docs
weight: 310
url: /tr/php-java/multithreading/
keywords:
- çok iş parçacığı
- birden çok iş parçacığı
- paralel çalışma
- slaytları dönüştür
- slaytlardan görüntülere
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java çok iş parçacığı, PowerPoint ve OpenDocument işleme performansını artırır. Verimli sunum iş akışları için en iyi uygulamaları keşfedin."
---
## **Giriş**

Sunumlarla paralel çalışma mümkün olsa da (parçalama/yükleme/kopyalama dışında) ve çoğu zaman her şey yolunda gidebilse de, kütüphaneyi birden fazla iş parçacığında kullandığınızda hatalı sonuçlar elde etme olasılığı vardır.

Çok iş parçacıklı bir ortamda tek bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) örneği **kullanmamanızı** şiddetle öneririz; çünkü bu, kolayca belirlenemeyen öngörülemeyen hatalar veya başarısızlıklara yol açabilir.

Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının örneğini birden çok iş parçacığında yüklemek, kaydetmek ve/veya kopyalamak **güvenli değildir**. Bu tür işlemler **desteklenmez**. Böyle görevleri yerine getirmeniz gerekiyorsa, işlemleri birkaç tek iş parçacıklı süreç kullanarak paralelleştirmeniz gerekir ve bu süreçlerin her biri kendi sunum örneğini kullanmalıdır.

Uzantıları kullanırken PHP'de çok iş parçacıklı çalışmayı garanti etmiyoruz. Kullanıyorsanız, sorumluluğu size aittir.

## **SSS**

**Her iş parçacığında lisans kurulumunu çağırmam gerekiyor mu?**

Hayır. İş parçacıkları başlamadan önce işlem/uygulama alanı başına bir kez yapmak yeterlidir. [license setup](/slides/tr/php-java/licensing/) eşzamanlı olarak (örneğin tembel başlatma sırasında) çağrılabilecekse, bu çağrıyı eşitleyin çünkü lisans kurulum yöntemi kendisi iş parçacığı güvenli değildir.

**`Presentation` veya `Slide` nesnelerini iş parçacıkları arasında aktarabilir miyim?**

“Canlı” sunum nesnelerini iş parçacıkları arasında geçirmek önerilmez: her iş parçacığı için bağımsız örnekler kullanın veya her iş parçacığı için ayrı sunum/slayt kapsayıcıları önceden oluşturun. Bu yaklaşım, tek bir sunum örneğinin iş parçacıkları arasında paylaşılmaması gerektiği genel önerisini takip eder.

**Her iş parçacığının kendi `Presentation` örneğine sahip olduğu durumda farklı formatlara (PDF, HTML, görüntüler) dışa aktarımı paralelleştirmek güvenli mi?**

Evet. Bağımsız örnekler ve ayrı çıktı yolları ile bu görevler genellikle doğru bir şekilde paralelleşir; herhangi bir ortak sunum nesnesi ve ortak I/O akışlarından kaçının.

**Çok iş parçacıklı ortamda global font ayarları (klasörler, ikameler) ile ne yapmalıyım?**

Tüm global [font settings](/slides/tr/php-java/powerpoint-fonts/) ayarlarını iş parçacıklarını başlatmadan önce başlatın ve paralel çalışma sırasında bunları değiştirmeyin. Bu, paylaşılan font kaynaklarına erişimde yarış durumlarını ortadan kaldırır.