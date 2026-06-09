---
title: C++ Kullanarak Sunumlarda Üst Simge ve Alt Simge Yönetimi
linktitle: Üst Simge ve Alt Simge
type: docs
weight: 80
url: /tr/cpp/superscript-and-subscript/
keywords:
- üst simge
- alt simge
- üst simge ekle
- alt simge ekle
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'de üst ve alt simgeyi ustalaştırın ve en yüksek etki için profesyonel metin biçimlendirmesiyle sunumlarınızı yükseltin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarınıza üst simge ve alt simge metin ekleme özellikleri sağlar. Kimyasal formülleri, matematiksel denklemleri vurgulamanız ya da içeriği dipnotlarla açıklamanız gerektiğinde, bu özel biçimlendirme seçenekleri açıklık ve kesinliği korur. Bu makalede, üst simge ve alt simge stillerini sorunsuz bir şekilde nasıl uygulayacağınızı ve her slaytta profesyonel sonuçlar elde edeceğinizi öğreneceksiniz.

## **Üst Simge ve Alt Simge Metni Yönetme**

Herhangi bir paragraf bölümüne üst simge ve alt simge metni ekleyebilirsiniz. Aspose.Slides metin çerçevesinde Üst Simge veya Alt Simge metni eklemek için **Escapement** özelliğini PortionFormat sınıfından kullanmanız gerekir.

Bu özellik, üst simge veya alt simge metnini (değer -%100 (alt simge) ile %100 (üst simge) arasında) döndürür veya ayarlar. Örneğin :

- [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- Bir slaytın referansını Index kullanarak alın.
- Slayta Dikdörtgen tipinde bir IAutoShape ekleyin.
- IAutoShape ile ilişkili ITextFrame’e erişin.
- Mevcut Paragrafları temizleyin
- Üst simge metni tutacak yeni bir paragraf nesnesi oluşturun ve bunu ITextFrame’in IParagraphs koleksiyonuna ekleyin.
- Yeni bir portion nesnesi oluşturun
- Üst simge eklemek için portion’ın Escapement özelliğini 0 ile 100 arasında ayarlayın. (0 üst simge yok anlamına gelir)
- Portion için bir metin ayarlayın ve ardından bu metni paragrafın portion koleksiyonuna ekleyin.
- Alt simge metni tutacak yeni bir paragraf nesnesi oluşturun ve bunu ITextFrame’in IParagraphs koleksiyonuna ekleyin.
- Yeni bir portion nesnesi oluşturun
- Alt simge eklemek için portion’ın Escapement özelliğini 0 ile -100 arasında ayarlayın. (0 alt simge yok anlamına gelir)
- Portion için bir metin ayarlayın ve ardından bu metni paragrafın portion koleksiyonuna ekleyin.
- Sunumu PPTX dosyası olarak kaydedin.

Yukarıdaki adımların uygulanması aşağıda verilmiştir.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **SSS**

**Üst simge ve alt simge, PDF veya diğer formatlara dışa aktarılırken korunur mu?**

Evet, Aspose.Slides, sunumları PDF, PPT/PPTX, görüntüler ve diğer desteklenen formatlara dışa aktarırken üst simge ve alt simge biçimlendirmesini doğru bir şekilde korur. Özel biçimlendirme tüm çıktı dosyalarında yerini korur.

**Üst simge ve alt simge, kalın veya italik gibi diğer biçimlendirme stilleriyle birleştirilebilir mi?**

Evet, Aspose.Slides, tek bir portion içinde çeşitli metin stillerini karıştırmanıza izin verir. Kalın, italik, alt çizgi gibi stilleri etkinleştirip aynı anda üst simge veya alt simge uygulamak için [PortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/portionformat/) sınıfındaki ilgili özellikleri yapılandırabilirsiniz.

**Üst simge ve alt simge biçimlendirmesi tablolar, grafikler veya SmartArt içindeki metinlerde çalışır mı?**

Evet, Aspose.Slides, tablolar ve grafik öğeleri gibi çoğu nesne içinde biçimlendirmeyi destekler. SmartArt ile çalışırken, ilgili öğelere (ör. [SmartArtNode](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/smartartnode/)) ve metin konteynerlerine erişmeniz ve ardından aynı şekilde [PortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/portionformat/) özelliklerini yapılandırmanız gerekir.