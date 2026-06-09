---
title: Reporting Services SharePoint Yapılandırması
type: docs
weight: 50
url: /tr/reportingservices/reporting-services-sharepoint-configuration/
---
{{% alert color="primary" %}} 

SharePoint artık RS sunucusunda yüklendi ve yapılandırıldı ve RS, Reporting Services Configuration Manager aracılığıyla kurulup yapılandırıldıktan sonra, Central Admin içindeki yapılandırmaya geçebiliriz. RS 2008 R2 bu süreci gerçekten basitleştirdi. Önceden bunun çalışması için üç adımlı bir süreç uygulamanız gerekiyordu. Şimdi sadece tek bir adım var. 

Genel Uygulama Ayarları’na girip Central Administrator web sitesine gitmek istiyoruz. Sayfanın alt kısmına doğru Reporting Services bölümünü göreceğiz. 

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)


**Şekil 17**: SharePoint Yapılandırması 

{{% alert color="primary" %}} 

**Reporting Services Integration** öğesine tıklayın. 

{{% /alert %}} 
## **Web Servis URL'si**
Reporting Services Configuration Manager’da bulduğumuz Report Server URL’sini buraya ekleyeceğiz. 
## **Kimlik Doğrulama Modu**
Bir kimlik doğrulama modu da seçeceğiz. Aşağıdaki MSDN bağlantısı bu seçeneklerin ayrıntılarını inceliyor. 
[SharePoint Entegre Modunda Reporting Services için Güvenlik Genel Bakışı](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

Kısaca, siteniz **Claims Authentication** kullanıyorsa, burada ne seçerseniz seçin her zaman Trusted Authentication kullanılacaktır. Windows kimlik bilgilerini iletmek istiyorsanız Windows Authentication’ı seçmelisiniz. Trusted Authentication için SPUser token’ı gönderir ve Windows kimlik bilgisine güvenmeziz. 

Classic Mode sitelerinizi NTLM için yapılandırdıysanız ve RS NTLM için ayarlandıysa Trusted Authentication’ı da kullanmak isteyeceksiniz. Windows Authentication ve veri kaynağınız için Kerberos gereklidir. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)


**Şekil 18**: Reporting Services Integration kimlik bilgilerini ayarlama 
## **Özelliği Etkinleştir**
Bu seçenek, Reporting Services’ı tüm Site koleksiyonlarında etkinleştirme ya da yalnızca belirli koleksiyonlarda etkinleştirme imkanı sunar. Temelde bu, hangi sitelerin Reporting Services’ı kullanabileceğini belirler. 
İşlem tamamlandığında aşağıdaki şekli görmelisiniz. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)


**Şekil 19**: Reporting Services’ın SharePoint ortamıyla başarılı entegrasyonu 

Şekil 14’te verilen Report Server URL’sine geri dönerek aşağıdaki şekle benzer bir sonuç görmeliyiz. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)


**Şekil 20**: Reporting Services’ın SharePoint ortamında başarılı doğrulaması 

{{% alert color="primary" %}} 

SharePoint siteniz SSL için yapılandırıldıysa, bu listede görünmez. Bilinen bir sorundur ve bir sorun olduğu anlamına gelmez. Raporlarınız hâlâ çalışacaktır. 

{{% /alert %}} 

Artık Reporting Services’ı SharePoint 2010’da kullanmaya hazırız. Önceki sürümde olduğu gibi “Site Collection Feature” içinde (Reporting Services Integration yapılandırıldığında etkinleştirilir) bir özellik bulunur. Ayrıca kurulum, sitemize eklemek için 3 içerik türü ekler. Şekil 21’de iki içerik türünün bir belge kitaplığına eklenerek özel bir rapor oluşturulduğunu görebiliriz. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)


**Şekil 21**: Report Builder 

“**Reporter Builder**”, sunucuda indirmemiz gereken bir ActiveX’tir; Şekil 22’de gösterildiği gibi. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)


**Şekil 22**: Report Builder’ı İndir ve Yükle 

İndirme tamamlandığında **Report Builder**’ı çalıştırın. Artık ilk raporumuzu tasarlamaya hazırız; Şekil 23’te görüldüğü gibi. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**Şekil 23**: Report Builder Yeni Rapor Oluşturma Sihirbazı 

Raporumuzu oluşturduktan sonra, raporları SharePoint 2010’da tutmak için oluşturduğumuz belge kitaplığına kaydedebiliriz. 

Diğer içerik türü, ortak bir bağlantı (data source) oluşturmak ve bunu SharePoint’te bir belge kitaplığına kaydetmek için kullanılmalıdır. Bir belge kitaplığı oluşturup bu içerik türünü ekleyebilir ve ardından raporların veri kaynağını değiştirecek bağlantılarımıza erişebiliriz. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)


**Şekil 24**: Raporu Report Server’a başarılı bir şekilde dışa aktarma