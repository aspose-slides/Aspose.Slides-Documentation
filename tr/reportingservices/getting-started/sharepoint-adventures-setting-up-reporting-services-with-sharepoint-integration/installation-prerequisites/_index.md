---
title: Kurulum Önkoşulları
type: docs
weight: 20
url: /tr/reportingservices/installation-prerequisites/
---
{{% alert color="primary" %}} 

Kuruluma devam etmeden önce karşılanması gereken önkoşullar şunlardır. 

{{% /alert %}} 
## **Reporting Services Add-In for SharePoint**
**Reporting Services Add‑In for SharePoint**, Entegrasyonun düzgün çalışmasını sağlayan önemli bileşenlerden biridir. Eklenti, SharePoint çiftliğinizdeki **Web Front Ends (WFE)** bilgisayarlarından herhangi birine ve Merkezi Yönetim sunucusuna kurulmalıdır. SQL 2008 R2 ve SharePoint 2010 ile gelen yeni değişikliklerden biri, 2008 R2 Eklentisi artık SharePoint kurulumunun bir önkoşulu olmasıdır. Bu, SharePoint'i kurarken RS Add‑In’in de otomatik olarak yükleneceği anlamına gelir. Aşağıdaki figürde gösterildiği ve vurgulandığı gibi. Bu, Add‑In’in kurulumu sırasında SP 2007 ve RS 2008 ile karşılaştığımız birçok sorunu önler.

![todo:image_alt_text](installation-prerequisites_1.png)


**Şekil 1**: Reporting Services Add‑In for SharePoint 
## **SharePoint Kimlik Doğrulaması**
RS Entegrasyonu parçalarına geçmeden önce, SharePoint çiftliğinizde **Site**'inizi nasıl yapılandırdığınız önemli bir konudur. Daha spesifik olarak, Site için kimlik doğrulamasını **Classic** mi yoksa **Claims** mi olarak yapılandıracağınız. Bu seçim başlangıçta önemlidir. Bu seçeneğin yapıldıktan sonra değiştirilebileceğine inanmıyorum. Değiştirilebilse bile basit bir işlem olmayacaktır. 

{{% alert color="primary" %}} 

Reporting Services 2008 R2, Claims tabanlı değildir 

{{% /alert %}} 

SharePoint sitenizi **Claims** kullanacak şekilde seçseniz bile, Reporting Services kendisi Claims tabanlı değildir. Bu, kimlik doğrulamasının Reporting Services ile nasıl çalıştığını etkiler. Peki, Reporting Services açısından fark nedir? Kullanıcı kimlik bilgilerini veri kaynağına iletmek isteyip istememenize bağlıdır. 

***Classic*** - Kerberos kullanılabilir ve kullanıcının kimlik bilgileri arka uç veri kaynağına iletilebilir (bunun için Kerberos kullanmanız gerekir). 

***Claims*** - Bir Claims token'ı kullanılır, Windows token'ı kullanılmaz. Bu senaryoda RS her zaman Güvenilir Kimlik Doğrulamasını (Trusted Authentication) kullanır ve yalnızca SPUser token'ına erişebilir. Kimlik bilgilerinizi veri kaynağınızda saklamanız gerekir. 

Şimdilik, sadece RS kurulumu üzerine odaklanmak istiyoruz. Bu noktada SharePoint, SharePoint Box'ta kuruldu ve **port 80** üzerinde **Classic Auth Site** olarak ayarlandı. Ayrıca, RS Sunucusunda **just installed Reporting Services** ve başka bir şey yok.