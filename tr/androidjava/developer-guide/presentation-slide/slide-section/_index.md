---
title: Android'de Sunumlarda Slayt Bölümlerini Yönet
linktitle: Slayt Bölümü
type: docs
weight: 90
url: /tr/androidjava/slide-section/
keywords:
- bölüm oluştur
- bölüm ekle
- bölüm düzenle
- bölüm değiştir
- bölüm adı
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint ve OpenDocument'te slayt bölümlerini düzene sokun—bölün, yeniden adlandırın ve yeniden sıralayın; PPTX ve ODP iş akışlarını optimize edin."
---
## **Giriş**

Aspose.Slides for Android via Java ile bir PowerPoint Sunumunu bölümlere düzenleyebilirsiniz. Belirli slaytları içeren bölümler oluşturabilirsiniz.

Bu durumlarda, bir sunumdaki slaytları mantıksal parçalara düzenlemek veya bölmek için bölümler oluşturmak isteyebilirsiniz:

- Başkalarıyla veya bir ekipte büyük bir sunum üzerinde çalışırken—belirli slaytları bir meslektaşınıza veya bazı ekip üyelerine atamanız gerektiğinde. 
- Birçok slaytı içeren bir sunumla uğraşırken—içeriğini bir kerede yönetmek veya düzenlemek konusunda zorlanıyorsanız.

İdeal olarak, benzer slaytları barındıran bir bölüm oluşturmalısınız—slaytların ortak bir yanı vardır veya bir kurala göre bir grup içinde bulunabilir—ve bölüme içindeki slaytları tanımlayan bir ad vermelisiniz. 

## **Sunularda Bölüm Oluşturma**

Bir sunumda slaytları barındıracak bir bölüm eklemek için, Aspose.Slides for Android via Java, oluşturmak istediğiniz bölümün adını ve bölümün başladığı slaytı belirlemenizi sağlayan [addSection()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) metodunu sunar.

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
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1, newSlide2'de sonlandırılacak ve ardından section2 başlayacak   

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

## **Bölüm Adlarını Değiştirme**

PowerPoint sunumunda bir bölüm oluşturduktan sonra, adını değiştirmeye karar verebilirsiniz. 

Bu örnek kod, Aspose.Slides kullanarak Java'da bir sunumdaki bölümün adını nasıl değiştireceğinizi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**PPT (PowerPoint 97–2003) formatına kaydedildiğinde bölümler korunur mu?**

Hayır. PPT formatı bölüm meta verilerini desteklemez, bu nedenle .ppt olarak kaydedildiğinde bölüm gruplaması kaybolur.

**Bir bütün bölüm "gizli" yapılabilir mi?**

Hayır. Yalnızca tek tek slaytlar gizlenebilir. Bir bölüm bir varlık olarak "gizli" durumuna sahip değildir.

**Bir slayttan bölümü ve tersine, bir bölümün ilk slaytını hızlıca bulabilir miyim?**

Evet. Bir bölüm, başlangıç slaytı ile benzersiz şekilde tanımlanır; bir slayt verildiğinde hangi bölüme ait olduğunu belirleyebilir ve bir bölüm için ilk slaytına erişebilirsiniz.