---
title: .NET'te Sunumlara Üstbilgi ve Altbilgi Ekleme
linktitle: Üstbilgi ve Altbilgi Ekle
type: docs
weight: 20
url: /tr/net/how-to-add-header-footer-in-a-presentation/
keywords:
- göç
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
{{% alert color="primary" %}} 
Yeni bir [Aspose.Slides for .NET API](/slides/tr/net/) yayınlandı ve artık bu tek ürün, sıfırdan PowerPoint belgeleri oluşturma ve mevcut belgeleri düzenleme yeteneğini destekliyor.
{{% /alert %}} 
## **Legacy Kod Desteği**
13.x öncesi Aspose.Slides for .NET sürümleriyle geliştirilen eski kodu kullanmak için kodunuzda bazı küçük değişiklikler yapmanız gerekir ve kod önceki gibi çalışacaktır. Eski Aspose.Slides for .NET içinde Aspose.Slide ve Aspose.Slides.Pptx ad alanları altında bulunan tüm sınıflar artık tek bir Aspose.Slides ad alanında birleştirildi. Lütfen aşağıdaki basit kod örneğine bir göz atın; bu örnek, eski Aspose.Slides API'sinde sunuma başlık ve altbilgi eklemeyi gösterir ve yeni birleştirilmiş API'ye nasıl geçileceğini açıklayan adımları izleyin.
## **Legacy Aspose.Slides for .NET Yaklaşımı**
```c#
PresentationEx sourcePres = new PresentationEx();

//Setting Header Footer visibility properties
sourcePres.UpdateSlideNumberFields = true;

//Update the Date Time Fields
sourcePres.UpdateDateTimeFields = true;

//Show date time placeholder
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Show the footer place holder
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Show Slide Number
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Set the  header footer visibility on Title Slide
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Write the presentation to the disk
sourcePres.Write("NewSource.pptx");
```

```c#
//Sunumu oluştur
Presentation pres = new Presentation();

//İlk slaytı al
Slide sld = pres.GetSlideByPosition(1);

//Slaytın Üstbilgi / Altbilgi'sine eriş
HeaderFooter hf = sld.HeaderFooter;

//Sayfa Numarası Görünürlüğünü ayarla
hf.PageNumberVisible = true;

//Altbilgi Görünürlüğünü ayarla
hf.FooterVisible = true;

//Üstbilgi Görünürlüğünü ayarla
hf.HeaderVisible = true;

//Tarih Saat Görünürlüğünü ayarla
hf.DateTimeVisible = true;

//Tarih Saat formatını ayarla
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Üstbilgi Metnini ayarla
hf.HeaderText = "Header Text";

//Altbilgi Metnini ayarla
hf.FooterText = "Footer Text";

//Sunumu diske yaz
pres.Write("HeadFoot.ppt");
```

## **Yeni Aspose.Slides for .NET 13.x Yaklaşımı**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Üstbilgi Altbilgi görünürlük özelliklerini ayarlama
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Tarih Saat alanlarını güncelle
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Tarih saat yer tutucusunu göster
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Altbilgi yer tutucusunu göster
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Başlık slaytında üstbilgi altbilgi görünürlüğünü ayarla
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Sunumu diske kaydet
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```