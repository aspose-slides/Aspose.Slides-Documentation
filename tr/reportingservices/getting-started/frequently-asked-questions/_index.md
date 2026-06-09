---
title: Sık Sorulan Sorular
type: docs
weight: 110
url: /tr/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 
Bu sayfa aşağıdaki konularla ilgili sık sorulan soruları toplar:

- [Desteklenen dosya formatları](#Supported-File-Formats).
- [Power BI Raporlama Hizmetleri desteği](#Support-for-Power-BI-Reporting-services).
- [Kurulum](#Installation).
- [Dışa Aktarım Yapılandırması](#Export-Configuration).

{{% /alert %}} 
### **Desteklenen Dosya Formatları**
#### **Q: Aspose.Slides for Reporting Services ile raporları hangi formatlara dışa aktarabilirsiniz?**
**A**: Aspose.Slides for Reporting Services, raporları PPT, PPS, PPTX, PPSX, XPS veya RPL formatlarında dışa aktarmayı sağlar.
### **Power BI Raporlama Hizmetleri Desteği**
#### **Q: Aspose.Slides for Reporting Services Power BI'yi destekliyor mu?**
**A**: Evet. Aspose.Slides for Reporting Services, Power BI'de sayfalı raporları (RDL) dışa aktarmayı destekler.
### **Kurulum**
#### **Q: Kurulum programı başlamıyor. Manuel kurulum istenen sonucu vermiyor.**
**A**: Sisteminizde .NET Framework 3.5’in kurulu olduğundan emin olun.
#### **Q: Aspose.Slides for Reporting Services kurulumundan sonra dışa aktarım seçenekleri eksik.**
**A**: rssrvpolicy.config içindeki herhangi bir CodeGroup doğru çalışmazsa, yapılandırma dosyası ayrıştırıcısı grubun son bölümlerini atlayabilir. Bu nedenle Aspose.Slides for Reporting Services ile ilişkili tüm CodeGroup'ları, Aspose.Slides for Reporting Services CodeGroup'larını içeren bloğun en üstüne taşıyın.
#### **Q: Aspose.Slides.ReportingServices dosyası veya derlemesi yüklenemedi (Execution permission cannot be acquired \ Exception from HRESULT: 0x80131418).**
**A**: 0x80131418 hata kodu, dll modülünün yeterli izne sahip olmadığını gösterir. Bu, .dll dosyasının başka bir bilgisayardan alındığında tam erişimin güvenlik özelliğiyle engellenmesinden kaynaklanabilir. dll dosyasının özellikler penceresini açıp “Security” sekmesinde “Unblock” düğmesine tıklayarak sorun çözülebilir.
#### **Q: ‘Aspose.Slides.Reporting.Services.lic’ lisans dosyası bulunamıyor.**
**A**: Lisans dosyası dll'nin yanına ya da Program Files (x86)\Aspose\Slides\ klasörüne yerleştirilmelidir.
### **Dışa Aktarım Yapılandırması**
#### **Q: Dışa aktarılan raporda hiperlink rengini nasıl değiştirebilirim?**
**A**: rsreportserver.config içindeki her Aspose.Slides for Reporting Services render uzantısının kendi yapılandırması vardır. Hiperlink rengini değiştirmek için <HyperlinkColor> bölümüne istediğiniz değeri girin.
#### **Q: Dışa aktarılan sunumlarda tablodaki metin dikey olarak uzatılıyor.**
**A**: Bu, belgenin daha okunabilir olmasını sağlamak içindir. Metnin raporda göründüğü gibi tabloda gösterilmesini istiyorsanız, rsreportserver.config yapılandırma dosyasında ilgili Aspose.Slides for Reporting Services uzantısını “Normal” olarak ayarlayın.