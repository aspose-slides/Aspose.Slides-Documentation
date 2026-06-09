---
title: .NET'te Sunumlarda Slayt Bölümlerini Yönetme
linktitle: Slayt Bölümü
type: docs
weight: 100
url: /tr/net/slide-section/
keywords:
- bölüm oluştur
- bölüm ekle
- bölümü düzenle
- bölümü değiştir
- bölüm adı
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument'teki slayt bölümlerini kolaylaştırın — bölümlerinizi bölün, yeniden adlandırın ve yeniden sıralayın, PPTX ve ODP iş akışlarını optimize edin."
---
## **Giriş**

Aspose.Slides for .NET ile bir PowerPoint Sunumunu bölümlere ayırabilirsiniz. Belirli slaytları içeren bölümler oluşturabilirsiniz.

Bu durumlarda, slaytları mantıksal parçalara ayırmak veya düzenlemek için bölümler oluşturmak isteyebilirsiniz:

- Diğer kişilerle veya bir ekipyle büyük bir sunum üzerinde çalışıyorsanız—belirli slaytları bir meslektaşınıza veya ekip üyelerine atamanız gerekiyorsa. 
- Çok sayıda slayt içeren bir sunumla uğraşıyorsanız—içeriğini tek seferde yönetmek veya düzenlemek zorlanıyorsanız.

İdeal olarak, benzer slaytları barındıran bir bölüm oluşturmalısınız—slaytların ortak bir özelliği vardır veya bir kurala göre bir grup içinde bulunabilir—ve bölüme içinde yer alan slaytları tanımlayan bir ad vermelisiniz.

## **Sunumlarda Bölüm Oluşturma**

Bir sunumda slaytları barındıracak bir bölüm eklemek için, Aspose.Slides for .NET AddSection metodunu sunar; bu metod, oluşturmak istediğiniz bölümün adını ve bölümün başladığı slaytı belirtmenizi sağlar.

Bu örnek kod, C# ile bir sunumda bölüm oluşturmayı gösterir:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1, newSlide2'de sona erecek ve ardından section2 başlayacak   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## **Bölüm İsimlerini Değiştirme**

PowerPoint sunumunda bir bölüm oluşturduktan sonra, adını değiştirmeye karar verebilirsiniz.

Bu örnek kod, Aspose.Slides kullanarak C# ile bir sunumda bölümün adını nasıl değiştireceğinizi gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```

## **SSS**

**PPT (PowerPoint 97–2003) formatına kaydederken bölümler korunur mu?**

Hayır. PPT formatı bölüm üst verisini desteklemez, bu nedenle .ppt olarak kaydedildiğinde bölüm gruplaması kaybolur.

**Bir bütün bölüm "gizli" yapılabilir mi?**

Hayır. Yalnızca tek tek slaytlar gizlenebilir. Bir bölüm, bir varlık olarak "gizli" durumuna sahip değildir.

**Bir slayttan bir bölümü ve tersine bir bölümün ilk slaytını hızlıca bulabilir miyim?**

Evet. Bir bölüm, başlangıç slaytı ile benzersiz olarak tanımlanır; bir slayt verildiğinde hangi bölüme ait olduğunu belirleyebilir ve bir bölüm için ilk slaytına erişebilirsiniz.