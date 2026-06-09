---
title: ASP.NET Core'da Arka Plan Görevlerini Çalıştırma
type: docs
weight: 300
url: /tr/net/how-to-run-background-tasks-in-asp-net-core/
keywords:
- ASP.NET Core
- arka plan görevi
- arka plan işleme
- barındırılan hizmet
- arka plan çalışanı
- görev kuyruğu
- eşzamansız görev zamanlaması
- sunucu tarafı dosya işleme
- ilerleme takibi
- durum sorgulama
- SignalR bildirimleri
- AWS SQS
- Amazon S3
- Amazon DynamoDB
- ölçeklenebilir mimari
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Hosted Services, görev kuyrukları ve durum güncellemeleriyle ASP.NET Core'da arka plan görevlerini çalıştırın - PPT, PPTX ve ODP dosyalarını Aspose.Slides kullanarak işleyin ve dönüştürün."
---
## **Giriş**

Dosya işleme (ör. bir sunumu PDF olarak dışa aktarma) tipik bir sunucu tarafı görevidir. İsteği işleyen kod içinde (istemci beklerken) gerçekleştirilmesi aşağıdaki dezavantajlara sahiptir:

- *Kötü UI.* Sayfa donar ve kullanıcı sonucun gelmesini beklemek zorunda kalır. Sayfayı yenilemek görevi iptal eder.
- *İşlem zaman aşımı.* İşlemenin sabit bir süre içinde tamamlanacağını garanti edemeyiz, bu nedenle kullanıcı bir “operation timeout” (işlem zaman aşımı) mesajı görebilir.
- *Düşük verim ve ölçeklenebilirlik.* ASP.NET Core, pek çok isteği eşzamansız olarak işlemek üzere tasarlanmıştır. CPU‑ağırlıklı, uzun süren görevler iş parçacıklarını engeller ve sunucu verimini azaltır.
- *Zayıf hata toleransı.* Uzun süren bir görev sırasında bir şeyler ters giderse (ör. bağlantı sorunu), işleme başarısız olur ve baştan yeniden başlaması gerekir.

