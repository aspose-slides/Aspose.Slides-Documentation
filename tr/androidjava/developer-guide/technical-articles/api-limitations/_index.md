---
title: API Kısıtlamaları
type: docs
weight: 320
url: /tr/androidjava/api-limitations/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android sınırlamalarını bilin: dışa aktarmalar PPT, PPTX, ODP ve PDF'de sabit Application/Producer meta verilerini ayarlar—entegrasyonları sürpriz olmadan planlamanıza yardımcı olur."
---
## **Genel Bakış**

Aspose.Slides ile sunumlar oluşturulduğunda veya dışa aktarıldığında, dosyaya belirli teknik meta veriler yazılır. Bu makale, PPTX ve PDF dosyalarındaki `Application`, `Creator` ve `Producer` meta veri alanlarıyla ilgili sınırlamaları açıklar.

## **Uygulama ve Üretici**

Aspose.Slides for Android via Java ile sunumlar oluşturduğunuzda veya dışa aktardığınızda, dosyaya bazı teknik meta veriler yazılır. Sıkça soru doğuran iki alan vardır:

**Application** bir **PPTX** sunumunu oluşturan veya son kaydetme işlemini yapan programı tanımlar. Aspose.Slides for Android via Java’da bu değer sabittir ve uygulama adınız yerine kütüphane satıcısını gösterir; hatta [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) kullanırsanız bile.

**Producer** dışa aktarma sırasında nihai dosyayı oluşturan işleme motorunu tanımlar. **PDF** dışa aktarmalarda meta veriler **Creator** ve **Producer** alanlarını kullanır. Aspose.Slides for Android via Java ile bu iki alan da sabittir ve kütüphane ile sürümünü yansıtır.

**Ne sınırlıdır**

Bu alanları API üzerinden yukarıdaki biçimler için geçersiz kılabilirsiniz. **PPTX** için Application özelliği "Aspose.Slides for Android via Java" olarak yazılır. **PDF** için Creator ve Producer özellikleri "Aspose.Slides for Android via Java x.x.x." olarak yazılır. Bu davranış tasarım gereği olup, dosyayı nasıl yüklediğiniz veya kaydettiğiniz ve [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) ile atanan değerler göz önüne alınmadan uygulanır.