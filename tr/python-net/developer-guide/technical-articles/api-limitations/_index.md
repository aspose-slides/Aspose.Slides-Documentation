---
title: API Kısıtlamaları
type: docs
weight: 210
url: /tr/python-net/api-limitations/
keywords:
- API kısıtlamaları
- dışa aktarma biçimi
- uygulama
- üretici
- belge özellikleri
- meta veri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python sınırlamalarını öğrenin: dışa aktarmalar PPT, PPTX, ODP ve PDF'de sabit Application/Producer meta verilerini ayarlar—entegrasyonları sürpriz olmadan planlamanıza yardımcı olur."
---
## **Genel Bakış**

Aspose.Slides ile sunumlar oluşturulduğunda veya dışa aktarıldığında, belirli teknik meta veriler çıktısı dosyasına yazılır. Bu makale, PPTX ve PDF dosyalarındaki `Application`, `Creator` ve `Producer` meta veri alanlarıyla ilgili sınırlamaları açıklar.

## **Application ve Producer**

Aspose.Slides for Python via .NET ile sunumlar oluşturduğunuzda veya dışa aktardığınızda, bazı teknik meta veriler dosyaya yazılır. İki alan sıkça soru doğurur:

**Application**, bir **PPTX** sunumunu oluşturan veya en son kaydeden programı tanımlar. Aspose.Slides for Python via .NET’de bu değer sabittir ve uygulama adınız ne olursa olsun, kütüphane satıcısını gösterir; hatta [DocumentProperties.name_of_application](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/name_of_application/) ayarlasanız bile.

**Producer**, dışa aktarma sırasında son dosyayı oluşturan render motorunu tanımlar. **PDF** dışa aktarmalarında meta veriler **Creator** ve **Producer** alanlarını kullanır. Aspose.Slides for Python via .NET ile bu iki alan da sabittir ve kütüphane ile sürümünü yansıtır.

**Sınırlamalar**

Bu alanları API üzerinden yukarıdaki formatlar için geçersiz kılamazsınız. **PPTX** için Application özelliği "Aspose.Slides for Python via .NET" olarak yazılır. **PDF** için Creator ve Producer özellikleri "Aspose.Slides for Python via .NET x.x.x" olarak yazılır. Bu davranış tasarım gereğidir ve dosyanın nasıl yüklendiği veya kaydedildiği, ayrıca [DocumentProperties.name_of_application](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/name_of_application/) değerine ne atanmış olduğu fark etmeksizin uygulanır.