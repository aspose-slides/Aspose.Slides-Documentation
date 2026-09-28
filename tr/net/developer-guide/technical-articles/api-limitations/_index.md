---
title: Çıktı Üst Veri Sınırlamaları
type: docs
weight: 320
url: /tr/net/api-limitations/
keywords:
- API sınırlamaları
- dışa aktarma biçimi
- uygulama
- üretici
- belge özellikleri
- üst veri
- üreteç
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET, belirlediğiniz uygulama adı ne olursa olsun, kaydedilen PPTX, PDF ve ODP dosyalarına sabit uygulama, oluşturucu ve üretici üst verileri yazar."
---
## **Genel Bakış**

Aspose.Slides ile sunumlar oluşturulduğunda veya dışa aktarıldığında, belirli teknik üst veriler çıkış dosyasına yazılır. Bu makale, PPTX, PDF ve ODP dosyalarındaki `Application`, `Creator`, `Producer` ve generator üst veri alanlarıyla ilgili sınırlamaları açıklamaktadır.

## **Application ve Producer**

Aspose.Slides for .NET ile sunumlar oluşturduğunuzda veya dışa aktardığınızda, dosyaya bazı teknik üst veriler yazılır. Sıklıkla soru gündeme gelen iki alan:

**Application** bir **PPTX** sunumunu oluşturan veya en son kaydeden programı tanımlar. Aspose.Slides for .NET içinde bu değer sabittir ve uygulama adınız yerine kütüphane adını gösterir; hatta [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/tr/net/aspose.slides/documentproperties/nameofapplication/) ayarlasanız bile.

**Producer** dışa aktarım sırasında final dosyasını üreten işleme motorunu tanımlar. **PDF** dışa aktarmalarında üst veriler **Creator** ve **Producer** alanlarını kullanır. Aspose.Slides for .NET ile bu ikisi de sabittir ve kütüphane ile sürümünü yansıtır.

**Kısıtlamalar**

Bu alanları API üzerinden yukarıdaki biçimlerde geçersiz kılmanız mümkün değildir. **PPTX** için Application özelliği “Aspose.Slides for .NET” olarak yazılır. **PDF** için Creator ve Producer özellikleri “Aspose.Slides for .NET” ve ardından kütüphane sürümü biçiminde yazılır. **ODP** için generator alanı “Aspose.Slides for .NET” ve ardından kütüphane sürümü biçiminde yazılır. Bu davranış tasarım gereği olup, dosyanın nasıl yüklendiği veya kaydedildiği ve [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/tr/net/aspose.slides/documentproperties/nameofapplication/) deki değerler göz ardı edilir.

Bu kısıtlama **PPT** dosyaları için geçerli değildir: bir PPT dosyasında, [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/tr/net/aspose.slides/documentproperties/nameofapplication/) içinde ayarladığınız uygulama adı kaydedilir.