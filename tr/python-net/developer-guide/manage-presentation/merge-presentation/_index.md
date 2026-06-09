---
title: Python ile Sunumları Verimli Bir Şekilde Birleştirme
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/python-net/merge-presentation/
keywords:
- PowerPoint birleştir
- sunumları birleştir
- slaytları birleştir
- PPT birleştir
- PPTX birleştir
- ODP birleştir
- PowerPoint birleştir
- sunumları birleştir
- slaytları birleştir
- PPT birleştir
- PPTX birleştir
- ODP birleştir
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarını zahmetsizce birleştirerek iş akışınızı hızlandırın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan diğerine slaytları klonlayarak sunumları birleştirmenizi sağlar. Bu makale, tüm sunumları veya seçili slaytları nasıl birleştireceğinizi, birleştirme sırasında slayt ana şablonu veya belirli bir düzenin nasıl kullanılacağını, farklı slayt boyutlarına sahip sunumların nasıl ele alınacağını ve birleştirilen slaytların bir sunum bölümüne nasıl ekleneceğini açıklar. Ayrıca birleştirilmiş içeriğe ilişkin pratik notları, konuşmacı notlarını, yorumları, şifre korumalı kaynak dosyaları ve iş parçacığı kullanımını kapsar.

## **Sunum Birleştirmenizi Optimize Edin**

