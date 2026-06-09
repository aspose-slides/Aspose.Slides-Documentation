---
title: API Kısıtlamaları
type: docs
weight: 320
url: /tr/php-java/api-limitations/
keywords:
- API kısıtlamaları
- dışa aktarma formatı
- uygulama
- üretici
- doküman özellikleri
- meta veri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP sınırlarını bilin: dışa aktarmalar PPT, PPTX, ODP ve PDF'de sabit Application/Producer meta verilerini ayarlar—entegrasyonları sürpriz olmadan planlamanıza yardımcı olur."
---
## **Genel Bakış**

Sunumlar Aspose.Slides ile oluşturulduğunda veya dışa aktarıldığında belirli teknik meta veriler çıktı dosyasına yazılır. Bu makale PPTX ve PDF dosyalarındaki `Application`, `Creator` ve `Producer` meta veri alanlarıyla ilgili sınırlamaları açıklar.

## **Uygulama ve Üretici**

Aspose.Slides for PHP via Java ile sunumlar oluşturduğunuzda veya dışa aktardığınızda, dosyaya bazı teknik meta veriler yazılır. İki alan genellikle sorular ortaya çıkarır:

**Application** **PPTX** sunumunu oluşturan veya en son kaydeden programı tanımlar. Aspose.Slides for PHP via Java'da bu değer sabittir ve uygulama adınız yerine kütüphane satıcısını gösterir, hatta [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/setnameofapplication/) kullansanız bile.

**Producer**, dışa aktarma sırasında son dosyayı üreten render motorunu tanımlar. **PDF** dışa aktarmalarında meta veriler **Creator** ve **Producer** alanlarını kullanır. Aspose.Slides for PHP via Java ile her iki alan da sabittir ve kütüphane ile sürümünü yansıtır.

**Ne sınırlıdır**

Bu alanları API üzerinden yukarıdaki formatlar için geçersiz kılamazsınız. **PPTX** için Application özelliği "Aspose.Slides for PHP via Java" olarak yazılır. **PDF** için Creator ve Producer özellikleri "Aspose.Slides for PHP via Java x.x.x." olarak yazılır. Bu davranış tasarıma göredir ve dosyayı nasıl yüklediğiniz veya kaydettiğinizden bağımsız olarak, ayrıca [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/setnameofapplication/) ile atanan değerlerden bağımsız olarak uygulanır.