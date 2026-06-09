---
title: C++'ta Sunumlara Çizgi Şekilleri Ekle
linktitle: Çizgi
type: docs
weight: 50
url: /tr/cpp/line/
keywords:
- çizgi
- çizgi oluştur
- çizgi ekle
- düz çizgi
- çizgi yapılandır
- çizgiyi özelleştir
- kesik çizgi stili
- ok başı
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint sunumlarında çizgi biçimlendirmeyi yönetmeyi öğrenin. Özellikleri, metodları ve örnekleri keşfedin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint slaytlarına programlı olarak çizgi şekilleri eklemenizi sağlar. Bu makale, basit bir çizgi nasıl oluşturulur ve bir çizginin ok gibi görünmesi için nasıl özelleştirileceğini gösterir.

Bir slayta çizgi şekli eklemeyi, görsel görünümünü ayarlamayı ve güncellenmiş sunumu kaydetmeyi öğreneceksiniz. Örnekler, stil, genişlik, noktalamalı desen, ok başı seçenekleri ve doldurma rengi gibi pratik çizgi biçimlendirme ayarlarına odaklanır.

## **Düz Bir Çizgi Oluştur**

- [Presentation sınıfı](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneğini oluşturun.
- Kaydırma referansını Index kullanarak edin.
- Shapes nesnesi tarafından sunulan [AddAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addautoshape/) metodunu kullanarak Line türünde bir AutoShape ekleyin.
- Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıda verilen örnekte, sunumun ilk slaytına bir çizgi ekledik.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **Ok Şeklinde Çizgi Oluştur**

Aspose.Slides for C++, geliştiricilerin çizginin daha çekici görünmesi için bazı özelliklerini yapılandırmasına da izin verir. Çizgiyi ok gibi göstermek için birkaç özelliği yapılandıralım. Bunu yapmak için aşağıdaki adımları izleyin:

- [Presentation sınıfı](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneğini oluşturun.
- Kaydırma referansını Index kullanarak edin.
- Shapes nesnesi tarafından sunulan [AddAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addautoshape/) metodunu kullanarak Line türünde bir AutoShape ekleyin.
- Line Style'ı Aspose.Slides for C++ tarafından sunulan stillerden birine ayarlayın.
- Çizginin Width değerini ayarlayın.
- Çizginin [Dash Style](https://reference.aspose.com/slides/tr/cpp/aspose.slides/linedashstyle/) değerini Aspose.Slides for C++ tarafından sunulan stillerden birine ayarlayın.
- Çizginin başlangıç noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/cpp/aspose.slides/lineformat/) ve Length değerlerini ayarlayın.
- Çizginin bitiş noktasının Arrow Head Style ve Length değerlerini ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **SSS**

**Düzenli bir çizgiyi bağlayıcıya dönüştürüp şekillere "yapışmasını" sağlayabilir miyim?**

Hayır. Düzenli bir çizgi (bir [AutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/autoshape/) türü [Line](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapetype/)) otomatik olarak bir bağlayıcı olmaz. Şekillere yapışmasını sağlamak için özel [Connector](https://reference.aspose.com/slides/tr/cpp/aspose.slides/connector/) türünü ve bağlantılar için [corresponding APIs](/slides/tr/cpp/connector/) kullanın.

**Tema tarafından devralınan bir çizgi özelliği varsa ve nihai değerleri belirlemek zor ise ne yapmalıyım?**

[Read the effective properties](/slides/tr/cpp/shape-effective-properties/) üzerinden [ILineFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilinefillformateffectivedata/) arayüzlerini kullanın—bunlar zaten kalıtımı ve tema stillerini hesaba katar.

**Bir çizgiyi düzenlemeye (taşıma, yeniden boyutlandırma) karşı kilitleyebilir miyim?**

Evet. Shapes, [lock objects](https://reference.aspose.com/slides/tr/cpp/aspose.slides/autoshape/get_autoshapelock/) sağlayarak [disallow editing operations](/slides/tr/cpp/applying-protection-to-presentation/) yapmanıza izin verir.