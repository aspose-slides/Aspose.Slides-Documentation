---
title: PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Güncelleme
type: docs
weight: 10
url: /tr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE nesnesi
- OLE güncelle
- otomatik
- eklenti
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint'ta bir eklenti ve Aspose.Slides for .NET kullanarak OLE grafiklerini ve nesnelerini otomatik olarak güncellemeyi, pratik kod ve optimizasyon ipuçlarını keşfedin."
---
## **Giriş**

Aspose.Slides for .NET müşterileri tarafından en sık sorulan sorulardan biri, sunum açıldığında otomatik olarak güncellenen düzenlenebilir grafikler (veya diğer OLE nesneleri) nasıl oluşturulur veya değiştirilir sorusudur. Ne yazık ki, PowerPoint Excel ve Word gibi otomatik makroları desteklemez. Mevcut tek makrolar `Auto_Open` ve `Auto_Close` olup, bunlar yalnızca bir eklentiden otomatik olarak çalışır. Bu kısa teknik ipucu, bunu nasıl başaracağınızı gösterir.

## **OLE Nesnelerini Otomatik Güncelle**

İlk olarak, PowerPoint'e Auto_Open makro özelliğini ekleyen birkaç ücretsiz eklenti mevcuttur; örneğin [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) ve [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Bu eklentilerden birini kurduktan sonra, aşağıda gösterildiği gibi şablon sunumunuza `Auto_Open()` makrosunu (veya Event Generator kullanıyorsanız `OnPresentationOpen()` makrosunu) ekleyin:

```cs
public void Auto_Open()
{
    // Sunumdaki her slaytı dolaş.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // Geçerli slayttaki tüm şekilleri dolaş.
        foreach (var oShape in oSlide.Shapes)
        {
            // Şeklin bir OLE nesnesi olup olmadığını kontrol et.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // Bir OLE nesnesi bulundu. Nesne referansını al ve ardından güncelle.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Şimdi, OLE sunucu programından çık.
                // Bu bellek serbest bırakır ve olası sorunları önler.
                // Ayrıca, nesneyi serbest bırakmak için oObject'i Nothing olarak ayarla.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

Aspose.Slides for .NET ile OLE nesnelerinde yapılan herhangi bir değişiklik, PowerPoint sunumu açtığında otomatik olarak güncellenir. Çok sayıda OLE nesneniz varsa ve hepsini güncellemek istemiyorsanız, işlemek istediğiniz şekillere özel bir etiket ekleyin ve makro içinde bu etiketi kontrol edin.