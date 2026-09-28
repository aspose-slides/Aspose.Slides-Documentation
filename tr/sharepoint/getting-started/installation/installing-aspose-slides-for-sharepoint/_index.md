---
title: Aspose.Slides for SharePoint'i Kurma
type: docs
weight: 10
url: /tr/sharepoint/installing-aspose-slides-for-sharepoint/
description: "Aspose.Slides for SharePoint'i bir SharePoint çiftliğine kurun: SharePoint sürümünüz için kurulum programını seçin, sistem kontrolünü çalıştırın ve çözümü dağıtarak etkinleştirin."
---
## **Paket İçeriği**

Aspose.Slides for SharePoint, [indirme sayfası](https://releases.aspose.com/slides/tr/sharepoint/) üzerinden ZIP arşivi olarak indirilir. Arşiv, desteklenen her SharePoint sürümü için bir SharePoint çözüm paketi (WSP) ve bir kurulum programı içerir:

| SharePoint sürümü | Kurulum programı | Çözüm paketi |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

Her kurulum programının yanında bir yapılandırma dosyası bulunur (örneğin *Setup2019.exe.config*), bu dosya kurulan çözüm paketinin adını belirtir. *License* klasörü son kullanıcı lisans sözleşmesi ve üçüncü taraf lisans bildirimlerine bir bağlantı içerir.

Aspose.Slides for SharePoint, SharePoint çözümü olarak paketlenmiştir; SharePoint bu çözümü sunucu çiftliği boyunca dağıtır. Özelliği ardından site koleksiyonları başına etkinleştirilir veya devre dışı bırakılır.

## **Kurulum Süreci**

Kurulumdan önce, kurulum programı bir sistem kontrolü gerçekleştirir. Şu öğeleri doğrular:

- Sunucuda SharePoint yüklü olması.
- Geçerli kullanıcının SharePoint çözümlerini kurma ve dağıtma iznine sahip olması.
- SharePoint Administration hizmetinin başlatılmış olması.
- SharePoint Timer hizmetinin başlatılmış olması.
- Yapılandırma dosyasında belirtilen çözüm paketinin mevcut olması.

Administration ve Timer hizmetleri, bazı kurulum eylemlerinin çiftlikteki tüm sunuculara çözümü yaymak için zamanlayıcı işleri olarak çalıştırılması gerektiği için gereklidir.

### **Kurulumun Çalıştırılması**

Aspose.Slides for SharePoint'i kurmak için:

1. ZIP arşivini SharePoint çiftliğindeki bir sunucunun yerel sürücüsüne açın.
2. SharePoint sürümünüzle eşleşen kurulum programını (yukarıdaki tabloya bakın) çalıştırın ve ekrandaki talimatları izleyin. Kurulum programı:
   1. Sistem kontrolünü çalıştırır. Kontrolün herhangi bir aşaması başarısız olursa kurulum devam etmez.

      **Sistem kontrolünün çalıştırılması**

      ![Kurulum programının Sistem Kontrol ekranı](installing-aspose-slides-for-sharepoint_1.png)

   2. Son kullanıcı lisans sözleşmesini gösterir. Devam etmek için sözleşmeyi kabul etmelisiniz.

      **Lisans sözleşmesi**

      ![Kurulum programının Lisans Sözleşmesi ekranı](installing-aspose-slides-for-sharepoint_2.png)

   3. Dağıtım hedeflerini gösterir. Özelliği etkinleştirmek istediğiniz web uygulamaları ve site koleksiyonlarını seçin.

      **Dağıtım hedeflerinin seçilmesi**

      ![Kurulum programının Site Koleksiyonu Dağıtım Hedefleri ekranı](installing-aspose-slides-for-sharepoint_3.png)

   4. Çözümü çiftliğe dağıtır.

      **Kurulum ilerlemesi**

      ![Kurulum programının Kurulum İlerleme ekranı](installing-aspose-slides-for-sharepoint_4.png)

   5. Aspose.Slides for SharePoint'i seçilen site koleksiyonlarında etkinleştirir.
   6. Çözümün dağıtıldığı ve etkinleştirildiği web uygulamaları ve site koleksiyonlarını listeler.

      **Kurulum başarılı**

      ![Kurulum programının Kurulum Tamamlandı ekranı](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Not" %}}
Ekran görüntüleri SharePoint 2007 üzerinde alınmıştır. Daha yeni sürümlerin kurulum programları aynı ekranları gösterir.
{{% /alert %}}

Aynı Aspose.Slides for SharePoint sürümü zaten yüklüyse, kurulum programı onarma veya kaldırma seçeneği sunar. Farklı bir sürüm yüklüyse, yükseltme veya kaldırma seçeneği sunar.

Kurulumdan sonra, seçilen site koleksiyonlarının belge kitaplıklarındaki dosya menüsünde **Aspose.Slides ile Dönüştür** (SharePoint 2007'de **Aspose.Slides ile Dönüştür**) öğesi görünür. İlk sunumu dönüştürmek için [Microsoft PowerPoint Belgelerini Diğer Biçimlere Dönüştürme](/slides/tr/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/) bölümüne bakın. Çözümün çiftliğe eklediği şeyler [Dağıtım ve Etkinleştirme](/slides/tr/sharepoint/deployment-and-activation/) bölümünde açıklanmıştır.

## **SSS**

**Hangi kurulum programını çalıştırmalıyım?**

SharePoint sürümünüzle aynı adı taşıyan programdır. Örneğin, bir SharePoint Server 2016 çiftliğinde *Setup2016.exe* çalıştırın. Her kurulum programı yalnızca kendi çözüm paketini kurar.

**Lisanslı sürüm için ayrı bir indirme gerekiyor mu?**

Hayır. Aynı paket, lisans çözümünü kurana kadar değerlendirme modunda çalışır; detaylar için [Aspose.Slides for SharePoint Lisansı Kurulumu](/slides/tr/sharepoint/installing-aspose-slides-for-sharepoint-license/) bölümüne bakın.

**Ürünü nasıl kaldırırım?**

Aynı kurulum programını yeniden çalıştırın ve **Kaldır** seçeneğini seçin; ayrıntılar için [Aspose.Slides for SharePoint Kaldırma](/slides/tr/sharepoint/uninstalling-aspose-slides-for-sharepoint/) bölümüne bakın.