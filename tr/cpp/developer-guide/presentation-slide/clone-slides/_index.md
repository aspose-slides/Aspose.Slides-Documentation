---
title: C++'ta Sunum Slaytlarını Klonla
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
description: "Aspose.Slides for C++ ile PowerPoint slaytlarını hızlı bir şekilde çoğaltın. Saniyeler içinde PPT oluşturmayı otomatikleştirmek ve manuel çalışmayı ortadan kaldırmak için net kod örneklerimizi izleyin."
---
## **Giriş**

Klonlama, bir şeyin tam bir kopyasını veya benzesini oluşturma sürecidir. Aspose.Slides for C++ ayrıca herhangi bir slaytın bir kopyasını veya klonunu oluşturmayı ve ardından bu klonlanmış slaytı mevcut veya başka bir açık sunuma eklemeyi mümkün kılar. Slayt klonlama süreci, orijinal slaytı değiştirmeden geliştiriciler tarafından değiştirilebilecek yeni bir slayt oluşturur. Bir slaytı klonlamanın birkaç olası yolu vardır:

- Sunum içinde sona klonla.
- Sunum içinde başka bir konuma klonla.
- Başka bir sunumda sona klonla.
- Başka bir sunumda başka bir konuma klonla.
- Başka bir sunumda belirli bir konuma klonla.

Aspose.Slides for C++’de, [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesi tarafından ortaya çıkarılan (a collection of [ISlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/) objects) [AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) ve [InsertClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/insertclone/) metodlarını sağlar ve yukarıdaki slayt klonlama türlerini gerçekleştirir.

## **Bir Sunumun Sonuna Slaytı Klonlamak**
Aynı sunum dosyasında mevcut slaytların sonuna bir slaytı klonlamak ve kullanmak istiyorsanız, aşağıdaki adımlara göre [AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) metodunu kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slides koleksiyonuna başvurarak [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) sınıfını örnekleyin; bu koleksiyon [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesi tarafından ortaya çıkar.
1. [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) nesnesi tarafından ortaya çıkarılan [AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) methodunu çağırın ve klonlanacak slaytı parametre olarak gönderin.
1. Değiştirilmiş sunum dosyasını yazın.

Aşağıdaki örnekte, sunumun ilk konumundaki (sıfır indeks) bir slaytı sunumun sonuna klonladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Bir Sunum İçinde Başka Bir Konuma Slayt Klonlamak**
Aynı sunum dosyasında slaytı farklı bir konuma klonlayıp kullanmak istiyorsanız, [InsertClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/insertclone/) methodunu kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. **Slides** koleksiyonuna başvurarak sınıfı örnekleyin; bu koleksiyon [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesi tarafından ortaya çıkar.
1. [InsertClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/insertclone/) methodunu [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) nesnesi üzerinden çağırın ve klonlanacak slaytı yeni konumun indeksiyle birlikte parametre olarak gönderin.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun sıfır indeksindeki (konum 1) bir slaytı indeks 1 – konum 2 ‑ye klonladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Başka Bir Sunumun Sonuna Slaytı Klonlamak**
Bir sunumdan bir slaytı klonlayıp başka bir sunuma, mevcut slaytların sonuna eklemek istiyorsanız:

1. Kaynak slaytın bulunduğu bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Hedef sunumun bulunduğu bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesi tarafından ortaya çıkarılan **Slides** koleksiyonuna başvurarak [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) sınıfını örnekleyin.
1. [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) nesnesi üzerinden [AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) methodunu çağırın ve kaynak sunumdan gelen slaytı parametre olarak gönderin.
1. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun ilk indeksindeki bir slaytı hedef sunumun sonuna klonladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Başka Bir Sunumda Başka Bir Konuma Slaytı Klonlamak**
Bir sunumdan bir slaytı başka bir sunuma belirli bir konuma klonlamak istiyorsanız:

1. Kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesi tarafından ortaya çıkarılan Slides koleksiyonuna başvurarak [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) sınıfını örnekleyin.
1. [InsertClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/insertclone/) methodunu [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) nesnesi üzerinden çağırın ve kaynak sunumdan gelen slaytı istenen konumla birlikte parametre olarak gönderin.
1. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir slaytı hedef sunumun indeks 1 (konum 2) ‑ne klonladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Başka Bir Sunumda Belirli Bir Konuma Slaytı Klonlamak**
Bir slaytı, master slaytıyla birlikte bir sunumdan başka bir sunuma klonlamanız gerekiyorsa, önce istenen master slaytı kaynak sunumdan hedef sunuma klonlamalısınız. Ardından bu master slaytı, master slaytı olan slaytı klonlamak için kullanmalısınız. **AddClone(ISlide, IMasterSlide)** hedef sunumdan bir master slaytı bekler; kaynak sunumdan değil. Master slaytıyla birlikte slaytı klonlamak için aşağıdaki adımları izleyin:

1. Kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Klonlanacak slaytı ve master slaytı erişin.
1. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesi tarafından ortaya çıkarılan Masters koleksiyonuna başvurarak [IMasterSlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/) sınıfını örnekleyin.
1. [IMasterSlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/) nesnesi üzerinden [AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) methodunu çağırın ve kaynak PPTX’den klonlanacak masterı parametre olarak gönderin.
1. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesi tarafından ortaya çıkarılan Slides koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) sınıfını örnekleyin.
1. [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) nesnesi üzerinden [AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) methodunu çağırın ve kaynak sunumdan gelen slaytı ve master slaytı parametre olarak gönderin.
1. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki master slaytıyla birlikte bir slaytı, master slaytı kaynak slayttan alarak hedef sunumun sonuna klonladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Belirtilen Bir Bölümün Sonuna Slaytı Klonlamak**
Aynı sunum dosyasında slaytı farklı bir bölüme klonlamak istiyorsanız, [**AddClone()**](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) methodunu [**ISlideCollection**](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) arayüzü üzerinden kullanın. Aspose.Slides for C++ bir slaytı ilk bölümden klonlamayı ve ardından bu klonlanmış slaytı aynı sunumun ikinci bölümüne eklemeyi mümkün kılar.

Aşağıdaki kod örneği, bir slaytı klonlayıp belirtilen bir bölüme eklemenizi gösterir.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **SSS**

**Konuşmacı notları ve gözden geçiren yorumlar klonlanır mı?**

Evet. Not sayfası ve inceleme yorumları klona dahil edilir. İstemiyorsanız, eklemeden sonra [kaldırın](/slides/tr/cpp/presentation-notes/).

**Grafikler ve veri kaynakları nasıl işlenir?**

Grafik nesnesi, biçimlendirme ve gömülü veri kopyalanır. Grafik dış bir kaynağa (ör. OLE‑gömülü bir çalışma kitabı) bağlanmışsa, bu bağlantı bir [OLE nesnesi](/slides/tr/cpp/manage-ole/) olarak korunur. Dosyalar arasında taşındıktan sonra veri kullanılabilirliğini ve yenileme davranışını doğrulayın.

**Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?**

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve istediğiniz bir [bölüme](/slides/tr/cpp/slide-section/) taşıyabilirsiniz. Hedef bölüm mevcut değilse, önce bölümü oluşturun ve ardından slaytı oraya taşıyın.