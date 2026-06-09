---
title: C++ Kullanarak Sunumlarda SmartArt Grafiklerini Yönetme
linktitle: SmartArt Grafikler
type: docs
weight: 20
url: /tr/cpp/manage-smartart-shape/
keywords:
- SmartArt nesnesi
- SmartArt grafiği
- SmartArt stili
- SmartArt rengi
- SmartArt oluştur
- SmartArt ekle
- SmartArt düzenle
- SmartArt değiştir
- SmartArt eriş
- SmartArt yerleşim tipi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++ içinde PowerPoint SmartArt oluşturma, düzenleme ve stil verme işlemlerini otomatikleştirin; kısa kod örnekleri ve performansa odaklı rehberlik sunar."
---
## **Genel Bakış**

Aspose.Slides size PowerPoint sunumlarında programlı olarak SmartArt grafikleri oluşturma ve yönetme imkanı sağlar. Bu makale bir slayta SmartArt şekli ekleme, mevcut SmartArt şekillerine erişme, belirli bir düzen türüne göre SmartArt bulma ve SmartArt stilini veya renk stilini değiştirerek görsel görünümünü güncelleme konularını açıklar.

Örnekler, sunum slaytının şekil koleksiyonu aracılığıyla SmartArt şekilleriyle nasıl çalışılacağını, bir şeklin SmartArt olup olmadığını nasıl kontrol edileceğini ve ardından özelliklerini nasıl değiştirebileceğinizi veya inceleyebileceğinizi gösterir.

## **SmartArt Şekli Oluşturma**
Aspose.Slides for C++ artık slaytlara sıfırdan özel SmartArt şekilleri eklemeyi kolaylaştırıyor. Aspose.Slides for C++ en basit API'yi sağlayarak SmartArt şekillerini en kolay şekilde oluşturmanıza olanak tanır. Bir slaytta SmartArt şekli oluşturmak için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- `Index` kullanarak bir slaydın referansını alın.
- LayoutType ayarlayarak bir SmartArt şekli ekleyin.
- Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **Bir Slayttaki SmartArt Şekline Erişme**
Aşağıdaki kod, sunum slaytına eklenen SmartArt şekillerine erişmek için kullanılacaktır. Örnek kodda slayt içindeki her şekli dolaşacak ve bunun SmartArt şekli olup olmadığını kontrol edeceğiz. Şekil SmartArt tipindeyse, onu SmartArt örneğine dönüştüreceğiz.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Belirli Bir Düzen Türüne Sahip SmartArt Şekline Erişme**
İşte aşağıdaki örnek kod, belirli bir LayoutType'a sahip SmartArt şekline erişmenize yardımcı olur. Lütfen SmartArt'ın LayoutType'ını değiştirmenin mümkün olmadığını, bunun yalnızca SmartArt şekli eklenirken ayarlandığını ve yalnızca okunabilir olduğunu unutmayın.

- `Presentation` sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.
- `Index` kullanarak ilk slaydın referansını alın.
- İlk slayttaki her şekli dolaşın.
- Şeklin SmartArt tipi olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli SmartArt'a dönüştürün.
- Belirli LayoutType'a sahip SmartArt şekli kontrol edin ve ardından gerekli işlemleri yapın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **SmartArt Şekli Stilini Değiştirme**
Aşağıdaki örnek kod, belirli bir LayoutType'a sahip SmartArt şekline erişmenize yardımcı olur.

- `Presentation` sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.
- `Index` kullanarak ilk slaydın referansını alın.
- İlk slayttaki her şekli dolaşın.
- Şeklin SmartArt tipi olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli SmartArt'a dönüştürün.
- Belirli bir Stil'e sahip SmartArt şekli bulun.
- SmartArt şekli için yeni Stili ayarlayın.
- Sunumu kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **SmartArt Şekli Renk Stilini Değiştirme**
Bu örnekte, herhangi bir SmartArt şeklinin renk stilini değiştirmeyi öğreneceğiz. Aşağıdaki örnek kod, belirli bir renk stiline sahip SmartArt şekline erişecek ve stilini değiştirecektir.

- `Presentation` sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.
- `Index` kullanarak ilk slaydın referansını alın.
- İlk slayttaki her şekli dolaşın.
- Şeklin SmartArt tipi olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli SmartArt'a dönüştürün.
- Belirli bir Renk Stiline sahip SmartArt şekli bulun.
- SmartArt şekli için yeni Renk Stilini ayarlayın.
- Sunumu kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **SSS**

**SmartArt'ı tek bir nesne olarak canlandırabilir miyim?**  
Evet. SmartArt bir şekildir, bu nedenle diğer şekillerde olduğu gibi animasyon API'si aracılığıyla [standard animations](/slides/tr/cpp/powerpoint-animation/) (giriş, çıkış, vurgu, hareket yolları) uygulayabilirsiniz.

**Bir slayttaki belirli bir SmartArt'ı iç ID'sini bilmiyorum, nasıl bulabilirim?**  
Alternative Text (AltText) ayarlayın ve bu değere göre şekli arayın—bu, hedef şekli bulmanın önerilen bir yoludur.

**SmartArt'ı diğer şekillerle gruplayabilir miyim?**  
Evet. SmartArt'ı diğer şekillerle (resimler, tablolar vb.) gruplayabilir ve ardından [grubu manipüle](/slides/tr/cpp/group/) edebilirsiniz.

**Belirli bir SmartArt'ın (ör. ön izleme veya rapor için) görüntüsünü nasıl alırım?**  
Şeklin bir küçük resim/görselini dışa aktarın; kütüphane, bireysel şekilleri raster dosyalara (PNG/JPG/TIFF) [render individual shapes](/slides/tr/cpp/create-shape-thumbnails/) edebilir.

**Tüm sunumu PDF'ye dönüştürürken SmartArt görünümü korunacak mı?**  
Evet. Render motoru, [PDF export](/slides/tr/cpp/convert-powerpoint-to-pdf/) için yüksek doğruluk hedefler ve çeşitli kalite ve uyumluluk seçenekleri sunar.