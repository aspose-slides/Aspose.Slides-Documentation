---
title: Android'de Sunumlardan Slaytları Kaldırma
linktitle: Slaytı Kaldır
type: docs
weight: 30
url: /tr/androidjava/remove-slide-from-presentation/
keywords:
- slaytı kaldır
- slaytı sil
- kullanılmayan slaytı kaldır
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PowerPoint ve OpenDocument sunumlarından slaytları zahmetsizce kaldırın. Net Java kod örnekleri alın ve iş akışınızı hızlandırın."
---
## **Giriş**

Bir slayt (veya içeriği) gereksiz hâle gelirse, silebilirsiniz. Aspose.Slides, bir sunumdaki tüm slaytların deposu olan [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/) i kapsayan [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfını sağlar. Bilinen bir [ISlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/) nesnesi için işaretçiler (referans veya indeks) kullanarak, kaldırmak istediğiniz slaytı belirtebilirsiniz.

## **Referans ile Slayt Kaldırma**

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Kaldırmak istediğiniz slaytın kimliği veya indeksi aracılığıyla bir referans alın.
1. Referans alınan slaytı sunumdan kaldırın.
1. Değiştirilmiş sunumu kaydedin. 

Bu Java kodu, bir slaytı referansı aracılığıyla nasıl kaldıracağınızı gösterir:

```java
// Bir sunum dosyasını temsil eden Presentation nesnesini örnekleyin
Presentation pres = new Presentation("demo.pptx");
try {
    // Slayt koleksiyonundaki indeksine göre bir slayta erişir
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Bir slaytı referansı aracılığıyla kaldırır
    pres.getSlides().remove(slide);
    
    // Değiştirilmiş sunumu kaydeder
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **İndeks ile Slayt Kaldırma**

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slaytı, indeks konumu üzerinden sunumdan kaldırın.
1. Değiştirilmiş sunumu kaydedin. 

Bu Java kodu, bir slaytı indeksi aracılığıyla nasıl kaldıracağınızı gösterir:

```java
// Bir sunum dosyasını temsil eden Presentation nesnesini oluşturur
Presentation pres = new Presentation("demo.pptx");
try {
    // Bir slaytı slayt indeksine göre kaldırır
    pres.getSlides().removeAt(0);
    
    // Değiştirilmiş sunumu kaydeder
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Kullanılmayan Layout Slaytlarını Kaldırma**

Aspose.Slides, istenmeyen ve kullanılmayan layout slaytlarını silmenizi sağlayan [Compress](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/) sınıfındaki [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) yöntemini sunar. Bu Java kodu, bir PowerPoint sunumundan layout slaytını nasıl kaldıracağınızı gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kullanılmayan Master Slaytlarını Kaldırma**

Aspose.Slides, istenmeyen ve kullanılmayan master slaytlarını silmenizi sağlayan [Compress](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/) sınıfındaki [removeUnusedMasterSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) yöntemini sunar. Bu Java kodu, bir PowerPoint sunumundan master slaytını nasıl kaldıracağınızı gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **SSS**

**Bir slaytı sildikten sonra slayt indeksleri ne olur?**

Silme işleminden sonra, [collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidecollection/) yeniden indekslenir: sonraki her slayt bir pozisyon sola kayar, bu nedenle önceki indeks numaraları artık geçerli olmaz. Sabit bir referansa ihtiyacınız varsa, indeks yerine her slaytın kalıcı kimliğini (ID) kullanın.

**Bir slaytın ID'si indeksten farklı mı ve komşu slaytlar silindiğinde değişir mi?**

Evet. İndeks, slaytın konumudur ve slaytlar eklendiğinde veya silindiğinde değişir. Slayt ID'si kalıcı bir tanımlayıcıdır ve diğer slaytlar silinse de değişmez.

**Bir slaytı silmek slayt bölümlerini nasıl etkiler?**

Slayt bir bölüme aitse, o bölüm bir slayt daha az içerir. Bölüm yapısı korunur; eğer bir bölüm boşalırsa, ihtiyacınıza göre [bölümleri kaldırabilir veya yeniden düzenleyebilirsiniz](/slides/tr/androidjava/slide-section/).

**Bir slayt silindiğinde ona ekli notlar ve yorumlar ne olur?**

[Notes](/slides/tr/androidjava/presentation-notes/) ve [comments](/slides/tr/androidjava/presentation-comments/) o belirli slayta bağlıdır ve slaytla birlikte kaldırılır. Diğer slaytlardaki içerik etkilenmez.

**Slayt silme ile kullanılmayan layout/master temizleme arasındaki fark nedir?**

Silme işlemi, desteden belirli normal slaytları kaldırır. Kullanılmayan layout/master temizleme ise, hiçbir şey tarafından referans verilen layout veya master slaytları kaldırarak dosya boyutunu azaltır ve kalan slayt içeriğini değiştirmez. Bu işlemler birbirini tamamlayıcı niteliktedir: genellikle önce silme, ardından temizleme yapılır.