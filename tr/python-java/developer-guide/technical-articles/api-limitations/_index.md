---
title: API Kısıtlamaları
type: docs
weight: 320
url: /tr/python-java/api-limitations/
keywords:
- API kısıtlamaları
- dışa aktarım formatı
- uygulama
- üretici
- belge özellikleri
- meta veri
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java sınırlamaları hakkında bilgi edinin: PPTX ve PDF dosyalarında sabit Application, Creator ve Producer meta verileri."
---
## **Genel Bakış**

Aspose.Slides ile sunumlar oluşturulduğunda veya dışa aktarıldığında, belirli teknik meta veriler çıktı dosyasına yazılır. Bu makale, PPTX ve PDF dosyalarındaki `Application`, `Creator` ve `Producer` meta veri alanlarıyla ilgili sınırlamaları açıklar.

## **Application ve Producer**

Aspose.Slides for Python via Java ile sunumlar oluşturduğunuzda veya dışa aktardığınızda dosyaya bazı teknik meta veriler yazılır. Sıkça sorulan iki alan şunlardır:

**Application** bir **PPTX** sunumunu oluşturan veya son kaydetme işlemini yapan programı tanımlar. Aspose.Slides for Python via Java’da bu değer sabittir ve kütüphane satıcısını gösterir; uygulama adınızı göstermez, hatta [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#setnameofapplication) kullansanız bile.

**Producer** dışa aktarma sırasında son dosyayı oluşturan render motorunu tanımlar. **PDF** dışa aktarmalarında meta veriler **Creator** ve **Producer** alanlarını kullanır. Aspose.Slides for Python via Java’da bu alanlar da sabittir ve kütüphane ile sürümünü yansıtır.

**Ne Kısıtlanmıştır**

Bu alanları API aracılığıyla yukarıdaki formatlarda geçersiz kılmanız mümkün değildir. **PPTX** için Application özelliği “Aspose.Slides for Java” olarak yazılır. **PDF** için Creator ve Producer özellikleri “Aspose.Slides for Java x.x.x.” olarak yazılır. Bu davranış tasarıma göredir ve dosyayı nasıl yüklerseniz veya kaydederseniz, [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#setnameofapplication) ile atanan değerler ne olursa olsun uygulanır.

## **SSS**

**Application değerini bir PPTX dosyasında uygulama adımla değiştirebilir miyim?**

Hayır. Değer sabittir, hatta [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#setnameofapplication) kullansanız bile değişmez.

**PDF dışa aktarmalarında Creator ve Producer alanlarını geçersiz kılabilir miyim?**

Hayır. Her iki alan da sabittir ve kütüphane ile sürümünü yansıtır; sunumu nasıl yüklerseniz veya kaydederseniz aynı kalır.