---
title: Dağıtım ve Etkinleştirme
type: docs
weight: 20
url: /tr/sharepoint/deployment-and-activation/
description: "Aspose.Slides for SharePoint çözümünün dağıtıldığında çiftliğe neler kurduğunu ve etkinleştirildiğinde site koleksiyonu özelliğinin neler eklediğini."
---
## **Dağıtım**

Dağıtım sırasında, Aspose.Slides for SharePoint çözümü:

- Derlemesini Global Assembly Cache'e (GAC) yükler ve **web.config** dosyasına SafeControl girdileri ekler. SharePoint 2010 ve sonrasında bu *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* ya da *Aspose.Slides.SharePoint2016.dll* (SharePoint 2019 paketi ayrıca *Aspose.Slides.SharePoint2016.dll* yükler). SharePoint 2007'de ise *Aspose.Slides.SharePointUI.dll* ve *Aspose.Slides.SharePoint.Deployment.dll* birlikte bulunur.
- Dönüştürme sayfasını, görüntülerini ve diğer destek dosyalarını SharePoint kurulum klasörlerine kopyalar.
- Özelliği kurar ve site koleksiyonları için etkinleştirilebilir hâle getirir.

## **Etkinleştirme**

Aspose.Slides for SharePoint, site koleksiyonu özelliği olarak paketlenmiştir ve site koleksiyonları üzerinde etkinleştirilebilir veya devre dışı bırakılabilir. Bir site koleksiyonunda etkinleştirildiğinde, özellik şunları ekler:

- SharePoint 2010 ve sonrasında:
  - belge kütüphanelerindeki belgeler menüsüne **Convert via Aspose.Slides** öğesini ekler;
  - **Aspose Tools** şerit sekmesini **Convert Slides** düğmesiyle ekler; bu düğme seçilen belgeleri dönüştürür;
  - PPT, PPTX, PPS ve PPSX dosyalarının menüsüne **View Slides** öğesini ekler.
- SharePoint 2007'de:
  - belge kütüphanelerindeki belgeler menüsüne **Convert with Aspose.Slides** öğesini ekler;
  - belge kütüphanelerinin **Actions** menüsüne **Convert All with Aspose.Slides** öğesini ekler.

SharePoint 2007'de, etkinleştirme ayrıca site koleksiyonunun üst web uygulamasının sanal dizininde değişiklikler yapar. Şunları gerçekleştirir:

- Dönüştürme ayarları sayfasını site haritası dosyasına ekler.
- Gerekli kaynak dosyalarını sanal dizindeki App_GlobalResources klasörüne kopyalar.

Kurulum programı, [kurulum](/slides/tr/sharepoint/installing-aspose-slides-for-sharepoint/) sırasında seçtiğiniz site koleksiyonlarında özelliği etkinleştirir.