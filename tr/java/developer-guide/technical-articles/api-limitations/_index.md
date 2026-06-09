---
title: API Kısıtlamaları
type: docs
weight: 320
url: /tr/java/api-limitations/
keywords:
- API kısıtlamaları
- dışa aktarma formatı
- uygulama
- üretici
- belge özellikleri
- meta veri
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java sınırlamalarını öğrenin: dışa aktarmalar PPT, PPTX, ODP ve PDF'te sabit Application/Producer meta verilerini ayarlar—böylece entegrasyonları sürpriz olmadan planlayabilirsiniz."
---
## **Genel Bakış**

Aspose.Slides ile sunumlar oluşturulduğunda veya dışa aktarıldığında, bazı teknik meta veriler çıktı dosyasına yazılır. Bu makale, PPTX ve PDF dosyalarındaki `Application`, `Creator` ve `Producer` meta veri alanlarıyla ilgili sınırlamaları açıklar.

## **Uygulama ve Üretici**

Aspose.Slides for Java ile sunumlar oluşturduğunuzda veya dışa aktardığınızda, bazı teknik meta veriler dosyaya yazılır. İki alan sıklıkla soru doğurur:

**Application** bir **PPTX** sunumunu oluşturan veya en son kaydeden programı tanımlar. Aspose.Slides for Java’da bu değer sabittir ve uygulama adınızı kullanıp kullanmadığınıza bakılmaksızın kütüphane satıcısını gösterir, hatta [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/tr/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) kullansanız bile.

**Producer** dışa aktarım sırasında nihai dosyayı oluşturan render motorunu tanımlar. **PDF** dışa aktarımlarında meta veriler **Creator** ve **Producer** alanlarını kullanır. Aspose.Slides for Java ile bunların her ikisi de sabittir ve kütüphane ile sürümünü yansıtır.

**Sınırlamalar**

Yukarıdaki formatlar için bu alanları API aracılığıyla değiştiremezsiniz. **PPTX** için Application özelliği "Aspose.Slides for Java" olarak yazılır. **PDF** için Creator ve Producer özellikleri "Aspose.Slides for Java x.x.x." olarak yazılır. Bu davranış tasarıma göre belirlenmiştir ve dosyayı nasıl yüklediğinize veya kaydettiğinize, ayrıca [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/tr/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) ile atanan değerlere bakılmaksızın uygulanır.