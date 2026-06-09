---
title: API Sınırlamaları
type: docs
weight: 320
url: /tr/cpp/api-limitations/
keywords:
- API sınırlamaları
- dışa aktarma formatı
- uygulama
- üretici
- belge özellikleri
- meta veriler
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ sınırlamalarını bilin: dışa aktarmalar PPT, PPTX, ODP ve PDF'de sabit Application/Producer meta verilerini ayarlar—entegrasyonları sürpriz olmadan planlamanıza yardımcı olur."
---
## **Genel Bakış**

Aspose.Slides ile sunumlar oluşturulduğunda veya dışa aktarıldığında, belirli teknik meta veriler çıktıyı dosyasına yazılır. Bu makale, PPTX ve PDF dosyalarındaki `Application`, `Creator` ve `Producer` meta veri alanlarıyla ilgili sınırlamaları açıklar.

## **Application ve Producer**

Aspose.Slides for C++ ile sunumlar oluşturduğunuzda veya dışa aktardığınızda, dosyaya bazı teknik meta veriler yazılır. İki alan genellikle soru doğurur:

**Application** bir **PPTX** sunumunu oluşturan veya son kaydeden programı tanımlar. Aspose.Slides for C++ içinde bu değer sabittir ve uygulama adınız yerine kütüphane sağlayıcısını gösterir, hatta [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/tr/cpp/aspose.slides/documentproperties/set_nameofapplication/) kullansanız bile.

**Producer** dışa aktarma sırasında nihai dosyayı oluşturan render motorunu tanımlar. **PDF** dışa aktarmalarda meta veri **Creator** ve **Producer** alanlarını kullanır. Aspose.Slides for C++ ile bu iki alan da sabittir ve kütüphaneyi ve sürümünü yansıtır.

**Sınırlamalar**

Yukarıdaki formatlar için bu alanları API aracılığıyla geçersiz kılamazsınız. **PPTX** için Application özelliği "Aspose.Slides for C++" olarak yazılır. **PDF** için Creator ve Producer özellikleri "Aspose.Slides for C++ x.x.x" olarak yazılır. Bu davranış tasarım gereği olup, dosyayı nasıl yüklediğiniz veya kaydettiğiniz ve [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/tr/cpp/aspose.slides/documentproperties/set_nameofapplication/) kullanarak atadığınız değerler ne olursa olsun geçerlidir.