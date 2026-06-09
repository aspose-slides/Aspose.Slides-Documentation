---
title: Java Kullanarak Sunumlarda Slayt Bölümlerini Yönetme
linktitle: Slayt Bölümü
type: docs
weight: 90
url: /tr/java/slide-section/
keywords:
- bölüm oluştur
- bölüm ekle
- bölüm düzenle
- bölüm değiştir
- bölüm adı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument'teki slayt bölümlerini düzenleyin — böl, yeniden adlandır ve yeniden sırala, PPTX ve ODP iş akışlarını optimize edin."
---
## **Giriş**

Aspose.Slides for Java ile bir PowerPoint Sunumunu bölümlere ayırabilirsiniz. Belirli slaytları içeren bölümler oluşturabilirsiniz. 

Bu durumlarda, bir sunumdaki slaytları mantıksal parçalara ayırmak veya düzenlemek için bölümler oluşturmak isteyebilirsiniz:

- Diğer kişiler veya bir ekip ile büyük bir sunum üzerinde çalışıyorsanız ve belirli slaytları bir meslektaşınıza veya ekip üyelerine atamanız gerekiyorsa. 
- Birçok slayt içeren bir sunumla uğraşıyorsanız ve içeriğini tek seferde yönetmek veya düzenlemek zor geliyorsa.

İdeal olarak, benzer slaytları barındıran bir bölüm oluşturmalısınız—slaytların ortak bir özelliği vardır ya da bir kurala göre bir grup içinde bulunabilir—ve bölüme içindeki slaytları tanımlayan bir ad vermelisiniz. 

## **Sunumlarda Bölüm Oluşturma**

Bir sunumda slaytları barındıracak bir bölüm eklemek için, Aspose.Slides for Java, oluşturmak istediğiniz bölümün adını ve bölümün başladığı slaytı belirtmenizi sağlayan [addSection()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) yöntemini sunar. 

Bu örnek kod, Java'da bir sunumda bölüm oluşturmayı gösterir:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1, newSlide2'de sona erecek ve ardından section2 başlayacak   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bölüm İsimlerini Değiştirme**

PowerPoint sunumunda bir bölüm oluşturduktan sonra, adını değiştirmeye karar verebilirsiniz. 

Bu örnek kod, Aspose.Slides kullanarak Java'da bir sunumda bölümün adını nasıl değiştireceğinizi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**PPT (PowerPoint 97–2003) formatına kaydederken bölümler korunur mu?**

Hayır. PPT formatı bölüm meta verilerini desteklemediği için .ppt olarak kaydedildiğinde bölüm gruplaması kaybolur.

**Bir bütün bölüm "gizli" yapılabilir mi?**

Hayır. Sadece tek tek slaytlar gizlenebilir. Bir bölüm bir varlık olarak "gizli" bir duruma sahip değildir.

**Bir slayta göre bir bölümü ve tersine bir bölümün ilk slaytını hızlıca bulabilir miyim?**

Evet. Bir bölüm, başlangıç slaytı ile benzersiz olarak tanımlanır; bir slayt verildiğinde hangi bölüme ait olduğunu belirleyebilir ve bir bölüm için ilk slaytına erişebilirsiniz.