Bir [daha iyi bir yaklaşım](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-9.0#complete-long-running-tasks-outside-of-http-requests) görevleri asenkron olarak zamanlamak, arka planda işlemek ve sonuç hazır olduğunda döndürmektir.

Bu modelde kullanıcı mevcut durumu görebilir (ve sayfadan ayrılabilir ya da sayfayı yenileyebilir), sunucu kaynakları verimli bir şekilde ölçeklenebilir ve esnek bir şekilde ayarlanabilir, ayrıca bir yeniden deneme politikası uygulanabilir.

Tipik bir arka plan işleme çözümü şunları içerir:

1. Görevi zamanlamak için bir API.
1. Görev durumunu izlemek için bir API.
1. Zamanlanan görevleri işlemek için bir arka plan çalışanı.
1. Sonucu depolamak ve almak için bir API.

## **Arka Plan Görevi Örneği**

Bu yaklaşımı göstermek için [örnek ASP.NET Core 3.1 web uygulamasını](./BackgroundJobDemo.zip) inceleyin. Uygulama, bir kullanıcının sunumu yükleyip **Export to PDF** (PDF olarak dışa aktar) düğmesine tıkladığı bir sayfa içerir; sunum daha sonra arka plan çalışanı tarafından yüklenir ve PDF’ye dönüştürülür.

## **Web Uygulaması**

Örnek web uygulaması (*BackgroundJobDemo* projesi) şunları içerir:

- Dosya yükleme sayfası (Razor sayfası “Upload”).
- İlerleme sayfası (Razor sayfası “Progress” ve durumu kontrol edip görüntüleyen birkaç JavaScript işlevi).
- İşleme durumunu sağlayan denetleyici (`JobStatusController`) (`api/status/{jobId}`).
- Dışa aktarılan PDF dosyasını döndüren denetleyici (`JobResultController`) (`api/result/{id}`).
- ASP.NET Core barındırma hizmetine dayalı arka plan çalışanı (bkz. `WorkerService` sınıfı).

Razor sayfaları, denetleyiciler ve arka plan çalışanı, gerçek işi *BackgroundJobDemo.Common* projesinde tanımlanan arayüzler aracılığıyla devreder. İş yönetimi ve işleme için somut uygulamalar ayrı projelerde (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws* vb.) sağlanır ve `Startup.ConfigureServices` metodunda değiştirilebilir.

Demo amaçlı, “Upload” sayfası tamponlu model bağlaması kullanır, ancak büyük dosya yüklemeleri için tamponlamayan akış [önerilir](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads). Üretim ortamı için ilgili [güvenlik konularını](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations) dikkate alın. “Progress” sayfası, JavaScript aracılığıyla zamanlanmış görev durumunu her iki saniyede bir (bu aralık yapılandırılabilir) sorgular. Sorgulama yaygındır, ancak daha gelişmiş senaryolarda WebSocket’ler üzerinden gerçek‑zaman bildirimlerine ihtiyaç duyulabilir (gerçek‑zaman iletişimleri bu makalenin kapsamı dışındadır). [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr), gerçek‑zaman iletişim için basit ama güçlü bir araçtır.

Arka plan çalışanını sunucu sürecinde barındırmak basit uygulamalar için uygundur, ancak [dezavantajları](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx) vardır. Daha sağlam ve ölçeklenebilir bir yaklaşım, çalışanı ayrı bir süreçte dağıtmaktır (bkz. *BackgroundJobDemo.Worker* konsol uygulaması).

## **Temel Uygulama**

*BackgroundJobDemo.Local* projesi, bir SQLite veri tabanı kullanarak basit bir görev‑yönetimi uygulaması sunar (veri tabanı yolu `LocalConfig.DbFilePath` ile yapılandırılır; bkz. `Startup.ConfigureServices`). Yüklenen ve işlenen dosyalar dosya sisteminde saklanır (depolama klasör yolu `LocalConfig.FileStorageFolderPath` ile yapılandırılır; bkz. `Startup.ConfigureServices`). Gerçek dünyadaki uygulamalarda daha iyi hata toleransı ve performans için görev zamanlaması mesaj kuyrukları (ör. RabbitMQ, AWS SQS, Azure Storage Queue) aracılığıyla yapılmalıdır.

## **Amazon Web Services Tabanlı Dağıtık Uygulama**

*BackgroundJobDemo.Aws* projesi, Amazon Web Services üzerinde görev işleme gerçekleştirir ve yatay olarak ölçeklenebilir dağıtık bir mimariyi gösterir. Aşağıdaki bileşenleri içerir:

- Web uygulaması — kullanıcı ile etkileşir ve PPTX‑to‑PDF dışa aktarma görevlerini zamanlar vb.
- Çalışan — dışa aktarmaları işler (process içinde, dış süreçte veya AWS Lambda).
- Mesaj kuyruğu — işlenecek görevleri saklar (Amazon SQS).
- Dosya depolama — yüklenen ve işlenen dosyaları saklar (Amazon S3).
- Anahtar‑değer deposu — görev işleme durumunu izler (Amazon DynamoDB).

Tipik bir dağıtık mimari, [mesaj kuyruklarına](https://aws.amazon.com/message-queue/) dayanır: web uygulaması arka plan görevlerini kuyruğa ekler; bir arka plan çalışanı kuyruğu dinler ve görevleri yerine getirir. Bu, bileşenleri ayırır ve işleme asenkron ve güvenilir hâle getirir. Kuyruk, *visibility timeout* (görünürlük zaman aşımı) kullanır: bir çalışan mesajı aldığında, mesaj diğer çalışanlar için görünmez hâle gelir; yalnızca işleyen çalışan tamamlandığında mesajı kaldırır. İşleme, görünürlük zaman aşımı içinde tamamlanmazsa (ör. bir hata ya da ağ sorunu nedeniyle) işlenmemiş mesaj tekrar görünür hâle gelir.

Uygulamamız, mikro hizmetler, dağıtık sistemler ve sunucusuz uygulamalar için tam yönetilen bir mesaj kuyruğu olan [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS) kullanır.

Mesaj kuyrukları hafif mesajlar için tasarlanmıştır (ör. SQS mesaj boyutu sınırı 256 KB’dır), bu yüzden mesaj yalnızca görev tanımını içermelidir. Ağır veri (dosyalar gibi) ayrı olarak depolanmalı ve mesajda referans verilmelidir. Yüklenen ve işlenen dosyalar için [Amazon S3](https://aws.amazon.com/s3/) kullanılır.

Görev sonuçlarını kimlik ile kalıcı olarak saklamak ve almak için bir anahtar‑değer deposu gerekir. Örnek, hızlı ve esnek bir NoSQL veri tabanı hizmeti olan [Amazon DynamoDB](https://aws.amazon.com/dynamodb/) kullanır.

Amazon Web Services ile demo uygulamayı çalıştırmak için:

1. Aynı AWS bölgesinde şunları oluşturup yapılandırın:
   1. bir SQS kuyruğu,
   1. bir S3 bucket,
   1. bir DynamoDB tablo.
1. `Startup.ConfigureServices` içinde *AddAws* metodunu çağırarak web uygulamasını bu hizmetlere bağlayın; SQS kuyruk URL’si, S3 bucket adı, DynamoDB tablo adı ve AWS bölgesi parametrelerini sağlayın.

## **Referanslar**

- [ASP.NET Core Performance Best Practices](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices)
- [Upload files in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)
- [Real-time ASP.NET with SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [Message Queues](https://aws.amazon.com/message-queue/)
- [Amazon Simple Queue Service](https://aws.amazon.com/sqs/)
- [Amazon S3](https://aws.amazon.com/s3/)
- [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)