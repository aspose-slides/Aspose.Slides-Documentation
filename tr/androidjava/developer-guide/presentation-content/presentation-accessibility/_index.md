---
title: Android'de Sunum Erişilebilirliğini Yönet
linktitle: Sunum Erişilebilirliği
type: docs
weight: 30
url: /tr/androidjava/presentation-accessibility/
keywords:
- sunum erişilebilirliği
- alternatif metin
- alternatif metin başlığı
- alternatif metin açıklaması
- dekoratif olarak işaretle
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'un PPT, PPTX ve ODP dosyalarındaki sunum erişilebilirliği kontrollerini otomatikleştirmenize nasıl yardımcı olduğunu keşfedin—ekran okuyucu deneyimini geliştirin ve uyumluluğu artırın."
---
## **Giriş**

Alternatif metin, yardımcı teknolojileri kullanan kişilerin resimlerin, grafiklerin ve diğer bilgilendirici şekillerin anlamını anlamalarına yardımcı olur. Bu makale, Aspose.Slides for Android via Java ile alternatif metin başlıklarını ve açıklamalarını nasıl okuyup güncelleyeceğinizi, erişilebilirlik açıklamalarını kodda kullanılan şekil adlarından nasıl ayıracağınızı ve bir şeklin dekoratif olarak işaretlenip işaretlenmediğini nasıl kontrol edeceğinizi açıklar.

Bu özellikler sunum erişilebilirliğini destekler, ancak bunu garanti etmez. Okuma sırası, renk kontrastı, metin okunabilirliği ve diğer erişilebilirlik gereksinimleri de incelenmelidir.

## **Alternatif Metin Başlıklarını ve Açıklamalarını Yönetme**

Alternatif metni, resimlerin, grafiklerin ve diğer bilgilendirici şekillerin anlamını göremeyen kişelere açıklamak için kullanın. Aşağıdaki yöntemler ve içerikler farklı amaçlar için hizmet verir:

| Yöntem veya içerik | Amaç |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Alternatif açıklama için kısa bir başlık. |
| [getAlternativeText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | Şeklin içeriğinin veya amacının slayt bağlamındaki anlamlı açıklaması. |
| [getName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getName--) | Kodun sunum içinde belirli bir şekli bulmak için kullanabileceği şekil adı. |
| Görünür metin | Şeklin metni veya bir grafiğin başlığı ve etiketleri gibi slaytta gösterilen içerik. Alternatif metni güncellemek bu içeriği değiştirmez. |

Bir sunum şablon olarak yeniden kullanıldığında, kod [getName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getName--) tarafından döndürülen adı bulup şekli güncelleyebilir. Bu ad, görselin okuyucuya ne iletiğini açıklayan alternatif metinden farklı bir amaca hizmet eder. Ad üzerinden arama, yazarların açıklamaları değiştirmesine veya çevirmesine izin verirken kodun şekli bulma şekli değişmez. İsimler düzenlenebilir ve benzersiz olması garanti edilmez; bu nedenle ismin hedef şekil ile eşleştiğini kontrol edin; bkz. [Identify and Find Shapes](/slides/tr/androidjava/shape-manipulations/#identify-and-find-shapes).

Aşağıdaki örnek, ilk slaydın ilk şekli olarak ofis girişinin bir resmi bulunan `input.pptx` dosyasını gerektirir. Görsel dekoratif olarak işaretlenmemiş olmalıdır. Örnek, mevcut alternatif metin başlığını ve açıklamasını okur, ikisini de günceller ve sunumu `output.pptx` olarak kaydeder. Kelimeleri gerçek görsele ve ilettiği bilgiye göre uyarlayın.

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

Sadece alternatif metin eklemek, sunum erişilebilirliğini veya erişilebilirlik standartlarına uyumu garanti etmez. Açıklamaların doğruluğunu ve alaka düzeyini gözden geçirin, ayrıca okuma sırasını, renk kontrastını, okunabilir metni ve diğer erişilebilirlik gereksinimlerini kontrol edin. Bilgilendirici görseller dekoratif olarak işaretlenmemelidir; bir sonraki bölümde [isDecorative](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#isDecorative--) nasıl kontrol edilir gösterilir.

## **Dekoratif Olarak İşaretle**

Dekoratif olarak işaretle, sadece süs amaçlı görselleri işaretleyerek ekran okuyucuların bunları atlamasını sağlar, böylece gereksiz gürültü azalır ve anlamlı içeriğe odaklanılır. Arka planlar, süslemeler ve boşluk doldurucular için uygulanır—grafikler, simgeler veya bilgi ileten resimler için asla uygulanmaz. Aspose.Slides bu bayrağı tespit ve doğrulama için sunar, otomatik erişilebilirlik kontrolleri ve temizlik imkanı verir.

![Dekoratif Olarak İşaretle](mark_as_decorative.png)

Aşağıdaki kod örneği bir şeklin dekoratif olarak işaretlenip işaretlenmediğini nasıl belirleyeceğinizi gösterir.

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

Konu başlığını tanımlayan kısa bir başlık ve görselin slayt bağlamında ilettiği bilgiyi açıklayan bir açıklama kullanın. Bir grafik için yalnızca “grafik” demek yerine ilgili eğilim ya da karşılaştırmayı tanımlayın.

**Şablonda şekilleri bulmak için alternatif metni kullanmalı mıyım?**

Şekli, [getName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getName--) tarafından döndürülen adla bulmayı ve bunun beklenen şekil olduğundan emin olmayı tercih edin. Alternatif metin düzenlenebilir veya çevrilebilir, bu da tam açıklama arayan kodu bozabilir; bkz. [Identify and Find Shapes](/slides/tr/androidjava/shape-manipulations/).

**Bir şekil ne zaman dekoratif olarak işaretlenmeli?**

Bilgi katmayan, yalnızca süs amaçlı görseller için dekoratif bayrağını kullanın. Anlam taşıyan resimler ve grafikler uygun bir açıklama gerektirir.

**Alternatif metin eklemek bir sunumu tamamen erişilebilir kılar mı?**

Hayır. Alternatif metin sadece erişilebilirliğin bir kısmını ele alır. Okuma sırası, renk kontrastı, metin okunabilirliği ve diğer geçerli gereksinimler de gözden geçirilmelidir; bu özelliklerin yalnızca ayarlanması uyumluluğu sağlamaz.