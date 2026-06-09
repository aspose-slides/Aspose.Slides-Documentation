---
title: C++ ile Sunum Yerelleştirmesini Otomatikleştirin
linktitle: Sunum Yerelleştirmesi
type: docs
weight: 100
url: /tr/cpp/presentation-localization/
keywords:
- dil değişikliği
- yazım denetimi
- dil kimliği
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "C++ ile Aspose.Slides kullanarak PowerPoint ve OpenDocument slayt yerelleştirmesini otomatize edin, pratik kod örnekleri ve daha hızlı küresel dağıtım için ipuçları sağlayarak."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak bir sunumdaki metnin `LanguageId` değerini nasıl ayarlayacağınızı açıklar. Sunumu nasıl açacağınızı, metin içeren bir şekil eklemeyi, bir metin bölümüne dil tanımlayıcısı atamayı ve sonucu PPTX dosyası olarak kaydetmeyi gösterir.

## **Sunum ve Şekil Metni İçin Dili Değiştir**
- [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- Slaytın referansını, indeksini kullanarak alın.
- Slayta Dikdörtgen türünde bir AutoShape ekleyin.
- TextFrame'e bir miktar metin ekleyin.
- Metne Language Id atayın.
- Sunumu PPTX dosyası olarak yazın.

Yukarıdaki adımların uygulanması aşağıdaki örnekte gösterilmiştir.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **SSS**

**Dil kimliği otomatik metin çevirisini tetikler mi?**

Hayır. Aspose.Slides'taki [Language ID](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_languageid/) yazım denetimi ve dilbilgisi kontrolü için dili depolar, ancak metin içeriğini çevremez veya değiştirmez. PowerPoint'in denetim için anlayacağı bir meta veridir.

**Dil kimliği, renderlama sırasında tireleme ve satır sonlarını etkiler mi?**

Aspose.Slides'te, [Language ID](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_languageid/) denetim amaçlıdır. Tireleme kalitesi ve satır kaydırma öncelikle [uygun yazı tipleri](/slides/tr/cpp/powerpoint-fonts/) ve yazı sistemi için düzen/satır sonu ayarlarına bağlıdır. Doğru renderlamayı sağlamak için gerekli yazı tiplerini kullanılabilir hale getirin, [yazı tipi ikame kuralları](/slides/tr/cpp/font-substitution/) ayarlarını yapılandırın ve/veya [yazı tiplerini gömme](/slides/tr/cpp/embedded-font/) sunuma gömün.

**Tek bir paragrafta farklı diller ayarlayabilir miyim?**

Evet. [Language ID](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_languageid/) metin bölümü seviyesinde uygulanır; bu nedenle tek bir paragraf, farklı denetim ayarlarına sahip birden çok dili karıştırabilir.