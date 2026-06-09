---
title: API Sınırlamaları
type: docs
weight: 320
url: /tr/net/api-limitations/
keywords:
- API sınırlamaları
- dışa aktarma formatı
- uygulama
- üretici
- belge özellikleri
- meta veri
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET sınırlamalarını öğrenin: dışa aktarmalar PPT, PPTX, ODP ve PDF'de sabit Application/Producer meta verilerini ayarlar—böylece entegrasyonları sürpriz olmadan planlayabilirsiniz."
---
## **Genel Bakış**

Aspose.Slides ile sunumlar oluşturulduğunda veya dışa aktarıldığında, belirli teknik meta veriler çıkış dosyasına yazılır. Bu makale, PPTX ve PDF dosyalarındaki `Application`, `Creator` ve `Producer` meta veri alanlarıyla ilgili kısıtlamaları açıklar.

## **Uygulama ve Üretici**

Aspose.Slides for .NET ile sunumlar oluşturduğunuzda veya dışa aktardığınızda, bazı teknik meta veriler dosyaya yazılır. İki alan genellikle sorular doğurur:

**Application** bir **PPTX** sunumunu oluşturan veya en son kaydeden programı tanımlar. Aspose.Slides for .NET'te bu değer sabittir ve uygulama adınız yerine kütüphane satıcısını gösterir, hatta [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/tr/net/aspose.slides/documentproperties/nameofapplication/) ayarlasanız bile.

**Producer** dışa aktarım sırasında son dosyayı oluşturan renderleme motorunu tanımlar. **PDF** dışa aktarımlarında meta veriler **Creator** ve **Producer** alanlarını kullanır. Aspose.Slides for .NET ile her iki alan da sabit olup kütüphane ve sürümünü yansıtır.

**Ne kısıtlanmıştır**

Bu alanları API üzerinden yukarıdaki formatlar için geçersiz kılamazsınız. **PPTX** için Application özelliği "Aspose.Slides for .NET" olarak yazılır. **PDF** için Creator ve Producer özellikleri "Aspose.Slides for .NET x.x.x" olarak yazılır. Bu davranış tasarım gereği olup dosyanın nasıl yüklendiği veya kaydedildiği ve [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/tr/net/aspose.slides/documentproperties/nameofapplication/) değerine atanan değerler ne olursa olsun uygulanır.