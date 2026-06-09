---
title: PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Güncelleme
type: docs
weight: 10
url: /tr/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE nesnesi
- OLE güncelle
- otomatik olarak
- eklentisi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "PowerPoint'te bir eklenti ve Aspose.Slides for Java kullanarak OLE grafiklerini ve nesnelerini otomatik güncellemeyi, pratik kod ve optimizasyon ipuçlarını içeren bir şekilde keşfedin."
---
## **Giriş**

Aspose.Slides for Java müşterileri tarafından en sık sorulan sorulardan biri, düzenlenebilir grafikler (veya diğer OLE nesneleri) oluşturma veya değiştirme ve bunların sunum açıldığında otomatik olarak güncellenmesini sağlamaktır. Ne yazık ki, PowerPoint, Excel ve Word'ün yaptığı gibi otomatik makroları desteklemez. Mevcut tek makrolar `Auto_Open` ve `Auto_Close`'dır ve bunlar yalnızca bir eklentiden otomatik olarak çalışır. Bu kısa teknik ipucu, bunu nasıl yapacağınızı gösterir.

## **OLE Nesnelerini Otomatik Güncelleme**

İlk olarak, PowerPoint'e Auto_Open makro özelliğini ekleyen birkaç ücretsiz eklenti mevcuttur, örneğin [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) ve [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Bu eklentilerden birini kurduktan sonra, aşağıda gösterildiği gibi şablon sunumunuza `Auto_Open()` makrosunu (veya Event Generator kullanıyorsanız `OnPresentationOpen()` makrosunu) ekleyin:

```java
// Sunumdaki her slaytı döngüye al.
for (var oSlide : ActivePresentation.Slides) {
    // Geçerli slayttaki tüm şekilleri döngüye al.
    for (var oShape : oSlide.Shapes) {
        // Şeklin bir OLE nesnesi olup olmadığını kontrol et.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // Bir OLE nesnesi bulundu. Nesne referansını al ve ardından güncelle.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // Şimdi, OLE sunucu programından çık.
            // Bu bellek boşaltır ve olası sorunları önler.
            // Ayrıca, nesneyi serbest bırakmak için oObject'i Nothing (null) olarak ayarla.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```

Aspose.Slides for Java ile OLE nesnelerinde yapılan tüm değişiklikler, PowerPoint sunumu açtığında otomatik olarak güncellenir. Çok sayıda OLE nesneniz varsa ve hepsini güncellemek istemiyorsanız, işlem yapmanız gereken şekillere bir özel etiket ekleyin ve makro içinde bunu kontrol edin.