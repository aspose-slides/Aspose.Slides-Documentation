---
title: Dağıtım ve Etkinleştirme
type: docs
weight: 20
url: /tr/sharepoint/deployment-and-activation/
---
## **Dağıtım**
Dağıtım sırasında, Aspose.Slides for SharePoint: 

- **Aspose.Slides.SharePoint.dll** dosyasını Global Assembly Cache'e kurar ve **web.config** dosyasına bir SafeControl girişi ekler.
- Özellik manifestosunu ve diğer gerekli dosyaları uygun dizinlere kurar.
- Özelliği SharePoint veritabanına kaydeder ve özellik kapsamında etkinleştirilebilir hâle getirir.
## **Etkinleştirme**
Aspose.Slides for SharePoint, site (site koleksiyonu) düzeyinde bir özellik olarak paketlenmiştir ve site koleksiyonlarında etkinleştirilebilir veya devre dışı bırakılabilir. Etkinleştirme sırasında, özellik site koleksiyonunun üst web uygulamasının sanal dizininde bazı değişiklikler yapar. Şunları yapar: 

- Dönüştürme ayarları sayfasını site haritası dosyasına ekler.
- Gerekli kaynak dosyalarını sanal dizindeki App_GlobalResources klasörüne kopyalar.