---
title: C++'ta ODP'yi PPTX'ye Dönüştür
linktitle: ODP'den PPTX'ye
type: docs
weight: 10
url: /tr/cpp/convert-odp-to-pptx/
keywords:
- OpenDocument'ı dönüştür
- sunumu dönüştür
- slaytı dönüştür
- ODP'yi dönüştür
- OpenDocument'tan PPTX'e
- ODP'den PPTX'e
- ODP'yi PPTX olarak kaydet
- ODP'yi PPTX'e aktar
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile ODP'yi PPTX'e dönüştürün. Temiz kod örnekleri, toplu ipuçları ve yüksek kaliteli sonuçlar—PowerPoint gerekmez."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak bir ODP sunumunu PPTX formatına nasıl dönüştüreceğinizi açıklar.

## **ODP'den PPTX'ye Dönüştürme**

Aspose.Slides for .NET, bir sunum dosyasını temsil eden Presentation sınıfını sunar. [**Presentation**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı, nesne oluşturulduğunda Presentation yapıcı üzerinden ODP'ye de erişebilir. Aşağıdaki örnek, bir ODP Sunumunu PPTX Sunumuna nasıl dönüştüreceğinizi gösterir.

``` cpp
// Belge dizinine giden yol.
String dataDir = GetDataPath();

// ODP dosyasını aç
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// ODP sunumunu PPTX formatına kaydet
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Canlı Örnek**

[**Aspose.Slides Conversion**](https://products.aspose.app/slides/tr/conversion/) web uygulamasını ziyaret edebilirsiniz; bu uygulama **Aspose.Slides API** ile oluşturulmuştur. Uygulama, ODP'den PPTX'ye dönüşümünün Aspose.Slides API kullanılarak nasıl uygulanabileceğini gösterir.

## **SSS**

**ODP'yi PPTX'ye dönüştürmek için Microsoft PowerPoint veya LibreOffice kurmam gerekir mi?**

Hayır. Aspose.Slides bağımsız çalışır ve ODP/PPTX okuma veya yazma için üçüncü taraf uygulamalara ihtiyaç duymaz.

**Dönüştürme sırasında master slaytlar, yerleşimler ve temalar korunur mu?**

Evet. Kütüphane tam bir sunum nesne modelini kullanır ve master slaytlar ve yerleşimler dahil yapıyı korur, böylece dönüşümden sonra tasarım doğru kalır.

**Şifre korumalı ODP dosyalarını dönüştürebilir miyim?**

Evet. Aspose.Slides, şifreyi sağladığınızda korumayı algılamayı, korumalı sunumları ([protected presentations](/slides/tr/cpp/password-protected-presentation/)) (ODP dahil) açıp çalıştırmayı ve ayrıca şifreleme ile belge özelliklerine erişimi yapılandırmayı destekler.

**Aspose.Slides bulut veya REST tabanlı dönüşüm hizmetleri için uygun mu?**

Evet. Yerel kütüphaneyi kendi arka ucunuzda veya [Aspose.Slides Cloud](https://products.aspose.cloud/slides/tr/family/) (REST API) kullanabilirsiniz; her iki seçenek de ODP → PPTX dönüşümünü destekler.