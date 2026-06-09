---
title: C++ ile Sunum Oluşturma
linktitle: Sunum Oluştur
type: docs
weight: 10
url: /tr/cpp/create-presentation/
keywords:
- sunum oluştur
- yeni sunum
- PPT oluştur
- yeni PPT
- PPTX oluştur
- yeni PPTX
- ODP oluştur
- yeni ODP
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides ile C++’ta sunumlar oluşturun—PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinden yararlanın ve güvenilir sonuçlar için programlı olarak kaydedin."
---
## **Overview**

Bu makale, Aspose.Slides ile bir sunum oluşturmayı, bir slayta basit içerik eklemeyi ve sonucu dosya olarak kaydetmeyi gösterir.

## **Create a PowerPoint Presentation**
Sunumun seçili slaytına basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.  
2. İndeksini kullanarak bir slaytın referansını alın.  
3. Shapes nesnesinin sunduğu AddAutoShape yöntemiyle Çizgi türünde bir AutoShape ekleyin.  
4. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun ilk slaytına bir çizgi ekledik.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **FAQ**

**What formats can I save a new presentation to?**

[PPTX, PPT ve ODP](/slides/tr/cpp/save-presentation/) formatlarında kaydedebilir ve [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/tr/cpp/convert-powerpoint-to-xps/), [HTML](/slides/tr/cpp/convert-powerpoint-to-html/), [SVG](/slides/tr/cpp/convert-powerpoint-to-png/) ve [görseller](/slides/tr/cpp/convert-powerpoint-to-png/) gibi diğer formatlara dışa aktarabilirsiniz.

**Can I start from a template (POTX/POTM) and save as a regular PPTX?**

Evet. Şablonu yükleyin ve istediğiniz formata kaydedin; POTX/POTM/PPTM ve benzeri formatlar [desteklenir](/slides/tr/cpp/supported-file-formats/).

**How do I control slide size/aspect ratio when creating a presentation?**

[Slayt boyutunu](/slides/tr/cpp/slide-size/) (4:3, 16:9 gibi ön ayarlar veya özel boyutlar) ayarlayın ve içeriğin nasıl ölçekleneceğini seçin.

**In what units are sizes and coordinates measured?**

Puan cinsindendir: 1 inç = 72 birim.

**How do I handle very large presentations (with many media files) to reduce memory usage?**

[BLOB yönetim stratejilerini](/slides/tr/cpp/manage-blob/) kullanın, geçici dosyalar aracılığıyla bellek içi depolamayı sınırlayın ve mümkün olduğunca dosya temelli iş akışlarını tercih edin.

**Can I create/save presentations in parallel?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneğini [birden çok iş parçacığından](/slides/tr/cpp/multithreading/) kullanamazsınız. İş parçacığı ya da süreç başına ayrı, izole örnekler çalıştırın.

**How do I remove the trial watermark and limitations?**

İşlem başına bir kez [lisans uygulayın](/slides/tr/cpp/licensing/). Lisans XML’i değiştirilmemeli ve birden çok iş parçacığı kullanılıyorsa lisans ayarları senkronize edilmelidir.

**Can I digitally sign the PPTX I create?**

Evet. Sunumlar için [dijital imzalar](/slides/tr/cpp/digital-signature-in-powerpoint/) (ekleme ve doğrulama) desteklenir.

**Are macros (VBA) supported in created presentations?**

Evet. [VBA projeleri oluşturup/​düzenleyebilir](/slides/tr/cpp/presentation-via-vba/) ve PPTM/PPSM gibi makro‑etkin dosyaları kaydedebilirsiniz.