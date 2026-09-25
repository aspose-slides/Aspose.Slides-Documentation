---
title: Java'da Sunum Erişilebilirliğini Yönetme
linktitle: Sunum Erişilebilirliği
type: docs
weight: 30
url: /tr/java/presentation-accessibility/
keywords:
- sunum erişilebilirliği
- alternatif metin
- alternatif metin başlığı
- alternatif metin açıklaması
- dekoratif olarak işaretle
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'ın PPT, PPTX ve ODP dosyalarındaki sunum erişilebilirliği kontrollerini otomatikleştirmeye nasıl yardımcı olduğunu keşfedin—ekran okuyucu deneyimini iyileştirin ve uyumluluğu artırın."
---
## **Giriş**

Alternatif metin, yardımcı teknolojileri kullanan kişilerin görsellerin, çizelgelerin ve diğer bilgilendirici şekillerin anlamını anlamalarına yardımcı olur. Bu makale, Aspose.Slides for Java ile alternatif metin başlıklarını ve açıklamalarını nasıl okuyup güncelleyebileceğinizi, erişilebilirlik açıklamalarını kodda kullanılan şekil adlarından nasıl ayıracağınızı ve bir şeklin dekoratif olarak işaretlenip işaretlenmediğini nasıl kontrol edeceğinizi açıklar.

Bu özellikler sunum erişilebilirliğini destekler, ancak bunu garanti etmez. Okuma sırası, renk kontrastı, metin okunabilirliği ve diğer erişilebilirlik gereksinimleri de gözden geçirilmelidir.

## **Alternatif Metin Başlıklarını ve Açıklamalarını Yönetme**

Alternatif metni, görsellerin, çizelgelerin ve diğer bilgilendirici şekillerin anlamını göremeyen kişilere açıklamak için kullanın. Aşağıdaki yöntemler ve içerikler farklı amaçlar taşır:

| Yöntem veya içerik | Amaç |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Alternatif açıklama için kısa bir başlık. |
| [getAlternativeText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getAlternativeText--) | Slayt bağlamında şeklin içeriği veya amacı hakkında anlamlı bir açıklama. |
| [getName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getName--) | Şeklin adı, kodun sunum içinde belirli bir şekli bulmak için kullanabileceği. |
| Görünür metin | Slaytta görüntülenen içerik, örneğin bir şeklin metni ya da bir çizelgenin başlığı ve etiketleri. Alternatif metni güncellemek bu içeriği değiştirmez. |

Bir sunum şablon olarak yeniden kullanıldığında, kod [getName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getName--) tarafından döndürülen adı bulup şekli güncelleyebilir. Bu ad, görselin okuyucuya ilettiği şeyi açıklayan alternatif metinden farklı bir amaca hizmet eder. İsme göre arama, yazarların kodun şekli bulma şeklini değiştirmeden açıklamaları iyileştirmesine veya çevirmesine olanak tanır. İsimler düzenlenebilir ve benzersiz olması garanti edilmez; bu nedenle adın hedef şekille eşleştiğini kontrol edin; bakınız [Şekilleri Tanımlama ve Bulma](/slides/tr/java/shape-manipulations/#identify-and-find-shapes).

Aşağıdaki örnek, ilk slayttaki ilk şekil olarak bir ofis girişinin resmini içeren `input.pptx` dosyasını gerektirir. Resim dekoratif olarak işaretlenmemiş olmalıdır. Örnek, mevcut alternatif metin başlığını ve açıklamasını okur ve ekrana yazdırır, her iki değeri günceller ve sunumu `output.pptx` olarak kaydeder. Kelimeleri gerçek resim ve ilettiği bilgiye göre uyarlayın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sadece alternatif metin eklemek, sunum erişilebilirliğini veya erişilebilirlik standartlarına uygunluğu garanti etmez. Açıklamaların doğruluğunu ve alâkasını gözden geçirin ve ayrıca okuma sırasını, renk kontrastını, okunabilir metni ve diğer erişilebilirlik gereksinimlerini kontrol edin. Bilgilendirici görseller dekoratif olarak işaretlenmemelidir; bir sonraki bölümde [isDecorative](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#isDecorative--) nasıl kontrol edileceği gösterilir.

## **Dekoratif Olarak İşaretleme**

Dekoratif olarak işaretleme, sadece süs amaçlı görselleri ekran okuyucularının atlamasını sağlar, böylece gürültü azalır ve odak anlamlı içeriğe yönelir. Bu işareti arka planlar, süslemeler ve boşluk doldurucular için uygulayın—hiçbir zaman bilgi taşıyan çizelgeler, simgeler veya resimler için kullanmayın. Aspose.Slides bu bayrağı algılamak ve doğrulamak için sunar, otomatik erişilebilirlik kontrolleri ve temizlik imkanı sağlar.

![Dekoratif Olarak İşaretle](mark_as_decorative.png)

Aşağıdaki kod örneği bir şeklin dekoratif olarak işaretlenip işaretlenmediğini belirlemeyi gösterir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **SSS**

**Alternatif metin başlığı ve açıklamasına ne koymalıyım?**

Konu başlığını tanımlayan kısa bir başlık ve görselin slayt bağlamında ne iletiyorsa açıklayan bir açıklama kullanın. Bir çizelge için sadece “çizelge” demek yerine ilgili eğilim ya da karşılaştırmayı açıklayın.

**Şablonda şekilleri bulmak için alternatif metni kullanmalı mıyım?**

Şekli [getName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getName--) tarafından döndürülen ad ile bulmayı ve beklenen şekil olduğundan emin olmayı tercih edin. Alternatif metin düzenlenebilir veya çevrilebilir, bu da tam açıklamayı arayan kodu bozabilir; bakınız [Şekilleri Tanımlama ve Bulma](/slides/tr/java/shape-manipulations/).

**Bir şekil ne zaman dekoratif olarak işaretlenmelidir?**

Bilgi eklemeyen süs amaçlı görseller için dekoratif bayrağı kullanın. Anlam taşıyan resim ve çizelgeler uygun bir açıklama almalıdır.

**Alternatif metin eklemek bir sunumu tamamen erişilebilir kılar mı?**

Hayır. Alternatif metin yalnızca erişilebilirliğin bir parçasını kapsar. Okuma sırası, renk kontrastı, metin okunabilirliği ve diğer geçerli gereksinimler de incelenmelidir; bu özellikleri ayarlamak tek başına uyumluluğu sağlamaz.