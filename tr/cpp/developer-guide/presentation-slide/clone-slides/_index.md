---
title: C++'da Sunum Slaytlarını Klonla
linktitle: Slaytları Klonla
type: docs
weight: 40
url: /tr/cpp/clone-slides/
keywords:
- slaytı klonla
- slaytı kopyala
- slaytı kaydet
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint slaytlarını hızlı bir şekilde çoğaltın. Açık kod örneklerimizi izleyerek PPT oluşturmayı saniyeler içinde otomatikleştirin ve manuel işi ortadan kaldırın."
---
## **Giriş**

Klonlama, bir şeyin tam kopyasını ya da replikasını oluşturma sürecidir. Aspose.Slides for C++ ayrıca herhangi bir slaytı kopyalama veya klonlamayı ve ardından bu klonlanmış slaytı mevcut ya da başka bir açık sunuma eklemeyi mümkün kılar. Slayt klonlama işlemi, orijinal slaytı değiştirmeden geliştiricilerin değiştirebileceği yeni bir slayt oluşturur. Slayt klonlamanın birkaç olası yolu vardır:

- Sunum içinde sona kopyala.
- Sunum içinde başka bir konuma kopyala.
- Başka bir sunumun sonuna kopyala.
- Başka bir sunumda başka bir konuma kopyala.
- Başka bir sunumda belirli bir konuma kopyala.

Aspose.Slides for C++’de, [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesi tarafından sunulan (bir [ISlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/) nesneleri koleksiyonu) [AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) ve [InsertClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/insertclone/) metodlarını sağlar ve bu metodlar yukarıdaki slayt klonlama türlerini gerçekleştirir.

## **Sunumun Sonunda Bir Slaytı Kopyalama**
Aynı sunum dosyasında mevcut slaytların sonuna bir slaytı kopyalamak ve kullanmak istiyorsanız, aşağıdaki adımlara göre [AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) metodunu kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slides koleksiyonuna başvurarak [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) sınıfının bir örneğini oluşturun.  
3. [AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) metodunu çağırın ve klonlanacak slaytı parametre olarak verin.  
4. Değiştirilmiş sunum dosyasını yazın.

Aşağıdaki örnekte, bir sunumun ilk konumunda (sıfır indeks) bulunan bir slaytı sunumun sonuna kopyaladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Sunum içinde başka bir konuma slaytı kopyalama**
Aynı sunum dosyasında slaytı farklı bir konuma kopyalamak istiyorsanız, [InsertClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/insertclone/) metodunu kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. **Slides** koleksiyonuna başvurarak sınıfın bir örneğini oluşturun.  
3. [InsertClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/insertclone/) metodunu çağırın ve klonlanacak slaytı yeni konumun indeksiyle birlikte parametre olarak verin.  
4. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun sıfır indeksinde (konum 1) bulunan bir slaytı indeks 1 – Konum 2 –'ye kopyaladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Başka Bir Sunumun Sonuna Slaytı Kopyalama**
Bir slaytı bir sunumdan alıp başka bir sunumun mevcut slaytlarının sonuna eklemek istiyorsanız:

1. Kaynak slaytı içeren bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
3. Hedef sunumun **Slides** koleksiyonuna başvurarak [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) sınıfını örnekleyin.  
4. [AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) metodunu çağırın ve kaynak sunumdan slaytı parametre olarak verin.  
5. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun ilk indeksindeki bir slaytı hedef sunumun sonuna kopyaladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Başka Bir Sunumda Başka Bir Konuma Slaytı Kopyalama**
Bir slaytı bir sunumdan alıp başka bir sunumda belirli bir konuma eklemek istiyorsanız:

1. Kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
3. Hedef sunumun Slides koleksiyonuna başvurarak [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) sınıfını örnekleyin.  
4. [InsertClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/insertclone/) metodunu çağırın ve kaynak sunumdan slaytı, istenen konum indeksini parametre olarak verin.  
5. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir slaytı hedef sunumun indeks 1 (konum 2) konumuna kopyaladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Başka Bir Sunumda Belirli Bir Konuma Slaytı Kopyalama**
Bir slaytı ana slaytıyla birlikte bir sunumdan alıp başka bir sunuma eklemek istiyorsanız, önce istenen ana slaytı kaynak sunumdan hedefe kopyalamanız gerekir. Ardından bu ana slaytı kullanarak slaytı klonlayabilirsiniz. **AddClone(ISlide, IMasterSlide)**, kaynak sunumdan değil, hedef sunumdan bir ana slayt bekler. Ana slayt ile birlikte slaytı klonlamak için aşağıdaki adımları izleyin:

1. Kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
3. Klonlanacak slayta ve ona ait ana slayta erişin.  
4. Hedef sunumun Masters koleksiyonuna başvurarak [IMasterSlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/) sınıfını örnekleyin.  
5. [AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) metodunu [IMasterSlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/) nesnesi üzerinde çağırın ve kaynak PPTX’ten klonlanacak ana slaytı parametre olarak verin.  
6. Hedef sunumun Slides koleksiyonuna başvurarak [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) sınıfını örnekleyin.  
7. [AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) metodunu [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) nesnesi üzerinde çağırın ve kaynak sunumdan slaytı ve ana slaytı parametre olarak verin.  
8. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir slaytı ve ona ait ana slaytı kullanarak hedef sunumun sonuna kopyaladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Belirli Bir Bölümün Sonuna Slaytı Kopyalama**
Aynı sunum içinde farklı bir bölüme slaytı kopyalamak istiyorsanız, [**AddClone()**](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) metodunu [**ISlideCollection**](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) arayüzünden kullanın. Aspose.Slides for C++ bir slaytı ilk bölümden klonlamayı ve ardından klonlanmış slaytı aynı sunumun ikinci bölümüne eklemeyi mümkün kılar.

Aşağıdaki kod parçası, bir slaytı klonlayıp belirli bir bölüme eklemenizi gösterir.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Slayt Boyutunun Eşleştiğinden Emin Olun**

Başka bir sunuma slaytları klonlarken, hedef sunumun slayt boyutunun kaynakla aynı olduğundan emin olun. Boyutlar farklıysa, Aspose.Slides klonlanmış şekillerin ölçeğini otomatik olarak ayarlamaz—orijinal koordinat ve boyutları korunur, bu da içeriğin kayma ya da slayt sınırlarının dışına taşmasına neden olabilir.

Klonlamadan önce hedef sunumun slayt boyutunu kaynakla eşleştirebilirsiniz:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

Bunu, ana slaytı ve slaytı klonlamadan önce yapın.

## **SSS**

**Konuşmacı notları ve inceleme yorumları kopyalanır mı?**  
Evet. Notlar sayfası ve inceleme yorumları klona dahil edilir. İstemiyorsanız, eklemeden sonra [silin](/slides/tr/cpp/presentation-notes/).

**Grafikler ve veri kaynakları nasıl ele alınır?**  
Grafik nesnesi, biçimlendirmesi ve gömülü verileri kopyalanır. Grafik dış bir kaynağa (ör. OLE gömülü çalışma kitabı) bağlanmışsa, bu bağlantı bir [OLE nesnesi](/slides/tr/cpp/manage-ole/) olarak korunur. Dosyalar arasında taşındıktan sonra veri erişilebilirliğini ve yenileme davranışını doğrulayın.

**Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?**  
Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçilen bir [bölüm](/slides/tr/cpp/slide-section/) içine yerleştirebilirsiniz. Hedef bölüm yoksa, önce oluşturun ve ardından slaytı o bölüme taşıyın.