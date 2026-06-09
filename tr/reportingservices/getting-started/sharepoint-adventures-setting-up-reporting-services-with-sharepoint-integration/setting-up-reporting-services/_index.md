---
title: Reporting Services Kurulumu
type: docs
weight: 30
url: /tr/reportingservices/setting-up-reporting-services/
---
{{% alert color="primary" %}} 

RS Sunucusundaki ilk durağımız Reporting Services Configuration Manager'dır. 

{{% /alert %}} 
## **Service Account**
Reporting Services için hangi hizmet hesabını kullandığınızı anlamalısınız. Sorunlarla karşılaşırsak, bunun hizmet hesabınızla ilgili olma ihtimali vardır. Varsayılan değer Network Service'dir. Yeni derlemeler dağıttığımda her zaman Domain Hesapları kullanırım, çünkü sorunların çoğu burada ortaya çıkar. Sunucumdaki bu yapılandırma için **RSService** adında bir Domain Hesabı kullandım. 
## **Web Service URL**
Web Service URL'sini yapılandırmamız gerekecek. Bu, Reporting Services'in kullandığı Web Servislerini barındıran **ReportServer** sanal dizini (vdir) ve SharePoint'in iletişim kuracağı yerdir. vdir'in özelliklerini (ör. SSL, portlar, host başlıkları, vb.) özelleştirmek istemediğiniz sürece, sadece Apply'e tıklayıp işinizi halledebilirsiniz. 

![todo:image_alt_text](setting-up-reporting-services_1.png)

![todo:image_alt_text](setting-up-reporting-services_2.png)


**Şekil 3**: Web Service URL'sinin ayarlanması 

Bu işlem tamamlandığında aşağıdaki şekli görmelisiniz. 

![todo:image_alt_text](setting-up-reporting-services_3.png)

**Şekil 4**: Web Service URL'sinin başarılı kurulumu 
## **Database**
Reporting Services Catalog Veritabanını oluşturmamız gerekiyor. Bu, herhangi bir SQL 2008 veya SQL 2008 R2 Database Engine üzerinde konumlandırılabilir. SQL11 de çalışır, ancak hâlen BETA aşamasındadır. Bu işlem, varsayılan olarak iki veritabanı oluşturur: **ReportServer** ve **ReportServerTempDB**. 
Bu konuda bir diğer önemli adım, veritabanı türü olarak SharePoint Integrated seçtiğinizden emin olmaktır. Bu seçim yapıldıktan sonra değiştirilemez. Lütfen Şekil 5, 6 ve 7'ye bakın. 

![todo:image_alt_text](setting-up-reporting-services_4.png)

**Şekil 5**: Report Server Veritabanının Oluşturulması 

![todo:image_alt_text](setting-up-reporting-services_5.png)

**Şekil 6**: Veritabanı Sunucusunun ve Kimlik Doğrulama Türünün Ayarlanması 

![todo:image_alt_text](setting-up-reporting-services_6.png)

**Şekil 7**: Veritabanı Adının ve Modunun Ayarlanması 

Kimlik bilgileri, Report Server'ın SQL Server ile nasıl iletişim kuracağını belirler. Seçtiğiniz hesap, Catalog veritabanı içinde ve RSExecRole aracılığıyla birkaç sistem veritabanına belirli haklar alır. MSDB, Subscription kullanımında SQL Agent üzerinden kullandığımız veritabanlarından biridir. 

![todo:image_alt_text](setting-up-reporting-services_7.png)

**Şekil 8**: Report Server Veritabanı Kimlik Bilgilerinin Ayarlanması 

Bu işlem tamamlandığında aşağıdaki şekle benzemelidir. 

![todo:image_alt_text](setting-up-reporting-services_8.png)


**Şekil 9**: Report Server Veritabanı kurulumu tamamlanana kadar ilerleme 
## **Report Manager URL**
Report Manager URL'ini atlayabiliriz, çünkü SharePoint Integrated modundayken kullanılmaz. SharePoint ön ucumuzdur. Report Manager çalışmaz. 
## **Encryption Keys**
Encryption Keys'i yedekleyin ve nerede sakladığınızı bilin. Veritabanını taşımanız veya geri yüklemeniz gerektiğinde bu anahtarlara ihtiyaç duyacaksınız. 

![todo:image_alt_text](setting-up-reporting-services_9.png)

Reporting Services Configuration Manager burada sona erdi. Web Service URL sekmesindeki URL'ye gittiğinizde aşağıdaki şekle benzer bir şey görmelisiniz. 

![todo:image_alt_text](setting-up-reporting-services_10.png)

**Şekil 12**: Kurulum sonrası Report Server erişimi 

Ne oldu? SharePoint, WFE'ye kuruldu ve Reporting Services kurulumu tamamlandı. Bu örnekte Reporting Services ve SharePoint farklı makinelerde. Aynı makinede olsalardı bu hatayı görmezdiniz. Teknik olarak SharePoint'i RS kutusuna kurmamız gerekir. Bu da IIS'in de etkinleştirileceği anlamına geliyor.