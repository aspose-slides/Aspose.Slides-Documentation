---
title: C++ Kullanarak Sunumlarda Slayt Bölümlerini Yönetme
linktitle: Slayt Bölümü
type: docs
weight: 100
url: /tr/cpp/slide-section/
keywords:
- bölüm oluştur
- bölüm ekle
- bölümü düzenle
- bölümü değiştir
- bölüm adı
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument'teki slayt bölümlerini kolaylaştırın — bölümlerin ayrılmasını, yeniden adlandırılmasını ve yeniden sıralanmasını sağlayarak PPTX ve ODP iş akışlarını optimize edin."
---
## **Giriş**

Aspose.Slides for C++ ile bir PowerPoint sunumunu bölümlere ayırabilirsiniz. Belirli slaytları içeren bölümler oluşturabilirsiniz. 

Aşağıdaki durumlarda slaytları bir sunumda mantıksal parçalara ayırmak veya düzenlemek için bölümler oluşturmak isteyebilirsiniz:

- Büyük bir sunum üzerinde başkalarıyla veya bir ekipte çalışıyorsunuz ve belirli slaytları bir meslektaşınıza ya da ekip üyelerine atamanız gerekiyor. 
- Çok sayıda slayt içeren bir sunumla uğraşıyorsunuz ve içeriğini tek seferde yönetmek ya da düzenlemek zorlanıyorsunuz.

İdeal olarak, benzer slaytları barındıran bir bölüm oluşturmalısınız—slaytların ortak bir yanı vardır ya da bir kurala göre bir grup içinde bulunabilirler—ve bölüme içindeki slaytları tanımlayan bir ad vermelisiniz. 

## **Sunumlarda Bölüm Oluşturma**

Bir sunumda slaytları barındıracak bir bölüm eklemek için Aspose.Slides for C++ AddSection metodunu sunar; bu metod, oluşturmak istediğiniz bölümün adını ve bölümün başladığı slaytı belirtmenize olanak tanır. 

Bu örnek kod, C++'ta bir sunumda bölüm oluşturmayı gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1, newSlide2'de sonlandırılacak ve ardından section2 başlayacak   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## **Bölüm İsimlerini Değiştirme**

PowerPoint sunumunda bir bölüm oluşturduktan sonra, adını değiştirmeye karar verebilirsiniz. 

Bu örnek kod, Aspose.Slides kullanarak C++'ta bir sunumda bölüm adını nasıl değiştireceğinizi gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```

## **SSS**

**Bölümler, PPT (PowerPoint 97–2003) formatına kaydedildiğinde korunur mu?**

Hayır. PPT formatı bölüm meta verilerini desteklemez, bu nedenle .ppt olarak kaydedildiğinde bölüm gruplaması kaybolur.

**Bir bütün bölüm "gizli" yapılabilir mi?**

Hayır. Yalnızca tek tek slaytlar gizlenebilir. Bir bölüm bir varlık olarak "gizli" durumuna sahip değildir.

**Bir slayta göre bir bölümü hızlıca bulabilir miyim ve bunun tersine bir bölümün ilk slaytını bulabilir miyim?**

Evet. Bir bölüm, başlangıç slaytı ile benzersiz şekilde tanımlanır; bir slayt verildiğinde hangi bölüme ait olduğunu belirleyebilir ve bir bölüm için ilk slaytına erişebilirsiniz.