[Aspose.Slides for Python](https://products.aspose.com/slides/tr/python-net/) ile stilleri, düzenleri ve tüm öğeleri koruyarak PowerPoint sunumlarını sorunsuz bir şekilde birleştirebilirsiniz. Diğer araçların aksine, Aspose.Slides kaliteyi veya veriyi kaybetmeden sunumları birleştirir. Tüm desteleri, belirli slaytları veya hatta farklı dosya biçimlerini (ör. PPT'den PPTX'e) birleştirin.

### **Birleştirme Özellikleri**

- **Tam Sunum Birleştirme:** Tüm slaytları tek bir dosyada birleştir.
- **Belirli Slayt Birleştirme:** Seçilen slaytları seçin ve birleştirin.
- **Çapraz Format Birleştirme:** Farklı formatlardaki sunumları bütünlüğünü koruyarak entegre edin.

## **Sunum Birleştirme**

Bir sunumu diğerine birleştirdiğinizde, slaytlarını tek bir sunumda birleştirerek tek bir dosya üretmiş olursunuz. PowerPoint veya OpenOffice gibi çoğu sunum programı, bu şekilde sunumları birleştirmenize izin veren özellikler sunmaz.

Ancak, [Aspose.Slides for Python](https://products.aspose.com/slides/tr/python-net/) birden fazla şekilde sunumları birleştirmenizi sağlar. Tüm şekiller, stiller, metin, biçimlendirme, yorumlar ve animasyonlar kayıpsız bir şekilde birleştirilebilir.

**Ayrıca bakınız**

[Python'da PowerPoint Slaytlarını Klonla](/slides/tr/python-net/clone-slides/)

### **Ne Birleştirilebilir**

Aspose.Slides ile şunları birleştirebilirsiniz:

- Tam sunumlar: Kaynak desteden tüm slaytlar tek bir sunumda birleştirilir.
- Belirli slaytlar: Yalnızca seçilen slaytlar tek bir sunumda birleştirilir.
- Aynı formatta sunumlar (ör. PPT→PPT, PPTX→PPTX) veya farklı formatlarda (ör. PPT→PPTX, PPTX→ODP).

### **Birleştirme Seçenekleri**

Şunları kontrol edebilirsiniz:
- Çıktı sunumundaki her slayt orijinal stilini korusun, ya da
- Çıktı sunumundaki tüm slaytlara tek bir stil uygulansın.

Sunumları birleştirmek için Aspose.Slides, [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) sınıfındaki [add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) yöntemlerini sağlar. Bu yöntem aşırı yüklemeleri birleştirmenin nasıl gerçekleştirileceğini tanımlar. Her [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesi bir [slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/slides/tr/) koleksiyonu sunar, bu nedenle hedef sunumun slide koleksiyonunda `add_clone` çağrılır.

`add_clone` yöntemi bir `Slide` döndürür—kaynak slayın bir klonu. Çıktı sunumundaki slaytlar orijinalin kopyalarıdır, bu nedenle stil, biçimlendirme veya düzen uygulayarak sonuç slaytlarını kaynak sunumları etkilemeden değiştirebilirsiniz.

## **Sunumları Birleştirme**

Aspose.Slides, slaytların düzenlerini ve stillerini koruyarak (varsayılan parametreler kullanılarak) birleştirmenizi sağlayan [add_clone(ISlide)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) yöntemini sunar.

Aşağıdaki Python örneği, sunumları nasıl birleştireceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Slayt Ana Şablonu ile Sunumları Birleştirme**

Aspose.Slides, bir şablondan slayt ana şablonu uygulayarak slaytları birleştirmenizi sağlayan [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) yöntemini sunar. Bu sayede gerektiğinde çıktıda slaytların stilini yeniden uygulayabilirsiniz.

Aşağıdaki Python örneği bu işlemi gösterir:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Note" color="warning" %}}
Belirtilen slayt ana şablonu altındaki uygun düzen otomatik olarak belirlenir. Uygun bir düzen bulunamazsa ve `add_clone` yönteminin `allow_clone_missing_layout` boolean parametresi `True` olarak ayarlanmışsa, kaynak slaydın düzeni kullanılır. Aksi takdirde bir [PptxEditException](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pptxeditexception/) fırlatılır.
{{% /alert %}}

Çıktı sunumundaki slaytlara farklı bir slayt düzeni uygulamak için birleştirirken [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) yöntemini kullanın.

## **Sunumlardan Belirli Slaytları Birleştirme**

Birden çok sunumdan belirli slaytları birleştirmek, özel slayt desteleri oluştururken yararlıdır. Aspose.Slides, yalnızca ihtiyacınız olan slaytları seçip içe aktarmanıza izin verirken, orijinal slaytların biçimlendirmesini, düzenini ve tasarımını korur.

Aşağıdaki Python örneği, iki diğer sunumdan başlık slaytları ekleyerek yeni bir sunum oluşturur ve sonucu bir dosyaya kaydeder:

```py
def get_title_slide(pres):
    for slide in pres.slides:
        if slide.layout_slide.layout_type == slides.SlideLayoutType.TITLE:
            return slide
    return None


with slides.Presentation() as presentation, \
        slides.Presentation("presentation1.pptx") as presentation1, \
        slides.Presentation("presentation2.pptx") as presentation2:
    presentation.slides.remove_at(0)

    slide1 = get_title_slide(presentation1)
    if slide1 is not None:
        presentation.slides.add_clone(slide1)

    slide2 = get_title_slide(presentation2)
    if slide2 is not None:
        presentation.slides.add_clone(slide2)

    presentation.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Slayt Düzeni ile Sunumları Birleştirme**

Aşağıdaki Python örneği, tek bir çıktıda birleştirilmiş bir sunum oluşturmak için belirli bir slayt düzeni uygulayarak birden çok sunumdan slaytları nasıl birleştireceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştirme**

{{% alert title="Note" color="warning" %}}
Farklı slayt boyutlarına sahip sunumları doğrudan birleştiremezsiniz.
{{% /alert %}}

İki farklı slayt boyutuna sahip sunumu birleştirmek için, önce bir sunumun slayt boyutunu diğerine eşit olacak şekilde yeniden boyutlandırın.

Aşağıdaki örnek kod bu süreci gösterir:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    slide_size = presentation1.slide_size.size
    with slides.Presentation("presentation2.pptx") as presentation2:
        presentation2.slide_size.set_size(slide_size.width, slide_size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **Slaytları Bir Sunum Bölümüne Birleştirme**

Aşağıdaki Python örneği, belirli bir slaytı bir sunum bölümüne nasıl birleştireceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

Slayt, bölümün sonuna eklenir. 

{{% alert title="Tip" color="primary" %}}
PowerPoint sunumlarını **ücretsiz çevrimiçi araç** ile birleştirmek mi istiyorsunuz? **Aspose PowerPoint Merger**'ı deneyin.

- **PowerPoint dosyalarını kolayca birleştirin**: Birden fazla **PPT, PPTX, ODP** sunumunu tek bir dosyada birleştirin.  
- **Farklı formatları destekler**: **PPT'den PPTX'e**, **PPTX'den ODP'ye** ve daha fazlasını birleştirin.  
- **Kurulum gerekmez**: Doğrudan tarayıcınızda çalışır, hızlı ve güvenlidir.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/tr/merger)  

PowerPoint dosyalarınızı **Aspose ücretsiz çevrimiçi aracı** ile bugün birleştirmeye başlayın!  
{{% /alert %}}

{{% alert title="Tip" color="primary" %}}
Aspose, bir [ÜCRETSİZ Collage web uygulaması](https://products.aspose.app/slides/tr/collage) sunar. Bu çevrimiçi hizmet sayesinde [JPG'den JPG'ye](https://products.aspose.app/slides/tr/collage/jpg) veya PNG'den PNG'ye görüntüleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve daha fazlasını yapabilirsiniz. 
{{% /alert %}}

## **SSS**

**Birleştirme sırasında konuşmacı notları korunur mu?**

Evet. Slaytları klonladığınızda Aspose.Slides, notlar, biçimlendirme ve animasyonlar dahil tüm slayt öğelerini aktarır.

**Yorumlar ve yazarları aktarılıyor mu?**

Yorumlar, slayt içeriğinin bir parçası olarak slaytla birlikte kopyalanır. Yorum yazar etiketleri, ortaya çıkan sunumda yorum nesneleri olarak korunur.

**Kaynak sunum şifre korumalıysa ne olur?**

[Şifreyle açılmalı](/slides/tr/python-net/password-protected-presentation/) ve [LoadOptions.password](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/password/) kullanılarak yüklenmelidir; yüklendikten sonra bu slaytlar korumasız bir hedef dosyaya (veya korumalı bir dosyaya da) güvenle klonlanabilir.

**Birleştirme işlemi ne kadar iş parçacığı güvenlidir?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneğini [birden fazla iş parçacığından](/slides/tr/python-net/multithreading/) kullanmayın. Önerilen kural “bir belge — bir iş parçacığı”dır; farklı dosyalar ayrı iş parçacıklarında paralel olarak işlenebilir.