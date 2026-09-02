---
title: .NET'te Sunumlarda Slayt Bölümlerini Yönetme
linktitle: Slayt Bölümü
type: docs
weight: 100
url: /tr/net/slide-section/
keywords:
- bölüm oluştur
- bölüm ekle
- bölüm düzenle
- bölüm değiştir
- bölüm adı
- bölüm slaytlarını getir
- bölüm slaytlarını işle
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile slayt bölümlerini yönetin: PPTX sunumlarında bölümleri oluşturun, yeniden adlandırın, yeniden sıralayın, slaytları alın ve işleyin."
---
## **Giriş**

Bölümler, ardışık slaytları içeriklerini değiştirmeden adlandırılmış gruplara düzenler. Aspose.Slides for .NET ile bölümleri oluşturabilir, yeniden sıralayabilir, yeniden adlandırabilir, inceleyebilir ve [Presentation.Sections](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sections/) özelliği aracılığıyla silebilirsiniz.

Bölümler özellikle şu durumlarda faydalıdır:

- büyük bir sunumun mantıksal konulara veya bölümlere ayrılması gerekir;
- farklı slayt grupları farklı iş birliği yapanlara atanır;
- slaytların grup olarak işlenmesi, taşınması veya birleştirilmesi gerekir.

Gruplandırılmış slaytların amacını anlatan kısa bölüm adları seçin. Bölümler sunum yapısının bir parçası olduğundan, üyeliği slayt konumlarından türetmek yerine bölüm API'lerini kullanarak belirleyin.

## **Bölüm Oluşturma ve Yönetme**

[ISectionCollection.AddSection](https://reference.aspose.com/slides/tr/net/aspose.slides/sectioncollection/addsection/) kullanarak bir bölümü adı ve başlangıç slaytı belirterek oluşturabilirsiniz. Aspose.Slides, slaytların hangi bölüme ait olduğunu sunumun mevcut bölüm yapısından belirler.

Aynı [ISectionCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/isectioncollection/) ayrıca şunları yapmanızı sağlar:

- slaytlarıyla birlikte bir bölümü taşımak için [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/sectioncollection/reordersectionwithslides/) kullanın;
- sadece bölüm tanımını, slaytlarını koruyarak, [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/tr/net/aspose.slides/sectioncollection/removesection/) ile kaldırın;
- bölümü ve slaytlarını [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/sectioncollection/removesectionwithslides/) ile kaldırın;
- sonuna boş bir bölüm eklemek için [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/tr/net/aspose.slides/sectioncollection/appendemptysection/) kullanın.

Aşağıdaki örnek iki bölüm oluşturur, birini taşır, onu slaytlarıyla birlikte kaldırır ve boş bir bölüm ekler:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

Bu işlemlerden sonra sunum, slaytlarıyla birlikte `Introduction` bölümünü ve boş bir `Appendix` bölümünü içerir. `Results` bölümü ve slaytları kaldırılmıştır.

## **Bölüm Yeniden Adlandırma**

Bir bölümü yeniden adlandırmak için [ISection.Name](https://reference.aspose.com/slides/tr/net/aspose.slides/isection/name/) özelliğini ayarlayın. Bölümün slaytları ve konumu değişmeden kalır.

Aşağıdaki örnek bir bölüm oluşturur ve adını değiştirir:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Bölümlerden Slaytları Getirme**

[Presentation.Sections](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sections/) özelliği, üzerinde döngü kurabileceğiniz bir [ISectionCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/isectioncollection/) döndürür. Her bir [ISection](https://reference.aspose.com/slides/tr/net/aspose.slides/isection/) için, o anda ait olduğu slaytları almak üzere [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/tr/net/aspose.slides/isection/getslideslistofsection/) çağırın. Yöntem bir [ISectionSlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/isectionslidecollection/) döndürür; bu da sayım, indeksli erişim ve yineleme sağlar.

Aşağıdaki örnek iki doldurulmuş bölüm ve bir boş bölüm oluşturur, ardından her bölümün [name](https://reference.aspose.com/slides/tr/net/aspose.slides/isection/name/), [identifier](https://reference.aspose.com/slides/tr/net/aspose.slides/isection/sectionid/), [starting slide](https://reference.aspose.com/slides/tr/net/aspose.slides/isection/startedfromslide/), slayt sayısı ve slayt numaralarını yazdırır. İlk slaytı okumak için koleksiyon indeksleyicisini ve her slaytı işlemek için `foreach` kullanır. Boş bölüm için, döndürülen koleksiyonun sayısı sıfırdır, indeksleyici erişilmez ve yineleme hiçbir yineleme yapmaz.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

Bölüm üyeliği sunumun bölüm yapısına göre belirlenir. Bir bölümün aralığını [ISection.StartedFromSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/isection/startedfromslide/), slayt indeksleri ve sonraki bölümün başlangıç slaytından manuel olarak hesaplamayın.

Yapısal düzenlemeler bir bölüm için döndürülen slaytları ve slayt numaralarını değiştirebilir. Buna slaytların yeniden sıralanması, bir slaytın bir bölüme kopyalanması, bir bölümün slaytlarıyla birlikte taşınması, slaytların kaldırılması ve bölümlerin kaldırılması dahildir. Sonraki örnek, bu tür her değişiklikten sonra [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/tr/net/aspose.slides/isection/getslideslistofsection/) çağırır; önceki sınırlarla ilgili varsayımları tutmaz.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

Slaytlar veya bölümler yeniden sıralandığında, kopyalandığında, taşındığında veya kaldırıldığında [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/tr/net/aspose.slides/isection/getslideslistofsection/) tekrar çağırın. Bu, sonraki işlemlerin mevcut sunum yapısına uygun kalmasını sağlar.

PPT (PowerPoint 97–2003) formatı bölüm meta verilerini korumaz. Bu iş akışını bölümleri destekleyen bir formatta, örneğin PPTX'te kullanın; PPT'ye dönüştürmek, sonraki yineleme için gereken bölüm yapısını kaldırır.

## **SSS**

**PPT (PowerPoint 97–2003) formatına kaydedilirken bölümler korunur mu?**

Hayır. PPT formatı bölüm meta verilerini desteklemez, bu nedenle .ppt'ye kaydedildiğinde bölüm gruplaması kaybolur.

**Bir bölüm tamamen "gizlenebilir" mi?**

Hayır. Bir bölümün görünürlük durumu yoktur. İçeriğini gizlemek için, bölümdeki her slayt için [ISlide.Hidden](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/hidden/) özelliğini ayarlayın.

**Bir slaytı içeren bölümü nasıl bulabilirim?**

[Presentation.Sections](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sections/) üzerinde yineleme yapın, her bölüm için [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/tr/net/aspose.slides/isection/getslideslistofsection/) çağırın ve döndürülen slaytları hedef slaytla karşılaştırın. Boş olmayan bir bölümde, [ISection.StartedFromSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/isection/startedfromslide/) ilk slaytını döndürür; boş bir bölümde ise `null` döndürür.