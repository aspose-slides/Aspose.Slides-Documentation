---
title: Python ile Sunumlarda Slayt Bölümlerini Yönet
linktitle: Slayt Bölümü
type: docs
weight: 100
url: /tr/python-net/slide-section/
keywords:
- bölüm oluştur
- bölüm ekle
- bölümü düzenle
- bölümü değiştir
- bölüm adı
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python ile PowerPoint ve OpenDocument'teki slayt bölümlerini kolaylaştırın — bölümleri ayırın, yeniden adlandırın ve yeniden sıralayın, PPTX ve ODP iş akışlarını optimize edin."
---
## **Giriş**

Aspose.Slides for Python ile PowerPoint sunumunu belirli slaytları gruplayan bölümlere düzenleyebilirsiniz.

Bu durumlarda, bir sunumu mantıksal parçalara düzenlemek veya bölmek için bölümler oluşturmak isteyebilirsiniz:

- Büyük bir sunum üzerinde bir ekip ile çalışırken ve belirli slaytları belirli çalışanlara atamanız gerektiğinde.
- Çok sayıda slayt içeren bir sunumla uğraşırken ve her şeyi bir anda yönetmek veya düzenlemek zor geldiğinde.

İdeal olarak, ilgili slaytları—tema, konu veya amacını paylaşanları—grupleyen bölümler oluşturun ve her bölüme içeriğini açıkça yansıtan bir ad verin. 

## **Sunumlarda Bölüm Oluşturma**

Bir sunumdaki slaytları gruplayan bir [Section](https://reference.aspose.com/slides/tr/python-net/aspose.slides/section/) eklemek için Aspose.Slides, [add_section](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sectioncollection/add_section/) metodunu sağlar. Bu metod, bölüm adını ve bölümün başladığı slaytı belirtmenize olanak tanır.

Aşağıdaki Python örneği, bir sunumda bölüm oluşturmanın nasıl yapılacağını gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # Bölüm 1 slide2'de sona erer; Bölüm 2 slide3'te başlar.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **Bölüm Adlarını Değiştirme**

PowerPoint sunumunda bir [Section](https://reference.aspose.com/slides/tr/python-net/aspose.slides/section/) oluşturduktan sonra, adını değiştirmeye karar verebilirsiniz.

Aşağıdaki Python örneği, bir sunumda bölümün adını nasıl yeniden adlandıracağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **SSS**

**PPT (PowerPoint 97–2003) formatına kaydederken bölümler korunur mu?**

Hayır. PPT formatı bölüm meta verilerini desteklemez, bu nedenle .ppt olarak kaydedildiğinde bölüm gruplaması kaybolur.

**Bir bütün bölüm "gizli" yapılabilir mi?**

Hayır. Yalnızca tek tek slaytlar gizlenebilir. Bir bölüm bir varlık olarak "gizli" durumuna sahip değildir.

**Bir slayt üzerinden hızlıca bölüm bulabilir miyim ve tersine, bir bölümün ilk slaytını bulabilir miyim?**

Evet. Bir bölüm, başlangıç slaytı ile benzersiz şekilde tanımlanır; bir slayt verildiğinde hangi bölüme ait olduğunu belirleyebilir ve bir bölüm için ilk slaytına erişebilirsiniz.