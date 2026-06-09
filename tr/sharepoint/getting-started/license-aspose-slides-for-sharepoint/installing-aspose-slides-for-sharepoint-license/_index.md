---
title: Aspose.Slides for SharePoint Lisansını Kurma
type: docs
weight: 10
url: /tr/sharepoint/installing-aspose-slides-for-sharepoint-license/
---
{{% alert color="primary" %}} 

Değerlendirmenizden memnun kaldığınızda bir lisans satın alabilirsiniz. Satın almadan önce lisans abonelik koşullarını anladığınızdan ve kabul ettiğinizden emin olun. Sipariş ödendikten sonra lisans size e-posta ile gönderilir.

Lisans, normal bir SharePoint çözüm paketi içeren bir ZIP arşividir. Arşiv şunları içerir:

- Aspose.Slides.SharePoint.License.wsp – SharePoint çözüm paketi dosyası. Lisans, bir sunucu çiftliğinde dağıtımı ve geri çekmeyi kolaylaştırmak için bir SharePoint çözümü olarak paketlenir.
- readme.txt – Lisans kurulum talimatları.

{{% /alert %}} 
## **Lisansı Dağıtma**
Lisans kurulumu, sunucu konsolundan stsadm.exe aracılığıyla gerçekleştirilir.

{{% alert color="primary" %}} 

Aşağıdaki bölümde açıklık getirmek için yollar atlanmıştır.

{{% /alert %}} 

Aspose.Slides for SharePoint lisansını dağıtmak için aşağıdaki adımları izleyin:

1. stsadm'i çalıştırarak çözümü SharePoint çözüm deposuna ekleyin: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. Çözümü çiftlikteki tüm sunuculara dağıtın: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Dağıtımı hemen tamamlamak için yönetim zamanlayıcı görevlerini yürütün: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

Dağıtım adımını çalıştırırken Windows SharePoint Services Administration hizmeti çalışmıyorsa uyarı alırsınız. stsadm.exe, bu hizmete ve çiftlik içinde çözüm verilerini çoğaltmak için Windows SharePoint Timer Service'e dayanır. Bu hizmetler sunucu çiftliğinizde çalışmıyorsa, lisansı her sunucuya dağıtmanız gerekebilir. 

{{% /alert %}} 
## **Lisansı Test Et**
Lisansın doğru şekilde kurulduğunu test etmek için herhangi bir belgeyi yeni bir formata dönüştürün. Belgede değerlendirme filigranı yoksa, lisans başarıyla etkinleştirilmiştir.