---
title: SharePoint için Aspose.Slides Lisansını Kaldırma
type: docs
weight: 20
url: /tr/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
Lisansı kaldırmak için, lütfen sunucu konsolundan aşağıdaki adımları izleyin. 

1. Lisans çözümünü farm'dan geri çekin: 

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Geri çekme işlemini hemen tamamlamak için yönetim zamanlayıcı işlerini çalıştırın: 

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Geri çekmenin tamamlanmasını bekleyin. Geri çekmenin tamamlanıp tamamlanmadığını kontrol etmek için **Central Administration**, ardından **Operations** ve **Solution Management** altında Merkezi Yönetim'i kullanabilirsiniz. 
4. Çözümü SharePoint çözüm deposundan kaldırın: 

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```