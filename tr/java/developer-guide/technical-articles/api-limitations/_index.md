---
title: Çıktı Meta Verisi Sınırlamaları
type: docs
weight: 320
url: /tr/java/api-limitations/
keywords:
- API sınırlamaları
- dışa aktarma formatı
- uygulama
- üretici
- belge özellikleri
- meta veriler
- oluşturucu
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java, kaydedilen PPTX, PDF ve ODP dosyalarına, uygulama adını ne ayarlarsanız ayarlayın, sabit uygulama, yaratıcı ve üretici meta verileri yazar."
---
## **Genel Bakış**

Aspose.Slides ile sunumlar oluşturulduğunda veya dışa aktarıldığında, belirli teknik meta veriler çıktı dosyasına yazılır. Bu makale, PPTX, PDF ve ODP dosyalarındaki `Application`, `Creator`, `Producer` ve generator meta veri alanlarıyla ilgili sınırlamaları açıklar.

## **Uygulama ve Üretici**

Aspose.Slides for Java ile sunumlar oluşturduğunuzda veya dışa aktardığınızda, dosyaya bazı teknik meta veriler yazılır. İki alan sıklıkla soru doğurur:

**Application** bir **PPTX** sunumunu oluşturan veya en son kaydeden programı belirtir. Aspose.Slides for Java’da bu değer sabittir ve uygulama adınız yerine kütüphane adını gösterir; hatta [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/tr/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) kullansanız da.

**Producer** dışa aktarma sırasında son dosyayı oluşturan render motorunu belirtir. **PDF** dışa aktarmalarda meta veriler **Creator** ve **Producer** alanlarını kullanır. Aspose.Slides for Java ile bu iki alan da sabittir ve kütüphane ile sürümünü yansıtır.

**Kısıtlamalar**

Yukarıdaki formatlar için bu alanları API aracılığıyla geçersiz kılamazsınız. **PPTX** için Application özelliği "Aspose.Slides for Java" olarak yazılır. **PDF** için Creator ve Producer özellikleri "Aspose.Slides for Java" ve ardından kütüphane sürümü olarak yazılır. **ODP** için generator alanı da aynı şekilde "Aspose.Slides for Java" ve kütüphane sürümüyle yazılır. Bu davranış tasarım gereği olup, dosyanın nasıl yüklendiği veya kaydedildiği ve [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/tr/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) ile atanan değerler dikkate alınmaksızın uygulanır.

Bu kısıtlama **PPT** dosyaları için geçerli değildir: bir PPT dosyasında, [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/tr/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) ile ayarladığınız uygulama adı kaydedilir.