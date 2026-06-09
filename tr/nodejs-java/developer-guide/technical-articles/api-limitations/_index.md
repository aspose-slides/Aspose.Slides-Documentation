---
title: API Kısıtlamaları
type: docs
weight: 320
url: /tr/nodejs-java/api-limitations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js sınırlamalarını öğrenin: dışa aktarmalar PPT, PPTX, ODP ve PDF formatlarında sabit Application/Producer meta verileri ayarlar—entegrasyonları sürpriz olmadan planlamanıza yardımcı olur."
---
## **Genel Bakış**

Aspose.Slides ile sunumlar oluşturulduğunda veya dışa aktarıldığında, belirli teknik meta veriler çıkış dosyasına yazılır. Bu makale, PPTX ve PDF dosyalarındaki `Application`, `Creator` ve `Producer` meta veri alanlarıyla ilgili sınırlamaları açıklamaktadır.

## **Uygulama ve Üretici**

Aspose.Slides for Node.js via Java ile sunumlar oluşturduğunuzda veya dışa aktardığınızda, dosyaya bazı teknik meta veriler yazılır. Genellikle iki alan soru doğurur:

**Application** bir **PPTX** sunumunu oluşturan veya en son kaydeden programı tanımlar. Aspose.Slides for Node.js via Java'da bu değer sabittir ve kütüphane satıcısını gösterir, uygulama adınız ne olursa olsun, [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/setnameofapplication/) kullansanız bile.

**Producer** dışa aktarım sırasında nihai dosyayı oluşturan render motorunu tanımlar. **PDF** dışa aktarmalarında meta veriler **Creator** ve **Producer** alanlarını kullanır. Aspose.Slides for Node.js via Java ile her iki alan da sabittir ve kütüphane ile sürümünü yansıtır.

**Ne sınırlıdır**

Bu alanları API aracılığıyla yukarıdaki formatlar için geçersiz kılamazsınız. **PPTX** için Application özelliği "Aspose.Slides for Node.js via Java" olarak yazılır. **PDF** için Creator ve Producer özellikleri "Aspose.Slides for Node.js via Java x.x.x." olarak yazılır. Bu davranış tasarım gereğidir ve dosyayı nasıl yüklediğiniz veya kaydettiğiniz, ayrıca [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/setnameofapplication/) ile atadığınız değerler ne olursa olsun aynı şekilde uygulanır.