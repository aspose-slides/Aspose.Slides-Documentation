---
title: JavaScript Kullanarak Sunumlarda Slayt Bölümlerini Yönetme
linktitle: Slayt Bölümü
type: docs
weight: 90
url: /tr/nodejs-java/slide-section/
keywords:
- bölüm oluştur
- bölüm ekle
- bölüm düzenle
- bölüm değiştir
- bölüm adı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile PowerPoint ve OpenDocument'teki slayt bölümlerini düzenleyin — bölümlerinizi ayırın, yeniden adlandırın ve yeniden sıralayın, PPTX ve ODP iş akışlarını optimize edin."
---
## **Giriş**

Aspose.Slides for Node.js via Java kullanarak bir PowerPoint Sunumunu bölümlere düzenleyebilirsiniz. Belirli slaytları içeren bölümler oluşturabilirsiniz.

Bu durumlarda, bir sunumdaki slaytları mantıksal parçalara ayırmak veya düzenlemek için bölümler oluşturmak isteyebilirsiniz:

- Diğer kişilerle veya bir ekiple büyük bir sunum üzerinde çalışırken ve belirli slaytları bir meslektaşınıza ya da ekip üyelerine atamanız gerektiğinde. 
- Birçok slayt içeren bir sunumla uğraşırken ve içeriğini bir kerede yönetmek ya da düzenlemek konusunda zorlanıyorsanız.

İdeal olarak, benzer slaytları barındıran bir bölüm oluşturmalısınız—slaytların ortak bir özelliği vardır ya da bir kurala göre gruplanabilir—ve bölüme içindeki slaytları tanımlayan bir ad vermelisiniz. 

## **Sunumlarda Bölüm Oluşturma**

Bir sunumda slaytları barındıracak bir bölüm eklemek için, Aspose.Slides for Node.js via Java, oluşturmak istediğiniz bölümün adını ve bölümün başlayacağı slaytı belirtmenizi sağlayan [addSection()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) metodunu sunar.

Bu örnek kod, JavaScript'te bir sunumda bölüm oluşturmayı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 newSlide2'de sona erecek ve ardından section2 başlayacak
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bölüm İsimlerini Değiştirme**

PowerPoint sunumunda bir bölüm oluşturduktan sonra, adını değiştirmeye karar verebilirsiniz. 

Bu örnek kod, Aspose.Slides kullanarak JavaScript'te bir sunumda bölümün adını nasıl değiştireceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Bölümler PPT (PowerPoint 97–2003) formatına kaydedildiğinde korunur mu?**

Hayır. PPT formatı bölüm meta verilerini desteklemez, bu yüzden .ppt olarak kaydedildiğinde bölüm gruplaması kaybolur.

**Tüm bir bölüm "gizli" yapılabilir mi?**

Hayır. Yalnızca tek tek slaytlar gizlenebilir. Bir bölüm bir varlık olarak "gizli" durumuna sahip değildir.

**Bir slayta göre bir bölümü ve tersine bir bölümün ilk slaydını hızlıca bulabilir miyim?**

Evet. Bir bölüm, başlangıç slaytı ile benzersiz şekilde tanımlanır; bir slayt verildiğinde hangi bölüme ait olduğunu belirleyebilir ve bir bölüm için ilk slaydına erişebilirsiniz.