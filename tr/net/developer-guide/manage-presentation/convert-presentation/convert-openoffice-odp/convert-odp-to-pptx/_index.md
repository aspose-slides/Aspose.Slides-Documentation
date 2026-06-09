---
title: ODP'yi .NET'te PPTX'e Dönüştür
linktitle: ODP'den PPTX'e
type: docs
weight: 10
url: /tr/net/convert-odp-to-pptx/
keywords:
- OpenDocument dönüştür
- sunumu dönüştür
- slaytı dönüştür
- ODP'yi dönüştür
- OpenDocument'tan PPTX'e
- ODP'den PPTX'e
- ODP'yi PPTX olarak kaydet
- ODP'yi PPTX'e dışa aktar
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile ODP'yi PPTX'e dönüştürün. Temiz C# kod örnekleri, toplu ipuçları ve yüksek kalitede sonuçlar—PowerPoint gerekmez."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak bir ODP sunumunu PPTX formatına nasıl dönüştüreceğinizi açıklar.

## **ODP'den PPTX'ye Dönüşüm**

Aspose.Slides for .NET, bir sunum dosyasını temsil eden Presentation sınıfını sunar. [**Presentation**](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı, nesne örneklenirken Presentation yapıcı aracılığıyla ODP'ye de erişebilir. Aşağıdaki örnek, bir ODP Sunumunu PPTX Sunumuna nasıl dönüştüreceğinizi gösterir.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Adımlar: ODP'yi PPTX'e C# ile Dönüştür</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Adımlar: ODP'yi PowerPoint'e C# ile Dönüştür</strong></a>

```c#
 // ODP dosyasını aç
Presentation pres = new Presentation("AccessOpenDoc.odp");

// ODP sunumunu PPTX biçimine kaydet
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **Canlı Örnek**

Aspose.Slides API ile oluşturulmuş olan [**Aspose.Slides Conversion**](https://products.aspose.app/slides/tr/conversion/) web uygulamasını ziyaret edebilirsiniz. Uygulama, ODP'den PPTX'e dönüşümünün Aspose.Slides API ile nasıl uygulanabileceğini gösterir.

## **SSS**

**ODP'yi PPTX'e dönüştürmek için Microsoft PowerPoint ya da LibreOffice kurmam gerekiyor mu?**

Hayır. Aspose.Slides bağımsız çalışır ve ODP/PPTX okuma veya yazma için üçüncü taraf uygulamalara ihtiyaç duymaz.

**Dönüşüm sırasında master slaytlar, düzenler ve temalar korunur mu?**

Evet. Kütüphane tam bir sunum nesne modelini kullanır ve yapı, master slaytlar ve düzenler dahil olmak üzere, korunur; böylece tasarım dönüşüm sonrası doğru kalır.

**Şifreyle korunan ODP dosyalarını dönüştürebilir miyim?**

Evet. Aspose.Slides, şifreyi sağladığınızda korumayı algılamayı, [korunan sunumları](/slides/tr/net/password-protected-presentation/) (ODP dahil) açmayı ve üzerinde çalışmayı, ayrıca şifreleme ve belge özelliklerine erişimi yapılandırmayı destekler.

**Aspose.Slides bulut veya REST tabanlı dönüşüm hizmetleri için uygun mu?**

Evet. Yerel kütüphaneyi kendi sunucu tarafında veya [Aspose.Slides Cloud](https://products.aspose.cloud/slides/tr/family/) (REST API) üzerinden kullanabilirsiniz; her iki seçenek de ODP → PPTX dönüşümünü destekler.