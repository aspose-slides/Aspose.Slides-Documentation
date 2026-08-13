---
title: .NET'te Sunumlara Üstbilgi ve Altbilgi Ekleme
linktitle: Üstbilgi ve Altbilgi Ekle
type: docs
weight: 20
url: /tr/net/how-to-add-header-footer-in-a-presentation/
keywords:
- taşıma
- üstbilgi ekle
- altbilgi ekle
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Hem eski hem de modern Aspose.Slides API'lerini kullanarak .NET'te PowerPoint PPT, PPTX ve ODP sunumlarına üstbilgi ve altbilgi eklemeyi öğrenin."
---
{{% alert color="info" %}} 

Yeni bir [Aspose.Slides for .NET API](/slides/tr/net/) yayınlandı ve artık bu tek ürün, PowerPoint belgelerini sıfırdan oluşturma ve mevcut belgeleri düzenleme yeteneğini destekliyor.

{{% /alert %}} 
## **Eski Kod Desteği**
13.x öncesi Aspose.Slides for .NET sürümleriyle geliştirilen eski kodu kullanmak için kodunuzda birkaç küçük değişiklik yapmanız gerekir ve kod önceki gibi çalışacaktır. Eski Aspose.Slides for .NET içinde Aspose.Slide ve Aspose.Slides.Pptx ad alanlarında bulunan tüm sınıflar artık tek bir Aspose.Slides ad alanında birleştirildi. Aşağıdaki basit kod parçacığını, legacy Aspose.Slides API'sinde sunumda başlık ve altbilgi eklemek için inceleyin ve yeni birleştirilmiş API'ye nasıl geçileceğini açıklayan adımları izleyin.
## **Legacy Aspose.Slides for .NET Yaklaşımı**
```c#
PresentationEx sourcePres = new PresentationEx();

//Üst Bilgi ve Alt Bilgi görünürlük özelliklerini ayarlama
sourcePres.UpdateSlideNumberFields = true;

//Tarih Saat Alanlarını Güncelle
sourcePres.UpdateDateTimeFields = true;

//Tarih saat yer tutucusunu göster
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Altbilgi yer tutucusunu göster
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Slayt Numarasını göster
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Başlık Slaytında üst ve alt bilgi görünürlüğünü ayarla
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Sunumu diske yaz
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//Sunumu oluştur
Presentation pres = new Presentation();

//İlk slaytı al
Slide sld = pres.GetSlideByPosition(1);

//Slaytın Üst Bilgi / Alt Bilgi'sine eriş
HeaderFooter hf = sld.HeaderFooter;

//Sayfa Numarası Görünürlüğünü Ayarla
hf.PageNumberVisible = true;

//Alt Bilgi Görünürlüğünü Ayarla
hf.FooterVisible = true;

//Üst Bilgi Görünürlüğünü Ayarla
hf.HeaderVisible = true;

//Tarih Saat Görünürlüğünü Ayarla
hf.DateTimeVisible = true;

//Tarih Saat formatını ayarla
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Üst Bilgi Metnini ayarla
hf.HeaderText = "Header Text";

//Alt Bilgi Metnini ayarla
hf.FooterText = "Footer Text";

//Sunumu diske yaz
pres.Write("HeadFoot.ppt");
```



## **Yeni Aspose.Slides for .NET 13.x Yaklaşımı**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //Üst Bilgi ve Alt Bilgi görünürlük özelliklerini ayarlama
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Tarih Saat Alanlarını Güncelle
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Tarih saat yer tutucusunu göster
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Altbilgi yer tutucusunu göster
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Başlık Slaytındaki üst ve alt bilgi görünürlüğünü ayarla
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Sunumu diske kaydet
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```